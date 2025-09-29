//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   仕入先マスタ（総括設定）DBリモートオブジェクト
//                  :   PMKAK09004R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   FSI斎藤 和宏
// Date             :   2012/08/29
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//**********************************************************************

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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入先マスタ（総括設定）DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先マスタ（総括設定）の実データ操作を行うクラスです。</br>
    /// <br>Programmer : FSI斎藤 和宏</br>
    /// <br>Date       : 2012/08/29</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SumSuppStDB : RemoteWithAppLockDB, ISumSuppStDB
    {
        /// <summary>
        /// 仕入先マスタ（総括設定）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        /// </remarks>
        public SumSuppStDB()
            : base("PMKAK09006D", "Broadleaf.Application.Remoting.ParamData.SumSuppStWork", "SUMSUPPSTRF")
        {

        }

        # region [Delete]
        /// <summary>
        /// 仕入先マスタ（総括設定）情報を物理削除します
        /// </summary>
        /// <param name="sumSuppStList">物理削除する仕入先マスタ（総括設定）情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタ（総括設定）のキー値が一致する仕入先マスタ（総括設定）情報を物理削除します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        public int Delete(object sumSuppStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = sumSuppStList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, ref sqlConnection, ref sqlTransaction);
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
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

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
        /// 仕入先マスタ（総括設定）情報を物理削除します
        /// </summary>
        /// <param name="sumSuppStList">仕入先マスタ（総括設定）情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList に格納されている仕入先マスタ（総括設定）情報を物理削除します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        public int Delete(ArrayList sumSuppStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(sumSuppStList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 仕入先マスタ（総括設定）情報を物理削除します
        /// </summary>
        /// <param name="sumSuppStList">仕入先マスタ（総括設定）情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList に格納されている仕入先マスタ（総括設定）情報を物理削除します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        private int DeleteProc(ArrayList sumSuppStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            StringBuilder sqlString = new StringBuilder(string.Empty);

            try
            {
                if (sumSuppStList != null)
                {
                    
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // タイムアウト時間を10分に設定
                    sqlCommand.CommandTimeout = 600;

                    for (int i = 0; i < sumSuppStList.Count; i++)
                    {
                        SumSuppStWork sumSuppStWork = sumSuppStList[i] as SumSuppStWork;
                        sqlString = new StringBuilder(string.Empty);

                        # region [SELECT文]
                        sqlString.AppendLine("SELECT");
                        sqlString.AppendLine("  UPDATEDATETIMERF");
                        sqlString.AppendLine("FROM");
                        sqlString.AppendLine("  SUMSUPPSTRF");
                        sqlString.AppendLine("WHERE");
                        sqlString.AppendLine("      ENTERPRISECODERF = @FINDENTERPRISECODE");
                        sqlString.AppendLine("  AND SUMSECTIONCDRF = @FINDSUMSECTIONCODE");
                        sqlString.AppendLine("  AND SUMSUPPLIERCDRF = @FINDSUMSUPPLIERCODE");
                        sqlString.AppendLine("  AND SECTIONCODERF = @FINDSECTIONCODE");
                        sqlString.AppendLine("  AND SUPPLIERCDRF = @FINDSUPPLIERCODE");
                        # endregion

                        sqlCommand.CommandText = sqlString.ToString();

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSumSectionCode = sqlCommand.Parameters.Add("@FINDSUMSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findSumSupplierCode = sqlCommand.Parameters.Add("@FINDSUMSUPPLIERCODE", SqlDbType.Int);
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findSupplierCode = sqlCommand.Parameters.Add("@FINDSUPPLIERCODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.EnterpriseCode);
                        findSumSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SumSectionCd.Trim());
                        findSumSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SumSupplierCd);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SectionCode.Trim());
                        findSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SupplierCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != sumSuppStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }
                            else
                            {
                                sqlString = new StringBuilder(string.Empty);

                                # region [DELETE文]
                                sqlString.AppendLine("DELETE");
                                sqlString.AppendLine("FROM");
                                sqlString.AppendLine("  SUMSUPPSTRF");
                                sqlString.AppendLine("WHERE");
                                sqlString.AppendLine("      ENTERPRISECODERF = @FINDENTERPRISECODE");
                                sqlString.AppendLine("  AND SUMSECTIONCDRF = @FINDSUMSECTIONCODE");
                                sqlString.AppendLine("  AND SUMSUPPLIERCDRF = @FINDSUMSUPPLIERCODE");
                                sqlString.AppendLine("  AND SECTIONCODERF = @FINDSECTIONCODE");
                                sqlString.AppendLine("  AND SUPPLIERCDRF = @FINDSUPPLIERCODE");
                                # endregion

                                sqlCommand.CommandText = sqlString.ToString();

                                // KEYコマンドを再設定
                                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.EnterpriseCode);
                                findSumSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SumSectionCd.Trim());
                                findSumSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SumSupplierCd);
                                findSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SectionCode.Trim());
                                findSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SupplierCode);
                            }

                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        # region [Search]
        /// <summary>
        /// 仕入先マスタ（総括設定）情報のリストを取得します。
        /// </summary>
        /// <param name="sumSuppStList">検索結果</param>
        /// <param name="sumSuppStparaObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタ（総括設定）のキー値が一致する、全ての仕入先マスタ（総括設定）情報を取得します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        public int Search(ref object sumSuppStList, object sumSuppStparaObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList sumSuppStArray = sumSuppStList as ArrayList;

                if (sumSuppStArray == null)
                {
                    sumSuppStArray = new ArrayList();
                }

                SumSuppStWork sumSuppStWork = sumSuppStparaObj as SumSuppStWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref sumSuppStArray, sumSuppStWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

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
        /// 仕入先マスタ（総括設定）情報のリストを取得します。
        /// </summary>
        /// <param name="sumSuppStList">仕入先マスタ（総括設定）情報を格納する ArrayList</param>
        /// <param name="sumSuppStparaObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタ（総括設定）のキー値が一致する、全ての仕入先マスタ（総括設定）情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        public int Search(ref ArrayList sumSuppStList, SumSuppStWork sumSuppStparaObj, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref sumSuppStList, sumSuppStparaObj, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 仕入先マスタ（総括設定）情報のリストを取得します。
        /// </summary>
        /// <param name="sumSuppStList">仕入先マスタ（総括設定）情報を格納する ArrayList</param>
        /// <param name="sumSuppStparaObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタ（総括設定）のキー値が一致する、全ての仕入先マスタ（総括設定）情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        private int SearchProc(ref ArrayList sumSuppStList, SumSuppStWork sumSuppStparaObj, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            StringBuilder sqlString = new StringBuilder(string.Empty);

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                // タイムアウト時間を10分に設定
                sqlCommand.CommandTimeout = 600;

                // READ UNCOMMITTEDの設定
                sqlCommand.Transaction = sqlConnection.BeginTransaction(IsolationLevel.ReadUncommitted);
                
                # region [SELECT文]
                sqlString.AppendLine("SELECT");
                sqlString.AppendLine("  *");
                sqlString.AppendLine("FROM");
                sqlString.AppendLine("  SUMSUPPSTRF");
                sqlString.AppendLine("WHERE");
                sqlString.AppendLine("        ENTERPRISECODERF = @FINDENTERPRISECODE");
                sqlString.AppendLine("  AND (@FINDSUMSECTIONCODE IS NULL OR @FINDSUMSECTIONCODE = SUMSECTIONCDRF)");
                sqlString.AppendLine("  AND (@FINDSUMSUPPLIERCODE = 0 OR @FINDSUMSUPPLIERCODE = SUMSUPPLIERCDRF)");

                # region [論理削除データ抽出Where句追加処理]
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlString.AppendLine("  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlString.AppendLine("  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE");
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                # endregion [論理削除データ抽出Where句追加処理]

                sqlString.AppendLine("ORDER BY");
                sqlString.AppendLine("  SUMSECTIONCDRF, SUMSUPPLIERCDRF");

                sqlCommand.CommandText = sqlString.ToString();

                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findSumSectionCode = sqlCommand.Parameters.Add("@FINDSUMSECTIONCODE", SqlDbType.NChar);
                SqlParameter findSumSupplierCode = sqlCommand.Parameters.Add("@FINDSUMSUPPLIERCODE", SqlDbType.Int);

                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumSuppStparaObj.EnterpriseCode);
                findSumSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStparaObj.SumSectionCd);
                findSumSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStparaObj.SumSupplierCd);
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    sumSuppStList.Add(this.CopyToSumSuppStWorkFromReader(ref myReader));
                }

                if (sumSuppStList.Count > 0)
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
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        # region [Write]
        /// <summary>
        /// 仕入先マスタ（総括設定）情報を追加・更新します。
        /// </summary>
        /// <param name="sumSuppStList">追加・更新する仕入先マスタ（総括設定）情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList に格納されている仕入先マスタ（総括設定）情報を追加・更新します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        public int Write(ref object sumSuppStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = sumSuppStList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);
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
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

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
        /// 仕入先マスタ（総括設定）情報を追加・更新します。
        /// </summary>
        /// <param name="sumSuppStList">追加・更新する仕入先マスタ（総括設定）情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList に格納されている仕入先マスタ（総括設定）情報を追加・更新します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        public int Write(ref ArrayList sumSuppStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref sumSuppStList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 仕入先マスタ（総括設定）情報を追加・更新します。
        /// </summary>
        /// <param name="sumSuppStList">追加・更新する仕入先マスタ（総括設定）情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList に格納されている仕入先マスタ（総括設定）情報を追加・更新します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        private int WriteProc(ref ArrayList sumSuppStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            StringBuilder sqlString = new StringBuilder(string.Empty);

            try
            {
                if (sumSuppStList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // タイムアウト時間を10分に設定
                    sqlCommand.CommandTimeout = 600;

                    SumSuppStWork sumSuppStWork = sumSuppStList[0] as SumSuppStWork;

                    #region [DELETE文(INSERT前)]
                    sqlString.AppendLine("DELETE");
                    sqlString.AppendLine("FROM");
                    sqlString.AppendLine("  SUMSUPPSTRF");
                    sqlString.AppendLine("WHERE");
                    sqlString.AppendLine("      ENTERPRISECODERF = @FINDENTERPRISECODE");
                    sqlString.AppendLine("  AND SUMSECTIONCDRF = @FINDSUMSECTIONCODE");
                    sqlString.AppendLine("  AND SUMSUPPLIERCDRF = @FINDSUMSUPPLIERCODE");
                    #endregion [DELETE文(INSERT前)]

                    sqlCommand.CommandText = sqlString.ToString();

                    // Prameterオブジェクトの作成
                    sqlCommand.Parameters.Clear();
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSumSectionCode = sqlCommand.Parameters.Add("@FINDSUMSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findSumSupplierCode = sqlCommand.Parameters.Add("@FINDSUMSUPPLIERCODE", SqlDbType.Int);

                    // KEYコマンドを再設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.EnterpriseCode);
                    findSumSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SumSectionCd.Trim());
                    findSumSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SumSupplierCd);

                    sqlCommand.ExecuteNonQuery();

                    sqlString = new StringBuilder(string.Empty);

                    # region [INSERT文]
                    sqlString.AppendLine("INSERT INTO SUMSUPPSTRF");
                    sqlString.AppendLine("  (CREATEDATETIMERF");
                    sqlString.AppendLine("  ,UPDATEDATETIMERF");
                    sqlString.AppendLine("  ,ENTERPRISECODERF");
                    sqlString.AppendLine("  ,FILEHEADERGUIDRF");
                    sqlString.AppendLine("  ,UPDEMPLOYEECODERF");
                    sqlString.AppendLine("  ,UPDASSEMBLYID1RF");
                    sqlString.AppendLine("  ,UPDASSEMBLYID2RF");
                    sqlString.AppendLine("  ,LOGICALDELETECODERF");
                    sqlString.AppendLine("  ,SUMSECTIONCDRF");
                    sqlString.AppendLine("  ,SUMSUPPLIERCDRF");
                    sqlString.AppendLine("  ,SECTIONCODERF");
                    sqlString.AppendLine("  ,SUPPLIERCDRF");
                    sqlString.AppendLine(")");
                    sqlString.AppendLine(" VALUES");
                    sqlString.AppendLine("  (@CREATEDATETIME");
                    sqlString.AppendLine("  ,@UPDATEDATETIME");
                    sqlString.AppendLine("  ,@ENTERPRISECODE");
                    sqlString.AppendLine("  ,@FILEHEADERGUID");
                    sqlString.AppendLine("  ,@UPDEMPLOYEECODE");
                    sqlString.AppendLine("  ,@UPDASSEMBLYID1");
                    sqlString.AppendLine("  ,@UPDASSEMBLYID2");
                    sqlString.AppendLine("  ,@LOGICALDELETECODE");
                    sqlString.AppendLine("  ,@SUMSECTIONCODE");
                    sqlString.AppendLine("  ,@SUMSUPPLIERCODE");
                    sqlString.AppendLine("  ,@SECTIONCODE");
                    sqlString.AppendLine("  ,@SUPPLIERCODE");
                    sqlString.AppendLine(")");
                    # endregion

                    sqlCommand.CommandText = sqlString.ToString();

                    # region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSumSectionCode = sqlCommand.Parameters.Add("@SUMSECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraSumSupplierCode = sqlCommand.Parameters.Add("@SUMSUPPLIERCODE", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraSupplierCode = sqlCommand.Parameters.Add("@SUPPLIERCODE", SqlDbType.Int);

                    # endregion

                    for (int i = 0; i < sumSuppStList.Count; i++)
                    {
                        sumSuppStWork = sumSuppStList[i] as SumSuppStWork;

                        // 登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sumSuppStWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sumSuppStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sumSuppStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(sumSuppStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sumSuppStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sumSuppStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.LogicalDeleteCode);
                        paraSumSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SumSectionCd.Trim());
                        paraSumSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SumSupplierCd);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SectionCode.Trim());
                        paraSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SupplierCode);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(sumSuppStWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            sumSuppStList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// 仕入先マスタ（総括設定）情報を論理削除します。
        /// </summary>
        /// <param name="sumSuppStList">論理削除する仕入先マスタ（総括設定）情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList に格納されている仕入先マスタ（総括設定）情報を論理削除します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        public int LogicalDelete(ref object sumSuppStList)
        {
            return this.LogicalDelete(ref sumSuppStList, 0);
        }

        /// <summary>
        /// 仕入先マスタ（総括設定）情報の論理削除を解除します。
        /// </summary>
        /// <param name="sumSuppStList">論理削除を解除する仕入先マスタ（総括設定）情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList に格納されている仕入先マスタ（総括設定）情報の論理削除を解除します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        public int RevivalLogicalDelete(ref object sumSuppStList)
        {
            return this.LogicalDelete(ref sumSuppStList, 1);
        }

        /// <summary>
        /// 仕入先マスタ（総括設定）情報の論理削除を操作します。
        /// </summary>
        /// <param name="sumSuppStList">論理削除を操作する仕入先マスタ（総括設定）情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList に格納されている仕入先マスタ（総括設定）情報の論理削除を操作します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        private int LogicalDelete(ref object sumSuppStList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = sumSuppStList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);
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
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

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
        /// 仕入先マスタ（総括設定）情報の論理削除を操作します。
        /// </summary>
        /// <param name="sumSuppStList">論理削除を操作する仕入先マスタ（総括設定）情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList に格納されている仕入先マスタ（総括設定）情報の論理削除を操作します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        public int LogicalDelete(ref ArrayList sumSuppStList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref sumSuppStList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 仕入先マスタ（総括設定）情報の論理削除を操作します。
        /// </summary>
        /// <param name="sumSuppStList">論理削除を操作する仕入先マスタ（総括設定）情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList に格納されている仕入先マスタ（総括設定）情報の論理削除を操作します。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        private int LogicalDeleteProc(ref ArrayList sumSuppStList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            StringBuilder sqlString = new StringBuilder(string.Empty);

            try
            {
                if (sumSuppStList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // タイムアウト時間を10分に設定
                    sqlCommand.CommandTimeout = 600;

                    for (int i = 0; i < sumSuppStList.Count; i++)
                    {
                        SumSuppStWork sumSuppStWork = sumSuppStList[i] as SumSuppStWork;

                        sqlString = new StringBuilder(string.Empty);

                        # region [SELECT文]
                        sqlString.AppendLine("SELECT");
                        sqlString.AppendLine("  UPDATEDATETIMERF");
                        sqlString.AppendLine(" ,LOGICALDELETECODERF");
                        sqlString.AppendLine("FROM");
                        sqlString.AppendLine("  SUMSUPPSTRF");
                        sqlString.AppendLine("WHERE");
                        sqlString.AppendLine("      ENTERPRISECODERF = @FINDENTERPRISECODE");
                        sqlString.AppendLine("  AND SUMSECTIONCDRF = @FINDSUMSECTIONCODE");
                        sqlString.AppendLine("  AND SUMSUPPLIERCDRF = @FINDSUMSUPPLIERCODE");
                        sqlString.AppendLine("  AND SECTIONCODERF = @FINDSECTIONCODE");
                        sqlString.AppendLine("  AND SUPPLIERCDRF = @FINDSUPPLIERCODE");
                        # endregion

                        sqlCommand.CommandText = sqlString.ToString();
                        
                        // Prameterオブジェクトの作成
                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSumSectionCode = sqlCommand.Parameters.Add("@FINDSUMSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findSumSupplierCode = sqlCommand.Parameters.Add("@FINDSUMSUPPLIERCODE", SqlDbType.Int);
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findSupplierCode = sqlCommand.Parameters.Add("@FINDSUPPLIERCODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.EnterpriseCode);
                        findSumSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SumSectionCd.Trim());
                        findSumSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SumSupplierCd);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SectionCode.Trim());
                        findSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SupplierCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != sumSuppStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            // SQL文初期化
                            sqlString = new StringBuilder(string.Empty);

                            # region [UPDATE文]
                            sqlString.AppendLine("UPDATE");
                            sqlString.AppendLine("  SUMSUPPSTRF");
                            sqlString.AppendLine("SET");
                            sqlString.AppendLine("  UPDATEDATETIMERF = @UPDATEDATETIME");
                            sqlString.AppendLine(" ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE");
                            sqlString.AppendLine(" ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1");
                            sqlString.AppendLine(" ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2");
                            sqlString.AppendLine(" ,LOGICALDELETECODERF = @LOGICALDELETECODE");
                            sqlString.AppendLine(" WHERE");
                            sqlString.AppendLine("      ENTERPRISECODERF = @FINDENTERPRISECODE");
                            sqlString.AppendLine("  AND SUMSECTIONCDRF = @FINDSUMSECTIONCODE");
                            sqlString.AppendLine("  AND SUMSUPPLIERCDRF = @FINDSUMSUPPLIERCODE");
                            sqlString.AppendLine("  AND SECTIONCODERF = @FINDSECTIONCODE");
                            sqlString.AppendLine("  AND SUPPLIERCDRF = @FINDSUPPLIERCODE");
                            # endregion

                            sqlCommand.CommandText = sqlString.ToString();

                            // KEYコマンドを再設定(WHERE句)
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.EnterpriseCode);
                            findSumSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SumSectionCd.Trim());
                            findSumSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SumSupplierCd);
                            findSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SectionCode.Trim());
                            findSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SupplierCode);


                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)sumSuppStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        // 論理削除モードの場合
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // 既に削除済みの場合正常
                                return status;
                            }
                            else if (logicalDelCd == 0) sumSuppStWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else sumSuppStWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                sumSuppStWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
                            }
                            else
                            {
                                if (logicalDelCd == 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // 既に復活している場合はそのまま正常を戻す
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  // 完全削除はデータなしを戻す
                                }

                                return status;
                            }
                        }

                        // Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sumSuppStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sumSuppStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sumSuppStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(sumSuppStWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            sumSuppStList = al;

            return status;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → SumSuppStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SumSuppStWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        /// </remarks>
        private SumSuppStWork CopyToSumSuppStWorkFromReader(ref SqlDataReader myReader)
        {
            SumSuppStWork sumSuppStWork = new SumSuppStWork();

            this.CopyToSumSuppStWorkFromReader(ref myReader, ref sumSuppStWork);

            return sumSuppStWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → SumSuppStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="sumSuppStWork">SumSuppStWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/08/29</br>
        /// </remarks>
        private void CopyToSumSuppStWorkFromReader(ref SqlDataReader myReader, ref SumSuppStWork sumSuppStWork)
        {
            if (myReader != null && sumSuppStWork != null)
            {
                # region クラスへ格納
                sumSuppStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                sumSuppStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                sumSuppStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                sumSuppStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                sumSuppStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                sumSuppStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                sumSuppStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                sumSuppStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                sumSuppStWork.SumSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUMSECTIONCDRF"));
                sumSuppStWork.SumSupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMSUPPLIERCDRF"));
                sumSuppStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                sumSuppStWork.SupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                # endregion
            }
        }
        # endregion
    }
}
