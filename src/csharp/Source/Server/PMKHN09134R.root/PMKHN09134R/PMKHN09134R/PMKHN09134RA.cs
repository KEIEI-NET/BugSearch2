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
    /// オペレーション設定リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : OperationStの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 23015 森本 大輝</br>
    /// <br>Date       : 2008.07.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class OperationStDB : RemoteWithAppLockDB, IOperationStDB
    {
        /// <summary>
        /// OperationStDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.22</br>
        /// </remarks>
        public OperationStDB() : base("PMKHN09136D", "Broadleaf.Application.Remoting.ParamData.OperationStWork", "OperationStRF")
        {

        }

        #region [Read]
        /// <summary>
        /// 単一のOperationSt情報を取得します。
        /// </summary>
        /// <param name="operationStObj">OperationStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStのキー値が一致するOperationSt情報を取得します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.22</br>
        public int Read(ref object operationStObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;

            try
            {
                //パラメータチェック
                if (operationStObj == null) return status;

                //パラメータのキャスト
                OperationStWork operationStWork = operationStObj as OperationStWork;

                //コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                //Read実行
                status = this.Read(ref operationStWork, readMode, ref sqlConnection);
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
                }
            }

            return status;
        }

        /// <summary>
        /// 単一のOperationSt情報を取得します。
        /// </summary>
        /// <param name="operationStWork">OperationStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStのキー値が一致するOperationSt情報を取得します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.22</br>
        private int Read(ref OperationStWork operationStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //Selectコマンドの生成
                #region [SELECT文]
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,OPERATIONSTDIVRF" + Environment.NewLine;
                sqlText += " ,CATEGORYCODERF" + Environment.NewLine;
                sqlText += " ,PGIDRF" + Environment.NewLine;
                sqlText += " ,OPERATIONCODERF" + Environment.NewLine;
                sqlText += " ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                sqlText += " ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,LIMITDIVRF" + Environment.NewLine;
                sqlText += " ,APPLYSTARTDATERF" + Environment.NewLine;
                sqlText += " ,APPLYENDDATERF" + Environment.NewLine;
                sqlText += " FROM OPERATIONSTRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += " AND CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;
                sqlText += " AND AUTHORITYLEVEL1RF=@FINDAUTHORITYLEVEL1" + Environment.NewLine;
                sqlText += " AND AUTHORITYLEVEL2RF=@FINDAUTHORITYLEVEL2" + Environment.NewLine;
                sqlText += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                #endregion

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
                SqlParameter findParaPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                SqlParameter findParaOperationCode = sqlCommand.Parameters.Add("@FINDOPERATIONCODE", SqlDbType.Int);
                SqlParameter findParaAuthorityLevel1 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL1", SqlDbType.Int);
                SqlParameter findParaAuthorityLevel2 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL2", SqlDbType.Int);
                SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(operationStWork.EnterpriseCode);
                findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.CategoryCode);
                findParaPgId.Value = operationStWork.PgId;
                findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationCode);
                findParaAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel1);
                findParaAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel2);
                findParaEmployeeCode.Value = operationStWork.EmployeeCode;

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToOperationStWorkFromReader(ref myReader, ref operationStWork);
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
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        #region [Search]
        /// <summary>
        /// OperationSt情報のリストを取得します。
        /// </summary>
        /// <param name="operationStList">検索結果</param>
        /// <param name="operationStObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStのキー値が一致する、全てのOperationSt情報を取得します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.22</br>
        public int Search(ref object operationStList, object operationStObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;

            try
            {
                //パラメータチェック
                if (operationStObj == null) return status;

                //パラメータのキャスト
                ArrayList operationStArray = operationStList as ArrayList;
                if (operationStArray == null)
                {
                    operationStArray = new ArrayList();
                }

                OperationStWork operationStWork = operationStObj as OperationStWork;

                //コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                //Search実行
                status = this.Search(ref operationStArray, operationStWork, readMode, logicalMode, ref sqlConnection);
                operationStList = operationStArray;
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
                }
            }

            return status;
        }

        /// <summary>
        /// OperationSt情報のリストを取得します。
        /// </summary>
        /// <param name="operationStList">OperationSt情報を格納</param>
        /// <param name="operationStWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStのキー値が一致する、全てのOperationSt情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.22</br>
        private int Search(ref ArrayList operationStList, OperationStWork operationStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //Selectコマンドの生成
                #region [SELECT文]
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,OPERATIONSTDIVRF" + Environment.NewLine;
                sqlText += " ,CATEGORYCODERF" + Environment.NewLine;
                sqlText += " ,PGIDRF" + Environment.NewLine;
                sqlText += " ,OPERATIONCODERF" + Environment.NewLine;
                sqlText += " ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                sqlText += " ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,LIMITDIVRF" + Environment.NewLine;
                sqlText += " ,APPLYSTARTDATERF" + Environment.NewLine;
                sqlText += " ,APPLYENDDATERF" + Environment.NewLine;
                sqlText += " FROM OPERATIONSTRF" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                //WHERE句
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, operationStWork, logicalMode);
                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    operationStList.Add(this.CopyToOperationStWorkFromReader(ref myReader));
                }

                if (operationStList.Count > 0)
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
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        #region [Write]
        /// <summary>
        /// OperationSt情報を追加・更新します。
        /// </summary>
        /// <param name="operationStList">追加・更新するOperationSt情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStList に格納されているOperationSt情報を追加・更新します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.22</br>
        public int Write(ref object operationStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //パラメータチェック
                if (operationStList == null) return status;

                //パラメータのキャスト
                ArrayList paraList = operationStList as ArrayList;
                if (paraList == null)
                {
                    paraList = new ArrayList();
                    OperationStWork operationStWork = operationStList as OperationStWork;
                    paraList.Add(operationStWork);
                }

                //コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                //トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //Write実行
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
                            //コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //ロールバック
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
        /// OperationSt情報を追加・更新します。
        /// </summary>
        /// <param name="operationStList">追加・更新するOperationSt情報</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStList に格納されているOperationSt情報を追加・更新します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.22</br>
        private int Write(ref ArrayList operationStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (operationStList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < operationStList.Count; i++)
                    {
                        OperationStWork operationStWork = operationStList[i] as OperationStWork;

                        //Selectコマンドの生成
                        #region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " ,OPERATIONSTDIVRF" + Environment.NewLine;
                        sqlText += " ,CATEGORYCODERF" + Environment.NewLine;
                        sqlText += " ,PGIDRF" + Environment.NewLine;
                        sqlText += " ,OPERATIONCODERF" + Environment.NewLine;
                        sqlText += " ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                        sqlText += " ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                        sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,LIMITDIVRF" + Environment.NewLine;
                        sqlText += " ,APPLYSTARTDATERF" + Environment.NewLine;
                        sqlText += " ,APPLYENDDATERF" + Environment.NewLine;
                        sqlText += " FROM OPERATIONSTRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += " AND CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                        sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                        sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;
                        sqlText += " AND AUTHORITYLEVEL1RF=@FINDAUTHORITYLEVEL1" + Environment.NewLine;
                        sqlText += " AND AUTHORITYLEVEL2RF=@FINDAUTHORITYLEVEL2" + Environment.NewLine;
                        sqlText += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
                        SqlParameter findParaPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                        SqlParameter findParaOperationCode = sqlCommand.Parameters.Add("@FINDOPERATIONCODE", SqlDbType.Int);
                        SqlParameter findParaAuthorityLevel1 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL1", SqlDbType.Int);
                        SqlParameter findParaAuthorityLevel2 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL2", SqlDbType.Int);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(operationStWork.EnterpriseCode);
                        findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.CategoryCode);
                        findParaPgId.Value = operationStWork.PgId;
                        findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationCode);
                        findParaAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel1);
                        findParaAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel2);
                        findParaEmployeeCode.Value = operationStWork.EmployeeCode;

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != operationStWork.UpdateDateTime)
                            {
                                if (operationStWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    //新規登録で該当データ有りの場合には重複
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                else
                                {
                                    //既存データで更新日時違いの場合には排他
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }

                                return status;
                            }

                            //Updateコマンドの生成
                            #region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE OPERATIONSTRF" + Environment.NewLine;
                            sqlText += " SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,OPERATIONSTDIVRF=@OPERATIONSTDIV" + Environment.NewLine;
                            sqlText += " ,CATEGORYCODERF=@CATEGORYCODE" + Environment.NewLine;
                            sqlText += " ,PGIDRF=@PGID" + Environment.NewLine;
                            sqlText += " ,OPERATIONCODERF=@OPERATIONCODE" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVEL1RF=@AUTHORITYLEVEL1" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVEL2RF=@AUTHORITYLEVEL2" + Environment.NewLine;
                            sqlText += " ,EMPLOYEECODERF=@EMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,LIMITDIVRF=@LIMITDIV" + Environment.NewLine;
                            sqlText += " ,APPLYSTARTDATERF=@APPLYSTARTDATE" + Environment.NewLine;
                            sqlText += " ,APPLYENDDATERF=@APPLYENDDATE" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += " AND CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                            sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                            sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;
                            sqlText += " AND AUTHORITYLEVEL1RF=@FINDAUTHORITYLEVEL1" + Environment.NewLine;
                            sqlText += " AND AUTHORITYLEVEL2RF=@FINDAUTHORITYLEVEL2" + Environment.NewLine;
                            sqlText += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(operationStWork.EnterpriseCode);
                            findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.CategoryCode);
                            findParaPgId.Value = operationStWork.PgId;
                            findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationCode);
                            findParaAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel1);
                            findParaAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel2);
                            findParaEmployeeCode.Value = operationStWork.EmployeeCode;

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)operationStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (operationStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            //Insertコマンドの生成
                            #region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO OPERATIONSTRF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,OPERATIONSTDIVRF" + Environment.NewLine;
                            sqlText += " ,CATEGORYCODERF" + Environment.NewLine;
                            sqlText += " ,PGIDRF" + Environment.NewLine;
                            sqlText += " ,OPERATIONCODERF" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                            sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,LIMITDIVRF" + Environment.NewLine;
                            sqlText += " ,APPLYSTARTDATERF" + Environment.NewLine;
                            sqlText += " ,APPLYENDDATERF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@OPERATIONSTDIV" + Environment.NewLine;
                            sqlText += " ,@CATEGORYCODE" + Environment.NewLine;
                            sqlText += " ,@PGID" + Environment.NewLine;
                            sqlText += " ,@OPERATIONCODE" + Environment.NewLine;
                            sqlText += " ,@AUTHORITYLEVEL1" + Environment.NewLine;
                            sqlText += " ,@AUTHORITYLEVEL2" + Environment.NewLine;
                            sqlText += " ,@EMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@LIMITDIV" + Environment.NewLine;
                            sqlText += " ,@APPLYSTARTDATE" + Environment.NewLine;
                            sqlText += " ,@APPLYENDDATE" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)operationStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraOperationStDiv = sqlCommand.Parameters.Add("@OPERATIONSTDIV", SqlDbType.Int);
                        SqlParameter paraCategoryCode = sqlCommand.Parameters.Add("@CATEGORYCODE", SqlDbType.Int);
                        SqlParameter paraPgId = sqlCommand.Parameters.Add("@PGID", SqlDbType.NVarChar);
                        SqlParameter paraOperationCode = sqlCommand.Parameters.Add("@OPERATIONCODE", SqlDbType.Int);
                        SqlParameter paraAuthorityLevel1 = sqlCommand.Parameters.Add("@AUTHORITYLEVEL1", SqlDbType.Int);
                        SqlParameter paraAuthorityLevel2 = sqlCommand.Parameters.Add("@AUTHORITYLEVEL2", SqlDbType.Int);
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraLimitDiv = sqlCommand.Parameters.Add("@LIMITDIV", SqlDbType.Int);
                        SqlParameter paraApplyStartDate = sqlCommand.Parameters.Add("@APPLYSTARTDATE", SqlDbType.Int);
                        SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(operationStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(operationStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(operationStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(operationStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(operationStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(operationStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(operationStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.LogicalDeleteCode);
                        paraOperationStDiv.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationStDiv);
                        paraCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.CategoryCode);
                        paraPgId.Value = operationStWork.PgId;
                        paraOperationCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationCode);
                        paraAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel1);
                        paraAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel2);
                        paraEmployeeCode.Value = operationStWork.EmployeeCode;
                        paraLimitDiv.Value = SqlDataMediator.SqlSetInt32(operationStWork.LimitDiv);
                        paraApplyStartDate.Value = SqlDataMediator.SqlSetInt32(operationStWork.ApplyStartDate);
                        paraApplyEndDate.Value = SqlDataMediator.SqlSetInt32(operationStWork.ApplyEndDate);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(operationStWork);
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
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

            operationStList = al;

            return status;
        }
        #endregion

        #region [Delete]
        /// <summary>
        /// OperationSt情報を物理削除します
        /// </summary>
        /// <param name="operationStList">物理削除するOperationSt情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStのキー値が一致するOperationSt情報を物理削除します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.22</br>
        public int Delete(object operationStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //パラメータチェック
                if (operationStList == null) return status;

                //パラメータのキャスト
                ArrayList paraList = operationStList as ArrayList;
                if (paraList == null)
                {
                    paraList = new ArrayList();
                    OperationStWork operationStWork = operationStList as OperationStWork;
                    paraList.Add(operationStWork);
                }

                //コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                //トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //Delete実行
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
                            //コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //ロールバック
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
        /// OperationSt情報を物理削除します
        /// </summary>
        /// <param name="operationStList">OperationSt情報を格納</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStList に格納されているOperationSt情報を物理削除します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.22</br>
        private int Delete(ArrayList operationStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (operationStList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < operationStList.Count; i++)
                    {
                        OperationStWork operationStWork = operationStList[i] as OperationStWork;

                        //Selectコマンドの生成
                        #region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM OPERATIONSTRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += " AND CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                        sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                        sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;
                        sqlText += " AND AUTHORITYLEVEL1RF=@FINDAUTHORITYLEVEL1" + Environment.NewLine;
                        sqlText += " AND AUTHORITYLEVEL2RF=@FINDAUTHORITYLEVEL2" + Environment.NewLine;
                        sqlText += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
                        SqlParameter findParaPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                        SqlParameter findParaOperationCode = sqlCommand.Parameters.Add("@FINDOPERATIONCODE", SqlDbType.Int);
                        SqlParameter findParaAuthorityLevel1 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL1", SqlDbType.Int);
                        SqlParameter findParaAuthorityLevel2 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL2", SqlDbType.Int);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(operationStWork.EnterpriseCode);
                        findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.CategoryCode);
                        findParaPgId.Value = operationStWork.PgId;
                        findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationCode);
                        findParaAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel1);
                        findParaAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel2);
                        findParaEmployeeCode.Value = operationStWork.EmployeeCode;

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //更新日時

                            if (_updateDateTime != operationStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            //Deleteコマンドの生成
                            #region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM OPERATIONSTRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += " AND CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                            sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                            sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;
                            sqlText += " AND AUTHORITYLEVEL1RF=@FINDAUTHORITYLEVEL1" + Environment.NewLine;
                            sqlText += " AND AUTHORITYLEVEL2RF=@FINDAUTHORITYLEVEL2" + Environment.NewLine;
                            sqlText += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(operationStWork.EnterpriseCode);
                            findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.CategoryCode);
                            findParaPgId.Value = operationStWork.PgId;
                            findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationCode);
                            findParaAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel1);
                            findParaAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel2);
                            findParaEmployeeCode.Value = operationStWork.EmployeeCode;
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
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
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        #region [LogicalDelete]
        /// <summary>
        /// OperationSt情報を論理削除します。
        /// </summary>
        /// <param name="operationStList">論理削除するOperationSt情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStWork に格納されているOperationSt情報を論理削除します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.22</br>
        public int LogicalDelete(ref object operationStList)
        {
            return this.LogicalDelete(ref operationStList, 0);
        }

        /// <summary>
        /// OperationSt情報の論理削除を解除します。
        /// </summary>
        /// <param name="operationStList">論理削除を解除するOperationSt情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStWork に格納されているOperationSt情報の論理削除を解除します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.22</br>
        public int RevivalLogicalDelete(ref object operationStList)
        {
            return this.LogicalDelete(ref operationStList, 1);
        }

        /// <summary>
        /// OperationSt情報の論理削除を操作します。
        /// </summary>
        /// <param name="operationStList">論理削除を操作するOperationSt情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStWork に格納されているOperationSt情報の論理削除を操作します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.22</br>
        private int LogicalDelete(ref object operationStList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //パラメータチェック
                if (operationStList == null) return status;

                //パラメータのキャスト
                ArrayList paraList = operationStList as ArrayList;
                if (paraList == null)
                {
                    paraList = new ArrayList();
                    OperationStWork operationStWork = operationStList as OperationStWork;
                    paraList.Add(operationStWork);
                }

                //コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                //トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //LogicalDelete実行
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
                            //コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //ロールバック
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
        /// OperationSt情報の論理削除を操作します。
        /// </summary>
        /// <param name="operationStList">論理削除を操作するOperationSt情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStWork に格納されているOperationSt情報の論理削除を操作します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.22</br>
        private int LogicalDelete(ref ArrayList operationStList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (operationStList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < operationStList.Count; i++)
                    {
                        OperationStWork operationStWork = operationStList[i] as OperationStWork;

                        //Selectコマンドの生成
                        #region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " FROM OPERATIONSTRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += " AND CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                        sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                        sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;
                        sqlText += " AND AUTHORITYLEVEL1RF=@FINDAUTHORITYLEVEL1" + Environment.NewLine;
                        sqlText += " AND AUTHORITYLEVEL2RF=@FINDAUTHORITYLEVEL2" + Environment.NewLine;
                        sqlText += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                        
                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
                        SqlParameter findParaPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                        SqlParameter findParaOperationCode = sqlCommand.Parameters.Add("@FINDOPERATIONCODE", SqlDbType.Int);
                        SqlParameter findParaAuthorityLevel1 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL1", SqlDbType.Int);
                        SqlParameter findParaAuthorityLevel2 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL2", SqlDbType.Int);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(operationStWork.EnterpriseCode);
                        findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.CategoryCode);
                        findParaPgId.Value = operationStWork.PgId;
                        findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationCode);
                        findParaAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel1);
                        findParaAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel2);
                        findParaEmployeeCode.Value = operationStWork.EmployeeCode;
                        
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != operationStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            //Updateコマンドの生成
                            #region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE OPERATIONSTRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += " AND CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                            sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                            sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;
                            sqlText += " AND AUTHORITYLEVEL1RF=@FINDAUTHORITYLEVEL1" + Environment.NewLine;
                            sqlText += " AND AUTHORITYLEVEL2RF=@FINDAUTHORITYLEVEL2" + Environment.NewLine;
                            sqlText += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(operationStWork.EnterpriseCode);
                            findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.CategoryCode);
                            findParaPgId.Value = operationStWork.PgId;
                            findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationCode);
                            findParaAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel1);
                            findParaAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel2);
                            findParaEmployeeCode.Value = operationStWork.EmployeeCode;

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)operationStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        //論理削除モードの場合
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;         //既に削除済みの場合正常
                                return status;
                            }
                            else if (logicalDelCd == 0) operationStWork.LogicalDeleteCode = 1;  //論理削除フラグをセット
                            else operationStWork.LogicalDeleteCode = 3;                         //完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                operationStWork.LogicalDeleteCode = 0;                          //論理削除フラグを解除
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

                        //Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(operationStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(operationStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(operationStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(operationStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(operationStWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

            operationStList = al;

            return status;
        }
        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="operationStWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.22</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, OperationStWork operationStWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            //企業コード
            retstring += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(operationStWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //カテゴリーコード
            if (operationStWork.CategoryCode != 0)
            {
                retstring += "  AND CATEGORYCODERF = @FINDCATEGORYCODE" + Environment.NewLine;
                SqlParameter findCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
                findCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.CategoryCode);
            }

            //プログラムＩＤ
            if (operationStWork.PgId != "")
            {
                retstring += "  AND PGIDRF = @FINDPGID" + Environment.NewLine;
                SqlParameter findPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                findPgId.Value = operationStWork.PgId;
            }

            //オペレーションコード
            if (operationStWork.OperationCode != 0)
            {
                retstring += "  AND OPERATIONCODERF = @FINDOPERATIONCODE" + Environment.NewLine;
                SqlParameter findOperationCode = sqlCommand.Parameters.Add("@FINDOPERATIONCODE", SqlDbType.Int);
                findOperationCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationCode);
            }

            //権限レベル1
            if (operationStWork.AuthorityLevel1 != 0)
            {
                retstring += "  AND AUTHORITYLEVEL1RF = @FINDAUTHORITYLEVEL1" + Environment.NewLine;
                SqlParameter findAuthorityLevel1 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL1", SqlDbType.Int);
                findAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel1);
            }

            //権限レベル2
            if (operationStWork.AuthorityLevel2 != 0)
            {
                retstring += "  AND AUTHORITYLEVEL2RF = @FINDAUTHORITYLEVEL2" + Environment.NewLine;
                SqlParameter findAuthorityLevel2 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL2", SqlDbType.Int);
                findAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel2);
            }

            //従業員コード
            if (operationStWork.EmployeeCode != "")
            {
                retstring += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                SqlParameter findEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                findEmployeeCode.Value = operationStWork.EmployeeCode;
            }

            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → OperationStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>OperationStWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.22</br>
        /// </remarks>
        private OperationStWork CopyToOperationStWorkFromReader(ref SqlDataReader myReader)
        {
            OperationStWork operationStWork = new OperationStWork();

            this.CopyToOperationStWorkFromReader(ref myReader, ref operationStWork);

            return operationStWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → OperationStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="operationStWork">OperationStWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.22</br>
        /// </remarks>
        private void CopyToOperationStWorkFromReader(ref SqlDataReader myReader, ref OperationStWork operationStWork)
        {
            if (myReader != null && operationStWork != null)
            {
                #region クラスへ格納
                operationStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                operationStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                operationStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                operationStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                operationStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                operationStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                operationStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                operationStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                operationStWork.OperationStDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPERATIONSTDIVRF"));
                operationStWork.CategoryCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYCODERF"));
                operationStWork.PgId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PGIDRF"));
                operationStWork.OperationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPERATIONCODERF"));
                operationStWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL1RF"));
                operationStWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL2RF"));
                operationStWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                operationStWork.LimitDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LIMITDIVRF"));
                operationStWork.ApplyStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYSTARTDATERF"));
                operationStWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
                #endregion
            }
        }
        #endregion
    }
}
