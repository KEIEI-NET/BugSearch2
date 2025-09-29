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
//　　仕入履歴データ　　 → ＠仕入履歴データ変更＠
//　　仕入履歴明細データ → ＠仕入履歴明細データ変更＠
//■─────────────────────────────────────────────■
/// <br>--------------------------------------</br>
/// <br>Note             :   連番966 仕入明細マスタの同時売上情報をクリアする。</br>
/// <br>Programmer       :   許雁波</br>
/// <br>Date             :   2011/08/16</br>
namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入履歴データDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入履歴データの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.10.24</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class StockSlipHistDB : RemoteWithAppLockDB, IStockSlipHistDB
    {
        /// <summary>
        /// 仕入履歴データDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        public StockSlipHistDB()
            :
            base("DCKOU01066D", "Broadleaf.Application.Remoting.ParamData.StockHistoryWork", "STOCKHISTORYRF")
        {
        }

        #region [Read]
        
        /// <summary>
        /// 指定された条件に合致する仕入履歴データと仕入明細履歴データを取得します。
        /// </summary>
        /// <param name="stockhistoryWork">検索条件と取得値を兼ねた StockHistoryWork</param>
        /// <param name="stockhistdtlWorkList">検索条件と取得値を兼ねた StockhistdtlWork が格納されている ArrayList</param>
        /// <param name="readMode">0:仕入履歴のみで検索  1:仕入明細履歴も使用して検索</param>
        /// <returns>STATUS</returns>
        public int Read(ref StockSlipHistWork stockhistoryWork, ref ArrayList stockhistdtlWorkList, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlConnection sqlConnection = null;
            try
            {
                //コネクション生成
                //sqlConnection = CreateSqlConnection();         //DEL 2008/06/03 M.Kubota
                sqlConnection = this.CreateSqlConnection(true);  //ADD 2008/06/03 M.Kubota

                if (sqlConnection != null)
                {
                    //sqlConnection.Open();  //DEL 2008/06/03 M.Kubota
                    SqlTransaction dummyTran = null;
                    status = ReadProc(ref stockhistoryWork, ref stockhistdtlWorkList, readMode, ref sqlConnection, ref dummyTran);
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
        /// 指定された条件に合致する仕入履歴データと仕入明細履歴データを取得します。
        /// </summary>
        /// <param name="stockhistoryWork">検索条件と取得値を兼ねた StockHistoryWork</param>
        /// <param name="stockhistdtlWorkList">検索条件と取得値を兼ねた StockhistdtlWork が格納されている ArrayList</param>
        /// <param name="readMode">0:仕入履歴のみで検索  1:仕入明細履歴も使用して検索</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int ReadProc(ref StockSlipHistWork stockhistoryWork, ref ArrayList stockhistdtlWorkList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            
            status = this.ReadStockSlipHist(ref stockhistoryWork, readMode, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (stockhistdtlWorkList != null && stockhistdtlWorkList.Count > 0 && stockhistdtlWorkList[0] is StockSlHistDtlWork && readMode == 1)
                {
                    status = this.ReadStockSlHistDtl(ref stockhistdtlWorkList, readMode, ref sqlConnection, ref sqlTransaction);
                }
                else
                {
                    status = this.ReadStockSlHistDtl(out stockhistdtlWorkList, stockhistoryWork, readMode, ref sqlConnection, ref sqlTransaction);
                }
            }
            
            return status;
        }

        /// <summary>
        /// 指定された条件に合致する仕入履歴データを取得します。
        /// </summary>
        /// <param name="stockhistoryWork">検索条件と取得値を兼ねる StockHistoryWork オブジェクト</param>
        /// <param name="readMode">検索区分 ※現時点では未使用</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int ReadStockSlipHist(ref StockSlipHistWork stockhistoryWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadStockSlipHistProc(ref stockhistoryWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件に合致する仕入履歴データを取得します。
        /// </summary>
        /// <param name="stockhistoryWork">検索条件と取得値を兼ねる StockHistoryWork オブジェクト</param>
        /// <param name="readMode">検索区分 ※現時点では未使用</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        private int ReadStockSlipHistProc(ref StockSlipHistWork stockhistoryWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            if (stockhistoryWork != null)
            {
                SqlDataReader myReader = null;

                try
                {
                    #region [SELECT文]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  SLPHIST.*" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLIPHISTRF AS SLPHIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  SLPHIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SLPHIST.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND SLPHIST.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
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
                        SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                        SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                        findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                        findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            this.CopyToStockHistoryWorkFromReader(myReader, ref stockhistoryWork);
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
        /// 指定された条件に合致する仕入履歴データに紐付く仕入明細履歴データを取得します。
        /// </summary>
        /// <param name="stockhistdtlWorkList">取得した StockHistDtlWork が格納される ArrayList</param>
        /// <param name="stockhistoryWork">検索条件となる StockHistoryWork オブジェクト</param>
        /// <param name="readMode">検索区分 ※現時点では未使用</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// 仕入伝票番号(＋仕入形式)で仕入明細履歴を取得したい場合に使用する。
        /// </remarks>
        public int ReadStockSlHistDtl(out ArrayList stockhistdtlWorkList, StockSlipHistWork stockhistoryWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadStockSlHistDtlProc(out stockhistdtlWorkList, stockhistoryWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件に合致する仕入履歴データに紐付く仕入明細履歴データを取得します。
        /// </summary>
        /// <param name="stockhistdtlWorkList">取得した StockHistDtlWork が格納される ArrayList</param>
        /// <param name="stockhistoryWork">検索条件となる StockHistoryWork オブジェクト</param>
        /// <param name="readMode">検索区分 ※現時点では未使用</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// 仕入伝票番号(＋仕入形式)で仕入明細履歴を取得したい場合に使用する。
        /// </remarks>
        private int ReadStockSlHistDtlProc(out ArrayList stockhistdtlWorkList, StockSlipHistWork stockhistoryWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            stockhistdtlWorkList = new ArrayList();

            if (stockhistoryWork != null)
            {
                SqlDataReader myReader = null;

                try
                {
                    #region [SELECT文]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  DTIL.*" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLIPHISTRF AS HIST INNER JOIN STOCKSLHISTDTLRF AS DTIL" + Environment.NewLine;
                    sqlText += "  ON  HIST.ENTERPRISECODERF = DTIL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERFORMALRF = DTIL.SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERSLIPNORF = DTIL.SUPPLIERSLIPNORF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
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
                        SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                        SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                        findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                        findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            stockhistdtlWorkList.Add(CopyToStockHistDtlWorkFromReader(myReader));
                        }

                        if (stockhistdtlWorkList.Count > 0)
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
        /// 指定された条件に合致する仕入明細履歴データを取得します。
        /// </summary>
        /// <param name="stockhistdtlWorkList">検索条件と取得値を兼ねる StockHistDtlWork が格納された ArrayList</param>
        /// <param name="readMode">検索区分 ※現時点では未使用</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// 仕入明細通番(＋仕入形式)で仕入明細履歴を取得したい場合に使用する。
        /// </remarks>
        public int ReadStockSlHistDtl(ref ArrayList stockhistdtlWorkList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadStockSlHistDtlProc(ref stockhistdtlWorkList, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件に合致する仕入明細履歴データを取得します。
        /// </summary>
        /// <param name="stockhistdtlWorkList">検索条件と取得値を兼ねる StockHistDtlWork が格納された ArrayList</param>
        /// <param name="readMode">検索区分 ※現時点では未使用</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// 仕入明細通番(＋仕入形式)で仕入明細履歴を取得したい場合に使用する。
        /// </remarks>
        private int ReadStockSlHistDtlProc(ref ArrayList stockhistdtlWorkList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            if (stockhistdtlWorkList != null && stockhistdtlWorkList.Count > 0 && stockhistdtlWorkList[0] is StockSlHistDtlWork)
            {
                SqlDataReader myReader = null;

                try
                {
                    #region [SELECT文]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  DTIL.*" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLHISTDTLRF AS DTIL" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND DTIL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND DTIL.STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
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
                        SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);       // 仕入形式
                        SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);  // 仕入明細通番

                        int hitCount = 0;
                        
                        foreach (object item in stockhistdtlWorkList)
                        {
                            StockSlHistDtlWork dtlwork = item as StockSlHistDtlWork;

                            if (dtlwork != null)
                            {
                                //Parameterオブジェクトへ値設定
                                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(dtlwork.EnterpriseCode);
                                findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(dtlwork.SupplierFormal);
                                findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(dtlwork.StockSlipDtlNum);

                                try
                                {
                                    myReader = sqlCommand.ExecuteReader();

                                    if (myReader.Read())
                                    {
                                        this.CopyToStockHistDtlWorkFromReader(myReader, ref dtlwork);
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
        #endregion

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

            StockSlipHistWork stockHistoryWork = null;
            ArrayList stockhistdtlWorkList = null;

            status = this.MakeStockHistoryParam(paramList, out stockHistoryWork, out stockhistdtlWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (stockHistoryWork != null)
                {
                    paramList.Add(stockHistoryWork);
                }

                if (stockhistdtlWorkList != null && stockhistdtlWorkList.Count > 0)
                {
                    paramList.Add(stockhistdtlWorkList);
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

            StockSlipHistWork stockHistoryWork = null;
            ArrayList stockhistdtlWorkList = null;

            status = this.MakeStockHistoryParam(paramList, out stockHistoryWork, out stockhistdtlWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (stockHistoryWork != null)
                {
                    // 既に仕入履歴が登録されている場合は一度読み込む
                    if (stockHistoryWork.SupplierSlipNo > 0)
                    {
                        status = this.ReadStockSlipHist(ref stockHistoryWork, 0, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }

                    paramList.Add(stockHistoryWork);
                }

                if (stockhistdtlWorkList != null && stockhistdtlWorkList.Count > 0)
                {
                    // 既に仕入履歴明細が登録されている場合は一度読み込む
                    if ((stockhistdtlWorkList[0] as StockSlHistDtlWork).StockSlipDtlNum > 0)
                    {
                        status = this.ReadStockSlHistDtl(ref stockhistdtlWorkList, 0, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }

                    paramList.Add(stockhistdtlWorkList);
                }
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="stockHistoryWork"></param>
        /// <param name="stockHistDtlWorks"></param>
        /// <returns></returns>
        private int MakeStockHistoryParam(ArrayList paramList, out StockSlipHistWork stockHistoryWork, out ArrayList stockHistDtlWorks)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            StockSlipHistWork dstStockHistoryWork = null;
            ArrayList dstStockhistdtlWorkList = null;

            bool redSlip = true;

            if (paramList != null && paramList.Count > 0)
            {
                foreach (object item in paramList)
                {
                    if (item is StockSlipWork)
                    {
                        if (dstStockHistoryWork == null)
                        {
                            StockSlipWork srcStockSlipWork = item as StockSlipWork;
                            dstStockHistoryWork = new StockSlipHistWork();

                            //＠仕入履歴データ変更＠
                            //dstStockHistoryWork.<#FieldName> = srcStockSlipWork.<#FieldName>;
                            # region [StockHistoryWork(仕入履歴データ) ← StockSlipWork(仕入データ)]
                            // 仕入履歴データ・仕入データのレイアウト変更が発生した場合は要修正

                            // 赤伝の場合は新規追加しかないので共通ファイルヘッダ部分を設定しない
                            if (srcStockSlipWork.DebitNoteDiv != 1)
                            {
                                redSlip = false;

                                dstStockHistoryWork.CreateDateTime = srcStockSlipWork.CreateDateTime;
                                dstStockHistoryWork.FileHeaderGuid = srcStockSlipWork.FileHeaderGuid;
                                dstStockHistoryWork.UpdateDateTime = srcStockSlipWork.UpdateDateTime;
                                dstStockHistoryWork.UpdEmployeeCode = srcStockSlipWork.UpdEmployeeCode;
                                dstStockHistoryWork.UpdAssemblyId1 = srcStockSlipWork.UpdAssemblyId1;
                                dstStockHistoryWork.UpdAssemblyId2 = srcStockSlipWork.UpdAssemblyId2;
                            }

                            dstStockHistoryWork.EnterpriseCode = srcStockSlipWork.EnterpriseCode;
                            dstStockHistoryWork.LogicalDeleteCode = srcStockSlipWork.LogicalDeleteCode;
                            dstStockHistoryWork.SupplierFormal = srcStockSlipWork.SupplierFormal;
                            dstStockHistoryWork.SupplierSlipNo = srcStockSlipWork.SupplierSlipNo;
                            dstStockHistoryWork.SectionCode = srcStockSlipWork.SectionCode;
                            dstStockHistoryWork.SubSectionCode = srcStockSlipWork.SubSectionCode;
                            dstStockHistoryWork.DebitNoteDiv = srcStockSlipWork.DebitNoteDiv;
                            dstStockHistoryWork.DebitNLnkSuppSlipNo = srcStockSlipWork.DebitNLnkSuppSlipNo;
                            dstStockHistoryWork.SupplierSlipCd = srcStockSlipWork.SupplierSlipCd;
                            dstStockHistoryWork.StockGoodsCd = srcStockSlipWork.StockGoodsCd;
                            dstStockHistoryWork.AccPayDivCd = srcStockSlipWork.AccPayDivCd;
                            dstStockHistoryWork.StockSectionCd = srcStockSlipWork.StockSectionCd;
                            dstStockHistoryWork.StockAddUpSectionCd = srcStockSlipWork.StockAddUpSectionCd;
                            dstStockHistoryWork.StockSlipUpdateCd = srcStockSlipWork.StockSlipUpdateCd;
                            dstStockHistoryWork.InputDay = srcStockSlipWork.InputDay;
                            dstStockHistoryWork.ArrivalGoodsDay = srcStockSlipWork.ArrivalGoodsDay;
                            dstStockHistoryWork.StockDate = srcStockSlipWork.StockDate;
                            dstStockHistoryWork.StockAddUpADate = srcStockSlipWork.StockAddUpADate;
                            dstStockHistoryWork.DelayPaymentDiv = srcStockSlipWork.DelayPaymentDiv;
                            dstStockHistoryWork.PayeeCode = srcStockSlipWork.PayeeCode;
                            dstStockHistoryWork.PayeeSnm = srcStockSlipWork.PayeeSnm;
                            dstStockHistoryWork.SupplierCd = srcStockSlipWork.SupplierCd;
                            dstStockHistoryWork.SupplierNm1 = srcStockSlipWork.SupplierNm1;
                            dstStockHistoryWork.SupplierNm2 = srcStockSlipWork.SupplierNm2;
                            dstStockHistoryWork.SupplierSnm = srcStockSlipWork.SupplierSnm;
                            dstStockHistoryWork.BusinessTypeCode = srcStockSlipWork.BusinessTypeCode;
                            dstStockHistoryWork.BusinessTypeName = srcStockSlipWork.BusinessTypeName;
                            dstStockHistoryWork.SalesAreaCode = srcStockSlipWork.SalesAreaCode;
                            dstStockHistoryWork.SalesAreaName = srcStockSlipWork.SalesAreaName;
                            dstStockHistoryWork.StockInputCode = srcStockSlipWork.StockInputCode;
                            dstStockHistoryWork.StockInputName = srcStockSlipWork.StockInputName;
                            dstStockHistoryWork.StockAgentCode = srcStockSlipWork.StockAgentCode;
                            dstStockHistoryWork.StockAgentName = srcStockSlipWork.StockAgentName;
                            dstStockHistoryWork.SuppTtlAmntDspWayCd = srcStockSlipWork.SuppTtlAmntDspWayCd;
                            dstStockHistoryWork.TtlAmntDispRateApy = srcStockSlipWork.TtlAmntDispRateApy;
                            dstStockHistoryWork.StockTotalPrice = srcStockSlipWork.StockTotalPrice;
                            dstStockHistoryWork.StockSubttlPrice = srcStockSlipWork.StockSubttlPrice;
                            dstStockHistoryWork.StockTtlPricTaxInc = srcStockSlipWork.StockTtlPricTaxInc;
                            dstStockHistoryWork.StockTtlPricTaxExc = srcStockSlipWork.StockTtlPricTaxExc;
                            dstStockHistoryWork.StockNetPrice = srcStockSlipWork.StockNetPrice;
                            dstStockHistoryWork.StockPriceConsTax = srcStockSlipWork.StockPriceConsTax;
                            dstStockHistoryWork.TtlItdedStcOutTax = srcStockSlipWork.TtlItdedStcOutTax;
                            dstStockHistoryWork.TtlItdedStcInTax = srcStockSlipWork.TtlItdedStcInTax;
                            dstStockHistoryWork.TtlItdedStcTaxFree = srcStockSlipWork.TtlItdedStcTaxFree;
                            dstStockHistoryWork.StockOutTax = srcStockSlipWork.StockOutTax;
                            dstStockHistoryWork.StckPrcConsTaxInclu = srcStockSlipWork.StckPrcConsTaxInclu;
                            dstStockHistoryWork.StckDisTtlTaxExc = srcStockSlipWork.StckDisTtlTaxExc;
                            dstStockHistoryWork.ItdedStockDisOutTax = srcStockSlipWork.ItdedStockDisOutTax;
                            dstStockHistoryWork.ItdedStockDisInTax = srcStockSlipWork.ItdedStockDisInTax;
                            dstStockHistoryWork.ItdedStockDisTaxFre = srcStockSlipWork.ItdedStockDisTaxFre;
                            dstStockHistoryWork.StockDisOutTax = srcStockSlipWork.StockDisOutTax;
                            dstStockHistoryWork.StckDisTtlTaxInclu = srcStockSlipWork.StckDisTtlTaxInclu;
                            dstStockHistoryWork.TaxAdjust = srcStockSlipWork.TaxAdjust;
                            dstStockHistoryWork.BalanceAdjust = srcStockSlipWork.BalanceAdjust;
                            dstStockHistoryWork.SuppCTaxLayCd = srcStockSlipWork.SuppCTaxLayCd;
                            dstStockHistoryWork.SupplierConsTaxRate = srcStockSlipWork.SupplierConsTaxRate;
                            dstStockHistoryWork.AccPayConsTax = srcStockSlipWork.AccPayConsTax;
                            dstStockHistoryWork.StockFractionProcCd = srcStockSlipWork.StockFractionProcCd;
                            dstStockHistoryWork.AutoPayment = srcStockSlipWork.AutoPayment;
                            dstStockHistoryWork.AutoPaySlipNum = srcStockSlipWork.AutoPaySlipNum;
                            dstStockHistoryWork.RetGoodsReasonDiv = srcStockSlipWork.RetGoodsReasonDiv;
                            dstStockHistoryWork.RetGoodsReason = srcStockSlipWork.RetGoodsReason;
                            dstStockHistoryWork.PartySaleSlipNum = srcStockSlipWork.PartySaleSlipNum;
                            dstStockHistoryWork.SupplierSlipNote1 = srcStockSlipWork.SupplierSlipNote1;
                            dstStockHistoryWork.SupplierSlipNote2 = srcStockSlipWork.SupplierSlipNote2;
                            dstStockHistoryWork.DetailRowCount = srcStockSlipWork.DetailRowCount;
                            dstStockHistoryWork.EdiSendDate = srcStockSlipWork.EdiSendDate;
                            dstStockHistoryWork.EdiTakeInDate = srcStockSlipWork.EdiTakeInDate;
                            dstStockHistoryWork.UoeRemark1 = srcStockSlipWork.UoeRemark1;
                            dstStockHistoryWork.UoeRemark2 = srcStockSlipWork.UoeRemark2;
                            dstStockHistoryWork.SlipPrintDivCd = srcStockSlipWork.SlipPrintDivCd;
                            dstStockHistoryWork.SlipPrintFinishCd = srcStockSlipWork.SlipPrintFinishCd;
                            dstStockHistoryWork.StockSlipPrintDate = srcStockSlipWork.StockSlipPrintDate;
                            dstStockHistoryWork.SlipPrtSetPaperId = srcStockSlipWork.SlipPrtSetPaperId;

                            # endregion
                        }
                    }
                    else if (item is StockSlipDeleteWork)
                    {
                        if (dstStockHistoryWork == null)
                        {
                            StockSlipDeleteWork srcStockSlipDeleteWork = item as StockSlipDeleteWork;
                            dstStockHistoryWork = new StockSlipHistWork();

                            //＠仕入履歴データ変更＠
                            # region [StockHistoryWork(仕入履歴データ) ← StockSlipDeleteWork(仕入削除データ)]

                            // 赤伝の場合は新規追加しかないので共通ファイルヘッダ部分を設定しない
                            if (srcStockSlipDeleteWork.DebitNoteDiv != 1)
                            {
                                redSlip = false;
                                dstStockHistoryWork.UpdateDateTime = srcStockSlipDeleteWork.UpdateDateTime;
                            }
                           
                            dstStockHistoryWork.EnterpriseCode = srcStockSlipDeleteWork.EnterpriseCode;
                            dstStockHistoryWork.SupplierFormal = srcStockSlipDeleteWork.SupplierFormal;
                            dstStockHistoryWork.SupplierSlipNo = srcStockSlipDeleteWork.SupplierSlipNo;
                            dstStockHistoryWork.DebitNoteDiv = srcStockSlipDeleteWork.DebitNoteDiv;
                            # endregion

                            if (srcStockSlipDeleteWork.SupplierFormal != 2)
                            {
                                dstStockhistdtlWorkList = new ArrayList();
                            }
                        }
                    }
                    else if (item is ArrayList)
                    {
                        if ((item as ArrayList)[0] is StockDetailWork)
                        {
                            if (dstStockhistdtlWorkList == null)
                            {
                                dstStockhistdtlWorkList = new ArrayList();

                                foreach (StockDetailWork srcStockDetailWork in (item as ArrayList))
                                {
                                    StockSlHistDtlWork dstStockHistDtlWork = new StockSlHistDtlWork();

                                    //＠仕入履歴明細データ変更＠
                                    //dstStockHistDtlWork.<#FieldName> = srcStockDetailWork.<#FieldName>;
                                    # region [StockHistDtlWork(仕入履歴明細データ) ← StockDetailWork(仕入明細データ)]
                                    // 仕入履歴明細データ・仕入明細データのレイアウト変更が発生した場合は要修正
                                    dstStockHistDtlWork.CreateDateTime = srcStockDetailWork.CreateDateTime;
                                    dstStockHistDtlWork.UpdateDateTime = srcStockDetailWork.UpdateDateTime;
                                    dstStockHistDtlWork.EnterpriseCode = srcStockDetailWork.EnterpriseCode;
                                    dstStockHistDtlWork.FileHeaderGuid = srcStockDetailWork.FileHeaderGuid;
                                    dstStockHistDtlWork.UpdEmployeeCode = srcStockDetailWork.UpdEmployeeCode;
                                    dstStockHistDtlWork.UpdAssemblyId1 = srcStockDetailWork.UpdAssemblyId1;
                                    dstStockHistDtlWork.UpdAssemblyId2 = srcStockDetailWork.UpdAssemblyId2;
                                    dstStockHistDtlWork.LogicalDeleteCode = srcStockDetailWork.LogicalDeleteCode;
                                    dstStockHistDtlWork.AcceptAnOrderNo = srcStockDetailWork.AcceptAnOrderNo;
                                    dstStockHistDtlWork.SupplierFormal = srcStockDetailWork.SupplierFormal;
                                    dstStockHistDtlWork.SupplierSlipNo = srcStockDetailWork.SupplierSlipNo;
                                    dstStockHistDtlWork.StockRowNo = srcStockDetailWork.StockRowNo;
                                    dstStockHistDtlWork.SectionCode = srcStockDetailWork.SectionCode;
                                    dstStockHistDtlWork.SubSectionCode = srcStockDetailWork.SubSectionCode;
                                    dstStockHistDtlWork.CommonSeqNo = srcStockDetailWork.CommonSeqNo;
                                    dstStockHistDtlWork.StockSlipDtlNum = srcStockDetailWork.StockSlipDtlNum;
                                    dstStockHistDtlWork.SupplierFormalSrc = srcStockDetailWork.SupplierFormalSrc;
                                    dstStockHistDtlWork.StockSlipDtlNumSrc = srcStockDetailWork.StockSlipDtlNumSrc;
                                    dstStockHistDtlWork.AcptAnOdrStatusSync = srcStockDetailWork.AcptAnOdrStatusSync;
                                    dstStockHistDtlWork.SalesSlipDtlNumSync = srcStockDetailWork.SalesSlipDtlNumSync;
                                    dstStockHistDtlWork.StockSlipCdDtl = srcStockDetailWork.StockSlipCdDtl;
                                    dstStockHistDtlWork.StockAgentCode = srcStockDetailWork.StockAgentCode;
                                    dstStockHistDtlWork.StockAgentName = srcStockDetailWork.StockAgentName;
                                    dstStockHistDtlWork.GoodsKindCode = srcStockDetailWork.GoodsKindCode;
                                    dstStockHistDtlWork.GoodsMakerCd = srcStockDetailWork.GoodsMakerCd;
                                    dstStockHistDtlWork.MakerName = srcStockDetailWork.MakerName;
                                    dstStockHistDtlWork.MakerKanaName = srcStockDetailWork.MakerKanaName;
                                    dstStockHistDtlWork.CmpltMakerKanaName = srcStockDetailWork.CmpltMakerKanaName;
                                    dstStockHistDtlWork.GoodsNo = srcStockDetailWork.GoodsNo;
                                    dstStockHistDtlWork.GoodsName = srcStockDetailWork.GoodsName;
                                    dstStockHistDtlWork.GoodsNameKana = srcStockDetailWork.GoodsNameKana;
                                    dstStockHistDtlWork.GoodsLGroup = srcStockDetailWork.GoodsLGroup;
                                    dstStockHistDtlWork.GoodsLGroupName = srcStockDetailWork.GoodsLGroupName;
                                    dstStockHistDtlWork.GoodsMGroup = srcStockDetailWork.GoodsMGroup;
                                    dstStockHistDtlWork.GoodsMGroupName = srcStockDetailWork.GoodsMGroupName;
                                    dstStockHistDtlWork.BLGroupCode = srcStockDetailWork.BLGroupCode;
                                    dstStockHistDtlWork.BLGroupName = srcStockDetailWork.BLGroupName;
                                    dstStockHistDtlWork.BLGoodsCode = srcStockDetailWork.BLGoodsCode;
                                    dstStockHistDtlWork.BLGoodsFullName = srcStockDetailWork.BLGoodsFullName;
                                    dstStockHistDtlWork.EnterpriseGanreCode = srcStockDetailWork.EnterpriseGanreCode;
                                    dstStockHistDtlWork.EnterpriseGanreName = srcStockDetailWork.EnterpriseGanreName;
                                    dstStockHistDtlWork.WarehouseCode = srcStockDetailWork.WarehouseCode;
                                    dstStockHistDtlWork.WarehouseName = srcStockDetailWork.WarehouseName;
                                    dstStockHistDtlWork.WarehouseShelfNo = srcStockDetailWork.WarehouseShelfNo;
                                    dstStockHistDtlWork.StockOrderDivCd = srcStockDetailWork.StockOrderDivCd;
                                    dstStockHistDtlWork.OpenPriceDiv = srcStockDetailWork.OpenPriceDiv;
                                    dstStockHistDtlWork.GoodsRateRank = srcStockDetailWork.GoodsRateRank;
                                    dstStockHistDtlWork.CustRateGrpCode = srcStockDetailWork.CustRateGrpCode;
                                    dstStockHistDtlWork.SuppRateGrpCode = srcStockDetailWork.SuppRateGrpCode;
                                    dstStockHistDtlWork.ListPriceTaxExcFl = srcStockDetailWork.ListPriceTaxExcFl;
                                    dstStockHistDtlWork.ListPriceTaxIncFl = srcStockDetailWork.ListPriceTaxIncFl;
                                    dstStockHistDtlWork.StockRate = srcStockDetailWork.StockRate;
                                    dstStockHistDtlWork.RateSectStckUnPrc = srcStockDetailWork.RateSectStckUnPrc;
                                    dstStockHistDtlWork.RateDivStckUnPrc = srcStockDetailWork.RateDivStckUnPrc;
                                    dstStockHistDtlWork.UnPrcCalcCdStckUnPrc = srcStockDetailWork.UnPrcCalcCdStckUnPrc;
                                    dstStockHistDtlWork.PriceCdStckUnPrc = srcStockDetailWork.PriceCdStckUnPrc;
                                    dstStockHistDtlWork.StdUnPrcStckUnPrc = srcStockDetailWork.StdUnPrcStckUnPrc;
                                    dstStockHistDtlWork.FracProcUnitStcUnPrc = srcStockDetailWork.FracProcUnitStcUnPrc;
                                    dstStockHistDtlWork.FracProcStckUnPrc = srcStockDetailWork.FracProcStckUnPrc;
                                    dstStockHistDtlWork.StockUnitPriceFl = srcStockDetailWork.StockUnitPriceFl;
                                    dstStockHistDtlWork.StockUnitTaxPriceFl = srcStockDetailWork.StockUnitTaxPriceFl;
                                    dstStockHistDtlWork.StockUnitChngDiv = srcStockDetailWork.StockUnitChngDiv;
                                    dstStockHistDtlWork.BfStockUnitPriceFl = srcStockDetailWork.BfStockUnitPriceFl;
                                    dstStockHistDtlWork.BfListPrice = srcStockDetailWork.BfListPrice;
                                    dstStockHistDtlWork.RateBLGoodsCode = srcStockDetailWork.RateBLGoodsCode;
                                    dstStockHistDtlWork.RateBLGoodsName = srcStockDetailWork.RateBLGoodsName;
                                    dstStockHistDtlWork.RateGoodsRateGrpCd = srcStockDetailWork.RateGoodsRateGrpCd;
                                    dstStockHistDtlWork.RateGoodsRateGrpNm = srcStockDetailWork.RateGoodsRateGrpNm;
                                    dstStockHistDtlWork.RateBLGroupCode = srcStockDetailWork.RateBLGroupCode;
                                    dstStockHistDtlWork.RateBLGroupName = srcStockDetailWork.RateBLGroupName;
                                    dstStockHistDtlWork.StockCount = srcStockDetailWork.StockCount;
                                    dstStockHistDtlWork.StockPriceTaxExc = srcStockDetailWork.StockPriceTaxExc;
                                    dstStockHistDtlWork.StockPriceTaxInc = srcStockDetailWork.StockPriceTaxInc;
                                    dstStockHistDtlWork.StockGoodsCd = srcStockDetailWork.StockGoodsCd;
                                    dstStockHistDtlWork.StockPriceConsTax = srcStockDetailWork.StockPriceConsTax;
                                    dstStockHistDtlWork.TaxationCode = srcStockDetailWork.TaxationCode;
                                    dstStockHistDtlWork.StockDtiSlipNote1 = srcStockDetailWork.StockDtiSlipNote1;
                                    dstStockHistDtlWork.SalesCustomerCode = srcStockDetailWork.SalesCustomerCode;
                                    dstStockHistDtlWork.SalesCustomerSnm = srcStockDetailWork.SalesCustomerSnm;
                                    dstStockHistDtlWork.OrderNumber = srcStockDetailWork.OrderNumber;
                                    dstStockHistDtlWork.SlipMemo1 = srcStockDetailWork.SlipMemo1;
                                    dstStockHistDtlWork.SlipMemo2 = srcStockDetailWork.SlipMemo2;
                                    dstStockHistDtlWork.SlipMemo3 = srcStockDetailWork.SlipMemo3;
                                    dstStockHistDtlWork.InsideMemo1 = srcStockDetailWork.InsideMemo1;
                                    dstStockHistDtlWork.InsideMemo2 = srcStockDetailWork.InsideMemo2;
                                    dstStockHistDtlWork.InsideMemo3 = srcStockDetailWork.InsideMemo3;
                                    # endregion

                                    dstStockhistdtlWorkList.Add(dstStockHistDtlWork);
                                }
                            }
                        }
                    }
                }
            }

            //--- 仕入明細に赤伝区分が追加されたら 上部 に処理を移動する --->>>
            // 赤伝の仕入履歴を登録する場合、仕入明細履歴の共通ファイルヘッダを初期化する
            if (dstStockhistdtlWorkList != null && redSlip)
            {
                foreach (StockSlHistDtlWork dstStockHistDtlWork in dstStockhistdtlWorkList)
                {
                    dstStockHistDtlWork.CreateDateTime = DateTime.MinValue;
                    dstStockHistDtlWork.FileHeaderGuid = Guid.Empty;
                    dstStockHistDtlWork.UpdateDateTime = DateTime.MinValue;
                    dstStockHistDtlWork.UpdEmployeeCode = "";
                    dstStockHistDtlWork.UpdAssemblyId1 = "";
                    dstStockHistDtlWork.UpdAssemblyId2 = "";
                }
            }
            //--- 仕入明細に赤伝区分が追加されたら 上部 に処理を移動する ---<<<

            stockHistoryWork = dstStockHistoryWork;
            stockHistDtlWorks = dstStockhistdtlWorkList;

            // 仕入履歴データの赤伝区分が 2:元黒 の場合、仕入明細履歴データが無くても ctDB_NORMAL とする
            // 2009/02/18 入庫更新対応>>>>>>>>>>>>>>>>>>>>>>
            // 発注データの場合はノーマルとする
            //if ((dstStockHistoryWork != null && dstStockhistdtlWorkList != null) ||
            //    (dstStockhistdtlWorkList == null && (dstStockHistoryWork != null && dstStockHistoryWork.DebitNoteDiv == 2)))
            if ((dstStockHistoryWork != null && dstStockhistdtlWorkList != null) ||
                (dstStockhistdtlWorkList == null && (dstStockHistoryWork != null && dstStockHistoryWork.DebitNoteDiv == 2)) ||
                (dstStockHistoryWork != null && dstStockHistoryWork.SupplierFormal == 2))
            // 2009/02/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="stockHistoryWork"></param>
        /// <param name="stockHistDtlWorks"></param>
        /// <returns></returns>
        private int GetStockHistoryParam(ArrayList paramList, out StockSlipHistWork stockHistoryWork, out ArrayList stockHistDtlWorks)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stockHistoryWork = null;
            stockHistDtlWorks = null;

            if (paramList != null || paramList.Count > 0)
            {
                foreach (object item in paramList)
                {
                    if (item is StockSlipHistWork)
                    {
                        if (stockHistoryWork == null)
                        {
                            stockHistoryWork = item as StockSlipHistWork;
                        }
                    }
                    else if (item is ArrayList)
                    {
                        if ((item as ArrayList).Count > 0 && (item as ArrayList)[0] is StockSlHistDtlWork && stockHistDtlWorks == null)
                        {
                            stockHistDtlWorks = item as ArrayList;
                        }
                    }

                    if (stockHistoryWork != null && stockHistDtlWorks != null)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        break;
                    }
                }
            }

            return status;
        }

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

            StockSlipHistWork stockhistoryWork = null;
            ArrayList stockhistdtlWorkList = null;

            try
            {
                status = this.GetStockHistoryParam(paramList, out stockhistoryWork, out stockhistdtlWorkList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //write実行
                    status = this.WriteProc(ref stockhistoryWork, ref stockhistdtlWorkList, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                // 仕入履歴及び仕入明細履歴に関するパラメータを削除する
                for (int i = paramList.Count - 1; i >= 0; i--)
                {
                    if (paramList[i] is StockSlipHistWork)
                    {
                        paramList.RemoveAt(i);
                    }
                    else if (paramList[i] is ArrayList)
                    {
                        if ((paramList[i] as ArrayList).Count > 0 && (paramList[i] as ArrayList)[0] is StockSlHistDtlWork)
                        {
                            paramList.RemoveAt(i);
                        }
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// 仕入履歴データ及び仕入明細履歴データを登録(追加・更新)します。
        /// </summary>
        /// <param name="stockhistoryWork">登録対象となる StockHistoryWork</param>
        /// <param name="stockhistdtlWorkList">登録対象となる StockhistdtlWork が格納されている ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int WriteProc(ref StockSlipHistWork stockhistoryWork, ref ArrayList stockhistdtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 仕入履歴データ登録処理
            status = this.WriteStockSlipHist(ref stockhistoryWork, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 仕入明細履歴データ登録処理
                status = this.WriteStockSlHistDtl(ref stockhistdtlWorkList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }

        /// <summary>
        /// 仕入履歴データを登録(削除→追加)します。
        /// </summary>
        /// <param name="stockhistoryWork">登録対象となる StockHistoryWork</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int WriteStockSlipHist(ref StockSlipHistWork stockhistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteStockSlipHistProc(ref stockhistoryWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 仕入履歴データを登録(削除→追加)します。
        /// </summary>
        /// <param name="stockhistoryWork">登録対象となる StockHistoryWork</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        private int WriteStockSlipHistProc(ref StockSlipHistWork stockhistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                // 仕入形式が 0:仕入 の場合にのみ履歴にデータを登録する
                if (stockhistoryWork != null && stockhistoryWork.SupplierFormal == 0)
                {
                    // データの有無に関わらずキーを条件に削除を行う
                    # region [DELETE]
                    string sqlText = "";
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLIPHISTRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                    findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                    sqlCommand.ExecuteNonQuery();
                    # endregion

                    // 仕入履歴データを新規登録する
                    # region [INSERT]
                    //＠仕入履歴データ変更＠
                    # region [INSERT文]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO STOCKSLIPHISTRF (" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSLIPNORF" + Environment.NewLine;
                    sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,SUBSECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,DEBITNOTEDIVRF" + Environment.NewLine;
                    sqlText += " ,DEBITNLNKSUPPSLIPNORF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSLIPCDRF" + Environment.NewLine;
                    sqlText += " ,STOCKGOODSCDRF" + Environment.NewLine;
                    sqlText += " ,ACCPAYDIVCDRF" + Environment.NewLine;
                    sqlText += " ,STOCKSECTIONCDRF" + Environment.NewLine;
                    sqlText += " ,STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                    sqlText += " ,STOCKSLIPUPDATECDRF" + Environment.NewLine;
                    sqlText += " ,INPUTDAYRF" + Environment.NewLine;
                    sqlText += " ,ARRIVALGOODSDAYRF" + Environment.NewLine;
                    sqlText += " ,STOCKDATERF" + Environment.NewLine;
                    sqlText += " ,STOCKADDUPADATERF" + Environment.NewLine;
                    sqlText += " ,DELAYPAYMENTDIVRF" + Environment.NewLine;
                    sqlText += " ,PAYEECODERF" + Environment.NewLine;
                    sqlText += " ,PAYEESNMRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERNM1RF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERNM2RF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += " ,BUSINESSTYPECODERF" + Environment.NewLine;
                    sqlText += " ,BUSINESSTYPENAMERF" + Environment.NewLine;
                    sqlText += " ,SALESAREACODERF" + Environment.NewLine;
                    sqlText += " ,SALESAREANAMERF" + Environment.NewLine;
                    sqlText += " ,STOCKINPUTCODERF" + Environment.NewLine;
                    sqlText += " ,STOCKINPUTNAMERF" + Environment.NewLine;
                    sqlText += " ,STOCKAGENTCODERF" + Environment.NewLine;
                    sqlText += " ,STOCKAGENTNAMERF" + Environment.NewLine;
                    sqlText += " ,SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
                    sqlText += " ,TTLAMNTDISPRATEAPYRF" + Environment.NewLine;
                    sqlText += " ,STOCKTOTALPRICERF" + Environment.NewLine;
                    sqlText += " ,STOCKSUBTTLPRICERF" + Environment.NewLine;
                    sqlText += " ,STOCKTTLPRICTAXINCRF" + Environment.NewLine;
                    sqlText += " ,STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
                    sqlText += " ,STOCKNETPRICERF" + Environment.NewLine;
                    sqlText += " ,STOCKPRICECONSTAXRF" + Environment.NewLine;
                    sqlText += " ,TTLITDEDSTCOUTTAXRF" + Environment.NewLine;
                    sqlText += " ,TTLITDEDSTCINTAXRF" + Environment.NewLine;
                    sqlText += " ,TTLITDEDSTCTAXFREERF" + Environment.NewLine;
                    sqlText += " ,STOCKOUTTAXRF" + Environment.NewLine;
                    sqlText += " ,STCKPRCCONSTAXINCLURF" + Environment.NewLine;
                    sqlText += " ,STCKDISTTLTAXEXCRF" + Environment.NewLine;
                    sqlText += " ,ITDEDSTOCKDISOUTTAXRF" + Environment.NewLine;
                    sqlText += " ,ITDEDSTOCKDISINTAXRF" + Environment.NewLine;
                    sqlText += " ,ITDEDSTOCKDISTAXFRERF" + Environment.NewLine;
                    sqlText += " ,STOCKDISOUTTAXRF" + Environment.NewLine;
                    sqlText += " ,STCKDISTTLTAXINCLURF" + Environment.NewLine;
                    sqlText += " ,TAXADJUSTRF" + Environment.NewLine;
                    sqlText += " ,BALANCEADJUSTRF" + Environment.NewLine;
                    sqlText += " ,SUPPCTAXLAYCDRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                    sqlText += " ,ACCPAYCONSTAXRF" + Environment.NewLine;
                    sqlText += " ,STOCKFRACTIONPROCCDRF" + Environment.NewLine;
                    sqlText += " ,AUTOPAYMENTRF" + Environment.NewLine;
                    sqlText += " ,AUTOPAYSLIPNUMRF" + Environment.NewLine;
                    sqlText += " ,RETGOODSREASONDIVRF" + Environment.NewLine;
                    sqlText += " ,RETGOODSREASONRF" + Environment.NewLine;
                    sqlText += " ,PARTYSALESLIPNUMRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSLIPNOTE1RF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSLIPNOTE2RF" + Environment.NewLine;
                    sqlText += " ,DETAILROWCOUNTRF" + Environment.NewLine;
                    sqlText += " ,EDISENDDATERF" + Environment.NewLine;
                    sqlText += " ,EDITAKEINDATERF" + Environment.NewLine;
                    sqlText += " ,UOEREMARK1RF" + Environment.NewLine;
                    sqlText += " ,UOEREMARK2RF" + Environment.NewLine;
                    sqlText += " ,SLIPPRINTDIVCDRF" + Environment.NewLine;
                    sqlText += " ,SLIPPRINTFINISHCDRF" + Environment.NewLine;
                    sqlText += " ,STOCKSLIPPRINTDATERF" + Environment.NewLine;
                    sqlText += " ,SLIPPRTSETPAPERIDRF)" + Environment.NewLine;
                    sqlText += "VALUES" + Environment.NewLine;
                    sqlText += "  (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSLIPNO" + Environment.NewLine;
                    sqlText += " ,@SECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@SUBSECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@DEBITNOTEDIV" + Environment.NewLine;
                    sqlText += " ,@DEBITNLNKSUPPSLIPNO" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSLIPCD" + Environment.NewLine;
                    sqlText += " ,@STOCKGOODSCD" + Environment.NewLine;
                    sqlText += " ,@ACCPAYDIVCD" + Environment.NewLine;
                    sqlText += " ,@STOCKSECTIONCD" + Environment.NewLine;
                    sqlText += " ,@STOCKADDUPSECTIONCD" + Environment.NewLine;
                    sqlText += " ,@STOCKSLIPUPDATECD" + Environment.NewLine;
                    sqlText += " ,@INPUTDAY" + Environment.NewLine;
                    sqlText += " ,@ARRIVALGOODSDAY" + Environment.NewLine;
                    sqlText += " ,@STOCKDATE" + Environment.NewLine;
                    sqlText += " ,@STOCKADDUPADATE" + Environment.NewLine;
                    sqlText += " ,@DELAYPAYMENTDIV" + Environment.NewLine;
                    sqlText += " ,@PAYEECODE" + Environment.NewLine;
                    sqlText += " ,@PAYEESNM" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERCD" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERNM1" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERNM2" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSNM" + Environment.NewLine;
                    sqlText += " ,@BUSINESSTYPECODE" + Environment.NewLine;
                    sqlText += " ,@BUSINESSTYPENAME" + Environment.NewLine;
                    sqlText += " ,@SALESAREACODE" + Environment.NewLine;
                    sqlText += " ,@SALESAREANAME" + Environment.NewLine;
                    sqlText += " ,@STOCKINPUTCODE" + Environment.NewLine;
                    sqlText += " ,@STOCKINPUTNAME" + Environment.NewLine;
                    sqlText += " ,@STOCKAGENTCODE" + Environment.NewLine;
                    sqlText += " ,@STOCKAGENTNAME" + Environment.NewLine;
                    sqlText += " ,@SUPPTTLAMNTDSPWAYCD" + Environment.NewLine;
                    sqlText += " ,@TTLAMNTDISPRATEAPY" + Environment.NewLine;
                    sqlText += " ,@STOCKTOTALPRICE" + Environment.NewLine;
                    sqlText += " ,@STOCKSUBTTLPRICE" + Environment.NewLine;
                    sqlText += " ,@STOCKTTLPRICTAXINC" + Environment.NewLine;
                    sqlText += " ,@STOCKTTLPRICTAXEXC" + Environment.NewLine;
                    sqlText += " ,@STOCKNETPRICE" + Environment.NewLine;
                    sqlText += " ,@STOCKPRICECONSTAX" + Environment.NewLine;
                    sqlText += " ,@TTLITDEDSTCOUTTAX" + Environment.NewLine;
                    sqlText += " ,@TTLITDEDSTCINTAX" + Environment.NewLine;
                    sqlText += " ,@TTLITDEDSTCTAXFREE" + Environment.NewLine;
                    sqlText += " ,@STOCKOUTTAX" + Environment.NewLine;
                    sqlText += " ,@STCKPRCCONSTAXINCLU" + Environment.NewLine;
                    sqlText += " ,@STCKDISTTLTAXEXC" + Environment.NewLine;
                    sqlText += " ,@ITDEDSTOCKDISOUTTAX" + Environment.NewLine;
                    sqlText += " ,@ITDEDSTOCKDISINTAX" + Environment.NewLine;
                    sqlText += " ,@ITDEDSTOCKDISTAXFRE" + Environment.NewLine;
                    sqlText += " ,@STOCKDISOUTTAX" + Environment.NewLine;
                    sqlText += " ,@STCKDISTTLTAXINCLU" + Environment.NewLine;
                    sqlText += " ,@TAXADJUST" + Environment.NewLine;
                    sqlText += " ,@BALANCEADJUST" + Environment.NewLine;
                    sqlText += " ,@SUPPCTAXLAYCD" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERCONSTAXRATE" + Environment.NewLine;
                    sqlText += " ,@ACCPAYCONSTAX" + Environment.NewLine;
                    sqlText += " ,@STOCKFRACTIONPROCCD" + Environment.NewLine;
                    sqlText += " ,@AUTOPAYMENT" + Environment.NewLine;
                    sqlText += " ,@AUTOPAYSLIPNUM" + Environment.NewLine;
                    sqlText += " ,@RETGOODSREASONDIV" + Environment.NewLine;
                    sqlText += " ,@RETGOODSREASON" + Environment.NewLine;
                    sqlText += " ,@PARTYSALESLIPNUM" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSLIPNOTE1" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSLIPNOTE2" + Environment.NewLine;
                    sqlText += " ,@DETAILROWCOUNT" + Environment.NewLine;
                    sqlText += " ,@EDISENDDATE" + Environment.NewLine;
                    sqlText += " ,@EDITAKEINDATE" + Environment.NewLine;
                    sqlText += " ,@UOEREMARK1" + Environment.NewLine;
                    sqlText += " ,@UOEREMARK2" + Environment.NewLine;
                    sqlText += " ,@SLIPPRINTDIVCD" + Environment.NewLine;
                    sqlText += " ,@SLIPPRINTFINISHCD" + Environment.NewLine;
                    sqlText += " ,@STOCKSLIPPRINTDATE" + Environment.NewLine;
                    sqlText += " ,@SLIPPRTSETPAPERID)" + Environment.NewLine;
                    # endregion

                    sqlCommand.CommandText = sqlText;

                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)stockhistoryWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);

                    //＠仕入履歴データ変更＠
                    #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);            // 作成日時
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);            // 更新日時
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);             // 企業コード
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);           // 更新従業員コード
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);          // 更新アセンブリID1
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);          // 更新アセンブリID2
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);         // 論理削除区分
                    SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);               // 仕入形式
                    SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);               // 仕入伝票番号
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);                   // 拠点コード
                    SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);               // 部門コード
                    SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);                   // 赤伝区分
                    SqlParameter paraDebitNLnkSuppSlipNo = sqlCommand.Parameters.Add("@DEBITNLNKSUPPSLIPNO", SqlDbType.Int);     // 赤黒連結仕入伝票番号
                    SqlParameter paraSupplierSlipCd = sqlCommand.Parameters.Add("@SUPPLIERSLIPCD", SqlDbType.Int);               // 仕入伝票区分
                    SqlParameter paraStockGoodsCd = sqlCommand.Parameters.Add("@STOCKGOODSCD", SqlDbType.Int);                   // 仕入商品区分
                    SqlParameter paraAccPayDivCd = sqlCommand.Parameters.Add("@ACCPAYDIVCD", SqlDbType.Int);                     // 買掛区分
                    SqlParameter paraStockSectionCd = sqlCommand.Parameters.Add("@STOCKSECTIONCD", SqlDbType.NChar);             // 仕入拠点コード
                    SqlParameter paraStockAddUpSectionCd = sqlCommand.Parameters.Add("@STOCKADDUPSECTIONCD", SqlDbType.NChar);   // 仕入計上拠点コード
                    SqlParameter paraStockSlipUpdateCd = sqlCommand.Parameters.Add("@STOCKSLIPUPDATECD", SqlDbType.Int);         // 仕入伝票更新区分
                    SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);                           // 入力日
                    SqlParameter paraArrivalGoodsDay = sqlCommand.Parameters.Add("@ARRIVALGOODSDAY", SqlDbType.Int);             // 入荷日
                    SqlParameter paraStockDate = sqlCommand.Parameters.Add("@STOCKDATE", SqlDbType.Int);                         // 仕入日
                    SqlParameter paraStockAddUpADate = sqlCommand.Parameters.Add("@STOCKADDUPADATE", SqlDbType.Int);             // 仕入計上日付
                    SqlParameter paraDelayPaymentDiv = sqlCommand.Parameters.Add("@DELAYPAYMENTDIV", SqlDbType.Int);             // 来勘区分
                    SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);                         // 支払先コード
                    SqlParameter paraPayeeSnm = sqlCommand.Parameters.Add("@PAYEESNM", SqlDbType.NVarChar);                      // 支払先略称
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);                       // 仕入先コード
                    SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);                // 仕入先名1
                    SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);                // 仕入先名2
                    SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);                // 仕入先略称
                    SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);           // 業種コード
                    SqlParameter paraBusinessTypeName = sqlCommand.Parameters.Add("@BUSINESSTYPENAME", SqlDbType.NVarChar);      // 業種名称
                    SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);                 // 販売エリアコード
                    SqlParameter paraSalesAreaName = sqlCommand.Parameters.Add("@SALESAREANAME", SqlDbType.NVarChar);            // 販売エリア名称
                    SqlParameter paraStockInputCode = sqlCommand.Parameters.Add("@STOCKINPUTCODE", SqlDbType.NChar);             // 仕入入力者コード
                    SqlParameter paraStockInputName = sqlCommand.Parameters.Add("@STOCKINPUTNAME", SqlDbType.NVarChar);          // 仕入入力者名称
                    SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@STOCKAGENTCODE", SqlDbType.NChar);             // 仕入担当者コード
                    SqlParameter paraStockAgentName = sqlCommand.Parameters.Add("@STOCKAGENTNAME", SqlDbType.NVarChar);          // 仕入担当者名称
                    SqlParameter paraSuppTtlAmntDspWayCd = sqlCommand.Parameters.Add("@SUPPTTLAMNTDSPWAYCD", SqlDbType.Int);     // 仕入先総額表示方法区分
                    SqlParameter paraTtlAmntDispRateApy = sqlCommand.Parameters.Add("@TTLAMNTDISPRATEAPY", SqlDbType.Int);       // 総額表示掛率適用区分
                    SqlParameter paraStockTotalPrice = sqlCommand.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);          // 仕入金額合計
                    SqlParameter paraStockSubttlPrice = sqlCommand.Parameters.Add("@STOCKSUBTTLPRICE", SqlDbType.BigInt);        // 仕入金額小計
                    SqlParameter paraStockTtlPricTaxInc = sqlCommand.Parameters.Add("@STOCKTTLPRICTAXINC", SqlDbType.BigInt);    // 仕入金額計（税込み）
                    SqlParameter paraStockTtlPricTaxExc = sqlCommand.Parameters.Add("@STOCKTTLPRICTAXEXC", SqlDbType.BigInt);    // 仕入金額計（税抜き）
                    SqlParameter paraStockNetPrice = sqlCommand.Parameters.Add("@STOCKNETPRICE", SqlDbType.BigInt);              // 仕入正価金額
                    SqlParameter paraStockPriceConsTax = sqlCommand.Parameters.Add("@STOCKPRICECONSTAX", SqlDbType.BigInt);      // 仕入金額消費税額
                    SqlParameter paraTtlItdedStcOutTax = sqlCommand.Parameters.Add("@TTLITDEDSTCOUTTAX", SqlDbType.BigInt);      // 仕入外税対象額合計
                    SqlParameter paraTtlItdedStcInTax = sqlCommand.Parameters.Add("@TTLITDEDSTCINTAX", SqlDbType.BigInt);        // 仕入内税対象額合計
                    SqlParameter paraTtlItdedStcTaxFree = sqlCommand.Parameters.Add("@TTLITDEDSTCTAXFREE", SqlDbType.BigInt);    // 仕入非課税対象額合計
                    SqlParameter paraStockOutTax = sqlCommand.Parameters.Add("@STOCKOUTTAX", SqlDbType.BigInt);                  // 仕入金額消費税額（外税）
                    SqlParameter paraStckPrcConsTaxInclu = sqlCommand.Parameters.Add("@STCKPRCCONSTAXINCLU", SqlDbType.BigInt);  // 仕入金額消費税額（内税）
                    SqlParameter paraStckDisTtlTaxExc = sqlCommand.Parameters.Add("@STCKDISTTLTAXEXC", SqlDbType.BigInt);        // 仕入値引金額計（税抜き）
                    SqlParameter paraItdedStockDisOutTax = sqlCommand.Parameters.Add("@ITDEDSTOCKDISOUTTAX", SqlDbType.BigInt);  // 仕入値引外税対象額合計
                    SqlParameter paraItdedStockDisInTax = sqlCommand.Parameters.Add("@ITDEDSTOCKDISINTAX", SqlDbType.BigInt);    // 仕入値引内税対象額合計
                    SqlParameter paraItdedStockDisTaxFre = sqlCommand.Parameters.Add("@ITDEDSTOCKDISTAXFRE", SqlDbType.BigInt);  // 仕入値引非課税対象額合計
                    SqlParameter paraStockDisOutTax = sqlCommand.Parameters.Add("@STOCKDISOUTTAX", SqlDbType.BigInt);            // 仕入値引消費税額（外税）
                    SqlParameter paraStckDisTtlTaxInclu = sqlCommand.Parameters.Add("@STCKDISTTLTAXINCLU", SqlDbType.BigInt);    // 仕入値引消費税額（内税）
                    SqlParameter paraTaxAdjust = sqlCommand.Parameters.Add("@TAXADJUST", SqlDbType.BigInt);                      // 消費税調整額
                    SqlParameter paraBalanceAdjust = sqlCommand.Parameters.Add("@BALANCEADJUST", SqlDbType.BigInt);              // 残高調整額
                    SqlParameter paraSuppCTaxLayCd = sqlCommand.Parameters.Add("@SUPPCTAXLAYCD", SqlDbType.Int);                 // 仕入先消費税転嫁方式コード
                    SqlParameter paraSupplierConsTaxRate = sqlCommand.Parameters.Add("@SUPPLIERCONSTAXRATE", SqlDbType.Float);   // 仕入先消費税税率
                    SqlParameter paraAccPayConsTax = sqlCommand.Parameters.Add("@ACCPAYCONSTAX", SqlDbType.BigInt);              // 買掛消費税
                    SqlParameter paraStockFractionProcCd = sqlCommand.Parameters.Add("@STOCKFRACTIONPROCCD", SqlDbType.Int);     // 仕入端数処理区分
                    SqlParameter paraAutoPayment = sqlCommand.Parameters.Add("@AUTOPAYMENT", SqlDbType.Int);                     // 自動支払区分
                    SqlParameter paraAutoPaySlipNum = sqlCommand.Parameters.Add("@AUTOPAYSLIPNUM", SqlDbType.Int);               // 自動支払伝票番号
                    SqlParameter paraRetGoodsReasonDiv = sqlCommand.Parameters.Add("@RETGOODSREASONDIV", SqlDbType.Int);         // 返品理由コード
                    SqlParameter paraRetGoodsReason = sqlCommand.Parameters.Add("@RETGOODSREASON", SqlDbType.NVarChar);          // 返品理由
                    SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@PARTYSALESLIPNUM", SqlDbType.NVarChar);      // 相手先伝票番号
                    SqlParameter paraSupplierSlipNote1 = sqlCommand.Parameters.Add("@SUPPLIERSLIPNOTE1", SqlDbType.NVarChar);    // 仕入伝票備考1
                    SqlParameter paraSupplierSlipNote2 = sqlCommand.Parameters.Add("@SUPPLIERSLIPNOTE2", SqlDbType.NVarChar);    // 仕入伝票備考2
                    SqlParameter paraDetailRowCount = sqlCommand.Parameters.Add("@DETAILROWCOUNT", SqlDbType.Int);               // 明細行数
                    SqlParameter paraEdiSendDate = sqlCommand.Parameters.Add("@EDISENDDATE", SqlDbType.Int);                     // ＥＤＩ送信日
                    SqlParameter paraEdiTakeInDate = sqlCommand.Parameters.Add("@EDITAKEINDATE", SqlDbType.Int);                 // ＥＤＩ取込日
                    SqlParameter paraUoeRemark1 = sqlCommand.Parameters.Add("@UOEREMARK1", SqlDbType.NVarChar);                  // ＵＯＥリマーク１
                    SqlParameter paraUoeRemark2 = sqlCommand.Parameters.Add("@UOEREMARK2", SqlDbType.NVarChar);                  // ＵＯＥリマーク２
                    SqlParameter paraSlipPrintDivCd = sqlCommand.Parameters.Add("@SLIPPRINTDIVCD", SqlDbType.Int);               // 伝票発行区分
                    SqlParameter paraSlipPrintFinishCd = sqlCommand.Parameters.Add("@SLIPPRINTFINISHCD", SqlDbType.Int);         // 伝票発行済区分
                    SqlParameter paraStockSlipPrintDate = sqlCommand.Parameters.Add("@STOCKSLIPPRINTDATE", SqlDbType.Int);       // 仕入伝票発行日
                    SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);    // 伝票印刷設定用帳票ID
                    #endregion

                    //＠仕入履歴データ変更＠
                    #region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockhistoryWork.CreateDateTime);             // 作成日時
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockhistoryWork.UpdateDateTime);             // 更新日時
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);                        // 企業コード
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockhistoryWork.FileHeaderGuid);                          // GUID
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UpdEmployeeCode);                      // 更新従業員コード
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UpdAssemblyId1);                        // 更新アセンブリID1
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UpdAssemblyId2);                        // 更新アセンブリID2
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.LogicalDeleteCode);                   // 論理削除区分
                    paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);                         // 仕入形式
                    paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);                         // 仕入伝票番号
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.SectionCode);                              // 拠点コード
                    paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SubSectionCode);                         // 部門コード
                    paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.DebitNoteDiv);                             // 赤伝区分
                    paraDebitNLnkSuppSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.DebitNLnkSuppSlipNo);               // 赤黒連結仕入伝票番号
                    paraSupplierSlipCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipCd);                         // 仕入伝票区分
                    paraStockGoodsCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.StockGoodsCd);                             // 仕入商品区分
                    paraAccPayDivCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.AccPayDivCd);                               // 買掛区分
                    paraStockSectionCd.Value = SqlDataMediator.SqlSetString(stockhistoryWork.StockSectionCd);                        // 仕入拠点コード
                    paraStockAddUpSectionCd.Value = SqlDataMediator.SqlSetString(stockhistoryWork.StockAddUpSectionCd);              // 仕入計上拠点コード
                    paraStockSlipUpdateCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.StockSlipUpdateCd);                   // 仕入伝票更新区分
                    paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockhistoryWork.InputDay);                      // 入力日
                    paraArrivalGoodsDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockhistoryWork.ArrivalGoodsDay);        // 入荷日
                    paraStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockhistoryWork.StockDate);                    // 仕入日
                    paraStockAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockhistoryWork.StockAddUpADate);        // 仕入計上日付
                    paraDelayPaymentDiv.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.DelayPaymentDiv);                       // 来勘区分
                    paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.PayeeCode);                                   // 支払先コード
                    paraPayeeSnm.Value = SqlDataMediator.SqlSetString(stockhistoryWork.PayeeSnm);                                    // 支払先略称
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierCd);                                 // 仕入先コード
                    paraSupplierNm1.Value = SqlDataMediator.SqlSetString(stockhistoryWork.SupplierNm1);                              // 仕入先名1
                    paraSupplierNm2.Value = SqlDataMediator.SqlSetString(stockhistoryWork.SupplierNm2);                              // 仕入先名2
                    paraSupplierSnm.Value = SqlDataMediator.SqlSetString(stockhistoryWork.SupplierSnm);                              // 仕入先略称
                    paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.BusinessTypeCode);                     // 業種コード
                    paraBusinessTypeName.Value = SqlDataMediator.SqlSetString(stockhistoryWork.BusinessTypeName);                    // 業種名称
                    paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SalesAreaCode);                           // 販売エリアコード
                    paraSalesAreaName.Value = SqlDataMediator.SqlSetString(stockhistoryWork.SalesAreaName);                          // 販売エリア名称
                    paraStockInputCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.StockInputCode);                        // 仕入入力者コード
                    paraStockInputName.Value = SqlDataMediator.SqlSetString(stockhistoryWork.StockInputName);                        // 仕入入力者名称
                    paraStockAgentCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.StockAgentCode);                        // 仕入担当者コード
                    paraStockAgentName.Value = SqlDataMediator.SqlSetString(stockhistoryWork.StockAgentName);                        // 仕入担当者名称
                    paraSuppTtlAmntDspWayCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SuppTtlAmntDspWayCd);               // 仕入先総額表示方法区分
                    paraTtlAmntDispRateApy.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.TtlAmntDispRateApy);                 // 総額表示掛率適用区分
                    paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StockTotalPrice);                       // 仕入金額合計
                    paraStockSubttlPrice.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StockSubttlPrice);                     // 仕入金額小計
                    paraStockTtlPricTaxInc.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StockTtlPricTaxInc);                 // 仕入金額計（税込み）
                    paraStockTtlPricTaxExc.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StockTtlPricTaxExc);                 // 仕入金額計（税抜き）
                    paraStockNetPrice.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StockNetPrice);                           // 仕入正価金額
                    paraStockPriceConsTax.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StockPriceConsTax);                   // 仕入金額消費税額
                    paraTtlItdedStcOutTax.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.TtlItdedStcOutTax);                   // 仕入外税対象額合計
                    paraTtlItdedStcInTax.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.TtlItdedStcInTax);                     // 仕入内税対象額合計
                    paraTtlItdedStcTaxFree.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.TtlItdedStcTaxFree);                 // 仕入非課税対象額合計
                    paraStockOutTax.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StockOutTax);                               // 仕入金額消費税額（外税）
                    paraStckPrcConsTaxInclu.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StckPrcConsTaxInclu);               // 仕入金額消費税額（内税）
                    paraStckDisTtlTaxExc.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StckDisTtlTaxExc);                     // 仕入値引金額計（税抜き）
                    paraItdedStockDisOutTax.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.ItdedStockDisOutTax);               // 仕入値引外税対象額合計
                    paraItdedStockDisInTax.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.ItdedStockDisInTax);                 // 仕入値引内税対象額合計
                    paraItdedStockDisTaxFre.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.ItdedStockDisTaxFre);               // 仕入値引非課税対象額合計
                    paraStockDisOutTax.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StockDisOutTax);                         // 仕入値引消費税額（外税）
                    paraStckDisTtlTaxInclu.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.StckDisTtlTaxInclu);                 // 仕入値引消費税額（内税）
                    paraTaxAdjust.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.TaxAdjust);                                   // 消費税調整額
                    paraBalanceAdjust.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.BalanceAdjust);                           // 残高調整額
                    paraSuppCTaxLayCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SuppCTaxLayCd);                           // 仕入先消費税転嫁方式コード
                    paraSupplierConsTaxRate.Value = SqlDataMediator.SqlSetDouble(stockhistoryWork.SupplierConsTaxRate);              // 仕入先消費税税率
                    paraAccPayConsTax.Value = SqlDataMediator.SqlSetInt64(stockhistoryWork.AccPayConsTax);                           // 買掛消費税
                    paraStockFractionProcCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.StockFractionProcCd);               // 仕入端数処理区分
                    paraAutoPayment.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.AutoPayment);                               // 自動支払区分
                    paraAutoPaySlipNum.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.AutoPaySlipNum);                         // 自動支払伝票番号
                    paraRetGoodsReasonDiv.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.RetGoodsReasonDiv);                   // 返品理由コード
                    paraRetGoodsReason.Value = SqlDataMediator.SqlSetString(stockhistoryWork.RetGoodsReason);                        // 返品理由
                    paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(stockhistoryWork.PartySaleSlipNum);                    // 相手先伝票番号
                    paraSupplierSlipNote1.Value = SqlDataMediator.SqlSetString(stockhistoryWork.SupplierSlipNote1);                  // 仕入伝票備考1
                    paraSupplierSlipNote2.Value = SqlDataMediator.SqlSetString(stockhistoryWork.SupplierSlipNote2);                  // 仕入伝票備考2
                    paraDetailRowCount.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.DetailRowCount);                         // 明細行数
                    paraEdiSendDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockhistoryWork.EdiSendDate);                // ＥＤＩ送信日
                    paraEdiTakeInDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockhistoryWork.EdiTakeInDate);            // ＥＤＩ取込日
                    paraUoeRemark1.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UoeRemark1);                                // ＵＯＥリマーク１
                    paraUoeRemark2.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UoeRemark2);                                // ＵＯＥリマーク２
                    paraSlipPrintDivCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SlipPrintDivCd);                         // 伝票発行区分
                    paraSlipPrintFinishCd.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SlipPrintFinishCd);                   // 伝票発行済区分
                    paraStockSlipPrintDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockhistoryWork.StockSlipPrintDate);  // 仕入伝票発行日
                    paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(stockhistoryWork.SlipPrtSetPaperId);                  // 伝票印刷設定用帳票ID
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
        /// 仕入明細履歴データを登録(削除→追加)します。
        /// </summary>
        /// <param name="stockhistdtlWorkList">登録対象となる StockhistdtlWork が格納されている ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int WriteStockSlHistDtl(ref ArrayList stockhistdtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteStockSlHistDtlProc(ref stockhistdtlWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 仕入明細履歴データを登録(削除→追加)します。
        /// </summary>
        /// <param name="stockhistdtlWorkList">登録対象となる StockhistdtlWork が格納されている ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        private int WriteStockSlHistDtlProc(ref ArrayList stockhistdtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (stockhistdtlWorkList != null && stockhistdtlWorkList.Count > 0 && stockhistdtlWorkList[0] is StockSlHistDtlWork)
                {
                    // 仕入伝票番号(＋α)を条件としてデータの有無に関わらず複数明細行の削除を行う
                    # region [DELETE]
                    string sqlText = "";
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLHISTDTLRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString((stockhistdtlWorkList[0] as StockSlHistDtlWork).EnterpriseCode);
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32((stockhistdtlWorkList[0] as StockSlHistDtlWork).SupplierFormal);
                    findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32((stockhistdtlWorkList[0] as StockSlHistDtlWork).SupplierSlipNo);

                    sqlCommand.ExecuteNonQuery();

                    # endregion

                    # region [INSERT]

                    //新規作成時のSQL文を生成
                    //＠仕入履歴明細データ変更＠
                    //para<#FieldName>.Value = SqlDataMediator.<#sqlDbTypeSetAccessor>(stockhistdtlWork.<#FieldName>);  // <#name>
                    # region [INSERT文]
                    //--- ADD 2008/09/12 M.Kubota --->>>
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO STOCKSLHISTDTLRF (" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ACCEPTANORDERNORF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSLIPNORF" + Environment.NewLine;
                    sqlText += " ,STOCKROWNORF" + Environment.NewLine;
                    sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,SUBSECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,COMMONSEQNORF" + Environment.NewLine;
                    sqlText += " ,STOCKSLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERFORMALSRCRF" + Environment.NewLine;
                    sqlText += " ,STOCKSLIPDTLNUMSRCRF" + Environment.NewLine;
                    sqlText += " ,ACPTANODRSTATUSSYNCRF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPDTLNUMSYNCRF" + Environment.NewLine;
                    sqlText += " ,STOCKSLIPCDDTLRF" + Environment.NewLine;
                    sqlText += " ,STOCKAGENTCODERF" + Environment.NewLine;
                    sqlText += " ,STOCKAGENTNAMERF" + Environment.NewLine;
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
                    sqlText += " ,STOCKORDERDIVCDRF" + Environment.NewLine;
                    sqlText += " ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlText += " ,GOODSRATERANKRF" + Environment.NewLine;
                    sqlText += " ,CUSTRATEGRPCODERF" + Environment.NewLine;
                    sqlText += " ,SUPPRATEGRPCODERF" + Environment.NewLine;
                    sqlText += " ,LISTPRICETAXEXCFLRF" + Environment.NewLine;
                    sqlText += " ,LISTPRICETAXINCFLRF" + Environment.NewLine;
                    sqlText += " ,STOCKRATERF" + Environment.NewLine;
                    sqlText += " ,RATESECTSTCKUNPRCRF" + Environment.NewLine;
                    sqlText += " ,RATEDIVSTCKUNPRCRF" + Environment.NewLine;
                    sqlText += " ,UNPRCCALCCDSTCKUNPRCRF" + Environment.NewLine;
                    sqlText += " ,PRICECDSTCKUNPRCRF" + Environment.NewLine;
                    sqlText += " ,STDUNPRCSTCKUNPRCRF" + Environment.NewLine;
                    sqlText += " ,FRACPROCUNITSTCUNPRCRF" + Environment.NewLine;
                    sqlText += " ,FRACPROCSTCKUNPRCRF" + Environment.NewLine;
                    sqlText += " ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                    sqlText += " ,STOCKUNITTAXPRICEFLRF" + Environment.NewLine;
                    sqlText += " ,STOCKUNITCHNGDIVRF" + Environment.NewLine;
                    sqlText += " ,BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                    sqlText += " ,BFLISTPRICERF" + Environment.NewLine;
                    sqlText += " ,RATEBLGOODSCODERF" + Environment.NewLine;
                    sqlText += " ,RATEBLGOODSNAMERF" + Environment.NewLine;
                    sqlText += " ,RATEGOODSRATEGRPCDRF" + Environment.NewLine;
                    sqlText += " ,RATEGOODSRATEGRPNMRF" + Environment.NewLine;
                    sqlText += " ,RATEBLGROUPCODERF" + Environment.NewLine;
                    sqlText += " ,RATEBLGROUPNAMERF" + Environment.NewLine;
                    sqlText += " ,STOCKCOUNTRF" + Environment.NewLine;
                    sqlText += " ,STOCKPRICETAXEXCRF" + Environment.NewLine;
                    sqlText += " ,STOCKPRICETAXINCRF" + Environment.NewLine;
                    sqlText += " ,STOCKGOODSCDRF" + Environment.NewLine;
                    sqlText += " ,STOCKPRICECONSTAXRF" + Environment.NewLine;
                    sqlText += " ,TAXATIONCODERF" + Environment.NewLine;
                    sqlText += " ,STOCKDTISLIPNOTE1RF" + Environment.NewLine;
                    sqlText += " ,SALESCUSTOMERCODERF" + Environment.NewLine;
                    sqlText += " ,SALESCUSTOMERSNMRF" + Environment.NewLine;
                    sqlText += " ,ORDERNUMBERRF" + Environment.NewLine;
                    sqlText += " ,SLIPMEMO1RF" + Environment.NewLine;
                    sqlText += " ,SLIPMEMO2RF" + Environment.NewLine;
                    sqlText += " ,SLIPMEMO3RF" + Environment.NewLine;
                    sqlText += " ,INSIDEMEMO1RF" + Environment.NewLine;
                    sqlText += " ,INSIDEMEMO2RF" + Environment.NewLine;
                    sqlText += " ,INSIDEMEMO3RF)" + Environment.NewLine;
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
                    sqlText += " ,@SUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSLIPNO" + Environment.NewLine;
                    sqlText += " ,@STOCKROWNO" + Environment.NewLine;
                    sqlText += " ,@SECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@SUBSECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@COMMONSEQNO" + Environment.NewLine;
                    sqlText += " ,@STOCKSLIPDTLNUM" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERFORMALSRC" + Environment.NewLine;
                    sqlText += " ,@STOCKSLIPDTLNUMSRC" + Environment.NewLine;
                    sqlText += " ,@ACPTANODRSTATUSSYNC" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPDTLNUMSYNC" + Environment.NewLine;
                    sqlText += " ,@STOCKSLIPCDDTL" + Environment.NewLine;
                    sqlText += " ,@STOCKAGENTCODE" + Environment.NewLine;
                    sqlText += " ,@STOCKAGENTNAME" + Environment.NewLine;
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
                    sqlText += " ,@STOCKORDERDIVCD" + Environment.NewLine;
                    sqlText += " ,@OPENPRICEDIV" + Environment.NewLine;
                    sqlText += " ,@GOODSRATERANK" + Environment.NewLine;
                    sqlText += " ,@CUSTRATEGRPCODE" + Environment.NewLine;
                    sqlText += " ,@SUPPRATEGRPCODE" + Environment.NewLine;
                    sqlText += " ,@LISTPRICETAXEXCFL" + Environment.NewLine;
                    sqlText += " ,@LISTPRICETAXINCFL" + Environment.NewLine;
                    sqlText += " ,@STOCKRATE" + Environment.NewLine;
                    sqlText += " ,@RATESECTSTCKUNPRC" + Environment.NewLine;
                    sqlText += " ,@RATEDIVSTCKUNPRC" + Environment.NewLine;
                    sqlText += " ,@UNPRCCALCCDSTCKUNPRC" + Environment.NewLine;
                    sqlText += " ,@PRICECDSTCKUNPRC" + Environment.NewLine;
                    sqlText += " ,@STDUNPRCSTCKUNPRC" + Environment.NewLine;
                    sqlText += " ,@FRACPROCUNITSTCUNPRC" + Environment.NewLine;
                    sqlText += " ,@FRACPROCSTCKUNPRC" + Environment.NewLine;
                    sqlText += " ,@STOCKUNITPRICEFL" + Environment.NewLine;
                    sqlText += " ,@STOCKUNITTAXPRICEFL" + Environment.NewLine;
                    sqlText += " ,@STOCKUNITCHNGDIV" + Environment.NewLine;
                    sqlText += " ,@BFSTOCKUNITPRICEFL" + Environment.NewLine;
                    sqlText += " ,@BFLISTPRICE" + Environment.NewLine;
                    sqlText += " ,@RATEBLGOODSCODE" + Environment.NewLine;
                    sqlText += " ,@RATEBLGOODSNAME" + Environment.NewLine;
                    sqlText += " ,@RATEGOODSRATEGRPCD" + Environment.NewLine;
                    sqlText += " ,@RATEGOODSRATEGRPNM" + Environment.NewLine;
                    sqlText += " ,@RATEBLGROUPCODE" + Environment.NewLine;
                    sqlText += " ,@RATEBLGROUPNAME" + Environment.NewLine;
                    sqlText += " ,@STOCKCOUNT" + Environment.NewLine;
                    sqlText += " ,@STOCKPRICETAXEXC" + Environment.NewLine;
                    sqlText += " ,@STOCKPRICETAXINC" + Environment.NewLine;
                    sqlText += " ,@STOCKGOODSCD" + Environment.NewLine;
                    sqlText += " ,@STOCKPRICECONSTAX" + Environment.NewLine;
                    sqlText += " ,@TAXATIONCODE" + Environment.NewLine;
                    sqlText += " ,@STOCKDTISLIPNOTE1" + Environment.NewLine;
                    sqlText += " ,@SALESCUSTOMERCODE" + Environment.NewLine;
                    sqlText += " ,@SALESCUSTOMERSNM" + Environment.NewLine;
                    sqlText += " ,@ORDERNUMBER" + Environment.NewLine;
                    sqlText += " ,@SLIPMEMO1" + Environment.NewLine;
                    sqlText += " ,@SLIPMEMO2" + Environment.NewLine;
                    sqlText += " ,@SLIPMEMO3" + Environment.NewLine;
                    sqlText += " ,@INSIDEMEMO1" + Environment.NewLine;
                    sqlText += " ,@INSIDEMEMO2" + Environment.NewLine;
                    sqlText += " ,@INSIDEMEMO3)" + Environment.NewLine;
                    //--- ADD 2008/09/12 M.Kubota ---<<<
                    # endregion                    

                    sqlCommand.CommandText = sqlText;

                    //＠仕入履歴明細データ変更＠
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
                    SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
                    SqlParameter paraStockRowNo = sqlCommand.Parameters.Add("@STOCKROWNO", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraCommonSeqNo = sqlCommand.Parameters.Add("@COMMONSEQNO", SqlDbType.BigInt);
                    SqlParameter paraStockSlipDtlNum = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUM", SqlDbType.BigInt);
                    SqlParameter paraSupplierFormalSrc = sqlCommand.Parameters.Add("@SUPPLIERFORMALSRC", SqlDbType.Int);
                    SqlParameter paraStockSlipDtlNumSrc = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUMSRC", SqlDbType.BigInt);
                    SqlParameter paraAcptAnOdrStatusSync = sqlCommand.Parameters.Add("@ACPTANODRSTATUSSYNC", SqlDbType.Int);
                    SqlParameter paraSalesSlipDtlNumSync = sqlCommand.Parameters.Add("@SALESSLIPDTLNUMSYNC", SqlDbType.BigInt);
                    SqlParameter paraStockSlipCdDtl = sqlCommand.Parameters.Add("@STOCKSLIPCDDTL", SqlDbType.Int);
                    SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@STOCKAGENTCODE", SqlDbType.NChar);
                    SqlParameter paraStockAgentName = sqlCommand.Parameters.Add("@STOCKAGENTNAME", SqlDbType.NVarChar);
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
                    SqlParameter paraStockOrderDivCd = sqlCommand.Parameters.Add("@STOCKORDERDIVCD", SqlDbType.Int);
                    SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                    SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                    SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter paraSuppRateGrpCode = sqlCommand.Parameters.Add("@SUPPRATEGRPCODE", SqlDbType.Int);
                    SqlParameter paraListPriceTaxExcFl = sqlCommand.Parameters.Add("@LISTPRICETAXEXCFL", SqlDbType.Float);
                    SqlParameter paraListPriceTaxIncFl = sqlCommand.Parameters.Add("@LISTPRICETAXINCFL", SqlDbType.Float);
                    SqlParameter paraStockRate = sqlCommand.Parameters.Add("@STOCKRATE", SqlDbType.Float);
                    SqlParameter paraRateSectStckUnPrc = sqlCommand.Parameters.Add("@RATESECTSTCKUNPRC", SqlDbType.NChar);
                    SqlParameter paraRateDivStckUnPrc = sqlCommand.Parameters.Add("@RATEDIVSTCKUNPRC", SqlDbType.NChar);
                    SqlParameter paraUnPrcCalcCdStckUnPrc = sqlCommand.Parameters.Add("@UNPRCCALCCDSTCKUNPRC", SqlDbType.Int);
                    SqlParameter paraPriceCdStckUnPrc = sqlCommand.Parameters.Add("@PRICECDSTCKUNPRC", SqlDbType.Int);
                    SqlParameter paraStdUnPrcStckUnPrc = sqlCommand.Parameters.Add("@STDUNPRCSTCKUNPRC", SqlDbType.Float);
                    SqlParameter paraFracProcUnitStcUnPrc = sqlCommand.Parameters.Add("@FRACPROCUNITSTCUNPRC", SqlDbType.Float);
                    SqlParameter paraFracProcStckUnPrc = sqlCommand.Parameters.Add("@FRACPROCSTCKUNPRC", SqlDbType.Int);
                    SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                    SqlParameter paraStockUnitTaxPriceFl = sqlCommand.Parameters.Add("@STOCKUNITTAXPRICEFL", SqlDbType.Float);
                    SqlParameter paraStockUnitChngDiv = sqlCommand.Parameters.Add("@STOCKUNITCHNGDIV", SqlDbType.Int);
                    SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                    SqlParameter paraBfListPrice = sqlCommand.Parameters.Add("@BFLISTPRICE", SqlDbType.Float);
                    SqlParameter paraRateBLGoodsCode = sqlCommand.Parameters.Add("@RATEBLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraRateBLGoodsName = sqlCommand.Parameters.Add("@RATEBLGOODSNAME", SqlDbType.NVarChar);
                    SqlParameter paraRateGoodsRateGrpCd = sqlCommand.Parameters.Add("@RATEGOODSRATEGRPCD", SqlDbType.Int);
                    SqlParameter paraRateGoodsRateGrpNm = sqlCommand.Parameters.Add("@RATEGOODSRATEGRPNM", SqlDbType.NVarChar);
                    SqlParameter paraRateBLGroupCode = sqlCommand.Parameters.Add("@RATEBLGROUPCODE", SqlDbType.Int);
                    SqlParameter paraRateBLGroupName = sqlCommand.Parameters.Add("@RATEBLGROUPNAME", SqlDbType.NVarChar);
                    SqlParameter paraStockCount = sqlCommand.Parameters.Add("@STOCKCOUNT", SqlDbType.Float);
                    SqlParameter paraStockPriceTaxExc = sqlCommand.Parameters.Add("@STOCKPRICETAXEXC", SqlDbType.BigInt);
                    SqlParameter paraStockPriceTaxInc = sqlCommand.Parameters.Add("@STOCKPRICETAXINC", SqlDbType.BigInt);
                    SqlParameter paraStockGoodsCd = sqlCommand.Parameters.Add("@STOCKGOODSCD", SqlDbType.Int);
                    SqlParameter paraStockPriceConsTax = sqlCommand.Parameters.Add("@STOCKPRICECONSTAX", SqlDbType.BigInt);
                    SqlParameter paraTaxationCode = sqlCommand.Parameters.Add("@TAXATIONCODE", SqlDbType.Int);
                    SqlParameter paraStockDtiSlipNote1 = sqlCommand.Parameters.Add("@STOCKDTISLIPNOTE1", SqlDbType.NVarChar);
                    SqlParameter paraSalesCustomerCode = sqlCommand.Parameters.Add("@SALESCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraSalesCustomerSnm = sqlCommand.Parameters.Add("@SALESCUSTOMERSNM", SqlDbType.NVarChar);
                    SqlParameter paraOrderNumber = sqlCommand.Parameters.Add("@ORDERNUMBER", SqlDbType.NVarChar);
                    SqlParameter paraSlipMemo1 = sqlCommand.Parameters.Add("@SLIPMEMO1", SqlDbType.NVarChar);
                    SqlParameter paraSlipMemo2 = sqlCommand.Parameters.Add("@SLIPMEMO2", SqlDbType.NVarChar);
                    SqlParameter paraSlipMemo3 = sqlCommand.Parameters.Add("@SLIPMEMO3", SqlDbType.NVarChar);
                    SqlParameter paraInsideMemo1 = sqlCommand.Parameters.Add("@INSIDEMEMO1", SqlDbType.NVarChar);
                    SqlParameter paraInsideMemo2 = sqlCommand.Parameters.Add("@INSIDEMEMO2", SqlDbType.NVarChar);
                    SqlParameter paraInsideMemo3 = sqlCommand.Parameters.Add("@INSIDEMEMO3", SqlDbType.NVarChar);
                    #endregion

                    foreach (object item in stockhistdtlWorkList)
                    {
                        StockSlHistDtlWork stockhistdtlWork = item as StockSlHistDtlWork;

                        // 仕入形式が 0:仕入 の場合にのみ履歴データを登録する
                        if (stockhistdtlWork != null && stockhistdtlWork.SupplierFormal == 0)
                        {
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockhistdtlWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            //＠仕入履歴明細データ変更＠
                            #region Parameterオブジェクトへ値設定(更新用)
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockhistdtlWork.CreateDateTime);   // 作成日時
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockhistdtlWork.UpdateDateTime);   // 更新日時
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.EnterpriseCode);              // 企業コード
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockhistdtlWork.FileHeaderGuid);                // GUID
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.UpdEmployeeCode);            // 更新従業員コード
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.UpdAssemblyId1);              // 更新アセンブリID1
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.UpdAssemblyId2);              // 更新アセンブリID2
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.LogicalDeleteCode);         // 論理削除区分
                            paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.AcceptAnOrderNo);             // 受注番号
                            paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SupplierFormal);               // 仕入形式
                            paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SupplierSlipNo);               // 仕入伝票番号
                            paraStockRowNo.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.StockRowNo);                       // 仕入行番号
                            paraSectionCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.SectionCode);                    // 拠点コード
                            paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SubSectionCode);               // 部門コード
                            paraCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.CommonSeqNo);                     // 共通通番
                            paraStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.StockSlipDtlNum);             // 仕入明細通番
                            paraSupplierFormalSrc.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SupplierFormalSrc);         // 仕入形式（元）
                            paraStockSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.StockSlipDtlNumSrc);       // 仕入明細通番（元）
                            paraAcptAnOdrStatusSync.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.AcptAnOdrStatusSync);     // 受注ステータス（同時）
                            paraSalesSlipDtlNumSync.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.SalesSlipDtlNumSync);     // 売上明細通番（同時）
                            paraStockSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.StockSlipCdDtl);               // 仕入伝票区分（明細）
                            paraStockAgentCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.StockAgentCode);              // 仕入担当者コード
                            paraStockAgentName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.StockAgentName);              // 仕入担当者名称
                            paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.GoodsKindCode);                 // 商品属性
                            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.GoodsMakerCd);                   // 商品メーカーコード
                            paraMakerName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.MakerName);                        // メーカー名称
                            paraMakerKanaName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.MakerKanaName);                // メーカーカナ名称
                            paraCmpltMakerKanaName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.CmpltMakerKanaName);      // メーカーカナ名称（一式）
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.GoodsNo);                            // 商品番号
                            paraGoodsName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.GoodsName);                        // 商品名称
                            paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.GoodsNameKana);                // 商品名称カナ
                            paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.GoodsLGroup);                     // 商品大分類コード
                            paraGoodsLGroupName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.GoodsLGroupName);            // 商品大分類名称
                            paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.GoodsMGroup);                     // 商品中分類コード
                            paraGoodsMGroupName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.GoodsMGroupName);            // 商品中分類名称
                            paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.BLGroupCode);                     // BLグループコード
                            paraBLGroupName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.BLGroupName);                    // BLグループコード名称
                            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.BLGoodsCode);                     // BL商品コード
                            paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.BLGoodsFullName);            // BL商品コード名称（全角）
                            paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.EnterpriseGanreCode);     // 自社分類コード
                            paraEnterpriseGanreName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.EnterpriseGanreName);    // 自社分類名称
                            paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.WarehouseCode);                // 倉庫コード
                            paraWarehouseName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.WarehouseName);                // 倉庫名称
                            paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.WarehouseShelfNo);          // 倉庫棚番
                            paraStockOrderDivCd.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.StockOrderDivCd);             // 仕入在庫取寄せ区分
                            paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.OpenPriceDiv);                   // オープン価格区分
                            paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.GoodsRateRank);                // 商品掛率ランク
                            paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.CustRateGrpCode);             // 得意先掛率グループコード
                            paraSuppRateGrpCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SuppRateGrpCode);             // 仕入先掛率グループコード
                            paraListPriceTaxExcFl.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.ListPriceTaxExcFl);        // 定価（税抜，浮動）
                            paraListPriceTaxIncFl.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.ListPriceTaxIncFl);        // 定価（税込，浮動）
                            paraStockRate.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.StockRate);                        // 仕入率
                            paraRateSectStckUnPrc.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.RateSectStckUnPrc);        // 掛率設定拠点（仕入単価）
                            paraRateDivStckUnPrc.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.RateDivStckUnPrc);          // 掛率設定区分（仕入単価）
                            paraUnPrcCalcCdStckUnPrc.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.UnPrcCalcCdStckUnPrc);   // 単価算出区分（仕入単価）
                            paraPriceCdStckUnPrc.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.PriceCdStckUnPrc);           // 価格区分（仕入単価）
                            paraStdUnPrcStckUnPrc.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.StdUnPrcStckUnPrc);        // 基準単価（仕入単価）
                            paraFracProcUnitStcUnPrc.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.FracProcUnitStcUnPrc);  // 端数処理単位（仕入単価）
                            paraFracProcStckUnPrc.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.FracProcStckUnPrc);         // 端数処理（仕入単価）
                            paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.StockUnitPriceFl);          // 仕入単価（税抜，浮動）
                            paraStockUnitTaxPriceFl.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.StockUnitTaxPriceFl);    // 仕入単価（税込，浮動）
                            paraStockUnitChngDiv.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.StockUnitChngDiv);           // 仕入単価変更区分
                            paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.BfStockUnitPriceFl);      // 変更前仕入単価（浮動）
                            paraBfListPrice.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.BfListPrice);                    // 変更前定価
                            paraRateBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.RateBLGoodsCode);             // BL商品コード（掛率）
                            paraRateBLGoodsName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.RateBLGoodsName);            // BL商品コード名称（掛率）
                            paraRateGoodsRateGrpCd.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.RateGoodsRateGrpCd);       // 商品掛率グループコード（掛率）
                            paraRateGoodsRateGrpNm.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.RateGoodsRateGrpNm);      // 商品掛率グループ名称（掛率）
                            paraRateBLGroupCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.RateBLGroupCode);             // BLグループコード（掛率）
                            paraRateBLGroupName.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.RateBLGroupName);            // BLグループ名称（掛率）
                            paraStockCount.Value = SqlDataMediator.SqlSetDouble(stockhistdtlWork.StockCount);                      // 仕入数
                            paraStockPriceTaxExc.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.StockPriceTaxExc);           // 仕入金額（税抜き）
                            paraStockPriceTaxInc.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.StockPriceTaxInc);           // 仕入金額（税込み）
                            paraStockGoodsCd.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.StockGoodsCd);                   // 仕入商品区分
                            paraStockPriceConsTax.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.StockPriceConsTax);         // 仕入金額消費税額
                            paraTaxationCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.TaxationCode);                   // 課税区分
                            paraStockDtiSlipNote1.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.StockDtiSlipNote1);        // 仕入伝票明細備考1
                            paraSalesCustomerCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SalesCustomerCode);         // 販売先コード
                            paraSalesCustomerSnm.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.SalesCustomerSnm);          // 販売先略称
                            paraOrderNumber.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.OrderNumber);                    // 発注番号
                            paraSlipMemo1.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.SlipMemo1);                        // 伝票メモ１
                            paraSlipMemo2.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.SlipMemo2);                        // 伝票メモ２
                            paraSlipMemo3.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.SlipMemo3);                        // 伝票メモ３
                            paraInsideMemo1.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.InsideMemo1);                    // 社内メモ１
                            paraInsideMemo2.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.InsideMemo2);                    // 社内メモ２
                            paraInsideMemo3.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.InsideMemo3);                    // 社内メモ３
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
        public int LogicalDeleteProc(ref ArrayList paramList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StockSlipHistWork stockhistoryWork = null;
            ArrayList stockhistdtlWorkList = null;

            status = this.GetStockHistoryParam(paramList, out stockhistoryWork, out stockhistdtlWorkList);

            if (stockhistoryWork != null)
            {
                status = this.LogicalDeleteProc(ref stockhistoryWork, ref stockhistdtlWorkList, procMode, ref sqlConnection, ref sqlTransaction);

                // 赤伝履歴削除の場合、元黒伝の赤黒連結伝票番号を初期化する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (stockhistoryWork.DebitNoteDiv == 1)
                    {
                        status = this.DeleteDebitNLnkSuppSlipNo(stockhistoryWork, ref sqlConnection, ref sqlTransaction);
                    }
                }
            }

            for (int i = 0; i < paramList.Count; i++)
            {
                if (paramList[i] is StockSlipHistWork)
                {
                    paramList.RemoveAt(i);
                }
                else if (paramList[i] is ArrayList)
                {

                    if ((paramList[i] as ArrayList).Count > 0 && (paramList[i] as ArrayList)[0] is StockSlHistDtlWork)
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
        /// <param name="stockhistoryWork"></param>
        /// <param name="stockhistdtlWorkList"></param>
        /// <param name="procMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int LogicalDeleteProc(ref StockSlipHistWork stockhistoryWork, ref ArrayList stockhistdtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            
            try
            {
                status = this.LogicalDeleteStockSlipHist(ref stockhistoryWork, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (stockhistdtlWorkList != null && stockhistdtlWorkList.Count > 0 && stockhistdtlWorkList[0] is StockSlHistDtlWork)
                    {
                        // 仕入明細履歴データを元に１件ごとに仕入明細履歴データを論理削除する
                        status = this.LogicalDeleteStockSlHistDtl(ref stockhistdtlWorkList, procMode, ref sqlConnection, ref sqlTransaction);
                    }
                    else
                    {
                        // 仕入履歴データを元に１度に複数件の仕入明細履歴データを論理削除する
                        status = this.LogicalDeleteStockSlHistDtl(ref stockhistoryWork, procMode, ref sqlConnection, ref sqlTransaction);
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

                base.WriteErrorLog(ex, "StockSlipHistDB.LogicalDeleteProc :" + procModestr);

                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {

            }
            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockhistoryWork"></param>
        /// <param name="procMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int LogicalDeleteStockSlipHist(ref StockSlipHistWork stockhistoryWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteStockSlipHistProc(ref stockhistoryWork, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockhistoryWork"></param>
        /// <param name="procMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int LogicalDeleteStockSlipHistProc(ref StockSlipHistWork stockhistoryWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                // 仕入形式が 0:仕入 の場合にのみ履歴にデータを操作する
                if (stockhistoryWork != null && stockhistoryWork.SupplierFormal == 0)
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
                    sqlText += "  STOCKSLIPHISTRF AS HIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    # endregion

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                    findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                        if (_updateDateTime != stockhistoryWork.UpdateDateTime)
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
                        sqlText += "  STOCKSLIPHISTRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                        # endregion

                        sqlCommand.CommandText = sqlText;

                        //KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                        findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                        findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)stockhistoryWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (stockhistoryWork.UpdateDateTime > DateTime.MinValue)
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
                        else if (logicalDelCd == 0) stockhistoryWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                        else stockhistoryWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            stockhistoryWork.LogicalDeleteCode = 0; //論理削除フラグを解除
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
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockhistoryWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.LogicalDeleteCode);
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
        /// 仕入明細履歴データの論理削除状態を操作します。
        /// </summary>
        /// <param name="stockhistoryWork">論理削除対象の仕入明細履歴データに紐付く StockHistoryWork</param>
        /// <param name="procMode">動作区分 0:削除, 1:復活</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int LogicalDeleteStockSlHistDtl(ref StockSlipHistWork stockhistoryWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteStockSlHistDtlProc(ref stockhistoryWork, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 仕入明細履歴データの論理削除状態を操作します。
        /// </summary>
        /// <param name="stockhistoryWork">論理削除対象の仕入明細履歴データに紐付く StockHistoryWork</param>
        /// <param name="procMode">動作区分 0:削除, 1:復活</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        private int LogicalDeleteStockSlHistDtlProc(ref StockSlipHistWork stockhistoryWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                // 仕入形式が 0:仕入 の場合にのみ履歴にデータを操作する
                if (stockhistoryWork != null && stockhistoryWork.SupplierFormal == 0)
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
                    sqlText += "  STOCKSLIPHISTRF AS HIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    # endregion

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                    findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                        if (_updateDateTime != stockhistoryWork.UpdateDateTime)
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
                        sqlText += "  STOCKSLHISTDTLRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                        # endregion

                        sqlCommand.CommandText = sqlText;

                        //KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                        findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                        findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)stockhistoryWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (stockhistoryWork.UpdateDateTime > DateTime.MinValue)
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

                    // 紐付く仕入履歴データの論理削除区分を踏襲する
                    /*
                    //論理削除モードの場合
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                            return status;
                        }
                        else if (logicalDelCd == 0) stockhistoryWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                        else stockhistoryWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            stockhistoryWork.LogicalDeleteCode = 0; //論理削除フラグを解除
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
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockhistoryWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockhistoryWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.LogicalDeleteCode);
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
        /// 仕入明細履歴データの論理削除状態を操作します。
        /// </summary>
        /// <param name="stockhistdtlWorkList">論理削除対象の StockhistdtlWork を格納する ArrayList</param>
        /// <param name="procMode">動作区分 0:削除, 1:復活</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        public int LogicalDeleteStockSlHistDtl(ref ArrayList stockhistdtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteStockSlHistDtlProc(ref stockhistdtlWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 仕入明細履歴データの論理削除状態を操作します。
        /// </summary>
        /// <param name="stockhistdtlWorkList">論理削除対象の StockhistdtlWork を格納する ArrayList</param>
        /// <param name="procMode">動作区分 0:削除, 1:復活</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        private int LogicalDeleteStockSlHistDtlProc(ref ArrayList stockhistdtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (stockhistdtlWorkList != null && stockhistdtlWorkList.Count > 0 && stockhistdtlWorkList[0] is StockSlHistDtlWork)
                {
                    int logicalDelCd = (int)ConstantManagement.LogicalMode.GetData0;
                    
                    foreach (object item in stockhistdtlWorkList)
                    {
                        StockSlHistDtlWork stockhistdtlWork = item as StockSlHistDtlWork;

                        // 仕入形式が 0:仕入 の場合にのみ履歴データを登録する
                        if (stockhistdtlWork != null && stockhistdtlWork.SupplierFormal == 0)
                        {
                            //Selectコマンドの生成
                            #region [SELECT文]
                            string sqlText = "";
                            sqlText += "SELECT" + Environment.NewLine;
                            sqlText += "  DTL.UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,DTL.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  STOCKSLHISTDTLRF AS DTL" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  DTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND DTL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                            sqlText += "  AND DTL.STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
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
                            SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                            SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);

                            //Parameterオブジェクトへ値設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.EnterpriseCode);
                            findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SupplierFormal);
                            findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.StockSlipDtlNum);

                            myReader = sqlCommand.ExecuteReader();

                            if (myReader.Read())
                            {
                                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                                if (_updateDateTime != stockhistdtlWork.UpdateDateTime)
                                {
                                    //新規登録で該当データ有りの場合には重複
                                    if (stockhistdtlWork.UpdateDateTime == DateTime.MinValue)
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
                                sqlText += "  STOCKSLHISTDTLRF" + Environment.NewLine;
                                sqlText += "SET" + Environment.NewLine;
                                sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                                sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                                sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                                sqlText += "WHERE" + Environment.NewLine;
                                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                                sqlText += "  AND STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                                # endregion

                                sqlCommand.CommandText = sqlText;

                                //KEYコマンドを再設定
                                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.EnterpriseCode);
                                findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SupplierFormal);
                                findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.StockSlipDtlNum);

                                //更新ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)stockhistdtlWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);
                            }
                            else
                            {
                                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                                if (stockhistdtlWork.UpdateDateTime > DateTime.MinValue)
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
                                else if (logicalDelCd == 0) stockhistdtlWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                                else stockhistdtlWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                            }
                            else
                            {
                                if (logicalDelCd == 1)
                                {
                                    stockhistdtlWork.LogicalDeleteCode = 0; //論理削除フラグを解除
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
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockhistdtlWork.UpdateDateTime);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.LogicalDeleteCode);
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

        // --- ADD 連番966 2011/08/16 ---------->>>>>
        /// <summary>
        /// 仕入履歴明細データの同時売上情報をクリアする。
        /// </summary>
        /// <param name="stockDetailWork">仕入明細work</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 連番966 仕入履歴明細データの同時売上情報をクリアする。</br>
        /// <br>Programmer : 許雁波</br>
        /// <br>Date       : 2011/08/16</br>
        /// <br></br>
        /// <br>Update Note: 売上仕入同時入力の売上データ削除時、仕入明細通番の型不正が発生する不具合の修正</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2011/10/14</br>
        public int ClearStockSlHistDtlSync(ref StockDetailWork stockDetailWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE STOCKSLHISTDTLRF SET UPDATEDATETIMERF=@UPDATEDATETIME,ENTERPRISECODERF=@ENTERPRISECODE,FILEHEADERGUIDRF=@FILEHEADERGUID,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE,UPDASSEMBLYID1RF=@UPDASSEMBLYID1,UPDASSEMBLYID2RF=@UPDASSEMBLYID2,ACPTANODRSTATUSSYNCRF=0,SALESSLIPDTLNUMSYNCRF=0 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUMRF ", sqlConnection, sqlTransaction))
                {
                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)stockDetailWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);

                    //Prameterオブジェクトの作成
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);

                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    // -- UPD 2011/10/14 ----------------------------->>>
                    //SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUMRF", SqlDbType.Int);
                    SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUMRF", SqlDbType.BigInt);
                    // -- UPD 2011/10/14 -----------------------------<<<

                    //KEYコマンドを再設定
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockDetailWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockDetailWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdAssemblyId2);

                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.EnterpriseCode);
                    findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SupplierFormal);
                    findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.StockSlipDtlNum);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }

            return status;
        }
        // --- ADD 連番966 2011/08/16 ----------<<<<<

        #region [Delete]
        /// <summary>
        /// 仕入履歴データ情報を物理削除します
        /// </summary>
        /// <param name="paramList">仕入履歴データ情報オブジェクト</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        /// <br>Note       : 仕入履歴データ情報を物理削除します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.24</br>
        public int Delete(ref ArrayList paramList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            StockSlipHistWork stockhistoryWork = null;
            ArrayList stockhistdtlWorkList = null;

            try
            {
                this.GetStockHistoryParam(paramList, out stockhistoryWork, out stockhistdtlWorkList);

                if (stockhistoryWork != null)
                {
                    //Delete実行
                    status = this.DeleteProc(ref stockhistoryWork, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
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
        /// <param name="stockhistoryWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int DeleteProc(ref StockSlipHistWork stockhistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            status = this.DeleteStockSlipHist(ref stockhistoryWork, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = this.DeleteStockSlHistDtl(ref stockhistoryWork, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }

        /// <summary>
        /// 仕入履歴データ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="stockhistoryWork">仕入履歴データ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 仕入履歴データ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.24</br>
        public int DeleteStockSlipHist(ref StockSlipHistWork stockhistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteStockSlipHistProc(ref stockhistoryWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 仕入履歴データ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="stockhistoryWork">仕入履歴データ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 仕入履歴データ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.24</br>
        private int DeleteStockSlipHistProc(ref StockSlipHistWork stockhistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                // 仕入形式が 0:仕入 の場合にのみ履歴にデータを操作する
                if (stockhistoryWork != null && stockhistoryWork.SupplierFormal == 0)
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
                    sqlText += "  STOCKSLIPHISTRF AS HIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    # endregion

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                    findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                        if (_updateDateTime != stockhistoryWork.UpdateDateTime)
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
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  STOCKSLIPHISTRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                        # endregion

                        sqlCommand.CommandText = sqlText;

                        //KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                        findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                        findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

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
                        if (stockhistoryWork.UpdateDateTime > DateTime.MinValue)
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
        /// 
        /// </summary>
        /// <param name="stockhistoryWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int DeleteStockSlHistDtl(ref StockSlipHistWork stockhistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteStockSlHistDtlProc(ref stockhistoryWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockhistoryWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int DeleteStockSlHistDtlProc(ref StockSlipHistWork stockhistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                // 仕入形式が 0:仕入 の場合にのみ履歴にデータを操作する
                if (stockhistoryWork != null && stockhistoryWork.SupplierFormal == 0)
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
                    sqlText += "  STOCKSLIPHISTRF AS HIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    # endregion

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                    findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                        if (_updateDateTime != stockhistoryWork.UpdateDateTime)
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
                        sqlText += "  STOCKSLIPHISTRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                        # endregion

                        sqlCommand.CommandText = sqlText;

                        //KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistoryWork.EnterpriseCode);
                        findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierFormal);
                        findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockhistoryWork.SupplierSlipNo);

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
                        if (stockhistoryWork.UpdateDateTime > DateTime.MinValue)
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
        /// 
        /// </summary>
        /// <param name="stockhistdtlWorkList"></param>
        /// <param name="procMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int DeleteStockSlHistDtl(ref ArrayList stockhistdtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteStockSlHistDtlProc(ref stockhistdtlWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockhistdtlWorkList"></param>
        /// <param name="procMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int DeleteStockSlHistDtlProc(ref ArrayList stockhistdtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (stockhistdtlWorkList != null && stockhistdtlWorkList.Count > 0 && stockhistdtlWorkList[0] is StockSlHistDtlWork)
                {
                    //int logicalDelCd = (int)ConstantManagement.LogicalMode.GetData0;

                    foreach (object item in stockhistdtlWorkList)
                    {
                        StockSlHistDtlWork stockhistdtlWork = item as StockSlHistDtlWork;

                        // 仕入形式が 0:仕入 の場合にのみ履歴データを登録する
                        if (stockhistdtlWork != null && stockhistdtlWork.SupplierFormal == 0)
                        {
                            //Selectコマンドの生成
                            #region [SELECT文]
                            string sqlText = "";
                            sqlText += "SELECT" + Environment.NewLine;
                            sqlText += "  DTL.UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,DTL.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  STOCKSLIPHISTRF AS DTL" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  DTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND DTL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                            sqlText += "  AND DTL.STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                            # endregion

                            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                            // Prameterオブジェクトの作成
                            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                            SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);

                            //Parameterオブジェクトへ値設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.EnterpriseCode);
                            findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SupplierFormal);
                            findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.StockSlipDtlNum);

                            myReader = sqlCommand.ExecuteReader();

                            if (myReader.Read())
                            {
                                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                                if (_updateDateTime != stockhistdtlWork.UpdateDateTime)
                                {
                                    //新規登録で該当データ有りの場合には重複
                                    if (stockhistdtlWork.UpdateDateTime == DateTime.MinValue)
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
                                sqlText += "DELETE" + Environment.NewLine;
                                sqlText += "  STOCKSLIPHISTRF" + Environment.NewLine;
                                sqlText += "WHERE" + Environment.NewLine;
                                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                                sqlText += "  AND STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                                # endregion

                                sqlCommand.CommandText = sqlText;

                                //KEYコマンドを再設定
                                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockhistdtlWork.EnterpriseCode);
                                findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockhistdtlWork.SupplierFormal);
                                findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockhistdtlWork.StockSlipDtlNum);
                            }
                            else
                            {
                                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                                if (stockhistdtlWork.UpdateDateTime > DateTime.MinValue)
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
            StockSlipHistWork redStockHistoryWork = null;
            ArrayList redStockHistDtlWorkList = null;

            status = this.MakeStockHistoryParam(redSlipList, out redStockHistoryWork, out redStockHistDtlWorkList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            
            // 赤伝履歴登録
            status = this.WriteProc(ref redStockHistoryWork, ref redStockHistDtlWorkList, ref sqlConnection, ref sqlTransaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            // 元黒格納用
            StockSlipHistWork blkStockHistoryWork = null;
            ArrayList blkStockHistDtlWorkList = null;

            status = this.MakeStockHistoryParam(blkSlipList, out blkStockHistoryWork, out blkStockHistDtlWorkList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            // 元黒履歴登録
            status = this.WriteProc(ref blkStockHistoryWork, ref blkStockHistDtlWorkList, ref sqlConnection, ref sqlTransaction);

            return status;
        }

        /// <summary>
        /// 元黒伝の赤黒連結仕入伝票番号をリセットします
        /// </summary>
        /// <param name="stockHistoryWork">履歴伝票削除パラメータ</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクションオブジェクト</param>
        /// <returns>STATUS</returns>
        private int DeleteDebitNLnkSuppSlipNo(StockSlipHistWork stockHistoryWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
				// ADD 2011/09/08 qijh SCM対応 - 拠点管理(10704767-00) #24609 --------->>>>>
				IFileHeader flhd = (IFileHeader)new StockSlipHistWork();
				new FileHeader(this).SetUpdateHeader(ref flhd, this);
				// ADD 2011/09/08 qijh SCM対応 - 拠点管理(10704767-00) #24609 ---------<<<<<
                string sqlText = "";
                sqlText += "UPDATE" + Environment.NewLine;
                sqlText += "  STOCKSLIPHISTRF" + Environment.NewLine;
                sqlText += "SET" + Environment.NewLine;
                sqlText += "  DEBITNLNKSUPPSLIPNORF = 0" + Environment.NewLine;
				sqlText += " ,DEBITNOTEDIVRF = 0" + Environment.NewLine;
				// ADD 2011/09/08 qijh SCM対応 - 拠点管理(10704767-00) #24609 --------->>>>>
				sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
				sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
				sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
				sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
				// ADD 2011/09/08 qijh SCM対応 - 拠点管理(10704767-00) #24609 ---------<<<<<
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                sqlText += "  AND DEBITNLNKSUPPSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
					SqlParameter findParaSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
					// ADD 2011/09/08 qijh SCM対応 - 拠点管理(10704767-00) #24609 --------->>>>>
					SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
					SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
					SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
					SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
					// ADD 2011/09/08 qijh SCM対応 - 拠点管理(10704767-00) #24609 ---------<<<<<

                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockHistoryWork.EnterpriseCode);
                    findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.SupplierFormal);
					findParaSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.SupplierSlipNo);
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
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }

            return status;
        }

        # endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → StockHistoryWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockHistoryWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        private StockSlipHistWork CopyToStockHistoryWorkFromReader(SqlDataReader myReader)
        {
            StockSlipHistWork wkStockHistoryWork = new StockSlipHistWork();

            this.CopyToStockHistoryWorkFromReader(myReader, ref wkStockHistoryWork);
            
            return wkStockHistoryWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="stockSlipHistWork"></param>
        private void CopyToStockHistoryWorkFromReader(SqlDataReader myReader, ref StockSlipHistWork stockSlipHistWork)
        {
            //＠仕入履歴データ変更＠
            // stockSlipHistWork.<#FieldName> = SqlDataMediator.<#sqlDbTypeGetAccessor>(myReader,myReader.GetOrdinal("<#FIELDRfield.Name>"));  // <#name>
            if (stockSlipHistWork != null)
            {
                #region クラスへ格納
                stockSlipHistWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));             // 作成日時
                stockSlipHistWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));             // 更新日時
                stockSlipHistWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));                        // 企業コード
                stockSlipHistWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                          // GUID
                stockSlipHistWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));                      // 更新従業員コード
                stockSlipHistWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));                        // 更新アセンブリID1
                stockSlipHistWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));                        // 更新アセンブリID2
                stockSlipHistWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));                   // 論理削除区分
                stockSlipHistWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));                         // 仕入形式
                stockSlipHistWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));                         // 仕入伝票番号
                stockSlipHistWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));                              // 拠点コード
                stockSlipHistWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));                         // 部門コード
                stockSlipHistWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));                             // 赤伝区分
                stockSlipHistWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));               // 赤黒連結仕入伝票番号
                stockSlipHistWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));                         // 仕入伝票区分
                stockSlipHistWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));                             // 仕入商品区分
                stockSlipHistWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));                               // 買掛区分
                stockSlipHistWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));                        // 仕入拠点コード
                stockSlipHistWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));              // 仕入計上拠点コード
                stockSlipHistWork.StockSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPUPDATECDRF"));                   // 仕入伝票更新区分
                stockSlipHistWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));                      // 入力日
                stockSlipHistWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));        // 入荷日
                stockSlipHistWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));                    // 仕入日
                stockSlipHistWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));        // 仕入計上日付
                stockSlipHistWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));                       // 来勘区分
                stockSlipHistWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));                                   // 支払先コード
                stockSlipHistWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));                                    // 支払先略称
                stockSlipHistWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));                                 // 仕入先コード
                stockSlipHistWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));                              // 仕入先名1
                stockSlipHistWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));                              // 仕入先名2
                stockSlipHistWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));                              // 仕入先略称
                stockSlipHistWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));                     // 業種コード
                stockSlipHistWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));                    // 業種名称
                stockSlipHistWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));                           // 販売エリアコード
                stockSlipHistWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));                          // 販売エリア名称
                stockSlipHistWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));                        // 仕入入力者コード
                stockSlipHistWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));                        // 仕入入力者名称
                stockSlipHistWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));                        // 仕入担当者コード
                stockSlipHistWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));                        // 仕入担当者名称
                stockSlipHistWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));               // 仕入先総額表示方法区分
                stockSlipHistWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));                 // 総額表示掛率適用区分
                stockSlipHistWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));                       // 仕入金額合計
                stockSlipHistWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));                     // 仕入金額小計
                stockSlipHistWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));                 // 仕入金額計（税込み）
                stockSlipHistWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));                 // 仕入金額計（税抜き）
                stockSlipHistWork.StockNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKNETPRICERF"));                           // 仕入正価金額
                stockSlipHistWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));                   // 仕入金額消費税額
                stockSlipHistWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));                   // 仕入外税対象額合計
                stockSlipHistWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));                     // 仕入内税対象額合計
                stockSlipHistWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));                 // 仕入非課税対象額合計
                stockSlipHistWork.StockOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAXRF"));                               // 仕入金額消費税額（外税）
                stockSlipHistWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));               // 仕入金額消費税額（内税）
                stockSlipHistWork.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXEXCRF"));                     // 仕入値引金額計（税抜き）
                stockSlipHistWork.ItdedStockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISOUTTAXRF"));               // 仕入値引外税対象額合計
                stockSlipHistWork.ItdedStockDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISINTAXRF"));                 // 仕入値引内税対象額合計
                stockSlipHistWork.ItdedStockDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISTAXFRERF"));               // 仕入値引非課税対象額合計
                stockSlipHistWork.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKDISOUTTAXRF"));                         // 仕入値引消費税額（外税）
                stockSlipHistWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));                 // 仕入値引消費税額（内税）
                stockSlipHistWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));                                   // 消費税調整額
                stockSlipHistWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));                           // 残高調整額
                stockSlipHistWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));                           // 仕入先消費税転嫁方式コード
                stockSlipHistWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));              // 仕入先消費税税率
                stockSlipHistWork.AccPayConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCPAYCONSTAXRF"));                           // 買掛消費税
                stockSlipHistWork.StockFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKFRACTIONPROCCDRF"));               // 仕入端数処理区分
                stockSlipHistWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));                               // 自動支払区分
                stockSlipHistWork.AutoPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYSLIPNUMRF"));                         // 自動支払伝票番号
                stockSlipHistWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));                   // 返品理由コード
                stockSlipHistWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));                        // 返品理由
                stockSlipHistWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));                    // 相手先伝票番号
                stockSlipHistWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));                  // 仕入伝票備考1
                stockSlipHistWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));                  // 仕入伝票備考2
                stockSlipHistWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));                         // 明細行数
                stockSlipHistWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));                // ＥＤＩ送信日
                stockSlipHistWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));            // ＥＤＩ取込日
                stockSlipHistWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));                                // ＵＯＥリマーク１
                stockSlipHistWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));                                // ＵＯＥリマーク２
                stockSlipHistWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));                         // 伝票発行区分
                stockSlipHistWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));                   // 伝票発行済区分
                stockSlipHistWork.StockSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKSLIPPRINTDATERF"));  // 仕入伝票発行日
                stockSlipHistWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));                  // 伝票印刷設定用帳票ID
                #endregion
            }
        }

        /// <summary>
        /// クラス格納処理 Reader → StockHistDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockHistDtlWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        private StockSlHistDtlWork CopyToStockHistDtlWorkFromReader(SqlDataReader myReader)
        {
            StockSlHistDtlWork wkStockHistDtlWork = new StockSlHistDtlWork();

            this.CopyToStockHistDtlWorkFromReader(myReader, ref wkStockHistDtlWork);

            return wkStockHistDtlWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="stockSlHistDtlWork"></param>
        private void CopyToStockHistDtlWorkFromReader(SqlDataReader myReader, ref StockSlHistDtlWork stockSlHistDtlWork)
        {
            //＠仕入履歴明細データ変更＠
            //stockSlHistDtlWork.<#FieldName> = SqlDataMediator.<#sqlDbTypeGetAccessor>(myReader,myReader.GetOrdinal("<#FIELDRfield.Name>"));  // <#name>
            if (stockSlHistDtlWork != null)
            {
                #region クラスへ格納
                stockSlHistDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));   // 作成日時
                stockSlHistDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));   // 更新日時
                stockSlHistDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));              // 企業コード
                stockSlHistDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                // GUID
                stockSlHistDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));            // 更新従業員コード
                stockSlHistDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));              // 更新アセンブリID1
                stockSlHistDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));              // 更新アセンブリID2
                stockSlHistDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));         // 論理削除区分
                stockSlHistDtlWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));             // 受注番号
                stockSlHistDtlWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));               // 仕入形式
                stockSlHistDtlWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));               // 仕入伝票番号
                stockSlHistDtlWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));                       // 仕入行番号
                stockSlHistDtlWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));                    // 拠点コード
                stockSlHistDtlWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));               // 部門コード
                stockSlHistDtlWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));                     // 共通通番
                stockSlHistDtlWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));             // 仕入明細通番
                stockSlHistDtlWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSRCRF"));         // 仕入形式（元）
                stockSlHistDtlWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSRCRF"));       // 仕入明細通番（元）
                stockSlHistDtlWork.AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSYNCRF"));     // 受注ステータス（同時）
                stockSlHistDtlWork.SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSYNCRF"));     // 売上明細通番（同時）
                stockSlHistDtlWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));               // 仕入伝票区分（明細）
                stockSlHistDtlWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));              // 仕入担当者コード
                stockSlHistDtlWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));              // 仕入担当者名称
                stockSlHistDtlWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));                 // 商品属性
                stockSlHistDtlWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));                   // 商品メーカーコード
                stockSlHistDtlWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));                        // メーカー名称
                stockSlHistDtlWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));                // メーカーカナ名称
                stockSlHistDtlWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERKANANAMERF"));      // メーカーカナ名称（一式）
                stockSlHistDtlWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));                            // 商品番号
                stockSlHistDtlWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));                        // 商品名称
                stockSlHistDtlWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));                // 商品名称カナ
                stockSlHistDtlWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));                     // 商品大分類コード
                stockSlHistDtlWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));            // 商品大分類名称
                stockSlHistDtlWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));                     // 商品中分類コード
                stockSlHistDtlWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));            // 商品中分類名称
                stockSlHistDtlWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));                     // BLグループコード
                stockSlHistDtlWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));                    // BLグループコード名称
                stockSlHistDtlWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));                     // BL商品コード
                stockSlHistDtlWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));            // BL商品コード名称（全角）
                stockSlHistDtlWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));     // 自社分類コード
                stockSlHistDtlWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));    // 自社分類名称
                stockSlHistDtlWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));                // 倉庫コード
                stockSlHistDtlWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));                // 倉庫名称
                stockSlHistDtlWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));          // 倉庫棚番
                stockSlHistDtlWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));             // 仕入在庫取寄せ区分
                stockSlHistDtlWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));                   // オープン価格区分
                stockSlHistDtlWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));                // 商品掛率ランク
                stockSlHistDtlWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));             // 得意先掛率グループコード
                stockSlHistDtlWork.SuppRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPRATEGRPCODERF"));             // 仕入先掛率グループコード
                stockSlHistDtlWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));        // 定価（税抜，浮動）
                stockSlHistDtlWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));        // 定価（税込，浮動）
                stockSlHistDtlWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));                        // 仕入率
                stockSlHistDtlWork.RateSectStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSTCKUNPRCRF"));        // 掛率設定拠点（仕入単価）
                stockSlHistDtlWork.RateDivStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSTCKUNPRCRF"));          // 掛率設定区分（仕入単価）
                stockSlHistDtlWork.UnPrcCalcCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSTCKUNPRCRF"));   // 単価算出区分（仕入単価）
                stockSlHistDtlWork.PriceCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSTCKUNPRCRF"));           // 価格区分（仕入単価）
                stockSlHistDtlWork.StdUnPrcStckUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSTCKUNPRCRF"));        // 基準単価（仕入単価）
                stockSlHistDtlWork.FracProcUnitStcUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSTCUNPRCRF"));  // 端数処理単位（仕入単価）
                stockSlHistDtlWork.FracProcStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSTCKUNPRCRF"));         // 端数処理（仕入単価）
                stockSlHistDtlWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));          // 仕入単価（税抜，浮動）
                stockSlHistDtlWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));    // 仕入単価（税込，浮動）
                stockSlHistDtlWork.StockUnitChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNITCHNGDIVRF"));           // 仕入単価変更区分
                stockSlHistDtlWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));      // 変更前仕入単価（浮動）
                stockSlHistDtlWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));                    // 変更前定価
                stockSlHistDtlWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));             // BL商品コード（掛率）
                stockSlHistDtlWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));            // BL商品コード名称（掛率）
                stockSlHistDtlWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPCDRF"));       // 商品掛率グループコード（掛率）
                stockSlHistDtlWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPNMRF"));      // 商品掛率グループ名称（掛率）
                stockSlHistDtlWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGROUPCODERF"));             // BLグループコード（掛率）
                stockSlHistDtlWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGROUPNAMERF"));            // BLグループ名称（掛率）
                stockSlHistDtlWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));                      // 仕入数
                stockSlHistDtlWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));           // 仕入金額（税抜き）
                stockSlHistDtlWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));           // 仕入金額（税込み）
                stockSlHistDtlWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));                   // 仕入商品区分
                stockSlHistDtlWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));         // 仕入金額消費税額
                stockSlHistDtlWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));                   // 課税区分
                stockSlHistDtlWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));        // 仕入伝票明細備考1
                stockSlHistDtlWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));         // 販売先コード
                stockSlHistDtlWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERSNMRF"));          // 販売先略称
                stockSlHistDtlWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));                    // 発注番号
                stockSlHistDtlWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));                        // 伝票メモ１
                stockSlHistDtlWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));                        // 伝票メモ２
                stockSlHistDtlWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));                        // 伝票メモ３
                stockSlHistDtlWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));                    // 社内メモ１
                stockSlHistDtlWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));                    // 社内メモ２
                stockSlHistDtlWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));                    // 社内メモ３
                #endregion
            }
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            StockSlipHistWork[] StockHistoryWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is StockSlipHistWork)
                    {
                        StockSlipHistWork wkStockHistoryWork = paraobj as StockSlipHistWork;
                        if (wkStockHistoryWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkStockHistoryWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            StockHistoryWorkArray = (StockSlipHistWork[])XmlByteSerializer.Deserialize(byteArray, typeof(StockSlipHistWork[]));
                        }
                        catch (Exception) { }
                        if (StockHistoryWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(StockHistoryWorkArray);
                        }
                        else
                        {
                            try
                            {
                                StockSlipHistWork wkStockHistoryWork = (StockSlipHistWork)XmlByteSerializer.Deserialize(byteArray, typeof(StockSlipHistWork));
                                if (wkStockHistoryWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkStockHistoryWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //特に何もしない
                }

            return retal;
        }
        #endregion

        # region [ｰｰｰDEL 2008/06/03 M.Kubota ---]
#if false
        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
#endif
        # endregion
    }
}
