//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ発注データアクセスクラス
// プログラム概要   : ＵＯＥ発注データアクセス制御を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2009/05/25  修正内容 : ホンダ UOE WEB対応
//----------------------------------------------------------------------------//
// 管理番号  XXXXXXXX-00 作成担当 : 長内 数馬
// 作 成 日  2011/10/27  修正内容 : 22008 長内 数馬 伝票明細追加情報セット不具合の修正
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : yangmj
// 作 成 日  2012/09/20  修正内容 : redmine#32404の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : chenw
// 作 成 日  2013/03/07  修正内容 : 2013/04/03配信分
//                                  Redmine#34989の対応 日産UOEWEBの改良(ＯＰＥＮ価格対応)
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : pengjie
// 作 成 日  2013/03/14  修正内容 : redmine#34986の対応 ＵＯＥ発注データの検索処理に、タイムアウトエラーメッセージ追加
//----------------------------------------------------------------------------//
// 管理番号  10902931-00 作成担当 : 譚洪
// 作 成 日  2013/08/15  修正内容 : 発注処理(自動)処理の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪権来
// 作 成 日  2014/01/24  修正内容 : Redmine#41551の対応 UOE消費税対応
//----------------------------------------------------------------------------//
// 管理番号  11001634-00  作成担当 : 鄧潘ハン
// 作 成 日  K2014/05/26  修正内容 : 自動発注エラーメッセージを出さないように修正とエラーログの更新
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;
using System.Threading;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ＵＯＥ発注データアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ発注データアクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
    /// <br>Update Note  : 2009/05/25 96186 立花 裕輔</br>
    /// <br>              ・ホンダ UOE WEB対応</br>
    /// <br>Update Note: 2012/09/20 yangmj redmine#23404の対応</br>
    /// <br>Update Note: 2014/01/24 汪権来 Redmine#41551の対応 UOE消費税対応</br>
    /// <br>Update Note : K2014/05/26 鄧潘ハン</br>
    /// <br>              自動発注エラーメッセージを出さないように修正とエラーログの更新</br>
    /// </remarks>
	public partial class UOEOrderDtlAcs
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		public UOEOrderDtlAcs()
		{
            // ---- ADD 2013/08/15 譚洪 ---- >>>>>
            //OPT-CPM0110：フタバUOEオプション（個別）
            fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
            if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FuTaBa = (int)Option.ON;
            }
            else
            {
                this._opt_FuTaBa = (int)Option.OFF;
            }
            // ---- ADD 2013/08/15 譚洪 ---- <<<<<

            int status = 0;

			//企業コードを取得する
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			//ログイン拠点コード
			this._loginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

            //UOE発注データ・仕入明細データ更新リモートオブジェクト
            this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();

            //UOE発注データ リモートオブジェクト
            this._iIOWriteUOEOdrDtlDB = (IIOWriteUOEOdrDtlDB)MediationIOWriteUOEOdrDtlDB.GetIOWriteUOEOdrDtlDB();

            this._StockProcMoney = new StockInputInitialDataSet.StockProcMoneyDataTable();

            this._taxRateSetAcs = new TaxRateSetAcs();

            //-----------------------------------------------------------
            // 税率設定マスタ
            //-----------------------------------------------------------
            ArrayList returnTaxRateSet;
            TaxRateSetAcs.SearchMode taxRateSetSearchMode = (ctIsLocalDBRead) ? TaxRateSetAcs.SearchMode.Local : TaxRateSetAcs.SearchMode.Remote;
            status = _taxRateSetAcs.Search(out returnTaxRateSet, _enterpriseCode, taxRateSetSearchMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.CacheTaxRateSet((TaxRateSet)returnTaxRateSet[0]);
            }
            else
            {
                this._taxRateSet = null;
            }

            //-----------------------------------------------------------
            // 仕入金額処理区分設定マスタ
            //-----------------------------------------------------------
            _stockProcMoneyAcs = new StockProcMoneyAcs();

            ArrayList returnStockProcMoney;
            StockProcMoneyWork paraStockProcMoneyWork = new StockProcMoneyWork();
            paraStockProcMoneyWork.EnterpriseCode = _enterpriseCode;
            paraStockProcMoneyWork.FracProcMoneyDiv = -1;

            status = _stockProcMoneyAcs.Search(out returnStockProcMoney, _enterpriseCode);

            this._stockProcMoneyList = new List<StockProcMoney>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockProcMoney stockProcMoney in (ArrayList)returnStockProcMoney)
                {
                    this.CacheStockProcMoney(stockProcMoney);
                    this._stockProcMoneyList.Add(stockProcMoney.Clone());
                }
            }

            //-----------------------------------------------------------
            //仕入金額計算クラス
            //-----------------------------------------------------------
            _stockPriceCalculate = new StockPriceCalculate();
            _stockPriceCalculate.CacheStockProcMoneyList(_stockProcMoneyList);

            //-----------------------------------------------------------
            //売上金額計算クラス
            //-----------------------------------------------------------
            _salesPriceCalculate = new SalesPriceCalculate();
        }

        /// <summary>
        /// アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns></returns>
        public static UOEOrderDtlAcs GetInstance()
        {
            if (_uOEOrderDtlAcs == null)
            {
                _uOEOrderDtlAcs = new UOEOrderDtlAcs();
            }
            return _uOEOrderDtlAcs;
        }
        # endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
        //アクセスクラス インスタンス
        private static UOEOrderDtlAcs _uOEOrderDtlAcs = null;

		//企業コード
		private string _enterpriseCode = "";

		//ログイン拠点コード
		private string _loginSectionCd = "";

        //UOE発注データ・仕入明細データ更新リモート
        private IIOWriteControlDB _iIOWriteControlDB = null;

        //UOE発注データ リモートオブジェクト
        private IIOWriteUOEOdrDtlDB _iIOWriteUOEOdrDtlDB = null;

        // 税率 アクセスクラス
        private TaxRateSetAcs _taxRateSetAcs = null;

        //税率クラス
        private TaxRateSet _taxRateSet = null   ;

        //仕入金額処理区分アクセスクラス
        private StockProcMoneyAcs _stockProcMoneyAcs = null;

        private StockInputInitialDataSet.StockProcMoneyDataTable _StockProcMoney = null;

        //売上金額処理区分アクセスクラス
        //private SalesProcMoneyAcs _salesProcMoneyAcs = null;

        //仕入金額計算アクセスクラス
        private StockPriceCalculate _stockPriceCalculate = null;

        //売上金額計算アクセスクラス
        private SalesPriceCalculate _salesPriceCalculate = null;

        //仕入金額処理区分リスト
        private List<StockProcMoney> _stockProcMoneyList = null;

        //売上金額処理区分リスト
        //private List<SalesProcMoney> _salesProcMoneyList = null;

        // ---- 2013/08/15 譚洪 ---- >>>>>
        //Thread中、メッセージ関係
        private const string MSGSHOWSOLT = "MSGSHOWSOLT";
        private LocalDataStoreSlot msgShowSolt = null;

        #region ■列挙体
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効ユーザ</summary>
            OFF = 0,
            /// <summary>有効ユーザ</summary>
            ON = 1,
        }
        #endregion

        /// <summary>テキスト出力オプション情報</summary>
        private int _opt_FuTaBa;//OPT-CPM0110：フタバUOEオプション（個別）

        //専用USB用
        Broadleaf.Application.Remoting.ParamData.PurchaseStatus fuTaBaPs;
        // ---- 2013/08/15 譚洪 ---- <<<<<
        # endregion

		// ===================================================================================== //
		// 定数群
		// ===================================================================================== //
		#region Public Const Member

        /// <summary>端数処理対象金額区分（金額）</summary>
        public const int ctFracProcMoneyDiv_Price = 0;
        /// <summary>端数処理対象金額区分（消費税）</summary>
        public const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>端数処理対象金額区分（単価）</summary>
        public const int ctFracProcMoneyDiv_UnitPrice = 2;
        /// <summary>端数処理対象金額区分（原価単価）</summary>
        public const int ctFracProcMoneyDiv_UnitCost = 3;
        /// <summary>端数処理対象金額区分（原価）</summary>
        public const int ctFracProcMoneyDiv_Cost = 4;

        /// <summary>ローカルDB読み込みモード</summary>
        //public static readonly bool ctIsLocalDBRead = true;
        public static readonly bool ctIsLocalDBRead = false;

		// メッセージ
		private const string MESSAGE_NoResult = "条件に一致するデータは存在しません。";
        // private const string MESSAGE_ErrResult = "データの取得に失敗しました。";  //DEL pengjie 2013/03/14 REDMINE#34986
        private const string MESSAGE_ErrResult = "発注データの抽出が失敗しました。"; //ADD pengjie 2013/03/14 REDMINE#34986
		private const string MESSAGE_NotFound = "処理対象のデータが存在しません。";
        private const string OPENFLAG = "OPEN価格"; // ADD chenw 2013/03/07 Redmine#34989
        private const string MESSAGE_TimeOut = "ただ今処理が混み合っているため、しばらく後に再度実行してください。";   //ADD pengjie 2013/03/14 REDMINE#34986

		# endregion

		// ===================================================================================== //
		// デリゲート
		// ===================================================================================== //
		# region Delegate
		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Event
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
        # region 税率設定マスタオブジェクト取得
        /// <summary>
        /// 税率設定マスタオブジェクト取得
        /// </summary>
        /// <returns>税率設定マスタオブジェクト</returns>
        public TaxRateSet taxRateSet
        {
            get { return this._taxRateSet; }
            set { this._taxRateSet = value; }
        }
        # endregion

        # region 仕入金額処理区分設定リスト
        /// <summary>仕入金額処理区分設定リスト</summary>
        public List<StockProcMoney> StockProcMoneyList
        {
            get { return this._stockProcMoneyList; }
        }
        # endregion

        # region 仕入金額計算アクセスクラス
        /// <summary>仕入金額計算アクセスクラス</summary>
        public StockPriceCalculate stockPriceCalculate
        {
            get { return this._stockPriceCalculate; }
        }
        # endregion

        # region 売上金額計算アクセスクラス
        /// <summary>売上金額計算アクセスクラス</summary>
        public SalesPriceCalculate salesPriceCalculate

        {
            get { return this._salesPriceCalculate; }
        }
        # endregion
        # endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
        # region ■仕入金額処理区分設定マスタキャッシュ制御処理
        /// <summary>
        /// 仕入金額処理区分設定マスタキャッシュ処理
        /// </summary>
        /// <param name="stockProcMoney">仕入金額処理区分設定マスタワーククラス</param>
        internal void CacheStockProcMoney(StockProcMoney stockProcMoney)
        {
            try
            {
                _StockProcMoney.AddStockProcMoneyRow(this.RowFromUIData(stockProcMoney));
            }
            catch (ConstraintException)
            {
                StockInputInitialDataSet.StockProcMoneyRow row = this._StockProcMoney.FindByFracProcMoneyDivFractionProcCodeUpperLimitPrice(stockProcMoney.FracProcMoneyDiv, stockProcMoney.FractionProcCode, stockProcMoney.UpperLimitPrice);
                this.SetRowFromUIData(ref row, stockProcMoney);
            }
        }
        
        /// <summary>
        /// 仕入金額処理区分設定マスタワーククラスの取得
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="upperLimitPrice">上限金額</param>
        /// <returns></returns>
        public StockProcMoney GetStockProcMoney(int fracProcMoneyDiv, int fractionProcCode, double upperLimitPrice)
        {
            StockProcMoney stockProcMoney = null;

            try
            {
                StockInputInitialDataSet.StockProcMoneyRow row = this._StockProcMoney.FindByFracProcMoneyDivFractionProcCodeUpperLimitPrice(
                                                                    fracProcMoneyDiv,
                                                                    fractionProcCode,
                                                                    upperLimitPrice);
                stockProcMoney = GetStockProcMoneyFromRow(row);
            }
            catch (ConstraintException)
            {
                stockProcMoney = null;
            }

            return (stockProcMoney);
        }

        /// <summary>
        /// 仕入金額処理区分設定マスタオブジェクト→仕入金額処理区分設定マスタ行オブジェクト設定処理
        /// </summary>
        /// <param name="row">仕入金額処理区分設定マスタ行クラス</param>
        /// <param name="stockProcMoney">仕入金額処理区分設定マスタワーククラス</param>
        internal void SetRowFromUIData(ref StockInputInitialDataSet.StockProcMoneyRow row, StockProcMoney stockProcMoney)
        {
            // 端数処理対象金額区分
            row.FracProcMoneyDiv = stockProcMoney.FracProcMoneyDiv;

            // 端数処理コード
            row.FractionProcCode = stockProcMoney.FractionProcCode;

            // 上限金額
            row.UpperLimitPrice = stockProcMoney.UpperLimitPrice;

            // 端数処理単位
            row.FractionProcUnit = stockProcMoney.FractionProcUnit;

            // 端数処理区分
            row.FractionProcCd = stockProcMoney.FractionProcCd;
        }

        /// <summary>
        /// 仕入金額処理区分設定マスタワーククラスの取得
        /// </summary>
        /// <param name="row">仕入金額処理区分設定マスタ行クラス</param>
        /// <returns>仕入金額処理区分設定マスタワーククラス</returns>
        internal StockProcMoney GetStockProcMoneyFromRow(StockInputInitialDataSet.StockProcMoneyRow row)
        {

            StockProcMoney stockProcMoney = new StockProcMoney();

            if (row != null)
            {
                // 端数処理対象金額区分
                stockProcMoney.FracProcMoneyDiv = (int)row.FracProcMoneyDiv;

                // 端数処理コード
                stockProcMoney.FractionProcCode = (int)row.FractionProcCode;

                // 上限金額
                stockProcMoney.UpperLimitPrice = (double)row.UpperLimitPrice;

                // 端数処理単位
                stockProcMoney.FractionProcUnit = (double)row.FractionProcUnit;

                // 端数処理区分
                stockProcMoney.FractionProcCd = (int)row.FractionProcCd;
            }

            return (stockProcMoney);
        }

        /// <summary>
        /// 仕入金額処理区分設定マスタオブジェクト→仕入金額処理区分設定マスタ行オブジェクト変換処理
        /// </summary>
        /// <param name="stockProcMoney">仕入金額処理区分設定マスタオブジェクト</param>
        /// <returns>仕入金額処理区分設定マスタ行オブジェクト</returns>
        internal StockInputInitialDataSet.StockProcMoneyRow RowFromUIData(StockProcMoney stockProcMoney)
        {
            StockInputInitialDataSet.StockProcMoneyRow row = _StockProcMoney.NewStockProcMoneyRow();

            this.SetRowFromUIData(ref row, stockProcMoney);
            return row;
        }
        # endregion

        # region 仕入金額を計算します。
        /// <summary>
        /// 仕入金額を計算します。
        /// </summary>
        /// <param name="stockCount">仕入数</param>
        /// <param name="stockUnitPrice">仕入単価</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="stockMoneyFrcProcCd">仕入金額端数処理コード</param>
        /// <param name="taxFracProcCode">消費税端数処理区分</param>
        /// <param name="stockPriceTaxInc">仕入金額（税込み）</param>
        /// <param name="stockPriceTaxExc">仕入金額（税抜き）</param>
        /// <param name="stockPriceConsTax">仕入消費税</param>
        /// <returns></returns>
        public bool CalculationStockPrice(double stockCount, double stockUnitPrice, int taxationCode, int stockMoneyFrcProcCd, int taxFracProcCode, out long stockPriceTaxInc, out long stockPriceTaxExc, out long stockPriceConsTax)
        {
            double taxFracProcUnit;
            int taxFracProcCd;
            double taxRate = GetTaxRate(DateTime.Now);

            GetFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, taxFracProcCode, 0, out taxFracProcUnit, out taxFracProcCd);

            stockPriceTaxInc = 0;
            stockPriceTaxExc = 0;
            stockPriceConsTax = 0;

            // 仕入数が0または仕入単価が0の場合はすべて0で終了
            if ((stockCount == 0) || (stockUnitPrice == 0)) return true;

            // 外税の場合
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                double unitPriceExc = stockUnitPrice;     // 単価（税抜き）
                double unitPriceInc;　　　　　　　　　　　// 単価（税込み）
                double unitPriceTax;　　　　　　　　　　　// 単価（消費税）
                long priceExc = 0;　　　　　　　　　　　　// 価格（税抜き）
                long priceInc;　　　　　　　　　　　　　　// 価格（税込み）
                long priceTax;　　　　　　　　　　　　　　// 価格（消費税）

                this._stockPriceCalculate.CalcTaxIncFromTaxExc((int)CalculateTax.TaxationCode.TaxExc, stockCount, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceInc;			// 仕入金額（税込み）
                stockPriceTaxExc = priceExc;			// 仕入金額（税抜き）
                stockPriceConsTax = priceTax;			// 仕入消費税
            }
            // 内税の場合
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                double unitPriceExc;　　　　　　　　　　　　// 単価（税抜き）
                double unitPriceInc = stockUnitPrice;　　 　// 単価（税込み）
                double unitPriceTax;　　　　　　　　　　　　// 単価（消費税）
                long priceExc;　　　　　　　　　　　　　　　// 価格（税抜き）
                long priceInc = 0;　　　　　　　　　　　　　// 価格（税込み）
                long priceTax;　　　　　　　　　　　　　　　// 価格（消費税）

                this._stockPriceCalculate.CalcTaxExcFromTaxInc((int)CalculateTax.TaxationCode.TaxInc, stockCount, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceInc;		// 仕入金額（税込み）
                stockPriceTaxExc = priceExc;		// 仕入金額（税抜き）
                stockPriceConsTax = priceTax;		// 仕入消費税
            }
            // 非課税の場合
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
            {
                double unitPriceExc = stockUnitPrice;       // 単価（税抜き）
                double unitPriceInc;                        // 単価（税込み）
                double unitPriceTax;                        // 単価（消費税）
                long priceExc = 0;                          // 価格（税抜き）
                long priceInc;                              // 価格（税込み）
                long priceTax;                              // 価格（消費税）

                this._stockPriceCalculate.CalcTaxIncFromTaxExc((int)CalculateTax.TaxationCode.TaxNone, stockCount, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceExc;                // 仕入金額（税込み）
                stockPriceTaxExc = priceExc;                // 仕入金額（税込み）
                stockPriceConsTax = priceTax;               // 仕入消費税
            }

            return true;
        }
        #endregion

        #region 仕入金額処理区分設定マスタ データ取得処理関連
        /// <summary>
        /// 端数処理単位、端数処理区分取得処理
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// 
        public void GetFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //デフォルト
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_UnitPrice: // 単価は0.01円単位
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // 単価以外は1円単位
                    break;
            }
            fractionProcCd = 1;     // 切捨て

            // 端数処理対象金額区分、端数処理コードが一致するデータを昇順に取得
            DataRow[] dr = this._StockProcMoney.Select(string.Format("{0} = {1} AND {2} = {3}", this._StockProcMoney.FracProcMoneyDivColumn.ColumnName,
                                                                                                        fracProcMoneyDiv,
                                                                                                        this._StockProcMoney.FractionProcCodeColumn, fractionProcCode,
                                                                                                        fractionProcCode),
                                                               string.Format("{0} DESC", this._StockProcMoney.UpperLimitPriceColumn.ColumnName));

            foreach (StockInputInitialDataSet.StockProcMoneyRow stockProcMoneyRow in dr)
            {
                if (stockProcMoneyRow.UpperLimitPrice < targetPrice)
                {
                    break;
                }
                fractionProcUnit = stockProcMoneyRow.FractionProcUnit;
                fractionProcCd = stockProcMoneyRow.FractionProcCd;
            }
        }
        #endregion


        # region 税率設定マスタキャッシュ制御
        /// <summary>
        /// 税率設定マスタキャッシュ処理
        /// </summary>
        /// <param name="taxRateSet">税率設定マスタオブジェクト</param>
        internal void CacheTaxRateSet(TaxRateSet taxRateSet)
        {
            this._taxRateSet = taxRateSet;
        }

        /// <summary>
        /// 税率設定マスタオブジェクト取得
        /// </summary>
        /// <returns>税率設定マスタオブジェクト</returns>
        public TaxRateSet GetTaxRateSet()
        {
            return this._taxRateSet;
        }

        /// <summary>
        /// 税率設定マスタで登録されている消費税率を取得します。
        /// </summary>
        /// <param name="addUpDate">計上日</param>
        /// <returns>消費税率</returns>
        public double GetTaxRate(DateTime addUpDate)
        {
            return TaxRateSetAcs.GetTaxRate(this.GetTaxRateSet(), addUpDate);
        }

        /// <summary>
        /// 税率設定マスタに設定されている消費税名称を取得します。
        /// </summary>
        /// <returns>消費税表示名称</returns>
        public string GetTaxRateName()
        {
            string result = "";
            TaxRateSet taxRateSet = this.GetTaxRateSet();

            if (taxRateSet == null) return result;

            return taxRateSet.TaxRateName;
        }
        # endregion

        # region 仕入税込金額の取得(double)
        /// <summary>
        /// 仕入税込金額の取得(double)
        /// </summary>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="stockCnsTaxFrcProcCd">仕入消費税端数処理コード</param>
        /// <returns>税込み金額</returns>
        public double GetStockPriceTaxInc(double targetPrice, int taxationCode, int stockCnsTaxFrcProcCd)
        {
            double priceTaxExc = 0;     //税抜き金額
            double priceTaxInc = 0;     //税込み金額
            double priceConsTax = 0;    //消費税金額
            double taxFracProcUnit = 0; //消費税端数処理単位
            int taxFracProcCd = 0;      //消費税端数処理区分

            double taxRate = GetTaxRate(DateTime.Now);

            stockPriceCalculate.CalculatePrice(
                                        taxationCode,        //課税区分
                                        targetPrice,         //対象金額
                                        taxRate,             //税率
                                        stockCnsTaxFrcProcCd,//仕入消費税端数処理コード
                                        out priceTaxExc,     //税抜き金額
                                        out priceTaxInc,     //税込み金額
                                        out priceConsTax,    //消費税金額
                                        out taxFracProcUnit, //消費税端数処理単位
                                        out taxFracProcCd ); //消費税端数処理区分
            return(priceTaxInc);
        }
        #endregion

        # region 仕入税込金額の取得(long)
        /// <summary>
        /// 仕入税込金額の取得(long)
        /// </summary>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="stockCnsTaxFrcProcCd">仕入消費税端数処理コード</param>
        /// <returns>税込み金額</returns>
        public long GetStockPriceTaxInc(long targetPrice, int taxationCode, int stockCnsTaxFrcProcCd)
        {
            long priceTaxExc = 0;       //税抜き金額
            long priceTaxInc = 0;       //税込み金額
            long priceConsTax = 0;      //消費税金額
            double taxFracProcUnit = 0; //消費税端数処理単位
            int taxFracProcCd = 0;      //消費税端数処理区分

            double taxRate = GetTaxRate(DateTime.Now);
    
            stockPriceCalculate.CalculatePrice(
                                        taxationCode,        //課税区分
                                        targetPrice,         //対象金額
                                        taxRate,             //税率
                                        stockCnsTaxFrcProcCd,//仕入消費税端数処理コード
                                        out priceTaxExc,     //税抜き金額
                                        out priceTaxInc,     //税込み金額
                                        out priceConsTax,    //消費税金額
                                        out taxFracProcUnit, //消費税端数処理単位
                                        out taxFracProcCd ); //消費税端数処理区分
            return(priceTaxInc);
        }
        #endregion

        # region 売上税込金額の取得(double)
        /// <summary>
        /// 売上税込金額の取得(double)
        /// </summary>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="salesCnsTaxFrcProcCd">仕入消費税端数処理コード</param>
        /// <returns>税込み金額</returns>
        public double GetSalesPriceTaxInc(double targetPrice, int taxationCode, int salesCnsTaxFrcProcCd)
        {
            double priceTaxExc = 0;     //税抜き金額
            double priceTaxInc = 0;     //税込み金額
            double priceConsTax = 0;    //消費税金額
            double taxFracProcUnit = 0; //消費税端数処理単位
            int taxFracProcCd = 0;      //消費税端数処理区分

            double taxRate = GetTaxRate(DateTime.Now);

            salesPriceCalculate.CalculatePrice(
                                        taxationCode,        //課税区分
                                        targetPrice,         //対象金額
                                        taxRate,             //税率
                                        salesCnsTaxFrcProcCd,//売上消費税端数処理コード
                                        out priceTaxExc,     //税抜き金額
                                        out priceTaxInc,     //税込み金額
                                        out priceConsTax,    //消費税金額
                                        out taxFracProcUnit, //消費税端数処理単位
                                        out taxFracProcCd); //消費税端数処理区分
            return (priceTaxInc);
        }
        #endregion

        # region 売上税込金額の取得(long)
        /// <summary>
        /// 売上税込金額の取得(long)
        /// </summary>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="stockCnsTaxFrcProcCd">仕入消費税端数処理コード</param>
        /// <returns>税込み金額</returns>
        public long GetSalesPriceTaxInc(long targetPrice, int taxationCode, int salesCnsTaxFrcProcCd)
        {
            long priceTaxExc = 0;       //税抜き金額
            long priceTaxInc = 0;       //税込み金額
            long priceConsTax = 0;      //消費税金額
            double taxFracProcUnit = 0; //消費税端数処理単位
            int taxFracProcCd = 0;      //消費税端数処理区分

            double taxRate = GetTaxRate(DateTime.Now);

            stockPriceCalculate.CalculatePrice(
                                        taxationCode,        //課税区分
                                        targetPrice,         //対象金額
                                        taxRate,             //税率
                                        salesCnsTaxFrcProcCd,//売上消費税端数処理コード
                                        out priceTaxExc,     //税抜き金額
                                        out priceTaxInc,     //税込み金額
                                        out priceConsTax,    //消費税金額
                                        out taxFracProcUnit, //消費税端数処理単位
                                        out taxFracProcCd); //消費税端数処理区分
            return (priceTaxInc);
        }
        #endregion

        # region ＵＯＥ発注データ・仕入明細の作成処理
        /// <summary>
        /// ＵＯＥ発注データ・仕入明細の作成処理
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">ＵＯＥ発注ＷＯＲＫリスト</param>
        /// <param name="StockDetailWorkList">仕入明細ＷＯＲＫリスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int WriteUOEOrderDtl(
            ref List<UOEOrderDtlWork> uOEOrderDtlWorkList,
            ref List<StockDetailWork> stockDetailWorkList,
            out string message)
        {
            IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();
            List<SlipDetailAddInfoWork> slipDetailAddInfoWorkList = new List<SlipDetailAddInfoWork>();

            return (WriteUOEOrderDtl(
                ref iOWriteCtrlOptWork,
                ref slipDetailAddInfoWorkList,
                ref uOEOrderDtlWorkList,
                ref stockDetailWorkList,
                out message));
        }
		# endregion

        # region ＵＯＥ発注データ・仕入明細の作成処理
        /// <summary>
        /// ＵＯＥ発注データ・仕入明細の作成処理
        /// </summary>
        /// <param name="iOWriteCtrlOptWork">売上・仕入制御オプション</param>
        /// <param name="slipDetailAddInfoWorkList">伝票明細追加情報データリスト</param>
        /// <param name="uOEOrderDtlWorkList">ＵＯＥ発注ＷＯＲＫリスト</param>
        /// <param name="StockDetailWorkList">仕入明細ＷＯＲＫリスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int WriteUOEOrderDtl(
            ref IOWriteCtrlOptWork iOWriteCtrlOptWork,
            ref List<SlipDetailAddInfoWork> slipDetailAddInfoWorkList,
            ref List<UOEOrderDtlWork> uOEOrderDtlWorkList,
            ref List<StockDetailWork> stockDetailWorkList,
            out string message)
        {
            // ---- ADD 2013/08/15 譚洪 ---- >>>>>
            //フタバUSB専用である場合、Thread中、メッセージの値を取得
            if (this._opt_FuTaBa == (int)Option.ON)
            {
                msgShowSolt = Thread.GetNamedDataSlot(MSGSHOWSOLT);
            }
            // ---- ADD 2013/08/15 譚洪 ---- <<<<<
           
            # region 変数の初期化
			//変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";

            //戻り値の初期化

            //ArrayListの初期化
            ArrayList slipDetailAddInfoWorkArry = null;
            ArrayList uOEOrderDtlWorkArry = null;
            ArrayList stockDetailWorkArry = null;
            # endregion

			try
			{
                # region ＵＯＥ発注データリストより各種リストを取得
                status = GetOrderWorkFromUOEOrderDtl(
                    uOEOrderDtlWorkList,
                    stockDetailWorkList,
                    out uOEOrderDtlWorkArry,
                    out stockDetailWorkArry,
                    out slipDetailAddInfoWorkArry,
                    out message);

                if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return(status);
                }
                # endregion

                # region リモート処理のパラメータ設定
                //売上・仕入制御オプションの設定
                IOWriteCtrlOptWork iOWriteCtrlOptWorkClass = new IOWriteCtrlOptWork();

                iOWriteCtrlOptWorkClass.CtrlStartingPoint = 1;              //制御起点
                iOWriteCtrlOptWorkClass.AcpOdrrAddUpRemDiv = 0;             //受注データ計上残区分
                iOWriteCtrlOptWorkClass.ShipmAddUpRemDiv = 0;               //出荷データ計上残区分
                iOWriteCtrlOptWorkClass.RetGoodsStockEtyDiv = 0;            //返品時在庫登録区分
                iOWriteCtrlOptWorkClass.SupplierSlipDelDiv = 0;             //仕入伝票削除区分
                iOWriteCtrlOptWorkClass.RemainCntMngDiv = 0;                //残数管理区分
                iOWriteCtrlOptWorkClass.EnterpriseCode = _enterpriseCode;   //企業コード
                iOWriteCtrlOptWorkClass.CarMngDivCd = 0;                    //車両管理区分
                
                //リモート処理のパラメータ設定
                CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                CustomSerializeArrayList paraUoeDetailList = new CustomSerializeArrayList();
                CustomSerializeArrayList paraStockList = new CustomSerializeArrayList();

                object objUOEOrderDtlWorkList = (object)uOEOrderDtlWorkArry;
                object objStockDetailWorkList = (object)stockDetailWorkArry;
                object objIOWriteCtrlOptWorkClass = (object)iOWriteCtrlOptWorkClass;
                object objSlipDetailAddInfoWorkList = (object)slipDetailAddInfoWorkArry;


                paraUoeDetailList.Add(objUOEOrderDtlWorkList);
                paraList.Add(paraUoeDetailList);

                paraStockList.Add(objSlipDetailAddInfoWorkList);
                paraStockList.Add(objStockDetailWorkList);

                paraList.Add(paraStockList);
                paraList.Add(objIOWriteCtrlOptWorkClass);

                object objParaList = (object)paraList;
                # endregion

                # region リモート処理の呼び出し
                //リモート処理の呼び出し
                string retItemInfo = "";
                do
                {
                    status = _iIOWriteControlDB.Write(ref objParaList, out message, out retItemInfo);
                    if ((status == 850) || (status == 851) || (status == 852))
                    {
                        // ---- DEL 2013/08/15 譚洪 --- >>>>>
                        //TMsgDisp.Show(
                        //    //this,
                        //    emErrorLevel.ERR_LEVEL_STOP,
                        //    "",
                        //    "シェアチェックエラー（拠点ロック）です。\r"
                        //    + "締処理か、処理が込み合っているためタイムアウトしました。\r"
                        //    + "再試行するか、しばらく待ってから再度処理を行ってください。\r",
                        //    status,
                        //    MessageBoxButtons.OK);
                        // ---- DEL 2013/08/15 譚洪 --- <<<<<

                        // ---- ADD 2013/08/15 譚洪 --- >>>>>
                        //フタバ専用USBではない
                        //発注処理(手動)と発注処理(自動)ではない
                        //発注処理(手動)である場合
                        if (this._opt_FuTaBa == (int)Option.OFF 
                             || Thread.GetData(msgShowSolt) == null
                             || (Thread.GetData(msgShowSolt) != null && (Int32)Thread.GetData(msgShowSolt) == 2))
                        {
                            TMsgDisp.Show(
                                //this,
                                emErrorLevel.ERR_LEVEL_STOP,
                                "",
                                "シェアチェックエラー（拠点ロック）です。\r"
                                + "締処理か、処理が込み合っているためタイムアウトしました。\r"
                                + "再試行するか、しばらく待ってから再度処理を行ってください。\r",
                                status,
                                MessageBoxButtons.OK);
                        }
                        else
                        {

                            message = "シェアチェックエラー（拠点ロック）です。\r\n"
                            + "締処理か、処理が込み合っているためタイムアウトしました。\r";

                            return (status);
                        }
                        // ---- ADD 2013/08/15 譚洪 --- <<<<<


                    }
                } while ((status == 850) || (status == 851) || (status == 852));

                if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return(status);
                }
                # endregion

                # region 戻り値の設定
                //戻り値の設定
                iOWriteCtrlOptWork = new IOWriteCtrlOptWork();
                slipDetailAddInfoWorkList = new List<SlipDetailAddInfoWork>();
                uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
                stockDetailWorkList = new List<StockDetailWork>();

                CustomSerializeArrayListForAfterWrite(
                    objParaList,
                    ref iOWriteCtrlOptWork,
                    ref slipDetailAddInfoWorkList,
                    ref uOEOrderDtlWorkList,
                    ref stockDetailWorkList);
                # endregion
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
        }
        # endregion

        # region ＵＯＥ発注回答更新処理
        /// <summary>
        /// ＵＯＥ発注回答更新処理
        /// </summary>
        /// <param name="stockSlipGrpList">ＵＯＥ回答情報確定用 仕入ヘッダ・明細情報定義</param>
        /// <param name="uOEOrderDtlWorkList">ＵＯＥ発注データ定義リスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int Write(ref List<StockSlipGrp> stockSlipGrpList, ref List<UOEOrderDtlWork> uOEOrderDtlWorkList, out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
				//パラメータクラス作成
                CustomSerializeArrayList csAry = ToCustomSerializeFromStockSlipGrpList(stockSlipGrpList, uOEOrderDtlWorkList);
				object setObj = (object)csAry;

                do
                {
                    status = this._iIOWriteUOEOdrDtlDB.OrderFixation(ref setObj);
                    if ((status == 850) || (status == 851) || (status == 852))
                    {

                        // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                        //TMsgDisp.Show(
                        //    //this,
                        //    emErrorLevel.ERR_LEVEL_STOP,
                        //    "",
                        //    "シェアチェックエラー（拠点ロック）です。\r"
                        //    + "締処理か、処理が込み合っているためタイムアウトしました。\r"
                        //    + "再試行するか、しばらく待ってから再度処理を行ってください。\r",
                        //    status,
                        //    MessageBoxButtons.OK);
                        // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<

                        // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                        //フタバ専用USBではない
                        //発注処理(手動)と発注処理(自動)ではない
                        //発注処理(手動)である場合
                        if (this._opt_FuTaBa == (int)Option.OFF
                             || Thread.GetData(msgShowSolt) == null
                             || (Thread.GetData(msgShowSolt) != null && (Int32)Thread.GetData(msgShowSolt) == 2))
                        {
                        TMsgDisp.Show(
                            //this,
                            emErrorLevel.ERR_LEVEL_STOP,
                            "",
                            "シェアチェックエラー（拠点ロック）です。\r"
                            + "締処理か、処理が込み合っているためタイムアウトしました。\r"
                            + "再試行するか、しばらく待ってから再度処理を行ってください。\r",
                            status,
                            MessageBoxButtons.OK);
                    }
                        else
                        {

                            message = "シェアチェックエラー（拠点ロック）です。\r\n"
                            + "締処理か、処理が込み合っているためタイムアウトしました。\r";

                            return (status);
                        }
                        // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<


                    }
                } while ((status == 850) || (status == 851) || (status == 852));

				if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (setObj is ArrayList))
				{
                    DivisionCustomSerializeArrayList((CustomSerializeArrayList)setObj, ref stockSlipGrpList, ref uOEOrderDtlWorkList);
				}
				else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
						 (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
				{
					message = MESSAGE_NoResult;
				}
				else
				{
					message = MESSAGE_NoResult;
				}
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

        # region ＵＯＥ発注データの検索処理
        /// <summary>
        /// ＵＯＥ発注データの検索処理
        /// </summary>
        /// <param name="para">検索パラメータ</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注ワーク</param>
        /// <param name="stockDetailWorkList">仕入明細ワーク</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int Search(UOESendProcCndtnPara para, out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList, out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
            uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            stockDetailWorkList = new List<StockDetailWork>();
			message = "";

			try
			{
                UOESendProcCndtnWork uOESendProcCndtnWork = ToUOESendProcCndtnWorkFromPara(para);

                ArrayList uOEOrderDtlWorkAry = new ArrayList(); 
                ArrayList stockDetailWorkAry = new ArrayList();

                object uOESendProcCndtnWorkObj = uOESendProcCndtnWork;
                object uOEOrderDtlWorkAryObj = uOEOrderDtlWorkAry;
                object stockDetailWorkAryObj = stockDetailWorkAry;

                status = this._iIOWriteUOEOdrDtlDB.Search(  uOESendProcCndtnWorkObj,
                                                            ref uOEOrderDtlWorkAryObj,
                                                            ref stockDetailWorkAryObj,
                                                            0,
                                                            ConstantManagement.LogicalMode.GetData0);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (uOEOrderDtlWorkAryObj is ArrayList)
                && (stockDetailWorkAryObj is ArrayList))
				{
					ArrayList retUOEOrderDtlWorkAry = (ArrayList)uOEOrderDtlWorkAryObj;
                    ArrayList retStockDetailWorkAry = (ArrayList)stockDetailWorkAryObj;

                    uOEOrderDtlWorkList.AddRange((UOEOrderDtlWork[])retUOEOrderDtlWorkAry.ToArray(typeof(UOEOrderDtlWork)));
                    stockDetailWorkList.AddRange((StockDetailWork[])retStockDetailWorkAry.ToArray(typeof(StockDetailWork)));
				}
				else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
						 (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
				{
					message = MESSAGE_NoResult;
                    uOEOrderDtlWorkList = null;
                    stockDetailWorkList = null;
                }
                //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT || status == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
                {
                    message = MESSAGE_TimeOut;
                }
                //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<
				else
				{
					message = MESSAGE_NoResult;
				}
			}
            //catch (Exception ex)// DEL pengjie 2013/03/14 REDMINE#34986
            catch (Exception)// ADD pengjie 2013/03/14 REDMINE#34986
			{
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
				status = -1;
                // message = ex.Message;  // DEL pengjie 2013/03/14 REDMINE#34986
                message = MESSAGE_ErrResult + "ST=" + status; // ADD pengjie 2013/03/14 REDMINE#34986
			}
			return (status);
		}
		# endregion

		# region ＵＯＥ発注データの削除処理
		/// <summary>
		/// ＵＯＥ発注データの削除処理
		/// </summary>
		/// <param name="list">ＵＯＥ発注データ</param>
		/// <param name="message">メッセージ</param>
		/// <returns></returns>
		public int Delete(List<UOEOrderDtlWork> list, out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
				if (list == null)
				{
					message = MESSAGE_NotFound;
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					return (status);
				}
				if (list.Count == 0)
				{
					message = MESSAGE_NotFound;
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					return (status);
				}

                //パラメータの設定
                ArrayList registList = new ArrayList();
                registList.AddRange(list);
				object uoeOrderDtlList = (object)registList;

                status = this._iIOWriteUOEOdrDtlDB.LogicalDelete(ref uoeOrderDtlList);
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
        # region ＵＯＥ発注確定用パラメーター作成
        /// <summary>
        /// ＵＯＥ発注確定用パラメーター作成
        /// </summary>
        /// <param name="stockSlipGrpList">ＵＯＥ回答情報確定用 仕入ヘッダ・明細情報定義</param>
        /// <param name="uOEOrderDtlWorkList">ＵＯＥ発注データ定義リスト</param>
        /// <returns>ＵＯＥ発注確定用パラメーター</returns>
        private CustomSerializeArrayList ToCustomSerializeFromStockSlipGrpList(List<StockSlipGrp> stockSlipGrpList, List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            //------------------------------------------------------------------------------------
            // csAry構成
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            統合リスト
            //      --ArrayList                     UOE発注データリスト
            //          --UOEOrderDtlWork           UOE発注データ
            //      --CustomSerializeArrayList      仕入データリスト
            //          --StockSlipWork             仕入ヘッダクラス
            //          --ArrayList                 仕入明細リスト
            //              --StockDetailWork       仕入明細クラス
            //------------------------------------------------------------------------------------
            CustomSerializeArrayList csAry = new CustomSerializeArrayList();

            try
            {
                // 2009/05/25 START >>>>>>
                ////UOE発注データ格納処理
                //ArrayList uOEOrderDtlWorkAry = new ArrayList();
                //uOEOrderDtlWorkAry.AddRange(uOEOrderDtlWorkList);
                //
                ////CustomSerializeArrayListへ設定
                //csAry.Add(uOEOrderDtlWorkAry);

                if ((uOEOrderDtlWorkList == null)
                || (uOEOrderDtlWorkList.Count == 0))
                {
                }
                else
                {
                    //UOE発注データ格納処理
                    ArrayList uOEOrderDtlWorkAry = new ArrayList();
                    uOEOrderDtlWorkAry.AddRange(uOEOrderDtlWorkList);

                    //CustomSerializeArrayListへ設定
                    csAry.Add(uOEOrderDtlWorkAry);
                }
                // 2009/05/25 END   <<<<<<

                //仕入情報格納処理
                foreach (StockSlipGrp stockSlipGrp in stockSlipGrpList)
                {
                    CustomSerializeArrayList stockGrpAry = new CustomSerializeArrayList();

                    //仕入ヘッダクラス
                    stockGrpAry.Add(stockSlipGrp.stockSlipWork);

                    //仕入明細クラス
                    ArrayList dtl = new ArrayList();
                    dtl.AddRange(stockSlipGrp.stockDetailWorkList);
                    stockGrpAry.Add(dtl);

                    //CustomSerializeArrayListへ設定
                    csAry.Add(stockGrpAry);
                }

            }
            catch (Exception)
            {
                csAry = null;
            }
            return (csAry);
        }
        # endregion

        # region CustomSerializeArrayListを各種データオブジェクトへ分割
        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトへ分割
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="stockSlipGrpList">ＵＯＥ回答情報確定用 仕入ヘッダ・明細情報定義</param>
        /// <param name="uOEOrderDtlWorkList">ＵＯＥ発注データ定義リスト</param>
        private void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, ref List<StockSlipGrp> stockSlipGrpList, ref List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            List<UOEOrderDtlWork> returnUOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            List<StockSlipGrp> returnStockSlipGrpList = new List<StockSlipGrp>();

            try
            {
                //------------------------------------------------------------------------------------
                // csAry構成
                //------------------------------------------------------------------------------------
                //  CustomSerializeArrayList            統合リスト
                //      --ArrayList                     UOE発注データリスト
                //          --UOEOrderDtlWork           UOE発注データ
                //      --CustomSerializeArrayList      仕入データリスト
                //          --StockSlipWork             仕入ヘッダクラス
                //          --ArrayList                 仕入明細リスト
                //              --StockDetailWork       仕入明細クラス
                //------------------------------------------------------------------------------------


                for (int i = 0; i < paraList.Count; i++)
                {
                    if (paraList[i] is ArrayList)
                    {
                        ArrayList list = (ArrayList)paraList[i];
                        if (list.Count == 0) continue;

                        //UOE発注データ
                        if (list[0] is UOEOrderDtlWork)
                        {
                            foreach (UOEOrderDtlWork work in list)
                            {
                                returnUOEOrderDtlWorkList.Add(work);
                            }
                        }
                        //仕入情報
                        else if((list[0] is ArrayList) || (list[0] is StockSlipWork))
                        {
                            StockSlipGrp stockSlipGrp = new StockSlipGrp();
                            for (int j = 0; j < list.Count; j++)
                            {
                                //仕入ヘッダー
                                if (list[j] is StockSlipWork)
                                {
                                    stockSlipGrp.stockSlipWork = (StockSlipWork)list[j];
                                }
                                //仕入明細
                                else if (list[j] is ArrayList)
                                {
                                    ArrayList dtlList = (ArrayList)list[j];
                                    if (dtlList[0] is StockDetailWork)
                                    {
                                        foreach (StockDetailWork work in dtlList)
                                        {
                                            stockSlipGrp.stockDetailWorkList.Add(work);
                                        }
                                    }
                                }
                            }
                            returnStockSlipGrpList.Add(stockSlipGrp);
                        }
                    }
                }
            }
            catch (Exception)
            {
                returnStockSlipGrpList = null;
                returnUOEOrderDtlWorkList = null;
            }

            //戻り値設定
            stockSlipGrpList = returnStockSlipGrpList;
            uOEOrderDtlWorkList = returnUOEOrderDtlWorkList;
        }
        # endregion

        # region UOE発注データ抽出条件変換(para→Work)
        /// <summary>
        /// UOE発注データ抽出条件変換(para→Work)
        /// </summary>
        /// <param name="para">UOE発注データ抽出条件パラメータ</param>
        /// <returns>UOE発注データ抽出条件Work</returns>
        /// <br>Update Note: 2012/09/20 yangmj redmine#23404の対応</br>
        private UOESendProcCndtnWork ToUOESendProcCndtnWorkFromPara(UOESendProcCndtnPara para)
        {
            UOESendProcCndtnWork returnUOESendProcCndtnWork = new UOESendProcCndtnWork();

   			try
			{
                returnUOESendProcCndtnWork.CashRegisterNo = para.CashRegisterNo;
                returnUOESendProcCndtnWork.CustomerCode = para.CustomerCode;
                returnUOESendProcCndtnWork.EnterpriseCode = para.EnterpriseCode;
                returnUOESendProcCndtnWork.St_InputDay = para.St_InputDay;
                returnUOESendProcCndtnWork.Ed_InputDay = para.Ed_InputDay;
                returnUOESendProcCndtnWork.SystemDivCd = para.SystemDivCd;
                returnUOESendProcCndtnWork.St_UOESalesOrderNo = para.St_UOESalesOrderNo;
                returnUOESendProcCndtnWork.Ed_UOESalesOrderNo = para.Ed_UOESalesOrderNo;
                returnUOESendProcCndtnWork.UOESupplierCd = para.UOESupplierCd;
                returnUOESendProcCndtnWork.St_OnlineNo = para.St_OnlineNo;
                returnUOESendProcCndtnWork.Ed_OnlineNo = para.Ed_OnlineNo;
                returnUOESendProcCndtnWork.DataSendCodes = para.DataSendCodes;
                //-----ADD YANGMJ 2012/09/20 REDMINE#32404 ----->>>>>
                returnUOESendProcCndtnWork.SectionCode = para.SectionCode;
                //-----ADD YANGMJ 2012/09/20 REDMINE#32404 -----<<<<<
			}
			catch (Exception)
			{
                returnUOESendProcCndtnWork = new UOESendProcCndtnWork();;
			}
			return (returnUOESendProcCndtnWork);
        }
		# endregion

        # region ＵＯＥ発注データリストよりＵＯＥ発注ＷＯＲＫリスト・仕入明細ＷＯＲＫリストを取得
        /// <summary>
        /// ＵＯＥ発注データリストよりＵＯＥ発注ＷＯＲＫリスト・仕入明細ＷＯＲＫリストを取得
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">ＵＯＥ発注ＷＯＲＫリスト</param>
        /// <param name="stockDetailWorkList">仕入明細ＷＯＲＫリスト</param>
        /// <param name="uOEOrderDtlWorkArry">ＵＯＥ発注ＷＯＲＫリスト</param>
        /// <param name="stockDetailWorkArry">仕入明細ＷＯＲＫリスト</param>
        /// <param name="slipDetailAddInfoWorkArry">伝票明細追加情報データリスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int GetOrderWorkFromUOEOrderDtl(List<UOEOrderDtlWork> uOEOrderDtlWorkList,
                                                List<StockDetailWork> stockDetailWorkList,
                                                out ArrayList uOEOrderDtlWorkArry,
                                                out ArrayList stockDetailWorkArry,
                                                out ArrayList slipDetailAddInfoWorkArry,
                                                out string message)
        {
            # region 変数の初期化
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            uOEOrderDtlWorkArry = null;
            stockDetailWorkArry = null;
            slipDetailAddInfoWorkArry = null;
            message = "";

            ArrayList returnUOEOrderDtlWorkArry = new ArrayList();
            ArrayList returnStockDetailWorkArry = new ArrayList();
            ArrayList returnSlipDetailAddInfoWorkArry = new ArrayList();

            //SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();  // DEL 2011/10/27
            int slipDtlRegOrder = 0;    //伝票・明細の登録順位を設定  // ADD 2011/10/27
            #endregion

            try
            {
                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    //Guid値取得
                    Guid guid = Guid.NewGuid();

                    # region ＵＯＥ発注データよりＵＯＥ発注ＷＯＲＫを取得
                    //ＵＯＥ発注データよりＵＯＥ発注ＷＯＲＫを取得
                    UOEOrderDtlWork uOEOrderDtlWork = uOEOrderDtlWorkList[i];
                    uOEOrderDtlWork.DtlRelationGuid = guid;
                    #endregion

                    # region ＵＯＥ発注データより仕入明細ＷＯＲＫを取得
                    //ＵＯＥ発注データより仕入明細ＷＯＲＫを取得
                    StockDetailWork stockDetailWork = stockDetailWorkList[i];
                    stockDetailWork.DtlRelationGuid = guid;
                    //--- ADD chenw 2013/03/07 Redmine#34989　--------->>>>>
                    if (OPENFLAG.Equals(uOEOrderDtlWork.LineErrorMassage.Trim()))
                    {
                        stockDetailWork.OpenPriceDiv = 1;
                    }
                    //--- ADD chenw 2013/03/07 Redmine#34989　---------<<<<<
                    #endregion

                    # region 伝票明細追加情報データ設定
                    SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();  // ADD 2011/10/27
                    //伝票明細追加情報データ
                    slipDetailAddInfoWork.DtlRelationGuid = guid;               //明細関連付けGUID
                    slipDetailAddInfoWork.GoodsEntryDiv = 0;                    //商品登録区分
                    slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;   //商品提供日付
                    slipDetailAddInfoWork.PriceUpdateDiv = 0;                   //価格更新区分
                    slipDetailAddInfoWork.PriceStartDate = DateTime.MinValue;   //価格開始日付
                    slipDetailAddInfoWork.PriceOfferDate = DateTime.MinValue;   //価格提供日付
                    slipDetailAddInfoWork.CarRelationGuid = Guid.Empty;         //車両関連付けGUID
                    // -- ADD 2011/10/27 ------------------------>>>
                    slipDtlRegOrder++;
                    slipDetailAddInfoWork.SlipDtlRegOrder = slipDtlRegOrder;    //伝票登録優先順位
                    // -- ADD 2011/10/27 ------------------------<<<
                    #endregion

                    # region リスト追加処理
                    //リスト追加処理
                    returnUOEOrderDtlWorkArry.Add(uOEOrderDtlWork);
                    returnStockDetailWorkArry.Add(stockDetailWork);
                    returnSlipDetailAddInfoWorkArry.Add(slipDetailAddInfoWork);
                    #endregion
                }

                //結果の格納
                uOEOrderDtlWorkArry = returnUOEOrderDtlWorkArry;
                stockDetailWorkArry  = returnStockDetailWorkArry;
                slipDetailAddInfoWorkArry = returnSlipDetailAddInfoWorkArry;
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }

		# endregion

        #region カスタムシリアライズアレイリスト分割処理
        /// <summary>
        /// カスタムシリアライズアレイリスト分割処理
        /// </summary>
        /// <param name="paraList">カスタムシリアライズアレイリスト</param>
        /// <param name="iOWriteCtrlOptWork">売上・仕入制御オプション</param>
        /// <param name="slipDetailAddInfoWorkList">伝票明細追加情報データリスト</param>
        /// <param name="uOEOrderDtlWorkList">ＵＯＥ発注ＷＯＲＫリスト</param>
        /// <param name="stockDetailWorkList">仕入明細ＷＯＲＫリスト</param>
        private void CustomSerializeArrayListForAfterWrite(object paraList,
            ref IOWriteCtrlOptWork iOWriteCtrlOptWork,
            ref List<SlipDetailAddInfoWork> slipDetailAddInfoWorkList,
            ref List<UOEOrderDtlWork> uOEOrderDtlWorkList,
            ref List<StockDetailWork> stockDetailWorkList)
        {
            foreach (object tempObj in (CustomSerializeArrayList)paraList)
            {
                if (tempObj is IOWriteCtrlOptWork)
                {
                    # region 売上・仕入制御オプション
                    //売上・仕入制御オプション
                    iOWriteCtrlOptWork = (IOWriteCtrlOptWork)tempObj;
                    # endregion
                }
                else if(tempObj is ArrayList)
                {
                    ArrayList tempAry = (ArrayList)tempObj;
                    if(tempAry.Count == 0)  continue;

                    foreach(object tempObj2 in tempAry)
                    {
                        if(tempObj2 is ArrayList)
                        {
                            ArrayList tempAry2 = (ArrayList)tempObj2;

                            if(tempAry2[0] is SlipDetailAddInfoWork)
                            {
                                # region 伝票明細追加情報データリスト
                                //伝票明細追加情報データリスト
                                foreach(SlipDetailAddInfoWork work in tempAry2)
                                {
                                    slipDetailAddInfoWorkList.Add(work);
                                }
                                # endregion
                            }
                            else if(tempAry2[0] is UOEOrderDtlWork)
                            {
                                # region ＵＯＥ発注ＷＯＲＫリスト
                                //ＵＯＥ発注ＷＯＲＫリスト
                                foreach (UOEOrderDtlWork work in tempAry2)
                                {
                                    uOEOrderDtlWorkList.Add(work);
                                }
                                # endregion
                            }
                            else if(tempAry2[0] is StockDetailWork)
                            {
                                # region 仕入明細ＷＯＲＫリスト
                                //仕入明細ＷＯＲＫリスト
                                foreach (StockDetailWork work in tempAry2)
                                {
                                    stockDetailWorkList.Add(work);
                                }
                                # endregion
                            }
                        }

                    }
                }
            }
        }
        # endregion
        # endregion

        // --------- ADD 汪権来 2014/01/24 for Redmine#41551 -------------- >>>>>>>
        # region 仕入税込金額の取得(double)

        /// <summary>
        /// 仕入税込金額の取得(double)
        /// </summary>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="stockCnsTaxFrcProcCd">仕入消費税端数処理コード</param>
        /// <param name="stockDate">仕入日</param>
        /// <returns>税込み金額</returns>
        public double GetStockPriceTaxInc(double targetPrice, int taxationCode, int stockCnsTaxFrcProcCd, DateTime stockDate)
        {

            double priceTaxExc = 0;     //税抜き金額
            double priceTaxInc = 0;     //税込み金額
            double priceConsTax = 0;    //消費税金額
            double taxFracProcUnit = 0; //消費税端数処理単位
            int taxFracProcCd = 0;      //消費税端数処理区分

            double taxRate = GetTaxRate(stockDate);

            stockPriceCalculate.CalculatePrice(
                                        taxationCode,        //課税区分
                                        targetPrice,         //対象金額
                                        taxRate,             //税率
                                        stockCnsTaxFrcProcCd,//仕入消費税端数処理コード
                                        out priceTaxExc,     //税抜き金額
                                        out priceTaxInc,     //税込み金額
                                        out priceConsTax,    //消費税金額
                                        out taxFracProcUnit, //消費税端数処理単位
                                        out taxFracProcCd); //消費税端数処理区分

            return (priceTaxInc);

        }

        #endregion

        # region 仕入金額を計算します。
        /// <summary>
        /// 仕入金額を計算します。
        /// </summary>
        /// <param name="stockCount">仕入数</param>
        /// <param name="stockUnitPrice">仕入単価</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="stockMoneyFrcProcCd">仕入金額端数処理コード</param>
        /// <param name="taxFracProcCode">消費税端数処理区分</param>
        /// <param name="stockDate">仕入日</param>
        /// <param name="stockPriceTaxInc">仕入金額（税込み）</param>
        /// <param name="stockPriceTaxExc">仕入金額（税抜き）</param>
        /// <param name="stockPriceConsTax">仕入消費税</param>
        /// <returns></returns>
        public bool CalculationStockPrice(double stockCount, double stockUnitPrice, int taxationCode, int stockMoneyFrcProcCd, int taxFracProcCode, DateTime stockDate, out long stockPriceTaxInc, out long stockPriceTaxExc, out long stockPriceConsTax)
        {

            double taxFracProcUnit;
            int taxFracProcCd;
            double taxRate = GetTaxRate(stockDate);
            GetFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, taxFracProcCode, 0, out taxFracProcUnit, out taxFracProcCd);

            stockPriceTaxInc = 0;
            stockPriceTaxExc = 0;
            stockPriceConsTax = 0;

            // 仕入数がまたは仕入単価がの場合はすべてで終了
            if ((stockCount == 0) || (stockUnitPrice == 0)) return true;

            // 外税の場合
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                double unitPriceExc = stockUnitPrice;     // 単価（税抜き）
                double unitPriceInc;　　　　　　　　　　　// 単価（税込み）
                double unitPriceTax;　　　　　　　　　　　// 単価（消費税）
                long priceExc = 0;　　　　　　　　　　　　// 価格（税抜き）
                long priceInc;　　　　　　　　　　　　　　// 価格（税込み）
                long priceTax;　　　　　　　　　　　　　　// 価格（消費税）

                this._stockPriceCalculate.CalcTaxIncFromTaxExc((int)CalculateTax.TaxationCode.TaxExc, stockCount, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceInc;                    // 仕入金額（税込み）
                stockPriceTaxExc = priceExc;                    // 仕入金額（税抜き）
                stockPriceConsTax = priceTax;                   // 仕入消費税

            }
            // 内税の場合
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                double unitPriceExc;　　　　　　　　　　　　// 単価（税抜き）
                double unitPriceInc = stockUnitPrice;　　　// 単価（税込み）
                double unitPriceTax;　　　　　　　　　　　　// 単価（消費税）
                long priceExc;　　　　　　　　　　　　　　　// 価格（税抜き）
                long priceInc = 0;　　　　　　　　　　　　　// 価格（税込み）
                long priceTax;　　　　　　　　　　　　　　　// 価格（消費税）

                this._stockPriceCalculate.CalcTaxExcFromTaxInc((int)CalculateTax.TaxationCode.TaxInc, stockCount, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceInc;            // 仕入金額（税込み）
                stockPriceTaxExc = priceExc;            // 仕入金額（税抜き）
                stockPriceConsTax = priceTax;           // 仕入消費税
            }
            // 非課税の場合
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
            {
                double unitPriceExc = stockUnitPrice;       // 単価（税抜き）
                double unitPriceInc;                        // 単価（税込み）
                double unitPriceTax;                        // 単価（消費税）
                long priceExc = 0;                          // 価格（税抜き）
                long priceInc;                              // 価格（税込み）
                long priceTax;                              // 価格（消費税）

                this._stockPriceCalculate.CalcTaxIncFromTaxExc((int)CalculateTax.TaxationCode.TaxNone, stockCount, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceExc;                // 仕入金額（税込み）
                stockPriceTaxExc = priceExc;                // 仕入金額（税込み）
                stockPriceConsTax = priceTax;               // 仕入消費税

            }
            return true;

        }

        #endregion
        // --------- ADD 汪権来 2014/01/24 for Redmine#41551 -------------- <<<<<<
    }
}
