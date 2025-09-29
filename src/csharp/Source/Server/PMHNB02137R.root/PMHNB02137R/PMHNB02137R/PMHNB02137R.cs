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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先過年度統計表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先過年度統計表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.9.10</br>
    /// <br></br>
    /// <br>Update Note: 2012/09/19 田建委</br>
    /// <br>管理番号   : 2012/09/26配信分</br>
    /// <br>             Redmine#32298 クエリ実行のタイムアウト時間を3600ｓにセットする</br>
    /// <br>Update Note: 2013/08/16 王君</br>
    /// <br>             Redmine#39041 #15,#16の対応</br>
    /// </remarks>
    [Serializable]
    public class CustFinancialListResultWorkDB : RemoteDB, ICustFinancialListResultWorkDB
    {
        /// <summary>
        /// 得意先過年度統計表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public CustFinancialListResultWorkDB()
            :
        base("PMHNB02139D", "Broadleaf.Application.Remoting.ParamData.CustomInqResultWork", "MTTLSALESSLIPRF") //基底クラスのコンストラクタ
        {
        }

        #region 得意先過年度統計表
        /// <summary>
        /// 指定された企業コードの得意先過年度統計表LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="customInqResultWork">検索結果</param>
        /// <param name="customInqOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの得意先過年度統計表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.24</br>
        public int Search(out object custFinancialListResultList, object custFinancialListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            custFinancialListResultList = null;

            CustFinancialListCndtnWork _custFinancialListCndtnWork = custFinancialListCndtnWork as CustFinancialListCndtnWork;

            try
            {
                status = SearchProc(out custFinancialListResultList, _custFinancialListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustFinancialListResultWorkDB.Search Exception=" + ex.Message);
                custFinancialListResultList = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの得意先過年度統計表LISTを全て戻します
        /// </summary>
        /// <param name="custFinancialListResultList">検索結果</param>
        /// <param name="_custFinancialListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの得意先過年度統計表LISTを全て戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.9.10</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 長内 DC.NS用に修正</br>
        private int SearchProc(out object custFinancialListResultList, CustFinancialListCndtnWork _custFinancialListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            custFinancialListResultList = null;

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


                status = SearchOrderProc(ref al, ref sqlConnection, _custFinancialListCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustFinancialListResultWorkDB.SearchProc Exception=" + ex.Message);
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

            custFinancialListResultList = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_custFinancialListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Update Note : 王君 2013/08/16</br>
        /// <br>            : Redmine#39041 #15,#16の対応</br>
        /// </remarks>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, CustFinancialListCndtnWork _custFinancialListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt="";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                int loopcnt = _custFinancialListCndtnWork.Ed_Year.Year - _custFinancialListCndtnWork.St_Year.Year;

                DateTime financialYear = _custFinancialListCndtnWork.Ed_Year;

                for (int i = 0; i <= loopcnt; i++)
                {
                    selectTxt = "";
                    sqlCommand.Parameters.Clear();
                    //SELECT文作成
                    selectTxt += MakeSelectString(_custFinancialListCndtnWork.PrintDiv);

                    //WHERE文の作成
                    selectTxt += MakeWhereString(ref sqlCommand, _custFinancialListCndtnWork, logicalMode);

                    //GROUPBY文作成
                    selectTxt += MakeGroupByString(_custFinancialListCndtnWork.PrintDiv);

                    sqlCommand.CommandText = selectTxt;

                    // ----- ADD 2012/09/19 田建委 redmine#32298 ----->>>>>
                    //タイムアウト時間の設定（秒）
                    sqlCommand.CommandTimeout = 3600;
                    // ----- ADD 2012/09/19 田建委 redmine#32298 -----<<<<<

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        #region 抽出結果-値セット
                        CustFinancialListResultWork wkCustFinancialListResultWork = new CustFinancialListResultWork();

                        //格納項目
                        // ----- ADD 王君 2013/08/16 Redmine#39041 ----->>>>>
                        switch (_custFinancialListCndtnWork.PrintDiv)
                        {
                            case 4:
                                {
                                    //請求先別
                                    wkCustFinancialListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF")); 
                                    break;
                                }
                            default:
                                {
                                    wkCustFinancialListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                                    break;
                                }
                        }
                        // ----- ADD 王君 2013/08/16 Redmine#39041 -----<<<<<
                        wkCustFinancialListResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        //wkCustFinancialListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF")); // DEL 王君　2013/08/16　Redmine#39041
                        wkCustFinancialListResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                        wkCustFinancialListResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        wkCustFinancialListResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                        wkCustFinancialListResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                        wkCustFinancialListResultWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESMONEYRF"));
                        wkCustFinancialListResultWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESRETGOODSPRICERF"));
                        wkCustFinancialListResultWork.DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMDISCOUNTPRICERF"));
                        wkCustFinancialListResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMGROSSPROFITRF"));
                        wkCustFinancialListResultWork.FinancialYear = financialYear.Year;
                        #endregion

                        al.Add(wkCustFinancialListResultWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    _custFinancialListCndtnWork.St_AddUpYearMonth = _custFinancialListCndtnWork.St_AddUpYearMonth.AddYears(-1);
                    _custFinancialListCndtnWork.Ed_AddUpYearMonth = _custFinancialListCndtnWork.Ed_AddUpYearMonth.AddYears(-1);

                    financialYear = financialYear.AddYears(-1);

                    if (!myReader.IsClosed) myReader.Close();
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "customInqResultWork.SearchOrderProc Exception=" + ex.Message);
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
        /// 発行タイプ別にSELECT分を作成
        /// </summary>
        /// <param name="printDiv">発行タイプ</param>
        /// <returns>SELECT文</returns>
        /// <remarks>
        /// <br>Update Note : 王君 2013/08/16</br>
        /// <br>            : Redmine#39041 #15,#16の対応</br>
        /// </remarks>
        private string MakeSelectString (Int32 printDiv)
        {
            string retString = string.Empty;

            switch (printDiv)
            {
                case 1:
                    {
                        //拠点別
                        retString += "SELECT " + Environment.NewLine;
                        retString += "	       MTL.ENTERPRISECODERF" + Environment.NewLine;
                        retString += "        ,MTL.ADDUPSECCODERF" + Environment.NewLine;
                        retString += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                        retString += "        ,0 AS CUSTOMERCODERF" + Environment.NewLine;
                        retString += "        ,'' AS CUSTOMERSNMRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESMONEYRF) AS  SUMSALESMONEYRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESRETGOODSPRICERF) AS SUMSALESRETGOODSPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.DISCOUNTPRICERF) AS SUMDISCOUNTPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.GROSSPROFITRF) AS SUMGROSSPROFITRF" + Environment.NewLine;
                        retString += " FROM MTTLSALESSLIPRF AS MTL " + Environment.NewLine;
                        retString += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     MTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND MTL.ADDUPSECCODERF=SEC.SECTIONCODERF" + Environment.NewLine;

                        break;
                    }
                case 2:
                    {
                        //得意先拠点別
                        retString += "SELECT " + Environment.NewLine;
                        retString += "	       MTL.ENTERPRISECODERF" + Environment.NewLine;
                        retString += "        ,MTL.ADDUPSECCODERF" + Environment.NewLine;
                        retString += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                        retString += "        ,MTL.CUSTOMERCODERF" + Environment.NewLine;
                        retString += "        ,CUS.CUSTOMERSNMRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESMONEYRF) AS  SUMSALESMONEYRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESRETGOODSPRICERF) AS SUMSALESRETGOODSPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.DISCOUNTPRICERF) AS SUMDISCOUNTPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.GROSSPROFITRF) AS SUMGROSSPROFITRF" + Environment.NewLine;
                        retString += " FROM MTTLSALESSLIPRF AS MTL " + Environment.NewLine;
                        retString += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     MTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND MTL.ADDUPSECCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                        retString += "LEFT JOIN CUSTOMERRF AS CUS" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     MTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND MTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF" + Environment.NewLine;

                        break;

                    }
                case 3:
                    {
                        //管理拠点別
                        retString += "SELECT " + Environment.NewLine;
                        retString += "	       MTL.ENTERPRISECODERF" + Environment.NewLine;
                        retString += "        ,CUS.MNGSECTIONCODERF AS ADDUPSECCODERF" + Environment.NewLine;
                        retString += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                        retString += "        ,0 AS CUSTOMERCODERF" + Environment.NewLine;
                        retString += "        ,'' AS CUSTOMERSNMRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESMONEYRF) AS  SUMSALESMONEYRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESRETGOODSPRICERF) AS SUMSALESRETGOODSPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.DISCOUNTPRICERF) AS SUMDISCOUNTPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.GROSSPROFITRF) AS SUMGROSSPROFITRF" + Environment.NewLine;
                        retString += " FROM MTTLSALESSLIPRF AS MTL " + Environment.NewLine;
                        retString += "LEFT JOIN CUSTOMERRF AS CUS" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     MTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND MTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF" + Environment.NewLine;
                        retString += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     MTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND CUS.MNGSECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;

                        break;

                    }
                case 4:
                    {
                        //請求先別
                        retString += "SELECT " + Environment.NewLine;
                        retString += "	       MTL.ENTERPRISECODERF" + Environment.NewLine;
                        //retString += "        ,MTL.ADDUPSECCODERF" + Environment.NewLine; // DEL 王君 2013/08/16 Redmine#39041 
                        retString += "        ,CUS.CLAIMSECTIONCODERF" + Environment.NewLine; // ADD 王君 2013/08/16 Redmine#39041 
                        retString += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                        retString += "        ,CUS.CLAIMCODERF AS CUSTOMERCODERF" + Environment.NewLine;
                        retString += "        ,CUS2.CUSTOMERSNMRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESMONEYRF) AS  SUMSALESMONEYRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESRETGOODSPRICERF) AS SUMSALESRETGOODSPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.DISCOUNTPRICERF) AS SUMDISCOUNTPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.GROSSPROFITRF) AS SUMGROSSPROFITRF" + Environment.NewLine;
                        retString += " FROM MTTLSALESSLIPRF AS MTL " + Environment.NewLine;

                        /* -----DEL 王君 2013/08/16 Redmine#39041 ----->>>>>
                        retString += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     MTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND MTL.ADDUPSECCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                         -----DEL 王君 2013/08/16 Redmine#39041 -----<<<<<*/

                        retString += "LEFT JOIN CUSTOMERRF AS CUS" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     MTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND MTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF" + Environment.NewLine;

                        retString += "LEFT JOIN CUSTOMERRF AS CUS2" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     CUS2.ENTERPRISECODERF=CUS.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND CUS2.CUSTOMERCODERF=CUS.CLAIMCODERF" + Environment.NewLine;
                        // ----- ADD 王君 2013/08/16 Redmine#39041 ----->>>>> 
                        retString += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     CUS2.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND CUS2.CLAIMSECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                        // ----- ADD 王君 2013/08/16 Redmine#39041 -----<<<<<
                        break;

                    }
                default:
                    {
                        //得意先別
                        retString += "SELECT " + Environment.NewLine;
                        retString += "	       MTL.ENTERPRISECODERF" + Environment.NewLine;
                        retString += "        ,MTL.ADDUPSECCODERF" + Environment.NewLine;
                        retString += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                        retString += "        ,MTL.CUSTOMERCODERF" + Environment.NewLine;
                        retString += "        ,CUS.CUSTOMERSNMRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESMONEYRF) AS  SUMSALESMONEYRF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.SALESRETGOODSPRICERF) AS SUMSALESRETGOODSPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.DISCOUNTPRICERF) AS SUMDISCOUNTPRICERF" + Environment.NewLine;
                        retString += "        ,SUM(MTL.GROSSPROFITRF) AS SUMGROSSPROFITRF" + Environment.NewLine;
                        retString += " FROM MTTLSALESSLIPRF AS MTL " + Environment.NewLine;
                        retString += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     MTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND MTL.ADDUPSECCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                        retString += "LEFT JOIN CUSTOMERRF AS CUS" + Environment.NewLine;
                        retString += "ON" + Environment.NewLine;
                        retString += "     MTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " AND MTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF" + Environment.NewLine;

                        break;

                    }
            }

            return retString;
        }

        /// <summary>
        /// 発行タイプ別にGROUP BY句を作成
        /// </summary>
        /// <param name="printDiv">発行タイプ</param>
        /// <returns>GROUP BY句</returns>
        /// <remarks>
        /// <br>Update Note : 王君 2013/08/16</br>
        /// <br>            : Redmine#39041 #15,#16の対応</br>
        /// </remarks>
        private string MakeGroupByString(Int32 printDiv)
        {
            string retString = string.Empty;

            switch (printDiv)
            {
                case 1:
                    {
                        //拠点別
                        retString += "GROUP BY" + Environment.NewLine;
                        retString += "	MTL.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " ,MTL.ADDUPSECCODERF" + Environment.NewLine;
                        retString += " ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;

                        break;

                    }
                case 2:
                    {
                        //得意先拠点別
                        retString += "GROUP BY" + Environment.NewLine;
                        retString += "	MTL.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " ,MTL.ADDUPSECCODERF" + Environment.NewLine;
                        retString += " ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                        retString += " ,MTL.CUSTOMERCODERF" + Environment.NewLine;
                        retString += " ,CUS.CUSTOMERSNMRF" + Environment.NewLine;

                        break;
                    }
                case 3:
                    {
                        //管理拠点別
                        retString += "GROUP BY" + Environment.NewLine;
                        retString += "	MTL.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " ,CUS.MNGSECTIONCODERF" + Environment.NewLine;
                        retString += " ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;

                        break;
                    }
                case 4:
                    {
                        //請求先別
                        retString += "GROUP BY" + Environment.NewLine;
                        retString += "	MTL.ENTERPRISECODERF" + Environment.NewLine;
                        //retString += " ,MTL.ADDUPSECCODERF" + Environment.NewLine;  // DEL 王君 2013/08/16 Redmine#39041
                        retString += "   ,CUS.CLAIMSECTIONCODERF" + Environment.NewLine; // ADD 王君 2013/08/16 Redmine#39041
                        retString += " ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                        retString += " ,CUS.CLAIMCODERF" + Environment.NewLine;
                        retString += " ,CUS2.CUSTOMERSNMRF" + Environment.NewLine;

                        break;
                    }
                default:
                    {
                        //得意先別
                        retString += "GROUP BY" + Environment.NewLine;
                        retString += "	MTL.ENTERPRISECODERF" + Environment.NewLine;
                        retString += " ,MTL.ADDUPSECCODERF" + Environment.NewLine;
                        retString += " ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                        retString += " ,MTL.CUSTOMERCODERF" + Environment.NewLine;
                        retString += " ,CUS.CUSTOMERSNMRF" + Environment.NewLine;

                        break;
                    }
            }

            return retString;
        }
        
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_orderListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, CustFinancialListCndtnWork _custFinancialListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;

            //企業コード
            retstring += " MTL.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_custFinancialListCndtnWork.EnterpriseCode);

            //実績集計区分
            retstring += " AND MTL.RSLTTTLDIVCDRF=0" + Environment.NewLine;

            //従業員区分
            retstring += " AND MTL.EMPLOYEEDIVCDRF=10" + Environment.NewLine;

            //計上拠点コード
            if (_custFinancialListCndtnWork.AddUpSecCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _custFinancialListCndtnWork.AddUpSecCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    switch (_custFinancialListCndtnWork.PrintDiv)
                    {
                        case 3:
                            {
                                retstring += " AND CUS.MNGSECTIONCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                                break;
                            }
                        case 4:
                            {
                                retstring += " AND CUS.CLAIMSECTIONCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                                break;
                            }
                        default:
                            {
                    retstring += " AND MTL.ADDUPSECCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                                break;
                            }
                    }
                    //retstring += " AND MTL.ADDUPSECCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                }
            }


            //開始得意先コード
            if (_custFinancialListCndtnWork.St_CustomerCode != 0)
            {
                retstring += " AND MTL.CUSTOMERCODERF>=@STCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@STCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(_custFinancialListCndtnWork.St_CustomerCode);
            }
           
            //終了得意先コード
            if (_custFinancialListCndtnWork.Ed_CustomerCode != 0)
            {
                retstring += " AND MTL.CUSTOMERCODERF<=@EDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@EDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(_custFinancialListCndtnWork.Ed_CustomerCode);
            }

            //年月度
            if (_custFinancialListCndtnWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND MTL.ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_custFinancialListCndtnWork.St_AddUpYearMonth);
            }
            if (_custFinancialListCndtnWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND MTL.ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_custFinancialListCndtnWork.Ed_AddUpYearMonth);
            }
            #endregion
            return retstring;
        }
    }
}

