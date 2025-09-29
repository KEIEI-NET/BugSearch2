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
    class MTtlSaSlipEmp : MTtlSaSlipBase, IMTtlSaSlip
    {
        Boolean bSection = false;

        #region [Emp用 Select文生成処理]
        /// <summary>
        /// 売上年間実績データ用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件格納クラス</param>
        /// <returns>売上年間実績データ用SELECT文</returns>
        /// <br>Note       : 売上年間実績データ用SELECT文を作成して戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br>Update Note: 2010/08/25、2010/09/10 chenyd</br>
        /// <br>            ・障害ID:13278 テキスト出力対応</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalesAnnualDataSelectParamWork paramWork, int paratotalDiv)
        {
            if (paramWork.SectionCode != "")
                bSection = true;
            string Text = "";
            
            // 修正 2008/09/22 >>>
            #region 修正前
            /*
            Text += "SELECT "
                + "ID.YEARMONTH AS YEARMONTH, "
                + "SL.SALESORDERDIVCDRF AS SALESORDERDIVCD, "
                + "SL.GOODSKINDCODERF AS GOODSKINDCODE, "
                + "SL.SUM_SALESTOTALTAXEXC AS SUM_SALESTOTALTAXEXC, "
                + "SL.SUM_SALESRETGOODSPRICE AS SUM_SALESRETGOODSPRICE, "
                + "SL.SUM_DISCOUNTPRICE AS SUM_DISCOUNTPRICE, "
                + "SL.SUM_GROSSPROFIT AS SUM_GROSSPROFIT, "
                + "ET.T_SALESTARGETMONEYRF AS SUM_SALESTARGETMONEY, "
                + "ET.T_SALESTARGETPROFITRF AS SUM_SALESTARGETPROFIT "
                + "FROM "
                + "(SELECT DISTINCT ADDUPYEARMONTHRF AS YEARMONTH FROM EMPMTTLSASLIPRF "
                + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Slip)
                + "UNION "
                + "SELECT DISTINCT CAST(TARGETDIVIDECODERF AS INT) AS YEARMONTH FROM EMPSALESTARGETRF "
                + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Target)
                + ") ID ";
            Text += "LEFT JOIN "
                + "(SELECT "
                + "ENTERPRISECODERF AS ENTERPRISECODERF, "
                + IFBy(bSection, "ADDUPSECCODERF AS ADDUPSECCODERF, ")
                + "ADDUPYEARMONTHRF AS ADDUPYEARMONTHRF, "
                + "SALESORDERDIVCDRF AS SALESORDERDIVCDRF, "
                + "GOODSKINDCODERF AS GOODSKINDCODERF, "
                + "SUM(SALESTOTALTAXEXCRF) AS SUM_SALESTOTALTAXEXC, "
                + "SUM(SALESRETGOODSPRICERF) AS SUM_SALESRETGOODSPRICE, "
                + "SUM(DISCOUNTPRICERF) AS SUM_DISCOUNTPRICE, "
                + "SUM(GROSSPROFITRF) AS SUM_GROSSPROFIT "
                + "FROM "
                + "EMPMTTLSASLIPRF "	        //担当者別売上月次集計データ
                + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Slip)
                + "GROUP BY "
                + "ENTERPRISECODERF "
                + IFBy(bSection, ", ADDUPSECCODERF ")
                + ", ADDUPYEARMONTHRF "
                + ", SALESORDERDIVCDRF "
                + ", GOODSKINDCODERF "
                + ") SL "
                + "ON ID.YEARMONTH=SL.ADDUPYEARMONTHRF ";
            */ 
            #endregion
            // --- ADD 2010/09/10 -------------------------------->>>>>
            if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
            {
               Text += "SELECT " + Environment.NewLine
                + "A.YEARMONTH AS YEARMONTH, " + Environment.NewLine;
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += "A.EMPLOYEECODERF AS EMPLOYEECODERF, " + Environment.NewLine;
                    Text += "A.ENTERPRISECODERF, " + Environment.NewLine;
                }
                Text += "A.RSLTTTLDIVCDRF AS RSLTTTLDIVCDRF," + Environment.NewLine                // 実績集計区分( 0:部品合計1:在庫2:純正3:作業 )
                    + "A.SUM_SALESMONEYRF, " + Environment.NewLine               // 売上金額(税抜　返品/値引は含まない)
                    + "A.SUM_SALESRETGOODSPRICE, " + Environment.NewLine
                    + "A.SUM_DISCOUNTPRICE, " + Environment.NewLine
                    + "A.SUM_GROSSPROFIT, " + Environment.NewLine
                    + "A.SUM_SALESTIMESRF, " + Environment.NewLine
                    + "A.SUM_SALESTARGETMONEY, " + Environment.NewLine
                    + "A.SUM_SALESTARGETPROFIT " + Environment.NewLine;

                Text += "FROM ( " + Environment.NewLine;
            }
            // --- ADD 2010/09/10 --------------------------------<<<<<
            Text += "SELECT " + Environment.NewLine
                + "ID.YEARMONTH AS YEARMONTH, " + Environment.NewLine;
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += "ID.EMPLOYEECODERF AS EMPLOYEECODERF, " + Environment.NewLine;
                    // --- ADD 2010/09/10 -------------------------------->>>>>
                    Text += "ID.ENTERPRISECODERF, " + Environment.NewLine;
                    // --- ADD 2010/09/10 --------------------------------<<<<<
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                Text += "SL.RSLTTTLDIVCDRF AS RSLTTTLDIVCDRF," + Environment.NewLine                // 実績集計区分( 0:部品合計1:在庫2:純正3:作業 )
                    + "SUM(SL.SUM_SALESMONEYRF) AS SUM_SALESMONEYRF, " + Environment.NewLine               // 売上金額(税抜　返品/値引は含まない)
                    + "SUM(SL.SUM_SALESRETGOODSPRICE) AS SUM_SALESRETGOODSPRICE, " + Environment.NewLine
                    + "SUM(SL.SUM_DISCOUNTPRICE) AS SUM_DISCOUNTPRICE, " + Environment.NewLine
                    + "SUM(SL.SUM_GROSSPROFIT) AS SUM_GROSSPROFIT, " + Environment.NewLine
                    + "SUM(SL.SUM_SALESTIMESRF) AS SUM_SALESTIMESRF, " + Environment.NewLine
                    + "ET.T_SALESTARGETMONEYRF AS SUM_SALESTARGETMONEY, " + Environment.NewLine
                    + "ET.T_SALESTARGETPROFITRF AS SUM_SALESTARGETPROFIT " + Environment.NewLine
                    + "FROM " + Environment.NewLine
                //+ "(SELECT DISTINCT ADDUPYEARMONTHRF AS YEARMONTH FROM MTTLSALESSLIPRF " + Environment.NewLine
                + "(SELECT DISTINCT ADDUPYEARMONTHRF AS YEARMONTH  " + Environment.NewLine;
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += ",  EMPLOYEECODERF AS EMPLOYEECODERF " + Environment.NewLine;
                    // --- ADD 2010/09/10 -------------------------------->>>>>
                    Text += ",  ENTERPRISECODERF " + Environment.NewLine;
                    // --- ADD 2010/09/10 --------------------------------<<<<<
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                Text += " FROM MTTLSALESSLIPRF " + Environment.NewLine
                    + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Slip, 0);
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += " AND  EMPLOYEECODERF != '    '  " + Environment.NewLine;
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                Text += "UNION " + Environment.NewLine
                        //+ "SELECT DISTINCT CAST(TARGETDIVIDECODERF AS INT) AS YEARMONTH FROM EMPSALESTARGETRF " + Environment.NewLine
                    + "SELECT DISTINCT CAST(TARGETDIVIDECODERF AS INT) AS YEARMONTH  " + Environment.NewLine;
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += ",  EMPLOYEECODERF AS EMPLOYEECODERF " + Environment.NewLine;
                    // --- ADD 2010/09/10 -------------------------------->>>>>
                    Text += ",  ENTERPRISECODERF " + Environment.NewLine;
                    // --- ADD 2010/09/10 --------------------------------<<<<<
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                Text += " FROM EMPSALESTARGETRF " + Environment.NewLine
                    + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Target,0)
                    + ") ID " + Environment.NewLine;

                Text += "LEFT JOIN " + Environment.NewLine
                    + "(SELECT " + Environment.NewLine
                    + "ENTERPRISECODERF AS ENTERPRISECODERF, " + Environment.NewLine;               // 企業コード
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += " EMPLOYEECODERF AS EMPLOYEECODERF, " + Environment.NewLine;
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                Text += IFBy(bSection, "ADDUPSECCODERF AS ADDUPSECCODERF, ")                          // 計上拠点
                    + "ADDUPYEARMONTHRF AS ADDUPYEARMONTHRF, " + Environment.NewLine                // 計上年月
                    + "RSLTTTLDIVCDRF AS RSLTTTLDIVCDRF," + Environment.NewLine                     // 実績集計区分( 0:部品合計1:在庫2:純正3:作業 )
                    + "SUM(SALESMONEYRF) AS SUM_SALESMONEYRF, " + Environment.NewLine               // 売上金額(税抜　返品/値引は含まない)
                    + "SUM(SALESRETGOODSPRICERF) AS SUM_SALESRETGOODSPRICE, " + Environment.NewLine // 返品額
                    + "SUM(DISCOUNTPRICERF) AS SUM_DISCOUNTPRICE, " + Environment.NewLine           // 値引金額
                    + "SUM(GROSSPROFITRF) AS SUM_GROSSPROFIT, " + Environment.NewLine               // 粗利金額
                    + "SUM(SALESTIMESRF) AS SUM_SALESTIMESRF " + Environment.NewLine                // 売上回数
                    + "FROM " + Environment.NewLine
                    + "MTTLSALESSLIPRF " + Environment.NewLine	                                    //売上月次集計データ
                    + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Slip, 0)
                    + "GROUP BY " + Environment.NewLine
                    + "ENTERPRISECODERF " + Environment.NewLine;// 企業コード
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += " ,EMPLOYEECODERF " + Environment.NewLine;
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                Text += IFBy(bSection, ", ADDUPSECCODERF ")                                           // 計上拠点
                    + ", ADDUPYEARMONTHRF " + Environment.NewLine                                   // 計上年月
                    + ", RSLTTTLDIVCDRF " + Environment.NewLine                                     // 実績集計区分( 0:部品合計1:在庫2:純正3:作業 )
                    + ") SL " + Environment.NewLine
                    + "ON ID.YEARMONTH=SL.ADDUPYEARMONTHRF " + Environment.NewLine;
                // 修正 2008/09/22 <<<
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += " AND ID.EMPLOYEECODERF=SL.EMPLOYEECODERF " + Environment.NewLine;
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                Text += "LEFT JOIN " + Environment.NewLine
                    + "(SELECT " + Environment.NewLine
                    + "ENTERPRISECODERF AS ENTERPRISECODERF, " + Environment.NewLine;
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += " EMPLOYEECODERF AS EMPLOYEECODERF, " + Environment.NewLine;
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                //+ IFBy(bSection, "SECTIONCODERF AS SECTIONCODERF, ") + Environment.NewLine
                Text += "CAST(TARGETDIVIDECODERF AS INT) AS TARGETDIVIDECODE, " + Environment.NewLine
                    + "SUM(SALESTARGETMONEYRF) AS T_SALESTARGETMONEYRF, " + Environment.NewLine
                    + "SUM(SALESTARGETPROFITRF) AS T_SALESTARGETPROFITRF " + Environment.NewLine
                    + "FROM EMPSALESTARGETRF " + Environment.NewLine;      //従業員別売上目標設定マスタ
                if (paramWork.TotalDiv == (int)TotalDivs.Section) 
                {
                    paramWork.EmployeeDivCd = 0;
                }
                Text += MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Target, 0)
                   + IFBy(paramWork.TotalDiv == (int)TotalDivs.Section, "AND TARGETCONTRASTCDRF=10 ")		// 10:拠点
                    //+ IFBy(paramWork.TotalDiv == (int)TotalDivs.SubSect, "AND TARGETCONTRASTCDRF=20 ")	// 20:拠点+部門
                    //+ IFBy(paramWork.TotalDiv == (int)TotalDivs.MinSect, "AND TARGETCONTRASTCDRF=21 ")	// 21:拠点+部門+課
                   + IFBy(paramWork.TotalDiv == (int)TotalDivs.SalesEmp, "AND TARGETCONTRASTCDRF=22 ")	    // 22:拠点+従業員
                    //+ IFBy(paramWork.TotalDiv == (int)TotalDivs.SalesEmp, "AND EMPLOYEEDIVCDRF=10 ")	    // 10:販売担当者
                   + "GROUP BY " + Environment.NewLine
                   + "ENTERPRISECODERF " + Environment.NewLine;
                 //+ IFBy(bSection, " , SECTIONCODERF ") + Environment.NewLine
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += " ,EMPLOYEECODERF " + Environment.NewLine;
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                Text += ", TARGETDIVIDECODERF " + Environment.NewLine
                    + ") ET " + Environment.NewLine
                    + "ON ID.YEARMONTH=ET.TARGETDIVIDECODE "+ Environment.NewLine;
             // --- ADD 2010/08/25 -------------------------------->>>>>
             if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
             {
                 Text += " AND ID.EMPLOYEECODERF=ET.EMPLOYEECODERF " + Environment.NewLine;
             }
             if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
             {
                 // --- UPD 2010/09/10 -------------------------------->>>>>
                 Text += " GROUP BY ID.YEARMONTH,ID.EMPLOYEECODERF, ID.ENTERPRISECODERF, SL.RSLTTTLDIVCDRF,ET.T_SALESTARGETMONEYRF,ET.T_SALESTARGETPROFITRF" + Environment.NewLine;
                 Text += " ) AS A " + Environment.NewLine;
                 Text += " INNER JOIN EMPLOYEERF ON " + Environment.NewLine;
                 Text += " EMPLOYEERF.ENTERPRISECODERF = A. ENTERPRISECODERF " + Environment.NewLine;
                 Text += " AND EMPLOYEERF.EMPLOYEECODERF = A. EMPLOYEECODERF " + Environment.NewLine;
                 Text += " AND EMPLOYEERF.LOGICALDELETECODERF = 0 " + Environment.NewLine;

                 //Text += "ORDER BY ID.EMPLOYEECODERF,ID.YEARMONTH, SL.RSLTTTLDIVCDRF " + Environment.NewLine;
                 Text += "ORDER BY A.EMPLOYEECODERF,A.YEARMONTH, A.RSLTTTLDIVCDRF " + Environment.NewLine;
                 // --- UPD 2010/09/10 --------------------------------<<<<<
             }
             else
             {
                 // --- ADD 2010/08/25 --------------------------------<<<<<
                 Text += "GROUP BY ID.YEARMONTH,SL.RSLTTTLDIVCDRF,ET.T_SALESTARGETMONEYRF,ET.T_SALESTARGETPROFITRF" + Environment.NewLine;
                 Text += "ORDER BY ID.YEARMONTH, SL.RSLTTTLDIVCDRF " + Environment.NewLine;
             }
             
            return Text;
        }
        #endregion  //[Emp用 Select文生成処理]

        #region [Emp用 Where句生成処理]
        /// <summary>
        /// 売上年間実績データ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="shipmentListParamWork">検索条件格納クラス</param>
        /// <returns>売上年間実績データ用WHERE句</returns>
        /// <br>Note       : 売上年間実績データ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br>Update Note: 2010/08/25 chenyd</br>
        /// <br>            ・障害ID:13278 テキスト出力対応</br>
        public string MakeWhereString(ref SqlCommand sqlCommand, SalesAnnualDataSelectParamWork paramWork, string prefName,
            SlipTargetDiv slipTargetDiv, int SubSlip)
        {

            string refName = prefName;
            if (prefName != "")
                refName += ".";

            string text = "WHERE " + Environment.NewLine;
            //固定条件
            //企業コード
            text += refName + "ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine;
            if (sqlCommand.Parameters.IndexOf("@ENTERPRISECODE") < 0)
            {
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);
            }
            //論理削除区分
            //text += "AND " + refName + ".LOGICALDELETECODERF=0 ";

            //これよりパラメータの値により動的変化の項目
            //拠点コード
            string secCode = "ADDUPSECCODERF";
            if (slipTargetDiv == SlipTargetDiv.Target)
                secCode = "SECTIONCODERF";

            // 修正 2008/09/22 拠点コード'00'は全拠点に変更 >>>
            #region 修正前
            //if (paramWork.SectionCode!=null && paramWork.SectionCode != "")
            //{
            //    text += "AND " + refName + secCode + "='" + paramWork.SectionCode + "' ";
            //}
            #endregion
            if (paramWork.SectionCode != null && paramWork.SectionCode != "" && paramWork.SectionCode != "00")
            {
                text += "AND " + refName + secCode + "='" + paramWork.SectionCode + "' " + Environment.NewLine;
            }
            // --- ADD 2010/09/20 ---------->>>>>
            else
            {
                text += "AND " + refName + secCode + " IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)" + Environment.NewLine;
            }
            // --- ADD 2010/09/20 ----------<<<<<
            // 修正 2008/09/22 <<<
            if (slipTargetDiv == SlipTargetDiv.Slip)
            {
                // この形式は、売上年間実績データ系を対象としています。
                if (paramWork.YearMonthSt != 0)
                {
                    text += "AND " + refName + "ADDUPYEARMONTHRF>=" + paramWork.YearMonthSt.ToString() + " " + Environment.NewLine;
                }
                if (paramWork.YearMonthEd != 0)
                {
                    text += "AND " + refName + "ADDUPYEARMONTHRF<=" + paramWork.YearMonthEd.ToString() + " " + Environment.NewLine;
                }
            }

            if (slipTargetDiv == SlipTargetDiv.Target)
            {
                // この形式は売上目標設定マスタ系を対象としています。
                text += "AND " + refName + "TARGETSETCDRF=10 ";        //目標設定区分 10:月間目標
                if (paramWork.YearMonthSt != 0)
                {
                    text += "AND " + refName + "TARGETDIVIDECODERF>='" + paramWork.YearMonthSt.ToString() + "' " + Environment.NewLine;
                }
                if (paramWork.YearMonthEd != 0)
                {
                    text += "AND " + refName + "TARGETDIVIDECODERF<='" + paramWork.YearMonthEd.ToString() + "' " + Environment.NewLine;
                }
            }
            // --- ADD 2010/08/25 -------------------------------->>>>>
            //従業員コード
            if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
            {
                if (paramWork.St_SelectionCode != "")
                {
                    text += "AND " + refName + "EMPLOYEECODERF >=@EMPLOYEECODE " + Environment.NewLine;
                    if (sqlCommand.Parameters.IndexOf("@EMPLOYEECODE") < 0)
                    {
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        paraEmployeeCode.Value = SqlDataMediator.SqlSetString(paramWork.St_SelectionCode);
                    }
                }
                if (paramWork.Ed_SelectionCode != "")
                {
                    text += "AND " + refName + "EMPLOYEECODERF <=@EMPLOYEECODEED " + Environment.NewLine;
                    if (sqlCommand.Parameters.IndexOf("@EMPLOYEECODEED") < 0)
                    {
                        SqlParameter paraEmployeeCodeed = sqlCommand.Parameters.Add("@EMPLOYEECODEED", SqlDbType.NChar);
                        paraEmployeeCodeed.Value = SqlDataMediator.SqlSetString(paramWork.Ed_SelectionCode);
                    }
                }
                text += "AND EMPLOYEECODERF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)" + Environment.NewLine; // ADD 2010/09/20
            }
            // --- ADD 2010/08/25 --------------------------------<<<<<
            else if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp) 
            {
                if (paramWork.EmployeeCode != "")
                {
                    text += "AND " + refName + "EMPLOYEECODERF=@EMPLOYEECODE " + Environment.NewLine;
                    if (sqlCommand.Parameters.IndexOf("@EMPLOYEECODE") < 0)
                    {
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        paraEmployeeCode.Value = SqlDataMediator.SqlSetString(paramWork.EmployeeCode);
                    }
                }
            }
            //従業員区分
            if (paramWork.EmployeeDivCd > 0)
            {
                text += "AND " + refName + "EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD " + Environment.NewLine;
                if (sqlCommand.Parameters.IndexOf("@EMPLOYEEDIVCD") < 0)
                {
                    SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);

                    //if ((paramWork.TotalDiv == (int)TotalDivs.Section) && (i == 3)) 
                    //{
                    //    paraEmployeeDivCd.Value = 0;
                    //}
                    //else
                    //{
                        paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(paramWork.EmployeeDivCd);
                    //}
                }

            }
            //i++;
            return text;

        }
        #endregion //[Emp用 Where句生成処理]

        #region [CopyToResultWorkFromReader処理]
        /// <summary>
        /// クラス格納処理 Reader → CopyToSalesAnnualDataSelectResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesAnnualDataSelectResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public SalesAnnualDataSelectResultWork CopyToResultWorkFromReader(ref SqlDataReader myReader, SalesAnnualDataSelectParamWork paramWork)
        {
            // 修正 2008/09/22 >>>
            #region 修正前
            /*
            resultWork.AUPYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("YEARMONTH"));
            resultWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCD"));
            resultWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODE"));
            resultWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_SALESTOTALTAXEXC"));
            resultWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_SALESRETGOODSPRICE"));
            resultWork.DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_DISCOUNTPRICE"));
            resultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_GROSSPROFIT"));
            resultWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_SALESTARGETMONEY"));
            resultWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_SALESTARGETPROFIT"));
            */ 
            #endregion
            SalesAnnualDataSelectResultWork resultWork = new SalesAnnualDataSelectResultWork();
            resultWork.AUPYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("YEARMONTH"));                      // 計上年月
            resultWork.RsltTtlDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RSLTTTLDIVCDRF"));                 // 実績集計区分( 0:部品合計1:在庫2:純正3:作業 )
            resultWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_SALESMONEYRF"));                 // 売上金額(税抜　返品/値引は含まない)
            resultWork.SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUM_SALESTIMESRF"));                 // 売上回数   
            resultWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_SALESRETGOODSPRICE"));   // 返品額
            resultWork.DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_DISCOUNTPRICE"));             // 値引金額
            resultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_GROSSPROFIT"));                 // 粗利額
            resultWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_SALESTARGETMONEY"));       // 売上目標額
            resultWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_SALESTARGETPROFIT"));     // 粗利目標額
            //resultWork.TermSalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(""));         // 期間伝票枚数 ★
            // --- ADD 2010/08/25 -------------------------------->>>>>
            if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
            {
                resultWork.SelectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            }
            // --- ADD 2010/08/25 --------------------------------<<<<<
            // 修正 2008/09/22 <<<
            return resultWork;
        }
        #endregion //[CopyToResultWorkFromReader処理]

    }
}
