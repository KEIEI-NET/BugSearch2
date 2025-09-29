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
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

//■─ファイルレイアウト変更時の修正について…────────────────────────■
//　ファイルレイアウトに変更があった場合は以下の文字列を頼りに修正を行って下さい。
//　　売上履歴データ　　 → ＠売上履歴データ変更＠
//　　売上履歴明細データ → ＠売上履歴明細データ変更＠
//■─────────────────────────────────────────────■

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上履歴データDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上履歴データの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note: 2008/06/06 M.Kubota</br>
    /// <br>           : PM.NSのファイルレイアウトに従って修正</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   SCM対応</br>
    /// <br>Programmer       :   22008 長内</br>
    /// <br>Date             :   2009/05/18</br>
    /// <br></br>
    /// <br>Update Note      :   得意先電子元帳の過去分赤伝対応の為、今まで考慮されていなかった不具合修正</br>
    /// <br>Programmer       :   22018 鈴木 正臣</br>
    /// <br>Date             :   2009/10/19</br>
    /// <br>Update Note      :   自動回答区分(SCM)追加の対応</br>
    /// <br>Programmer       :   duzg</br>
    /// <br>Date             :   2011/07/23</br>
    /// <br>Update Note      :   PCCUOE対応</br>
    /// <br>Programmer       :   高峰</br>
    /// <br>Date             :   2011/08/10</br>
    /// <br>Update Note      :   readmine #8412</br>
    /// <br>Programmer       :   liusy</br>
    /// <br>Date             :   2011/12/02</br>
    /// <br>Update Note: 2011/12/15 凌小青</br>
    /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
    /// <br>             Redmine#27313　得意先電子元帳の得意先伝票番号が空白になっているの修正</br>
    /// <br></br>
    /// <br>Update Note      :   SF表示項目追加対応</br>
    /// <br>Programmer       :   西 毅</br>
    /// <br>Date             :   2012/01/23</br>
    /// <br></br>
    /// <br>Update Note      :   仕入先情報追加対応</br>
    /// <br>Programmer       :   西 毅</br>
    /// <br>Date             :   2012/05/07</br>
    /// </remarks>
    [Serializable]
    public class SalesSlipHistDB : RemoteWithAppLockDB, ISalesSlipHistDB
    {
        /// <summary>
        /// 売上履歴データDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        public SalesSlipHistDB()
            :
            base("DCHNB01846D", "Broadleaf.Application.Remoting.ParamData.salesHistoryWork", "SALESHISTORYRF")
        {

        }

        #region [Read]
        
        /// <summary>
        /// 指定された条件に合致する売上履歴データと売上明細履歴データを取得します。
        /// </summary>
        /// <param name="saleshistoryWork">検索条件と取得値を兼ねた salesHistoryWork</param>
        /// <param name="saleshistdtlWorkList">検索条件と取得値を兼ねた StockhistdtlWork が格納されている ArrayList</param>
        /// <param name="readMode">0:売上履歴のみで検索  1:売上明細履歴も使用して検索</param>
        /// <returns>STATUS</returns>
        public int Read(ref SalesHistoryWork saleshistoryWork, ref ArrayList saleshistdtlWorkList, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlConnection sqlConnection = null;
            try
            {
                //コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection != null)
                {
                    SqlTransaction dummyTran = null;
                    status = ReadProc(ref saleshistoryWork, ref saleshistdtlWorkList, readMode, ref sqlConnection, ref dummyTran);
                }
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 指定された条件に合致する売上履歴データと売上明細履歴データを取得します。
        /// </summary>
        /// <param name="saleshistoryWork">検索条件と取得値を兼ねた StockHistoryWork</param>
        /// <param name="saleshistdtlWorkList">検索条件と取得値を兼ねた StockhistdtlWork が格納されている ArrayList</param>
        /// <param name="readMode">0:売上履歴のみで検索  1:売上明細履歴も使用して検索</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int ReadProc(ref SalesHistoryWork saleshistoryWork, ref ArrayList saleshistdtlWorkList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            
            status = this.ReadSalesSlipHist(ref saleshistoryWork, readMode, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (saleshistdtlWorkList != null && saleshistdtlWorkList.Count > 0 && saleshistdtlWorkList[0] is SalesHistDtlWork && readMode == 1)
                {
                    status = this.ReadSalesSlHistDtl(ref saleshistdtlWorkList, readMode, ref sqlConnection, ref sqlTransaction);
                }
                else
                {
                    status = this.ReadSalesSlHistDtl(out saleshistdtlWorkList, saleshistoryWork, readMode, ref sqlConnection, ref sqlTransaction);
                }
            }
            
            return status;
        }

        /// <summary>
        /// 指定された条件に合致する売上履歴データを取得します。
        /// </summary>
        /// <param name="saleshistoryWork">検索条件と取得値を兼ねる StockHistoryWork オブジェクト</param>
        /// <param name="readMode">検索区分 ※現時点では未使用</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int ReadSalesSlipHist(ref SalesHistoryWork saleshistoryWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            if (saleshistoryWork != null)
            {
                SqlDataReader myReader = null;

                try
                {
                    #region [SELECT文]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  SLHIST.*" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SALESHISTORYRF AS SLHIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  SLHIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SLHIST.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND SLHIST.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                    #endregion

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                    {
                        // トランザクションが指定されている場合は設定する
                        if (sqlTransaction != null)
                        {
                            sqlCommand.Transaction = sqlTransaction;
                        }

                        // Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                        SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(saleshistoryWork.EnterpriseCode);
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.AcptAnOdrStatus);
                        findSalesSlipNum.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SalesSlipNum);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            this.CopyToSalesHistoryWorkFromReader(myReader, ref saleshistoryWork);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);
                }
                finally
                {
                    if (myReader != null)
                    {
                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        myReader.Dispose();
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// 指定された条件に合致する売上履歴データに紐付く売上明細履歴データを取得します。
        /// </summary>
        /// <param name="saleshistdtlWorkList">取得した StockHistDtlWork が格納される ArrayList</param>
        /// <param name="saleshistoryWork">検索条件となる StockHistoryWork オブジェクト</param>
        /// <param name="readMode">検索区分 ※現時点では未使用</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// 売上伝票番号(＋売上形式)で売上明細履歴を取得したい場合に使用する。
        /// </remarks>
        public int ReadSalesSlHistDtl(out ArrayList saleshistdtlWorkList, SalesHistoryWork saleshistoryWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            saleshistdtlWorkList = new ArrayList();

            if (saleshistoryWork != null)
            {
                SqlDataReader myReader = null;

                try
                {
                    #region [SELECT文]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  DTIL.*" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
                    //sqlText += "  SALESHISTORYWORK AS HIST INNER JOIN SALESHISTDTLWORK AS DTIL" + Environment.NewLine;
                    sqlText += "  SALESHISTORYRF AS HIST INNER JOIN SALESHISTDTLRF AS DTIL" + Environment.NewLine;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
                    sqlText += "  ON  HIST.ENTERPRISECODERF = DTIL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND HIST.ACPTANODRSTATUSRF = DTIL.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "  AND HIST.SALESSLIPNUMRF = DTIL.SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND HIST.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                    #endregion

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                    {
                        // トランザクションが指定されている場合は設定する
                        if (sqlTransaction != null)
                        {
                            sqlCommand.Transaction = sqlTransaction;
                        }

                        // Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                        SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(saleshistoryWork.EnterpriseCode);
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.AcptAnOdrStatus);
                        findSalesSlipNum.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SalesSlipNum);

                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            saleshistdtlWorkList.Add(CopyToSalesHistDtlWorkFromReader(ref myReader));
                        }

                        if (saleshistdtlWorkList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);
                }
                finally
                {
                    if (myReader != null)
                    {
                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        myReader.Dispose();
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// 指定された条件に合致する売上明細履歴データを取得します。
        /// </summary>
        /// <param name="saleshistdtlWorkList">検索条件と取得値を兼ねる StockHistDtlWork が格納された ArrayList</param>
        /// <param name="readMode">検索区分 ※現時点では未使用</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// 売上明細通番(＋売上形式)で売上明細履歴を取得したい場合に使用する。
        /// </remarks>
        public int ReadSalesSlHistDtl(ref ArrayList saleshistdtlWorkList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            if (saleshistdtlWorkList != null && saleshistdtlWorkList.Count > 0 && saleshistdtlWorkList[0] is SalesHistDtlWork)
            {
                SqlDataReader myReader = null;

                try
                {
                    #region [SELECT文]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  DTIL.*" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SALESHISTDTLRF AS DTIL" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND DTIL.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND DTIL.SALESSLIPDTLNUMRF = @FINDSALESSLIPDTLNUM" + Environment.NewLine;
                    #endregion

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                    {
                        // トランザクションが指定されている場合は設定する
                        if (sqlTransaction != null)
                        {
                            sqlCommand.Transaction = sqlTransaction;
                        }

                        // Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);     // 企業コード
                        SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);     // 受注ステータス
                        SqlParameter findSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUM", SqlDbType.BigInt);  // 売上明細通番

                        int hitCount = 0;
                        
                        foreach (object item in saleshistdtlWorkList)
                        {
                            SalesHistDtlWork dtlwork = item as SalesHistDtlWork;

                            if (dtlwork != null)
                            {
                                //Parameterオブジェクトへ値設定
                                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(dtlwork.EnterpriseCode);
                                findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(dtlwork.AcptAnOdrStatus);
                                findSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(dtlwork.SalesSlipDtlNum);

                                try
                                {
                                    myReader = sqlCommand.ExecuteReader();

                                    if (myReader.Read())
                                    {
                                        this.CopyToSalesHistDtlWorkFromReader(myReader, ref dtlwork);
                                        hitCount++;
                                    }
                                }
                                finally
                                {
                                    if (myReader != null)
                                    {
                                        if (!myReader.IsClosed)
                                        {
                                            myReader.Close();
                                        }

                                        myReader.Dispose();
                                        myReader = null;
                                    }
                                }
                            }
                        }

                        if (hitCount > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                }
                finally
                {
                    if (myReader != null)
                    {
                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        myReader.Dispose();
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// 前回商品単価取得メソッド
        /// </summary>
        /// <param name="param"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int GetLastUnitPrice(object param, out object value)
        {
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            value = null;

            try
            {
                GetLastUnitPriceParamWork paramWork = param as GetLastUnitPriceParamWork;

                if (paramWork == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": 取得パラメータが未指定です。";
                    base.WriteErrorLog(errmsg, status);
                }
                else
                {
                    //コネクション生成
                    sqlConnection = this.CreateSqlConnection(true);

                    if (sqlConnection != null)
                    {
                        SalesHistDtlWork outValue = null;
                        status = GetLastUnitPriceProc(paramWork, out outValue, ref sqlConnection, ref sqlTransaction);
                        value = outValue;
                    }
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            }
            
            return status;
        }

        /// <summary>
        /// 前回商品単価取得メソッド
        /// </summary>
        /// <param name="paramwrk"></param>
        /// <param name="dtlwrk"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int GetLastUnitPriceProc(GetLastUnitPriceParamWork paramwrk, out SalesHistDtlWork dtlwrk, ref SqlConnection connection, ref SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            dtlwrk = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand("", connection, transaction);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  MAIN.*" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SALESHISTDTLRF AS MAIN" + Environment.NewLine;
                sqlText += "  INNER JOIN" + Environment.NewLine;
                sqlText += "  (" + Environment.NewLine;
                sqlText += "    SELECT" + Environment.NewLine;
                sqlText += "      DTIL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "     ,DTIL.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += "     ,MAX(DTIL.SALESSLIPNUMRF) AS SALESSLIPNUMRF" + Environment.NewLine;
                sqlText += "     ,MAX(DTIL.SALESSLIPDTLNUMRF) AS SALESSLIPDTLNUMRF" + Environment.NewLine;
                sqlText += "     ,MAX(DTIL.SALESROWNORF) AS SALESROWNORF" + Environment.NewLine;
                sqlText += "     ,MAX(DTIL.SALESDATERF) AS MAXSALESDATE" + Environment.NewLine;
                sqlText += "    FROM" + Environment.NewLine;
                sqlText += "      SALESHISTORYRF AS SLIP INNER JOIN SALESHISTDTLRF AS DTIL" + Environment.NewLine;
                sqlText += "      ON  SLIP.ENTERPRISECODERF = DTIL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "      AND SLIP.ACPTANODRSTATUSRF = DTIL.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += "      AND SLIP.SALESSLIPNUMRF = DTIL.SALESSLIPNUMRF" + Environment.NewLine;
                sqlText += "    WHERE" + Environment.NewLine;
                sqlText += "      SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "      AND SLIP.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                sqlText += "      AND DTIL.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                sqlText += "      AND DTIL.GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                sqlText += "    GROUP BY" + Environment.NewLine;
                sqlText += "      DTIL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "     ,DTIL.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += "  ) AS SUB" + Environment.NewLine;
                sqlText += "  ON  MAIN.ENTERPRISECODERF = SUB.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND MAIN.ACPTANODRSTATUSRF = SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += "  AND MAIN.SALESSLIPDTLNUMRF = SUB.SALESSLIPDTLNUMRF" + Environment.NewLine;

                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramwrk.EnterpriseCode);
                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(paramwrk.CustomerCode);
                findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paramwrk.GoodsMakerCd);
                findGoodsNo.Value = SqlDataMediator.SqlSetString(paramwrk.GoodsNo);
                # endregion

                sqlCommand.CommandText = sqlText;

                # region [SQL Debug]
#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif
                # endregion

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    dtlwrk = this.CopyToSalesHistDtlWorkFromReader(ref myReader);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int Write(ref ArrayList paramList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SalesHistoryWork saleshistoryWork = null;
            ArrayList saleshistdtlWorkList = null;

            try
            {
                status = this.GetSalesHistoryParam(paramList, out saleshistoryWork, out saleshistdtlWorkList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //write実行
                    status = this.WriteProc(ref saleshistoryWork, ref saleshistdtlWorkList, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                // 売上履歴及び売上明細履歴に関するパラメータを削除する
                for (int i = paramList.Count - 1; i >= 0; i--)
                {
                    if (paramList[i] is SalesHistoryWork)
                    {
                        paramList.RemoveAt(i);
                    }
                    else if (paramList[i] is ArrayList)
                    {
                        if ((paramList[i] as ArrayList).Count > 0 && (paramList[i] as ArrayList)[0] is SalesHistDtlWork)
                        {
                            paramList.RemoveAt(i);
                        }
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// 売上履歴データ及び売上明細履歴データを登録(追加・更新)します。
        /// </summary>
        /// <param name="saleshistoryWork">登録対象となる StockHistoryWork</param>
        /// <param name="saleshistdtlWorkList">登録対象となる StockhistdtlWork が格納されている ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int WriteProc(ref SalesHistoryWork saleshistoryWork, ref ArrayList saleshistdtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 売上履歴データ登録処理
            status = this.WriteSalesHistory(ref saleshistoryWork, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 売上明細履歴データ登録処理
                status = this.WriteSalesHistDtlWork(ref saleshistdtlWorkList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }

        /// <summary>
        /// 売上履歴データを登録(追加・更新)します。
        /// </summary>
        /// <param name="saleshistoryWork">登録対象となる SalesHistoryWork</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int WriteSalesHistory(ref SalesHistoryWork saleshistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteSalesHistoryProc(ref saleshistoryWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 売上履歴データを登録(追加・更新)します。
        /// </summary>
        /// <param name="saleshistoryWork">登録対象となる SalesHistoryWork</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        private int WriteSalesHistoryProc(ref SalesHistoryWork saleshistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                // 受注ステータスが 30:売上 の場合にのみ履歴にデータを登録する
                if (saleshistoryWork != null && saleshistoryWork.AcptAnOdrStatus == 30)
                {
                    // データの有無に関わらずキーを条件に削除を行う
                    # region [DELETE]
                    string sqlText = "";
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SALESHISTORYRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                    // Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(saleshistoryWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.AcptAnOdrStatus);
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SalesSlipNum);

                    sqlCommand.ExecuteNonQuery();
                    # endregion

                    // 売上履歴データを新規登録する
                    # region [INSERT]

                    //＠売上履歴データ変更＠
                    # region [INSERT文]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO SALESHISTORYRF (" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,SUBSECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,DEBITNOTEDIVRF" + Environment.NewLine;
                    sqlText += " ,DEBITNLNKSALESSLNUMRF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPCDRF" + Environment.NewLine;
                    sqlText += " ,SALESGOODSCDRF" + Environment.NewLine;
                    sqlText += " ,ACCRECDIVCDRF" + Environment.NewLine;
                    sqlText += " ,SALESINPSECCDRF" + Environment.NewLine;
                    sqlText += " ,DEMANDADDUPSECCDRF" + Environment.NewLine;
                    sqlText += " ,RESULTSADDUPSECCDRF" + Environment.NewLine;
                    sqlText += " ,UPDATESECCDRF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPUPDATECDRF" + Environment.NewLine;
                    sqlText += " ,SEARCHSLIPDATERF" + Environment.NewLine;
                    sqlText += " ,SHIPMENTDAYRF" + Environment.NewLine;
                    sqlText += " ,SALESDATERF" + Environment.NewLine;
                    sqlText += " ,ADDUPADATERF" + Environment.NewLine;
                    sqlText += " ,DELAYPAYMENTDIVRF" + Environment.NewLine;
                    sqlText += " ,INPUTAGENCDRF" + Environment.NewLine;
                    sqlText += " ,INPUTAGENNMRF" + Environment.NewLine;
                    sqlText += " ,SALESINPUTCODERF" + Environment.NewLine;
                    sqlText += " ,SALESINPUTNAMERF" + Environment.NewLine;
                    sqlText += " ,FRONTEMPLOYEECDRF" + Environment.NewLine;
                    sqlText += " ,FRONTEMPLOYEENMRF" + Environment.NewLine;
                    sqlText += " ,SALESEMPLOYEECDRF" + Environment.NewLine;
                    sqlText += " ,SALESEMPLOYEENMRF" + Environment.NewLine;
                    sqlText += " ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                    sqlText += " ,TTLAMNTDISPRATEAPYRF" + Environment.NewLine;
                    sqlText += " ,SALESTOTALTAXINCRF" + Environment.NewLine;
                    sqlText += " ,SALESTOTALTAXEXCRF" + Environment.NewLine;
                    sqlText += " ,SALESPRTTOTALTAXINCRF" + Environment.NewLine;
                    sqlText += " ,SALESPRTTOTALTAXEXCRF" + Environment.NewLine;
                    sqlText += " ,SALESWORKTOTALTAXINCRF" + Environment.NewLine;
                    sqlText += " ,SALESWORKTOTALTAXEXCRF" + Environment.NewLine;
                    sqlText += " ,SALESSUBTOTALTAXINCRF" + Environment.NewLine;
                    sqlText += " ,SALESSUBTOTALTAXEXCRF" + Environment.NewLine;
                    sqlText += " ,SALESPRTSUBTTLINCRF" + Environment.NewLine;
                    sqlText += " ,SALESPRTSUBTTLEXCRF" + Environment.NewLine;
                    sqlText += " ,SALESWORKSUBTTLINCRF" + Environment.NewLine;
                    sqlText += " ,SALESWORKSUBTTLEXCRF" + Environment.NewLine;
                    sqlText += " ,SALESNETPRICERF" + Environment.NewLine;
                    sqlText += " ,SALESSUBTOTALTAXRF" + Environment.NewLine;
                    sqlText += " ,ITDEDSALESOUTTAXRF" + Environment.NewLine;
                    sqlText += " ,ITDEDSALESINTAXRF" + Environment.NewLine;
                    sqlText += " ,SALSUBTTLSUBTOTAXFRERF" + Environment.NewLine;
                    sqlText += " ,SALESOUTTAXRF" + Environment.NewLine;
                    sqlText += " ,SALAMNTCONSTAXINCLURF" + Environment.NewLine;
                    sqlText += " ,SALESDISTTLTAXEXCRF" + Environment.NewLine;
                    sqlText += " ,ITDEDSALESDISOUTTAXRF" + Environment.NewLine;
                    sqlText += " ,ITDEDSALESDISINTAXRF" + Environment.NewLine;
                    sqlText += " ,ITDEDPARTSDISOUTTAXRF" + Environment.NewLine;
                    sqlText += " ,ITDEDPARTSDISINTAXRF" + Environment.NewLine;
                    sqlText += " ,ITDEDWORKDISOUTTAXRF" + Environment.NewLine;
                    sqlText += " ,ITDEDWORKDISINTAXRF" + Environment.NewLine;
                    sqlText += " ,ITDEDSALESDISTAXFRERF" + Environment.NewLine;
                    sqlText += " ,SALESDISOUTTAXRF" + Environment.NewLine;
                    sqlText += " ,SALESDISTTLTAXINCLURF" + Environment.NewLine;
                    sqlText += " ,PARTSDISCOUNTRATERF" + Environment.NewLine;
                    sqlText += " ,RAVORDISCOUNTRATERF" + Environment.NewLine;
                    sqlText += " ,TOTALCOSTRF" + Environment.NewLine;
                    sqlText += " ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                    sqlText += " ,CONSTAXRATERF" + Environment.NewLine;
                    sqlText += " ,FRACTIONPROCCDRF" + Environment.NewLine;
                    sqlText += " ,ACCRECCONSTAXRF" + Environment.NewLine;
                    sqlText += " ,AUTODEPOSITCDRF" + Environment.NewLine;
                    sqlText += " ,AUTODEPOSITSLIPNORF" + Environment.NewLine;
                    sqlText += " ,DEPOSITALLOWANCETTLRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITALWCBLNCERF" + Environment.NewLine;
                    sqlText += " ,CLAIMCODERF" + Environment.NewLine;
                    sqlText += " ,CLAIMSNMRF" + Environment.NewLine;
                    sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += " ,CUSTOMERNAMERF" + Environment.NewLine;
                    sqlText += " ,CUSTOMERNAME2RF" + Environment.NewLine;
                    sqlText += " ,CUSTOMERSNMRF" + Environment.NewLine;
                    sqlText += " ,HONORIFICTITLERF" + Environment.NewLine;
                    sqlText += " ,OUTPUTNAMECODERF" + Environment.NewLine;
                    sqlText += " ,OUTPUTNAMERF" + Environment.NewLine;
                    sqlText += " ,SLIPADDRESSDIVRF" + Environment.NewLine;
                    sqlText += " ,ADDRESSEECODERF" + Environment.NewLine;
                    sqlText += " ,ADDRESSEENAMERF" + Environment.NewLine;
                    sqlText += " ,ADDRESSEENAME2RF" + Environment.NewLine;
                    sqlText += " ,ADDRESSEEPOSTNORF" + Environment.NewLine;
                    sqlText += " ,ADDRESSEEADDR1RF" + Environment.NewLine;
                    sqlText += " ,ADDRESSEEADDR3RF" + Environment.NewLine;
                    sqlText += " ,ADDRESSEEADDR4RF" + Environment.NewLine;
                    sqlText += " ,ADDRESSEETELNORF" + Environment.NewLine;
                    sqlText += " ,ADDRESSEEFAXNORF" + Environment.NewLine;
                    sqlText += " ,PARTYSALESLIPNUMRF" + Environment.NewLine;
                    sqlText += " ,SLIPNOTERF" + Environment.NewLine;
                    sqlText += " ,SLIPNOTE2RF" + Environment.NewLine;
                    sqlText += " ,SLIPNOTE3RF" + Environment.NewLine;
                    sqlText += " ,RETGOODSREASONDIVRF" + Environment.NewLine;
                    sqlText += " ,RETGOODSREASONRF" + Environment.NewLine;
                    sqlText += " ,DETAILROWCOUNTRF" + Environment.NewLine;
                    sqlText += " ,EDISENDDATERF" + Environment.NewLine;
                    sqlText += " ,EDITAKEINDATERF" + Environment.NewLine;
                    sqlText += " ,UOEREMARK1RF" + Environment.NewLine;
                    sqlText += " ,UOEREMARK2RF" + Environment.NewLine;
                    sqlText += " ,SLIPPRINTDIVCDRF" + Environment.NewLine;
                    sqlText += " ,SLIPPRINTFINISHCDRF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPPRINTDATERF" + Environment.NewLine;
                    sqlText += " ,BUSINESSTYPECODERF" + Environment.NewLine;
                    sqlText += " ,BUSINESSTYPENAMERF" + Environment.NewLine;
                    sqlText += " ,DELIVEREDGOODSDIVRF" + Environment.NewLine;
                    sqlText += " ,DELIVEREDGOODSDIVNMRF" + Environment.NewLine;
                    sqlText += " ,SALESAREACODERF" + Environment.NewLine;
                    sqlText += " ,SALESAREANAMERF" + Environment.NewLine;
                    sqlText += " ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                    sqlText += " ,COMPLETECDRF" + Environment.NewLine;
                    sqlText += " ,SALESPRICEFRACPROCCDRF" + Environment.NewLine;
                    sqlText += " ,STOCKGOODSTTLTAXEXCRF" + Environment.NewLine;
                    sqlText += " ,PUREGOODSTTLTAXEXCRF" + Environment.NewLine;
                    sqlText += " ,LISTPRICEPRINTDIVRF" + Environment.NewLine;
                    //-------ADD BY 凌小青 on 2011/12/15 for Redmine#27313------->>>>>>>>>
                    sqlText += " ,CUSTSLIPNORF" + Environment.NewLine;
                    //-------ADD BY 凌小青 on 2011/12/15 for Redmine#27313-------<<<<<<<<<
                    sqlText += " ,ERANAMEDISPCD1RF)" + Environment.NewLine;
                    sqlText += "VALUES" + Environment.NewLine;
                    sqlText += "  (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPNUM" + Environment.NewLine;
                    sqlText += " ,@SECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@SUBSECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@DEBITNOTEDIV" + Environment.NewLine;
                    sqlText += " ,@DEBITNLNKSALESSLNUM" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPCD" + Environment.NewLine;
                    sqlText += " ,@SALESGOODSCD" + Environment.NewLine;
                    sqlText += " ,@ACCRECDIVCD" + Environment.NewLine;
                    sqlText += " ,@SALESINPSECCD" + Environment.NewLine;
                    sqlText += " ,@DEMANDADDUPSECCD" + Environment.NewLine;
                    sqlText += " ,@RESULTSADDUPSECCD" + Environment.NewLine;
                    sqlText += " ,@UPDATESECCD" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPUPDATECD" + Environment.NewLine;
                    sqlText += " ,@SEARCHSLIPDATE" + Environment.NewLine;
                    sqlText += " ,@SHIPMENTDAY" + Environment.NewLine;
                    sqlText += " ,@SALESDATE" + Environment.NewLine;
                    sqlText += " ,@ADDUPADATE" + Environment.NewLine;
                    sqlText += " ,@DELAYPAYMENTDIV" + Environment.NewLine;
                    sqlText += " ,@INPUTAGENCD" + Environment.NewLine;
                    sqlText += " ,@INPUTAGENNM" + Environment.NewLine;
                    sqlText += " ,@SALESINPUTCODE" + Environment.NewLine;
                    sqlText += " ,@SALESINPUTNAME" + Environment.NewLine;
                    sqlText += " ,@FRONTEMPLOYEECD" + Environment.NewLine;
                    sqlText += " ,@FRONTEMPLOYEENM" + Environment.NewLine;
                    sqlText += " ,@SALESEMPLOYEECD" + Environment.NewLine;
                    sqlText += " ,@SALESEMPLOYEENM" + Environment.NewLine;
                    sqlText += " ,@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                    sqlText += " ,@TTLAMNTDISPRATEAPY" + Environment.NewLine;
                    sqlText += " ,@SALESTOTALTAXINC" + Environment.NewLine;
                    sqlText += " ,@SALESTOTALTAXEXC" + Environment.NewLine;
                    sqlText += " ,@SALESPRTTOTALTAXINC" + Environment.NewLine;
                    sqlText += " ,@SALESPRTTOTALTAXEXC" + Environment.NewLine;
                    sqlText += " ,@SALESWORKTOTALTAXINC" + Environment.NewLine;
                    sqlText += " ,@SALESWORKTOTALTAXEXC" + Environment.NewLine;
                    sqlText += " ,@SALESSUBTOTALTAXINC" + Environment.NewLine;
                    sqlText += " ,@SALESSUBTOTALTAXEXC" + Environment.NewLine;
                    sqlText += " ,@SALESPRTSUBTTLINC" + Environment.NewLine;
                    sqlText += " ,@SALESPRTSUBTTLEXC" + Environment.NewLine;
                    sqlText += " ,@SALESWORKSUBTTLINC" + Environment.NewLine;
                    sqlText += " ,@SALESWORKSUBTTLEXC" + Environment.NewLine;
                    sqlText += " ,@SALESNETPRICE" + Environment.NewLine;
                    sqlText += " ,@SALESSUBTOTALTAX" + Environment.NewLine;
                    sqlText += " ,@ITDEDSALESOUTTAX" + Environment.NewLine;
                    sqlText += " ,@ITDEDSALESINTAX" + Environment.NewLine;
                    sqlText += " ,@SALSUBTTLSUBTOTAXFRE" + Environment.NewLine;
                    sqlText += " ,@SALESOUTTAX" + Environment.NewLine;
                    sqlText += " ,@SALAMNTCONSTAXINCLU" + Environment.NewLine;
                    sqlText += " ,@SALESDISTTLTAXEXC" + Environment.NewLine;
                    sqlText += " ,@ITDEDSALESDISOUTTAX" + Environment.NewLine;
                    sqlText += " ,@ITDEDSALESDISINTAX" + Environment.NewLine;
                    sqlText += " ,@ITDEDPARTSDISOUTTAX" + Environment.NewLine;
                    sqlText += " ,@ITDEDPARTSDISINTAX" + Environment.NewLine;
                    sqlText += " ,@ITDEDWORKDISOUTTAX" + Environment.NewLine;
                    sqlText += " ,@ITDEDWORKDISINTAX" + Environment.NewLine;
                    sqlText += " ,@ITDEDSALESDISTAXFRE" + Environment.NewLine;
                    sqlText += " ,@SALESDISOUTTAX" + Environment.NewLine;
                    sqlText += " ,@SALESDISTTLTAXINCLU" + Environment.NewLine;
                    sqlText += " ,@PARTSDISCOUNTRATE" + Environment.NewLine;
                    sqlText += " ,@RAVORDISCOUNTRATE" + Environment.NewLine;
                    sqlText += " ,@TOTALCOST" + Environment.NewLine;
                    sqlText += " ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                    sqlText += " ,@CONSTAXRATE" + Environment.NewLine;
                    sqlText += " ,@FRACTIONPROCCD" + Environment.NewLine;
                    sqlText += " ,@ACCRECCONSTAX" + Environment.NewLine;
                    sqlText += " ,@AUTODEPOSITCD" + Environment.NewLine;
                    sqlText += " ,@AUTODEPOSITSLIPNO" + Environment.NewLine;
                    sqlText += " ,@DEPOSITALLOWANCETTL" + Environment.NewLine;
                    sqlText += " ,@DEPOSITALWCBLNCE" + Environment.NewLine;
                    sqlText += " ,@CLAIMCODE" + Environment.NewLine;
                    sqlText += " ,@CLAIMSNM" + Environment.NewLine;
                    sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                    sqlText += " ,@CUSTOMERNAME" + Environment.NewLine;
                    sqlText += " ,@CUSTOMERNAME2" + Environment.NewLine;
                    sqlText += " ,@CUSTOMERSNM" + Environment.NewLine;
                    sqlText += " ,@HONORIFICTITLE" + Environment.NewLine;
                    sqlText += " ,@OUTPUTNAMECODE" + Environment.NewLine;
                    sqlText += " ,@OUTPUTNAME" + Environment.NewLine;
                    sqlText += " ,@SLIPADDRESSDIV" + Environment.NewLine;
                    sqlText += " ,@ADDRESSEECODE" + Environment.NewLine;
                    sqlText += " ,@ADDRESSEENAME" + Environment.NewLine;
                    sqlText += " ,@ADDRESSEENAME2" + Environment.NewLine;
                    sqlText += " ,@ADDRESSEEPOSTNO" + Environment.NewLine;
                    sqlText += " ,@ADDRESSEEADDR1" + Environment.NewLine;
                    sqlText += " ,@ADDRESSEEADDR3" + Environment.NewLine;
                    sqlText += " ,@ADDRESSEEADDR4" + Environment.NewLine;
                    sqlText += " ,@ADDRESSEETELNO" + Environment.NewLine;
                    sqlText += " ,@ADDRESSEEFAXNO" + Environment.NewLine;
                    sqlText += " ,@PARTYSALESLIPNUM" + Environment.NewLine;
                    sqlText += " ,@SLIPNOTE" + Environment.NewLine;
                    sqlText += " ,@SLIPNOTE2" + Environment.NewLine;
                    sqlText += " ,@SLIPNOTE3" + Environment.NewLine;
                    sqlText += " ,@RETGOODSREASONDIV" + Environment.NewLine;
                    sqlText += " ,@RETGOODSREASON" + Environment.NewLine;
                    sqlText += " ,@DETAILROWCOUNT" + Environment.NewLine;
                    sqlText += " ,@EDISENDDATE" + Environment.NewLine;
                    sqlText += " ,@EDITAKEINDATE" + Environment.NewLine;
                    sqlText += " ,@UOEREMARK1" + Environment.NewLine;
                    sqlText += " ,@UOEREMARK2" + Environment.NewLine;
                    sqlText += " ,@SLIPPRINTDIVCD" + Environment.NewLine;
                    sqlText += " ,@SLIPPRINTFINISHCD" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPPRINTDATE" + Environment.NewLine;
                    sqlText += " ,@BUSINESSTYPECODE" + Environment.NewLine;
                    sqlText += " ,@BUSINESSTYPENAME" + Environment.NewLine;
                    sqlText += " ,@DELIVEREDGOODSDIV" + Environment.NewLine;
                    sqlText += " ,@DELIVEREDGOODSDIVNM" + Environment.NewLine;
                    sqlText += " ,@SALESAREACODE" + Environment.NewLine;
                    sqlText += " ,@SALESAREANAME" + Environment.NewLine;
                    sqlText += " ,@SLIPPRTSETPAPERID" + Environment.NewLine;
                    sqlText += " ,@COMPLETECD" + Environment.NewLine;
                    sqlText += " ,@SALESPRICEFRACPROCCD" + Environment.NewLine;
                    sqlText += " ,@STOCKGOODSTTLTAXEXC" + Environment.NewLine;
                    sqlText += " ,@PUREGOODSTTLTAXEXC" + Environment.NewLine;
                    sqlText += " ,@LISTPRICEPRINTDIV" + Environment.NewLine;
                    //-------ADD BY 凌小青 on 2011/12/15 for Redmine#27313------->>>>>>>>>
                    sqlText += " ,@CUSTSLIPNO" + Environment.NewLine;
                    //-------ADD BY 凌小青 on 2011/12/15 for Redmine#27313-------<<<<<<<<<
                    sqlText += " ,@ERANAMEDISPCD1)" + Environment.NewLine;
                    # endregion

                    sqlCommand.CommandText = sqlText;

                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)saleshistoryWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);

                    //＠売上履歴データ変更＠
                    #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                    SqlParameter paraDebitNLnkSalesSlNum = sqlCommand.Parameters.Add("@DEBITNLNKSALESSLNUM", SqlDbType.NChar);
                    SqlParameter paraSalesSlipCd = sqlCommand.Parameters.Add("@SALESSLIPCD", SqlDbType.Int);
                    SqlParameter paraSalesGoodsCd = sqlCommand.Parameters.Add("@SALESGOODSCD", SqlDbType.Int);
                    SqlParameter paraAccRecDivCd = sqlCommand.Parameters.Add("@ACCRECDIVCD", SqlDbType.Int);
                    SqlParameter paraSalesInpSecCd = sqlCommand.Parameters.Add("@SALESINPSECCD", SqlDbType.NChar);
                    SqlParameter paraDemandAddUpSecCd = sqlCommand.Parameters.Add("@DEMANDADDUPSECCD", SqlDbType.NChar);
                    SqlParameter paraResultsAddUpSecCd = sqlCommand.Parameters.Add("@RESULTSADDUPSECCD", SqlDbType.NChar);
                    SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                    SqlParameter paraSalesSlipUpdateCd = sqlCommand.Parameters.Add("@SALESSLIPUPDATECD", SqlDbType.Int);
                    SqlParameter paraSearchSlipDate = sqlCommand.Parameters.Add("@SEARCHSLIPDATE", SqlDbType.Int);
                    SqlParameter paraShipmentDay = sqlCommand.Parameters.Add("@SHIPMENTDAY", SqlDbType.Int);
                    SqlParameter paraSalesDate = sqlCommand.Parameters.Add("@SALESDATE", SqlDbType.Int);
                    SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                    SqlParameter paraDelayPaymentDiv = sqlCommand.Parameters.Add("@DELAYPAYMENTDIV", SqlDbType.Int);
                    SqlParameter paraInputAgenCd = sqlCommand.Parameters.Add("@INPUTAGENCD", SqlDbType.NVarChar);
                    SqlParameter paraInputAgenNm = sqlCommand.Parameters.Add("@INPUTAGENNM", SqlDbType.NVarChar);
                    SqlParameter paraSalesInputCode = sqlCommand.Parameters.Add("@SALESINPUTCODE", SqlDbType.NChar);
                    SqlParameter paraSalesInputName = sqlCommand.Parameters.Add("@SALESINPUTNAME", SqlDbType.NVarChar);
                    SqlParameter paraFrontEmployeeCd = sqlCommand.Parameters.Add("@FRONTEMPLOYEECD", SqlDbType.NChar);
                    SqlParameter paraFrontEmployeeNm = sqlCommand.Parameters.Add("@FRONTEMPLOYEENM", SqlDbType.NVarChar);
                    SqlParameter paraSalesEmployeeCd = sqlCommand.Parameters.Add("@SALESEMPLOYEECD", SqlDbType.NChar);
                    SqlParameter paraSalesEmployeeNm = sqlCommand.Parameters.Add("@SALESEMPLOYEENM", SqlDbType.NVarChar);
                    SqlParameter paraTotalAmountDispWayCd = sqlCommand.Parameters.Add("@TOTALAMOUNTDISPWAYCD", SqlDbType.Int);
                    SqlParameter paraTtlAmntDispRateApy = sqlCommand.Parameters.Add("@TTLAMNTDISPRATEAPY", SqlDbType.Int);
                    SqlParameter paraSalesTotalTaxInc = sqlCommand.Parameters.Add("@SALESTOTALTAXINC", SqlDbType.BigInt);
                    SqlParameter paraSalesTotalTaxExc = sqlCommand.Parameters.Add("@SALESTOTALTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraSalesPrtTotalTaxInc = sqlCommand.Parameters.Add("@SALESPRTTOTALTAXINC", SqlDbType.BigInt);
                    SqlParameter paraSalesPrtTotalTaxExc = sqlCommand.Parameters.Add("@SALESPRTTOTALTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraSalesWorkTotalTaxInc = sqlCommand.Parameters.Add("@SALESWORKTOTALTAXINC", SqlDbType.BigInt);
                    SqlParameter paraSalesWorkTotalTaxExc = sqlCommand.Parameters.Add("@SALESWORKTOTALTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraSalesSubtotalTaxInc = sqlCommand.Parameters.Add("@SALESSUBTOTALTAXINC", SqlDbType.BigInt);
                    SqlParameter paraSalesSubtotalTaxExc = sqlCommand.Parameters.Add("@SALESSUBTOTALTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraSalesPrtSubttlInc = sqlCommand.Parameters.Add("@SALESPRTSUBTTLINC", SqlDbType.BigInt);
                    SqlParameter paraSalesPrtSubttlExc = sqlCommand.Parameters.Add("@SALESPRTSUBTTLEXC", SqlDbType.BigInt);
                    SqlParameter paraSalesWorkSubttlInc = sqlCommand.Parameters.Add("@SALESWORKSUBTTLINC", SqlDbType.BigInt);
                    SqlParameter paraSalesWorkSubttlExc = sqlCommand.Parameters.Add("@SALESWORKSUBTTLEXC", SqlDbType.BigInt);
                    SqlParameter paraSalesNetPrice = sqlCommand.Parameters.Add("@SALESNETPRICE", SqlDbType.BigInt);
                    SqlParameter paraSalesSubtotalTax = sqlCommand.Parameters.Add("@SALESSUBTOTALTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesOutTax = sqlCommand.Parameters.Add("@ITDEDSALESOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesInTax = sqlCommand.Parameters.Add("@ITDEDSALESINTAX", SqlDbType.BigInt);
                    SqlParameter paraSalSubttlSubToTaxFre = sqlCommand.Parameters.Add("@SALSUBTTLSUBTOTAXFRE", SqlDbType.BigInt);
                    SqlParameter paraSalesOutTax = sqlCommand.Parameters.Add("@SALESOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraSalAmntConsTaxInclu = sqlCommand.Parameters.Add("@SALAMNTCONSTAXINCLU", SqlDbType.BigInt);
                    SqlParameter paraSalesDisTtlTaxExc = sqlCommand.Parameters.Add("@SALESDISTTLTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesDisOutTax = sqlCommand.Parameters.Add("@ITDEDSALESDISOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesDisInTax = sqlCommand.Parameters.Add("@ITDEDSALESDISINTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedPartsDisOutTax = sqlCommand.Parameters.Add("@ITDEDPARTSDISOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedPartsDisInTax = sqlCommand.Parameters.Add("@ITDEDPARTSDISINTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedWorkDisOutTax = sqlCommand.Parameters.Add("@ITDEDWORKDISOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedWorkDisInTax = sqlCommand.Parameters.Add("@ITDEDWORKDISINTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesDisTaxFre = sqlCommand.Parameters.Add("@ITDEDSALESDISTAXFRE", SqlDbType.BigInt);
                    SqlParameter paraSalesDisOutTax = sqlCommand.Parameters.Add("@SALESDISOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraSalesDisTtlTaxInclu = sqlCommand.Parameters.Add("@SALESDISTTLTAXINCLU", SqlDbType.BigInt);
                    SqlParameter paraPartsDiscountRate = sqlCommand.Parameters.Add("@PARTSDISCOUNTRATE", SqlDbType.Float);
                    SqlParameter paraRavorDiscountRate = sqlCommand.Parameters.Add("@RAVORDISCOUNTRATE", SqlDbType.Float);
                    SqlParameter paraTotalCost = sqlCommand.Parameters.Add("@TOTALCOST", SqlDbType.BigInt);
                    SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                    SqlParameter paraConsTaxRate = sqlCommand.Parameters.Add("@CONSTAXRATE", SqlDbType.Float);
                    SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                    SqlParameter paraAccRecConsTax = sqlCommand.Parameters.Add("@ACCRECCONSTAX", SqlDbType.BigInt);
                    SqlParameter paraAutoDepositCd = sqlCommand.Parameters.Add("@AUTODEPOSITCD", SqlDbType.Int);
                    SqlParameter paraAutoDepositSlipNo = sqlCommand.Parameters.Add("@AUTODEPOSITSLIPNO", SqlDbType.Int);
                    SqlParameter paraDepositAllowanceTtl = sqlCommand.Parameters.Add("@DEPOSITALLOWANCETTL", SqlDbType.BigInt);
                    SqlParameter paraDepositAlwcBlnce = sqlCommand.Parameters.Add("@DEPOSITALWCBLNCE", SqlDbType.BigInt);
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                    SqlParameter paraClaimSnm = sqlCommand.Parameters.Add("@CLAIMSNM", SqlDbType.NVarChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                    SqlParameter paraHonorificTitle = sqlCommand.Parameters.Add("@HONORIFICTITLE", SqlDbType.NVarChar);
                    SqlParameter paraOutputNameCode = sqlCommand.Parameters.Add("@OUTPUTNAMECODE", SqlDbType.Int);
                    SqlParameter paraOutputName = sqlCommand.Parameters.Add("@OUTPUTNAME", SqlDbType.NVarChar);
                    SqlParameter paraSlipAddressDiv = sqlCommand.Parameters.Add("@SLIPADDRESSDIV", SqlDbType.Int);
                    SqlParameter paraAddresseeCode = sqlCommand.Parameters.Add("@ADDRESSEECODE", SqlDbType.Int);
                    SqlParameter paraAddresseeName = sqlCommand.Parameters.Add("@ADDRESSEENAME", SqlDbType.NVarChar);
                    SqlParameter paraAddresseeName2 = sqlCommand.Parameters.Add("@ADDRESSEENAME2", SqlDbType.NVarChar);
                    SqlParameter paraAddresseePostNo = sqlCommand.Parameters.Add("@ADDRESSEEPOSTNO", SqlDbType.NVarChar);
                    SqlParameter paraAddresseeAddr1 = sqlCommand.Parameters.Add("@ADDRESSEEADDR1", SqlDbType.NVarChar);
                    SqlParameter paraAddresseeAddr3 = sqlCommand.Parameters.Add("@ADDRESSEEADDR3", SqlDbType.NVarChar);
                    SqlParameter paraAddresseeAddr4 = sqlCommand.Parameters.Add("@ADDRESSEEADDR4", SqlDbType.NVarChar);
                    SqlParameter paraAddresseeTelNo = sqlCommand.Parameters.Add("@ADDRESSEETELNO", SqlDbType.NVarChar);
                    SqlParameter paraAddresseeFaxNo = sqlCommand.Parameters.Add("@ADDRESSEEFAXNO", SqlDbType.NVarChar);
                    SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@PARTYSALESLIPNUM", SqlDbType.NVarChar);
                    SqlParameter paraSlipNote = sqlCommand.Parameters.Add("@SLIPNOTE", SqlDbType.NVarChar);
                    SqlParameter paraSlipNote2 = sqlCommand.Parameters.Add("@SLIPNOTE2", SqlDbType.NVarChar);
                    SqlParameter paraSlipNote3 = sqlCommand.Parameters.Add("@SLIPNOTE3", SqlDbType.NVarChar);
                    SqlParameter paraRetGoodsReasonDiv = sqlCommand.Parameters.Add("@RETGOODSREASONDIV", SqlDbType.Int);
                    SqlParameter paraRetGoodsReason = sqlCommand.Parameters.Add("@RETGOODSREASON", SqlDbType.NVarChar);
                    SqlParameter paraDetailRowCount = sqlCommand.Parameters.Add("@DETAILROWCOUNT", SqlDbType.Int);
                    SqlParameter paraEdiSendDate = sqlCommand.Parameters.Add("@EDISENDDATE", SqlDbType.Int);
                    SqlParameter paraEdiTakeInDate = sqlCommand.Parameters.Add("@EDITAKEINDATE", SqlDbType.Int);
                    SqlParameter paraUoeRemark1 = sqlCommand.Parameters.Add("@UOEREMARK1", SqlDbType.NVarChar);
                    SqlParameter paraUoeRemark2 = sqlCommand.Parameters.Add("@UOEREMARK2", SqlDbType.NVarChar);
                    SqlParameter paraSlipPrintDivCd = sqlCommand.Parameters.Add("@SLIPPRINTDIVCD", SqlDbType.Int);
                    SqlParameter paraSlipPrintFinishCd = sqlCommand.Parameters.Add("@SLIPPRINTFINISHCD", SqlDbType.Int);
                    SqlParameter paraSalesSlipPrintDate = sqlCommand.Parameters.Add("@SALESSLIPPRINTDATE", SqlDbType.Int);
                    SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                    SqlParameter paraBusinessTypeName = sqlCommand.Parameters.Add("@BUSINESSTYPENAME", SqlDbType.NVarChar);
                    SqlParameter paraDeliveredGoodsDiv = sqlCommand.Parameters.Add("@DELIVEREDGOODSDIV", SqlDbType.Int);
                    SqlParameter paraDeliveredGoodsDivNm = sqlCommand.Parameters.Add("@DELIVEREDGOODSDIVNM", SqlDbType.NVarChar);
                    SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                    SqlParameter paraSalesAreaName = sqlCommand.Parameters.Add("@SALESAREANAME", SqlDbType.NVarChar);
                    SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);
                    SqlParameter paraCompleteCd = sqlCommand.Parameters.Add("@COMPLETECD", SqlDbType.Int);
                    SqlParameter paraSalesPriceFracProcCd = sqlCommand.Parameters.Add("@SALESPRICEFRACPROCCD", SqlDbType.Int);
                    SqlParameter paraStockGoodsTtlTaxExc = sqlCommand.Parameters.Add("@STOCKGOODSTTLTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraPureGoodsTtlTaxExc = sqlCommand.Parameters.Add("@PUREGOODSTTLTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraListPricePrintDiv = sqlCommand.Parameters.Add("@LISTPRICEPRINTDIV", SqlDbType.Int);
                    SqlParameter paraEraNameDispCd1 = sqlCommand.Parameters.Add("@ERANAMEDISPCD1", SqlDbType.Int);
                    //-------ADD BY 凌小青 on 2011/12/15 for Redmine#27313------->>>>>>>>>
                    SqlParameter paraCustSlipNo = sqlCommand.Parameters.Add("@CUSTSLIPNO", SqlDbType.Int);
                    //-------ADD BY 凌小青 on 2011/12/15 for Redmine#27313-------<<<<<<<<<
                    #endregion

                    //＠売上履歴データ変更＠
                    #region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(saleshistoryWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(saleshistoryWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(saleshistoryWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(saleshistoryWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(saleshistoryWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(saleshistoryWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(saleshistoryWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.LogicalDeleteCode);
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SalesSlipNum);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SectionCode);
                    paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.SubSectionCode);
                    paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.DebitNoteDiv);
                    paraDebitNLnkSalesSlNum.Value = SqlDataMediator.SqlSetString(saleshistoryWork.DebitNLnkSalesSlNum);
                    paraSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.SalesSlipCd);
                    paraSalesGoodsCd.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.SalesGoodsCd);
                    paraAccRecDivCd.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.AccRecDivCd);
                    paraSalesInpSecCd.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SalesInpSecCd);
                    paraDemandAddUpSecCd.Value = SqlDataMediator.SqlSetString(saleshistoryWork.DemandAddUpSecCd);
                    paraResultsAddUpSecCd.Value = SqlDataMediator.SqlSetString(saleshistoryWork.ResultsAddUpSecCd);
                    paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(saleshistoryWork.UpdateSecCd);
                    paraSalesSlipUpdateCd.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.SalesSlipUpdateCd);
                    paraSearchSlipDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(saleshistoryWork.SearchSlipDate);
                    paraShipmentDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(saleshistoryWork.ShipmentDay);
                    paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(saleshistoryWork.SalesDate);
                    paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(saleshistoryWork.AddUpADate);
                    paraDelayPaymentDiv.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.DelayPaymentDiv);
                    paraInputAgenCd.Value = SqlDataMediator.SqlSetString(saleshistoryWork.InputAgenCd);
                    paraInputAgenNm.Value = SqlDataMediator.SqlSetString(saleshistoryWork.InputAgenNm);
                    paraSalesInputCode.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SalesInputCode);
                    paraSalesInputName.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SalesInputName);
                    paraFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(saleshistoryWork.FrontEmployeeCd);
                    paraFrontEmployeeNm.Value = SqlDataMediator.SqlSetString(saleshistoryWork.FrontEmployeeNm);
                    paraSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SalesEmployeeCd);
                    paraSalesEmployeeNm.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SalesEmployeeNm);
                    paraTotalAmountDispWayCd.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.TotalAmountDispWayCd);
                    paraTtlAmntDispRateApy.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.TtlAmntDispRateApy);
                    paraSalesTotalTaxInc.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalesTotalTaxInc);
                    paraSalesTotalTaxExc.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalesTotalTaxExc);
                    paraSalesPrtTotalTaxInc.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalesPrtTotalTaxInc);
                    paraSalesPrtTotalTaxExc.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalesPrtTotalTaxExc);
                    paraSalesWorkTotalTaxInc.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalesWorkTotalTaxInc);
                    paraSalesWorkTotalTaxExc.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalesWorkTotalTaxExc);
                    paraSalesSubtotalTaxInc.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalesSubtotalTaxInc);
                    paraSalesSubtotalTaxExc.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalesSubtotalTaxExc);
                    paraSalesPrtSubttlInc.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalesPrtSubttlInc);
                    paraSalesPrtSubttlExc.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalesPrtSubttlExc);
                    paraSalesWorkSubttlInc.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalesWorkSubttlInc);
                    paraSalesWorkSubttlExc.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalesWorkSubttlExc);
                    paraSalesNetPrice.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalesNetPrice);
                    paraSalesSubtotalTax.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalesSubtotalTax);
                    paraItdedSalesOutTax.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.ItdedSalesOutTax);
                    paraItdedSalesInTax.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.ItdedSalesInTax);
                    paraSalSubttlSubToTaxFre.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalSubttlSubToTaxFre);
                    paraSalesOutTax.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalesOutTax);
                    paraSalAmntConsTaxInclu.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalAmntConsTaxInclu);
                    paraSalesDisTtlTaxExc.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalesDisTtlTaxExc);
                    paraItdedSalesDisOutTax.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.ItdedSalesDisOutTax);
                    paraItdedSalesDisInTax.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.ItdedSalesDisInTax);
                    paraItdedPartsDisOutTax.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.ItdedPartsDisOutTax);
                    paraItdedPartsDisInTax.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.ItdedPartsDisInTax);
                    paraItdedWorkDisOutTax.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.ItdedWorkDisOutTax);
                    paraItdedWorkDisInTax.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.ItdedWorkDisInTax);
                    paraItdedSalesDisTaxFre.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.ItdedSalesDisTaxFre);
                    paraSalesDisOutTax.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalesDisOutTax);
                    paraSalesDisTtlTaxInclu.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.SalesDisTtlTaxInclu);
                    paraPartsDiscountRate.Value = SqlDataMediator.SqlSetDouble(saleshistoryWork.PartsDiscountRate);
                    paraRavorDiscountRate.Value = SqlDataMediator.SqlSetDouble(saleshistoryWork.RavorDiscountRate);
                    paraTotalCost.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.TotalCost);
                    paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.ConsTaxLayMethod);
                    paraConsTaxRate.Value = SqlDataMediator.SqlSetDouble(saleshistoryWork.ConsTaxRate);
                    paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.FractionProcCd);
                    paraAccRecConsTax.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.AccRecConsTax);
                    paraAutoDepositCd.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.AutoDepositCd);
                    paraAutoDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.AutoDepositSlipNo);
                    paraDepositAllowanceTtl.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.DepositAllowanceTtl);
                    paraDepositAlwcBlnce.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.DepositAlwcBlnce);
                    paraClaimCode.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.ClaimCode);
                    paraClaimSnm.Value = SqlDataMediator.SqlSetString(saleshistoryWork.ClaimSnm);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.CustomerCode);
                    paraCustomerName.Value = SqlDataMediator.SqlSetString(saleshistoryWork.CustomerName);
                    paraCustomerName2.Value = SqlDataMediator.SqlSetString(saleshistoryWork.CustomerName2);
                    paraCustomerSnm.Value = SqlDataMediator.SqlSetString(saleshistoryWork.CustomerSnm);
                    paraHonorificTitle.Value = SqlDataMediator.SqlSetString(saleshistoryWork.HonorificTitle);
                    paraOutputNameCode.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.OutputNameCode);
                    paraOutputName.Value = SqlDataMediator.SqlSetString(saleshistoryWork.OutputName);
                    paraSlipAddressDiv.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.SlipAddressDiv);
                    paraAddresseeCode.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.AddresseeCode);
                    paraAddresseeName.Value = SqlDataMediator.SqlSetString(saleshistoryWork.AddresseeName);
                    paraAddresseeName2.Value = SqlDataMediator.SqlSetString(saleshistoryWork.AddresseeName2);
                    paraAddresseePostNo.Value = SqlDataMediator.SqlSetString(saleshistoryWork.AddresseePostNo);
                    paraAddresseeAddr1.Value = SqlDataMediator.SqlSetString(saleshistoryWork.AddresseeAddr1);
                    paraAddresseeAddr3.Value = SqlDataMediator.SqlSetString(saleshistoryWork.AddresseeAddr3);
                    paraAddresseeAddr4.Value = SqlDataMediator.SqlSetString(saleshistoryWork.AddresseeAddr4);
                    paraAddresseeTelNo.Value = SqlDataMediator.SqlSetString(saleshistoryWork.AddresseeTelNo);
                    paraAddresseeFaxNo.Value = SqlDataMediator.SqlSetString(saleshistoryWork.AddresseeFaxNo);
                    paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(saleshistoryWork.PartySaleSlipNum);
                    paraSlipNote.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SlipNote);
                    paraSlipNote2.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SlipNote2);
                    paraSlipNote3.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SlipNote3);
                    paraRetGoodsReasonDiv.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.RetGoodsReasonDiv);
                    paraRetGoodsReason.Value = SqlDataMediator.SqlSetString(saleshistoryWork.RetGoodsReason);
                    paraDetailRowCount.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.DetailRowCount);
                    paraEdiSendDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(saleshistoryWork.EdiSendDate);
                    paraEdiTakeInDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(saleshistoryWork.EdiTakeInDate);
                    paraUoeRemark1.Value = SqlDataMediator.SqlSetString(saleshistoryWork.UoeRemark1);
                    paraUoeRemark2.Value = SqlDataMediator.SqlSetString(saleshistoryWork.UoeRemark2);
                    paraSlipPrintDivCd.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.SlipPrintDivCd);
                    paraSlipPrintFinishCd.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.SlipPrintFinishCd);
                    paraSalesSlipPrintDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(saleshistoryWork.SalesSlipPrintDate);
                    paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.BusinessTypeCode);
                    paraBusinessTypeName.Value = SqlDataMediator.SqlSetString(saleshistoryWork.BusinessTypeName);
                    paraDeliveredGoodsDiv.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.DeliveredGoodsDiv);
                    paraDeliveredGoodsDivNm.Value = SqlDataMediator.SqlSetString(saleshistoryWork.DeliveredGoodsDivNm);
                    paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.SalesAreaCode);
                    paraSalesAreaName.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SalesAreaName);
                    paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SlipPrtSetPaperId);
                    paraCompleteCd.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.CompleteCd);
                    paraSalesPriceFracProcCd.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.SalesPriceFracProcCd);
                    paraStockGoodsTtlTaxExc.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.StockGoodsTtlTaxExc);
                    paraPureGoodsTtlTaxExc.Value = SqlDataMediator.SqlSetInt64(saleshistoryWork.PureGoodsTtlTaxExc);
                    paraListPricePrintDiv.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.ListPricePrintDiv);
                    paraEraNameDispCd1.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.EraNameDispCd1);
                    //-------ADD BY 凌小青 on 2011/12/15 for Redmine#27313------->>>>>>>>>
                    paraCustSlipNo.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.CustSlipNo);
                    //-------ADD BY 凌小青 on 2011/12/15 for Redmine#27313-------<<<<<<<<<
                    #endregion

                    sqlCommand.ExecuteNonQuery();

                    # endregion
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 売上明細履歴データを登録(追加・更新)します。
        /// </summary>
        /// <param name="saleshistdtlWorkList">登録対象となる SalesHistDtlWork が格納されている ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int WriteSalesHistDtlWork(ref ArrayList saleshistdtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteSalesHistDtlWorkProc(ref saleshistdtlWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 売上明細履歴データを登録(追加・更新)します。
        /// </summary>
        /// <param name="saleshistdtlWorkList">登録対象となる SalesHistDtlWork が格納されている ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        private int WriteSalesHistDtlWorkProc(ref ArrayList saleshistdtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (saleshistdtlWorkList != null && saleshistdtlWorkList.Count > 0 && saleshistdtlWorkList[0] is SalesHistDtlWork)
                {
                    // 売上伝票番号(＋α)を条件としてデータの有無にかかわらず複数明細行の削除を行う
                    # region [DELETE]
                    string sqlText = "";
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SALESHISTDTLRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Parameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                    // Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString((saleshistdtlWorkList[0] as SalesHistDtlWork).EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32((saleshistdtlWorkList[0] as SalesHistDtlWork).AcptAnOdrStatus);
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString((saleshistdtlWorkList[0] as SalesHistDtlWork).SalesSlipNum);

                    sqlCommand.ExecuteNonQuery();
                    # endregion

                    # region [INSERT]

                    //＠売上履歴明細データ変更＠
                    //新規作成時のSQL文を生成
                    # region [INSERT文]
                    //--- ADD 2008/09/12 M.Kubota --->>>
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO SALESHISTDTLRF (" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ACCEPTANORDERNORF" + Environment.NewLine;
                    sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += " ,SALESROWNORF" + Environment.NewLine;
                    sqlText += " ,SALESROWDERIVNORF" + Environment.NewLine;
                    sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,SUBSECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,SALESDATERF" + Environment.NewLine;
                    sqlText += " ,COMMONSEQNORF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += " ,ACPTANODRSTATUSSRCRF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPDTLNUMSRCRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERFORMALSYNCRF" + Environment.NewLine;
                    sqlText += " ,STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPCDDTLRF" + Environment.NewLine;
                    sqlText += " ,GOODSKINDCODERF" + Environment.NewLine;
                    sqlText += " ,GOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += " ,MAKERNAMERF" + Environment.NewLine;
                    sqlText += " ,MAKERKANANAMERF" + Environment.NewLine;
                    sqlText += " ,CMPLTMAKERKANANAMERF" + Environment.NewLine;
                    sqlText += " ,GOODSNORF" + Environment.NewLine;
                    sqlText += " ,GOODSNAMERF" + Environment.NewLine;
                    sqlText += " ,GOODSNAMEKANARF" + Environment.NewLine;
                    sqlText += " ,GOODSLGROUPRF" + Environment.NewLine;
                    sqlText += " ,GOODSLGROUPNAMERF" + Environment.NewLine;
                    sqlText += " ,GOODSMGROUPRF" + Environment.NewLine;
                    sqlText += " ,GOODSMGROUPNAMERF" + Environment.NewLine;
                    sqlText += " ,BLGROUPCODERF" + Environment.NewLine;
                    sqlText += " ,BLGROUPNAMERF" + Environment.NewLine;
                    sqlText += " ,BLGOODSCODERF" + Environment.NewLine;
                    sqlText += " ,BLGOODSFULLNAMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISEGANRECODERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISEGANRENAMERF" + Environment.NewLine;
                    sqlText += " ,WAREHOUSECODERF" + Environment.NewLine;
                    sqlText += " ,WAREHOUSENAMERF" + Environment.NewLine;
                    sqlText += " ,WAREHOUSESHELFNORF" + Environment.NewLine;
                    sqlText += " ,SALESORDERDIVCDRF" + Environment.NewLine;
                    sqlText += " ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlText += " ,GOODSRATERANKRF" + Environment.NewLine;
                    sqlText += " ,CUSTRATEGRPCODERF" + Environment.NewLine;
                    sqlText += " ,LISTPRICERATERF" + Environment.NewLine;
                    sqlText += " ,RATESECTPRICEUNPRCRF" + Environment.NewLine;
                    sqlText += " ,RATEDIVLPRICERF" + Environment.NewLine;
                    sqlText += " ,UNPRCCALCCDLPRICERF" + Environment.NewLine;
                    sqlText += " ,PRICECDLPRICERF" + Environment.NewLine;
                    sqlText += " ,STDUNPRCLPRICERF" + Environment.NewLine;
                    sqlText += " ,FRACPROCUNITLPRICERF" + Environment.NewLine;
                    sqlText += " ,FRACPROCLPRICERF" + Environment.NewLine;
                    sqlText += " ,LISTPRICETAXINCFLRF" + Environment.NewLine;
                    sqlText += " ,LISTPRICETAXEXCFLRF" + Environment.NewLine;
                    sqlText += " ,LISTPRICECHNGCDRF" + Environment.NewLine;
                    sqlText += " ,SALESRATERF" + Environment.NewLine;
                    sqlText += " ,RATESECTSALUNPRCRF" + Environment.NewLine;
                    sqlText += " ,RATEDIVSALUNPRCRF" + Environment.NewLine;
                    sqlText += " ,UNPRCCALCCDSALUNPRCRF" + Environment.NewLine;
                    sqlText += " ,PRICECDSALUNPRCRF" + Environment.NewLine;
                    sqlText += " ,STDUNPRCSALUNPRCRF" + Environment.NewLine;
                    sqlText += " ,FRACPROCUNITSALUNPRCRF" + Environment.NewLine;
                    sqlText += " ,FRACPROCSALUNPRCRF" + Environment.NewLine;
                    sqlText += " ,SALESUNPRCTAXINCFLRF" + Environment.NewLine;
                    sqlText += " ,SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                    sqlText += " ,SALESUNPRCCHNGCDRF" + Environment.NewLine;
                    sqlText += " ,COSTRATERF" + Environment.NewLine;
                    sqlText += " ,RATESECTCSTUNPRCRF" + Environment.NewLine;
                    sqlText += " ,RATEDIVUNCSTRF" + Environment.NewLine;
                    sqlText += " ,UNPRCCALCCDUNCSTRF" + Environment.NewLine;
                    sqlText += " ,PRICECDUNCSTRF" + Environment.NewLine;
                    sqlText += " ,STDUNPRCUNCSTRF" + Environment.NewLine;
                    sqlText += " ,FRACPROCUNITUNCSTRF" + Environment.NewLine;
                    sqlText += " ,FRACPROCUNCSTRF" + Environment.NewLine;
                    sqlText += " ,SALESUNITCOSTRF" + Environment.NewLine;
                    sqlText += " ,SALESUNITCOSTCHNGDIVRF" + Environment.NewLine;
                    sqlText += " ,RATEBLGOODSCODERF" + Environment.NewLine;
                    sqlText += " ,RATEBLGOODSNAMERF" + Environment.NewLine;
                    sqlText += " ,RATEGOODSRATEGRPCDRF" + Environment.NewLine;
                    sqlText += " ,RATEGOODSRATEGRPNMRF" + Environment.NewLine;
                    sqlText += " ,RATEBLGROUPCODERF" + Environment.NewLine;
                    sqlText += " ,RATEBLGROUPNAMERF" + Environment.NewLine;
                    sqlText += " ,PRTBLGOODSCODERF" + Environment.NewLine;
                    sqlText += " ,PRTBLGOODSNAMERF" + Environment.NewLine;
                    sqlText += " ,SALESCODERF" + Environment.NewLine;
                    sqlText += " ,SALESCDNMRF" + Environment.NewLine;
                    sqlText += " ,WORKMANHOURRF" + Environment.NewLine;
                    sqlText += " ,SHIPMENTCNTRF" + Environment.NewLine;
                    sqlText += " ,SALESMONEYTAXINCRF" + Environment.NewLine;
                    sqlText += " ,SALESMONEYTAXEXCRF" + Environment.NewLine;
                    sqlText += " ,COSTRF" + Environment.NewLine;
                    sqlText += " ,GRSPROFITCHKDIVRF" + Environment.NewLine;
                    sqlText += " ,SALESGOODSCDRF" + Environment.NewLine;
                    sqlText += " ,SALESPRICECONSTAXRF" + Environment.NewLine;
                    sqlText += " ,TAXATIONDIVCDRF" + Environment.NewLine;
                    sqlText += " ,PARTYSLIPNUMDTLRF" + Environment.NewLine;
                    sqlText += " ,DTLNOTERF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += " ,ORDERNUMBERRF" + Environment.NewLine;
                    sqlText += " ,WAYTOORDERRF" + Environment.NewLine;
                    sqlText += " ,SLIPMEMO1RF" + Environment.NewLine;
                    sqlText += " ,SLIPMEMO2RF" + Environment.NewLine;
                    sqlText += " ,SLIPMEMO3RF" + Environment.NewLine;
                    sqlText += " ,INSIDEMEMO1RF" + Environment.NewLine;
                    sqlText += " ,INSIDEMEMO2RF" + Environment.NewLine;
                    sqlText += " ,INSIDEMEMO3RF" + Environment.NewLine;
                    sqlText += " ,BFLISTPRICERF" + Environment.NewLine;
                    sqlText += " ,BFSALESUNITPRICERF" + Environment.NewLine;
                    sqlText += " ,BFUNITCOSTRF" + Environment.NewLine;
                    sqlText += " ,CMPLTSALESROWNORF" + Environment.NewLine;
                    sqlText += " ,CMPLTGOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += " ,CMPLTMAKERNAMERF" + Environment.NewLine;
                    sqlText += " ,CMPLTGOODSNAMERF" + Environment.NewLine;
                    sqlText += " ,CMPLTSHIPMENTCNTRF" + Environment.NewLine;
                    sqlText += " ,CMPLTSALESUNPRCFLRF" + Environment.NewLine;
                    sqlText += " ,CMPLTSALESMONEYRF" + Environment.NewLine;
                    sqlText += " ,CMPLTSALESUNITCOSTRF" + Environment.NewLine;
                    sqlText += " ,CMPLTCOSTRF" + Environment.NewLine;
                    sqlText += " ,CMPLTPARTYSALSLNUMRF" + Environment.NewLine;
                    sqlText += " ,CMPLTNOTERF" + Environment.NewLine;
                    sqlText += " ,PRTGOODSNORF" + Environment.NewLine;
                    sqlText += " ,PRTMAKERCODERF" + Environment.NewLine;
                    sqlText += " ,PRTMAKERNAMERF" + Environment.NewLine;
                    // 2009/05/18 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    sqlText += " ,CAMPAIGNCODERF" + Environment.NewLine;
                    sqlText += " ,CAMPAIGNNAMERF" + Environment.NewLine;
                    sqlText += " ,GOODSDIVCDRF" + Environment.NewLine;
                    sqlText += " ,ANSWERDELIVDATERF" + Environment.NewLine;
                    sqlText += " ,RECYCLEDIVRF" + Environment.NewLine;
                    sqlText += " ,RECYCLEDIVNMRF" + Environment.NewLine;
                    sqlText += " ,WAYTOACPTODRRF" + Environment.NewLine;
                    // 2009/05/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlText += " ,AUTOANSWERDIVSCMRF" + Environment.NewLine; // Add 2011/07/23 duzg for 自動回答区分(SCM)追加
                    // -- ADD 2011/08/10   ------ >>>>>>
                    sqlText += " ,ACCEPTORORDERKINDRF" + Environment.NewLine;
                    sqlText += " ,INQUIRYNUMBERRF" + Environment.NewLine;
                    sqlText += " ,INQROWNUMBERRF" + Environment.NewLine;
                    // -- ADD 2011/08/10   ------ <<<<<<
                    // -- ADD 2012/01/23   ------ >>>>>>
                    sqlText += " ,GOODSSPECIALNOTERF" + Environment.NewLine;
                    // -- ADD 2012/01/23   ------ <<<<<<
                    //2012/05/07 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    sqlText += " ,RENTSYNCSUPPLIERRF" + Environment.NewLine;
                    sqlText += " ,RENTSYNCSTOCKDATERF" + Environment.NewLine;
                    sqlText += " ,RENTSYNCSUPSLIPNORF" + Environment.NewLine;
                    //2012/05/07 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlText += " )" + Environment.NewLine;
                    sqlText += "VALUES" + Environment.NewLine;
                    sqlText += "  (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,@ACCEPTANORDERNO" + Environment.NewLine;
                    sqlText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPNUM" + Environment.NewLine;
                    sqlText += " ,@SALESROWNO" + Environment.NewLine;
                    sqlText += " ,@SALESROWDERIVNO" + Environment.NewLine;
                    sqlText += " ,@SECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@SUBSECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@SALESDATE" + Environment.NewLine;
                    sqlText += " ,@COMMONSEQNO" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPDTLNUM" + Environment.NewLine;
                    sqlText += " ,@ACPTANODRSTATUSSRC" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPDTLNUMSRC" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERFORMALSYNC" + Environment.NewLine;
                    sqlText += " ,@STOCKSLIPDTLNUMSYNC" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPCDDTL" + Environment.NewLine;
                    sqlText += " ,@GOODSKINDCODE" + Environment.NewLine;
                    sqlText += " ,@GOODSMAKERCD" + Environment.NewLine;
                    sqlText += " ,@MAKERNAME" + Environment.NewLine;
                    sqlText += " ,@MAKERKANANAME" + Environment.NewLine;
                    sqlText += " ,@CMPLTMAKERKANANAME" + Environment.NewLine;
                    sqlText += " ,@GOODSNO" + Environment.NewLine;
                    sqlText += " ,@GOODSNAME" + Environment.NewLine;
                    sqlText += " ,@GOODSNAMEKANA" + Environment.NewLine;
                    sqlText += " ,@GOODSLGROUP" + Environment.NewLine;
                    sqlText += " ,@GOODSLGROUPNAME" + Environment.NewLine;
                    sqlText += " ,@GOODSMGROUP" + Environment.NewLine;
                    sqlText += " ,@GOODSMGROUPNAME" + Environment.NewLine;
                    sqlText += " ,@BLGROUPCODE" + Environment.NewLine;
                    sqlText += " ,@BLGROUPNAME" + Environment.NewLine;
                    sqlText += " ,@BLGOODSCODE" + Environment.NewLine;
                    sqlText += " ,@BLGOODSFULLNAME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISEGANRECODE" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISEGANRENAME" + Environment.NewLine;
                    sqlText += " ,@WAREHOUSECODE" + Environment.NewLine;
                    sqlText += " ,@WAREHOUSENAME" + Environment.NewLine;
                    sqlText += " ,@WAREHOUSESHELFNO" + Environment.NewLine;
                    sqlText += " ,@SALESORDERDIVCD" + Environment.NewLine;
                    sqlText += " ,@OPENPRICEDIV" + Environment.NewLine;
                    sqlText += " ,@GOODSRATERANK" + Environment.NewLine;
                    sqlText += " ,@CUSTRATEGRPCODE" + Environment.NewLine;
                    sqlText += " ,@LISTPRICERATE" + Environment.NewLine;
                    sqlText += " ,@RATESECTPRICEUNPRC" + Environment.NewLine;
                    sqlText += " ,@RATEDIVLPRICE" + Environment.NewLine;
                    sqlText += " ,@UNPRCCALCCDLPRICE" + Environment.NewLine;
                    sqlText += " ,@PRICECDLPRICE" + Environment.NewLine;
                    sqlText += " ,@STDUNPRCLPRICE" + Environment.NewLine;
                    sqlText += " ,@FRACPROCUNITLPRICE" + Environment.NewLine;
                    sqlText += " ,@FRACPROCLPRICE" + Environment.NewLine;
                    sqlText += " ,@LISTPRICETAXINCFL" + Environment.NewLine;
                    sqlText += " ,@LISTPRICETAXEXCFL" + Environment.NewLine;
                    sqlText += " ,@LISTPRICECHNGCD" + Environment.NewLine;
                    sqlText += " ,@SALESRATE" + Environment.NewLine;
                    sqlText += " ,@RATESECTSALUNPRC" + Environment.NewLine;
                    sqlText += " ,@RATEDIVSALUNPRC" + Environment.NewLine;
                    sqlText += " ,@UNPRCCALCCDSALUNPRC" + Environment.NewLine;
                    sqlText += " ,@PRICECDSALUNPRC" + Environment.NewLine;
                    sqlText += " ,@STDUNPRCSALUNPRC" + Environment.NewLine;
                    sqlText += " ,@FRACPROCUNITSALUNPRC" + Environment.NewLine;
                    sqlText += " ,@FRACPROCSALUNPRC" + Environment.NewLine;
                    sqlText += " ,@SALESUNPRCTAXINCFL" + Environment.NewLine;
                    sqlText += " ,@SALESUNPRCTAXEXCFL" + Environment.NewLine;
                    sqlText += " ,@SALESUNPRCCHNGCD" + Environment.NewLine;
                    sqlText += " ,@COSTRATE" + Environment.NewLine;
                    sqlText += " ,@RATESECTCSTUNPRC" + Environment.NewLine;
                    sqlText += " ,@RATEDIVUNCST" + Environment.NewLine;
                    sqlText += " ,@UNPRCCALCCDUNCST" + Environment.NewLine;
                    sqlText += " ,@PRICECDUNCST" + Environment.NewLine;
                    sqlText += " ,@STDUNPRCUNCST" + Environment.NewLine;
                    sqlText += " ,@FRACPROCUNITUNCST" + Environment.NewLine;
                    sqlText += " ,@FRACPROCUNCST" + Environment.NewLine;
                    sqlText += " ,@SALESUNITCOST" + Environment.NewLine;
                    sqlText += " ,@SALESUNITCOSTCHNGDIV" + Environment.NewLine;
                    sqlText += " ,@RATEBLGOODSCODE" + Environment.NewLine;
                    sqlText += " ,@RATEBLGOODSNAME" + Environment.NewLine;
                    sqlText += " ,@RATEGOODSRATEGRPCD" + Environment.NewLine;
                    sqlText += " ,@RATEGOODSRATEGRPNM" + Environment.NewLine;
                    sqlText += " ,@RATEBLGROUPCODE" + Environment.NewLine;
                    sqlText += " ,@RATEBLGROUPNAME" + Environment.NewLine;
                    sqlText += " ,@PRTBLGOODSCODE" + Environment.NewLine;
                    sqlText += " ,@PRTBLGOODSNAME" + Environment.NewLine;
                    sqlText += " ,@SALESCODE" + Environment.NewLine;
                    sqlText += " ,@SALESCDNM" + Environment.NewLine;
                    sqlText += " ,@WORKMANHOUR" + Environment.NewLine;
                    sqlText += " ,@SHIPMENTCNT" + Environment.NewLine;
                    sqlText += " ,@SALESMONEYTAXINC" + Environment.NewLine;
                    sqlText += " ,@SALESMONEYTAXEXC" + Environment.NewLine;
                    sqlText += " ,@COST" + Environment.NewLine;
                    sqlText += " ,@GRSPROFITCHKDIV" + Environment.NewLine;
                    sqlText += " ,@SALESGOODSCD" + Environment.NewLine;
                    sqlText += " ,@SALESPRICECONSTAX" + Environment.NewLine;
                    sqlText += " ,@TAXATIONDIVCD" + Environment.NewLine;
                    sqlText += " ,@PARTYSLIPNUMDTL" + Environment.NewLine;
                    sqlText += " ,@DTLNOTE" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERCD" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSNM" + Environment.NewLine;
                    sqlText += " ,@ORDERNUMBER" + Environment.NewLine;
                    sqlText += " ,@WAYTOORDER" + Environment.NewLine;
                    sqlText += " ,@SLIPMEMO1" + Environment.NewLine;
                    sqlText += " ,@SLIPMEMO2" + Environment.NewLine;
                    sqlText += " ,@SLIPMEMO3" + Environment.NewLine;
                    sqlText += " ,@INSIDEMEMO1" + Environment.NewLine;
                    sqlText += " ,@INSIDEMEMO2" + Environment.NewLine;
                    sqlText += " ,@INSIDEMEMO3" + Environment.NewLine;
                    sqlText += " ,@BFLISTPRICE" + Environment.NewLine;
                    sqlText += " ,@BFSALESUNITPRICE" + Environment.NewLine;
                    sqlText += " ,@BFUNITCOST" + Environment.NewLine;
                    sqlText += " ,@CMPLTSALESROWNO" + Environment.NewLine;
                    sqlText += " ,@CMPLTGOODSMAKERCD" + Environment.NewLine;
                    sqlText += " ,@CMPLTMAKERNAME" + Environment.NewLine;
                    sqlText += " ,@CMPLTGOODSNAME" + Environment.NewLine;
                    sqlText += " ,@CMPLTSHIPMENTCNT" + Environment.NewLine;
                    sqlText += " ,@CMPLTSALESUNPRCFL" + Environment.NewLine;
                    sqlText += " ,@CMPLTSALESMONEY" + Environment.NewLine;
                    sqlText += " ,@CMPLTSALESUNITCOST" + Environment.NewLine;
                    sqlText += " ,@CMPLTCOST" + Environment.NewLine;
                    sqlText += " ,@CMPLTPARTYSALSLNUM" + Environment.NewLine;
                    sqlText += " ,@CMPLTNOTE" + Environment.NewLine;
                    sqlText += " ,@PRTGOODSNO" + Environment.NewLine;
                    sqlText += " ,@PRTMAKERCODE" + Environment.NewLine;
                    sqlText += " ,@PRTMAKERNAME" + Environment.NewLine;
                    // 2009/05/18 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    sqlText += " ,@CAMPAIGNCODE" + Environment.NewLine;
                    sqlText += " ,@CAMPAIGNNAME" + Environment.NewLine;
                    sqlText += " ,@GOODSDIVCD" + Environment.NewLine;
                    sqlText += " ,@ANSWERDELIVDATE" + Environment.NewLine;
                    sqlText += " ,@RECYCLEDIV" + Environment.NewLine;
                    sqlText += " ,@RECYCLEDIVNM" + Environment.NewLine;
                    sqlText += " ,@WAYTOACPTODR" + Environment.NewLine;
                    // 2009/05/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlText += " ,@AUTOANSWERDIVSCM" + Environment.NewLine;// Add 2011/07/23 duzg for 自動回答区分(SCM)追加
                    // -- ADD 2011/08/10   ------ >>>>>>
                    sqlText += " ,@ACCEPTORORDERKIND" + Environment.NewLine;
                    sqlText += " ,@INQUIRYNUMBER" + Environment.NewLine;
                    sqlText += " ,@INQROWNUMBER" + Environment.NewLine;
                    // -- ADD 2011/08/10   ------ <<<<<<
                    // -- ADD 2012/01/23   ------ >>>>>>
                    sqlText += " ,@GOODSSPECIALNOTE" + Environment.NewLine;
                    // -- ADD 2012/01/23   ------ <<<<<<
                    //2012/05/07 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    sqlText += " ,@RENTSYNCSUPPLIER" + Environment.NewLine;
                    sqlText += " ,@RENTSYNCSTOCKDATE" + Environment.NewLine;
                    sqlText += " ,@RENTSYNCSUPSLIPNO" + Environment.NewLine;
                    //2012/05/07 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlText += " )" + Environment.NewLine;
                    //--- ADD 2008/09/12 M.Kubota ---<<<
                    # endregion

                    sqlCommand.CommandText = sqlText;

                    //＠売上履歴明細データ変更＠
                    #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter paraSalesRowNo = sqlCommand.Parameters.Add("@SALESROWNO", SqlDbType.Int);
                    SqlParameter paraSalesRowDerivNo = sqlCommand.Parameters.Add("@SALESROWDERIVNO", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraSalesDate = sqlCommand.Parameters.Add("@SALESDATE", SqlDbType.Int);
                    SqlParameter paraCommonSeqNo = sqlCommand.Parameters.Add("@COMMONSEQNO", SqlDbType.BigInt);
                    SqlParameter paraSalesSlipDtlNum = sqlCommand.Parameters.Add("@SALESSLIPDTLNUM", SqlDbType.BigInt);
                    SqlParameter paraAcptAnOdrStatusSrc = sqlCommand.Parameters.Add("@ACPTANODRSTATUSSRC", SqlDbType.Int);
                    SqlParameter paraSalesSlipDtlNumSrc = sqlCommand.Parameters.Add("@SALESSLIPDTLNUMSRC", SqlDbType.BigInt);
                    SqlParameter paraSupplierFormalSync = sqlCommand.Parameters.Add("@SUPPLIERFORMALSYNC", SqlDbType.Int);
                    SqlParameter paraStockSlipDtlNumSync = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUMSYNC", SqlDbType.BigInt);
                    SqlParameter paraSalesSlipCdDtl = sqlCommand.Parameters.Add("@SALESSLIPCDDTL", SqlDbType.Int);
                    SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                    SqlParameter paraMakerKanaName = sqlCommand.Parameters.Add("@MAKERKANANAME", SqlDbType.NVarChar);
                    SqlParameter paraCmpltMakerKanaName = sqlCommand.Parameters.Add("@CMPLTMAKERKANANAME", SqlDbType.NVarChar);
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                    SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                    SqlParameter paraGoodsLGroup = sqlCommand.Parameters.Add("@GOODSLGROUP", SqlDbType.Int);
                    SqlParameter paraGoodsLGroupName = sqlCommand.Parameters.Add("@GOODSLGROUPNAME", SqlDbType.NVarChar);
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                    SqlParameter paraGoodsMGroupName = sqlCommand.Parameters.Add("@GOODSMGROUPNAME", SqlDbType.NVarChar);
                    SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                    SqlParameter paraBLGroupName = sqlCommand.Parameters.Add("@BLGROUPNAME", SqlDbType.NVarChar);
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                    SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                    SqlParameter paraEnterpriseGanreName = sqlCommand.Parameters.Add("@ENTERPRISEGANRENAME", SqlDbType.NVarChar);
                    SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                    SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                    SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                    SqlParameter paraSalesOrderDivCd = sqlCommand.Parameters.Add("@SALESORDERDIVCD", SqlDbType.Int);
                    SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                    SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                    SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter paraListPriceRate = sqlCommand.Parameters.Add("@LISTPRICERATE", SqlDbType.Float);
                    SqlParameter paraRateSectPriceUnPrc = sqlCommand.Parameters.Add("@RATESECTPRICEUNPRC", SqlDbType.NChar);
                    SqlParameter paraRateDivLPrice = sqlCommand.Parameters.Add("@RATEDIVLPRICE", SqlDbType.NChar);
                    SqlParameter paraUnPrcCalcCdLPrice = sqlCommand.Parameters.Add("@UNPRCCALCCDLPRICE", SqlDbType.Int);
                    SqlParameter paraPriceCdLPrice = sqlCommand.Parameters.Add("@PRICECDLPRICE", SqlDbType.Int);
                    SqlParameter paraStdUnPrcLPrice = sqlCommand.Parameters.Add("@STDUNPRCLPRICE", SqlDbType.Float);
                    SqlParameter paraFracProcUnitLPrice = sqlCommand.Parameters.Add("@FRACPROCUNITLPRICE", SqlDbType.Float);
                    SqlParameter paraFracProcLPrice = sqlCommand.Parameters.Add("@FRACPROCLPRICE", SqlDbType.Int);
                    SqlParameter paraListPriceTaxIncFl = sqlCommand.Parameters.Add("@LISTPRICETAXINCFL", SqlDbType.Float);
                    SqlParameter paraListPriceTaxExcFl = sqlCommand.Parameters.Add("@LISTPRICETAXEXCFL", SqlDbType.Float);
                    SqlParameter paraListPriceChngCd = sqlCommand.Parameters.Add("@LISTPRICECHNGCD", SqlDbType.Int);
                    SqlParameter paraSalesRate = sqlCommand.Parameters.Add("@SALESRATE", SqlDbType.Float);
                    SqlParameter paraRateSectSalUnPrc = sqlCommand.Parameters.Add("@RATESECTSALUNPRC", SqlDbType.NChar);
                    SqlParameter paraRateDivSalUnPrc = sqlCommand.Parameters.Add("@RATEDIVSALUNPRC", SqlDbType.NChar);
                    SqlParameter paraUnPrcCalcCdSalUnPrc = sqlCommand.Parameters.Add("@UNPRCCALCCDSALUNPRC", SqlDbType.Int);
                    SqlParameter paraPriceCdSalUnPrc = sqlCommand.Parameters.Add("@PRICECDSALUNPRC", SqlDbType.Int);
                    SqlParameter paraStdUnPrcSalUnPrc = sqlCommand.Parameters.Add("@STDUNPRCSALUNPRC", SqlDbType.Float);
                    SqlParameter paraFracProcUnitSalUnPrc = sqlCommand.Parameters.Add("@FRACPROCUNITSALUNPRC", SqlDbType.Float);
                    SqlParameter paraFracProcSalUnPrc = sqlCommand.Parameters.Add("@FRACPROCSALUNPRC", SqlDbType.Int);
                    SqlParameter paraSalesUnPrcTaxIncFl = sqlCommand.Parameters.Add("@SALESUNPRCTAXINCFL", SqlDbType.Float);
                    SqlParameter paraSalesUnPrcTaxExcFl = sqlCommand.Parameters.Add("@SALESUNPRCTAXEXCFL", SqlDbType.Float);
                    SqlParameter paraSalesUnPrcChngCd = sqlCommand.Parameters.Add("@SALESUNPRCCHNGCD", SqlDbType.Int);
                    SqlParameter paraCostRate = sqlCommand.Parameters.Add("@COSTRATE", SqlDbType.Float);
                    SqlParameter paraRateSectCstUnPrc = sqlCommand.Parameters.Add("@RATESECTCSTUNPRC", SqlDbType.NChar);
                    SqlParameter paraRateDivUnCst = sqlCommand.Parameters.Add("@RATEDIVUNCST", SqlDbType.NChar);
                    SqlParameter paraUnPrcCalcCdUnCst = sqlCommand.Parameters.Add("@UNPRCCALCCDUNCST", SqlDbType.Int);
                    SqlParameter paraPriceCdUnCst = sqlCommand.Parameters.Add("@PRICECDUNCST", SqlDbType.Int);
                    SqlParameter paraStdUnPrcUnCst = sqlCommand.Parameters.Add("@STDUNPRCUNCST", SqlDbType.Float);
                    SqlParameter paraFracProcUnitUnCst = sqlCommand.Parameters.Add("@FRACPROCUNITUNCST", SqlDbType.Float);
                    SqlParameter paraFracProcUnCst = sqlCommand.Parameters.Add("@FRACPROCUNCST", SqlDbType.Int);
                    SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Float);
                    SqlParameter paraSalesUnitCostChngDiv = sqlCommand.Parameters.Add("@SALESUNITCOSTCHNGDIV", SqlDbType.Int);
                    SqlParameter paraRateBLGoodsCode = sqlCommand.Parameters.Add("@RATEBLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraRateBLGoodsName = sqlCommand.Parameters.Add("@RATEBLGOODSNAME", SqlDbType.NVarChar);
                    SqlParameter paraRateGoodsRateGrpCd = sqlCommand.Parameters.Add("@RATEGOODSRATEGRPCD", SqlDbType.Int);
                    SqlParameter paraRateGoodsRateGrpNm = sqlCommand.Parameters.Add("@RATEGOODSRATEGRPNM", SqlDbType.NVarChar);
                    SqlParameter paraRateBLGroupCode = sqlCommand.Parameters.Add("@RATEBLGROUPCODE", SqlDbType.Int);
                    SqlParameter paraRateBLGroupName = sqlCommand.Parameters.Add("@RATEBLGROUPNAME", SqlDbType.NVarChar);
                    SqlParameter paraPrtBLGoodsCode = sqlCommand.Parameters.Add("@PRTBLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraPrtBLGoodsName = sqlCommand.Parameters.Add("@PRTBLGOODSNAME", SqlDbType.NVarChar);
                    SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
                    SqlParameter paraSalesCdNm = sqlCommand.Parameters.Add("@SALESCDNM", SqlDbType.NVarChar);
                    SqlParameter paraWorkManHour = sqlCommand.Parameters.Add("@WORKMANHOUR", SqlDbType.Float);
                    SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
                    SqlParameter paraSalesMoneyTaxInc = sqlCommand.Parameters.Add("@SALESMONEYTAXINC", SqlDbType.BigInt);
                    SqlParameter paraSalesMoneyTaxExc = sqlCommand.Parameters.Add("@SALESMONEYTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraCost = sqlCommand.Parameters.Add("@COST", SqlDbType.BigInt);
                    SqlParameter paraGrsProfitChkDiv = sqlCommand.Parameters.Add("@GRSPROFITCHKDIV", SqlDbType.Int);
                    SqlParameter paraSalesGoodsCd = sqlCommand.Parameters.Add("@SALESGOODSCD", SqlDbType.Int);
                    SqlParameter paraSalesPriceConsTax = sqlCommand.Parameters.Add("@SALESPRICECONSTAX", SqlDbType.BigInt);
                    SqlParameter paraTaxationDivCd = sqlCommand.Parameters.Add("@TAXATIONDIVCD", SqlDbType.Int);
                    SqlParameter paraPartySlipNumDtl = sqlCommand.Parameters.Add("@PARTYSLIPNUMDTL", SqlDbType.NVarChar);
                    SqlParameter paraDtlNote = sqlCommand.Parameters.Add("@DTLNOTE", SqlDbType.NVarChar);
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                    SqlParameter paraOrderNumber = sqlCommand.Parameters.Add("@ORDERNUMBER", SqlDbType.NVarChar);
                    SqlParameter paraWayToOrder = sqlCommand.Parameters.Add("@WAYTOORDER", SqlDbType.Int);
                    SqlParameter paraSlipMemo1 = sqlCommand.Parameters.Add("@SLIPMEMO1", SqlDbType.NVarChar);
                    SqlParameter paraSlipMemo2 = sqlCommand.Parameters.Add("@SLIPMEMO2", SqlDbType.NVarChar);
                    SqlParameter paraSlipMemo3 = sqlCommand.Parameters.Add("@SLIPMEMO3", SqlDbType.NVarChar);
                    SqlParameter paraInsideMemo1 = sqlCommand.Parameters.Add("@INSIDEMEMO1", SqlDbType.NVarChar);
                    SqlParameter paraInsideMemo2 = sqlCommand.Parameters.Add("@INSIDEMEMO2", SqlDbType.NVarChar);
                    SqlParameter paraInsideMemo3 = sqlCommand.Parameters.Add("@INSIDEMEMO3", SqlDbType.NVarChar);
                    SqlParameter paraBfListPrice = sqlCommand.Parameters.Add("@BFLISTPRICE", SqlDbType.Float);
                    SqlParameter paraBfSalesUnitPrice = sqlCommand.Parameters.Add("@BFSALESUNITPRICE", SqlDbType.Float);
                    SqlParameter paraBfUnitCost = sqlCommand.Parameters.Add("@BFUNITCOST", SqlDbType.Float);
                    SqlParameter paraCmpltSalesRowNo = sqlCommand.Parameters.Add("@CMPLTSALESROWNO", SqlDbType.Int);
                    SqlParameter paraCmpltGoodsMakerCd = sqlCommand.Parameters.Add("@CMPLTGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraCmpltMakerName = sqlCommand.Parameters.Add("@CMPLTMAKERNAME", SqlDbType.NVarChar);
                    SqlParameter paraCmpltGoodsName = sqlCommand.Parameters.Add("@CMPLTGOODSNAME", SqlDbType.NVarChar);
                    SqlParameter paraCmpltShipmentCnt = sqlCommand.Parameters.Add("@CMPLTSHIPMENTCNT", SqlDbType.Float);
                    SqlParameter paraCmpltSalesUnPrcFl = sqlCommand.Parameters.Add("@CMPLTSALESUNPRCFL", SqlDbType.Float);
                    SqlParameter paraCmpltSalesMoney = sqlCommand.Parameters.Add("@CMPLTSALESMONEY", SqlDbType.BigInt);
                    SqlParameter paraCmpltSalesUnitCost = sqlCommand.Parameters.Add("@CMPLTSALESUNITCOST", SqlDbType.Float);
                    SqlParameter paraCmpltCost = sqlCommand.Parameters.Add("@CMPLTCOST", SqlDbType.BigInt);
                    SqlParameter paraCmpltPartySalSlNum = sqlCommand.Parameters.Add("@CMPLTPARTYSALSLNUM", SqlDbType.NVarChar);
                    SqlParameter paraCmpltNote = sqlCommand.Parameters.Add("@CMPLTNOTE", SqlDbType.NVarChar);
                    SqlParameter paraPrtGoodsNo = sqlCommand.Parameters.Add("@PRTGOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraPrtMakerCode = sqlCommand.Parameters.Add("@PRTMAKERCODE", SqlDbType.Int);
                    SqlParameter paraPrtMakerName = sqlCommand.Parameters.Add("@PRTMAKERNAME", SqlDbType.NVarChar);
                    // 2009/05/18 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);  // キャンペーンコード
                    SqlParameter paraCampaignName = sqlCommand.Parameters.Add("@CAMPAIGNNAME", SqlDbType.NVarChar);  // キャンペーン名称
                    SqlParameter paraGoodsDivCd = sqlCommand.Parameters.Add("@GOODSDIVCD", SqlDbType.Int);  // 商品種別
                    SqlParameter paraAnswerDelivDate = sqlCommand.Parameters.Add("@ANSWERDELIVDATE", SqlDbType.NVarChar);  // 回答納期
                    SqlParameter paraRecycleDiv = sqlCommand.Parameters.Add("@RECYCLEDIV", SqlDbType.Int);  // リサイクル区分
                    SqlParameter paraRecycleDivNm = sqlCommand.Parameters.Add("@RECYCLEDIVNM", SqlDbType.NVarChar);  // リサイクル区分名称
                    SqlParameter paraWayToAcptOdr = sqlCommand.Parameters.Add("@WAYTOACPTODR", SqlDbType.Int);  // 受注方法
                    // 2009/05/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    SqlParameter paraAutoAnswerDivSCM = sqlCommand.Parameters.Add("@AUTOANSWERDIVSCM", SqlDbType.Int);  // 自動回答区分(SCM)// Add 2011/07/23 duzg for 自動回答区分(SCM)追加
                    // -- ADD 2011/08/10   ------ >>>>>>
                    SqlParameter paraAcceptOrOrderKind = sqlCommand.Parameters.Add("@ACCEPTORORDERKIND", SqlDbType.Int);      // 受発注種別
                    SqlParameter paraInquiryNumber = sqlCommand.Parameters.Add("@INQUIRYNUMBER", SqlDbType.BigInt);           // 問合せ番号
                    SqlParameter paraInqRowNumber = sqlCommand.Parameters.Add("@INQROWNUMBER", SqlDbType.Int);                // 問合せ行番号
                    // -- ADD 2011/08/10   ------ <<<<<<
                    // -- ADD 2012/01/23   ------ >>>>>>
                    SqlParameter paraGoodsSpecialNote = sqlCommand.Parameters.Add("@GOODSSPECIALNOTE", SqlDbType.NVarChar);      // 商品規格・特記事項
                    // -- ADD 2012/01/23   ------ <<<<<<
                    //2012/05/07 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    SqlParameter paraRentSyncSupplier = sqlCommand.Parameters.Add("@RENTSYNCSUPPLIER", SqlDbType.Int);      // 貸出同時仕入先
                    SqlParameter paraRentSyncStockDate = sqlCommand.Parameters.Add("@RENTSYNCSTOCKDATE", SqlDbType.Int);      // 貸出同時仕入日
                    SqlParameter paraRentSyncSupSlipNo = sqlCommand.Parameters.Add("@RENTSYNCSUPSLIPNO", SqlDbType.NVarChar);      // 貸出同時仕入伝票番号
                    //2012/05/07 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    #endregion

                    foreach (object item in saleshistdtlWorkList)
                    {
                        SalesHistDtlWork saleshistdtlWork = item as SalesHistDtlWork;

                        // 受注ステータスが 30:売上 の場合にのみ履歴データを登録する
                        if (saleshistdtlWork != null && saleshistdtlWork.AcptAnOdrStatus == 30)
                        {
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)saleshistdtlWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            //＠売上履歴明細データ変更＠                            
                            //para<#FieldName>.Value = SqlDataMediator.<#sqlDbTypeSetAccessor>(saleshistdtlWork.<#FieldName>);               // <#name>
                            #region Parameterオブジェクトへ値設定(更新用)
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(saleshistdtlWork.CreateDateTime);                // 作成日時
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(saleshistdtlWork.UpdateDateTime);                // 更新日時
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.EnterpriseCode);                           // 企業コード
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(saleshistdtlWork.FileHeaderGuid);                             // GUID
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.UpdEmployeeCode);                         // 更新従業員コード
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.UpdAssemblyId1);                           // 更新アセンブリID1
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.UpdAssemblyId2);                           // 更新アセンブリID2
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.LogicalDeleteCode);                      // 論理削除区分
                            paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.AcceptAnOrderNo);                          // 受注番号
                            paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.AcptAnOdrStatus);                          // 受注ステータス
                            paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.SalesSlipNum);                               // 売上伝票番号
                            paraSalesRowNo.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.SalesRowNo);                                    // 売上行番号
                            paraSalesRowDerivNo.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.SalesRowDerivNo);                          // 売上行番号枝番
                            paraSectionCode.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.SectionCode);                                 // 拠点コード
                            paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.SubSectionCode);                            // 部門コード
                            paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(saleshistdtlWork.SalesDate);                       // 売上日付
                            paraCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(saleshistdtlWork.CommonSeqNo);                                  // 共通通番
                            paraSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(saleshistdtlWork.SalesSlipDtlNum);                          // 売上明細通番
                            paraAcptAnOdrStatusSrc.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.AcptAnOdrStatusSrc);                    // 受注ステータス（元）
                            paraSalesSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(saleshistdtlWork.SalesSlipDtlNumSrc);                    // 売上明細通番（元）
                            paraSupplierFormalSync.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.SupplierFormalSync);                    // 仕入形式（同時）
                            paraStockSlipDtlNumSync.Value = SqlDataMediator.SqlSetInt64(saleshistdtlWork.StockSlipDtlNumSync);                  // 仕入明細通番（同時）
                            paraSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.SalesSlipCdDtl);                            // 売上伝票区分（明細）
                            paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.GoodsKindCode);                              // 商品属性
                            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.GoodsMakerCd);                                // 商品メーカーコード
                            paraMakerName.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.MakerName);                                     // メーカー名称
                            paraMakerKanaName.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.MakerKanaName);                             // メーカーカナ名称
                            paraCmpltMakerKanaName.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.CmpltMakerKanaName);                   // メーカーカナ名称（一式）
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.GoodsNo);                                         // 商品番号
                            paraGoodsName.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.GoodsName);                                     // 商品名称
                            paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.GoodsNameKana);                             // 商品名称カナ
                            paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.GoodsLGroup);                                  // 商品大分類コード
                            paraGoodsLGroupName.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.GoodsLGroupName);                         // 商品大分類名称
                            paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.GoodsMGroup);                                  // 商品中分類コード
                            paraGoodsMGroupName.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.GoodsMGroupName);                         // 商品中分類名称
                            paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.BLGroupCode);                                  // BLグループコード
                            paraBLGroupName.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.BLGroupName);                                 // BLグループコード名称
                            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.BLGoodsCode);                                  // BL商品コード
                            paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.BLGoodsFullName);                         // BL商品コード名称（全角）
                            paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.EnterpriseGanreCode);                  // 自社分類コード
                            paraEnterpriseGanreName.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.EnterpriseGanreName);                 // 自社分類名称
                            paraWarehouseCode.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.WarehouseCode);                             // 倉庫コード
                            paraWarehouseName.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.WarehouseName);                             // 倉庫名称
                            paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.WarehouseShelfNo);                       // 倉庫棚番
                            paraSalesOrderDivCd.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.SalesOrderDivCd);                          // 売上在庫取寄せ区分
                            paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.OpenPriceDiv);                                // オープン価格区分
                            paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.GoodsRateRank);                             // 商品掛率ランク
                            paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.CustRateGrpCode);                          // 得意先掛率グループコード
                            paraListPriceRate.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.ListPriceRate);                             // 定価率
                            paraRateSectPriceUnPrc.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.RateSectPriceUnPrc);                   // 掛率設定拠点（定価）
                            paraRateDivLPrice.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.RateDivLPrice);                             // 掛率設定区分（定価）
                            paraUnPrcCalcCdLPrice.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.UnPrcCalcCdLPrice);                      // 単価算出区分（定価）
                            paraPriceCdLPrice.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.PriceCdLPrice);                              // 価格区分（定価）
                            paraStdUnPrcLPrice.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.StdUnPrcLPrice);                           // 基準単価（定価）
                            paraFracProcUnitLPrice.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.FracProcUnitLPrice);                   // 端数処理単位（定価）
                            paraFracProcLPrice.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.FracProcLPrice);                            // 端数処理（定価）
                            paraListPriceTaxIncFl.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.ListPriceTaxIncFl);                     // 定価（税込，浮動）
                            paraListPriceTaxExcFl.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.ListPriceTaxExcFl);                     // 定価（税抜，浮動）
                            paraListPriceChngCd.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.ListPriceChngCd);                          // 定価変更区分
                            paraSalesRate.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.SalesRate);                                     // 売価率
                            paraRateSectSalUnPrc.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.RateSectSalUnPrc);                       // 掛率設定拠点（売上単価）
                            paraRateDivSalUnPrc.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.RateDivSalUnPrc);                         // 掛率設定区分（売上単価）
                            paraUnPrcCalcCdSalUnPrc.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.UnPrcCalcCdSalUnPrc);                  // 単価算出区分（売上単価）
                            paraPriceCdSalUnPrc.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.PriceCdSalUnPrc);                          // 価格区分（売上単価）
                            paraStdUnPrcSalUnPrc.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.StdUnPrcSalUnPrc);                       // 基準単価（売上単価）
                            paraFracProcUnitSalUnPrc.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.FracProcUnitSalUnPrc);               // 端数処理単位（売上単価）
                            paraFracProcSalUnPrc.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.FracProcSalUnPrc);                        // 端数処理（売上単価）
                            paraSalesUnPrcTaxIncFl.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.SalesUnPrcTaxIncFl);                   // 売上単価（税込，浮動）
                            paraSalesUnPrcTaxExcFl.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.SalesUnPrcTaxExcFl);                   // 売上単価（税抜，浮動）
                            paraSalesUnPrcChngCd.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.SalesUnPrcChngCd);                        // 売上単価変更区分
                            paraCostRate.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.CostRate);                                       // 原価率
                            paraRateSectCstUnPrc.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.RateSectCstUnPrc);                       // 掛率設定拠点（原価単価）
                            paraRateDivUnCst.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.RateDivUnCst);                               // 掛率設定区分（原価単価）
                            paraUnPrcCalcCdUnCst.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.UnPrcCalcCdUnCst);                        // 単価算出区分（原価単価）
                            paraPriceCdUnCst.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.PriceCdUnCst);                                // 価格区分（原価単価）
                            paraStdUnPrcUnCst.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.StdUnPrcUnCst);                             // 基準単価（原価単価）
                            paraFracProcUnitUnCst.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.FracProcUnitUnCst);                     // 端数処理単位（原価単価）
                            paraFracProcUnCst.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.FracProcUnCst);                              // 端数処理（原価単価）
                            paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.SalesUnitCost);                             // 原価単価
                            paraSalesUnitCostChngDiv.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.SalesUnitCostChngDiv);                // 原価単価変更区分
                            paraRateBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.RateBLGoodsCode);                          // BL商品コード（掛率）
                            paraRateBLGoodsName.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.RateBLGoodsName);                         // BL商品コード名称（掛率）
                            paraRateGoodsRateGrpCd.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.RateGoodsRateGrpCd);                    // 商品掛率グループコード（掛率）
                            paraRateGoodsRateGrpNm.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.RateGoodsRateGrpNm);                   // 商品掛率グループ名称（掛率）
                            paraRateBLGroupCode.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.RateBLGroupCode);                          // BLグループコード（掛率）
                            paraRateBLGroupName.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.RateBLGroupName);                         // BLグループ名称（掛率）
                            paraPrtBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.PrtBLGoodsCode);                            // BL商品コード（印刷）
                            paraPrtBLGoodsName.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.PrtBLGoodsName);                           // BL商品コード名称（印刷）
                            paraSalesCode.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.SalesCode);                                      // 販売区分コード
                            paraSalesCdNm.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.SalesCdNm);                                     // 販売区分名称
                            paraWorkManHour.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.WorkManHour);                                 // 作業工数
                            paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.ShipmentCnt);                                 // 出荷数
                            paraSalesMoneyTaxInc.Value = SqlDataMediator.SqlSetInt64(saleshistdtlWork.SalesMoneyTaxInc);                        // 売上金額（税込み）
                            paraSalesMoneyTaxExc.Value = SqlDataMediator.SqlSetInt64(saleshistdtlWork.SalesMoneyTaxExc);                        // 売上金額（税抜き）
                            paraCost.Value = SqlDataMediator.SqlSetInt64(saleshistdtlWork.Cost);                                                // 原価
                            paraGrsProfitChkDiv.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.GrsProfitChkDiv);                          // 粗利チェック区分
                            paraSalesGoodsCd.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.SalesGoodsCd);                                // 売上商品区分
                            paraSalesPriceConsTax.Value = SqlDataMediator.SqlSetInt64(saleshistdtlWork.SalesPriceConsTax);                      // 売上金額消費税額
                            paraTaxationDivCd.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.TaxationDivCd);                              // 課税区分
                            paraPartySlipNumDtl.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.PartySlipNumDtl);                         // 相手先伝票番号（明細）
                            paraDtlNote.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.DtlNote);                                         // 明細備考
                            paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.SupplierCd);                                    // 仕入先コード
                            paraSupplierSnm.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.SupplierSnm);                                 // 仕入先略称
                            paraOrderNumber.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.OrderNumber);                                 // 発注番号
                            paraWayToOrder.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.WayToOrder);                                    // 注文方法
                            paraSlipMemo1.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.SlipMemo1);                                     // 伝票メモ１
                            paraSlipMemo2.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.SlipMemo2);                                     // 伝票メモ２
                            paraSlipMemo3.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.SlipMemo3);                                     // 伝票メモ３
                            paraInsideMemo1.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.InsideMemo1);                                 // 社内メモ１
                            paraInsideMemo2.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.InsideMemo2);                                 // 社内メモ２
                            paraInsideMemo3.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.InsideMemo3);                                 // 社内メモ３
                            paraBfListPrice.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.BfListPrice);                                 // 変更前定価
                            paraBfSalesUnitPrice.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.BfSalesUnitPrice);                       // 変更前売価
                            paraBfUnitCost.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.BfUnitCost);                                   // 変更前原価
                            paraCmpltSalesRowNo.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.CmpltSalesRowNo);                          // 一式明細番号
                            paraCmpltGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.CmpltGoodsMakerCd);                      // メーカーコード（一式）
                            paraCmpltMakerName.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.CmpltMakerName);                           // メーカー名称（一式）
                            paraCmpltGoodsName.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.CmpltGoodsName);                           // 商品名称（一式）
                            paraCmpltShipmentCnt.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.CmpltShipmentCnt);                       // 数量（一式）
                            paraCmpltSalesUnPrcFl.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.CmpltSalesUnPrcFl);                     // 売上単価（一式）
                            paraCmpltSalesMoney.Value = SqlDataMediator.SqlSetInt64(saleshistdtlWork.CmpltSalesMoney);                          // 売上金額（一式）
                            paraCmpltSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(saleshistdtlWork.CmpltSalesUnitCost);                   // 原価単価（一式）
                            paraCmpltCost.Value = SqlDataMediator.SqlSetInt64(saleshistdtlWork.CmpltCost);                                      // 原価金額（一式）
                            paraCmpltPartySalSlNum.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.CmpltPartySalSlNum);                   // 相手先伝票番号（一式）
                            paraCmpltNote.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.CmpltNote);                                     // 一式備考
                            paraPrtGoodsNo.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.PrtGoodsNo);                                   // 印刷用品番
                            paraPrtMakerCode.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.PrtMakerCode);                                // 印刷用メーカーコード
                            paraPrtMakerName.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.PrtMakerName);                               // 印刷用メーカー名称
                            // 2009/05/18 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.CampaignCode);  // キャンペーンコード
                            paraCampaignName.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.CampaignName);  // キャンペーン名称
                            paraGoodsDivCd.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.GoodsDivCd);  // 商品種別
                            paraAnswerDelivDate.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.AnswerDelivDate);  // 回答納期
                            paraRecycleDiv.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.RecycleDiv);  // リサイクル区分
                            paraRecycleDivNm.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.RecycleDivNm);  // リサイクル区分名称
                            paraWayToAcptOdr.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.WayToAcptOdr);  // 受注方法
                            // 2009/05/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            paraAutoAnswerDivSCM.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.AutoAnswerDivSCM);  // 自動回答区分(SCM)// Add 2011/07/23 duzg for 自動回答区分(SCM)追加
                           // -- ADD 2011/08/10   ------ >>>>>>
                            paraAcceptOrOrderKind.Value = SqlDataMediator.SqlSetInt16(saleshistdtlWork.AcceptOrOrderKind);      // 受発注種別
                            paraInquiryNumber.Value = SqlDataMediator.SqlSetInt64(saleshistdtlWork.InquiryNumber);           // 問合せ番号
                            paraInqRowNumber.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.InqRowNumber);                // 問合せ行番号
                            // -- ADD 2011/08/10   ------ <<<<<<
                            // -- ADD 2012/01/23   ------ >>>>>>
                            paraGoodsSpecialNote.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.GoodsSpecialNote);      // 商品規格・特記事項
                            // -- ADD 2012/01/23   ------ <<<<<<
                            //2012/05/07 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            paraRentSyncSupplier.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.RentSyncSupplier);      // 貸出同時仕入先
                            paraRentSyncStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(saleshistdtlWork.RentSyncStockDate);  // 貸出同時仕入日
                            paraRentSyncSupSlipNo.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.RentSyncSupSlipNo);      // 貸出同時仕入伝票番号
                            //2012/05/07 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            #endregion

                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    # endregion
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [LogicalDelete]
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int LogicalDelete(ref ArrayList paramList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref paramList, 0, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int RevivalLogicalDelete(ref ArrayList paramList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref paramList, 1, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="procMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int LogicalDeleteProc(ref ArrayList paramList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SalesHistoryWork saleshistoryWork = null;
            ArrayList saleshistdtlWorkList = null;

            status = this.GetSalesHistoryParam(paramList, out saleshistoryWork, out saleshistdtlWorkList);

            if (saleshistoryWork != null)
            {
                status = this.LogicalDeleteProc(ref saleshistoryWork, ref saleshistdtlWorkList, procMode, ref sqlConnection, ref sqlTransaction);

                // 赤伝履歴削除の場合、元黒伝の赤黒連結伝票番号を初期化する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (saleshistoryWork.DebitNoteDiv == 1)
                    {
                        status = this.DeleteDebitNLnkSalesSlipNo(saleshistoryWork, ref sqlConnection, ref sqlTransaction);
                    }
                }
            }

            for (int i = 0; i < paramList.Count; i++)
            {
                if (paramList[i] is SalesHistoryWork)
                {
                    paramList.RemoveAt(i);
                }
                else if (paramList[i] is ArrayList)
                {
                    if ((paramList[i] as ArrayList).Count > 0 && (paramList[i] as ArrayList)[0] is SalesHistDtlWork)
                    {
                        paramList.RemoveAt(i);
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saleshistoryWork"></param>
        /// <param name="saleshistdtlWorkList"></param>
        /// <param name="procMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int LogicalDeleteProc(ref SalesHistoryWork saleshistoryWork, ref ArrayList saleshistdtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            
            try
            {
                status = this.LogicalDeleteSalesHistory(ref saleshistoryWork, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (saleshistdtlWorkList != null && saleshistdtlWorkList.Count > 0 && saleshistdtlWorkList[0] is SalesHistDtlWork)
                    {
                        // 売上明細履歴データを元に１件ごとに売上明細履歴データを論理削除する
                        status = this.LogicalDeleteSalesHistDtl(ref saleshistdtlWorkList, procMode, ref sqlConnection, ref sqlTransaction);
                    }
                    else
                    {
                        // 売上履歴データを元に１度に複数件の売上明細履歴データを論理削除する
                        status = this.LogicalDeleteSalesHistDtl(ref saleshistoryWork, procMode, ref sqlConnection, ref sqlTransaction);
                    }
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";

                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": " + procModestr;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {

            }
            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saleshistoryWork"></param>
        /// <param name="procMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int LogicalDeleteSalesHistory(ref SalesHistoryWork saleshistoryWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteSalesHistoryProc(ref saleshistoryWork, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saleshistoryWork"></param>
        /// <param name="procMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int LogicalDeleteSalesHistoryProc(ref SalesHistoryWork saleshistoryWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                // 受注ステータスが 30:売上 の場合にのみ履歴にデータを操作する
                if (saleshistoryWork != null && saleshistoryWork.AcptAnOdrStatus == 30)
                {
                    int logicalDelCd = (int)ConstantManagement.LogicalMode.GetData0;
                    
                    //Selectコマンドの生成
                    #region [SELECT文]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  HIST.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,HIST.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,HIST.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SALESHISTORYRF AS HIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND HIST.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                    # endregion

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(saleshistoryWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.AcptAnOdrStatus);
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SalesSlipNum);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                        if (_updateDateTime != saleshistoryWork.UpdateDateTime)
                        {
                            //既存データで更新日時違いの場合には排他
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // 現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        //更新時のSQL文を作成
                        # region [UPDATE文]
                        sqlText = "";
                        sqlText += "UPDATE" + Environment.NewLine;
                        sqlText += "  SALESHISTORYRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        // add by liusy 2011/12/02 readmine #8412 ---------<<<<<<
                        sqlText += " ,SEARCHSLIPDATERF = @SEARCHSLIPDATE" + Environment.NewLine;
                        // add by liusy 2011/12/02 readmine #8412 --------->>>>>>
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += "  AND SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                        # endregion

                        sqlCommand.CommandText = sqlText;

                        //KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(saleshistoryWork.EnterpriseCode);
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.AcptAnOdrStatus);
                        findSalesSlipNum.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SalesSlipNum);

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)saleshistoryWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (saleshistoryWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }
                    }

                    sqlCommand.Cancel();
                    
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    //論理削除モードの場合
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                            return status;
                        }
                        else if (logicalDelCd == 0) saleshistoryWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                        else saleshistoryWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            saleshistoryWork.LogicalDeleteCode = 0; //論理削除フラグを解除
                        }
                        else
                        {
                            if (logicalDelCd == 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //既に復活している場合はそのまま正常を戻す
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  //完全削除はデータなしを戻す
                            }

                            return status;
                        }
                    }

                    #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    // add by liusy 2011/12/02 readmine #8412 ---------<<<<<<
                    SqlParameter paraSearchSlipDate = sqlCommand.Parameters.Add("@SEARCHSLIPDATE", SqlDbType.Int);
                    // add by liusy 2011/12/02 readmine #8412 --------->>>>>>
                    #endregion

                    #region Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(saleshistoryWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(saleshistoryWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(saleshistoryWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(saleshistoryWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.LogicalDeleteCode);
                    // add by liusy 2011/12/02 readmine #8412 ---------<<<<<<
                    paraSearchSlipDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(saleshistoryWork.UpdateDateTime);
                    // add by liusy 2011/12/02 readmine #8412 --------->>>>>>
                    #endregion

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 売上明細履歴データの論理削除状態を操作します。
        /// </summary>
        /// <param name="saleshistoryWork">論理削除対象の売上明細履歴データに紐付く StockHistoryWork</param>
        /// <param name="procMode">動作区分 0:削除, 1:復活</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int LogicalDeleteSalesHistDtl(ref SalesHistoryWork saleshistoryWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteSalesHistDtlProc(ref saleshistoryWork, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 売上明細履歴データの論理削除状態を操作します。
        /// </summary>
        /// <param name="saleshistoryWork">論理削除対象の売上明細履歴データに紐付く StockHistoryWork</param>
        /// <param name="procMode">動作区分 0:削除, 1:復活</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        private int LogicalDeleteSalesHistDtlProc(ref SalesHistoryWork saleshistoryWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                // 受注ステータスが 30:売上 の場合にのみ履歴にデータを操作する
                if (saleshistoryWork != null && saleshistoryWork.AcptAnOdrStatus == 30)
                {
                    int logicalDelCd = (int)ConstantManagement.LogicalMode.GetData0;

                    //Selectコマンドの生成
                    #region [SELECT文]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  HIST.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,HIST.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,HIST.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SALESHISTORYRF AS HIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND HIST.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                    # endregion

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(saleshistoryWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.AcptAnOdrStatus);
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SalesSlipNum);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                        if (_updateDateTime != saleshistoryWork.UpdateDateTime)
                        {
                            //既存データで更新日時違いの場合には排他
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // 現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        //更新時のSQL文を作成
                        # region [UPDATE文]
                        sqlText = "";
                        sqlText += "UPDATE" + Environment.NewLine;
                        sqlText += "  SALESHISTDTLRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += "  AND SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                        # endregion

                        sqlCommand.CommandText = sqlText;

                        //KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(saleshistoryWork.EnterpriseCode);
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.AcptAnOdrStatus);
                        findSalesSlipNum.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SalesSlipNum);

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)saleshistoryWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (saleshistoryWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }
                    }

                    sqlCommand.Cancel();

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    // 紐付く売上履歴データの論理削除区分を踏襲する
                    /*
                    //論理削除モードの場合
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                            return status;
                        }
                        else if (logicalDelCd == 0) saleshistoryWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                        else saleshistoryWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            saleshistoryWork.LogicalDeleteCode = 0; //論理削除フラグを解除
                        }
                        else
                        {
                            if (logicalDelCd == 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //既に復活している場合はそのまま正常を戻す
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  //完全削除はデータなしを戻す
                            }

                            return status;
                        }
                    }
                    */

                    #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    #endregion

                    #region Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(saleshistoryWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(saleshistoryWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(saleshistoryWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(saleshistoryWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.LogicalDeleteCode);
                    #endregion

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 売上明細履歴データの論理削除状態を操作します。
        /// </summary>
        /// <param name="saleshistdtlWorkList">論理削除対象の StockhistdtlWork を格納する ArrayList</param>
        /// <param name="procMode">動作区分 0:削除, 1:復活</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int LogicalDeleteSalesHistDtl(ref ArrayList saleshistdtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteSalesHistDtlProc(ref saleshistdtlWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 売上明細履歴データの論理削除状態を操作します。
        /// </summary>
        /// <param name="saleshistdtlWorkList">論理削除対象の StockhistdtlWork を格納する ArrayList</param>
        /// <param name="procMode">動作区分 0:削除, 1:復活</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        private int LogicalDeleteSalesHistDtlProc(ref ArrayList saleshistdtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (saleshistdtlWorkList != null && saleshistdtlWorkList.Count > 0 && saleshistdtlWorkList[0] is SalesHistDtlWork)
                {
                    int logicalDelCd = (int)ConstantManagement.LogicalMode.GetData0;
                    
                    foreach (object item in saleshistdtlWorkList)
                    {
                        SalesHistDtlWork saleshistdtlWork = item as SalesHistDtlWork;

                        // 受注ステータスが 30:売上 の場合にのみ履歴データを登録する
                        if (saleshistdtlWork != null && saleshistdtlWork.AcptAnOdrStatus == 30)
                        {
                            //Selectコマンドの生成
                            #region [SELECT文]
                            string sqlText = "";
                            sqlText += "SELECT" + Environment.NewLine;
                            sqlText += "  DTL.UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,DTL.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  SALESHISTDTLRF AS DTL" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  DTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND DTL.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  AND DTL.SALESSLIPDTLNUMRF = @FINDSALESSLIPDTLNUM" + Environment.NewLine;
                            # endregion

                            if (sqlCommand == null)
                            {
                                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                            }
                            else
                            {
                                sqlCommand.CommandText = sqlText;
                                sqlCommand.Parameters.Clear();
                            }

                            // Prameterオブジェクトの作成
                            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                            SqlParameter findSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUM", SqlDbType.BigInt);

                            //Parameterオブジェクトへ値設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.EnterpriseCode);
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.AcptAnOdrStatus);
                            findSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(saleshistdtlWork.SalesSlipDtlNum);

                            myReader = sqlCommand.ExecuteReader();

                            if (myReader.Read())
                            {
                                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                                if (_updateDateTime != saleshistdtlWork.UpdateDateTime)
                                {
                                    //新規登録で該当データ有りの場合には重複
                                    if (saleshistdtlWork.UpdateDateTime == DateTime.MinValue)
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                    }
                                    //既存データで更新日時違いの場合には排他
                                    else
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                    }

                                    return status;
                                }

                                //更新時のSQL文を作成
                                # region [UPDATE文]
                                sqlText = "";
                                sqlText += "UPDATE" + Environment.NewLine;
                                sqlText += "  SALESHISTDTLRF" + Environment.NewLine;
                                sqlText += "SET" + Environment.NewLine;
                                sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                                sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                                sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                                sqlText += "WHERE" + Environment.NewLine;
                                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                                sqlText += "  AND SALESSLIPDTLNUMRF = @FINDSALESSLIPDTLNUM" + Environment.NewLine;
                                # endregion

                                sqlCommand.CommandText = sqlText;

                                //KEYコマンドを再設定
                                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.EnterpriseCode);
                                findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.AcptAnOdrStatus);
                                findSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(saleshistdtlWork.SalesSlipDtlNum);

                                //更新ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)saleshistdtlWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);
                            }
                            else
                            {
                                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                                if (saleshistdtlWork.UpdateDateTime > DateTime.MinValue)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                    return status;
                                }
                            }

                            sqlCommand.Cancel();

                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }

                            //論理削除モードの場合
                            if (procMode == 0)
                            {
                                if (logicalDelCd == 3)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                                    return status;
                                }
                                else if (logicalDelCd == 0) saleshistdtlWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                                else saleshistdtlWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                            }
                            else
                            {
                                if (logicalDelCd == 1)
                                {
                                    saleshistdtlWork.LogicalDeleteCode = 0; //論理削除フラグを解除
                                }
                                else
                                {
                                    if (logicalDelCd == 0)
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //既に復活している場合はそのまま正常を戻す
                                    }
                                    else
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  //完全削除はデータなしを戻す
                                    }

                                    return status;
                                }
                            }

                            #region Parameterオブジェクトの作成(更新用)
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                            #endregion

                            #region Parameterオブジェクトへ値設定(更新用)
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(saleshistdtlWork.UpdateDateTime);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.LogicalDeleteCode);
                            #endregion

                            sqlCommand.ExecuteNonQuery();

                        }
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        #endregion

        #region [Delete]
        /// <summary>
        /// 売上履歴データ情報を物理削除します
        /// </summary>
        /// <param name="paramList">削除する売上履歴情報を含むArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        public int Delete(ref ArrayList paramList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SalesHistoryWork saleshistoryWork = null;
            ArrayList saleshistdtlWorkList = null;

            try
            {
                this.GetSalesHistoryParam(paramList, out saleshistoryWork, out saleshistdtlWorkList);

                if (saleshistoryWork != null)
                {
                    //Delete実行
                    status = this.DeleteProc(ref saleshistoryWork, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saleshistoryWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int DeleteProc(ref SalesHistoryWork saleshistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            status = this.DeleteSalesSlipHist(ref saleshistoryWork, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = this.DeleteSalesSlHistDtl(ref saleshistoryWork, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }

        /// <summary>
        /// 売上履歴データ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="saleshistoryWork">売上履歴データ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 売上履歴データ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.24</br>
        public int DeleteSalesSlipHist(ref SalesHistoryWork saleshistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteSalesSlipHistProc(ref saleshistoryWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 売上履歴データ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="saleshistoryWork">売上履歴データ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 売上履歴データ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.24</br>
        private int DeleteSalesSlipHistProc(ref SalesHistoryWork saleshistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                // 受注ステータスが 30:売上 の場合にのみ履歴にデータを操作する
                if (saleshistoryWork != null && saleshistoryWork.AcptAnOdrStatus == 30)
                {
                    int logicalDelCd = (int)ConstantManagement.LogicalMode.GetData0;

                    //Selectコマンドの生成
                    #region [SELECT文]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  HIST.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,HIST.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,HIST.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SALESHISTDTLRF AS HIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND HIST.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                    # endregion

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(saleshistoryWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.AcptAnOdrStatus);
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SalesSlipNum);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                        if (_updateDateTime != saleshistoryWork.UpdateDateTime)
                        {
                            //既存データで更新日時違いの場合には排他
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // 現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        //削除時のSQL文を作成
                        # region [DELETE文]
                        sqlText = "";
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  SALESHISTORYWORK" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ACPTANODRSTATUSRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += "  AND SALESSLIPNUMRF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                        # endregion

                        sqlCommand.CommandText = sqlText;

                        //KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(saleshistoryWork.EnterpriseCode);
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.AcptAnOdrStatus);
                        findSalesSlipNum.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SalesSlipNum);

                        sqlCommand.Cancel();

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.ExecuteNonQuery();

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (saleshistoryWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 売上履歴データに紐付く売上履歴明細データを物理削除します。
        /// </summary>
        /// <param name="saleshistoryWork">売上履歴データ情報オブジェクト</param>
        /// <param name="sqlConnection">SqlConnnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int DeleteSalesSlHistDtl(ref SalesHistoryWork saleshistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteSalesSlHistDtl(ref saleshistoryWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 売上履歴データに紐付く売上履歴明細データを物理削除します。
        /// </summary>
        /// <param name="saleshistoryWork">売上履歴データ情報オブジェクト</param>
        /// <param name="sqlConnection">SqlConnnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        private int DeleteSalesSlHistDtlProc(ref SalesHistoryWork saleshistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                // 受注ステータスが 30:売上 の場合にのみ履歴にデータを操作する
                if (saleshistoryWork != null && saleshistoryWork.AcptAnOdrStatus == 30)
                {
                    int logicalDelCd = (int)ConstantManagement.LogicalMode.GetData0;

                    //Selectコマンドの生成
                    #region [SELECT文]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  HIST.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,HIST.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,HIST.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SALESHISTDTLWORK AS HIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND HIST.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                    # endregion

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(saleshistoryWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.AcptAnOdrStatus);
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SalesSlipNum);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                        if (_updateDateTime != saleshistoryWork.UpdateDateTime)
                        {
                            //既存データで更新日時違いの場合には排他
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // 現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        //削除時のSQL文を作成
                        # region [DELETE文]
                        sqlText = "";
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  SALESHISTDTLWORK" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += "  AND SALESSLIPNUMRF = @FINDSALESSLIPNUMRF" + Environment.NewLine;
                        # endregion

                        sqlCommand.CommandText = sqlText;

                        //KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(saleshistoryWork.EnterpriseCode);
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(saleshistoryWork.AcptAnOdrStatus);
                        findSalesSlipNum.Value = SqlDataMediator.SqlSetString(saleshistoryWork.SalesSlipNum);

                        sqlCommand.Cancel();

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.ExecuteNonQuery();

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (saleshistoryWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 指定された売上履歴明細データを物理削除します。
        /// </summary>
        /// <param name="saleshistdtlWorkList">売上履歴明細データの配列</param>
        /// <param name="procMode">処理区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int DeleteSalesSlHistDtl(ref ArrayList saleshistdtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteSalesSlHistDtlProc(ref saleshistdtlWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された売上履歴明細データを物理削除します。
        /// </summary>
        /// <param name="saleshistdtlWorkList">売上履歴明細データの配列</param>
        /// <param name="procMode">処理区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        private int DeleteSalesSlHistDtlProc(ref ArrayList saleshistdtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (saleshistdtlWorkList != null && saleshistdtlWorkList.Count > 0 && saleshistdtlWorkList[0] is SalesHistDtlWork)
                {
                    foreach (object item in saleshistdtlWorkList)
                    {
                        SalesHistDtlWork saleshistdtlWork = item as SalesHistDtlWork;

                        // 受注ステータスが 30:売上 の場合にのみ履歴データを登録する
                        if (saleshistdtlWork != null && saleshistdtlWork.AcptAnOdrStatus == 30)
                        {
                            //Selectコマンドの生成
                            #region [SELECT文]
                            string sqlText = "";
                            sqlText += "SELECT" + Environment.NewLine;
                            sqlText += "  DTL.UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,DTL.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  SALESHISTDTLRF AS DTL" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  DTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND DTL.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  AND DTL.SALESSLIPDTLNUMRF = @FINDSALESSLIPDTLNUM" + Environment.NewLine;
                            # endregion

                            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                            // Prameterオブジェクトの作成
                            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                            SqlParameter findSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUM", SqlDbType.BigInt);

                            //Parameterオブジェクトへ値設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.EnterpriseCode);
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.AcptAnOdrStatus);
                            findSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(saleshistdtlWork.SalesSlipDtlNum);

                            myReader = sqlCommand.ExecuteReader();

                            if (myReader.Read())
                            {
                                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                                if (_updateDateTime != saleshistdtlWork.UpdateDateTime)
                                {
                                    //新規登録で該当データ有りの場合には重複
                                    if (saleshistdtlWork.UpdateDateTime == DateTime.MinValue)
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                    }
                                    //既存データで更新日時違いの場合には排他
                                    else
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                    }

                                    return status;
                                }

                                //削除時のSQL文を作成
                                # region [DELETE文]
                                sqlText = "";
                                sqlText += "DELETE" + Environment.NewLine;
                                sqlText += "  SALESHISTDTLRF" + Environment.NewLine;
                                sqlText += "WHERE" + Environment.NewLine;
                                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                                sqlText += "  AND SALESSLIPDTLNUMRF = @FINDSALESSLIPDTLNUM" + Environment.NewLine;
                                # endregion

                                sqlCommand.CommandText = sqlText;

                                //KEYコマンドを再設定
                                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(saleshistdtlWork.EnterpriseCode);
                                findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(saleshistdtlWork.AcptAnOdrStatus);
                                findSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(saleshistdtlWork.SalesSlipDtlNum);
                            }
                            else
                            {
                                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                                if (saleshistdtlWork.UpdateDateTime > DateTime.MinValue)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                    return status;
                                }
                            }

                            sqlCommand.Cancel();

                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }

                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;

        }                
        #endregion

        # region [RedWrite]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="redSlipList"></param>
        /// <param name="blkSlipList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int RedWrite(ref ArrayList redSlipList, ref ArrayList blkSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 赤伝格納用
            SalesHistoryWork redSalesHistoryWork = null;
            ArrayList redSalesHistDtlWorkList = null;

            status = this.MakeSalesHistoryParam(redSlipList, out redSalesHistoryWork, out redSalesHistDtlWorkList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            
            // 赤伝履歴登録
            status = this.WriteProc(ref redSalesHistoryWork, ref redSalesHistDtlWorkList, ref sqlConnection, ref sqlTransaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            // 元黒格納用
            SalesHistoryWork blkSalesHistoryWork = null;
            ArrayList blkSalesHistDtlWorkList = null;

            status = this.MakeSalesHistoryParam(blkSlipList, out blkSalesHistoryWork, out blkSalesHistDtlWorkList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            // 元黒履歴登録
            status = this.WriteProc(ref blkSalesHistoryWork, ref blkSalesHistDtlWorkList, ref sqlConnection, ref sqlTransaction);

            return status;
        }

        /// <summary>
        /// 元黒伝の赤黒連結売上伝票番号をリセットします
        /// </summary>
        /// <param name="salesHistoryWork">履歴伝票削除パラメータ</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクションオブジェクト</param>
        /// <returns>STATUS</returns>
        private int DeleteDebitNLnkSalesSlipNo(SalesHistoryWork salesHistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
				// ADD 2011/09/08 qijh SCM対応 - 拠点管理(10704767-00) #24609 --------->>>>>
				IFileHeader flhd = (IFileHeader)new SalesHistoryWork();
				new FileHeader(this).SetUpdateHeader(ref flhd, this);
				// ADD 2011/09/08 qijh SCM対応 - 拠点管理(10704767-00) #24609 ---------<<<<<
                string sqlText = "";
                sqlText += "UPDATE" + Environment.NewLine;
                sqlText += "  SALESHISTORYRF" + Environment.NewLine;
                sqlText += "SET" + Environment.NewLine;
                sqlText += "  DEBITNLNKSALESSLNUMRF = NULL" + Environment.NewLine;
				sqlText += " ,DEBITNOTEDIVRF = 0" + Environment.NewLine;
				// ADD 2011/09/08 qijh SCM対応 - 拠点管理(10704767-00) #24609 --------->>>>>
				sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
				sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
				sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
				sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
				// ADD 2011/09/08 qijh SCM対応 - 拠点管理(10704767-00) #24609 ---------<<<<<
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                sqlText += "  AND DEBITNLNKSALESSLNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                                  
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
					// ADD 2011/09/08 qijh SCM対応 - 拠点管理(10704767-00) #24609 --------->>>>>
					SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
					SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
					SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
					SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
					// ADD 2011/09/08 qijh SCM対応 - 拠点管理(10704767-00) #24609 ---------<<<<<

                    //KEYコマンドを再設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesHistoryWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesHistoryWork.AcptAnOdrStatus);
					findSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesHistoryWork.SalesSlipNum);
					// ADD 2011/09/08 qijh SCM対応 - 拠点管理(10704767-00) #24609 --------->>>>>
					paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(flhd.UpdateDateTime);
					paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(flhd.UpdEmployeeCode);
					paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(flhd.UpdAssemblyId1);
					paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(flhd.UpdAssemblyId2);
					// ADD 2011/09/08 qijh SCM対応 - 拠点管理(10704767-00) #24609 ---------<<<<<

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }

        # endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int WriteInitialize(ref ArrayList paramList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SalesHistoryWork salesHistoryWork = null;
            ArrayList saleshistdtlWorkList = null;

            status = this.MakeSalesHistoryParam(paramList, out salesHistoryWork, out saleshistdtlWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (salesHistoryWork != null)
                {
                    paramList.Add(salesHistoryWork);
                }

                if (saleshistdtlWorkList != null && saleshistdtlWorkList.Count > 0)
                {
                    paramList.Add(saleshistdtlWorkList);
                }
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int DeleteInitialize(ref ArrayList paramList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SalesHistoryWork salesHistoryWork = null;
            ArrayList saleshistdtlWorkList = null;

            status = this.MakeSalesHistoryParam(paramList, out salesHistoryWork, out saleshistdtlWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (salesHistoryWork != null)
                {
                    // 既に売上履歴が登録されている場合は一度読み込む
                    if (SalesHistTool.StrToIntDef(salesHistoryWork.SalesSlipNum, 0) > 0)
                    {
                        status = this.ReadSalesSlipHist(ref salesHistoryWork, 0, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }

                    paramList.Add(salesHistoryWork);
                }

                if (saleshistdtlWorkList != null && saleshistdtlWorkList.Count > 0)
                {
                    // 既に売上履歴明細が登録されている場合は一度読み込む
                    if ((saleshistdtlWorkList[0] as SalesHistDtlWork).SalesSlipDtlNum > 0)
                    {
                        status = this.ReadSalesSlHistDtl(ref saleshistdtlWorkList, 0, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }

                    paramList.Add(saleshistdtlWorkList);
                }
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="salesHistoryWork"></param>
        /// <param name="salesHistDtlWorks"></param>
        /// <returns></returns>
        private int MakeSalesHistoryParam(ArrayList paramList, out SalesHistoryWork salesHistoryWork, out ArrayList salesHistDtlWorks)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SalesHistoryWork dstSalesHistoryWork = null;
            ArrayList dstSalesHistDtlWorkList = null;

            bool redSlip = true;

            if (paramList != null && paramList.Count > 0)
            {
                foreach (object item in paramList)
                {
                    if (item is SalesSlipWork)
                    {
                        if (dstSalesHistoryWork == null)
                        {
                            SalesSlipWork srcSalesSlipWork = item as SalesSlipWork;
                            dstSalesHistoryWork = new SalesHistoryWork();
                            
                            //＠売上履歴データ変更＠
                            //dstSalesHistoryWork.<#FieldName> = srcSalesSlipWork.<#FieldName>;
                            # region [SalesHistoryWork(売上履歴データ) ← SalesSlipWork(売上データ)]
                            // 売上履歴データ・売上データのレイアウト変更が発生した場合は要修正

                            // 赤伝の場合は新規追加しかないので共通ファイルヘッダ部分を設定しない
                            if (srcSalesSlipWork.DebitNoteDiv != 1)
                            {
                                redSlip = false;

                                dstSalesHistoryWork.CreateDateTime = srcSalesSlipWork.CreateDateTime;
                                dstSalesHistoryWork.FileHeaderGuid = srcSalesSlipWork.FileHeaderGuid;
                                dstSalesHistoryWork.UpdateDateTime = srcSalesSlipWork.UpdateDateTime;
                                dstSalesHistoryWork.UpdEmployeeCode = srcSalesSlipWork.UpdEmployeeCode;
                                dstSalesHistoryWork.UpdAssemblyId1 = srcSalesSlipWork.UpdAssemblyId1;
                                dstSalesHistoryWork.UpdAssemblyId2 = srcSalesSlipWork.UpdAssemblyId2;
                            }


                            dstSalesHistoryWork.EnterpriseCode = srcSalesSlipWork.EnterpriseCode;
                            dstSalesHistoryWork.LogicalDeleteCode = srcSalesSlipWork.LogicalDeleteCode;
                            dstSalesHistoryWork.AcptAnOdrStatus = srcSalesSlipWork.AcptAnOdrStatus;
                            dstSalesHistoryWork.SalesSlipNum = srcSalesSlipWork.SalesSlipNum;
                            dstSalesHistoryWork.SectionCode = srcSalesSlipWork.SectionCode;
                            dstSalesHistoryWork.SubSectionCode = srcSalesSlipWork.SubSectionCode;
                            dstSalesHistoryWork.DebitNoteDiv = srcSalesSlipWork.DebitNoteDiv;
                            dstSalesHistoryWork.DebitNLnkSalesSlNum = srcSalesSlipWork.DebitNLnkSalesSlNum;
                            dstSalesHistoryWork.SalesSlipCd = srcSalesSlipWork.SalesSlipCd;
                            dstSalesHistoryWork.SalesGoodsCd = srcSalesSlipWork.SalesGoodsCd;
                            dstSalesHistoryWork.AccRecDivCd = srcSalesSlipWork.AccRecDivCd;
                            dstSalesHistoryWork.SalesInpSecCd = srcSalesSlipWork.SalesInpSecCd;
                            dstSalesHistoryWork.DemandAddUpSecCd = srcSalesSlipWork.DemandAddUpSecCd;
                            dstSalesHistoryWork.ResultsAddUpSecCd = srcSalesSlipWork.ResultsAddUpSecCd;
                            dstSalesHistoryWork.UpdateSecCd = srcSalesSlipWork.UpdateSecCd;
                            dstSalesHistoryWork.SalesSlipUpdateCd = srcSalesSlipWork.SalesSlipUpdateCd;
                            dstSalesHistoryWork.SearchSlipDate = srcSalesSlipWork.SearchSlipDate;
                            dstSalesHistoryWork.ShipmentDay = srcSalesSlipWork.ShipmentDay;
                            dstSalesHistoryWork.SalesDate = srcSalesSlipWork.SalesDate;
                            dstSalesHistoryWork.AddUpADate = srcSalesSlipWork.AddUpADate;
                            dstSalesHistoryWork.DelayPaymentDiv = srcSalesSlipWork.DelayPaymentDiv;
                            dstSalesHistoryWork.InputAgenCd = srcSalesSlipWork.InputAgenCd;
                            dstSalesHistoryWork.InputAgenNm = srcSalesSlipWork.InputAgenNm;
                            dstSalesHistoryWork.SalesInputCode = srcSalesSlipWork.SalesInputCode;
                            dstSalesHistoryWork.SalesInputName = srcSalesSlipWork.SalesInputName;
                            dstSalesHistoryWork.FrontEmployeeCd = srcSalesSlipWork.FrontEmployeeCd;
                            dstSalesHistoryWork.FrontEmployeeNm = srcSalesSlipWork.FrontEmployeeNm;
                            dstSalesHistoryWork.SalesEmployeeCd = srcSalesSlipWork.SalesEmployeeCd;
                            dstSalesHistoryWork.SalesEmployeeNm = srcSalesSlipWork.SalesEmployeeNm;
                            dstSalesHistoryWork.TotalAmountDispWayCd = srcSalesSlipWork.TotalAmountDispWayCd;
                            dstSalesHistoryWork.TtlAmntDispRateApy = srcSalesSlipWork.TtlAmntDispRateApy;
                            dstSalesHistoryWork.SalesTotalTaxInc = srcSalesSlipWork.SalesTotalTaxInc;
                            dstSalesHistoryWork.SalesTotalTaxExc = srcSalesSlipWork.SalesTotalTaxExc;
                            dstSalesHistoryWork.SalesPrtTotalTaxInc = srcSalesSlipWork.SalesPrtTotalTaxInc;
                            dstSalesHistoryWork.SalesPrtTotalTaxExc = srcSalesSlipWork.SalesPrtTotalTaxExc;
                            dstSalesHistoryWork.SalesWorkTotalTaxInc = srcSalesSlipWork.SalesWorkTotalTaxInc;
                            dstSalesHistoryWork.SalesWorkTotalTaxExc = srcSalesSlipWork.SalesWorkTotalTaxExc;
                            dstSalesHistoryWork.SalesSubtotalTaxInc = srcSalesSlipWork.SalesSubtotalTaxInc;
                            dstSalesHistoryWork.SalesSubtotalTaxExc = srcSalesSlipWork.SalesSubtotalTaxExc;
                            dstSalesHistoryWork.SalesPrtSubttlInc = srcSalesSlipWork.SalesPrtSubttlInc;
                            dstSalesHistoryWork.SalesPrtSubttlExc = srcSalesSlipWork.SalesPrtSubttlExc;
                            dstSalesHistoryWork.SalesWorkSubttlInc = srcSalesSlipWork.SalesWorkSubttlInc;
                            dstSalesHistoryWork.SalesWorkSubttlExc = srcSalesSlipWork.SalesWorkSubttlExc;
                            dstSalesHistoryWork.SalesNetPrice = srcSalesSlipWork.SalesNetPrice;
                            dstSalesHistoryWork.SalesSubtotalTax = srcSalesSlipWork.SalesSubtotalTax;
                            dstSalesHistoryWork.ItdedSalesOutTax = srcSalesSlipWork.ItdedSalesOutTax;
                            dstSalesHistoryWork.ItdedSalesInTax = srcSalesSlipWork.ItdedSalesInTax;
                            dstSalesHistoryWork.SalSubttlSubToTaxFre = srcSalesSlipWork.SalSubttlSubToTaxFre;
                            dstSalesHistoryWork.SalesOutTax = srcSalesSlipWork.SalesOutTax;
                            dstSalesHistoryWork.SalAmntConsTaxInclu = srcSalesSlipWork.SalAmntConsTaxInclu;
                            dstSalesHistoryWork.SalesDisTtlTaxExc = srcSalesSlipWork.SalesDisTtlTaxExc;
                            dstSalesHistoryWork.ItdedSalesDisOutTax = srcSalesSlipWork.ItdedSalesDisOutTax;
                            dstSalesHistoryWork.ItdedSalesDisInTax = srcSalesSlipWork.ItdedSalesDisInTax;
                            dstSalesHistoryWork.ItdedPartsDisOutTax = srcSalesSlipWork.ItdedPartsDisOutTax;
                            dstSalesHistoryWork.ItdedPartsDisInTax = srcSalesSlipWork.ItdedPartsDisInTax;
                            dstSalesHistoryWork.ItdedWorkDisOutTax = srcSalesSlipWork.ItdedWorkDisOutTax;
                            dstSalesHistoryWork.ItdedWorkDisInTax = srcSalesSlipWork.ItdedWorkDisInTax;
                            dstSalesHistoryWork.ItdedSalesDisTaxFre = srcSalesSlipWork.ItdedSalesDisTaxFre;
                            dstSalesHistoryWork.SalesDisOutTax = srcSalesSlipWork.SalesDisOutTax;
                            dstSalesHistoryWork.SalesDisTtlTaxInclu = srcSalesSlipWork.SalesDisTtlTaxInclu;
                            dstSalesHistoryWork.PartsDiscountRate = srcSalesSlipWork.PartsDiscountRate;
                            dstSalesHistoryWork.RavorDiscountRate = srcSalesSlipWork.RavorDiscountRate;
                            dstSalesHistoryWork.TotalCost = srcSalesSlipWork.TotalCost;
                            dstSalesHistoryWork.ConsTaxLayMethod = srcSalesSlipWork.ConsTaxLayMethod;
                            dstSalesHistoryWork.ConsTaxRate = srcSalesSlipWork.ConsTaxRate;
                            dstSalesHistoryWork.FractionProcCd = srcSalesSlipWork.FractionProcCd;
                            dstSalesHistoryWork.AccRecConsTax = srcSalesSlipWork.AccRecConsTax;
                            dstSalesHistoryWork.AutoDepositCd = srcSalesSlipWork.AutoDepositCd;
                            dstSalesHistoryWork.AutoDepositSlipNo = srcSalesSlipWork.AutoDepositSlipNo;
                            dstSalesHistoryWork.DepositAllowanceTtl = srcSalesSlipWork.DepositAllowanceTtl;
                            dstSalesHistoryWork.DepositAlwcBlnce = srcSalesSlipWork.DepositAlwcBlnce;
                            dstSalesHistoryWork.ClaimCode = srcSalesSlipWork.ClaimCode;
                            dstSalesHistoryWork.ClaimSnm = srcSalesSlipWork.ClaimSnm;
                            dstSalesHistoryWork.CustomerCode = srcSalesSlipWork.CustomerCode;
                            dstSalesHistoryWork.CustomerName = srcSalesSlipWork.CustomerName;
                            dstSalesHistoryWork.CustomerName2 = srcSalesSlipWork.CustomerName2;
                            dstSalesHistoryWork.CustomerSnm = srcSalesSlipWork.CustomerSnm;
                            dstSalesHistoryWork.HonorificTitle = srcSalesSlipWork.HonorificTitle;
                            dstSalesHistoryWork.OutputNameCode = srcSalesSlipWork.OutputNameCode;
                            dstSalesHistoryWork.OutputName = srcSalesSlipWork.OutputName;
                            dstSalesHistoryWork.SlipAddressDiv = srcSalesSlipWork.SlipAddressDiv;
                            dstSalesHistoryWork.AddresseeCode = srcSalesSlipWork.AddresseeCode;
                            dstSalesHistoryWork.AddresseeName = srcSalesSlipWork.AddresseeName;
                            dstSalesHistoryWork.AddresseeName2 = srcSalesSlipWork.AddresseeName2;
                            dstSalesHistoryWork.AddresseePostNo = srcSalesSlipWork.AddresseePostNo;
                            dstSalesHistoryWork.AddresseeAddr1 = srcSalesSlipWork.AddresseeAddr1;
                            dstSalesHistoryWork.AddresseeAddr3 = srcSalesSlipWork.AddresseeAddr3;
                            dstSalesHistoryWork.AddresseeAddr4 = srcSalesSlipWork.AddresseeAddr4;
                            dstSalesHistoryWork.AddresseeTelNo = srcSalesSlipWork.AddresseeTelNo;
                            dstSalesHistoryWork.AddresseeFaxNo = srcSalesSlipWork.AddresseeFaxNo;
                            dstSalesHistoryWork.PartySaleSlipNum = srcSalesSlipWork.PartySaleSlipNum;
                            dstSalesHistoryWork.SlipNote = srcSalesSlipWork.SlipNote;
                            dstSalesHistoryWork.SlipNote2 = srcSalesSlipWork.SlipNote2;
                            dstSalesHistoryWork.SlipNote3 = srcSalesSlipWork.SlipNote3;
                            dstSalesHistoryWork.RetGoodsReasonDiv = srcSalesSlipWork.RetGoodsReasonDiv;
                            dstSalesHistoryWork.RetGoodsReason = srcSalesSlipWork.RetGoodsReason;
                            dstSalesHistoryWork.DetailRowCount = srcSalesSlipWork.DetailRowCount;
                            dstSalesHistoryWork.EdiSendDate = srcSalesSlipWork.EdiSendDate;
                            dstSalesHistoryWork.EdiTakeInDate = srcSalesSlipWork.EdiTakeInDate;
                            dstSalesHistoryWork.UoeRemark1 = srcSalesSlipWork.UoeRemark1;
                            dstSalesHistoryWork.UoeRemark2 = srcSalesSlipWork.UoeRemark2;
                            dstSalesHistoryWork.SlipPrintDivCd = srcSalesSlipWork.SlipPrintDivCd;
                            dstSalesHistoryWork.SlipPrintFinishCd = srcSalesSlipWork.SlipPrintFinishCd;
                            dstSalesHistoryWork.SalesSlipPrintDate = srcSalesSlipWork.SalesSlipPrintDate;
                            dstSalesHistoryWork.BusinessTypeCode = srcSalesSlipWork.BusinessTypeCode;
                            dstSalesHistoryWork.BusinessTypeName = srcSalesSlipWork.BusinessTypeName;
                            dstSalesHistoryWork.DeliveredGoodsDiv = srcSalesSlipWork.DeliveredGoodsDiv;
                            dstSalesHistoryWork.DeliveredGoodsDivNm = srcSalesSlipWork.DeliveredGoodsDivNm;
                            dstSalesHistoryWork.SalesAreaCode = srcSalesSlipWork.SalesAreaCode;
                            dstSalesHistoryWork.SalesAreaName = srcSalesSlipWork.SalesAreaName;
                            dstSalesHistoryWork.SlipPrtSetPaperId = srcSalesSlipWork.SlipPrtSetPaperId;
                            dstSalesHistoryWork.CompleteCd = srcSalesSlipWork.CompleteCd;
                            dstSalesHistoryWork.SalesPriceFracProcCd = srcSalesSlipWork.SalesPriceFracProcCd;
                            dstSalesHistoryWork.StockGoodsTtlTaxExc = srcSalesSlipWork.StockGoodsTtlTaxExc;
                            dstSalesHistoryWork.PureGoodsTtlTaxExc = srcSalesSlipWork.PureGoodsTtlTaxExc;
                            dstSalesHistoryWork.ListPricePrintDiv = srcSalesSlipWork.ListPricePrintDiv;
                            dstSalesHistoryWork.EraNameDispCd1 = srcSalesSlipWork.EraNameDispCd1;
                            dstSalesHistoryWork.CustSlipNo = srcSalesSlipWork.CustSlipNo; //ADD BY 凌小青 on 2011/12/15 for Redmine#27313
                            
                            # endregion
                        }
                    }
                    else if (item is SalesSlipDeleteWork)
                    {
                        if (dstSalesHistoryWork == null)
                        {
                            SalesSlipDeleteWork srcSalesSlipDeleteWork = item as SalesSlipDeleteWork;
                            dstSalesHistoryWork = new SalesHistoryWork();

                            //＠売上履歴データ変更＠
                            # region [SalesHistoryWork(売上履歴データ) ← SalesSlipDeleteWork(売上削除データ)]

                            // 赤伝の場合は新規追加しかないので共通ファイルヘッダ部分を設定しない
                            if (srcSalesSlipDeleteWork.DebitNoteDiv != 1)
                            {
                                redSlip = false;
                                dstSalesHistoryWork.UpdateDateTime = srcSalesSlipDeleteWork.UpdateDateTime;
                            }

                            dstSalesHistoryWork.EnterpriseCode = srcSalesSlipDeleteWork.EnterpriseCode;
                            dstSalesHistoryWork.AcptAnOdrStatus = srcSalesSlipDeleteWork.AcptAnOdrStatus;
                            dstSalesHistoryWork.SalesSlipNum = srcSalesSlipDeleteWork.SalesSlipNum;
                            dstSalesHistoryWork.DebitNoteDiv = srcSalesSlipDeleteWork.DebitNoteDiv;
                            # endregion

                            dstSalesHistDtlWorkList = new ArrayList();
                        }
                    }
                    else if (item is ArrayList)
                    {
                        if ((item as ArrayList)[0] is SalesDetailWork)
                        {
                            if (dstSalesHistDtlWorkList == null)
                            {
                                dstSalesHistDtlWorkList = new ArrayList();

                                foreach (SalesDetailWork srcStockDetailWork in (item as ArrayList))
                                {
                                    SalesHistDtlWork dstSalesHistDtlWork = new SalesHistDtlWork();

                                    //＠売上履歴明細データ変更＠
                                    //dstSalesHistDtlWork.<#FieldName> = srcStockDetailWork.<#FieldName>;
                                    # region [SalesHistDtlWork(売上履歴明細データ) ← SalesDetailWork(売上明細データ)]
                                    // 売上履歴明細データ・売上明細データのレイアウト変更が発生した場合は要修正
                                    dstSalesHistDtlWork.CreateDateTime = srcStockDetailWork.CreateDateTime;
                                    dstSalesHistDtlWork.UpdateDateTime = srcStockDetailWork.UpdateDateTime;
                                    dstSalesHistDtlWork.EnterpriseCode = srcStockDetailWork.EnterpriseCode;
                                    dstSalesHistDtlWork.FileHeaderGuid = srcStockDetailWork.FileHeaderGuid;
                                    dstSalesHistDtlWork.UpdEmployeeCode = srcStockDetailWork.UpdEmployeeCode;
                                    dstSalesHistDtlWork.UpdAssemblyId1 = srcStockDetailWork.UpdAssemblyId1;
                                    dstSalesHistDtlWork.UpdAssemblyId2 = srcStockDetailWork.UpdAssemblyId2;
                                    dstSalesHistDtlWork.LogicalDeleteCode = srcStockDetailWork.LogicalDeleteCode;
                                    dstSalesHistDtlWork.AcceptAnOrderNo = srcStockDetailWork.AcceptAnOrderNo;
                                    dstSalesHistDtlWork.AcptAnOdrStatus = srcStockDetailWork.AcptAnOdrStatus;
                                    dstSalesHistDtlWork.SalesSlipNum = srcStockDetailWork.SalesSlipNum;
                                    dstSalesHistDtlWork.SalesRowNo = srcStockDetailWork.SalesRowNo;
                                    dstSalesHistDtlWork.SalesRowDerivNo = srcStockDetailWork.SalesRowDerivNo;
                                    dstSalesHistDtlWork.SectionCode = srcStockDetailWork.SectionCode;
                                    dstSalesHistDtlWork.SubSectionCode = srcStockDetailWork.SubSectionCode;
                                    dstSalesHistDtlWork.SalesDate = srcStockDetailWork.SalesDate;
                                    dstSalesHistDtlWork.CommonSeqNo = srcStockDetailWork.CommonSeqNo;
                                    dstSalesHistDtlWork.SalesSlipDtlNum = srcStockDetailWork.SalesSlipDtlNum;
                                    dstSalesHistDtlWork.AcptAnOdrStatusSrc = srcStockDetailWork.AcptAnOdrStatusSrc;
                                    dstSalesHistDtlWork.SalesSlipDtlNumSrc = srcStockDetailWork.SalesSlipDtlNumSrc;
                                    dstSalesHistDtlWork.SupplierFormalSync = srcStockDetailWork.SupplierFormalSync;
                                    dstSalesHistDtlWork.StockSlipDtlNumSync = srcStockDetailWork.StockSlipDtlNumSync;
                                    dstSalesHistDtlWork.SalesSlipCdDtl = srcStockDetailWork.SalesSlipCdDtl;
                                    dstSalesHistDtlWork.GoodsKindCode = srcStockDetailWork.GoodsKindCode;
                                    dstSalesHistDtlWork.GoodsMakerCd = srcStockDetailWork.GoodsMakerCd;
                                    dstSalesHistDtlWork.MakerName = srcStockDetailWork.MakerName;
                                    dstSalesHistDtlWork.MakerKanaName = srcStockDetailWork.MakerKanaName;
                                    dstSalesHistDtlWork.CmpltMakerKanaName = srcStockDetailWork.CmpltMakerKanaName;
                                    dstSalesHistDtlWork.GoodsNo = srcStockDetailWork.GoodsNo;
                                    dstSalesHistDtlWork.GoodsName = srcStockDetailWork.GoodsName;
                                    dstSalesHistDtlWork.GoodsNameKana = srcStockDetailWork.GoodsNameKana;
                                    dstSalesHistDtlWork.GoodsLGroup = srcStockDetailWork.GoodsLGroup;
                                    dstSalesHistDtlWork.GoodsLGroupName = srcStockDetailWork.GoodsLGroupName;
                                    dstSalesHistDtlWork.GoodsMGroup = srcStockDetailWork.GoodsMGroup;
                                    dstSalesHistDtlWork.GoodsMGroupName = srcStockDetailWork.GoodsMGroupName;
                                    dstSalesHistDtlWork.BLGroupCode = srcStockDetailWork.BLGroupCode;
                                    dstSalesHistDtlWork.BLGroupName = srcStockDetailWork.BLGroupName;
                                    dstSalesHistDtlWork.BLGoodsCode = srcStockDetailWork.BLGoodsCode;
                                    dstSalesHistDtlWork.BLGoodsFullName = srcStockDetailWork.BLGoodsFullName;
                                    dstSalesHistDtlWork.EnterpriseGanreCode = srcStockDetailWork.EnterpriseGanreCode;
                                    dstSalesHistDtlWork.EnterpriseGanreName = srcStockDetailWork.EnterpriseGanreName;
                                    dstSalesHistDtlWork.WarehouseCode = srcStockDetailWork.WarehouseCode;
                                    dstSalesHistDtlWork.WarehouseName = srcStockDetailWork.WarehouseName;
                                    dstSalesHistDtlWork.WarehouseShelfNo = srcStockDetailWork.WarehouseShelfNo;
                                    dstSalesHistDtlWork.SalesOrderDivCd = srcStockDetailWork.SalesOrderDivCd;
                                    dstSalesHistDtlWork.OpenPriceDiv = srcStockDetailWork.OpenPriceDiv;
                                    dstSalesHistDtlWork.GoodsRateRank = srcStockDetailWork.GoodsRateRank;
                                    dstSalesHistDtlWork.CustRateGrpCode = srcStockDetailWork.CustRateGrpCode;
                                    dstSalesHistDtlWork.ListPriceRate = srcStockDetailWork.ListPriceRate;
                                    dstSalesHistDtlWork.RateSectPriceUnPrc = srcStockDetailWork.RateSectPriceUnPrc;
                                    dstSalesHistDtlWork.RateDivLPrice = srcStockDetailWork.RateDivLPrice;
                                    dstSalesHistDtlWork.UnPrcCalcCdLPrice = srcStockDetailWork.UnPrcCalcCdLPrice;
                                    dstSalesHistDtlWork.PriceCdLPrice = srcStockDetailWork.PriceCdLPrice;
                                    dstSalesHistDtlWork.StdUnPrcLPrice = srcStockDetailWork.StdUnPrcLPrice;
                                    dstSalesHistDtlWork.FracProcUnitLPrice = srcStockDetailWork.FracProcUnitLPrice;
                                    dstSalesHistDtlWork.FracProcLPrice = srcStockDetailWork.FracProcLPrice;
                                    dstSalesHistDtlWork.ListPriceTaxIncFl = srcStockDetailWork.ListPriceTaxIncFl;
                                    dstSalesHistDtlWork.ListPriceTaxExcFl = srcStockDetailWork.ListPriceTaxExcFl;
                                    dstSalesHistDtlWork.ListPriceChngCd = srcStockDetailWork.ListPriceChngCd;
                                    dstSalesHistDtlWork.SalesRate = srcStockDetailWork.SalesRate;
                                    dstSalesHistDtlWork.RateSectSalUnPrc = srcStockDetailWork.RateSectSalUnPrc;
                                    dstSalesHistDtlWork.RateDivSalUnPrc = srcStockDetailWork.RateDivSalUnPrc;
                                    dstSalesHistDtlWork.UnPrcCalcCdSalUnPrc = srcStockDetailWork.UnPrcCalcCdSalUnPrc;
                                    dstSalesHistDtlWork.PriceCdSalUnPrc = srcStockDetailWork.PriceCdSalUnPrc;
                                    dstSalesHistDtlWork.StdUnPrcSalUnPrc = srcStockDetailWork.StdUnPrcSalUnPrc;
                                    dstSalesHistDtlWork.FracProcUnitSalUnPrc = srcStockDetailWork.FracProcUnitSalUnPrc;
                                    dstSalesHistDtlWork.FracProcSalUnPrc = srcStockDetailWork.FracProcSalUnPrc;
                                    dstSalesHistDtlWork.SalesUnPrcTaxIncFl = srcStockDetailWork.SalesUnPrcTaxIncFl;
                                    dstSalesHistDtlWork.SalesUnPrcTaxExcFl = srcStockDetailWork.SalesUnPrcTaxExcFl;
                                    dstSalesHistDtlWork.SalesUnPrcChngCd = srcStockDetailWork.SalesUnPrcChngCd;
                                    dstSalesHistDtlWork.CostRate = srcStockDetailWork.CostRate;
                                    dstSalesHistDtlWork.RateSectCstUnPrc = srcStockDetailWork.RateSectCstUnPrc;
                                    dstSalesHistDtlWork.RateDivUnCst = srcStockDetailWork.RateDivUnCst;
                                    dstSalesHistDtlWork.UnPrcCalcCdUnCst = srcStockDetailWork.UnPrcCalcCdUnCst;
                                    dstSalesHistDtlWork.PriceCdUnCst = srcStockDetailWork.PriceCdUnCst;
                                    dstSalesHistDtlWork.StdUnPrcUnCst = srcStockDetailWork.StdUnPrcUnCst;
                                    dstSalesHistDtlWork.FracProcUnitUnCst = srcStockDetailWork.FracProcUnitUnCst;
                                    dstSalesHistDtlWork.FracProcUnCst = srcStockDetailWork.FracProcUnCst;
                                    dstSalesHistDtlWork.SalesUnitCost = srcStockDetailWork.SalesUnitCost;
                                    dstSalesHistDtlWork.SalesUnitCostChngDiv = srcStockDetailWork.SalesUnitCostChngDiv;
                                    dstSalesHistDtlWork.RateBLGoodsCode = srcStockDetailWork.RateBLGoodsCode;
                                    dstSalesHistDtlWork.RateBLGoodsName = srcStockDetailWork.RateBLGoodsName;
                                    dstSalesHistDtlWork.RateGoodsRateGrpCd = srcStockDetailWork.RateGoodsRateGrpCd;
                                    dstSalesHistDtlWork.RateGoodsRateGrpNm = srcStockDetailWork.RateGoodsRateGrpNm;
                                    dstSalesHistDtlWork.RateBLGroupCode = srcStockDetailWork.RateBLGroupCode;
                                    dstSalesHistDtlWork.RateBLGroupName = srcStockDetailWork.RateBLGroupName;
                                    dstSalesHistDtlWork.PrtBLGoodsCode = srcStockDetailWork.PrtBLGoodsCode;
                                    dstSalesHistDtlWork.PrtBLGoodsName = srcStockDetailWork.PrtBLGoodsName;
                                    dstSalesHistDtlWork.SalesCode = srcStockDetailWork.SalesCode;
                                    dstSalesHistDtlWork.SalesCdNm = srcStockDetailWork.SalesCdNm;
                                    dstSalesHistDtlWork.WorkManHour = srcStockDetailWork.WorkManHour;
                                    dstSalesHistDtlWork.ShipmentCnt = srcStockDetailWork.ShipmentCnt;
                                    dstSalesHistDtlWork.SalesMoneyTaxInc = srcStockDetailWork.SalesMoneyTaxInc;
                                    dstSalesHistDtlWork.SalesMoneyTaxExc = srcStockDetailWork.SalesMoneyTaxExc;
                                    dstSalesHistDtlWork.Cost = srcStockDetailWork.Cost;
                                    dstSalesHistDtlWork.GrsProfitChkDiv = srcStockDetailWork.GrsProfitChkDiv;
                                    dstSalesHistDtlWork.SalesGoodsCd = srcStockDetailWork.SalesGoodsCd;
                                    dstSalesHistDtlWork.SalesPriceConsTax = srcStockDetailWork.SalesPriceConsTax;
                                    dstSalesHistDtlWork.TaxationDivCd = srcStockDetailWork.TaxationDivCd;
                                    dstSalesHistDtlWork.PartySlipNumDtl = srcStockDetailWork.PartySlipNumDtl;
                                    dstSalesHistDtlWork.DtlNote = srcStockDetailWork.DtlNote;
                                    dstSalesHistDtlWork.SupplierCd = srcStockDetailWork.SupplierCd;
                                    dstSalesHistDtlWork.SupplierSnm = srcStockDetailWork.SupplierSnm;
                                    dstSalesHistDtlWork.OrderNumber = srcStockDetailWork.OrderNumber;
                                    dstSalesHistDtlWork.WayToOrder = srcStockDetailWork.WayToOrder;
                                    dstSalesHistDtlWork.SlipMemo1 = srcStockDetailWork.SlipMemo1;
                                    dstSalesHistDtlWork.SlipMemo2 = srcStockDetailWork.SlipMemo2;
                                    dstSalesHistDtlWork.SlipMemo3 = srcStockDetailWork.SlipMemo3;
                                    dstSalesHistDtlWork.InsideMemo1 = srcStockDetailWork.InsideMemo1;
                                    dstSalesHistDtlWork.InsideMemo2 = srcStockDetailWork.InsideMemo2;
                                    dstSalesHistDtlWork.InsideMemo3 = srcStockDetailWork.InsideMemo3;
                                    dstSalesHistDtlWork.BfListPrice = srcStockDetailWork.BfListPrice;
                                    dstSalesHistDtlWork.BfSalesUnitPrice = srcStockDetailWork.BfSalesUnitPrice;
                                    dstSalesHistDtlWork.BfUnitCost = srcStockDetailWork.BfUnitCost;
                                    dstSalesHistDtlWork.CmpltSalesRowNo = srcStockDetailWork.CmpltSalesRowNo;
                                    dstSalesHistDtlWork.CmpltGoodsMakerCd = srcStockDetailWork.CmpltGoodsMakerCd;
                                    dstSalesHistDtlWork.CmpltMakerName = srcStockDetailWork.CmpltMakerName;
                                    dstSalesHistDtlWork.CmpltGoodsName = srcStockDetailWork.CmpltGoodsName;
                                    dstSalesHistDtlWork.CmpltShipmentCnt = srcStockDetailWork.CmpltShipmentCnt;
                                    dstSalesHistDtlWork.CmpltSalesUnPrcFl = srcStockDetailWork.CmpltSalesUnPrcFl;
                                    dstSalesHistDtlWork.CmpltSalesMoney = srcStockDetailWork.CmpltSalesMoney;
                                    dstSalesHistDtlWork.CmpltSalesUnitCost = srcStockDetailWork.CmpltSalesUnitCost;
                                    dstSalesHistDtlWork.CmpltCost = srcStockDetailWork.CmpltCost;
                                    dstSalesHistDtlWork.CmpltPartySalSlNum = srcStockDetailWork.CmpltPartySalSlNum;
                                    dstSalesHistDtlWork.CmpltNote = srcStockDetailWork.CmpltNote;
                                    dstSalesHistDtlWork.PrtGoodsNo = srcStockDetailWork.PrtGoodsNo;
                                    dstSalesHistDtlWork.PrtMakerCode = srcStockDetailWork.PrtMakerCode;
                                    dstSalesHistDtlWork.PrtMakerName = srcStockDetailWork.PrtMakerName;
                                    // 2009/05/18 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                    dstSalesHistDtlWork.CampaignCode = srcStockDetailWork.CampaignCode;  // キャンペーンコード
                                    dstSalesHistDtlWork.CampaignName = srcStockDetailWork.CampaignName;  // キャンペーン名称
                                    dstSalesHistDtlWork.GoodsDivCd = srcStockDetailWork.GoodsDivCd;  // 商品種別
                                    dstSalesHistDtlWork.AnswerDelivDate = srcStockDetailWork.AnswerDelivDate;  // 回答納期
                                    dstSalesHistDtlWork.RecycleDiv = srcStockDetailWork.RecycleDiv;  // リサイクル区分
                                    dstSalesHistDtlWork.RecycleDivNm = srcStockDetailWork.RecycleDivNm;  // リサイクル区分名称
                                    dstSalesHistDtlWork.WayToAcptOdr = srcStockDetailWork.WayToAcptOdr;  // 受注方法
                                    //2009/05/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                    dstSalesHistDtlWork.AutoAnswerDivSCM = srcStockDetailWork.AutoAnswerDivSCM;  // Add 2011/07/23 duzg for 自動回答区分(SCM)追加
                                    // ----- ADD 2011/08/10 ----- >>>>>
                                    dstSalesHistDtlWork.AcceptOrOrderKind = srcStockDetailWork.AcceptOrOrderKind;  // 受発注種別
                                    dstSalesHistDtlWork.InquiryNumber = srcStockDetailWork.InquiryNumber;  // 問合せ番号
                                    dstSalesHistDtlWork.InqRowNumber = srcStockDetailWork.InqRowNumber;  // 問合せ行番号
                                    // ----- ADD 2011/08/10 ----- <<<<<
                                    // ----- ADD 2012/01/23 ----- >>>>>
                                    dstSalesHistDtlWork.GoodsSpecialNote = srcStockDetailWork.GoodsSpecialNote;  // 商品規格・特記事項
                                    // ----- ADD 2012/01/23 ----- <<<<<
                                    //2012/05/07 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                    dstSalesHistDtlWork.RentSyncSupplier = srcStockDetailWork.RentSyncSupplier;  // 貸出同時仕入先
                                    dstSalesHistDtlWork.RentSyncStockDate = srcStockDetailWork.RentSyncStockDate;  // 貸出同時仕入日
                                    dstSalesHistDtlWork.RentSyncSupSlipNo = srcStockDetailWork.RentSyncSupSlipNo;  // 貸出同時仕入伝票番号
                                    //2012/05/07 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                    # endregion

                                    dstSalesHistDtlWorkList.Add(dstSalesHistDtlWork);
                                }
                            }
                        }
                    }
                }
            }

            //--- 売上明細に赤伝区分が追加されたら 上部 に処理を移動する --->>>
            // 赤伝の売上履歴を登録する場合、売上明細履歴の共通ファイルヘッダを初期化する
            if (dstSalesHistDtlWorkList != null && redSlip)
            {
                foreach (SalesHistDtlWork dstSalesHistDtlWork in dstSalesHistDtlWorkList)
                {
                    dstSalesHistDtlWork.CreateDateTime = DateTime.MinValue;
                    dstSalesHistDtlWork.FileHeaderGuid = Guid.Empty;
                    dstSalesHistDtlWork.UpdateDateTime = DateTime.MinValue;
                    dstSalesHistDtlWork.UpdEmployeeCode = "";
                    dstSalesHistDtlWork.UpdAssemblyId1 = "";
                    dstSalesHistDtlWork.UpdAssemblyId2 = "";
                }
            }
            //--- 売上明細に赤伝区分が追加されたら 上部 に処理を移動する ---<<<

            salesHistoryWork = dstSalesHistoryWork;
            salesHistDtlWorks = dstSalesHistDtlWorkList;

            // 売上履歴データの赤伝区分が 2:元黒 の場合、売上明細履歴データが無くても ctDB_NORMAL とする
            if ((dstSalesHistoryWork != null && dstSalesHistDtlWorkList != null) ||
                (dstSalesHistDtlWorkList == null && (dstSalesHistoryWork != null && dstSalesHistoryWork.DebitNoteDiv == 2)))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="salesHistoryWork"></param>
        /// <param name="salesHistDtlWorks"></param>
        /// <returns></returns>
        private int GetSalesHistoryParam(ArrayList paramList, out SalesHistoryWork salesHistoryWork, out ArrayList salesHistDtlWorks)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            salesHistoryWork = null;
            salesHistDtlWorks = null;

            if (paramList != null || paramList.Count > 0)
            {
                foreach (object item in paramList)
                {
                    if (item is SalesHistoryWork)
                    {
                        if (salesHistoryWork == null)
                        {
                            salesHistoryWork = item as SalesHistoryWork;
                        }
                    }
                    else if (item is ArrayList)
                    {
                        if ((item as ArrayList).Count > 0 && (item as ArrayList)[0] is SalesHistDtlWork && salesHistDtlWorks == null)
                        {
                            salesHistDtlWorks = item as ArrayList;
                        }
                    }

                    if (salesHistoryWork != null && salesHistDtlWorks != null)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        break;
                    }
                }
            }

            return status;
        }

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → salesHistoryWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>salesHistoryWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        private SalesHistoryWork CopyToSalesHistoryWorkFromReader(SqlDataReader myReader)
        {
            SalesHistoryWork wkSalesHistoryWork = new SalesHistoryWork();

            this.CopyToSalesHistoryWorkFromReader(myReader, ref wkSalesHistoryWork);

            return wkSalesHistoryWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="salesHistoryWork"></param>
        private void CopyToSalesHistoryWorkFromReader(SqlDataReader myReader, ref SalesHistoryWork salesHistoryWork)
        {
            //＠売上履歴データ変更＠
            if (salesHistoryWork != null)
            {
                #region クラスへ格納
                salesHistoryWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                salesHistoryWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                salesHistoryWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                salesHistoryWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                salesHistoryWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                salesHistoryWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                salesHistoryWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                salesHistoryWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                salesHistoryWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                salesHistoryWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                salesHistoryWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                salesHistoryWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                salesHistoryWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                salesHistoryWork.DebitNLnkSalesSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEBITNLNKSALESSLNUMRF"));
                salesHistoryWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
                salesHistoryWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
                salesHistoryWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
                salesHistoryWork.SalesInpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPSECCDRF"));
                salesHistoryWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
                salesHistoryWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                salesHistoryWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                salesHistoryWork.SalesSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPUPDATECDRF"));
                salesHistoryWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
                salesHistoryWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
                salesHistoryWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                salesHistoryWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                salesHistoryWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
                salesHistoryWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
                salesHistoryWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
                salesHistoryWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
                salesHistoryWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
                salesHistoryWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
                salesHistoryWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
                salesHistoryWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
                salesHistoryWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
                salesHistoryWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                salesHistoryWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
                salesHistoryWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));
                salesHistoryWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
                salesHistoryWork.SalesPrtTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTTOTALTAXINCRF"));
                salesHistoryWork.SalesPrtTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTTOTALTAXEXCRF"));
                salesHistoryWork.SalesWorkTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKTOTALTAXINCRF"));
                salesHistoryWork.SalesWorkTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKTOTALTAXEXCRF"));
                salesHistoryWork.SalesSubtotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXINCRF"));
                salesHistoryWork.SalesSubtotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXEXCRF"));
                salesHistoryWork.SalesPrtSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTSUBTTLINCRF"));
                salesHistoryWork.SalesPrtSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTSUBTTLEXCRF"));
                salesHistoryWork.SalesWorkSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKSUBTTLINCRF"));
                salesHistoryWork.SalesWorkSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKSUBTTLEXCRF"));
                salesHistoryWork.SalesNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESNETPRICERF"));
                salesHistoryWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));
                salesHistoryWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
                salesHistoryWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
                salesHistoryWork.SalSubttlSubToTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALSUBTTLSUBTOTAXFRERF"));
                salesHistoryWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAXRF"));
                salesHistoryWork.SalAmntConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALAMNTCONSTAXINCLURF"));
                salesHistoryWork.SalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXEXCRF"));
                salesHistoryWork.ItdedSalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISOUTTAXRF"));
                salesHistoryWork.ItdedSalesDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISINTAXRF"));
                salesHistoryWork.ItdedPartsDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPARTSDISOUTTAXRF"));
                salesHistoryWork.ItdedPartsDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPARTSDISINTAXRF"));
                salesHistoryWork.ItdedWorkDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDWORKDISOUTTAXRF"));
                salesHistoryWork.ItdedWorkDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDWORKDISINTAXRF"));
                salesHistoryWork.ItdedSalesDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISTAXFRERF"));
                salesHistoryWork.SalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISOUTTAXRF"));
                salesHistoryWork.SalesDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXINCLURF"));
                salesHistoryWork.PartsDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSDISCOUNTRATERF"));
                salesHistoryWork.RavorDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RAVORDISCOUNTRATERF"));
                salesHistoryWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOSTRF"));
                salesHistoryWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                salesHistoryWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
                salesHistoryWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
                salesHistoryWork.AccRecConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCRECCONSTAXRF"));
                salesHistoryWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
                salesHistoryWork.AutoDepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITSLIPNORF"));
                salesHistoryWork.DepositAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));
                salesHistoryWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
                salesHistoryWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                salesHistoryWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
                salesHistoryWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                salesHistoryWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                salesHistoryWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                salesHistoryWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                salesHistoryWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                salesHistoryWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
                salesHistoryWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
                salesHistoryWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPADDRESSDIVRF"));
                salesHistoryWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
                salesHistoryWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
                salesHistoryWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
                salesHistoryWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));
                salesHistoryWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));
                salesHistoryWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));
                salesHistoryWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));
                salesHistoryWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));
                salesHistoryWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));
                salesHistoryWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                salesHistoryWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
                salesHistoryWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
                salesHistoryWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
                salesHistoryWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                salesHistoryWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
                salesHistoryWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
                salesHistoryWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                salesHistoryWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                salesHistoryWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                salesHistoryWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                salesHistoryWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));
                salesHistoryWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
                salesHistoryWork.SalesSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESSLIPPRINTDATERF"));
                salesHistoryWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                salesHistoryWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
                salesHistoryWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));
                salesHistoryWork.DeliveredGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVNMRF"));
                salesHistoryWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                salesHistoryWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
                salesHistoryWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
                salesHistoryWork.CompleteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPLETECDRF"));
                salesHistoryWork.SalesPriceFracProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESPRICEFRACPROCCDRF"));
                salesHistoryWork.StockGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKGOODSTTLTAXEXCRF"));
                salesHistoryWork.PureGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PUREGOODSTTLTAXEXCRF"));
                salesHistoryWork.ListPricePrintDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICEPRINTDIVRF"));
                salesHistoryWork.EraNameDispCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD1RF"));
                #endregion
            }
        }

        /// <summary>
        /// クラス格納処理 Reader → SalesHistDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesHistDtlWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        private SalesHistDtlWork CopyToSalesHistDtlWorkFromReader(ref SqlDataReader myReader)
        {
            SalesHistDtlWork wkSalesHistDtlWork = new SalesHistDtlWork();

            this.CopyToSalesHistDtlWorkFromReader(myReader, ref wkSalesHistDtlWork);

            return wkSalesHistDtlWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="salesSlHistDtlWork"></param>
        private void CopyToSalesHistDtlWorkFromReader(SqlDataReader myReader, ref SalesHistDtlWork salesSlHistDtlWork)
        {
            //＠売上履歴明細データ変更＠
            //salesSlHistDtlWork.<#FieldName> = SqlDataMediator.<#sqlDbTypeGetAccessor>(myReader,myReader.GetOrdinal("<#FIELDRfield.Name>"));               // <#name>
            if (salesSlHistDtlWork != null)
            {
                #region クラスへ格納
                salesSlHistDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));                // 作成日時
                salesSlHistDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));                // 更新日時
                salesSlHistDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));                           // 企業コード
                salesSlHistDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                             // GUID
                salesSlHistDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));                         // 更新従業員コード
                salesSlHistDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));                           // 更新アセンブリID1
                salesSlHistDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));                           // 更新アセンブリID2
                salesSlHistDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));                      // 論理削除区分
                salesSlHistDtlWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));                          // 受注番号
                salesSlHistDtlWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));                          // 受注ステータス
                salesSlHistDtlWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));                               // 売上伝票番号
                salesSlHistDtlWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));                                    // 売上行番号
                salesSlHistDtlWork.SalesRowDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWDERIVNORF"));                          // 売上行番号枝番
                salesSlHistDtlWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));                                 // 拠点コード
                salesSlHistDtlWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));                            // 部門コード
                salesSlHistDtlWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));                       // 売上日付
                salesSlHistDtlWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));                                  // 共通通番
                salesSlHistDtlWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));                          // 売上明細通番
                salesSlHistDtlWork.AcptAnOdrStatusSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSRCRF"));                    // 受注ステータス（元）
                salesSlHistDtlWork.SalesSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSRCRF"));                    // 売上明細通番（元）
                salesSlHistDtlWork.SupplierFormalSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSYNCRF"));                    // 仕入形式（同時）
                salesSlHistDtlWork.StockSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSYNCRF"));                  // 仕入明細通番（同時）
                salesSlHistDtlWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));                            // 売上伝票区分（明細）
                salesSlHistDtlWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));                              // 商品属性
                salesSlHistDtlWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));                                // 商品メーカーコード
                salesSlHistDtlWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));                                     // メーカー名称
                salesSlHistDtlWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));                             // メーカーカナ名称
                salesSlHistDtlWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERKANANAMERF"));                   // メーカーカナ名称（一式）
                salesSlHistDtlWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));                                         // 商品番号
                salesSlHistDtlWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));                                     // 商品名称
                salesSlHistDtlWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));                             // 商品名称カナ
                salesSlHistDtlWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));                                  // 商品大分類コード
                salesSlHistDtlWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));                         // 商品大分類名称
                salesSlHistDtlWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));                                  // 商品中分類コード
                salesSlHistDtlWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));                         // 商品中分類名称
                salesSlHistDtlWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));                                  // BLグループコード
                salesSlHistDtlWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));                                 // BLグループコード名称
                salesSlHistDtlWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));                                  // BL商品コード
                salesSlHistDtlWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));                         // BL商品コード名称（全角）
                salesSlHistDtlWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));                  // 自社分類コード
                salesSlHistDtlWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));                 // 自社分類名称
                salesSlHistDtlWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));                             // 倉庫コード
                salesSlHistDtlWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));                             // 倉庫名称
                salesSlHistDtlWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));                       // 倉庫棚番
                salesSlHistDtlWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));                          // 売上在庫取寄せ区分
                salesSlHistDtlWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));                                // オープン価格区分
                salesSlHistDtlWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));                             // 商品掛率ランク
                salesSlHistDtlWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));                          // 得意先掛率グループコード
                salesSlHistDtlWork.ListPriceRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERATERF"));                             // 定価率
                salesSlHistDtlWork.RateSectPriceUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTPRICEUNPRCRF"));                   // 掛率設定拠点（定価）
                salesSlHistDtlWork.RateDivLPrice = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVLPRICERF"));                             // 掛率設定区分（定価）
                salesSlHistDtlWork.UnPrcCalcCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDLPRICERF"));                      // 単価算出区分（定価）
                salesSlHistDtlWork.PriceCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDLPRICERF"));                              // 価格区分（定価）
                salesSlHistDtlWork.StdUnPrcLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCLPRICERF"));                           // 基準単価（定価）
                salesSlHistDtlWork.FracProcUnitLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITLPRICERF"));                   // 端数処理単位（定価）
                salesSlHistDtlWork.FracProcLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCLPRICERF"));                            // 端数処理（定価）
                salesSlHistDtlWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));                     // 定価（税込，浮動）
                salesSlHistDtlWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));                     // 定価（税抜，浮動）
                salesSlHistDtlWork.ListPriceChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICECHNGCDRF"));                          // 定価変更区分
                salesSlHistDtlWork.SalesRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRATERF"));                                     // 売価率
                salesSlHistDtlWork.RateSectSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSALUNPRCRF"));                       // 掛率設定拠点（売上単価）
                salesSlHistDtlWork.RateDivSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSALUNPRCRF"));                         // 掛率設定区分（売上単価）
                salesSlHistDtlWork.UnPrcCalcCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSALUNPRCRF"));                  // 単価算出区分（売上単価）
                salesSlHistDtlWork.PriceCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSALUNPRCRF"));                          // 価格区分（売上単価）
                salesSlHistDtlWork.StdUnPrcSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSALUNPRCRF"));                       // 基準単価（売上単価）
                salesSlHistDtlWork.FracProcUnitSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSALUNPRCRF"));               // 端数処理単位（売上単価）
                salesSlHistDtlWork.FracProcSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSALUNPRCRF"));                        // 端数処理（売上単価）
                salesSlHistDtlWork.SalesUnPrcTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXINCFLRF"));                   // 売上単価（税込，浮動）
                salesSlHistDtlWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));                   // 売上単価（税抜，浮動）
                salesSlHistDtlWork.SalesUnPrcChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCCHNGCDRF"));                        // 売上単価変更区分
                salesSlHistDtlWork.CostRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("COSTRATERF"));                                       // 原価率
                salesSlHistDtlWork.RateSectCstUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTCSTUNPRCRF"));                       // 掛率設定拠点（原価単価）
                salesSlHistDtlWork.RateDivUnCst = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVUNCSTRF"));                               // 掛率設定区分（原価単価）
                salesSlHistDtlWork.UnPrcCalcCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDUNCSTRF"));                        // 単価算出区分（原価単価）
                salesSlHistDtlWork.PriceCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDUNCSTRF"));                                // 価格区分（原価単価）
                salesSlHistDtlWork.StdUnPrcUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCUNCSTRF"));                             // 基準単価（原価単価）
                salesSlHistDtlWork.FracProcUnitUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITUNCSTRF"));                     // 端数処理単位（原価単価）
                salesSlHistDtlWork.FracProcUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCUNCSTRF"));                              // 端数処理（原価単価）
                salesSlHistDtlWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));                             // 原価単価
                salesSlHistDtlWork.SalesUnitCostChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNITCOSTCHNGDIVRF"));                // 原価単価変更区分
                salesSlHistDtlWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));                          // BL商品コード（掛率）
                salesSlHistDtlWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));                         // BL商品コード名称（掛率）
                salesSlHistDtlWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPCDRF"));                    // 商品掛率グループコード（掛率）
                salesSlHistDtlWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPNMRF"));                   // 商品掛率グループ名称（掛率）
                salesSlHistDtlWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGROUPCODERF"));                          // BLグループコード（掛率）
                salesSlHistDtlWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGROUPNAMERF"));                         // BLグループ名称（掛率）
                salesSlHistDtlWork.PrtBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTBLGOODSCODERF"));                            // BL商品コード（印刷）
                salesSlHistDtlWork.PrtBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTBLGOODSNAMERF"));                           // BL商品コード名称（印刷）
                salesSlHistDtlWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));                                      // 販売区分コード
                salesSlHistDtlWork.SalesCdNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCDNMRF"));                                     // 販売区分名称
                salesSlHistDtlWork.WorkManHour = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("WORKMANHOURRF"));                                 // 作業工数
                salesSlHistDtlWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));                                 // 出荷数
                salesSlHistDtlWork.SalesMoneyTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXINCRF"));                        // 売上金額（税込み）
                salesSlHistDtlWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));                        // 売上金額（税抜き）
                salesSlHistDtlWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));                                                // 原価
                salesSlHistDtlWork.GrsProfitChkDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GRSPROFITCHKDIVRF"));                          // 粗利チェック区分
                salesSlHistDtlWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));                                // 売上商品区分
                salesSlHistDtlWork.SalesPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRICECONSTAXRF"));                      // 売上金額消費税額
                salesSlHistDtlWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));                              // 課税区分
                salesSlHistDtlWork.PartySlipNumDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSLIPNUMDTLRF"));                         // 相手先伝票番号（明細）
                salesSlHistDtlWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));                                         // 明細備考
                salesSlHistDtlWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));                                    // 仕入先コード
                salesSlHistDtlWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));                                 // 仕入先略称
                salesSlHistDtlWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));                                 // 発注番号
                salesSlHistDtlWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDERRF"));                                    // 注文方法
                salesSlHistDtlWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));                                     // 伝票メモ１
                salesSlHistDtlWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));                                     // 伝票メモ２
                salesSlHistDtlWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));                                     // 伝票メモ３
                salesSlHistDtlWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));                                 // 社内メモ１
                salesSlHistDtlWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));                                 // 社内メモ２
                salesSlHistDtlWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));                                 // 社内メモ３
                salesSlHistDtlWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));                                 // 変更前定価
                salesSlHistDtlWork.BfSalesUnitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSALESUNITPRICERF"));                       // 変更前売価
                salesSlHistDtlWork.BfUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFUNITCOSTRF"));                                   // 変更前原価
                salesSlHistDtlWork.CmpltSalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTSALESROWNORF"));                          // 一式明細番号
                salesSlHistDtlWork.CmpltGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTGOODSMAKERCDRF"));                      // メーカーコード（一式）
                salesSlHistDtlWork.CmpltMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERNAMERF"));                           // メーカー名称（一式）
                salesSlHistDtlWork.CmpltGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTGOODSNAMERF"));                           // 商品名称（一式）
                salesSlHistDtlWork.CmpltShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSHIPMENTCNTRF"));                       // 数量（一式）
                salesSlHistDtlWork.CmpltSalesUnPrcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNPRCFLRF"));                     // 売上単価（一式）
                salesSlHistDtlWork.CmpltSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTSALESMONEYRF"));                          // 売上金額（一式）
                salesSlHistDtlWork.CmpltSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNITCOSTRF"));                   // 原価単価（一式）
                salesSlHistDtlWork.CmpltCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTCOSTRF"));                                      // 原価金額（一式）
                salesSlHistDtlWork.CmpltPartySalSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTPARTYSALSLNUMRF"));                   // 相手先伝票番号（一式）
                salesSlHistDtlWork.CmpltNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTNOTERF"));                                     // 一式備考
                salesSlHistDtlWork.PrtGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTGOODSNORF"));                                   // 印刷用品番
                salesSlHistDtlWork.PrtMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTMAKERCODERF"));                                // 印刷用メーカーコード
                salesSlHistDtlWork.PrtMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTMAKERNAMERF"));                               // 印刷用メーカー名称
                // 2009/05/18 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                salesSlHistDtlWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));  // キャンペーンコード
                salesSlHistDtlWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF"));  // キャンペーン名称
                salesSlHistDtlWork.GoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSDIVCDRF"));  // 商品種別
                salesSlHistDtlWork.AnswerDelivDate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATERF"));  // 回答納期
                salesSlHistDtlWork.RecycleDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECYCLEDIVRF"));  // リサイクル区分
                salesSlHistDtlWork.RecycleDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECYCLEDIVNMRF"));  // リサイクル区分名称
                salesSlHistDtlWork.WayToAcptOdr = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOACPTODRRF"));  // 受注方法
                // 2009/05/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                salesSlHistDtlWork.AutoAnswerDivSCM = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERDIVSCMRF"));  // add 2011/07/23 duz
                // -- ADD 2012/01/23   ------ >>>>>>
                salesSlHistDtlWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));  // 特記事項
                // -- ADD 2012/01/23   ------ <<<<<<
                //2012/05/07 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                salesSlHistDtlWork.RentSyncSupplier = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RENTSYNCSUPPLIERRF"));  // 貸出同時仕入先
                salesSlHistDtlWork.RentSyncStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RENTSYNCSTOCKDATERF"));  // 貸出同時仕入日
                salesSlHistDtlWork.RentSyncSupSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RENTSYNCSUPSLIPNORF"));  // 貸出同時仕入伝票番号
                //2012/05/07 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                #endregion
            }
        }
        #endregion
    }
}
