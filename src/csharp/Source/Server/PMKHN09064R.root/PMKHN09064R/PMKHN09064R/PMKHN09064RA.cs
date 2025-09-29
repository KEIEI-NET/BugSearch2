//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   BLグループマスタDBリモートオブジェクト
//                  :   PMKHN09064R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2008.06.05
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// BLグループマスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLグループマスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.06.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class BLGroupUDB : RemoteWithAppLockDB, IBLGroupUDB
    {
        /// <summary>
        /// BLグループマスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        /// </remarks>
        public BLGroupUDB() : base("PMKHN09066D", "Broadleaf.Application.Remoting.ParamData.BLGroupUWork", "BLGROUPURF")
        {

        }

        # region [Read]
        /// <summary>
        /// 単一のBLグループマスタ情報を取得します。
        /// </summary>
        /// <param name="blGroupUObj">BLGroupUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLグループマスタのキー値が一致するBLグループマスタ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Read(ref object blGroupUObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                BLGroupUWork blGroupUWork = blGroupUObj as BLGroupUWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref blGroupUWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// 単一のBLグループマスタ情報を取得します。
        /// </summary>
        /// <param name="blGroupUWork">BLGroupUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLグループマスタのキー値が一致するBLグループマスタ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Read(ref BLGroupUWork blGroupUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref blGroupUWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 単一のBLグループマスタ情報を取得します。
        /// </summary>
        /// <param name="blGroupUWork">BLGroupUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLグループマスタのキー値が一致するBLグループマスタ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private int ReadProc(ref BLGroupUWork blGroupUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  BLG.*" + Environment.NewLine;
                sqlText += "  ,GLG.GUIDENAMERF AS GOODSLGROUPNMRF" + Environment.NewLine;
                sqlText += "  ,SAL.GUIDENAMERF AS SALESCODENMRF" + Environment.NewLine;
                sqlText += "FROM BLGROUPURF AS BLG" + Environment.NewLine;
                sqlText += "  LEFT JOIN USERGDBDURF AS GLG" + Environment.NewLine;
                sqlText += "    ON  BLG.ENTERPRISECODERF = GLG.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND BLG.GOODSLGROUPRF = GLG.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND GLG.USERGUIDEDIVCDRF = 70" + Environment.NewLine;
                sqlText += "  LEFT JOIN USERGDBDURF AS SAL" + Environment.NewLine;
                sqlText += "    ON  BLG.ENTERPRISECODERF = SAL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND BLG.SALESCODERF = SAL.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND SAL.USERGUIDEDIVCDRF = 71" + Environment.NewLine;
                sqlText += "WHERE BLG.ENTERPRISECODERF=@FINDENTERPRISECODE AND BLG.BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGroupUWork.EnterpriseCode);
                findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(blGroupUWork.BLGroupCode);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToBLGroupUWorkFromReader(ref myReader, ref blGroupUWork);
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
        /// BLグループマスタ情報を物理削除します
        /// </summary>
        /// <param name="blGroupUList">物理削除するBLグループマスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLグループマスタのキー値が一致するBLグループマスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Delete(object blGroupUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = blGroupUList as ArrayList;

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
        /// BLグループマスタ情報を物理削除します
        /// </summary>
        /// <param name="blGroupUList">BLグループマスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : blGroupUList に格納されているBLグループマスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Delete(ArrayList blGroupUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(blGroupUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// BLグループマスタ情報を物理削除します
        /// </summary>
        /// <param name="blGroupUList">BLグループマスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : blGroupUList に格納されているBLグループマスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private int DeleteProc(ArrayList blGroupUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (blGroupUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < blGroupUList.Count; i++)
                    {
                        BLGroupUWork blGroupUWork = blGroupUList[i] as BLGroupUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  BLGROUPURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGroupUWork.EnterpriseCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(blGroupUWork.BLGroupCode);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != blGroupUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  BLGROUPURF" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGroupUWork.EnterpriseCode);
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(blGroupUWork.BLGroupCode);

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
        /// BLグループマスタ情報のリストを取得します。
        /// </summary>
        /// <param name="blGroupUList">検索結果</param>
        /// <param name="blGroupUObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLグループマスタのキー値が一致する、全てのBLグループマスタ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Search(ref object blGroupUList, object blGroupUObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList blGroupUArray = blGroupUList as ArrayList;
                BLGroupUWork blGroupUWork = blGroupUObj as BLGroupUWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref blGroupUArray, blGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// BLグループマスタ情報のリストを取得します。
        /// </summary>
        /// <param name="blGroupUList">BLグループマスタ情報を格納する ArrayList</param>
        /// <param name="blGroupUWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLグループマスタのキー値が一致する、全てのBLグループマスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Search(ref ArrayList blGroupUList, BLGroupUWork blGroupUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref blGroupUList, blGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// BLグループマスタ情報のリストを取得します。
        /// </summary>
        /// <param name="blGroupUList">BLグループマスタ情報を格納する ArrayList</param>
        /// <param name="blGroupUWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLグループマスタのキー値が一致する、全てのBLグループマスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private int SearchProc(ref ArrayList blGroupUList, BLGroupUWork blGroupUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  BLG.*" + Environment.NewLine;
                sqlText += "  ,GLG.GUIDENAMERF AS GOODSLGROUPNMRF" + Environment.NewLine;
                sqlText += "  ,SAL.GUIDENAMERF AS SALESCODENMRF" + Environment.NewLine;
                sqlText += "FROM BLGROUPURF AS BLG" + Environment.NewLine;
                sqlText += "  LEFT JOIN USERGDBDURF AS GLG" + Environment.NewLine;
                sqlText += "    ON  BLG.ENTERPRISECODERF = GLG.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND BLG.GOODSLGROUPRF = GLG.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND GLG.USERGUIDEDIVCDRF = 70" + Environment.NewLine;
                sqlText += "  LEFT JOIN USERGDBDURF AS SAL" + Environment.NewLine;
                sqlText += "    ON  BLG.ENTERPRISECODERF = SAL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND BLG.SALESCODERF = SAL.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND SAL.USERGUIDEDIVCDRF = 71" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, blGroupUWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    blGroupUList.Add(this.CopyToBLGroupUWorkFromReader(ref myReader));
                }

                if (blGroupUList.Count > 0)
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
        /// BLグループマスタ情報を追加・更新します。
        /// </summary>
        /// <param name="blGroupUList">追加・更新するBLグループマスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : blGroupUList に格納されているBLグループマスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Write(ref object blGroupUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = blGroupUList as ArrayList;

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
        /// BLグループマスタ情報を追加・更新します。
        /// </summary>
        /// <param name="blGroupUList">追加・更新するBLグループマスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : blGroupUList に格納されているBLグループマスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Write(ref ArrayList blGroupUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref blGroupUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// BLグループマスタ情報を追加・更新します。
        /// </summary>
        /// <param name="blGroupUList">追加・更新するBLグループマスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : blGroupUList に格納されているBLグループマスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private int WriteProc(ref ArrayList blGroupUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (blGroupUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < blGroupUList.Count; i++)
                    {
                        BLGroupUWork blGroupUWork = blGroupUList[i] as BLGroupUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  BLGROUPURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGroupUWork.EnterpriseCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(blGroupUWork.BLGroupCode);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != blGroupUWork.UpdateDateTime)
                            {
                                if (blGroupUWork.UpdateDateTime == DateTime.MinValue)
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

                            ////提供データを修正した場合は提供データ区分に１をセットする
                            //if ((blGroupUWork.OfferDate != DateTime.MinValue) && (blGroupUWork.OfferDataDiv == 1))
                            //{
                            //    blGroupUWork.OfferDataDiv = 1;
                            //}

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText = "UPDATE BLGROUPURF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , GOODSLGROUPRF=@GOODSLGROUP , GOODSMGROUPRF=@GOODSMGROUP , BLGROUPCODERF=@BLGROUPCODE , BLGROUPNAMERF=@BLGROUPNAME , BLGROUPKANANAMERF=@BLGROUPKANANAME , SALESCODERF=@SALESCODE , OFFERDATERF=@OFFERDATE , OFFERDATADIVRF=@OFFERDATADIV WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BLGROUPCODERF=@FINDBLGROUPCODE";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGroupUWork.EnterpriseCode);
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(blGroupUWork.BLGroupCode);


                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)blGroupUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {

                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (blGroupUWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO BLGROUPURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, GOODSLGROUPRF, GOODSMGROUPRF, BLGROUPCODERF, BLGROUPNAMERF, BLGROUPKANANAMERF, SALESCODERF, OFFERDATERF, OFFERDATADIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @GOODSLGROUP, @GOODSMGROUP, @BLGROUPCODE, @BLGROUPNAME, @BLGROUPKANANAME, @SALESCODE, @OFFERDATE, @OFFERDATADIV)";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)blGroupUWork;
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
                        SqlParameter paraGoodsLGroup = sqlCommand.Parameters.Add("@GOODSLGROUP", SqlDbType.Int);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraBLGroupName = sqlCommand.Parameters.Add("@BLGROUPNAME", SqlDbType.NVarChar);
                        SqlParameter paraBLGroupKanaName = sqlCommand.Parameters.Add("@BLGROUPKANANAME", SqlDbType.NVarChar);
                        SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
                        SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                        SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);

                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(blGroupUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(blGroupUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGroupUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(blGroupUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(blGroupUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(blGroupUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(blGroupUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(blGroupUWork.LogicalDeleteCode);
                        paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(blGroupUWork.GoodsLGroup);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(blGroupUWork.GoodsMGroup);
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(blGroupUWork.BLGroupCode);
                        paraBLGroupName.Value = SqlDataMediator.SqlSetString(blGroupUWork.BLGroupName);
                        paraBLGroupKanaName.Value = SqlDataMediator.SqlSetString(blGroupUWork.BLGroupKanaName);
                        paraSalesCode.Value = SqlDataMediator.SqlSetInt32(blGroupUWork.SalesCode);
                        paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(blGroupUWork.OfferDate);
                        paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(blGroupUWork.OfferDataDiv);

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(blGroupUWork);
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

            blGroupUList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// BLグループマスタ情報を論理削除します。
        /// </summary>
        /// <param name="blGroupUList">論理削除するBLグループマスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : blGroupUWork に格納されているBLグループマスタ情報を論理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int LogicalDelete(ref object blGroupUList)
        {
            return this.LogicalDelete(ref blGroupUList, 0);
        }

        /// <summary>
        /// BLグループマスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="blGroupUList">論理削除を解除するBLグループマスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : blGroupUWork に格納されているBLグループマスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int RevivalLogicalDelete(ref object blGroupUList)
        {
            return this.LogicalDelete(ref blGroupUList, 1);
        }

        /// <summary>
        /// BLグループマスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="blGroupUList">論理削除を操作するBLグループマスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : blGroupUWork に格納されているBLグループマスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private int LogicalDelete(ref object blGroupUList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = blGroupUList as ArrayList;

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
        /// BLグループマスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="blGroupUList">論理削除を操作するBLグループマスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : blGroupUWork に格納されているBLグループマスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int LogicalDelete(ref ArrayList blGroupUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref blGroupUList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// BLグループマスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="blGroupUList">論理削除を操作するBLグループマスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : blGroupUWork に格納されているBLグループマスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private int LogicalDeleteProc(ref ArrayList blGroupUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (blGroupUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < blGroupUList.Count; i++)
                    {
                        BLGroupUWork blGroupUWork = blGroupUList[i] as BLGroupUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  BLGROUPURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGroupUWork.EnterpriseCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(blGroupUWork.BLGroupCode);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != blGroupUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  BLGROUPURF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGroupUWork.EnterpriseCode);
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(blGroupUWork.BLGroupCode);


                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)blGroupUWork;
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
                            else if (logicalDelCd == 0) blGroupUWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else blGroupUWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                blGroupUWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(blGroupUWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(blGroupUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(blGroupUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(blGroupUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(blGroupUWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(blGroupUWork);
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

            blGroupUList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="blGroupUWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, BLGroupUWork blGroupUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // 企業コード
            retstring += "  BLG.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGroupUWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND BLG.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND BLG.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            if (blGroupUWork.BLGroupCode != 0)
            {
                retstring += "AND BLG.BLGROUPCODERF = @FINDBLGROUPCODE" + Environment.NewLine;
                SqlParameter findBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                findBLGroupCode.Value = SqlDataMediator.SqlSetInt32(blGroupUWork.BLGroupCode);
            }

            return retstring;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → BLGroupUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>BLGroupUWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        /// </remarks>
        private BLGroupUWork CopyToBLGroupUWorkFromReader(ref SqlDataReader myReader)
        {
            BLGroupUWork blGroupUWork = new BLGroupUWork();

            this.CopyToBLGroupUWorkFromReader(ref myReader, ref blGroupUWork);

            return blGroupUWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → BLGroupUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="blGroupUWork">BLGroupUWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        /// </remarks>
        private void CopyToBLGroupUWorkFromReader(ref SqlDataReader myReader, ref BLGroupUWork blGroupUWork)
        {
            if (myReader != null && blGroupUWork != null)
            {
                # region クラスへ格納
                blGroupUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                blGroupUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                blGroupUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                blGroupUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                blGroupUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                blGroupUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                blGroupUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                blGroupUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                blGroupUWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                blGroupUWork.GoodsLGroupNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNMRF"));
                blGroupUWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                blGroupUWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                blGroupUWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
                blGroupUWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));
                blGroupUWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                blGroupUWork.SalesCodeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCODENMRF"));
                blGroupUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                blGroupUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));

                # endregion
            }
        }
        # endregion
    }
}
