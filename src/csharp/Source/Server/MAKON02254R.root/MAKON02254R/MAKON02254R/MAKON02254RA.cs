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
using Broadleaf.Library.Diagnostics;  //ADD 2008/06/30 D.Tanaka


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入確認表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入確認表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20098　村瀬　勝也</br>
    /// <br>Date       : 2007.03.19</br>
    /// <br></br>
    /// <br>Update Note: 30290 得意先・仕入先切り分け</br>
    /// <br>Date       : 2008.04.23</br>
    /// <br></br>
    /// <br>Update Note: ＰＭ.ＮＳ用に変更</br>
    /// <br>Date       : 2008/06/30</br>
    /// <br>           : 99076 田中 大介</br>
    /// <br></br>
    /// <br>Update Note: ①伝票タイプ印刷時の重複排除処理追加</br>
    /// <br>Update Note: ②発行タイプ指定の不具合修正</br>
    /// <br>Date       : 2008.10.16</br>
    /// <br>           : 23012 畠中 啓次朗</br>
    /// <br></br>
    /// <br>Update Note: 地区コード抽出の不具合修正</br>
    /// <br>Date       : 2008.10.21</br>
    /// <br>           : 23012 畠中 啓次朗</br>
    /// <br></br>
    /// <br>Update Note: 抽出結果項目追加</br>
    /// <br>Date       : 2008.10.29 2008.11.13 </br>
    /// <br>           : 23012 畠中 啓次朗</br>
    /// <br></br>
    /// <br>Update Note: 不具合修正(テーブルの結合方法)</br>
    /// <br>Date       : 2009.01.14</br>
    /// <br>           : 23012 畠中 啓次朗</br>
    /// <br></br>
    /// <br>Update Note: 不具合修正(値引金額集計仕様の変更)</br>
    /// <br>Date       : 2009.04.21</br>
    /// <br>           : 23012 畠中 啓次朗</br>
    /// <br></br>
    /// <br>Update Note: 不具合修正(UOEアンマッチ区分参照の修正※伝票タイプ)</br>
    /// <br>Date       : 2009.04.27</br>
    /// <br>           : 23012 畠中 啓次朗</br>
    /// <br></br>
    /// <br>Update Note: 不具合修正</br>
    /// <br>Date       : 2009/05/19</br>
    /// <br>           : 23012 畠中 啓次朗</br>
    /// <br></br>
    /// <br>Update Note: MANTIS対応[11184]</br>
    /// <br>Date       : 2009/07/23</br>
    /// <br>           : 23012 畠中 啓次朗</br>
    /// <br></br>
    /// <br>Update Note: 2009/09/08 呉元嘯</br>
    /// <br>           : PM.NS-2-B・ＰＭ．ＮＳ保守依頼①</br>
    /// <br>           : 過去分表示対応</br>
    /// <br></br>
    /// <br>Update Note: 速度チューニング</br>
    /// <br>Date       : 2010/05/10</br>
    /// <br>           : 22008 長内 数馬</br>
    /// <br>Update Note: 伝票タイプにて出力した時に値引伝票が重複して出力されている障害の対応</br>
    /// <br>Date       : 2012/10/16</br>
    /// <br>           : 脇田 靖之</br>
    /// <br>Update Note: 伝票タイプにて出力した時に商品値引の金額が値引欄に表示されない障害の対応</br>
    /// <br>Date       : 2012/10/29</br>
    /// <br>           : 脇田 靖之</br>
    /// <br>Update Note: 管理番号10801804-00 2013/03/13配信分の緊急対応</br>
    /// <br>             Redmine #34611 仕入確認表UOE分データ判定不正</br>
    /// <br>Date       : 2013/02/07</br>
    /// <br>           : 孫　東響</br>
    /// <br>Update Note: デットロックのトレース解析(仕：2677/依：11100068-00)</br>
    /// <br>             Redmine #44965 仕入確認表ブロック障害の防止</br>
    /// <br>Date       : 2015/03/23</br>
    /// <br>           : 楊　揚</br>
    /// <br>Update Note: 11570208-00 軽減税率対応</br>
    /// <br>Date	   : 2020/02/27</br>
    /// <br>           : 3H 尹安</br>
    /// <br>Update Note: 11800255-00　インボイス対応（税率別合計金額不具合修正） </br>
    /// <br>Date       : 2022/09/28</br>
    /// <br>           : 陳艶丹 </br>
    /// </remarks>
    [Serializable]
    //public class StockConfDB : RemoteDB, IStockConfDB             DEL 2008/06/30
    public class StockConfDB : RemoteWithAppLockDB, IStockConfDB  //ADD 2008/06/30
    {
        /// <summary>
        /// 仕入確認表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        /// </remarks>
        public StockConfDB()
            :
            base("MAKON02256D", "Broadleaf.Application.Remoting.ParamData.StockConfWork", "STOCKCONFRF")
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
        /// 指定された条件の仕入確認表情報LISTを戻します
        /// </summary>
        /// <param name="stockConfWork">検索結果</param>
        /// <param name="parastockConfWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入確認表情報LISTを戻します</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        public int Search(out object stockConfWork, object parastockConfWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockConfWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                    return status;
                sqlConnection.Open();

                SetTransIsolationReadUncommitted(sqlConnection); // Add by 楊揚　2015/03/23 for redmine #44965 ブロック障害の防止

                return SearchStockConfProc(out stockConfWork, parastockConfWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockConfDB.Search");
                stockConfWork = new ArrayList();
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
        /// 指定された条件の仕入確認表情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objstockConfWork">検索結果</param>
        /// <param name="parastockConfWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入確認表情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        public int SearchStockConfProc(out object objstockConfWork, object parastockConfWork, ref SqlConnection sqlConnection)
        {
            StockConfShWork stockconfshWork = null;

            ArrayList stockconfshWorkList = parastockConfWork as ArrayList;
            ArrayList stockconfWorkList = new ArrayList();

            if (stockconfshWorkList == null)
            {
                stockconfshWork = parastockConfWork as StockConfShWork;
            }
            else
            {
                if (stockconfshWorkList.Count > 0)
                    stockconfshWork = stockconfshWorkList[0] as StockConfShWork;
            }

            int status = SearchStockConfProc(out stockconfWorkList, stockconfshWork, ref sqlConnection);
            objstockConfWork = stockconfWorkList;
            return status;

        }

        /// <summary>
        /// 指定された条件の仕入確認表情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockconfWorkList">検索結果</param>
        /// <param name="stockconfShWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入確認表情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        public int SearchStockConfProc(out ArrayList stockconfWorkList, StockConfShWork stockconfShWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string OrderbyStr = "";

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                sqlCommand.CommandText += MakeSelectString(ref sqlCommand, stockconfShWork)
                                       + MakeWhereString(ref sqlCommand, stockconfShWork)
                                       + OrderbyStr;

                #region [SQL DEBUG]
#if DEBUG
                Console.Clear();  //ADD 2008/06/30
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));  //ADD 2008/06/30

                #region [OLD-SQL DEBUG]
                // 2008/06/30 DEL-Start -------------------------------------------------- >>>>>
                //Console.Clear();
                //Console.WriteLine("--- 変数 ---");

                //foreach (SqlParameter param in sqlCommand.Parameters)
                //{
                //    string sqlDbType = param.SqlDbType.ToString();
                //    if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                //    {
                //        sqlDbType += string.Format("({0})", param.Value.ToString().Length);
                //    }

                //    string value = param.Value.ToString();
                //    if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                //    {
                //        value = string.Format("'{0}'", param.Value);
                //    }

                //    Console.WriteLine(string.Format("DECLARE {0} {1}", param.ParameterName, sqlDbType));
                //    Console.WriteLine(string.Format("SET {0} = {1}", param.ParameterName, value));
                //    Console.WriteLine("");
                //}

                //Console.WriteLine("--- SQL ---");
                //Console.WriteLine(sqlCommand.CommandText);
                // 2008/06/30 DEL-End ---------------------------------------------------- <<<<<
                #endregion
#endif
                #endregion

                
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToStockConfWorkFromReader(ref myReader));
                }

                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockConfDB.SearchStockConfProc");
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                    myReader.Dispose();
                }
            }

            stockconfWorkList = al;

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockConfSlipTtlWork"></param>
        /// <param name="parastockConfWork"></param>
        /// <returns></returns>
        public int SearchSlipTtl(out object stockConfSlipTtlWork, object parastockConfWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction dummyTransaction = null;
            stockConfSlipTtlWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                    return status;
                sqlConnection.Open();

                SetTransIsolationReadUncommitted(sqlConnection); // Add by 楊揚　2015/03/25 for redmine #44965 デットロックのトレース解析 

                return SearchStockConfSlipTtlProc(out stockConfSlipTtlWork, parastockConfWork, ref sqlConnection, ref dummyTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockConfDB.SearchSlipTtl");
                stockConfSlipTtlWork = new ArrayList();
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
        /// 
        /// </summary>
        /// <param name="stockConfSlipTtlWork"></param>
        /// <param name="parastockConfWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int SearchStockConfSlipTtlProc(out object stockConfSlipTtlWork, object parastockConfWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            StockConfShWork stockconfshWork = null;

            ArrayList stockconfshWorkList = parastockConfWork as ArrayList;
            ArrayList stockConfSlipTtlWorkList = new ArrayList();

            if (stockconfshWorkList == null)
            {
                stockconfshWork = parastockConfWork as StockConfShWork;
            }
            else
            {
                if (stockconfshWorkList.Count > 0)
                    stockconfshWork = stockconfshWorkList[0] as StockConfShWork;
            }

            int status = SearchStockConfSlipTtlProc(out stockConfSlipTtlWorkList, stockconfshWork, ref sqlConnection, ref sqlTransaction);
            stockConfSlipTtlWork = stockConfSlipTtlWorkList;
            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockConfSlipTtlWorkList"></param>
        /// <param name="stockconfShWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int SearchStockConfSlipTtlProc(out ArrayList stockConfSlipTtlWorkList, StockConfShWork stockconfShWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string OrderbyStr = "";

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                if (sqlTransaction != null)
                {
                    sqlCommand.Transaction = sqlTransaction;
                }

                sqlCommand.CommandText += MakeSelectStringSlipTtl(ref sqlCommand, stockconfShWork)
                                       + MakeWhereStringSlipTtl(ref sqlCommand, stockconfShWork)
                                       + OrderbyStr;

                # region [SQL DEBUG]
#if DEBUG
                Console.Clear();
                Console.WriteLine("--- 変数 ---");

                foreach (SqlParameter param in sqlCommand.Parameters)
                {
                    string sqlDbType = param.SqlDbType.ToString();
                    if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                    {
                        sqlDbType += string.Format("({0})", param.Value.ToString().Length);
                    }

                    string value = param.Value.ToString();
                    if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                    {
                        value = string.Format("'{0}'", param.Value);
                    }

                    Console.WriteLine(string.Format("DECLARE {0} {1}", param.ParameterName, sqlDbType));
                    Console.WriteLine(string.Format("SET {0} = {1}", param.ParameterName, value));
                    Console.WriteLine("");
                }

                Console.WriteLine("--- SQL ---");
                Console.WriteLine(sqlCommand.CommandText);
#endif
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToStockConfSlipTtlWorkFromReader(ref myReader));
                }

                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockConfDB.SearchStockConfProc");
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                    myReader.Dispose();
                }
            }

            stockConfSlipTtlWorkList = al;

            return status;
        }
        #endregion

        #region [SQL生成処理]
        /// <summary>
        /// SQL生成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="stockconfShWork">検索条件格納クラス</param>
        /// <returns>仕入確認表のSQL文字列</returns>
        /// <remarks>
        /// <br>Note       : 仕入確認表のSQLを作成して戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.05</br>
        /// <br>Update Note: 2009/09/08 呉元嘯 過去分表示対応</br>
        /// <br>Update Note: 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 尹安</br>
        /// <br>Date       : 2020/02/27</br>
        /// </remarks>
        private string MakeSelectString(ref SqlCommand sqlCommand, StockConfShWork stockconfShWork)
        {
            string sqlText = string.Empty;

            //--- UPD 2008/06/30 D.Tanaka --->>>
            sqlText += "SELECT" + Environment.NewLine;
            //sqlText += " SLIP.SECTIONCODERF" + Environment.NewLine;           // 拠点コード
            sqlText += " SLIP.STOCKSECTIONCDRF" + Environment.NewLine;           // 拠点コード
            sqlText += " ,SECI.SECTIONGUIDESNMRF" + Environment.NewLine;      // 拠点ガイド略称
            sqlText += " ,SLIP.STOCKSLIPUPDATECDRF" + Environment.NewLine;    // ADD 2008.10.16 ②
            sqlText += " ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERSNMRF" + Environment.NewLine;
            sqlText += " ,SLIP.INPUTDAYRF" + Environment.NewLine;
            sqlText += " ,SLIP.ARRIVALGOODSDAYRF" + Environment.NewLine;
            sqlText += " ,SLIP.STOCKDATERF" + Environment.NewLine;
            sqlText += " ,SLIP.STOCKADDUPADATERF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
            sqlText += " ,DTIL.STOCKROWNORF" + Environment.NewLine;
            sqlText += " ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine;
            sqlText += " ,SLIP.ACCPAYDIVCDRF" + Environment.NewLine;
            sqlText += " ,SLIP.UOEREMARK1RF" + Environment.NewLine;
            sqlText += " ,SLIP.UOEREMARK2RF" + Environment.NewLine;
            sqlText += " ,DTIL.ENTERPRISEGANRECODERF" + Environment.NewLine;
            sqlText += " ,DTIL.ENTERPRISEGANRENAMERF" + Environment.NewLine;
            sqlText += " ,SLIP.STOCKAGENTCODERF" + Environment.NewLine;
            sqlText += " ,SLIP.STOCKAGENTNAMERF" + Environment.NewLine;
            sqlText += " ,DTIL.GOODSNORF" + Environment.NewLine;
            sqlText += " ,DTIL.GOODSNAMERF" + Environment.NewLine;
            sqlText += " ,DTIL.GOODSMAKERCDRF" + Environment.NewLine;
            sqlText += " ,DTIL.MAKERNAMERF" + Environment.NewLine;
            sqlText += " ,DTIL.STOCKORDERDIVCDRF" + Environment.NewLine;
            sqlText += " ,DTIL.WAREHOUSECODERF" + Environment.NewLine;
            sqlText += " ,DTIL.WAREHOUSENAMERF" + Environment.NewLine;
            sqlText += " ,DTIL.WAREHOUSESHELFNORF" + Environment.NewLine;
            sqlText += " ,DTIL.BLGOODSCODERF" + Environment.NewLine;
            sqlText += " ,DTIL.BLGOODSFULLNAMERF" + Environment.NewLine;
            sqlText += " ,SLIP.DEBITNOTEDIVRF" + Environment.NewLine;
            sqlText += " ,DTIL.STOCKDTISLIPNOTE1RF" + Environment.NewLine;
            sqlText += " ,DTIL.STOCKCOUNTRF" + Environment.NewLine;
            sqlText += " ,DTIL.BFLISTPRICERF" + Environment.NewLine;
            sqlText += " ,DTIL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
            sqlText += " ,DTIL.BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
            sqlText += " ,DTIL.STOCKUNITPRICEFLRF" + Environment.NewLine;
            sqlText += " ,DTIL.STOCKUNITTAXPRICEFLRF" + Environment.NewLine;
            sqlText += " ,DTIL.STOCKPRICETAXEXCRF" + Environment.NewLine;
            sqlText += " ,DTIL.STOCKPRICETAXINCRF" + Environment.NewLine;
            //sqlText += " ,SLIP.STOCKPRICECONSTAXRF" + Environment.NewLine; // DEL 2008.11.13
            sqlText += " ,DTIL.STOCKPRICECONSTAXRF" + Environment.NewLine;   // ADD 2008.11.13
            sqlText += " ,SLIP.PAYEECODERF" + Environment.NewLine;
            sqlText += " ,SLIP.PAYEESNMRF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERSLIPNOTE2RF" + Environment.NewLine;
            sqlText += " ,SLIP.STOCKGOODSCDRF" + Environment.NewLine;
            sqlText += " ,UDTIL.SALESSLIPNUMRF" + Environment.NewLine;  // 売上明細データ．売上伝票番号
            sqlText += " ,USLIP.CUSTOMERCODERF" + Environment.NewLine;  // 売上データ．得意先コード
            // ADD 2008.10.29 >>>
            sqlText += " ,SLIP.SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPCTAXLAYCDRF" + Environment.NewLine;
            sqlText += " ,DTIL.TAXATIONCODERF" + Environment.NewLine;
            // ADD 2008.10.29 <<<
            // ADD 2009.01.06 >>>>>>>>>>
            sqlText += " ,DTIL.STOCKSLIPCDDTLRF" + Environment.NewLine;

            // ----- ADD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
            if (stockconfShWork.StockOrderDivCd != -1)
            {
                sqlText += " ,CASE WHEN  EXISTS (" + Environment.NewLine;
                sqlText += "       SELECT   " + Environment.NewLine;
                sqlText += "          1   " + Environment.NewLine;
                sqlText += "       FROM  STOCKSLHISTDTLRF AS STOCKSLDTL " + Environment.NewLine;
                sqlText += "         WHERE STOCKSLDTL.ENTERPRISECODERF=SLIP.ENTERPRISECODERF " + Environment.NewLine;
                sqlText += "         AND SLIP.SUPPLIERFORMALRF = STOCKSLDTL.SUPPLIERFORMALRF  " + Environment.NewLine;
                sqlText += "         AND SLIP.SUPPLIERSLIPNORF = STOCKSLDTL.SUPPLIERSLIPNORF  " + Environment.NewLine;
                sqlText += "         AND STOCKSLDTL.TAXATIONCODERF != 1  " + Environment.NewLine;
                sqlText += "         AND SLIP.SUPPCTAXLAYCDRF = 0 ";
                sqlText += "         AND STOCKSLDTL.STOCKORDERDIVCDRF!=@FINDSTOCKORDERDIVCD)";

                sqlText += "       AND NOT EXISTS (" + Environment.NewLine;
                sqlText += "       SELECT   " + Environment.NewLine;
                sqlText += "          1   " + Environment.NewLine;
                sqlText += "       FROM  STOCKSLHISTDTLRF AS STOCKSLDTL " + Environment.NewLine;
                sqlText += "         WHERE STOCKSLDTL.ENTERPRISECODERF=SLIP.ENTERPRISECODERF " + Environment.NewLine;
                sqlText += "         AND SLIP.SUPPLIERFORMALRF = STOCKSLDTL.SUPPLIERFORMALRF  " + Environment.NewLine;
                sqlText += "         AND SLIP.SUPPLIERSLIPNORF = STOCKSLDTL.SUPPLIERSLIPNORF  " + Environment.NewLine;
                sqlText += "         AND STOCKSLDTL.TAXATIONCODERF != 1  " + Environment.NewLine;
                sqlText += "         AND SLIP.SUPPCTAXLAYCDRF = 0 ";
                sqlText += "         AND STOCKSLDTL.STOCKORDERDIVCDRF=@FINDSTOCKORDERDIVCD)";
                sqlText += "  THEN 1 ELSE 0 END TAXRATEEXISTFLAG  " + Environment.NewLine;
            }
            else 
            {
                sqlText += " ,0 AS TAXRATEEXISTFLAG  " + Environment.NewLine;
            }
            // ----- ADD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<

            // ADD 2009.01.06 <<<<<<<<<<
            sqlText += " ,SLIP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
            sqlText += " ,SLIP.STOCKPRICECONSTAXRF AS STOCKPRICECONSTAXDENRF" + Environment.NewLine;
            sqlText += " ,SLIP.STCKDISTTLTAXEXCRF" + Environment.NewLine;
            sqlText += " ,SLIP.STOCKDISOUTTAXRF" + Environment.NewLine;
            sqlText += " ,SLIP.STCKDISTTLTAXINCLURF" + Environment.NewLine;
            // --- ADD START 3H 尹安 2020/02/27 ---------->>>>>
            sqlText += " ,SLIP.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
            // --- ADD END 3H 尹安 2020/02/27 ----------<<<<<
            sqlText += "FROM" + Environment.NewLine;
            //sqlText += "  (STOCKSLIPRF AS SLIP INNER JOIN STOCKDETAILRF AS DTIL" + Environment.NewLine;    // 仕入データ、仕入明細データ  // DEL 2009/09/08
            sqlText += "  (STOCKSLIPHISTRF AS SLIP INNER JOIN STOCKSLHISTDTLRF AS DTIL" + Environment.NewLine;    // 仕入履歴データ、仕入履歴明細データ  // ADD 2009/09/08
            sqlText += "    ON  SLIP.ENTERPRISECODERF = DTIL.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND SLIP.SUPPLIERFORMALRF = DTIL.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "    AND SLIP.SUPPLIERSLIPNORF = DTIL.SUPPLIERSLIPNORF)" + Environment.NewLine;
            // --- ADD 2009/04/15 ------ >>>
            // sqlText += "  LEFT JOIN SALESDETAILRF AS UDTIL" + Environment.NewLine; // DEL 2009/09/08
            sqlText += "  LEFT JOIN SALESHISTDTLRF AS UDTIL" + Environment.NewLine; // ADD 2009/09/08
            sqlText += "  ON  UDTIL.ENTERPRISECODERF = DTIL.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "  AND UDTIL.ACPTANODRSTATUSRF = DTIL.ACPTANODRSTATUSSYNCRF" + Environment.NewLine;
            sqlText += "  AND UDTIL.SALESSLIPDTLNUMRF = DTIL.SALESSLIPDTLNUMSYNCRF" + Environment.NewLine;
            // sqlText += "  LEFT JOIN SALESSLIPRF AS USLIP" + Environment.NewLine; // DEL 2009/09/08
            sqlText += "  LEFT JOIN SALESHISTORYRF AS USLIP" + Environment.NewLine; // ADD 2009/09/08
            sqlText += "  ON  USLIP.ENTERPRISECODERF = UDTIL.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "  AND USLIP.ACPTANODRSTATUSRF = UDTIL.ACPTANODRSTATUSRF" + Environment.NewLine;
            sqlText += "  AND USLIP.SALESSLIPNUMRF = UDTIL.SALESSLIPNUMRF" + Environment.NewLine;
            // --- ADD 2009/04/15 ------ <<<
            // --- DEL 2009/04/15 ------ >>>
            //sqlText += "  LEFT OUTER JOIN" + Environment.NewLine;
            //sqlText += "  (SALESDETAILRF AS UDTIL INNER JOIN SALESSLIPRF AS USLIP" + Environment.NewLine;  // 売上データ、売上明細データ
            //sqlText += "    ON  UDTIL.ENTERPRISECODERF = USLIP.ENTERPRISECODERF" + Environment.NewLine;
            //sqlText += "    AND UDTIL.ACPTANODRSTATUSRF = USLIP.ACPTANODRSTATUSRF" + Environment.NewLine;
            //sqlText += "    AND UDTIL.SALESSLIPNUMRF = USLIP.SALESSLIPNUMRF)" + Environment.NewLine;
            //sqlText += "  ON  DTIL.ENTERPRISECODERF = UDTIL.ENTERPRISECODERF" + Environment.NewLine;
            //// 修正 2009.01.14 >>>
            ////sqlText += "  AND DTIL.COMMONSEQNORF = UDTIL.COMMONSEQNORF" + Environment.NewLine;
            //sqlText += "  AND DTIL.STOCKSLIPDTLNUMRF = UDTIL.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;
            // 修正 2009.01.14 <<<
            // --- DEL 2009/04/15 ------ <<<
            sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI" + Environment.NewLine;                     // 拠点情報設定マスタ
            sqlText += "    ON  SLIP.ENTERPRISECODERF = SECI.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND SLIP.STOCKSECTIONCDRF = SECI.SECTIONCODERF" + Environment.NewLine;

            # region [DC.NS-SQL文]
            //sqlText += "SELECT" + Environment.NewLine;
            //sqlText += "  SLIP.SECTIONCODERF" + Environment.NewLine;           // 拠点コード
            //sqlText += " ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;        // 拠点ガイド名称
            //sqlText += " ,SLIP.SUPPLIERCDRF" + Environment.NewLine;            // 仕入先コード
            //sqlText += " ,SLIP.SUPPLIERSNMRF" + Environment.NewLine;           // 仕入先略称
            //sqlText += " ,SLIP.INPUTDAYRF" + Environment.NewLine;              // 入力日付
            //sqlText += " ,SLIP.ARRIVALGOODSDAYRF" + Environment.NewLine;       // 入荷日
            //sqlText += " ,SLIP.STOCKDATERF" + Environment.NewLine;             // 仕入日
            //sqlText += " ,SLIP.STOCKADDUPADATERF" + Environment.NewLine;       // 仕入計上日付
            //sqlText += " ,SLIP.SUPPLIERFORMALRF" + Environment.NewLine;        // 仕入形式
            //sqlText += " ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;        // 仕入伝票番号
            //sqlText += " ,DTIL.STOCKROWNORF" + Environment.NewLine;            // 仕入行番号
            //sqlText += " ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;      // 相手先伝票番号
            //sqlText += " ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine;        // 仕入伝票区分
            //sqlText += " ,SLIP.ACCPAYDIVCDRF" + Environment.NewLine;           // 買掛区分
            //sqlText += " ,DTIL.LARGEGOODSGANRECODERF" + Environment.NewLine;   // 商品区分グループコード
            //sqlText += " ,DTIL.LARGEGOODSGANRENAMERF" + Environment.NewLine;   // 商品区分グループ名称
            //sqlText += " ,DTIL.MEDIUMGOODSGANRECODERF" + Environment.NewLine;  // 商品区分コード
            //sqlText += " ,DTIL.MEDIUMGOODSGANRENAMERF" + Environment.NewLine;  // 商品区分名称
            //sqlText += " ,DTIL.DETAILGOODSGANRECODERF" + Environment.NewLine;  // 商品区分詳細コード
            //sqlText += " ,DTIL.DETAILGOODSGANRENAMERF" + Environment.NewLine;  // 商品区分詳細名称
            //sqlText += " ,DTIL.ENTERPRISEGANRECODERF" + Environment.NewLine;   // 自社分類コード
            //sqlText += " ,DTIL.ENTERPRISEGANRENAMERF" + Environment.NewLine;   // 自社分類名称
            //sqlText += " ,SLIP.STOCKAGENTCODERF" + Environment.NewLine;        // 仕入担当者コード
            //sqlText += " ,SLIP.STOCKAGENTNAMERF" + Environment.NewLine;        // 仕入担当者名称
            //sqlText += " ,DTIL.GOODSNORF" + Environment.NewLine;               // 商品番号
            //sqlText += " ,DTIL.GOODSNAMERF" + Environment.NewLine;             // 商品名称
            //sqlText += " ,DTIL.GOODSMAKERCDRF" + Environment.NewLine;          // 商品メーカーコード
            //sqlText += " ,DTIL.MAKERNAMERF" + Environment.NewLine;             // メーカー名称
            //sqlText += " ,DTIL.STOCKORDERDIVCDRF" + Environment.NewLine;       // 仕入在庫取寄せ区分
            //sqlText += " ,DTIL.WAREHOUSECODERF" + Environment.NewLine;         // 倉庫コード
            //sqlText += " ,DTIL.WAREHOUSENAMERF" + Environment.NewLine;         // 倉庫名称
            //sqlText += " ,DTIL.WAREHOUSESHELFNORF" + Environment.NewLine;      // 倉庫棚番
            //sqlText += " ,DTIL.BLGOODSCODERF" + Environment.NewLine;           // BL商品コード
            //sqlText += " ,DTIL.BLGOODSFULLNAMERF" + Environment.NewLine;       // BL商品コード名称(全角)
            //sqlText += " ,SLIP.DEBITNOTEDIVRF" + Environment.NewLine;          // 赤伝区分
            //sqlText += " ,DTIL.STOCKDTISLIPNOTE1RF" + Environment.NewLine;     // 仕入伝票明細備考１
            //sqlText += " ,DTIL.STOCKCOUNTRF" + Environment.NewLine;            // 仕入数
            //sqlText += " ,DTIL.UNITCODERF" + Environment.NewLine;              // 単位コード
            //sqlText += " ,DTIL.UNITNAMERF" + Environment.NewLine;              // 単位名称
            //sqlText += " ,DTIL.LISTPRICETAXEXCFLRF" + Environment.NewLine;     // 定価(浮動、税抜)
            //sqlText += " ,DTIL.STOCKUNITPRICEFLRF" + Environment.NewLine;      // 仕入単価(浮動、税抜)
            //sqlText += " ,DTIL.STOCKUNITTAXPRICEFLRF" + Environment.NewLine;   // 仕入単価(浮動、税込)
            //sqlText += " ,DTIL.STOCKPRICETAXEXCRF" + Environment.NewLine;      // 仕入金額(税抜)
            //sqlText += " ,DTIL.STOCKPRICETAXINCRF" + Environment.NewLine;      // 仕入金額(税込)
            //sqlText += " ,DTIL.ORDERNUMBERRF AS ORDERFORMNORF" + Environment.NewLine;           // 注文番号(発注№)
            //sqlText += " ,SLIP.STOCKPRICECONSTAXRF" + Environment.NewLine;     // 仕入金額消費税額
            //sqlText += " ,SLIP.PAYEECODERF" + Environment.NewLine;             // 支払先コード
            //sqlText += " ,SLIP.PAYEESNMRF" + Environment.NewLine;              // 支払先略称
            //sqlText += " ,SLIP.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;     // 仕入伝票備考１
            //sqlText += " ,SLIP.SUPPLIERSLIPNOTE2RF" + Environment.NewLine;     // 仕入伝票備考２
            //sqlText += " ,SLIP.STOCKGOODSCDRF" + Environment.NewLine;          // 仕入商品区分
            //sqlText += "FROM" + Environment.NewLine;
            //sqlText += "  STOCKSLIPRF AS SLIP INNER JOIN STOCKDETAILRF AS DTIL" + Environment.NewLine;
            //sqlText += "    ON  SLIP.ENTERPRISECODERF = DTIL.ENTERPRISECODERF" + Environment.NewLine;
            //sqlText += "    AND SLIP.SUPPLIERFORMALRF = DTIL.SUPPLIERFORMALRF" + Environment.NewLine;
            //sqlText += "    AND SLIP.SUPPLIERSLIPNORF = DTIL.SUPPLIERSLIPNORF" + Environment.NewLine;
            //sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI" + Environment.NewLine;
            //sqlText += "    ON  SLIP.ENTERPRISECODERF = SECI.ENTERPRISECODERF" + Environment.NewLine;
            //sqlText += "    AND SLIP.SECTIONCODERF = SECI.SECTIONCODERF" + Environment.NewLine;
            # endregion
            //--- UPD 2008/06/30 D.Tanaka ---<<<

            return sqlText;
        }

        /// <summary>
        /// SQL生成
        /// </summary>
        /// <param name="sqlCommand">sqlCommandオブジェクト</param>
        /// <param name="stockconfShWork">検索条件格納クラス</param>
        /// <returns>仕入確認表(伝票合計)のSQL文字列</returns>
        /// <remarks>
        /// <br>Note       : 仕入確認表のSQLを作成して戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.12.19</br>
        /// <br>Update Note: 2009/09/08 呉元嘯 過去分表示対応</br>
        /// <br>Update Note: 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 尹安</br>
        /// <br>           : 2020/02/27</br>
        /// </remarks>
        private string MakeSelectStringSlipTtl(ref SqlCommand sqlCommand, StockConfShWork stockconfShWork)
        {
            string sqlText = string.Empty;

            //--- UPD 2008/06/30 D.Tanaka --->>>
            sqlText += "SELECT" + Environment.NewLine;
            sqlText += " DISTINCT " + Environment.NewLine; // ADD 2008.10.16 ①　
            sqlText += " SLIP.STOCKSECTIONCDRF" + Environment.NewLine;
            sqlText += " ,SECI.SECTIONGUIDESNMRF" + Environment.NewLine;
            sqlText += " ,SLIP.STOCKSLIPUPDATECDRF" + Environment.NewLine; // ADD 2008.10.16 ②
            sqlText += " ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERSNMRF" + Environment.NewLine;
            sqlText += " ,SLIP.INPUTDAYRF" + Environment.NewLine;
            sqlText += " ,SLIP.ARRIVALGOODSDAYRF" + Environment.NewLine;
            sqlText += " ,SLIP.STOCKDATERF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
            sqlText += " ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine;           
            //sqlText += " ,SLIP.STOCKTOTALPRICERF" + Environment.NewLine;
            //sqlText += " ,SLIP.STOCKSUBTTLPRICERF" + Environment.NewLine;
            //sqlText += " ,SLIP.STOCKTTLPRICTAXINCRF" + Environment.NewLine;
            // --- DEL 2009/04/09 ------>>> 
            //sqlText += " ,SLIP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
            // --- DEL 2009/04/09 ------<<<

            // 修正 2009/07/23 >>>
            //sqlText += " ,SLIP.STOCKPRICECONSTAXRF" + Environment.NewLine;
            sqlText += " ,CASE WHEN SLIP.SUPPCTAXLAYCDRF =0 THEN SLIP.STOCKPRICECONSTAXRF ELSE DTL.STOCKPRICETAXINCRF -DTL.STOCKPRICETAXEXCRF END AS STOCKPRICECONSTAXRF" + Environment.NewLine;
            // 修正 2009/07/23 <<<

            sqlText += " ,SLIP.STOCKGOODSCDRF" + Environment.NewLine;
            sqlText += " ,SLIP.ACCPAYDIVCDRF" + Environment.NewLine;
            sqlText += " ,SLIP.UOEREMARK1RF" + Environment.NewLine;
            sqlText += " ,SLIP.UOEREMARK2RF" + Environment.NewLine;
            // ADD 2008.10.29 >>>
            sqlText += " ,SLIP.SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
            sqlText += " ,SLIP.SUPPCTAXLAYCDRF" + Environment.NewLine;
            sqlText += " ,SLIP.STCKPRCCONSTAXINCLURF" + Environment.NewLine;
            //sqlText += " ,SLIP.STCKDISTTLTAXINCLURF" + Environment.NewLine;
            // ADD 2008.10.29 <<<
            // 2009.01.09 >>>>
            //sqlText += " ,SLIP.STOCKDISOUTTAXRF" + Environment.NewLine;
            //sqlText += " ,SLIP.STCKDISTTLTAXEXCRF" + Environment.NewLine;
            // 2009.01.09 <<<<
            // --- UPD 2012/10/29 Y.Wakita ---------->>>>>
            // 修正 2009/04/21 >>>
            ////sqlText += " ,DIS.STOCKPRICECONSTAXIN AS STCKDISTTLTAXINCLURF" + Environment.NewLine;
            ////sqlText += " ,DIS.STOCKPRICECONSTAXOUT AS STOCKDISOUTTAXRF" + Environment.NewLine;
            ////sqlText += " ,DIS.STOCKPRICETAXEXC AS STCKDISTTLTAXEXCRF" + Environment.NewLine;
            //sqlText += " ,SLIP.STCKDISTTLTAXINCLURF - DIS.STOCKPRICECONSTAXIN AS STCKDISTTLTAXINCLURF" + Environment.NewLine;
            //sqlText += " ,SLIP.STOCKDISOUTTAXRF - DIS.STOCKPRICECONSTAXOUT AS STOCKDISOUTTAXRF" + Environment.NewLine;
            //sqlText += " ,SLIP.STCKDISTTLTAXEXCRF - DIS.STOCKPRICETAXEXC AS STCKDISTTLTAXEXCRF" + Environment.NewLine;
            // 修正 2009/04/21 <<<
            sqlText += " ,DIS.STOCKPRICECONSTAXIN AS STCKDISTTLTAXINCLURF" + Environment.NewLine;
            sqlText += " ,DIS.STOCKPRICECONSTAXOUT AS STOCKDISOUTTAXRF" + Environment.NewLine;
            sqlText += " ,DIS.STOCKPRICETAXEXC AS STCKDISTTLTAXEXCRF" + Environment.NewLine;
            // --- UPD 2012/10/29 Y.Wakita ----------<<<<<

            // 修正 2009/05/19 >>>
            //// --- ADD 2009/04/09 ------>>> 
            //sqlText += " ,DTL.STOCKPRICETAXEXCRF AS STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
            //sqlText += " ,DTL.STOCKPRICETAXINCRF AS STOCKTTLPRICTAXINCRF" + Environment.NewLine;
            //sqlText += " ,DTL.STOCKPRICETAXEXCRF AS STOCKSUBTTLPRICERF" + Environment.NewLine;
            //sqlText += " ,DTL.STOCKPRICETAXINCRF AS STOCKTOTALPRICERF" + Environment.NewLine;
            //// --- ADD 2009/04/09 ------<<<
            //sqlText += " ,SLIP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
            //sqlText += " ,SLIP.STOCKTTLPRICTAXINCRF" + Environment.NewLine;
            //sqlText += " ,SLIP.STOCKSUBTTLPRICERF" + Environment.NewLine;
            //sqlText += " ,SLIP.STOCKTOTALPRICERF" + Environment.NewLine;
            // 修正 2009/05/19 <<<
            // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
            sqlText += "    ,F.STOCKPRICETAXFREE AS STOCKPRICETAXFREECRF" + Environment.NewLine;
            sqlText += " ,CASE WHEN  EXISTS (" + Environment.NewLine;
            sqlText += "       SELECT   " + Environment.NewLine;
            sqlText += "          1   " + Environment.NewLine;
            sqlText += "       FROM  STOCKSLHISTDTLRF STOCKSLDTL " + Environment.NewLine;
            sqlText += "       WHERE STOCKSLDTL.ENTERPRISECODERF=SLIP.ENTERPRISECODERF " + Environment.NewLine;
            sqlText += "       AND SLIP.SUPPLIERFORMALRF = STOCKSLDTL.SUPPLIERFORMALRF  " + Environment.NewLine;
            sqlText += "       AND SLIP.SUPPLIERSLIPNORF = STOCKSLDTL.SUPPLIERSLIPNORF  " + Environment.NewLine;
            sqlText += "       AND SLIP.SUPPCTAXLAYCDRF != 9 " + Environment.NewLine;
            sqlText += "       AND STOCKSLDTL.TAXATIONCODERF != 1  " + Environment.NewLine;
            if (stockconfShWork.StockOrderDivCd != -1)
            {
                sqlText += "   AND (SLIP.SUPPCTAXLAYCDRF = 0 OR ( SLIP.SUPPCTAXLAYCDRF <> 0 AND STOCKSLDTL.STOCKORDERDIVCDRF=@FINDSTOCKORDERDIVCD))";
            }
            sqlText += "  ) THEN 1 ELSE 0 END TAXRATEEXISTFLAG  " + Environment.NewLine;
            sqlText += " ,CASE WHEN  EXISTS (" + Environment.NewLine;
            sqlText += "       SELECT   " + Environment.NewLine;
            sqlText += "          1   " + Environment.NewLine;
            sqlText += "       FROM  STOCKSLHISTDTLRF STOCKSLDTL " + Environment.NewLine;
            sqlText += "       WHERE STOCKSLDTL.ENTERPRISECODERF=SLIP.ENTERPRISECODERF " + Environment.NewLine;
            sqlText += "       AND SLIP.SUPPLIERFORMALRF = STOCKSLDTL.SUPPLIERFORMALRF  " + Environment.NewLine;
            sqlText += "       AND SLIP.SUPPLIERSLIPNORF = STOCKSLDTL.SUPPLIERSLIPNORF  " + Environment.NewLine;
            if (stockconfShWork.StockOrderDivCd != -1)
            {
                sqlText += "    AND STOCKSLDTL.STOCKORDERDIVCDRF=@FINDSTOCKORDERDIVCD ";
            }
            sqlText += "       AND (SLIP.SUPPCTAXLAYCDRF = 9 OR STOCKSLDTL.TAXATIONCODERF = 1))  " + Environment.NewLine;
            sqlText += "  THEN 1 ELSE 0 END TAXFREEEXISTFLAG  " + Environment.NewLine;
            // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
            // 合計タイプの場合
            // 　消費税は、伝票の値を出力
            // 　その他金額は、明細の値を出力←←PM7仕様
            sqlText += " ,DTL.STOCKPRICETAXEXCRF AS STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
            sqlText += " ,DTL.STOCKPRICETAXEXCRF AS STOCKSUBTTLPRICERF" + Environment.NewLine;
            // 修正2009/07/23 >>>
            //sqlText += " ,DTL.STOCKPRICETAXEXCRF + SLIP.STOCKTTLPRICTAXINCRF - SLIP.STOCKTTLPRICTAXEXCRF AS STOCKTTLPRICTAXINCRF " + Environment.NewLine;
            //sqlText += " ,DTL.STOCKPRICETAXEXCRF + SLIP.STOCKTTLPRICTAXINCRF - SLIP.STOCKTTLPRICTAXEXCRF AS STOCKTOTALPRICERF " + Environment.NewLine;
            sqlText += " ,CASE WHEN SLIP.SUPPCTAXLAYCDRF =0 THEN DTL.STOCKPRICETAXEXCRF + SLIP.STOCKTTLPRICTAXINCRF - SLIP.STOCKTTLPRICTAXEXCRF  " ;
            sqlText += "   ELSE  DTL.STOCKPRICETAXINCRF END AS STOCKTTLPRICTAXINCRF  " + Environment.NewLine;
            sqlText += " ,CASE WHEN SLIP.SUPPCTAXLAYCDRF =0 THEN DTL.STOCKPRICETAXEXCRF + SLIP.STOCKTTLPRICTAXINCRF - SLIP.STOCKTTLPRICTAXEXCRF " ;
            sqlText += "  ELSE DTL.STOCKPRICETAXINCRF END AS STOCKTOTALPRICERF " + Environment.NewLine;
            // --- ADD START 3H 尹安 2020/02/27 ---------->>>>>
            sqlText += " ,SLIP.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
            // --- ADD END 3H 尹安 2020/02/27 ----------<<<<<
            // 修正 2009/07/23 <<<

            sqlText += "FROM" + Environment.NewLine;
            //sqlText += "  STOCKSLIPRF AS SLIP LEFT OUTER JOIN STOCKDETAILRF AS DTIL" + Environment.NewLine;  // 仕入データ、仕入明細データ  // DEL 2009/09/08
            sqlText += "  STOCKSLIPHISTRF AS SLIP LEFT OUTER JOIN STOCKSLHISTDTLRF AS DTIL" + Environment.NewLine;  // 仕入履歴データ、仕入履歴明細データ  // ADD 2009/09/08
            sqlText += "    ON  SLIP.ENTERPRISECODERF = DTIL.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND SLIP.SUPPLIERFORMALRF = DTIL.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "    AND SLIP.SUPPLIERSLIPNORF = DTIL.SUPPLIERSLIPNORF" + Environment.NewLine;
            sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI" + Environment.NewLine;                       // 拠点情報設定マスタ
            sqlText += "    ON  SLIP.ENTERPRISECODERF = SECI.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND SLIP.STOCKSECTIONCDRF = SECI.SECTIONCODERF" + Environment.NewLine;
            sqlText += "  LEFT JOIN" + Environment.NewLine;
            sqlText += "  (" + Environment.NewLine;
            sqlText += "    SELECT" + Environment.NewLine;
            sqlText += "     DTIL.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "     DTIL.SUPPLIERFORMALRF," + Environment.NewLine;
            sqlText += "     DTIL.SUPPLIERSLIPNORF," + Environment.NewLine;
            //sqlText += "     DTIL.STOCKSLIPDTLNUMRF," + Environment.NewLine;  // DEL 2012/10/16 Y.Wakita
            sqlText += "     SUM(DTIL.STOCKPRICETAXEXCRF) STOCKPRICETAXEXC ," + Environment.NewLine;
            sqlText += "     SUM(CASE WHEN DTIL.TAXATIONCODERF = 0 THEN DTIL.STOCKPRICECONSTAXRF ELSE 0 END ) STOCKPRICECONSTAXOUT," + Environment.NewLine;
            sqlText += "     SUM(CASE WHEN DTIL.TAXATIONCODERF = 1 THEN DTIL.STOCKPRICECONSTAXRF ELSE 0 END ) STOCKPRICECONSTAXIN" + Environment.NewLine;
            sqlText += "    FROM" + Environment.NewLine;
            // sqlText += "     STOCKDETAILRF AS DTIL" + Environment.NewLine;  // DEL 2009/09/08
            sqlText += "     STOCKSLHISTDTLRF AS DTIL" + Environment.NewLine;  // ADD 2009/09/08
            sqlText += "    WHERE" + Environment.NewLine;
            sqlText += "     ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += "     AND SUPPLIERFORMALRF = 0  " + Environment.NewLine;
            sqlText += "     AND STOCKSLIPCDDTLRF = 2 -- 値引" + Environment.NewLine;
            sqlText += "     AND STOCKCOUNTRF != 0  -- 数量" + Environment.NewLine;
            sqlText += "    GROUP BY " + Environment.NewLine;
            sqlText += "     DTIL.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "     DTIL.SUPPLIERFORMALRF," + Environment.NewLine;
            // --- UPD 2012/10/16 Y.Wakita ---------->>>>>
            //sqlText += "     DTIL.SUPPLIERSLIPNORF," + Environment.NewLine;
            //sqlText += "     DTIL.STOCKSLIPDTLNUMRF" + Environment.NewLine;
            sqlText += "     DTIL.SUPPLIERSLIPNORF" + Environment.NewLine;
            // --- UPD 2012/10/16 Y.Wakita ----------<<<<<
            sqlText += "  ) AS DIS" + Environment.NewLine;
            sqlText += "    ON  SLIP.ENTERPRISECODERF = DIS.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND SLIP.SUPPLIERFORMALRF = DIS.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "    AND SLIP.SUPPLIERSLIPNORF = DIS.SUPPLIERSLIPNORF" + Environment.NewLine;
            // DEL 2009/05/19 >>>
            // --- ADD 2009/04/09 ------>>> 
            sqlText += "  LEFT JOIN" + Environment.NewLine;
            sqlText += "  (SELECT" + Environment.NewLine;
            sqlText += "    ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "   ,SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "   ,SUPPLIERSLIPNORF" + Environment.NewLine;
            //sqlText += "   ,STOCKSLIPDTLNUMRF" + Environment.NewLine;
            if (stockconfShWork.StockOrderDivCd != -1)
            {
                sqlText += "   ,STOCKORDERDIVCDRF" + Environment.NewLine;
            }
            sqlText += "   ,SUM(STOCKPRICETAXEXCRF) AS STOCKPRICETAXEXCRF" + Environment.NewLine;
            sqlText += "   ,SUM(STOCKPRICETAXINCRF) AS STOCKPRICETAXINCRF" + Environment.NewLine;
            // sqlText += "   FROM STOCKDETAILRF AS STDTL" + Environment.NewLine;  // DEL 2009/09/08
            sqlText += "   FROM STOCKSLHISTDTLRF AS STDTL" + Environment.NewLine;  // ADD 2009/09/08
            sqlText += "   GROUP BY " + Environment.NewLine;
            sqlText += "    ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "   ,SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "   ,SUPPLIERSLIPNORF" + Environment.NewLine;
            if (stockconfShWork.StockOrderDivCd != -1)
            {
                sqlText += "   ,STOCKORDERDIVCDRF" + Environment.NewLine;
            }
            //sqlText += "   ,STOCKSLIPDTLNUMRF" + Environment.NewLine;
            sqlText += "   ) AS DTL" + Environment.NewLine;
            sqlText += "   ON  DTL.ENTERPRISECODERF = SLIP.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "   AND DTL.SUPPLIERFORMALRF = SLIP.SUPPLIERFORMALRF" + Environment.NewLine;
            //sqlText += "   AND DTL.STOCKSLIPDTLNUMRF = DIS.STOCKSLIPDTLNUMRF" + Environment.NewLine;
            sqlText += "   AND DTL.SUPPLIERSLIPNORF = SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
            // --- ADD 2009/04/09 ------<<<
            // DEL 2009/05/19 <<<
            // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
            sqlText += " LEFT JOIN" + Environment.NewLine;
            sqlText += " (" + Environment.NewLine;
            sqlText += "   SELECT" + Environment.NewLine;
            sqlText += "    STDTL.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "    STDTL.SUPPLIERFORMALRF," + Environment.NewLine;
            sqlText += "    STDTL.SUPPLIERSLIPNORF," + Environment.NewLine;
            sqlText += "    SUM(STDTL.STOCKPRICETAXEXCRF) STOCKPRICETAXFREE" + Environment.NewLine;
            sqlText += "   FROM " + Environment.NewLine;
            sqlText += "     STOCKSLHISTDTLRF AS STDTL" + Environment.NewLine;
            sqlText += "   LEFT JOIN STOCKSLIPHISTRF AS SLIP " + Environment.NewLine;
            sqlText += "   ON " + Environment.NewLine;
            sqlText += "    (SLIP.ENTERPRISECODERF = STDTL.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "     AND SLIP.SUPPLIERFORMALRF = STDTL.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "     AND SLIP.SUPPLIERSLIPNORF = STDTL.SUPPLIERSLIPNORF) " + Environment.NewLine;
            sqlText += "   WHERE" + Environment.NewLine;
            sqlText += "        SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE  " + Environment.NewLine;
            sqlText += "    AND (STDTL.STOCKSLIPCDDTLRF != 2  OR (STDTL.STOCKSLIPCDDTLRF=2 AND STDTL.STOCKCOUNTRF=0 ))" + Environment.NewLine;
            sqlText += "    AND (SLIP.SUPPCTAXLAYCDRF = 9 OR STDTL.TAXATIONCODERF = 1)  " + Environment.NewLine;
            sqlText += "    AND (SLIP.SUPPLIERSLIPCDRF = 10 OR SLIP.SUPPLIERSLIPCDRF = 20)  " + Environment.NewLine;
            if (stockconfShWork.StockOrderDivCd != -1)
            {
                sqlText += "    AND STDTL.STOCKORDERDIVCDRF=@FINDSTOCKORDERDIVCD ";
            }
            sqlText += "   GROUP BY " + Environment.NewLine;
            sqlText += "    STDTL.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "    STDTL.SUPPLIERFORMALRF," + Environment.NewLine;
            sqlText += "    STDTL.SUPPLIERSLIPNORF " + Environment.NewLine;
            sqlText += " ) AS F ON " + Environment.NewLine;
            sqlText += " (      " + Environment.NewLine;
            sqlText += "    SLIP.ENTERPRISECODERF = F.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND SLIP.SUPPLIERFORMALRF = F.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "    AND SLIP.SUPPLIERSLIPNORF = F.SUPPLIERSLIPNORF" + Environment.NewLine;
            sqlText += "  )" + Environment.NewLine;
            // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
            //※仕入明細は在取区分、出力指定の抽出条件で必要となるため連結してます。（GDは明細なしでも伝票登録可能なので LEFT JOINとする）

            # region [DC.NS-SQL文]
            //sqlText += "SELECT" + Environment.NewLine;
            //sqlText += "  SLIP.SECTIONCODERF" + Environment.NewLine;         // 拠点コード
            //sqlText += " ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;      // 拠点ガイド名称
            //sqlText += " ,SLIP.SUPPLIERCDRF" + Environment.NewLine;          // 仕入先コード
            //sqlText += " ,SLIP.SUPPLIERSNMRF" + Environment.NewLine;         // 仕入先略称
            //sqlText += " ,SLIP.INPUTDAYRF" + Environment.NewLine;            // 入力日付
            //sqlText += " ,SLIP.ARRIVALGOODSDAYRF" + Environment.NewLine;     // 入荷日付
            //sqlText += " ,SLIP.STOCKDATERF" + Environment.NewLine;           // 仕入日付
            //sqlText += " ,SLIP.SUPPLIERFORMALRF" + Environment.NewLine;      // 仕入形式
            //sqlText += " ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;      // 伝票番号
            //sqlText += " ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;    // 相手先伝票番号
            //sqlText += " ,SLIP.STOCKGOODSCDRF" + Environment.NewLine;        // 仕入商品区分
            //sqlText += " ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine;      // 仕入伝票区分
            //sqlText += " ,SLIP.STOCKTOTALPRICERF" + Environment.NewLine;     // 仕入金額合計
            //sqlText += " ,SLIP.STOCKSUBTTLPRICERF" + Environment.NewLine;    // 仕入金額小計
            //sqlText += " ,SLIP.STOCKTTLPRICTAXINCRF" + Environment.NewLine;  // 仕入金額計（税込）
            //sqlText += " ,SLIP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;  // 仕入金額計（税抜）
            //sqlText += " ,SLIP.STOCKPRICECONSTAXRF" + Environment.NewLine;   // 仕入金額消費税額
            //sqlText += "FROM" + Environment.NewLine;
            //sqlText += "  STOCKSLIPRF AS SLIP LEFT OUTER JOIN SECINFOSETRF AS SECI" + Environment.NewLine;
            //sqlText += "    ON  SLIP.ENTERPRISECODERF = SECI.ENTERPRISECODERF" + Environment.NewLine;
            //sqlText += "    AND SLIP.SECTIONCODERF = SECI.SECTIONCODERF" + Environment.NewLine;
            # endregion
            //--- UPD 2008/06/30 D.Tanaka ---<<<
            return sqlText;
        }

        #endregion                      

        #region [WHERE句生成処理]
        /// <summary>
        /// WHERE句生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="stockconfShWork">検索条件格納クラス</param>
        /// <returns>仕入確認表のSQL文字列</returns>
        /// <remarks>
        /// <br>Note       : 仕入確認表のSQLを作成して戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.05</br>
        /// <br>Update Note: 2009/09/08 呉元嘯 過去分表示対応</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockConfShWork stockconfShWork)
        {
            // 基本WHERE句の作成
            string sqlText = "WHERE" + Environment.NewLine;

            // 企業コード
            sqlText += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockconfShWork.EnterpriseCode);

            // 論理削除区分
            //sqlText += "  AND SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine; // DEL 2008.10.16 ②

            // 仕入伝票区分(0:仕入 固定)
            sqlText += "  AND SLIP.SUPPLIERFORMALRF = 0" + Environment.NewLine;

            // 仕入拠点コード
            if (stockconfShWork.StockSectionCd.Length > 0)
            {
                string[] sections = stockconfShWork.StockSectionCd;

                for (int i = 0; i < sections.Length; i++)
                {
                    sections[i] = "'" + sections[i] + "'";
                }

                string inText = string.Join(", ", sections);

                sqlText += "  AND SLIP.STOCKSECTIONCDRF IN (" + inText + ")" + Environment.NewLine;
            }

            // 発行タイプ
            switch (stockconfShWork.PrintType)
            {
                case 0:
                    {
                        // 通常(未訂正分＋訂正分)
                        sqlText += "  AND SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                        break;
                    }
                case 1:
                    {
                        // 訂正
                        sqlText += "  AND (SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                        //sqlText += "       AND SLIP.CREATEDATETIMERF <> SLIP.UPDATEDATETIMERF)" + Environment.NewLine; // DEL 2008.10.16 ②
                        sqlText += "       AND SLIP.STOCKSLIPUPDATECDRF = 1)" + Environment.NewLine; // ADD 2008.10.16 ②
                        break;
                    }
                case 2:
                    {
                        // 削除
                        sqlText += "  AND SLIP.LOGICALDELETECODERF = 1" + Environment.NewLine;
                        break;
                    }
                case 3:
                    {
                        // 訂正＋削除
                        sqlText += "  AND (SLIP.LOGICALDELETECODERF = 1" + Environment.NewLine;
                        sqlText += "       OR (SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                        //sqlText += "           AND SLIP.CREATEDATETIMERF <> SLIP.UPDATEDATETIMERF))" + Environment.NewLine; // DEL 2008.10.16 ②
                        sqlText += "           AND SLIP.STOCKSLIPUPDATECDRF = 1))" + Environment.NewLine;   // DEL 2008.10.16 ②
                        break;
                    }
            }

            // 仕入日付(開始)
            if (stockconfShWork.StockDateSt != 0)
            {
                // -- UPD 2010/05/10 -------------------------------------------->>> 
                //sqlText += "  AND SLIP.STOCKDATERF >= @FINDSTOCKDATEST" + Environment.NewLine;
                //SqlParameter paraStockDateSt = sqlCommand.Parameters.Add("@FINDSTOCKDATEST", SqlDbType.Int);
                //paraStockDateSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.StockDateSt);

                sqlText += "  AND SLIP.STOCKDATERF >= " + SqlDataMediator.SqlSetInt32(stockconfShWork.StockDateSt).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 --------------------------------------------<<<
            }

            // 仕入日付(終了)
            if (stockconfShWork.StockDateEd != 0)
            {
                // -- UPD 2010/05/10 -------------------------------------------->>>
                //sqlText += "  AND SLIP.STOCKDATERF <= @FINDSTOCKDATEED" + Environment.NewLine;
                //SqlParameter paraStockDateEd = sqlCommand.Parameters.Add("@FINDSTOCKDATEED", SqlDbType.Int);
                //paraStockDateEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.StockDateEd);

                sqlText += "  AND SLIP.STOCKDATERF <= " + SqlDataMediator.SqlSetInt32(stockconfShWork.StockDateEd).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 --------------------------------------------<<<
            }

            // 入力日付(開始)
            if (stockconfShWork.InputDaySt != 0)
            {
                sqlText += "  AND SLIP.INPUTDAYRF >= @FINDINPUTDAYST" + Environment.NewLine;
                SqlParameter paraStockDateSt = sqlCommand.Parameters.Add("@FINDINPUTDAYST", SqlDbType.Int);
                paraStockDateSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.InputDaySt);
            }

            // 入力日付(終了)
            if (stockconfShWork.InputDayEd != 0)
            {
                sqlText += "  AND SLIP.INPUTDAYRF <= @FINDINPUTDAYED" + Environment.NewLine;
                SqlParameter paraStockDateEd = sqlCommand.Parameters.Add("@FINDINPUTDAYED", SqlDbType.Int);
                paraStockDateEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.InputDayEd);
            }

            // 入荷日付(開始)
            if (stockconfShWork.ArrivalGoodsDaySt != 0)
            {
                sqlText += "  AND SLIP.ARRIVALGOODSDAYRF >= @FINDARRIVALGOODSDAYST" + Environment.NewLine;
                SqlParameter paraArrivalGoodsDaySt = sqlCommand.Parameters.Add("@FINDARRIVALGOODSDAYST", SqlDbType.Int);
                paraArrivalGoodsDaySt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.ArrivalGoodsDaySt);
            }

            // 入荷日付(終了)
            if (stockconfShWork.ArrivalGoodsDaySt != 0)
            {
                sqlText += "  AND SLIP.ARRIVALGOODSDAYRF <= @FINDARRIVALGOODSDAYED" + Environment.NewLine;
                SqlParameter paraArrivalGoodsDayEd = sqlCommand.Parameters.Add("@FINDARRIVALGOODSDAYED", SqlDbType.Int);
                paraArrivalGoodsDayEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.ArrivalGoodsDayEd);
            }

            // 仕入先コード(開始)
            if (stockconfShWork.SupplierCdSt != 0)
            {
                sqlText += "  AND SLIP.SUPPLIERCDRF >= @FINDSUPPLIERCDST" + Environment.NewLine;
                SqlParameter paraSupplierCdSt = sqlCommand.Parameters.Add("@FINDSUPPLIERCDST", SqlDbType.Int);
                paraSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierCdSt);
            }

            // 仕入先コード(終了)
            if (stockconfShWork.SupplierCdEd != 0)
            {
                sqlText += "  AND SLIP.SUPPLIERCDRF <= @FINDSUPPLIERCDED" + Environment.NewLine;
                SqlParameter paraSupplierCdEd = sqlCommand.Parameters.Add("@FINDSUPPLIERCDED", SqlDbType.Int);
                paraSupplierCdEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierCdEd);
            }

            // 仕入伝票区分
            if ((stockconfShWork.SupplierSlipCd != 0) && (stockconfShWork.SupplierSlipCd != 30))
            {
                sqlText += "  AND SLIP.SUPPLIERSLIPCDRF = @FINDSUPPLIERSLIPCD" + Environment.NewLine;
                SqlParameter paraSupplierSlipCd = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPCD", SqlDbType.Int);
                paraSupplierSlipCd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierSlipCd);
            }
            if ((stockconfShWork.SupplierSlipCd == 30))
            {
                sqlText += "  AND( (SLIP.SUPPLIERSLIPCDRF = 20) OR (SLIP.SUPPLIERSLIPCDRF = 10 AND DTIL.STOCKSLIPCDDTLRF=2 ))" + Environment.NewLine;

            }

            // 赤伝区分
            if (stockconfShWork.DebitNoteDiv != -1)
            {
                sqlText += "  AND SLIP.DEBITNOTEDIVRF = @FINDDEBITNOTEDIV" + Environment.NewLine;
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@FINDDEBITNOTEDIV", SqlDbType.Int);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.DebitNoteDiv);
            }

            // 仕入担当者コード(開始)
            if (!string.IsNullOrEmpty(stockconfShWork.StockAgentCodeSt) && stockconfShWork.StockAgentCodeSt == stockconfShWork.StockAgentCodeEd)
            {
                // 開始と終了が同じ場合は後方一致の曖昧検索とする
                sqlText += "  AND SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEST" + Environment.NewLine;
                SqlParameter paraStockAgentCodeSt = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEST", SqlDbType.NVarChar);
                paraStockAgentCodeSt.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeSt + "%");
            }
            else
            {

                // 仕入担当者コード(開始)
                if (!string.IsNullOrEmpty(stockconfShWork.StockAgentCodeSt))
                {
                    // 開始と終了が同じ場合は後方一致の曖昧検索とする
                    sqlText += "  AND SLIP.STOCKAGENTCODERF >= @FINDSTOCKAGENTCODEST" + Environment.NewLine;
                    SqlParameter paraStockAgentCodeSt = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEST", SqlDbType.NVarChar);
                    paraStockAgentCodeSt.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeSt);
                }

                // 仕入担当者コード(終了)
                if (stockconfShWork.StockAgentCodeEd != "")
                {
                    if (string.IsNullOrEmpty(stockconfShWork.StockAgentCodeSt))
                    {
                        sqlText += "  AND (SLIP.STOCKAGENTCODERF <= @FINDSTOCKAGENTCODEED1 OR" + Environment.NewLine;
                        sqlText += "       SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEED2 OR" + Environment.NewLine;
                        sqlText += "       SLIP.STOCKAGENTCODERF IS NULL)" + Environment.NewLine;
                        
                        SqlParameter paraStockAgentCodeEd1 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED1", SqlDbType.NVarChar);
                        paraStockAgentCodeEd1.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeEd);
                        
                        SqlParameter paraStockAgentCodeEd2 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED2", SqlDbType.NVarChar);
                        paraStockAgentCodeEd2.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeEd + "%");
                    }
                    else
                    {
                        sqlText += "  AND (SLIP.STOCKAGENTCODERF <= @FINDSTOCKAGENTCODEED1 OR" + Environment.NewLine;
                        sqlText += "       SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEED2)" + Environment.NewLine;

                        SqlParameter paraStockAgentCodeEd1 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED1", SqlDbType.NVarChar);
                        paraStockAgentCodeEd1.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeEd);

                        SqlParameter paraStockAgentCodeEd2 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED2", SqlDbType.NVarChar);
                        paraStockAgentCodeEd2.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeEd + "%");
                    }
                }
            }


            // 仕入伝票番号
            // 2008/06/30 Del-Start 検索できなくなる可能性があるので削除 ------------- >>>>>
            //if (stockconfShWork.SupplierSlipNoSt == 0 && stockconfShWork.SupplierSlipNoEd == 0)
            //{
            //    sqlText += "  AND SLIP.SUPPLIERSLIPNORF = SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
            //}
            //else
            //{
            // 2008/06/30 Del-End ---------------------------------------------------- <<<<<
                // 仕入伝票番号(開始)
                if (stockconfShWork.SupplierSlipNoSt != 0)
                {
                    sqlText += "  AND SLIP.SUPPLIERSLIPNORF >= @FINDSUPPLIERSLIPNOST" + Environment.NewLine;
                    SqlParameter paraSupplierSlipNoSt = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNOST", SqlDbType.Int);
                    paraSupplierSlipNoSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierSlipNoSt);
                }

                // 仕入伝票番号(終了)
                if (stockconfShWork.SupplierSlipNoEd != 0)
                {
                    sqlText += "  AND SLIP.SUPPLIERSLIPNORF <= @FINDSUPPLIERSLIPNOED" + Environment.NewLine;
                    SqlParameter paraSupplierSlipNoEd = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNOED", SqlDbType.Int);
                    paraSupplierSlipNoEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierSlipNoEd);
                }
            //}  2008/06/30 DEL
    
            // 相手先伝番(開始)
            if (!string.IsNullOrEmpty(stockconfShWork.PartySaleSlipNumSt) &&
                stockconfShWork.PartySaleSlipNumSt == stockconfShWork.PartySaleSlipNumEd)
            {
                // 開始と終了が同じ場合は後方一致の曖昧検索とする
                sqlText += "  AND SLIP.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUMST" + Environment.NewLine;
                SqlParameter paraPartySaleSlipNumSt = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMST", SqlDbType.NVarChar);
                paraPartySaleSlipNumSt.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumSt + "%");
            }
            else
            {
                // 相手先伝番(開始)
                if (!string.IsNullOrEmpty(stockconfShWork.PartySaleSlipNumSt))
                {
                    sqlText += "  AND SLIP.PARTYSALESLIPNUMRF >= @FINDPARTYSALESLIPNUMST" + Environment.NewLine;
                    SqlParameter paraPartySaleSlipNumSt = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMST", SqlDbType.NVarChar);
                    paraPartySaleSlipNumSt.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumSt);
                }

                // 相手先伝番(終了)
                if (!string.IsNullOrEmpty(stockconfShWork.PartySaleSlipNumEd))
                {
                    if (string.IsNullOrEmpty(stockconfShWork.PartySaleSlipNumSt))
                    {
                        sqlText += "  AND (SLIP.PARTYSALESLIPNUMRF <= @FINDPARTYSALESLIPNUMED1 OR" + Environment.NewLine;
                        sqlText += "       SLIP.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUMED2 OR" + Environment.NewLine;
                        sqlText += "       SLIP.PARTYSALESLIPNUMRF IS NULL)" + Environment.NewLine;

                        SqlParameter paraPartySaleSlipNumEd1 = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMED1", SqlDbType.NVarChar);
                        paraPartySaleSlipNumEd1.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumEd);

                        SqlParameter paraPartySaleSlipNumEd2 = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMED2", SqlDbType.NVarChar);
                        paraPartySaleSlipNumEd2.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumEd);
                    }
                    else
                    {
                        sqlText += "  AND (SLIP.PARTYSALESLIPNUMRF <= @FINDPARTYSALESLIPNUMED1 OR" + Environment.NewLine;
                        sqlText += "       SLIP.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUMED2)" + Environment.NewLine;

                        SqlParameter paraPartySaleSlipNumEd1 = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMED1", SqlDbType.NVarChar);
                        paraPartySaleSlipNumEd1.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumEd);

                        SqlParameter paraPartySaleSlipNumEd2 = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMED2", SqlDbType.NVarChar);
                        paraPartySaleSlipNumEd2.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumEd);
                    }
                }
            }

            // 2008/06/30 ADD-Start -------------------------------------------------- >>>>>
            // 販売エリアコード(開始)
            if (stockconfShWork.SalesAreaCodeSt != 0)
            {
                sqlText += "  AND SLIP.SALESAREACODERF >= @FINDSALESAREACODEST" + Environment.NewLine;
                SqlParameter paraSalesAreaCodeSt = sqlCommand.Parameters.Add("@FINDSALESAREACODEST", SqlDbType.Int);
                paraSalesAreaCodeSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SalesAreaCodeSt);
            }

            // 販売エリアコード(終了)
            if (stockconfShWork.SalesAreaCodeEd != 0)
            {
                //sqlText += "  AND SLIP.SALESAREACODERF >= @FINDSALESAREACODEED" + Environment.NewLine; // DEL 2008.10.21
                sqlText += "  AND SLIP.SALESAREACODERF <= @FINDSALESAREACODEED" + Environment.NewLine;   // ADD 2008.10.21 
                SqlParameter paraSalesAreaCodeEd = sqlCommand.Parameters.Add("@FINDSALESAREACODEED", SqlDbType.Int);
                paraSalesAreaCodeEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SalesAreaCodeEd);
            }

            // 仕入在庫取寄せ区分
            if (stockconfShWork.StockOrderDivCd != -1)
            {
                sqlText += "  AND DTIL.STOCKORDERDIVCDRF = @FINDSTOCKORDERDIVCD" + Environment.NewLine;
                SqlParameter paraStockOrderDivCd = sqlCommand.Parameters.Add("@FINDSTOCKORDERDIVCD", SqlDbType.Int);
                paraStockOrderDivCd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.StockOrderDivCd);
            }

            // 出力指定
            switch (stockconfShWork.OutputDesignated)
            {
                case 1:
                    {
                        // --- UPD 2009/09/08 -------------->>>>>
                        // 仕入入力：「注文方法≠2:オンライン発注」&&「 売上明細通番（同時）=0」
                        // sqlText += "  AND (DTIL.WAYTOORDERRF <> 2" + Environment.NewLine;
                        // --- DEL 2013/02/07 BY 孫東響 For Redmine#34611 -------------------------------->>>>>
                        //sqlText += "  AND ( NOT EXISTS ( SELECT * " + Environment.NewLine;
                        //sqlText += "                   FROM UOEORDERDTLRF " + Environment.NewLine;
                        //sqlText += "                   WHERE COMMONSEQNORF = DTIL.COMMONSEQNORF " + Environment.NewLine;
                        //sqlText += "                   AND ENTERPRISECODERF = DTIL.ENTERPRISECODERF " + Environment.NewLine;
                        //sqlText += "                   AND LOGICALDELETECODERF = 0 ) " + Environment.NewLine;
                        // --- DEL 2013/02/07 BY 孫東響 For Redmine#34611 --------------------------------<<<<<
                        sqlText += "  AND ( NOT EXISTS ( " + GetOnLineOrder() + " ) " + Environment.NewLine;// ADD 2013/02/07 BY 孫東響 For Redmine#34611                        
                        sqlText += "       AND DTIL.SALESSLIPDTLNUMSYNCRF = 0)" + Environment.NewLine;
                        // --- UPD 2009/09/08 --------------<<<<<
                        break;
                    }
                case 2:
                    {
                        // --- UPD 2009/09/08 -------------->>>>>
                        // UOE分：「注文方法=2:オンライン発注」
                        // sqlText += "  AND DTIL.WAYTOORDERRF = 2" + Environment.NewLine;
                        // --- DEL 2013/02/07 BY 孫東響 For Redmine#34611 -------------------------------->>>>>
                        //sqlText += "  AND EXISTS ( SELECT * " + Environment.NewLine;
                        //sqlText += "               FROM UOEORDERDTLRF " + Environment.NewLine;
                        //sqlText += "               WHERE COMMONSEQNORF = DTIL.COMMONSEQNORF " + Environment.NewLine;
                        //sqlText += "               AND ENTERPRISECODERF = DTIL.ENTERPRISECODERF " + Environment.NewLine;
                        //sqlText += "               AND LOGICALDELETECODERF = 0 ) " + Environment.NewLine;
                        // --- DEL 2013/02/07 BY 孫東響 For Redmine#34611 --------------------------------<<<<<
                        sqlText += "  AND EXISTS ( " + GetOnLineOrder() + " ) " + Environment.NewLine;// ADD 2013/02/07 BY 孫東響 For Redmine#34611                        
                        // --- UPD 2009/09/08 --------------<<<<<
                        break;
                    }
                case 3:
                    {
                        // 同時入力分：「売上明細通番（同時）≠0」
                        sqlText += "  AND DTIL.SALESSLIPDTLNUMSYNCRF <> 0 " + Environment.NewLine;
                        break;
                    }
                case 4:
                    {
                        // --- UPD 2009/09/08 -------------->>>>>
                        // UOEアンマッチ：「注文方法=2:オンライン発注」&&「変更前仕入単価≠仕入単価」
                        // --- ADD 2008.10.08 ---------->>>>>
                        //sqlText += "  AND (DTIL.WAYTOORDERRF = 2" + Environment.NewLine;
                        //sqlText += "       AND DTIL.BFSTOCKUNITPRICEFLRF = STOCKUNITPRICEFLRF)" + Environment.NewLine;
                        // sqlText += "  AND (DTIL.WAYTOORDERRF = 2" + Environment.NewLine;

                        // --- DEL 2013/02/07 BY 孫東響 For Redmine#34611 -------------------------------->>>>>
                        //sqlText += "  AND ( EXISTS ( SELECT * " + Environment.NewLine;
                        //sqlText += "               FROM UOEORDERDTLRF " + Environment.NewLine;
                        //sqlText += "               WHERE COMMONSEQNORF = DTIL.COMMONSEQNORF " + Environment.NewLine;
                        //sqlText += "               AND ENTERPRISECODERF = DTIL.ENTERPRISECODERF " + Environment.NewLine;
                        //sqlText += "               AND LOGICALDELETECODERF = 0 ) " + Environment.NewLine;
                        // --- DEL 2013/02/07 BY 孫東響 For Redmine#34611 --------------------------------<<<<<
                        sqlText += "  AND ( EXISTS ( " + GetOnLineOrder() + " ) " + Environment.NewLine;// ADD 2013/02/07 BY 孫東響 For Redmine#34611
                        
                        sqlText += "       AND DTIL.BFSTOCKUNITPRICEFLRF <> STOCKUNITPRICEFLRF) " + Environment.NewLine;
                        // --- ADD 2008.10.08 ----------<<<<<

                        // --- UPD 2009/09/08 --------------<<<<<
                        break;
                    }
                default: // 0:全て
                    break;
            }
            // 2008/06/30 ADD-End ---------------------------------------------------- <<<<<

            return sqlText;
        }

        /// <summary>
        /// WHERE句生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="stockconfShWork">検索条件格納クラス</param>
        /// <returns>仕入確認表(伝票合計)のSQL文字列</returns>
        /// <br>Note       : 仕入確認表のSQLを作成して戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.12.19</br>
        private string MakeWhereStringSlipTtl(ref SqlCommand sqlCommand, StockConfShWork stockconfShWork)
        {
            // 基本WHERE句の作成
            string sqlText = "WHERE" + Environment.NewLine;

            // 企業コード
            sqlText += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockconfShWork.EnterpriseCode);

            // 論理削除区分
            //sqlText += "  AND SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine; // DEL 2008.10.16 ②

            // 仕入伝票区分(0:仕入 固定)
            sqlText += "  AND SLIP.SUPPLIERFORMALRF = 0" + Environment.NewLine;

            // 仕入拠点コード
            if (stockconfShWork.StockSectionCd.Length > 0)
            {
                string[] sections = stockconfShWork.StockSectionCd;

                for (int i = 0; i < sections.Length; i++)
                {
                    sections[i] = "'" + sections[i] + "'";
                }

                string inText = string.Join(", ", sections);

                sqlText += "  AND SLIP.STOCKSECTIONCDRF IN (" + inText + ")" + Environment.NewLine;
            }

            // 発行タイプ
            switch (stockconfShWork.PrintType)
            {
                case 0:
                    {
                        // 通常(未訂正分＋訂正分)
                        sqlText += "  AND SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                        break;
                    }
                case 1:
                    {
                        // 訂正
                        sqlText += "  AND (SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                        //sqlText += "       AND SLIP.CREATEDATETIMERF <> SLIP.UPDATEDATETIMERF)" + Environment.NewLine; // DEL 2008.10.16 ②
                        sqlText += "       AND SLIP.STOCKSLIPUPDATECDRF = 1)" + Environment.NewLine; // ADD 2008.10.16 ②
                        break;
                    }
                case 2:
                    {
                        // 削除
                        sqlText += "  AND SLIP.LOGICALDELETECODERF = 1" + Environment.NewLine;
                        break;
                    }
                case 3:
                    {
                        // 訂正＋削除
                        sqlText += "  AND (SLIP.LOGICALDELETECODERF = 1" + Environment.NewLine;
                        sqlText += "       OR (SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                        //sqlText += "           AND SLIP.CREATEDATETIMERF <> SLIP.UPDATEDATETIMERF))" + Environment.NewLine; // DEL 2008.10.16 ②
                        sqlText += "           AND SLIP.STOCKSLIPUPDATECDRF = 1))" + Environment.NewLine; // ADD 2008.10.16 ②
                        break;
                    }
            }

            // 仕入日付(開始)
            if (stockconfShWork.StockDateSt != 0)
            {
                // -- UPD 2010/05/10 ---------------------------------------------->>>
                //sqlText += "  AND SLIP.STOCKDATERF >= @FINDSTOCKDATEST" + Environment.NewLine;
                //SqlParameter paraStockDateSt = sqlCommand.Parameters.Add("@FINDSTOCKDATEST", SqlDbType.Int);
                //paraStockDateSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.StockDateSt);

                sqlText += "  AND SLIP.STOCKDATERF >= " + SqlDataMediator.SqlSetInt32(stockconfShWork.StockDateSt).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 ----------------------------------------------<<<
            }

            // 仕入日付(終了)
            if (stockconfShWork.StockDateEd != 0)
            {
                // -- UPD 2010/05/10 ---------------------------------------------->>>
                //sqlText += "  AND SLIP.STOCKDATERF <= @FINDSTOCKDATEED" + Environment.NewLine;
                //SqlParameter paraStockDateEd = sqlCommand.Parameters.Add("@FINDSTOCKDATEED", SqlDbType.Int);
                //paraStockDateEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.StockDateEd);

                sqlText += "  AND SLIP.STOCKDATERF <= " + SqlDataMediator.SqlSetInt32(stockconfShWork.StockDateEd).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 ----------------------------------------------<<<
            }

            // 入力日付(開始)
            if (stockconfShWork.InputDaySt != 0)
            {
                sqlText += "  AND SLIP.INPUTDAYRF >= @FINDINPUTDAYST" + Environment.NewLine;
                SqlParameter paraStockDateSt = sqlCommand.Parameters.Add("@FINDINPUTDAYST", SqlDbType.Int);
                paraStockDateSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.InputDaySt);
            }

            // 入力日付(終了)
            if (stockconfShWork.InputDayEd != 0)
            {
                sqlText += "  AND SLIP.INPUTDAYRF <= @FINDINPUTDAYED" + Environment.NewLine;
                SqlParameter paraStockDateEd = sqlCommand.Parameters.Add("@FINDINPUTDAYED", SqlDbType.Int);
                paraStockDateEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.InputDayEd);
            }

            // 入荷日付(開始)
            if (stockconfShWork.ArrivalGoodsDaySt != 0)
            {
                sqlText += "  AND SLIP.ARRIVALGOODSDAYRF >= @FINDARRIVALGOODSDAYST" + Environment.NewLine;
                SqlParameter paraArrivalGoodsDaySt = sqlCommand.Parameters.Add("@FINDARRIVALGOODSDAYST", SqlDbType.Int);
                paraArrivalGoodsDaySt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.ArrivalGoodsDaySt);
            }

            // 入荷日付(終了)
            if (stockconfShWork.ArrivalGoodsDaySt != 0)
            {
                sqlText += "  AND SLIP.ARRIVALGOODSDAYRF <= @FINDARRIVALGOODSDAYED" + Environment.NewLine;
                SqlParameter paraArrivalGoodsDayEd = sqlCommand.Parameters.Add("@FINDARRIVALGOODSDAYED", SqlDbType.Int);
                paraArrivalGoodsDayEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.ArrivalGoodsDayEd);
            }

            // 仕入先コード(開始)
            if (stockconfShWork.SupplierCdSt != 0)
            {
                sqlText += "  AND SLIP.SUPPLIERCDRF >= @FINDSUPPLIERCDST" + Environment.NewLine;
                SqlParameter paraSupplierCdSt = sqlCommand.Parameters.Add("@FINDSUPPLIERCDST", SqlDbType.Int);
                paraSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierCdSt);
            }

            // 仕入先コード(終了)
            if (stockconfShWork.SupplierCdEd != 0)
            {
                sqlText += "  AND SLIP.SUPPLIERCDRF <= @FINDSUPPLIERCDED" + Environment.NewLine;
                SqlParameter paraSupplierCdEd = sqlCommand.Parameters.Add("@FINDSUPPLIERCDED", SqlDbType.Int);
                paraSupplierCdEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierCdEd);
            }

            // 仕入伝票区分
            if ((stockconfShWork.SupplierSlipCd != 0) && stockconfShWork.SupplierSlipCd != 30)
            {
                sqlText += "  AND SLIP.SUPPLIERSLIPCDRF = @FINDSUPPLIERSLIPCD" + Environment.NewLine;
                SqlParameter paraSupplierSlipCd = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPCD", SqlDbType.Int);
                paraSupplierSlipCd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierSlipCd);
            }

            // 赤伝区分
            if (stockconfShWork.DebitNoteDiv != -1)
            {
                sqlText += "  AND SLIP.DEBITNOTEDIVRF = @FINDDEBITNOTEDIV" + Environment.NewLine;
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@FINDDEBITNOTEDIV", SqlDbType.Int);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.DebitNoteDiv);
            }

            // 仕入担当者コード(開始)
            if (!string.IsNullOrEmpty(stockconfShWork.StockAgentCodeSt) && stockconfShWork.StockAgentCodeSt == stockconfShWork.StockAgentCodeEd)
            {
                // 開始と終了が同じ場合は後方一致の曖昧検索とする
                sqlText += "  AND SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEST" + Environment.NewLine;
                SqlParameter paraStockAgentCodeSt = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEST", SqlDbType.NVarChar);
                paraStockAgentCodeSt.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeSt + "%");
            }
            else
            {
                // 仕入担当者コード(開始)
                if (!string.IsNullOrEmpty(stockconfShWork.StockAgentCodeSt))
                {
                    // 開始と終了が同じ場合は後方一致の曖昧検索とする
                    sqlText += "  AND SLIP.STOCKAGENTCODERF >= @FINDSTOCKAGENTCODEST" + Environment.NewLine;
                    SqlParameter paraStockAgentCodeSt = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEST", SqlDbType.NVarChar);
                    paraStockAgentCodeSt.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeSt);
                }

                // 仕入担当者コード(終了)
                if (stockconfShWork.StockAgentCodeEd != "")
                {
                    if (string.IsNullOrEmpty(stockconfShWork.StockAgentCodeSt))
                    {
                        sqlText += "  AND (SLIP.STOCKAGENTCODERF <= @FINDSTOCKAGENTCODEED1 OR" + Environment.NewLine;
                        sqlText += "       SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEED2 OR" + Environment.NewLine;
                        sqlText += "       SLIP.STOCKAGENTCODERF IS NULL)" + Environment.NewLine;

                        SqlParameter paraStockAgentCodeEd1 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED1", SqlDbType.NVarChar);
                        paraStockAgentCodeEd1.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeEd);

                        SqlParameter paraStockAgentCodeEd2 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED2", SqlDbType.NVarChar);
                        paraStockAgentCodeEd2.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeEd + "%");
                    }
                    else
                    {
                        sqlText += "  AND (SLIP.STOCKAGENTCODERF <= @FINDSTOCKAGENTCODEED1 OR" + Environment.NewLine;
                        sqlText += "       SLIP.STOCKAGENTCODERF LIKE @FINDSTOCKAGENTCODEED2)" + Environment.NewLine;

                        SqlParameter paraStockAgentCodeEd1 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED1", SqlDbType.NVarChar);
                        paraStockAgentCodeEd1.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeEd);

                        SqlParameter paraStockAgentCodeEd2 = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODEED2", SqlDbType.NVarChar);
                        paraStockAgentCodeEd2.Value = SqlDataMediator.SqlSetString(stockconfShWork.StockAgentCodeEd + "%");
                    }
                }
            }


            // 仕入伝票番号
            // 2008/06/30 Del-Start 検索できなくなる可能性があるので削除 ------------- >>>>>
            //if (stockconfShWork.SupplierSlipNoSt == 0 && stockconfShWork.SupplierSlipNoEd == 0)
            //{
            //    sqlText += "  AND SLIP.SUPPLIERSLIPNORF = SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
            //}
            //else
            //{
            // 2008/06/30 Del-End ---------------------------------------------------- <<<<<
                // 仕入伝票番号(開始)
                if (stockconfShWork.SupplierSlipNoSt != 0)
                {
                    sqlText += "  AND SLIP.SUPPLIERSLIPNORF >= @FINDSUPPLIERSLIPNOST" + Environment.NewLine;
                    SqlParameter paraSupplierSlipNoSt = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNOST", SqlDbType.Int);
                    paraSupplierSlipNoSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierSlipNoSt);
                }

                // 仕入伝票番号(終了)
                if (stockconfShWork.SupplierSlipNoEd != 0)
                {
                    sqlText += "  AND SLIP.SUPPLIERSLIPNORF <= @FINDSUPPLIERSLIPNOED" + Environment.NewLine;
                    SqlParameter paraSupplierSlipNoEd = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNOED", SqlDbType.Int);
                    paraSupplierSlipNoEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SupplierSlipNoEd);
                }
            //}  2008/06/30 DEL

            // 相手先伝番(開始)
            if (!string.IsNullOrEmpty(stockconfShWork.PartySaleSlipNumSt) &&
                stockconfShWork.PartySaleSlipNumSt == stockconfShWork.PartySaleSlipNumEd)
            {
                // 開始と終了が同じ場合は後方一致の曖昧検索とする
                sqlText += "  AND SLIP.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUMST" + Environment.NewLine;
                SqlParameter paraPartySaleSlipNumSt = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMST", SqlDbType.NVarChar);
                paraPartySaleSlipNumSt.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumSt + "%");
            }
            else
            {
                // 相手先伝番(開始)
                if (!string.IsNullOrEmpty(stockconfShWork.PartySaleSlipNumSt))
                {
                    sqlText += "  AND SLIP.PARTYSALESLIPNUMRF >= @FINDPARTYSALESLIPNUMST" + Environment.NewLine;
                    SqlParameter paraPartySaleSlipNumSt = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMST", SqlDbType.NVarChar);
                    paraPartySaleSlipNumSt.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumSt);
                }

                // 相手先伝番(終了)
                if (!string.IsNullOrEmpty(stockconfShWork.PartySaleSlipNumEd))
                {
                    if (string.IsNullOrEmpty(stockconfShWork.PartySaleSlipNumSt))
                    {
                        sqlText += "  AND (SLIP.PARTYSALESLIPNUMRF <= @FINDPARTYSALESLIPNUMED1 OR" + Environment.NewLine;
                        sqlText += "       SLIP.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUMED2 OR" + Environment.NewLine;
                        sqlText += "       SLIP.PARTYSALESLIPNUMRF IS NULL)" + Environment.NewLine;

                        SqlParameter paraPartySaleSlipNumEd1 = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMED1", SqlDbType.NVarChar);
                        paraPartySaleSlipNumEd1.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumEd);

                        SqlParameter paraPartySaleSlipNumEd2 = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMED2", SqlDbType.NVarChar);
                        paraPartySaleSlipNumEd2.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumEd);
                    }
                    else
                    {
                        sqlText += "  AND (SLIP.PARTYSALESLIPNUMRF <= @FINDPARTYSALESLIPNUMED1 OR" + Environment.NewLine;
                        sqlText += "       SLIP.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUMED2)" + Environment.NewLine;

                        SqlParameter paraPartySaleSlipNumEd1 = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMED1", SqlDbType.NVarChar);
                        paraPartySaleSlipNumEd1.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumEd);

                        SqlParameter paraPartySaleSlipNumEd2 = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUMED2", SqlDbType.NVarChar);
                        paraPartySaleSlipNumEd2.Value = SqlDataMediator.SqlSetString(stockconfShWork.PartySaleSlipNumEd);
                    }
                }
            }

            // 2008/06/30 ADD-Start -------------------------------------------------- >>>>>
            // 販売エリアコード(開始)
            if (stockconfShWork.SalesAreaCodeSt != 0)
            {
                sqlText += "  AND SLIP.SALESAREACODERF >= @FINDSALESAREACODEST" + Environment.NewLine;
                SqlParameter paraSalesAreaCodeSt = sqlCommand.Parameters.Add("@FINDSALESAREACODEST", SqlDbType.Int);
                paraSalesAreaCodeSt.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SalesAreaCodeSt);
            }

            // 販売エリアコード(終了)
            if (stockconfShWork.SalesAreaCodeEd != 0)
            {
                //sqlText += "  AND SLIP.SALESAREACODERF >= @FINDSALESAREACODEED" + Environment.NewLine;  // DEL 2008.10.21
                sqlText += "  AND SLIP.SALESAREACODERF <= @FINDSALESAREACODEED" + Environment.NewLine;    // ADD 2008.10.21
                SqlParameter paraSalesAreaCodeEd = sqlCommand.Parameters.Add("@FINDSALESAREACODEED", SqlDbType.Int);
                paraSalesAreaCodeEd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.SalesAreaCodeEd);
            }

            // 仕入在庫取寄せ区分
            if (stockconfShWork.StockOrderDivCd != -1)
            {
                sqlText += "  AND DTIL.STOCKORDERDIVCDRF = @FINDSTOCKORDERDIVCD" + Environment.NewLine;
                sqlText += "  AND DTL.STOCKORDERDIVCDRF = @FINDSTOCKORDERDIVCD" + Environment.NewLine;
                SqlParameter paraStockOrderDivCd = sqlCommand.Parameters.Add("@FINDSTOCKORDERDIVCD", SqlDbType.Int);
                paraStockOrderDivCd.Value = SqlDataMediator.SqlSetInt32(stockconfShWork.StockOrderDivCd);
            }

            // 出力指定
            switch (stockconfShWork.OutputDesignated)
            {
                case 1:
                    {
                        // --- UPD 2009/09/08 -------------->>>>>
                        // 仕入入力：「注文方法≠2:オンライン発注」&&「 売上明細通番（同時）=0」
                        // sqlText += "  AND (DTIL.WAYTOORDERRF <> 2" + Environment.NewLine;

                        // --- DEL 2013/02/07 BY 孫東響 For Redmine#34611 -------------------------------->>>>>
                        //sqlText += "  AND ( NOT EXISTS ( SELECT * " + Environment.NewLine;
                        //sqlText += "                   FROM UOEORDERDTLRF " + Environment.NewLine;
                        //sqlText += "                   WHERE COMMONSEQNORF = DTIL.COMMONSEQNORF " + Environment.NewLine;
                        //sqlText += "                   AND ENTERPRISECODERF = DTIL.ENTERPRISECODERF " + Environment.NewLine;
                        //sqlText += "                   AND LOGICALDELETECODERF = 0 ) " + Environment.NewLine;
                        // --- DEL 2013/02/07 BY 孫東響 For Redmine#34611 --------------------------------<<<<<
                        sqlText += "  AND ( NOT EXISTS ( " + GetOnLineOrder() + " ) " + Environment.NewLine;// ADD 2013/02/07 BY 孫東響 For Redmine#34611
                        
                        sqlText += "  AND DTIL.SALESSLIPDTLNUMSYNCRF = 0)" + Environment.NewLine;
                        // --- UPD 2009/09/08 --------------<<<<<
                        break;
                    }
                case 2:
                    {
                        // --- UPD 2009/09/08 -------------->>>>>
                        // UOE分：「注文方法=2:オンライン発注」
                        // sqlText += "  AND DTIL.WAYTOORDERRF = 2" + Environment.NewLine;

                        // --- DEL 2013/02/07 BY 孫東響 For Redmine#34611 -------------------------------->>>>>
                        //sqlText += "  AND EXISTS ( SELECT * " + Environment.NewLine;
                        //sqlText += "               FROM UOEORDERDTLRF " + Environment.NewLine;
                        //sqlText += "               WHERE COMMONSEQNORF = DTIL.COMMONSEQNORF " + Environment.NewLine;
                        //sqlText += "               AND ENTERPRISECODERF = DTIL.ENTERPRISECODERF " + Environment.NewLine;
                        //sqlText += "               AND LOGICALDELETECODERF = 0 ) " + Environment.NewLine;
                        // --- DEL 2013/02/07 BY 孫東響 For Redmine#34611 --------------------------------<<<<<
                        sqlText += "  AND EXISTS ( " + GetOnLineOrder() + " ) " + Environment.NewLine;// ADD 2013/02/07 BY 孫東響 For Redmine#34611
                        // --- UPD 2009/09/08 -------------->>>>>
                        break;
                    }
                case 3:
                    {
                        // 同時入力分：「売上明細通番（同時）≠0」
                        sqlText += "  AND DTIL.SALESSLIPDTLNUMSYNCRF <> 0" + Environment.NewLine;
                        break;
                    }
                case 4:
                    {
                        // --- UPD 2009/09/08 -------------->>>>>
                        // UOEアンマッチ：「注文方法=2:オンライン発注」&&「変更前仕入単価≠仕入単価」
                        // sqlText += "  AND (DTIL.WAYTOORDERRF = 2" + Environment.NewLine;

                        // --- DEL 2013/02/07 BY 孫東響 For Redmine#34611 -------------------------------->>>>>
                        //sqlText += "  AND ( EXISTS ( SELECT * " + Environment.NewLine;
                        //sqlText += "               FROM UOEORDERDTLRF " + Environment.NewLine;
                        //sqlText += "               WHERE COMMONSEQNORF = DTIL.COMMONSEQNORF " + Environment.NewLine;
                        //sqlText += "               AND ENTERPRISECODERF = DTIL.ENTERPRISECODERF " + Environment.NewLine;
                        //sqlText += "               AND LOGICALDELETECODERF = 0 ) " + Environment.NewLine;
                        // --- DEL 2013/02/07 BY 孫東響 For Redmine#34611 --------------------------------<<<<<
                        sqlText += "  AND ( EXISTS ( " + GetOnLineOrder() + " ) " + Environment.NewLine;// ADD 2013/02/07 BY 孫東響 For Redmine#34611
                        
                        // 修正 2009/04/27 >>>
                        //sqlText += "       AND DTIL.BFSTOCKUNITPRICEFLRF = STOCKUNITPRICEFLRF)" + Environment.NewLine;
                        sqlText += "       AND DTIL.BFSTOCKUNITPRICEFLRF <> STOCKUNITPRICEFLRF)" + Environment.NewLine;
                        // 修正 2009/04/27 <<<
                        // --- UPD 2009/09/08 -------------->>>>>
                        break;
                    }
                default: // 0:全て
                    break;
            }
            // 2008/06/30 ADD-End ---------------------------------------------------- <<<<<

            return sqlText;
        }

        // --- ADD 2013/02/07 BY 孫東響 For Redmine#34611 -------------------------------->>>>>
        /// <summary>
        /// オンライン発注検索クエリの取得
        /// </summary>
        ///<returns>オンライン発注の検索クエリ</returns>
        private string GetOnLineOrder()
        {
            // UOEデータの検索
            // 検索条件は以下です。
            // 仕入履歴明細データ．企業コード=仕入明細データ．企業コード 
            // 仕入履歴明細データ．仕入形式（元）=仕入明細データ．仕入形式
            // 仕入履歴明細データ．仕入明細通番（元）=仕入明細データ．仕入明細通番 
            // 仕入明細データ.注文方法 = 2
            // 仕入明細データ.論理削除区分 = 0

            StringBuilder sqlStringBulid = new StringBuilder();
            sqlStringBulid.Append(" SELECT * ").Append(Environment.NewLine);
            sqlStringBulid.Append(" FROM STOCKDETAILRF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            sqlStringBulid.Append(" WHERE ENTERPRISECODERF = DTIL.ENTERPRISECODERF ").Append(Environment.NewLine);
            sqlStringBulid.Append(" AND STOCKSLIPDTLNUMRF = DTIL.STOCKSLIPDTLNUMSRCRF ").Append(Environment.NewLine);
            sqlStringBulid.Append(" AND SUPPLIERFORMALRF = DTIL.SUPPLIERFORMALSRCRF ").Append(Environment.NewLine);
            sqlStringBulid.Append(" AND WAYTOORDERRF = 2 ").Append(Environment.NewLine);
            sqlStringBulid.Append(" AND LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);

            return sqlStringBulid.ToString();
        }
        // --- ADD 2013/02/07 BY 孫東響 For Redmine#34611 --------------------------------<<<<<
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
        /// <br>Update Note: 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 尹安</br>
        /// <br>Date       : 2020/02/27</br>
        /// </remarks>
        private StockConfWork CopyToStockConfWorkFromReader(ref SqlDataReader myReader)
        {
            StockConfWork wkStockConfWork = new StockConfWork();

            // 2008/06/30 UPD-Start -------------------------------------------------- >>>>>
            #region クラスへ格納
            wkStockConfWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
            wkStockConfWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            wkStockConfWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkStockConfWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkStockConfWork.InputDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            wkStockConfWork.ArrivalGoodsDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            wkStockConfWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            wkStockConfWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            wkStockConfWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            wkStockConfWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            wkStockConfWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
            wkStockConfWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            wkStockConfWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            wkStockConfWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
            wkStockConfWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            wkStockConfWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            wkStockConfWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            wkStockConfWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
            wkStockConfWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            wkStockConfWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            wkStockConfWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkStockConfWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkStockConfWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkStockConfWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkStockConfWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
            wkStockConfWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkStockConfWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            wkStockConfWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkStockConfWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkStockConfWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkStockConfWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            wkStockConfWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));
            wkStockConfWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            wkStockConfWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
            wkStockConfWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
            wkStockConfWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
            wkStockConfWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStockConfWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
            wkStockConfWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
            wkStockConfWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
            wkStockConfWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            wkStockConfWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkStockConfWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            wkStockConfWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            wkStockConfWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
            wkStockConfWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            wkStockConfWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            wkStockConfWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            // ADD 2008.10.29 >>>
            wkStockConfWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
            wkStockConfWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            wkStockConfWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
            // ADD 2008.10.29 <<<
            // ADD 2009.01.06 >>>>>>>>>>
            wkStockConfWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
            // ADD 2009.01.06 <<<<<<<<<<
            wkStockConfWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
            wkStockConfWork.StockPriceConsTaxDen = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXDENRF"));
            wkStockConfWork.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXEXCRF"));
            wkStockConfWork.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKDISOUTTAXRF"));
            wkStockConfWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));
            // --- ADD START 3H 尹安 2020/02/27 ---------->>>>>
            // 仕入先消費税税率
            wkStockConfWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));
            // --- ADD END 3H 尹安 2020/02/27 ----------<<<<<
            wkStockConfWork.TaxRateExistFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXRATEEXISTFLAG")) > 0;// ADD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            #endregion

            #region OLD-DC.NSクラスへ格納
            //wkStockConfWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            //wkStockConfWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            //wkStockConfWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            //wkStockConfWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            //wkStockConfWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            //wkStockConfWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            //wkStockConfWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            //wkStockConfWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            //wkStockConfWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            //wkStockConfWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            //wkStockConfWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
            //wkStockConfWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            //wkStockConfWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            //wkStockConfWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
            //wkStockConfWork.LargeGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRECODERF"));
            //wkStockConfWork.LargeGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRENAMERF"));
            //wkStockConfWork.MediumGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRECODERF"));
            //wkStockConfWork.MediumGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRENAMERF"));
            //wkStockConfWork.DetailGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRECODERF"));
            //wkStockConfWork.DetailGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRENAMERF"));
            //wkStockConfWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            //wkStockConfWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
            //wkStockConfWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            //wkStockConfWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            //wkStockConfWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            //wkStockConfWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            //wkStockConfWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            //wkStockConfWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            //wkStockConfWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
            //wkStockConfWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            //wkStockConfWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            //wkStockConfWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            //wkStockConfWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            //wkStockConfWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            //wkStockConfWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            //wkStockConfWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));
            //wkStockConfWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            //wkStockConfWork.UnitCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNITCODERF"));
            //wkStockConfWork.UnitName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITNAMERF"));
            //wkStockConfWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
            //wkStockConfWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            //wkStockConfWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
            //wkStockConfWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
            //wkStockConfWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
            //wkStockConfWork.OrderFormNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERFORMNORF"));
            //wkStockConfWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            //wkStockConfWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            //wkStockConfWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            //wkStockConfWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            //wkStockConfWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
            //wkStockConfWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            #endregion
            // 2008/06/30 UPD-End --------------------------------------------------- <<<<<

            return wkStockConfWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myReader"></param>        
        /// <returns></returns>
        /// <br>Update Note: 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 尹安</br>
        /// <br>Date       : 2020/02/27</br>
        private StockConfSlipTtlWork CopyToStockConfSlipTtlWorkFromReader(ref SqlDataReader myReader)
        {
            StockConfSlipTtlWork wkStockConfSlipTtlWork = new StockConfSlipTtlWork();

            // 2008/06/30 UPD-Start -------------------------------------------------- >>>>>
            #region クラスへ格納
            wkStockConfSlipTtlWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
            wkStockConfSlipTtlWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            wkStockConfSlipTtlWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkStockConfSlipTtlWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkStockConfSlipTtlWork.InputDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            wkStockConfSlipTtlWork.ArrivalGoodsDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            wkStockConfSlipTtlWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            wkStockConfSlipTtlWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            wkStockConfSlipTtlWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            wkStockConfSlipTtlWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            wkStockConfSlipTtlWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            wkStockConfSlipTtlWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            wkStockConfSlipTtlWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            wkStockConfSlipTtlWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
            wkStockConfSlipTtlWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
            wkStockConfSlipTtlWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            wkStockConfSlipTtlWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            wkStockConfSlipTtlWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
            wkStockConfSlipTtlWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            wkStockConfSlipTtlWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            // ADD 2008.10.29 >>>
            wkStockConfSlipTtlWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
            wkStockConfSlipTtlWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            wkStockConfSlipTtlWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));
            wkStockConfSlipTtlWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));
            // ADD 2008.10.29 <<<
            //2009.01.09 >>>>
            wkStockConfSlipTtlWork.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKDISOUTTAXRF"));
            wkStockConfSlipTtlWork.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXEXCRF"));
            // --- ADD START 3H 尹安 2020/02/27 ---------->>>>>
            // 仕入先消費税税率
            wkStockConfSlipTtlWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));
            // --- ADD END 3H 尹安 2020/02/27 ----------<<<<<
            //2009.01.09 <<<<

            // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
            // 仕入明細非課税存在フラグ
            wkStockConfSlipTtlWork.TaxFreeExistFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXFREEEXISTFLAG")) > 0;
            // 仕入明細課税存在フラグ
            wkStockConfSlipTtlWork.TaxRateExistFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXRATEEXISTFLAG")) > 0;
            // 仕入金額非課税
            wkStockConfSlipTtlWork.StockPriceTaxFreeCrf = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXFREECRF"));
            // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<

            #endregion

            #region OLD-DC.NSクラスへ格納
            //wkStockConfSlipTtlWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            //wkStockConfSlipTtlWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            //wkStockConfSlipTtlWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            //wkStockConfSlipTtlWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            //wkStockConfSlipTtlWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            //wkStockConfSlipTtlWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            //wkStockConfSlipTtlWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            //wkStockConfSlipTtlWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            //wkStockConfSlipTtlWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            //wkStockConfSlipTtlWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            //wkStockConfSlipTtlWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            //wkStockConfSlipTtlWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            //wkStockConfSlipTtlWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            //wkStockConfSlipTtlWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
            //wkStockConfSlipTtlWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
            //wkStockConfSlipTtlWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            //wkStockConfSlipTtlWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            #endregion
            // 2008/06/30 UPD-End --------------------------------------------------- <<<<<

            return wkStockConfSlipTtlWork;
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
