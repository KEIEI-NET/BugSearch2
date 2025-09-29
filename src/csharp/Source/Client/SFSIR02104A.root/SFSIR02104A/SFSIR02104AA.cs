using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
// --- ADD 2012/09/07 ---------->>>>>
using Broadleaf.Application.Resources;
// --- ADD 2012/09/07 ----------<<<<<
namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 支払検索アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 支払情報の検索を行うアクセスクラスです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2006.05.24</br>
	/// <br></br>
    /// <br>UpdateNote  : 2006.12.22 木村 武正</br>
    /// <br>              携帯.NS用にインセンティブ（リベート支払額）を追加</br>
    /// <br>UpdateNote  : 2007.08.01 木村 武正 月次締め処理チェックを追加</br>
    /// <br>UpdateNote  : 2007.09.05 疋田 勇人 DC.NS用に変更</br>
    /// <br>UpdateNote  : 2008/07/08 忍 幸史 DC.NS用に変更</br>
    /// <br>Update Note : 2009/12/20 譚洪 ＰＭ．ＮＳ保守依頼④</br>
    /// <br>                ・操作性/入力速度向上のために以下の改良を行う</br>
    /// <br>                ・仕入先入力後に入金一覧を初期表示しないように変更の対応</br>
    /// <br>UpdateNote  : 2010/03/26 工藤 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更</br>
    /// <br>UpdateNote  : 2010/03/26 工藤 MANTIS対応[15201]：支払一覧画面に｢入力担当者｣を表示へ変更</br>
    /// <br>Update Note : 2010.04.27 gejun</br>
    /// <br>              M1007A-支払手形データ更新追加</br>
    /// <br>UpdateNote  : 2012/09/07 FSI上北田 秀樹 仕入総括対応</br> 
    /// <br></br>
    /// <br>Update Note : 2012/12/24 王君</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              Redmine#33741の追加対応</br>
    /// <br>Update Note : 2013/02/21 脇田 靖之</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              支払伝票削除時、手形データ紐付け解除対応</br>
    /// <br>Update Note : 2013/02/22 脇田 靖之</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              登録済みの支払伝票を変更せず、手形画面で確定後に</br>
    /// <br>              保存を実行すると締め伝票になる障害対応</br>
    /// <br>Update Note : 2013/03/01 王君</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              Redmine#33741の追加対応</br>
    //----------------------------------------------------------------------------//
    /// <br></br>
    /// </remarks>
	public class PaymentSlpSearch
	{

		#region PrivateMember
		// ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ //
		// 　　　　アクセスクラス系
		// ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ //
		// 支払伝票アクセスクラス
		private PaymentSlpAcs _paymentSlpAcs;
		// 支払伝票検索アクセスクラス
		private SearchPaymentAcs _searchPaymentAcs;

        // ↓ 20070519 18322 d MK.NSでは使用しないため削除
		//// 支払KINGETアクセスクラス
		//private KingetSuplierPayAcs _kingetSuplierPayAcs;
		//// 締次更新アクセスクラス
		//private CAddUpHisAcs _cAddUpHisAcs;
        // ↑ 20070519 18322 d

        // ↓ 20070519 18322 a
        // 得意先情報検索
        //private CustomerInfoAcs _customerInfoAcs = new CustomerInfoAcs();
        // ↑ 20070519 18322 a

        // ↓ 20070529 18322 a
        // 支払締準備処理のリモートオブジェクト
        private ISuplierPayDB _iSuplierPayDB = null;
        // ↑ 20070529 18322 a

        //// ↓ 20070801 18322 a
        //// 月次締め処理のリモートオブジェクト
        //private IMonthlyAddUpDB _iMonthlyAddUpDB = null;

        //// 最終月次締め日付
        //private MonthlyAddUpHisWork _lastMonthlyAddUpHis = null;
        //// ↑ 20070801 18322 a

        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
        // 仕入情報アクセスクラス
        private SupplierAcs _suppliAcs = null;
        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

		// ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ //
		// 　　　　データクラス系
		// ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ //
		// 仕入先情報
		private SearchCustSuppliRet _searchCustSuppliRet = new SearchCustSuppliRet();
		// 支払金額情報
		private SearchSuplierPayRet _searchSuplierPayRet = new SearchSuplierPayRet();
		// 抽出結果の支払伝票マスタ
		private Hashtable _paymentSlpHashTable;

		// ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ //
		// 　　　　その他
		// ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆ //
		// 支払情報 DataTable
		private DataTable _dtPaymentInfo = new DataTable();
        // ----- ADD 王君 2012/12/24 Redmine#33741 ------ >>>>>
        // 支払ガイド情報 DataTable
        private DataTable _dtPaymentInfoUH = new DataTable();
        // ----- ADD 王君 2012/12/24 Redmine#33741 ------ <<<<<
        //// 前回締日
        //private int _cAddUpUpDate;

        // 前回締め日
        private DateTime _lastAddUpDay;
        // 前回月次締日
        private DateTime _lastMonthlyAddUpDay;

        /// <summary>締日算出モジュール</summary>
        private TotalDayCalculator _totalDayCalculator;

		// エラーメッセージ
		private string _errorMessage;

        // --- ADD 2012/09/07 ---------->>>>>
        // 仕入総括オプションフラグ
        private bool _supplierSummary;
        // --- ADD 2012/09/07 ----------<<<<<

		#endregion

		#region Const
		// ☆☆☆ 支払情報 ☆☆☆
		/// <summary>支払伝票一覧テーブル名称</summary>
		public const string TBL_PAYMENTSLP = "PaymentSlp";
        // ---- ADD 王君 2012/12/24 Redmine#33741 ----- >>>>>
        public const string TBL_PAYMENTSLPG = "PaymentSlpG"; // 支払伝票一覧テーブル名称(仕入伝票検索ガイド用)
        // ---- ADD 王君 2012/12/24 Redmine#33741 ----- <<<<<
		/// <summary>支払伝票番号</summary>
		public const string COL_PAYMENTSLP_PAYMENTSLIPNO		= "PaymentSlipNo";
		/// <summary>支払日付</summary>
		public const string COL_PAYMENTSLP_PAYMENTDATE			= "PaymentDate";
        /// <summary>計上日付</summary>
        public const string COL_PAYMENTSLP_ADDUPADATE           = "AddUpADate";   // 2007.09.05 add
        /// <summary>支払金種名称</summary>
		public const string COL_PAYMENTSLP_PAYMENTMONEYKINDNAME	= "PaymentMoneyKindName";
		/// <summary>支払金額</summary>
		public const string COL_PAYMENTSLP_PAYMENT				= "Payment";
		/// <summary>支払金額計</summary>
		public const string COL_PAYMENTSLP_PAYMENTTOTAL			= "PaymentTotal";
		/// <summary>値引支払額</summary>
		public const string COL_PAYMENTSLP_DISCOUNTPAYMENT		= "DiscountPayment";
		/// <summary>手数料支払額</summary>
		public const string COL_PAYMENTSLP_FEEPAYMENT			= "FeePayment";
        // ↓ 20061222 18322 a
        ///// <summary>インセンティブ（リベート支払額）</summary>
        //public const string COL_PAYMENTSLP_REBATEPAYMENT        = "RebatePayment";  // 2007.09.05 hikita del
        /// <summary>赤伝区分</summary>
        public const string COL_PAYMENTSLP_DEBITNOTEDIV         = "DebitNoteDiv";
        // ↑ 20061222 18322 a
        /// <summary>伝票摘要</summary>
        public const string COL_PAYMENTSLP_OUTLINE				= "Outline";
		/// <summary>締済みフラグ</summary>
		public const string COL_PAYMENTSLP_FINISHEDFLG			= "FinishedFlg";

        // ADD 2010/03/26 MANTIS対応[15201]：支払一覧画面に｢入力担当者｣を表示へ変更 ---------->>>>>
        /// <summary>支払入力者名称</summary>
        public const string COL_PAYMENT_INPUT_AGENT_NM = "PaymentInputAgentNm";
        // ADD 2010/03/26 MANTIS対応[15201]：支払一覧画面に｢入力担当者｣を表示へ変更 ----------<<<<<
        // ----- ADD 王君 2012/12/24 Redmine#33741----->>>>>
        /// <summary>仕入先コード</summary>
        public const string COL_PAYMENTSLP_SUPPLIERCDRF = "SupplierCd";
        /// <summary>仕入先名</summary>
        public const string COL_PAYMENTSLP_SUPPLIERNAME = "SupplierNm";
        // ----- ADD 王君 2012/12/24 Redmine#33741-----<<<<<
		#endregion

		#region Property
		/// <summary>エラーメッセージ</summary>
		public string ErrorMessage
		{
			get { return _errorMessage; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public PaymentSlpSearch()
		{
			// 支払伝票アクセスクラス
			_paymentSlpAcs = new PaymentSlpAcs();
			// 支払伝票検索アクセスクラス
			_searchPaymentAcs = new SearchPaymentAcs();

            // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
            // 仕入情報アクセスクラス
            this._suppliAcs = new SupplierAcs();
            // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

            // ↓ 20070519 18322 d MK.NSでは使用しないため削除
			//// 支払KINGETアクセスクラス
			//_kingetSuplierPayAcs = new KingetSuplierPayAcs();
            //
			///// 締次更新アクセスクラス
			//_cAddUpHisAcs = new CAddUpHisAcs();
            // ↑ 20070519 18322 d

            // ↓ 20070529 18322 a 支払締準備処理のリモートを取得
            this._iSuplierPayDB = (ISuplierPayDB)MediationSuplierPayDB.GetSuplierPayDB();
            // ↑ 20070529 18322 a

            //// ↓ 20070801 18322 a
            //// 月次締め処理のリモートオブジェクト
            //this._iMonthlyAddUpDB = (IMonthlyAddUpDB)MediationMonthlyAddUpDB.GetCustMonthlyAddUpDB();

            //this._lastMonthlyAddUpHis = null;
            //// ↑ 20070801 18322 a

			// データテーブル作成
			_dtPaymentInfo = CreatePaymentInfoDataTable(TBL_PAYMENTSLP);
            // ----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
            // ガイドデータテーブル作成
            _dtPaymentInfoUH = CreatePaymentInfoDataTableUH(TBL_PAYMENTSLPG);
            // ----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>

			// 支払伝票マスタ保持用
			_paymentSlpHashTable = new Hashtable();

            _totalDayCalculator = TotalDayCalculator.GetInstance();

            // --- ADD 2012/09/07 ---------->>>>>
            // 仕入総括オプションフラグ取得
            this.CacheOptionInfo();
            // --- ADD 2012/09/07 ----------<<<<<

		}
		#endregion

		#region PublicMethod
        public void ClearPaymentDataTable()
        {
            this._dtPaymentInfo.Clear();

            this._paymentSlpHashTable.Clear();
        }

		/// <summary>
		/// 支払情報データテーブル取得処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: 支払情報データテーブルを取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.24</br>
		/// </remarks>
		public DataTable GetPaymentInfoDataTable()
		{
			return _dtPaymentInfo;
		}

        // ----- ADD 王君 2012/12/24 Redmine#33741 ----- >>>>>
        /// <summary>
        /// ガイド用tableclear
        /// </summary>
        ///<remarks>
        /// <br>Update Note : 2012/12/24 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の追加対応</br>
        /// </remarks>
        public void ClearPaymentDataTableUH()
        {
            this._dtPaymentInfo.Clear();
        }

        /// <summary>
        /// ガイド支払情報データテーブル削除処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: ガイド支払情報データテーブルを削除します。</br>
        /// <br>Programmer	: 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の追加対応</br>
        /// <br>Update Note : 2013/03/01 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の追加対応</br>
        /// </remarks>
        public void ClearPaymentGdDataTable()
        {
            this._dtPaymentInfoUH.Clear();

            //this._paymentSlpHashTable.Clear();// DEL 王君　2013/03/01 Redmine#33741 
        }
        /// <summary>
        /// 支払ガイド情報データテーブル取得処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: 支払ガイド情報データテーブルを取得します。</br>
        /// <br>Programmer	: 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の追加対応</br>
        /// </remarks>
        public DataTable GetPaymentInfoDataTableH()
        {
            return _dtPaymentInfoUH;
        }
        // ----- ADD 王君　2012/12/24 Redmine#33741 ----- <<<<< 

		/// <summary>
		/// 前回締日取得処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: 前回締日を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.24</br>
		/// </remarks>
		public int GetCAddUpUpDate()
		{
			return TDateTime.DateTimeToLongDate(this._lastAddUpDay);
		}

		/// <summary>
		/// 最終月次締め日取得処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: 最終月次締め日を取得します。</br>
		/// <br>Programmer	: 18322 木村 武正</br>
		/// <br>Date		: 2007.08.01</br>
		/// </remarks>
		public int GetLastMonthlyDate()
		{
            int result = 0;

            if (this._lastMonthlyAddUpDay != null)
            {
                result = TDateTime.DateTimeToLongDate(this._lastMonthlyAddUpDay);
            }

			return result;
		}

		/// <summary>
		/// 支払伝票取得処理
		/// </summary>
		/// <param name="paymentSlp">支払伝票マスタ</param>
		/// <param name="paymentSlipNo">支払伝票番号</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定支払伝票番号の支払伝票マスタを取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.24</br>
		/// </remarks>
		public int GetPaymentSlp(out PaymentSlp paymentSlp, int paymentSlipNo)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			paymentSlp = null;
			if (_paymentSlpHashTable.ContainsKey(paymentSlipNo))
			{
				paymentSlp = (PaymentSlp)_paymentSlpHashTable[paymentSlipNo];
			}
			else
			{
				status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			return status;
		}

        // 前回月次更新日取得
        public DateTime GetHisTotalDayMonthlyAccPay(string sectionCode)
        {
            DateTime lastMonthlyAddUpDay;

            this._totalDayCalculator.ClearCache();
            this._totalDayCalculator.InitializeHisMonthlyAccPay();

            int status = this._totalDayCalculator.GetHisTotalDayMonthlyAccPay(sectionCode, out lastMonthlyAddUpDay);
            if (status != 0)
            {
                lastMonthlyAddUpDay = new DateTime();
            }

            return lastMonthlyAddUpDay;
        }

        // 前回支払締日取得
        public DateTime GetTotalDayPayment(string sectionCode, int payeeCode)
        {
            DateTime prevTotalDay;

            this._totalDayCalculator.ClearCache();

            int status = this._totalDayCalculator.GetTotalDayPayment(sectionCode, payeeCode, out prevTotalDay);
            if (status != 0)
            {
                prevTotalDay = new DateTime();
            }

            return prevTotalDay;
        }

        public DateTime GetCurrentTotalDayPayment(string sectionCode, int payeeCode)
        {
            DateTime prevTotalDay;
            DateTime currentDay;

            this._totalDayCalculator.ClearCache();

            int status = this._totalDayCalculator.GetTotalDayPayment(sectionCode, payeeCode, out prevTotalDay, out currentDay);
            if (status != 0)
            {
                currentDay = new DateTime();
            }

            return currentDay;
        }

        /// <summary>
        /// 支払情報データ検索処理
        /// </summary>
        /// <param name="searchPaymentParameter">検索条件パラメータ</param>
        /// <param name="custSuppli">仕入先情報マスタ</param>
        /// <param name="suplierPayParam">支払金額情報マスタ</param>
        /// <param name="searchPaySlpInfoParameter">支払情報検索パラメータクラス</param>
        /// <param name="detailsShowFlg">支払一覧情報検索フラグ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払情報を一括して検索します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// <br>Update Note : 2009/12/20 譚洪 ＰＭ．ＮＳ保守依頼④</br> 
        /// <br>                ・操作性/入力速度向上のために以下の改良を行う</br>
        /// <br>                ・仕入先入力後に入金一覧を初期表示しないように変更の対応</br>
        /// </remarks>
        public int SearchPaymentInfo(SearchPaymentParameter searchPaymentParameter, 
                                     SearchPaySlpInfoParameter searchPaySlpInfoParameter, 
                                     out SearchCustSuppliRet custSuppli, 
                                     out SearchSuplierPayRet suplierPayParam,
                                     bool detailsShowFlg)            // ADD 2009/12/20
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int cAddUpUpDate = 0;

            custSuppli = new SearchCustSuppliRet();
            suplierPayParam = new SearchSuplierPayRet();

            try
            {
                // 仕入月次更新履歴取得
                this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccPay(searchPaymentParameter.AddUpSecCode);

                // 仕入締次処理日取得
                this._lastAddUpDay = GetTotalDayPayment(searchPaymentParameter.AddUpSecCode, searchPaymentParameter.PayeeCode);

                // 仕入先情報/支払金額情報取得処理
                if (searchPaymentParameter.PayeeCode != 0)
                {
                    status = this.GetCustomPaymentInfo1(searchPaymentParameter, out custSuppli, out suplierPayParam);
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                // 支払準備処理で取得した前回の締め日更新年月日を設定する
                                cAddUpUpDate = TDateTime.DateTimeToLongDate(suplierPayParam.LastCAddUpUpdDate);

                                break;
                            }
                        default:
                            {
                                return (status);
                            }
                    }
                }

                //SearchParaPaymentRead searchParaPaymentRead = CopyToSearchParaPaymentReadFromSearchPaySlpInfoParameter(searchPaySlpInfoParameter);  // DEL 2009/12/20
                this._paymentSlpHashTable = new Hashtable();
                this._dtPaymentInfo.Rows.Clear();

                // ADD 2009/12/20 ----->>>>>
                if (detailsShowFlg)
                {
                    SearchParaPaymentRead searchParaPaymentRead = CopyToSearchParaPaymentReadFromSearchPaySlpInfoParameter(searchPaySlpInfoParameter);

                    // 支払伝票情報取得処理
                    ArrayList retList;
                    ArrayList paymentSlpList = new ArrayList();
                    status = this._searchPaymentAcs.Search(searchParaPaymentRead, out retList);
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                // 検索用支払伝票マスタ→支払伝票マスタへコピー
                                foreach (SearchPaymentSlp searchPaymentSlp in retList)
                                {
                                    paymentSlpList.Add(CopyToPaymentSlpFromSearchPaymentSlp(searchPaymentSlp));
                                }

                                SearchPaymentParameter searchPaymentParametar2 = new SearchPaymentParameter();
                                searchPaymentParametar2.EnterpriseCode = searchPaymentParameter.EnterpriseCode;
                                searchPaymentParametar2.SupplierCode = searchPaymentParameter.SupplierCode;
                                searchPaymentParametar2.PayeeCode = searchPaymentParameter.PayeeCode;
                                searchPaymentParametar2.AddUpSecCode = searchPaymentParameter.AddUpSecCode;
                                searchPaymentParametar2.AddUpADate = searchPaymentParameter.AddUpADate;

                                // 最終計上日付を取得
                                foreach (PaymentSlp paymentSlp in paymentSlpList)
                                {
                                    if (paymentSlp.PayeeCode != searchPaymentParametar2.PayeeCode)
                                    {
                                        continue;
                                    }

                                    if (searchPaymentParametar2.SupplierCode == 0)
                                    {
                                        // 支払伝票の得意先で支払情報を取得
                                        searchPaymentParametar2.SupplierCode = paymentSlp.SupplierCd;
                                        searchPaymentParametar2.PayeeCode = paymentSlp.PayeeCode;
                                        status = this.GetCustomPaymentInfo1(searchPaymentParametar2, out custSuppli, out suplierPayParam);
                                        cAddUpUpDate = TDateTime.DateTimeToLongDate(this._lastAddUpDay);
                                    }

                                    // 最終計上日付を設定
                                    paymentSlp.CAddUpUpdDate = cAddUpUpDate;

                                    // 支払伝票一覧DataRow作成
                                    SetPaymentDataToDataTable(paymentSlp);
                                }

                                break;
                            }
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            {
                                if (searchPaymentParameter.SupplierCode == 0)
                                {
                                    this._errorMessage = "指定した条件で、支払伝票は存在しませんでした。";
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                break;
                            }
                        default:
                            {
                                this._errorMessage = this._searchPaymentAcs.ErrorMessage;
                                return (status);
                            }
                    }
                }
                // ADD 2009/12/20 -----<<<<<

                #region DEL 2009/12/20
                // DEL 2009/12/20 ----->>>>>
                //// 支払伝票情報取得処理
                //ArrayList retList;
                //ArrayList paymentSlpList = new ArrayList();
                //status = this._searchPaymentAcs.Search(searchParaPaymentRead, out retList);
                //switch (status)
                //{
                //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                //        {
                //            // 検索用支払伝票マスタ→支払伝票マスタへコピー
                //            foreach (SearchPaymentSlp searchPaymentSlp in retList)
                //            {
                //                paymentSlpList.Add(CopyToPaymentSlpFromSearchPaymentSlp(searchPaymentSlp));
                //            }

                //            SearchPaymentParameter searchPaymentParametar2 = new SearchPaymentParameter();
                //            searchPaymentParametar2.EnterpriseCode = searchPaymentParameter.EnterpriseCode;
                //            searchPaymentParametar2.SupplierCode = searchPaymentParameter.SupplierCode;
                //            searchPaymentParametar2.PayeeCode = searchPaymentParameter.PayeeCode;
                //            searchPaymentParametar2.AddUpSecCode = searchPaymentParameter.AddUpSecCode;
                //            searchPaymentParametar2.AddUpADate = searchPaymentParameter.AddUpADate;

                //            // 最終計上日付を取得
                //            foreach (PaymentSlp paymentSlp in paymentSlpList)
                //            {
                //                if (paymentSlp.PayeeCode != searchPaymentParametar2.PayeeCode)
                //                {
                //                    continue;
                //                }

                //                if (searchPaymentParametar2.SupplierCode == 0)
                //                {
                //                    // 支払伝票の得意先で支払情報を取得
                //                    searchPaymentParametar2.SupplierCode = paymentSlp.SupplierCd;
                //                    searchPaymentParametar2.PayeeCode = paymentSlp.PayeeCode;

                //                    status = this.GetCustomPaymentInfo1(searchPaymentParametar2, out custSuppli, out suplierPayParam);
                //                    cAddUpUpDate = TDateTime.DateTimeToLongDate(this._lastAddUpDay);
                //                }

                //                // 最終計上日付を設定
                //                paymentSlp.CAddUpUpdDate = cAddUpUpDate;

                //                // 支払伝票一覧DataRow作成
                //                SetPaymentDataToDataTable(paymentSlp);
                //            }

                //            break;
                //        }
                //    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                //        {
                //            if (searchPaymentParameter.SupplierCode == 0)
                //            {
                //                this._errorMessage = "指定した条件で、支払伝票は存在しませんでした。";
                //            }
                //            else
                //            {
                //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //            }
                //            break;
                //        }
                //    default:
                //        {
                //            this._errorMessage = this._searchPaymentAcs.ErrorMessage;
                //            return (status);
                //        }
                //}
                // DEL 2009/12/20 -----<<<<<
                #endregion
            }
            catch (Exception ex)
            {
                this._errorMessage = ex.Message;
                status = -1;
            }

            return status;
        }

        // ----- ADD 王君 2012/12/24 Redmine#33741 ----------->>>>>
        /// <summary>
        /// 支払情報データ検索処理(支払伝票番号検索モード)
        /// </summary>
        /// <param name="searchPaymentParameter">検索条件パラメータ</param>
        /// <param name="custSuppli">仕入先情報マスタ</param>
        /// <param name="suplierPayParam">支払金額情報マスタ</param>
        /// <param name="searchPaySlpInfoParameter">支払情報検索パラメータクラス</param>
        /// <param name="detailsShowFlg">支払一覧情報検索フラグ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払情報を一括して検索します。</br>
        /// <br>Programmer	: 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>Date		: 2012/12/24</br>
        /// </remarks>
        public int SearchPaymentInfoUG(SearchPaymentParameter searchPaymentParameter,
                                     SearchPaySlpInfoParameter searchPaySlpInfoParameter,
                                     out SearchCustSuppliRet custSuppli,
                                     out SearchSuplierPayRet suplierPayParam,
                                     bool detailsShowFlg)            
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int cAddUpUpDate = 0;
            custSuppli = new SearchCustSuppliRet();
            suplierPayParam = new SearchSuplierPayRet();

            try
            {
                // 仕入月次更新履歴取得
                this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccPay(searchPaymentParameter.AddUpSecCode);

                // 仕入締次処理日取得
                this._lastAddUpDay = GetTotalDayPayment(searchPaymentParameter.AddUpSecCode, searchPaymentParameter.PayeeCode);

                // 仕入先情報/支払金額情報取得処理
                if (searchPaymentParameter.PayeeCode != 0)
                {
                    status = this.GetCustomPaymentInfo1(searchPaymentParameter, out custSuppli, out suplierPayParam);
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                // 支払準備処理で取得した前回の締め日更新年月日を設定する
                                cAddUpUpDate = TDateTime.DateTimeToLongDate(suplierPayParam.LastCAddUpUpdDate);

                                break;
                            }
                        default:
                            {
                                return (status);
                            }
                    }
                } 
                #endregion
            }
            catch (Exception ex)
            {
                this._errorMessage = ex.Message;
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 支払伝票情報データ検索処理(支払伝票番号検索モード)
        /// </summary>
        /// <param name="searchPaySlpInfoParameter">検索条件パラメータ</param>
        /// <param name="totalDay">支払日</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票情報を一括して検索します。</br>
        /// <br>Programmer	: 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>Date		: 2012/12/24</br>
        /// </remarks>
        public int SearchPaySlpInfoUG(SearchPaySlpInfoParameter searchPaySlpInfoParameter, int totalDay)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                SearchParaPaymentRead searchParaPaymentRead = CopyToSearchParaPaymentReadFromSearchPaySlpInfoParameter(searchPaySlpInfoParameter);
                this._paymentSlpHashTable = new Hashtable();
                this._dtPaymentInfo.Rows.Clear();

                // 支払伝票情報取得処理
                ArrayList retList;
                ArrayList paymentSlpList = new ArrayList();
                status = this._searchPaymentAcs.Search(searchParaPaymentRead, out retList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // 仕入月次更新履歴取得
                            this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccPay(searchParaPaymentRead.AddUpSecCode);

                            // 仕入締次処理日取得
                            this._lastAddUpDay = GetTotalDayPayment(searchParaPaymentRead.AddUpSecCode, searchParaPaymentRead.SupplierCd);

                            // 検索用支払伝票マスタ→支払伝票マスタへコピー
                            foreach (SearchPaymentSlp searchPaymentSlp in retList)
                            {
                                paymentSlpList.Add(CopyToPaymentSlpFromSearchPaymentSlp(searchPaymentSlp));
                            }

                            foreach (PaymentSlp paymentSlp in paymentSlpList)
                            {
                                paymentSlp.CAddUpUpdDate = TDateTime.DateTimeToLongDate(this._lastAddUpDay);

                                // 支払伝票一覧DataRow作成
                                SetPaymentDataToDataTable(paymentSlp);
                            }

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            this._errorMessage = "指定された条件で、支払伝票は存在しませんでした。";
                            break;
                        }
                    default:
                        {
                            this._errorMessage = this._searchPaymentAcs.ErrorMessage;
                            return status;
                        }
                }
            }
            catch (Exception ex)
            {
                this._errorMessage = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// 支払伝票情報データ検索処理(支払伝票番号検索モード)
        /// </summary>
        /// <param name="searchPaySlpInfoParameter">検索条件パラメータ</param>
        /// <param name="totalDay">支払日</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票情報を一括して検索します。</br>
        /// <br>Programmer	: 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>Date		: 2012/12/24</br>
        /// </remarks>
        public int SearchPaySlpInfoUH(SearchPaySlpInfoParameter searchPaySlpInfoParameter, int totalDay)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //DataSet初期化
            this.ClearPaymentGdDataTable();

            try
            {
                SearchParaPaymentRead searchParaPaymentRead = CopyToSearchParaPaymentReadFromSearchPaySlpInfoParameter(searchPaySlpInfoParameter);
                this._paymentSlpHashTable = new Hashtable();

                // 支払伝票情報取得処理
                ArrayList retList;
                ArrayList paymentSlpList = new ArrayList();

                // 仕入月次更新履歴取得
                this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccPay(searchParaPaymentRead.AddUpSecCode);

                // 仕入締次処理日取得
                this._lastAddUpDay = GetTotalDayPayment(searchParaPaymentRead.AddUpSecCode, searchParaPaymentRead.SupplierCd);

                if (searchPaySlpInfoParameter.SupplierCode == 0)
                {
                    searchParaPaymentRead.PaymentCallMonthsStart = this._lastMonthlyAddUpDay.AddDays(1);
                }
                else
                {
                    if (this._lastMonthlyAddUpDay > this._lastAddUpDay)
                    {
                        searchParaPaymentRead.PaymentCallMonthsStart = this._lastMonthlyAddUpDay.AddDays(1);
                    }
                    else
                    {
                        searchParaPaymentRead.PaymentCallMonthsStart = this._lastAddUpDay.AddDays(1);
                    }
                }
                status = this._searchPaymentAcs.Search(searchParaPaymentRead, out retList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // 検索用支払伝票マスタ→支払伝票マスタへコピー
                            foreach (SearchPaymentSlp searchPaymentSlp in retList)
                            {
                                paymentSlpList.Add(CopyToPaymentSlpFromSearchPaymentSlp(searchPaymentSlp));
                            }

                            foreach (PaymentSlp paymentSlp in paymentSlpList)
                            {
                                paymentSlp.CAddUpUpdDate = TDateTime.DateTimeToLongDate(this._lastAddUpDay);

                                // 支払伝票一覧DataRow作成
                                SetPaymentDataToDataTableUH(paymentSlp);
                            }
                            this._dtPaymentInfoUH.DefaultView.Sort = "PaymentSlipNo asc";                 
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            this._errorMessage = "指定された条件で、支払伝票は存在しませんでした。";
                            break;
                        }
                    default:
                        {
                            this._errorMessage = this._searchPaymentAcs.ErrorMessage;
                            return status;
                        }
                }
            }
            catch (Exception ex)
            {
                this._errorMessage = ex.Message;
            }

            return status;
        }

        // ----- ADD 王君 2012/12/24 Redmine#33741 -----------<<<<<

        /// <summary>
        /// クラスメンバコピー処理
        /// </summary>
        /// <param name="searchPaySlpInfoParameter"></param>
        /// <returns></returns>
        private SearchParaPaymentRead CopyToSearchParaPaymentReadFromSearchPaySlpInfoParameter(SearchPaySlpInfoParameter searchPaySlpInfoParameter)
        {
            SearchParaPaymentRead searchParaPaymentRead = new SearchParaPaymentRead();

            searchParaPaymentRead.AddUpSecCode = searchPaySlpInfoParameter.AddUpSecCode;
            searchParaPaymentRead.AutoPayment = searchPaySlpInfoParameter.AutoPayment;
            searchParaPaymentRead.EnterpriseCode = searchPaySlpInfoParameter.EnterpriseCode;
            searchParaPaymentRead.PaymentCallMonthsEnd = searchPaySlpInfoParameter.PaymentCallMonthsEnd;
            searchParaPaymentRead.PaymentCallMonthsStart = searchPaySlpInfoParameter.PaymentCallMonthsStart;
            searchParaPaymentRead.PaymentSlipNo = searchPaySlpInfoParameter.PaymentSlipNo;
            searchParaPaymentRead.SupplierCd = searchPaySlpInfoParameter.SupplierCode;
            searchParaPaymentRead.SupplierCd = searchPaySlpInfoParameter.SupplierCode;


            return searchParaPaymentRead;
        }

        /// <summary>
        /// 支払伝票情報データ検索処理
        /// </summary>
        /// <param name="searchPaySlpInfoParameter">検索条件パラメータ</param>
        /// <param name="totalDay">支払日</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票情報を一括して検索します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        public int SearchPaySlpInfo(SearchPaySlpInfoParameter searchPaySlpInfoParameter, int totalDay)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                SearchParaPaymentRead searchParaPaymentRead = CopyToSearchParaPaymentReadFromSearchPaySlpInfoParameter(searchPaySlpInfoParameter);
                this._paymentSlpHashTable = new Hashtable();
                this._dtPaymentInfo.Rows.Clear();

                // 支払伝票情報取得処理
                ArrayList retList;
                ArrayList paymentSlpList = new ArrayList();
                status = this._searchPaymentAcs.Search(searchParaPaymentRead, out retList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // 仕入月次更新履歴取得
                            this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccPay(searchParaPaymentRead.AddUpSecCode);

                            // 仕入締次処理日取得
                            this._lastAddUpDay = GetTotalDayPayment(searchParaPaymentRead.AddUpSecCode, searchParaPaymentRead.SupplierCd);

                            // 検索用支払伝票マスタ→支払伝票マスタへコピー
                            foreach (SearchPaymentSlp searchPaymentSlp in retList)
                            {
                                if (searchPaymentSlp.PayeeCode != searchPaySlpInfoParameter.PayeeCode)
                                {
                                    continue;
                                }

                                paymentSlpList.Add(CopyToPaymentSlpFromSearchPaymentSlp(searchPaymentSlp));
                            }

                            foreach (PaymentSlp paymentSlp in paymentSlpList)
                            {
                                paymentSlp.CAddUpUpdDate = TDateTime.DateTimeToLongDate(this._lastAddUpDay);

                                // 支払伝票一覧DataRow作成
                                SetPaymentDataToDataTable(paymentSlp);
                            }
                            
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            this._errorMessage = "指定された条件で、支払伝票は存在しませんでした。";
                            break;
                        }
                    default:
                        {
                            this._errorMessage = this._searchPaymentAcs.ErrorMessage;
                            return status;
                        }
                }
            }
            catch (Exception ex)
            {
                this._errorMessage = ex.Message;
            }

            return status;
        }

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 支払情報データ検索処理
		/// </summary>
		/// <param name="searchPaymentParameter">検索条件パラメータ</param>
		/// <param name="custSuppli">仕入先情報マスタ</param>
		/// <param name="suplierPayParam">支払金額情報マスタ</param>
		/// <param name="searchPaySlpInfoParameter">支払情報検索パラメータクラス</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 支払情報を一括して検索します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.24</br>
		/// </remarks>
		public int SearchPaymentInfo(SearchPaymentParameter searchPaymentParameter, SearchPaySlpInfoParameter searchPaySlpInfoParameter, out SearchCustSuppliRet custSuppli, out SearchSuplierPayRet suplierPayParam)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			int cAddUpUpDate = 0;
			custSuppli = null;
			suplierPayParam	= null;

			try
			{
                // ↓ 20070801 18322 a 追加
                if (this._lastMonthlyAddUpHis == null)
                {
                    // 最終月次締め日を取得
                    MonthlyAddUpHisWork monthlyAddUpHisWork = new MonthlyAddUpHisWork();
                    monthlyAddUpHisWork.EnterpriseCode = searchPaymentParameter.EnterpriseCode;
                    monthlyAddUpHisWork.AddUpSecCode   = searchPaymentParameter.AddUpSecCode;

                    string retMsg;
                    object retObj = monthlyAddUpHisWork;
                    status = this._iMonthlyAddUpDB.ReadHis(ref retObj, out retMsg);
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
                // ↑ 20070801 18322 a 追加

				// 仕入先情報/支払金額情報取得処理
				if (searchPaymentParameter.CustomerCode != 0)
				{
					status = this.GetCustomPaymentInfo1(searchPaymentParameter, out custSuppli, out suplierPayParam);
					switch (status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						{
                            // ↓ 20070520 18322 c 支払準備処理で取得する為、削除
							//// 最終計上日付を取得
							//GetCAddUpHisInfo(searchPaySlpInfoParameter.EnterpriseCode, custSuppli.TotalDay, out cAddUpUpDate);

                            // 支払準備処理で取得した前回の締め日更新年月日を設定する
                            cAddUpUpDate = TDateTime.DateTimeToLongDate(suplierPayParam.LastCAddUpUpdDate);
                            // ↑ 20070520 18322 c

							break;
						}
						default:
						{
							return status;
						}
					}
                }

				SearchParaPaymentRead searchParaPaymentRead
					= (SearchParaPaymentRead)DBAndXMLDataMergeParts.CopyPropertyInClass(searchPaySlpInfoParameter, typeof(SearchParaPaymentRead));

				_paymentSlpHashTable = new Hashtable();
				_dtPaymentInfo.Rows.Clear();

				ArrayList retList;
				// 支払伝票情報取得処理
				status = _searchPaymentAcs.Search(searchParaPaymentRead, out retList);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// 検索用支払伝票マスタ→支払伝票マスタへコピー
						retList = DBAndXMLDataMergeParts.CopyPropertyInList(retList, typeof(PaymentSlp));

                        // ↓ 20070519 18322 a 支払準備処理の機能ができたら置き換える部分
                        SearchPaymentParameter searchPaymentParametar2 = new SearchPaymentParameter();
                        searchPaymentParametar2.EnterpriseCode = searchPaymentParameter.EnterpriseCode;
                        searchPaymentParametar2.CustomerCode   = searchPaymentParameter.CustomerCode;
                        searchPaymentParametar2.PayeeCode      = searchPaymentParameter.PayeeCode;
                        searchPaymentParametar2.AddUpSecCode   = searchPaymentParameter.AddUpSecCode;
                        searchPaymentParametar2.AddUpADate     = searchPaymentParameter.AddUpADate;

						// 最終計上日付を取得
						for (int ix = 0 ; ix != retList.Count ; ix++)
						{
							PaymentSlp paymentSlp = (PaymentSlp)retList[ix];

                            if (searchPaymentParametar2.CustomerCode == 0)
                            {
                                // 支払伝票の得意先で支払情報を取得
                                searchPaymentParametar2.CustomerCode = paymentSlp.CustomerCode;
                                searchPaymentParametar2.PayeeCode = paymentSlp.PayeeCode;

                                status = this.GetCustomPaymentInfo1(searchPaymentParametar2, out custSuppli, out suplierPayParam);
                                cAddUpUpDate = this._cAddUpUpDate;
                            }

                            // 最終計上日付を設定
							paymentSlp.CAddUpUpdDate = cAddUpUpDate;


							SetPaymentDataToDataTable(paymentSlp);
                        }
                        // ↑ 20070519 18322 a

                        // ↓ 20070519 18322 d 支払準備処理の機能を利用する為削除
                        #region 仕入先情報/支払金額情報取得処理
                        //// 仕入先情報/支払金額情報取得処理
						//if (searchPaymentParameter.CustomerCode == 0)
						//{
						//	PaymentSlp wkPaymentSlp = (PaymentSlp)retList[0];
						//	searchPaymentParameter.CustomerCode = wkPaymentSlp.CustomerCode;
						//	status = this.GetCustomPaymentInfo1(searchPaymentParameter, out custSuppli, out suplierPayParam);
						//	switch (status)
						//	{
						//		case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						//		{
						//			// 最終計上日付を取得
						//			GetCAddUpHisInfo(searchPaySlpInfoParameter.EnterpriseCode, custSuppli.TotalDay, out cAddUpUpDate);
						//			break;
						//		}
						//		default:
						//		{
						//			return status;
						//		}
						//	}
						//}
						//
						//// 最終計上日付を取得
						//for (int ix = 0 ; ix != retList.Count ; ix++)
						//{
						//	PaymentSlp paymentSlp = (PaymentSlp)retList[ix];
						//	paymentSlp.CAddUpUpdDate = cAddUpUpDate;
						//
						//	SetPaymentDataToDataTable(paymentSlp);
                        //}
                        #endregion
                        // ↑ 20070519 18322 d

                        break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						if (searchPaymentParameter.CustomerCode == 0)
						{
							_errorMessage = "指定した条件で、支払伝票は存在しませんでした。";
						}
						else
						{
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}
						break;
					}
					default:
					{
						_errorMessage = _searchPaymentAcs.ErrorMessage;
						return status;
					}
				}
			}
			catch (Exception ex)
			{
				_errorMessage = ex.Message;
				status = -1;
			}

			return status;
		}

        /// <summary>
		/// 支払伝票情報データ検索処理
		/// </summary>
		/// <param name="searchPaySlpInfoParameter">検索条件パラメータ</param>
		/// <param name="totalDay">支払日</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 支払伝票情報を一括して検索します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.24</br>
		/// </remarks>
		public int SearchPaySlpInfo(SearchPaySlpInfoParameter searchPaySlpInfoParameter, int totalDay)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				SearchParaPaymentRead searchParaPaymentRead
					= (SearchParaPaymentRead)DBAndXMLDataMergeParts.CopyPropertyInClass(searchPaySlpInfoParameter, typeof(SearchParaPaymentRead));

				_paymentSlpHashTable = new Hashtable();
				_dtPaymentInfo.Rows.Clear();

				ArrayList retList;
				// 支払伝票情報取得処理
				status = _searchPaymentAcs.Search(searchParaPaymentRead, out retList);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// 検索用支払伝票マスタ→支払伝票マスタへコピー
						retList = DBAndXMLDataMergeParts.CopyPropertyInList(retList, typeof(PaymentSlp));

                        // ↓ 20070519 18322 a
    					for (int ix = 0 ; ix != retList.Count ; ix++)
						{
							PaymentSlp paymentSlp = (PaymentSlp)retList[ix];
	    					paymentSlp.CAddUpUpdDate = this._cAddUpUpDate;
                            SetPaymentDataToDataTable(paymentSlp);
						}
                        // ↑ 20070519 18322 a

                        // ↓ 20070519 18322 d 支払準備処理の機能で
                        #region 最終計上日付を取得
                        //// 最終計上日付を取得
						//int cAddUpUpDate = 0;
						//status = GetCAddUpHisInfo(searchPaySlpInfoParameter.EnterpriseCode, totalDay, out cAddUpUpDate);
						//switch (status)
						//{
						//	case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						//	case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						//	{
						//		for (int ix = 0 ; ix != retList.Count ; ix++)
						//		{
						//			PaymentSlp paymentSlp = (PaymentSlp)retList[ix];
						//			paymentSlp.CAddUpUpdDate = cAddUpUpDate;
						//
						//			SetPaymentDataToDataTable(paymentSlp);
						//		}
						//		status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						//		break;
						//	}
						//}
                        #endregion
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						_errorMessage = "指定された条件で、支払伝票は存在しませんでした。";
						break;
					}
					default:
					{
						_errorMessage = _searchPaymentAcs.ErrorMessage;
						return status;
					}
				}
			}
			catch (Exception ex)
			{
				_errorMessage = ex.Message;
			}

			return status;
		}
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更
        
        /// <summary>
		/// 支払伝票更新処理
		/// </summary>
		/// <param name="paymentSlp">支払伝票マスタ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 支払伝票マスタを登録します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.24</br>
		/// </remarks>
		public int SavePaymentData(ref PaymentSlp paymentSlp)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			_errorMessage = "";

			status = _paymentSlpAcs.Write(ref paymentSlp);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                // 支払伝票一覧DataRow作成
				SetPaymentDataToDataTable(paymentSlp);
			}
			else
			{
				_errorMessage = _paymentSlpAcs.ErrorMessage;
			}

			return status;
		}

        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
        // --------------- ADD START 2010.04.27 gejun FOR M1007A-支払手形データ更新追加-------->>>>
        /// <summary>
        /// 支払伝票更新処理(支払手形データも連れる)
        /// </summary>
        /// <param name="paymentSlp">支払伝票マスタ</param>
        /// <param name="payDraftData">支払手形データ</param>
        /// <param name="payDraftDataDel">支払手形データ(削除用)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票マスタを登録、更新、削除します。</br>
        /// <br>Programmer	: gejun</br>
        /// <br>Date		: 2019.04.27</br>
        /// </remarks>
        public int SavePaymentDataWithDraft(ref PaymentSlp paymentSlp, PayDraftData payDraftData, PayDraftData payDraftDataDel)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            _errorMessage = "";

            status = _paymentSlpAcs.WriteWithPayDraft(ref paymentSlp, payDraftData, payDraftDataDel);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 支払伝票一覧DataRow作成
                SetPaymentDataToDataTable(paymentSlp);
            }
            else
            {
                _errorMessage = _paymentSlpAcs.ErrorMessage;
            }

            return status;
        }
        // --- ADD 2012/10/18 -------------------------------------------------->>>>>
        /// <summary>
        /// 支払伝票更新処理(支払手形・受取手形データも連れる)
        /// </summary>
        /// <param name="paymentSlp">支払伝票マスタ</param>
        /// <param name="payDraftData">支払手形データ</param>
        /// <param name="payDraftDataDel">支払手形データ(削除用)</param>
        /// <param name="rcvDraftData">受取手形データ</param>
        /// <param name="rcvDraftDataDel">受取手形データ(削除用)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票マスタを登録、更新、削除します。</br>
        /// <br>Programmer	: 宮本</br>
        /// <br>Date		: 2012/10/18</br>
        /// </remarks>
        // --- UPD 2013/02/22 Y.Wakita ---------->>>>>
        //public int SavePaymentDataWithDraftAll(ref PaymentSlp paymentSlp, PayDraftData payDraftData, PayDraftData payDraftDataDel
        //                                                                , RcvDraftData rcvDraftData, RcvDraftData rcvDraftDataDel)
        public int SavePaymentDataWithDraftAll(ref PaymentSlp paymentSlp, PayDraftData payDraftData, PayDraftData payDraftDataDel
                                                                        , RcvDraftData rcvDraftData, RcvDraftData rcvDraftDataDel
                                                                        , bool payUpdFlg)
        // --- UPD 2013/02/22 Y.Wakita ----------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            _errorMessage = "";

            // --- ADD 2013/02/22 Y.Wakita ---------->>>>>
            DateTime addUpADateBk = new DateTime();
            if (payUpdFlg == false)
            {
                //支払伝票を更新しない為、日付を操作する。
                addUpADateBk = paymentSlp.AddUpADate;
                paymentSlp.AddUpADate = DateTime.MinValue;
            }
            // --- ADD 2013/02/22 Y.Wakita ----------<<<<<
            status = _paymentSlpAcs.WriteWithDraft(ref paymentSlp, payDraftData, payDraftDataDel, rcvDraftData, rcvDraftDataDel);
            // --- ADD 2013/02/22 Y.Wakita ---------->>>>>
            if (payUpdFlg == false)
            {
                //日付を元に戻す
                paymentSlp.AddUpADate = addUpADateBk;
            }
            // --- ADD 2013/02/22 Y.Wakita ----------<<<<<
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 支払伝票一覧DataRow作成
                SetPaymentDataToDataTable(paymentSlp);
            }
            else
            {
                _errorMessage = _paymentSlpAcs.ErrorMessage;
            }

            return status;
        }
        // --- ADD 2012/10/18 --------------------------------------------------<<<<<

        // --------------- ADD END 2010.04.27 gejun FOR M1007A-支払手形データ更新追加-------->>>>
		/// <summary>
		/// 支払伝票削除処理
		/// </summary>
		/// <param name="paymentSlp">支払伝票マスタ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 支払伝票マスタを削除します。</br>
		/// <br>Programmer	: 30414 忍 幸史</br>
		/// <br>Date		: 2008/07/08</br>
		/// </remarks>
        // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
        //public int DeletePaymentData(PaymentSlp paymentSlp)
        public int DeletePaymentData(PaymentSlp paymentSlp, PayDraftData payDraftData)
        // --- UPD 2013/02/21 Y.Wakita ----------<<<<<
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			_errorMessage = "";

            PaymentDataWork paymentDataWork;

            // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
            //status = _paymentSlpAcs.Delete(paymentSlp.EnterpriseCode, paymentSlp.PaymentSlipNo, out paymentDataWork);
            status = _paymentSlpAcs.Delete(paymentSlp.EnterpriseCode, paymentSlp.PaymentSlipNo, payDraftData, out paymentDataWork);
            // --- UPD 2013/02/21 Y.Wakita ----------<<<<<
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					RemovePaymentDataFromDataTable(paymentSlp);

                    if (paymentDataWork != null)
                    {
                        // 元相殺済み黒伝を黒伝に戻す
                        SetPaymentDataToDataTable(CopyToPaymentSlpFromPaymentSlpWork(paymentDataWork));
                    }
					break;
				}
				default:
				{
					_errorMessage = _paymentSlpAcs.ErrorMessage;
					break;
				}
			}

			return status;
        }

        /// <summary>
        /// 支払伝票赤伝作成処理
        /// </summary>
        /// <param name="mode">赤伝作成モード 0:赤入金作成</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="updateSecCd">更新拠点コード</param>
        /// <param name="paymentAgentCode">支払担当者コード</param>
        /// <param name="paymentAgentNm">支払担当者名</param>
        /// <param name="addUpADate">計上日</param>
        /// <param name="paymentSlp">支払伝票マスタ(赤伝に変更する黒伝)</param>
        /// <param name="akaPaymentShipNo">支払伝票番号(赤伝)</param>
        /// <param name="message">エラー発生時メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票の赤伝を作成をします。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        public int RedCreatePaymentSlp(int mode, 
                                       string enterpriseCode, 
                                       string updateSecCd, 
                                       string paymentAgentCode, 
                                       string paymentAgentNm, 
                                       int addUpADate, 
                                       PaymentSlp paymentSlp, 
                                       out int akaPaymentShipNo, 
                                       out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            akaPaymentShipNo = 0;
            message = "";

            try
            {
                //=====================================
                // 赤入金作成処理
                //=====================================
                ArrayList paymentDataWorkList;
                status = _paymentSlpAcs.RedCreate(mode,
                                                  enterpriseCode,
                                                  updateSecCd,
                                                  paymentAgentCode,
                                                  paymentAgentNm,
                                                  TDateTime.LongDateToDateTime(addUpADate),
                                                  paymentSlp.PaymentSlipNo,
                                                  out paymentDataWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // エラー発生
                    message = _paymentSlpAcs.ErrorMessage;
                    return status;
                }

                //=====================================
                // 支払伝票一覧更新処理
                //=====================================
                foreach (PaymentDataWork paymentDataWork in paymentDataWorkList)
                {
                    // 赤伝元の黒伝と赤伝をリストに登録・更新
                    SetPaymentDataToDataTable(CopyToPaymentSlpFromPaymentSlpWork(paymentDataWork));
                    if (paymentDataWork.DebitNoteDiv == 1)
                    {
                        // 赤伝の支払伝票番号を取得
                        akaPaymentShipNo = paymentDataWork.PaymentSlipNo;
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;
        }
        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 支払伝票削除処理
        /// </summary>
        /// <param name="paymentSlp">支払伝票マスタ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票マスタを削除します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2006.05.24</br>
        /// </remarks>
        public int DeletePaymentData(PaymentSlp paymentSlp)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            _errorMessage = "";

            // ↓ 20070213 18322 c MA.NS用に変更
            //status = _paymentSlpAcs.Delete(paymentSlp.EnterpriseCode, paymentSlp.PaymentSlipNo);

            PaymentSlpWork paymentSlpWork;

            status = _paymentSlpAcs.Delete(paymentSlp.EnterpriseCode, paymentSlp.PaymentSlipNo, out paymentSlpWork);
            // ↑ 20070213 18322 c
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        RemovePaymentDataFromDataTable(paymentSlp);

                        // ↓ 20070213 18322 c MA.NS用に変更
                        if (paymentSlpWork != null)
                        {
                            // 元相殺済み黒伝を黒伝に戻す
                            SetPaymentDataToDataTable(CopyToPaymentSlpFromPaymentSlpWork(paymentSlpWork));
                        }
                        // ↑ 20070213 18322 c
                        break;
                    }
                default:
                    {
                        _errorMessage = _paymentSlpAcs.ErrorMessage;
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// 支払伝票赤伝作成処理
        /// </summary>
        /// <param name="mode">赤伝作成モード 0:赤入金作成</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="updateSecCd">更新拠点コード</param>
        /// <param name="paymentAgentCode">支払担当者コード</param>
        /// <param name="paymentAgentNm">支払担当者名</param>
        /// <param name="addUpADate">計上日</param>
        /// <param name="paymentSlp">支払伝票マスタ(赤伝に変更する黒伝)</param>
        /// <param name="akaPaymentShipNo">支払伝票番号(赤伝)</param>
        /// <param name="message">エラー発生時メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払伝票の赤伝を作成をします。</br>
        /// <br>Programmer	: 18322 木村 武正</br>
        /// <br>Date		: 2006.12.22</br>
        /// </remarks>
        public int RedCreatePaymentSlp(int mode, string enterpriseCode, string updateSecCd, string paymentAgentCode, string paymentAgentNm, int addUpADate, PaymentSlp paymentSlp, out int akaPaymentShipNo, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            akaPaymentShipNo = 0;
            message = "";

            try
            {
                //=====================================
                // 赤入金作成処理
                //=====================================
                ArrayList paymentSlpWorkList;
                status = _paymentSlpAcs.RedCreate(mode,
                                                  enterpriseCode,
                                                  updateSecCd,
                                                  paymentAgentCode,
                                                  paymentAgentNm,
                                                  TDateTime.LongDateToDateTime(addUpADate),
                                                  paymentSlp.PaymentSlipNo,
                                                  out paymentSlpWorkList);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // エラー発生
                    message = _paymentSlpAcs.ErrorMessage;
                    return status;
                }

                //=====================================
                // 支払伝票一覧更新処理
                //=====================================
                foreach (PaymentSlpWork paymentSlpWork in paymentSlpWorkList)
				{
                    // 赤伝元の黒伝と赤伝をリストに登録・更新

                    SetPaymentDataToDataTable(CopyToPaymentSlpFromPaymentSlpWork(paymentSlpWork));
                    if (paymentSlpWork.DebitNoteDiv == 1)
                    {
                        // 赤伝の支払伝票番号を取得
                        akaPaymentShipNo = paymentSlpWork.PaymentSlipNo;
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;
        }
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更
        
        /// <summary>
		/// 支払データ読込処理
		/// </summary>
		/// <param name="paymentSlp">支払伝票マスタ</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="paymentSlipNo">支払伝票番号</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 支払伝票マスタを読み込みます。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.24</br>
		/// </remarks>
		public int ReadPaymentData(out PaymentSlp paymentSlp, string enterpriseCode, int paymentSlipNo)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			_errorMessage = "";

			status = _paymentSlpAcs.Read(out paymentSlp, enterpriseCode, paymentSlipNo);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					break;
				}
				default:
				{
					_errorMessage = _paymentSlpAcs.ErrorMessage;
					break;
				}
			}

			return status;
		}

		/// <summary>
		/// 支払金額情報取得処理
		/// </summary>
		/// <param name="searchPaymentParameter">検索パラメータ</param>
		/// <param name="suplierPayParam">支払金額情報マスタ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 支払金額情報を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.24</br>
		/// </remarks>
		public int ReadCustomPaymentInfo(SearchPaymentParameter searchPaymentParameter, out SearchSuplierPayRet suplierPayParam)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			suplierPayParam = null;
			try
			{
				// 仕入先情報/支払金額情報取得処理
				status = this.GetCustomPaymentInfo2(searchPaymentParameter, out suplierPayParam);
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				_errorMessage = ex.Message;
			}

			return status;
		}

        /// <summary>
        /// 仕入情報取得処理
        /// </summary>
        /// <param name="supplier">仕入情報</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 指定得意先の仕入情報を取得します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/07/08</br>
        /// </remarks>
        public int GetCustSuppli(out Supplier supplier, string enterpriseCode, int supplierCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            supplier = new Supplier();

            try
            {
                status = this._suppliAcs.Read(out supplier, enterpriseCode, supplierCode);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 得意先取得処理
		/// </summary>
        /// <param name="customerInfo">得意先情報</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定得意先の得意先情報を取得します。</br>
		/// <br>Programmer	: 18322 T.Kimura</br>
		/// <br>Date		: 2007.07.25</br>
		/// </remarks>
		public int GetCustomerInfo(out CustomerInfo customerInfo, string enterpriseCode, int customerCode)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            customerInfo = null;
            CustSuppli   customerSuppli;
            status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo
                                                               ,out customerSuppli
                                                               ,    enterpriseCode
                                                               ,    customerCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // データ無しの場合は、DBから読み込み
                status = this._customerInfoAcs.ReadDBDataWithCustSuppli(    ConstantManagement.LogicalMode.GetData0
                                                                       ,    enterpriseCode
                                                                       ,    customerCode
                                                                       ,    true
                                                                       ,out customerInfo
                                                                       ,out customerSuppli);

            }

			return status;
		}
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更

        #region PrivateMethod
        /// <summary>
		/// 支払伝票一覧DataTable作成処理
		/// </summary>
		/// <param name="tableNm">データテーブル</param>
		/// <remarks>
		/// <br>Note		: 支払伝票一覧用のデータテーブルスキーマを作成します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.24</br>
        /// <br>UpdateNote  : 2006.12.22 木村 武正</br>
        /// <br>              携帯.NS用にインセンティブ（リベート支払額）を追加</br>
        /// <br>UpdateNote  : 2012/12/24 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
		/// </remarks>
		private DataTable CreatePaymentInfoDataTable(string tableNm)
		{
			// データテーブルの列定義
			DataTable dt = new DataTable(tableNm);

			dt.Columns.Add(COL_PAYMENTSLP_PAYMENTSLIPNO,		typeof(string));	// 支払伝票番号
			dt.Columns.Add(COL_PAYMENTSLP_PAYMENTDATE,			typeof(string));	// 支払日付
            dt.Columns.Add(COL_PAYMENTSLP_ADDUPADATE,           typeof(string));	// 計上日付     // 2007.09.05 add
            dt.Columns.Add(COL_PAYMENTSLP_PAYMENTMONEYKINDNAME,	typeof(string));	// 支払金種名称
			dt.Columns.Add(COL_PAYMENTSLP_PAYMENT,				typeof(long));		// 支払金額
			dt.Columns.Add(COL_PAYMENTSLP_FEEPAYMENT,			typeof(long));		// 手数料支払額
			dt.Columns.Add(COL_PAYMENTSLP_DISCOUNTPAYMENT,		typeof(long));		// 値引支払額
            // ↓ 20061222 18322 a 携帯.NS用にインセンティブを追加
            //dt.Columns.Add(COL_PAYMENTSLP_REBATEPAYMENT,        typeof(long));      // インセンティブ（リベート支払額） // 2007.09.05 hikita del
            // ↑ 20061222 18322 a
			dt.Columns.Add(COL_PAYMENTSLP_PAYMENTTOTAL,			typeof(long));		// 支払金額計
			dt.Columns.Add(COL_PAYMENTSLP_OUTLINE,				typeof(string));	// 伝票摘要
			dt.Columns.Add(COL_PAYMENTSLP_FINISHEDFLG,			typeof(string));	// 締済みフラグ
            // ↓ 20061222 18322 a 携帯.NS用に赤伝区分を追加
            dt.Columns.Add(COL_PAYMENTSLP_DEBITNOTEDIV,         typeof(int));       // 赤伝
            // ↑ 20061222 18322 a

            // ADD 2010/03/26 MANTIS対応[15201]：支払一覧画面に｢入力担当者｣を表示へ変更 ---------->>>>>
            dt.Columns.Add(COL_PAYMENT_INPUT_AGENT_NM, typeof(string)); // 支払入力者名称
            // ADD 2010/03/26 MANTIS対応[15201]：支払一覧画面に｢入力担当者｣を表示へ変更 ----------<<<<<
            // ----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
            dt.Columns.Add(COL_PAYMENTSLP_SUPPLIERCDRF, typeof(int));
            dt.Columns.Add(COL_PAYMENTSLP_SUPPLIERNAME, typeof(string));
            // ------ ADD 王君 2012/12/24 Redmine#33741 -----<<<<<
			return dt;
		}

        // ----- ADD 王君 2012/12/24 Redmine#33741 ----- >>>>>
        /// <summary>
        /// 支払伝票一覧DataTable作成処理(支払伝票検索ガイド一覧用)
        /// </summary>
        /// <param name="tableNm">データテーブル</param>
        /// <remarks>
        /// <br>Note		: 支払伝票一覧用のデータテーブルスキーマを作成します。</br>
        /// <br>Programmer	: 王君</br>
        /// <br>Date		: 2012/12/24</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// </remarks>
        private DataTable CreatePaymentInfoDataTableUH(string tableNm)
        {
            // データテーブルの列定義
            DataTable dt = new DataTable(tableNm);

            dt.Columns.Add(COL_PAYMENTSLP_PAYMENTSLIPNO, typeof(string));	// 支払伝票番号
            dt.Columns.Add(COL_PAYMENTSLP_PAYMENTDATE, typeof(string));	// 支払日付
            dt.Columns.Add(COL_PAYMENTSLP_ADDUPADATE, typeof(string));	// 計上日付     // 2007.09.05 add
            dt.Columns.Add(COL_PAYMENTSLP_PAYMENTMONEYKINDNAME, typeof(string));	// 支払金種名称
            dt.Columns.Add(COL_PAYMENTSLP_PAYMENT, typeof(long));		// 支払金額
            dt.Columns.Add(COL_PAYMENTSLP_FEEPAYMENT, typeof(long));		// 手数料支払額
            dt.Columns.Add(COL_PAYMENTSLP_DISCOUNTPAYMENT, typeof(long));		// 値引支払額
            dt.Columns.Add(COL_PAYMENTSLP_PAYMENTTOTAL, typeof(long));		// 支払金額計
            dt.Columns.Add(COL_PAYMENTSLP_OUTLINE, typeof(string));	// 伝票摘要
            dt.Columns.Add(COL_PAYMENTSLP_FINISHEDFLG, typeof(string));	// 締済みフラグ
            dt.Columns.Add(COL_PAYMENTSLP_DEBITNOTEDIV, typeof(int));       // 赤伝
            dt.Columns.Add(COL_PAYMENT_INPUT_AGENT_NM, typeof(string)); // 支払入力者名称
            dt.Columns.Add(COL_PAYMENTSLP_SUPPLIERCDRF, typeof(int));//仕入先コード
            dt.Columns.Add(COL_PAYMENTSLP_SUPPLIERNAME, typeof(string));//仕入先名
            return dt;
        }

        /// <summary>
        /// 支払伝票一覧DataRow作成処理(伝票検索ガイド用)
        /// </summary>
        /// <param name="paymentSlp">支払伝票マスタ</param>
        /// <remarks>
        /// <br>Note		: 支払伝票一覧用の行を作成・追加します。</br>
        /// <br>Programmer	: 王君</br>
        /// <br>Date		: 2012/12/24</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// </remarks>
        private void SetPaymentDataToDataTableUH(PaymentSlp paymentSlp)
        {
            // 支払伝票マスタをHashTableに確保
            _paymentSlpHashTable[paymentSlp.PaymentSlipNo] = paymentSlp;

            DataRow dr = null;
            foreach (DataRow wkRow in _dtPaymentInfoUH.Rows)
            {
                int paymentSlipNo = TStrConv.StrToIntDef(wkRow[COL_PAYMENTSLP_PAYMENTSLIPNO].ToString(), -1);
                if (paymentSlp.PaymentSlipNo == paymentSlipNo)
                {
                    dr = wkRow;
                    break;
                }
            }
            if (dr == null)
            {
                dr = _dtPaymentInfoUH.NewRow();
                _dtPaymentInfoUH.Rows.Add(dr);
            }

            // 支払伝票番号
            dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO] = paymentSlp.PaymentSlipNo.ToString("000000000");
            // 支払日付
            dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTDATE] = paymentSlp.PaymentDate.ToString("yyyy/MM/dd");
            // 計上日付
            dr[PaymentSlpSearch.COL_PAYMENTSLP_ADDUPADATE] = paymentSlp.AddUpADate.ToString("yyyy/MM/dd");  

            List<string> moneyKindNameList = new List<string>();
            for (int index = 0; index < paymentSlp.PaymentDtl.Length; index++)
            {
                if (!string.IsNullOrEmpty(paymentSlp.MoneyKindNameDtl[index]))
                {
                    moneyKindNameList.Add(paymentSlp.MoneyKindNameDtl[index]);
                }
            }
            switch (moneyKindNameList.Count)
            {
                case 0:
                    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = "";
                    break;
                case 1:
                    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = moneyKindNameList[0];
                    break;
                case 2:
                    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = moneyKindNameList[0] + "・" + moneyKindNameList[1];
                    break;
                default:
                    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = moneyKindNameList[0] + "・" + moneyKindNameList[1] + "ほか";
                    break;
            }
            // 支払金額
            dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT] = paymentSlp.Payment;
            // 手数料支払額
            dr[PaymentSlpSearch.COL_PAYMENTSLP_FEEPAYMENT] = paymentSlp.FeePayment;
            // 値引支払額
            dr[PaymentSlpSearch.COL_PAYMENTSLP_DISCOUNTPAYMENT] = paymentSlp.DiscountPayment;
            // 赤伝
            dr[PaymentSlpSearch.COL_PAYMENTSLP_DEBITNOTEDIV] = paymentSlp.DebitNoteDiv;
            // 支払金額計
            dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL] = paymentSlp.PaymentTotal;
            // 伝票摘要
            dr[PaymentSlpSearch.COL_PAYMENTSLP_OUTLINE] = paymentSlp.Outline;
            // 支払伝票マスタ
            if (TDateTime.DateTimeToLongDate(paymentSlp.AddUpADate) > paymentSlp.CAddUpUpdDate)
            {
                dr[PaymentSlpSearch.COL_PAYMENTSLP_FINISHEDFLG] = "";
            }
            else
            {
                dr[PaymentSlpSearch.COL_PAYMENTSLP_FINISHEDFLG] = "〆";
            }

            // ↓ 20070801 18322 月次〆を追加
            if (paymentSlp.AddUpADate < this._lastMonthlyAddUpDay)
            {
                // 最終月次更新日以前の支払日のとき
                dr[PaymentSlpSearch.COL_PAYMENTSLP_FINISHEDFLG] = "〆";
            }
            // FIXME:支払入力者名称
            dr[PaymentSlpSearch.COL_PAYMENT_INPUT_AGENT_NM] = paymentSlp.PaymentAgentName;
            dr[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERCDRF] = paymentSlp.SupplierCd; // 仕入先コード
            dr[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERNAME] = paymentSlp.SupplierSnm;// 仕入先名
        }
        // ----- ADD 王君 2012/12/24 Redmine#33741 ----- <<<<<

		/// <summary>
		/// 支払伝票一覧DataRow作成処理
		/// </summary>
		/// <param name="paymentSlp">支払伝票マスタ</param>
		/// <remarks>
		/// <br>Note		: 支払伝票一覧用の行を作成・追加します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.24</br>
        /// <br>UpdateNote  : 2006.12.22 木村 武正</br>
        /// <br>              携帯.NS用にインセンティブ（リベート支払額）を追加</br>
        /// <br>UpdateNote  : 2012/12/24 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// </remarks>
		private void SetPaymentDataToDataTable(PaymentSlp paymentSlp)
		{
			// 支払伝票マスタをHashTableに確保
			_paymentSlpHashTable[paymentSlp.PaymentSlipNo] = paymentSlp;

			DataRow dr = null;
			foreach (DataRow wkRow in _dtPaymentInfo.Rows)
			{
				int paymentSlipNo = TStrConv.StrToIntDef(wkRow[COL_PAYMENTSLP_PAYMENTSLIPNO].ToString(), -1);
				if (paymentSlp.PaymentSlipNo == paymentSlipNo)
				{
					dr = wkRow;
					break;
				}
			}
			if (dr == null)
			{
				dr = _dtPaymentInfo.NewRow();
				_dtPaymentInfo.Rows.Add(dr);
			}

			// 支払伝票番号
			dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO]		= paymentSlp.PaymentSlipNo.ToString("000000000");
			// 支払日付
			dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTDATE]			= paymentSlp.PaymentDate.ToString("yyyy/MM/dd");
            // 計上日付
            dr[PaymentSlpSearch.COL_PAYMENTSLP_ADDUPADATE]          = paymentSlp.AddUpADate.ToString("yyyy/MM/dd");    // 2007.09.05 add

            // 支払金種名称
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //if (paymentSlp.AutoPayment == 0)  // 通常支払   //2007.09.05 add
            //{
            //    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = paymentSlp.PaymentMoneyKindName;
            //}
            //// 2007.09.05 add start -------------------------------->>
            //else
            //{
            //    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = paymentSlp.PaymentMoneyKindName + "(自動)";
            //}
            List<string> moneyKindNameList = new List<string>();
            for (int index = 0; index < paymentSlp.PaymentDtl.Length; index++)
            {
                // DEL 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ---------->>>>>
                //if (paymentSlp.PaymentDtl[index] != 0)
                // DEL 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ----------<<<<<
                // ADD 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ---------->>>>>
                if (!string.IsNullOrEmpty(paymentSlp.MoneyKindNameDtl[index]))
                // ADD 2010/03/26 MANTIS対応[15200]：0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更 ----------<<<<<
                {
                    moneyKindNameList.Add(paymentSlp.MoneyKindNameDtl[index]);
                }
            }
            switch (moneyKindNameList.Count)
            {
                case 0:
                    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = "";
                    break;
                case 1:
                    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = moneyKindNameList[0];
                    break;
                case 2:
                    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = moneyKindNameList[0] + "・" + moneyKindNameList[1];
                    break;
                default:
                    dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME] = moneyKindNameList[0] + "・" + moneyKindNameList[1] + "ほか";
                    break;
            }
            // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<

            // 2007.09.05 add end ----------------------------------<<
			// 支払金額
			dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT]				= paymentSlp.Payment;
			// 手数料支払額
			dr[PaymentSlpSearch.COL_PAYMENTSLP_FEEPAYMENT]			= paymentSlp.FeePayment;
			// 値引支払額
			dr[PaymentSlpSearch.COL_PAYMENTSLP_DISCOUNTPAYMENT]		= paymentSlp.DiscountPayment;
            // ↓ 20061222 18322 a 
            // インセンティブ(リベート支払額)
            //dr[PaymentSlpSearch.COL_PAYMENTSLP_REBATEPAYMENT] = paymentSlp.RebatePayment;  // 2007.09.05 hikita del
            // 赤伝
            dr[PaymentSlpSearch.COL_PAYMENTSLP_DEBITNOTEDIV] = paymentSlp.DebitNoteDiv;
            // ↑ 20061222 18322 a
			// 支払金額計
			dr[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL]		= paymentSlp.PaymentTotal;
			// 伝票摘要
            dr[PaymentSlpSearch.COL_PAYMENTSLP_OUTLINE] = paymentSlp.Outline;
			// 支払伝票マスタ
			if (TDateTime.DateTimeToLongDate(paymentSlp.AddUpADate) > paymentSlp.CAddUpUpdDate)
			{
				dr[PaymentSlpSearch.COL_PAYMENTSLP_FINISHEDFLG] = "";
			}
			else
			{
				dr[PaymentSlpSearch.COL_PAYMENTSLP_FINISHEDFLG] = "〆";
			}

            // ↓ 20070801 18322 月次〆を追加
            if (paymentSlp.AddUpADate < this._lastMonthlyAddUpDay)
            {
                // 最終月次更新日以前の支払日のとき
                dr[PaymentSlpSearch.COL_PAYMENTSLP_FINISHEDFLG] = "〆";
            }
            // ↑ 20070801 18322 月次〆を追加

            // ADD 2010/03/26 MANTIS対応[15201]：支払一覧画面に｢入力担当者｣を表示へ変更 ---------->>>>>
            // FIXME:支払入力者名称
            dr[PaymentSlpSearch.COL_PAYMENT_INPUT_AGENT_NM] = paymentSlp.PaymentAgentName;
            // ADD 2010/03/26 MANTIS対応[15201]：支払一覧画面に｢入力担当者｣を表示へ変更 ----------<<<<<
            // ----- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
            dr[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERCDRF] = paymentSlp.SupplierCd;
            dr[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERNAME] = paymentSlp.SupplierSnm;
            // ----- ADD 王君 2012/12/24 Redmine#33741 -----<<<<<
        }

		/// <summary>
		/// 支払伝票一覧DataRow削除処理
		/// </summary>
		/// <param name="paymentSlp">支払伝票マスタ</param>
		/// <remarks>
		/// <br>Note		: 支払伝票一覧用の行を削除します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.24</br>
		/// </remarks>
		private void RemovePaymentDataFromDataTable(PaymentSlp paymentSlp)
		{
			// 支払伝票マスタをHashTableから削除
			if (_paymentSlpHashTable.ContainsKey(paymentSlp.PaymentSlipNo))
			{
				_paymentSlpHashTable.Remove(paymentSlp.PaymentSlipNo);
			}
			for (int ix = 0 ; ix != _dtPaymentInfo.Rows.Count ; ix++)
			{
				DataRow wkRow = _dtPaymentInfo.Rows[ix];
				int paymentSlipNo = TStrConv.StrToIntDef(wkRow[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].ToString(), 0);
				if (paymentSlp.PaymentSlipNo == paymentSlipNo)
				{
					_dtPaymentInfo.Rows.RemoveAt(ix);
					break;
				}
			}
        }

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 仕入先情報／支払金額情報取得処理
        /// </summary>
        /// <param name="searchPaymentParameter">検索パラメータ</param>
        /// <param name="custSuppli">仕入先情報マスタ</param>
        /// <param name="suplierPayParam">支払金額情報マスタ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 仕入先情報と支払金額情報を取得します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2006.05.24</br>
        /// </remarks>
        private int GetCustomPaymentInfo1(SearchPaymentParameter searchPaymentParameter, out SearchCustSuppliRet custSuppli, out SearchSuplierPayRet suplierPayParam)
        {
            // ↓ 20070520 18322 a MK.NS用に変更
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            custSuppli = null;
            suplierPayParam = null;

            //==========================
            // 得意先情報取得
            //==========================
            CustomerInfo customerInfo;
            CustSuppli customerSuppli;
            status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo
                                                               , out customerSuppli
                                                               , searchPaymentParameter.EnterpriseCode
                                                               , searchPaymentParameter.CustomerCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // データ無しの場合は、DBから読み込み
                status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0
                                                                       , searchPaymentParameter.EnterpriseCode
                                                                       , searchPaymentParameter.CustomerCode
                                                                       , true
                                                                       , out customerInfo
                                                                       , out customerSuppli);

            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    if (_searchCustSuppliRet == null)
                    {
                        _searchCustSuppliRet = new SearchCustSuppliRet();
                    }

                    // 得意先コード
                    _searchCustSuppliRet.CustomerCode = customerInfo.CustomerCode;
                    // 名称2
                    _searchCustSuppliRet.Name = customerInfo.Name;
                    // 名称2
                    _searchCustSuppliRet.Name2 = customerInfo.Name2;
                    // カナ
                    _searchCustSuppliRet.Kana = customerInfo.Kana;
                    // 略称
                    _searchCustSuppliRet.SNm = customerInfo.CustomerSnm;

                    // 主連絡先区分
                    _searchCustSuppliRet.MainContactCode = customerInfo.MainContactCode;
                    // FAX番号（自宅）
                    _searchCustSuppliRet.HomeFaxNo = customerInfo.HomeFaxNo;
                    // 電話番号（自宅）
                    _searchCustSuppliRet.HomeTelNo = customerInfo.HomeTelNo;
                    // FAX番号（勤務先）
                    _searchCustSuppliRet.OfficeFaxNo = customerInfo.OfficeFaxNo;
                    // 電話番号（勤務先）
                    _searchCustSuppliRet.OfficeTelNo = customerInfo.OfficeTelNo;
                    // 電話番号（その他）
                    _searchCustSuppliRet.OthersTelNo = customerInfo.OthersTelNo;
                    // 電話番号（携帯）
                    _searchCustSuppliRet.PortableTelNo = customerInfo.PortableTelNo;

                    // 外注仕入先区分
                    _searchCustSuppliRet.OsrcSupplierDivCd = 0;
                    // 支払日 
                    _searchCustSuppliRet.PaymentDay = customerSuppli.PaymentDay;
                    // 支払月区分
                    _searchCustSuppliRet.PaymentMonthCode = customerSuppli.PaymentMonthCode;
                    // 支払月名称
                    _searchCustSuppliRet.PaymentMonthName = customerSuppli.PaymentMonthName;

                    // 仕入先消費税転嫁方式名称
                    _searchCustSuppliRet.SuppCTaxLayMethodNm = customerSuppli.SuppCTaxLayMethodNm;
                    // 締日
                    _searchCustSuppliRet.TotalDay = customerInfo.TotalDay;

                    // 支払先コード
                    _searchCustSuppliRet.PayeeCode = customerSuppli.PayeeCode;

                    // 支払先の情報を取得
                    status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0
                                                                           , searchPaymentParameter.EnterpriseCode
                                                                           , customerSuppli.PayeeCode
                                                                           , true
                                                                           , out customerInfo
                                                                           , out customerSuppli);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        _searchCustSuppliRet.PName = customerInfo.Name;
                        _searchCustSuppliRet.PName2 = customerInfo.Name2;
                        _searchCustSuppliRet.PSNm = customerInfo.CustomerSnm;
                    }

                    custSuppli = _searchCustSuppliRet.Clone();

                    status = GetCustomPaymentInfo2(searchPaymentParameter, out suplierPayParam);
                    if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                        (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                    {
                        // 仕入先情報は存在するので正常終了とする
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    _searchSuplierPayRet = suplierPayParam.Clone();

                    // 支払期間（開始）、支払期間（終了）
                    _searchCustSuppliRet.StartDateSpan = suplierPayParam.StartDateSpan;
                    _searchCustSuppliRet.EndDateSpan = suplierPayParam.EndDateSpan;

                    custSuppli.StartDateSpan = suplierPayParam.StartDateSpan;
                    custSuppli.EndDateSpan = suplierPayParam.EndDateSpan;

                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    _searchCustSuppliRet = null;
                    _searchSuplierPayRet = null;
                    custSuppli = _searchCustSuppliRet;
                    suplierPayParam = _searchSuplierPayRet;
                    this._errorMessage = "指定された条件で、仕入先は存在しませんでした。";
                    break;
                default:
                    this._errorMessage = "仕入先情報の取得に失敗しました。";
                    break;
            }
            // ↑ 20070520 18322 a 

            // ↓ 20070520 18322 d 支払準備処理の機能で仕入金額・支払金額の集計等を行う為
            //                     機能を変更
            #region オリジナル機能
            //// パラメータ初期化
            //KingetSuplierPayWork kingetSuplierPayWork;
            //custSuppli		= null;
            //suplierPayParam = null;
            //
            //// 支払KINGET処理
            //int status = _kingetSuplierPayAcs.Read(
            //	out kingetSuplierPayWork, searchPaymentParameter.EnterpriseCode,
            //	searchPaymentParameter.AddUpSecCode, searchPaymentParameter.CustomerCode, TDateTime.DateTimeToLongDate(searchPaymentParameter.AddUpADate));
            //
            //switch (status)
            //{
            //	case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
            //	{
            //		// クラスメンバーコピー処理（KINGET用仕入先支払金額ワーククラス⇒仕入先情報クラス）
            //		_searchCustSuppliRet = (SearchCustSuppliRet)DBAndXMLDataMergeParts.CopyPropertyInClass(kingetSuplierPayWork, typeof(SearchCustSuppliRet)); 
            //		// クラスメンバーコピー処理（KINGET用仕入先支払金額ワーククラス⇒支払金額情報クラス）
            //		_searchSuplierPayRet = (SearchSuplierPayRet)DBAndXMLDataMergeParts.CopyPropertyInClass(kingetSuplierPayWork, typeof(SearchSuplierPayRet));
            //	
            //        // ↓ 20070519 18322 a 前回締め日を設定
            //        this._cAddUpUpDate = _searchCustSuppliRet.StartDateSpan;
            //        // ↑ 20070519 18322 a
            //
            //		custSuppli		= _searchCustSuppliRet.Clone();
            //		suplierPayParam = _searchSuplierPayRet.Clone();
            //		break;
            //	}
            //	case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
            //	case (int)ConstantManagement.DB_Status.ctDB_EOF:
            //	{
            //		_searchCustSuppliRet= null;
            //		_searchSuplierPayRet= null;
            //		custSuppli		= _searchCustSuppliRet;
            //		suplierPayParam	= _searchSuplierPayRet;
            //		_errorMessage = "指定された条件で、仕入先は存在しませんでした。";
            //		break;
            //	}
            //	default:
            //	{
            //		_errorMessage = "仕入先情報の取得に失敗しました。";
            //		break;
            //	}
            //}
            #endregion
            // ↑ 20070520 18322 d

            return status;
        }
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更

        /// <summary>
		/// 仕入先情報／支払金額情報取得処理
		/// </summary>
		/// <param name="searchPaymentParameter">検索パラメータ</param>
		/// <param name="custSuppli">仕入先情報マスタ</param>
		/// <param name="suplierPayParam">支払金額情報マスタ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 仕入先情報と支払金額情報を取得します。</br>
		/// <br>Programmer	: 30414 忍 幸史</br>
		/// <br>Date		: 2008/07/08</br>
		/// </remarks>
		private int GetCustomPaymentInfo1(SearchPaymentParameter searchPaymentParameter, out SearchCustSuppliRet custSuppli, out SearchSuplierPayRet suplierPayParam)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            custSuppli = new SearchCustSuppliRet();
            suplierPayParam = new SearchSuplierPayRet();

            //==========================
            // 仕入先情報取得
            //==========================
            Supplier supplier;
            
            status = GetCustSuppli(out supplier,
                                     searchPaymentParameter.EnterpriseCode, 
                                     searchPaymentParameter.PayeeCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        this._searchCustSuppliRet = null;
                        this._searchSuplierPayRet = null;
                        custSuppli = _searchCustSuppliRet;
                        suplierPayParam = _searchSuplierPayRet;
                        this._errorMessage = "指定された条件で、仕入先は存在しませんでした。";
                        return (status);
                    }
                default:
                    {
                        this._errorMessage = "仕入先情報の取得に失敗しました。";
                        return (status);
                    }
            }

            if (this._searchCustSuppliRet == null)
            {
                this._searchCustSuppliRet = new SearchCustSuppliRet();
            }

            this._searchCustSuppliRet.SupplierCode = supplier.SupplierCd;                                           // 得意先コード
            this._searchCustSuppliRet.Name = supplier.SupplierNm1;                                                  // 名称1
            this._searchCustSuppliRet.Name2 = supplier.SupplierNm2;                                                 // 名称2
            this._searchCustSuppliRet.Kana = supplier.SupplierKana;                                                 // カナ
            this._searchCustSuppliRet.SNm = supplier.SupplierSnm;                                                   // 略称
            this._searchCustSuppliRet.OsrcSupplierDivCd = 0;                                                        // 外注仕入先区分
            this._searchCustSuppliRet.PaymentDay = supplier.PaymentDay;                                             // 支払日 
            this._searchCustSuppliRet.PaymentMonthCode = supplier.PaymentMonthCode;                                 // 支払月区分
            this._searchCustSuppliRet.PaymentMonthName = supplier.PaymentMonthName;                                 // 支払月名称
            this._searchCustSuppliRet.SuppCTaxLayMethodNm = Supplier.GetSuppCTaxLayCdName(supplier.SuppCTaxLayCd);  // 仕入先消費税転嫁方式名称
            this._searchCustSuppliRet.TotalDay = supplier.PaymentTotalDay;                                          // 締日
            this._searchCustSuppliRet.PayeeCode = supplier.PayeeCode;                                               // 支払先コード
            this._searchCustSuppliRet.PName = supplier.PayeeName;
            this._searchCustSuppliRet.PName2 = supplier.PayeeName2;
            this._searchCustSuppliRet.PSNm = supplier.PayeeSnm;

            custSuppli = this._searchCustSuppliRet.Clone();

            // 支払金額情報取得
            status = GetCustomPaymentInfo2(searchPaymentParameter, out suplierPayParam);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
            {
                // 仕入先情報は存在するので正常終了とする
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            this._searchSuplierPayRet = suplierPayParam.Clone();

            // 支払期間（開始）、支払期間（終了）
            this._searchCustSuppliRet.StartDateSpan = suplierPayParam.StartDateSpan;
            this._searchCustSuppliRet.EndDateSpan = suplierPayParam.EndDateSpan;

            custSuppli.StartDateSpan = suplierPayParam.StartDateSpan;
            custSuppli.EndDateSpan = suplierPayParam.EndDateSpan;

            return (status);
		}

		/// <summary>
		/// 支払金額情報取得処理
		/// </summary>
		/// <param name="searchPaymentParameter">検索パラメータ</param>
		/// <param name="suplierPayParam">支払金額情報マスタ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 支払金額情報を取得します。</br>
		/// <br>Programmer	: 30414 忍 幸史</br>
		/// <br>Date		: 2006.05.24</br>
        /// <br>UpdateNote  : 2012/09/07 FSI上北田 秀樹 仕入総括対応</br> 
		/// </remarks>
		private int GetCustomPaymentInfo2(SearchPaymentParameter searchPaymentParameter, out SearchSuplierPayRet suplierPayParam)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            suplierPayParam = new SearchSuplierPayRet();

            string retMsg;

            // 仕入先支払金額マスタ生成
            SuplierPayWork suplierPayWork = new SuplierPayWork();
            suplierPayWork.EnterpriseCode = searchPaymentParameter.EnterpriseCode;
            suplierPayWork.AddUpSecCode   = searchPaymentParameter.AddUpSecCode;
            suplierPayWork.PayeeCode      = searchPaymentParameter.PayeeCode;
            //suplierPayWork.SupplierCd = searchPaymentParameter.SupplierCode;
            suplierPayWork.SupplierCd = searchPaymentParameter.PayeeCode;

            suplierPayWork.AddUpDate = GetCurrentTotalDayPayment(searchPaymentParameter.AddUpSecCode, searchPaymentParameter.PayeeCode);
            if (suplierPayWork.AddUpDate == DateTime.MinValue)
            {
                suplierPayWork.AddUpDate = searchPaymentParameter.AddUpADate;
            }

            // 指定した支払先の支払処理結果を取得
            object paraSuplierPayWork = (object)suplierPayWork;
            // --- DEL 2012/09/07 ----------------------------------------->>>>>
            //status = this._iSuplierPayDB.ReadSuplierPay(ref paraSuplierPayWork, out retMsg);
            // --- DEL 2012/09/07 -----------------------------------------<<<<<
            // --- ADD 2012/09/07 ----------------------------------------->>>>>
            if (_supplierSummary)
            {
                // 仕入総括オプションが有効の場合
                status = this._iSuplierPayDB.ReadSuplierPayByAddUpSecCode(ref paraSuplierPayWork, out retMsg);
            }
            else
            {
                // 仕入総括オプションが無効の場合
                status = this._iSuplierPayDB.ReadSuplierPay(ref paraSuplierPayWork, out retMsg);
            }
            // --- ADD 2012/09/07 -----------------------------------------<<<<<



            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 戻り値とエラーメッセージを返す。
                suplierPayParam = new SearchSuplierPayRet();
                this._errorMessage = retMsg ;
                return (status);
            }

            // 戻り値を変換
            suplierPayWork = paraSuplierPayWork as SuplierPayWork;
            if (suplierPayWork == null)
            {
                suplierPayParam = new SearchSuplierPayRet();
                this._errorMessage = "指定された条件で、支払金額情報は存在しませんでした。";
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            // クラスメンバーコピー処理(支払金額情報マスタワーク→支払金額情報マスタ)
            suplierPayParam = new SearchSuplierPayRet();
            suplierPayParam = CopyToSearchSuplierPayRetFromSuplierPayWork(suplierPayWork);

			return (status);
		}

        /// <summary>
        /// クラスメンバーコピー処理（支払伝票マスタワーク⇒支払伝票マスタ）
        /// </summary>
        /// <param name="paymentSlpWork">支払伝票マスタワーククラス</param>
        /// <returns>支払伝票マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 支払伝票マスタワーククラスから支払伝票マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/08</br>
        /// </remarks>
        private PaymentSlp CopyToPaymentSlpFromPaymentSlpWork(PaymentDataWork paymentDataWork)
        {
            PaymentSlp paymentSlp = new PaymentSlp();

            paymentSlp.CreateDateTime = paymentDataWork.CreateDateTime;              // 作成日付
            paymentSlp.UpdateDateTime = paymentDataWork.UpdateDateTime;              // 更新日付
            paymentSlp.EnterpriseCode = paymentDataWork.EnterpriseCode;              // 企業コード
            paymentSlp.FileHeaderGuid = paymentDataWork.FileHeaderGuid;              // GUID
            paymentSlp.UpdEmployeeCode = paymentDataWork.UpdEmployeeCode;            // 更新従業員コード
            paymentSlp.UpdAssemblyId1 = paymentDataWork.UpdAssemblyId1;              // 更新アセンブリID1
            paymentSlp.UpdAssemblyId2 = paymentDataWork.UpdAssemblyId2;              // 更新アセンブリID2
            paymentSlp.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;        // 論理削除区分
            paymentSlp.DebitNoteDiv = paymentDataWork.DebitNoteDiv;                  // 赤伝区分
            paymentSlp.PaymentSlipNo = paymentDataWork.PaymentSlipNo;                // 支払伝票番号
            paymentSlp.SupplierCd = paymentDataWork.SupplierCd;                      // 仕入先コード
            paymentSlp.SupplierNm1 = paymentDataWork.SupplierNm1;                    // 仕入先名1
            paymentSlp.SupplierNm2 = paymentDataWork.SupplierNm2;                    // 仕入先名2
            paymentSlp.SupplierSnm = paymentDataWork.SupplierSnm;                    // 仕入先略称
            paymentSlp.PayeeCode = paymentDataWork.PayeeCode;                        // 支払先コード
            paymentSlp.PayeeName = paymentDataWork.PayeeName;                        // 支払先名称
            paymentSlp.PayeeName2 = paymentDataWork.PayeeName2;                      // 支払先名称2
            paymentSlp.PayeeSnm = paymentDataWork.PayeeSnm;                          // 支払先略称
            paymentSlp.PaymentInpSectionCd = paymentDataWork.PaymentInpSectionCd;    // 支払入力拠点コード
            paymentSlp.AddUpSecCode = paymentDataWork.AddUpSecCode;                  // 計上拠点コード
            paymentSlp.UpdateSecCd = paymentDataWork.UpdateSecCd;                    // 更新拠点コード
            paymentSlp.PaymentDate = paymentDataWork.PaymentDate;                    // 支払日付
            paymentSlp.AddUpADate = paymentDataWork.AddUpADate;                      // 計上日付
            paymentSlp.PaymentTotal = paymentDataWork.PaymentTotal;                  // 支払計
            paymentSlp.Payment = paymentDataWork.Payment;                            // 支払金額
            paymentSlp.FeePayment = paymentDataWork.FeePayment;                      // 手数料支払額
            paymentSlp.DiscountPayment = paymentDataWork.DiscountPayment;            // 値引支払額
            paymentSlp.AutoPayment = paymentDataWork.AutoPayment;                    // 自動支払区分
            paymentSlp.DraftDrawingDate = paymentDataWork.DraftDrawingDate;          // 手形振出日
            paymentSlp.DebitNoteLinkPayNo = paymentDataWork.DebitNoteLinkPayNo;      // 赤黒支払連結番号
            paymentSlp.PaymentAgentCode = paymentDataWork.PaymentAgentCode;          // 支払担当者コード
            paymentSlp.PaymentAgentName = paymentDataWork.PaymentAgentName;          // 支払担当者名称
            paymentSlp.Outline = paymentDataWork.Outline;                            // 伝票摘要
            paymentSlp.DraftKind = paymentDataWork.DraftKind;                        // 手形種類
            paymentSlp.DraftKindName = paymentDataWork.DraftKindName;                // 手形種類名称
            paymentSlp.DraftDivide = paymentDataWork.DraftDivide;                    // 手形区分
            paymentSlp.DraftDivideName = paymentDataWork.DraftDivideName;            // 手形区分名称
            paymentSlp.DraftNo = paymentDataWork.DraftNo;                            // 手形番号
            paymentSlp.BankCode = paymentDataWork.BankCode;                          // 銀行コード
            paymentSlp.BankName = paymentDataWork.BankName;                          // 銀行名称
            paymentSlp.CAddUpUpdDate = TDateTime.DateTimeToLongDate(this._lastAddUpDay);                           // 締日計上日付
            paymentSlp.PaymentRowNoDtl = new int[10];
            paymentSlp.PaymentRowNoDtl[0] = paymentDataWork.PaymentRowNo1;
            paymentSlp.PaymentRowNoDtl[1] = paymentDataWork.PaymentRowNo2;
            paymentSlp.PaymentRowNoDtl[2] = paymentDataWork.PaymentRowNo3;
            paymentSlp.PaymentRowNoDtl[3] = paymentDataWork.PaymentRowNo4;
            paymentSlp.PaymentRowNoDtl[4] = paymentDataWork.PaymentRowNo5;
            paymentSlp.PaymentRowNoDtl[5] = paymentDataWork.PaymentRowNo6;
            paymentSlp.PaymentRowNoDtl[6] = paymentDataWork.PaymentRowNo7;
            paymentSlp.PaymentRowNoDtl[7] = paymentDataWork.PaymentRowNo8;
            paymentSlp.PaymentRowNoDtl[8] = paymentDataWork.PaymentRowNo9;
            paymentSlp.PaymentRowNoDtl[9] = paymentDataWork.PaymentRowNo10;
            paymentSlp.MoneyKindCodeDtl = new int[10];
            paymentSlp.MoneyKindCodeDtl[0] = paymentDataWork.MoneyKindCode1;
            paymentSlp.MoneyKindCodeDtl[1] = paymentDataWork.MoneyKindCode2;
            paymentSlp.MoneyKindCodeDtl[2] = paymentDataWork.MoneyKindCode3;
            paymentSlp.MoneyKindCodeDtl[3] = paymentDataWork.MoneyKindCode4;
            paymentSlp.MoneyKindCodeDtl[4] = paymentDataWork.MoneyKindCode5;
            paymentSlp.MoneyKindCodeDtl[5] = paymentDataWork.MoneyKindCode6;
            paymentSlp.MoneyKindCodeDtl[6] = paymentDataWork.MoneyKindCode7;
            paymentSlp.MoneyKindCodeDtl[7] = paymentDataWork.MoneyKindCode8;
            paymentSlp.MoneyKindCodeDtl[8] = paymentDataWork.MoneyKindCode9;
            paymentSlp.MoneyKindCodeDtl[9] = paymentDataWork.MoneyKindCode10;
            paymentSlp.MoneyKindNameDtl = new string[10];
            paymentSlp.MoneyKindNameDtl[0] = paymentDataWork.MoneyKindName1;
            paymentSlp.MoneyKindNameDtl[1] = paymentDataWork.MoneyKindName2;
            paymentSlp.MoneyKindNameDtl[2] = paymentDataWork.MoneyKindName3;
            paymentSlp.MoneyKindNameDtl[3] = paymentDataWork.MoneyKindName4;
            paymentSlp.MoneyKindNameDtl[4] = paymentDataWork.MoneyKindName5;
            paymentSlp.MoneyKindNameDtl[5] = paymentDataWork.MoneyKindName6;
            paymentSlp.MoneyKindNameDtl[6] = paymentDataWork.MoneyKindName7;
            paymentSlp.MoneyKindNameDtl[7] = paymentDataWork.MoneyKindName8;
            paymentSlp.MoneyKindNameDtl[8] = paymentDataWork.MoneyKindName9;
            paymentSlp.MoneyKindNameDtl[9] = paymentDataWork.MoneyKindName10;
            paymentSlp.MoneyKindDivDtl = new int[10];
            paymentSlp.MoneyKindDivDtl[0] = paymentDataWork.MoneyKindDiv1;
            paymentSlp.MoneyKindDivDtl[1] = paymentDataWork.MoneyKindDiv2;
            paymentSlp.MoneyKindDivDtl[2] = paymentDataWork.MoneyKindDiv3;
            paymentSlp.MoneyKindDivDtl[3] = paymentDataWork.MoneyKindDiv4;
            paymentSlp.MoneyKindDivDtl[4] = paymentDataWork.MoneyKindDiv5;
            paymentSlp.MoneyKindDivDtl[5] = paymentDataWork.MoneyKindDiv6;
            paymentSlp.MoneyKindDivDtl[6] = paymentDataWork.MoneyKindDiv7;
            paymentSlp.MoneyKindDivDtl[7] = paymentDataWork.MoneyKindDiv8;
            paymentSlp.MoneyKindDivDtl[8] = paymentDataWork.MoneyKindDiv9;
            paymentSlp.MoneyKindDivDtl[9] = paymentDataWork.MoneyKindDiv10;
            paymentSlp.PaymentDtl = new long[10];
            paymentSlp.PaymentDtl[0] = paymentDataWork.Payment1;
            paymentSlp.PaymentDtl[1] = paymentDataWork.Payment2;
            paymentSlp.PaymentDtl[2] = paymentDataWork.Payment3;
            paymentSlp.PaymentDtl[3] = paymentDataWork.Payment4;
            paymentSlp.PaymentDtl[4] = paymentDataWork.Payment5;
            paymentSlp.PaymentDtl[5] = paymentDataWork.Payment6;
            paymentSlp.PaymentDtl[6] = paymentDataWork.Payment7;
            paymentSlp.PaymentDtl[7] = paymentDataWork.Payment8;
            paymentSlp.PaymentDtl[8] = paymentDataWork.Payment9;
            paymentSlp.PaymentDtl[9] = paymentDataWork.Payment10;
            paymentSlp.ValidityTermDtl = new DateTime[10];
            paymentSlp.ValidityTermDtl[0] = paymentDataWork.ValidityTerm1;
            paymentSlp.ValidityTermDtl[1] = paymentDataWork.ValidityTerm2;
            paymentSlp.ValidityTermDtl[2] = paymentDataWork.ValidityTerm3;
            paymentSlp.ValidityTermDtl[3] = paymentDataWork.ValidityTerm4;
            paymentSlp.ValidityTermDtl[4] = paymentDataWork.ValidityTerm5;
            paymentSlp.ValidityTermDtl[5] = paymentDataWork.ValidityTerm6;
            paymentSlp.ValidityTermDtl[6] = paymentDataWork.ValidityTerm7;
            paymentSlp.ValidityTermDtl[7] = paymentDataWork.ValidityTerm8;
            paymentSlp.ValidityTermDtl[8] = paymentDataWork.ValidityTerm9;
            paymentSlp.ValidityTermDtl[9] = paymentDataWork.ValidityTerm10;

            return paymentSlp;
        }

        /// <summary>
        /// クラスメンバーコピー処理（支払伝票マスタ検索クラス⇒支払伝票マスタクラス）
        /// </summary>
        /// <param name="searchPaymentSlp">支払伝票マスタ検索クラス</param>
        /// <returns>支払伝票マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 支払伝票マスタ検索クラスから支払伝票マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/08</br>
        /// </remarks>
        private PaymentSlp CopyToPaymentSlpFromSearchPaymentSlp(SearchPaymentSlp searchPaymentSlp)
        {
            PaymentSlp paymentSlp = new PaymentSlp();

            paymentSlp.CreateDateTime = searchPaymentSlp.CreateDateTime;              // 作成日付
            paymentSlp.UpdateDateTime = searchPaymentSlp.UpdateDateTime;              // 更新日付
            paymentSlp.EnterpriseCode = searchPaymentSlp.EnterpriseCode;              // 企業コード
            paymentSlp.FileHeaderGuid = searchPaymentSlp.FileHeaderGuid;              // GUID
            paymentSlp.UpdEmployeeCode = searchPaymentSlp.UpdEmployeeCode;            // 更新従業員コード
            paymentSlp.UpdAssemblyId1 = searchPaymentSlp.UpdAssemblyId1;              // 更新アセンブリID1
            paymentSlp.UpdAssemblyId2 = searchPaymentSlp.UpdAssemblyId2;              // 更新アセンブリID2
            paymentSlp.LogicalDeleteCode = searchPaymentSlp.LogicalDeleteCode;        // 論理削除区分
            paymentSlp.DebitNoteDiv = searchPaymentSlp.DebitNoteDiv;                  // 赤伝区分
            paymentSlp.PaymentSlipNo = searchPaymentSlp.PaymentSlipNo;                // 支払伝票番号
            paymentSlp.SupplierCd = searchPaymentSlp.SupplierCd;                      // 仕入先コード
            paymentSlp.SupplierNm1 = searchPaymentSlp.SupplierNm1;                    // 仕入先名1
            paymentSlp.SupplierNm2 = searchPaymentSlp.SupplierNm2;                    // 仕入先名2
            paymentSlp.SupplierSnm = searchPaymentSlp.SupplierSnm;                    // 仕入先略称
            paymentSlp.PayeeCode = searchPaymentSlp.PayeeCode;                        // 支払先コード
            paymentSlp.PayeeName = searchPaymentSlp.PayeeName;                        // 支払先名称
            paymentSlp.PayeeName2 = searchPaymentSlp.PayeeName2;                      // 支払先名称2
            paymentSlp.PayeeSnm = searchPaymentSlp.PayeeSnm;                          // 支払先略称
            paymentSlp.PaymentInpSectionCd = searchPaymentSlp.PaymentInpSectionCd;    // 支払入力拠点コード
            paymentSlp.AddUpSecCode = searchPaymentSlp.AddUpSecCode;                  // 計上拠点コード
            paymentSlp.UpdateSecCd = searchPaymentSlp.UpdateSecCd;                    // 更新拠点コード
            paymentSlp.PaymentDate = searchPaymentSlp.PaymentDate;                    // 支払日付
            paymentSlp.AddUpADate = searchPaymentSlp.AddUpADate;                      // 計上日付
            paymentSlp.PaymentTotal = searchPaymentSlp.PaymentTotal;                  // 支払計
            paymentSlp.Payment = searchPaymentSlp.Payment;                            // 支払金額
            paymentSlp.FeePayment = searchPaymentSlp.FeePayment;                      // 手数料支払額
            paymentSlp.DiscountPayment = searchPaymentSlp.DiscountPayment;            // 値引支払額
            paymentSlp.AutoPayment = searchPaymentSlp.AutoPayment;                    // 自動支払区分
            paymentSlp.DraftDrawingDate = searchPaymentSlp.DraftDrawingDate;          // 手形振出日
            paymentSlp.DebitNoteLinkPayNo = searchPaymentSlp.DebitNoteLinkPayNo;      // 赤黒支払連結番号
            paymentSlp.PaymentAgentCode = searchPaymentSlp.PaymentAgentCode;          // 支払担当者コード
            paymentSlp.PaymentAgentName = searchPaymentSlp.PaymentAgentName;          // 支払担当者名称
            paymentSlp.Outline = searchPaymentSlp.Outline;                            // 伝票摘要
            paymentSlp.DraftKind = searchPaymentSlp.DraftKind;                        // 手形種類
            paymentSlp.DraftKindName = searchPaymentSlp.DraftKindName;                // 手形種類名称
            paymentSlp.DraftDivide = searchPaymentSlp.DraftDivide;                    // 手形区分
            paymentSlp.DraftDivideName = searchPaymentSlp.DraftDivideName;            // 手形区分名称
            paymentSlp.DraftNo = searchPaymentSlp.DraftNo;                            // 手形番号
            paymentSlp.BankCode = searchPaymentSlp.BankCode;                          // 銀行コード
            paymentSlp.BankName = searchPaymentSlp.BankName;                          // 銀行名称
            paymentSlp.CAddUpUpdDate = TDateTime.DateTimeToLongDate(this._lastAddUpDay);                           // 締日計上日付
            paymentSlp.PaymentRowNoDtl = new int[10];
            paymentSlp.PaymentRowNoDtl[0] = searchPaymentSlp.PaymentRowNoDtl[0];
            paymentSlp.PaymentRowNoDtl[1] = searchPaymentSlp.PaymentRowNoDtl[1];
            paymentSlp.PaymentRowNoDtl[2] = searchPaymentSlp.PaymentRowNoDtl[2];
            paymentSlp.PaymentRowNoDtl[3] = searchPaymentSlp.PaymentRowNoDtl[3];
            paymentSlp.PaymentRowNoDtl[4] = searchPaymentSlp.PaymentRowNoDtl[4];
            paymentSlp.PaymentRowNoDtl[5] = searchPaymentSlp.PaymentRowNoDtl[5];
            paymentSlp.PaymentRowNoDtl[6] = searchPaymentSlp.PaymentRowNoDtl[6];
            paymentSlp.PaymentRowNoDtl[7] = searchPaymentSlp.PaymentRowNoDtl[7];
            paymentSlp.PaymentRowNoDtl[8] = searchPaymentSlp.PaymentRowNoDtl[8];
            paymentSlp.PaymentRowNoDtl[9] = searchPaymentSlp.PaymentRowNoDtl[9];
            paymentSlp.MoneyKindCodeDtl = new int[10];
            paymentSlp.MoneyKindCodeDtl[0] = searchPaymentSlp.MoneyKindCodeDtl[0];
            paymentSlp.MoneyKindCodeDtl[1] = searchPaymentSlp.MoneyKindCodeDtl[1];
            paymentSlp.MoneyKindCodeDtl[2] = searchPaymentSlp.MoneyKindCodeDtl[2];
            paymentSlp.MoneyKindCodeDtl[3] = searchPaymentSlp.MoneyKindCodeDtl[3];
            paymentSlp.MoneyKindCodeDtl[4] = searchPaymentSlp.MoneyKindCodeDtl[4];
            paymentSlp.MoneyKindCodeDtl[5] = searchPaymentSlp.MoneyKindCodeDtl[5];
            paymentSlp.MoneyKindCodeDtl[6] = searchPaymentSlp.MoneyKindCodeDtl[6];
            paymentSlp.MoneyKindCodeDtl[7] = searchPaymentSlp.MoneyKindCodeDtl[7];
            paymentSlp.MoneyKindCodeDtl[8] = searchPaymentSlp.MoneyKindCodeDtl[8];
            paymentSlp.MoneyKindCodeDtl[9] = searchPaymentSlp.MoneyKindCodeDtl[9];
            paymentSlp.MoneyKindNameDtl = new string[10];
            paymentSlp.MoneyKindNameDtl[0] = searchPaymentSlp.MoneyKindNameDtl[0];
            paymentSlp.MoneyKindNameDtl[1] = searchPaymentSlp.MoneyKindNameDtl[1];
            paymentSlp.MoneyKindNameDtl[2] = searchPaymentSlp.MoneyKindNameDtl[2];
            paymentSlp.MoneyKindNameDtl[3] = searchPaymentSlp.MoneyKindNameDtl[3];
            paymentSlp.MoneyKindNameDtl[4] = searchPaymentSlp.MoneyKindNameDtl[4];
            paymentSlp.MoneyKindNameDtl[5] = searchPaymentSlp.MoneyKindNameDtl[5];
            paymentSlp.MoneyKindNameDtl[6] = searchPaymentSlp.MoneyKindNameDtl[6];
            paymentSlp.MoneyKindNameDtl[7] = searchPaymentSlp.MoneyKindNameDtl[7];
            paymentSlp.MoneyKindNameDtl[8] = searchPaymentSlp.MoneyKindNameDtl[8];
            paymentSlp.MoneyKindNameDtl[9] = searchPaymentSlp.MoneyKindNameDtl[9];
            paymentSlp.MoneyKindDivDtl = new int[10];
            paymentSlp.MoneyKindDivDtl[0] = searchPaymentSlp.MoneyKindDivDtl[0];
            paymentSlp.MoneyKindDivDtl[1] = searchPaymentSlp.MoneyKindDivDtl[1];
            paymentSlp.MoneyKindDivDtl[2] = searchPaymentSlp.MoneyKindDivDtl[2];
            paymentSlp.MoneyKindDivDtl[3] = searchPaymentSlp.MoneyKindDivDtl[3];
            paymentSlp.MoneyKindDivDtl[4] = searchPaymentSlp.MoneyKindDivDtl[4];
            paymentSlp.MoneyKindDivDtl[5] = searchPaymentSlp.MoneyKindDivDtl[5];
            paymentSlp.MoneyKindDivDtl[6] = searchPaymentSlp.MoneyKindDivDtl[6];
            paymentSlp.MoneyKindDivDtl[7] = searchPaymentSlp.MoneyKindDivDtl[7];
            paymentSlp.MoneyKindDivDtl[8] = searchPaymentSlp.MoneyKindDivDtl[8];
            paymentSlp.MoneyKindDivDtl[9] = searchPaymentSlp.MoneyKindDivDtl[9];
            paymentSlp.PaymentDtl = new long[10];
            paymentSlp.PaymentDtl[0] = searchPaymentSlp.PaymentDtl[0];
            paymentSlp.PaymentDtl[1] = searchPaymentSlp.PaymentDtl[1];
            paymentSlp.PaymentDtl[2] = searchPaymentSlp.PaymentDtl[2];
            paymentSlp.PaymentDtl[3] = searchPaymentSlp.PaymentDtl[3];
            paymentSlp.PaymentDtl[4] = searchPaymentSlp.PaymentDtl[4];
            paymentSlp.PaymentDtl[5] = searchPaymentSlp.PaymentDtl[5];
            paymentSlp.PaymentDtl[6] = searchPaymentSlp.PaymentDtl[6];
            paymentSlp.PaymentDtl[7] = searchPaymentSlp.PaymentDtl[7];
            paymentSlp.PaymentDtl[8] = searchPaymentSlp.PaymentDtl[8];
            paymentSlp.PaymentDtl[9] = searchPaymentSlp.PaymentDtl[9];
            paymentSlp.ValidityTermDtl = new DateTime[10];
            paymentSlp.ValidityTermDtl[0] = searchPaymentSlp.ValidityTermDtl[0];
            paymentSlp.ValidityTermDtl[1] = searchPaymentSlp.ValidityTermDtl[1];
            paymentSlp.ValidityTermDtl[2] = searchPaymentSlp.ValidityTermDtl[2];
            paymentSlp.ValidityTermDtl[3] = searchPaymentSlp.ValidityTermDtl[3];
            paymentSlp.ValidityTermDtl[4] = searchPaymentSlp.ValidityTermDtl[4];
            paymentSlp.ValidityTermDtl[5] = searchPaymentSlp.ValidityTermDtl[5];
            paymentSlp.ValidityTermDtl[6] = searchPaymentSlp.ValidityTermDtl[6];
            paymentSlp.ValidityTermDtl[7] = searchPaymentSlp.ValidityTermDtl[7];
            paymentSlp.ValidityTermDtl[8] = searchPaymentSlp.ValidityTermDtl[8];
            paymentSlp.ValidityTermDtl[9] = searchPaymentSlp.ValidityTermDtl[9];
            
            return paymentSlp;
        }

        /// <summary>
        /// クラスメンバーコピー処理（支払金額情報マスタワーク⇒支払金額情報マスタ）
        /// </summary>
        /// <param name="suplierPayWork">支払金額情報マスタワーククラス</param>
        /// <returns>支払金額情報マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 支払金額情報マスタワーククラスから支払金額情報マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/08</br>
        /// </remarks>
        private SearchSuplierPayRet CopyToSearchSuplierPayRetFromSuplierPayWork(SuplierPayWork suplierPayWork)
        {
            SearchSuplierPayRet searchSuplierPayRet = new SearchSuplierPayRet();

            searchSuplierPayRet.CreateDateTime = suplierPayWork.CreateDateTime;             // 作成日時
            searchSuplierPayRet.UpdateDateTime = suplierPayWork.UpdateDateTime;             // 更新日時
            searchSuplierPayRet.EnterpriseCode = suplierPayWork.EnterpriseCode;             // 企業コード
            searchSuplierPayRet.FileHeaderGuid = suplierPayWork.FileHeaderGuid;             // GUID
            searchSuplierPayRet.UpdEmployeeCode = suplierPayWork.UpdEmployeeCode;           // 更新従業員コード
            searchSuplierPayRet.UpdAssemblyId1 = suplierPayWork.UpdAssemblyId1;             // 更新アセンブリID1
            searchSuplierPayRet.UpdAssemblyId2 = suplierPayWork.UpdAssemblyId2;             // 更新アセンブリID2
            searchSuplierPayRet.LogicalDeleteCode = suplierPayWork.LogicalDeleteCode;       // 論理削除区分
            searchSuplierPayRet.SupplierCode = suplierPayWork.SupplierCd;                   // 仕入先コード
            searchSuplierPayRet.SupplierName = suplierPayWork.SupplierNm1;                  // 仕入先名1
            searchSuplierPayRet.SupplierName2 = suplierPayWork.SupplierNm2;                 // 仕入先名2
            searchSuplierPayRet.SupplierSnm = suplierPayWork.SupplierSnm;                   // 仕入先略称
            searchSuplierPayRet.PayeeCode = suplierPayWork.PayeeCode;                       // 支払先コード
            searchSuplierPayRet.PayeeName = suplierPayWork.PayeeName;                       // 支払先名称
            searchSuplierPayRet.PayeeName2 = suplierPayWork.PayeeName2;                     // 支払先名称2
            searchSuplierPayRet.PayeeSnm = suplierPayWork.PayeeSnm;                         // 支払先略称
            searchSuplierPayRet.AddUpDate = suplierPayWork.AddUpDate;                       // 計上年月日
            searchSuplierPayRet.AddUpYearMonth = suplierPayWork.AddUpYearMonth;             // 計上年月
            searchSuplierPayRet.LastTimePayment = suplierPayWork.LastTimePayment;           // 前回支払金額
            searchSuplierPayRet.ThisTimePayNrml = suplierPayWork.ThisTimePayNrml;           // 今回支払金額（通常支払）
            searchSuplierPayRet.ThisTimeFeePayNrml = suplierPayWork.ThisTimeFeePayNrml;     // 今回手数料額（通常支払）
            searchSuplierPayRet.ThisTimeDisPayNrml = suplierPayWork.ThisTimeDisPayNrml;     // 今回値引額（通常支払）
            searchSuplierPayRet.ThisTimeTtlBlcPay = suplierPayWork.ThisTimeTtlBlcPay;       // 今回繰越残高（支払計）
            searchSuplierPayRet.ItdedOffsetOutTax = suplierPayWork.ItdedOffsetOutTax;       // 相殺後外税対象額
            searchSuplierPayRet.ItdedOffsetInTax = suplierPayWork.ItdedOffsetInTax;         // 相殺後内税対象額
            searchSuplierPayRet.ItdedOffsetTaxFree = suplierPayWork.ItdedOffsetTaxFree;     // 相殺後非課税対象額
            searchSuplierPayRet.OffsetOutTax = suplierPayWork.OffsetOutTax;                 // 相殺後外税消費税
            searchSuplierPayRet.OffsetInTax = suplierPayWork.OffsetInTax;                   // 相殺後内税消費税
            searchSuplierPayRet.ThisTimeStockPrice = suplierPayWork.ThisTimeStockPrice;     // 今回仕入金額
            searchSuplierPayRet.ThisStcPrcTax = suplierPayWork.ThisStcPrcTax;               // 今回仕入消費税
            searchSuplierPayRet.TtlItdedStcOutTax = suplierPayWork.TtlItdedStcOutTax;       // 仕入外税対象額合計
            searchSuplierPayRet.TtlItdedStcInTax = suplierPayWork.TtlItdedStcInTax;         // 仕入内税対象額合計
            searchSuplierPayRet.TtlItdedStcTaxFree = suplierPayWork.TtlItdedStcTaxFree;     // 仕入非課税対象額合計
            searchSuplierPayRet.TtlStockOuterTax = suplierPayWork.TtlStockOuterTax;         // 仕入外税額合計
            searchSuplierPayRet.TtlStockInnerTax = suplierPayWork.TtlStockInnerTax;         // 仕入内税額合計
            searchSuplierPayRet.ThisStckPricRgds = suplierPayWork.ThisStckPricRgds;         // 今回返品金額
            searchSuplierPayRet.ThisStcPrcTaxRgds = suplierPayWork.ThisStcPrcTaxRgds;       // 今回返品消費税
            searchSuplierPayRet.TtlItdedRetOutTax = suplierPayWork.TtlItdedRetOutTax;       // 返品外税対象額合計
            searchSuplierPayRet.TtlItdedRetInTax = suplierPayWork.TtlItdedRetInTax;         // 返品内税対象額合計
            searchSuplierPayRet.TtlItdedRetTaxFree = suplierPayWork.TtlItdedRetTaxFree;     // 返品非課税対象額合計
            searchSuplierPayRet.TtlRetOuterTax = suplierPayWork.TtlRetOuterTax;             // 返品外税額合計
            searchSuplierPayRet.TtlRetInnerTax = suplierPayWork.TtlRetInnerTax;             // 返品内税額合計
            searchSuplierPayRet.SuppCTaxLayCd = suplierPayWork.SuppCTaxLayCd;               // 仕入先消費税転嫁方式コード
            searchSuplierPayRet.SupplierConsTaxRate = suplierPayWork.SupplierConsTaxRate;   // 仕入先消費税税率
            searchSuplierPayRet.FractionProcCd = suplierPayWork.FractionProcCd;             // 端数処理区分
            searchSuplierPayRet.StockTotalPayBalance = suplierPayWork.StockTotalPayBalance; // 仕入合計残高（支払計）
            searchSuplierPayRet.StockTtl2TmBfBlPay = suplierPayWork.StockTtl2TmBfBlPay;     // 仕入2回前残高（支払計）  
            searchSuplierPayRet.StockTtl3TmBfBlPay = suplierPayWork.StockTtl3TmBfBlPay;     // 仕入3回前残高（支払計）
            searchSuplierPayRet.CAddUpUpdExecDate = suplierPayWork.CAddUpUpdExecDate;       // 締次更新実行年月日
            searchSuplierPayRet.StartCAddUpUpdDate = suplierPayWork.StartCAddUpUpdDate;     // 締次更新開始年月日
            searchSuplierPayRet.LastCAddUpUpdDate = suplierPayWork.LastCAddUpUpdDate;       // 前回締次更新年月日
            searchSuplierPayRet.OfsThisTimeStock = suplierPayWork.OfsThisTimeStock;       // 相殺後今回仕入金額
            searchSuplierPayRet.OfsThisStockTax = suplierPayWork.OfsThisStockTax;       // 相殺後今回仕入消費税額

            if (searchSuplierPayRet.LastCAddUpUpdDate == DateTime.MinValue)
            {
                // 日付範囲（開始）
                searchSuplierPayRet.StartDateSpan = TDateTime.DateTimeToLongDate(DateTime.MinValue);

                /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
                // 日付範囲（終了）
                Int32 endDateSpan = TDateTime.DateTimeToLongDate(suplierPayWork.AddUpDate);

                if (suplierPayWork.AddUpDate.Day > suplierPayWork.CustomerTotalDay)
                {
                    endDateSpan = TDateTime.DateTimeToLongDate(suplierPayWork.AddUpDate.AddMonths(1));
                }
                endDateSpan = endDateSpan - suplierPayWork.AddUpDate.Day + suplierPayWork.CustomerTotalDay;
                
                searchSuplierPayRet.EndDateSpan = endDateSpan;
                   --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
            }
            else
            {
                // 日付範囲（開始）
                searchSuplierPayRet.StartDateSpan = TDateTime.DateTimeToLongDate(suplierPayWork.StartCAddUpUpdDate);

                // 日付範囲（終了）
                if (DateTime.DaysInMonth(suplierPayWork.LastCAddUpUpdDate.Year, suplierPayWork.LastCAddUpUpdDate.Month) == suplierPayWork.LastCAddUpUpdDate.Day)
                {
                    // 前回月末で締め処理したときは、今回も月末にする。
                    DateTime dt = suplierPayWork.LastCAddUpUpdDate.AddMonths(1);
                    searchSuplierPayRet.EndDateSpan = TDateTime.DateTimeToLongDate(dt);
                    searchSuplierPayRet.EndDateSpan = Convert.ToInt32(Math.Truncate(Convert.ToDouble(searchSuplierPayRet.EndDateSpan / 100)));
                    searchSuplierPayRet.EndDateSpan = searchSuplierPayRet.EndDateSpan * 100;
                    searchSuplierPayRet.EndDateSpan += DateTime.DaysInMonth(dt.Year, dt.Month);
                }
                else
                {
                    // 月末以外で締め処理
                    searchSuplierPayRet.EndDateSpan = TDateTime.DateTimeToLongDate(suplierPayWork.LastCAddUpUpdDate.AddMonths(1));
                }
            }

            // 今回支払計 ＝ 今回支払金額（通常支払）＋今回手数料額（通常支払）
            //            ＋ 今回値引額（通常支払）  ＋今回リベート額（通常支払）
            searchSuplierPayRet.ThisTimePaymentMeter = suplierPayWork.ThisTimePayNrml
                                                 + suplierPayWork.ThisTimeFeePayNrml
                                                 + suplierPayWork.ThisTimeDisPayNrml;

            // 相殺後仕入計 ＝ 相殺後外税対象額＋相殺後内税対象額＋相殺後非課税対象額
            searchSuplierPayRet.StcMtrAfOffset = suplierPayWork.ItdedOffsetOutTax
                                           + suplierPayWork.ItdedOffsetInTax
                                           + suplierPayWork.ItdedOffsetTaxFree;

            // 相殺後仕入消費税計 ＝ 相殺後外税消費税＋相殺後内税消費税
            searchSuplierPayRet.StcConsTaxMtrAfOffset = suplierPayWork.OffsetOutTax
                                                  + suplierPayWork.OffsetInTax;

            //// 前回締日を設定
            //this._cAddUpUpDate = TDateTime.DateTimeToLongDate(suplierPayWork.LastCAddUpUpdDate);

            // 残高合計
            searchSuplierPayRet.BlnceTtl = suplierPayWork.StockTtl3TmBfBlPay
                                     + suplierPayWork.StockTtl2TmBfBlPay
                                     + suplierPayWork.StockTotalPayBalance;
            // 差引残高
            searchSuplierPayRet.Balance = suplierPayWork.StockTtl3TmBfBlPay
                                    + suplierPayWork.StockTtl2TmBfBlPay
                                    + suplierPayWork.StockTotalPayBalance
                                    + suplierPayWork.ThisTimePayNrml; 

            return searchSuplierPayRet;
        }

        // ↓ 20070519 18322 d MK.NSでは使用しないため削除
        #region 前回締次更新年月日取得処理
        ///// <summary>
		///// 前回締次更新年月日取得処理
		///// </summary>
		///// <param name="enterpriseCode">企業コード</param>
		///// <param name="totalDay">締日</param>
		///// <param name="cAddUpUpDate">締次更新年月日</param>
		///// <returns>ステータス</returns>
		///// <remarks>
		///// <br>Note		: 指定する締日に対する締次更新年月日を取得します。</br>
		///// <br>Programmer	: 22024 寺坂　誉志</br>
		///// <br>Date		: 2006.05.24</br>
		///// </remarks>
		//private int GetCAddUpHisInfo(string enterpriseCode, int totalDay, out int cAddUpUpDate)
		//{
		//	CAddUpHis[] cAddUpHis;
		//	cAddUpUpDate = 0;
		//
		//	// 締次更新履歴取得処理
		//	int status = _cAddUpHisAcs.SearchLastCAddUpHis(out cAddUpHis, enterpriseCode, totalDay, 0);
		//
		//	switch (status)
		//	{
		//		case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
		//		{
		//			// 締次更新年月日取得
		//			cAddUpUpDate = TDateTime.DateTimeToLongDate(cAddUpHis[0].CAddUpUpdDate);
		//			break;
		//		}
		//		case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
		//		case (int)ConstantManagement.DB_Status.ctDB_EOF:
		//		{
		//			// 締次更新年月日取得
		//			cAddUpUpDate = 0;
		//			break;
		//		}
		//		default:
		//		{
		//			_errorMessage = "締次更新履歴の取得に失敗しました。";
		//			break;
		//		}
		//	}
		//	_cAddUpUpDate = cAddUpUpDate;
		//
		//	return status;
		//}
        #endregion
        // ↑ 20070519 18322 d

        #region DEL 2008/07/08 Partsman用に変更
        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
		/// <summary>
        /// クラスメンバーコピー処理（支払伝票マスタワーククラス⇒支払伝票マスタクラス）
		/// </summary>
        /// <param name="paymentSlpWork">支払伝票マスタワーククラス</param>
        /// <returns>支払伝票マスタクラス</returns>
		/// <remarks>
        /// <br>Note       : 支払伝票マスタワーククラスから支払伝票マスタクラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 18322 木村 武正</br>
		/// <br>Date       : 2006.12.22</br>
		/// </remarks>
        private PaymentSlp CopyToPaymentSlpFromPaymentSlpWork(PaymentSlpWork paymentSlpWork)
        {
            PaymentSlp ret = new PaymentSlp();

            ret.CreateDateTime = paymentSlpWork.CreateDateTime;
            ret.UpdateDateTime = paymentSlpWork.UpdateDateTime;
            ret.EnterpriseCode = paymentSlpWork.EnterpriseCode;
            ret.FileHeaderGuid = paymentSlpWork.FileHeaderGuid;
            ret.UpdEmployeeCode = paymentSlpWork.UpdEmployeeCode;
            ret.UpdAssemblyId1 = paymentSlpWork.UpdAssemblyId1;
            ret.UpdAssemblyId2 = paymentSlpWork.UpdAssemblyId2;
            ret.LogicalDeleteCode = paymentSlpWork.LogicalDeleteCode;
            ret.DebitNoteDiv = paymentSlpWork.DebitNoteDiv;
            ret.PaymentSlipNo = paymentSlpWork.PaymentSlipNo;
            ret.CustomerCode = paymentSlpWork.CustomerCode;
            ret.CustomerName = paymentSlpWork.CustomerName;
            ret.CustomerName2 = paymentSlpWork.CustomerName2;
            ret.CustomerSnm = paymentSlpWork.CustomerSnm;
            ret.PayeeCode = paymentSlpWork.PayeeCode;
            ret.PayeeName = paymentSlpWork.PayeeName;
            ret.PayeeName2 = paymentSlpWork.PayeeName2;
            ret.PayeeSnm = paymentSlpWork.PayeeSnm;
            ret.PaymentInpSectionCd = paymentSlpWork.PaymentInpSectionCd;
            ret.AddUpSecCode = paymentSlpWork.AddUpSecCode;
            ret.UpdateSecCd = paymentSlpWork.UpdateSecCd;
            ret.PaymentDate = paymentSlpWork.PaymentDate;
            ret.AddUpADate = paymentSlpWork.AddUpADate;
            ret.PaymentMoneyKindCode = paymentSlpWork.PaymentMoneyKindCode;
            ret.PaymentMoneyKindName = paymentSlpWork.PaymentMoneyKindName;
            ret.PaymentMoneyKindDiv = paymentSlpWork.PaymentMoneyKindDiv;
            ret.PaymentTotal = paymentSlpWork.PaymentTotal;
            ret.Payment = paymentSlpWork.Payment;
            ret.FeePayment = paymentSlpWork.FeePayment;
            ret.DiscountPayment = paymentSlpWork.DiscountPayment;
            ret.RebatePayment = paymentSlpWork.RebatePayment;
            ret.AutoPayment = paymentSlpWork.AutoPayment;
            ret.CreditOrLoanCd = paymentSlpWork.CreditOrLoanCd;
            ret.CreditCompanyCode = paymentSlpWork.CreditCompanyCode;
            ret.DraftDrawingDate = paymentSlpWork.DraftDrawingDate;
            ret.DraftPayTimeLimit = paymentSlpWork.DraftPayTimeLimit;
            ret.DebitNoteLinkPayNo = paymentSlpWork.DebitNoteLinkPayNo;
            ret.PaymentAgentCode = paymentSlpWork.PaymentAgentCode;
            ret.PaymentAgentName = paymentSlpWork.PaymentAgentName;
            ret.Outline = paymentSlpWork.Outline;

            ret.CAddUpUpdDate = this._cAddUpUpDate;

            // 2007.09.05 hikita add start ------------------------------->>
            ret.DraftKind = paymentSlpWork.DraftKind;
            ret.DraftKindName = paymentSlpWork.DraftKindName;
            ret.DraftDivide = paymentSlpWork.DraftDivide;
            ret.DraftDivideName = paymentSlpWork.DraftDivideName;
            ret.DraftNo = paymentSlpWork.DraftNo;
            ret.BankCode = paymentSlpWork.BankCode;
            ret.BankName = paymentSlpWork.BankName;
            // 2007.09.05 hikita add end ---------------------------------<<

            return ret;
        }
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/08 Partsman用に変更

        // --- ADD 2012/09/07 ----------------------------------------->>>>>
        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オプション情報制御処理。</br>
        /// <br>Programmer : FSI上北田 秀樹</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ●仕入先総括オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SuppSumFunc);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._supplierSummary = true;
            }
            else
            {
                this._supplierSummary = false;
            }
            #endregion
        }
        // --- ADD 2012/09/07 -----------------------------------------<<<<<

        #endregion
    }
}
