//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売上仕入対比表(月報年報)DBリモートオブジェクト
// プログラム概要   : 売上仕入対比表(月報年報)の実データ操作を行うクラスです。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 23012 畠中 啓次朗
// 作 成 日  2008/11/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 23012 畠中 啓次朗
// 修 正 日  2009/05/22  修正内容 : 不具合修正(MANTIS 1.5次分 ID:13288)
//----------------------------------------------------------------------------//
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
    /// 売上仕入対比表(月報年報)DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上仕入対比表(月報年報)の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.11.18</br>
    /// <br></br>
    /// <br>Update Note:不具合修正(MANTIS 1.5次分 ID:13288)</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2009.05.22</br>
    /// <br></br>
    /// <br>Update Note:イスコ対応・READUNCOMMITTED対応</br>
    /// <br>Programmer : 30517 夏野 駿希</br>
    /// <br>Date       : 2011/08/01</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SalesSlipYearContrastResultWorkDB : RemoteDB, ISalesSlipYearContrastResultWorkDB
    {
        /// <summary>
        /// 売上仕入対比表(月報年報)DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.18</br>
        /// </remarks>
        public SalesSlipYearContrastResultWorkDB()
            :
        base("DCTOK02166D", "Broadleaf.Application.Remoting.ParamData.SalesSlipYearContrastResultWork", "MTTLSALESSTOCKSLIPRF") //基底クラスのコンストラクタ
        {
        }

        #region 売上仕入対比表(月報年報)
        /// <summary>
        /// 指定された企業コードの売上仕入対比表(月報年報)LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="customInqResultWork">検索結果</param>
        /// <param name="customInqOrderParamWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの売上仕入対比表(月報年報)LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.18</br>
        public int Search(out object salesSlipYearContrastResultList, object salesSlipYearContrastParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            salesSlipYearContrastResultList = null;

            SalesSlipYearContrastParamWork _salesSlipYearContrastParamWork = salesSlipYearContrastParamWork as SalesSlipYearContrastParamWork;

            try
            {
                status = SearchProc(out salesSlipYearContrastResultList, _salesSlipYearContrastParamWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipYearContrastResultWorkDB.Search Exception=" + ex.Message);
                salesSlipYearContrastResultList = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの売上仕入対比表(月報年報)LISTを全て戻します
        /// </summary>
        /// <param name="salesSlipYearContrastResultList">検索結果</param>
        /// <param name="_salesSlipYearContrastParamWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの売上仕入対比表(月報年報)LISTを全て戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.18</br>
        private int SearchProc(out object salesSlipYearContrastResultList, SalesSlipYearContrastParamWork _salesSlipYearContrastParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            salesSlipYearContrastResultList = null;

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


                status = SearchOrderProc(ref al, ref sqlConnection, _salesSlipYearContrastParamWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipYearContrastResultWorkDB.SearchProc Exception=" + ex.Message);
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

            salesSlipYearContrastResultList = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_salesSlipYearContrastParamWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, SalesSlipYearContrastParamWork _salesSlipYearContrastParamWork, ConstantManagement.LogicalMode logicalMode)
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
                selectTxt += MakeSelectString(ref sqlCommand, _salesSlipYearContrastParamWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    SalesSlipYearContrastResultWork ResultWork = new SalesSlipYearContrastResultWork();
                    //格納項目
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    ResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    ResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));

                    ResultWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY"));
                    ResultWork.SalesMoneyStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYSTOCK"));
                    ResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFIT"));
                    ResultWork.MoveShipmentPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MOVESHIPMENTPRICE"));
                    ResultWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICE"));
                    ResultWork.StockTotalPriceStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICESTOCK"));
                    ResultWork.MoveArrivalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MOVEARRIVALPRICE"));

                    ResultWork.AnnualSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YEARSALESMONEY"));
                    ResultWork.AnnualSalesMoneyStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YEARSALESMONEYSTOCK"));
                    ResultWork.AnnualGrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YEARGROSSPROFIT"));
                    ResultWork.AnnualMoveShipmentPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YEARMOVESHIPMENTPRICE"));
                    ResultWork.AnnualStockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YEARSTOCKTOTALPRICE"));
                    ResultWork.AnnualStockTotalPriceStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YEARSTOCKTOTALPRICESTOCK"));
                    ResultWork.AnnualMoveArrivalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("YEARMOVEARRIVALPRICE"));
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
        private string MakeSelectString(ref SqlCommand sqlCommand, SalesSlipYearContrastParamWork _salesSlipYearContrastParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retString = string.Empty;
            if (retString == "")
            {
                retString += "SELECT" + Environment.NewLine;
                retString += " YEARSLIP.ADDUPSECCODERF" + Environment.NewLine;
                retString += ",SECINF.SECTIONGUIDESNMRF" + Environment.NewLine;
                retString += ",YEARSLIP.SUPPLIERCDRF" + Environment.NewLine;
                retString += ",SUPPLIER.SUPPLIERSNMRF" + Environment.NewLine;
                retString += ",MONTHSLIP.SALESMONEY AS SALESMONEY" + Environment.NewLine;
                retString += ",MONTHSLIP.SALESMONEYSTOCK AS SALESMONEYSTOCK" + Environment.NewLine;
                retString += ",MONTHSLIP.GROSSPROFIT AS GROSSPROFIT" + Environment.NewLine;
                retString += ",MONTHSLIP.MOVESHIPMENTPRICE AS MOVESHIPMENTPRICE" + Environment.NewLine;
                retString += ",MONTHSLIP.STOCKTOTALPRICE AS STOCKTOTALPRICE" + Environment.NewLine;
                retString += ",MONTHSLIP.STOCKTOTALPRICESTOCK AS STOCKTOTALPRICESTOCK" + Environment.NewLine;
                retString += ",MONTHSLIP.MOVEARRIVALPRICE AS MOVEARRIVALPRICE" + Environment.NewLine;
                retString += ",YEARSLIP.SALESMONEY AS YEARSALESMONEY" + Environment.NewLine;
                retString += ",YEARSLIP.SALESMONEYSTOCK AS YEARSALESMONEYSTOCK" + Environment.NewLine;
                retString += ",YEARSLIP.GROSSPROFIT AS YEARGROSSPROFIT" + Environment.NewLine;
                retString += ",YEARSLIP.MOVESHIPMENTPRICE AS YEARMOVESHIPMENTPRICE" + Environment.NewLine;
                retString += ",YEARSLIP.STOCKTOTALPRICE AS YEARSTOCKTOTALPRICE" + Environment.NewLine;
                retString += ",YEARSLIP.STOCKTOTALPRICESTOCK AS YEARSTOCKTOTALPRICESTOCK" + Environment.NewLine;
                retString += ",YEARSLIP.MOVEARRIVALPRICE AS YEARMOVEARRIVALPRICE" + Environment.NewLine;

                #region 当月データ集計
                retString += "FROM" + Environment.NewLine;
                retString += "(" + Environment.NewLine;
                retString += "  SELECT " + Environment.NewLine;
                retString += "   ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,ADDUPSECCODERF" + Environment.NewLine;
                retString += "  ,SUPPLIERCDRF" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN SALESMONEYRF + SALESRETGOODSPRICERF + DISCOUNTPRICERF ELSE 0 END) AS SALESMONEY" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=1 THEN SALESMONEYRF + SALESRETGOODSPRICERF + DISCOUNTPRICERF ELSE 0 END) AS SALESMONEYSTOCK" + Environment.NewLine;
                // 修正 2009/05/22 >>>
                //retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=1 THEN GROSSPROFITRF ELSE 0 END) AS GROSSPROFIT" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN GROSSPROFITRF ELSE 0 END) AS GROSSPROFIT" + Environment.NewLine;
                // 修正 2009/05/22 <<<
                //retString += "  ,SUM(MOVESHIPMENTPRICERF)AS MOVESHIPMENTPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN MOVESHIPMENTPRICERF ELSE 0 END)AS MOVESHIPMENTPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALPRICERF + STOCKRETGOODSPRICERF + STOCKTOTALDISCOUNTRF ELSE 0 END) AS STOCKTOTALPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=1 THEN STOCKTOTALPRICERF + STOCKRETGOODSPRICERF + STOCKTOTALDISCOUNTRF ELSE 0 END) AS STOCKTOTALPRICESTOCK" + Environment.NewLine;
                // ADD 2009/04/08 ----->>>
                //retString += "  ,SUM(MOVEARRIVALPRICERF) AS MOVEARRIVALPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN MOVEARRIVALPRICERF ELSE 0 END) AS MOVEARRIVALPRICE" + Environment.NewLine;
                // ADD 2009/04/08 -----<<<
                retString += "  FROM" + Environment.NewLine;
                // 2011/08/01 >>>
                //retString += "  MTTLSALESSTOCKSLIPRF " + Environment.NewLine;
                retString += "  MTTLSALESSTOCKSLIPRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                retString += MakeWhereString(ref sqlCommand, _salesSlipYearContrastParamWork, logicalMode, 1);
                retString += "  GROUP BY" + Environment.NewLine;
                retString += "   ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,ADDUPSECCODERF" + Environment.NewLine;
                retString += "  ,SUPPLIERCDRF" + Environment.NewLine;
                retString += ") AS YEARSLIP" + Environment.NewLine;
                #endregion

                #region 当期データ集計
                // 修正 2009/05/22 当期データが正常に抽出されないため　当月←当期の結合ではなく　当月→当期の結合に修正 >>>
                //retString += "LEFT JOIN" + Environment.NewLine;
                retString += "RIGHT JOIN" + Environment.NewLine;
                // 修正 2009/05/22 <<<
                retString += "(" + Environment.NewLine;
                retString += "  SELECT" + Environment.NewLine;
                retString += "  ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,ADDUPSECCODERF" + Environment.NewLine;
                retString += "  ,SUPPLIERCDRF" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN SALESMONEYRF + SALESRETGOODSPRICERF + DISCOUNTPRICERF ELSE 0 END) AS SALESMONEY" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=1 THEN SALESMONEYRF + SALESRETGOODSPRICERF + DISCOUNTPRICERF ELSE 0 END) AS SALESMONEYSTOCK" + Environment.NewLine;
                // ADD 2009/04/08 ----->>>
                //retString += "  ,SUM(GROSSPROFITRF) AS GROSSPROFIT" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN GROSSPROFITRF ELSE 0 END) AS GROSSPROFIT" + Environment.NewLine;
                // ADD 2009/04/08 -----<<<
                //retString += "  ,SUM(MOVESHIPMENTPRICERF)AS MOVESHIPMENTPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN MOVESHIPMENTPRICERF ELSE 0 END)AS MOVESHIPMENTPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN STOCKTOTALPRICERF + STOCKRETGOODSPRICERF + STOCKTOTALDISCOUNTRF ELSE 0 END) AS STOCKTOTALPRICE" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=1 THEN STOCKTOTALPRICERF + STOCKRETGOODSPRICERF + STOCKTOTALDISCOUNTRF ELSE 0 END) AS STOCKTOTALPRICESTOCK" + Environment.NewLine;
                // ADD 2009/04/08 ----->>>
                retString += "  ,SUM(CASE WHEN RSLTTTLDIVCDRF=0 THEN MOVEARRIVALPRICERF ELSE 0 END) AS MOVEARRIVALPRICE" + Environment.NewLine;
                //retString += "  ,SUM(MOVEARRIVALPRICERF) AS MOVEARRIVALPRICE" + Environment.NewLine;
                // ADD 2009/04/08 -----<<<
                retString += "  FROM" + Environment.NewLine;
                // 2011/08/01 >>>
                //retString += "  MTTLSALESSTOCKSLIPRF " + Environment.NewLine;
                retString += "  MTTLSALESSTOCKSLIPRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                retString += MakeWhereString(ref sqlCommand, _salesSlipYearContrastParamWork, logicalMode, 0);
                retString += "  GROUP BY" + Environment.NewLine;
                retString += "  ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,ADDUPSECCODERF" + Environment.NewLine;
                retString += "  ,SUPPLIERCDRF" + Environment.NewLine;
                retString += ") AS MONTHSLIP" + Environment.NewLine;                
                retString += "ON MONTHSLIP.ADDUPSECCODERF = YEARSLIP.ADDUPSECCODERF" + Environment.NewLine;
                retString += "AND MONTHSLIP.SUPPLIERCDRF = YEARSLIP.SUPPLIERCDRF" + Environment.NewLine;
                #endregion

                #region JOIN
                retString += " LEFT JOIN " + Environment.NewLine;
                // 2011/08/01 >>>
                //retString += " SUPPLIERRF AS SUPPLIER" + Environment.NewLine;
                retString += " SUPPLIERRF AS SUPPLIER WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                retString += " ON SUPPLIER.ENTERPRISECODERF = YEARSLIP.ENTERPRISECODERF" + Environment.NewLine;
                retString += " AND SUPPLIER.SUPPLIERCDRF = YEARSLIP.SUPPLIERCDRF" + Environment.NewLine;
                retString += " LEFT JOIN" + Environment.NewLine;
                // 2011/08/01 >>>
                //retString += " SECINFOSETRF AS SECINF" + Environment.NewLine;
                retString += " SECINFOSETRF AS SECINF WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                retString += " ON SECINF.ENTERPRISECODERF = YEARSLIP.ENTERPRISECODERF" + Environment.NewLine;
                retString += " AND SECINF.SECTIONCODERF = YEARSLIP.ADDUPSECCODERF" + Environment.NewLine;
                #endregion
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
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesSlipYearContrastParamWork _salesSlipYearContrastParamWork, ConstantManagement.LogicalMode logicalMode, int MakeMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;
            if (MakeMode == 0)
            {
                //企業コード
                retstring += " ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_salesSlipYearContrastParamWork.EnterpriseCode);

                //計上拠点コード
                if (_salesSlipYearContrastParamWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _salesSlipYearContrastParamWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }

                    if (sectionCodestr != "")
                    {
                        retstring += " AND ADDUPSECCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                    }
                }

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    retstring += " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    retstring += " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }


                //開始仕入先コード
                if (_salesSlipYearContrastParamWork.StSupplierCd != 0)
                {
                    retstring += " AND SUPPLIERCDRF>=@STCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STCUSTOMERCODE", SqlDbType.Int);
                    paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(_salesSlipYearContrastParamWork.StSupplierCd);
                }

                //終了仕入先コード
                if ((_salesSlipYearContrastParamWork.EdSupplierCd != 0) && (_salesSlipYearContrastParamWork.EdSupplierCd != 999999))
                {
                    retstring += " AND SUPPLIERCDRF<=@EDCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDCUSTOMERCODE", SqlDbType.Int);
                    paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(_salesSlipYearContrastParamWork.EdSupplierCd);
                }

                //対象日付
                if (_salesSlipYearContrastParamWork.StAddUpYearMonth != 0)
                {
                    retstring += " AND ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                    SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                    paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_salesSlipYearContrastParamWork.StAddUpYearMonth);
                }
                if (_salesSlipYearContrastParamWork.EdAddUpYearMonth != 0)
                {
                    retstring += " AND ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                    SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                    paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_salesSlipYearContrastParamWork.EdAddUpYearMonth);
                }
            }
            else
            {
                //企業コード
                retstring += " ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;

                //計上拠点コード
                if (_salesSlipYearContrastParamWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _salesSlipYearContrastParamWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }

                    if (sectionCodestr != "")
                    {
                        retstring += " AND ADDUPSECCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                    }
                }

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    retstring += " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    retstring += " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }


                //開始仕入先コード
                if (_salesSlipYearContrastParamWork.StSupplierCd != 0)
                {
                    retstring += " AND SUPPLIERCDRF>=@STCUSTOMERCODE" + Environment.NewLine;
                }

                //終了仕入先コード
                if ((_salesSlipYearContrastParamWork.EdSupplierCd != 0) && (_salesSlipYearContrastParamWork.EdSupplierCd != 999999))
                {
                    retstring += " AND SUPPLIERCDRF<=@EDCUSTOMERCODE" + Environment.NewLine;
                }

                //対象日付
                if (_salesSlipYearContrastParamWork.StAnnualAddUpYearMonth != 0)
                {
                    retstring += " AND ADDUPYEARMONTHRF>=@STANNUALADDUPYEARMONTH" + Environment.NewLine;
                    SqlParameter paraStAnnualAddUpYearMonth = sqlCommand.Parameters.Add("@STANNUALADDUPYEARMONTH", SqlDbType.Int);
                    paraStAnnualAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_salesSlipYearContrastParamWork.StAnnualAddUpYearMonth);
                }
                if (_salesSlipYearContrastParamWork.EdAnnualAddUpYearMonth != 0)
                {
                    retstring += " AND ADDUPYEARMONTHRF<=@EDANNUALADDUPYEARMONTH" + Environment.NewLine;
                    SqlParameter paraEdAnnualAddUpYearMonth = sqlCommand.Parameters.Add("@EDANNUALADDUPYEARMONTH", SqlDbType.Int);
                    paraEdAnnualAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_salesSlipYearContrastParamWork.EdAnnualAddUpYearMonth);
                }
            }
            #endregion
            return retstring;
        }
        #endregion
    }
}

