//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メールメッセージ設定処理
// プログラム概要   : メールメッセージ設定処理DBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011.08.09  修正内容 : 新規作成
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
    /// メールメッセージ設定処理リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : メールメッセージ設定処理の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date       : 2011.08.09</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PccMailDtDB : RemoteDB, IPccMailDtDB
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public PccMailDtDB() : base("PMPCC01016D", "Broadleaf.Application.Remoting.ParamData.PccMailDtWork", "PCCMAILDTRF")
        {
        }

        #region [コネクション生成処理]
        /// <summary>
        /// コネクション生成処理
        /// </summary>
        /// <returns>コネクション</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_SCM_UserDB);
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
        /// トランザクション生成処理
        /// </summary>
        /// <returns>トランザクション</returns>
        /// <remarks>
        /// <br>Note       : トランザクション生成処理</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }
        #endregion  //トランザクション生成処理

        #region IPccMailDtDB メンバ

        /// <summary>
        /// メールメッセージ設定処理登録、更新処理
        /// </summary>
        /// <param name="pccMailDtWorkList">PCCメールデータリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int Write(ref object pccMailDtWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // パラメータのキャスト
                ArrayList paraList = pccMailDtWorkList as ArrayList;

                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                status = WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccMailDtDB.Write");
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
        /// メールメッセージ設定処理登録、更新処理
        /// </summary>
        /// <param name="pccMailDtWorkList">PCCメールデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int WriteProc(ref ArrayList pccMailDtWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try 
            {
                if (pccMailDtWorkList != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    
                    for (int i = 0; i < pccMailDtWorkList.Count; i++)
                    {
                        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                        PccMailDtWork pccMailDtWork = pccMailDtWorkList[i] as PccMailDtWork;

                        # region [SELECT文]
                        sqlText = new StringBuilder();
                        sqlText.Append("SELECT UPDATEDATETIMERF").Append(Environment.NewLine);
                        sqlText.Append(" FROM PCCMAILDTRF").Append(Environment.NewLine);
                        sqlText.Append(" WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD").Append(Environment.NewLine);
                        sqlText.Append(" AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD").Append(Environment.NewLine);
                        sqlText.Append(" AND INQOTHEREPCDRF=@FINDINQOTHEREPCD").Append(Environment.NewLine);
                        sqlText.Append(" AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);
                        sqlText.Append(" AND UPDATEDATERF=@FINDUPDATEDATE").Append(Environment.NewLine);
                        sqlText.Append(" AND UPDATETIMERF=@FINDUPDATETIME").Append(Environment.NewLine);

                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // Prameterオブジェクトの作成

                        SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                        SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                        SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                        SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                        SqlParameter findParaUpdateDate = sqlCommand.Parameters.Add("@FINDUPDATEDATE", SqlDbType.Int);
                        SqlParameter findParaUpdateTime = sqlCommand.Parameters.Add("@FINDUPDATETIME", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalEpCd);
                        findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalSecCd);
                        findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherEpCd);
                        findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherSecCd);
                        findParaUpdateDate.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateDate);
                        findParaUpdateTime.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateTime);
                        //タイムアウト時間の設定
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        myReader = sqlCommand.ExecuteReader();

                         if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != pccMailDtWork.UpdateDateTime)
                            {
                                if (pccMailDtWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText.Append("UPDATE PCCMAILDTRF SET CREATEDATETIMERF=@CREATEDATETIME").Append(Environment.NewLine);
                            sqlText.Append(" , UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                            sqlText.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);

                            sqlText.Append(" , INQORIGINALEPCDRF=@INQORIGINALEPCD").Append(Environment.NewLine);
                            sqlText.Append(" , INQORIGINALSECCDRF=@INQORIGINALSECCD").Append(Environment.NewLine);
                            sqlText.Append(" , INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
                            sqlText.Append(" , INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
                            sqlText.Append(" , UPDATEDATERF=@UPDATEDATE").Append(Environment.NewLine);
                            sqlText.Append(" , UPDATETIMERF=@UPDATETIME").Append(Environment.NewLine);

                            sqlText.Append(" , PCCMAILTITLERF=@PCCMAILTITLE").Append(Environment.NewLine);
                            sqlText.Append(" , PCCMAILDOCCNTSRF=@PCCMAILDOCCNTS").Append(Environment.NewLine);


                            sqlText.Append("  WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD").Append(Environment.NewLine);
                            sqlText.Append("  AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD").Append(Environment.NewLine);
                            sqlText.Append("  AND INQOTHEREPCDRF=@FINDINQOTHEREPCD").Append(Environment.NewLine);
                            sqlText.Append("  AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);
                            sqlText.Append("  AND UPDATEDATERF=@FINDUPDATEDATE").Append(Environment.NewLine);
                            sqlText.Append("  AND UPDATETIMERF=@FINDUPDATETIME").Append(Environment.NewLine);
                         
                            sqlCommand.CommandText = sqlText.ToString().ToString();
                            # endregion
                            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalEpCd);
                            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalSecCd);
                            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherEpCd);
                            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherSecCd);
                            findParaUpdateDate.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateDate);
                            findParaUpdateTime.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateTime);
                        
                            // 更新ヘッダ情報を設定
                            pccMailDtWork.UpdateDateTime = DateTime.Now;
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (pccMailDtWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = new StringBuilder();
                            sqlText.Append("INSERT INTO PCCMAILDTRF").Append(Environment.NewLine);
                            sqlText.Append(" (CREATEDATETIMERF").Append(Environment.NewLine);
                            sqlText.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);
                            sqlText.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);

                            sqlText.Append("    ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                            sqlText.Append("    ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                            sqlText.Append("    ,INQOTHEREPCDRF").Append(Environment.NewLine);
                            sqlText.Append("    ,INQOTHERSECCDRF").Append(Environment.NewLine);
                            sqlText.Append("    ,UPDATEDATERF").Append(Environment.NewLine);

                            sqlText.Append("    ,UPDATETIMERF").Append(Environment.NewLine);
                            sqlText.Append("    ,PCCMAILTITLERF").Append(Environment.NewLine);
                            sqlText.Append("    ,PCCMAILDOCCNTSRF").Append(Environment.NewLine);


                           
                            sqlText.Append(" )").Append(Environment.NewLine);
                            sqlText.Append(" VALUES").Append(Environment.NewLine);
                            sqlText.Append(" (@CREATEDATETIME").Append(Environment.NewLine);
                            sqlText.Append("    ,@UPDATEDATETIME").Append(Environment.NewLine);
                            sqlText.Append("    ,@LOGICALDELETECODE").Append(Environment.NewLine);

                            sqlText.Append("    ,@INQORIGINALEPCD").Append(Environment.NewLine);
                            sqlText.Append("    ,@INQORIGINALSECCD").Append(Environment.NewLine);
                            sqlText.Append("    ,@INQOTHEREPCD").Append(Environment.NewLine);
                            sqlText.Append("    ,@INQOTHERSECCD").Append(Environment.NewLine);
                            sqlText.Append("    ,@UPDATEDATE").Append(Environment.NewLine);

                            sqlText.Append("    ,@UPDATETIME").Append(Environment.NewLine);
                            sqlText.Append("    ,@PCCMAILTITLE").Append(Environment.NewLine);
                            sqlText.Append("    ,@PCCMAILDOCCNTS").Append(Environment.NewLine);
                            sqlText.Append(" )").Append(Environment.NewLine);
                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // 登録ヘッダ情報を設定
                            pccMailDtWork.UpdateDateTime = DateTime.Now;
                            pccMailDtWork.CreateDateTime = DateTime.Now;
                            pccMailDtWork.LogicalDeleteCode = 0;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                      
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                        SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                        SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                        SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                        SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                        SqlParameter paraUpdateTime = sqlCommand.Parameters.Add("@UPDATETIME", SqlDbType.Int);
                        SqlParameter paraPccMailTitle = sqlCommand.Parameters.Add("@PCCMAILTITLE", SqlDbType.VarChar);
                        SqlParameter paraMailDocCnts = sqlCommand.Parameters.Add("@PCCMAILDOCCNTS", SqlDbType.VarChar);

                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccMailDtWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccMailDtWork.UpdateDateTime);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.LogicalDeleteCode);

                        paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalEpCd);
                        paraInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalSecCd);
                        paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherEpCd);
                        paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherSecCd);
                        paraUpdateDate.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateDate);
                        paraUpdateTime.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateTime);
                        paraPccMailTitle.Value = SqlDataMediator.SqlSetString(pccMailDtWork.PccMailTitle);
                        paraMailDocCnts.Value = SqlDataMediator.SqlSetString(pccMailDtWork.PccMailDocCnts);

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
                base.WriteErrorLog(ex, "PccMailDtWorkDB.LogicalDelete");
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
        /// メールメッセージ設定検索処理
        /// </summary>
        /// <param name="pccMailDtWorkList">PCCメールデータリスト</param>
        /// <param name="parsePccMailDtWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int Search(ref object pccMailDtWorkList, PccMailDtWork parsePccMailDtWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            pccMailDtWorkList = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchProc(ref pccMailDtWorkList, parsePccMailDtWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccMailDtDB.Search");
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
        /// メールメッセージ設定検索処理
        /// </summary>
        /// <param name="pccMailDtWorkList">PCCメールデータリスト</param>
        /// <param name="parsePccMailDtWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int SearchProc(ref object pccMailDtWorkList, PccMailDtWork parsePccMailDtWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList pccMailDtArray = pccMailDtWorkList as ArrayList;

            if (pccMailDtArray == null)
            {
                pccMailDtArray = new ArrayList();
            }

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT文]
                sqlText.Append("SELECT CREATEDATETIMERF").Append(Environment.NewLine);
                sqlText.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);         
                sqlText.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);
               
                sqlText.Append("    ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlText.Append("    ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlText.Append("    ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlText.Append("    ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlText.Append("    ,UPDATEDATERF").Append(Environment.NewLine);
                sqlText.Append("    ,UPDATETIMERF").Append(Environment.NewLine);
               
                sqlText.Append("    ,PCCMAILTITLERF").Append(Environment.NewLine);
                sqlText.Append("    ,PCCMAILDOCCNTSRF").Append(Environment.NewLine);
                sqlText.Append("    FROM PCCMAILDTRF WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
                sqlText.Append("    WHERE ").Append(Environment.NewLine);
                if (!string.IsNullOrEmpty(parsePccMailDtWork.InqOriginalEpCd.Trim()))	//@@@@20230303
                {
                    sqlText.Append("    INQORIGINALEPCDRF=@FINDINQORIGINALEPCD").Append(Environment.NewLine);
                    // Prameterオブジェクトの作成
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                    // Parameterオブジェクトへ値設定
                    findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(parsePccMailDtWork.InqOriginalEpCd);
                }
                if (!string.IsNullOrEmpty(parsePccMailDtWork.InqOriginalSecCd))
                {
                    if (!string.IsNullOrEmpty(parsePccMailDtWork.InqOriginalEpCd.Trim()))	//@@@@20230303
                    {
                        sqlText.Append(" AND ");
                    }
                    sqlText.Append(" INQORIGINALSECCDRF=@FINDINQORIGINALSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(parsePccMailDtWork.InqOriginalSecCd);
                }
                if (!string.IsNullOrEmpty(parsePccMailDtWork.InqOtherEpCd))
                {
                    if (!string.IsNullOrEmpty(parsePccMailDtWork.InqOriginalEpCd.Trim()) || !string.IsNullOrEmpty(parsePccMailDtWork.InqOriginalSecCd))	//@@@@20230303
                    {
                        sqlText.Append(" AND ");
                    }
                    sqlText.Append(" INQOTHEREPCDRF=@FINDINQOTHEREPCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(parsePccMailDtWork.InqOtherEpCd);
                
                }
                if (!string.IsNullOrEmpty(parsePccMailDtWork.InqOtherSecCd))
                {
                    if (!string.IsNullOrEmpty(parsePccMailDtWork.InqOriginalEpCd.Trim()) || !string.IsNullOrEmpty(parsePccMailDtWork.InqOriginalSecCd) || !string.IsNullOrEmpty(parsePccMailDtWork.InqOtherEpCd))	//@@@@20230303
                    {
                        sqlText.Append(" AND ");
                    }
                    sqlText.Append(" INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(parsePccMailDtWork.InqOtherSecCd);
                }
                if (parsePccMailDtWork.UpdateDateSt > 0)
                {
                    sqlText.Append(" AND UPDATEDATERF>=@FINDINFINDUPDATEDATEST").Append(Environment.NewLine);
                    SqlParameter findParaUpdateDateSt = sqlCommand.Parameters.Add("@FINDINFINDUPDATEDATEST", SqlDbType.Int);
                    findParaUpdateDateSt.Value = SqlDataMediator.SqlSetInt32(parsePccMailDtWork.UpdateDateSt);
                
                }
                if (parsePccMailDtWork.UpdateDateEd > 0)
                {
                    sqlText.Append(" AND UPDATEDATERF<=@FINDINFINDUPDATEDATEED").Append(Environment.NewLine);
                    SqlParameter findParaUpdateDateEd = sqlCommand.Parameters.Add("@FINDINFINDUPDATEDATEED", SqlDbType.Int);
                    findParaUpdateDateEd.Value = SqlDataMediator.SqlSetInt32(parsePccMailDtWork.UpdateDateEd);
                }
                //論理削除区分
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    sqlText.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                sqlText.Append("  ORDER BY INQORIGINALEPCDRF ASC, INQORIGINALSECCDRF ASC,INQOTHEREPCDRF ASC,INQOTHERSECCDRF ASC,UPDATEDATERF DESC,UPDATETIMERF DESC").Append(Environment.NewLine);


                sqlCommand.CommandText = sqlText.ToString();
              
                # endregion
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

               myReader = sqlCommand.ExecuteReader();
               status = CopyToPccMailDtListFromReader(ref myReader, ref pccMailDtArray);
                if (pccMailDtArray.Count > 0)
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
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "PccMailDtDB.Search");
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
            pccMailDtWorkList = pccMailDtArray;
            return status;
        }

        /// <summary>
        /// メールメッセージ設定検索処理
        /// </summary>
        /// <param name="pccMailDtWorkList">PCCメールデータリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int Read(ref object pccMailDtWorkList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                PccMailDtWork pccMailDtWork = pccMailDtWorkList as PccMailDtWork;

                status = ReadProc(ref pccMailDtWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccMailDtDB.Read");
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
        /// メールメッセージ設定検索処理
        /// </summary>
        /// <param name="pccMailDtWork">PCCメールデータリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int ReadProc(ref PccMailDtWork pccMailDtWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
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
                sqlText.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);

                sqlText.Append("    ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlText.Append("    ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlText.Append("    ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlText.Append("    ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlText.Append("    ,UPDATEDATERF").Append(Environment.NewLine);
                sqlText.Append("    ,UPDATETIMERF").Append(Environment.NewLine);

                sqlText.Append("    ,PCCMAILTITLERF").Append(Environment.NewLine);
                sqlText.Append("    ,PCCMAILDOCCNTSRF").Append(Environment.NewLine);
                sqlText.Append(" FROM PCCMAILDTRF WITH (READUNCOMMITTED)   ").Append(Environment.NewLine);
                sqlText.Append(" WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlText.Append(" AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlText.Append(" AND INQOTHEREPCDRF=@FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlText.Append(" AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlText.Append(" AND UPDATEDATERF=@FINDUPDATEDATE").Append(Environment.NewLine);
                sqlText.Append(" AND UPDATETIMERF=@FINDUPDATETIME").Append(Environment.NewLine);
                //論理削除区分
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    sqlText.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                sqlCommand.CommandText = sqlText.ToString();

                // Prameterオブジェクトの作成
                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                SqlParameter findParaUpdateDate = sqlCommand.Parameters.Add("@FINDUPDATEDATE", SqlDbType.Int);
                SqlParameter findParaUpdateTime = sqlCommand.Parameters.Add("@FINDUPDATETIME", SqlDbType.Int);

                // Parameterオブジェクトへ値設定
                findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalEpCd);
                findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalSecCd);
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherSecCd);
                findParaUpdateDate.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateDate);
                findParaUpdateTime.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateTime);

                # endregion
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    pccMailDtWork = this.CopyToPccMailDtWorkFromReader(ref myReader);
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
        /// メールメッセージ設定論理削除処理
        /// </summary>
        /// <param name="pccMailDtWorkList">PCCメールデータリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int LogicalDelete(ref object pccMailDtWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                status = LogicalDeleteProc(ref pccMailDtWorkList, 0, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccMailDtDB.LogicalDelete");
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
        /// メールメッセージ設定論理削除処理
        /// </summary>
        /// <param name="pccMailDtWorkList">PCCメールデータリスト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int LogicalDeleteProc(ref object pccMailDtWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList pccMailDtWorkArrList = null;
            ArrayList pccMailDtWorkArrListNew = null;

            try
            {

                if (pccMailDtWorkList != null)
                {
                    pccMailDtWorkArrList = pccMailDtWorkList as ArrayList;
                }

                if (pccMailDtWorkList == null || pccMailDtWorkArrList.Count == 0)
                {
                    return status;
                }
                pccMailDtWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccMailDtWorkArrList.Count; i++)
                {
                    PccMailDtWork pccMailDtWorkEach = pccMailDtWorkArrList[i] as PccMailDtWork;
                    status = LogicalDeleteProcEach(ref pccMailDtWorkEach, procMode, ref  sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccMailDtWorkArrListNew.Add(pccMailDtWorkEach);

                    pccMailDtWorkList = pccMailDtWorkArrListNew as object;

                }

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccMailDtWorkDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccMailDtWorkDB.LogicalDeleteProc Exception=" + ex.Message);
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
        ///  メールメッセージ設定論理削除処理
        /// </summary>
        /// <param name="pccMailDtWorkEach">PCCメールデータ</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        private int LogicalDeleteProcEach(ref PccMailDtWork pccMailDtWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int logicalDelCd = 0;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlText = new StringBuilder();
            sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

            sqlText.Append("SELECT").Append(Environment.NewLine);
            sqlText.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlText.Append(" ,LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlText.Append("FROM").Append(Environment.NewLine);
            sqlText.Append("  PCCMAILDTRF").Append(Environment.NewLine);
            sqlText.Append(" WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlText.Append(" AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlText.Append(" AND INQOTHEREPCDRF=@FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlText.Append(" AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlText.Append(" AND UPDATEDATERF=@FINDUPDATEDATE").Append(Environment.NewLine);
            sqlText.Append(" AND UPDATETIMERF=@FINDUPDATETIME").Append(Environment.NewLine);
            sqlCommand.CommandText = sqlText.ToString();

            // Prameterオブジェクトの作成
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaUpdateDate = sqlCommand.Parameters.Add("@FINDUPDATEDATE", SqlDbType.Int);
            SqlParameter findParaUpdateTime = sqlCommand.Parameters.Add("@FINDUPDATETIME", SqlDbType.Int);

           // Parameterオブジェクトへ値設定
            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWorkEach.InqOriginalEpCd);
            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWorkEach.InqOriginalSecCd);
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWorkEach.InqOtherSecCd);
            findParaUpdateDate.Value = SqlDataMediator.SqlSetInt32(pccMailDtWorkEach.UpdateDate);
            findParaUpdateTime.Value = SqlDataMediator.SqlSetInt32(pccMailDtWorkEach.UpdateTime);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            
            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                if (_updateDateTime != pccMailDtWorkEach.UpdateDateTime)
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
                sqlText.Append("  PCCMAILDTRF").Append(Environment.NewLine);
                sqlText.Append("SET").Append(Environment.NewLine);
                sqlText.Append("  UPDATEDATETIMERF = @UPDATEDATETIME").Append(Environment.NewLine);
                sqlText.Append(" ,LOGICALDELETECODERF = @LOGICALDELETECODE").Append(Environment.NewLine);

                sqlText.Append(" WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlText.Append(" AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlText.Append(" AND INQOTHEREPCDRF=@FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlText.Append(" AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlText.Append(" AND UPDATEDATERF=@FINDUPDATEDATE").Append(Environment.NewLine);
                sqlText.Append(" AND UPDATETIMERF=@FINDUPDATETIME").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                // KEYコマンドを再設定
                findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWorkEach.InqOriginalEpCd);
                findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWorkEach.InqOriginalSecCd);
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWorkEach.InqOtherSecCd);
                findParaUpdateDate.Value = SqlDataMediator.SqlSetInt32(pccMailDtWorkEach.UpdateDate);
                findParaUpdateTime.Value = SqlDataMediator.SqlSetInt32(pccMailDtWorkEach.UpdateTime);
                  

                // 更新ヘッダ情報を設定
                pccMailDtWorkEach.UpdateDateTime = DateTime.Now;
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

                if (logicalDelCd == 0) pccMailDtWorkEach.LogicalDeleteCode = 1;//論理削除フラグをセット

            }
            else
            {
                if (logicalDelCd == 1) pccMailDtWorkEach.LogicalDeleteCode = 0;//論理削除フラグを解除

            }
            // Parameterオブジェクトの作成(更新用)
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
           
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

            // Parameterオブジェクトへ値設定(更新用)
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccMailDtWorkEach.UpdateDateTime);

            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccMailDtWorkEach.LogicalDeleteCode);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

            sqlCommand.ExecuteNonQuery();




            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            return status;

        }

        /// <summary>
        /// メールメッセージ設定物理削除処理
        /// </summary>
        /// <param name="pccMailDtWorkList">PCCメールデータリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int Delete(ref object pccMailDtWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // パラメータのキャスト
                ArrayList paraList = pccMailDtWorkList as ArrayList;
               
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                status = DeleteProc(ref paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccMailDtDB.Delete");
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
        /// メールメッセージ設定物理削除処理
        /// </summary>
        /// <param name="pccMailDtWorkList">PCCメールデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int DeleteProc(ref ArrayList pccMailDtWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (pccMailDtWorkList != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    
                    for (int i = 0; i < pccMailDtWorkList.Count; i++)
                    {
                        PccMailDtWork pccMailDtWork = pccMailDtWorkList[i] as PccMailDtWork;
                        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                        # region [SELECT文]
                        sqlText = new StringBuilder();
                        sqlText.Append("SELECT UPDATEDATETIMERF").Append(Environment.NewLine);
                        sqlText.Append(" FROM PCCMAILDTRF").Append(Environment.NewLine);
                        sqlText.Append(" WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD").Append(Environment.NewLine);
                        sqlText.Append(" AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD").Append(Environment.NewLine);
                        sqlText.Append(" AND INQOTHEREPCDRF=@FINDINQOTHEREPCD").Append(Environment.NewLine);
                        sqlText.Append(" AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);
                        sqlText.Append(" AND UPDATEDATERF=@FINDUPDATEDATE").Append(Environment.NewLine);
                        sqlText.Append(" AND UPDATETIMERF=@FINDUPDATETIME").Append(Environment.NewLine);

                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // Prameterオブジェクトの作成

                        SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                        SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                        SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                        SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                        SqlParameter findParaUpdateDate = sqlCommand.Parameters.Add("@FINDUPDATEDATE", SqlDbType.Int);
                        SqlParameter findParaUpdateTime = sqlCommand.Parameters.Add("@FINDUPDATETIME", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalEpCd);
                        findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalSecCd);
                        findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherEpCd);
                        findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherSecCd);
                        findParaUpdateDate.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateDate);
                        findParaUpdateTime.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateTime);
                        //タイムアウト時間の設定
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != pccMailDtWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = new StringBuilder();
                            sqlText.Append("DELETE").Append(Environment.NewLine);
                            sqlText.Append(" FROM PCCMAILDTRF").Append(Environment.NewLine);
                            sqlText.Append(" WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD").Append(Environment.NewLine);
                            sqlText.Append(" AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD").Append(Environment.NewLine);
                            sqlText.Append(" AND INQOTHEREPCDRF=@FINDINQOTHEREPCD").Append(Environment.NewLine);
                            sqlText.Append(" AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);
                            sqlText.Append(" AND UPDATEDATERF=@FINDUPDATEDATE").Append(Environment.NewLine);
                            sqlText.Append(" AND UPDATETIMERF=@FINDUPDATETIME").Append(Environment.NewLine);

                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // Parameterオブジェクトへ値設定
                            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalEpCd);
                            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalSecCd);
                            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherEpCd);
                            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherSecCd);
                            findParaUpdateDate.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateDate);
                            findParaUpdateTime.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateTime);

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
        /// メールメッセージ設定復活処理
        /// </summary>
        /// <param name="pccMailDtWorkList">PCCメールデータリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object pccMailDtWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                status = RevivalLogicalDeleteProc(ref pccMailDtWorkList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccMailDtDB.Delete");
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
        /// メールメッセージ設定復活処理
        /// </summary>
        /// <param name="pccMailDtWorkList">PCCメールデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int RevivalLogicalDeleteProc(ref object pccMailDtWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            status = LogicalDeleteProc(ref pccMailDtWorkList, 1, ref sqlConnection, ref sqlTransaction);
            return status;
        }


        #endregion

        #region 内部処理
         /// <summary>
        /// PCCメールメッセージ設定取得処理
        /// </summary>
        /// <param name="myReader">メールメッセージ設定Reader</param>
        /// <param name="pccMailDtWorkList">メールメッセージ設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyToPccMailDtListFromReader(ref SqlDataReader myReader, ref ArrayList pccMailDtWorkList)
        {
            pccMailDtWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //作成日時
            int colIndex_CreateDateTime = 0;
            //更新日時
            int colIndex_UpdateDateTime = 0;
            //論理削除区分
            int colIndex_LogicalDeleteCode = 0;
            //問合せ元企業コード
            int colIndex_InqOriginalEpCd = 0;
            //問合せ元拠点コード
            int colIndex_InqOriginalSecCd = 0;
            //問合せ先企業コード
            int colIndex_InqOtherEpCd = 0;
            //問合せ先拠点コード
            int colIndex_InqOtherSecCd = 0;
            //更新年月日
            int colIndex_UpdateDate = 0;
            //更新時分秒ミリ秒
            int colIndex_UpdateTime = 0;
            //PCCメール件名
            int colIndex_PccMailTitle = 0;
            //PCCメール本文
            int colIndex_PccMailDocCnts = 0;
            try
            {
                if (myReader.HasRows)
                {
                    //作成日時
                    colIndex_CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
                    //更新日時
                    colIndex_UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
                    //論理削除区分
                    colIndex_LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
                    //問合せ元企業コード
                    colIndex_InqOriginalEpCd = myReader.GetOrdinal("INQORIGINALEPCDRF");
                    //問合せ元拠点コード
                    colIndex_InqOriginalSecCd = myReader.GetOrdinal("INQORIGINALSECCDRF");
                    //問合せ先企業コード
                    colIndex_InqOtherEpCd = myReader.GetOrdinal("INQOTHEREPCDRF");
                    //問合せ先拠点コード
                    colIndex_InqOtherSecCd = myReader.GetOrdinal("INQOTHERSECCDRF");
                    //更新年月日
                    colIndex_UpdateDate = myReader.GetOrdinal("UPDATEDATERF");
                    //更新時分秒ミリ秒
                    colIndex_UpdateTime = myReader.GetOrdinal("UPDATETIMERF");
                    //PCCメール件名
                    colIndex_PccMailTitle = myReader.GetOrdinal("PCCMAILTITLERF");
                    //PCCメール本文
                    colIndex_PccMailDocCnts = myReader.GetOrdinal("PCCMAILDOCCNTSRF");
                }
                while (myReader.Read())
                {
                    PccMailDtWork pccMailDtWork = new PccMailDtWork();
                    //作成日時
                    pccMailDtWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                    //更新日時
                    pccMailDtWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                    //論理削除区分
                    pccMailDtWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                    //問合せ元企業コード
                    pccMailDtWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd).Trim();//@@@@20230303
                    //問合せ元拠点コード
                    pccMailDtWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
                    //問合せ先企業コード
                    pccMailDtWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                    //問合せ先拠点コード
                    pccMailDtWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                    //更新年月日
                    pccMailDtWork.UpdateDate = SqlDataMediator.SqlGetInt32(myReader, colIndex_UpdateDate);
                    //更新時分秒ミリ秒
                    pccMailDtWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, colIndex_UpdateTime);
                    //PCCメール件名
                    pccMailDtWork.PccMailTitle = SqlDataMediator.SqlGetString(myReader, colIndex_PccMailTitle);
                    //PCCメール本文
                    pccMailDtWork.PccMailDocCnts = SqlDataMediator.SqlGetString(myReader, colIndex_PccMailDocCnts);
                    pccMailDtWorkList.Add(pccMailDtWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccMailDtDB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// PCCメールデータ取得処理
        /// </summary>
        /// <param name="myReader">PCCメールデータReader</param>
        /// <returns>ＰPCCメールデータ</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private PccMailDtWork CopyToPccMailDtWorkFromReader(ref SqlDataReader myReader)
        {
            PccMailDtWork pccMailDtWork = new PccMailDtWork();
            if (myReader != null && pccMailDtWork != null)
            {
                # region クラスへ格納
                pccMailDtWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                pccMailDtWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));

                pccMailDtWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                pccMailDtWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF")).Trim();//@@@@20230303
                pccMailDtWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
                pccMailDtWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));
                pccMailDtWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));
                pccMailDtWork.UpdateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATEDATERF"));
                pccMailDtWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));

                pccMailDtWork.PccMailTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PCCMAILTITLERF"));
                pccMailDtWork.PccMailDocCnts = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PCCMAILDOCCNTSRF"));

                # endregion
            }
            
            return pccMailDtWork;
        }

       
        #endregion

    }
}
