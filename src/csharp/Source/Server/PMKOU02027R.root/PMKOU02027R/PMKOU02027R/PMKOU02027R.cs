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
    /// 仕入分析表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入分析表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.11.13</br>
    /// <br></br>
    /// <br>Update Note: 集計元テーブルの変更</br>
    /// <br>Update Note: 売上仕入月次集計データ⇒仕入月次集計データ</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2009.01.08</br>
    /// <br></br>
    /// <br>Update Note: イスコ対応・READUNCOMMITTED対応</br>
    /// <br>Programmer : 30517 夏野 駿希</br>
    /// <br>Date       : 2011/08/01</br>
    /// </remarks>
    [Serializable]
    public class SlipHistAnalyzeResultWorkDB : RemoteDB, ISlipHistAnalyzeResultWorkDB
    {
        /// <summary>
        /// 仕入分析表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.13</br>
        /// </remarks>
        public SlipHistAnalyzeResultWorkDB()
            :
        base("PMKOU02029D", "Broadleaf.Application.Remoting.ParamData.SlipHistAnalyzeResultWork", "MTTLSALESSTOCKSLIPRF") //基底クラスのコンストラクタ
        {
        }

        #region 仕入分析表
        /// <summary>
        /// 指定された企業コードの仕入分析表LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="customInqResultWork">検索結果</param>
        /// <param name="customInqOrderParamWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入分析表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.13</br>
        public int Search(out object slipHistAnalyzeResultList, object slipHistAnalyzeParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            slipHistAnalyzeResultList = null;

            SlipHistAnalyzeParamWork _slipHistAnalyzeParamWork = slipHistAnalyzeParamWork as SlipHistAnalyzeParamWork;

            try
            {
                status = SearchProc(out slipHistAnalyzeResultList, _slipHistAnalyzeParamWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SlipHistAnalyzeResultWorkDB.Search Exception=" + ex.Message);
                slipHistAnalyzeResultList = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの仕入分析表LISTを全て戻します
        /// </summary>
        /// <param name="slipHistAnalyzeResultList">検索結果</param>
        /// <param name="_slipHistAnalyzeParamWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入分析表LISTを全て戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.13</br>
        private int SearchProc(out object slipHistAnalyzeResultList, SlipHistAnalyzeParamWork _slipHistAnalyzeParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            slipHistAnalyzeResultList = null;

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


                status = SearchOrderProc(ref al, ref sqlConnection, _slipHistAnalyzeParamWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SlipHistAnalyzeResultWorkDB.SearchProc Exception=" + ex.Message);
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

            slipHistAnalyzeResultList = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_slipHistAnalyzeParamWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, SlipHistAnalyzeParamWork _slipHistAnalyzeParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt="";

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                selectTxt = "";

                sqlCommand.Parameters.Clear();
                //SELECT文作成
                selectTxt += MakeSelectString(ref sqlCommand, _slipHistAnalyzeParamWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    SlipHistAnalyzeResultWork ResultWork = new SlipHistAnalyzeResultWork();
                    //格納項目

                    // 修正 2009.01.08 >>>
                    //ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                    // 修正 2009.01.08 <<<

                    ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    ResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    ResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    ResultWork.TotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALPRICE"));
                    ResultWork.RetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETGOODSPRICE"));
                    ResultWork.TotalDiscount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALDISCOUNT"));
                    ResultWork.TotalPriceStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALPRICESTOCK"));
                    ResultWork.TotalPriceTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALPRICETOTAL"));
                    ResultWork.AnnualTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALTOTALPRICE"));
                    ResultWork.AnnualRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALRETGOODSPRICE"));
                    ResultWork.AnnualTotalDiscount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALTOTALDISCOUNT"));
                    ResultWork.AnnualTotalPriceStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALTOTALPRICESTOCK"));
                    ResultWork.AnnualTotalPriceTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALTOTALPRICETOTAL"));
                    #endregion

                    al.Add(ResultWork);

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

        #region SELECT文生成
        /// <summary>
        /// 発行タイプ別にSELECT分を作成
        /// </summary>
        /// <param name="printDiv">発行タイプ</param>
        /// <returns>SELECT文</returns>
        private string MakeSelectString(ref SqlCommand sqlCommand, SlipHistAnalyzeParamWork _slipHistAnalyzeParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retString = string.Empty;
            if (retString == "")
            {
                // 修正 2009.01.08 >>>
                #region DEL 2009.01.08
                /*
                retString += "SELECT" + Environment.NewLine;
                retString += " YEARSLIP.ADDUPSECCODERF" + Environment.NewLine;
                retString += ",SECINF.SECTIONGUIDESNMRF" + Environment.NewLine;
                retString += ",YEARSLIP.SUPPLIERCDRF" + Environment.NewLine;
                retString += ",SUPPLIER.SUPPLIERSNMRF" + Environment.NewLine;
                retString += ",MONTHSLIP.TOTALPRICE" + Environment.NewLine;
                retString += ",MONTHSLIP.RETGOODSPRICE" + Environment.NewLine;
                retString += ",MONTHSLIP.TOTALDISCOUNT" + Environment.NewLine;
                retString += ",MONTHSLIP.TOTALPRICESTOCK" + Environment.NewLine;
                retString += ",MONTHSLIP.TOTALPRICETOTAL" + Environment.NewLine;
                retString += ",YEARSLIP.ANNUALTOTALPRICE" + Environment.NewLine;
                retString += ",YEARSLIP.ANNUALRETGOODSPRICE" + Environment.NewLine;
                retString += ",YEARSLIP.ANNUALTOTALDISCOUNT" + Environment.NewLine;
                retString += ",YEARSLIP.ANNUALTOTALPRICESTOCK" + Environment.NewLine;
                retString += ",YEARSLIP.ANNUALTOTALPRICETOTAL" + Environment.NewLine;

                #region 当期データ集計
                retString += "FROM" + Environment.NewLine;
                retString += "(" + Environment.NewLine;
                retString += "SELECT" + Environment.NewLine;
                retString += "  ENTERPRISECODERF" + Environment.NewLine;
                retString += " ,ADDUPSECCODERF" + Environment.NewLine;
                retString += " ,SUPPLIERCDRF" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALPRICERF - STOCKTOTALDISCOUNTRF ELSE 0 END) AS ANNUALTOTALPRICE" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKRETGOODSPRICERF ELSE 0 END) AS ANNUALRETGOODSPRICE" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALDISCOUNTRF ELSE 0 END) AS ANNUALTOTALDISCOUNT" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALPRICERF + STOCKRETGOODSPRICERF ELSE 0 END) AS ANNUALTOTALPRICESTOCK" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=1 THEN STOCKTOTALPRICERF + STOCKRETGOODSPRICERF ELSE 0 END) AS ANNUALTOTALPRICETOTAL" + Environment.NewLine;
                retString += "FROM MTTLSALESSTOCKSLIPRF" + Environment.NewLine;
                retString += MakeWhereString(ref sqlCommand, _slipHistAnalyzeParamWork, logicalMode, 1);
                retString += "GROUP BY" + Environment.NewLine;
                retString += "  ENTERPRISECODERF" + Environment.NewLine;
                retString += " ,ADDUPSECCODERF" + Environment.NewLine;
                retString += " ,SUPPLIERCDRF" + Environment.NewLine;
                retString += ") AS YEARSLIP" + Environment.NewLine;
                #endregion

                #region 当月データ集計
                retString += "LEFT JOIN" + Environment.NewLine;
                retString += "(" + Environment.NewLine;
                retString += "SELECT" + Environment.NewLine;
                retString += "  ENTERPRISECODERF" + Environment.NewLine;
                retString += " ,ADDUPSECCODERF" + Environment.NewLine;
                retString += " ,SUPPLIERCDRF" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALPRICERF - STOCKTOTALDISCOUNTRF ELSE 0 END) AS TOTALPRICE" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKRETGOODSPRICERF ELSE 0 END) AS RETGOODSPRICE" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALDISCOUNTRF ELSE 0 END) AS TOTALDISCOUNT" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALPRICERF + STOCKRETGOODSPRICERF ELSE 0 END) AS TOTALPRICESTOCK" + Environment.NewLine;
                retString += " ,SUM(CASE WHEN RSLTTTLDIVCDRF=1 THEN STOCKTOTALPRICERF + STOCKRETGOODSPRICERF ELSE 0 END) AS TOTALPRICETOTAL" + Environment.NewLine;
                retString += "FROM MTTLSALESSTOCKSLIPRF" + Environment.NewLine;
                retString += MakeWhereString(ref sqlCommand, _slipHistAnalyzeParamWork, logicalMode, 0);
                retString += "GROUP BY" + Environment.NewLine;
                retString += "  ENTERPRISECODERF" + Environment.NewLine;
                retString += " ,ADDUPSECCODERF" + Environment.NewLine;
                retString += " ,SUPPLIERCDRF" + Environment.NewLine;
                retString += ") AS MONTHSLIP" + Environment.NewLine;
                retString += "ON " + Environment.NewLine;
                retString += "MONTHSLIP.ADDUPSECCODERF = YEARSLIP.ADDUPSECCODERF" + Environment.NewLine;
                retString += "AND MONTHSLIP.SUPPLIERCDRF = YEARSLIP.SUPPLIERCDRF" + Environment.NewLine;
                #endregion

                #region JOIN
                retString += "LEFT JOIN " + Environment.NewLine;
                retString += "SUPPLIERRF AS SUPPLIER" + Environment.NewLine;
                retString += "ON SUPPLIER.ENTERPRISECODERF = YEARSLIP.ENTERPRISECODERF" + Environment.NewLine;
                retString += "AND SUPPLIER.SUPPLIERCDRF = YEARSLIP.SUPPLIERCDRF" + Environment.NewLine;
                retString += "LEFT JOIN" + Environment.NewLine;
                retString += "SECINFOSETRF AS SECINF" + Environment.NewLine;
                retString += "ON SECINF.ENTERPRISECODERF = YEARSLIP.ENTERPRISECODERF" + Environment.NewLine;
                retString += "AND SECINF.SECTIONCODERF = YEARSLIP.ADDUPSECCODERF" + Environment.NewLine;
                #endregion
                */
                #endregion 

                #region SELECT文作成
                retString += "SELECT" + Environment.NewLine;
                retString += " YEARSLIP.STOCKSECTIONCDRF" + Environment.NewLine;
                retString += " ,SECINF.SECTIONGUIDESNMRF" + Environment.NewLine;
                retString += " ,YEARSLIP.SUPPLIERCDRF" + Environment.NewLine;
                retString += " ,SUPPLIER.SUPPLIERSNMRF" + Environment.NewLine;
                retString += " ,MONTHSLIP.TOTALPRICE" + Environment.NewLine;
                retString += " ,MONTHSLIP.RETGOODSPRICE" + Environment.NewLine;
                retString += " ,MONTHSLIP.TOTALDISCOUNT" + Environment.NewLine;
                retString += " ,MONTHSLIP.TOTALPRICESTOCK" + Environment.NewLine;
                retString += " ,MONTHSLIP.TOTALPRICETOTAL" + Environment.NewLine;
                retString += " ,YEARSLIP.ANNUALTOTALPRICE" + Environment.NewLine;
                retString += " ,YEARSLIP.ANNUALRETGOODSPRICE" + Environment.NewLine;
                retString += " ,YEARSLIP.ANNUALTOTALDISCOUNT" + Environment.NewLine;
                retString += " ,YEARSLIP.ANNUALTOTALPRICESTOCK" + Environment.NewLine;
                retString += " ,YEARSLIP.ANNUALTOTALPRICETOTAL" + Environment.NewLine;
                retString += "FROM" + Environment.NewLine;
                retString += "(" + Environment.NewLine;

                #region 当期データ集計
                retString += "  SELECT" + Environment.NewLine;
                retString += "  ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,STOCKSECTIONCDRF" + Environment.NewLine;
                retString += "  ,SUPPLIERCDRF" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALPRICERF ELSE 0 END) AS ANNUALTOTALPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKRETGOODSPRICERF ELSE 0 END) AS ANNUALRETGOODSPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALDISCOUNTRF ELSE 0 END) AS ANNUALTOTALDISCOUNT" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=1 THEN (STOCKTOTALPRICERF + STOCKRETGOODSPRICERF + STOCKTOTALDISCOUNTRF) ELSE 0 END) AS ANNUALTOTALPRICESTOCK" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN (STOCKTOTALPRICERF + STOCKRETGOODSPRICERF + STOCKTOTALDISCOUNTRF) ELSE 0 END) AS ANNUALTOTALPRICETOTAL  " + Environment.NewLine;
                retString += "  FROM" + Environment.NewLine;
                // 2011/08/01 >>>
                //retString += "   MTTLSTOCKSLIPRF" + Environment.NewLine;
                retString += "   MTTLSTOCKSLIPRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                retString += MakeWhereString(ref sqlCommand, _slipHistAnalyzeParamWork, logicalMode, 1);
                retString += "  GROUP BY" + Environment.NewLine;
                retString += "   ENTERPRISECODERF" + Environment.NewLine;
                retString += "   ,STOCKSECTIONCDRF" + Environment.NewLine;
                retString += "   ,SUPPLIERCDRF" + Environment.NewLine;
                retString += ") AS YEARSLIP" + Environment.NewLine;
                #endregion

                #region 当月データ集計
                retString += "LEFT JOIN" + Environment.NewLine;
                retString += "( " + Environment.NewLine;
                retString += " SELECT" + Environment.NewLine;
                retString += "  ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,STOCKSECTIONCDRF" + Environment.NewLine;
                retString += "  ,SUPPLIERCDRF" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALPRICERF ELSE 0 END) AS TOTALPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKRETGOODSPRICERF ELSE 0 END) AS RETGOODSPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALDISCOUNTRF ELSE 0 END) AS TOTALDISCOUNT" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=1 THEN (STOCKTOTALPRICERF + STOCKRETGOODSPRICERF + STOCKTOTALDISCOUNTRF) ELSE 0 END) AS TOTALPRICESTOCK" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN (STOCKTOTALPRICERF + STOCKRETGOODSPRICERF + STOCKTOTALDISCOUNTRF) ELSE 0 END) AS TOTALPRICETOTAL  " + Environment.NewLine;
                retString += "  FROM" + Environment.NewLine;
                // 2011/08/01 >>>
                //retString += "   MTTLSTOCKSLIPRF" + Environment.NewLine;
                retString += "   MTTLSTOCKSLIPRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                retString += MakeWhereString(ref sqlCommand, _slipHistAnalyzeParamWork, logicalMode, 0);
                retString += "  GROUP BY" + Environment.NewLine;
                retString += "   ENTERPRISECODERF" + Environment.NewLine;
                retString += "   ,STOCKSECTIONCDRF" + Environment.NewLine;
                retString += "   ,SUPPLIERCDRF" + Environment.NewLine;
                retString += ") AS MONTHSLIP" + Environment.NewLine;
                retString += " ON MONTHSLIP.STOCKSECTIONCDRF = YEARSLIP.STOCKSECTIONCDRF" + Environment.NewLine;
                retString += " AND MONTHSLIP.SUPPLIERCDRF = YEARSLIP.SUPPLIERCDRF" + Environment.NewLine;
                #endregion

                #region JOIN句
                retString += "LEFT JOIN" + Environment.NewLine;
                // 2011/08/01 >>>
                //retString += " SUPPLIERRF AS SUPPLIER" + Environment.NewLine;
                retString += " SUPPLIERRF AS SUPPLIER WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                retString += " ON SUPPLIER.ENTERPRISECODERF = YEARSLIP.ENTERPRISECODERF" + Environment.NewLine;
                retString += " AND SUPPLIER.SUPPLIERCDRF = YEARSLIP.SUPPLIERCDRF" + Environment.NewLine;
                retString += "LEFT JOIN" + Environment.NewLine;
                // 2011/08/01 >>>
                //retString += " SECINFOSETRF AS SECINF" + Environment.NewLine;
                retString += " SECINFOSETRF AS SECINF WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                retString += " ON SECINF.ENTERPRISECODERF = YEARSLIP.ENTERPRISECODERF" + Environment.NewLine;
                retString += " AND SECINF.SECTIONCODERF = YEARSLIP.STOCKSECTIONCDRF" + Environment.NewLine;
                #endregion

                #region 実績無し排除
                retString += "WHERE" + Environment.NewLine;
                retString += " MONTHSLIP.TOTALPRICE != 0" + Environment.NewLine;
                retString += " OR MONTHSLIP.RETGOODSPRICE != 0" + Environment.NewLine;
                retString += " OR MONTHSLIP.TOTALDISCOUNT != 0" + Environment.NewLine;
                retString += " OR MONTHSLIP.TOTALPRICESTOCK != 0" + Environment.NewLine;
                retString += " OR MONTHSLIP.TOTALPRICETOTAL != 0" + Environment.NewLine;
                retString += " OR YEARSLIP.ANNUALTOTALPRICE != 0" + Environment.NewLine;
                retString += " OR YEARSLIP.ANNUALRETGOODSPRICE != 0" + Environment.NewLine;
                retString += " OR YEARSLIP.ANNUALTOTALDISCOUNT != 0" + Environment.NewLine;
                retString += " OR YEARSLIP.ANNUALTOTALPRICESTOCK != 0" + Environment.NewLine;
                retString += " OR YEARSLIP.ANNUALTOTALPRICETOTAL != 0" + Environment.NewLine;
                #endregion

                #endregion
                // 修正 2009.01.08 <<<
            }
            

            return retString;
        }
        #endregion

        #region Where句生成
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_orderListParamWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SlipHistAnalyzeParamWork _slipHistAnalyzeParamWork, ConstantManagement.LogicalMode logicalMode, int MakeMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;
            if (MakeMode == 0)
            {
                //企業コード
                retstring += " ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_slipHistAnalyzeParamWork.EnterpriseCode);

                //計上拠点コード
                if (_slipHistAnalyzeParamWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _slipHistAnalyzeParamWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }

                    if (sectionCodestr != "")
                    {
                        // 修正 2009.01.08 >>>
                        //retstring += " AND ADDUPSECCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                        retstring += " AND STOCKSECTIONCDRF IN (" + sectionCodestr + ") " + Environment.NewLine;
                        // 修正 2009.01.08 <<<
                    }
                }


                //開始仕入先コード
                if (_slipHistAnalyzeParamWork.StSupplierCd != 0)
                {
                    retstring += " AND SUPPLIERCDRF>=@STCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STCUSTOMERCODE", SqlDbType.Int);
                    paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(_slipHistAnalyzeParamWork.StSupplierCd);
                }

                //終了仕入先コード
                if ((_slipHistAnalyzeParamWork.EdSupplierCd != 0) && (_slipHistAnalyzeParamWork.EdSupplierCd != 999999))
                {
                    retstring += " AND SUPPLIERCDRF<=@EDCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDCUSTOMERCODE", SqlDbType.Int);
                    paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(_slipHistAnalyzeParamWork.EdSupplierCd);
                }

                //対象日付
                if (_slipHistAnalyzeParamWork.StAddUpYearMonth != 0)
                {
                    // 修正 2009.01.08 >>>
                    //retstring += " AND ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                    retstring += " AND STOCKDATEYMRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                    // 修正 2009.01.08 <<<

                    SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                    paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_slipHistAnalyzeParamWork.StAddUpYearMonth);
                }
                if (_slipHistAnalyzeParamWork.EdAddUpYearMonth != 0)
                {
                    // 修正 2009.01.08 >>>
                    //retstring += " AND ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                    retstring += " AND STOCKDATEYMRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                    // 修正 2009.01.08 <<<
                    SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                    paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_slipHistAnalyzeParamWork.EdAddUpYearMonth);
                }
            }
            else
            {
                //企業コード
                retstring += " ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;

                //計上拠点コード
                if (_slipHistAnalyzeParamWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _slipHistAnalyzeParamWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }

                    if (sectionCodestr != "")
                    {
                        // 修正 2009.01.08 >>>
                        //retstring += " AND ADDUPSECCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                        retstring += " AND STOCKSECTIONCDRF IN (" + sectionCodestr + ") " + Environment.NewLine;
                        // 修正 2009.01.08 <<<
                    }
                }


                //開始仕入先コード
                if (_slipHistAnalyzeParamWork.StSupplierCd != 0)
                {
                    retstring += " AND SUPPLIERCDRF>=@STCUSTOMERCODE" + Environment.NewLine;
                }

                //終了仕入先コード
                if ((_slipHistAnalyzeParamWork.EdSupplierCd != 0) && (_slipHistAnalyzeParamWork.EdSupplierCd != 999999))
                {
                    retstring += " AND SUPPLIERCDRF<=@EDCUSTOMERCODE" + Environment.NewLine;
                }

                //対象日付
                if (_slipHistAnalyzeParamWork.StAnnualAddUpYearMonth != 0)
                {
                    // 修正 2009.01.08 >>>
                    //retstring += " AND ADDUPYEARMONTHRF>=@STANNUALADDUPYEARMONTH" + Environment.NewLine;
                    retstring += " AND STOCKDATEYMRF>=@STANNUALADDUPYEARMONTH" + Environment.NewLine;
                    // 修正 2009.01.08 <<<

                    SqlParameter paraStAnnualAddUpYearMonth = sqlCommand.Parameters.Add("@STANNUALADDUPYEARMONTH", SqlDbType.Int);
                    paraStAnnualAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_slipHistAnalyzeParamWork.StAnnualAddUpYearMonth);
                }
                if (_slipHistAnalyzeParamWork.EdAnnualAddUpYearMonth != 0)
                {
                    // 修正 2009.01.08 >>>
                    //retstring += " AND ADDUPYEARMONTHRF<=@EDANNUALADDUPYEARMONTH" + Environment.NewLine;
                    retstring += " AND STOCKDATEYMRF<=@EDANNUALADDUPYEARMONTH" + Environment.NewLine;
                    // 修正 2009.01.08 <<<
                    SqlParameter paraEdAnnualAddUpYearMonth = sqlCommand.Parameters.Add("@EDANNUALADDUPYEARMONTH", SqlDbType.Int);
                    paraEdAnnualAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_slipHistAnalyzeParamWork.EdAnnualAddUpYearMonth);
                }
            }
            #endregion
            return retstring;
        }
        #endregion
    }
}

