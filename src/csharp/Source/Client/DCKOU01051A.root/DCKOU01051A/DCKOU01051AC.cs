# region ※using
using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
//using Broadleaf.Windows.Forms;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
# endregion

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 請求先確認アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 請求確認画面用のデータ検索等を行います。</br>
	/// <br>Programmer	: 21024　佐々木 健</br>
	/// <br>Date		: 2007.09.28</br>
    /// <br></br>
    /// <br>Update Note : 2008.04.24 20056 對馬 大輔</br>
    ///	<br>			・PM.NS 共通修正 得意先・仕入先分離対応</br>
    ///	<br>			・PM.NS 共通修正 拠点制御設定マスタ削除対応</br>
	/// <br></br>
	/// <br>Update Note : 2008.05.29 21024 佐々木 健</br>
	///	<br>			・起動時にエラーが出るので修正</br>
	/// <br></br>
	/// <br>Update Note : 2008.07.07 21024 佐々木 健</br>
	///	<br>			・全体設定マスタ系の読み込みを修正</br>
    /// <br></br>
    /// <br>Update Note : 2008.09.05 21024 佐々木 健</br>
    ///	<br>			・電話番号、FAX番号を表示できるように修正</br>
    /// <br></br>
    /// <br>Update Note : 2009.01.31 21024 佐々木 健</br>
    ///	<br>			・仕入金額処理区分設定、売上金額処理区分設定マスタの読み込み方法を修正</br>
    /// </remarks>
	public class CustomerClaimConfAcs
	{
		# region ■Private Member

		private string _enterpriseCode;						// 企業コード
		private string _loginSectionCode;					// 自拠点コード

		private CustomerClaimConf _customerClaimConf;		// 請求確認画面データクラス
        //private StockProcMoney _stockProcMoney;				// 仕入金額処理区分設定(消費税用)   // 2009.01.31 Del
        private TaxRateSet _taxRateSet;						// 税率設定
		private AllDefSet _allDefSet;						// 全体初期値設定
		private StockTtlSt _stockTtlSt;						// 仕入全体設定
        //private SalesProcMoney _salesProcMoney;				// 売上金額処理区分設定(消費税用)   // 2009.01.31 Del
		private CustomerChange _customerChange;				// 得意先変動情報
        private AlItmDspNm _alItmDspNm;                     // 全体項目表示名称マスタ

		private PaymentSlpSearch _paymentSlpSearch;			// 支払情報検索アクセスクラス
		private InputDepositNormalTypeAcs _inputDepositNormalTypeAcs;	// 入金アクセスクラス
        private CustomerInfoAcs _customerInfoAcs;			// 得意先アクセスクラス // ADD 2008.04.24
        private SupplierAcs _supplierAcs;                   // 仕入先アクセスクラス
		private CustomerChangeAcs _customerChangeAcs;		// 得意先変動情報アクセスクラス
        private AlItmDspNmAcs _alItmDspNmAcs;               // 全体項目表示名称アクセスクラス     // 2008.09.05 Add
		private static SecInfoAcs _secInfoAcs;				// 拠点アクセスクラス
        // 2009.01.31 Add >>>
        private StockProcMoneyAcs _stockProcMoneyAcs;       // 仕入金額処理区分設定マスタアクセスクラス
        private SalesProcMoneyAcs _salesProcMoneyAcs;       // 売上金額処理区分設定マスタアクセスクラス
        private ClaimConfDataSet _claimConfDataSet;         // 金額処理区分設定マスタキャッシュ用データセット
        // 2009.01.31 Add <<<
        // 2008.05.29 Update >>>
		//private bool _isLocalDBRead = true;
		private bool _isLocalDBRead = false;

		// 2008.05.29 Update <<<

        bool _readPaymentInitData = false;
        bool _readClaimInitData = false;

		private GuideType _guideType = GuideType.Claim;		// ガイドモード

		private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";
		private const string ctSection_All = "00";			// 全社設定用拠点コード  2008.07.07 Add
		
		# endregion

		#region ■Enums
		/// <summary>
		/// 起動タイプ
		/// </summary>
		public enum GuideType : int
		{
			/// <summary>請求</summary>
			Claim = 1,
			/// <summary>支払</summary>
			Payment = 2
		}
		#endregion

		# region ■Constracter
		/// <summary>
		/// 請求確認画面アクセスクラス コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 請求確認画面アクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 21024　佐々木 健</br>
		/// <br>Date       : 2007.09.28</br>
		/// </remarks>
		public CustomerClaimConfAcs()
		{
			// 企業コードを取得する
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// 自拠点コードを取得する
			this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

			// 各アクセスクラスのインスタンス化
			this._customerInfoAcs = new CustomerInfoAcs();
            this._supplierAcs = new SupplierAcs(); // ADD 2008.04.24
			this._customerClaimConf = new CustomerClaimConf();
			this._paymentSlpSearch = new PaymentSlpSearch();
			this._inputDepositNormalTypeAcs = new InputDepositNormalTypeAcs();
			this._customerChangeAcs = new CustomerChangeAcs();
            this._alItmDspNmAcs = new AlItmDspNmAcs(); // 2008.09.05 Add
            // 2009.01.31 Add >>>
            this._salesProcMoneyAcs = new SalesProcMoneyAcs();
            this._stockProcMoneyAcs = new StockProcMoneyAcs();
            this._claimConfDataSet = new ClaimConfDataSet();
            // 2009.01.31 Add <<<

			// 各種情報の初期化(検索済み判断に使用するのでインスタンス化しない)
			this._stockTtlSt = null;
            //this._stockProcMoney = null;  // 2009.01.31 Del
			this._taxRateSet = null;
			this._allDefSet = null;
            //this._salesProcMoney = null;  // 2009.01.31 Del
			this._customerChange = null;
            this._alItmDspNm = null;
		}
		# endregion

		#region■Properies
		/// <summary>ガイドモードプロパティ</summary>
		public GuideType Mode
		{
			set { this._guideType = value; }
			get { return this._guideType; }
		}

		/// <summary>請求確認画面データオブジェクトプロパティ</summary>
		public CustomerClaimConf CustomerClaimConf
		{
			set { this._customerClaimConf = value; }
			get { return this._customerClaimConf; }
		}

		/// <summary>得意先変動情報データオブジェクトプロパティ</summary>
		public CustomerChange CustomerChange
		{
			set { this._customerChange = value; }
			get { return this._customerChange; }
		}

		/// <summary>ローカルDB読み込みモードプロパティ</summary>
		public bool IsLocalDBRead
		{
			// 2008.05.29 Update >>>
			//set { this._isLocalDBRead = true; }
			set { this._isLocalDBRead = value; }
			// 2008.05.29 Update <<<
			get { return this._isLocalDBRead; }
		}
		#endregion

		#region■Public Method
        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 得意先読み込み処理
        ///// </summary>
        ///// <param name="customerCode">得意先コード</param>
        ///// <param name="customerInfo">得意先情報オブジェクト</param>
        ///// <param name="custSuppli">得意先仕入情報オブジェクト</param>
        ///// <param name="customerChange">得意先変動情報オブジェクト</param>
        ///// <returns>読み込みステータス</returns>
        //public int ReadCustomer(int customerCode, out CustomerInfo customerInfo, out CustSuppli custSuppli, out CustomerChange customerChange)
        //{
        //    return this.ReadCustomerProc(customerCode, out customerInfo, out custSuppli, out customerChange);
        //}
        /// <summary>
        /// 得意先読み込み処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerInfo">得意先情報オブジェクト</param>
        /// <param name="customerChange">得意先変動情報オブジェクト</param>
        /// <returns>読み込みステータス</returns>
        public int ReadCustomer(int customerCode, out CustomerInfo customerInfo, out CustomerChange customerChange)
        {
            return this.ReadCustomerProc(customerCode, out customerInfo, out customerChange);
        }
        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 仕入先読み込み処理
        /// </summary>
        /// <param name="supplierCode"></param>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public int ReadSupplier(int supplierCode, out Supplier supplier)
        {
            return this.ReadSupplierProc(supplierCode, out supplier);
        }
        // ADD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// データキャッシュ処理
        ///// </summary>
        ///// <param name="customerInfo">得意先情報オブジェクト</param>
        ///// <param name="custSuppli">得意先仕入情報オブジェクト</param>
        ///// <param name="customerChange">得意先変動情報オブジェクト</param>
        ///// <param name="salesDate">売上日</param>
        ///// <param name="addUpdate">計上日付</param>
        ///// <param name="delayPaymentDiv">来勘区分</param>
        ///// <param name="reCalcAddUpDate">True:計上日を再計算する</param>
        //public void Cache( CustomerInfo customerInfo, CustSuppli custSuppli, CustomerChange customerChange, DateTime salesDate, DateTime addUpdate, int delayPaymentDiv, bool reCalcAddUpDate )
        //{
        //    this.cacheProc(customerInfo, custSuppli, customerChange, salesDate, addUpdate, delayPaymentDiv, reCalcAddUpDate);
        //}
        /// <summary>
        /// 得意先情報データキャッシュ処理
        /// </summary>
        /// <param name="customerInfo">得意先情報オブジェクト</param>
        /// <param name="customerChange">得意先変動情報オブジェクト</param>
        /// <param name="salesDate">売上日</param>
        /// <param name="addUpdate">計上日付</param>
        /// <param name="delayPaymentDiv">来勘区分</param>
        /// <param name="reCalcAddUpDate">True:計上日を再計算する</param>
        public void CacheCustomer(CustomerInfo customerInfo, CustomerChange customerChange, DateTime salesDate, DateTime addUpdate, int delayPaymentDiv, bool reCalcAddUpDate)
        {
            this.CacheCustomerProc(customerInfo, customerChange, salesDate, addUpdate, delayPaymentDiv, reCalcAddUpDate);
        }
        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 仕入先情報データキャッシュ処理
        /// </summary>
        /// <param name="supplier">仕入先情報オブジェクト</param>
        /// <param name="stockDate">仕入日</param>
        /// <param name="addUpdate">計上日</param>
        /// <param name="delayPaymentDiv">来勘区分</param>
        /// <param name="reCalcAddUpDate">計上日を再計算する</param>
        public void CacheSupplier(Supplier supplier, DateTime stockDate, DateTime addUpdate, int delayPaymentDiv, bool reCalcAddUpDate)
        {
            this.CacheSupplierProc(supplier, stockDate, addUpdate, delayPaymentDiv, reCalcAddUpDate);
        }
        // ADD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// 初期データ取得処理
		/// </summary>
		public void InitialSearch()
		{
			switch (this._guideType)
			{
				case GuideType.Claim:  // 請求
					{
						this.ReadClaimInitData();
						break;
					}
				case GuideType.Payment: // 支払
					{
						this.ReadPaymentInitData();
						break;
					}
			}
            this.ReadAlItmDspNmAcs();   // 2008.09.05 Add
		}

      
		# endregion

		#region ■Private Method

		/// <summary>
		/// 拠点制御アクセスクラスインスタンス化処理
		/// </summary>
		private void CreateSecInfoAcs()
		{
			if (_secInfoAcs == null)
			{
				_secInfoAcs = ( this._isLocalDBRead ) ? new SecInfoAcs((int)SecInfoAcs.SearchMode.Local) : new SecInfoAcs((int)SecInfoAcs.SearchMode.Remote);
			}

			// ログイン担当拠点情報の取得
			if (_secInfoAcs.SecInfoSet == null)
			{
				throw new ApplicationException(MESSAGE_NONOWNSECTION);
			}
		}

        // DEL 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 制御機能拠点取得処理
        ///// <br>SecInfoAcs.CtrlFuncCode(SFKTN01210A)の詳細は以下の通り。</br>
        ///// <br>・OwnSecSetting = 自拠点設定</br>
        ///// <br>・DemandAddUpSecCd = 請求計上拠点</br>
        ///// <br>・ResultsAddUpSecCd = 実績計上拠点</br>
        ///// <br>・BillSettingSecCd = 請求設定拠点</br>
        ///// <br>・BalanceDispSecCd = 残高表示拠点</br>
        ///// <br>・PayAddUpSecCd = 支払計上拠点</br>
        ///// <br>・PayAddUpSetSecCd = 支払設定拠点</br>
        ///// <br>・PayBlcDispSecCd = 支払残高表示拠点</br>
        ///// <br>・StockUpdateSecCd = 在庫更新拠点</br>
        ///// </summary>
        ///// <param name="sectionCode">対象拠点コード</param>
        ///// <param name="ctrlFuncCode">取得する制御機能コード</param>
        ///// <param name="ctrlSectionCode">対象制御拠点コード</param>
        ///// <param name="ctrlSectionName">対象制御拠点名称</param>
        //private int GetOwnSeCtrlCode( string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode, out string ctrlSectionCode, out string ctrlSectionName )
        //{
        //    // 拠点制御アクセスクラスインスタンス化処理
        //    this.CreateSecInfoAcs();

        //    // 対象制御拠点の初期値はログイン担当拠点
        //    ctrlSectionCode = sectionCode.TrimEnd();
        //    ctrlSectionName = "";

        //    SecInfoSet secInfoSet;
        //    int status = _secInfoAcs.GetSecInfo(sectionCode, ctrlFuncCode, out secInfoSet);

        //    switch (status)
        //    {
        //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //            {
        //                if (secInfoSet != null)
        //                {
        //                    ctrlSectionCode = secInfoSet.SectionCode.Trim();
        //                    ctrlSectionName = secInfoSet.SectionGuideNm.Trim();
        //                }
        //                else
        //                {
        //                    // 拠点制御設定がされていない
        //                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //                }
        //                break;
        //            }
        //        default:
        //            {
        //                break;
        //            }
        //    }

        //    return status;
        //}
        // DEL 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2008.09.05 Add >>>
        /// <summary>
        /// 全体項目表示名称マスタを読み込みます
        /// </summary>
        private void ReadAlItmDspNmAcs()
        {
            this._alItmDspNmAcs.Read(out this._alItmDspNm, this._enterpriseCode);
        }
        // 2008.09.05 Add <<<

		/// <summary>
		/// 支払モード用初期データ読み込み処理
		/// </summary>
		private void ReadPaymentInitData()
		{
            if (_readPaymentInitData) return;

			int status;		// 2008.07.07 Add
			// 仕入全体設定
			if (this._stockTtlSt == null)
			{
				StockTtlStAcs stockTtlStAcs = new StockTtlStAcs();

				// 2008.07.07 Update >>>
				//stockTtlStAcs.Read(out this._stockTtlSt, this._enterpriseCode);

				ArrayList retStockTtlStList;
				status = stockTtlStAcs.SearchAll(out retStockTtlStList, this._enterpriseCode);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					StockTtlSt secStockTtlSt = null;
					StockTtlSt allSecStockTtlSt = null;
					foreach (StockTtlSt stockTtlSt in retStockTtlStList)
					{
						if (stockTtlSt.SectionCode.Trim() == this._loginSectionCode.Trim())
						{
							secStockTtlSt = stockTtlSt;
							break;
						}
						else if (stockTtlSt.SectionCode.Trim() == ctSection_All)
						{
							allSecStockTtlSt = stockTtlSt;
						}
					}
					if (allSecStockTtlSt != null) this._stockTtlSt = allSecStockTtlSt; 
					if (secStockTtlSt != null) this._stockTtlSt = secStockTtlSt;
				}
				// 2008.07.07 Update <<<
			}

			// 仕入金額処理区分
            // 2009.01.31 Del >>>
            //if (this._stockProcMoney == null)
            //{
            //    StockProcMoneyAcs stockProcMoneyAcs = new StockProcMoneyAcs();
            //    stockProcMoneyAcs.Read(out this._stockProcMoney, this._enterpriseCode, 1, 0, 999999999);
            //}
            this.SearchStockProckMoney();
            // 2009.01.31 Del <<<

            // 2008.05.29 Add >>>
			// 税率設定マスタ読み込み
			if (this._taxRateSet == null)
			{
				TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();

				TaxRateSetAcs.SearchMode taxRateSearchMode = ( this._isLocalDBRead ) ? TaxRateSetAcs.SearchMode.Local : TaxRateSetAcs.SearchMode.Remote;
				taxRateSetAcs.Read(out this._taxRateSet, this._enterpriseCode, 0, taxRateSearchMode);
			}

			// 全体初期値設定
			if (this._allDefSet == null)
			{
				AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
				AllDefSetAcs.SearchMode allDefSetSearchMode = ( this._isLocalDBRead ) ? AllDefSetAcs.SearchMode.Local : AllDefSetAcs.SearchMode.Remote;
				// 2008.07.07 Update >>>
				//allDefSetAcs.Read(out this._allDefSet, this._enterpriseCode, this._loginSectionCode, allDefSetSearchMode);

				ArrayList retAllDefSetList;
				status = allDefSetAcs.Search(out retAllDefSetList, this._enterpriseCode);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					AllDefSet secAllDefSet = null;
					AllDefSet allSecAllDefSet = null;
					foreach (AllDefSet allDefSet in retAllDefSetList)
					{
						if (allDefSet.SectionCode.Trim() == this._loginSectionCode.Trim())
						{
							secAllDefSet = allDefSet;
							break;
						}
						else if (allDefSet.SectionCode.Trim() == ctSection_All)
						{
							allSecAllDefSet = allDefSet;
						}
					}
					if (allSecAllDefSet != null) this._allDefSet = allSecAllDefSet;
					if (secAllDefSet != null) this._allDefSet = secAllDefSet;
				}
				// 2008.07.07 Update <<<
			}
			// 2008.05.29 Add <<<

            this._readPaymentInitData = true;// 2009.01.31 Add
		}

		/// <summary>
		/// 請求モード用初期データ読み込み処理
		/// </summary>
		private void ReadClaimInitData()
		{
            if (this._readClaimInitData) return;    // 2009.01.31 Add
			int status = 0;		// 2008.07.07 Add
			// 税率設定マスタ読み込み
			if (this._taxRateSet == null)
			{
				TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();

				TaxRateSetAcs.SearchMode taxRateSearchMode = ( this._isLocalDBRead ) ? TaxRateSetAcs.SearchMode.Local : TaxRateSetAcs.SearchMode.Remote;
				taxRateSetAcs.Read(out this._taxRateSet, this._enterpriseCode, 0, taxRateSearchMode);
			}

			// 全体初期値設定
			if (this._allDefSet == null)
			{
				AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
				AllDefSetAcs.SearchMode allDefSetSearchMode = ( this._isLocalDBRead ) ? AllDefSetAcs.SearchMode.Local : AllDefSetAcs.SearchMode.Remote;

				// 2008.07.07 Update >>>
				//allDefSetAcs.Read(out this._allDefSet, this._enterpriseCode, this._loginSectionCode, allDefSetSearchMode);

				ArrayList retAllDefSetList;
				status = allDefSetAcs.Search(out retAllDefSetList, this._enterpriseCode);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					AllDefSet secAllDefSet = null;
					AllDefSet allSecAllDefSet = null;
					foreach (AllDefSet allDefSet in retAllDefSetList)
					{
						if (allDefSet.SectionCode.Trim() == this._loginSectionCode.Trim())
						{
							secAllDefSet = allDefSet;
							break;
						}
						else if (allDefSet.SectionCode.Trim() == ctSection_All)
						{
							allSecAllDefSet = allDefSet;
						}
					}
					if (allSecAllDefSet != null) this._allDefSet = allSecAllDefSet;
					if (secAllDefSet != null) this._allDefSet = secAllDefSet;
				}
				// 2008.07.07 Update <<<
			}

            // 2009.01.31 >>>
            //// 売上金額処理区分設定
            //if (this._salesProcMoney == null)
            //{
            //    SalesProcMoneyAcs salesProcMoneyAcs = new SalesProcMoneyAcs();
            //    salesProcMoneyAcs.IsLocalDBRead = this._isLocalDBRead;
            //    salesProcMoneyAcs.Read(out this._salesProcMoney, this._enterpriseCode, 1, 0, 999999999);
            //}

            this.SearchSalesProckMoney();

            this._readClaimInitData = true; 
            // 2009.01.31 <<<
        }

        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 得意先・得意先仕入情報読み込み処理
        ///// </summary>
        ///// <param name="customerCode">得意先コード</param>
        ///// <param name="customerInfo">得意先情報</param>
        ///// <param name="custSuppli">得意先仕入情報</param>
        ///// <param name="customerChange">得意先変動情報</param>
        ///// <returns></returns>
        //private int ReadCustomerProc( int customerCode, out CustomerInfo customerInfo, out CustSuppli custSuppli, out CustomerChange customerChange )
        //{
        //    custSuppli = null;
        //    customerInfo = null;
        //    customerChange = null;
        //    if (customerCode == 0)
        //    {
        //        return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    switch (this.Mode)
        //    {
        //        case GuideType.Claim:
        //            {
        //                this.ReadClaimInitData();
        //                int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerCode, out customerInfo);

        //                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    return status;
        //                }
        //                // 業販先以外は得意先情報をクリアする
        //                if (customerInfo.AcceptWholeSale != 1)
        //                {
        //                    customerInfo = null;
        //                }

        //                if (customerInfo.CreditMngCode != 0)
        //                {
        //                    this._customerChangeAcs.Read(out customerChange, this._enterpriseCode, customerCode);
        //                }

        //                break;
        //            }
        //        case GuideType.Payment:
        //            {
        //                this.ReadPaymentInitData();
        //                int status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerCode, true, out customerInfo, out custSuppli);
        //                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    return status;
        //                }
        //                break;
        //            }
        //    }

        //    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //}
        /// <summary>
        /// 得意先・得意先仕入情報読み込み処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerInfo">得意先情報</param>
        /// <param name="customerChange">得意先変動情報</param>
        /// <returns></returns>
        private int ReadCustomerProc(int customerCode, out CustomerInfo customerInfo, out CustomerChange customerChange)
        {
            customerInfo = null;
            customerChange = null;
            if (customerCode == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            switch (this.Mode)
            {
                case GuideType.Claim:
                    {
                        this.ReadClaimInitData();
                        int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerCode, out customerInfo);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                        // 業販先以外は得意先情報をクリアする
                        if (customerInfo.AcceptWholeSale != 1)
                        {
                            customerInfo = null;
                        }

                        if (customerInfo.CreditMngCode != 0)
                        {
                            this._customerChangeAcs.Read(out customerChange, this._enterpriseCode, customerCode);
                        }

                        break;
                    }
                case GuideType.Payment:
                    {
                        break;
                    }
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 仕入先情報読み込み処理
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <param name="supplier">仕入先情報</param>
        /// <returns></returns>
        private int ReadSupplierProc(int supplierCode, out Supplier supplier)
        {
            supplier = null;
            if (supplierCode == 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            switch (this.Mode)
            {
                case GuideType.Claim:
                    {
                        break;
                    }
                case GuideType.Payment:
                    {
                        this.ReadPaymentInitData();
                        int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, supplierCode);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                        break;
                    }
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        // ADD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
#if false
        ///// <summary>
        ///// データキャッシュ処理
        ///// </summary>
        ///// <param name="customerInfo">得意先情報クラス</param>
        ///// <param name="custSuppli">得意先仕入情報クラス</param>
        ///// <param name="customerChange">得意先変動情報</param>
        ///// <param name="salesDate">売上日付</param>
        ///// <param name="addUpdate">計上日付</param>
        ///// <param name="delayPaymentDiv">来勘区分</param>
        ///// <param name="reCalcAddUpDate">計上日を再計算する</param>
        //private void cacheProc( CustomerInfo customerInfo, CustSuppli custSuppli, CustomerChange customerChange, DateTime salesDate, DateTime addUpdate, int delayPaymentDiv, bool reCalcAddUpDate )
        //{

        //    this._customerChange = ( customerChange == null ) ? new CustomerChange() : customerChange.Clone();

        //    switch (this.Mode)
        //    {
        //        case GuideType.Claim:
        //            {
        //                if (customerInfo == null)
        //                {
        //                    this._customerClaimConf = new CustomerClaimConf();
        //                    return;
        //                }

        //                // 得意先情報クラスからのセット(共通項目)
        //                this.SetCustomerClaimConfFromCustomerInfo_Common(ref this._customerClaimConf, customerInfo);

        //                this._customerClaimConf.TotalDay = customerInfo.TotalDay;
        //                this._customerClaimConf.NTimeCalcStDate = customerInfo.NTimeCalcStDate;

        //                // 得意先マスタの消費税転嫁方式参照区分が
        //                // ｢1:仕入先参照」の場合は得意先マスタの「消費税転嫁方式」を設定する
        //                // ｢0:全体設定参照」の場合は税率設定マスタの「消費税転嫁方式」を設定する
        //                if (customerInfo.CustCTaXLayRefCd == 1)
        //                {
        //                    this._customerClaimConf.ConsTaxLayMethod = customerInfo.ConsTaxLayMethod;
        //                }
        //                else
        //                {
        //                    this._customerClaimConf.ConsTaxLayMethod = this._taxRateSet.ConsTaxLayMethod;
        //                }

        //                // 得意先マスタの総額表示方法参照区分が
        //                // ｢1:得意先参照」の場合は得意先マスタの「総額表示方法区分」を設定する
        //                // ｢0:全体設定参照」の場合は全体初期値設定マスタの「総額表示方法区分」を設定する
        //                if (customerInfo.TotalAmntDspWayRef == 1)
        //                {
        //                    this._customerClaimConf.TotalAmountDispWayCd = customerInfo.TotalAmountDispWayCd;
        //                }
        //                else
        //                {
        //                    this._customerClaimConf.TotalAmountDispWayCd = this._allDefSet.TotalAmountDispWayCd;
        //                }

        //                // 消費税の処理区分は売上金額処理区分設定マスタより取得
        //                this._customerClaimConf.TaxFractionProcCd = this._salesProcMoney.FractionProcCd;

        //                //// 請求計上拠点の取得
        //                //string addUpSectionCode;
        //                //string addUpSectionName;
        //                //this.GetOwnSeCtrlCode(this._customerClaimConf.MngSectionCode, SecInfoAcs.CtrlFuncCode.DemandAddUpSecCd, out addUpSectionCode, out addUpSectionName);
        //                //this._customerClaimConf.AddUpSectionCode = addUpSectionCode;

        //                // 前回支払情報の取得
        //                long lastStockTotalPayBalance;
        //                DateTime lastAddUpDate;
        //                this.GetDemandAddUpLastInfo(this._enterpriseCode, this._customerClaimConf.AddUpSectionCode, customerInfo.CustomerCode, out lastStockTotalPayBalance, out lastAddUpDate);

        //                this._customerClaimConf.LastCAddUpUpdDate = lastAddUpDate;
        //                this._customerClaimConf.LastTimeDemand = lastStockTotalPayBalance;

        //                break;
        //            }
        //        case GuideType.Payment:
        //            {
        //                if (( customerInfo == null ) || ( custSuppli == null ))
        //                {
        //                    this._customerClaimConf = new CustomerClaimConf();
        //                    return;
        //                }

        //                // 得意先情報クラスからのセット(共通項目)
        //                this.SetCustomerClaimConfFromCustomerInfo_Common(ref this._customerClaimConf, customerInfo);

        //                this._customerClaimConf.TotalDay = custSuppli.PaymentTotalDay;
        //                this._customerClaimConf.NTimeCalcStDate = custSuppli.NTimeCalcStDate;

        //                // 得意先仕入情報マスタの仕入先消費税転嫁方式参照区分が
        //                // ｢1:仕入先参照」の場合は得意先仕入情報マスタの「仕入先消費税転嫁方式」を設定する
        //                // ｢0:全体設定参照」の場合は仕入在庫全体設定マスタの「仕入先消費税転嫁方式」を設定する
        //                if (custSuppli.SuppCTaxLayRefCd == 1)
        //                {
        //                    this._customerClaimConf.ConsTaxLayMethod = custSuppli.SuppCTaxLayCd;
        //                }
        //                else
        //                {
        //                    this._customerClaimConf.ConsTaxLayMethod = this._stockTtlSt.SuppCTaxLayCd;
        //                }

        //                // 得意先仕入情報マスタの仕入先総額表示方法参照区分が
        //                // ｢1:仕入先参照」の場合は得意先仕入情報マスタの「仕入先総額表示方法区分」を設定する
        //                // ｢0:全体設定参照」の場合は全体初期値設定マスタの「総額表示方法区分」を設定する
        //                if (custSuppli.StckTtlAmntDspWayRef == 1)
        //                {
        //                    this._customerClaimConf.TotalAmountDispWayCd = custSuppli.SuppTtlAmntDspWayCd;
        //                }
        //                else
        //                {
        //                    this._customerClaimConf.TotalAmountDispWayCd = this._allDefSet.TotalAmountDispWayCd;
        //                }

        //                // 消費税の処理区分は仕入金額処理区分設定マスタより取得
        //                this._customerClaimConf.TaxFractionProcCd = this._stockProcMoney.FractionProcCd;

        //                //// 支払計上拠点の取得
        //                //string addUpSectionCode;
        //                //string addUpSectionName;
        //                //this.GetOwnSeCtrlCode(this._customerClaimConf.MngSectionCode, SecInfoAcs.CtrlFuncCode.PayAddUpSecCd, out addUpSectionCode, out addUpSectionName);
        //                //this._customerClaimConf.AddUpSectionCode = addUpSectionCode;

        //                // 前回支払情報の取得
        //                long lastStockTotalPayBalance;
        //                DateTime lastAddUpDate;
        //                this.GetPaymentAddUpLastInfo(this._enterpriseCode, this._customerClaimConf.AddUpSectionCode, customerInfo.CustomerCode, out lastStockTotalPayBalance, out lastAddUpDate);

        //                this._customerClaimConf.LastCAddUpUpdDate = lastAddUpDate;
        //                this._customerClaimConf.LastTimeDemand = lastStockTotalPayBalance;
        //                break;
        //            }
        //    }
        //    if (reCalcAddUpDate)
        //    {
        //        CustomerClaimConfAcs.CalcAddUpDate(salesDate, this._customerClaimConf.TotalDay, this._customerClaimConf.NTimeCalcStDate, out addUpdate, out delayPaymentDiv);
        //    }
        //    this._customerClaimConf.AddUpADate = addUpdate;
        //    this._customerClaimConf.CollectMoneyCode = delayPaymentDiv;
        //}
#endif
        /// <summary>
        /// データキャッシュ処理
        /// </summary>
        /// <param name="customerInfo">得意先情報クラス</param>
        /// <param name="customerChange">得意先変動情報</param>
        /// <param name="salesDate">売上日付</param>
        /// <param name="addUpdate">計上日付</param>
        /// <param name="delayPaymentDiv">来勘区分</param>
        /// <param name="reCalcAddUpDate">計上日を再計算する</param>
        private void CacheCustomerProc(CustomerInfo customerInfo, CustomerChange customerChange, DateTime salesDate, DateTime addUpdate, int delayPaymentDiv, bool reCalcAddUpDate)
        {

            this._customerChange = (customerChange == null) ? new CustomerChange() : customerChange.Clone();

            switch (this.Mode)
            {
                case GuideType.Claim:
                    {
                        if (customerInfo == null)
                        {
                            this._customerClaimConf = new CustomerClaimConf();
                            return;
                        }

                        // 得意先情報クラスからのセット(共通項目)
                        this._customerClaimConf.CustomerCode = customerInfo.CustomerCode;
                        this._customerClaimConf.Name = customerInfo.Name;
                        this._customerClaimConf.Name2 = customerInfo.Name2;
                        this._customerClaimConf.CustomerSnm = customerInfo.CustomerSnm;
                        this._customerClaimConf.MngSectionCode = customerInfo.MngSectionCode;
                        this._customerClaimConf.OfficeFaxNo = customerInfo.OfficeFaxNo;
                        //this._customerClaimConf.OfficeFaxNoDspName = customerInfo.OfficeFaxNoDspName;     // 2008.09.05 Del
                        this._customerClaimConf.OfficeTelNo = customerInfo.OfficeTelNo;
                        //this._customerClaimConf.OfficeTelNoDspName = customerInfo.OfficeTelNoDspName;     // 2008.09.05 Del
                        this._customerClaimConf.CreditMngCode = customerInfo.CreditMngCode;
                        this._customerClaimConf.CustomerAgent = customerInfo.CustomerAgentNm;

                        this._customerClaimConf.TotalDay = customerInfo.TotalDay;
                        this._customerClaimConf.NTimeCalcStDate = customerInfo.NTimeCalcStDate;

                        // 得意先マスタの消費税転嫁方式参照区分が
                        // ｢1:仕入先参照」の場合は得意先マスタの「消費税転嫁方式」を設定する
                        // ｢0:全体設定参照」の場合は税率設定マスタの「消費税転嫁方式」を設定する
                        if (customerInfo.CustCTaXLayRefCd == 1)
                        {
                            this._customerClaimConf.ConsTaxLayMethod = customerInfo.ConsTaxLayMethod;
                        }
                        else
                        {
                            this._customerClaimConf.ConsTaxLayMethod = this._taxRateSet.ConsTaxLayMethod;
                        }

                        // 得意先マスタの総額表示方法参照区分が
                        // ｢1:得意先参照」の場合は得意先マスタの「総額表示方法区分」を設定する
                        // ｢0:全体設定参照」の場合は全体初期値設定マスタの「総額表示方法区分」を設定する
                        if (customerInfo.TotalAmntDspWayRef == 1)
                        {
                            this._customerClaimConf.TotalAmountDispWayCd = customerInfo.TotalAmountDispWayCd;
                        }
                        else
                        {
                            this._customerClaimConf.TotalAmountDispWayCd = this._allDefSet.TotalAmountDispWayCd;
                        }

                        // 2009.01.31 >>>
                        //// 消費税の処理区分は売上金額処理区分設定マスタより取得
                        //this._customerClaimConf.TaxFractionProcCd = this._salesProcMoney.FractionProcCd;
                        double fractionProcUnit;
                        int fractionProcCd;
                        this.GetSalesFractionInfo(1, customerInfo.SalesCnsTaxFrcProcCd, 999999999, out fractionProcUnit, out fractionProcCd);
                        this._customerClaimConf.TaxFractionProcCd = fractionProcCd;
                        // 2009.01.31 <<<

                        //// 請求計上拠点の取得
                        //string addUpSectionCode;
                        //string addUpSectionName;
                        //this.GetOwnSeCtrlCode(this._customerClaimConf.MngSectionCode, SecInfoAcs.CtrlFuncCode.DemandAddUpSecCd, out addUpSectionCode, out addUpSectionName);
                        //this._customerClaimConf.AddUpSectionCode = addUpSectionCode;

                        // 前回支払情報の取得
                        long lastStockTotalPayBalance;
                        DateTime lastAddUpDate;
                        this.GetDemandAddUpLastInfo(this._enterpriseCode, this._customerClaimConf.AddUpSectionCode, customerInfo.CustomerCode, out lastStockTotalPayBalance, out lastAddUpDate);

                        this._customerClaimConf.LastCAddUpUpdDate = lastAddUpDate;
                        this._customerClaimConf.LastTimeDemand = lastStockTotalPayBalance;

                        break;
                    }
                case GuideType.Payment:
                    {
                        break;
                    }
            }

            // 2008.09.05 Add >>>
            if (this._alItmDspNm != null)
            {
                this._customerClaimConf.OfficeTelNoDspName = this._alItmDspNm.OfficeTelNoDspName;
                this._customerClaimConf.OfficeFaxNoDspName = this._alItmDspNm.OfficeFaxNoDspName;
            }
            // 2008.09.05 Add <<<

            if (reCalcAddUpDate)
            {
                CustomerClaimConfAcs.CalcAddUpDate(salesDate, this._customerClaimConf.TotalDay, this._customerClaimConf.NTimeCalcStDate, out addUpdate, out delayPaymentDiv);
            }
            this._customerClaimConf.AddUpADate = addUpdate;
            this._customerClaimConf.CollectMoneyCode = delayPaymentDiv;
        }
        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// データキャッシュ処理
        /// </summary>
		/// <param name="supplier">仕入先情報クラス</param>
        /// <param name="stockDate">仕入日</param>
        /// <param name="addUpdate">計上日</param>
        /// <param name="delayPaymentDiv">来勘区分</param>
        /// <param name="reCalcAddUpDate">計上日を再計算する</param>
        private void CacheSupplierProc(Supplier supplier, DateTime stockDate, DateTime addUpdate, int delayPaymentDiv, bool reCalcAddUpDate)
        {
            switch (this.Mode)
            {
                case GuideType.Claim:
                    {
                        break;
                    }
                case GuideType.Payment:
                    {
                        if (supplier == null)
                        {
                            this._customerClaimConf = new CustomerClaimConf();
                            return;
                        }

                        this._customerClaimConf.CustomerCode = supplier.SupplierCd;
                        this._customerClaimConf.Name = supplier.SupplierNm1;
                        this._customerClaimConf.Name2 = supplier.SupplierNm2;
                        this._customerClaimConf.CustomerSnm = supplier.SupplierSnm;
                        this._customerClaimConf.MngSectionCode = supplier.MngSectionCode;
                        this._customerClaimConf.OfficeFaxNo = supplier.SupplierTelNo2;
                        this._customerClaimConf.OfficeTelNo = supplier.SupplierTelNo;
                        this._customerClaimConf.CustomerAgent = supplier.StockAgentName;

                        this._customerClaimConf.TotalDay = supplier.PaymentTotalDay;
                        this._customerClaimConf.NTimeCalcStDate = supplier.NTimeCalcStDate;

                        // 得意先仕入情報マスタの仕入先消費税転嫁方式参照区分が
                        // ｢1:仕入先参照」の場合は得意先仕入情報マスタの「仕入先消費税転嫁方式」を設定する
                        // ｢0:全体設定参照」の場合は税率設定マスタの「仕入先消費税転嫁方式」を設定する
                        if (supplier.SuppCTaxLayRefCd == 1)
                        {
                            this._customerClaimConf.ConsTaxLayMethod = supplier.SuppCTaxLayCd;
                        }
                        else
                        {
							// 2008.07.07 Update >>>
							//this._customerClaimConf.ConsTaxLayMethod = this._stockTtlSt.SuppCTaxLayCd;
							this._customerClaimConf.ConsTaxLayMethod = this._taxRateSet.ConsTaxLayMethod;
							// 2008.07.07 Update <<<
                        }

                        // 得意先仕入情報マスタの仕入先総額表示方法参照区分が
                        // ｢1:仕入先参照」の場合は得意先仕入情報マスタの「仕入先総額表示方法区分」を設定する
                        // ｢0:全体設定参照」の場合は全体初期値設定マスタの「総額表示方法区分」を設定する
                        if (supplier.StckTtlAmntDspWayRef == 1)
                        {
                            this._customerClaimConf.TotalAmountDispWayCd = supplier.SuppTtlAmntDspWayCd;
                        }
                        else
                        {
                            this._customerClaimConf.TotalAmountDispWayCd = this._allDefSet.TotalAmountDispWayCd;
                        }

                        // 2009.01.31 >>>
                        //// 消費税の処理区分は仕入金額処理区分設定マスタより取得
                        //this._customerClaimConf.TaxFractionProcCd = this._stockProcMoney.FractionProcCd;

                        double fractionProcUnit;
                        int fractionProcCd;
                        this.GetStockFractionInfo(1, supplier.StockCnsTaxFrcProcCd, 999999999, out fractionProcUnit, out fractionProcCd);
                        this._customerClaimConf.TaxFractionProcCd = fractionProcCd;

                        // 2009.01.31 <<<

                        // 前回支払情報の取得
                        long lastStockTotalPayBalance;
                        DateTime lastAddUpDate;
                        this.GetPaymentAddUpLastInfo(this._enterpriseCode, this._customerClaimConf.AddUpSectionCode, supplier.SupplierCd, out lastStockTotalPayBalance, out lastAddUpDate);

                        this._customerClaimConf.LastCAddUpUpdDate = lastAddUpDate;
                        this._customerClaimConf.LastTimeDemand = lastStockTotalPayBalance;

                        // 2008.09.05 Add >>>
                        if (this._alItmDspNm!=null)
                        {
                            this._customerClaimConf.OfficeTelNoDspName = this._alItmDspNm.OfficeTelNoDspName;
                            this._customerClaimConf.OfficeFaxNoDspName = this._alItmDspNm.OfficeFaxNoDspName;
                        }
                        // 2008.09.05 Add <<<
                        break;
                    }
            }
            if (reCalcAddUpDate)
            {
                CustomerClaimConfAcs.CalcAddUpDate(stockDate, this._customerClaimConf.TotalDay, this._customerClaimConf.NTimeCalcStDate, out addUpdate, out delayPaymentDiv);
            }
            this._customerClaimConf.AddUpADate = addUpdate;
            this._customerClaimConf.CollectMoneyCode = delayPaymentDiv;
        }
        // ADD 2008.04.27 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // DEL 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 得意先情報クラス→請求確認画面クラス項目セット(請求・支払共通)
        ///// </summary>
        ///// <param name="customerClaimConf"></param>
        ///// <param name="customerInfo"></param>
        //private void SetCustomerClaimConfFromCustomerInfo_Common( ref CustomerClaimConf customerClaimConf, CustomerInfo customerInfo )
        //{
        //    customerClaimConf.CustomerCode = customerInfo.CustomerCode;
        //    customerClaimConf.Name = customerInfo.Name;
        //    customerClaimConf.Name2 = customerInfo.Name2;
        //    customerClaimConf.CustomerSnm = customerInfo.CustomerSnm;
        //    customerClaimConf.MngSectionCode = customerInfo.MngSectionCode;
        //    customerClaimConf.OfficeFaxNo = customerInfo.OfficeFaxNo;
        //    customerClaimConf.OfficeFaxNoDspName = customerInfo.OfficeFaxNoDspName;
        //    customerClaimConf.OfficeTelNo = customerInfo.OfficeTelNo;
        //    customerClaimConf.OfficeTelNoDspName = customerInfo.OfficeTelNoDspName;
        //    customerClaimConf.CreditMngCode = customerInfo.CreditMngCode;
        //    customerClaimConf.CustomerAgent = customerInfo.CustomerAgent;
        //}
        // DEL 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// 前回請求情報取得処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="addUpSectionCode">計上拠点コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="lastTotalPayBalance">前回請求金額</param>
		/// <param name="lastAddUpDate">前回請求締日</param>
		private void GetDemandAddUpLastInfo( string enterpriseCode, string addUpSectionCode, int customerCode, out long lastTotalPayBalance, out DateTime lastAddUpDate )
		{
			lastTotalPayBalance = 0;
			lastAddUpDate = DateTime.MinValue;
			InputDepositNormalTypeAcs.SearchCustomerParameter searchCustomerParameter = new InputDepositNormalTypeAcs.SearchCustomerParameter();
			searchCustomerParameter.EnterpriseCode = enterpriseCode;
			searchCustomerParameter.AddUpSecCod = addUpSectionCode;
			searchCustomerParameter.CustomerCode = customerCode;
			searchCustomerParameter.AddUpADate = TDateTime.DateTimeToLongDate(DateTime.Today);
			string msg="";

			DepositCustDmdPrc depositCustDmdPrc;

			int status = this._inputDepositNormalTypeAcs.ReadCustomDemandInfo(searchCustomerParameter, out depositCustDmdPrc, out msg);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				lastTotalPayBalance = depositCustDmdPrc.ThisTimeTtlBlcDmd;
				lastAddUpDate = depositCustDmdPrc.LastCAddUpUpdDate;
			}
		}

		/// <summary>
		/// 前回支払情報取得処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="addUpSectionCode">計上拠点コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="lastStockTotalPayBalance">前回支払金額</param>
		/// <param name="lastAddUpDate">前回支払締日</param>
		private void GetPaymentAddUpLastInfo( string enterpriseCode, string addUpSectionCode, int customerCode, out long lastStockTotalPayBalance, out DateTime lastAddUpDate )
		{
			lastStockTotalPayBalance = 0;
			lastAddUpDate = DateTime.MinValue;
			SearchPaymentParameter searchPaymentParameter = new SearchPaymentParameter();
			searchPaymentParameter.EnterpriseCode = enterpriseCode;
			searchPaymentParameter.AddUpSecCode = addUpSectionCode;
			searchPaymentParameter.PayeeCode = customerCode;
			searchPaymentParameter.AddUpADate = DateTime.Today;

			SearchSuplierPayRet searchSuplierPayRet;

			int status = this._paymentSlpSearch.ReadCustomPaymentInfo(searchPaymentParameter, out searchSuplierPayRet);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                lastStockTotalPayBalance = searchSuplierPayRet.StockTtl3TmBfBlPay + searchSuplierPayRet.StockTtl2TmBfBlPay + searchSuplierPayRet.LastTimePayment;
				lastAddUpDate = searchSuplierPayRet.LastCAddUpUpdDate;
			}
		}

        /// <summary>
        /// 仕入金額処理区分設定マスタの検索
        /// </summary>
        private void SearchStockProckMoney()
        {
            ArrayList al;
            this._claimConfDataSet.StockProcMoney.Rows.Clear();

            int status = this._stockProcMoneyAcs.Search(out al, this._enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockProcMoney stockProckMoney in al)
                {
                    ClaimConfDataSet.StockProcMoneyRow row = this._claimConfDataSet.StockProcMoney.NewStockProcMoneyRow();
                    row.FracProcMoneyDiv = stockProckMoney.FracProcMoneyDiv;
                    row.FractionProcCode = stockProckMoney.FractionProcCode;
                    row.UpperLimitPrice = stockProckMoney.UpperLimitPrice;
                    row.FractionProcUnit = stockProckMoney.FractionProcUnit;
                    row.FractionProcCd = stockProckMoney.FractionProcCd;
                    this._claimConfDataSet.StockProcMoney.AddStockProcMoneyRow(row);
                }
            }
        }

        /// <summary>
        /// 仕入金額処理区分設定情報取得
        /// </summary>
        /// <param name="fracProcMoneyDiv"></param>
        /// <param name="fractionProcCode"></param>
        /// <param name="upperLimitPrice"></param>
        /// <param name="fractionProcUnit"></param>
        /// <param name="fractionProcCd"></param>
        private void GetStockFractionInfo(int fracProcMoneyDiv, int fractionProcCode, double upperLimitPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            fractionProcUnit = 0;
            fractionProcCd = 0;
            ClaimConfDataSet.StockProcMoneyRow row = this._claimConfDataSet.StockProcMoney.FindByUpperLimitPriceFractionProcCodeFracProcMoneyDiv(upperLimitPrice, fractionProcCode, fracProcMoneyDiv);

            if (row != null)
            {
                fractionProcUnit = row.FractionProcUnit;
                fractionProcCd = row.FractionProcCd;
            }
        }

        /// <summary>
        /// 売上金額処理区分設定マスタの検索
        /// </summary>
        private void SearchSalesProckMoney()
        {
            ArrayList al;
            this._claimConfDataSet.SalesProcMoney.Rows.Clear();

            int status = this._salesProcMoneyAcs.Search(out al, this._enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (SalesProcMoney salesProcMoney in al)
                {
                    ClaimConfDataSet.SalesProcMoneyRow row = this._claimConfDataSet.SalesProcMoney.NewSalesProcMoneyRow();
                    row.FracProcMoneyDiv = salesProcMoney.FracProcMoneyDiv;
                    row.FractionProcCode = salesProcMoney.FractionProcCode;
                    row.UpperLimitPrice = salesProcMoney.UpperLimitPrice;
                    row.FractionProcUnit = salesProcMoney.FractionProcUnit;
                    row.FractionProcCd = salesProcMoney.FractionProcCd;
                    this._claimConfDataSet.SalesProcMoney.AddSalesProcMoneyRow(row);
                }
            }
        }

        /// <summary>
        /// 売上金額処理区分設定情報取得
        /// </summary>
        /// <param name="fracProcMoneyDiv"></param>
        /// <param name="fractionProcCode"></param>
        /// <param name="upperLimitPrice"></param>
        /// <param name="fractionProcUnit"></param>
        /// <param name="fractionProcCd"></param>
        private void GetSalesFractionInfo(int fracProcMoneyDiv, int fractionProcCode, double upperLimitPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            fractionProcUnit = 0;
            fractionProcCd = 0;
            ClaimConfDataSet.SalesProcMoneyRow row = this._claimConfDataSet.SalesProcMoney.FindByFracProcMoneyDivFractionProcCodeUpperLimitPrice(fracProcMoneyDiv, fractionProcCode, upperLimitPrice);

            if (row != null)
            {
                fractionProcUnit = row.FractionProcUnit;
                fractionProcCd = row.FractionProcCd;
            }
        }
		#endregion

		#region ■Static Method

		/// <summary>
		/// 計上日計算処理
		/// </summary>
		/// <param name="targetDate">対象日</param>
		/// <param name="totalDay">締日</param>
		/// <param name="nTimeCalcStDate">来月勘定開始日</param>
		/// <param name="addUpADate">計上日(算出結果)</param>
		/// <param name="delayPaymentDiv">来勘区分(算出	結果)</param>
		public static void CalcAddUpDate( DateTime targetDate, int totalDay, int nTimeCalcStDate, out DateTime addUpADate, out int delayPaymentDiv )
		{
			DateTime thisTimeAddUpDate = CustomerClaimConfAcs.GetNextTotalDate(0, targetDate, totalDay);
			// 来月請求の場合は、今回請求日の翌日が計上日
			DateTime nextTimeAddUpDate = thisTimeAddUpDate.AddDays(1);
			// 基本的に対象日が計上日で当月請求
			addUpADate = targetDate;
			delayPaymentDiv = 0;

			// 来月勘定開始日が設定されていない場合はそのまま終了
			if (nTimeCalcStDate == 0)
				return;

			// 来月勘定開始日 ≦ 締日
			if (nTimeCalcStDate <= totalDay)
			{
				// 対象日の日付が来月勘定開始日～締日の場合に来月勘定
				if (( nTimeCalcStDate <= targetDate.Day ) && ( targetDate.Day <= totalDay ))
				{
					addUpADate = nextTimeAddUpDate;
					delayPaymentDiv = 1;
				}
			}
			// 来月勘定開始日 ＞ 締日
			else
			{
				// 対象日の日付が1日～締日、来月勘定開始日～末日の場合に来月勘定
				if (( 1 <= targetDate.Day ) && ( targetDate.Day <= totalDay ) ||
					( nTimeCalcStDate <= targetDate.Day ))
				{
					addUpADate = nextTimeAddUpDate;
					delayPaymentDiv = 1;
				}
			}
		}

		/// <summary>
		/// 基となる日から、当月・翌月・翌々月の締対象となる計上日を取得します。
		/// </summary>
		/// <param name="collectMoneyMonth">0:当月,1:翌月,2:翌々月...</param>
		/// <param name="totalDay">締日</param>
		/// <param name="baseDate">基となる日</param>
		/// <returns>計上日</returns>
		public static DateTime CalcAddUpDate( int collectMoneyMonth, int totalDay, DateTime baseDate )
		{
			return ( collectMoneyMonth == 0 ) ? baseDate : (DateTime)GetNextTotalDate(collectMoneyMonth - 1, baseDate, totalDay).AddDays(1);
		}

		/// <summary>
		/// 計上日から、締対象となる対象月の区分値を取得します
		/// </summary>
		/// <param name="totalDay">締日</param>
		/// <param name="baseDate">基となる日</param>
		/// <param name="targetDate">計上日</param>
		/// <returns>0:当月,1:翌月,2:翌々月...</returns>
		public static int CalcCollectMoneyCode( int totalDay, DateTime baseDate, DateTime targetDate )
		{
			const int collectMoneyMonthMax = 99;
			if (targetDate <= baseDate)
			{
				return 0;
			}

			for (int cnt = 0; cnt < collectMoneyMonthMax; cnt++)
			{
				if ((DateTime)GetNextTotalDate(cnt, baseDate, totalDay).AddDays(1) > targetDate)
				{
					return cnt;
				}
			}
			return collectMoneyMonthMax;
		}

		/// <summary>
		/// 指定日付の次回以降の締日を算出します。
		/// </summary>
		/// <param name="loopCnt">0:当月,1:翌月,2:翌々月...</param>
		/// <param name="targetdate">対象日</param>
		/// <param name="totalDay">締日</param>
		/// <returns></returns>
		private static DateTime GetNextTotalDate( int loopCnt, DateTime targetdate, int totalDay )
		{

			DateTime retDate = targetdate;

			// 対象月の実際の締日を取得
			int totalDayR = GetRealTotalDay(retDate, totalDay);

			// 対象日が実際の締日より大きい場合は1ヵ月加算
			if (targetdate.Day > totalDayR)
			{
				retDate = retDate.AddMonths(1);

				totalDayR = GetRealTotalDay(retDate, totalDay);
			}
			retDate = new DateTime(retDate.Year, retDate.Month, totalDayR);

			return ( loopCnt == 0 ) ? retDate : GetNextTotalDate(loopCnt - 1, retDate.AddDays(1), totalDay);
		}

		/// <summary>
		/// 対象年月日、締日から、実際に締対象となる日付を算出します。
		/// </summary>
		/// <param name="targetDate">対象年月日</param>
		/// <param name="totalDay">設定上の締日</param>
		/// <returns>対象月の実際の締日</returns>
		private static int GetRealTotalDay( DateTime targetDate, int totalDay )
		{
			int retValue = totalDay;
			// 対象月の末日取得
			int lastDayofMonth = DateTime.DaysInMonth(targetDate.Year, targetDate.Month);

			if (lastDayofMonth < totalDay) retValue = lastDayofMonth;

			return retValue;
		}

		#endregion
	}
}
