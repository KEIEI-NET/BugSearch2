//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PMDBID管理マスタDBリモートオブジェクト
// プログラム概要   : PMDBID管理マスタDBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/08/18  修正内容 : 新規作成
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
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMDBID管理マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMDBID管理マスタの実データ操作を行うクラスです。</br>
    /// </remarks>
    [Serializable]
    public class PmDbIdMngDB : RemoteWithAppLockDB, IPmDbIdMngDB
    {

        /// <summary>
        /// PMDBID管理マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// </remarks>
        public PmDbIdMngDB()
            : base("PMSCM00296D", "Broadleaf.Application.Remoting.ParamData.PmDbIdMngWork", "PmDbIdMngRF")
        {
        }

        # region [Read]
        /// <summary>
        /// 単一のPMDBID管理マスタ情報を取得します。
        /// </summary>
        /// <param name="pmDbIdMngObj">PmDbIdMngWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID管理マスタのキー値が一致するPMDBID管理マスタ情報を取得します。</br>
        public int Read(ref object pmDbIdMngObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                PmDbIdMngWork pmDbIdMngWork = pmDbIdMngObj as PmDbIdMngWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref pmDbIdMngWork, readMode, sqlConnection, sqlTransaction);
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
        /// 単一のPMDBID管理マスタ情報を取得します。
        /// </summary>
        /// <param name="pmDbIdMngWork">PmDbIdMngWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID管理マスタのキー値が一致するPMDBID管理マスタ情報を取得します。</br>
        public int Read(ref PmDbIdMngWork pmDbIdMngWork, int readMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref pmDbIdMngWork, readMode, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// PMDBID管理マスタ情報リストを取得します。
        /// </summary>
        /// <param name="pmDbIdMngObj">抽出条件リスト(PmDbIdMngWork)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID管理マスタのキー値が一致するPMDBID管理マスタ情報を取得します。</br>
        public int ReadAll(ref object pmDbIdMngObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList paraList = pmDbIdMngObj as ArrayList;
                ArrayList pmDbIdMngList = new ArrayList();

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.ReadAll(ref pmDbIdMngList, paraList, sqlConnection, sqlTransaction);

                pmDbIdMngObj = pmDbIdMngList;

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
        /// 単一のPMDBID管理マスタ情報を取得します。
        /// </summary>
        /// <param name="pmDbIdMngList">抽出結果リスト(PmDbIdMngWork)</param>
        /// <param name="paraList">抽出条件リスト(PmDbIdMngWork)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID管理マスタのキー値が一致するPMDBID管理マスタ情報を取得します。</br>
        public int ReadAll(ref ArrayList pmDbIdMngList, ArrayList paraList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            foreach (PmDbIdMngWork pmDbIdMngWork in paraList)
            {
                PmDbIdMngWork pararetWork = pmDbIdMngWork;

                status = this.ReadProc(ref pararetWork, 0, sqlConnection, sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    pmDbIdMngList.Add(pararetWork);
                }
                else
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        return status;
                    }
            }

            //件数の有無は関係無しで異常系以外はノーマルとする
            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            return status;
        }

        /// <summary>
        /// 単一のPMDBID管理マスタ情報を取得します。
        /// </summary>
        /// <param name="pmDbIdMngWork">PmDbIdMngWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID管理マスタのキー値が一致するPMDBID管理マスタ情報を取得します。</br>
        private int ReadProc(ref PmDbIdMngWork pmDbIdMngWork, int readMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sb = new StringBuilder();
                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction);

                # region [SELECT文]

                sb.AppendLine("SELECT");
                sb.AppendLine("  CREATEDATETIMERF");          // 作成日時
                sb.AppendLine("  , UPDATEDATETIMERF");        // 更新日時
                sb.AppendLine("  , ENTERPRISECODERF");        // 企業コード
                sb.AppendLine("  , DBIDMNGGUIDRF");           // DBID管理GUID
                sb.AppendLine("FROM");
                sb.AppendLine("  PMDBIDMNGRF ");

                sqlCommand.CommandText = sb.ToString();
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, ref pmDbIdMngWork);

                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToRecieveSecTableWorkFromReader(ref myReader, ref pmDbIdMngWork);
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
        /// PMDBID管理マスタ情報を物理削除します
        /// </summary>
        /// <param name="pmDbIdMngList">物理削除するPMDBID管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID管理マスタのキー値が一致するPMDBID管理マスタ情報を物理削除します。</br>
        public int Delete(object pmDbIdMngList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = pmDbIdMngList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, sqlConnection, sqlTransaction);
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
        /// PMDBID管理マスタ情報を物理削除します
        /// </summary>
        /// <param name="pmDbIdMngList">PMDBID管理マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngList に格納されているPMDBID管理マスタ情報を物理削除します。</br>
        public int Delete(ArrayList pmDbIdMngList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(pmDbIdMngList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// PMDBID管理マスタ情報を物理削除します
        /// </summary>
        /// <param name="pmDbIdMngList">PMDBID管理マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngList に格納されているPMDBID管理マスタ情報を物理削除します。</br>
        private int DeleteProc(ArrayList pmDbIdMngList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (pmDbIdMngList != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < pmDbIdMngList.Count; i++)
                    {
                        PmDbIdMngWork pmDbIdMngWork = pmDbIdMngList[i] as PmDbIdMngWork;

                        # region [SELECT文]

                        sb.AppendLine("SELECT");
                        sb.AppendLine("  UPDATEDATETIMERF");
                        sb.AppendLine("FROM");
                        sb.AppendLine("  PMDBIDMNGRF ");

                        sqlCommand.CommandText = sb.ToString();
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, ref pmDbIdMngWork);

                        # endregion

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (pmDbIdMngWork.DbIdMngGuid != "" && _updateDateTime != pmDbIdMngWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]

                            sb = new StringBuilder();
                            sb.AppendLine("DELETE FROM");
                            sb.AppendLine("  PMDBIDMNGRF ");

                            bool isWhere = false;
                            if (pmDbIdMngWork.EnterpriseCode != "")
                            {
                                isWhere = true;
                                sb.AppendLine("WHERE");
                                sb.AppendLine("  ENTERPRISECODERF = @DELETEENTERPRISECODE ");

                                sqlCommand.Parameters.Clear();
                                // Prameterオブジェクトの作成
                                SqlParameter updateParaEnterpriseCode = sqlCommand.Parameters.Add("@DELETEENTERPRISECODE", SqlDbType.NChar);
                                //Parameterオブジェクトへ値設定
                                updateParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmDbIdMngWork.EnterpriseCode);
                            }


                            if (pmDbIdMngWork.DbIdMngGuid != "")
                            {
                                if (isWhere)
                                {
                                    sb.AppendLine("  AND DBIDMNGGUIDRF = @DELETEDBIDMNGGUID ");
                                }
                                else
                                {
                                    sb.AppendLine("WHERE");
                                    sb.AppendLine("  DBIDMNGGUIDRF = @DELETEDBIDMNGGUID ");
                                }
                                // Prameterオブジェクトの作成
                                SqlParameter updateParaDbIdGuid = sqlCommand.Parameters.Add("@DELETEDBIDMNGGUID", SqlDbType.NChar);
                                //Parameterオブジェクトへ値設定
                                updateParaDbIdGuid.Value = SqlDataMediator.SqlSetString(pmDbIdMngWork.DbIdMngGuid);
                            }

                            sqlCommand.CommandText = sb.ToString();

                            # endregion
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
        /// PMDBID管理マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="pmDbIdMngList">検索結果</param>
        /// <param name="pmDbIdMngObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID管理マスタのキー値が一致する、全てのPMDBID管理マスタ情報を取得します。</br>
        public int Search(ref object pmDbIdMngList, object pmDbIdMngObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList pmDbIdMngArray = pmDbIdMngList as ArrayList;
                PmDbIdMngWork pmDbIdMngWork = pmDbIdMngObj as PmDbIdMngWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Search(ref pmDbIdMngArray, pmDbIdMngWork, readMode, logicalMode, sqlConnection, sqlTransaction);

                //TEST
                if (status == 0)
                {
                    pmDbIdMngList = pmDbIdMngArray as object;
                }
                else
                {
                    ArrayList workArray = new ArrayList();
                    pmDbIdMngList = workArray as object;
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
        /// PMDBID管理マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="pmDbIdMngList">PMDBID管理マスタ情報を格納する ArrayList</param>
        /// <param name="pmDbIdMngWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID管理マスタのキー値が一致する、全てのPMDBID管理マスタ情報が格納されている ArrayList を取得します。</br>
        public int Search(ref ArrayList pmDbIdMngList, PmDbIdMngWork pmDbIdMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref pmDbIdMngList, pmDbIdMngWork, readMode, logicalMode, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// PMDBID管理マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="pmDbIdMngList">PMDBID管理マスタ情報を格納する ArrayList</param>
        /// <param name="pmDbIdMngWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID管理マスタのキー値が一致する、全てのPMDBID管理マスタ情報が格納されている ArrayList を取得します。</br>
        private int SearchProc(ref ArrayList pmDbIdMngList, PmDbIdMngWork pmDbIdMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            pmDbIdMngList = new ArrayList();
            try
            {
                StringBuilder sb = new StringBuilder();
                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction);

                # region [SELECT文]

                sb.AppendLine("SELECT");
                sb.AppendLine("  CREATEDATETIMERF");          // 作成日時
                sb.AppendLine("  , UPDATEDATETIMERF");        // 更新日時
                sb.AppendLine("  , ENTERPRISECODERF");        // 企業コード
                sb.AppendLine("  , DBIDMNGGUIDRF");           // DBID管理GUID
                sb.AppendLine("FROM");
                sb.AppendLine("  PMDBIDMNGRF ");

                sqlCommand.CommandText = sb.ToString();
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, ref pmDbIdMngWork);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    pmDbIdMngList.Add(this.CopyToRecieveSecTableWorkFromReader(ref myReader));
                }

                if (pmDbIdMngList.Count > 0)
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
        /// PMDBID管理マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="pmDbIdMngList">追加・更新するPMDBID管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngList に格納されているPMDBID管理マスタ情報を追加・更新します。</br>
        public int Write(ref object pmDbIdMngList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = pmDbIdMngList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                status = this.Write(ref paraList, sqlConnection, sqlTransaction);
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
        /// PMDBID管理マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="pmDbIdMngList">追加・更新するPMDBID管理マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngList に格納されているPMDBID管理マスタ情報を追加・更新します。</br>
        public int Write(ref ArrayList pmDbIdMngList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref pmDbIdMngList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// PMDBID管理マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="pmDbIdMngList">追加・更新するPMDBID管理マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngList に格納されているPMDBID管理マスタ情報を追加・更新します。</br>
        private int WriteProc(ref ArrayList pmDbIdMngList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (pmDbIdMngList != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < pmDbIdMngList.Count; i++)
                    {
                        PmDbIdMngWork pmDbIdMngWork = pmDbIdMngList[i] as PmDbIdMngWork;

                        # region [SELECT文]

                        sb.AppendLine("SELECT");
                        sb.AppendLine("  CREATEDATETIMERF");          // 作成日時
                        sb.AppendLine("  , UPDATEDATETIMERF");        // 更新日時
                        sb.AppendLine("  , ENTERPRISECODERF");        // 企業コード
                        sb.AppendLine("  , DBIDMNGGUIDRF");           // DBID管理GUID
                        sb.AppendLine("FROM");
                        sb.AppendLine("  PMDBIDMNGRF ");

                        sqlCommand.Parameters.Clear();

                        sqlCommand.CommandText = sb.ToString();
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, ref pmDbIdMngWork);

                        # endregion

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            pmDbIdMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時

                            # region [UPDATE文]

                            sb = new StringBuilder();

                            sb.AppendLine("UPDATE PMDBIDMNGRF ");
                            sb.AppendLine("SET");
                            sb.AppendLine("  CREATEDATETIMERF = @CREATEDATETIME");
                            sb.AppendLine("  , UPDATEDATETIMERF = @UPDATEDATETIME");
                            sb.AppendLine("  , ENTERPRISECODERF = @ENTERPRISECODE");
                            sb.AppendLine("  , DBIDMNGGUIDRF = @DBIDMNGGUID");

                            bool isWhere = false;
                            if (pmDbIdMngWork.EnterpriseCode != "")
                            {
                                isWhere = true;
                                sb.AppendLine("WHERE");
                                sb.AppendLine("  ENTERPRISECODERF = @UPDATEENTERPRISECODE ");

                                sqlCommand.Parameters.Clear();
                                // Prameterオブジェクトの作成
                                SqlParameter updateParaEnterpriseCode = sqlCommand.Parameters.Add("@UPDATEENTERPRISECODE", SqlDbType.NChar);
                                //Parameterオブジェクトへ値設定
                                updateParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmDbIdMngWork.EnterpriseCode);
                            }


                            if (pmDbIdMngWork.DbIdMngGuid != "")
                            {
                                if (isWhere)
                                {
                                    sb.AppendLine("  AND DBIDMNGGUIDRF = @UPDATEDBIDMNGGUID ");
                                }
                                else
                                {
                                    sb.AppendLine("WHERE");
                                    sb.AppendLine("  DBIDMNGGUIDRF = @UPDATEDBIDMNGGUID ");
                                }
                                // Prameterオブジェクトの作成
                                SqlParameter updateParaDbIdGuid = sqlCommand.Parameters.Add("@UPDATEDBIDMNGGUID", SqlDbType.NChar);
                                //Parameterオブジェクトへ値設定
                                updateParaDbIdGuid.Value = SqlDataMediator.SqlSetString(pmDbIdMngWork.DbIdMngGuid);
                            }

                            #endregion

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmDbIdMngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            sqlCommand.CommandText = sb.ToString();

                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (pmDbIdMngWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            #region INSERT文

                            sb = new StringBuilder();
                            sb.AppendLine("INSERT ");
                            sb.AppendLine("INTO PMDBIDMNGRF( ");
                            sb.AppendLine("  CREATEDATETIMERF");
                            sb.AppendLine("  , UPDATEDATETIMERF");
                            sb.AppendLine("  , ENTERPRISECODERF");
                            sb.AppendLine("  , DBIDMNGGUIDRF");
                            sb.AppendLine(") ");
                            sb.AppendLine("VALUES ( ");
                            sb.AppendLine("  @CREATEDATETIME");
                            sb.AppendLine("  , @UPDATEDATETIME");
                            sb.AppendLine("  , @ENTERPRISECODE");
                            sb.AppendLine("  , @DBIDMNGGUID");
                            sb.AppendLine(") ");

                            #endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmDbIdMngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            sqlCommand.CommandText = sb.ToString();
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }


                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);               // 作成日時
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);               // 更新日時
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);                // 企業コード
                        SqlParameter paraDbIdMngGuid = sqlCommand.Parameters.Add("@DBIDMNGGUID", SqlDbType.NChar);                   // DBID管理GUID
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmDbIdMngWork.CreateDateTime);           // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmDbIdMngWork.UpdateDateTime);           // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmDbIdMngWork.EnterpriseCode);                      // 企業コード
                        paraDbIdMngGuid.Value = SqlDataMediator.SqlSetString(pmDbIdMngWork.DbIdMngGuid);                        // DBID管理GUID
                        #endregion

                        int cnt = sqlCommand.ExecuteNonQuery();
                        al.Add(pmDbIdMngWork);
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
                    sqlCommand.Dispose();
                }
            }

            pmDbIdMngList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// PMDBID管理マスタ情報を論理削除します。
        /// </summary>
        /// <param name="pmDbIdMngList">論理削除するPMDBID管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngWork に格納されているPMDBID管理マスタ情報を論理削除します。</br>
        public int LogicalDelete(ref object pmDbIdMngList)
        {
            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
        }

        /// <summary>
        /// PMDBID管理マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="pmDbIdMngList">論理削除を解除するPMDBID管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngWork に格納されているPMDBID管理マスタ情報の論理削除を解除します。</br>
        public int RevivalLogicalDelete(ref object pmDbIdMngList)
        {
            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="pmDbIdMngWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ref PmDbIdMngWork pmDbIdMngWork)
        {
            StringBuilder sb = new StringBuilder();

            bool isWhere = false;

            if (pmDbIdMngWork.EnterpriseCode != "")
            {
                isWhere = true;
                sb.AppendLine("WHERE");
                sb.AppendLine("  ENTERPRISECODERF = @FINDENTERPRISECODE ");

                sqlCommand.Parameters.Clear();
                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmDbIdMngWork.EnterpriseCode);
            }

            if (pmDbIdMngWork.DbIdMngGuid != "")
            {
                if (isWhere)
                {
                    sb.AppendLine("  AND DBIDMNGGUIDRF = @FINDDBIDMNGGUID ");
                }
                else
                {
                    sb.AppendLine("WHERE");
                    sb.AppendLine("  DBIDMNGGUIDRF = @FINDDBIDMNGGUID ");
                }
                // Prameterオブジェクトの作成
                SqlParameter findParaDbIdGuid = sqlCommand.Parameters.Add("@FINDDBIDMNGGUID", SqlDbType.NChar);
                //Parameterオブジェクトへ値設定
                findParaDbIdGuid.Value = SqlDataMediator.SqlSetString(pmDbIdMngWork.DbIdMngGuid);
            }

            return sb.ToString();
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → PmDbIdMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PmDbIdMngWork オブジェクト</returns>
        /// <remarks>
        /// </remarks>
        private PmDbIdMngWork CopyToRecieveSecTableWorkFromReader(ref SqlDataReader myReader)
        {
            PmDbIdMngWork pmDbIdMngWork = new PmDbIdMngWork();

            this.CopyToRecieveSecTableWorkFromReader(ref myReader, ref pmDbIdMngWork);

            return pmDbIdMngWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → PmDbIdMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="pmDbIdMngWork">PmDbIdMngWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// </remarks>
        private void CopyToRecieveSecTableWorkFromReader(ref SqlDataReader myReader, ref PmDbIdMngWork pmDbIdMngWork)
        {
            if (myReader != null && pmDbIdMngWork != null)
            {
                # region クラスへ格納
                pmDbIdMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
                pmDbIdMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
                pmDbIdMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));             // 企業コード
                pmDbIdMngWork.DbIdMngGuid = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DBIDMNGGUIDRF"));                  // DBID管理GUID
                # endregion
            }
        }
        # endregion
    }
}