using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.LocalAccess
{
    /// <summary>
    /// オペレーションマスタローカルDBアクセスオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : オペレーションマスタローカルDB実データ操作を行うクラスです。</br>
    /// <br>Programmer : 23015 森本 大輝</br>
    /// <br>Date       : 2008.07.18</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/02 呉元嘯 セキュリティ管理部品の高速化改良対応</br>
    /// <br></br>
    /// </remarks>
    public class OperationLcDB
    {
        /// <summary>
        /// オペレーションマスタローカルDBオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        /// <br>Update Note: 2010/04/02 呉元嘯 セキュリティ管理部品の高速化改良対応</br>
        /// </remarks>
        public OperationLcDB()
        {
        }

        // ----------ADD 2010/04/02---------->>>>>
        #region [SearchAll]
        /// <summary>
        /// オペレーションマスタ情報の全件取得
        /// </summary>
        /// <param name="operationList">検索結果</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : オペレーションマスタ情報の全件取得を行います</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/04/02</br>
        public int SearchAll(ref object operationList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            try
            {
                //パラメータのキャスト
                ArrayList operationArray = operationList as ArrayList;
                if (operationArray == null)
                {
                    operationArray = new ArrayList();
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //Search実行
                status = SearchAllProc(ref operationArray, readMode, logicalMode, ref sqlConnection);
                operationList = operationArray;
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.SearchAll", 0);
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
        /// オペレーションマスタ情報の全件取得(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="operationList">検索結果</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : オペレーションマスタ情報の全件取得を行います(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/04/02</br>
        private int SearchAllProc(ref ArrayList operationList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                //Selectコマンドの生成
                #region [SELECT文]
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  OFFERDATERF" + Environment.NewLine;
                sqlText += " ,CATEGORYCODERF" + Environment.NewLine;
                sqlText += " ,CATEGORYNAMERF" + Environment.NewLine;
                sqlText += " ,CATEGORYDSPODRRF" + Environment.NewLine;
                sqlText += " ,PGIDRF" + Environment.NewLine;
                sqlText += " ,PGNAMERF" + Environment.NewLine;
                sqlText += " ,PGDSPODRRF" + Environment.NewLine;
                sqlText += " ,OPERATIONCODERF" + Environment.NewLine;
                sqlText += " ,OPERATIONNAMERF" + Environment.NewLine;
                sqlText += " ,OPERATIONDSPODRRF" + Environment.NewLine;
                sqlText += " FROM OPERATIONRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    operationList.Add(CopyToOperationWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "OperationLcDB.SearchAllProc", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.SearchAllProc", 0);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                }
            }

            return status;
        }
        #endregion
        // ----------ADD 2010/04/02----------<<<<<
        #region [Search]
        /// <summary>
        /// 指定された条件のオペレーションマスタLC情報LISTを戻します
        /// </summary>
        /// <param name="operationList">検索結果</param>
        /// <param name="paraOperationObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のオペレーションマスタLC情報LISTを戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        public int Search(ref object operationList, object paraOperationObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            try
            {
                //パラメータチェック
                if (paraOperationObj == null) return status;

                //パラメータのキャスト
                ArrayList operationArray = operationList as ArrayList;
                if (operationArray == null)
                {
                    operationArray = new ArrayList();
                }

                Operation operationWork = paraOperationObj as Operation;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //Search実行
                status = SearchProc(ref operationArray, operationWork, readMode, logicalMode, ref sqlConnection);
                operationList = operationArray;
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.Search", 0);
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
        /// 指定された条件のオペレーションマスタLC情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="operationList">検索結果</param>
        /// <param name="operationWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のオペレーションマスタLC情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        private int SearchProc(ref ArrayList operationList, Operation operationWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                //Selectコマンドの生成
                #region [SELECT文]
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  OFFERDATERF" + Environment.NewLine;
                sqlText += " ,CATEGORYCODERF" + Environment.NewLine;
                sqlText += " ,CATEGORYNAMERF" + Environment.NewLine;
                sqlText += " ,CATEGORYDSPODRRF" + Environment.NewLine;
                sqlText += " ,PGIDRF" + Environment.NewLine;
                sqlText += " ,PGNAMERF" + Environment.NewLine;
                sqlText += " ,PGDSPODRRF" + Environment.NewLine;
                sqlText += " ,OPERATIONCODERF" + Environment.NewLine;
                sqlText += " ,OPERATIONNAMERF" + Environment.NewLine;
                sqlText += " ,OPERATIONDSPODRRF" + Environment.NewLine;
                sqlText += " FROM OPERATIONRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, operationWork, logicalMode);
                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    operationList.Add(CopyToOperationWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "OperationLcDB.SearchProc", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.SearchProc", 0);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                }
            }

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件のオペレーションマスタLCを戻します
        /// </summary>
        /// <param name="paraOperationObj">Operationオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のオペレーションマスタLCを戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        public int Read(ref object paraOperationObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                //パラメータチェック
                if (paraOperationObj == null) return status;

                //パラメータのキャスト
                Operation operationWork = paraOperationObj as Operation;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //Read実行
                status = ReadProc(ref operationWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.Read", 0);
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

            return status;
        }

        /// <summary>
        /// 指定された条件のオペレーションマスタLCを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="operationWork">blGoodsCdUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のオペレーションマスタLCを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        private int ReadProc(ref Operation operationWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                #region [SELECT文]
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  OFFERDATERF" + Environment.NewLine;
                sqlText += " ,CATEGORYCODERF" + Environment.NewLine;
                sqlText += " ,CATEGORYNAMERF" + Environment.NewLine;
                sqlText += " ,CATEGORYDSPODRRF" + Environment.NewLine;
                sqlText += " ,PGIDRF" + Environment.NewLine;
                sqlText += " ,PGNAMERF" + Environment.NewLine;
                sqlText += " ,PGDSPODRRF" + Environment.NewLine;
                sqlText += " ,OPERATIONCODERF" + Environment.NewLine;
                sqlText += " ,OPERATIONNAMERF" + Environment.NewLine;
                sqlText += " ,OPERATIONDSPODRRF" + Environment.NewLine;
                sqlText += " FROM OPERATIONRF" + Environment.NewLine;
                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "     CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;
                #endregion

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))    
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
                    SqlParameter findParaPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                    SqlParameter findParaOperationCode = sqlCommand.Parameters.Add("@FINDOPERATIONCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationWork.CategoryCode);
                    findParaPgId.Value = SqlDataMediator.SqlSetString(operationWork.PgId);
                    findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationWork.OperationCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        operationWork = CopyToOperationWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "OperationLcDB.ReadProc", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.ReadProc", 0);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                }
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// オペレーションマスタローカル情報を追加・更新します。
        /// </summary>
        /// <param name="operationList">追加・更新するOperation情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationList に格納されているOperation情報を追加・更新します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        public int Write(ref object operationList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //パラメータチェック
                if (operationList == null) return status;

                //パラメータのキャスト
                ArrayList paraList = operationList as ArrayList;
                if (paraList == null)
                {
                    paraList = new ArrayList();
                    Operation operationWork = operationList as Operation;
                    paraList.Add(operationWork);
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //Write実行
                status = WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.Write", 0);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// オペレーションマスタローカル情報を追加・更新します。
        /// </summary>
        /// <param name="operationList">追加・更新するOperation情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationList に格納されているOperation情報を追加・更新します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        private int WriteProc(ref ArrayList operationList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (operationList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < operationList.Count; i++)
                    {
                        Operation operationWork = operationList[i] as Operation;

                        //Selectコマンドの生成
                        #region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  OFFERDATERF" + Environment.NewLine;
                        sqlText += " ,CATEGORYCODERF" + Environment.NewLine;
                        sqlText += " ,CATEGORYNAMERF" + Environment.NewLine;
                        sqlText += " ,CATEGORYDSPODRRF" + Environment.NewLine;
                        sqlText += " ,PGIDRF" + Environment.NewLine;
                        sqlText += " ,PGNAMERF" + Environment.NewLine;
                        sqlText += " ,PGDSPODRRF" + Environment.NewLine;
                        sqlText += " ,OPERATIONCODERF" + Environment.NewLine;
                        sqlText += " ,OPERATIONNAMERF" + Environment.NewLine;
                        sqlText += " ,OPERATIONDSPODRRF" + Environment.NewLine;
                        sqlText += " FROM OPERATIONRF" + Environment.NewLine;
                        sqlText += " WHERE CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                        sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                        sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
                        SqlParameter findParaPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                        SqlParameter findParaOperationCode = sqlCommand.Parameters.Add("@FINDOPERATIONCODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationWork.CategoryCode);
                        findParaPgId.Value = SqlDataMediator.SqlSetString(operationWork.PgId);
                        findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationWork.OperationCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //Updateコマンドの生成
                            #region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE OPERATIONRF" + Environment.NewLine;
                            sqlText += " SET" + Environment.NewLine;
                            sqlText += "  OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                            sqlText += " ,CATEGORYCODERF=@CATEGORYCODE" + Environment.NewLine;
                            sqlText += " ,CATEGORYNAMERF=@CATEGORYNAME" + Environment.NewLine;
                            sqlText += " ,CATEGORYDSPODRRF=@CATEGORYDSPODR" + Environment.NewLine;
                            sqlText += " ,PGIDRF=@PGID" + Environment.NewLine;
                            sqlText += " ,PGNAMERF=@PGNAME" + Environment.NewLine;
                            sqlText += " ,PGDSPODRRF=@PGDSPODR" + Environment.NewLine;
                            sqlText += " ,OPERATIONCODERF=@OPERATIONCODE" + Environment.NewLine;
                            sqlText += " ,OPERATIONNAMERF=@OPERATIONNAME" + Environment.NewLine;
                            sqlText += " ,OPERATIONDSPODRRF=@OPERATIONDSPODR" + Environment.NewLine;
                            sqlText += " WHERE CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                            sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                            sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEYコマンドを再設定
                            findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationWork.CategoryCode);
                            findParaPgId.Value = SqlDataMediator.SqlSetString(operationWork.PgId);
                            findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationWork.OperationCode);
                        }
                        else
                        {
                            //Insertコマンドの生成
                            #region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO OPERATIONRF" + Environment.NewLine;
                            sqlText += " (OFFERDATERF" + Environment.NewLine;
                            sqlText += " ,CATEGORYCODERF" + Environment.NewLine;
                            sqlText += " ,CATEGORYNAMERF" + Environment.NewLine;
                            sqlText += " ,CATEGORYDSPODRRF" + Environment.NewLine;
                            sqlText += " ,PGIDRF" + Environment.NewLine;
                            sqlText += " ,PGNAMERF" + Environment.NewLine;
                            sqlText += " ,PGDSPODRRF" + Environment.NewLine;
                            sqlText += " ,OPERATIONCODERF" + Environment.NewLine;
                            sqlText += " ,OPERATIONNAMERF" + Environment.NewLine;
                            sqlText += " ,OPERATIONDSPODRRF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@OFFERDATE" + Environment.NewLine;
                            sqlText += " ,@CATEGORYCODE" + Environment.NewLine;
                            sqlText += " ,@CATEGORYNAME" + Environment.NewLine;
                            sqlText += " ,@CATEGORYDSPODR" + Environment.NewLine;
                            sqlText += " ,@PGID" + Environment.NewLine;
                            sqlText += " ,@PGNAME" + Environment.NewLine;
                            sqlText += " ,@PGDSPODR" + Environment.NewLine;
                            sqlText += " ,@OPERATIONCODE" + Environment.NewLine;
                            sqlText += " ,@OPERATIONNAME" + Environment.NewLine;
                            sqlText += " ,@OPERATIONDSPODR" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                        SqlParameter paraCategoryCode = sqlCommand.Parameters.Add("@CATEGORYCODE", SqlDbType.Int);
                        SqlParameter paraCategoryName = sqlCommand.Parameters.Add("@CATEGORYNAME", SqlDbType.NVarChar);
                        SqlParameter paraCategoryDspOdr = sqlCommand.Parameters.Add("@CATEGORYDSPODR", SqlDbType.Int);
                        SqlParameter paraPgId = sqlCommand.Parameters.Add("@PGID", SqlDbType.NVarChar);
                        SqlParameter paraPgName = sqlCommand.Parameters.Add("@PGNAME", SqlDbType.NVarChar);
                        SqlParameter paraPgDspOdr = sqlCommand.Parameters.Add("@PGDSPODR", SqlDbType.Int);
                        SqlParameter paraOperationCode = sqlCommand.Parameters.Add("@OPERATIONCODE", SqlDbType.Int);
                        SqlParameter paraOperationName = sqlCommand.Parameters.Add("@OPERATIONNAME", SqlDbType.NVarChar);
                        SqlParameter paraOperationDspOdr = sqlCommand.Parameters.Add("@OPERATIONDSPODR", SqlDbType.Int);
                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraOfferDate.Value = SqlDataMediator.SqlSetInt32(operationWork.OfferDate);
                        paraCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationWork.CategoryCode);
                        paraCategoryName.Value = SqlDataMediator.SqlSetString(operationWork.CategoryName);
                        paraCategoryDspOdr.Value = SqlDataMediator.SqlSetInt32(operationWork.CategoryDspOdr);
                        paraPgId.Value = SqlDataMediator.SqlSetString(operationWork.PgId);
                        paraPgName.Value = SqlDataMediator.SqlSetString(operationWork.PgName);
                        paraPgDspOdr.Value = SqlDataMediator.SqlSetInt32(operationWork.PgDspOdr);
                        paraOperationCode.Value = SqlDataMediator.SqlSetInt32(operationWork.OperationCode);
                        paraOperationName.Value = SqlDataMediator.SqlSetString(operationWork.OperationName);
                        paraOperationDspOdr.Value = SqlDataMediator.SqlSetInt32(operationWork.OperationDspOdr);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(operationWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "OperationLcDB.WriteProc", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.WriteProc", 0);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

            operationList = al;

            return status;
        }
        #endregion

        #region [Delete]
        /// <summary>
        /// オペレーションマスタローカル情報を物理削除します
        /// </summary>
        /// <param name="operationList">物理削除するOperation情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : Operationのキー値が一致するOperation情報を物理削除します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        public int Delete(object operationList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //パラメータチェック
                if (operationList == null) return status;

                //パラメータのキャスト
                ArrayList paraList = operationList as ArrayList;
                if (paraList == null)
                {
                    paraList = new ArrayList();
                    Operation operationWork = operationList as Operation;
                    paraList.Add(operationWork);
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //Delete実行
                status = DeleteProc(paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.Delete", 0);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// オペレーションマスタローカル情報を物理削除します
        /// </summary>
        /// <param name="operationList">Operation情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationList に格納されているOperation情報を物理削除します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        private int DeleteProc(ArrayList operationList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (operationList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < operationList.Count; i++)
                    {
                        Operation operationWork = operationList[i] as Operation;

                        //Selectコマンドの生成
                        #region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT OFFERDATERF" + Environment.NewLine;
                        sqlText += " FROM OPERATIONRF" + Environment.NewLine;
                        sqlText += " WHERE CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                        sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                        sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
                        SqlParameter findParaPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                        SqlParameter findParaOperationCode = sqlCommand.Parameters.Add("@FINDOPERATIONCODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationWork.CategoryCode);
                        findParaPgId.Value = SqlDataMediator.SqlSetString(operationWork.PgId);
                        findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationWork.OperationCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //Deleteコマンドの生成
                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM OPERATIONRF" + Environment.NewLine;
                            sqlText += " WHERE CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                            sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                            sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationWork.CategoryCode);
                            findParaPgId.Value = SqlDataMediator.SqlSetString(operationWork.PgId);
                            findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationWork.OperationCode);
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
                status = WriteSQLErrorLog(ex, "OperationLcDB.DeleteProc", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.DeleteProc", 0);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="operationWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, Operation operationWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = "WHERE ";

            //カテゴリコード
            retstring += "CATEGORYCODERF=@FINDCATEGORYCODE ";
            SqlParameter paraCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
            paraCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationWork.CategoryCode);

            //プログラムＩＤ
            if (operationWork.PgId != "")
            {
                retstring += "AND PGIDRF=@FINDPGID ";
                SqlParameter paraPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                paraPgId.Value = SqlDataMediator.SqlSetString(operationWork.PgId);
            }

            //オペレーションコード
            if (operationWork.OperationCode != -1)
            {
                retstring += "AND OPERATIONCODERF=@FINDOPERATIONCODE ";
                SqlParameter paraOperationCode = sqlCommand.Parameters.Add("@FINDOPERATIONCODE", SqlDbType.Int);
                paraOperationCode.Value = SqlDataMediator.SqlSetInt32(operationWork.OperationCode);
            }

            //提供日付
            if (operationWork.OfferDate != 0)
            {
                retstring += "AND OFFERDATERF=@FINDOFFERDATE ";
                SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@FINDOFFERDATE", SqlDbType.Int);
                paraOfferDate.Value = SqlDataMediator.SqlSetInt32(operationWork.OfferDate);
            }

            //カテゴリ名称
            if (operationWork.CategoryName != "")
            {
                retstring += "AND CATEGORYNAMERF=@FINDCATEGORYNAME ";
                SqlParameter paraCategoryName = sqlCommand.Parameters.Add("@FINDCATEGORYNAME", SqlDbType.NVarChar);
                paraCategoryName.Value = SqlDataMediator.SqlSetString(operationWork.CategoryName);
            }

            //カテゴリ表示順位
            if (operationWork.CategoryDspOdr != 0)
            {
                retstring += "AND CATEGORYDSPODRRF=@FINDCATEGORYDSPODR ";
                SqlParameter paraCategoryDspOdr = sqlCommand.Parameters.Add("@FINDCATEGORYDSPODR", SqlDbType.Int);
                paraCategoryDspOdr.Value = SqlDataMediator.SqlSetInt32(operationWork.CategoryDspOdr);
            }

            //プログラム名称
            if (operationWork.PgName != "")
            {
                retstring += "AND PGNAMERF=@FINDPGNAME ";
                SqlParameter paraPgName = sqlCommand.Parameters.Add("@FINDPGNAME", SqlDbType.NVarChar);
                paraPgName.Value = SqlDataMediator.SqlSetString(operationWork.PgName);
            }

            //プログラム表示順位
            if (operationWork.PgDspOdr != 0)
            {
                retstring += "AND PGDSPODRRF=@FINDPGDSPODR ";
                SqlParameter paraPgDspOdr = sqlCommand.Parameters.Add("@FINDPGDSPODR", SqlDbType.Int);
                paraPgDspOdr.Value = SqlDataMediator.SqlSetInt32(operationWork.PgDspOdr);
            }

            //オペレーション名称
            if (operationWork.OperationName != "")
            {
                retstring += "AND OPERATIONNAMERF=@FINDOPERATIONNAME ";
                SqlParameter paraOperationName = sqlCommand.Parameters.Add("@FINDOPERATIONNAME", SqlDbType.NVarChar);
                paraOperationName.Value = SqlDataMediator.SqlSetString(operationWork.OperationName);
            }

            //オペレーション表示順位
            if (operationWork.OperationDspOdr != 0)
            {
                retstring += "AND OPERATIONDSPODRRF=@FINDOPERATIONDSPODR ";
                SqlParameter paraOperationDspOdr = sqlCommand.Parameters.Add("@FINDOPERATIONDSPODR", SqlDbType.Int);
                paraOperationDspOdr.Value = SqlDataMediator.SqlSetInt32(operationWork.OperationDspOdr);
            }

            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → Operation
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>OperationWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        /// </remarks>
        private Operation CopyToOperationWorkFromReader(ref SqlDataReader myReader)
        {
            Operation wkOperationWork = new Operation();

            #region クラスへ格納
            wkOperationWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkOperationWork.CategoryCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYCODERF"));
            wkOperationWork.CategoryName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYNAMERF"));
            wkOperationWork.CategoryDspOdr = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYDSPODRRF"));
            wkOperationWork.PgId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PGIDRF"));
            wkOperationWork.PgName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PGNAMERF"));
            wkOperationWork.PgDspOdr = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PGDSPODRRF"));
            wkOperationWork.OperationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPERATIONCODERF"));
            wkOperationWork.OperationName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OPERATIONNAMERF"));
            wkOperationWork.OperationDspOdr = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPERATIONDSPODRRF"));
            #endregion

            return wkOperationWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            ClientSqlConnectionInfo clientSqlConnectionInfo = new ClientSqlConnectionInfo();
            string connectionText = clientSqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Local_OfferDB);
            if (connectionText == null || connectionText == "") return null;
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }
        #endregion

        #region [エラーログ出力処理]
        private void WriteErrorLog(Exception ex, string errorText, int status)
        {
            string message = "";
            if (ex != null)
            {
                if (ex is SqlException)
                {
                    this.WriteSQLErrorLog((SqlException)ex, errorText, status);
                }
                else
                {
                    message = string.Concat(new object[] { "Index #", 0, "\nMessage: ", ex.Message, "\n", errorText, "\nSource: ", ex.Source, "\nStatus = ", status.ToString(), "\n" });
                    new ClientLogTextOut().Output(ex.Source, message, status, ex);
                }
            }
            else
            {
                new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, errorText, status);
            }
        }

        private int WriteSQLErrorLog(SqlException ex, string errorText, int status)
        {
            string message = "";
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                object obj2 = message;
                message = string.Concat(new object[] { obj2, "Index #", i, "\nMessage: ", ex.Errors[i].Message, "\nLineNumber: ", ex.Errors[i].LineNumber, "\nSource: ", ex.Errors[i].Source, "\nProcedure: ", ex.Errors[i].Procedure, "\n" });
            }
            if (!errorText.Trim().Equals(""))
            {
                message = message + errorText + "\n";
            }
            message = message + "Status = " + status.ToString() + "\n";
            new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, message, status);
            if (ex.Number == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
            {
                return (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
            }
            if (ex.Number == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }
            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
        }
        #endregion

    }
}
