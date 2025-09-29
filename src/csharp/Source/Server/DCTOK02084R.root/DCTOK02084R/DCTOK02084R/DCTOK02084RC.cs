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
    class MTtlStSlipGoods : MTtlStSlipBase, IMTtlStSlip
    {
        #region [GoodsMTtlStSlip用 Select文生成処理]
        /// <summary>
        /// 商品別仕入月次集計データ用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="cndtnWork">検索条件格納クラス</param>
        /// <returns>商品別仕入月次集計データ用SELECT文</returns>
        /// <br>Note       : 商品別仕入月次集計データ用SELECT文を作成して戻します</br>
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
        /// 商品別仕入月次集計データ用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="cndtnWork">検索条件格納クラス</param>
        /// <returns>商品別仕入月次集計データ用SELECT文</returns>
        /// <br>Note       : 商品別仕入月次集計データ用SELECT文を作成して戻します</br>
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
                + "Y.GOODSMAKERCDRF AS GOODSMAKERCDRF, "
                + "Y.MAKERNAMERF AS MAKERNAMERF, "
                + "Y.LARGEGOODSGANRECODERF AS LARGEGOODSGANRECODERF, "
                + "Y.LARGEGOODSGANRENAMERF AS LARGEGOODSGANRENAMERF, "
                + "Y.MEDIUMGOODSGANRECODERF AS MEDIUMGOODSGANRECODERF, "
                + "Y.MEDIUMGOODSGANRENAMERF AS MEDIUMGOODSGANRENAMERF, "
                + "Y.DETAILGOODSGANRECODERF AS DETAILGOODSGANRECODERF, "
                + "Y.DETAILGOODSGANRENAMERF AS DETAILGOODSGANRENAMERF, "
                // ↓ 2008.03.06 980081 a
                + "Y.ENTERPRISEGANRECODERF AS ENTERPRISEGANRECODERF, "
                + "Y.ENTERPRISEGANRENAMERF AS ENTERPRISEGANRENAMERF, "
                // ↑ 2008.03.06 980081 a
                + "Y.BLGOODSCODERF AS BLGOODSCODERF, "
                + "Y.BLGOODSFULLNAMERF AS BLGOODSFULLNAMERF, "
                + "Y.GOODSNORF AS GOODSNORF, "
                + "Y.GOODSSHORTNAMERF AS GOODSSHORTNAMERF, ";

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
                + "FROM GOODSMTTLSTSLIPRF Y ";

            /* +0 月 */
            Text += "LEFT JOIN "
                + "(SELECT "
                + IFBySection(GroupBySectionDiv, " M01.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                // ↓ 2008.04.02 980081 a
                + IFBySection(GroupBySectionDiv, " M01.COMPANYNAME1RF AS COMPANYNAME1RF, ")
                + IFBySection(GroupBySectionDiv, " M01.COMPANYNAME2RF AS COMPANYNAME2RF, ")
                + IFBySection(GroupBySectionDiv, " M01.SECTIONGUIDENMRF AS SECTIONGUIDENMRF, ")
                + " M01.MAKERNAMERF AS MAKERNAMERF, "
                + " M01.LARGEGOODSGANRECODERF AS LARGEGOODSGANRECODERF, "
                + " M01.LARGEGOODSGANRENAMERF AS LARGEGOODSGANRENAMERF, "
                + " M01.MEDIUMGOODSGANRECODERF AS MEDIUMGOODSGANRECODERF, "
                + " M01.MEDIUMGOODSGANRENAMERF AS MEDIUMGOODSGANRENAMERF, "
                + " M01.DETAILGOODSGANRECODERF AS DETAILGOODSGANRECODERF, "
                + " M01.DETAILGOODSGANRENAMERF AS DETAILGOODSGANRENAMERF, "
                + " M01.ENTERPRISEGANRECODERF AS ENTERPRISEGANRECODERF, "
                + " M01.ENTERPRISEGANRENAMERF AS ENTERPRISEGANRENAMERF, "
                + " M01.BLGOODSCODERF AS BLGOODSCODERF, "
                + " M01.BLGOODSFULLNAMERF AS BLGOODSFULLNAMERF, "
                + " M01.GOODSSHORTNAMERF AS GOODSSHORTNAMERF, "
                // ↑ 2008.04.02 980081 a
                + " M01.GOODSMAKERCDRF AS GOODSMAKERCDRF, "
                + " M01.GOODSNORF AS GOODSNORF, "
                + " SUM(M01.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                + " SUM(M01.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                + " SUM(M01.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                + " FROM GOODSMTTLSTSLIPRF M01 "
                + MakeWhereString(ref sqlCommand, cndtnWork, "M01", TermDiv.MonthBound, 0)
                + " GROUP BY "
                + IFBySection(GroupBySectionDiv, "M01.STOCKSECTIONCDRF, ")
                // ↓ 2008.04.02 980081 a
                + IFBySection(GroupBySectionDiv, "M01.COMPANYNAME1RF, ")
                + IFBySection(GroupBySectionDiv, "M01.COMPANYNAME2RF, ")
                + IFBySection(GroupBySectionDiv, "M01.SECTIONGUIDENMRF, ")
                + " M01.MAKERNAMERF, "
                + " M01.LARGEGOODSGANRECODERF, "
                + " M01.LARGEGOODSGANRENAMERF, "
                + " M01.MEDIUMGOODSGANRECODERF, "
                + " M01.MEDIUMGOODSGANRENAMERF, "
                + " M01.DETAILGOODSGANRECODERF, "
                + " M01.DETAILGOODSGANRENAMERF, "
                + " M01.ENTERPRISEGANRECODERF, "
                + " M01.ENTERPRISEGANRENAMERF, "
                + " M01.BLGOODSCODERF, "
                + " M01.BLGOODSFULLNAMERF, "
                + " M01.GOODSSHORTNAMERF, "
                // ↑ 2008.04.02 980081 a
                + " M01.GOODSMAKERCDRF, M01.GOODSNORF "
                + ") M01 "
                + "ON "
                + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M01.STOCKSECTIONCDRF AND ")
                // ↓ 2008.04.02 980081 a
                + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M01.COMPANYNAME1RF AND ")
                + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M01.COMPANYNAME2RF AND ")
                + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M01.SECTIONGUIDENMRF AND ")
                + "    Y.MAKERNAMERF=M01.MAKERNAMERF AND "
                + "    Y.LARGEGOODSGANRECODERF=M01.LARGEGOODSGANRECODERF AND "
                + "    Y.LARGEGOODSGANRENAMERF=M01.LARGEGOODSGANRENAMERF AND "
                + "    Y.MEDIUMGOODSGANRECODERF=M01.MEDIUMGOODSGANRECODERF AND "
                + "    Y.MEDIUMGOODSGANRENAMERF=M01.MEDIUMGOODSGANRENAMERF AND "
                + "    Y.DETAILGOODSGANRECODERF=M01.DETAILGOODSGANRECODERF AND "
                + "    Y.DETAILGOODSGANRENAMERF=M01.DETAILGOODSGANRENAMERF AND "
                + "    Y.ENTERPRISEGANRECODERF=M01.ENTERPRISEGANRECODERF AND "
                + "    Y.ENTERPRISEGANRENAMERF=M01.ENTERPRISEGANRENAMERF AND "
                + "    Y.BLGOODSCODERF=M01.BLGOODSCODERF AND "
                + "    Y.BLGOODSFULLNAMERF=M01.BLGOODSFULLNAMERF AND "
                + "    Y.GOODSSHORTNAMERF=M01.GOODSSHORTNAMERF AND "
                // ↑ 2008.04.02 980081 a
                + "    Y.GOODSMAKERCDRF=M01.GOODSMAKERCDRF AND "
                + "    Y.GOODSNORF=M01.GOODSNORF ";

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
                    + " M02.MAKERNAMERF AS MAKERNAMERF, "
                    + " M02.LARGEGOODSGANRECODERF AS LARGEGOODSGANRECODERF, "
                    + " M02.LARGEGOODSGANRENAMERF AS LARGEGOODSGANRENAMERF, "
                    + " M02.MEDIUMGOODSGANRECODERF AS MEDIUMGOODSGANRECODERF, "
                    + " M02.MEDIUMGOODSGANRENAMERF AS MEDIUMGOODSGANRENAMERF, "
                    + " M02.DETAILGOODSGANRECODERF AS DETAILGOODSGANRECODERF, "
                    + " M02.DETAILGOODSGANRENAMERF AS DETAILGOODSGANRENAMERF, "
                    + " M02.ENTERPRISEGANRECODERF AS ENTERPRISEGANRECODERF, "
                    + " M02.ENTERPRISEGANRENAMERF AS ENTERPRISEGANRENAMERF, "
                    + " M02.BLGOODSCODERF AS BLGOODSCODERF, "
                    + " M02.BLGOODSFULLNAMERF AS BLGOODSFULLNAMERF, "
                    + " M02.GOODSSHORTNAMERF AS GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M02.GOODSMAKERCDRF AS GOODSMAKERCDRF, "
                    + " M02.GOODSNORF AS GOODSNORF, "
                    + " SUM(M02.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M02.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M02.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM GOODSMTTLSTSLIPRF M02 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M02", TermDiv.MonthBound, 1)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M02.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M02.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M02.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M02.SECTIONGUIDENMRF, ")
                    + " M02.MAKERNAMERF, "
                    + " M02.LARGEGOODSGANRECODERF, "
                    + " M02.LARGEGOODSGANRENAMERF, "
                    + " M02.MEDIUMGOODSGANRECODERF, "
                    + " M02.MEDIUMGOODSGANRENAMERF, "
                    + " M02.DETAILGOODSGANRECODERF, "
                    + " M02.DETAILGOODSGANRENAMERF, "
                    + " M02.ENTERPRISEGANRECODERF, "
                    + " M02.ENTERPRISEGANRENAMERF, "
                    + " M02.BLGOODSCODERF, "
                    + " M02.BLGOODSFULLNAMERF, "
                    + " M02.GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M02.GOODSMAKERCDRF, M02.GOODSNORF "
                    + ") M02 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M02.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M02.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M02.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M02.SECTIONGUIDENMRF AND ")
                    + "    Y.MAKERNAMERF=M02.MAKERNAMERF AND "
                    + "    Y.LARGEGOODSGANRECODERF=M02.LARGEGOODSGANRECODERF AND "
                    + "    Y.LARGEGOODSGANRENAMERF=M02.LARGEGOODSGANRENAMERF AND "
                    + "    Y.MEDIUMGOODSGANRECODERF=M02.MEDIUMGOODSGANRECODERF AND "
                    + "    Y.MEDIUMGOODSGANRENAMERF=M02.MEDIUMGOODSGANRENAMERF AND "
                    + "    Y.DETAILGOODSGANRECODERF=M02.DETAILGOODSGANRECODERF AND "
                    + "    Y.DETAILGOODSGANRENAMERF=M02.DETAILGOODSGANRENAMERF AND "
                    + "    Y.ENTERPRISEGANRECODERF=M02.ENTERPRISEGANRECODERF AND "
                    + "    Y.ENTERPRISEGANRENAMERF=M02.ENTERPRISEGANRENAMERF AND "
                    + "    Y.BLGOODSCODERF=M02.BLGOODSCODERF AND "
                    + "    Y.BLGOODSFULLNAMERF=M02.BLGOODSFULLNAMERF AND "
                    + "    Y.GOODSSHORTNAMERF=M02.GOODSSHORTNAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.GOODSMAKERCDRF=M02.GOODSMAKERCDRF AND "
                    + "    Y.GOODSNORF=M02.GOODSNORF ";
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
                    + " M03.MAKERNAMERF AS MAKERNAMERF, "
                    + " M03.LARGEGOODSGANRECODERF AS LARGEGOODSGANRECODERF, "
                    + " M03.LARGEGOODSGANRENAMERF AS LARGEGOODSGANRENAMERF, "
                    + " M03.MEDIUMGOODSGANRECODERF AS MEDIUMGOODSGANRECODERF, "
                    + " M03.MEDIUMGOODSGANRENAMERF AS MEDIUMGOODSGANRENAMERF, "
                    + " M03.DETAILGOODSGANRECODERF AS DETAILGOODSGANRECODERF, "
                    + " M03.DETAILGOODSGANRENAMERF AS DETAILGOODSGANRENAMERF, "
                    + " M03.ENTERPRISEGANRECODERF AS ENTERPRISEGANRECODERF, "
                    + " M03.ENTERPRISEGANRENAMERF AS ENTERPRISEGANRENAMERF, "
                    + " M03.BLGOODSCODERF AS BLGOODSCODERF, "
                    + " M03.BLGOODSFULLNAMERF AS BLGOODSFULLNAMERF, "
                    + " M03.GOODSSHORTNAMERF AS GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M03.GOODSMAKERCDRF AS GOODSMAKERCDRF, "
                    + " M03.GOODSNORF AS GOODSNORF, "
                    + " SUM(M03.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M03.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M03.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM GOODSMTTLSTSLIPRF M03 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M03", TermDiv.MonthBound, 2)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M03.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M03.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M03.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M03.SECTIONGUIDENMRF, ")
                    + " M03.MAKERNAMERF, "
                    + " M03.LARGEGOODSGANRECODERF, "
                    + " M03.LARGEGOODSGANRENAMERF, "
                    + " M03.MEDIUMGOODSGANRECODERF, "
                    + " M03.MEDIUMGOODSGANRENAMERF, "
                    + " M03.DETAILGOODSGANRECODERF, "
                    + " M03.DETAILGOODSGANRENAMERF, "
                    + " M03.ENTERPRISEGANRECODERF, "
                    + " M03.ENTERPRISEGANRENAMERF, "
                    + " M03.BLGOODSCODERF, "
                    + " M03.BLGOODSFULLNAMERF, "
                    + " M03.GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M03.GOODSMAKERCDRF, M03.GOODSNORF "
                    + ") M03 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M03.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M03.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M03.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M03.SECTIONGUIDENMRF AND ")
                    + "    Y.MAKERNAMERF=M03.MAKERNAMERF AND "
                    + "    Y.LARGEGOODSGANRECODERF=M03.LARGEGOODSGANRECODERF AND "
                    + "    Y.LARGEGOODSGANRENAMERF=M03.LARGEGOODSGANRENAMERF AND "
                    + "    Y.MEDIUMGOODSGANRECODERF=M03.MEDIUMGOODSGANRECODERF AND "
                    + "    Y.MEDIUMGOODSGANRENAMERF=M03.MEDIUMGOODSGANRENAMERF AND "
                    + "    Y.DETAILGOODSGANRECODERF=M03.DETAILGOODSGANRECODERF AND "
                    + "    Y.DETAILGOODSGANRENAMERF=M03.DETAILGOODSGANRENAMERF AND "
                    + "    Y.ENTERPRISEGANRECODERF=M03.ENTERPRISEGANRECODERF AND "
                    + "    Y.ENTERPRISEGANRENAMERF=M03.ENTERPRISEGANRENAMERF AND "
                    + "    Y.BLGOODSCODERF=M03.BLGOODSCODERF AND "
                    + "    Y.BLGOODSFULLNAMERF=M03.BLGOODSFULLNAMERF AND "
                    + "    Y.GOODSSHORTNAMERF=M03.GOODSSHORTNAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.GOODSMAKERCDRF=M03.GOODSMAKERCDRF AND "
                    + "    Y.GOODSNORF=M03.GOODSNORF ";
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
                    + " M04.MAKERNAMERF AS MAKERNAMERF, "
                    + " M04.LARGEGOODSGANRECODERF AS LARGEGOODSGANRECODERF, "
                    + " M04.LARGEGOODSGANRENAMERF AS LARGEGOODSGANRENAMERF, "
                    + " M04.MEDIUMGOODSGANRECODERF AS MEDIUMGOODSGANRECODERF, "
                    + " M04.MEDIUMGOODSGANRENAMERF AS MEDIUMGOODSGANRENAMERF, "
                    + " M04.DETAILGOODSGANRECODERF AS DETAILGOODSGANRECODERF, "
                    + " M04.DETAILGOODSGANRENAMERF AS DETAILGOODSGANRENAMERF, "
                    + " M04.ENTERPRISEGANRECODERF AS ENTERPRISEGANRECODERF, "
                    + " M04.ENTERPRISEGANRENAMERF AS ENTERPRISEGANRENAMERF, "
                    + " M04.BLGOODSCODERF AS BLGOODSCODERF, "
                    + " M04.BLGOODSFULLNAMERF AS BLGOODSFULLNAMERF, "
                    + " M04.GOODSSHORTNAMERF AS GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M04.GOODSMAKERCDRF AS GOODSMAKERCDRF, "
                    + " M04.GOODSNORF AS GOODSNORF, "
                    + " SUM(M04.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M04.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M04.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM GOODSMTTLSTSLIPRF M04 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M04", TermDiv.MonthBound, 3)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M04.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M04.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M04.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M04.SECTIONGUIDENMRF, ")
                    + " M04.MAKERNAMERF, "
                    + " M04.LARGEGOODSGANRECODERF, "
                    + " M04.LARGEGOODSGANRENAMERF, "
                    + " M04.MEDIUMGOODSGANRECODERF, "
                    + " M04.MEDIUMGOODSGANRENAMERF, "
                    + " M04.DETAILGOODSGANRECODERF, "
                    + " M04.DETAILGOODSGANRENAMERF, "
                    + " M04.ENTERPRISEGANRECODERF, "
                    + " M04.ENTERPRISEGANRENAMERF, "
                    + " M04.BLGOODSCODERF, "
                    + " M04.BLGOODSFULLNAMERF, "
                    + " M04.GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M04.GOODSMAKERCDRF, M04.GOODSNORF "
                    + ") M04 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M04.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M04.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M04.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M04.SECTIONGUIDENMRF AND ")
                    + "    Y.MAKERNAMERF=M04.MAKERNAMERF AND "
                    + "    Y.LARGEGOODSGANRECODERF=M04.LARGEGOODSGANRECODERF AND "
                    + "    Y.LARGEGOODSGANRENAMERF=M04.LARGEGOODSGANRENAMERF AND "
                    + "    Y.MEDIUMGOODSGANRECODERF=M04.MEDIUMGOODSGANRECODERF AND "
                    + "    Y.MEDIUMGOODSGANRENAMERF=M04.MEDIUMGOODSGANRENAMERF AND "
                    + "    Y.DETAILGOODSGANRECODERF=M04.DETAILGOODSGANRECODERF AND "
                    + "    Y.DETAILGOODSGANRENAMERF=M04.DETAILGOODSGANRENAMERF AND "
                    + "    Y.ENTERPRISEGANRECODERF=M04.ENTERPRISEGANRECODERF AND "
                    + "    Y.ENTERPRISEGANRENAMERF=M04.ENTERPRISEGANRENAMERF AND "
                    + "    Y.BLGOODSCODERF=M04.BLGOODSCODERF AND "
                    + "    Y.BLGOODSFULLNAMERF=M04.BLGOODSFULLNAMERF AND "
                    + "    Y.GOODSSHORTNAMERF=M04.GOODSSHORTNAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.GOODSMAKERCDRF=M04.GOODSMAKERCDRF AND "
                    + "    Y.GOODSNORF=M04.GOODSNORF ";
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
                    + " M05.MAKERNAMERF AS MAKERNAMERF, "
                    + " M05.LARGEGOODSGANRECODERF AS LARGEGOODSGANRECODERF, "
                    + " M05.LARGEGOODSGANRENAMERF AS LARGEGOODSGANRENAMERF, "
                    + " M05.MEDIUMGOODSGANRECODERF AS MEDIUMGOODSGANRECODERF, "
                    + " M05.MEDIUMGOODSGANRENAMERF AS MEDIUMGOODSGANRENAMERF, "
                    + " M05.DETAILGOODSGANRECODERF AS DETAILGOODSGANRECODERF, "
                    + " M05.DETAILGOODSGANRENAMERF AS DETAILGOODSGANRENAMERF, "
                    + " M05.ENTERPRISEGANRECODERF AS ENTERPRISEGANRECODERF, "
                    + " M05.ENTERPRISEGANRENAMERF AS ENTERPRISEGANRENAMERF, "
                    + " M05.BLGOODSCODERF AS BLGOODSCODERF, "
                    + " M05.BLGOODSFULLNAMERF AS BLGOODSFULLNAMERF, "
                    + " M05.GOODSSHORTNAMERF AS GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M05.GOODSMAKERCDRF AS GOODSMAKERCDRF, "
                    + " M05.GOODSNORF AS GOODSNORF, "
                    + " SUM(M05.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M05.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M05.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM GOODSMTTLSTSLIPRF M05 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M05", TermDiv.MonthBound, 4)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M05.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M05.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M05.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M05.SECTIONGUIDENMRF, ")
                    + " M05.MAKERNAMERF, "
                    + " M05.LARGEGOODSGANRECODERF, "
                    + " M05.LARGEGOODSGANRENAMERF, "
                    + " M05.MEDIUMGOODSGANRECODERF, "
                    + " M05.MEDIUMGOODSGANRENAMERF, "
                    + " M05.DETAILGOODSGANRECODERF, "
                    + " M05.DETAILGOODSGANRENAMERF, "
                    + " M05.ENTERPRISEGANRECODERF, "
                    + " M05.ENTERPRISEGANRENAMERF, "
                    + " M05.BLGOODSCODERF, "
                    + " M05.BLGOODSFULLNAMERF, "
                    + " M05.GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M05.GOODSMAKERCDRF, M05.GOODSNORF "
                    + ") M05 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M05.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M05.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M05.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M05.SECTIONGUIDENMRF AND ")
                    + "    Y.MAKERNAMERF=M05.MAKERNAMERF AND "
                    + "    Y.LARGEGOODSGANRECODERF=M05.LARGEGOODSGANRECODERF AND "
                    + "    Y.LARGEGOODSGANRENAMERF=M05.LARGEGOODSGANRENAMERF AND "
                    + "    Y.MEDIUMGOODSGANRECODERF=M05.MEDIUMGOODSGANRECODERF AND "
                    + "    Y.MEDIUMGOODSGANRENAMERF=M05.MEDIUMGOODSGANRENAMERF AND "
                    + "    Y.DETAILGOODSGANRECODERF=M05.DETAILGOODSGANRECODERF AND "
                    + "    Y.DETAILGOODSGANRENAMERF=M05.DETAILGOODSGANRENAMERF AND "
                    + "    Y.ENTERPRISEGANRECODERF=M05.ENTERPRISEGANRECODERF AND "
                    + "    Y.ENTERPRISEGANRENAMERF=M05.ENTERPRISEGANRENAMERF AND "
                    + "    Y.BLGOODSCODERF=M05.BLGOODSCODERF AND "
                    + "    Y.BLGOODSFULLNAMERF=M05.BLGOODSFULLNAMERF AND "
                    + "    Y.GOODSSHORTNAMERF=M05.GOODSSHORTNAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.GOODSMAKERCDRF=M05.GOODSMAKERCDRF AND "
                    + "    Y.GOODSNORF=M05.GOODSNORF ";
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
                    + " M06.MAKERNAMERF AS MAKERNAMERF, "
                    + " M06.LARGEGOODSGANRECODERF AS LARGEGOODSGANRECODERF, "
                    + " M06.LARGEGOODSGANRENAMERF AS LARGEGOODSGANRENAMERF, "
                    + " M06.MEDIUMGOODSGANRECODERF AS MEDIUMGOODSGANRECODERF, "
                    + " M06.MEDIUMGOODSGANRENAMERF AS MEDIUMGOODSGANRENAMERF, "
                    + " M06.DETAILGOODSGANRECODERF AS DETAILGOODSGANRECODERF, "
                    + " M06.DETAILGOODSGANRENAMERF AS DETAILGOODSGANRENAMERF, "
                    + " M06.ENTERPRISEGANRECODERF AS ENTERPRISEGANRECODERF, "
                    + " M06.ENTERPRISEGANRENAMERF AS ENTERPRISEGANRENAMERF, "
                    + " M06.BLGOODSCODERF AS BLGOODSCODERF, "
                    + " M06.BLGOODSFULLNAMERF AS BLGOODSFULLNAMERF, "
                    + " M06.GOODSSHORTNAMERF AS GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M06.GOODSMAKERCDRF AS GOODSMAKERCDRF, "
                    + " M06.GOODSNORF AS GOODSNORF, "
                    + " SUM(M06.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M06.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M06.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM GOODSMTTLSTSLIPRF M06 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M06", TermDiv.MonthBound, 5)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M06.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M06.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M06.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M06.SECTIONGUIDENMRF, ")
                    + " M06.MAKERNAMERF, "
                    + " M06.LARGEGOODSGANRECODERF, "
                    + " M06.LARGEGOODSGANRENAMERF, "
                    + " M06.MEDIUMGOODSGANRECODERF, "
                    + " M06.MEDIUMGOODSGANRENAMERF, "
                    + " M06.DETAILGOODSGANRECODERF, "
                    + " M06.DETAILGOODSGANRENAMERF, "
                    + " M06.ENTERPRISEGANRECODERF, "
                    + " M06.ENTERPRISEGANRENAMERF, "
                    + " M06.BLGOODSCODERF, "
                    + " M06.BLGOODSFULLNAMERF, "
                    + " M06.GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M06.GOODSMAKERCDRF, M06.GOODSNORF "
                    + ") M06 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M06.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M06.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M06.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M06.SECTIONGUIDENMRF AND ")
                    + "    Y.MAKERNAMERF=M06.MAKERNAMERF AND "
                    + "    Y.LARGEGOODSGANRECODERF=M06.LARGEGOODSGANRECODERF AND "
                    + "    Y.LARGEGOODSGANRENAMERF=M06.LARGEGOODSGANRENAMERF AND "
                    + "    Y.MEDIUMGOODSGANRECODERF=M06.MEDIUMGOODSGANRECODERF AND "
                    + "    Y.MEDIUMGOODSGANRENAMERF=M06.MEDIUMGOODSGANRENAMERF AND "
                    + "    Y.DETAILGOODSGANRECODERF=M06.DETAILGOODSGANRECODERF AND "
                    + "    Y.DETAILGOODSGANRENAMERF=M06.DETAILGOODSGANRENAMERF AND "
                    + "    Y.ENTERPRISEGANRECODERF=M06.ENTERPRISEGANRECODERF AND "
                    + "    Y.ENTERPRISEGANRENAMERF=M06.ENTERPRISEGANRENAMERF AND "
                    + "    Y.BLGOODSCODERF=M06.BLGOODSCODERF AND "
                    + "    Y.BLGOODSFULLNAMERF=M06.BLGOODSFULLNAMERF AND "
                    + "    Y.GOODSSHORTNAMERF=M06.GOODSSHORTNAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.GOODSMAKERCDRF=M06.GOODSMAKERCDRF AND "
                    + "    Y.GOODSNORF=M06.GOODSNORF ";
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
                    + " M07.MAKERNAMERF AS MAKERNAMERF, "
                    + " M07.LARGEGOODSGANRECODERF AS LARGEGOODSGANRECODERF, "
                    + " M07.LARGEGOODSGANRENAMERF AS LARGEGOODSGANRENAMERF, "
                    + " M07.MEDIUMGOODSGANRECODERF AS MEDIUMGOODSGANRECODERF, "
                    + " M07.MEDIUMGOODSGANRENAMERF AS MEDIUMGOODSGANRENAMERF, "
                    + " M07.DETAILGOODSGANRECODERF AS DETAILGOODSGANRECODERF, "
                    + " M07.DETAILGOODSGANRENAMERF AS DETAILGOODSGANRENAMERF, "
                    + " M07.ENTERPRISEGANRECODERF AS ENTERPRISEGANRECODERF, "
                    + " M07.ENTERPRISEGANRENAMERF AS ENTERPRISEGANRENAMERF, "
                    + " M07.BLGOODSCODERF AS BLGOODSCODERF, "
                    + " M07.BLGOODSFULLNAMERF AS BLGOODSFULLNAMERF, "
                    + " M07.GOODSSHORTNAMERF AS GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M07.GOODSMAKERCDRF AS GOODSMAKERCDRF, "
                    + " M07.GOODSNORF AS GOODSNORF, "
                    + " SUM(M07.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M07.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M07.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM GOODSMTTLSTSLIPRF M07 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M07", TermDiv.MonthBound, 6)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M07.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M07.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M07.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M07.SECTIONGUIDENMRF, ")
                    + " M07.MAKERNAMERF, "
                    + " M07.LARGEGOODSGANRECODERF, "
                    + " M07.LARGEGOODSGANRENAMERF, "
                    + " M07.MEDIUMGOODSGANRECODERF, "
                    + " M07.MEDIUMGOODSGANRENAMERF, "
                    + " M07.DETAILGOODSGANRECODERF, "
                    + " M07.DETAILGOODSGANRENAMERF, "
                    + " M07.ENTERPRISEGANRECODERF, "
                    + " M07.ENTERPRISEGANRENAMERF, "
                    + " M07.BLGOODSCODERF, "
                    + " M07.BLGOODSFULLNAMERF, "
                    + " M07.GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M07.GOODSMAKERCDRF, M07.GOODSNORF "
                    + ") M07 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M07.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M07.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M07.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M07.SECTIONGUIDENMRF AND ")
                    + "    Y.MAKERNAMERF=M07.MAKERNAMERF AND "
                    + "    Y.LARGEGOODSGANRECODERF=M07.LARGEGOODSGANRECODERF AND "
                    + "    Y.LARGEGOODSGANRENAMERF=M07.LARGEGOODSGANRENAMERF AND "
                    + "    Y.MEDIUMGOODSGANRECODERF=M07.MEDIUMGOODSGANRECODERF AND "
                    + "    Y.MEDIUMGOODSGANRENAMERF=M07.MEDIUMGOODSGANRENAMERF AND "
                    + "    Y.DETAILGOODSGANRECODERF=M07.DETAILGOODSGANRECODERF AND "
                    + "    Y.DETAILGOODSGANRENAMERF=M07.DETAILGOODSGANRENAMERF AND "
                    + "    Y.ENTERPRISEGANRECODERF=M07.ENTERPRISEGANRECODERF AND "
                    + "    Y.ENTERPRISEGANRENAMERF=M07.ENTERPRISEGANRENAMERF AND "
                    + "    Y.BLGOODSCODERF=M07.BLGOODSCODERF AND "
                    + "    Y.BLGOODSFULLNAMERF=M07.BLGOODSFULLNAMERF AND "
                    + "    Y.GOODSSHORTNAMERF=M07.GOODSSHORTNAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.GOODSMAKERCDRF=M07.GOODSMAKERCDRF AND "
                    + "    Y.GOODSNORF=M07.GOODSNORF ";
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
                    + " M08.MAKERNAMERF AS MAKERNAMERF, "
                    + " M08.LARGEGOODSGANRECODERF AS LARGEGOODSGANRECODERF, "
                    + " M08.LARGEGOODSGANRENAMERF AS LARGEGOODSGANRENAMERF, "
                    + " M08.MEDIUMGOODSGANRECODERF AS MEDIUMGOODSGANRECODERF, "
                    + " M08.MEDIUMGOODSGANRENAMERF AS MEDIUMGOODSGANRENAMERF, "
                    + " M08.DETAILGOODSGANRECODERF AS DETAILGOODSGANRECODERF, "
                    + " M08.DETAILGOODSGANRENAMERF AS DETAILGOODSGANRENAMERF, "
                    + " M08.ENTERPRISEGANRECODERF AS ENTERPRISEGANRECODERF, "
                    + " M08.ENTERPRISEGANRENAMERF AS ENTERPRISEGANRENAMERF, "
                    + " M08.BLGOODSCODERF AS BLGOODSCODERF, "
                    + " M08.BLGOODSFULLNAMERF AS BLGOODSFULLNAMERF, "
                    + " M08.GOODSSHORTNAMERF AS GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M08.GOODSMAKERCDRF AS GOODSMAKERCDRF, "
                    + " M08.GOODSNORF AS GOODSNORF, "
                    + " SUM(M08.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M08.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M08.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM GOODSMTTLSTSLIPRF M08 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M08", TermDiv.MonthBound, 7)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M08.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M08.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M08.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M08.SECTIONGUIDENMRF, ")
                    + " M08.MAKERNAMERF, "
                    + " M08.LARGEGOODSGANRECODERF, "
                    + " M08.LARGEGOODSGANRENAMERF, "
                    + " M08.MEDIUMGOODSGANRECODERF, "
                    + " M08.MEDIUMGOODSGANRENAMERF, "
                    + " M08.DETAILGOODSGANRECODERF, "
                    + " M08.DETAILGOODSGANRENAMERF, "
                    + " M08.ENTERPRISEGANRECODERF, "
                    + " M08.ENTERPRISEGANRENAMERF, "
                    + " M08.BLGOODSCODERF, "
                    + " M08.BLGOODSFULLNAMERF, "
                    + " M08.GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M08.GOODSMAKERCDRF, M08.GOODSNORF "
                    + ") M08 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M08.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M08.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M08.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M08.SECTIONGUIDENMRF AND ")
                    + "    Y.MAKERNAMERF=M08.MAKERNAMERF AND "
                    + "    Y.LARGEGOODSGANRECODERF=M08.LARGEGOODSGANRECODERF AND "
                    + "    Y.LARGEGOODSGANRENAMERF=M08.LARGEGOODSGANRENAMERF AND "
                    + "    Y.MEDIUMGOODSGANRECODERF=M08.MEDIUMGOODSGANRECODERF AND "
                    + "    Y.MEDIUMGOODSGANRENAMERF=M08.MEDIUMGOODSGANRENAMERF AND "
                    + "    Y.DETAILGOODSGANRECODERF=M08.DETAILGOODSGANRECODERF AND "
                    + "    Y.DETAILGOODSGANRENAMERF=M08.DETAILGOODSGANRENAMERF AND "
                    + "    Y.ENTERPRISEGANRECODERF=M08.ENTERPRISEGANRECODERF AND "
                    + "    Y.ENTERPRISEGANRENAMERF=M08.ENTERPRISEGANRENAMERF AND "
                    + "    Y.BLGOODSCODERF=M08.BLGOODSCODERF AND "
                    + "    Y.BLGOODSFULLNAMERF=M08.BLGOODSFULLNAMERF AND "
                    + "    Y.GOODSSHORTNAMERF=M08.GOODSSHORTNAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.GOODSMAKERCDRF=M08.GOODSMAKERCDRF AND "
                    + "    Y.GOODSNORF=M08.GOODSNORF ";
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
                    + " M09.MAKERNAMERF AS MAKERNAMERF, "
                    + " M09.LARGEGOODSGANRECODERF AS LARGEGOODSGANRECODERF, "
                    + " M09.LARGEGOODSGANRENAMERF AS LARGEGOODSGANRENAMERF, "
                    + " M09.MEDIUMGOODSGANRECODERF AS MEDIUMGOODSGANRECODERF, "
                    + " M09.MEDIUMGOODSGANRENAMERF AS MEDIUMGOODSGANRENAMERF, "
                    + " M09.DETAILGOODSGANRECODERF AS DETAILGOODSGANRECODERF, "
                    + " M09.DETAILGOODSGANRENAMERF AS DETAILGOODSGANRENAMERF, "
                    + " M09.ENTERPRISEGANRECODERF AS ENTERPRISEGANRECODERF, "
                    + " M09.ENTERPRISEGANRENAMERF AS ENTERPRISEGANRENAMERF, "
                    + " M09.BLGOODSCODERF AS BLGOODSCODERF, "
                    + " M09.BLGOODSFULLNAMERF AS BLGOODSFULLNAMERF, "
                    + " M09.GOODSSHORTNAMERF AS GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M09.GOODSMAKERCDRF AS GOODSMAKERCDRF, "
                    + " M09.GOODSNORF AS GOODSNORF, "
                    + " SUM(M09.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M09.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M09.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM GOODSMTTLSTSLIPRF M09 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M09", TermDiv.MonthBound, 8)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M09.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M09.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M09.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M09.SECTIONGUIDENMRF, ")
                    + " M09.MAKERNAMERF, "
                    + " M09.LARGEGOODSGANRECODERF, "
                    + " M09.LARGEGOODSGANRENAMERF, "
                    + " M09.MEDIUMGOODSGANRECODERF, "
                    + " M09.MEDIUMGOODSGANRENAMERF, "
                    + " M09.DETAILGOODSGANRECODERF, "
                    + " M09.DETAILGOODSGANRENAMERF, "
                    + " M09.ENTERPRISEGANRECODERF, "
                    + " M09.ENTERPRISEGANRENAMERF, "
                    + " M09.BLGOODSCODERF, "
                    + " M09.BLGOODSFULLNAMERF, "
                    + " M09.GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M09.GOODSMAKERCDRF, M09.GOODSNORF "
                    + ") M09 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M09.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M09.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M09.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M09.SECTIONGUIDENMRF AND ")
                    + "    Y.MAKERNAMERF=M09.MAKERNAMERF AND "
                    + "    Y.LARGEGOODSGANRECODERF=M09.LARGEGOODSGANRECODERF AND "
                    + "    Y.LARGEGOODSGANRENAMERF=M09.LARGEGOODSGANRENAMERF AND "
                    + "    Y.MEDIUMGOODSGANRECODERF=M09.MEDIUMGOODSGANRECODERF AND "
                    + "    Y.MEDIUMGOODSGANRENAMERF=M09.MEDIUMGOODSGANRENAMERF AND "
                    + "    Y.DETAILGOODSGANRECODERF=M09.DETAILGOODSGANRECODERF AND "
                    + "    Y.DETAILGOODSGANRENAMERF=M09.DETAILGOODSGANRENAMERF AND "
                    + "    Y.ENTERPRISEGANRECODERF=M09.ENTERPRISEGANRECODERF AND "
                    + "    Y.ENTERPRISEGANRENAMERF=M09.ENTERPRISEGANRENAMERF AND "
                    + "    Y.BLGOODSCODERF=M09.BLGOODSCODERF AND "
                    + "    Y.BLGOODSFULLNAMERF=M09.BLGOODSFULLNAMERF AND "
                    + "    Y.GOODSSHORTNAMERF=M09.GOODSSHORTNAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.GOODSMAKERCDRF=M09.GOODSMAKERCDRF AND "
                    + "    Y.GOODSNORF=M09.GOODSNORF ";
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
                    + " M10.MAKERNAMERF AS MAKERNAMERF, "
                    + " M10.LARGEGOODSGANRECODERF AS LARGEGOODSGANRECODERF, "
                    + " M10.LARGEGOODSGANRENAMERF AS LARGEGOODSGANRENAMERF, "
                    + " M10.MEDIUMGOODSGANRECODERF AS MEDIUMGOODSGANRECODERF, "
                    + " M10.MEDIUMGOODSGANRENAMERF AS MEDIUMGOODSGANRENAMERF, "
                    + " M10.DETAILGOODSGANRECODERF AS DETAILGOODSGANRECODERF, "
                    + " M10.DETAILGOODSGANRENAMERF AS DETAILGOODSGANRENAMERF, "
                    + " M10.ENTERPRISEGANRECODERF AS ENTERPRISEGANRECODERF, "
                    + " M10.ENTERPRISEGANRENAMERF AS ENTERPRISEGANRENAMERF, "
                    + " M10.BLGOODSCODERF AS BLGOODSCODERF, "
                    + " M10.BLGOODSFULLNAMERF AS BLGOODSFULLNAMERF, "
                    + " M10.GOODSSHORTNAMERF AS GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M10.GOODSMAKERCDRF AS GOODSMAKERCDRF, "
                    + " M10.GOODSNORF AS GOODSNORF, "
                    + " SUM(M10.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M10.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M10.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM GOODSMTTLSTSLIPRF M10 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M10", TermDiv.MonthBound, 9)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M10.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M10.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M10.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M10.SECTIONGUIDENMRF, ")
                    + " M10.MAKERNAMERF, "
                    + " M10.LARGEGOODSGANRECODERF, "
                    + " M10.LARGEGOODSGANRENAMERF, "
                    + " M10.MEDIUMGOODSGANRECODERF, "
                    + " M10.MEDIUMGOODSGANRENAMERF, "
                    + " M10.DETAILGOODSGANRECODERF, "
                    + " M10.DETAILGOODSGANRENAMERF, "
                    + " M10.ENTERPRISEGANRECODERF, "
                    + " M10.ENTERPRISEGANRENAMERF, "
                    + " M10.BLGOODSCODERF, "
                    + " M10.BLGOODSFULLNAMERF, "
                    + " M10.GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M10.GOODSMAKERCDRF, M10.GOODSNORF "
                    + ") M10 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M10.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M10.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M10.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M10.SECTIONGUIDENMRF AND ")
                    + "    Y.MAKERNAMERF=M10.MAKERNAMERF AND "
                    + "    Y.LARGEGOODSGANRECODERF=M10.LARGEGOODSGANRECODERF AND "
                    + "    Y.LARGEGOODSGANRENAMERF=M10.LARGEGOODSGANRENAMERF AND "
                    + "    Y.MEDIUMGOODSGANRECODERF=M10.MEDIUMGOODSGANRECODERF AND "
                    + "    Y.MEDIUMGOODSGANRENAMERF=M10.MEDIUMGOODSGANRENAMERF AND "
                    + "    Y.DETAILGOODSGANRECODERF=M10.DETAILGOODSGANRECODERF AND "
                    + "    Y.DETAILGOODSGANRENAMERF=M10.DETAILGOODSGANRENAMERF AND "
                    + "    Y.ENTERPRISEGANRECODERF=M10.ENTERPRISEGANRECODERF AND "
                    + "    Y.ENTERPRISEGANRENAMERF=M10.ENTERPRISEGANRENAMERF AND "
                    + "    Y.BLGOODSCODERF=M10.BLGOODSCODERF AND "
                    + "    Y.BLGOODSFULLNAMERF=M10.BLGOODSFULLNAMERF AND "
                    + "    Y.GOODSSHORTNAMERF=M10.GOODSSHORTNAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.GOODSMAKERCDRF=M10.GOODSMAKERCDRF AND "
                    + "    Y.GOODSNORF=M10.GOODSNORF ";
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
                    + " M11.MAKERNAMERF AS MAKERNAMERF, "
                    + " M11.LARGEGOODSGANRECODERF AS LARGEGOODSGANRECODERF, "
                    + " M11.LARGEGOODSGANRENAMERF AS LARGEGOODSGANRENAMERF, "
                    + " M11.MEDIUMGOODSGANRECODERF AS MEDIUMGOODSGANRECODERF, "
                    + " M11.MEDIUMGOODSGANRENAMERF AS MEDIUMGOODSGANRENAMERF, "
                    + " M11.DETAILGOODSGANRECODERF AS DETAILGOODSGANRECODERF, "
                    + " M11.DETAILGOODSGANRENAMERF AS DETAILGOODSGANRENAMERF, "
                    + " M11.ENTERPRISEGANRECODERF AS ENTERPRISEGANRECODERF, "
                    + " M11.ENTERPRISEGANRENAMERF AS ENTERPRISEGANRENAMERF, "
                    + " M11.BLGOODSCODERF AS BLGOODSCODERF, "
                    + " M11.BLGOODSFULLNAMERF AS BLGOODSFULLNAMERF, "
                    + " M11.GOODSSHORTNAMERF AS GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M11.GOODSMAKERCDRF AS GOODSMAKERCDRF, "
                    + " M11.GOODSNORF AS GOODSNORF, "
                    + " SUM(M11.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M11.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M11.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM GOODSMTTLSTSLIPRF M11 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M11", TermDiv.MonthBound, 10)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M11.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M11.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M11.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M11.SECTIONGUIDENMRF, ")
                    + " M11.MAKERNAMERF, "
                    + " M11.LARGEGOODSGANRECODERF, "
                    + " M11.LARGEGOODSGANRENAMERF, "
                    + " M11.MEDIUMGOODSGANRECODERF, "
                    + " M11.MEDIUMGOODSGANRENAMERF, "
                    + " M11.DETAILGOODSGANRECODERF, "
                    + " M11.DETAILGOODSGANRENAMERF, "
                    + " M11.ENTERPRISEGANRECODERF, "
                    + " M11.ENTERPRISEGANRENAMERF, "
                    + " M11.BLGOODSCODERF, "
                    + " M11.BLGOODSFULLNAMERF, "
                    + " M11.GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M11.GOODSMAKERCDRF, M11.GOODSNORF "
                    + ") M11 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M11.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M11.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M11.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M11.SECTIONGUIDENMRF AND ")
                    + "    Y.MAKERNAMERF=M11.MAKERNAMERF AND "
                    + "    Y.LARGEGOODSGANRECODERF=M11.LARGEGOODSGANRECODERF AND "
                    + "    Y.LARGEGOODSGANRENAMERF=M11.LARGEGOODSGANRENAMERF AND "
                    + "    Y.MEDIUMGOODSGANRECODERF=M11.MEDIUMGOODSGANRECODERF AND "
                    + "    Y.MEDIUMGOODSGANRENAMERF=M11.MEDIUMGOODSGANRENAMERF AND "
                    + "    Y.DETAILGOODSGANRECODERF=M11.DETAILGOODSGANRECODERF AND "
                    + "    Y.DETAILGOODSGANRENAMERF=M11.DETAILGOODSGANRENAMERF AND "
                    + "    Y.ENTERPRISEGANRECODERF=M11.ENTERPRISEGANRECODERF AND "
                    + "    Y.ENTERPRISEGANRENAMERF=M11.ENTERPRISEGANRENAMERF AND "
                    + "    Y.BLGOODSCODERF=M11.BLGOODSCODERF AND "
                    + "    Y.BLGOODSFULLNAMERF=M11.BLGOODSFULLNAMERF AND "
                    + "    Y.GOODSSHORTNAMERF=M11.GOODSSHORTNAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.GOODSMAKERCDRF=M11.GOODSMAKERCDRF AND "
                    + "    Y.GOODSNORF=M11.GOODSNORF ";
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
                    + " M12.MAKERNAMERF AS MAKERNAMERF, "
                    + " M12.LARGEGOODSGANRECODERF AS LARGEGOODSGANRECODERF, "
                    + " M12.LARGEGOODSGANRENAMERF AS LARGEGOODSGANRENAMERF, "
                    + " M12.MEDIUMGOODSGANRECODERF AS MEDIUMGOODSGANRECODERF, "
                    + " M12.MEDIUMGOODSGANRENAMERF AS MEDIUMGOODSGANRENAMERF, "
                    + " M12.DETAILGOODSGANRECODERF AS DETAILGOODSGANRECODERF, "
                    + " M12.DETAILGOODSGANRENAMERF AS DETAILGOODSGANRENAMERF, "
                    + " M12.ENTERPRISEGANRECODERF AS ENTERPRISEGANRECODERF, "
                    + " M12.ENTERPRISEGANRENAMERF AS ENTERPRISEGANRENAMERF, "
                    + " M12.BLGOODSCODERF AS BLGOODSCODERF, "
                    + " M12.BLGOODSFULLNAMERF AS BLGOODSFULLNAMERF, "
                    + " M12.GOODSSHORTNAMERF AS GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M12.GOODSMAKERCDRF AS GOODSMAKERCDRF, "
                    + " M12.GOODSNORF AS GOODSNORF, "
                    + " SUM(M12.TOTALSTOCKCOUNTRF) AS S_TOTALSTOCKCOUNTRF, "
                    + " SUM(M12.STOCKTOTALPRICERF) AS S_STOCKTOTALPRICERF, "
                    + " SUM(M12.STOCKRETGOODSPRICERF) AS S_STOCKRETGOODSPRICERF "
                    + " FROM GOODSMTTLSTSLIPRF M12 "
                    + MakeWhereString(ref sqlCommand, cndtnWork, "M12", TermDiv.MonthBound, 11)
                    + " GROUP BY "
                    + IFBySection(GroupBySectionDiv, "M12.STOCKSECTIONCDRF, ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "M12.COMPANYNAME1RF, ")
                    + IFBySection(GroupBySectionDiv, "M12.COMPANYNAME2RF, ")
                    + IFBySection(GroupBySectionDiv, "M12.SECTIONGUIDENMRF, ")
                    + " M12.MAKERNAMERF, "
                    + " M12.LARGEGOODSGANRECODERF, "
                    + " M12.LARGEGOODSGANRENAMERF, "
                    + " M12.MEDIUMGOODSGANRECODERF, "
                    + " M12.MEDIUMGOODSGANRENAMERF, "
                    + " M12.DETAILGOODSGANRECODERF, "
                    + " M12.DETAILGOODSGANRENAMERF, "
                    + " M12.ENTERPRISEGANRECODERF, "
                    + " M12.ENTERPRISEGANRENAMERF, "
                    + " M12.BLGOODSCODERF, "
                    + " M12.BLGOODSFULLNAMERF, "
                    + " M12.GOODSSHORTNAMERF, "
                    // ↑ 2008.04.02 980081 a
                    + " M12.GOODSMAKERCDRF, M12.GOODSNORF "
                    + ") M12 "
                    + "ON "
                    + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF=M12.STOCKSECTIONCDRF AND ")
                    // ↓ 2008.04.02 980081 a
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF=M12.COMPANYNAME1RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF=M12.COMPANYNAME2RF AND ")
                    + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF=M12.SECTIONGUIDENMRF AND ")
                    + "    Y.MAKERNAMERF=M12.MAKERNAMERF AND "
                    + "    Y.LARGEGOODSGANRECODERF=M12.LARGEGOODSGANRECODERF AND "
                    + "    Y.LARGEGOODSGANRENAMERF=M12.LARGEGOODSGANRENAMERF AND "
                    + "    Y.MEDIUMGOODSGANRECODERF=M12.MEDIUMGOODSGANRECODERF AND "
                    + "    Y.MEDIUMGOODSGANRENAMERF=M12.MEDIUMGOODSGANRENAMERF AND "
                    + "    Y.DETAILGOODSGANRECODERF=M12.DETAILGOODSGANRECODERF AND "
                    + "    Y.DETAILGOODSGANRENAMERF=M12.DETAILGOODSGANRENAMERF AND "
                    + "    Y.ENTERPRISEGANRECODERF=M12.ENTERPRISEGANRECODERF AND "
                    + "    Y.ENTERPRISEGANRENAMERF=M12.ENTERPRISEGANRENAMERF AND "
                    + "    Y.BLGOODSCODERF=M12.BLGOODSCODERF AND "
                    + "    Y.BLGOODSFULLNAMERF=M12.BLGOODSFULLNAMERF AND "
                    + "    Y.GOODSSHORTNAMERF=M12.GOODSSHORTNAMERF AND "
                    // ↑ 2008.04.02 980081 a
                    + "    Y.GOODSMAKERCDRF=M12.GOODSMAKERCDRF AND "
                    + "    Y.GOODSNORF=M12.GOODSNORF ";
            }
            /*    */
            Text+= MakeWhereString(ref sqlCommand, cndtnWork, "Y", TermDiv.YearBound, 0)
                + "GROUP BY "
                + IFBySection(GroupBySectionDiv, "Y.STOCKSECTIONCDRF, ")
                + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF, ")
                + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF, ")
                + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF, ")
                + "Y.GOODSMAKERCDRF, Y.MAKERNAMERF, "
                + "Y.LARGEGOODSGANRECODERF, Y.LARGEGOODSGANRENAMERF, Y.MEDIUMGOODSGANRECODERF, Y.MEDIUMGOODSGANRENAMERF, "
                // ↓ 2008.03.06 980081 c
                //+ "Y.DETAILGOODSGANRECODERF, Y.DETAILGOODSGANRENAMERF, Y.BLGOODSCODERF, Y.BLGOODSFULLNAMERF, Y.GOODSNORF, Y.GOODSSHORTNAMERF "
                + "Y.DETAILGOODSGANRECODERF, Y.DETAILGOODSGANRENAMERF, Y.ENTERPRISEGANRECODERF, Y.ENTERPRISEGANRENAMERF, Y.BLGOODSCODERF, Y.BLGOODSFULLNAMERF, Y.GOODSNORF, Y.GOODSSHORTNAMERF "
                // ↑ 2008.03.06 980081 c
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
                //+ "Y.GOODSMAKERCDRF, Y.LARGEGOODSGANRECODERF, Y.MEDIUMGOODSGANRECODERF, Y.DETAILGOODSGANRECODERF, "
                //// ↓ 2008.03.06 980081 a
                //+ "Y.ENTERPRISEGANRECODERF, Y.ENTERPRISEGANRENAMERF, "
                //// ↑ 2008.03.06 980081 
                //+ "Y.BLGOODSCODERF, Y.GOODSNORF ";
                + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME1RF, ")
                + IFBySection(GroupBySectionDiv, "Y.COMPANYNAME2RF, ")
                + IFBySection(GroupBySectionDiv, "Y.SECTIONGUIDENMRF, ")
                + "Y.GOODSMAKERCDRF, Y.MAKERNAMERF, "
                + "Y.LARGEGOODSGANRECODERF, Y.LARGEGOODSGANRENAMERF, Y.MEDIUMGOODSGANRECODERF, Y.MEDIUMGOODSGANRENAMERF, "
                + "Y.DETAILGOODSGANRECODERF, Y.DETAILGOODSGANRENAMERF, Y.ENTERPRISEGANRECODERF, Y.ENTERPRISEGANRENAMERF, Y.BLGOODSCODERF, Y.BLGOODSFULLNAMERF, Y.GOODSNORF, Y.GOODSSHORTNAMERF ";
                // ↑ 2008.04.02 980081 c

            return Text;
        }
        #endregion  //[GoodsMTtlStSlip用 Select文生成処理]

        #region [GoodsMTtlStSlip用 Where句生成処理]
        /// <summary>
        /// 商品別仕入月次集計データ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="cndtnWork">検索条件格納クラス</param>
        /// <param name="refName">参照名称</param>
        /// <param name="termDiv">集計期間区分  0:指定月  1:当期範囲</param>
        /// <param name="monthIndex">月インデックス 集計期間区分=0のとき使用する </param>
        /// <returns>商品別仕入月次集計データ用WHERE句</returns>
        /// <br>Note       : 商品別仕入月次集計データ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 山田 明友</br>
        /// <br>Date       : 2007.11.30</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockTransListCndtnWork cndtnWork, string refName, TermDiv termDiv, int monthIndex)
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

            //開始商品番号
            if (cndtnWork.St_GoodsNo != "")
            {
                text += "AND " + refName + ".GOODSNORF>=@ST_GOODSNO ";
                if (sqlCommand.Parameters.IndexOf("@ST_GOODSNO") < 0)
                {
                    SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@ST_GOODSNO", SqlDbType.NVarChar);
                    paraStGoodsNo.Value = SqlDataMediator.SqlSetString(cndtnWork.St_GoodsNo);
                }
            }

            //終了商品番号
            if (cndtnWork.Ed_GoodsNo != "")
            {
                text += "AND " + refName + ".GOODSNORF<=@ED_GOODSNO ";
                if (sqlCommand.Parameters.IndexOf("@ED_GOODSNO") < 0)
                {
                    SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@ED_GOODSNO", SqlDbType.NVarChar);
                    paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(cndtnWork.Ed_GoodsNo);
                }
            }

            //開始区分グループコード
            if (cndtnWork.St_LargeGoodsGanreCode != "")
            {
                text += "AND " + refName + ".LARGEGOODSGANRECODERF>=@ST_LARGEGOODSGANRECODE ";
                if (sqlCommand.Parameters.IndexOf("@ST_LARGEGOODSGANRECODE") < 0)
                {
                    SqlParameter paraStLargeGoodsGanreCode = sqlCommand.Parameters.Add("@ST_LARGEGOODSGANRECODE", SqlDbType.NChar);
                    paraStLargeGoodsGanreCode.Value = SqlDataMediator.SqlSetString(cndtnWork.St_LargeGoodsGanreCode);
                }
            }

            //終了区分グループコード
            if (cndtnWork.Ed_LargeGoodsGanreCode != "")
            {
                text += "AND " + refName + ".LARGEGOODSGANRECODERF<=@ED_LARGEGOODSGANRECODE ";
                if (sqlCommand.Parameters.IndexOf("@ED_LARGEGOODSGANRECODE") < 0)
                {
                    SqlParameter paraEdLargeGoodsGanreCode = sqlCommand.Parameters.Add("@ED_LARGEGOODSGANRECODE", SqlDbType.NChar);
                    paraEdLargeGoodsGanreCode.Value = SqlDataMediator.SqlSetString(cndtnWork.Ed_LargeGoodsGanreCode);
                }
            }

            //開始区分コード
            if (cndtnWork.St_MediumGoodsGanreCode != "")
            {
                text += "AND " + refName + ".MEDIUMGOODSGANRECODERF>=@ST_MEDIUMGOODSGANRECODE ";
                if (sqlCommand.Parameters.IndexOf("@ST_MEDIUMGOODSGANRECODE") < 0)
                {
                    SqlParameter paraStMediumGoodsGanreCode = sqlCommand.Parameters.Add("@ST_MEDIUMGOODSGANRECODE", SqlDbType.NChar);
                    paraStMediumGoodsGanreCode.Value = SqlDataMediator.SqlSetString(cndtnWork.St_MediumGoodsGanreCode);
                }
            }

            //終了区分コード
            if (cndtnWork.Ed_MediumGoodsGanreCode != "")
            {
                text += "AND " + refName + ".MEDIUMGOODSGANRECODERF<=@ED_MEDIUMGOODSGANRECODE ";
                if (sqlCommand.Parameters.IndexOf("@ED_MEDIUMGOODSGANRECODE") < 0)
                {
                    SqlParameter paraEdMediumGoodsGanreCode = sqlCommand.Parameters.Add("@ED_MEDIUMGOODSGANRECODE", SqlDbType.NChar);
                    paraEdMediumGoodsGanreCode.Value = SqlDataMediator.SqlSetString(cndtnWork.Ed_MediumGoodsGanreCode);
                }
            }

            //開始区分詳細コード
            if (cndtnWork.St_DetailGoodsGanreCode != "")
            {
                text += "AND " + refName + ".DETAILGOODSGANRECODERF>=@ST_DETAILGOODSGANRECODE ";
                if (sqlCommand.Parameters.IndexOf("@ST_DETAILGOODSGANRECODE") < 0)
                {
                    SqlParameter paraStDetailGoodsGanreCode = sqlCommand.Parameters.Add("@ST_DETAILGOODSGANRECODE", SqlDbType.NChar);
                    paraStDetailGoodsGanreCode.Value = SqlDataMediator.SqlSetString(cndtnWork.St_DetailGoodsGanreCode);
                }
            }

            //終了区分詳細コード
            if (cndtnWork.Ed_DetailGoodsGanreCode != "")
            {
                text += "AND " + refName + ".DETAILGOODSGANRECODERF<=@ED_DETAILGOODSGANRECODE ";
                if (sqlCommand.Parameters.IndexOf("@ED_DETAILGOODSGANRECODE") < 0)
                {
                    SqlParameter paraEdDetailGoodsGanreCode = sqlCommand.Parameters.Add("@ED_DETAILGOODSGANRECODE", SqlDbType.NChar);
                    paraEdDetailGoodsGanreCode.Value = SqlDataMediator.SqlSetString(cndtnWork.Ed_DetailGoodsGanreCode);
                }
            }

            // ↓ 2008.03.06 980081 a
            //開始自社分類コード
            if (cndtnWork.St_EnterpriseGanreCode != 0)
            {
                text += "AND " + refName + ".ENTERPRISEGANRECODERF>=@ST_ENTERPRISEGANRECODE ";
                if (sqlCommand.Parameters.IndexOf("@ST_ENTERPRISEGANRECODE") < 0)
                {
                    SqlParameter paraStEnterpriseGanreCode = sqlCommand.Parameters.Add("@ST_ENTERPRISEGANRECODE", SqlDbType.Int);
                    paraStEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(cndtnWork.St_EnterpriseGanreCode);
                }
            }

            //終了自社分類コード
            if (cndtnWork.Ed_EnterpriseGanreCode != 0)
            {
                text += "AND " + refName + ".ENTERPRISEGANRECODERF<=@ED_ENTERPRISEGANRECODE ";
                if (sqlCommand.Parameters.IndexOf("@ED_ENTERPRISEGANRECODE") < 0)
                {
                    SqlParameter paraEdEnterpriseGanreCode = sqlCommand.Parameters.Add("@ED_ENTERPRISEGANRECODE", SqlDbType.Int);
                    paraEdEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(cndtnWork.Ed_EnterpriseGanreCode);
                }
            }
            // ↑ 2008.03.06 980081 a

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

            //開始BL商品コード
            if (cndtnWork.St_BLGoodsCode != 0)
            {
                text += "AND " + refName + ".BLGOODSCODERF>=@ST_BLGOODSCODE ";
                if (sqlCommand.Parameters.IndexOf("@ST_BLGOODSCODE") < 0)
                {
                    SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@ST_BLGOODSCODE", SqlDbType.Int);
                    paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(cndtnWork.St_BLGoodsCode);
                }
            }

            //終了BL商品コード
            if (cndtnWork.Ed_BLGoodsCode != 0)
            {
                text += "AND " + refName + ".BLGOODSCODERF<=@ED_BLGOODSCODE ";
                if (sqlCommand.Parameters.IndexOf("@ED_BLGOODSCODE") < 0)
                {
                    SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@ED_BLGOODSCODE", SqlDbType.Int);
                    paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(cndtnWork.Ed_BLGoodsCode);
                }
            }

            //開始メーカーコード
            if (cndtnWork.St_BLGoodsCode != 0)
            {
                text += "AND " + refName + ".BLGOODSCODERF>=@ST_BLGOODSCODE ";
                if (sqlCommand.Parameters.IndexOf("@ST_BLGOODSCODE") < 0)
                {
                    SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@ST_BLGOODSCODE", SqlDbType.Int);
                    paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(cndtnWork.St_BLGoodsCode);
                }
            }

            //終了メーカーコード
            if (cndtnWork.Ed_BLGoodsCode != 0)
            {
                text += "AND " + refName + ".BLGOODSCODERF<=@ED_BLGOODSCODE ";
                if (sqlCommand.Parameters.IndexOf("@ED_BLGOODSCODE") < 0)
                {
                    SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@ED_BLGOODSCODE", SqlDbType.Int);
                    paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(cndtnWork.Ed_BLGoodsCode);
                }
            }

            return text;

        }
        #endregion //[GoodsMTtlStSlip用 Where句生成処理]

        #region [GoodsMTtlStSlip用 Having句生成処理]
        /// <summary>
        /// 商品別仕入月次集計データ用HAVING句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="cndtnWork">検索条件格納クラス</param>
        /// <param name="refName"></param>
        /// <param name="termDiv"></param>
        /// <returns>商品別仕入月次集計データ用HAVING句</returns>
        /// <br>Note       : 商品別仕入月次集計データ用HAVING句を作成して戻します</br>
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
        #endregion //[GoodsMTtlStSlip用 Having句生成処理]

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
            ResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            ResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            ResultWork.LargeGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRECODERF"));
            ResultWork.LargeGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRENAMERF"));
            ResultWork.MediumGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRECODERF"));
            ResultWork.MediumGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRENAMERF"));
            ResultWork.DetailGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRECODERF"));
            ResultWork.DetailGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRENAMERF"));
            // ↓ 2008.03.06 980081 a
            ResultWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            ResultWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
            // ↑ 2008.03.06 980081 a
            ResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            ResultWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            ResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            ResultWork.GoodsShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSHORTNAMERF"));

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
