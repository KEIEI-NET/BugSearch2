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
    /// 権限レベルマスタローカルDBアクセスオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 権限レベルマスタローカルDB実データ操作を行うクラスです。</br>
    /// <br>Programmer : 23015 森本 大輝</br>
    /// <br>Date       : 2008.07.18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br></br>
    /// </remarks>
    public class AuthorityLevelLcDB
    {
        /// <summary>
        /// 権限レベルマスタローカルDBオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        /// </remarks>
        public AuthorityLevelLcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の権限レベルマスタLC情報LISTを戻します
        /// </summary>
        /// <param name="authorityLevelList">検索結果</param>
        /// <param name="paraAuthorityLevelObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の権限レベルマスタLC情報LISTを戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        public int Search(ref object authorityLevelList, object paraAuthorityLevelObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            try
            {
                //パラメータチェック
                if (paraAuthorityLevelObj == null) return status;

                //パラメータのキャスト
                ArrayList authorityLevelArray = authorityLevelList as ArrayList;
                if (authorityLevelArray == null)
                {
                    authorityLevelArray = new ArrayList();
                }

                AuthorityLevel authorityLevelWork = paraAuthorityLevelObj as AuthorityLevel;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //Search実行
                status = SearchProc(ref authorityLevelArray, authorityLevelWork, readMode, logicalMode, ref sqlConnection);
                authorityLevelList = authorityLevelArray;
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AuthorityLevelLcDB.Search", 0);
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
        /// 指定された条件の権限レベルマスタLC情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="authorityLevelList">検索結果</param>
        /// <param name="authorityLevelWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の権限レベルマスタLC情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        private int SearchProc(ref ArrayList authorityLevelList, AuthorityLevel authorityLevelWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
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
                sqlText += " ,AUTHORITYLEVELDIVRF" + Environment.NewLine;
                sqlText += " ,AUTHORITYLEVELCDRF" + Environment.NewLine;
                sqlText += " ,AUTHORITYLEVELNMRF" + Environment.NewLine;
                sqlText += " FROM AUTHORITYLEVELRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, authorityLevelWork, logicalMode);
                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    authorityLevelList.Add(CopyToAuthorityLevelWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "AuthorityLevelLcDB.SearchProc", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AuthorityLevelLcDB.SearchProc", 0);
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
        /// 指定された条件の権限レベルマスタLCを戻します
        /// </summary>
        /// <param name="paraAuthorityLevelObj">AuthorityLevelオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の権限レベルマスタLCを戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        public int Read(ref object paraAuthorityLevelObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                //パラメータチェック
                if (paraAuthorityLevelObj == null) return status;

                //パラメータのキャスト
                AuthorityLevel authorityLevelWork = paraAuthorityLevelObj as AuthorityLevel;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //Read実行
                status = ReadProc(ref authorityLevelWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AuthorityLevelLcDB.Read", 0);
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
        /// 指定された条件の権限レベルマスタLCを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="authorityLevelWork">blGoodsCdUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の権限レベルマスタLCを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        private int ReadProc(ref AuthorityLevel authorityLevelWork, int readMode, ref SqlConnection sqlConnection)
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
                sqlText += " ,AUTHORITYLEVELDIVRF" + Environment.NewLine;
                sqlText += " ,AUTHORITYLEVELCDRF" + Environment.NewLine;
                sqlText += " ,AUTHORITYLEVELNMRF" + Environment.NewLine;
                sqlText += " FROM AUTHORITYLEVELRF" + Environment.NewLine;
                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "     AUTHORITYLEVELDIVRF=@FINDAUTHORITYLEVELDIV" + Environment.NewLine;
                sqlText += " AND AUTHORITYLEVELCDRF=@FINDAUTHORITYLEVELCD" + Environment.NewLine;
                #endregion

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaAuthorityLevelDiv = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVELDIV", SqlDbType.Int);
                    SqlParameter findParaAuthorityLevelCd = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVELCD", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaAuthorityLevelDiv.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelDiv);
                    findParaAuthorityLevelCd.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelCd);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    
                    if (myReader.Read())
                    {
                        authorityLevelWork = CopyToAuthorityLevelWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "AuthorityLevelLcDB.ReadProc", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AuthorityLevelLcDB.ReadProc", 0);
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
        /// 権限レベルマスタローカル情報を追加・更新します。
        /// </summary>
        /// <param name="authorityLevelList">追加・更新するAuthorityLevel情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : AuthorityLevelList に格納されているAuthorityLevel情報を追加・更新します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        public int Write(ref object authorityLevelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //パラメータチェック
                if (authorityLevelList == null) return status;

                //パラメータのキャスト
                ArrayList paraList = authorityLevelList as ArrayList;
                if (paraList == null)
                {
                    paraList = new ArrayList();
                    AuthorityLevel authorityLevelWork = authorityLevelList as AuthorityLevel;
                    paraList.Add(authorityLevelWork);
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
                WriteErrorLog(ex, "AuthorityLevelLcDB.Write", 0);
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
        /// 権限レベルマスタローカル情報を追加・更新します。
        /// </summary>
        /// <param name="authorityLevelList">追加・更新するAuthorityLevel情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : AuthorityLevelList に格納されているAuthorityLevel情報を追加・更新します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        private int WriteProc(ref ArrayList authorityLevelList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (authorityLevelList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < authorityLevelList.Count; i++)
                    {
                        AuthorityLevel authorityLevelWork = authorityLevelList[i] as AuthorityLevel;

                        //Selectコマンドの生成
                        #region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  OFFERDATERF" + Environment.NewLine;
                        sqlText += " ,AUTHORITYLEVELDIVRF" + Environment.NewLine;
                        sqlText += " ,AUTHORITYLEVELCDRF" + Environment.NewLine;
                        sqlText += " ,AUTHORITYLEVELNMRF" + Environment.NewLine;
                        sqlText += " FROM AUTHORITYLEVELRF" + Environment.NewLine;
                        sqlText += " WHERE" + Environment.NewLine;
                        sqlText += "     AUTHORITYLEVELDIVRF=@FINDAUTHORITYLEVELDIV" + Environment.NewLine;
                        sqlText += " AND AUTHORITYLEVELCDRF=@FINDAUTHORITYLEVELCD" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaAuthorityLevelDiv = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVELDIV", SqlDbType.Int);
                        SqlParameter findParaAuthorityLevelCd = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVELCD", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaAuthorityLevelDiv.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelDiv);
                        findParaAuthorityLevelCd.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelCd);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //Updateコマンドの生成
                            #region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE AUTHORITYLEVELRF" + Environment.NewLine;
                            sqlText += " SET" + Environment.NewLine;
                            sqlText += "  OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVELDIVRF=@AUTHORITYLEVELDIV" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVELCDRF=@AUTHORITYLEVELCD" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVELNMRF=@AUTHORITYLEVELNM" + Environment.NewLine;
                            sqlText += " WHERE AUTHORITYLEVELDIVRF=@FINDAUTHORITYLEVELDIV" + Environment.NewLine;
                            sqlText += " AND AUTHORITYLEVELCDRF=@FINDAUTHORITYLEVELCD" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEYコマンドを再設定
                            findParaAuthorityLevelDiv.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelDiv);
                            findParaAuthorityLevelCd.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelCd);
                        }
                        else
                        {
                            //Insertコマンドの生成
                            #region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO AUTHORITYLEVELRF" + Environment.NewLine;
                            sqlText += " (OFFERDATERF" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVELDIVRF" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVELCDRF" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVELNMRF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@OFFERDATE" + Environment.NewLine;
                            sqlText += " ,@AUTHORITYLEVELDIV" + Environment.NewLine;
                            sqlText += " ,@AUTHORITYLEVELCD" + Environment.NewLine;
                            sqlText += " ,@AUTHORITYLEVELNM" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                        SqlParameter paraAuthorityLevelDiv = sqlCommand.Parameters.Add("@AUTHORITYLEVELDIV", SqlDbType.Int);
                        SqlParameter paraAuthorityLevelCd = sqlCommand.Parameters.Add("@AUTHORITYLEVELCD", SqlDbType.Int);
                        SqlParameter paraAuthorityLevelNm = sqlCommand.Parameters.Add("@AUTHORITYLEVELNM", SqlDbType.NVarChar);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraOfferDate.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.OfferDate);
                        paraAuthorityLevelDiv.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelDiv);
                        paraAuthorityLevelCd.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelCd);
                        paraAuthorityLevelNm.Value = SqlDataMediator.SqlSetString(authorityLevelWork.AuthorityLevelNm);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(authorityLevelWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "AuthorityLevelLcDB.WriteProc", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AuthorityLevelLcDB.WriteProc", 0);
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

            authorityLevelList = al;

            return status;
        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 権限レベルマスタローカル情報を物理削除します
        /// </summary>
        /// <param name="authorityLevelList">物理削除するAuthorityLevel情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : AuthorityLevelのキー値が一致するAuthorityLevel情報を物理削除します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        public int Delete(object authorityLevelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //パラメータチェック
                if (authorityLevelList == null) return status;

                //パラメータのキャスト
                ArrayList paraList = authorityLevelList as ArrayList;
                if (paraList == null)
                {
                    paraList = new ArrayList();
                    AuthorityLevel authorityLevelWork = authorityLevelList as AuthorityLevel;
                    paraList.Add(authorityLevelWork);
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
                WriteErrorLog(ex, "AuthorityLevelLcDB.Delete", 0);
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
        /// 権限レベルマスタローカル情報を物理削除します
        /// </summary>
        /// <param name="authorityLevelList">AuthorityLevel情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : AuthorityLevelList に格納されているAuthorityLevel情報を物理削除します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        private int DeleteProc(ArrayList authorityLevelList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (authorityLevelList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < authorityLevelList.Count; i++)
                    {
                        AuthorityLevel authorityLevelWork = authorityLevelList[i] as AuthorityLevel;

                        //Selectコマンドの生成
                        #region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  OFFERDATERF" + Environment.NewLine;
                        sqlText += " ,AUTHORITYLEVELDIVRF" + Environment.NewLine;
                        sqlText += " ,AUTHORITYLEVELCDRF" + Environment.NewLine;
                        sqlText += " ,AUTHORITYLEVELNMRF" + Environment.NewLine;
                        sqlText += " FROM AUTHORITYLEVELRF" + Environment.NewLine;
                        sqlText += " WHERE" + Environment.NewLine;
                        sqlText += "     AUTHORITYLEVELDIVRF=@FINDAUTHORITYLEVELDIV" + Environment.NewLine;
                        sqlText += " AND AUTHORITYLEVELCDRF=@FINDAUTHORITYLEVELCD" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaAuthorityLevelDiv = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVELDIV", SqlDbType.Int);
                        SqlParameter findParaAuthorityLevelCd = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVELCD", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaAuthorityLevelDiv.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelDiv);
                        findParaAuthorityLevelCd.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelCd);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //Deleteコマンドの生成
                            #region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM AUTHORITYLEVELRF" + Environment.NewLine;
                            sqlText += " WHERE" + Environment.NewLine;
                            sqlText += "     AUTHORITYLEVELDIVRF=@FINDAUTHORITYLEVELDIV" + Environment.NewLine;
                            sqlText += " AND AUTHORITYLEVELCDRF=@FINDAUTHORITYLEVELCD" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEYコマンドを再設定
                            findParaAuthorityLevelDiv.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelDiv);
                            findParaAuthorityLevelCd.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelCd);
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
                status = WriteSQLErrorLog(ex, "AuthorityLevelLcDB.DeleteProc", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AuthorityLevelLcDB.DeleteProc", 0);
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
        /// <param name="authorityLevelWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, AuthorityLevel authorityLevelWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = "WHERE ";

            //権限レベル区分
            retstring += "AUTHORITYLEVELDIVRF=@FINDAUTHORITYLEVELDIV ";
            SqlParameter paraAuthorityLevelDiv = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVELDIV", SqlDbType.Int);
            paraAuthorityLevelDiv.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelDiv);

            //権限レベルコード
            if (authorityLevelWork.AuthorityLevelCd != 0)
            {
                retstring += "AND AUTHORITYLEVELCDRF=@FINDAUTHORITYLEVELCD ";
                SqlParameter paraAuthorityLevelCd = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVELCD", SqlDbType.Int);
                paraAuthorityLevelCd.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelCd);
            }

            //提供日付
            if (authorityLevelWork.OfferDate != 0)
            {
                retstring += "AND OFFERDATERF=@FINDOFFERDATE ";
                SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@FINDOFFERDATE", SqlDbType.Int);
                paraOfferDate.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.OfferDate);
            }

            //権限レベル名称
            if (authorityLevelWork.AuthorityLevelNm != "")
            {
                retstring += "AND AUTHORITYLEVELNMRF=@FINDAUTHORITYLEVELNM ";
                SqlParameter paraAuthorityLevelNm = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVELNM", SqlDbType.NVarChar);
                paraAuthorityLevelNm.Value = SqlDataMediator.SqlSetString(authorityLevelWork.AuthorityLevelNm);
            }

            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → AuthorityLevel
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>AuthorityLevelWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.18</br>
        /// </remarks>
        private AuthorityLevel CopyToAuthorityLevelWorkFromReader(ref SqlDataReader myReader)
        {
            AuthorityLevel wkAuthorityLevelWork = new AuthorityLevel();

            #region クラスへ格納
            wkAuthorityLevelWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkAuthorityLevelWork.AuthorityLevelDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVELDIVRF"));
            wkAuthorityLevelWork.AuthorityLevelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVELCDRF"));
            wkAuthorityLevelWork.AuthorityLevelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AUTHORITYLEVELNMRF"));
            #endregion

            return wkAuthorityLevelWork;
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
