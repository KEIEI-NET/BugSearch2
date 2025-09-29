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
    /// 過年度統計表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 過年度統計表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2007.12.04</br>
    /// <br></br>
    /// <br>UpdateNote : 返品金額が二重集計されている対応</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2008.04.02</br>
    /// </remarks>
    [Serializable]
    public class PastYearStatisticsDB : RemoteDB, IPastYearStatisticsDB
    {
        /// <summary>
        /// 過年度統計表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.12.04</br>
        /// </remarks>
        public PastYearStatisticsDB()
            :
            base("DCTOK02186D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PastYearStatisticsWork", "CUSTMTTLSALSLIPRF")
        {
        }

        #region [SearchPastYearStatistics]
        /// <summary>
        /// 指定された条件の過年度統計表を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の過年度統計表を戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.12.04</br>
        public int SearchPastYearStatistics(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;
            retObj = null;

            ExtrInfo_PastYearStatisticsWork extrInfo_PastYearStatistics = null;

            ArrayList extrInfo_PastYearStatisticsList = paraObj as ArrayList;
            ArrayList retList = new ArrayList();

            if (extrInfo_PastYearStatisticsList == null)
            {
                extrInfo_PastYearStatistics = paraObj as ExtrInfo_PastYearStatisticsWork;
            }
            else
            {
                if (extrInfo_PastYearStatisticsList.Count > 0)
                    extrInfo_PastYearStatistics = extrInfo_PastYearStatisticsList[0] as ExtrInfo_PastYearStatisticsWork;
            }

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //●暗号化キーOPEN
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTMTTLSALSLIPRF" });
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //●過年度統計表取得
                status = SearchPastYearStatisticsProc(ref retList, extrInfo_PastYearStatistics, ref sqlConnection);

                //STATUS
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PastYearStatisticsDB.SearchPastYearStatistics");
                retObj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                //●暗号化キーCLOSE
                //if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retObj = (object)retList;
            return status;
        }

        /// <summary>
        /// 指定された条件の過年度統計表を戻します
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="extrInfo_PastYearStatistics">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の過年度統計表を戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        private int SearchPastYearStatisticsProc(ref ArrayList retList, ExtrInfo_PastYearStatisticsWork extrInfo_PastYearStatistics, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            if (extrInfo_PastYearStatistics.Ed_AddUpYear - extrInfo_PastYearStatistics.St_AddUpYear >= 8)
            {
                return status;
            }

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            //期首月の取得
            Int32 companyBiginMonth;
            GetCompanyBiginMonth(out companyBiginMonth, extrInfo_PastYearStatistics, ref sqlConnection);

            //営業所別
            string useTable = "MTTLSALESSLIPRF";
            string groupUnit = "GROUP BY TTL.ADDUPSECCODERF, TTL.SECTIONGUIDENMRF ";
            if (extrInfo_PastYearStatistics.ListType == 1)
            {
                //得意先別
                useTable = "CUSTMTTLSALSLIPRF";
                groupUnit = "GROUP BY TTL.ADDUPSECCODERF, TTL.SECTIONGUIDENMRF, TTL.CUSTOMERCODERF, TTL.CUSTOMERSNMRF ";
            }

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //企業コード
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_PastYearStatistics.EnterpriseCode);

                //拠点コード
                string whereSecCust = "";
                if (extrInfo_PastYearStatistics.SecCodeList != null)
                {
                    string sectionString = "";
                    foreach (string sectionCode in extrInfo_PastYearStatistics.SecCodeList)
                    {
                        if (sectionCode != "")
                        {
                            if (sectionString != "") sectionString += ",";
                            sectionString += "'" + sectionCode + "'";
                        }
                    }
                    if (sectionString != "")
                    {
                        whereSecCust = "AND TTL.ADDUPSECCODERF IN (" + sectionString + ") ";
                    }
                }

                //得意先コード
                string whereCustomerCode = "";
                if (extrInfo_PastYearStatistics.ListType == 1)
                {
                    if (extrInfo_PastYearStatistics.St_CustomerCode > 0)
                    {
                        whereCustomerCode += "AND TTL.CUSTOMERCODERF>=@ST_CUSTOMERCODE ";
                        SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE", SqlDbType.Int);
                        paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PastYearStatistics.St_CustomerCode);
                    }
                    if (extrInfo_PastYearStatistics.Ed_CustomerCode > 0)
                    {
                        whereCustomerCode += "AND TTL.CUSTOMERCODERF<=@ED_CUSTOMERCODE ";
                        SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE", SqlDbType.Int);
                        paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PastYearStatistics.Ed_CustomerCode);
                    }
                }

                #region [SQL文]
                sqlCommand.CommandText = "SELECT ";
                string totalUnit = "";
                if (extrInfo_PastYearStatistics.TotalWay == true)
                {
                    sqlCommand.CommandText += "'000000' ADDUPSECCODERF, "
                                            + "'' SECTIONGUIDENMRF, ";
                    totalUnit += "'000000' ADDUPSECCODERF, '' SECTIONGUIDENMRF, ";
                }
                else
                {
                    sqlCommand.CommandText += "ADDUPSECCODERF, "
                                            + "SECTIONGUIDENMRF, ";
                    totalUnit += "TTL.ADDUPSECCODERF, TTL.SECTIONGUIDENMRF, ";
                }
                if (extrInfo_PastYearStatistics.ListType == 1)
                {
                    //得意先別
                    sqlCommand.CommandText += "CUSTOMERCODERF, "
                                            + "CUSTOMERSNMRF, ";
                    totalUnit += "TTL.CUSTOMERCODERF, TTL.CUSTOMERSNMRF, ";
                }
                else
                {
                    //営業所別
                    sqlCommand.CommandText += "0 CUSTOMERCODERF, "
                                            + "'' CUSTOMERSNMRF, ";
                    totalUnit += "0 CUSTOMERCODERF, '' CUSTOMERSNMRF, ";
                }

                if (extrInfo_PastYearStatistics.MoneyUnit == 1)
                {
                    sqlCommand.CommandText += "(SUM(SALESMONEY1RF) + 500) / 1000 SALESMONEY1RF, "
                                            + "(SUM(GROSSMONEY1RF) + 500) / 1000 GROSSMONEY1RF, "
                                            + "(SUM(SALESMONEY2RF) + 500) / 1000 SALESMONEY2RF, "
                                            + "(SUM(GROSSMONEY2RF) + 500) / 1000 GROSSMONEY2RF, "
                                            + "(SUM(SALESMONEY3RF) + 500) / 1000 SALESMONEY3RF, "
                                            + "(SUM(GROSSMONEY3RF) + 500) / 1000 GROSSMONEY3RF, "
                                            + "(SUM(SALESMONEY4RF) + 500) / 1000 SALESMONEY4RF, "
                                            + "(SUM(GROSSMONEY4RF) + 500) / 1000 GROSSMONEY4RF, "
                                            + "(SUM(SALESMONEY5RF) + 500) / 1000 SALESMONEY5RF, "
                                            + "(SUM(GROSSMONEY5RF) + 500) / 1000 GROSSMONEY5RF, "
                                            + "(SUM(SALESMONEY6RF) + 500) / 1000 SALESMONEY6RF, "
                                            + "(SUM(GROSSMONEY6RF) + 500) / 1000 GROSSMONEY6RF, "
                                            + "(SUM(SALESMONEY7RF) + 500) / 1000 SALESMONEY7RF, "
                                            + "(SUM(GROSSMONEY7RF) + 500) / 1000 GROSSMONEY7RF, "
                                            + "(SUM(SALESMONEY8RF) + 500) / 1000 SALESMONEY8RF, "
                                            + "(SUM(GROSSMONEY8RF) + 500) / 1000 GROSSMONEY8RF "
                                            + "FROM ( SELECT ";
                }
                else
                {
                    sqlCommand.CommandText += "SUM(SALESMONEY1RF) SALESMONEY1RF, "
                                            + "SUM(GROSSMONEY1RF) GROSSMONEY1RF, "
                                            + "SUM(SALESMONEY2RF) SALESMONEY2RF, "
                                            + "SUM(GROSSMONEY2RF) GROSSMONEY2RF, "
                                            + "SUM(SALESMONEY3RF) SALESMONEY3RF, "
                                            + "SUM(GROSSMONEY3RF) GROSSMONEY3RF, "
                                            + "SUM(SALESMONEY4RF) SALESMONEY4RF, "
                                            + "SUM(GROSSMONEY4RF) GROSSMONEY4RF, "
                                            + "SUM(SALESMONEY5RF) SALESMONEY5RF, "
                                            + "SUM(GROSSMONEY5RF) GROSSMONEY5RF, "
                                            + "SUM(SALESMONEY6RF) SALESMONEY6RF, "
                                            + "SUM(GROSSMONEY6RF) GROSSMONEY6RF, "
                                            + "SUM(SALESMONEY7RF) SALESMONEY7RF, "
                                            + "SUM(GROSSMONEY7RF) GROSSMONEY7RF, "
                                            + "SUM(SALESMONEY8RF) SALESMONEY8RF, "
                                            + "SUM(GROSSMONEY8RF) GROSSMONEY8RF "
                                            + "FROM ( SELECT ";
                }
                //1年目集計
                string whereMonthRange = MakeMonthRange(extrInfo_PastYearStatistics.St_AddUpYear, 0, companyBiginMonth);
                sqlCommand.CommandText += totalUnit
                                        // ↓ 2008.04.02 980081 c
                                        //+ "SUM(TTL.SALESTOTALTAXEXCRF + TTL.SALESRETGOODSPRICERF) SALESMONEY1RF, "
                                        + "SUM(TTL.SALESTOTALTAXEXCRF) SALESMONEY1RF, "
                                        // ↑ 2008.04.02 980081 c
                                        + "SUM(TTL.GROSSPROFITRF) GROSSMONEY1RF, "
                                        + "CONVERT(BIGINT,0) SALESMONEY2RF, "
                                        + "CONVERT(BIGINT,0) GROSSMONEY2RF, "
                                        + "CONVERT(BIGINT,0) SALESMONEY3RF, "
                                        + "CONVERT(BIGINT,0) GROSSMONEY3RF, "
                                        + "CONVERT(BIGINT,0) SALESMONEY4RF, "
                                        + "CONVERT(BIGINT,0) GROSSMONEY4RF, "
                                        + "CONVERT(BIGINT,0) SALESMONEY5RF, "
                                        + "CONVERT(BIGINT,0) GROSSMONEY5RF, "
                                        + "CONVERT(BIGINT,0) SALESMONEY6RF, "
                                        + "CONVERT(BIGINT,0) GROSSMONEY6RF, "
                                        + "CONVERT(BIGINT,0) SALESMONEY7RF, "
                                        + "CONVERT(BIGINT,0) GROSSMONEY7RF, "
                                        + "CONVERT(BIGINT,0) SALESMONEY8RF, "
                                        + "CONVERT(BIGINT,0) GROSSMONEY8RF "
                                        + "FROM " + useTable + " TTL ";
                sqlCommand.CommandText += "WHERE TTL.ENTERPRISECODERF=@ENTERPRISECODE " + whereSecCust + whereCustomerCode + whereMonthRange + groupUnit;

                //2年目集計
                if (extrInfo_PastYearStatistics.Ed_AddUpYear - extrInfo_PastYearStatistics.St_AddUpYear >= 1)
                {
                    sqlCommand.CommandText += "UNION SELECT ";

                    whereMonthRange = MakeMonthRange(extrInfo_PastYearStatistics.St_AddUpYear, 1, companyBiginMonth);
                    sqlCommand.CommandText += totalUnit
                                            + "CONVERT(BIGINT,0) SALESMONEY1RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY1RF, "
                                            // ↓ 2008.04.02 980081 c
                                            //+ "SUM(TTL.SALESTOTALTAXEXCRF + TTL.SALESRETGOODSPRICERF) SALESMONEY2RF, "
                                            + "SUM(TTL.SALESTOTALTAXEXCRF) SALESMONEY2RF, "
                                            // ↑ 2008.04.02 980081 c
                                            + "SUM(TTL.GROSSPROFITRF) GROSSMONEY2RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY3RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY3RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY4RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY4RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY5RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY5RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY6RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY6RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY7RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY7RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY8RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY8RF "
                                            + "FROM " + useTable + " TTL ";
                    sqlCommand.CommandText += "WHERE TTL.ENTERPRISECODERF=@ENTERPRISECODE " + whereSecCust + whereCustomerCode + whereMonthRange + groupUnit;
                }

                //3年目集計
                if (extrInfo_PastYearStatistics.Ed_AddUpYear - extrInfo_PastYearStatistics.St_AddUpYear >= 2)
                {
                    sqlCommand.CommandText += "UNION SELECT ";

                    whereMonthRange = MakeMonthRange(extrInfo_PastYearStatistics.St_AddUpYear, 2, companyBiginMonth);
                    sqlCommand.CommandText += totalUnit
                                            + "CONVERT(BIGINT,0) SALESMONEY1RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY1RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY2RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY2RF, "
                                            // ↓ 2008.04.02 980081 c
                                            //+ "SUM(TTL.SALESTOTALTAXEXCRF + TTL.SALESRETGOODSPRICERF) SALESMONEY3RF, "
                                            + "SUM(TTL.SALESTOTALTAXEXCRF) SALESMONEY3RF, "
                                            // ↑ 2008.04.02 980081 c
                                            + "SUM(TTL.GROSSPROFITRF) GROSSMONEY3RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY4RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY4RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY5RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY5RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY6RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY6RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY7RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY7RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY8RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY8RF "
                                            + "FROM " + useTable + " TTL ";
                    sqlCommand.CommandText += "WHERE TTL.ENTERPRISECODERF=@ENTERPRISECODE " + whereSecCust + whereCustomerCode + whereMonthRange + groupUnit;
                }

                //4年目集計
                if (extrInfo_PastYearStatistics.Ed_AddUpYear - extrInfo_PastYearStatistics.St_AddUpYear >= 3)
                {
                    sqlCommand.CommandText += "UNION SELECT ";

                    whereMonthRange = MakeMonthRange(extrInfo_PastYearStatistics.St_AddUpYear, 3, companyBiginMonth);
                    sqlCommand.CommandText += totalUnit
                                            + "CONVERT(BIGINT,0) SALESMONEY1RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY1RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY2RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY2RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY3RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY3RF, "
                                            // ↓ 2008.04.02 980081 c
                                            //+ "SUM(TTL.SALESTOTALTAXEXCRF + TTL.SALESRETGOODSPRICERF) SALESMONEY4RF, "
                                            + "SUM(TTL.SALESTOTALTAXEXCRF) SALESMONEY4RF, "
                                            // ↑ 2008.04.02 980081 c
                                            + "SUM(TTL.GROSSPROFITRF) GROSSMONEY4RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY5RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY5RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY6RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY6RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY7RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY7RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY8RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY8RF "
                                            + "FROM " + useTable + " TTL ";
                    sqlCommand.CommandText += "WHERE TTL.ENTERPRISECODERF=@ENTERPRISECODE " + whereSecCust + whereCustomerCode + whereMonthRange + groupUnit;
                }

                //5年目集計
                if (extrInfo_PastYearStatistics.Ed_AddUpYear - extrInfo_PastYearStatistics.St_AddUpYear >= 4)
                {
                    sqlCommand.CommandText += "UNION SELECT ";

                    whereMonthRange = MakeMonthRange(extrInfo_PastYearStatistics.St_AddUpYear, 4, companyBiginMonth);
                    sqlCommand.CommandText += totalUnit
                                            + "CONVERT(BIGINT,0) SALESMONEY1RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY1RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY2RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY2RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY3RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY3RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY4RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY4RF, "
                                            // ↓ 2008.04.02 980081 c
                                            //+ "SUM(TTL.SALESTOTALTAXEXCRF + TTL.SALESRETGOODSPRICERF) SALESMONEY5RF, "
                                            + "SUM(TTL.SALESTOTALTAXEXCRF) SALESMONEY5RF, "
                                            // ↑ 2008.04.02 980081 c
                                            + "SUM(TTL.GROSSPROFITRF) GROSSMONEY5RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY6RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY6RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY7RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY7RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY8RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY8RF "
                                            + "FROM " + useTable + " TTL ";
                    sqlCommand.CommandText += "WHERE TTL.ENTERPRISECODERF=@ENTERPRISECODE " + whereSecCust + whereCustomerCode + whereMonthRange + groupUnit;
                }

                //6年目集計
                if (extrInfo_PastYearStatistics.Ed_AddUpYear - extrInfo_PastYearStatistics.St_AddUpYear >= 5)
                {
                    sqlCommand.CommandText += "UNION SELECT ";

                    whereMonthRange = MakeMonthRange(extrInfo_PastYearStatistics.St_AddUpYear, 5, companyBiginMonth);
                    sqlCommand.CommandText += totalUnit
                                            + "CONVERT(BIGINT,0) SALESMONEY1RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY1RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY2RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY2RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY3RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY3RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY4RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY4RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY5RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY5RF, "
                                            // ↓ 2008.04.02 980081 c
                                            //+ "SUM(TTL.SALESTOTALTAXEXCRF + TTL.SALESRETGOODSPRICERF) SALESMONEY6RF, "
                                            + "SUM(TTL.SALESTOTALTAXEXCRF) SALESMONEY6RF, "
                                            // ↑ 2008.04.02 980081 c
                                            + "SUM(TTL.GROSSPROFITRF) GROSSMONEY6RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY7RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY7RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY8RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY8RF "
                                            + "FROM " + useTable + " TTL ";
                    sqlCommand.CommandText += "WHERE TTL.ENTERPRISECODERF=@ENTERPRISECODE " + whereSecCust + whereCustomerCode + whereMonthRange + groupUnit;
                }

                //7年目集計
                if (extrInfo_PastYearStatistics.Ed_AddUpYear - extrInfo_PastYearStatistics.St_AddUpYear >= 6)
                {
                    sqlCommand.CommandText += "UNION SELECT ";

                    whereMonthRange = MakeMonthRange(extrInfo_PastYearStatistics.St_AddUpYear, 6, companyBiginMonth);
                    sqlCommand.CommandText += totalUnit
                                            + "CONVERT(BIGINT,0) SALESMONEY1RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY1RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY2RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY2RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY3RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY3RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY4RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY4RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY5RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY5RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY6RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY6RF, "
                                            // ↓ 2008.04.02 980081 c
                                            //+ "SUM(TTL.SALESTOTALTAXEXCRF + TTL.SALESRETGOODSPRICERF) SALESMONEY7RF, "
                                            + "SUM(TTL.SALESTOTALTAXEXCRF) SALESMONEY7RF, "
                                            // ↑ 2008.04.02 980081 c
                                            + "SUM(TTL.GROSSPROFITRF) GROSSMONEY7RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY8RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY8RF "
                                            + "FROM " + useTable + " TTL ";
                    sqlCommand.CommandText += "WHERE TTL.ENTERPRISECODERF=@ENTERPRISECODE " + whereSecCust + whereCustomerCode + whereMonthRange + groupUnit;
                }

                //8年目集計
                if (extrInfo_PastYearStatistics.Ed_AddUpYear - extrInfo_PastYearStatistics.St_AddUpYear >= 7)
                {
                    sqlCommand.CommandText += "UNION SELECT ";

                    whereMonthRange = MakeMonthRange(extrInfo_PastYearStatistics.St_AddUpYear, 7, companyBiginMonth);
                    sqlCommand.CommandText += totalUnit
                                            + "CONVERT(BIGINT,0) SALESMONEY1RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY1RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY2RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY2RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY3RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY3RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY4RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY4RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY5RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY5RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY6RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY6RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY7RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY7RF, "
                                            // ↓ 2008.04.02 980081 c
                                            //+ "SUM(TTL.SALESTOTALTAXEXCRF + TTL.SALESRETGOODSPRICERF) SALESMONEY8RF, "
                                            + "SUM(TTL.SALESTOTALTAXEXCRF) SALESMONEY8RF, "
                                            // ↑ 2008.04.02 980081 c
                                            + "SUM(TTL.GROSSPROFITRF) GROSSMONEY8RF "
                                            + "FROM " + useTable + " TTL ";
                    sqlCommand.CommandText += "WHERE TTL.ENTERPRISECODERF=@ENTERPRISECODE " + whereSecCust + whereCustomerCode + whereMonthRange + groupUnit;
                }

                sqlCommand.CommandText += " ) AS UNION_DATA ";

                if (extrInfo_PastYearStatistics.ListType == 1)
                {
                    sqlCommand.CommandText += "GROUP BY UNION_DATA.ADDUPSECCODERF, UNION_DATA.SECTIONGUIDENMRF, UNION_DATA.CUSTOMERCODERF, UNION_DATA.CUSTOMERSNMRF ";
                }
                else
                {
                    sqlCommand.CommandText += "GROUP BY UNION_DATA.ADDUPSECCODERF, UNION_DATA.SECTIONGUIDENMRF ";
                }

                #endregion

                myReader = sqlCommand.ExecuteReader();

                RsltInfo_PastYearStatisticsWork pastYearStatisticsResultWork;
                while (myReader.Read())
                {
                    pastYearStatisticsResultWork = CopyToPastYearStatisticsResultFromReader(ref myReader);
                    retList.Add(pastYearStatisticsResultWork);
                }

                if (retList.Count != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        #endregion

        #region [過年度統計表抽出結果クラス格納処理]
        /// <summary>
        /// 過年度統計表抽出結果クラス格納処理 Reader → RsltInfo_PastYearStatisticsWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RsltInfo_PastYearStatisticsWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        /// </remarks>
        private RsltInfo_PastYearStatisticsWork CopyToPastYearStatisticsResultFromReader(ref SqlDataReader myReader)
        {
            RsltInfo_PastYearStatisticsWork wkRsltInfo_PastYearStatisticsWork = new RsltInfo_PastYearStatisticsWork();

            wkRsltInfo_PastYearStatisticsWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkRsltInfo_PastYearStatisticsWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkRsltInfo_PastYearStatisticsWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkRsltInfo_PastYearStatisticsWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkRsltInfo_PastYearStatisticsWork.SalesMoney1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY1RF"));
            wkRsltInfo_PastYearStatisticsWork.GrossMoney1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSMONEY1RF"));
            wkRsltInfo_PastYearStatisticsWork.SalesMoney2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY2RF"));
            wkRsltInfo_PastYearStatisticsWork.GrossMoney2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSMONEY2RF"));
            wkRsltInfo_PastYearStatisticsWork.SalesMoney3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY3RF"));
            wkRsltInfo_PastYearStatisticsWork.GrossMoney3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSMONEY3RF"));
            wkRsltInfo_PastYearStatisticsWork.SalesMoney4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY4RF"));
            wkRsltInfo_PastYearStatisticsWork.GrossMoney4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSMONEY4RF"));
            wkRsltInfo_PastYearStatisticsWork.SalesMoney5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY5RF"));
            wkRsltInfo_PastYearStatisticsWork.GrossMoney5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSMONEY5RF"));
            wkRsltInfo_PastYearStatisticsWork.SalesMoney6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY6RF"));
            wkRsltInfo_PastYearStatisticsWork.GrossMoney6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSMONEY6RF"));
            wkRsltInfo_PastYearStatisticsWork.SalesMoney7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY7RF"));
            wkRsltInfo_PastYearStatisticsWork.GrossMoney7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSMONEY7RF"));
            wkRsltInfo_PastYearStatisticsWork.SalesMoney8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY8RF"));
            wkRsltInfo_PastYearStatisticsWork.GrossMoney8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSMONEY8RF"));
            return wkRsltInfo_PastYearStatisticsWork;
        }

        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.12.04</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

        #region その他の関数
        /// <summary>
        /// 期首月を求めます
        /// </summary>
        /// <param name="companyBiginMonth">戻り値:期首月</param>
        /// <param name="extrInfo_PastYearStatistics">パラメータクラス</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 期首月を求めます</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        private int GetCompanyBiginMonth(out Int32 companyBiginMonth, ExtrInfo_PastYearStatisticsWork extrInfo_PastYearStatistics, ref SqlConnection sqlConnection)
        {
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            companyBiginMonth = 0;
            try
            {
                sqlCommand = new SqlCommand("SELECT COMPANYBIGINMONTHRF FROM COMPANYINFRF WHERE ENTERPRISECODERF=@ENTERPRISECODE ", sqlConnection);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_PastYearStatistics.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    companyBiginMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYBIGINMONTHRF"));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        /// <summary>
        /// 年度ごとの抽出範囲を求めます
        /// </summary>
        /// <param name="st_Year">開始年</param>
        /// <param name="addYear">加算年</param>
        /// <param name="companyBiginMonth">期首月</param>
        /// <returns>SQL文のWHERE句(年月度)</returns>
        /// <br>Note       : 年度ごとの抽出範囲を求めます</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        private string MakeMonthRange(Int32 st_Year, Int32 addYear, Int32 companyBiginMonth)
        {
            Int32 startYear = st_Year + addYear;
            Int32 startMonth = companyBiginMonth;
            Int32 endYear = st_Year + addYear + 1;
            Int32 endMonth = companyBiginMonth - 1;
            if (companyBiginMonth == 1)
            {
                endYear = st_Year + addYear;
                endMonth = 12;
            }
            return "AND TTL.ADDUPYEARMONTHRF>=" + Convert.ToString(startYear * 100 + startMonth) + " "
                 + "AND TTL.ADDUPYEARMONTHRF<=" + Convert.ToString(endYear * 100 + endMonth) + " ";

        }

        #endregion

    }
}
