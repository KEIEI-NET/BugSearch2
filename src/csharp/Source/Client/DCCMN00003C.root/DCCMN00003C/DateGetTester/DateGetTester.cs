using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 日付取得部品の結果を確認する為のテストフォームです。
    /// </summary>
    public partial class DateGetTester : Form
    {
        // 日付取得部品
        private DateGetAcs _dateGet;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DateGetTester()
        {
            InitializeComponent();
            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();
        }
        /// <summary>
        /// フォームロードイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateGetTester_Load( object sender, EventArgs e )
        {
            CompanyInf companyInf = _dateGet.GetCompanyInf();
            DisplayFromCompanyInf( companyInf );

            // 現在処理中年月取得
            DateTime thisYearMonth;
            int thisYear;
            this._dateGet.GetThisYearMonth( out thisYearMonth, out thisYear );

            // ①会計年度テーブル
            GetFinancialYearTable();

            // ③現在処理年月
            this.tde_t3_sys.SetDateTime( DateTime.Today );

            // ④集計期間
            this.tde_t4_base.SetDateTime( new DateTime( companyInf.FinancialYear, 1, 1 ) );

            // ⑤指定日を含む年月度
            this.tde_t5_dt.SetDateTime( DateTime.Today );

            // ⑥指定月度を含む年月度・指定月度の範囲日付
            this.tde_t6_ym.SetDateTime( thisYearMonth );

            // ⑦日付チェック
            this.tde_t7_a_st.SetDateTime( DateTime.Today );
            this.tde_t7_a_ed.SetDateTime( DateTime.Today );
        }

        # region ■ ①会計年度テーブル取得 ■
        /// <summary>
        /// ボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click( object sender, EventArgs e )
        {
            GetFinancialYearTable();
        }
        /// <summary>
        /// 会計年度テーブル取得処理
        /// </summary>
        private void GetFinancialYearTable()
        {
            int addYearsFromThis = tNedit3.GetInt();
                
            List<DateTime> startDate;
            List<DateTime> endDate;
            List<DateTime> yearMonth;
            int year;
            _dateGet.GetFinancialYearTable( addYearsFromThis, out startDate, out endDate, out yearMonth, out year );

            SetTable( startDate, endDate, yearMonth, year );
        }

        /// <summary>
        /// 自社設定クラスの画面表示処理
        /// </summary>
        /// <param name="companyInf"></param>
        private void DisplayFromCompanyInf( CompanyInf companyInf )
        {
            // 自社締日
            tNedit2.SetInt( companyInf.CompanyTotalDay );

            // 会計年度
            tNedit1.SetInt( companyInf.FinancialYear );

            // 期首年月日
            this.tDateEdit1.SetLongDate( companyInf.CompanyBiginDate );


            // 開始年区分
            if ( companyInf.StartYearDiv == 0 )
            {
                tEdit1.Text = "0:前年";
            }
            else
            {
                tEdit1.Text = "1:翌年";
            }

            // 開始月区分
            if ( companyInf.StartMonthDiv == 0 )
            {
                tEdit2.Text = "0:前月";
            }
            else
            {
                tEdit2.Text = "1:翌月";
            }

        }

        /// <summary>
        /// 会計年度テーブル表示処理
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="yearMonth"></param>
        private void SetTable( List<DateTime> startDate, List<DateTime> endDate, List<DateTime> yearMonth, int year )
        {
            List<TDateEdit> stDtList = new List<TDateEdit>();
            List<TDateEdit> edDtList = new List<TDateEdit>();
            List<UltraLabel> ymList = new List<UltraLabel>();
            stDtList.AddRange( new TDateEdit[] { tde_st_1, tde_st_2, tde_st_3, tde_st_4, tde_st_5, tde_st_6, tde_st_7, tde_st_8, tde_st_9, tde_st_10, tde_st_11, tde_st_12 } );
            edDtList.AddRange( new TDateEdit[] { tde_ed_1, tde_ed_2, tde_ed_3, tde_ed_4, tde_ed_5, tde_ed_6, tde_ed_7, tde_ed_8, tde_ed_9, tde_ed_10, tde_ed_11, tde_ed_12 } );
            ymList.AddRange( new UltraLabel[] { lb_1, lb_2, lb_3, lb_4, lb_5, lb_6, lb_7, lb_8, lb_9, lb_10, lb_11, lb_12 } );

            // 年度
            lb_Year.Text = year.ToString();

            for ( int index = 0; index < 12; index++ )
            {
                // 年月度
                ymList[index].Text = string.Format( "{0}.{1}", yearMonth[index].Year, yearMonth[index].Month.ToString( "00" ) );

                // 開始日
                stDtList[index].SetDateTime( startDate[index] );
                // 終了日
                edDtList[index].SetDateTime( endDate[index] );
            }
        }

        /// <summary>
        /// 自社設定マスタ再取得処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click( object sender, EventArgs e )
        {
            // 再読み込み
            this._dateGet.ReloadCompanyInf();

            // 表示更新
            CompanyInf companyInf = _dateGet.GetCompanyInf();
            DisplayFromCompanyInf( companyInf );
            GetFinancialYearTable();
        }
        # endregion ■ ①会計年度テーブル取得 ■

        # region ■ ②会計年度期末取得 ■
        /// <summary>
        /// 会計年度期末取得処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click( object sender, EventArgs e )
        {
            // 画面入力から年数差分を取得
            int addYearsFromThis = tNedit4.GetInt();

            // 会計年度期末の取得
            DateTime startDate;
            DateTime endDate;
            DateTime yearMonth;
            int year;
            this._dateGet.GetLastMonth( addYearsFromThis, out startDate, out endDate, out yearMonth, out year );

            // 画面に表示
            this.lb_t2_Year.Text = year.ToString();
            this.lb_t2_YearMonth.Text = string.Format( "{0}.{1}", yearMonth.Year.ToString(), yearMonth.Month.ToString( "00" ) );
            this.tde_t2_st.SetDateTime( startDate );
            this.tde_t2_ed.SetDateTime( endDate );
        }
        # endregion ■ ②会計年度期末取得 ■

        # region ■ ③現在処理年月取得 ■
        /// <summary>
        /// 現在処理年月取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click( object sender, EventArgs e )
        {
            // 現在処理年月取得
            DateTime thisYearMonth;
            int thisYear;
            DateTime startMonthDate;
            DateTime endMonthDate;
            DateTime startYearDate;
            DateTime endYearDate;

            this._dateGet.GetThisYearMonth( out thisYearMonth, out thisYear, out startMonthDate, out endMonthDate, out startYearDate, out endYearDate );

            // 画面に表示
            this.lb_t3_Year.Text = thisYear.ToString();
            this.tde_t3_yst.SetDateTime( startYearDate );
            this.tde_t3_yed.SetDateTime( endYearDate );
            this.lb_t3_YearMonth.Text = string.Format( "{0}.{1}", thisYearMonth.Year.ToString(), thisYearMonth.Month.ToString( "00" ) );
            this.tde_t3_mst.SetDateTime( startMonthDate );
            this.tde_t3_med.SetDateTime( endMonthDate );
        }
        # endregion ■ ③現在処理年月取得 ■

        # region ■ ④集計期間取得 ■
        /// <summary>
        /// 処理区分変更時イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ce_t3_mode_ValueChanged( object sender, EventArgs e )
        {
            // 現在処理年月取得
            // 現在処理年月取得
            DateTime thisYearMonth;
            int thisYear;
            this._dateGet.GetThisYearMonth( out thisYearMonth, out thisYear );


            switch ( (int)ce_t3_mode.Value )
            {
                case 0:
                case 3:
                    {
                        // 年のみ
                        tde_t4_st.DateFormat = emDateFormat.df4Y;
                        tde_t4_ed.DateFormat = emDateFormat.df4Y;
                        tde_t4_base.DateFormat = emDateFormat.df4Y;
                        tde_t4_base.SetDateTime( new DateTime( thisYear, 1, 1 ) );
                    }
                    break;
                case 1:
                case 4:
                    {
                        // 年月のみ
                        tde_t4_st.DateFormat = emDateFormat.df4Y2M;
                        tde_t4_ed.DateFormat = emDateFormat.df4Y2M;
                        tde_t4_base.DateFormat = emDateFormat.df4Y2M;
                        tde_t4_base.SetDateTime( thisYearMonth );
                    }
                    break;
                case 2:
                case 5:
                    {
                        // 年月日
                        tde_t4_st.DateFormat = emDateFormat.df4Y2M2D;
                        tde_t4_ed.DateFormat = emDateFormat.df4Y2M2D;
                        tde_t4_base.DateFormat = emDateFormat.df4Y2M2D;
                        tde_t4_base.SetDateTime( DateTime.Today );
                    }
                    break;
            }

            // 結果欄はクリア
            this.tde_t4_st.SetDateTime( DateTime.MinValue );
            this.tde_t4_ed.SetDateTime( DateTime.MinValue );
        }

        /// <summary>
        /// 集計期間取得処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click( object sender, EventArgs e )
        {
            // 範囲
            int range = this.tne_t4_Range.GetInt();
            if ( range <= 0 )
            {
                this.tne_t4_Range.SetInt( 1 );
                range = 1;
            }

            // 結果・開始
            DateTime startDate = DateTime.MinValue;
            // 結果・終了
            DateTime endDate = DateTime.MinValue;


            switch ( (int)ce_t3_mode.Value )
            {
                case 0:
                    {
                        // 過去数年
                        tde_t4_base.SetLongDate( (tde_t4_base.GetLongDate() / 10000) * 10000 + 101 );
                        DateTime baseDate = this.tde_t4_base.GetDateTime();
                        this._dateGet.GetPeriod( DateGetAcs.ProcModeDivState.PastYears, baseDate, range, out startDate, out endDate );
                    }
                    break;
                case 1:
                    {
                        // 過去数月
                        tde_t4_base.SetLongDate( (tde_t4_base.GetLongDate() / 100) * 100 + 1 );
                        DateTime baseDate = this.tde_t4_base.GetDateTime();
                        this._dateGet.GetPeriod( DateGetAcs.ProcModeDivState.PastMonths, baseDate, range, out startDate, out endDate );
                    }
                    break;
                case 2:
                    {
                        // 過去数日
                        DateTime baseDate = this.tde_t4_base.GetDateTime();
                        this._dateGet.GetPeriod( DateGetAcs.ProcModeDivState.PastDays, baseDate, range, out startDate, out endDate );
                    }
                    break;
                case 3:
                    {
                        // 今後数年
                        tde_t4_base.SetLongDate( (tde_t4_base.GetLongDate() / 10000) * 10000 + 101 );
                        DateTime baseDate = this.tde_t4_base.GetDateTime();
                        this._dateGet.GetPeriod( DateGetAcs.ProcModeDivState.FutureYears, baseDate, range, out startDate, out endDate );
                    }
                    break;
                case 4:
                    {
                        // 今後数月
                        tde_t4_base.SetLongDate( (tde_t4_base.GetLongDate() / 100) * 100 + 1 );
                        DateTime baseDate = this.tde_t4_base.GetDateTime();
                        this._dateGet.GetPeriod( DateGetAcs.ProcModeDivState.FutureMonths, baseDate, range, out startDate, out endDate );
                    }
                    break;
                case 5:
                    {
                        // 今後数日
                        DateTime baseDate = this.tde_t4_base.GetDateTime();
                        this._dateGet.GetPeriod( DateGetAcs.ProcModeDivState.FutureDays, baseDate, range, out startDate, out endDate );
                    }
                    break;
            }

            // 表示
            this.tde_t4_st.SetDateTime( startDate );
            this.tde_t4_ed.SetDateTime( endDate );
        }
        # endregion ■ ④集計期間取得 ■

        # region ■ ⑤指定日を含む年月度取得 ■
        /// <summary>
        /// 指定日付を含む年月度取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click( object sender, EventArgs e )
        {
            // 年月度取得
            DateTime thisYearMonth;
            int thisYear;
            DateTime startMonthDate;
            DateTime endMonthDate;
            DateTime startYearDate;
            DateTime endYearDate;

            DateTime dateTime = tde_t5_dt.GetDateTime();

            this._dateGet.GetYearMonth( dateTime, out thisYearMonth, out thisYear, out startMonthDate, out endMonthDate, out startYearDate, out endYearDate );

            // 画面に表示
            this.lb_t5_Year.Text = thisYear.ToString();
            this.tde_t5_yst.SetDateTime( startYearDate );
            this.tde_t5_yed.SetDateTime( endYearDate );
            this.lb_t5_YearMonth.Text = string.Format( "{0}.{1}", thisYearMonth.Year.ToString(), thisYearMonth.Month.ToString( "00" ) );
            this.tde_t5_mst.SetDateTime( startMonthDate );
            this.tde_t5_med.SetDateTime( endMonthDate );
        }
        # endregion ■ ⑤指定日を含む年月度取得 ■

        # region ■ ⑥指定年月度の年度・日付 ■
        /// <summary>
        /// 指定年月度の年度・日付
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click( object sender, EventArgs e )
        {
            // 入力月度の調整(yyyy/mm/01)
            tde_t6_ym.SetLongDate( (tde_t6_ym.GetLongDate() / 100) * 100 + 1 );

            //----------------------------------------------
            // 指定年月度の年度を取得
            //----------------------------------------------
            int year;
            int addYears;
            DateTime ysMonth;
            DateTime yeMonth;
            _dateGet.GetYearFromMonth( tde_t6_ym.GetDateTime(), out year, out addYears, out ysMonth, out yeMonth );

            // 表示
            lb_t6_Year.Text = year.ToString();
            lb_t6_addYears.Text = addYears.ToString();
            lb_t6_ysMonth.Text = string.Format( "{0}.{1}", ysMonth.Year, ysMonth.Month.ToString( "00" ) );
            lb_t6_yeMonth.Text = string.Format( "{0}.{1}", yeMonth.Year, yeMonth.Month.ToString( "00" ) );

            //----------------------------------------------
            // 指定年月度の開始日・終了日を取得
            //----------------------------------------------
            DateTime msDate;
            DateTime meDate;
            _dateGet.GetDaysFromMonth( tde_t6_ym.GetDateTime(), out msDate, out meDate );

            // 表示
            tde_t6_mst.SetDateTime( msDate );
            tde_t6_med.SetDateTime( meDate );

        }
        # endregion ■ ⑥指定年月度の年度・日付 ■

        # region ■ ⑦日付チェック ■
        /// <summary>
        /// 日付チェック（有効チェック・範囲チェック・同一年度チェック）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click( object sender, EventArgs e )
        {
            string errorMessage;
            Control errorControl;

            // チェック
            bool status = CheckDateInputT7( out errorMessage, out errorControl );

            // メッセージ表示
            if ( errorMessage != string.Empty )
            {
                MessageBox.Show( "エラー：\n" + errorMessage );
            }
            else
            {
                MessageBox.Show( "チェックＯＫ" );
            }

            // フォーカスセット
            if ( errorControl != null )
            {
                errorControl.Focus();
            }
        }
        /// <summary>
        /// 日付チェック処理
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="errorControl"></param>
        private bool CheckDateInputT7( out string errorMessage, out Control errorControl )
        {
            bool status = true;

            errorMessage = string.Empty;
            errorControl = null;

            const string ct_err_NoInput = "を入力して下さい。";
            const string ct_err_Invalid = "の入力が不正です。";
            const string ct_err_RangeOver = "が範囲外です。";
            const string ct_err_Reverse = "は開始≦終了となるように入力して下さい。";
            const string ct_err_NotOnYear = "は同一年度内で指定して下さい。";
            const string ct_err_NotOnMonth = "は同一年月度内で指定して下さい。";


            DateGetAcs.YmdType rangeType = DateGetAcs.YmdType.YearMonthDay;
            // 範囲指定
            switch (ce_t7_a_rangeType.SelectedIndex)
            {
                case 1:
                    {
                        rangeType = DateGetAcs.YmdType.YearMonth;
                    }
                    break;
                case 2:
                    {
                        rangeType = DateGetAcs.YmdType.Year;
                    }
                    break;
            }

            // 日付範囲フルチェック
            DateGetAcs.CheckDateRangeResult cdrResult = _dateGet.CheckDateRange( rangeType, tne_t7_a_ymdRange.GetInt(), ref tde_t7_a_st, ref tde_t7_a_ed,
                                                                                (ce_t7_a_allowNoInput.SelectedIndex == 1),
                                                                                (ce_t7_a_checkOnYear.SelectedIndex == 1),
                                                                                (ce_t7_a_checkOnMonth.SelectedIndex == 1) );

            switch ( cdrResult )
            {
                case DateGetAcs.CheckDateRangeResult.OK:
                    status = true;
                    break;
                case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                    errorMessage = string.Format( "{0}{1}", "日付", ct_err_Reverse );
                    errorControl = tde_t7_a_st;
                    status = false;
                    break;
                case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    errorMessage = string.Format( "{0}{1}", "日付", ct_err_RangeOver );
                    errorControl = tde_t7_a_st;
                    status = false;
                    break;
                case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    errorMessage = string.Format( "{0}{1}", "開始日", ct_err_NoInput );
                    errorControl = tde_t7_a_st;
                    status = false;
                    break;
                case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                    errorMessage = string.Format( "{0}{1}", "開始日", ct_err_Invalid );
                    errorControl = tde_t7_a_st;
                    status = false;
                    break;
                case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    errorMessage = string.Format( "{0}{1}", "終了日", ct_err_NoInput );
                    errorControl = tde_t7_a_ed;
                    status = false;
                    break;
                case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                    errorMessage = string.Format( "{0}{1}", "終了日", ct_err_Invalid );
                    errorControl = tde_t7_a_ed;
                    status = false;
                    break;
                case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear:
                    errorMessage = string.Format( "{0}{1}", "日付", ct_err_NotOnYear );
                    errorControl = tde_t7_a_st;
                    status = false;
                    break;
                case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
                    errorMessage = string.Format( "{0}{1}", "日付", ct_err_NotOnMonth );
                    errorControl = tde_t7_a_st;
                    status = false;
                    break;
                default:
                    status = true;
                    break;
            }

            return status;
        }
        /// <summary>
        /// 日付入力指定区分　変更イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ce_t7_a_inputType_ValueChanged( object sender, EventArgs e )
        {
            // 現在処理年月取得
            DateTime thisYearMonth;
            int thisYear;
            this._dateGet.GetThisYearMonth( out thisYearMonth, out thisYear );


            switch ( ce_t7_a_inputType.SelectedIndex )
            {
                case 0:
                    {
                        // 年月日
                        tde_t7_a_st.DateFormat = emDateFormat.df4Y2M2D;
                        tde_t7_a_ed.DateFormat = emDateFormat.df4Y2M2D;
                        tde_t7_a_st.SetDateTime( DateTime.Today );
                        tde_t7_a_ed.SetDateTime( DateTime.Today );
                    }
                    break;
                case 1:
                    {
                        // 年月
                        tde_t7_a_st.DateFormat = emDateFormat.df4Y2M;
                        tde_t7_a_ed.DateFormat = emDateFormat.df4Y2M;
                        tde_t7_a_st.SetDateTime( thisYearMonth );
                        tde_t7_a_ed.SetDateTime( thisYearMonth );
                    }
                    break;
                case 2:
                    {
                        // 年
                        tde_t7_a_st.DateFormat = emDateFormat.df4Y;
                        tde_t7_a_ed.DateFormat = emDateFormat.df4Y;
                        tde_t7_a_st.SetDateTime( new DateTime( thisYear, 1, 1 ) );
                        tde_t7_a_ed.SetDateTime( new DateTime( thisYear, 1, 1 ) );
                    }
                    break;
            }
        }
        # endregion ■ ⑦日付チェック ■

    }
}