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
    class MTtlStSlipBL : MTtlStSlipBase, IMTtlStSlip
    {
        #region [MTtlStockSlip用 Select文生成処理]
        /// <summary>
        /// 仕入月次集計データ用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件格納クラス</param>
        /// <returns>仕入月次集計データ用SELECT文</returns>
        /// <br>Note       : 仕入月次集計データ用SELECT文を作成して戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, StockMonthYearReportParamWork paramWork)
        {
            return MakeSelectStringProc(ref sqlCommand, paramWork);
        }
        /// <summary>
        /// 仕入月次集計データ用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件格納クラス</param>
        /// <returns>仕入月次集計データ用SELECT文</returns>
        /// <br>Note       : 仕入月次集計データ用SELECT文を作成して戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.26</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, StockMonthYearReportParamWork paramWork)
        {
            Boolean bSection = false;
            Boolean bMaker = false;

            if (paramWork.TtlType != 0)
                bSection = true;
            if (paramWork.TotalType == (int)TotalTypes.n4_Maker)
                bMaker = true;

            string Text = "";

            Text += "SELECT "
                + "Y.ENTERPRISECODERF AS ENTERPRISECODERF, "
                + IFBy(bSection, "Y.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBy(bSection, "Y.SECTIONGUIDENMRF AS SECTIONGUIDENMRF, ")
                + IFBy(bMaker, "Y.GOODSMAKERCDRF AS GOODSMAKERCDRF, ")
                + IFBy(bMaker, "Y.MAKERNAMERF AS MAKERNAMERF, ")
                + "M.MS_TOTALSTOCKCOUNTRF AS MS_TOTALSTOCKCOUNTRF, "
                + "MA.MAS_STOCKTOTALPRICERF AS MS_STOCKTOTALPRICERF, "
                + "MB.MBS_STOCKRETGOODSPRICERF AS MS_STOCKRETGOODSPRICERF, "
                + "M.MS_STOCKTOTALDISCOUNTRF AS MS_STOCKTOTALDISCOUNTRF, "
                + "SUM(Y.TOTALSTOCKCOUNTRF) AS YS_TOTALSTOCKCOUNTRF, "
                + "YA.YAS_STOCKTOTALPRICERF AS YS_STOCKTOTALPRICERF, "
                + "YB.YBS_STOCKRETGOODSPRICERF AS YS_STOCKRETGOODSPRICERF, "
                + "SUM(Y.STOCKTOTALDISCOUNTRF) AS YS_STOCKTOTALDISCOUNTRF "
                + "FROM MTTLSTOCKSLIPRF Y ";

            Text += "LEFT JOIN "
                + "(SELECT "
                + "YA.ENTERPRISECODERF AS ENTERPRISECODERF, "
                + IFBy(bSection, " YA.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBy(bMaker, "YA.GOODSMAKERCDRF AS GOODSMAKERCDRF, ")
                + "SUM(YA.STOCKTOTALPRICERF) AS YAS_STOCKTOTALPRICERF "
                + "FROM MTTLSTOCKSLIPRF YA "
                + MakeWhereString(ref sqlCommand, paramWork, "YA", TermDiv.YearBound)
                + "AND YA.SUPPLIERSLIPCDRF=10 "     // 仕入
                + "GROUP BY "
                + "YA.ENTERPRISECODERF "
                + IFBy(bSection, ", YA.STOCKSECTIONCDRF ")
                + IFBy(bMaker, ", YA.GOODSMAKERCDRF ")
                + ") YA "
                + " ON "
                + "Y.ENTERPRISECODERF=YA.ENTERPRISECODERF "
                + IFBy(bSection, "AND Y.STOCKSECTIONCDRF=YA.STOCKSECTIONCDRF ")
                + IFBy(bMaker, "AND Y.GOODSMAKERCDRF=YA.GOODSMAKERCDRF ");

            Text += "LEFT JOIN "
                + "(SELECT "
                + "YB.ENTERPRISECODERF AS ENTERPRISECODERF, "
                + IFBy(bSection, " YB.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBy(bMaker, "YB.GOODSMAKERCDRF AS GOODSMAKERCDRF, ")
                + "SUM(YB.STOCKRETGOODSPRICERF) AS YBS_STOCKRETGOODSPRICERF "
                + "FROM MTTLSTOCKSLIPRF YB "
                + MakeWhereString(ref sqlCommand, paramWork, "YB", TermDiv.YearBound)
                + "AND YB.SUPPLIERSLIPCDRF=20 "     // 返品
                + "GROUP BY "
                + "YB.ENTERPRISECODERF "
                + IFBy(bSection, ", YB.STOCKSECTIONCDRF ")
                + IFBy(bMaker, ", YB.GOODSMAKERCDRF ")
                + ") YB "
                + " ON "
                + "Y.ENTERPRISECODERF=YB.ENTERPRISECODERF "
                + IFBy(bSection, "AND Y.STOCKSECTIONCDRF=YB.STOCKSECTIONCDRF ")
                + IFBy(bMaker, "AND Y.GOODSMAKERCDRF=YB.GOODSMAKERCDRF ");

            Text += "LEFT JOIN "
                + "(SELECT "
                + "M.ENTERPRISECODERF AS ENTERPRISECODERF, "
                + IFBy(bSection, " M.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBy(bMaker,"M.GOODSMAKERCDRF AS GOODSMAKERCDRF, ")
                + "SUM(M.TOTALSTOCKCOUNTRF) AS MS_TOTALSTOCKCOUNTRF, "
                + "SUM(M.STOCKTOTALDISCOUNTRF) AS MS_STOCKTOTALDISCOUNTRF "
                + "FROM MTTLSTOCKSLIPRF M "
                + MakeWhereString(ref sqlCommand, paramWork, "M", TermDiv.MonthBound)
                + "GROUP BY "
                + "M.ENTERPRISECODERF "
                + IFBy(bSection, ", M.STOCKSECTIONCDRF ")
                + IFBy(bMaker,", M.GOODSMAKERCDRF ")
                + ") M "
                + "ON "
                + "Y.ENTERPRISECODERF=M.ENTERPRISECODERF "
                + IFBy(bSection, "AND Y.STOCKSECTIONCDRF=M.STOCKSECTIONCDRF ")
                + IFBy(bMaker, "AND Y.GOODSMAKERCDRF=M.GOODSMAKERCDRF ");

            Text += "LEFT JOIN "
                + "(SELECT "
                + "MA.ENTERPRISECODERF AS ENTERPRISECODERF, "
                + IFBy(bSection, " MA.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBy(bMaker,"MA.GOODSMAKERCDRF AS GOODSMAKERCDRF, ")
                + "SUM(MA.STOCKTOTALPRICERF) AS MAS_STOCKTOTALPRICERF "
                + "FROM MTTLSTOCKSLIPRF MA "
                + MakeWhereString(ref sqlCommand, paramWork, "MA", TermDiv.YearBound)
                + "AND MA.SUPPLIERSLIPCDRF=10 "     // 仕入
                + "GROUP BY "
                + "MA.ENTERPRISECODERF "
                + IFBy(bSection, ", MA.STOCKSECTIONCDRF ")
                + IFBy(bMaker,", MA.GOODSMAKERCDRF ")
                + ") MA "
                + " ON "
                + "Y.ENTERPRISECODERF=MA.ENTERPRISECODERF "
                + IFBy(bSection, "AND Y.STOCKSECTIONCDRF=MA.STOCKSECTIONCDRF ")
                + IFBy(bMaker,"AND Y.GOODSMAKERCDRF=MA.GOODSMAKERCDRF ");

            Text += "LEFT JOIN "
                + "(SELECT "
                + "MB.ENTERPRISECODERF AS ENTERPRISECODERF, "
                + IFBy(bSection, " MB.STOCKSECTIONCDRF AS STOCKSECTIONCDRF, ")
                + IFBy(bMaker,"MB.GOODSMAKERCDRF AS GOODSMAKERCDRF, ")
                + "SUM(MB.STOCKRETGOODSPRICERF) AS MBS_STOCKRETGOODSPRICERF "
                + "FROM MTTLSTOCKSLIPRF MB "
                + MakeWhereString(ref sqlCommand, paramWork, "MB", TermDiv.YearBound)
                + "AND MB.SUPPLIERSLIPCDRF=20 "      // 返品
                + "GROUP BY "
                + "MB.ENTERPRISECODERF "
                + IFBy(bSection, ", MB.STOCKSECTIONCDRF ")
                + IFBy(bMaker, ", MB.GOODSMAKERCDRF ")
                + ") MB "
                + " ON "
                + "Y.ENTERPRISECODERF=MB.ENTERPRISECODERF "
                + IFBy(bSection, "AND Y.STOCKSECTIONCDRF=MB.STOCKSECTIONCDRF ")
                + IFBy(bMaker, "AND Y.GOODSMAKERCDRF=MB.GOODSMAKERCDRF ");

            Text += MakeWhereString(ref sqlCommand, paramWork, "Y", TermDiv.YearBound)
                + "GROUP BY "
                + "Y.ENTERPRISECODERF, "
                + IFBy(bSection, "Y.STOCKSECTIONCDRF, ")
                + IFBy(bSection, "Y.SECTIONGUIDENMRF, ")
                + IFBy(bMaker, "Y.GOODSMAKERCDRF, Y.MAKERNAMERF, ")
                + "M.MS_TOTALSTOCKCOUNTRF, MA.MAS_STOCKTOTALPRICERF, MB.MBS_STOCKRETGOODSPRICERF, "
                + "M.MS_STOCKTOTALDISCOUNTRF, "
                + "YA.YAS_STOCKTOTALPRICERF, YB.YBS_STOCKRETGOODSPRICERF "
                + IFBy(bSection || bMaker, "ORDER BY ")
                + IFBy(bSection, "Y.STOCKSECTIONCDRF ")
                + IFBy(bSection && bMaker, ",")
                + IFBy(bMaker, "Y.GOODSMAKERCDRF ");

            return Text;
        }
        #endregion  //[MTtlStockSlip用 Select文生成処理]

        #region [MTtlStockSlip用 Where句生成処理]
        /// <summary>
        /// 仕入月次集計データ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件格納クラス</param>
        /// <param name="refName">テーブル名</param>
        /// <param name="termDiv">集計期間区分  0:指定月範囲  1:当期範囲</param>
        /// <returns>仕入月次集計データ用WHERE句</returns>
        /// <br>Note       : 仕入月次集計データ用WHERE句を作成して戻します</br>
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

           //開始メーカーコード
            if (paramWork.GoodsMakerCdSt != 0)
            {
                text += "AND " + refName + ".GOODSMAKERCDRF>=@ST_GOODSMAKERCD ";
                if (sqlCommand.Parameters.IndexOf("@ST_GOODSMAKERCD") < 0)
                {
                    SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@ST_GOODSMAKERCD", SqlDbType.Int);
                    paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCdSt);
                }
            }

            //終了メーカーコード
            if (paramWork.GoodsMakerCdEd != 0)
            {
                text += "AND " + refName + ".GOODSMAKERCDRF<=@ED_GOODSMAKERCD ";
                if (sqlCommand.Parameters.IndexOf("@ED_GOODSMAKERCD") < 0)
                {
                    SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@ED_GOODSMAKERCD", SqlDbType.Int);
                    paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCdEd);
                }
            }

            return text;

        }
        #endregion //[MTtlStockSlip用 Where句生成処理]

        #region [CopyToResultWorkFromReader処理]
        /// <summary>
        /// クラス格納処理 Reader → CopyToSalesRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">検索条件格納クラス</param>
        /// <returns>StockMonthYearReportResultWork</returns>
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
        /// <returns>StockMonthYearReportResultWork</returns>
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
            if (paramWork.TotalType == (int)TotalTypes.n4_Maker)
            {
                resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                resultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
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
        #endregion //[CopyToResultWorkFromReader処理]

    }
}
