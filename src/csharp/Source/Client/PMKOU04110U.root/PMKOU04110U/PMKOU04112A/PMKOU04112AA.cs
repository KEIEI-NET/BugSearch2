//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入年間実績照会
// プログラム概要   : 仕入年間実績照会アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30418 徳永
// 作 成 日  2008/12/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 修 正 日  2009/01/30  修正内容 : 障害対応10714（検索処理時、残高照会の前回検索データをクリアする処理を追加）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 修 正 日  2009/02/02  修正内容 : 障害対応10701（返品額、値引額はプラス表示するように修正）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2009/02/12  修正内容 : 障害対応11087
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/06/17  修正内容 : MANTIS【13397】システム日付によって対象年度の実績が異なるのを修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 杜志剛
// 修 正 日  2010/07/20  修正内容 : テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liyp
// 修 正 日  2011/03/23  修正内容 : テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI今野 利裕
// 作 成 日  2012/09/18  修正内容 : 仕入先総括対応
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using System.Collections.Generic;
// --- ADD 2012/09/18 ---------->>>>>
using Broadleaf.Application.Resources;
// --- ADD 2012/09/18 ----------<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 仕入先年間実績照会アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先年間実績照会のアクセスクラスです。</br>
    /// <br>Programmer : 30418 徳永</br>
    /// <br>Date       : 2008.12.11</br>
    /// <br>Update Note: 2009.01.30 30452 上野 俊治</br>
    /// <br>            ・障害対応10714（検索処理時、残高照会の前回検索データをクリアする処理を追加）</br>
    /// <br>Update Note: 2009.02.02 30452 上野 俊治</br>
    /// <br>            ・障害対応10701（返品額、値引額はプラス表示するように修正）</br>
    /// <br>Update Note: 2009.02.12 30414 忍 幸史</br>
    /// <br>            ・障害対応11087</br>
    /// <br>Update Note: 2010.07.20 30414 杜志剛</br>
    /// <br>            ・テキスト出力対応</br>
    /// <br>Update Note: 2011/03/23 liyp</br>
    /// <br>            ・テキスト出力対応</br>
    /// <br>Update Note: 2012/09/18 FSI今野 利裕</br>
    /// <br>             仕入先総括対応</br>
    /// </remarks>
    public partial class SuppYearResultAcs
    {

        #region プライベート変数

        /// <summary>仕入先年間実績照会 リモートDB取得用Mediateクラス</summary>
        ISuppYearResultDB _iSuppYearResultDB;

        /// <summary>仕入先年間実績照会 データセット</summary>
        private InventoryUpdateDataSet _dataSet;

        /// <summary>自社設定取得 アクセスクラス</summary>
        private CompanyInfAcs _companyInfAcs;

        /// <summary>自社設定取得 データクラス</summary>
        private CompanyInf _companyInf;

        /// <summary>日付取得 アクセスクラス</summary>
        private DateGetAcs _dateGetAcs;

        /// <summary>SFUKK09042A)金種データ取得 アクセスクラス</summary>
        private MoneyKindAcs _moneyKindAcs;

        ///// <summary>SFUKK09041E)金種データ取得 データクラス</summary>
        //private MoneyKind _moneyKind; // DEL 2009/01/30

        /// <summary>DCKHN01060C)仕入金額計算クラス</summary>
        private StockPriceCalculate _stockCalculator;

        /// <summary>期首年月日</summary>
        private DateTime _companyBeginDate;

        /// <summary>当期開始年月</summary>
        private DateTime _this_YearMonth;

        /// <summary>現在処理年月</summary>
        private DateTime _addUpYearMonth;

        //private DateTime _companyEndDate;

        /// <summary>現在処理年月</summary>
        //private DateTime _companyNowDate;

        /// <summary>平均で使用する月数</summary>
        private int _monthCount = 0;

        /// <summary>仕入金額端数処理コード（金額の丸めに必要）UIから渡される</summary>
        private int _stockPriceFrcProcCd = 0;

        /// <summary>DCKON09102A)仕入金額処理区分マスタ アクセスクラス</summary>
        StockProcMoneyAcs _stockProcMoneyAcs;

        private bool _excOrtxtDiv = false;                      // テキスト出力orExcel出力区分  // ADD 2011/03/23

        ///// <summary>DCKON09101E)仕入金額処理区分マスタ データクラス</summary>
        //StockProcMoney _stockProcMoney; // DEL 2009/01/30

        // ADD 2009/06/17 ------>>>
        // 締日算出モジュール
        TotalDayCalculator _totalDayCalculator;
        // ADD 2009/06/17 ------<<<

        // --- ADD 2012/09/18 ---------->>>>>
        // 仕入先総括のオプションコード利用可否設定用フラグ
        // true → 仕入先総括使用する。 false → 仕入先総括使用しない。
        private bool _optSuppSumEnable = false;
        // --- ADD 2012/09/18 ----------<<<<<
        
        #endregion // プライベート変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SuppYearResultAcs()
        {
            this._iSuppYearResultDB = MediationSuppYearResultDB.GetSuppYearResultDB();

            this._dataSet = new InventoryUpdateDataSet();
            this._companyInfAcs = new CompanyInfAcs();

            this._moneyKindAcs = new MoneyKindAcs();
            this._stockProcMoneyAcs = new StockProcMoneyAcs();

            // 日付取得部品
            _dateGetAcs = DateGetAcs.GetInstance();

            _totalDayCalculator = TotalDayCalculator.GetInstance(); // ADD 2009/06/17

            // --- ADD 2012/09/18 ---------->>>>>
            #region ●オプション情報
            this.CacheOptionInfo();
            #endregion
            // --- ADD 2012/09/18 ----------<<<<<
        }

        #endregion // コンストラクタ

        #region プロパティ

        /// <summary>
        /// データセット
        /// </summary>
        public InventoryUpdateDataSet DataSet
        {
            get { return _dataSet; }
        }

        /// <summary>
        /// データビュー
        /// </summary>
        public DataView DataView
        {
            get
            {
                return this._dataSet.MonthResult.DefaultView;
            }
        }

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// データビュー
        /// </summary>
        public DataView OutPutDataView
        {
            get
            {
                return this._dataSet.OutPutResult.DefaultView;
            }
        }
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// <summary>現在処理年月(処理対象年が前年度の時は年度終了日)</summary>
        public DateTime AddUpYearMonth
        {
            get { return this._addUpYearMonth; }
            set { this._addUpYearMonth = value; }
        }

        /// <summary>処理対象年開始日</summary>
        public DateTime CompanyBeginDate
        {
            get { return this._companyBeginDate; }
            set { this._companyBeginDate = value; }
        }

        /// <summary>処理対象年開始日</summary>
        public DateTime This_YearMonth
        {
            get { return this._this_YearMonth; }
            set { this._this_YearMonth = value; }
        }

        // ---------------ADD 2011/03/23 ------------------->>>>>
        // テキスト出力orExcel出力区分
        public bool ExcOrtxtDiv
        {
            get { return this._excOrtxtDiv; }
            set { _excOrtxtDiv = value; }
        }
        // ---------------ADD 2011/03/23 -------------------<<<<<

        /// <summary>仕入金額端数処理コード</summary>
        public int StockPriceFrcProcCd
        {
            get { return this._stockPriceFrcProcCd; }
            set { this._stockPriceFrcProcCd = value; }
        }

        #endregion // プロパティ

        #region 公開関数

        /// <summary>
        /// 自社情報取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="financialYear">(out)会計年度</param>
        /// <param name="companyBeginMonth">(out)会計年度開始月</param>
        public void GetCompanyInf(string enterpriseCode, out int financialYear, out int companyBeginMonth)
        {
            financialYear = System.DateTime.Now.Year;
            companyBeginMonth = 0;

            // 自社情報読み込み
            int status = this._companyInfAcs.Read(out this._companyInf, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                financialYear = this._companyInf.FinancialYear;
                companyBeginMonth = this._companyInf.CompanyBiginMonth;
            }
        }

        /// <summary>
        /// 会計年度および企業コードから会計年度開始日を返します
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="financialYear"></param>
        /// <param name="companyBeginDate"></param>
        public bool GetCompanyBeginDate(string enterpriseCode, int financialYear, out DateTime companyBeginDate)
        {
            companyBeginDate = DateTime.MinValue;

            // 自社情報読み込み
            CompanyInf companyInf;
            int status = this._companyInfAcs.Read(out companyInf, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int year = companyInf.FinancialYear;
                int date = companyInf.CompanyBiginDate;

                if (year == financialYear)
                {
                    companyBeginDate = TDateTime.LongDateToDateTime(date);
                    return true;
                }
                else
                {
                    companyBeginDate = TDateTime.LongDateToDateTime(date).AddYears(-1);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 金種コードから金種名を取得
        /// </summary>
        /// <param name="MoneyKindCode">金種コード</param>
        /// <param name="MoneyKindName">金種名</param>
        /// <param name="enterpriseCd">企業コード</param>
        /// <returns></returns>
        public int GetMoneyKindName(int MoneyKindCode, out string MoneyKindName, string enterpriseCd)
        {
            MoneyKindName = string.Empty;

            ArrayList retList;
            int status = this._moneyKindAcs.Search(out retList, enterpriseCd);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (MoneyKind mk in retList)
                {
                    if (mk.MoneyKindCode == MoneyKindCode)
                    {
                        MoneyKindName = mk.MoneyKindName.Trim();
                        break;
                    }
                }
                
            }
            return status;
        }

        /// <summary>
        /// 年月日系を取得
        /// </summary>
        /// <param name="financialYear">対象となる会計年度(画面上の数値)</param>
        /// <param name="baseDate">基準となる年月日(画面上で指定された日付)</param>
        public void GetDateParams(int financialYear, DateTime baseDate, string enterpriseCode)
        {
            if (baseDate == DateTime.MinValue) return;

            
            //int currentFinancialYear = this._companyInf.FinancialYear;
            //List<DateTime> startMonthTable;
            //List<DateTime> endMonthTable;
            //List<DateTime> monthList;
            //DateTime startYearDate; // DEL 2009/01/30
            //DateTime endYearDate; // DEL 2009/01/30

            // 必要となるもの
            // 計上年月         [this._addUpYearMonth]  現在処理中年月
            // 当期開始年月度   [this._this_YearMonth]
            // 期首年月日       [this._companyBeginDate]

            // 現在処理年月を取得(yyyy/MM/01)
            // DEL 2009/06/17 ------>>>
            //this._dateGetAcs.GetThisYearMonth(out this._addUpYearMonth);
            //this._addUpYearMonth = DateTime.Parse(this._addUpYearMonth.ToString("yyyy/MM") + "/01 00:00:00");
            // DEL 2009/06/17 ------<<<
            
            // ADD 2009/06/17 ------>>>
            // 現在処理年月を今回月次更新年月とする
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;

            _totalDayCalculator.InitializeHisMonthly();
            _totalDayCalculator.GetHisTotalDayMonthly("", out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
            if (currentTotalMonth != DateTime.MinValue)
            {
                this._addUpYearMonth = DateTime.Parse(currentTotalMonth.ToString("yyyy/MM") + "/01 00:00:00");
            }
            else
            {
                this._dateGetAcs.GetThisYearMonth(out this._addUpYearMonth);
                this._addUpYearMonth = DateTime.Parse(this._addUpYearMonth.ToString("yyyy/MM") + "/01 00:00:00");
            }
            // ADD 2009/06/17 ------<<<
            
            // 当期開始年月度(yyyy/MM/01)を取得
            GetCompanyBeginDate(enterpriseCode, financialYear, out this._this_YearMonth);
            this._this_YearMonth = DateTime.Parse(this._this_YearMonth.ToString("yyyy/MM") + "/01 00:00:00");

            // 年度の開始日(yyyy/MM/dd)を取得
            GetCompanyBeginDate(enterpriseCode, financialYear, out this._companyBeginDate);

            //int year;
            //int addYears;
            //DateTime startYearMonth;
            //DateTime endYearMonth;
            //// 指定された年度の開始日を取得(基準日は画面上の入力日)
            //this._dateGetAcs.GetYearMonth(baseDate, out startYearDate, out year, out startYearMonth, out endYearMonth, out this._this_YearMonth, out endYearDate);
            //this._this_YearMonth = DateTime.Parse(this._this_YearMonth.ToString("yyyy/MM") + "/01 00:00:00");

            //// 指定された年度の年度開始月を取得
            //this._dateGetAcs.GetYearFromMonth(baseDate, out year, out addYears, out startYearMonth, out endYearMonth);

            //// 年月度の開始日・終了日を取得
            //DateTime startMonthDate;
            //DateTime endMonthDate;
            //this._dateGetAcs.GetDaysFromMonth(startYearMonth, out startMonthDate, out endMonthDate);
            //this._companyBeginDate = startMonthDate; // 期首年月日(年度の開始月の開始日)

        }

        // --- ADD 2012/11/08 ---------->>>>>
        /// <summary>
        /// 締日取得処理（金額・月次買掛）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <returns>STATUS</returns>
        public int GetTotalDayMonthlyAccPay(string enterpriseCode, string sectionCode, int supplierCd, out DateTime prevTotalDay)
        {
            sectionCode = sectionCode.Trim();

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;

            // リモート呼び出し
            DateTime date;
            status = _iSuppYearResultDB.SearchMonthlyAccPay(enterpriseCode, sectionCode, supplierCd, out date);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            //--------------------------------------------
            // 算出結果をセット
            //--------------------------------------------
            prevTotalDay = date;

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        // --- ADD 2012/11/08 ----------<<<<<
        #endregion // 公開関数

        #region データセットを設定

        /// <summary>
        /// グリッドに使用するデータセットを設定
        /// </summary>
        public void SetDataSetBase()
        {
            int companyBeginMonth = this._companyInf.CompanyBiginMonth;

            // 会計年度テーブルを取得(開始月 - 終了月[12行])
            //this._dateGetAcs.GetFinancialYearTable((currentFinancialYear - financialYear) * -1, out startMonthTable, out endMonthTable, out monthList, out year);

            // 月名称列を設定
            for (int ix = 0; ix < 14; ix++)
            {
                // 月ごとに新規行を作成[12行] + 固定行2行(合計/平均)
                // 月ごとの行は年度開始月～年度終了月で順に作成
                InventoryUpdateDataSet.MonthResultRow row = _dataSet.MonthResult.NewMonthResultRow();
                if (ix < 12)
                {
                    int iMonth = companyBeginMonth + ix;
                    if (iMonth > 12) { iMonth = iMonth - 12; }
                    row.RowTitle = iMonth.ToString() + "月";
                    row.RowMonth = iMonth;
                }
                if (ix == 12) { row.RowTitle = "合計"; }
                if (ix == 13) { row.RowTitle = "平均"; }

                row.RowNo = ix;
                row.RowSetFlg = 0;
                _dataSet.MonthResult.AddMonthResultRow(row);
            }
        }

        #endregion // データセットを設定

        #region 検索

        /// <summary>
        /// 仕入実績照会データを検索し、検索結果をデータテーブルにキャッシュします。
        /// </summary>
        /// <param name="suppYearResultCndtn">検索条件データクラス</param>
        /// <returns>status</returns>
        /// <br>Update Note : 2010/09/08 楊明俊</br>
        /// <br>            ・障害ID:14443 テキスト出力対応</br>
        public int Search(SuppYearResultCndtn suppYearResultCndtn)
        {
            int status = 0;

            // データセットの金額欄をゼロクリア
            if(!"SubMain".Equals(suppYearResultCndtn.MainDiv)) // ADD 2010/07/20
                this.ClearMonthResult2Zero();
            // 残高照会の前回検索時データをクリア
            this._dataSet.AccPayResult.Clear(); // ADD 2009/01/30

            this._dataSet.OutPutResult.Rows.Clear(); // ADD 2010/07/20

            // 仕入金額処理区分リストを取得
            ArrayList returnStockProcMoney;
            List<StockProcMoney> stockProcMoneyList = new List<StockProcMoney>();

            status = this._stockProcMoneyAcs.Search(out returnStockProcMoney, suppYearResultCndtn.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                {
                    foreach (StockProcMoney stockProcMoney in (ArrayList)returnStockProcMoney)
                    {
                        stockProcMoneyList.Add(stockProcMoney.Clone());
                    }
                }

                this._stockCalculator = new StockPriceCalculate(stockProcMoneyList);
            }

            SuppYearResultCndtnWork suppYearResultCndtnWork = new SuppYearResultCndtnWork();
            suppYearResultCndtnWork.EnterpriseCode = suppYearResultCndtn.EnterpriseCode;        // 企業コード
            suppYearResultCndtnWork.SectionCode = suppYearResultCndtn.SectionCode;              // 拠点コード
            suppYearResultCndtnWork.SupplierCd = suppYearResultCndtn.SupplierCd;                // 仕入先コード
            suppYearResultCndtnWork.AccDiv = suppYearResultCndtn.AccDiv;                        // 精算先区分
            suppYearResultCndtnWork.SuppTotalDay = suppYearResultCndtn.SuppTotalDay;            // 仕入先の最終締年月日
            suppYearResultCndtnWork.CompanyBiginDate = suppYearResultCndtn.CompanyBiginDate;    // 期首年月日
            suppYearResultCndtnWork.This_YearMonth = suppYearResultCndtn.This_YearMonth;        // 当期計上年月度
            suppYearResultCndtnWork.AddUpYearMonth = suppYearResultCndtn.AddUpYearMonth;        // 現在処理中年月
            suppYearResultCndtnWork.SecTotalDay = suppYearResultCndtn.SecTotalDay;              // 自社締日

            // --- ADD 2010/07/20-------------------------------->>>>>
            if (!String.IsNullOrEmpty(suppYearResultCndtn.MainDiv) && "SubMain".Equals(suppYearResultCndtn.MainDiv))
            {
                // 拠点コードFrom～To
                suppYearResultCndtnWork.SectionCodeSt = suppYearResultCndtn.SectionCodeSt;
                suppYearResultCndtnWork.SectionCodeEnd = suppYearResultCndtn.SectionCodeEnd;
                // 仕入先コードFrom～To
                suppYearResultCndtnWork.SupplierCdSt = suppYearResultCndtn.SupplierCdSt;
                suppYearResultCndtnWork.SupplierCdEnd = suppYearResultCndtn.SupplierCdEnd;
            }
            // 画面区分
            suppYearResultCndtnWork.MainDiv = suppYearResultCndtn.MainDiv;
            // --- ADD 2010/07/20--------------------------------<<<<<

            object paraObj = (object)suppYearResultCndtnWork;
            object retObjResult; // 年間実績
            object retObjAccPay; // 残高照会

            // --- DEL 2012/09/18 ---------------------------->>>>>
            //status = this._iSuppYearResultDB.Search(out retObjAccPay, out retObjResult, paraObj);
            // --- DEL 2012/09/18 ----------------------------<<<<<
            // --- ADD 2012/09/18 ---------------------------->>>>>
            if (this._optSuppSumEnable)
            {
                // 仕入先総括有効時のリモートクラスのメソッドをコール
                status = this._iSuppYearResultDB.SearchSuppSum(out retObjAccPay, out retObjResult, paraObj);
            }
            else
            {
                // 既存メソッドをコール
                status = this._iSuppYearResultDB.Search(out retObjAccPay, out retObjResult, paraObj);
            }
            // --- ADD 2012/09/18 ----------------------------<<<<<

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 実績照会をデータセット
                ArrayList retListResult = (ArrayList)retObjResult;
                // --- ADD 2010/07/20-------------------------------->>>>>
                if (!String.IsNullOrEmpty(suppYearResultCndtn.MainDiv) && "SubMain".Equals(suppYearResultCndtn.MainDiv))
                {
                    List<SuppYearResultSuppResultWork> retTempListResult = new List<SuppYearResultSuppResultWork>();
                    foreach (SuppYearResultSuppResultWork data in retListResult)
                    {
                        // --- ADD 2010/09/08-------------------------------->>>>>
                        data.StockSectionCd = data.StockSectionCd.Trim();
                        // --- ADD 2010/09/08--------------------------------<<<<<
                        retTempListResult.Add(data);
                    }
                    Dictionary<string, List<SuppYearResultSuppResultWork>> result = ResultWorkSet(retTempListResult);

                    _dataSet.OutPutResult.Rows.Clear();
                    foreach (String key in result.Keys)
                    {
                        InventoryUpdateDataSet.OutPutResultRow row = _dataSet.OutPutResult.NewOutPutResultRow();
                        _dataSet.OutPutResult.AddOutPutResultRow(row);
                    }
                    int index = 0;
                    foreach (String key in result.Keys)
                    {
                        List<SuppYearResultSuppResultWork> tempList = (List<SuppYearResultSuppResultWork>)result[key];
                        if ((tempList.Count > 0) && (retListResult[0] is SuppYearResultSuppResultWork))
                        {
                            foreach (SuppYearResultSuppResultWork data in tempList)
                            {
                                // --- ADD 2010/09/08-------------------------------->>>>>
                                data.StockSectionCd = data.StockSectionCd.Trim();
                                // --- ADD 2010/09/08--------------------------------<<<<<
                                this.ResultWork2DataSetBuMonth(data, index);
                            }
                            index += 1;
                        }
                    }
                }
                else
                {
                // --- ADD 2010/07/20--------------------------------<<<<<
                    if ((retListResult.Count > 0) && (retListResult[0] is SuppYearResultSuppResultWork))
                    {
                        this._monthCount = 0;
                        int count = 0;
                        foreach (SuppYearResultSuppResultWork data in retListResult)
                        {
                            // --- ADD 2010/09/08-------------------------------->>>>>
                            data.StockSectionCd = data.StockSectionCd.Trim();
                            // --- ADD 2010/09/08--------------------------------<<<<<
                            this.ResultWork2DataSet(data);
                            count++;
                        }

                        // 空行を追加
                        if (count < 12)
                        {
                            for (int ix = 0; ix < 12 - count; ix++)
                            {
                                this.ResultWork2DataSet(ix);
                            }
                        }
                    }

                    // 残高照会をデータセットへ
                    if (retObjAccPay != null)
                    {
                        SuppYearResultAccPayWork dataAccPay = (SuppYearResultAccPayWork)retObjAccPay;
                        this.AccPayWork2DataSet(dataAccPay);
                    }

                    // 合計値・平均値をセット
                    SetTotalAverage();
                    this._dataSet.MonthResult.DefaultView.Sort = this._dataSet.MonthResult.RowNoColumn.ColumnName;
                }

            }
            return status;
        }

        #endregion // 検索

        // --- ADD 2010/07/20-------------------------------->>>>>
        #region Group By 操作

        /// <summary>
        /// 仕入実績照会データテーブルの行を設定する
        /// </summary>
        /// <param name="retListResult">結果リスト</param>
        /// <returns>キーと値のコレクション</returns>
        private Dictionary<string, List<SuppYearResultSuppResultWork>> ResultWorkSet(List<SuppYearResultSuppResultWork> retListResult)
        {
            //Dictionary<string, List<SuppYearResultSuppResultWork>> result = null; // DEL 2010/10/27
            Dictionary<string, List<SuppYearResultSuppResultWork>> result = new Dictionary<string, List<SuppYearResultSuppResultWork>>();//ADD 2010/10/27
            List<SuppYearResultSuppResultWork> tempList = null;

            String tKey = "-1";
            String tempKey = "";
            if (null != retListResult && retListResult.Count > 0)
            {
                result = new Dictionary<string, List<SuppYearResultSuppResultWork>>();
                tempList = new List<SuppYearResultSuppResultWork>();
                retListResult.Sort(delegate(SuppYearResultSuppResultWork a, SuppYearResultSuppResultWork b)
                        {
                            int st = Convert.ToInt16(a.StockSectionCd.Trim()).CompareTo(Convert.ToInt16(b.StockSectionCd.Trim()));
                            if (st == 0) st = a.SupplierCd.CompareTo(b.SupplierCd);
                            return st;
                        });
            }

            foreach (SuppYearResultSuppResultWork data in retListResult)
            {
                tempKey = data.StockSectionCd.Trim() + "/" + data.SupplierCd.ToString();
                if (!tKey.Equals(tempKey))
                {
                    if (null != tempList)
                    {
                        tempList.Sort(delegate(SuppYearResultSuppResultWork a, SuppYearResultSuppResultWork b)
                        {
                            return a.AddUpYearMonth.CompareTo(b.AddUpYearMonth);
                        });
                    }
                    tempList = new List<SuppYearResultSuppResultWork>();
                    result.Add(tempKey, tempList);
                    tempList.Add(data);
                    tKey = tempKey;
                }
                else
                {
                    tempList.Add(data);
                }
            }
            if (null != tempList)
            {
                tempList.Sort(delegate(SuppYearResultSuppResultWork a, SuppYearResultSuppResultWork b)
                        {
                            return a.AddUpYearMonth.CompareTo(b.AddUpYearMonth);
                        });
            }
            return result;
        }

        #endregion
        // --- ADD 2010/07/20--------------------------------<<<<<

        #region データセット操作

        /// <summary>
        /// 仕入実績照会データテーブルの行をクリアします。
        /// </summary>
        public void ClearDataset()
        {
            this._dataSet.MonthResult.Rows.Clear();
            this._dataSet.AccPayResult.Rows.Clear();
        }

        /// <summary>
        /// 仕入実績照会（実績照会）データ行クラスゼロクリア処理（月次）
        /// </summary>
        private void ClearMonthResult2Zero()
        {
            for (int ix = 0; ix < _dataSet.MonthResult.Count; ix++)
            {
                // 仕入金額欄
                _dataSet.MonthResult[ix].St_StockPriceTaxExc = 0;
                _dataSet.MonthResult[ix].St_StockRetGoodsPrice = 0;
                _dataSet.MonthResult[ix].St_StockTotalDiscount = 0;
                _dataSet.MonthResult[ix].St_StockPriceConsTax = 0;
                _dataSet.MonthResult[ix].St_StockPriceSum = 0;

                // 取寄金額欄
                _dataSet.MonthResult[ix].Or_StockPriceTaxExc = 0;
                _dataSet.MonthResult[ix].Or_StockRetGoodsPrice = 0;
                _dataSet.MonthResult[ix].Or_StockTotalDiscount = 0;
                _dataSet.MonthResult[ix].Or_StockPriceConsTax = 0;
                _dataSet.MonthResult[ix].Or_StockPriceSum = 0;

                // 合計金額欄
                _dataSet.MonthResult[ix].To_StockPriceTaxExc = 0;
                _dataSet.MonthResult[ix].To_StockRetGoodsPrice = 0;
                _dataSet.MonthResult[ix].To_StockTotalDiscount = 0;
                _dataSet.MonthResult[ix].To_StockPriceConsTax = 0;
                _dataSet.MonthResult[ix].To_StockPriceSum = 0;
            }
        }

        #endregion // データセット操作

        #region 検索結果をデータセットに

        /// <summary>
        /// 仕入実績照会（実績照会）検索結果からデータテーブル行を作成
        /// </summary>
        /// <param name="data">仕入実績照会（実績照会）検索結果</param>
        /// <br>Update Note :2011/03/23 liyp</br>
        /// <br>             テキスト出力修正</br>
        private void ResultWork2DataSet(SuppYearResultSuppResultWork data)
        {
            //// 月単位
            for (int ix = 0; ix < this._dataSet.MonthResult.Count; ix++)
            {
                // 月が一致する行へセット
                if (data.AddUpYearMonth.Month == _dataSet.MonthResult[ix].RowMonth)
                {
                    // 現在処理年月よりも後の場合は空白
                    if (data.AddUpYearMonth > this._addUpYearMonth)
                    {
                        // --- ADD 2010/07/20-------------------------------->>>>>
                        _dataSet.MonthResult[ix].StockSectionCd = String.Empty;    // 拠点コード
                        _dataSet.MonthResult[ix].SectionGuideNm = String.Empty;    // 拠点名称
                        _dataSet.MonthResult[ix].SupplierCd = String.Empty;    // 仕入先コード
                        _dataSet.MonthResult[ix].SupplierNm = String.Empty;    // 仕入先名称
                        // --- ADD 2010/07/20--------------------------------<<<<<

                        // --- DEL 2010/07/20-------------------------------->>>>>
                        //_dataSet.MonthResult[ix].SetSt_StockPriceTaxExcNull();
                        //_dataSet.MonthResult[ix].SetSt_StockRetGoodsPriceNull();
                        //_dataSet.MonthResult[ix].SetSt_StockTotalDiscountNull();
                        //_dataSet.MonthResult[ix].SetSt_StockPriceConsTaxNull();
                        //_dataSet.MonthResult[ix].SetSt_StockPriceSumNull();
                        //_dataSet.MonthResult[ix].SetOr_StockPriceTaxExcNull();
                        //_dataSet.MonthResult[ix].SetOr_StockRetGoodsPriceNull();
                        //_dataSet.MonthResult[ix].SetOr_StockTotalDiscountNull();
                        //_dataSet.MonthResult[ix].SetOr_StockPriceConsTaxNull();
                        //_dataSet.MonthResult[ix].SetOr_StockPriceSumNull();
                        //_dataSet.MonthResult[ix].SetTo_StockPriceTaxExcNull();
                        //_dataSet.MonthResult[ix].SetTo_StockRetGoodsPriceNull();
                        //_dataSet.MonthResult[ix].SetTo_StockTotalDiscountNull();
                        //_dataSet.MonthResult[ix].SetTo_StockPriceConsTaxNull();
                        //_dataSet.MonthResult[ix].SetTo_StockPriceSumNull();
                        // --- DEL 2010/07/20--------------------------------<<<<<

                        // --- ADD 2010/07/20-------------------------------->>>>>
                        _dataSet.MonthResult[ix].St_StockPriceConsTax = 0;
                        _dataSet.MonthResult[ix].St_StockRetGoodsPrice = 0;
                        _dataSet.MonthResult[ix].St_StockTotalDiscount = 0;
                        _dataSet.MonthResult[ix].St_StockPriceConsTax = 0;
                        _dataSet.MonthResult[ix].St_StockPriceSum = 0;
                        _dataSet.MonthResult[ix].Or_StockPriceTaxExc = 0;
                        _dataSet.MonthResult[ix].Or_StockRetGoodsPrice = 0;
                        _dataSet.MonthResult[ix].Or_StockTotalDiscount = 0;
                        _dataSet.MonthResult[ix].Or_StockPriceConsTax = 0;
                        _dataSet.MonthResult[ix].Or_StockPriceSum = 0;
                        _dataSet.MonthResult[ix].To_StockPriceTaxExc = 0;
                        _dataSet.MonthResult[ix].To_StockRetGoodsPrice = 0;
                        _dataSet.MonthResult[ix].To_StockTotalDiscount = 0;
                        _dataSet.MonthResult[ix].To_StockPriceConsTax = 0;
                        _dataSet.MonthResult[ix].To_StockPriceSum = 0;
                        // --- ADD 2010/07/20--------------------------------<<<<<
                    }
                    else
                    {
                        // 会計年度開始日チェック
                        if (data.AddUpYearMonth >= _companyBeginDate.AddDays(_companyBeginDate.Day * -1))
                        {
                            _dataSet.MonthResult[ix].RowSetFlg = TDateTime.DateTimeToLongDate(data.AddUpYearMonth);   // TODO ?

                            // 仕入金額
                            _dataSet.MonthResult[ix].St_StockPriceTaxExc = _dataSet.MonthResult[ix].St_StockPriceTaxExc + data.St_StockPriceTaxExc;
                            //_dataSet.MonthResult[ix].St_StockRetGoodsPrice = _dataSet.MonthResult[ix].St_StockRetGoodsPrice + data.St_StockRetGoodsPrice; // DEL 2009/02/02
                            _dataSet.MonthResult[ix].St_StockRetGoodsPrice = _dataSet.MonthResult[ix].St_StockRetGoodsPrice - data.St_StockRetGoodsPrice; // ADD 2009/02/02
                            //_dataSet.MonthResult[ix].St_StockTotalDiscount = _dataSet.MonthResult[ix].St_StockTotalDiscount + data.St_StockTotalDiscount; // DEL 2009/02/02
                            _dataSet.MonthResult[ix].St_StockTotalDiscount = _dataSet.MonthResult[ix].St_StockTotalDiscount - data.St_StockTotalDiscount; // ADD 2009/02/02
                            _dataSet.MonthResult[ix].St_StockPriceConsTax = _dataSet.MonthResult[ix].St_StockPriceConsTax + data.St_StockPriceConsTax;
                            _dataSet.MonthResult[ix].St_StockPriceSum = _dataSet.MonthResult[ix].St_StockPriceSum + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // 取寄金額
                            _dataSet.MonthResult[ix].Or_StockPriceTaxExc = _dataSet.MonthResult[ix].Or_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            //_dataSet.MonthResult[ix].Or_StockRetGoodsPrice = _dataSet.MonthResult[ix].Or_StockRetGoodsPrice + data.Or_StockRetGoodsPrice; // DEL 2009/02/02
                            _dataSet.MonthResult[ix].Or_StockRetGoodsPrice = _dataSet.MonthResult[ix].Or_StockRetGoodsPrice - data.Or_StockRetGoodsPrice; // ADD 2009/02/02
                            //_dataSet.MonthResult[ix].Or_StockTotalDiscount = _dataSet.MonthResult[ix].Or_StockTotalDiscount + data.Or_StockTotalDiscount; // DEL 2009/02/02
                            _dataSet.MonthResult[ix].Or_StockTotalDiscount = _dataSet.MonthResult[ix].Or_StockTotalDiscount - data.Or_StockTotalDiscount; // ADD 2009/02/02
                            _dataSet.MonthResult[ix].Or_StockPriceConsTax = _dataSet.MonthResult[ix].Or_StockPriceConsTax + data.Or_StockPriceConsTax;
                            _dataSet.MonthResult[ix].Or_StockPriceSum = _dataSet.MonthResult[ix].Or_StockPriceSum + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // 合計金額
                            _dataSet.MonthResult[ix].To_StockPriceTaxExc = _dataSet.MonthResult[ix].To_StockPriceTaxExc + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            //_dataSet.MonthResult[ix].To_StockRetGoodsPrice = _dataSet.MonthResult[ix].To_StockRetGoodsPrice + data.St_StockRetGoodsPrice + data.Or_StockRetGoodsPrice; // DEL 2009/02/02
                            _dataSet.MonthResult[ix].To_StockRetGoodsPrice = _dataSet.MonthResult[ix].To_StockRetGoodsPrice - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice; // ADD 2009/02/02
                            //_dataSet.MonthResult[ix].To_StockTotalDiscount = _dataSet.MonthResult[ix].To_StockTotalDiscount + data.St_StockTotalDiscount + data.Or_StockTotalDiscount; // DEL 2009/02/02
                            // 2009.03.02 30413 犬飼 値引の符号を反転させる >>>>>>START
                            // --- CHG 2009/02/12 障害ID:11087対応------------------------------------------------------>>>>>
                            //_dataSet.MonthResult[ix].To_StockTotalDiscount = _dataSet.MonthResult[ix].To_StockTotalDiscount + data.St_StockTotalDiscount - data.Or_StockTotalDiscount; // ADD 2009/02/02
                            //_dataSet.MonthResult[ix].To_StockTotalDiscount = _dataSet.MonthResult[ix].To_StockTotalDiscount + data.St_StockTotalDiscount - data.Or_StockTotalDiscount; // ADD 2009/02/02
                            _dataSet.MonthResult[ix].To_StockTotalDiscount = _dataSet.MonthResult[ix].To_StockTotalDiscount - data.St_StockTotalDiscount - data.Or_StockTotalDiscount; // ADD 2009/02/02
                            // --- CHG 2009/02/12 障害ID:11087対応------------------------------------------------------<<<<<
                            // 2009.03.02 30413 犬飼 値引の符号を反転させる <<<<<<END
                            _dataSet.MonthResult[ix].To_StockPriceConsTax = _dataSet.MonthResult[ix].To_StockPriceConsTax + data.St_StockPriceConsTax + data.Or_StockPriceConsTax;
                            _dataSet.MonthResult[ix].To_StockPriceSum = _dataSet.MonthResult[ix].To_StockPriceSum + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount 
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

        // --- ADD 2010/07/20-------------------------------->>>>>
                            _dataSet.MonthResult[ix].StockSectionCd = data.StockSectionCd.ToString();   // 拠点コード
                            _dataSet.MonthResult[ix].SectionGuideNm = data.SectionGuideNm.ToString();   // 拠点名称
                            //_dataSet.MonthResult[ix].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード // DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.MonthResult[ix].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // 仕入先コード
                            }
                            else
                            {
                                _dataSet.MonthResult[ix].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.MonthResult[ix].SupplierNm = data.SupplierNm;   // 仕入先名称
        // --- ADD 2010/07/20--------------------------------<<<<<

                            // 平均で使用する月数
                            _monthCount++;
                        }
                    }
                }
            }
        }

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// 仕入実績照会（実績照会）検索結果からデータテーブル行を作成
        /// </summary>
        /// <param name="data">仕入実績照会（実績照会）検索結果</param>
        /// <param name="beginMonth">index</param>
        /// <param name="index">月単位</param>
        /// <br>Update Note :2011/03/23 liyp</br>
        /// <br>             テキスト出力修正</br>
        private void ResultWork2DataSetBuMonth(SuppYearResultSuppResultWork data, int index)
        {
            string month = data.AddUpYearMonth.Month.ToString();

            // 現在処理年月よりも後の場合は空白
            if (data.AddUpYearMonth > this._addUpYearMonth)
            {
                _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // 拠点コード
                _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // 拠点名称
                //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード //DEL 2011/03/23
                // --------------------ADD 2011/03/23 ------------->>>>>
                if (_excOrtxtDiv)
                {
                    _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // 仕入先コード
                }
                else
                {
                    _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード
                }
                // --------------------ADD 2011/03/23 -------------<<<<<
                _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // 仕入先名称
                return;
            }

            // 会計年度開始日チェック
            if (data.AddUpYearMonth >= _companyBeginDate.AddDays(_companyBeginDate.Day * -1))
            {
                // 月単位
                int indexBetweenMonth = 0;
                int companyBiginMonth = this._companyInf.CompanyBiginMonth;
                if ((data.AddUpYearMonth.Month - companyBiginMonth) >= 0)
                {
                    indexBetweenMonth = data.AddUpYearMonth.Month - companyBiginMonth;
                }
                else
                {
                    indexBetweenMonth = (data.AddUpYearMonth.Month - companyBiginMonth) + 12;
                }
                switch (indexBetweenMonth)
                {
                    case 0:
                        {
                            // 仕入金額
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_1_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_1_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_1_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_1_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_1_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_1_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_1_Month = _dataSet.OutPutResult[index].St_StockPriceSum_1_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // 取寄金額
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_1_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_1_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_1_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_1_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_1_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_1_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_1_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_1_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // 合計金額
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_1_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_1_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_1_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_1_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_1_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_1_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_1_Month = _dataSet.OutPutResult[index].To_StockPriceSum_1_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // 拠点コード
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // 拠点名称
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // 仕入先コード
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // 仕入先名称
                            break;
                        }
                    case 1:
                        {
                            // 仕入金額
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_2_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_2_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_2_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_2_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_2_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_2_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_2_Month = _dataSet.OutPutResult[index].St_StockPriceSum_2_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // 取寄金額
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_2_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_2_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_2_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_2_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_2_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_2_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_2_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_2_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // 合計金額
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_2_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_2_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_2_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_2_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_2_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_2_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_2_Month = _dataSet.OutPutResult[index].To_StockPriceSum_2_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // 拠点コード
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // 拠点名称
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // 仕入先コード
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // 仕入先名称
                            break;
                        }
                    case 2:
                        {
                            // 仕入金額
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_3_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_3_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_3_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_3_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_3_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_3_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_3_Month = _dataSet.OutPutResult[index].St_StockPriceSum_3_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // 取寄金額
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_3_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_3_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_3_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_3_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_3_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_3_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_3_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_3_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // 合計金額
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_3_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_3_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_3_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_3_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_3_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_3_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_3_Month = _dataSet.OutPutResult[index].To_StockPriceSum_3_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // 拠点コード
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // 拠点名称
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // 仕入先コード
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // 仕入先名称
                            break;
                        }
                    case 3:
                        {
                            // 仕入金額
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_4_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_4_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_4_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_4_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_4_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_4_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_4_Month = _dataSet.OutPutResult[index].St_StockPriceSum_4_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // 取寄金額
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_4_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_4_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_4_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_4_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_4_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_4_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_4_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_4_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // 合計金額
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_4_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_4_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_4_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_4_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_4_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_4_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_4_Month = _dataSet.OutPutResult[index].To_StockPriceSum_4_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // 拠点コード
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // 拠点名称
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // 仕入先コード
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // 仕入先名称
                            break;
                        }
                    case 4:
                        {
                            // 仕入金額
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_5_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_5_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_5_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_5_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_5_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_5_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_5_Month = _dataSet.OutPutResult[index].St_StockPriceSum_5_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // 取寄金額
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_5_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_5_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_5_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_5_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_5_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_5_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_5_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_5_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // 合計金額
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_5_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_5_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_5_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_5_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_5_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_5_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_5_Month = _dataSet.OutPutResult[index].To_StockPriceSum_5_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // 拠点コード
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // 拠点名称
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // 仕入先コード
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // 仕入先名称
                            break;
                        }
                    case 5:
                        {
                            // 仕入金額
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_6_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_6_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_6_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_6_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_6_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_6_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_6_Month = _dataSet.OutPutResult[index].St_StockPriceSum_6_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // 取寄金額
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_6_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_6_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_6_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_6_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_6_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_6_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_6_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_6_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // 合計金額
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_6_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_6_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_6_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_6_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_6_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_6_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_6_Month = _dataSet.OutPutResult[index].To_StockPriceSum_6_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // 拠点コード
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // 拠点名称
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // 仕入先コード
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // 仕入先名称
                            break;
                        }
                    case 6:
                        {
                            // 仕入金額
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_7_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_7_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_7_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_7_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_7_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_7_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_7_Month = _dataSet.OutPutResult[index].St_StockPriceSum_7_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // 取寄金額
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_7_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_7_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_7_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_7_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_7_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_7_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_7_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_7_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // 合計金額
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_7_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_7_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_7_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_7_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_7_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_7_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_7_Month = _dataSet.OutPutResult[index].To_StockPriceSum_7_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // 拠点コード
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // 拠点名称
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // 仕入先コード
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // 仕入先名称
                            break;
                        }
                    case 7:
                        {
                            // 仕入金額
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_8_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_8_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_8_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_8_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_8_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_8_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_8_Month = _dataSet.OutPutResult[index].St_StockPriceSum_8_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // 取寄金額
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_8_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_8_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_8_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_8_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_8_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_8_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_8_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_8_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // 合計金額
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_8_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_8_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_8_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_8_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_8_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_8_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_8_Month = _dataSet.OutPutResult[index].To_StockPriceSum_8_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // 拠点コード
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // 拠点名称
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // 仕入先コード
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // 仕入先名称
                            break;
                        }
                    case 8:
                        {
                            // 仕入金額
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_9_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_9_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_9_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_9_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_9_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_9_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_9_Month = _dataSet.OutPutResult[index].St_StockPriceSum_9_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // 取寄金額
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_9_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_9_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_9_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_9_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_9_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_9_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_9_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_9_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // 合計金額
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_9_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_9_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_9_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_9_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_9_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_9_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_9_Month = _dataSet.OutPutResult[index].To_StockPriceSum_9_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // 拠点コード
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // 拠点名称
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // 仕入先コード
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // 仕入先名称
                            break;
                        }
                    case 9:
                        {
                            // 仕入金額
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_10_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_10_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_10_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_10_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_10_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_10_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_10_Month = _dataSet.OutPutResult[index].St_StockPriceSum_10_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // 取寄金額
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_10_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_10_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_10_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_10_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_10_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_10_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_10_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_10_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // 合計金額
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_10_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_10_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_10_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_10_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_10_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_10_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_10_Month = _dataSet.OutPutResult[index].To_StockPriceSum_10_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // 拠点コード
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // 拠点名称
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // 仕入先コード
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // 仕入先名称
                            break;
                        }
                    case 10:
                        {
                            // 仕入金額
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_11_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_11_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_11_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_11_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_11_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_11_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_11_Month = _dataSet.OutPutResult[index].St_StockPriceSum_11_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // 取寄金額
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_11_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_11_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_11_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_11_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_11_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_11_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_11_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_11_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // 合計金額
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_11_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_11_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_11_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_11_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_11_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_11_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_11_Month = _dataSet.OutPutResult[index].To_StockPriceSum_11_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // 拠点コード
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // 拠点名称
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // 仕入先コード
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // 仕入先名称
                            break;
                        }
                    case 11:
                        {
                            // 仕入金額
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_12_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_12_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_12_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_12_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_12_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_12_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_12_Month = _dataSet.OutPutResult[index].St_StockPriceSum_12_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // 取寄金額
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_12_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_12_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_12_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_12_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_12_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_12_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_12_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_12_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // 合計金額
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_12_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_12_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_12_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_12_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_12_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_12_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_12_Month = _dataSet.OutPutResult[index].To_StockPriceSum_12_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // 拠点コード
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // 拠点名称
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // 仕入先コード
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // 仕入先コード
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // 仕入先名称
                            break;
                        }

                }
            }
        }
        // --- ADD 2010/07/20--------------------------------<<<<<
        
        /// <summary>
        /// 仕入実績照会（実績照会）検索結果からデータテーブル行を作成
        /// </summary>
        /// <param name="data">仕入実績照会（実績照会）検索結果</param>
        private void ResultWork2DataSet(int ix)
        {
            // --- ADD 2010/07/20-------------------------------->>>>>
            _dataSet.MonthResult[11 - ix].StockSectionCd = String.Empty;   // 拠点コード
            _dataSet.MonthResult[11 - ix].SectionGuideNm = String.Empty;   // 拠点名称
            _dataSet.MonthResult[11 - ix].SupplierCd = String.Empty;    // 仕入先コード
            _dataSet.MonthResult[11 - ix].SupplierNm = String.Empty;    // 仕入先名称
            // --- ADD 2010/07/20--------------------------------<<<<<

            // --- DEL 2010/07/20-------------------------------->>>>>
            //_dataSet.MonthResult[11 - ix].SetSt_StockPriceTaxExcNull();
            //_dataSet.MonthResult[11 - ix].SetSt_StockRetGoodsPriceNull();
            //_dataSet.MonthResult[11 - ix].SetSt_StockTotalDiscountNull();
            //_dataSet.MonthResult[11 - ix].SetSt_StockPriceConsTaxNull();
            //_dataSet.MonthResult[11 - ix].SetSt_StockPriceSumNull();
            //_dataSet.MonthResult[11 - ix].SetOr_StockPriceTaxExcNull();
            //_dataSet.MonthResult[11 - ix].SetOr_StockRetGoodsPriceNull();
            //_dataSet.MonthResult[11 - ix].SetOr_StockTotalDiscountNull();
            //_dataSet.MonthResult[11 - ix].SetOr_StockPriceConsTaxNull();
            //_dataSet.MonthResult[11 - ix].SetOr_StockPriceSumNull();
            //_dataSet.MonthResult[11 - ix].SetTo_StockPriceTaxExcNull();
            //_dataSet.MonthResult[11 - ix].SetTo_StockRetGoodsPriceNull();
            //_dataSet.MonthResult[11 - ix].SetTo_StockTotalDiscountNull();
            //_dataSet.MonthResult[11 - ix].SetTo_StockPriceConsTaxNull();
            //_dataSet.MonthResult[11 - ix].SetTo_StockPriceSumNull();
            // --- DEL 2010/07/20--------------------------------<<<<<

            // --- ADD 2010/07/20-------------------------------->>>>>
            _dataSet.MonthResult[11 - ix].St_StockPriceTaxExc = 0;
            _dataSet.MonthResult[11 - ix].St_StockRetGoodsPrice = 0;
            _dataSet.MonthResult[11 - ix].St_StockTotalDiscount = 0;
            _dataSet.MonthResult[11 - ix].St_StockPriceConsTax = 0;
            _dataSet.MonthResult[11 - ix].St_StockPriceSum = 0;
            _dataSet.MonthResult[11 - ix].Or_StockPriceTaxExc = 0;
            _dataSet.MonthResult[11 - ix].Or_StockRetGoodsPrice = 0;
            _dataSet.MonthResult[11 - ix].Or_StockTotalDiscount = 0;
            _dataSet.MonthResult[11 - ix].Or_StockPriceConsTax = 0;
            _dataSet.MonthResult[11 - ix].Or_StockPriceSum = 0;
            _dataSet.MonthResult[11 - ix].To_StockPriceTaxExc = 0;
            _dataSet.MonthResult[11 - ix].To_StockRetGoodsPrice = 0;
            _dataSet.MonthResult[11 - ix].To_StockTotalDiscount = 0;
            _dataSet.MonthResult[11 - ix].To_StockPriceConsTax = 0;
            _dataSet.MonthResult[11 - ix].To_StockPriceSum = 0;
            // --- ADD 2010/07/20--------------------------------<<<<<
        }

        /// <summary>
        /// 仕入実績照会（残高照会）検索結果からデータテーブル行を作成
        /// </summary>
        /// <param name="data">仕入実績照会（残高照会）検索結果</param>
        private void AccPayWork2DataSet(SuppYearResultAccPayWork data)
        {
            // 残高データは1件のみ
            DataRow row = this._dataSet.AccPayResult.NewRow();
            row[this._dataSet.AccPayResult.StockTtl3TmBfBlPayColumn.ColumnName] = data.StockTtl3TmBfBlPay;
            row[this._dataSet.AccPayResult.StockTtl2TmBfBlPayColumn.ColumnName] = data.StockTtl2TmBfBlPay;
            row[this._dataSet.AccPayResult.LastTimePaymenColumn.ColumnName] = data.LastTimePayment;
            row[this._dataSet.AccPayResult.CashePaymenColumn.ColumnName] = data.CashePayment;
            row[this._dataSet.AccPayResult.TrfrPaymentColumn.ColumnName] = data.TrfrPayment;
            row[this._dataSet.AccPayResult.CheckKPaymentColumn.ColumnName] = data.CheckKPayment;
            row[this._dataSet.AccPayResult.DraftPaymentColumn.ColumnName] = data.DraftPayment;
            row[this._dataSet.AccPayResult.OffsetPaymentColumn.ColumnName] = data.OffsetPayment;
            row[this._dataSet.AccPayResult.FundtransferPaymentColumn.ColumnName] = data.FundtransferPayment;
            row[this._dataSet.AccPayResult.EmoneyPaymentColumn.ColumnName] = data.EmoneyPayment;
            row[this._dataSet.AccPayResult.OtherPaymentColumn.ColumnName] = data.OtherPayment;
            row[this._dataSet.AccPayResult.ThisTimeFeePayNrmlColumn.ColumnName] = data.ThisTimeFeePayNrml;
            row[this._dataSet.AccPayResult.ThisTimeDisPayNrmlColumn.ColumnName] = data.ThisTimeDisPayNrml;
            row[this._dataSet.AccPayResult.StockSlipCountColumn.ColumnName] = data.StockSlipCount;
            row[this._dataSet.AccPayResult.ThisTimeStockPriceColumn.ColumnName] = data.ThisTimeStockPrice;
            // 2009.03.09 30413 犬飼 返品・値引の符号を反転 >>>>>>START
            //row[this._dataSet.AccPayResult.ThisStckPricRgdsColumn.ColumnName] = data.ThisStckPricRgds;
            //row[this._dataSet.AccPayResult.ThisStckPricDisColumn.ColumnName] = data.ThisStckPricDis;
            row[this._dataSet.AccPayResult.ThisStckPricRgdsColumn.ColumnName] = -data.ThisStckPricRgds;
            row[this._dataSet.AccPayResult.ThisStckPricDisColumn.ColumnName] = -data.ThisStckPricDis;
            // 2009.03.09 30413 犬飼 返品・値引の符号を反転 <<<<<<END
            row[this._dataSet.AccPayResult.OfsThisTimeStockColumn.ColumnName] = data.OfsThisTimeStock;
            row[this._dataSet.AccPayResult.OfsThisStockTaxColumn.ColumnName] = data.OfsThisStockTax;
            row[this._dataSet.AccPayResult.StockTotalPayBalanceColumn.ColumnName] = data.StockTotalPayBalance;
            row[this._dataSet.AccPayResult.MonthLastTimeAccPayColumn.ColumnName] = data.MonthLastTimeAccPay;
            row[this._dataSet.AccPayResult.MonthCashePaymentColumn.ColumnName] = data.MonthCashePayment;
            row[this._dataSet.AccPayResult.MonthTrfrPaymentColumn.ColumnName] = data.MonthTrfrPayment;
            row[this._dataSet.AccPayResult.MonthCheckKPaymentColumn.ColumnName] = data.MonthCheckKPayment;
            row[this._dataSet.AccPayResult.MonthDraftPaymentColumn.ColumnName] = data.MonthDraftPayment;
            row[this._dataSet.AccPayResult.MonthOffsetPaymentColumn.ColumnName] = data.MonthOffsetPayment;
            row[this._dataSet.AccPayResult.MonthFundtransferPaymentColumn.ColumnName] = data.MonthFundtransferPayment;
            row[this._dataSet.AccPayResult.MonthEmoneyPaymentColumn.ColumnName] = data.MonthEmoneyPayment;
            row[this._dataSet.AccPayResult.MonthOtherPaymentColumn.ColumnName] = data.MonthOtherPayment;
            row[this._dataSet.AccPayResult.MonthThisTimeFeePayNrmlColumn.ColumnName] = data.MonthThisTimeFeePayNrml;
            row[this._dataSet.AccPayResult.MonthThisTimeDisPayNrmlColumn.ColumnName] = data.MonthThisTimeDisPayNrml;
            row[this._dataSet.AccPayResult.MonthStockSlipCountColumn.ColumnName] = data.MonthStockSlipCount;
            row[this._dataSet.AccPayResult.MonthThisTimeStockPriceColumn.ColumnName] = data.MonthThisTimeStockPrice;
            // 2009.03.09 30413 犬飼 返品・値引の符号を反転 >>>>>>START
            //row[this._dataSet.AccPayResult.MonthThisStckPricRgdsColumn.ColumnName] = data.MonthThisStckPricRgds;
            //row[this._dataSet.AccPayResult.MonthThisStckPricDisColumn.ColumnName] = data.MonthThisStckPricDis;
            row[this._dataSet.AccPayResult.MonthThisStckPricRgdsColumn.ColumnName] = -data.MonthThisStckPricRgds;
            row[this._dataSet.AccPayResult.MonthThisStckPricDisColumn.ColumnName] = -data.MonthThisStckPricDis;
            // 2009.03.09 30413 犬飼 返品・値引の符号を反転 <<<<<<END
            row[this._dataSet.AccPayResult.MonthOfsThisTimeStockColumn.ColumnName] = data.MonthOfsThisTimeStock;
            row[this._dataSet.AccPayResult.MonthOfsThisStockTaxColumn.ColumnName] = data.MonthOfsThisStockTax;
            row[this._dataSet.AccPayResult.MonthStckTtlAccPayBalanceColumn.ColumnName] = data.MonthStckTtlAccPayBalance;
            row[this._dataSet.AccPayResult.YearStockSlipCountColumn.ColumnName] = data.YearStockSlipCount;
            row[this._dataSet.AccPayResult.YearThisTimeStockPriceColumn.ColumnName] = data.YearThisTimeStockPrice;
            // 2009.03.09 30413 犬飼 返品・値引の符号を反転 >>>>>>START
            //row[this._dataSet.AccPayResult.YearThisStckPricRgdsColumn.ColumnName] = data.YearThisStckPricRgds;
            //row[this._dataSet.AccPayResult.YearThisStckPricDisColumn.ColumnName] = data.YearThisStckPricDis;
            row[this._dataSet.AccPayResult.YearThisStckPricRgdsColumn.ColumnName] = -data.YearThisStckPricRgds;
            row[this._dataSet.AccPayResult.YearThisStckPricDisColumn.ColumnName] = -data.YearThisStckPricDis;
            // 2009.03.09 30413 犬飼 返品・値引の符号を反転 <<<<<<END
            row[this._dataSet.AccPayResult.YearOfsThisTimeStockColumn.ColumnName] = data.YearOfsThisTimeStock;
            row[this._dataSet.AccPayResult.YearOfsThisStockTaxColumn.ColumnName] = data.YearOfsThisStockTax;

            // --- ADD 2009/02/13 -------------------------------->>>>>
            // 合計値の取得
            row[this._dataSet.AccPayResult.PaymentInfoSumColumn.ColumnName] = data.CashePayment
                                                                            + data.TrfrPayment
                                                                            + data.CheckKPayment
                                                                            + data.DraftPayment
                                                                            + data.OffsetPayment
                                                                            + data.FundtransferPayment
                                                                            + data.EmoneyPayment
                                                                            + data.OtherPayment
                                                                            + data.ThisTimeFeePayNrml
                                                                            + data.ThisTimeDisPayNrml;

            row[this._dataSet.AccPayResult.MonthPaymentInfoSumColumn.ColumnName] = data.MonthCashePayment
                                                                                + data.MonthTrfrPayment
                                                                                + data.MonthCheckKPayment
                                                                                + data.MonthDraftPayment
                                                                                + data.MonthOffsetPayment
                                                                                + data.MonthFundtransferPayment
                                                                                + data.MonthEmoneyPayment
                                                                                + data.MonthOtherPayment
                                                                                + data.MonthThisTimeFeePayNrml
                                                                                + data.MonthThisTimeDisPayNrml;
            // --- ADD 2009/02/13 --------------------------------<<<<<

            this._dataSet.AccPayResult.Rows.Add(row);
        }

        #endregion // 検索結果をデータセットに

        #region 平均セット

        /// <summary>
        /// 仕入実績照会（実績照会）合計値・平均値セット処理
        /// </summary>
        /// <param name="ix">売上実績照会データ合計行番号</param>
        /// <param name="target">売上実績照会データ平均行番号</param>
        /// <param name="data">対象行件数</param>
        private void SetTotalAverage()
        {
            Int64 totalAmt01 = 0;
            Int64 totalAmt02 = 0;
            Int64 totalAmt03 = 0;
            Int64 totalAmt04 = 0;
            Int64 totalAmt05 = 0;
            Int64 totalAmt06 = 0;
            Int64 totalAmt07 = 0;
            Int64 totalAmt08 = 0;
            Int64 totalAmt09 = 0;
            Int64 totalAmt10 = 0;
            Int64 totalAmt11 = 0;
            Int64 totalAmt12 = 0;
            Int64 totalAmt13 = 0;
            Int64 totalAmt14 = 0;
            Int64 totalAmt15 = 0;
            //Double averageAmount = 0; // DEL 2009/01/30
            
            // --- ADD 2010/07/20-------------------------------->>>>>
            if (this._monthCount > 14)
            {
                this._monthCount = 14;
            }
            // --- ADD 2010/07/20--------------------------------<<<<<
            // 各列の合計値を算出
            for (int ix = 0; ix < this._monthCount; ix++)
            {
                totalAmt01 += _dataSet.MonthResult[ix].St_StockPriceTaxExc;
                totalAmt02 += _dataSet.MonthResult[ix].St_StockRetGoodsPrice;
                totalAmt03 += _dataSet.MonthResult[ix].St_StockTotalDiscount;
                totalAmt04 += _dataSet.MonthResult[ix].St_StockPriceConsTax;
                totalAmt05 += _dataSet.MonthResult[ix].Or_StockPriceTaxExc;
                totalAmt06 += _dataSet.MonthResult[ix].Or_StockRetGoodsPrice;
                totalAmt07 += _dataSet.MonthResult[ix].Or_StockTotalDiscount;
                totalAmt08 += _dataSet.MonthResult[ix].Or_StockPriceConsTax;
                totalAmt09 += _dataSet.MonthResult[ix].To_StockPriceTaxExc;
                totalAmt10 += _dataSet.MonthResult[ix].To_StockRetGoodsPrice;
                totalAmt11 += _dataSet.MonthResult[ix].To_StockTotalDiscount;
                totalAmt12 += _dataSet.MonthResult[ix].To_StockPriceConsTax;
                totalAmt13 += _dataSet.MonthResult[ix].St_StockPriceSum;
                totalAmt14 += _dataSet.MonthResult[ix].Or_StockPriceSum;
                totalAmt15 += _dataSet.MonthResult[ix].To_StockPriceSum;
            }
            // --- ADD 2010/07/20-------------------------------->>>>>
            _dataSet.MonthResult[12].StockSectionCd = String.Empty;   // 拠点コード
            _dataSet.MonthResult[12].SectionGuideNm = String.Empty;   // 拠点名称
            _dataSet.MonthResult[12].SupplierCd = String.Empty;   // 仕入先コード
            _dataSet.MonthResult[12].SupplierNm = String.Empty;   // 仕入先名称
            // --- ADD 2010/07/20--------------------------------<<<<<

            _dataSet.MonthResult[12].St_StockPriceTaxExc    = totalAmt01;
            _dataSet.MonthResult[12].St_StockRetGoodsPrice  = totalAmt02;
            _dataSet.MonthResult[12].St_StockTotalDiscount  = totalAmt03;
            _dataSet.MonthResult[12].St_StockPriceConsTax   = totalAmt04;
            _dataSet.MonthResult[12].St_StockPriceSum       = totalAmt13;
            _dataSet.MonthResult[12].Or_StockPriceTaxExc    = totalAmt05;
            _dataSet.MonthResult[12].Or_StockRetGoodsPrice  = totalAmt06;
            _dataSet.MonthResult[12].Or_StockTotalDiscount  = totalAmt07;
            _dataSet.MonthResult[12].Or_StockPriceConsTax   = totalAmt08;
            _dataSet.MonthResult[12].Or_StockPriceSum       = totalAmt14;
            _dataSet.MonthResult[12].To_StockPriceTaxExc    = totalAmt09;
            _dataSet.MonthResult[12].To_StockRetGoodsPrice  = totalAmt10;
            _dataSet.MonthResult[12].To_StockTotalDiscount  = totalAmt11;
            _dataSet.MonthResult[12].To_StockPriceConsTax   = totalAmt12;
            _dataSet.MonthResult[12].To_StockPriceSum       = totalAmt15;


            if (this._monthCount > 0)
            {
                //this._monthCount++;
            // --- ADD 2010/07/20-------------------------------->>>>>
                _dataSet.MonthResult[13].StockSectionCd = String.Empty;   // 拠点コード
                _dataSet.MonthResult[13].SectionGuideNm = String.Empty;   // 拠点名称
                _dataSet.MonthResult[13].SupplierCd = String.Empty;   // 仕入先コード
                _dataSet.MonthResult[13].SupplierNm = String.Empty;   // 仕入先名称
            // --- ADD 2010/07/20--------------------------------<<<<<

                // 丸めは仕入金額計算区分による（自動計算）                
                _dataSet.MonthResult[13].St_StockPriceTaxExc    = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt01 / this._monthCount);
                _dataSet.MonthResult[13].St_StockRetGoodsPrice  = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt02 / this._monthCount);
                _dataSet.MonthResult[13].St_StockTotalDiscount  = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt03 / this._monthCount);
                _dataSet.MonthResult[13].St_StockPriceConsTax   = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt04 / this._monthCount);
                _dataSet.MonthResult[13].St_StockPriceSum       = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt13 / this._monthCount);
                _dataSet.MonthResult[13].Or_StockPriceTaxExc    = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt05 / this._monthCount);
                _dataSet.MonthResult[13].Or_StockRetGoodsPrice  = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt06 / this._monthCount);
                _dataSet.MonthResult[13].Or_StockTotalDiscount  = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt07 / this._monthCount);
                _dataSet.MonthResult[13].Or_StockPriceConsTax   = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt08 / this._monthCount);
                _dataSet.MonthResult[13].Or_StockPriceSum       = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt14 / this._monthCount);
                _dataSet.MonthResult[13].To_StockPriceTaxExc    = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt09 / this._monthCount);
                _dataSet.MonthResult[13].To_StockRetGoodsPrice  = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt10 / this._monthCount);
                _dataSet.MonthResult[13].To_StockTotalDiscount  = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt11 / this._monthCount);
                _dataSet.MonthResult[13].To_StockPriceConsTax   = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt12 / this._monthCount);
                _dataSet.MonthResult[13].To_StockPriceSum       = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt15 / this._monthCount);
            }
        }

        #endregion // 平均セット

        // --- ADD 2012/09/18 ---------->>>>>
        #region ■オプション情報制御処理

        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オプション情報制御処理。</br>
        /// <br>Programmer : FSI 今野</br>
        /// <br>Date       : 2012/09/18</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ●仕入総括機能（個別）オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._optSuppSumEnable = true;
            }
            else
            {
                this._optSuppSumEnable = false;
            }
            #endregion
        }
        #endregion ■オプション情報制御処理
        // --- ADD 2012/09/18 ----------<<<<<
    }
}
