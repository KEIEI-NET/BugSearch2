//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PCC全体設定マスタ取得設定マスタメンテ
// プログラム概要   : PCC全体設定取得設定マスタメンテDBリモートオブジェクト   
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葉巧燕
// 作 成 日  2011.08.01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
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
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PCC全体設定マスタ取得設定マスタメンテリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC全体設定マスタ取得設定マスタメンテの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 葉巧燕</br>
    /// <br>Date       : 2011.08.01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PccTtlStDB : RemoteDB, IPccTtlStDB
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public PccTtlStDB()
            : base("PMPCC09006D", "Broadleaf.Application.Remoting.ParamData.PccTtlStWork", "PCCTTLSTRF")
        {
        }

        #region [コネクション生成処理]

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (string.IsNullOrEmpty(connectionText))
            {
                return null;
            }

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }

        #endregion

        #region [トランザクション生成処理]

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <returns>SqlTransaction</returns>
        /// <remarks>
        /// <br>Note       : SqlTransaction生成処理</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }

        #endregion  //トランザクション生成処理

        #region IPccTtlStDB メンバ

        /// <summary>
        /// PCC全体設定取得設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccTtlStObj">PCC全体設定取得設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Read(ref object pccTtlStObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                PccTtlStWork pccTtlStWork = pccTtlStObj as PccTtlStWork;

                status = ReadProc(ref pccTtlStWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccTtlStDB.Read");
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
            return status;
        }

        /// <summary>
        /// PCC全体設定取得設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccTtlStWork">PCC全体設定取得設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int ReadProc(ref PccTtlStWork pccTtlStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT文]
                sqlText.Append("SELECT CREATEDATETIMERF").Append(Environment.NewLine);
                sqlText.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlText.Append("    ,ENTERPRISECODERF").Append(Environment.NewLine);
                sqlText.Append("    ,FILEHEADERGUIDRF").Append(Environment.NewLine);
                sqlText.Append("    ,UPDEMPLOYEECODERF").Append(Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID1RF").Append(Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID2RF").Append(Environment.NewLine);
                sqlText.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlText.Append("    ,SECTIONCODERF").Append(Environment.NewLine);
                sqlText.Append("    ,FRONTEMPLOYEECDRF").Append(Environment.NewLine);
                sqlText.Append("    ,FRONTEMPLOYEENMRF").Append(Environment.NewLine);
                sqlText.Append("    ,DELIVEREDGOODSDIVRF").Append(Environment.NewLine);
                sqlText.Append("    ,SALESSLIPPRTDIVRF").Append(Environment.NewLine);
                sqlText.Append("    ,ACPODRRSLIPPRTDIVRF").Append(Environment.NewLine);
                sqlText.Append(" FROM PCCTTLSTRF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
                sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.SectionCode);

                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToPccTtlStWorkFromReader(ref myReader, ref pccTtlStWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
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
        /// PCC全体設定取得設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="pccTtlStList">PCC全体設定取得設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Delete(ref object pccTtlStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // パラメータのキャスト
                ArrayList paraList = pccTtlStList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                status = this.DeleteProc(ref paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "PccTtlStDB.Delete");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// PCC全体設定取得設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="pccTtlStList">PCC全体設定取得設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>    
        public int DeleteProc(ref ArrayList pccTtlStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (pccTtlStList != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < pccTtlStList.Count; i++)
                    {
                        PccTtlStWork pccTtlStWork = pccTtlStList[i] as PccTtlStWork;

                        # region [SELECT文]
                        sqlText = new StringBuilder();
                        sqlText.Append("SELECT UPDATEDATETIMERF").Append(Environment.NewLine);
                        sqlText.Append(" FROM PCCTTLSTRF").Append(Environment.NewLine);
                        sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
                        sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);

                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.SectionCode);

                        //タイムアウト時間の設定
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != pccTtlStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = new StringBuilder();
                            sqlText.Append("DELETE").Append(Environment.NewLine);
                            sqlText.Append(" FROM PCCTTLSTRF").Append(Environment.NewLine);
                            sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
                            sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);

                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.SectionCode);

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
                        //タイムアウト時間の設定
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "PccTtlStDB.Delete");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// PCC全体設定取得設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccTtlStList">PCC全体設定取得設定データリスト</param>
        /// <param name="pccTtlStObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Search(ref object pccTtlStList, PccTtlStWork pccTtlStObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            pccTtlStList = null;
            SqlConnection sqlConnection = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                PccTtlStWork pccTtlStWork = pccTtlStObj as PccTtlStWork;
                status = SearchProc(ref pccTtlStList, pccTtlStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccTtlStDB.Search");
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
            return status;
        }

        /// <summary>
        /// PCC全体設定取得設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccTtlStList">PCC全体設定取得設定データリスト</param>
        /// <param name="pccTtlStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>  
        public int SearchProc(ref object pccTtlStList, PccTtlStWork pccTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList pccTtlStArray = pccTtlStList as ArrayList;

            if (pccTtlStArray == null)
            {
                pccTtlStArray = new ArrayList();
            }
            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT文]
                sqlText.Append("SELECT CREATEDATETIMERF").Append(Environment.NewLine);
                sqlText.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlText.Append("    ,ENTERPRISECODERF").Append(Environment.NewLine);
                sqlText.Append("    ,FILEHEADERGUIDRF").Append(Environment.NewLine);
                sqlText.Append("    ,UPDEMPLOYEECODERF").Append(Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID1RF").Append(Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID2RF").Append(Environment.NewLine);
                sqlText.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlText.Append("    ,SECTIONCODERF").Append(Environment.NewLine);
                sqlText.Append("    ,FRONTEMPLOYEECDRF").Append(Environment.NewLine);
                sqlText.Append("    ,DELIVEREDGOODSDIVRF").Append(Environment.NewLine);
                sqlText.Append("    ,SALESSLIPPRTDIVRF").Append(Environment.NewLine);
                sqlText.Append("    ,ACPODRRSLIPPRTDIVRF").Append(Environment.NewLine);
                sqlText.Append(" FROM PCCTTLSTRF").Append(Environment.NewLine);
                sqlText.Append(" WITH (READUNCOMMITTED)").Append(Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
                sqlText.Append("  ORDER BY ENTERPRISECODERF, SECTIONCODERF").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlText.ToString();

                // Prameterオブジェクトの作成
               
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.SectionCode);

                # endregion

                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                myReader = sqlCommand.ExecuteReader();
                status = CopyToListForSearch(ref myReader, out pccTtlStArray);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "PccTtlStDB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
            pccTtlStList = pccTtlStArray;
            return status;

        }

        /// <summary>
        /// PCC全体設定取得設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pccTtlStList">PCC全体設定取得設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Write(ref object pccTtlStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // パラメータのキャスト
                ArrayList paraList = pccTtlStList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                // write実行
                status = this.WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "PccTtlStDB.Write");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// PCC全体設定取得設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pccTtlStList">PCC全体設定取得設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int WriteProc(ref ArrayList pccTtlStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (pccTtlStList != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < pccTtlStList.Count; i++)
                    {
                        PccTtlStWork pccTtlStWork = pccTtlStList[i] as PccTtlStWork;

                        # region [SELECT文]
                        sqlText = new StringBuilder();
                        sqlText.Append("SELECT UPDATEDATETIMERF").Append(Environment.NewLine);
                        sqlText.Append(" FROM PCCTTLSTRF").Append(Environment.NewLine);
                        sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
                        sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);

                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // Prameterオブジェクトの作成

                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.SectionCode);

                        //タイムアウト時間の設定
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != pccTtlStWork.UpdateDateTime)
                            {
                                if (pccTtlStWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText = new StringBuilder();
                            sqlText.Append("UPDATE PCCTTLSTRF SET CREATEDATETIMERF=@CREATEDATETIME").Append(Environment.NewLine);
                            sqlText.Append(" , UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                            sqlText.Append(" , ENTERPRISECODERF=@ENTERPRISECODE").Append(Environment.NewLine);
                            sqlText.Append(" , FILEHEADERGUIDRF=@FILEHEADERGUID").Append(Environment.NewLine);
                            sqlText.Append(" , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE").Append(Environment.NewLine);
                            sqlText.Append(" , UPDASSEMBLYID1RF=@UPDASSEMBLYID1").Append(Environment.NewLine);
                            sqlText.Append(" , UPDASSEMBLYID2RF=@UPDASSEMBLYID2").Append(Environment.NewLine);
                            sqlText.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                            sqlText.Append(" , SECTIONCODERF=@SECTIONCODE").Append(Environment.NewLine);
                            sqlText.Append(" , FRONTEMPLOYEECDRF=@FRONTEMPLOYEECD").Append(Environment.NewLine);
                            sqlText.Append(" , DELIVEREDGOODSDIVRF=@DELIVEREDGOODSDIV").Append(Environment.NewLine);
                            sqlText.Append(" , SALESSLIPPRTDIVRF=@SALESSLIPPRTDIV").Append(Environment.NewLine);
                            sqlText.Append(" , ACPODRRSLIPPRTDIVRF=@ACPODRRSLIPPRTDIV").Append(Environment.NewLine);
                            sqlText.Append("  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
                            sqlText.Append("  AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);
                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.SectionCode);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pccTtlStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (pccTtlStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = new StringBuilder();
                            sqlText.Append("INSERT INTO PCCTTLSTRF").Append(Environment.NewLine);
                            sqlText.Append(" (CREATEDATETIMERF").Append(Environment.NewLine);
                            sqlText.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);
                            sqlText.Append("    ,ENTERPRISECODERF").Append(Environment.NewLine);
                            sqlText.Append("    ,FILEHEADERGUIDRF").Append(Environment.NewLine);
                            sqlText.Append("    ,UPDEMPLOYEECODERF").Append(Environment.NewLine);
                            sqlText.Append("    ,UPDASSEMBLYID1RF").Append(Environment.NewLine);
                            sqlText.Append("    ,UPDASSEMBLYID2RF").Append(Environment.NewLine);
                            sqlText.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);
                            sqlText.Append("    ,SECTIONCODERF").Append(Environment.NewLine);
                            sqlText.Append("    ,FRONTEMPLOYEECDRF").Append(Environment.NewLine);
                            sqlText.Append("    ,DELIVEREDGOODSDIVRF").Append(Environment.NewLine);
                            sqlText.Append("    ,SALESSLIPPRTDIVRF").Append(Environment.NewLine);
                            sqlText.Append("    ,ACPODRRSLIPPRTDIVRF").Append(Environment.NewLine);
                            sqlText.Append(" )").Append(Environment.NewLine);
                            sqlText.Append(" VALUES").Append(Environment.NewLine);
                            sqlText.Append(" (@CREATEDATETIME").Append(Environment.NewLine);
                            sqlText.Append("    ,@UPDATEDATETIME").Append(Environment.NewLine);
                            sqlText.Append("    ,@ENTERPRISECODE").Append(Environment.NewLine);
                            sqlText.Append("    ,@FILEHEADERGUID").Append(Environment.NewLine);
                            sqlText.Append("    ,@UPDEMPLOYEECODE").Append(Environment.NewLine);
                            sqlText.Append("    ,@UPDASSEMBLYID1").Append(Environment.NewLine);
                            sqlText.Append("    ,@UPDASSEMBLYID2").Append(Environment.NewLine);
                            sqlText.Append("    ,@LOGICALDELETECODE").Append(Environment.NewLine);
                            sqlText.Append("    ,@SECTIONCODE").Append(Environment.NewLine);
                            sqlText.Append("    ,@FRONTEMPLOYEECD").Append(Environment.NewLine);
                            sqlText.Append("    ,@DELIVEREDGOODSDIV").Append(Environment.NewLine);
                            sqlText.Append("    ,@SALESSLIPPRTDIV").Append(Environment.NewLine);
                            sqlText.Append("    ,@ACPODRRSLIPPRTDIV").Append(Environment.NewLine);
                            sqlText.Append(" )").Append(Environment.NewLine);
                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pccTtlStWork;
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
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraFrontEmployeeCd = sqlCommand.Parameters.Add("@FRONTEMPLOYEECD", SqlDbType.NChar);
                        SqlParameter paraDeliveredGoodsDiv = sqlCommand.Parameters.Add("@DELIVEREDGOODSDIV", SqlDbType.Int);
                        SqlParameter paraSalesSlipPrtDiv = sqlCommand.Parameters.Add("@SALESSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraAcpOdrrSlipPrtDiv = sqlCommand.Parameters.Add("@ACPODRRSLIPPRTDIV", SqlDbType.Int);

                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccTtlStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccTtlStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(pccTtlStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pccTtlStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pccTtlStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccTtlStWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.SectionCode);
                        paraFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(pccTtlStWork.FrontEmployeeCd);
                        paraDeliveredGoodsDiv.Value = SqlDataMediator.SqlSetInt32(pccTtlStWork.DeliveredGoodsDiv);
                        paraSalesSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(pccTtlStWork.SalesSlipPrtDiv);
                        paraAcpOdrrSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(pccTtlStWork.AcpOdrrSlipPrtDiv);

                        # endregion

                        //タイムアウト時間の設定
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                        sqlCommand.ExecuteNonQuery();
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "PccTtlStDB.LogicalDelete");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// PCC全体設定取得設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccTtlStList">PCC全体設定取得設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int LogicalDelete(ref object pccTtlStList)
        {
            return this.LogicalDelete(ref pccTtlStList, 0);
        }

        /// <summary>
        /// UOE 自社設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="pccTtlStList">論理削除を操作するUOE 自社設定マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PccTtlStWork に格納されているUOE 自社設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer :葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        public int LogicalDelete(ref object pccTtlStList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                status = this.LogicalDeleteProc(ref pccTtlStList, procMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "PccTtlStDB.LogicalDelete");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// UOE 自社設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="pccTtlStList">論理削除を操作するUOE 自社設定マスタ情報を格納する</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PccTtlStWork に格納されているUOE 自社設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer :葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        private int LogicalDeleteProc(ref object pccTtlStList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList pccTtlStArrList = null;
            ArrayList pccTtlStArrListNew = null;
            try
            {

                if (pccTtlStList != null)
                {
                    pccTtlStArrList = pccTtlStList as ArrayList;
                }
                if (pccTtlStArrList == null || pccTtlStArrList.Count == 0)
                {
                    return status;

                }
                pccTtlStArrListNew = new ArrayList();

                for (int i = 0; i < pccTtlStArrList.Count; i++)
                {
                    PccTtlStWork pccTtlStWorkEach = pccTtlStArrList[i] as PccTtlStWork;
                    status = LogicalDeleteProcEach(ref pccTtlStWorkEach, procMode, ref  sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccTtlStArrListNew.Add(pccTtlStWorkEach);

                    pccTtlStList = pccTtlStArrListNew as object;

                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccTtlStWorkDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccTtlStWorkDB.LogicalDeleteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // myReaderの釈放
                if (myReader != null && !myReader.IsClosed)
                {
                    myReader.Close();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// UOE 自社設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="pccTtlStWorkEach">論理削除を操作するUOE 自社設定マスタ情報を格納する</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">トランザクション情報</param>
        /// <param name="myReader">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PccTtlStWork に格納されているUOE 自社設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer :葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        private int LogicalDeleteProcEach(ref PccTtlStWork pccTtlStWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int logicalDelCd = 0;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            StringBuilder sqlText = new StringBuilder();

            sqlText.Append("SELECT").Append(Environment.NewLine);
            sqlText.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlText.Append(" ,LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlText.Append("FROM").Append(Environment.NewLine);
            sqlText.Append("  PCCTTLSTRF").Append(Environment.NewLine);
            sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
            sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);


            // Prameterオブジェクトの作成

            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

            // Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pccTtlStWorkEach.EnterpriseCode);
            findParaSectionCode.Value = SqlDataMediator.SqlSetString(pccTtlStWorkEach.SectionCode);

            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                if (_updateDateTime != pccTtlStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }

                // 現在の論理削除区分を取得
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                # region [UPDATE文]
                sqlText = new StringBuilder();
                sqlText.Append("UPDATE").Append(Environment.NewLine);
                sqlText.Append("  PCCTTLSTRF").Append(Environment.NewLine);
                sqlText.Append("SET").Append(Environment.NewLine);
                sqlText.Append("  UPDATEDATETIMERF = @UPDATEDATETIME").Append(Environment.NewLine);
                sqlText.Append(" ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE").Append(Environment.NewLine);
                sqlText.Append(" ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1").Append(Environment.NewLine);
                sqlText.Append(" ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2").Append(Environment.NewLine);
                sqlText.Append(" ,LOGICALDELETECODERF = @LOGICALDELETECODE").Append(Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
                sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                // KEYコマンドを再設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pccTtlStWorkEach.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(pccTtlStWorkEach.SectionCode);


                // 更新ヘッダ情報を設定
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)pccTtlStWorkEach;
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
            //論理削除モードの場合
            if (procMode == 0)
            {

                if (logicalDelCd == 0) pccTtlStWorkEach.LogicalDeleteCode = 1;//論理削除フラグをセット

            }
            else
            {
                if (logicalDelCd == 1) pccTtlStWorkEach.LogicalDeleteCode = 0;//論理削除フラグを解除

            }


            // Parameterオブジェクトの作成(更新用)
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

            // Parameterオブジェクトへ値設定(更新用)
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccTtlStWorkEach.UpdateDateTime);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pccTtlStWorkEach.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pccTtlStWorkEach.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pccTtlStWorkEach.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccTtlStWorkEach.LogicalDeleteCode);

            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            return status;

        }

        /// <summary>
        /// PCC全体設定取得設定マスタメンテ復活処理
        /// </summary>
        /// <param name="pccTtlStList">PCC全体設定取得設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object pccTtlStList)
        {
            return this.LogicalDelete(ref pccTtlStList, 1);
        }

        #endregion

        #region 内部処理

        # region [クラス格納処理]

        /// <summary>
        /// クラス格納処理 Reader → PccTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PccTtlStWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer :葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private PccTtlStWork CopyToPccTtlStWorkFromReader(ref SqlDataReader myReader)
        {
            PccTtlStWork pccTtlStWork = new PccTtlStWork();

            this.CopyToPccTtlStWorkFromReader(ref myReader, ref pccTtlStWork);

            return pccTtlStWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → PccTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="pccTtlStWork">PccTtlStWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer :葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void CopyToPccTtlStWorkFromReader(ref SqlDataReader myReader, ref PccTtlStWork pccTtlStWork)
        {
            if (myReader != null && pccTtlStWork != null)
            {
                # region クラスへ格納


                pccTtlStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                pccTtlStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                pccTtlStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                pccTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                pccTtlStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                pccTtlStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                pccTtlStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                pccTtlStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                pccTtlStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                pccTtlStWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
                pccTtlStWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));
                pccTtlStWork.SalesSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPPRTDIVRF"));
                pccTtlStWork.AcpOdrrSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRRSLIPPRTDIVRF"));
                # endregion
            }
        }

        /// <summary>
        /// クラス格納処理 Reader → PccTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="pccTtlStWork">PccTtlStWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer :葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private int CopyToListForSearch(ref SqlDataReader myReader, out ArrayList pccTtlStWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            pccTtlStWorkList = new ArrayList();
            //作成日時
            int colIndex_CreateDateTime = 0;
            //更新日時
            int colIndex_UpdateDateTime = 0;
            //企業コード
            int colIndex_EnterpriseCode = 0;
            //GUID
            int colIndex_FileHeaderGuid = 0;
            //更新従業員コード
            int colIndex_UpdEmployeeCode = 0;
            //更新アセンブリID1
            int colIndex_UpdAssemblyId1 = 0;
            //更新アセンブリID2
            int colIndex_UpdAssemblyId2 = 0;
            //論理削除区分
            int colIndex_LogicalDeleteCode = 0;
            //拠点コード
            int colIndex_SectionCode = 0;
            //受付従業員コード
            int colIndex_FrontEmployeeCd = 0;
            //納品区分
            int colIndex_DeliveredGoodsDiv = 0;
            //売上伝票発行区分
            int colIndex_SalesSlipPrtDiv = 0;
            //受注伝票印刷区分
            int colIndex_AcpOdrrSlipPrtDiv = 0;
            if (myReader.HasRows)
            {
                //作成日時
                colIndex_CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
                //更新日時
                colIndex_UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
                //企業コード
                colIndex_EnterpriseCode = myReader.GetOrdinal("ENTERPRISECODERF");
                //GUID
                colIndex_FileHeaderGuid = myReader.GetOrdinal("FILEHEADERGUIDRF");
                //更新従業員コード
                colIndex_UpdEmployeeCode = myReader.GetOrdinal("UPDEMPLOYEECODERF");
                //更新アセンブリID1
                colIndex_UpdAssemblyId1 = myReader.GetOrdinal("UPDASSEMBLYID1RF");
                //更新アセンブリID2
                colIndex_UpdAssemblyId2 = myReader.GetOrdinal("UPDASSEMBLYID2RF");
                //論理削除区分
                colIndex_LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
                //拠点コード
                colIndex_SectionCode = myReader.GetOrdinal("SECTIONCODERF");
                //受付従業員コード
                colIndex_FrontEmployeeCd = myReader.GetOrdinal("FRONTEMPLOYEECDRF");
                //納品区分
                colIndex_DeliveredGoodsDiv = myReader.GetOrdinal("DELIVEREDGOODSDIVRF");
                //売上伝票発行区分
                colIndex_SalesSlipPrtDiv = myReader.GetOrdinal("SALESSLIPPRTDIVRF");
                //受注伝票印刷区分
                colIndex_AcpOdrrSlipPrtDiv = myReader.GetOrdinal("ACPODRRSLIPPRTDIVRF");
            }
            while (myReader.Read())
            {
                PccTtlStWork pccTtlStWork = new PccTtlStWork();
                //作成日時
                pccTtlStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                //更新日時
                pccTtlStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                //企業コード
                pccTtlStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, colIndex_EnterpriseCode);
                //GUID
                pccTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, colIndex_FileHeaderGuid);
                //更新従業員コード
                pccTtlStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, colIndex_UpdEmployeeCode);
                //更新アセンブリID1
                pccTtlStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, colIndex_UpdAssemblyId1);
                //更新アセンブリID2
                pccTtlStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, colIndex_UpdAssemblyId2);
                //論理削除区分
                pccTtlStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                //拠点コード
                pccTtlStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, colIndex_SectionCode);
                //受付従業員コード
                pccTtlStWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, colIndex_FrontEmployeeCd);
                //納品区分
                pccTtlStWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_DeliveredGoodsDiv);
                //売上伝票発行区分
                pccTtlStWork.SalesSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_SalesSlipPrtDiv);
                //受注伝票印刷区分
                pccTtlStWork.AcpOdrrSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_AcpOdrrSlipPrtDiv);
                pccTtlStWorkList.Add(pccTtlStWork);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            if (pccTtlStWorkList.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            return status;
        }
        # endregion

        #endregion

    }
}
