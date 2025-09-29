using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.ParamData;


namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 日付取得部品（日付取得アクセスクラス）
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自社設定マスタより、各種日付を取得するクラスです。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2008.01.23</br>
    /// <br></br>
    /// <br>Update Note: 2008.05.30 鈴木 正臣</br>
    /// <br>               ①PM.NS向け変更。</br>
    /// <br>                 内部のコア機能をPMCMN00006Cに移し、本部品はUI向け機能に限定する。</br>
    /// <br>                 本部品をリモートPGから呼び出す事は禁止する。</br>
    /// </remarks>
    public class DateGetAcs
    {
        /// <summary>
        /// singleton インスタンス
        /// </summary>
        private static DateGetAcs stc_DateGetAcs;

        /// <summary>
        /// 会計年度テーブル取得処理
        /// </summary>
        private FinYearTableGenerator _finYearTableGenerator;

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        private DateGetAcs()
        {
            // 企業コード取得
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 自社設定マスタ読み込み
            CompanyInfAcs companyInfAcs = new CompanyInfAcs();
            companyInfAcs.Read( out _companyInf, _enterpriseCode );
            _finYearTableGenerator = new FinYearTableGenerator( CopyToWorkFromCompanyInf( _companyInf ) );

            // 年だけの区分リスト
            _yearOnlyList = new List<emDateFormat>();
            _yearOnlyList.AddRange( new emDateFormat[] { emDateFormat.df2Y, emDateFormat.df4Y, emDateFormat.dfG2Y } );
            // 年月だけの区分リスト
            _monthOnlyList = new List<emDateFormat>();
            _monthOnlyList.AddRange( new emDateFormat[] { emDateFormat.df2M, emDateFormat.df2Y2M, emDateFormat.df4Y2M, emDateFormat.dfG2Y2M } );
        }
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>自社設定クラス</summary>
        private CompanyInf _companyInf;
        /// <summary>年だけの区分リスト</summary>
        List<emDateFormat> _yearOnlyList;
        /// <summary>年月だけの区分リスト</summary>
        List<emDateFormat> _monthOnlyList;
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        #endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region Public Methods

        # region [日付取得処理]

        # region ■ インスタンス取得処理 ■
        /// <summary>
        /// インスタンス取得処理
        /// </summary>
        /// <returns>DateGetAcsのsingletonのインスタンス</returns>
        public static DateGetAcs GetInstance()
        {
            if ( stc_DateGetAcs == null )
            {
                stc_DateGetAcs = new DateGetAcs();
            }
            return stc_DateGetAcs;
        }
        # endregion ■ インスタンス取得処理 ■


        # region ■ 自社設定クラス取得 ■
        /// <summary>
        /// 自社設定クラス取得処理
        /// </summary>
        /// <returns>日付取得部品が使用している自社設定クラスインスタンス</returns>
        public CompanyInf GetCompanyInf()
        {
            return _companyInf;
        }
        # endregion ■ 自社設定クラス取得 ■

        # region ■ 自社設定マスタ再取得処理 ■
        /// <summary>
        /// 自社設定マスタ再取得処理
        /// </summary>
        /// <remarks>リモート呼び出しにより、自社設定マスタを再度取得します。</remarks>
        public void ReloadCompanyInf()
        {
            // 自社設定マスタ読み込み
            CompanyInfAcs companyInfAcs = new CompanyInfAcs();
            companyInfAcs.Read( out _companyInf, _enterpriseCode );

            _finYearTableGenerator = new FinYearTableGenerator( CopyToWorkFromCompanyInf( _companyInf ) );
        }
        # endregion ■ 自社設定マスタ再取得処理 ■


        # region ■ 会計年度テーブル取得 ■
        /// <summary>
        /// 会計年度テーブル取得処理
        /// </summary>
        /// <param name="startMonthDate">(出力)月度開始日リスト</param>
        /// <param name="endMonthDate">(出力)月度終了日リスト</param>
        /// <remarks>当年の月度開始日・終了日情報を取得します。</remarks>
        public void GetFinancialYearTable( out List<DateTime> startMonthDate, out List<DateTime> endMonthDate )
        {
            _finYearTableGenerator.GetFinancialYearTable( out startMonthDate, out endMonthDate );
        }
        /// <summary>
        /// 会計年度テーブル取得処理
        /// </summary>
        /// <param name="startMonthDate">(出力)月度開始日リスト</param>
        /// <param name="endMonthDate">(出力)月度終了日リスト</param>
        /// <param name="yearMonth">(出力)月度リスト</param>
        /// <remarks>当年の月度開始日・終了日・年月度情報を取得します。</remarks>
        public void GetFinancialYearTable( out List<DateTime> startMonthDate, out List<DateTime> endMonthDate, out List<DateTime> yearMonth )
        {
            _finYearTableGenerator.GetFinancialYearTable( out startMonthDate, out endMonthDate, out yearMonth );
        }
        /// <summary>
        /// 会計年度テーブル取得処理
        /// </summary>
        /// <param name="addYearFromThis">当年からの年度差分</param>
        /// <param name="startMonthDate">(出力)月度開始日リスト</param>
        /// <param name="endMonthDate">(出力)月度終了日リスト</param>
        /// <param name="yearMonth">(出力)月度リスト</param>
        /// <remarks>当年から指定年数先の月度開始日・終了日・年月度情報を取得します。</remarks>
        public void GetFinancialYearTable( int addYearFromThis, out List<DateTime> startMonthDate, out List<DateTime> endMonthDate, out List<DateTime> yearMonth )
        {
            _finYearTableGenerator.GetFinancialYearTable( addYearFromThis, out startMonthDate, out endMonthDate, out yearMonth );
        }
        /// <summary>
        /// 会計年度テーブル取得処理
        /// </summary>
        /// <param name="addYearFromThis">当年からの年度差分</param>
        /// <param name="startMonthDate">(出力)月度開始日リスト</param>
        /// <param name="endMonthDate">(出力)月度終了日リスト</param>
        /// <param name="yearMonth">(出力)月度リスト</param>
        /// <param name="year">(出力)対象年度</param>
        /// <remarks>当年から指定年数先の月度開始日・終了日・年月度情報と年度を取得します。</remarks>
        public void GetFinancialYearTable( int addYearFromThis, out List<DateTime> startMonthDate, out List<DateTime> endMonthDate, out List<DateTime> yearMonth, out int year )
        {
            _finYearTableGenerator.GetFinancialYearTable( addYearFromThis, out startMonthDate, out endMonthDate, out yearMonth, out year );
        }
        /// <summary>
        /// 会計年度テーブル取得処理
        /// </summary>
        /// <param name="year">指定年度</param>
        /// <param name="startMonthDate">(出力)月度開始日リスト</param>
        /// <param name="endMonthDate">(出力)月度終了日リスト</param>
        /// <param name="yearMonth">(出力)月度リスト</param>
        /// <remarks>指定年度の月度開始日・終了日・年月度情報を取得します。</remarks>
        public void GetFinancialYearTable( DateTime year, out List<DateTime> startMonthDate, out List<DateTime> endMonthDate, out List<DateTime> yearMonth )
        {
            _finYearTableGenerator.GetFinancialYearTable( year, out startMonthDate, out endMonthDate, out yearMonth );
        }
        # endregion ■ 会計年度テーブル取得 ■

        # region ■ 会計年度期末取得 ■
        /// <summary>
        /// 会計年度期末取得
        /// </summary>
        /// <param name="startMonthDate">(出力)月度開始日</param>
        /// <param name="endMonthDate">(出力)月度終了日</param>
        /// <remarks>当年の会計年度期末月の開始日・終了日を取得します。</remarks>
        public void GetLastMonth( out DateTime startMonthDate, out DateTime endMonthDate )
        {
            _finYearTableGenerator.GetLastMonth( out startMonthDate, out endMonthDate );
        }
        /// <summary>
        /// 会計年度期末取得
        /// </summary>
        /// <param name="startMonthDate">(出力)月度開始日</param>
        /// <param name="endMonthDate">(出力)月度終了日</param>
        /// <param name="yearMonth">(出力)年月度</param>
        /// <remarks>当年の会計年度期末月の開始日・終了日・年月度を取得します。</remarks>
        public void GetLastMonth( out DateTime startMonthDate, out DateTime endMonthDate, out DateTime yearMonth )
        {
            _finYearTableGenerator.GetLastMonth( out startMonthDate, out endMonthDate, out yearMonth );
        }
        /// <summary>
        /// 会計年度期末取得
        /// </summary>
        /// <param name="addYearFromThis">当年からの年度差分</param>
        /// <param name="startMonthDate">(出力)月度開始日</param>
        /// <param name="endMonthDate">(出力)月度終了日</param>
        /// <param name="yearMonth">(出力)年月度</param>
        /// <remarks>当年から指定年数先の会計年度期末月の開始日・終了日・年月度を取得します。</remarks>
        public void GetLastMonth( int addYearFromThis, out DateTime startMonthDate, out DateTime endMonthDate, out DateTime yearMonth )
        {
            _finYearTableGenerator.GetLastMonth( addYearFromThis, out startMonthDate, out endMonthDate, out yearMonth );
        }
        /// <summary>
        /// 会計年度期末取得
        /// </summary>
        /// <param name="addYearFromThis">当年からの年度差分</param>
        /// <param name="startMonthDate">(出力)月度開始日</param>
        /// <param name="endMonthDate">(出力)月度終了日</param>
        /// <param name="yearMonth">(出力)年月度</param>
        /// <param name="year">(出力)年度</param>
        /// <remarks>当年から指定年数先の会計年度期末月の開始日・終了日・年月度および年度を取得します。</remarks>
        public void GetLastMonth( int addYearFromThis, out DateTime startMonthDate, out DateTime endMonthDate, out DateTime yearMonth, out int year )
        {
            _finYearTableGenerator.GetLastMonth( addYearFromThis, out startMonthDate, out endMonthDate, out yearMonth, out year );
        }
        # endregion ■ 会計年度期末取得 ■

        # region ■ 指定日付を含む年度・年月度の取得 ■
        /// <summary>
        /// 指定日付を含む年度・年月度の取得
        /// </summary>
        /// <param name="dateTime">指定日付</param>
        /// <param name="yearMonth">(出力)年月度</param>
        /// <remarks>指定日付を含む年月度を取得します。</remarks>
        public void GetYearMonth( DateTime dateTime, out DateTime yearMonth )
        {
            _finYearTableGenerator.GetYearMonth( dateTime, out yearMonth );
        }
        /// <summary>
        /// 指定日付を含む年度・年月度の取得
        /// </summary>
        /// <param name="dateTime">指定日付</param>
        /// <param name="yearMonth">(出力)年月度</param>
        /// <param name="year">(出力)年度</param>
        /// <remarks>指定日付を含む年月度・年度を取得します。</remarks>
        public void GetYearMonth( DateTime dateTime, out DateTime yearMonth, out int year )
        {
            _finYearTableGenerator.GetYearMonth( dateTime, out yearMonth, out year );
        }
        /// <summary>
        /// 指定日付を含む年度・年月度の取得
        /// </summary>
        /// <param name="dateTime">指定日付</param>
        /// <param name="yearMonth">(出力)年月度</param>
        /// <param name="year">(出力)年度</param>
        /// <param name="startMonthDate">(出力)年月度開始日</param>
        /// <param name="endMonthDate">(出力)年月度終了日</param>
        /// <remarks>指定日付を含む年月度・年度・年月度開始日・年月度終了日を取得します。</remarks>
        public void GetYearMonth( DateTime dateTime, out DateTime yearMonth, out int year, out DateTime startMonthDate, out DateTime endMonthDate )
        {
            _finYearTableGenerator.GetYearMonth( dateTime, out yearMonth, out year, out startMonthDate, out endMonthDate );
        }
        /// <summary>
        /// 指定日付を含む年度・年月度の取得
        /// </summary>
        /// <param name="dateTime">指定日付</param>
        /// <param name="yearMonth">(出力)年月度</param>
        /// <param name="year">(出力)年度</param>
        /// <param name="startMonthDate">(出力)年月度開始日</param>
        /// <param name="endMonthDate">(出力)年月度終了日</param>
        /// <param name="startYearDate">(出力)年度開始日</param>
        /// <param name="endYearDate">(出力)年度終了日</param>
        /// <remarks>指定日付を含む年月度・年度・月度開始日・月度終了日・年度開始日・年度終了日を取得します。</remarks>
        public void GetYearMonth( DateTime dateTime, out DateTime yearMonth, out int year, out DateTime startMonthDate, out DateTime endMonthDate, out DateTime startYearDate, out DateTime endYearDate )
        {
            _finYearTableGenerator.GetYearMonth( dateTime, out yearMonth, out year, out startMonthDate, out endMonthDate, out startYearDate, out endYearDate );
        }
        # endregion ■ 指定日付を含む年度・年月度の取得 ■

        # region ■ 現在処理年月の取得 ■
        /// <summary>
        /// 現在処理年月の取得
        /// </summary>
        /// <param name="yearMonth">(出力)年月度</param>
        /// <remarks>現在処理年月度を取得します。</remarks>
        public void GetThisYearMonth( out DateTime yearMonth )
        {
            _finYearTableGenerator.GetThisYearMonth( out yearMonth );
        }
        /// <summary>
        /// 現在処理年月の取得
        /// </summary>
        /// <param name="yearMonth">(出力)年月度</param>
        /// <param name="year">(出力)年度</param>
        /// <remarks>現在処理年月の年月度・年度を取得します。</remarks>
        public void GetThisYearMonth( out DateTime yearMonth, out int year )
        {
            _finYearTableGenerator.GetThisYearMonth( out yearMonth, out year );
        }
        /// <summary>
        /// 現在処理年月の取得
        /// </summary>
        /// <param name="yearMonth">(出力)年月度</param>
        /// <param name="year">(出力)年度</param>
        /// <param name="startMonthDate">(出力)年月度開始日</param>
        /// <param name="endMonthDate">(出力)年月度終了日</param>
        /// <remarks>現在処理年月の年月度・年度・月度開始日・月度終了日を取得します。</remarks>
        public void GetThisYearMonth( out DateTime yearMonth, out int year, out DateTime startMonthDate, out DateTime endMonthDate )
        {
            _finYearTableGenerator.GetThisYearMonth( out yearMonth, out year, out startMonthDate, out endMonthDate );
        }
        /// <summary>
        /// 現在処理年月の取得
        /// </summary>
        /// <param name="yearMonth">(出力)年月度</param>
        /// <param name="year">(出力)年度</param>
        /// <param name="startMonthDate">(出力)年月度開始日</param>
        /// <param name="endMonthDate">(出力)年月度終了日</param>
        /// <param name="startYearDate">(出力)年度開始日</param>
        /// <param name="endYearDate">(出力)年度終了日</param>
        /// <remarks>現在処理年月の年月度・年度・月度開始日・月度終了日・年度開始日・年度終了日を取得します。</remarks>
        public void GetThisYearMonth( out DateTime yearMonth, out int year, out DateTime startMonthDate, out DateTime endMonthDate, out DateTime startYearDate, out DateTime endYearDate )
        {
            _finYearTableGenerator.GetThisYearMonth( out yearMonth, out year, out startMonthDate, out endMonthDate, out startYearDate, out endYearDate );
        }
        # endregion ■ 現在処理年月の取得 ■


        # region ■ 集計期間取得 ■
        /// <summary>
        /// 集計期間取得
        /// </summary>
        /// <param name="procModeDiv">処理区分</param>
        /// <param name="ymdRange">基準を含めた範囲</param>
        /// <param name="startDate">(出力)開始　日付/月度/年度</param>
        /// <param name="endDate">(出力)終了　日付/月度/年度</param>
        /// <remarks>
        /// 処理区分と範囲に従い、開始日付・終了日付を取得します。<br/>
        /// ・procModeDiv = PastYears : 過去数年（開始年～終了年）<br/>
        /// ・procModeDiv = PastMonth : 過去数カ月（開始月～終了月）<br/>
        /// ・procModeDiv = PastDays  : 過去数日（開始日～終了日）<br/>
        /// ・procModeDiv = PastYears : 今後数年（開始年～終了年）<br/>
        /// ・procModeDiv = PastMonth : 今後数カ月（開始月～終了月）<br/>
        /// ・procModeDiv = PastDays  : 今後数日（開始日～終了日）<br/>
        /// </remarks>
        public void GetPeriod( ProcModeDivState procModeDiv, int ymdRange, out DateTime startDate, out DateTime endDate )
        {
            // 指定する基準日付(baseDate)
            DateTime baseDate;

            // 処理年月を取得
            DateTime yearMonth;
            int year;
            GetThisYearMonth( out yearMonth, out year );

            if ( procModeDiv == ProcModeDivState.PastYears || procModeDiv == ProcModeDivState.FutureYears )
            {
                // 当年度
                baseDate = new DateTime( year, 1, 1 );
            }
            else if ( procModeDiv == ProcModeDivState.PastMonths || procModeDiv == ProcModeDivState.FutureMonths )
            {
                // 当月度
                baseDate = yearMonth;
            }
            else
            {
                // 当日：システム日付
                baseDate = DateTime.Today;
            }

            // 集計期間取得
            GetPeriod( procModeDiv, baseDate, ymdRange, out startDate, out endDate );
        }
        /// <summary>
        /// 集計期間取得
        /// </summary>
        /// <param name="procModeDiv">処理区分</param>
        /// <param name="baseDate">基準　日付/月度/年度</param>
        /// <param name="ymdRange">基準を含めた範囲</param>
        /// <param name="startDate">(出力)開始　日付/月度/年度</param>
        /// <param name="endDate">(出力)終了　日付/月度/年度</param>
        /// <remarks>
        /// 処理区分と範囲に従い、開始日付・終了日付を取得します。<br/>
        /// ・procModeDiv = PastYears : 過去数年（開始年～終了年）<br/>
        /// ・procModeDiv = PastMonth : 過去数カ月（開始月～終了月）<br/>
        /// ・procModeDiv = PastDays  : 過去数日（開始日～終了日）<br/>
        /// ・procModeDiv = PastYears : 今後数年（開始年～終了年）<br/>
        /// ・procModeDiv = PastMonth : 今後数カ月（開始月～終了月）<br/>
        /// ・procModeDiv = PastDays  : 今後数日（開始日～終了日）<br/>
        /// </remarks>
        public void GetPeriod( ProcModeDivState procModeDiv, DateTime baseDate, int ymdRange, out DateTime startDate, out DateTime endDate )
        {
            // 初期化
            startDate = DateTime.MinValue;
            endDate = DateTime.MinValue;


            // 処理区分に従い処理する
            # region [処理区分毎の処理]
            switch ( procModeDiv )
            {
                // 過去数年
                case ProcModeDivState.PastYears:
                    {
                        // 終了年
                        endDate = new DateTime( baseDate.Year, 1, 1 );

                        // 開始年
                        startDate = endDate.AddYears( -1 * (ymdRange - 1) );
                    }
                    break;
                // 過去数月
                case ProcModeDivState.PastMonths:
                    {
                        // 終了月
                        endDate = new DateTime( baseDate.Year, baseDate.Month, 1 );

                        // 開始月
                        startDate = endDate.AddMonths( -1 * (ymdRange - 1) );
                    }
                    break;
                // 過去数日
                case ProcModeDivState.PastDays:
                    {
                        // 終了日
                        endDate = baseDate.Date;

                        // 開始日
                        startDate = endDate.AddDays( -1 * (ymdRange - 1) );
                    }
                    break;
                // 今後数年
                case ProcModeDivState.FutureYears:
                    {
                        // 開始年
                        startDate = new DateTime( baseDate.Year, 1, 1 );

                        // 終了年
                        endDate = startDate.AddYears( (ymdRange - 1) );
                    }
                    break;
                // 今後数月
                case ProcModeDivState.FutureMonths:
                    {
                        // 開始月
                        startDate = new DateTime( baseDate.Year, baseDate.Month, 1 );

                        // 終了月
                        endDate = startDate.AddMonths( (ymdRange - 1) );
                    }
                    break;
                // 今後数日
                case ProcModeDivState.FutureDays:
                    {
                        // 開始日
                        startDate = baseDate.Date;

                        // 終了日
                        endDate = startDate.AddDays( (ymdRange - 1) );
                    }
                    break;
            }
            # endregion
        }
        # endregion ■ 集計期間取得 ■


        # region ■ 年月度からの年度情報の取得 ■
        /// <summary>
        /// 年月度からの年度情報の取得
        /// </summary>
        /// <param name="yearMonth">年月度</param>
        /// <param name="year">(出力)年度</param>
        /// <param name="addYearsFromThis">(出力)当年からの年度差分</param>
        /// <remarks>
        /// 指定年月度を含む年度と、その年度の当年からの差分を取得します。<br/>
        /// </remarks>
        public void GetYearFromMonth( DateTime yearMonth, out int year, out int addYearsFromThis )
        {
            _finYearTableGenerator.GetYearFromMonth( yearMonth, out year, out addYearsFromThis );
        }
        /// <summary>
        /// 年月度からの年度情報の取得
        /// </summary>
        /// <param name="yearMonth">年月度</param>
        /// <param name="year">(出力)年度</param>
        /// <param name="addYearsFromThis">(出力)当年からの年度差分</param>
        /// <param name="startYearMonth">(出力)年度　開始年月度</param>
        /// <param name="endYearMonth">(出力)年度　終了年月度</param>
        /// <remarks>
        /// 指定年月度を含む年度・年度の当年からの差分・年度開始月度・年度終了月度を取得します。<br/>
        /// </remarks>
        public void GetYearFromMonth( DateTime yearMonth, out int year, out int addYearsFromThis, out DateTime startYearMonth, out DateTime endYearMonth )
        {
            _finYearTableGenerator.GetYearFromMonth( yearMonth, out year, out addYearsFromThis, out startYearMonth, out endYearMonth );
        }
        # endregion ■ 年月度からの年度情報の取得 ■

        # region ■ 年月度からの日付範囲の取得 ■
        /// <summary>
        /// 年月度からの日付範囲の取得
        /// </summary>
        /// <param name="yearMonth">年月度</param>
        /// <param name="startMonthDate">(出力)月度開始日</param>
        /// <param name="endMonthDate">(出力)月度終了日</param>
        /// <remarks>
        /// 指定年月度の月度開始日・月度終了日を取得します。<br/>
        /// </remarks>
        public void GetDaysFromMonth( DateTime yearMonth, out DateTime startMonthDate, out DateTime endMonthDate )
        {
            _finYearTableGenerator.GetDaysFromMonth( yearMonth, out startMonthDate, out endMonthDate );
        }
        # endregion ■ 年月度からの日付範囲の取得 ■

        # endregion

        # region [日付チェック処理]

        # region ■ 日付範囲入力チェック処理 ■
        /// <summary>
        /// 日付範囲入力チェック処理
        /// </summary>
        /// <param name="rangeType">範囲指定タイプ</param>
        /// <param name="ymdRange">範囲</param>
        /// <param name="inputType">入力タイプ</param>
        /// <param name="startDate">開始日</param>
        /// <param name="endDate">終了日</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// 開始日付・終了日付の大小チェック・指定範囲外チェックを行います。<br/>
        /// </remarks>
        public CheckPeriodResult CheckPeriod( YmdType rangeType, int ymdRange, YmdType inputType, DateTime startDate, DateTime endDate )
        {
            return (CheckPeriodResult)(int)_finYearTableGenerator.CheckPeriod( (FinYearTableGenerator.YmdTypeCmn)(int)rangeType, ymdRange, (FinYearTableGenerator.YmdTypeCmn)(int)inputType, startDate, endDate );
        }
        # endregion ■ 日付範囲入力チェック処理 ■
        # region ■ 日付範囲入力チェック処理（機能限定） ■
        /// <summary>
        /// 開始～終了日付が(自社締め関係なく)指定月数内に収まっているか判定
        /// </summary>
        /// <param name="months">月数</param>
        /// <param name="startDate">開始日付</param>
        /// <param name="endDate">終了日付</param>
        /// <returns>true:範囲内 / false:範囲外</returns>
        /// <remarks>
        /// 開始～終了日付が(自社締め関係なく)指定月数内に収まっているか判定します。<br/>
        /// </remarks>
        public bool CheckPeriodDaysOnMonths( int months, DateTime startDate, DateTime endDate )
        {
            return _finYearTableGenerator.CheckPeriodDaysOnMonths( months, startDate, endDate );
        }
        /// <summary>
        /// 開始～終了年月が(自社締め関係なく)指定月数内に収まっているか判定
        /// </summary>
        /// <param name="months">月数</param>
        /// <param name="startMonth">開始年月</param>
        /// <param name="endMonth">終了年月</param>
        /// <returns>true:範囲内 / false:範囲外</returns>
        /// <remarks>
        /// 開始～終了月が(自社締め関係なく)指定月数内に収まっているか判定します。<br/>
        /// </remarks>
        public bool CheckPeriodMonthsOnMonths( int months, DateTime startMonth, DateTime endMonth )
        {
            return _finYearTableGenerator.CheckPeriodMonthsOnMonths( months, startMonth, endMonth );
        }
        /// <summary>
        /// 開始～終了年度が(自社締め関係なく)指定年数内に収まっているか判定
        /// </summary>
        /// <param name="years">月数</param>
        /// <param name="startYear">開始年度</param>
        /// <param name="endYear">終了年度</param>
        /// <returns>true:範囲内 / false:範囲外</returns>
        /// <remarks>
        /// 開始～終了年が(自社締め関係なく)指定月数内に収まっているか判定します。<br/>
        /// </remarks>
        public bool CheckPeriodYearsOnYears( int years, DateTime startYear, DateTime endYear )
        {
            return _finYearTableGenerator.CheckPeriodYearsOnYears( years, startYear, endYear );
        }
        # endregion ■ 日付範囲入力チェック処理（機能限定） ■


        # region ■ 日付項目入力チェック処理 ■
        /// <summary>
        /// 日付項目入力チェック処理
        /// </summary>
        /// <param name="targetDateEdit">対象日付Edit</param>
        /// <returns>チェック結果</returns>
        /// <remarks>日付の未入力・無効チェックを行います。</remarks>
        public CheckDateResult CheckDate( ref TDateEdit targetDateEdit )
        {
            return CheckDate( ref targetDateEdit, false );
        }
        /// <summary>
        /// 日付項目入力チェック処理
        /// </summary>
        /// <param name="targetDateEdit">対象日付Edit</param>
        /// <param name="allowNoInput">未入力許可フラグ</param>
        /// <returns>チェック結果</returns>
        /// <remarks>日付の未入力・無効チェックを行います。</remarks>
        public CheckDateResult CheckDate( ref TDateEdit targetDateEdit, bool allowNoInput )
        {
            //---------------------------------------------------
            // 未入力チェック
            //---------------------------------------------------
            if ( !allowNoInput )
            {
                if ( DateEditNoInputCheck( targetDateEdit ) )
                {
                    return CheckDateResult.ErrorOfNoInput;
                }
            }

            //---------------------------------------------------
            // 無効チェック前の補正処理
            //---------------------------------------------------
            if ( _yearOnlyList.Contains( targetDateEdit.DateFormat ) )
            {
                // 年だけ (yyyy/01/01)
                targetDateEdit.SetLongDate( (targetDateEdit.GetLongDate() / 10000) * 10000 + 101 );
            }
            else if ( _monthOnlyList.Contains( targetDateEdit.DateFormat ) )
            {
                // 年月だけ (yyyy/mm/01)
                targetDateEdit.SetLongDate( (targetDateEdit.GetLongDate() / 100) * 100 + 1 );
            }

            //---------------------------------------------------
            // 無効チェック処理
            //---------------------------------------------------
            if ( targetDateEdit.CheckInputData() != null ) return CheckDateResult.ErrorOfInvalid;
            if ( !DateEditInputCheck( targetDateEdit, allowNoInput ) ) return CheckDateResult.ErrorOfInvalid;

            //---------------------------------------------------
            // エラーなし
            //---------------------------------------------------
            return CheckDateResult.OK;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
        /// <summary>
        /// 日付チェック処理（年式用）※売上伝票入力・検索見積発行で使用
        /// </summary>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        public CheckDateResult CheckDateForFirstEntryDate( ref TDateEdit targetDateEdit )
        {
            // 年式用なので、デフォルトは未入力可
            return CheckDateForFirstEntryDate( ref targetDateEdit, true );
        }
        /// <summary>
        /// 日付チェック処理（年式用）※売上伝票入力・検索見積発行で使用
        /// </summary>
        /// <param name="targetDateEdit"></param>
        /// <param name="allowNoInput"></param>
        /// <returns></returns>
        public CheckDateResult CheckDateForFirstEntryDate( ref TDateEdit targetDateEdit, bool allowNoInput )
        {
            int yy = targetDateEdit.GetDateYear();
            int mm = targetDateEdit.GetDateMonth();

            if ( yy!= 0)
            {
                if ( mm != 0)
                {
                    // 年あり・月あり

                    // システムサポートチェック
                    if ( yy < 1900 )
                    {
                        return CheckDateResult.ErrorOfInvalid;
                    }
                    // 月範囲チェック
                    if ( mm < 1 || 12 < mm )
                    {
                        return CheckDateResult.ErrorOfInvalid;
                    }

                    targetDateEdit.LongDate = (yy * 10000) + (mm * 100) + 0;
                    return CheckDateResult.OK;
                }
                else
                {
                    // 年あり・月なし

                    // システムサポートチェック
                    if ( yy < 1900 )
                    {
                        return CheckDateResult.ErrorOfInvalid;
                    }

                    targetDateEdit.LongDate = (yy * 10000) + 0 + 0;
                    return CheckDateResult.OK;
                }
            }
            else
            {
                if ( mm != 0 )
                {
                    // 年なし・月あり
                    return CheckDateResult.ErrorOfInvalid; // エラー
                }
                else
                {
                    // 年なし・月なし
                    if ( allowNoInput )
                    {
                        return CheckDateResult.OK; // 未入力OK
                    }
                    else
                    {
                        return CheckDateResult.ErrorOfNoInput; // 未入力NG
                    }
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD
        # endregion ■ 日付項目入力チェック処理 ■


        # region ■ 自社締め同一年度チェック処理 ■
        /// <summary>
        /// 自社締め同一年度チェック処理
        /// </summary>
        /// <param name="startYearMonth">開始月</param>
        /// <param name="endYearMonth">終了月</param>
        /// <returns>true:同一年度内 / false:同一年度内にない</returns>
        /// <remarks>
        /// 年月度を２つ指定して、同一年度内かチェックします。<br/>
        /// </remarks>
        public bool CheckMonthsOnYear( DateTime startYearMonth, DateTime endYearMonth )
        {
            return _finYearTableGenerator.CheckMonthsOnYear( startYearMonth, endYearMonth );
        }
        /// <summary>
        /// 自社締め同一年度チェック処理
        /// </summary>
        /// <param name="startDate">開始日</param>
        /// <param name="endDate">終了日</param>
        /// <returns>true:同一年度内 / false:同一年度内にない</returns>
        /// <remarks>
        /// 年月日を２つ指定して、同一年度内かチェックします。<br/>
        /// </remarks>
        public bool CheckDaysOnYear( DateTime startDate, DateTime endDate )
        {
            return _finYearTableGenerator.CheckDaysOnYear( startDate, endDate );
        }
        # endregion ■ 自社締め同一年度チェック処理 ■

        # region ■ 自社締め同一年月度チェック処理 ■
        /// <summary>
        /// 自社締め同一年月度チェック処理
        /// </summary>
        /// <param name="startMonthDate">開始日</param>
        /// <param name="endMonthDate">終了日</param>
        /// <returns>true:同一月度内 / false:同一月度内にない</returns>
        /// <remarks>
        /// 年月日を２つ指定して、同一年月度かチェックします。<br/>
        /// </remarks>
        public bool CheckDaysOnMonth( DateTime startMonthDate, DateTime endMonthDate )
        {
            return _finYearTableGenerator.CheckDaysOnMonth( startMonthDate, endMonthDate );
        }
        # endregion ■ 自社締め同一年月度チェック処理 ■


        # region ■ 日付範囲汎用チェック処理 ■
        /// <summary>
        /// 日付範囲汎用チェック処理
        /// </summary>
        /// <param name="rangeType">範囲指定タイプ</param>
        /// <param name="ymdRange">範囲指定</param>
        /// <param name="startDateEdit">開始日付Edit</param>
        /// <param name="endDateEdit">終了日付Edit</param>
        /// <param name="allowNoInput">未入力許可 (true:許可する/false:許可しない)</param>
        /// <returns>日付範囲チェック結果</returns>
        /// <remarks>
        /// 開始日付チェック、終了日付チェック、日付範囲チェック、自社締め同一年度チェックを行います。<br/>
        /// <br></br>
        /// <br>以下のpublicメソッドを使用します。</br>
        /// <br>　・日付チェック　　　　　　　：CheckDate</br>
        /// <br>　・自社締め同一年度チェック　：CheckMonthsOnYear / CheckDaysOnYear</br>
        /// <br>  ・自社締め同一年月度チェック：CheckDaysOnMonth</br>
        /// <br>　・日付範囲チェック　　　　　：CheckPeriod</br>
        /// </remarks>
        public CheckDateRangeResult CheckDateRange( YmdType rangeType, int ymdRange, ref TDateEdit startDateEdit, ref TDateEdit endDateEdit, bool allowNoInput )
        {
            return CheckDateRange( rangeType, ymdRange, ref startDateEdit, ref endDateEdit, allowNoInput, false, false );
        }
        /// <summary>
        /// 日付範囲汎用チェック処理
        /// </summary>
        /// <param name="rangeType">範囲指定タイプ</param>
        /// <param name="ymdRange">範囲指定</param>
        /// <param name="startDateEdit">開始日付Edit</param>
        /// <param name="endDateEdit">終了日付Edit</param>
        /// <param name="allowNoInput">未入力許可 (true:許可する/false:許可しない)</param>
        /// <param name="checkOnYear">自社締め同一年度チェック（true:する/false:しない）</param>
        /// <returns>日付範囲チェック結果</returns>
        /// <remarks>
        /// 開始日付チェック、終了日付チェック、日付範囲チェック、自社締め同一年度チェックを行います。<br/>
        /// <br></br>
        /// <br>以下のpublicメソッドを使用します。</br>
        /// <br>　・日付チェック　　　　　　　：CheckDate</br>
        /// <br>　・自社締め同一年度チェック　：CheckMonthsOnYear / CheckDaysOnYear</br>
        /// <br>  ・自社締め同一年月度チェック：CheckDaysOnMonth</br>
        /// <br>　・日付範囲チェック　　　　　：CheckPeriod</br>
        /// </remarks>
        public CheckDateRangeResult CheckDateRange( YmdType rangeType, int ymdRange, ref TDateEdit startDateEdit, ref TDateEdit endDateEdit, bool allowNoInput, bool checkOnYear )
        {
            return CheckDateRange( rangeType, ymdRange, ref startDateEdit, ref endDateEdit, allowNoInput, checkOnYear, false );
        }
        /// <summary>
        /// 日付範囲汎用チェック処理
        /// </summary>
        /// <param name="rangeType">範囲指定タイプ</param>
        /// <param name="ymdRange">範囲指定</param>
        /// <param name="startDateEdit">開始日付Edit</param>
        /// <param name="endDateEdit">終了日付Edit</param>
        /// <param name="allowNoInput">未入力許可 (true:許可する/false:許可しない)</param>
        /// <param name="checkOnYear">自社締め同一年度チェック（true:する/false:しない）</param>
        /// <param name="checkOnMonth">自社締め同一年月度チェック (true:する/false:しない)</param>
        /// <returns>日付範囲チェック結果</returns>
        /// <remarks>
        /// 開始日付チェック、終了日付チェック、日付範囲チェック、自社締め同一年度チェックを行います。<br/>
        /// <br>（※ＵＩ仕様で日付範囲に制限がある場合に使用して下さい。制限が無い場合は他のpublicメソッドを個別に使用して下さい。）</br>
        /// <br></br>
        /// <br>以下のpublicメソッドを使用します。</br>
        /// <br>　・日付チェック　　　　　　　：CheckDate</br>
        /// <br>　・自社締め同一年度チェック　：CheckMonthsOnYear / CheckDaysOnYear</br>
        /// <br>  ・自社締め同一年月度チェック：CheckDaysOnMonth</br>
        /// <br>　・日付範囲チェック　　　　　：CheckPeriod</br>
        /// </remarks>
        public CheckDateRangeResult CheckDateRange( YmdType rangeType, int ymdRange, ref TDateEdit startDateEdit, ref TDateEdit endDateEdit, bool allowNoInput, bool checkOnYear, bool checkOnMonth )
        {
            //--------------------------------------------------------------
            // エラーの優先順は以下の通りです。
            //--------------------------------------------------------------
            // 
            // ①　( 開始未入力 )
            // ②　開始不正
            // ③　( 終了未入力 )
            // ④　終了不正
            // ⑤　( 終了あり・開始のみ未入力 )
            // ⑥　( 開始あり・終了のみ未入力 )
            // ⑦　逆転エラー
            // ⑧　( 同一年月度チェックエラー )
            // ⑨　( 同一年度チェックエラー )
            // ⑩　範囲外エラー
            // 
            //--------------------------------------------------------------

            # region [inputType判定]
            // 入力形式は、開始日付Editのタイプを元に決定
            YmdType inputType;
            if ( _yearOnlyList.Contains( startDateEdit.DateFormat ) )
            {
                inputType = YmdType.Year;
            }
            else if ( _monthOnlyList.Contains( startDateEdit.DateFormat ) )
            {
                inputType = YmdType.YearMonth;
            }
            else
            {
                inputType = YmdType.YearMonthDay;
            }
            # endregion

            //-------------------------------------
            // 入力チェック処理
            //-------------------------------------
            # region [開始日・終了日の入力チェック]
            CheckDateResult cdResult;

            // 開始
            bool stNoInput = false;
            cdResult = CheckDate( ref startDateEdit, false );
            switch ( cdResult )
            {
                case CheckDateResult.ErrorOfNoInput:
                    if ( allowNoInput )
                    {
                        stNoInput = true;
                    }
                    else
                    {
                        return CheckDateRangeResult.ErrorOfStartNoInput;
                    }
                    break;
                case CheckDateResult.ErrorOfInvalid:
                    return CheckDateRangeResult.ErrorOfStartInvalid;
            }

            // 終了
            bool edNoInput = false;
            cdResult = CheckDate( ref endDateEdit, false );
            switch ( cdResult )
            {
                case CheckDateResult.ErrorOfNoInput:
                    if ( allowNoInput )
                    {
                        edNoInput = true;
                    }
                    else
                    {
                        return CheckDateRangeResult.ErrorOfEndNoInput;
                    }
                    break;
                case CheckDateResult.ErrorOfInvalid:
                    return CheckDateRangeResult.ErrorOfEndInvalid;
            }

            // 片方だけ未入力のチェック 
            // → 片方が入力済みならばもう片方の未入力を許可しない (allowNoInputによらない)
            if ( stNoInput == true && edNoInput == false )
            {
                // 開始のみ未入力
                return CheckDateRangeResult.ErrorOfStartNoInput;
            }
            else if ( stNoInput == false && edNoInput == true )
            {
                // 終了のみ未入力
                return CheckDateRangeResult.ErrorOfEndNoInput;
            }
            else if ( stNoInput == true && edNoInput == true )
            {
                // どちらも未入力ならばここで正常終了
                return CheckDateRangeResult.OK;
            }

            # endregion [開始日・終了日の入力チェック]

            //-------------------------------------
            // 範囲内チェック
            //-------------------------------------
            # region [範囲内チェック]
            bool rangeOver = false;
            CheckPeriodResult cpResult = CheckPeriod( rangeType, ymdRange, inputType, startDateEdit.GetDateTime(), endDateEdit.GetDateTime() );

            switch ( cpResult )
            {
                case CheckPeriodResult.ErrorOfReverse:
                    {
                        return CheckDateRangeResult.ErrorOfReverse; // 逆転エラーを返す
                    }
                case CheckPeriodResult.ErrorOfRangeOver:
                    {
                        // 範囲がゼロ以下ならば、無制限とみなす
                        if ( ymdRange > 0 )
                        {
                            rangeOver = true;   // 範囲エラーは即返さず、同一年月度・同一年度チェックOKの場合に返す
                        }
                    }
                    break;
            }
            # endregion

            //-------------------------------------
            // 同一年月度チェック
            //-------------------------------------
            # region [同一年月度チェック]
            if ( checkOnMonth )
            {
                bool onMonth = true;

                switch ( inputType )
                {
                    case YmdType.Year:
                        {
                            // チェックしない
                        }
                        break;
                    case YmdType.YearMonth:
                        {
                            onMonth = (startDateEdit.GetDateTime().Year == endDateEdit.GetDateTime().Year) &&
                                      (startDateEdit.GetDateTime().Month == endDateEdit.GetDateTime().Month);
                        }
                        break;
                    case YmdType.YearMonthDay:
                        {
                            onMonth = CheckDaysOnMonth( startDateEdit.GetDateTime(), endDateEdit.GetDateTime() );
                        }
                        break;
                }
                if ( !onMonth )
                {
                    return CheckDateRangeResult.ErrorOfNotOnMonth;
                }
            }
            # endregion

            //-------------------------------------
            // 同一年度チェック
            //-------------------------------------
            # region [同一年度チェック]
            if ( checkOnYear )
            {
                bool onYear = true;
                switch ( inputType )
                {
                    case YmdType.Year:
                        {
                            // 年のみ
                            onYear = (startDateEdit.GetDateTime().Year == endDateEdit.GetDateTime().Year);
                        }
                        break;
                    case YmdType.YearMonth:
                        {
                            // 年月度
                            onYear = CheckMonthsOnYear( startDateEdit.GetDateTime(), endDateEdit.GetDateTime() );
                        }
                        break;
                    case YmdType.YearMonthDay:
                        {
                            // 年月日
                            onYear = CheckDaysOnYear( startDateEdit.GetDateTime(), endDateEdit.GetDateTime() );
                        }
                        break;
                }
                if ( !onYear )
                {
                    return CheckDateRangeResult.ErrorOfNotOnYear;
                }
            }
            # endregion


            # region [範囲外エラー返却]
            // 範囲チェックエラーならばこのタイミングで返す
            if ( rangeOver )
            {
                return CheckDateRangeResult.ErrorOfRangeOver;
            }
            # endregion [範囲外エラー返却]

            // 結果ＯＫ
            return CheckDateRangeResult.OK;
        }
        # endregion ■ 日付範囲汎用チェック処理 ■

        # endregion

        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region Private Methods

        # region [共通処理]
        /// <summary>
        /// 日付取得（DateTime ← int）
        /// </summary>
        /// <param name="longDate"></param>
        /// <returns></returns>
        private static DateTime DateTimeFromLongDate( int longDate )
        {
            return new DateTime( (longDate / 10000), ((longDate / 100) % 100), (longDate % 100) );
        }
        /// <summary>
        /// 当月締日取得
        /// </summary>
        /// <param name="currentDate"></param>
        /// <param name="totalDay"></param>
        /// <returns></returns>
        private static DateTime GetEndDate( DateTime currentDate, int totalDay)
        {
            // 日 > 締日
            if ( currentDate.Day > totalDay )
            {
                // 次の月に進める
                currentDate = currentDate.AddMonths( 1 );
            }

            // その月の末日で丸める
            int maxDay = DateTime.DaysInMonth( currentDate.Year, currentDate.Month );
            if ( totalDay > maxDay )
            {
                totalDay = maxDay;
            }

            // 締日をセットして返す
            return (new DateTime( currentDate.Year, currentDate.Month, totalDay ));
        }
        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="targetDateEdit">チェック対象コントロール</param>
        /// <param name="allowNoInput">未入力許可</param>
        /// <returns>チェック結果(true/false)</returns>
        /// <remarks>
        /// </remarks>
        private bool DateEditInputCheck( TDateEdit targetDateEdit, bool allowNoInput )
        {
            bool status = true;

            // 入力日付を数値型で取得
            int date = targetDateEdit.GetLongDate();
            int yy = date / 10000;
            int mm = (date / 100) % 100;
            int dd = date % 100;

            // このタイミングで未入力ならばチェックしない
            if ( DateEditNoInputCheck(targetDateEdit) )
            {
                if ( allowNoInput )
                {
                    // 許可している未入力なのでOK
                    status = true;
                }
                else
                {
                    // 許可していない未入力なのでNG
                    status = false;
                }
            }
            else
            // システムサポートチェック
            if ( yy < 1900 )
            {
                status = false;
            }
            // 年月日別入力チェック
            else if ( (yy == 0) || (mm == 0) || (dd == 0) )
            {
                status = false;
            }
            // 単純日付妥当性チェック
            else if ( TDateTime.IsAvailableDate( targetDateEdit.GetDateTime() ) == false )
            {
                status = false;
            }

            return status;
        }
        /// <summary>
        /// 日付Edit 未入力チェック
        /// </summary>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        private bool DateEditNoInputCheck( TDateEdit targetDateEdit )
        {
            int date = targetDateEdit.GetLongDate();
            int yy = date / 10000;
            int mm = (date / 100) % 100;
            int dd = date % 100;

            if ( _yearOnlyList.Contains( targetDateEdit.DateFormat ) )
            {
                // 年のみ
                if ( yy == 0 ) return true;
            }
            else if ( _monthOnlyList.Contains( targetDateEdit.DateFormat ) )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 DEL
                ////if ( yy == 0 && mm == 0 ) return true;
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 DEL
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                //if ( yy == 0 || mm == 0 ) return true;
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
                if ( yy == 0 && mm == 0 ) return true;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            }
            else
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 DEL
                ////if ( yy == 0 && mm == 0 && dd == 0 ) return true;
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 DEL
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                //if ( yy == 0 || mm == 0 || dd == 0 ) return true;
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
                if ( yy == 0 && mm == 0 && dd == 0 ) return true;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            }

            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyInf"></param>
        /// <returns></returns>
        private CompanyInfWork CopyToWorkFromCompanyInf( CompanyInf companyInf )
        {
            CompanyInfWork work = new CompanyInfWork();

            work.CreateDateTime = companyInf.CreateDateTime; // 作成日時
            work.UpdateDateTime = companyInf.UpdateDateTime; // 更新日時
            work.EnterpriseCode = companyInf.EnterpriseCode; // 企業コード
            work.FileHeaderGuid = companyInf.FileHeaderGuid; // GUID
            work.UpdEmployeeCode = companyInf.UpdEmployeeCode; // 更新従業員コード
            work.UpdAssemblyId1 = companyInf.UpdAssemblyId1; // 更新アセンブリID1
            work.UpdAssemblyId2 = companyInf.UpdAssemblyId2; // 更新アセンブリID2
            work.LogicalDeleteCode = companyInf.LogicalDeleteCode; // 論理削除区分
            work.CompanyCode = companyInf.CompanyCode; // 自社コード
            work.CompanyTotalDay = companyInf.CompanyTotalDay; // 自社締日
            work.FinancialYear = companyInf.FinancialYear; // 会計年度
            work.CompanyBiginMonth = companyInf.CompanyBiginMonth; // 期首月
            work.CompanyBiginMonth2 = companyInf.CompanyBiginMonth2; // 期首月2
            work.CompanyBiginDate = companyInf.CompanyBiginDate; // 期首年月日
            work.StartYearDiv = companyInf.StartYearDiv; // 開始年区分
            work.StartMonthDiv = companyInf.StartMonthDiv; // 開始月区分
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/25 DEL
            //work.CompanyName1 = companyInf.CompanyName1; // 自社名称1
            //work.CompanyName2 = companyInf.CompanyName2; // 自社名称2
            //work.PostNo = companyInf.PostNo; // 郵便番号
            //work.Address1 = companyInf.Address1; // 住所1（都道府県市区郡・町村・字）
            //work.Address2 = companyInf.Address2; // 住所2（丁目）
            //work.Address3 = companyInf.Address3; // 住所3（番地）
            //work.Address4 = companyInf.Address4; // 住所4（アパート名称）
            //work.CompanyTelNo1 = companyInf.CompanyTelNo1; // 自社電話番号1
            //work.CompanyTelNo2 = companyInf.CompanyTelNo2; // 自社電話番号2
            //work.CompanyTelNo3 = companyInf.CompanyTelNo3; // 自社電話番号3
            //work.CompanyTelTitle1 = companyInf.CompanyTelTitle1; // 自社電話番号タイトル1
            //work.CompanyTelTitle2 = companyInf.CompanyTelTitle2; // 自社電話番号タイトル2
            //work.CompanyTelTitle3 = companyInf.CompanyTelTitle3; // 自社電話番号タイトル3
            //work.SecMngDiv = companyInf.SecMngDiv; // 部署管理区分
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/25 DEL

            return work;
        }
        # endregion
        
        #endregion

        // ===================================================================================== //
        // その他
        // ===================================================================================== //

        # region ■ 処理区分列挙型 ■
        /// <summary>
        /// 処理区分　列挙型
        /// </summary>
        /// <remarks>
        /// 集計期間取得(GetPeriod)の処理区分を表します。<br/>
        /// </remarks>
        public enum ProcModeDivState
        {
            /// <summary>過去　年度</summary>
            PastYears = 0,
            /// <summary>過去　月度</summary>
            PastMonths = 1,
            /// <summary>過去　日付</summary>
            PastDays = 2,
            /// <summary>今後　年度</summary>
            FutureYears = 3,
            /// <summary>今後　月度</summary>
            FutureMonths = 4,
            /// <summary>今後　日付</summary>
            FutureDays = 5,
        }
        # endregion ■ 処理区分列挙型 ■

        # region ■ 年月日指定タイプ列挙型 ■
        /// <summary>
        /// 年月日指定タイプ　列挙型
        /// </summary>
        /// <remarks>年・月・日の区分を表します。</remarks>
        public enum YmdType
        {
            /// <summary>年</summary>
            Year = 0,
            /// <summary>年月</summary>
            YearMonth = 1,
            /// <summary>年月日</summary>
            YearMonthDay = 2,
        }
        # endregion ■ 年月日指定タイプ列挙型 ■

        # region ■ 日付範囲チェック返却値列挙型 ■
        /// <summary>
        /// 日付範囲チェック返却値　列挙型
        /// </summary>
        /// <remarks>CheckPeriodのチェック結果を表します。</remarks>
        public enum CheckPeriodResult
        {
            /// <summary>ＯＫ（エラーなし）</summary>
            OK = 0,
            /// <summary>逆転エラー（開始＞終了になっている）</summary>
            ErrorOfReverse = 1,
            /// <summary>範囲エラー（開始～終了が指定範囲を超えている）</summary>
            ErrorOfRangeOver = 2,
        }
        # endregion ■ 日付範囲チェック返却値列挙型 ■

        # region ■ 日付入力チェック返却値列挙型 ■
        /// <summary>
        /// 日付入力チェック返却値　列挙型
        /// </summary>
        /// <remarks>CheckDateのチェック結果を表します。</remarks>
        public enum CheckDateResult
        {
            /// <summary>ＯＫ（エラーなし）</summary>
            OK = 0,
            /// <summary>未入力エラー（yyyy,mm,dd全て未入力）</summary>
            ErrorOfNoInput = 1,
            /// <summary>無効日付エラー（2008/99/99のような無効な日付）</summary>
            ErrorOfInvalid = 2,
        }
        # endregion ■ 日付入力チェック返却値列挙型 ■

        # region ■ 日付範囲フルチェック返却値列挙型 ■
        /// <summary>
        /// 日付範囲フルチェック返却値　列挙型
        /// </summary>
        /// <remarks>CheckDateRangeのチェック結果を表します。</remarks>
        public enum CheckDateRangeResult
        {
            /// <summary>ＯＫ（エラーなし）</summary>
            OK = 0,
            /// <summary>逆転エラー（開始＞終了になっている）</summary>
            ErrorOfReverse = 1,
            /// <summary>範囲エラー（開始～終了が指定範囲を超えている）</summary>
            ErrorOfRangeOver = 2,
            /// <summary>開始未入力エラー（開始日付が未入力）</summary>
            ErrorOfStartNoInput = 3,
            /// <summary>開始無効エラー（開始日付が無効）</summary>
            ErrorOfStartInvalid = 4,
            /// <summary>終了未入力エラー（終了日付が未入力）</summary>
            ErrorOfEndNoInput = 5,
            /// <summary>終了無効エラー（終了日付が無効）</summary>
            ErrorOfEndInvalid = 6,
            /// <summary>年度またぎエラー（開始～終了が同一年度内でない）</summary>
            ErrorOfNotOnYear = 7,
            /// <summary>年月度またぎエラー（開始～終了が同一年月度内でない）</summary>
            ErrorOfNotOnMonth = 8,
        }
        # endregion ■ 日付範囲フルチェック返却値列挙型 ■
    }

}
