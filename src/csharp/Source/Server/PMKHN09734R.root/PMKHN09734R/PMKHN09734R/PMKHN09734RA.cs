//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ロールグループ権限設定マスタ                    //
//                      リモートオブジェクト                            //
//                  :   PMKHN09734R.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting                  //
// Programmer       :   30746 高川 悟                                   //
// Date             :   2013/02/18                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ロールグループ権限設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : ロールグループ権限設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30746 高川 悟</br>
    /// <br>Date       : 2013/02/18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class RoleGroupAuthDB : RemoteWithAppLockDB, IRoleGroupAuthDB 
    {
        /// <summary>
        /// ロールグループ権限設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public RoleGroupAuthDB()
            : base("PMKHN09736D", "Broadleaf.Application.Remoting.ParamData.RoleGroupAuthWork", "ROLEGRPAUTHRTSTRF")
        {
        }

        # region [Read]
        /// <summary>
        /// 単一のロールグループ権限設定マスタ情報を取得します。
        /// </summary>
        /// <param name="roleGroupAuthObj">RoleGroupAuthWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ権限設定マスタのキー値が一致するロールグループ権限設定マスタ情報を取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int Read(ref object roleGroupAuthObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                RoleGroupAuthWork roleGroupAuthWork = roleGroupAuthObj as RoleGroupAuthWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref roleGroupAuthWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// 単一のロールグループ権限設定マスタ情報を取得します。
        /// </summary>
        /// <param name="roleGroupAuthWork">RoleGroupAuthWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ権限設定マスタのキー値が一致するロールグループ権限設定マスタ情報を取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int Read(ref RoleGroupAuthWork roleGroupAuthWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref roleGroupAuthWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 単一のロールグループ権限設定マスタ情報を取得します。
        /// </summary>
        /// <param name="roleGroupAuthWork">RoleGroupAuthWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ権限設定マスタのキー値が一致するロールグループ権限設定マスタ情報を取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        private int ReadProc(ref RoleGroupAuthWork roleGroupAuthWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT *" + Environment.NewLine;
                sqlText += "FROM   ROLEGRPAUTHRTSTRF" + Environment.NewLine;
                sqlText += "WHERE  ENTERPRISECODERF    = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND  ROLEGROUPCODERF     = @FINDROLEGROUPCODE" + Environment.NewLine;
                sqlText += "  AND  ROLECATEGORYIDRF    = @FINDROLECATEGORYID" + Environment.NewLine;
                sqlText += "  AND  ROLECATEGORYSUBIDRF = @FINDROLECATEGORYSUBID" + Environment.NewLine;
                sqlText += "  AND  ROLEITEMIDRF        = @FINDROLEITEMID" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);
                SqlParameter findParaRoleCategoryID = sqlCommand.Parameters.Add("@FINDROLECATEGORYID", SqlDbType.Int);
                SqlParameter findParaRoleCategorySubID = sqlCommand.Parameters.Add("@FINDROLECATEGORYSUBID", SqlDbType.Int);
                SqlParameter findParaRoleItemID = sqlCommand.Parameters.Add("@FINDROLEITEMID", SqlDbType.Int);

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.EnterpriseCode);
                findParaRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleGroupCode);
                findParaRoleCategoryID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategoryID);
                findParaRoleCategorySubID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategorySubID);
                findParaRoleItemID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleItemID);


#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToRoleGroupAuthWorkFromReader(ref myReader, ref roleGroupAuthWork);
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

        # region [Delete]
        /// <summary>
        /// ロールグループ権限設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="roleGroupAuthList">物理削除するロールグループ権限設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ権限設定マスタのキー値が一致するロールグループ権限設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int Delete(object roleGroupAuthList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = roleGroupAuthList as ArrayList;

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
        /// ロールグループ権限設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="roleGroupAuthList">ロールグループ権限設定マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList に格納されているロールグループ権限設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int Delete(ArrayList roleGroupAuthList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(roleGroupAuthList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ロールグループ権限設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="roleGroupAuthList">ロールグループ権限設定マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList に格納されているロールグループ権限設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        private int DeleteProc(ArrayList roleGroupAuthList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (roleGroupAuthList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < roleGroupAuthList.Count; i++)
                    {
                        RoleGroupAuthWork roleGroupAuthWork = roleGroupAuthList[i] as RoleGroupAuthWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM   ROLEGRPAUTHRTSTRF" + Environment.NewLine;
                        sqlText += "WHERE  ENTERPRISECODERF    = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND  ROLEGROUPCODERF     = @FINDROLEGROUPCODE" + Environment.NewLine;
                        sqlText += "  AND  ROLECATEGORYIDRF    = @FINDROLECATEGORYID" + Environment.NewLine;
                        sqlText += "  AND  ROLECATEGORYSUBIDRF = @FINDROLECATEGORYSUBID" + Environment.NewLine;
                        sqlText += "  AND  ROLEITEMIDRF        = @FINDROLEITEMID" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaRoleCategoryID = sqlCommand.Parameters.Add("@FINDROLECATEGORYID", SqlDbType.Int);
                        SqlParameter findParaRoleCategorySubID = sqlCommand.Parameters.Add("@FINDROLECATEGORYSUBID", SqlDbType.Int);
                        SqlParameter findParaRoleItemID = sqlCommand.Parameters.Add("@FINDROLEITEMID", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.EnterpriseCode);
                        findParaRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleGroupCode);
                        findParaRoleCategoryID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategoryID);
                        findParaRoleCategorySubID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategorySubID);
                        findParaRoleItemID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleItemID);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != roleGroupAuthWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM   ROLEGRPAUTHRTSTRF" + Environment.NewLine;
                            sqlText += "WHERE  ENTERPRISECODERF    = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND  ROLEGROUPCODERF     = @FINDROLEGROUPCODE" + Environment.NewLine;
                            sqlText += "  AND  ROLECATEGORYIDRF    = @FINDROLECATEGORYID" + Environment.NewLine;
                            sqlText += "  AND  ROLECATEGORYSUBIDRF = @FINDROLECATEGORYSUBID" + Environment.NewLine;
                            sqlText += "  AND  ROLEITEMIDRF        = @FINDROLEITEMID" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.EnterpriseCode);
                            findParaRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleGroupCode);
                            findParaRoleCategoryID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategoryID);
                            findParaRoleCategorySubID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategorySubID);
                            findParaRoleItemID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleItemID);

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
        /// ロールグループ権限設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="roleGroupAuthList">検索結果</param>
        /// <param name="roleGroupAuthObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ権限設定マスタのキー値が一致する、全ての車種名称マスタ情報を取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int Search(ref object roleGroupAuthList, object roleGroupAuthObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;


            try
            {
                ArrayList roleGroupAuthArray = roleGroupAuthList as ArrayList;
                RoleGroupAuthWork roleGroupAuthWork = roleGroupAuthObj as RoleGroupAuthWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref roleGroupAuthArray, roleGroupAuthWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// ロールグループ権限設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="roleGroupAuthList">ロールグループ権限設定マスタ情報を格納する ArrayList</param>
        /// <param name="roleGroupAuthWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ権限設定マスタのキー値が一致する、全てのロールグループ権限設定マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int Search(ref ArrayList roleGroupAuthList, RoleGroupAuthWork roleGroupAuthWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref roleGroupAuthList, roleGroupAuthWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ロールグループ権限設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="roleGroupAuthList">ロールグループ権限設定マスタ情報を格納する ArrayList</param>
        /// <param name="modelNamroleGroupAuthWorkeUWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ権限設定マスタのキー値が一致する、全てのロールグループ権限設定マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        private int SearchProc(ref ArrayList roleGroupAuthList, RoleGroupAuthWork roleGroupAuthWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT *" + Environment.NewLine;
                sqlText += "FROM   ROLEGRPAUTHRTSTRF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, roleGroupAuthWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    roleGroupAuthList.Add(this.CopyToRoleGroupAuthWorkFromReader(ref myReader));
                }

                if (roleGroupAuthList.Count > 0)
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
        /// ロールグループ権限設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="roleGroupAuthList">追加・更新するロールグループ権限設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList に格納されている車種名称マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int Write(ref object roleGroupAuthList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = roleGroupAuthList as ArrayList;

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
        /// ロールグループ権限設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="roleGroupAuthList">追加・更新するロールグループ権限設定マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthListに格納されているロールグループ権限設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int Write(ref ArrayList roleGroupAuthList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref roleGroupAuthList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ロールグループ権限設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="roleGroupAuthList">追加・更新するロールグループ権限設定マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList に格納されているロールグループ権限設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        private int WriteProc(ref ArrayList roleGroupAuthList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (roleGroupAuthList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < roleGroupAuthList.Count; i++)
                    {
                        RoleGroupAuthWork roleGroupAuthWork = roleGroupAuthList[i] as RoleGroupAuthWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM   ROLEGRPAUTHRTSTRF" + Environment.NewLine;
                        sqlText += "WHERE  ENTERPRISECODERF    = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND  ROLEGROUPCODERF     = @FINDROLEGROUPCODE" + Environment.NewLine;
                        sqlText += "  AND  ROLECATEGORYIDRF    = @FINDROLECATEGORYID" + Environment.NewLine;
                        sqlText += "  AND  ROLECATEGORYSUBIDRF = @FINDROLECATEGORYSUBID" + Environment.NewLine;
                        sqlText += "  AND  ROLEITEMIDRF        = @FINDROLEITEMID" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaRoleCategoryID = sqlCommand.Parameters.Add("@FINDROLECATEGORYID", SqlDbType.Int);
                        SqlParameter findParaRoleCategorySubID = sqlCommand.Parameters.Add("@FINDROLECATEGORYSUBID", SqlDbType.Int);
                        SqlParameter findParaRoleItemID = sqlCommand.Parameters.Add("@FINDROLEITEMID", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.EnterpriseCode);
                        findParaRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleGroupCode);
                        findParaRoleCategoryID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategoryID);
                        findParaRoleCategorySubID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategorySubID);
                        findParaRoleItemID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleItemID);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != roleGroupAuthWork.UpdateDateTime)
                            {
                                if (roleGroupAuthWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    // 新規登録で該当データ有りの場合には重複
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                else
                                {
                                    // 既存データで更新日時違いの場合には排他
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }

                                return status;
                            }

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE ROLEGRPAUTHRTSTRF" + Environment.NewLine;
                            sqlText += "SET    CREATEDATETIMERF    = @CREATEDATETIME," + Environment.NewLine;
                            sqlText += "       UPDATEDATETIMERF    = @UPDATEDATETIME," + Environment.NewLine;
                            sqlText += "       ENTERPRISECODERF    = @ENTERPRISECODE," + Environment.NewLine;
                            sqlText += "       FILEHEADERGUIDRF    = @FILEHEADERGUID," + Environment.NewLine;
                            sqlText += "       UPDEMPLOYEECODERF   = @UPDEMPLOYEECODE," + Environment.NewLine;
                            sqlText += "       UPDASSEMBLYID1RF    = @UPDASSEMBLYID1," + Environment.NewLine;
                            sqlText += "       UPDASSEMBLYID2RF    = @UPDASSEMBLYID2," + Environment.NewLine;
                            sqlText += "       LOGICALDELETECODERF = @LOGICALDELETECODE," + Environment.NewLine;
                            sqlText += "       ROLEGROUPCODERF     = @ROLEGROUPCODE," + Environment.NewLine;
                            sqlText += "       ROLECATEGORYIDRF    = @ROLECATEGORYID," + Environment.NewLine;
                            sqlText += "       ROLECATEGORYSUBIDRF = @ROLECATEGORYSUBID," + Environment.NewLine;
                            sqlText += "       ROLEITEMIDRF        = @ROLEITEMID," + Environment.NewLine;
                            sqlText += "       ROLELIMITDIVRF      = @ROLELIMITDIV" + Environment.NewLine;
                            sqlText += "WHERE  ENTERPRISECODERF    = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND  ROLEGROPCODERF      = @FINDROLEGROPCODE" + Environment.NewLine;
                            sqlText += "  AND  ROLECATEGORYIDRF    = @FINDROLECATEGORYID" + Environment.NewLine;
                            sqlText += "  AND  ROLECATEGORYSUBIDRF = @FINDROLECATEGORYSUBID" + Environment.NewLine;
                            sqlText += "  AND  ROLEITEMIDRF        = @FINDROLEITEMID" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.EnterpriseCode);
                            findParaRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleGroupCode);
                            findParaRoleCategoryID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategoryID);
                            findParaRoleCategorySubID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategorySubID);
                            findParaRoleItemID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleItemID);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)roleGroupAuthWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (roleGroupAuthWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO ROLEGRPAUTHRTSTRF (" + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF," + Environment.NewLine;
                            sqlText += "    UPDATEDATETIMERF," + Environment.NewLine;
                            sqlText += "    ENTERPRISECODERF," + Environment.NewLine;
                            sqlText += "    FILEHEADERGUIDRF," + Environment.NewLine;
                            sqlText += "    UPDEMPLOYEECODERF," + Environment.NewLine;
                            sqlText += "    UPDASSEMBLYID1RF," + Environment.NewLine;
                            sqlText += "    UPDASSEMBLYID2RF," + Environment.NewLine;
                            sqlText += "    LOGICALDELETECODERF," + Environment.NewLine;
                            sqlText += "    ROLEGROUPCODERF," + Environment.NewLine;
                            sqlText += "    ROLECATEGORYIDRF," + Environment.NewLine;
                            sqlText += "    ROLECATEGORYSUBIDRF," + Environment.NewLine;
                            sqlText += "    ROLEITEMIDRF," + Environment.NewLine;
                            sqlText += "    ROLELIMITDIVRF" + Environment.NewLine;
                            sqlText += ") VALUES (" + Environment.NewLine;
                            sqlText += "    @CREATEDATETIME," + Environment.NewLine;
                            sqlText += "    @UPDATEDATETIME," + Environment.NewLine;
                            sqlText += "    @ENTERPRISECODE," + Environment.NewLine;
                            sqlText += "    @FILEHEADERGUID," + Environment.NewLine;
                            sqlText += "    @UPDEMPLOYEECODE," + Environment.NewLine;
                            sqlText += "    @UPDASSEMBLYID1," + Environment.NewLine;
                            sqlText += "    @UPDASSEMBLYID2," + Environment.NewLine;
                            sqlText += "    @LOGICALDELETECODE," + Environment.NewLine;
                            sqlText += "    @ROLEGROUPCODE," + Environment.NewLine;
                            sqlText += "    @ROLECATEGORYID," + Environment.NewLine;
                            sqlText += "    @ROLECATEGORYSUBID," + Environment.NewLine;
                            sqlText += "    @ROLEITEMID," + Environment.NewLine;
                            sqlText += "    @ROLELIMITDIV" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;

                            IFileHeader flhd = (IFileHeader)roleGroupAuthWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraRoleGroupCode = sqlCommand.Parameters.Add("@ROLEGROUPCODE", SqlDbType.Int);
                        SqlParameter paraRoleCategoryID = sqlCommand.Parameters.Add("@ROLECATEGORYID", SqlDbType.Int);
                        SqlParameter paraRoleCategorySubID = sqlCommand.Parameters.Add("@ROLECATEGORYSUBID", SqlDbType.Int);
                        SqlParameter paraRoleItemID = sqlCommand.Parameters.Add("@ROLEITEMID", SqlDbType.Int);
                        SqlParameter paraRoleLimitDiv = sqlCommand.Parameters.Add("@ROLELIMITDIV", SqlDbType.Int);

                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(roleGroupAuthWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(roleGroupAuthWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(roleGroupAuthWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.LogicalDeleteCode);
                        paraRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleGroupCode);
                        paraRoleCategoryID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategoryID);
                        paraRoleCategorySubID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategorySubID);
                        paraRoleItemID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleItemID);
                        paraRoleLimitDiv.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleLimitDiv);

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(roleGroupAuthWork);
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

            roleGroupAuthList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// ロールグループ権限設定マスタ情報を論理削除します。
        /// </summary>
        /// <param name="roleGroupAuthList">論理削除するロールグループ権限設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList に格納されているロールグループ権限設定マスタ情報を論理削除します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int LogicalDelete(ref object roleGroupAuthList)
        {
            return this.LogicalDelete(ref roleGroupAuthList, 0);
        }

        /// <summary>
        /// ロールグループ権限設定マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="roleGroupAuthList">論理削除を解除するロールグループ権限設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList に格納されているロールグループ権限設定マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int RevivalLogicalDelete(ref object roleGroupAuthList)
        {
            return this.LogicalDelete(ref roleGroupAuthList, 1);
        }

        /// <summary>
        /// ロールグループ権限設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="roleGroupAuthList">論理削除を操作するロールグループ権限設定マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList に格納されているロールグループ権限マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        private int LogicalDelete(ref object roleGroupAuthList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = roleGroupAuthList as ArrayList;

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
        /// ロールグループ権限設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="roleGroupAuthList">論理削除を操作するロールグループ権限設定マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList に格納されているロールグループ権限設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int LogicalDelete(ref ArrayList roleGroupAuthList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref roleGroupAuthList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ロールグループ権限設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="roleGroupAuthList">論理削除を操作するロールグループ権限設定マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList に格納されているロールグループ権限設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        private int LogicalDeleteProc(ref ArrayList roleGroupAuthList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (roleGroupAuthList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < roleGroupAuthList.Count; i++)
                    {
                        RoleGroupAuthWork roleGroupAuthWork = roleGroupAuthList[i] as RoleGroupAuthWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF," + Environment.NewLine;
                        sqlText += "       LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM   ROLEGRPAUTHRTSTRF" + Environment.NewLine;
                        sqlText += "WHERE  ENTERPRISECODERF    = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND  ROLEGROUPCODERF     = @FINDROLEGROUPCODE" + Environment.NewLine;
                        sqlText += "  AND  ROLECATEGORYIDRF    = @FINDROLECATEGORYID" + Environment.NewLine;
                        sqlText += "  AND  ROLECATEGORYSUBIDRF = @FINDROLECATEGORYSUBID" + Environment.NewLine;
                        sqlText += "  AND  ROLEITEMIDRF        = @FINDROLEITEMID" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaRoleCategoryID = sqlCommand.Parameters.Add("@FINDROLECATEGORYID", SqlDbType.Int);
                        SqlParameter findParaRoleCategorySubID = sqlCommand.Parameters.Add("@FINDROLECATEGORYSUBID", SqlDbType.Int);
                        SqlParameter findParaRoleItemID = sqlCommand.Parameters.Add("@FINDROLEITEMID", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.EnterpriseCode);
                        findParaRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleGroupCode);
                        findParaRoleCategoryID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategoryID);
                        findParaRoleCategorySubID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategorySubID);
                        findParaRoleItemID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleItemID);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != roleGroupAuthWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE ROLEGRPAUTHRTSTRF" + Environment.NewLine;
                            sqlText += "SET    UPDATEDATETIMERF    = @UPDATEDATETIME," + Environment.NewLine;
                            sqlText += "       UPDEMPLOYEECODERF   = @UPDEMPLOYEECODE," + Environment.NewLine;
                            sqlText += "       UPDASSEMBLYID1RF    = @UPDASSEMBLYID1," + Environment.NewLine;
                            sqlText += "       UPDASSEMBLYID2RF    = @UPDASSEMBLYID2," + Environment.NewLine;
                            sqlText += "       LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE  ENTERPRISECODERF    = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND  ROLEGROUPCODERF     = @FINDROLEGROUPCODE" + Environment.NewLine;
                            sqlText += "  AND  ROLECATEGORYIDRF    = @FINDROLECATEGORYID" + Environment.NewLine;
                            sqlText += "  AND  ROLECATEGORYSUBIDRF = @FINDROLECATEGORYSUBID" + Environment.NewLine;
                            sqlText += "  AND  ROLEITEMIDRF        = @FINDROLEITEMID" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.EnterpriseCode);
                            findParaRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleGroupCode);
                            findParaRoleCategoryID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategoryID);
                            findParaRoleCategorySubID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategorySubID);
                            findParaRoleItemID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleItemID);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)roleGroupAuthWork;
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
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;             // 既に削除済みの場合正常
                                return status;
                            }
                            else if (logicalDelCd == 0) roleGroupAuthWork.LogicalDeleteCode = 1;    // 論理削除フラグをセット
                            else roleGroupAuthWork.LogicalDeleteCode = 3;                           // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                roleGroupAuthWork.LogicalDeleteCode = 0;                            // 論理削除フラグを解除
                            }
                            else
                            {
                                if (logicalDelCd == 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;         // 既に復活している場合はそのまま正常を戻す
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;      // 完全削除はデータなしを戻す
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(roleGroupAuthWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(roleGroupAuthWork);
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

            roleGroupAuthList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="roleGroupAuthWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, RoleGroupAuthWork roleGroupAuthWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE  ";

            // 企業コード
            retstring += "ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // ロールグループコードが指定されていたら抽出条件に追加
            if (roleGroupAuthWork.RoleGroupCode != 0)
            {
                retstring += "  AND  ROLEGROUPCODERF = @FINDROLEGROUPCODE" + Environment.NewLine;
                SqlParameter findRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);
                findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleGroupCode);

                // カテゴリIDが指定されていたら抽出条件に追加
                if (roleGroupAuthWork.RoleCategoryID != 0)
                {
                    retstring += "  AND  ROLECATEGORYIDRF = @FINDROLECATEGORYID" + Environment.NewLine;
                    SqlParameter findRoleCategoryID = sqlCommand.Parameters.Add("@FINDROLECATEGORYID", SqlDbType.Int);
                    findRoleCategoryID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategoryID);

                    // サブカテゴリIDが指定されていたら抽出条件に追加
                    if (roleGroupAuthWork.RoleCategorySubID != 0)
                    {
                        retstring += "  AND  ROLECATEGORYSUBIDRF = @FINDROLECATEGORYSUBID" + Environment.NewLine;
                        SqlParameter findRoleCategorySubID = sqlCommand.Parameters.Add("@FINDROLECATEGORYSUBID", SqlDbType.Int);
                        findRoleCategorySubID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategorySubID);

                        // アイテムIDが指定されていたら抽出条件に追加
                        if (roleGroupAuthWork.RoleItemID != 0)
                        {
                            retstring += "  AND  ROLEITEMIDRF = @FINDROLEITEMID" + Environment.NewLine;
                            SqlParameter findRoleItemID = sqlCommand.Parameters.Add("@FINDROLEITEMID", SqlDbType.Int);
                            findRoleItemID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleItemID);
                        }
                    }
                }
            }

            return retstring;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → RoleGroupAuthWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RoleGroupAuthWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private RoleGroupAuthWork CopyToRoleGroupAuthWorkFromReader(ref SqlDataReader myReader)
        {
            RoleGroupAuthWork roleGroupAuthWork = new RoleGroupAuthWork();

            this.CopyToRoleGroupAuthWorkFromReader(ref myReader, ref roleGroupAuthWork);

            return roleGroupAuthWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → RoleGroupAuthWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="roleGroupAuthWork">RoleGroupAuthWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void CopyToRoleGroupAuthWorkFromReader(ref SqlDataReader myReader, ref RoleGroupAuthWork roleGroupAuthWork)
        {
            if (myReader != null && roleGroupAuthWork != null)
            {
                # region クラスへ格納
                roleGroupAuthWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                roleGroupAuthWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                roleGroupAuthWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                roleGroupAuthWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                roleGroupAuthWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                roleGroupAuthWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                roleGroupAuthWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                roleGroupAuthWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                roleGroupAuthWork.RoleGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLEGROUPCODERF"));
                roleGroupAuthWork.RoleCategoryID = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLECATEGORYIDRF"));
                roleGroupAuthWork.RoleCategorySubID = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLECATEGORYSUBIDRF"));
                roleGroupAuthWork.RoleItemID = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLEITEMIDRF"));
                roleGroupAuthWork.RoleLimitDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLELIMITDIVRF"));

                # endregion
            }
        }
        # endregion

    }
}