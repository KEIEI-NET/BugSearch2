using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上速報表示DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上速報表示の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350 櫻井 亮太</br>
    /// <br>Date       : 2008.10.27</br>
    /// <br></br>
    /// <br>Update Note: 速度チューニング</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/05/10</br>
    /// <br>Update Note: 鄧潘ハン</br>
    /// <br>Date       : 2011/03/22</br>
    /// <br>             照会プログラムのログ出力対応</br>
    /// <br>Update Note: chenyk</br>
    /// <br>Date       : 2014/02/21</br>
    /// <br>             redmine#42135 稼働日取得方法の対応</br>
    /// <br>Update Note: chenyk</br>
    /// <br>Date       : 2014/03/06</br>
    /// <br>             redmine#42135 四捨五入の修正</br>
    /// </remarks>
    [Serializable]
    public class SalesReportOrderWorkDB : RemoteDB, ISalesReportOrderWorkDB
    {
        /// <summary>
        /// 売上速報表示DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.2</br>
        /// </remarks>
        public SalesReportOrderWorkDB()
            :
        base("PMHNB04157D", "Broadleaf.Application.Remoting.ParamData.SalesReportOrderWorkDB", "SalesHistoryRF") //基底クラスのコンストラクタ
        {
        }

        private CompanyInfDB _companyInfDB = new CompanyInfDB();

        #region Search
        /// <summary>
        /// 指定された企業コードの売上速報表示のLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="salesReportResultWork">検索結果</param>
        /// <param name=" salesReportOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの売上速報表示LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.27</br>
        public int Search(out object salesReportResultWork, object salesReportOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            salesReportResultWork = null;

            SalesReportOrderCndtnWork _salesReportOrderCndtnWork = salesReportOrderCndtnWork as SalesReportOrderCndtnWork;

            try
            {
                // 売上速報表示検索
                status = SearchProc(out salesReportResultWork, _salesReportOrderCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesReportOrderWorkDB.Search Exception=" + ex.Message);
                salesReportResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの売上速報表示のLISTを全て戻します
        /// </summary>
        /// <param name="salesReportResultWork">検索結果</param>
        /// <param name=" salesReportOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの売上速報表示LISTを全て戻します</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.27</br>
        /// <br>Update Note: 鄧潘ハン</br>
        /// <br>Date       : 2011/03/22</br>
        /// <br>             照会プログラムのログ出力対応</br>
        /// <br>Update Note: chenyk</br>
        /// <br>Date       : 2014/02/21</br>
        /// <br>             redmine#42135 稼働日取得方法の対応</br>
        /// <br></br>
        public int SearchProc(out object salesReportResultWork, SalesReportOrderCndtnWork _salesReportOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            salesReportResultWork = null;
            SqlConnection sqlConnection = null;

            ArrayList al = new ArrayList();   //抽出結果

            try
            {

                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                ArrayList list = new ArrayList();
                CompanyInfWork companyInfWork = new CompanyInfWork();

                //締め範囲日付取得
                companyInfWork.EnterpriseCode = _salesReportOrderCndtnWork.EnterpriseCode;

                // --- ADD 2011/03/22----------------------------------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, companyInfWork.EnterpriseCode, "売上速報表示", "抽出開始");
                // --- ADD 2011/03/22-----------------------------------<<<<<
                
                status = _companyInfDB.Search(out list, companyInfWork, ref sqlConnection);

                // --- ADD 2011/03/22----------------------------------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, companyInfWork.EnterpriseCode, "売上速報表示", "抽出終了");
                // --- ADD 2011/03/22-----------------------------------<<<<<

                companyInfWork = list[0] as CompanyInfWork;

                int year;
                DateTime yearmonth;
                string strYearMonth;
                DateTime stMonth, edMonth;

                FinYearTableGenerator fin = new FinYearTableGenerator(companyInfWork);
                fin.GetYearMonth(_salesReportOrderCndtnWork.St_SalesDate, out yearmonth, out year);
                if (yearmonth.Month >= 1 && yearmonth.Month <= 9)
                {
                    strYearMonth = yearmonth.Year.ToString() + "0" + yearmonth.Month.ToString();
                }
                else
                {
                    strYearMonth = yearmonth.Year.ToString() + yearmonth.Month.ToString();

                }

                fin.GetDaysFromMonth(yearmonth, out stMonth, out edMonth);

                status = SearchOrderProc(ref al, ref sqlConnection, _salesReportOrderCndtnWork, logicalMode, strYearMonth);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 稼働日検索
                    status = this.SearchHoliday(ref al, ref sqlConnection, _salesReportOrderCndtnWork, readMode, logicalMode, stMonth, edMonth);
                }
                // --- ADD chenyk 2014/02/21 ------->>>>>
                // 画面指定範囲内の目標金額となるように修正
                TargetMoneyUpdate(ref al);
                // --- ADD chenyk 2014/02/21 -------<<<<<
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesReportOrderWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            salesReportResultWork = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_orderListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, SalesReportOrderCndtnWork _salesReportOrderCndtnWork, ConstantManagement.LogicalMode logicalMode, string strYearMonth)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select文作成

                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += "         SAL.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += "        ,SAL.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "        ,SAL.RESULTSADDUPSECCDRF" + Environment.NewLine;
                selectTxt += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "        ,SUM(SAL.SALESTOTALTAXEXCRF) AS SUMSALESTOTALTAXEXCRF" + Environment.NewLine;
                selectTxt += "        ,EMP.SALESTARGETMONEYRF" + Environment.NewLine;
                selectTxt += "        ,EMP.SALESTARGETPROFITRF" + Environment.NewLine;
                selectTxt += "        ,SUM(SAL.SALESTOTALTAXEXCRF - SAL.TOTALCOSTRF) AS SUMTOTALCOST" + Environment.NewLine;
                selectTxt += " FROM SALESHISTORYRF AS SAL" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "	SEC.ENTERPRISECODERF=SAL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND SEC.SECTIONCODERF=SAL.RESULTSADDUPSECCDRF" + Environment.NewLine;
                selectTxt += "LEFT JOIN EMPSALESTARGETRF AS EMP" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "	EMP.ENTERPRISECODERF=SAL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND EMP.SECTIONCODERF=SAL.RESULTSADDUPSECCDRF" + Environment.NewLine;
                selectTxt += "	AND EMP.SUBSECTIONCODERF=0" + Environment.NewLine;
                selectTxt += "	AND EMP.EMPLOYEEDIVCDRF=0" + Environment.NewLine;
              	selectTxt += "	AND EMP.TARGETSETCDRF = 10" + Environment.NewLine;
                selectTxt += "  AND EMP.TARGETCONTRASTCDRF = 10" + Environment.NewLine;
                selectTxt += "  AND EMP.TARGETDIVIDECODERF = @TARGET" + Environment.NewLine;
                selectTxt += "  AND EMP.EMPLOYEECODERF = ''" + Environment.NewLine;

                SqlParameter parastrYearMonth = sqlCommand.Parameters.Add("@TARGET", SqlDbType.NChar);
                parastrYearMonth.Value = SqlDataMediator.SqlSetString(strYearMonth);

                //WHERE文の作成
                selectTxt += MakeWhereString(ref sqlCommand, _salesReportOrderCndtnWork, logicalMode);

                selectTxt += " GROUP BY SAL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,SAL.RESULTSADDUPSECCDRF" + Environment.NewLine;
                selectTxt += " ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += " ,EMP.SALESTARGETMONEYRF" + Environment.NewLine;
                selectTxt += " ,EMP.SALESTARGETPROFITRF" + Environment.NewLine;


                sqlCommand.CommandText = selectTxt;
                #endregion

                myReader = sqlCommand.ExecuteReader();  
                
                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    SalesReportResultWork wkSalesReportResultWork = new SalesReportResultWork();
                    
                    //格納項目
                    wkSalesReportResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkSalesReportResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                    wkSalesReportResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkSalesReportResultWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESTOTALTAXEXCRF"));
                    wkSalesReportResultWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEYRF"));
                    if (wkSalesReportResultWork.SalesTargetMoney != 0)
                    {

                        wkSalesReportResultWork.AchievementRateNet = ((double)wkSalesReportResultWork.SalesTotalTaxExc / (double)wkSalesReportResultWork.SalesTargetMoney) *100;
                    } 
                    wkSalesReportResultWork.GrossMargin = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMTOTALCOST"));  
                    wkSalesReportResultWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFITRF"));
                    if (wkSalesReportResultWork.SalesTargetProfit != 0)
                    {
                        
                        wkSalesReportResultWork.AchievementRateGross = ((double)wkSalesReportResultWork.GrossMargin / (double)wkSalesReportResultWork.SalesTargetProfit * 100);
                    }                    
                    #endregion

                    al.Add(wkSalesReportResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesReportOrderWork.SearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion


        /// <summary>
        /// 指定された企業コードの売上速報表示のLISTを全て戻します
        /// </summary>
        /// <param name="salesReportResultWork">検索結果</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの売上速報表示LISTを全て戻します</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.27</br>
        /// <br>Update Note: chenyk</br>
        /// <br>Date       : 2014/02/21</br>
        /// <br>             redmine#42135 稼働日取得方法の対応</br>
        /// <br></br>
        public int SearchHoliday(ref ArrayList al, ref SqlConnection sqlConnection, SalesReportOrderCndtnWork _salesReportOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode,DateTime stMonth, DateTime edMonth)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                //status = SearchHolidayProc(ref al, ref sqlConnection, _salesReportOrderCndtnWork, logicalMode, stMonth, edMonth); // DEL chenyk 2014/02/21 for redmine#42135
                // --- ADD chenyk 2014/02/21 for redmine#42135 ------>>>>>
                status = SearchHolidayProc(ref al, ref sqlConnection, _salesReportOrderCndtnWork, logicalMode, stMonth, edMonth, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = SearchHolidayProc(ref al, ref sqlConnection, _salesReportOrderCndtnWork, logicalMode, _salesReportOrderCndtnWork.St_SalesDate, _salesReportOrderCndtnWork.Ed_SalesDate, 1);
                }
                // --- ADD chenyk 2014/02/21 for redmine#42135 ------<<<<<
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesReportOrderWorkDB.SearchHolyday Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_orderListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="flag">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: chenyk</br>
        /// <br>Date       : 2014/02/21</br>
        /// <br>             redmine#42135 稼働日取得方法の対応</br>
        //private int SearchHolidayProc(ref ArrayList al, ref SqlConnection sqlConnection, SalesReportOrderCndtnWork _salesReportOrderCndtnWork, ConstantManagement.LogicalMode logicalMode,DateTime stMonth, DateTime edMonth) // DEL chenyk 2014/02/21
        private int SearchHolidayProc(ref ArrayList al, ref SqlConnection sqlConnection, SalesReportOrderCndtnWork _salesReportOrderCndtnWork, ConstantManagement.LogicalMode logicalMode, DateTime stMonth, DateTime edMonth, int flag) // ADD chenyk 2014/02/21
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList list = new ArrayList();
            ArrayList palaList = new ArrayList();
            
            int holiday;
            int j=0;

            try
            {
                // 拠点毎の休日判定
                foreach (SalesReportResultWork salesReportResultWork in al)
                {
                    //リストから拠点抽出
                    string sectionCode = salesReportResultWork.SectionCode;

                    myReader = null;
                    sqlCommand = null;

                    string selectTxt = "";
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                    #region Select文作成

                    selectTxt += "SELECT " + Environment.NewLine;
                    selectTxt += "COUNT(*) AS HOLIDAYCOUNTRF" + Environment.NewLine;
                    selectTxt += " FROM HOLIDAYSETTINGRF" + Environment.NewLine;

                    selectTxt += MakeHolidayWhereString(ref sqlCommand, _salesReportOrderCndtnWork, logicalMode, sectionCode, stMonth, edMonth);
                    sqlCommand.CommandText = selectTxt;

                    myReader = sqlCommand.ExecuteReader();

                    #endregion
                    while (myReader.Read())
                    {
                        // 抽出結果
                        holiday = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HOLIDAYCOUNTRF"));
                        list.Add(holiday);
                    }

                    // 指定範囲内の日数取得
                    TimeSpan i = edMonth - stMonth;

                    int Allday = i.Days;
                    int Opday = Allday+1 - (int)list[j];

                    //稼働日を追加
                    // salesReportResultWork.OperationDay = Opday; // DEL chenyk 2014/02/21 for redmine#42135
                    // --- ADD chenyk 2014/02/21 for redmine#42135 ------>>>>>
                    if (flag == 0)
                    {
                        salesReportResultWork.OperationDayInRange = Opday;
                    }
                    else
                    {
                        salesReportResultWork.OperationDay = Opday;
                    }
                    // --- ADD chenyk 2014/02/21 for redmine#42135 ------<<<<<

                    palaList.Add(salesReportResultWork);
                    if (!myReader.IsClosed) myReader.Close();
                    j++;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                
                al.Clear();
                al = palaList;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesReportOrderWork.SearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }


        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_orderListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesReportOrderCndtnWork _salesReportOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = "WHERE" + Environment.NewLine;
            if (_salesReportOrderCndtnWork.SectionCode != "")
            {
                #region WHERE文作成
                // 企業コード
                retstring += "SAL.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_salesReportOrderCndtnWork.EnterpriseCode);

                // 拠点コード
                retstring += " AND SAL.RESULTSADDUPSECCDRF=@SECTIONCODE";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(_salesReportOrderCndtnWork.SectionCode);

                // 売上日付
                if (_salesReportOrderCndtnWork.St_SalesDate != DateTime.MinValue)
                {
                    retstring += " AND SAL.SALESDATERF>=@STSALESDATE" + Environment.NewLine;
                    SqlParameter paraStSalesDate = sqlCommand.Parameters.Add("@STSALESDATE", SqlDbType.Int);
                    paraStSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_salesReportOrderCndtnWork.St_SalesDate);
                }
                if (_salesReportOrderCndtnWork.Ed_SalesDate != DateTime.MinValue)
                {
                    retstring += " AND SAL.SALESDATERF<=@EDSALESDATE" + Environment.NewLine;
                    SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@EDSALESDATE", SqlDbType.Int);
                    paraEdSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_salesReportOrderCndtnWork.Ed_SalesDate);
                }

                // 売上伝票区分
                retstring += " AND ((SAL.SALESSLIPCDRF = 0) OR (SAL.SALESSLIPCDRF = 1))" + Environment.NewLine;

                // 論理削除コード
                retstring += " AND SAL.LOGICALDELETECODERF = 0" + Environment.NewLine;

                // -- ADD 2010/05/10 ---------------------------------->>>
                // 受注ステータス(30固定)
                retstring += " AND SAL.ACPTANODRSTATUSRF = 30" + Environment.NewLine;
                // -- ADD 2010/05/10 ----------------------------------<<<
            
            }
            if (_salesReportOrderCndtnWork.SectionCode == "")
            {
                // 企業コード
                retstring += "SAL.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_salesReportOrderCndtnWork.EnterpriseCode);

                // 論理削除コード
                retstring += " AND SAL.LOGICALDELETECODERF = 0" + Environment.NewLine;

                // 売上日付
                if (_salesReportOrderCndtnWork.St_SalesDate != DateTime.MinValue)
                {
                    retstring += " AND SAL.SALESDATERF>=@STSALESDATE" + Environment.NewLine;
                    SqlParameter paraStSalesDate = sqlCommand.Parameters.Add("@STSALESDATE", SqlDbType.Int);
                    paraStSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_salesReportOrderCndtnWork.St_SalesDate);
                }
                if (_salesReportOrderCndtnWork.Ed_SalesDate != DateTime.MinValue)
                {
                    retstring += " AND SAL.SALESDATERF<=@EDSALESDATE" + Environment.NewLine;
                    SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@EDSALESDATE", SqlDbType.Int);
                    paraEdSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_salesReportOrderCndtnWork.Ed_SalesDate);
                }

                // -- ADD 2010/05/10 ---------------------------------->>>
                // 受注ステータス(30固定)
                retstring += " AND SAL.ACPTANODRSTATUSRF = 30" + Environment.NewLine;
                // -- ADD 2010/05/10 ----------------------------------<<<

            }
            #endregion
            return retstring;
        }


        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_orderListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeHolidayWhereString(ref SqlCommand sqlCommand, SalesReportOrderCndtnWork _salesReportOrderCndtnWork, ConstantManagement.LogicalMode logicalMode,string sectionCode, DateTime stMonth, DateTime edMonth)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;
            // 企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_salesReportOrderCndtnWork.EnterpriseCode);

            // 拠点コード
            retstring += " AND SECTIONCODERF=@SECTIONCODE";
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
            paraSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);

            // 適用区分0,1
            retstring += " AND ((APPLYDATECDRF = 0) OR (APPLYDATECDRF = 1))" + Environment.NewLine;
            
            // 適用年月日
            if (_salesReportOrderCndtnWork.St_SalesDate != DateTime.MinValue)
            {
                retstring += " AND APPLYDATERF>=@STAPPLYDATE" + Environment.NewLine;
                SqlParameter paraStSalesDate = sqlCommand.Parameters.Add("@STAPPLYDATE", SqlDbType.Int);
                paraStSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stMonth);
            }
            if (_salesReportOrderCndtnWork.Ed_SalesDate != DateTime.MinValue)
            {
                retstring += " AND APPLYDATERF<=@EDAPPLYDATE" + Environment.NewLine;
                SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@EDAPPLYDATE", SqlDbType.Int);
                paraEdSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(edMonth);
            }

            #endregion
            return retstring;
        }

        // --- ADD chenyk 2014/02/21 ------->>>>>
        /// <summary>
        /// 画面指定範囲内の売上目標金額となるように修正
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <returns></returns>
        private void TargetMoneyUpdate (ref ArrayList al)
        {
            ArrayList palaList = new ArrayList();
            foreach (SalesReportResultWork resultWork in al)
            {
                long salesTargetMoney = resultWork.SalesTargetMoney;
                long salesTargetProfit = resultWork.SalesTargetProfit;
                int operationDayInRange = resultWork.OperationDayInRange;
                int operationDay = resultWork.OperationDay;
                if (operationDayInRange != 0)
                {
                    // 売上目標金額
                    //resultWork.SalesTargetMoney = salesTargetMoney * operationDay / operationDayInRange; // DEL chenyk 2014/03/06 Redmine#42135 四捨五入の修正
                    resultWork.SalesTargetMoney = this.GetUnitChangeProc(salesTargetMoney * operationDay, operationDayInRange); // ADD chenyk 2014/03/06 Redmine#42135 四捨五入の修正
                    if (resultWork.SalesTargetMoney != 0)
                    {
                        // 達成率（純売上）
                        resultWork.AchievementRateNet = ((double)resultWork.SalesTotalTaxExc / (double)resultWork.SalesTargetMoney) * 100;
                    }
                }
                else
                {
                    resultWork.SalesTargetMoney = 0;
                    resultWork.AchievementRateNet = 0.00;
                }
                if (operationDayInRange != 0)
                {
                    // 売上目標粗利額
                    //resultWork.SalesTargetProfit = salesTargetProfit * operationDay / operationDayInRange; // DEL chenyk 2014/03/06 Redmine#42135 四捨五入の修正
                    resultWork.SalesTargetProfit = this.GetUnitChangeProc(salesTargetProfit * operationDay, operationDayInRange); // ADD chenyk 2014/03/06 Redmine#42135 四捨五入の修正
                    if (resultWork.SalesTargetProfit != 0)
                    {
                        // 達成率（粗利）
                        resultWork.AchievementRateGross = ((double)resultWork.GrossMargin / (double)resultWork.SalesTargetProfit * 100);
                    }
                }
                else
                {
                    resultWork.SalesTargetProfit = 0;
                    resultWork.AchievementRateGross = 0.00;
                }
                palaList.Add(resultWork);
            }
            al.Clear();
            al = palaList;
        }

        // --- ADD chenyk 2014/03/06 Redmine#42135 四捨五入の修正 ----->>>>>
        #region ◆単位変換処理
        /// <summary>
        /// 単位変換処理（四捨五入）
        /// </summary>
        /// <param name="numerator">分子</param>
        /// <param name="denominator">分母</param>
        internal Int64 GetUnitChangeProc(Int64 numerator, Int64 denominator)
        {
            Int64 retInt;
            Int64 workInt;
            double workdbl;

            retInt = numerator / denominator;
            workdbl = (double)numerator / (double)denominator;

            workInt = (Int64)(workdbl * 10) % 10;
            if (workInt >= 5)
            {
                retInt++;
            }

            return retInt;
        }
        #endregion
        // --- ADD chenyk 2014/03/06 Redmine#42135 四捨五入の修正 -----<<<<<
        // --- ADD chenyk 2014/02/21 -------<<<<<
    }
}

