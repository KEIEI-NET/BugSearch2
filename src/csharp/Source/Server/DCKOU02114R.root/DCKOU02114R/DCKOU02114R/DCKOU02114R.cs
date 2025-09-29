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
    /// 仕入日報月報DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入日報月報の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.09.06</br>
    /// <br></br>
    /// <br>Update Note: 2008.04.23  30290</br>
    /// <br>             得意先・仕入先分離対応</br>
    /// <br>Update Note: 2008.07.11  23015  森本  大輝</br>
    /// <br>             PM.NS対応</br>
    /// <br></br>
    /// <br>Update Note: 抽出拠点の変更(ログイン拠点から計上拠点に変更)</br>
    /// <br>Programmer : 23012　畠中 啓次朗</br>
    /// <br>Date       : 2009.04.06</br>
    /// <br></br>
    /// <br>Update Note: 抽出拠点の変更(仕入計上拠点から仕入拠点に変更)</br>
    /// <br>Programmer : 23012　畠中 啓次朗</br>
    /// <br>Date       : 2009/06/10</br>
    /// <br></br>
    /// <br>Update Note: 2009/09/08 黄偉兵</br>
    /// <br>               PM.NS-2-B・ＰＭ．ＮＳ保守依頼①</br>
    /// <br>                         過去分表示対応</br>
    /// <br></br>
    /// <br>Update Note: 速度チューニング</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2010/05/10</br>
    /// <br>Update Note: 2013/03/13配信分、Redmine#33820 仕入日報月報/仕入れ金額が不正の修正</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>Programmer : 李亜博</br>
    /// <br>Date       : 2013/01/08</br> 
    /// <br>Update Note: デットロックのトレース解析(仕：2677/依：11100068-00)</br>
    /// <br>             Redmine #44965 仕入日報月報ブロック障害の防止</br>
    /// <br>Date       : 2015/03/23</br>
    /// <br>           : 楊　揚</br>
    /// </remarks>
    [Serializable]
    public class StockDayMonthReportDB : RemoteDB, IStockDayMonthReportDB
    {
        /// <summary>
        /// 仕入日報月報リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.06</br>
        /// </remarks>
        public StockDayMonthReportDB()
            :
            base("DCKOU02116D", "Broadleaf.Application.Remoting.ParamData.StockDayMonthReportDataWork", "STOCKCONFRF")
        {
        }

        #region [Search]

        // Add by 楊揚　2015/03/23 for redmine #44965 ブロック障害の防止 ---->>>>>
        /// <summary>
        /// トランザクション分離レベルを「READ UNCOMMITTED」に設定します。
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        /// <br>Note       : トランザクション分離レベルの設定</br>
        /// <br>Programmer : 楊　揚</br>
        /// <br>Date       : 2015.03.23</br>
        private static void SetTransIsolationReadUncommitted(SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED", conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        // Add by 楊揚　2015/03/23 for redmine #44965 ブロック障害の防止 ----<<<<<

        /// <summary>
        /// 指定された条件の仕入日報月報情報LISTを戻します
        /// </summary>
        /// <param name="stockDayMonthReportDataWork">検索結果</param>
        /// <param name="parastockDayMonthReportWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入日報月報情報LISTを戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.</br>
        /// <br>Update Note: 2008.07.11  23015  森本  大輝</br>
        /// <br>             PM.NS対応</br>
        public int Search(out object stockDayMonthReportDataWork, object parastockDayMonthReportWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlEncryptInfo sqlEncryptInfo = null;

            stockDayMonthReportDataWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                    return status;
                sqlConnection.Open();

                SetTransIsolationReadUncommitted(sqlConnection); // Add by 楊揚　2015/03/23 for redmine #44965 ブロック障害の防止 

                return SearchProc(out stockDayMonthReportDataWork, parastockDayMonthReportWork, ref sqlConnection, ref sqlEncryptInfo);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockDayMonthReportDB.Search");
                stockDayMonthReportDataWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の仕入日報月報情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockDayMonthReportDataWork">検索結果</param>
        /// <param name="parastockDayMonthReportWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlEncryptInfo">sqlEncryptInfo</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入日報月報情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        public int SearchProc(out object stockDayMonthReportDataWork, object parastockDayMonthReportWork, ref SqlConnection sqlConnection, ref SqlEncryptInfo sqlEncryptInfo)
        {
            StockDayMonthReportWork stockDayMonthReportWork = null;

            ArrayList stockDayMonthReportWorkList = parastockDayMonthReportWork as ArrayList;
            ArrayList stockDayMonthReportDataWorkList = new ArrayList();

            if (stockDayMonthReportWorkList == null)
            {
                stockDayMonthReportWork = parastockDayMonthReportWork as StockDayMonthReportWork;
            }
            else
            {
                if (stockDayMonthReportWorkList.Count > 0)
                    stockDayMonthReportWork = stockDayMonthReportWorkList[0] as StockDayMonthReportWork;
            }

            int status = SearchProc(out stockDayMonthReportDataWorkList, stockDayMonthReportWork, ref sqlConnection, ref sqlEncryptInfo);
            
            stockDayMonthReportDataWork = stockDayMonthReportDataWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の仕入日報月報情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockDayMonthReportDataWorkList">検索結果</param>
        /// <param name="stockDayMonthReportWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlEncryptInfo">sqlEncryptInfo</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入日報月報情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        /// <br>Update Note: 2008.07.11  23015  森本  大輝</br>
        /// <br>             PM.NS対応</br>
		public int SearchProc(out ArrayList stockDayMonthReportDataWorkList, StockDayMonthReportWork stockDayMonthReportWork, ref SqlConnection sqlConnection, ref SqlEncryptInfo sqlEncryptInfo)
		{
			return this.SearchProcProc(out stockDayMonthReportDataWorkList, stockDayMonthReportWork, ref sqlConnection, ref sqlEncryptInfo);
		}

        /// <summary>
        /// 指定された条件の仕入日報月報情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockDayMonthReportDataWorkList">検索結果</param>
        /// <param name="stockDayMonthReportWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlEncryptInfo">sqlEncryptInfo</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入日報月報情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        /// <br>Update Note: 2008.07.11  23015  森本  大輝</br>
        /// <br>             PM.NS対応</br>
        /// <br>Update Note: 2009/09/08 黄偉兵</br>
        /// <br>               PM.NS-2-B・ＰＭ．ＮＳ保守依頼①</br>
        /// <br>                         過去分表示対応</br>
        /// <br>Update Note: 2013/01/08 李亜博</br>
        /// <br>管理番号   : 10801804-00</br>
        /// <br>             2013/03/13配信分、Redmine#33820 仕入日報月報/仕入れ金額が不正の修正</br>
		private int SearchProcProc(out ArrayList stockDayMonthReportDataWorkList, StockDayMonthReportWork stockDayMonthReportWork, ref SqlConnection sqlConnection, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                string sqlText = "";

                // --- ADD 2008/07/11 ---------->>>>>
                // 対象テーブル
                // STOCKSLIPRF    SLIP  仕入データ
                // STOCKDETAILRF  DTIL  仕入明細データ
                // SECINFOSETRF   SECI  拠点情報設定マスタ

                #region SELECT文作成
                sqlText += "SELECT" + Environment.NewLine;
                // 修正 2009/06/10 >>>
                //// 修正 2009.04.06 >>>
                ////sqlText += "DTIL.SECTIONCODERF" + Environment.NewLine;
                //sqlText += "DTIL.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                //// 修正 2009.04.06 <<<
                sqlText += "DTIL.STOCKSECTIONCDRF" + Environment.NewLine;
                // 修正 2009/06/10 <<<
                sqlText += ",SECI.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlText += ",DTIL.SUPPLIERCDRF" + Environment.NewLine;
                //sqlText += ",DTIL.SUPPLIERSNMRF" + Environment.NewLine;//DEL 2013/01/08 李亜博 for Redmine#33820
                sqlText += ",SUPP.SUPPLIERSNMRF" + Environment.NewLine;//ADD 2013/01/08 李亜博 for Redmine#33820
                sqlText += ",DTIL.STOCKSLIPCDDTLRF" + Environment.NewLine;
                sqlText += ",DTIL.STOCKORDERDIVCDRF" + Environment.NewLine;
                sqlText += ",DTIL.DAYSTOCKPRICETAXEXC" + Environment.NewLine;
                sqlText += ",DTIL.MONTHSTOCKPRICETAXEXC" + Environment.NewLine;
                // --- ADD 2009/09/08 ---------->>>>>
                // 仕入数
                sqlText += " ,DTIL.STOCKCOUNTRF" + Environment.NewLine;
                // --- ADD 2009/09/08 ----------<<<<<
                sqlText += " FROM" + Environment.NewLine;
                sqlText += " (" + Environment.NewLine;

                #region [データ抽出メインQuery]
                sqlText += " SELECT" + Environment.NewLine;
                sqlText += "    SLIPS.ENTERPRISECODERF" + Environment.NewLine;
                // 修正 2009/06/10 >>>
                // 修正 2009.04.06 >>>
                ////sqlText += "   ,SLIPS.SECTIONCODERF" + Environment.NewLine;
                //sqlText += "   ,SLIPS.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                //// 修正 2009.04.06 <<<
                sqlText += "   ,SLIPS.STOCKSECTIONCDRF" + Environment.NewLine;
                // 修正 2009/06/10 <<<
                sqlText += "   ,SLIPS.SUPPLIERCDRF" + Environment.NewLine;
                //sqlText += "   ,SLIPS.SUPPLIERSNMRF" + Environment.NewLine;//DEL 2013/01/08 李亜博 for Redmine#33820
                sqlText += "   ,DTILM.STOCKORDERDIVCDRF" + Environment.NewLine;
                sqlText += "   ,DTILM.STOCKSLIPCDDTLRF" + Environment.NewLine;
                sqlText += "   ,DTILD.DAYSTOCKPRICETAXEXC" + Environment.NewLine;
                sqlText += "   ,DTILM.MONTHSTOCKPRICETAXEXC" + Environment.NewLine;
                // --- ADD 2009/09/08 ---------->>>>>
                // 仕入数
                sqlText += "   ,DTILM.STOCKCOUNTRF" + Environment.NewLine;
                // --- ADD 2009/09/08 ----------<<<<<
                sqlText += "  FROM" + Environment.NewLine;
                sqlText += "  (" + Environment.NewLine;

                #region [仕入データ]
                sqlText += "   SELECT" + Environment.NewLine;
                sqlText += "     SLIPSSUB.ENTERPRISECODERF" + Environment.NewLine;
                // 修正 2009/06/10 >>>
                //// 修正 2009.04.06 >>>
                ////sqlText += "    ,SLIPSSUB.SECTIONCODERF" + Environment.NewLine;
                //sqlText += "    ,SLIPSSUB.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                //// 修正 2009.04.06 <<<
                sqlText += "    ,SLIPSSUB.STOCKSECTIONCDRF" + Environment.NewLine;
                // 修正 2009/06/10 <<<
                sqlText += "    ,SLIPSSUB.SUPPLIERCDRF" + Environment.NewLine;
                //sqlText += "    ,SLIPSSUB.SUPPLIERSNMRF" + Environment.NewLine;//DEL 2013/01/08 李亜博 for Redmine#33820
                // sqlText += "   FROM STOCKSLIPRF AS SLIPSSUB" + Environment.NewLine; // DEL 2009/09/08
                sqlText += "   FROM STOCKSLIPHISTRF AS SLIPSSUB" + Environment.NewLine; // ADD 2009/09/08
                sqlText += MakeWhereString(ref sqlCommand, stockDayMonthReportWork, 2, "SLIPSSUB");
                sqlText += "   GROUP BY" + Environment.NewLine;
                sqlText += "     SLIPSSUB.ENTERPRISECODERF" + Environment.NewLine;
                // 修正 2009/06/10 >>>
                //// 修正 2009.04.06 >>>
                ////sqlText += "    ,SLIPSSUB.SECTIONCODERF" + Environment.NewLine;
                //sqlText += "    ,SLIPSSUB.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                //// 修正 2009.04.06 <<<
                sqlText += "    ,SLIPSSUB.STOCKSECTIONCDRF" + Environment.NewLine;
                // 修正 2009/06/10 <<<
                sqlText += "    ,SLIPSSUB.SUPPLIERCDRF" + Environment.NewLine;
                //sqlText += "    ,SLIPSSUB.SUPPLIERSNMRF" + Environment.NewLine;//DEL 2013/01/08 李亜博 for Redmine#33820
                sqlText += "  ) AS SLIPS" + Environment.NewLine;
                #endregion //[仕入データ]

                #region [仕入明細データ]

                #region [累計分抽出]
                sqlText += "  LEFT JOIN" + Environment.NewLine;
                sqlText += "  ( " + Environment.NewLine;
                sqlText += "   SELECT" + Environment.NewLine;
                sqlText += "     DTILMSUB.ENTERPRISECODERF" + Environment.NewLine;
                // 修正 2009/06/10 >>>
                //// 修正 2009.04.06 >>>
                ////sqlText += "    ,DTILMSUB.SECTIONCODERF" + Environment.NewLine;
                //sqlText += "    ,DTILMSUB.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                //// 修正 2009.04.06 <<<
                sqlText += "    ,DTILMSUB.STOCKSECTIONCDRF" + Environment.NewLine;
                // 修正 2009/06/10 <<<
                sqlText += "    ,DTILMSUB.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,DTILMSUB.STOCKORDERDIVCDRF" + Environment.NewLine;
                sqlText += "    ,DTILMSUB.STOCKSLIPCDDTLRF" + Environment.NewLine;
                // --- ADD 2009/09/08 ---------->>>>>
                // 仕入数
                sqlText += "    ,DTILMSUB.STOCKCOUNTRF" + Environment.NewLine;
                // --- ADD 2009/09/08 ----------<<<<<
                sqlText += "    ,SUM(DTILMSUB.STOCKPRICETAXEXCRF) AS MONTHSTOCKPRICETAXEXC" + Environment.NewLine;
                sqlText += "   FROM" + Environment.NewLine;
                sqlText += "   (" + Environment.NewLine;
                sqlText += "     SELECT" + Environment.NewLine;
                sqlText += "       SLIPMSUB.ENTERPRISECODERF" + Environment.NewLine;
                // 修正 2009/06/10 >>>
                //// 修正 2009.04.06 >>>
                ////sqlText += "      ,SLIPMSUB.SECTIONCODERF" + Environment.NewLine;
                //sqlText += "      ,SLIPMSUB.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                //// 修正 2009.04.06 <<<
                sqlText += "      ,SLIPMSUB.STOCKSECTIONCDRF" + Environment.NewLine;
                // 修正 2009/06/10 <<<
                sqlText += "      ,SLIPMSUB.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "      ,SLIPMSUB.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += "      ,DTILMSUB_1.STOCKORDERDIVCDRF" + Environment.NewLine;
                sqlText += "      ,DTILMSUB_1.STOCKSLIPCDDTLRF" + Environment.NewLine;
                sqlText += "      ,DTILMSUB_1.STOCKPRICETAXEXCRF" + Environment.NewLine;
                // 仕入数 // ADD 2009/09/08
                sqlText += "      ,CASE WHEN DTILMSUB_1.STOCKCOUNTRF<>0 THEN 1 ELSE 0 end STOCKCOUNTRF" + Environment.NewLine; // ADD 2009/09/08
                // sqlText += "     FROM STOCKSLIPRF AS SLIPMSUB" + Environment.NewLine; // DEL 2009/09/08
                sqlText += "     FROM STOCKSLIPHISTRF AS SLIPMSUB" + Environment.NewLine; // ADD 2009/09/08
                // sqlText += "     LEFT JOIN STOCKDETAILRF DTILMSUB_1" + Environment.NewLine; // DEL 2009/09/08
                sqlText += "     LEFT JOIN STOCKSLHISTDTLRF DTILMSUB_1" + Environment.NewLine; // ADD 2009/09/08
                sqlText += "     ON  DTILMSUB_1.ENTERPRISECODERF=SLIPMSUB.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "     AND DTILMSUB_1.SUPPLIERSLIPNORF=SLIPMSUB.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += "     AND DTILMSUB_1.SUPPLIERFORMALRF=SLIPMSUB.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += MakeWhereString(ref sqlCommand, stockDayMonthReportWork, 1, "SLIPMSUB");
                sqlText += "   ) AS DTILMSUB" + Environment.NewLine;
                sqlText += "   GROUP BY" + Environment.NewLine;
                sqlText += "     DTILMSUB.ENTERPRISECODERF" + Environment.NewLine;
                // 修正 2009/06/10 >>>
                //// 修正 2009.04.06 >>>
                ////sqlText += "    ,DTILMSUB.SECTIONCODERF" + Environment.NewLine;
                //sqlText += "    ,DTILMSUB.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                //// 修正 2009.04.06 <<<
                sqlText += "    ,DTILMSUB.STOCKSECTIONCDRF" + Environment.NewLine;
                // 修正 2009/06/10 <<<
                sqlText += "    ,DTILMSUB.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,DTILMSUB.STOCKORDERDIVCDRF" + Environment.NewLine;
                sqlText += "    ,DTILMSUB.STOCKSLIPCDDTLRF" + Environment.NewLine;
                // 仕入数  // ADD 2009/09/08
                sqlText += "    ,DTILMSUB.STOCKCOUNTRF" + Environment.NewLine;  // ADD 2009/09/08
                sqlText += "  ) AS DTILM" + Environment.NewLine;
                sqlText += "  ON  DTILM.ENTERPRISECODERF=SLIPS.ENTERPRISECODERF" + Environment.NewLine;
                // 修正 2009/06/10 >>>
                //// 修正 2009.04.06 >>>
                ////sqlText += "  AND DTILM.SECTIONCODERF = SLIPS.SECTIONCODERF" + Environment.NewLine;
                //sqlText += "  AND DTILM.STOCKADDUPSECTIONCDRF = SLIPS.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                //// 修正 2009.04.06 <<<
                sqlText += "  AND DTILM.STOCKSECTIONCDRF = SLIPS.STOCKSECTIONCDRF" + Environment.NewLine;
                // 修正 2009/06/10 <<<
                sqlText += "  AND DTILM.SUPPLIERCDRF=SLIPS.SUPPLIERCDRF" + Environment.NewLine;
                #endregion  //[累計分抽出]

                #region [日計分抽出]
                sqlText += "  LEFT JOIN" + Environment.NewLine;
                sqlText += "  ( " + Environment.NewLine;
                sqlText += "   SELECT" + Environment.NewLine;
                sqlText += "     DTILDSUB.ENTERPRISECODERF" + Environment.NewLine;
                // 修正 2009/06/10 >>>
                //// 修正 2009.04.06 >>>
                ////sqlText += "    ,DTILDSUB.SECTIONCODERF" + Environment.NewLine;
                //sqlText += "    ,DTILDSUB.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                //// 修正 2009.04.06 <<<
                sqlText += "    ,DTILDSUB.STOCKSECTIONCDRF" + Environment.NewLine;
                // 修正 2009/06/10 <<<
                sqlText += "    ,DTILDSUB.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,DTILDSUB.STOCKORDERDIVCDRF" + Environment.NewLine;
                sqlText += "    ,DTILDSUB.STOCKSLIPCDDTLRF" + Environment.NewLine;
                sqlText += "    ,SUM(DTILDSUB.STOCKPRICETAXEXCRF) AS DAYSTOCKPRICETAXEXC" + Environment.NewLine;
                sqlText += "    ,DTILDSUB.STOCKCOUNTRF" + Environment.NewLine; // ADD 2009/09/08
                sqlText += "   FROM" + Environment.NewLine;
                sqlText += "   (" + Environment.NewLine;
                sqlText += "     SELECT" + Environment.NewLine;
                sqlText += "       SLIPDSUB.ENTERPRISECODERF" + Environment.NewLine;
                // 修正 2009/06/10 >>>
                //// 修正 2009.04.06 >>>
                ////sqlText += "      ,SLIPDSUB.SECTIONCODERF" + Environment.NewLine;
                //sqlText += "      ,SLIPDSUB.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                //// 修正 2009.04.06 <<<
                sqlText += "      ,SLIPDSUB.STOCKSECTIONCDRF" + Environment.NewLine;
                // 修正 2009/06/10 <<<
                sqlText += "      ,SLIPDSUB.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "      ,SLIPDSUB.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += "      ,DTILDSUB_1.STOCKORDERDIVCDRF" + Environment.NewLine;
                sqlText += "      ,DTILDSUB_1.STOCKSLIPCDDTLRF" + Environment.NewLine;
                sqlText += "      ,DTILDSUB_1.STOCKPRICETAXEXCRF" + Environment.NewLine;
                sqlText += "      ,CASE WHEN DTILDSUB_1.STOCKCOUNTRF <>0 THEN 1 ELSE 0 end STOCKCOUNTRF" + Environment.NewLine; // ADD 2009/09/08
                // sqlText += "     FROM STOCKSLIPRF AS SLIPDSUB" + Environment.NewLine; // DEL 2009/09/08
                sqlText += "     FROM STOCKSLIPHISTRF AS SLIPDSUB" + Environment.NewLine; // ADD 2009/09/08
                // sqlText += "     LEFT JOIN STOCKDETAILRF DTILDSUB_1" + Environment.NewLine; // DEL 2009/09/08
                sqlText += "     LEFT JOIN STOCKSLHISTDTLRF DTILDSUB_1" + Environment.NewLine; // ADD 2009/09/08
                sqlText += "     ON  DTILDSUB_1.ENTERPRISECODERF=SLIPDSUB.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "     AND DTILDSUB_1.SUPPLIERSLIPNORF=SLIPDSUB.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += "     AND DTILDSUB_1.SUPPLIERFORMALRF=SLIPDSUB.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += MakeWhereString(ref sqlCommand, stockDayMonthReportWork, 0, "SLIPDSUB");
                sqlText += "   ) AS DTILDSUB" + Environment.NewLine;
                sqlText += "   GROUP BY" + Environment.NewLine;
                sqlText += "     DTILDSUB.ENTERPRISECODERF" + Environment.NewLine;
                // 修正 2009/06/10 >>>
                //// 修正 2009.04.06 >>>
                ////sqlText += "    ,DTILDSUB.SECTIONCODERF" + Environment.NewLine;
                //sqlText += "    ,DTILDSUB.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                //// 修正 2009.04.06 <<<
                sqlText += "    ,DTILDSUB.STOCKSECTIONCDRF" + Environment.NewLine;
                // 修正 2009/06/10 <<<
                sqlText += "    ,DTILDSUB.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,DTILDSUB.STOCKORDERDIVCDRF" + Environment.NewLine;
                sqlText += "    ,DTILDSUB.STOCKSLIPCDDTLRF" + Environment.NewLine;
                sqlText += "    ,DTILDSUB.STOCKCOUNTRF" + Environment.NewLine; // ADD 2009/09/08
                sqlText += "  ) AS DTILD" + Environment.NewLine;
                sqlText += "  ON  DTILD.ENTERPRISECODERF=SLIPS.ENTERPRISECODERF" + Environment.NewLine;
                // 修正 2009/06/10 >>>
                //// 修正 2009.04.06 >>>
                ////sqlText += "  AND DTILD.SECTIONCODERF = SLIPS.SECTIONCODERF" + Environment.NewLine;
                //sqlText += "  AND DTILD.STOCKADDUPSECTIONCDRF = SLIPS.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                //// 修正 2009.04.06 <<<
                sqlText += "  AND DTILD.STOCKSECTIONCDRF = SLIPS.STOCKSECTIONCDRF" + Environment.NewLine;
                // 修正 2009/06/10 <<<
                sqlText += "  AND DTILD.SUPPLIERCDRF=SLIPS.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  AND DTILD.STOCKORDERDIVCDRF=DTILM.STOCKORDERDIVCDRF" + Environment.NewLine;
                sqlText += "  AND DTILD.STOCKSLIPCDDTLRF=DTILM.STOCKSLIPCDDTLRF" + Environment.NewLine;
                sqlText += "  AND DTILD.STOCKCOUNTRF=DTILM.STOCKCOUNTRF" + Environment.NewLine; // ADD 2009/09/08
                #endregion  //[日計分抽出]

                #endregion  //[仕入明細データ]

                #endregion  //[データ抽出メインQuery]
                sqlText += ") AS DTIL" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECI" + Environment.NewLine;
                sqlText += " ON  SECI.ENTERPRISECODERF=DTIL.ENTERPRISECODERF" + Environment.NewLine;
                // 修正 2009/06/10 >>>
                //// 修正 2009.04.06 >>>
                ////sqlText += " AND SECI.SECTIONCODERF=DTIL.SECTIONCODERF" + Environment.NewLine;
                //sqlText += " AND SECI.SECTIONCODERF=DTIL.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                //// 修正 2009.04.06 <<<
                sqlText += " AND SECI.SECTIONCODERF=DTIL.STOCKSECTIONCDRF" + Environment.NewLine;
                // 修正 2009/06/10 <<<
                // --- ADD 李亜博 2013/01/08 for Redmine#33820---------->>>>>
                sqlText += " LEFT JOIN SUPPLIERRF SUPP" + Environment.NewLine;
                sqlText += " ON SUPP.ENTERPRISECODERF=DTIL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND SUPP.SUPPLIERCDRF=DTIL.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += " AND SUPP.LOGICALDELETECODERF=0" + Environment.NewLine;
                // --- ADD 李亜博 2013/01/08 for Redmine#33820----------<<<<<
                #endregion

                sqlCommand.CommandText = sqlText;

                // --- ADD 2008/07/11 ----------<<<<<

                #region [DEL 2008/07/11]
                /* --- DEL 2008/07/11 ---------->>>>>
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  SLIP.SECTIONCODERF" + Environment.NewLine;
                sqlText += " ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;

                switch (stockDayMonthReportWork.PrintType)
                {
                    case 0:  // 営業所別
                        {
                            sqlText += " ,NULL AS STOCKAGENTCODERF" + Environment.NewLine;
                            sqlText += " ,NULL AS STOCKAGENTNAMERF" + Environment.NewLine;
                            sqlText += " ,NULL AS SUPPLIERCDRF" + Environment.NewLine;
                            sqlText += " ,NULL AS SUPPLIERNM1RF" + Environment.NewLine;
                            sqlText += " ,NULL AS SUPPLIERNM2RF" + Environment.NewLine;
                            break;
                        }
                    case 1: // 営業所別・担当者別
                        {
                            sqlText += " ,SLIP.STOCKAGENTCODERF" + Environment.NewLine;
                            sqlText += " ,EMPL.NAMERF AS STOCKAGENTNAMERF" + Environment.NewLine;
                            sqlText += " ,NULL AS SUPPLIERCDRF" + Environment.NewLine;
                            sqlText += " ,NULL AS SUPPLIERNM1RF" + Environment.NewLine;
                            sqlText += " ,NULL AS SUPPLIERNM2RF" + Environment.NewLine;
                            break;
                        }
                    case 2: // 営業所別・仕入先別
                        {
                            sqlText += " ,NULL AS STOCKAGENTCODERF" + Environment.NewLine;
                            sqlText += " ,NULL AS STOCKAGENTNAMERF" + Environment.NewLine;
                            sqlText += " ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
                            sqlText += " ,CAST(DECRYPTBYKEY(SUPPL.SUPPLIERNM1RF) AS NVARCHAR(30)) AS SUPPLIERNM1RF" + Environment.NewLine;
                            sqlText += " ,CAST(DECRYPTBYKEY(SUPPL.SUPPLIERNM2RF) AS NVARCHAR(30)) AS SUPPLIERNM2RF" + Environment.NewLine;
                            break;
                        }
                    case 3: // 営業所別・担当者別・仕入先別
                        {
                            sqlText += " ,SLIP.STOCKAGENTCODERF" + Environment.NewLine;
                            sqlText += " ,EMPL.NAMERF AS STOCKAGENTNAMERF" + Environment.NewLine;
                            sqlText += " ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
                            sqlText += " ,CAST(DECRYPTBYKEY(SUPPL.SUPPLIERNM1RF) AS NVARCHAR(30)) AS SUPPLIERNM1RF" + Environment.NewLine;
                            sqlText += " ,CAST(DECRYPTBYKEY(SUPPL.SUPPLIERNM2RF) AS NVARCHAR(30)) AS SUPPLIERNM2RF" + Environment.NewLine;
                            break;
                        }
                    default:// パラメータ違反
                        {
                            base.WriteErrorLog(string.Format("StockDayMonthReportWork.PrintType に不適当な値が設定されています。({0})", stockDayMonthReportWork.PrintType));
                            stockDayMonthReportDataWorkList = al;
                            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                }

                sqlText += " ,SUM(CASE WHEN SLIP.STOCKDATERF BETWEEN @FINDDAYST AND @FINDDAYED THEN" + Environment.NewLine;
                sqlText += "        CASE SLIP.SUPPLIERSLIPCDRF WHEN 10 THEN SLIP.STOCKSUBTTLPRICERF ELSE 0 END" + Environment.NewLine;
                sqlText += "        ELSE 0 END) AS STCKPRICEDAYTOTALRF" + Environment.NewLine;
                sqlText += " ,SUM(CASE WHEN SLIP.STOCKDATERF BETWEEN @FINDDAYST AND @FINDDAYED THEN" + Environment.NewLine;
                sqlText += "        CASE SLIP.SUPPLIERSLIPCDRF WHEN 20 THEN SLIP.STOCKSUBTTLPRICERF ELSE 0 END" + Environment.NewLine;
                sqlText += "        ELSE 0 END) AS RETGDSDAYTOTALRF" + Environment.NewLine;
                sqlText += " ,SUM(CASE WHEN SLIP.STOCKDATERF BETWEEN @FINDDAYST AND @FINDDAYED THEN" + Environment.NewLine;
                sqlText += "        SLIP.STCKDISTTLTAXEXCRF ELSE 0 END) AS DISDAYTOTALRF" + Environment.NewLine;
                sqlText += " ,SUM(CASE SLIP.SUPPLIERSLIPCDRF WHEN 10 THEN" + Environment.NewLine;
                sqlText += "        SLIP.STOCKSUBTTLPRICERF ELSE 0 END) AS STCKPRICEMONTHTOTALRF" + Environment.NewLine;
                sqlText += " ,SUM(CASE SLIP.SUPPLIERSLIPCDRF WHEN 20 THEN" + Environment.NewLine;
                sqlText += "        SLIP.STOCKSUBTTLPRICERF ELSE 0 END) AS RETGDSMONTHTOTALRF" + Environment.NewLine;
                sqlText += " ,SUM(SLIP.STCKDISTTLTAXEXCRF) AS DISDAYMONTHTOTALRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKSLIPRF AS SLIP" + Environment.NewLine;
                sqlText += "    LEFT OUTER JOIN SECINFOSETRF AS SECI" + Environment.NewLine;
                sqlText += "      ON  SLIP.ENTERPRISECODERF = SECI.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "      AND SLIP.SECTIONCODERF = SECI.SECTIONCODERF" + Environment.NewLine;

                switch (stockDayMonthReportWork.PrintType)
                {
                    case 0:  // 営業所別
                        {
                            break;
                        }
                    case 1: // 営業所別・担当者別
                        {
                            sqlText += "    LEFT OUTER JOIN EMPLOYEERF AS EMPL" + Environment.NewLine;
                            sqlText += "      ON  SLIP.ENTERPRISECODERF = EMPL.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "      AND SLIP.STOCKAGENTCODERF = EMPL.EMPLOYEECODERF" + Environment.NewLine;
                            break;
                        }
                    case 2: // 営業所別・仕入先別
                        {
                            sqlText += "    LEFT OUTER JOIN SUPPLIERRF AS SUPPL" + Environment.NewLine;
                            sqlText += "      ON  SLIP.ENTERPRISECODERF = SUPPL.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "      AND SLIP.SUPPLIERCDRF = SUPPL.SUPPLIERCDRF" + Environment.NewLine;
                            break;
                        }
                    case 3: // 営業所別・担当者別・仕入先別
                        {
                            sqlText += "    LEFT OUTER JOIN EMPLOYEERF AS EMPL" + Environment.NewLine;
                            sqlText += "      ON  SLIP.ENTERPRISECODERF = EMPL.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "      AND SLIP.STOCKAGENTCODERF = EMPL.EMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    LEFT OUTER JOIN SUPPLIERRF AS SUPPL" + Environment.NewLine;
                            sqlText += "      ON  SLIP.ENTERPRISECODERF = SUPPL.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "      AND SLIP.SUPPLIERCDRF = SUPPL.SUPPLIERCDRF" + Environment.NewLine;
                            break;
                        }
                }
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "  AND SLIP.SUPPLIERFORMALRF = 0" + Environment.NewLine;
                sqlText += "  AND SLIP.SUPPLIERSLIPNORF = SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += "  AND SLIP.DEBITNOTEDIVRF = 0" + Environment.NewLine;
                sqlText += "  AND SLIP.STOCKDATERF BETWEEN @FINDMONTHST AND @FINDMONTHED" + Environment.NewLine;

                // 拠点コード
                if (stockDayMonthReportWork.SectionCode.Length > 0)
                {
                    string[] sections = stockDayMonthReportWork.SectionCode;

                    for (int i = 0; i < sections.Length; i++)
                    {
                        sections[i] = "'" + sections[i] + "'";
                    }

                    string inText = string.Join(", ", sections);

                    sqlText += "  AND SLIP.STOCKSECTIONCDRF IN (" + inText + ")" + Environment.NewLine;
                }

                // 得意先コード(開始)
                
                if (stockDayMonthReportWork.SupplierCdSt != 0)
                {
                    sqlText += "  AND SLIP.SUPPLIERCDRF >= @FINDSUPPLIERCODEST" + Environment.NewLine;
                    SqlParameter paraSupplierCodeSt = sqlCommand.Parameters.Add("@FINDSUPPLIERCODEST", SqlDbType.Int);
                    paraSupplierCodeSt.Value = SqlDataMediator.SqlSetInt32(stockDayMonthReportWork.SupplierCdSt);
                }

                // 得意先コード(終了)
                if (stockDayMonthReportWork.SupplierCdEd != 0)
                {
                    sqlText += "  AND SLIP.SUPPLIERCDRF <= @FINDSUPPLIERCODEED" + Environment.NewLine;
                    SqlParameter paraSupplierCodeEd = sqlCommand.Parameters.Add("@FINDSUPPLIERCODEED", SqlDbType.Int);
                    paraSupplierCodeEd.Value = SqlDataMediator.SqlSetInt32(stockDayMonthReportWork.SupplierCdEd);
                }

                // 仕入担当者コード(開始)
                if (!string.IsNullOrEmpty(stockDayMonthReportWork.StockAgentCodeSt) && stockDayMonthReportWork.StockAgentCodeSt == stockDayMonthReportWork.StockAgentCodeEd)
                {
                    // 開始と終了が同じ場合は後方一致の曖昧検索とする
                    sqlText += "  AND SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEST" + Environment.NewLine;
                    SqlParameter paraStockAgentCodeSt = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEST", SqlDbType.NVarChar);
                    paraStockAgentCodeSt.Value = SqlDataMediator.SqlSetString(stockDayMonthReportWork.StockAgentCodeSt + "%");
                }
                else
                {
                    // 仕入担当者コード(開始)
                    if (!string.IsNullOrEmpty(stockDayMonthReportWork.StockAgentCodeSt))
                    {
                        // 開始と終了が同じ場合は後方一致の曖昧検索とする
                        sqlText += "  AND SLIP.STOCKAGENTCODERF >= @FINDSTOCKAGENTCODEST" + Environment.NewLine;
                        SqlParameter paraStockAgentCodeSt = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEST", SqlDbType.NVarChar);
                        paraStockAgentCodeSt.Value = SqlDataMediator.SqlSetString(stockDayMonthReportWork.StockAgentCodeSt);
                    }

                    // 仕入担当者コード(終了)
                    if (stockDayMonthReportWork.StockAgentCodeEd != "")
                    {
                        if (string.IsNullOrEmpty(stockDayMonthReportWork.StockAgentCodeSt))
                        {
                            sqlText += "  AND (SLIP.STOCKAGENTCODERF <= @FINDSTOCKAGENTCODEED1 OR" + Environment.NewLine;
                            sqlText += "       SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEED2 OR" + Environment.NewLine;
                            sqlText += "       SLIP.STOCKAGENTCODERF IS NULL)" + Environment.NewLine;

                            SqlParameter paraStockAgentCodeEd1 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED1", SqlDbType.NVarChar);
                            paraStockAgentCodeEd1.Value = SqlDataMediator.SqlSetString(stockDayMonthReportWork.StockAgentCodeEd);

                            SqlParameter paraStockAgentCodeEd2 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED2", SqlDbType.NVarChar);
                            paraStockAgentCodeEd2.Value = SqlDataMediator.SqlSetString(stockDayMonthReportWork.StockAgentCodeEd + "%");
                        }
                        else
                        {
                            sqlText += "  AND (SLIP.STOCKAGENTCODERF <= @FINDSTOCKAGENTCODEED1 OR" + Environment.NewLine;
                            sqlText += "       SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEED2)" + Environment.NewLine;

                            SqlParameter paraStockAgentCodeEd1 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED1", SqlDbType.NVarChar);
                            paraStockAgentCodeEd1.Value = SqlDataMediator.SqlSetString(stockDayMonthReportWork.StockAgentCodeEd);

                            SqlParameter paraStockAgentCodeEd2 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED2", SqlDbType.NVarChar);
                            paraStockAgentCodeEd2.Value = SqlDataMediator.SqlSetString(stockDayMonthReportWork.StockAgentCodeEd + "%");
                        }
                    }
                }
                
                sqlText += "GROUP BY" + Environment.NewLine;
                sqlText += "  SLIP.SECTIONCODERF" + Environment.NewLine;
                sqlText += " ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;

                switch (stockDayMonthReportWork.PrintType)
                {
                    case 0:  // 営業所別
                        {
                            break;
                        }
                    case 1: // 営業所別・担当者別
                        {
                            sqlText += " ,SLIP.STOCKAGENTCODERF" + Environment.NewLine;
                            sqlText += " ,EMPL.NAMERF" + Environment.NewLine;
                            break;
                        }
                    case 2: // 営業所別・仕入先別
                        {
                            sqlText += " ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
                            sqlText += " ,SUPPL.SUPPLIERNM1RF" + Environment.NewLine;
                            sqlText += " ,SUPPL.SUPPLIERNM2RF" + Environment.NewLine;
                            break;
                        }
                    case 3: // 営業所別・担当者別・仕入先別
                        {
                            sqlText += " ,SLIP.STOCKAGENTCODERF" + Environment.NewLine;
                            sqlText += " ,EMPL.NAMERF" + Environment.NewLine;
                            sqlText += " ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
                            sqlText += " ,SUPPL.SUPPLIERNM1RF" + Environment.NewLine;
                            sqlText += " ,SUPPL.SUPPLIERNM2RF" + Environment.NewLine;
                            break;
                        }
                }

                sqlCommand.CommandText = sqlText;

                // 企業コード
                sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar).Value = SqlDataMediator.SqlSetString(stockDayMonthReportWork.EnterpriseCode);

                // 日計集計開始日
                sqlCommand.Parameters.Add("@FINDDAYST", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stockDayMonthReportWork.StockDateSt);

                // 日計集計終了日
                sqlCommand.Parameters.Add("@FINDDAYED", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stockDayMonthReportWork.StockDateEd);

                # region [ 月計集計開始日算出処理 ]
                int ySt = stockDayMonthReportWork.StockDateSt / 10000;          // yyyymmdd の yyyy を取得
                int mSt = (stockDayMonthReportWork.StockDateSt % 10000) / 100;  // yyyymmdd の   mm を取得
                int dSt = stockDayMonthReportWork.StockDateSt % 100;            // yyyymm   の月末日を取得

                DateTime dtSt = new DateTime(ySt, mSt, dSt);  // 年月日計算を行うため、一度 DateTime 型に変換する

                // 開始日が締め日よりも小さい場合、前月の日付を求める
                if (dtSt.Day < stockDayMonthReportWork.TotalDay)
                {
                    dtSt = dtSt.AddMonths(-1);
                }

                // 月末日と締め日を比較して小さい方をカレンダー上の締め日とする。(例：締日=31で2月の締め日は2月28日とする)
                ySt = dtSt.Year;
                mSt = dtSt.Month;
                dSt = (stockDayMonthReportWork.TotalDay < DateTime.DaysInMonth(dtSt.Year, dtSt.Month)) ? stockDayMonthReportWork.TotalDay : DateTime.DaysInMonth(dtSt.Year, dtSt.Month);

                // 締日の翌日を月計集計開始日とする (例：2月28日の翌日は3月1日)
                dtSt = new DateTime(ySt, mSt, dSt);
                dtSt = dtSt.AddDays(1);

                int ymdSt = (dtSt.Year * 10000) + (dtSt.Month * 100) + dtSt.Day;

                // 月計集計開始日
                sqlCommand.Parameters.Add("@FINDMONTHST", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(ymdSt);
                # endregion

                # region [ 月計集計終了日算出処理 ]

                // 月計集計開始日(年月まで対象とする)の一ヵ月後を算出
                DateTime dtEd = dtSt.AddMonths(1);

                // 月末日と締め日を比較して小さい方をカレンダー上の締め日とする。(例：締日=31で2月の締め日は2月28日とする)
                int yEd = dtEd.Year;
                int mEd = dtEd.Month;
                int dEd = (stockDayMonthReportWork.TotalDay < DateTime.DaysInMonth(dtEd.Year, dtEd.Month)) ? stockDayMonthReportWork.TotalDay : DateTime.DaysInMonth(dtEd.Year, dtEd.Month);

                int ymdEd = (yEd * 10000) + (mEd * 100) + dEd;

                // 月計集計終了日
                sqlCommand.Parameters.Add("@FINDMONTHED", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(ymdEd);
                # endregion
                  --- DEL 2008/07/11 ----------<<<<< */
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToStockDayMonthReportDataWorkFromReader(ref myReader));
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
                base.WriteErrorLog(ex, "StockDayMonthReportDB.SearchProc");
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }
            }

            stockDayMonthReportDataWorkList = al;

            return status;
        }
        #endregion

        #region [StockSlip用 Where句生成処理]
        /// <summary>
        /// 仕入データ用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="stockDayMonthReportWork">検索条件</param>
        /// <param name="iType">検索タイプ 0:日計 1:累計 2:日計or累計(開始日が若い方)</param>
        /// <param name="sTblNm">テーブル名略称</param>
        /// <returns>仕入データ用WHERE句</returns>
        /// <br>Note       : 仕入データ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.13</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockDayMonthReportWork stockDayMonthReportWork, int iType, string sTblNm)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " " + sTblNm + ".ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(stockDayMonthReportWork.EnterpriseCode);

            //論理削除区分 0:有効 1:論理削除 2:保留 3:完全削除
            retstring += " AND " + sTblNm + ".LOGICALDELETECODERF=0" + Environment.NewLine;

            // -- ADD 2010/05/10 ------------------------------------->>>
            //仕入形式 0:仕入 固定
            retstring += " AND " + sTblNm + ".SUPPLIERFORMALRF=0" + Environment.NewLine;
            // -- ADD 2010/05/10 -------------------------------------<<<

            //拠点コード  ※配列で複数指定される
            if (stockDayMonthReportWork.DepositStockSecCodeList != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in stockDayMonthReportWork.DepositStockSecCodeList)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    // 修正 2009/06/10 >>>
                    //// 修正 2009.04.06 >>>
                    ////retstring += " AND " + sTblNm + ".SECTIONCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                    //retstring += " AND " + sTblNm + ".STOCKADDUPSECTIONCDRF IN (" + sectionCodestr + ") " + Environment.NewLine;
                    //// 修正 2009.04.06 <<<
                    retstring += " AND " + sTblNm + ".STOCKSECTIONCDRF IN (" + sectionCodestr + ") " + Environment.NewLine;
                    // 修正 2009/06/10 <<<
                }
            }

            //仕入先コード
            if (stockDayMonthReportWork.SupplierCdSt != 0)
            {
                retstring += " AND " + sTblNm + ".SUPPLIERCDRF>=@" + sTblNm + "STSUPPLIERCDRF" + Environment.NewLine;
                SqlParameter paraStStockSupplierCode = sqlCommand.Parameters.Add("@" + sTblNm + "STSUPPLIERCDRF", SqlDbType.Int);
                paraStStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(stockDayMonthReportWork.SupplierCdSt);
            }
            if (stockDayMonthReportWork.SupplierCdEd != 999999999)
            {
                retstring += " AND " + sTblNm + ".SUPPLIERCDRF<=@" + sTblNm + "EDSUPPLIERCDRF" + Environment.NewLine;
                SqlParameter paraEdStockSupplierCode = sqlCommand.Parameters.Add("@" + sTblNm + "EDSUPPLIERCDRF", SqlDbType.Int);
                paraEdStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(stockDayMonthReportWork.SupplierCdEd);
            }

            //仕入日
            switch (iType)
            {
                case 0:
                    #region [日計]
                    // -- UPD 2010/05/10 -------------------------------------------->>>
                    ////開始対象年月日(日計)
                    //retstring += " AND " + sTblNm + ".STOCKDATERF>=@D" + sTblNm + "STOCKDATEST" + Environment.NewLine;
                    //SqlParameter paraDayStockDateSt = sqlCommand.Parameters.Add("@D" + sTblNm + "STOCKDATEST", SqlDbType.Int);
                    //paraDayStockDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockDayMonthReportWork.DayStockDateSt);
                    ////終了対象年月日(日計)
                    //retstring += " AND " + sTblNm + ".STOCKDATERF<=@D" + sTblNm + "SALESDATEED" + Environment.NewLine;
                    //SqlParameter paraDayStockDateEd = sqlCommand.Parameters.Add("@D" + sTblNm + "SALESDATEED", SqlDbType.Int);
                    //paraDayStockDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockDayMonthReportWork.DayStockDateEd);

                    //開始対象年月日(日計)
                    retstring += " AND " + sTblNm + ".STOCKDATERF>=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockDayMonthReportWork.DayStockDateSt).ToString() + Environment.NewLine;
                    //終了対象年月日(日計)
                    retstring += " AND " + sTblNm + ".STOCKDATERF<=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockDayMonthReportWork.DayStockDateEd).ToString() + Environment.NewLine;
                    // -- UPD 2010/05/10 --------------------------------------------<<<
                    #endregion
                    break;
                case 1:
                    #region [累計]
                    // -- UPD 2010/05/10 -------------------------------------------->>>
                    ////開始対象年月日(累計)
                    //retstring += " AND " + sTblNm + ".STOCKDATERF>=@M" + sTblNm + "STOCKDATEST" + Environment.NewLine;
                    //SqlParameter parMonthStockDateSt = sqlCommand.Parameters.Add("@M" + sTblNm + "STOCKDATEST", SqlDbType.Int);
                    //parMonthStockDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockDayMonthReportWork.MonthStockDateSt);
                    ////終了対象年月日(累計)
                    //retstring += " AND " + sTblNm + ".STOCKDATERF<=@M" + sTblNm + "SALESDATEED" + Environment.NewLine;
                    //SqlParameter paraMonthStockDateEd = sqlCommand.Parameters.Add("@M" + sTblNm + "SALESDATEED", SqlDbType.Int);
                    //paraMonthStockDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockDayMonthReportWork.MonthStockDateEd);

                    //開始対象年月日(累計)
                    retstring += " AND " + sTblNm + ".STOCKDATERF>=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockDayMonthReportWork.MonthStockDateSt).ToString() + Environment.NewLine;
                    //終了対象年月日(累計)
                    retstring += " AND " + sTblNm + ".STOCKDATERF<=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockDayMonthReportWork.MonthStockDateEd).ToString() + Environment.NewLine;
                    // -- UPD 2010/05/10 --------------------------------------------<<<
                    #endregion
                    break;
                case 2:
                    #region [日計or累計(日付の若い方)]
                    //日付確認
                    DateTime dStockDateSt;
                    if (stockDayMonthReportWork.DayStockDateSt >= stockDayMonthReportWork.MonthStockDateSt)
                        dStockDateSt = stockDayMonthReportWork.MonthStockDateSt;  //累計の開始日付の方が若い
                    else
                        dStockDateSt = stockDayMonthReportWork.DayStockDateSt;    //日計の開始日付の方が若い

                    // -- UPD 2010/05/10 -------------------------------------------->>>
                    ////開始対象年月日
                    //retstring += " AND " + sTblNm + ".STOCKDATERF>=@" + sTblNm + "STOCKDATEST" + Environment.NewLine;
                    //SqlParameter paraStockDateSt = sqlCommand.Parameters.Add("@" + sTblNm + "STOCKDATEST", SqlDbType.Int);
                    //paraStockDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dStockDateSt);
                    
                    ////終了対象年月日
                    //retstring += " AND " + sTblNm + ".STOCKDATERF<=@" + sTblNm + "SALESDATEED" + Environment.NewLine;
                    //SqlParameter paraStockDateEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESDATEED", SqlDbType.Int);
                    //paraStockDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockDayMonthReportWork.DayStockDateEd);

                    //開始対象年月日
                    retstring += " AND " + sTblNm + ".STOCKDATERF>=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dStockDateSt).ToString() + Environment.NewLine;
                    //終了対象年月日
                    retstring += " AND " + sTblNm + ".STOCKDATERF<=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockDayMonthReportWork.DayStockDateEd).ToString() + Environment.NewLine;
                    // -- UPD 2010/05/10 --------------------------------------------<<<
                    #endregion
                    break;
                default:
                    break;
            }
            #endregion

            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → StockConfWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockConfWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.05</br>
        /// <br>Update Note: 2008.07.11  23015  森本  大輝</br>
        /// <br>Update Note: 2009/09/08 黄偉兵 過去分表示対応</br>
        /// <br>             PM.NS対応</br>
        /// </remarks>
        private StockDayMonthReportDataWork CopyToStockDayMonthReportDataWorkFromReader(ref SqlDataReader myReader)
        {
            StockDayMonthReportDataWork retWork = new StockDayMonthReportDataWork();

            #region クラスへ格納

            #region [DEL 2008/07/11]
            /* --- DEL 2008/07/11 ---------->>>>>
            retWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            retWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            retWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            retWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            retWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            retWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            retWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            retWork.StckPriceDayTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRICEDAYTOTALRF"));
            retWork.RetGdsDayTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETGDSDAYTOTALRF"));
            retWork.DisDayTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISDAYTOTALRF"));
            retWork.NetStcPrcDayTotal = retWork.StckPriceDayTotal + retWork.RetGdsDayTotal + retWork.DisDayTotal;
            retWork.StckPriceMonthTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRICEMONTHTOTALRF"));
            retWork.RetGdsMonthTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETGDSMONTHTOTALRF"));
            retWork.DisDayMonthTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISDAYMONTHTOTALRF"));
            retWork.NetStcPrcMonthTotal = retWork.StckPriceMonthTotal + retWork.RetGdsDayTotal + retWork.DisDayTotal;
              --- DEL 2008/07/11 ----------<<<<< */
            #endregion

            #region [ADD 2008/07/11]
            // --- ADD 2008/07/11 ---------->>>>>
            // 修正 2009/06/10 >>>
            //// 修正 2009.04.06 >>>
            ////retWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            //retWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));
            //retWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));
            //// 修正 2009.04.06 <<<
            retWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
            retWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
            // 修正 2009/06/10 <<<
            retWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            retWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            retWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            retWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
            retWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
            retWork.DayStockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DAYSTOCKPRICETAXEXC"));
            retWork.MonthStockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSTOCKPRICETAXEXC"));
            retWork.StockCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKCOUNTRF")); // ADD 2009/09/08
            // --- ADD 2008/07/11 ----------<<<<<
            #endregion

            #endregion

            return retWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
                return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
