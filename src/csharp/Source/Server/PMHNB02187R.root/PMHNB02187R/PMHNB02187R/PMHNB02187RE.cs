using System;
using System.Collections;
using System.Collections.Generic;
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
    class MTtlSaSlipArea : MTtlSaSlipBase, IMTtlSaSlip
    {   

        #region [地区別用 Select文]
        /// <summary>
        /// 地区別用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="ParamWork">検索条件</param>
        /// <returns>地区別用SELECT文</returns>
        /// <br>Note       : 地区別用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.21</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, CustSalesDistributionReportParamWork ParamWork)
        {
            return this.MakeSelectStringProc(ref sqlCommand, ParamWork);
        }
        #endregion  //[地区別用 Select文]

        #region [地区別用 Select文生成処理]
        /// <summary>
        /// 地区別用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="ParamWork">検索条件</param>
        /// <returns>地区別用SELECT文</returns>
        /// <br>Note       : 地区別用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.21</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, CustSalesDistributionReportParamWork ParamWork)
        {

            string selectTxt = "";

            #region [Select文作成]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "   AREA.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   ,SALES.RESULTSADDUPSECCDRF" + Environment.NewLine;
            selectTxt += "   ,SECINF.SECTIONGUIDESNMRF" + Environment.NewLine;
            selectTxt += "   ,AREA.SALESAREACODE" + Environment.NewLine;
            selectTxt += "   ,USERGD.GUIDENAMERF" + Environment.NewLine;
            selectTxt += "   ,SALES.SALESCOUNT " + Environment.NewLine;
            selectTxt += "   ,SALES.SALESMONEY" + Environment.NewLine;
            selectTxt += "   ,SALES.TOTALCOST" + Environment.NewLine;
            selectTxt += "   ,SALES.SALESDATERF" + Environment.NewLine;
            selectTxt += "FROM" + Environment.NewLine;
            selectTxt += "(" + Environment.NewLine;
            if (ParamWork.SearchDiv == 0)
            {
                selectTxt += " SELECT" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,GUIDECODERF AS  SALESAREACODE" + Environment.NewLine;
                selectTxt += " FROM" + Environment.NewLine;
                selectTxt += " USERGDBDURF AS  AREAU" + Environment.NewLine;
                selectTxt += MakeWhereString(ref sqlCommand, ParamWork, "AREAU", 0);
                selectTxt += " AND AREAU.USERGUIDEDIVCDRF=21" + Environment.NewLine;
                selectTxt += " UNION" + Environment.NewLine;
            }

            selectTxt += " SELECT DISTINCT" + Environment.NewLine;
            selectTxt += "  ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  ,SALESAREACODERF AS SALESAREACODE" + Environment.NewLine;
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += "   SALESHISTORYRF AS SALEMP" + Environment.NewLine;
            selectTxt += MakeWhereString(ref sqlCommand, ParamWork, "SALEMP", 1);
            selectTxt += "   AND ACPTANODRSTATUSRF = 30" + Environment.NewLine;
            selectTxt += "   AND (SALESSLIPCDRF = 0 OR SALESSLIPCDRF = 1 )" + Environment.NewLine;
            selectTxt += ") AS AREA" + Environment.NewLine;

            selectTxt += "LEFT JOIN" + Environment.NewLine;
            selectTxt += "(" + Environment.NewLine;
            selectTxt += "  SELECT" + Environment.NewLine;
            selectTxt += "   ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   ,RESULTSADDUPSECCDRF" + Environment.NewLine;
            selectTxt += "   ,SALESAREACODERF" + Environment.NewLine;
            selectTxt += "   ,SALESDATERF" + Environment.NewLine;
            selectTxt += "   ,COUNT(SALESSLIPNUMRF) AS SALESCOUNT " + Environment.NewLine;
            //selectTxt += "   ,SUM(SALESSUBTOTALTAXEXCRF) AS SALESMONEY" + Environment.NewLine;
            selectTxt += "   ,SUM(SALESTOTALTAXEXCRF) AS SALESMONEY" + Environment.NewLine;
            selectTxt += "   ,SUM(TOTALCOSTRF) AS TOTALCOST" + Environment.NewLine;
            selectTxt += "  FROM" + Environment.NewLine;
            selectTxt += "   SALESHISTORYRF AS SALHIS" + Environment.NewLine;
            selectTxt += MakeWhereString(ref sqlCommand, ParamWork, "SALHIS", 1);
            selectTxt += "   AND ACPTANODRSTATUSRF = 30" + Environment.NewLine;
            selectTxt += "   AND (SALESSLIPCDRF = 0 OR SALESSLIPCDRF = 1 )" + Environment.NewLine;
            selectTxt += "  GROUP BY" + Environment.NewLine;
            selectTxt += "   ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   ,RESULTSADDUPSECCDRF" + Environment.NewLine;
            selectTxt += "   ,SALESAREACODERF" + Environment.NewLine;
            selectTxt += "   ,SALESDATERF" + Environment.NewLine;
            selectTxt += ") AS SALES" + Environment.NewLine;
            selectTxt += "ON AREA.ENTERPRISECODERF = SALES.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "AND AREA.SALESAREACODE = SALES.SALESAREACODERF" + Environment.NewLine;

            #region [JOIN]
            selectTxt += "LEFT JOIN SECINFOSETRF AS SECINF" + Environment.NewLine;
            selectTxt += "ON SALES.ENTERPRISECODERF = SECINF.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "AND SALES.RESULTSADDUPSECCDRF = SECINF.SECTIONCODERF" + Environment.NewLine;
            selectTxt += "LEFT" + Environment.NewLine;
            selectTxt += " JOIN USERGDBDURF AS USERGD" + Environment.NewLine;
            selectTxt += " ON AREA.ENTERPRISECODERF=USERGD.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USERGD.USERGUIDEDIVCDRF=21" + Environment.NewLine;
            selectTxt += " AND AREA.SALESAREACODE =USERGD.GUIDECODERF" + Environment.NewLine;
            #endregion  //[JOIN]


            #endregion  //[Select文作成]

            return selectTxt;
        }
        #endregion  //[得意先別用 Select文生成処理]


        #region [地区別集計データ用 Where句 生成処理]
        /// <summary>
        /// 商品別売上月次集計データ用WHERE句 生成処理 (月計用)
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="ParamWork">検索条件</param>
        /// <param name="sGSMSLP">テーブル名略称：商品別売上月次集計データ</param>
        /// <returns>地区別集計データ用WHERE句</returns>
        /// <br>Note       : 地区別売上月次集計データ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.21</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CustSalesDistributionReportParamWork ParamWork, string sGSMSLP,int iMakeDiv)
        {

            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += sGSMSLP + ".ENTERPRISECODERF=@" + sGSMSLP + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sGSMSLP + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(ParamWork.EnterpriseCode);

            //論理削除区分
            retstring += " AND " + sGSMSLP + ".LOGICALDELETECODERF=0 " + Environment.NewLine;

            if (iMakeDiv == 1)
            {
                //拠点コード
                if (ParamWork.SectionCode != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in ParamWork.SectionCode)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        retstring += " AND " + sGSMSLP + ".RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                    }
                    retstring += Environment.NewLine;
                }

                //対象日付
                if (ParamWork.StSalesDate != 0)
                {
                    retstring += " AND " + sGSMSLP + ".SALESDATERF>=@" + sGSMSLP + "SALESDATEST" + Environment.NewLine;
                    SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@" + sGSMSLP + "SALESDATEST", SqlDbType.Int);
                    paraSalesDateSt.Value = SqlDataMediator.SqlSetInt32(ParamWork.StSalesDate);
                }
                if (ParamWork.EdSalesDate != 0)
                {
                    retstring += " AND " + sGSMSLP + ".SALESDATERF<=@" + sGSMSLP + "SALESDATEED" + Environment.NewLine;
                    SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@" + sGSMSLP + "SALESDATEED", SqlDbType.Int);
                    paraSalesDateEd.Value = SqlDataMediator.SqlSetInt32(ParamWork.EdSalesDate);
                }

                //担当者コード
                if (ParamWork.StSalesEmployeeCd != "")
                {
                    retstring += " AND " + sGSMSLP + ".SALESEMPLOYEECDRF>=@" + sGSMSLP + "SALESEMPLOYEECDST" + Environment.NewLine;
                    SqlParameter paraStSalesEmployeeCd = sqlCommand.Parameters.Add("@" + sGSMSLP + "SALESEMPLOYEECDST", SqlDbType.NChar);
                    paraStSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(ParamWork.StSalesEmployeeCd);
                }
                if (ParamWork.EdSalesEmployeeCd != "")
                {
                    retstring += " AND " + sGSMSLP + ".SALESEMPLOYEECDRF<=@" + sGSMSLP + "SALESEMPLOYEECDED" + Environment.NewLine;
                    SqlParameter paraEdSalesEmployeeCd = sqlCommand.Parameters.Add("@" + sGSMSLP + "SALESEMPLOYEECDED", SqlDbType.NChar);
                    paraEdSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(ParamWork.EdSalesEmployeeCd);
                }

                //地区コード
                if (ParamWork.StSalesAreaCode != 0)
                {
                    retstring += " AND " + sGSMSLP + ".SALESAREACODERF>=@" + sGSMSLP + "SALESAREACODEST" + Environment.NewLine;
                    SqlParameter paraStSalesAreaCode = sqlCommand.Parameters.Add("@" + sGSMSLP + "SALESAREACODEST", SqlDbType.Int);
                    paraStSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(ParamWork.StSalesAreaCode);
                }
                if (ParamWork.EdSalesAreaCode != 9999)
                {
                    retstring += " AND " + sGSMSLP + ".SALESAREACODERF<=@" + sGSMSLP + "SALESAREACODEED" + Environment.NewLine;
                    SqlParameter paraEdSalesAreaCode = sqlCommand.Parameters.Add("@" + sGSMSLP + "SALESAREACODEED", SqlDbType.Int);
                    paraEdSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(ParamWork.EdSalesAreaCode);
                }

                //得意先コード
                if (ParamWork.StCustomerCode != 0)
                {
                    retstring += " AND " + sGSMSLP + ".CUSTOMERCODERF>=@" + sGSMSLP + "CUSTOMERCODEST" + Environment.NewLine;
                    SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@" + sGSMSLP + "CUSTOMERCODEST", SqlDbType.Int);
                    paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(ParamWork.StCustomerCode);
                }
                if (ParamWork.EdCustomerCode != 99999999)
                {
                    retstring += " AND " + sGSMSLP + ".CUSTOMERCODERF<=@" + sGSMSLP + "CUSTOMERCODEED" + Environment.NewLine;
                    SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@" + sGSMSLP + "CUSTOMERCODEED", SqlDbType.Int);
                    paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(ParamWork.EdCustomerCode);
                }
            }
            else
            {
                //地区コード
                if (ParamWork.StSalesAreaCode != 0)
                {
                    retstring += " AND " + sGSMSLP + ".GUIDECODERF>=@" + sGSMSLP + "SALESAREACODEST" + Environment.NewLine;
                    SqlParameter paraStSalesAreaCode = sqlCommand.Parameters.Add("@" + sGSMSLP + "SALESAREACODEST", SqlDbType.Int);
                    paraStSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(ParamWork.StSalesAreaCode);
                }
                if (ParamWork.EdSalesAreaCode != 9999)
                {
                    retstring += " AND " + sGSMSLP + ".GUIDECODERF<=@" + sGSMSLP + "SALESAREACODEED" + Environment.NewLine;
                    SqlParameter paraEdSalesAreaCode = sqlCommand.Parameters.Add("@" + sGSMSLP + "SALESAREACODEED", SqlDbType.Int);
                    paraEdSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(ParamWork.EdSalesAreaCode);
                }

            }

　           #endregion  //WHERE文作成

            return retstring;
        }
        #endregion  //[商品別売上月次集計データ用 Where句 生成処理]

        #region [CopyToSalesRsltListResultWorkFromReader処理 呼出]
        /// <summary>
        /// クラス格納処理 Reader → CopyToSalesRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CopyToSalesRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.21</br>
        /// </remarks>
        public CustSalesDistributionReportResultWork CopyToSalesRsltListResultWorkFromReader(ref SqlDataReader myReader, CustSalesDistributionReportParamWork ParamWork)
        {
            return this.CopyToSalesRsltListResultWorkFromReaderProc(ref myReader, ParamWork);
        }
        #endregion  //[CopyToSalesRsltListResultWorkFromReader処理 呼出]

        #region [CopyToSalesRsltListResultWorkFromReader処理]
        /// <summary>
        /// クラス格納処理 Reader → CopyToSalesRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CopyToSalesRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.21</br>
        /// </remarks>
        private CustSalesDistributionReportResultWork CopyToSalesRsltListResultWorkFromReaderProc(ref SqlDataReader myReader, CustSalesDistributionReportParamWork ParamWork)
        {
            #region [抽出結果-値セット]
            CustSalesDistributionReportResultWork ResultWork = new CustSalesDistributionReportResultWork();
            ResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            ResultWork.SecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
            ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            //ResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            //ResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            //ResultWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
            //ResultWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
            ResultWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODE"));
            ResultWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
            ResultWork.SalesCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCOUNT"));
            ResultWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY"));
            ResultWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOST"));
            ResultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            #endregion  //[抽出結果-値セット]

            return ResultWork;
        }
        #endregion //[CopyToSalesRsltListResultWorkFromReader処理]
    }
}
