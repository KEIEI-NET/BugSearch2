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
    class MTtlStSlipEmp : MTtlStSlipBase, IMTtlStSlip
    {
        #region [EmpMTtlStSlip用 Select文生成処理]
        /// <summary>
        /// 担当者別仕入月次集計データ用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件格納クラス</param>
        /// <returns>担当者別仕入月次集計データ用SELECT文</returns>
        /// <br>Note       : 担当者別仕入月次集計データ用SELECT文を作成して戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, StockMonthYearReportParamWork paramWork)
        {
            return MakeSelectStringProc(ref sqlCommand, paramWork);
        }
        /// <summary>
        /// 担当者別仕入月次集計データ用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件格納クラス</param>
        /// <returns>担当者別仕入月次集計データ用SELECT文</returns>
        /// <br>Note       : 担当者別仕入月次集計データ用SELECT文を作成して戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, StockMonthYearReportParamWork paramWork)
        {
            Boolean bSection = false;
            Boolean bSubSect = false;
            Boolean bMinSect = false;
            Boolean bEmployee = false;

            if (paramWork.TtlType != 0)
                bSection = true;
            if (paramWork.TotalType == (int)TotalTypes.n2_Employee)
                bEmployee = true;
            if(paramWork.TotalType ==(int)TotalTypes.n3_SubSection)
            {
                bSection = true;
                if(paramWork.SectionDiv==1)
                    bSubSect=true;
                else if(paramWork.SectionDiv==2)
                {
                    bSubSect=true;
                    bMinSect=true;
                }
            }

            string Text = "";

            Text += "SELECT "
                + IFBy(bSection, "Y.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBy(bSection, "Y.SECTIONGUIDENMRF AS SECTIONGUIDENMRF, ")
                + IFBy(bSubSect, "Y.SUBSECTIONCODERF AS SUBSECTIONCODERF, ")
                + IFBy(bSubSect, "Y.SUBSECTIONNAMERF AS SUBSECTIONNAMERF, ")
                + IFBy(bMinSect, "Y.MINSECTIONCODERF AS MINSECTIONCODERF, ")
                + IFBy(bMinSect, "Y.MINSECTIONNAMERF AS MINSECTIONNAMERF, ")
                + IFBy(bEmployee, "Y.EMPLOYEECODERF AS EMPLOYEECODERF, ")
                + IFBy(bEmployee, "Y.EMPLOYEENAMERF AS EMPLOYEENAMERF, ")
                + "M.MS_TOTALSTOCKCOUNTRF AS MS_TOTALSTOCKCOUNTRF, "
                + "MA.MAS_STOCKTOTALPRICERF AS MS_STOCKTOTALPRICERF, "
                + "MB.MBS_STOCKRETGOODSPRICERF AS MS_STOCKRETGOODSPRICERF, "
                + "M.MS_STOCKTOTALDISCOUNTRF AS MS_STOCKTOTALDISCOUNTRF, "
                + "SUM(Y.TOTALSTOCKCOUNTRF) AS YS_TOTALSTOCKCOUNTRF, "
                + "YA.YAS_STOCKTOTALPRICERF AS YS_STOCKTOTALPRICERF, "
                + "YB.YBS_STOCKRETGOODSPRICERF AS YS_STOCKRETGOODSPRICERF, "
                + "SUM(Y.STOCKTOTALDISCOUNTRF) AS YS_STOCKTOTALDISCOUNTRF "
                + "FROM EMPMTTLSTSLIPRF Y ";

            Text += "LEFT JOIN "
                + "(SELECT "
                + IFBy(bSection, " YA.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBy(bSubSect, " YA.SUBSECTIONCODERF AS SUBSECTIONCODERF, ")
                + IFBy(bMinSect, " YA.MINSECTIONCODERF AS MINSECTIONCODERF, ")
                + IFBy(bEmployee, "YA.EMPLOYEECODERF AS EMPLOYEECODERF, ")
                + "SUM(YA.STOCKTOTALPRICERF) AS YAS_STOCKTOTALPRICERF "
                + "FROM EMPMTTLSTSLIPRF YA "
                + MakeWhereString(ref sqlCommand, paramWork, "YA", TermDiv.YearBound)
                + "AND YA.SUPPLIERSLIPCDRF=10 "     // 仕入
                + "GROUP BY "
                + FirstCommaToSpace(
                      IFBy(bSection, "YA.STOCKSECTIONCDRF ")
                    + IFBy(bSubSect, ", YA.SUBSECTIONCODERF ")
                    + IFBy(bMinSect, ", YA.MINSECTIONCODERF ")
                    + IFBy(bEmployee, ", YA.EMPLOYEECODERF "))
                + ") YA "
                + " ON "
                + FirstANDToSpace(
                      IFBy(bSection, "Y.STOCKSECTIONCDRF=YA.STOCKSECTIONCDRF ")
                    + IFBy(bSubSect, "AND Y.SUBSECTIONCODERF=YA.SUBSECTIONCODERF ")
                    + IFBy(bMinSect, "AND Y.MINSECTIONCODERF=YA.MINSECTIONCODERF ")
                    + IFBy(bEmployee, "AND Y.EMPLOYEECODERF=YA.EMPLOYEECODERF "));

            Text += "LEFT JOIN "
                + "(SELECT "
                + IFBy(bSection, "YB.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBy(bSubSect, " YB.SUBSECTIONCODERF AS SUBSECTIONCODERF, ")
                + IFBy(bMinSect, " YB.MINSECTIONCODERF AS MINSECTIONCODERF, ")
                + IFBy(bEmployee, "YB.EMPLOYEECODERF AS EMPLOYEECODERF, ")
                + "SUM(YB.STOCKRETGOODSPRICERF) AS YBS_STOCKRETGOODSPRICERF "
                + "FROM EMPMTTLSTSLIPRF YB "
                + MakeWhereString(ref sqlCommand, paramWork, "YB", TermDiv.YearBound)
                + "AND YB.SUPPLIERSLIPCDRF=20 "     // 返品
                + "GROUP BY "
                + FirstCommaToSpace(
                      IFBy(bSection, "YB.STOCKSECTIONCDRF ")
                    + IFBy(bSubSect, ", YB.SUBSECTIONCODERF ")
                    + IFBy(bMinSect, ", YB.MINSECTIONCODERF ")
                    + IFBy(bEmployee, ", YB.EMPLOYEECODERF "))
                + ") YB "
                + " ON "
                + FirstANDToSpace(
                      IFBy(bSection, "Y.STOCKSECTIONCDRF=YB.STOCKSECTIONCDRF ")
                    + IFBy(bSubSect, "AND Y.SUBSECTIONCODERF=YB.SUBSECTIONCODERF ")
                    + IFBy(bMinSect, "AND Y.MINSECTIONCODERF=YB.MINSECTIONCODERF ")
                    + IFBy(bEmployee, "AND Y.EMPLOYEECODERF=YB.EMPLOYEECODERF "));

            Text += "LEFT JOIN "
                + "(SELECT "
                + IFBy(bSection, "M.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBy(bSubSect, " M.SUBSECTIONCODERF AS SUBSECTIONCODERF, ")
                + IFBy(bMinSect, " M.MINSECTIONCODERF AS MINSECTIONCODERF, ")
                + IFBy(bEmployee, "M.EMPLOYEECODERF AS EMPLOYEECODERF, ")
                + "SUM(M.TOTALSTOCKCOUNTRF) AS MS_TOTALSTOCKCOUNTRF, "
                + "SUM(M.STOCKTOTALDISCOUNTRF) AS MS_STOCKTOTALDISCOUNTRF "
                + "FROM EMPMTTLSTSLIPRF M "
                + MakeWhereString(ref sqlCommand, paramWork, "M", TermDiv.MonthBound)
                + "GROUP BY "
                + FirstCommaToSpace(
                      IFBy(bSection, "M.STOCKSECTIONCDRF ")
                    + IFBy(bSubSect, ", M.SUBSECTIONCODERF ")
                    + IFBy(bMinSect, ", M.MINSECTIONCODERF ")
                    + IFBy(bEmployee, ", M.EMPLOYEECODERF "))
                + ") M "
                + "ON "
                + FirstANDToSpace(
                      IFBy(bSection, "Y.STOCKSECTIONCDRF=M.STOCKSECTIONCDRF ")
                    + IFBy(bSubSect, "AND Y.SUBSECTIONCODERF=M.SUBSECTIONCODERF ")
                    + IFBy(bMinSect, "AND Y.MINSECTIONCODERF=M.MINSECTIONCODERF ")
                    + IFBy(bEmployee, "AND Y.EMPLOYEECODERF=M.EMPLOYEECODERF "));

            Text += "LEFT JOIN "
                + "(SELECT "
                + IFBy(bSection, "MA.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBy(bSubSect, " MA.SUBSECTIONCODERF AS SUBSECTIONCODERF, ")
                + IFBy(bMinSect, " MA.MINSECTIONCODERF AS MINSECTIONCODERF, ")
                + IFBy(bEmployee, "MA.EMPLOYEECODERF AS EMPLOYEECODERF, ")
                + "SUM(MA.STOCKTOTALPRICERF) AS MAS_STOCKTOTALPRICERF "
                + "FROM EMPMTTLSTSLIPRF MA "
                + MakeWhereString(ref sqlCommand, paramWork, "MA", TermDiv.YearBound)
                + "AND MA.SUPPLIERSLIPCDRF=10 "     // 仕入
                + "GROUP BY "
                + FirstCommaToSpace(
                      IFBy(bSection, "MA.STOCKSECTIONCDRF ")
                    + IFBy(bSubSect, ", MA.SUBSECTIONCODERF ")
                    + IFBy(bMinSect, ", MA.MINSECTIONCODERF ")
                    + IFBy(bEmployee, ", MA.EMPLOYEECODERF "))
                + ") MA "
                + " ON "
                + FirstANDToSpace(
                      IFBy(bSection, "Y.STOCKSECTIONCDRF=MA.STOCKSECTIONCDRF ")
                    + IFBy(bSubSect, "AND Y.SUBSECTIONCODERF=MA.SUBSECTIONCODERF ")
                    + IFBy(bMinSect, "AND Y.MINSECTIONCODERF=MA.MINSECTIONCODERF ")
                    + IFBy(bEmployee, "AND Y.EMPLOYEECODERF=MA.EMPLOYEECODERF "));

            Text += "LEFT JOIN "
                + "(SELECT "
                + IFBy(bSection, "MB.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBy(bSubSect, " MB.SUBSECTIONCODERF AS SUBSECTIONCODERF, ")
                + IFBy(bMinSect, " MB.MINSECTIONCODERF AS MINSECTIONCODERF, ")
                + IFBy(bEmployee, "MB.EMPLOYEECODERF AS EMPLOYEECODERF, ")
                + "SUM(MB.STOCKRETGOODSPRICERF) AS MBS_STOCKRETGOODSPRICERF "
                + "FROM EMPMTTLSTSLIPRF MB "
                + MakeWhereString(ref sqlCommand, paramWork, "MB", TermDiv.YearBound)
                + "AND MB.SUPPLIERSLIPCDRF=20 "     // 返品
                + "GROUP BY "
                + FirstCommaToSpace(
                      IFBy(bSection, "MB.STOCKSECTIONCDRF ")
                    + IFBy(bSubSect, ", MB.SUBSECTIONCODERF ")
                    + IFBy(bMinSect, ", MB.MINSECTIONCODERF ")
                    + IFBy(bEmployee, ", MB.EMPLOYEECODERF "))
                + ") MB "
                + " ON "
                + FirstANDToSpace(
                      IFBy(bSection, "Y.STOCKSECTIONCDRF=MB.STOCKSECTIONCDRF ")
                    + IFBy(bSubSect, "AND Y.SUBSECTIONCODERF=MB.SUBSECTIONCODERF ")
                    + IFBy(bMinSect, "AND Y.MINSECTIONCODERF=MB.MINSECTIONCODERF ")
                    + IFBy(bEmployee, "AND Y.EMPLOYEECODERF=MB.EMPLOYEECODERF "));

            Text += MakeWhereString(ref sqlCommand, paramWork, "Y", TermDiv.YearBound)
                + "GROUP BY "
                + IFBy(bSection, "Y.STOCKSECTIONCDRF, Y.SECTIONGUIDENMRF, ")
                + IFBy(bSubSect, "Y.SUBSECTIONCODERF, Y.SUBSECTIONNAMERF, ")
                + IFBy(bMinSect, "Y.MINSECTIONCODERF, Y.MINSECTIONNAMERF, ")
                + IFBy(bEmployee, "Y.EMPLOYEECODERF, Y.EMPLOYEENAMERF, ")
                + "M.MS_TOTALSTOCKCOUNTRF, MA.MAS_STOCKTOTALPRICERF, MB.MBS_STOCKRETGOODSPRICERF, "
                + "M.MS_STOCKTOTALDISCOUNTRF, "
                + "YA.YAS_STOCKTOTALPRICERF, YB.YBS_STOCKRETGOODSPRICERF "
                + "ORDER BY "
                + FirstCommaToSpace(
                      IFBy(bSection, "Y.STOCKSECTIONCDRF ")
                    + IFBy(bSubSect, ", Y.SUBSECTIONCODERF ")
                    + IFBy(bMinSect, ", Y.MINSECTIONCODERF ")
                    + IFBy(bEmployee, ", Y.EMPLOYEECODERF "));

            return Text;
        }
        #endregion  //[EmpMTtlStSlip用 Select文生成処理]

        #region [EmpMTtlStSlip用 Where句生成処理]
        /// <summary>
        /// 担当者別仕入月次集計データ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件格納クラス</param>
        /// <param name="refName">テーブル名</param>
        /// <param name="termDiv">集計期間区分  0:指定月範囲  1:当期範囲</param>
        /// <returns>担当者別仕入月次集計データ用WHERE句</returns>
        /// <br>Note       : 担当者別仕入月次集計データ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockMonthYearReportParamWork paramWork, string refName, TermDiv termDiv)
        {
            string text = "WHERE ";
            //固定条件
            //企業コード
            text += refName + ".ENTERPRISECODERF=@ENTERPRISECODE ";
            if (sqlCommand.Parameters.IndexOf("@ENTERPRISECODE") < 0)
            {
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);
            }

            //論理削除区分
            //text += "AND " + refName + ".LOGICALDELETECODERF=0 ";

            //これよりパラメータの値により動的変化の項目
            //拠点コード
            if (paramWork.TotalType==(int)TotalTypes.n3_SubSection )
            {
                if (paramWork.SectionCodeSt != "")
                    text += "AND " + refName + ".STOCKSECTIONCDRF>='" + paramWork.SectionCodeSt + "' ";
                if (paramWork.SectionCodeEd != "")
                    text += "AND " + refName + ".STOCKSECTIONCDRF<='" + paramWork.SectionCodeEd + "' ";
                if (paramWork.SectionDiv == (int)SectDiv.n1_SubSection || paramWork.SectionDiv == (int)SectDiv.n2_MinSection)
                {
                    if(paramWork.SubSectionCodeSt!=0)
                        text += "AND " + refName + ".SUBSECTIONCODERF>=" + paramWork.SubSectionCodeSt.ToString() + " ";
                    if (paramWork.SubSectionCodeEd != 0)
                        text += "ANE " + refName + ".SUBSECTIONCODERF<=" + paramWork.SubSectionCodeEd.ToString() + " ";
                }
                if (paramWork.SectionDiv == (int)SectDiv.n2_MinSection)
                {
                    if (paramWork.MinSectionCodeSt != 0)
                        text += "AND " + refName + ".MINSECTIONCODERF>=" + paramWork.MinSectionCodeSt.ToString() + " ";
                    if (paramWork.MinSectionCodeEd != 0)
                        text += "AND " + refName + ".MINSECTIONCODERF<=" + paramWork.MinSectionCodeEd.ToString() + " ";
                }
            }
            else
            {
                if (paramWork.TtlType != 0)
                {
                    //拠点別集計の場合（全社集計でない場合）
                    if (paramWork.SectionCodes != null &&
                        paramWork.SectionCodes.Length > 0)
                    {
                        if (paramWork.SectionCodes[0] != null &&
                            paramWork.SectionCodes[0] != "")
                        {
                            text += "AND " + refName + ".STOCKSECTIONCDRF IN (";
                            text += "'" + paramWork.SectionCodes[0].ToString() + "'";
                            for (int i = 1; i < paramWork.SectionCodes.Length; i++)
                            {
                                if (paramWork.SectionCodes[i] == null)
                                    break;
                                text += ", '" + paramWork.SectionCodes[i].ToString() + "'";
                            }
                            text += ") ";
                        }
                    }
                }
            }

            switch (termDiv)
            {
                case TermDiv.MonthBound:     // 指定月範囲

                    if (paramWork.StockDateYmSt != DateTime.MinValue)
                    {
                        int addupYMSt = TDateTime.DateTimeToLongDate("YYYYMM", paramWork.StockDateYmSt);
                        text += " AND " + refName + ".STOCKDATEYMRF>=" + addupYMSt.ToString() + " ";
                    }
                    if (paramWork.StockDateYmEd != DateTime.MinValue)
                    {
                        if (paramWork.StockDateYmSt == DateTime.MinValue)
                        {
                            text += " AND (" + refName + ".STOCKDATEYMRF IS NULL OR";
                        }
                        else
                        {
                            text += " AND";
                        }

                        int addupYMEd = TDateTime.DateTimeToLongDate("YYYYMM", paramWork.StockDateYmEd);
                        text += " " + refName + ".STOCKDATEYMRF<=" + addupYMEd.ToString() + " ";

                        if (paramWork.StockDateYmSt == DateTime.MinValue)
                        {
                            text += " ) ";
                        }
                    }
                    break;
                case TermDiv.YearBound:     // 期範囲
                    if (paramWork.AnnualStockDateYmSt != DateTime.MinValue)
                    {
                        int addupYMSt = TDateTime.DateTimeToLongDate("YYYYMM", paramWork.AnnualStockDateYmSt);
                        text += " AND " + refName + ".STOCKDATEYMRF>=" + addupYMSt.ToString() + " ";
                    }
                    if (paramWork.AnnualStockDateYmEd != DateTime.MinValue)
                    {
                        if (paramWork.AnnualStockDateYmSt == DateTime.MinValue)
                        {
                            text += " AND (" + refName + ".STOCKDATEYMRF IS NULL OR";
                        }
                        else
                        {
                            text += " AND";
                        }

                        int addupYMEd = TDateTime.DateTimeToLongDate("YYYYMM", paramWork.AnnualStockDateYmEd);
                        text += " " + refName + ".STOCKDATEYMRF<=" + addupYMEd.ToString() + " ";

                        if (paramWork.AnnualStockDateYmSt == DateTime.MinValue)
                        {
                            text += " ) ";
                        }
                    }
                    break;
                default:
                    break;
            }

            //開始従業員コード
            if (paramWork.EmployeeCodeSt != "")
            {
                text += "AND " + refName + ".EMPLOYEECODERF>=@ST_EMPLOYEECODE ";
                if (sqlCommand.Parameters.IndexOf("@ST_EMPLOYEECODE") < 0)
                {
                    SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@ST_EMPLOYEECODE", SqlDbType.NChar);
                    paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(paramWork.EmployeeCodeSt);
                }
            }

            //終了従業員コード
            if (paramWork.EmployeeCodeEd != "")
            {
                text += "AND " + refName + ".EMPLOYEECODERF<=@ED_EMPLOYEECODE ";
                if (sqlCommand.Parameters.IndexOf("@ED_EMPLOYEECODE") < 0)
                {
                    SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@ED_EMPLOYEECODE", SqlDbType.NChar);
                    paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(paramWork.EmployeeCodeEd);
                }
            }

            return text;
        }
        #endregion //[EmpMTtlStSlip用 Where句生成処理]

        #region [CopyToSalesRsltListResultWorkFromReader処理]
        /// <summary>
        /// クラス格納処理 Reader → CopyToSalesRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">検索条件格納クラス</param>
        /// <returns>CopyToSalesRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public StockMonthYearReportResultWork CopyToResultWorkFromReader(ref SqlDataReader myReader, StockMonthYearReportParamWork paramWork)
        {
            return CopyToResultWorkFromReaderProc(ref myReader, paramWork);
        }
        /// <summary>
        /// クラス格納処理 Reader → CopyToSalesRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">検索条件格納クラス</param>
        /// <returns>CopyToSalesRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private StockMonthYearReportResultWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, StockMonthYearReportParamWork paramWork)
        {
            StockMonthYearReportResultWork resultWork = new StockMonthYearReportResultWork();

            if (paramWork.TtlType != 0)
            {
                resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                resultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            }
            if (paramWork.TotalType==(int)TotalTypes.n3_SubSection)
            {
                if (paramWork.SectionDiv == (int)SectDiv.n1_SubSection || paramWork.SectionDiv == (int)SectDiv.n2_MinSection)
                {
                    resultWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    resultWork.SubSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSECTIONNAMERF"));
                }
                if (paramWork.SectionDiv == (int)SectDiv.n2_MinSection)
                {
                    resultWork.MinSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MINSECTIONCODERF"));
                    resultWork.MinSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MINSECTIONNAMERF"));
                }
            }

            if (paramWork.TotalType == (int)TotalTypes.n2_Employee)
            {
                resultWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                resultWork.EmployeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEENAMERF"));
            }

            resultWork.MonthTotalStockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MS_TOTALSTOCKCOUNTRF"));
            resultWork.MonthStockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MS_STOCKTOTALPRICERF"));
            resultWork.MonthStockRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MS_STOCKRETGOODSPRICERF"));
            resultWork.MonthStockTotalDiscount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MS_STOCKTOTALDISCOUNTRF"));

            resultWork.AnnualTotalStockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("YS_TOTALSTOCKCOUNTRF"));
            resultWork.AnnualStockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YS_STOCKTOTALPRICERF"));
            resultWork.AnnualStockRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YS_STOCKRETGOODSPRICERF"));
            resultWork.AnnualStockTotalDiscount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YS_STOCKTOTALDISCOUNTRF"));

            return resultWork;
        }
        #endregion //[CopyToSalesRsltListResultWorkFromReader処理]

    }
}

