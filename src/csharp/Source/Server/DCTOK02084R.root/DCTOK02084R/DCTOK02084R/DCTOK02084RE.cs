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
        /// <param name="cndtnWork">検索条件格納クラス</param>
        /// <returns>担当者別仕入月次集計データ用SELECT文</returns>
        /// <br>Note       : 担当者別仕入月次集計データ用SELECT文を作成して戻します</br>
        /// <br>Programmer : 山田 明友</br>
        /// <br>Date       : 2007.11.30</br>
        /// <br></br>
        /// <br>UpdateNote : 「LEFT JOIN」部不具合のため多重集計されているのを修正</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.04.02</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, StockTransListCndtnWork cndtnWork)
        {
            return MakeSelectStringProc(ref sqlCommand, cndtnWork);
        }
        /// <summary>
        /// 担当者別仕入月次集計データ用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="cndtnWork">検索条件格納クラス</param>
        /// <returns>担当者別仕入月次集計データ用SELECT文</returns>
        /// <br>Note       : 担当者別仕入月次集計データ用SELECT文を作成して戻します</br>
        /// <br>Programmer : 山田 明友</br>
        /// <br>Date       : 2007.11.30</br>
        /// <br></br>
        /// <br>UpdateNote : 「LEFT JOIN」部不具合のため多重集計されているのを修正</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.04.02</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, StockTransListCndtnWork cndtnWork)
        {
            int GroupBySectionDiv = cndtnWork.GroupBySectionDiv;

            string Text = "";

            Text += "SELECT "
                + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF AS COMPANYNAME1RF, ")
                + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF AS COMPANYNAME2RF, ")
                + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF AS SECTIONGUIDENMRF, ")
                + "Y.EMPLOYEECODERF AS EMPLOYEECODERF, "
                + "Y.EMPLOYEENAMERF AS EMPLOYEENAMERF, ";

            Text += "M01.S_TOTALSTOCKCOUNTRF AS M01_TOTALSTOCKCOUNTRF, "
                 + "M01.S_STOCKTOTALPRICERF AS M01_STOCKTOTALPRICERF, "
                 + "M01.S_STOCKRETGOODSPRICERF AS M01_STOCKRETGOODSPRICERF, ";

            if (IncMonth(cndtnWork.St_ThisYearMonth, 1) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "M02.S_TOTALSTOCKCOUNTRF AS M02_TOTALSTOCKCOUNTRF, "
                     + "M02.S_STOCKTOTALPRICERF AS M02_STOCKTOTALPRICERF, "
                     + "M02.S_STOCKRETGOODSPRICERF AS M02_STOCKRETGOODSPRICERF, ";
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 2) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "M03.S_TOTALSTOCKCOUNTRF AS M03_TOTALSTOCKCOUNTRF, "
                     + "M03.S_STOCKTOTALPRICERF AS M03_STOCKTOTALPRICERF, "
                     + "M03.S_STOCKRETGOODSPRICERF AS M03_STOCKRETGOODSPRICERF, ";
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 3) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "M04.S_TOTALSTOCKCOUNTRF AS M04_TOTALSTOCKCOUNTRF, "
                     + "M04.S_STOCKTOTALPRICERF AS M04_STOCKTOTALPRICERF, "
                     + "M04.S_STOCKRETGOODSPRICERF AS M04_STOCKRETGOODSPRICERF, ";
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 4) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "M05.S_TOTALSTOCKCOUNTRF AS M05_TOTALSTOCKCOUNTRF, "
                     + "M05.S_STOCKTOTALPRICERF AS M05_STOCKTOTALPRICERF, "
                     + "M05.S_STOCKRETGOODSPRICERF AS M05_STOCKRETGOODSPRICERF, ";
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 5) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "M06.S_TOTALSTOCKCOUNTRF AS M06_TOTALSTOCKCOUNTRF, "
                     + "M06.S_STOCKTOTALPRICERF AS M06_STOCKTOTALPRICERF, "
                     + "M06.S_STOCKRETGOODSPRICERF AS M06_STOCKRETGOODSPRICERF, ";
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 6) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "M07.S_TOTALSTOCKCOUNTRF AS M07_TOTALSTOCKCOUNTRF, "
                     + "M07.S_STOCKTOTALPRICERF AS M07_STOCKTOTALPRICERF, "
                     + "M07.S_STOCKRETGOODSPRICERF AS M07_STOCKRETGOODSPRICERF, ";
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 7) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "M08.S_TOTALSTOCKCOUNTRF AS M08_TOTALSTOCKCOUNTRF, "
                     + "M08.S_STOCKTOTALPRICERF AS M08_STOCKTOTALPRICERF, "
                     + "M08.S_STOCKRETGOODSPRICERF AS M08_STOCKRETGOODSPRICERF, ";
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 8) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "M09.S_TOTALSTOCKCOUNTRF AS M09_TOTALSTOCKCOUNTRF, "
                     + "M09.S_STOCKTOTALPRICERF AS M09_STOCKTOTALPRICERF, "
                     + "M09.S_STOCKRETGOODSPRICERF AS M09_STOCKRETGOODSPRICERF, ";
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 9) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "M10.S_TOTALSTOCKCOUNTRF AS M10_TOTALSTOCKCOUNTRF, "
                     + "M10.S_STOCKTOTALPRICERF AS M10_STOCKTOTALPRICERF, "
                     + "M10.S_STOCKRETGOODSPRICERF AS M10_STOCKRETGOODSPRICERF, ";
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 10) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "M11.S_TOTALSTOCKCOUNTRF AS M11_TOTALSTOCKCOUNTRF, "
                     + "M11.S_STOCKTOTALPRICERF AS M11_STOCKTOTALPRICERF, "
                     + "M11.S_STOCKRETGOODSPRICERF AS M11_STOCKRETGOODSPRICERF, ";
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 11) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "M12.S_TOTALSTOCKCOUNTRF AS M12_TOTALSTOCKCOUNTRF, "
                     + "M12.S_STOCKTOTALPRICERF AS M12_STOCKTOTALPRICERF, "
                     + "M12.S_STOCKRETGOODSPRICERF AS M12_STOCKRETGOODSPRICERF, ";
            }

            Text += "SUM(Y.TOTALSTOCKCOUNTRF) AS YS_TOTALSTOCKCOUNTRF, "
                + "SUM(Y.STOCKTOTALPRICERF) AS YS_STOCKTOTALPRICERF, "
                + "SUM(Y.STOCKRETGOODSPRICERF) AS YS_STOCKRETGOODSPRICERF "
                + "FROM EMPMTTLSTSLIPRF Y ";

            /* +0 月 */
            Text += "LEFT JOIN "
                + "(SELECT "
                + IFBySection(GroupBySectionDiv, " M01.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                // ↓ 2008.04.02 980081 a
                + IFBySection(GroupBySectionDiv, " M01.COMPANYNAME1RF AS COMPANYNAME1RF, ")
                + IFBySection(GroupBySectionDiv, " M01.COMPANYNAME2RF AS COMPANYNAME2RF, ")
                + IFBySection(GroupBySectionDiv, " M01.SECTIONGUIDENMRF AS SECTIONGUIDENMRF, ")
                + " M01.EMPLOYEENAMERF AS EMPLOYEENAMERF, "
                // ↑ 2008.04.02 980081 a
                + " M01.EMPLOYEECODERF AS EMPLOYEECODERF, "
                + " SUM(M01.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                + " SUM(M01.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                + " SUM(M01.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                + " FROM EMPMTTLSTSLIPRF M01 "
                + MakeWhereString(ref sqlCommand, cndtnWork, "M01", TermDiv.MonthBound, 0)
                + " GROUP BY "
                + IFBySection(GroupBySectionDiv, "M01.STOCKSECTIONCDRF, ")
                // ↓ 2008.04.02 980081 a
                + IFBySection(GroupBySectionDiv, "M01.COMPANYNAME1RF, ")
                + IFBySection(GroupBySectionDiv, "M01.COMPANYNAME2RF, ")
                + IFBySection(GroupBySectionDiv, "M01.SECTIONGUIDENMRF, ")
                + " M01.EMPLOYEENAMERF, "
                // ↑ 2008.04.02 980081 a
                + " M01.EMPLOYEECODERF "
                + ") M01 "
                + "ON "
                + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M01.STOCKSECTIONCDRF AND ")
                // ↓ 2008.04.02 980081 a
                + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M01.COMPANYNAME1RF AND ")
                + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M01.COMPANYNAME2RF AND ")
                + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M01.SECTIONGUIDENMRF AND ")
                + "    Y.EMPLOYEENAMERF=M01.EMPLOYEENAMERF AND "
                // ↑ 2008.04.02 980081 a
                + "    Y.EMPLOYEECODERF=M01.EMPLOYEECODERF ";

            /* +1 月 */
            if (IncMonth(cndtnWork.St_ThisYearMonth, 1) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "LEFT JOIN "
                    + "(SELECT "
                    + IFBySection(GroupBySectionDiv, " M02.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, " M02.COMPANYNAME1RF AS COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, " M02.COMPANYNAME2RF AS COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, " M02.SECTIONGUIDENMRF AS SECTIONGUIDENMRF, ")
                    + " M02.EMPLOYEENAMERF AS EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M02.EMPLOYEECODERF AS EMPLOYEECODERF, "
                    + " SUM(M02.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M02.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M02.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM EMPMTTLSTSLIPRF M02 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M02", TermDiv.MonthBound, 1)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M02.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M02.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M02.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M02.SECTIONGUIDENMRF, ")
                    + " M02.EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M02.EMPLOYEECODERF "
                    + ") M02 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M02.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M02.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M02.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M02.SECTIONGUIDENMRF AND ")
                    + "    Y.EMPLOYEENAMERF=M02.EMPLOYEENAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.EMPLOYEECODERF=M02.EMPLOYEECODERF ";
            }
            /* +2 月 */
            if (IncMonth(cndtnWork.St_ThisYearMonth, 2) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "LEFT JOIN "
                    + "(SELECT "
                    + IFBySection(GroupBySectionDiv, " M03.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, " M03.COMPANYNAME1RF AS COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, " M03.COMPANYNAME2RF AS COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, " M03.SECTIONGUIDENMRF AS SECTIONGUIDENMRF, ")
                    + " M03.EMPLOYEENAMERF AS EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M03.EMPLOYEECODERF AS EMPLOYEECODERF, "
                    + " SUM(M03.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M03.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M03.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM EMPMTTLSTSLIPRF M03 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M03", TermDiv.MonthBound, 2)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M03.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M03.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M03.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M03.SECTIONGUIDENMRF, ")
                    + " M03.EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M03.EMPLOYEECODERF "
                    + ") M03 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M03.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M03.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M03.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M03.SECTIONGUIDENMRF AND ")
                    + "    Y.EMPLOYEENAMERF=M03.EMPLOYEENAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.EMPLOYEECODERF=M03.EMPLOYEECODERF ";
            }
            /* +3 月 */
            if (IncMonth(cndtnWork.St_ThisYearMonth, 3) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "LEFT JOIN "
                    + "(SELECT "
                    + IFBySection(GroupBySectionDiv, " M04.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, " M04.COMPANYNAME1RF AS COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, " M04.COMPANYNAME2RF AS COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, " M04.SECTIONGUIDENMRF AS SECTIONGUIDENMRF, ")
                    + " M04.EMPLOYEENAMERF AS EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M04.EMPLOYEECODERF AS EMPLOYEECODERF, "
                    + " SUM(M04.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M04.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M04.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM EMPMTTLSTSLIPRF M04 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M04", TermDiv.MonthBound, 3)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M04.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M04.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M04.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M04.SECTIONGUIDENMRF, ")
                    + " M04.EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M04.EMPLOYEECODERF "
                    + ") M04 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M04.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M04.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M04.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M04.SECTIONGUIDENMRF AND ")
                    + "    Y.EMPLOYEENAMERF=M04.EMPLOYEENAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.EMPLOYEECODERF=M04.EMPLOYEECODERF ";
            }
            /* +4 月 */
            if (IncMonth(cndtnWork.St_ThisYearMonth, 4) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "LEFT JOIN "
                    + "(SELECT "
                    + IFBySection(GroupBySectionDiv, " M05.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, " M05.COMPANYNAME1RF AS COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, " M05.COMPANYNAME2RF AS COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, " M05.SECTIONGUIDENMRF AS SECTIONGUIDENMRF, ")
                    + " M05.EMPLOYEENAMERF AS EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M05.EMPLOYEECODERF AS EMPLOYEECODERF, "
                    + " SUM(M05.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M05.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M05.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM EMPMTTLSTSLIPRF M05 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M05", TermDiv.MonthBound, 4)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M05.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M05.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M05.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M05.SECTIONGUIDENMRF, ")
                    + " M05.EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M05.EMPLOYEECODERF "
                    + ") M05 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M05.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M05.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M05.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M05.SECTIONGUIDENMRF AND ")
                    + "    Y.EMPLOYEENAMERF=M05.EMPLOYEENAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.EMPLOYEECODERF=M05.EMPLOYEECODERF ";
            }
            /* +5 月 */
            if (IncMonth(cndtnWork.St_ThisYearMonth, 5) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "LEFT JOIN "
                    + "(SELECT "
                    + IFBySection(GroupBySectionDiv, " M06.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, " M06.COMPANYNAME1RF AS COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, " M06.COMPANYNAME2RF AS COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, " M06.SECTIONGUIDENMRF AS SECTIONGUIDENMRF, ")
                    + " M06.EMPLOYEENAMERF AS EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M06.EMPLOYEECODERF AS EMPLOYEECODERF, "
                    + " SUM(M06.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M06.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M06.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM EMPMTTLSTSLIPRF M06 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M06", TermDiv.MonthBound, 5)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M06.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M06.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M06.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M06.SECTIONGUIDENMRF, ")
                    + " M06.EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M06.EMPLOYEECODERF "
                    + ") M06 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M06.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M06.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M06.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M06.SECTIONGUIDENMRF AND ")
                    + "    Y.EMPLOYEENAMERF=M06.EMPLOYEENAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.EMPLOYEECODERF=M06.EMPLOYEECODERF ";
            }
            /* +6 月 */
            if (IncMonth(cndtnWork.St_ThisYearMonth, 6) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "LEFT JOIN "
                    + "(SELECT "
                    + IFBySection(GroupBySectionDiv, " M07.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, " M07.COMPANYNAME1RF AS COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, " M07.COMPANYNAME2RF AS COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, " M07.SECTIONGUIDENMRF AS SECTIONGUIDENMRF, ")
                    + " M07.EMPLOYEENAMERF AS EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M07.EMPLOYEECODERF AS EMPLOYEECODERF, "
                    + " SUM(M07.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M07.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M07.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM EMPMTTLSTSLIPRF M07 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M07", TermDiv.MonthBound, 6)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M07.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M07.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M07.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M07.SECTIONGUIDENMRF, ")
                    + " M07.EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M07.EMPLOYEECODERF "
                    + ") M07 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M07.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M07.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M07.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M07.SECTIONGUIDENMRF AND ")
                    + "    Y.EMPLOYEENAMERF=M07.EMPLOYEENAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.EMPLOYEECODERF=M07.EMPLOYEECODERF ";
            }
            /* +7 月 */
            if (IncMonth(cndtnWork.St_ThisYearMonth, 7) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "LEFT JOIN "
                    + "(SELECT "
                    + IFBySection(GroupBySectionDiv, " M08.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, " M08.COMPANYNAME1RF AS COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, " M08.COMPANYNAME2RF AS COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, " M08.SECTIONGUIDENMRF AS SECTIONGUIDENMRF, ")
                    + " M08.EMPLOYEENAMERF AS EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M08.EMPLOYEECODERF AS EMPLOYEECODERF, "
                    + " SUM(M08.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M08.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M08.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM EMPMTTLSTSLIPRF M08 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M08", TermDiv.MonthBound, 7)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M08.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M08.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M08.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M08.SECTIONGUIDENMRF, ")
                    + " M08.EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M08.EMPLOYEECODERF "
                    + ") M08 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M08.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M08.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M08.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M08.SECTIONGUIDENMRF AND ")
                    + "    Y.EMPLOYEENAMERF=M08.EMPLOYEENAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.EMPLOYEECODERF=M08.EMPLOYEECODERF ";
            }
            /* +8 月 */
            if (IncMonth(cndtnWork.St_ThisYearMonth, 8) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "LEFT JOIN "
                    + "(SELECT "
                    + IFBySection(GroupBySectionDiv, " M09.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, " M09.COMPANYNAME1RF AS COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, " M09.COMPANYNAME2RF AS COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, " M09.SECTIONGUIDENMRF AS SECTIONGUIDENMRF, ")
                    + " M09.EMPLOYEENAMERF AS EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M09.EMPLOYEECODERF AS EMPLOYEECODERF, "
                    + " SUM(M09.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M09.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M09.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM EMPMTTLSTSLIPRF M09 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M09", TermDiv.MonthBound, 8)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M09.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M09.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M09.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M09.SECTIONGUIDENMRF, ")
                    + " M09.EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M09.EMPLOYEECODERF "
                    + ") M09 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M09.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M09.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M09.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M09.SECTIONGUIDENMRF AND ")
                    + "    Y.EMPLOYEENAMERF=M09.EMPLOYEENAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.EMPLOYEECODERF=M09.EMPLOYEECODERF ";
            }
            /* +9 月 */
            if (IncMonth(cndtnWork.St_ThisYearMonth, 9) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "LEFT JOIN "
                    + "(SELECT "
                    + IFBySection(GroupBySectionDiv, " M10.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, " M10.COMPANYNAME1RF AS COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, " M10.COMPANYNAME2RF AS COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, " M10.SECTIONGUIDENMRF AS SECTIONGUIDENMRF, ")
                    + " M10.EMPLOYEENAMERF AS EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M10.EMPLOYEECODERF AS EMPLOYEECODERF, "
                    + " SUM(M10.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M10.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M10.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM EMPMTTLSTSLIPRF M10 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M10", TermDiv.MonthBound, 9)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M10.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M10.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M10.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M10.SECTIONGUIDENMRF, ")
                    + " M10.EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M10.EMPLOYEECODERF "
                    + ") M10 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M10.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M10.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M10.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M10.SECTIONGUIDENMRF AND ")
                    + "    Y.EMPLOYEENAMERF=M10.EMPLOYEENAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.EMPLOYEECODERF=M10.EMPLOYEECODERF ";
            }
            /* +10 月 */
            if (IncMonth(cndtnWork.St_ThisYearMonth, 10) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "LEFT JOIN "
                    + "(SELECT "
                    + IFBySection(GroupBySectionDiv, " M11.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, " M11.COMPANYNAME1RF AS COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, " M11.COMPANYNAME2RF AS COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, " M11.SECTIONGUIDENMRF AS SECTIONGUIDENMRF, ")
                    + " M11.EMPLOYEENAMERF AS EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M11.EMPLOYEECODERF AS EMPLOYEECODERF, "
                    + " SUM(M11.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M11.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M11.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM EMPMTTLSTSLIPRF M11 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M11", TermDiv.MonthBound, 10)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M11.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M11.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M11.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M11.SECTIONGUIDENMRF, ")
                    + " M11.EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M11.EMPLOYEECODERF "
                    + ") M11 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M11.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M11.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M11.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M11.SECTIONGUIDENMRF AND ")
                    + "    Y.EMPLOYEENAMERF=M11.EMPLOYEENAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.EMPLOYEECODERF=M11.EMPLOYEECODERF ";
            }
            /* +11 月 */
            if (IncMonth(cndtnWork.St_ThisYearMonth, 11) <= cndtnWork.Ed_ThisYearMonth)
            {
                Text += "LEFT JOIN "
                    + "(SELECT "
                    + IFBySection(GroupBySectionDiv, " M12.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, " M12.COMPANYNAME1RF AS COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, " M12.COMPANYNAME2RF AS COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, " M12.SECTIONGUIDENMRF AS SECTIONGUIDENMRF, ")
                    + " M12.EMPLOYEENAMERF AS EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M12.EMPLOYEECODERF AS EMPLOYEECODERF, "
                    + " SUM(M12.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M12.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M12.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM EMPMTTLSTSLIPRF M12 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M12", TermDiv.MonthBound, 11)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M12.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M12.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M12.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M12.SECTIONGUIDENMRF, ")
                    + " M12.EMPLOYEENAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M12.EMPLOYEECODERF "
                    + ") M12 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M12.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M12.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M12.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M12.SECTIONGUIDENMRF AND ")
                    + "    Y.EMPLOYEENAMERF=M12.EMPLOYEENAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.EMPLOYEECODERF=M12.EMPLOYEECODERF ";
            }
            /*    */
            Text += MakeWhereString(ref sqlCommand, cndtnWork, "Y", TermDiv.YearBound, 0)
                + "GROUP BY "
                + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF, ")
                + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF, ")
                + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF, ")
                + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF, ")
                + "Y.EMPLOYEECODERF, Y.EMPLOYEENAMERF "
                + ", M01.S_TOTALSTOCKCOUNTRF, M01.S_STOCKTOTALPRICERF, M01.S_STOCKRETGOODSPRICERF ";
            if (IncMonth(cndtnWork.St_ThisYearMonth, 1) <= cndtnWork.Ed_ThisYearMonth)
                Text += ", M02.S_TOTALSTOCKCOUNTRF, M02.S_STOCKTOTALPRICERF, M02.S_STOCKRETGOODSPRICERF ";
            if (IncMonth(cndtnWork.St_ThisYearMonth, 2) <= cndtnWork.Ed_ThisYearMonth)
                Text += ", M03.S_TOTALSTOCKCOUNTRF, M03.S_STOCKTOTALPRICERF, M03.S_STOCKRETGOODSPRICERF ";
            if (IncMonth(cndtnWork.St_ThisYearMonth, 3) <= cndtnWork.Ed_ThisYearMonth)
                Text += ", M04.S_TOTALSTOCKCOUNTRF, M04.S_STOCKTOTALPRICERF, M04.S_STOCKRETGOODSPRICERF ";
            if (IncMonth(cndtnWork.St_ThisYearMonth, 4) <= cndtnWork.Ed_ThisYearMonth)
                Text += ", M05.S_TOTALSTOCKCOUNTRF, M05.S_STOCKTOTALPRICERF, M05.S_STOCKRETGOODSPRICERF ";
            if (IncMonth(cndtnWork.St_ThisYearMonth, 5) <= cndtnWork.Ed_ThisYearMonth)
                Text += ", M06.S_TOTALSTOCKCOUNTRF, M06.S_STOCKTOTALPRICERF, M06.S_STOCKRETGOODSPRICERF ";
            if (IncMonth(cndtnWork.St_ThisYearMonth, 6) <= cndtnWork.Ed_ThisYearMonth)
                Text += ", M07.S_TOTALSTOCKCOUNTRF, M07.S_STOCKTOTALPRICERF, M07.S_STOCKRETGOODSPRICERF ";
            if (IncMonth(cndtnWork.St_ThisYearMonth, 7) <= cndtnWork.Ed_ThisYearMonth)
                Text += ", M08.S_TOTALSTOCKCOUNTRF, M08.S_STOCKTOTALPRICERF, M08.S_STOCKRETGOODSPRICERF ";
            if (IncMonth(cndtnWork.St_ThisYearMonth, 8) <= cndtnWork.Ed_ThisYearMonth)
                Text += ", M09.S_TOTALSTOCKCOUNTRF, M09.S_STOCKTOTALPRICERF, M09.S_STOCKRETGOODSPRICERF ";
            if (IncMonth(cndtnWork.St_ThisYearMonth, 9) <= cndtnWork.Ed_ThisYearMonth)
                Text += ", M10.S_TOTALSTOCKCOUNTRF, M10.S_STOCKTOTALPRICERF, M10.S_STOCKRETGOODSPRICERF ";
            if (IncMonth(cndtnWork.St_ThisYearMonth, 10) <= cndtnWork.Ed_ThisYearMonth)
                Text += ", M11.S_TOTALSTOCKCOUNTRF, M11.S_STOCKTOTALPRICERF, M11.S_STOCKRETGOODSPRICERF ";
            if (IncMonth(cndtnWork.St_ThisYearMonth, 11) <= cndtnWork.Ed_ThisYearMonth)
                Text += ", M12.S_TOTALSTOCKCOUNTRF, M12.S_STOCKTOTALPRICERF, M12.S_STOCKRETGOODSPRICERF ";

            Text += MakeHavingString(ref sqlCommand, cndtnWork, "Y", TermDiv.YearBound)
                + "ORDER BY "
                + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF, ")
                // ↓ 2008.04.02 980081 c
                //+ "Y.EMPLOYEECODERF ";
                + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF, ")
                + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF, ")
                + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF, ")
                + "Y.EMPLOYEECODERF, Y.EMPLOYEENAMERF ";
                // ↑ 2008.04.02 980081 c

            return Text;
        }
        #endregion  //[EmpMTtlStSlip用 Select文生成処理]

        #region [EmpMTtlStSlip用 Where句生成処理]
        /// <summary>
        /// 担当者別仕入月次集計データ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="cndtnWork">検索条件格納クラス</param>
        /// <param name="refName"></param>
        /// <param name="termDiv">集計期間区分  0:指定月範囲  1:当期範囲</param>
        /// <param name="monthIndex"></param>
        /// <returns>担当者別仕入月次集計データ用WHERE句</returns>
        /// <br>Note       : 担当者別仕入月次集計データ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 山田 明友</br>
        /// <br>Date       : 2007.11.30</br>
        public string MakeWhereString(ref SqlCommand sqlCommand, StockTransListCndtnWork cndtnWork, string refName, TermDiv termDiv, int monthIndex)
        {
            return MakeWhereStringProc(ref sqlCommand, cndtnWork, refName, termDiv, monthIndex);
        }
        /// <summary>
        /// 担当者別仕入月次集計データ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="cndtnWork">検索条件格納クラス</param>
        /// <param name="refName"></param>
        /// <param name="termDiv">集計期間区分  0:指定月範囲  1:当期範囲</param>
        /// <param name="monthIndex"></param>
        /// <returns>担当者別仕入月次集計データ用WHERE句</returns>
        /// <br>Note       : 担当者別仕入月次集計データ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 山田 明友</br>
        /// <br>Date       : 2007.11.30</br>
        private string MakeWhereStringProc(ref SqlCommand sqlCommand, StockTransListCndtnWork cndtnWork, string refName, TermDiv termDiv, int monthIndex)
        {
            string text = "WHERE ";
            //固定条件
            //企業コード
            text += refName + ".ENTERPRISECODERF=@ENTERPRISECODE ";
            if (sqlCommand.Parameters.IndexOf("@ENTERPRISECODE") < 0)
            {
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);
            }

            //論理削除区分
            //text += "AND " + refName + ".LOGICALDELETECODERF=0 ";

            //これよりパラメータの値により動的変化の項目
            //拠点コード
            if (cndtnWork.GroupBySectionDiv != 0)
            {
                //拠点別集計の場合（全社集計でない場合）
                if (cndtnWork.AddUpSecCodes != null &&
                    cndtnWork.AddUpSecCodes.Length > 0)
                {
                    if (cndtnWork.AddUpSecCodes[0] != null &&
                        cndtnWork.AddUpSecCodes[0] != "")
                    {
                        text += "AND " + refName + ".STOCKSECTIONCDRF IN (";
                        text += "'" + cndtnWork.AddUpSecCodes[0].ToString() + "'";
                        for (int i = 1; i < cndtnWork.AddUpSecCodes.Length; i++)
                        {
                            if (cndtnWork.AddUpSecCodes[i] == null)
                                break;
                            text += ", '" + cndtnWork.AddUpSecCodes[i].ToString() + "'";
                        }
                        text += ") ";
                    }
                }
            }

            switch (termDiv)
            {
                case TermDiv.MonthBound:     // 指定月範囲
                    int YM = IncMonth(cndtnWork.St_ThisYearMonth, monthIndex);
                    text += "AND " + refName + ".STOCKDATEYMRF=" + YM.ToString() + " ";
                    break;
                case TermDiv.YearBound:     // 期範囲
                    //開始期年月
                    if (cndtnWork.St_ThisYearMonth != 0)
                    {
                        text += "AND " + refName + ".STOCKDATEYMRF>=@ST_THISYEARMONTH ";
                        if (sqlCommand.Parameters.IndexOf("@ST_THISYEARMONTH") < 0)
                        {
                            SqlParameter paraStThisYearMonth = sqlCommand.Parameters.Add("@ST_THISYEARMONTH", SqlDbType.Int);
                            paraStThisYearMonth.Value = SqlDataMediator.SqlSetInt32(cndtnWork.St_ThisYearMonth);
                        }
                    }

                    //終了期年月
                    if (cndtnWork.Ed_ThisYearMonth != 0)
                    {
                        text += "AND " + refName + ".STOCKDATEYMRF<=@ED_THISYEARMONTH ";
                        if (sqlCommand.Parameters.IndexOf("@ED_THISYEARMONTH") < 0)
                        {
                            SqlParameter paraEdThisYearMonth = sqlCommand.Parameters.Add("@ED_THISYEARMONTH", SqlDbType.Int);
                            paraEdThisYearMonth.Value = SqlDataMediator.SqlSetInt32(cndtnWork.Ed_ThisYearMonth);
                        }
                    }
                    break;
                default:
                    break;
            }

            //開始担当者コード
            if (cndtnWork.St_EmployeeCode != "")
            {
                text += "AND " + refName + ".EMPLOYEECODERF>=@ST_EMPLOYEECODE ";
                if (sqlCommand.Parameters.IndexOf("@ST_EMPLOYEECODE") < 0)
                {
                    SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@ST_EMPLOYEECODE", SqlDbType.NChar);
                    paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(cndtnWork.St_EmployeeCode);
                }
            }

            //終了担当者コード
            if (cndtnWork.Ed_EmployeeCode != "")
            {
                text += "AND " + refName + ".EMPLOYEECODERF<=@ED_EMPLOYEECODE ";
                if (sqlCommand.Parameters.IndexOf("@ED_EMPLOYEECODE") < 0)
                {
                    SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@ED_EMPLOYEECODE", SqlDbType.NChar);
                    paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(cndtnWork.Ed_EmployeeCode);
                }
            }

            //仕入在庫取寄せ区分
            if (cndtnWork.StockOrderDiv != 0)
            {
                switch (cndtnWork.StockOrderDiv)
                {
                    case 0:     // 合計
                        break;
                    case 1:     // 在庫
                        text += "AND " + refName + ".STOCKORDERDIVCDRF=1 ";
                        break;
                    case 2:     // 取寄
                        text += "AND " + refName + ".STOCKORDERDIVCDRF=0 ";
                        break;
                    default:
                        break;
                }
            }

            return text;
        }
        #endregion //[EmpMTtlStSlip用 Where句生成処理]

        #region [EmpMTtlStSlip用 Having句生成処理]
        /// <summary>
        /// 担当者別仕入月次集計データ用HAVING句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="cndtnWork">検索条件格納クラス</param>
        /// <param name="refName"></param>
        /// <param name="termDiv">集計期間区分  0:指定月範囲  1:当期範囲</param>
        /// <returns>担当者別仕入月次集計データ用HAVING句</returns>
        /// <br>Note       : 担当者別仕入月次集計データ用HAVING句を作成して戻します</br>
        /// <br>Programmer : 山田 明友</br>
        /// <br>Date       : 2007.11.30</br>
        private string MakeHavingString(ref SqlCommand sqlCommand, StockTransListCndtnWork cndtnWork, string refName, TermDiv termDiv)
        {
            string sTotalStockCount = "SUM(" + refName + ".TOTALSTOCKCOUNTRF)";
            if (termDiv == TermDiv.MonthBound)
                sTotalStockCount = "SUM(" + refName + ".TOTALSTOCKCOUNTRF)";

            string text = "";
            if (cndtnWork.St_TotalStockCount != 0.0 || cndtnWork.Ed_TotalStockCount != 0.0)
            {
                text += "HAVING ";
                if (cndtnWork.St_TotalStockCount != 0.0)
                {
                    text += sTotalStockCount + ">=@ST_TOTALSTOCKCOUNT ";
                    if (sqlCommand.Parameters.IndexOf("@ST_TOTALSTOCKCOUNT") < 0)
                    {
                        SqlParameter paraStTotalStockCount = sqlCommand.Parameters.Add("@ST_TOTALSTOCKCOUNT", SqlDbType.Float);
                        paraStTotalStockCount.Value = SqlDataMediator.SqlSetDouble(cndtnWork.St_TotalStockCount);
                    }
                }
                if (cndtnWork.Ed_TotalStockCount != 0.0)
                {
                    if (cndtnWork.St_TotalStockCount != 0.0)
                    {
                        text += "AND ";
                    }
                    text += sTotalStockCount + "<=@ED_TOTALSTOCKCOUNT ";
                    if (sqlCommand.Parameters.IndexOf("@ED_TOTALSTOCKCOUNT") < 0)
                    {
                        SqlParameter paraEdTotalStockCount = sqlCommand.Parameters.Add("@ED_TOTALSTOCKCOUNT", SqlDbType.Float);
                        paraEdTotalStockCount.Value = SqlDataMediator.SqlSetDouble(cndtnWork.Ed_TotalStockCount);
                    }
                }
            }

            return text;
        }
        #endregion //[EmpMTtlStSlip用 Having句生成処理]

        #region [CopyToStockRsltListResultWorkFromReader処理]
        /// <summary>
        /// クラス格納処理 Reader → CopyToStockRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="cndtnWork"></param>
        /// <returns>CopyToStockRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 山田 明友</br>
        /// <br>Date       : 2007.11.30</br>
        /// </remarks>
        public StockTransListResultWork CopyToStockRsltListResultWorkFromReader(ref SqlDataReader myReader, StockTransListCndtnWork cndtnWork)
        {
            return CopyToStockRsltListResultWorkFromReaderProc(ref myReader, cndtnWork);
        }
        /// <summary>
        /// クラス格納処理 Reader → CopyToStockRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="cndtnWork"></param>
        /// <returns>CopyToStockRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 山田 明友</br>
        /// <br>Date       : 2007.11.30</br>
        /// </remarks>
        private StockTransListResultWork CopyToStockRsltListResultWorkFromReaderProc(ref SqlDataReader myReader, StockTransListCndtnWork cndtnWork)
        {
            StockTransListResultWork ResultWork = new StockTransListResultWork();

            if (cndtnWork.GroupBySectionDiv != 0)
            {
                ResultWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                ResultWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME1RF"));
                ResultWork.CompanyName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME2RF"));
                ResultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            }
            ResultWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            ResultWork.EmployeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEENAMERF"));

            ResultWork.TotalStockCount1 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("M01_TOTALSTOCKCOUNTRF"));
            ResultWork.StockTotalTaxExc1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M01_STOCKTOTALPRICERF"));
            ResultWork.StockRetGoodsPrice1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M01_STOCKRETGOODSPRICERF"));

            if (IncMonth(cndtnWork.St_ThisYearMonth, 1) <= cndtnWork.Ed_ThisYearMonth)
            {
                ResultWork.TotalStockCount2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("M02_TOTALSTOCKCOUNTRF"));
                ResultWork.StockTotalTaxExc2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M02_STOCKTOTALPRICERF"));
                ResultWork.StockRetGoodsPrice2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M02_STOCKRETGOODSPRICERF"));
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 2) <= cndtnWork.Ed_ThisYearMonth)
            {
                ResultWork.TotalStockCount3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("M03_TOTALSTOCKCOUNTRF"));
                ResultWork.StockTotalTaxExc3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M03_STOCKTOTALPRICERF"));
                ResultWork.StockRetGoodsPrice3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M03_STOCKRETGOODSPRICERF"));
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 3) <= cndtnWork.Ed_ThisYearMonth)
            {
                ResultWork.TotalStockCount4 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("M04_TOTALSTOCKCOUNTRF"));
                ResultWork.StockTotalTaxExc4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M04_STOCKTOTALPRICERF"));
                ResultWork.StockRetGoodsPrice4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M04_STOCKRETGOODSPRICERF"));
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 4) <= cndtnWork.Ed_ThisYearMonth)
            {
                ResultWork.TotalStockCount5 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("M05_TOTALSTOCKCOUNTRF"));
                ResultWork.StockTotalTaxExc5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M05_STOCKTOTALPRICERF"));
                ResultWork.StockRetGoodsPrice5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M05_STOCKRETGOODSPRICERF"));
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 5) <= cndtnWork.Ed_ThisYearMonth)
            {
                ResultWork.TotalStockCount6 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("M06_TOTALSTOCKCOUNTRF"));
                ResultWork.StockTotalTaxExc6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M06_STOCKTOTALPRICERF"));
                ResultWork.StockRetGoodsPrice6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M06_STOCKRETGOODSPRICERF"));
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 6) <= cndtnWork.Ed_ThisYearMonth)
            {
                ResultWork.TotalStockCount7 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("M07_TOTALSTOCKCOUNTRF"));
                ResultWork.StockTotalTaxExc7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M07_STOCKTOTALPRICERF"));
                ResultWork.StockRetGoodsPrice7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M07_STOCKRETGOODSPRICERF"));
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 7) <= cndtnWork.Ed_ThisYearMonth)
            {
                ResultWork.TotalStockCount8 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("M08_TOTALSTOCKCOUNTRF"));
                ResultWork.StockTotalTaxExc8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M08_STOCKTOTALPRICERF"));
                ResultWork.StockRetGoodsPrice8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M08_STOCKRETGOODSPRICERF"));
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 8) <= cndtnWork.Ed_ThisYearMonth)
            {
                ResultWork.TotalStockCount9 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("M09_TOTALSTOCKCOUNTRF"));
                ResultWork.StockTotalTaxExc9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M09_STOCKTOTALPRICERF"));
                ResultWork.StockRetGoodsPrice9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M09_STOCKRETGOODSPRICERF"));
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 9) <= cndtnWork.Ed_ThisYearMonth)
            {
                ResultWork.TotalStockCount10 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("M10_TOTALSTOCKCOUNTRF"));
                ResultWork.StockTotalTaxExc10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M10_STOCKTOTALPRICERF"));
                ResultWork.StockRetGoodsPrice10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M10_STOCKRETGOODSPRICERF"));
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 10) <= cndtnWork.Ed_ThisYearMonth)
            {
                ResultWork.TotalStockCount11 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("M11_TOTALSTOCKCOUNTRF"));
                ResultWork.StockTotalTaxExc11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M11_STOCKTOTALPRICERF"));
                ResultWork.StockRetGoodsPrice11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M11_STOCKRETGOODSPRICERF"));
            }
            if (IncMonth(cndtnWork.St_ThisYearMonth, 11) <= cndtnWork.Ed_ThisYearMonth)
            {
                ResultWork.TotalStockCount12 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("M12_TOTALSTOCKCOUNTRF"));
                ResultWork.StockTotalTaxExc12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M12_STOCKTOTALPRICERF"));
                ResultWork.StockRetGoodsPrice12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("M12_STOCKRETGOODSPRICERF"));
            }

            return ResultWork;
        }
        #endregion //[CopyToStockRsltListResultWorkFromReader処理]

    }
}
