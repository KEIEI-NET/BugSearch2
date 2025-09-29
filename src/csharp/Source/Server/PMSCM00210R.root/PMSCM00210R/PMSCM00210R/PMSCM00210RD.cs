//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   同期実行管理 リモートオブジェクト
//                  :   PMSCM00210R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   田建委
// Date             :   2014/08/01
//----------------------------------------------------------------------
// 管理番号  11670219-00 作成担当 : 陳艶丹
// 修 正 日  2020/06/18  修正内容 : PMKOBETSU-4005 ＥＢＥ対策
//----------------------------------------------------------------------
// Update Note      : 
//----------------------------------------------------------------------
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Data.SqlClient;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;// ADD 2020/06/18 陳艶丹 PMKOBETSU-4005

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 同期実行スレッドクラス。
    /// </summary>
    /// <remarks>
    /// <br>Note       : 同期実行スレッドのオブジェクト</br>
    /// <br>Programmer : 松本 宏紀</br>
    /// <br>Date       : 2014/08/07</br>
    /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2020/06/18</br>
    /// </remarks>
    public class SyncExecThreadDB : RemoteWithAppLockDB
    {
        private static object _syncBatchOneThreadLock = new object();
        private static object _syncRealOneThreadLock = new object();

        private SyncExecWorkDB _worker;

        /// <summary>
        /// 同期実行スレッド(即時)のコンストラクタ
        /// </summary>
        public SyncExecThreadDB(SyncExecWorkDB worker)
        {
            this._worker = worker;
        }

        /// <summary>
        /// 同期実行スレッド(リアル)処理
        /// </summary>
        public void SyncRealExecWork()
        {
            try
            {
                int status = 0;
                while (true)
                {
                    if (this._worker.StaticFirstSyncDiv == 2)
                    {
                        lock (_syncRealOneThreadLock)
                        {
                            SyncExecWorkDB.DebugLog(this._worker.SyncAuthInfo.EnterpriseCode, "Worker:execute start", "readThread");
                            status = SyncExecRealWorkProc();
                            SyncExecWorkDB.DebugLog(this._worker.SyncAuthInfo.EnterpriseCode, "Worker:execute end.", "readThread");
                        }
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            SyncExecWorkDB.DebugLog(this._worker.SyncAuthInfo.EnterpriseCode, "Worker:wait !", "readThread");
                            this._worker.SyncThreadWait();
                            SyncExecWorkDB.DebugLog(this._worker.SyncAuthInfo.EnterpriseCode, "Worker:wake up! ", "readThread");
                        }
                    }
                    else
                    {
                        SyncExecWorkDB.DebugLog(this._worker.SyncAuthInfo.EnterpriseCode, "Worker:wait !!!!!", "readThread");
                        this._worker.SyncThreadWait();
                        SyncExecWorkDB.DebugLog(this._worker.SyncAuthInfo.EnterpriseCode, "Worker:wake up!!!!!! ", "readThread");
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SyncExecDBWork.SyncRealExecWork Exception=" + ex.Message);
            }
            finally
            {
                SyncExecWorkDB.DebugLog(this._worker.SyncAuthInfo.EnterpriseCode, "Worker is dead.", "readThread");
            }
        }

        /// <summary>
        /// 同期実行スレッド(バッチ)処理
        /// </summary>
        public void SyncBatchExecWork()
        {
            try
            {
                int status = 0;
                while (true)
                {
                    if (this._worker.StaticFirstSyncDiv == 2)
                    {
                        lock (_syncBatchOneThreadLock)
                        {
                            lock (this._worker.SyncExecLock)
                            {
                                status = SyncExecBatchWorkProc();
                            }
                        }
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            this._worker.SyncBatchThreadWait();
                        }
                    }
                    else
                    {
                        this._worker.SyncBatchThreadWait();
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SyncExecDBWork.SyncRealExecWork Exception=" + ex.Message);
            }
        }

        #region Private Protected Method
        /// <summary>
        /// 同期処理(リアル)
        /// </summary>
        /// <returns></returns>
        protected int SyncExecRealWorkProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlReader = null;
            int syncStatus = 3000;
            string syncMessage = "";
            Dictionary<string, SyncMngWork> syncMngDict = new Dictionary<string, SyncMngWork>();
            long transactionId = -1;
            ReplicaDBAccessControl controller = null;
            SyncReqDataWork work1 = null;
            SyncReqDataWork work2 = null;
            SyncReqDataWork work3 = null;
            List<SyncReqDataWork> sendReqDataList = new List<SyncReqDataWork>();
            try
            {
                try
                {
                    // コネクション生成
                    sqlConnection = CreateSqlConnection();
                    if (sqlConnection == null) return status;

                    // トランザクションを開始
                    sqlTransaction = this.CreateTransaction(ref sqlConnection);

                    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                    sqlReader = this.GetSyncRequestReader(sqlConnection, sqlTransaction, sqlCommand, true);
                    if (sqlReader == null)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        return status;
                    }

                    controller = new ReplicaDBAccessControl(this._worker.SyncAuthInfo.ToSyncBasicInfo());
                    while (sqlReader.Read())
                    {
                        work2 = CopyToSyncReqWorkFromReader(ref sqlReader);
                        transactionId = work2.TransctId;
                        if (work2.SyncTargetDiv == 0)
                        {
                            #region 同期(バッチ)　行単位処理
                            work3 = this.ConvertSendData(work1, work2);
                            if (work3 != null)
                            {
                                sendReqDataList.Add(work3);
                                this.UpdateSymcMngWork(syncMngDict, work3);
                            }
                            if (sendReqDataList.Count >= this._worker.XmlSetting.DataSendLimitSize)
                            {
                                if (controller.SyncWrite(transactionId, sendReqDataList, true) != ReplicaDBAccessControl.STATUS_NORMAL)
                                {
                                    syncStatus = ReplicaDBAccessControl.STATUS_ERROR_SENDEND;
                                    break;
                                }
                                sendReqDataList.Clear();
                            }
                            #endregion
                            work1 = work2;
                        }
                        else
                        {
                            #region 同期(バッチ) 表単位処理
                            syncStatus = this.InnerTableSyncProc(controller, syncMngDict, work2, transactionId, true);
                            if (syncStatus != ReplicaDBAccessControl.STATUS_NORMAL)
                            {
                                break;
                            }
                            #endregion
                        }
                    }
                    #region 最後の1つを追加&送信
                    if (work1 != null)
                    {
                        work3 = this.ConvertSendData(work1, null);
                        if (work3 != null)
                        {
                            sendReqDataList.Add(work3);
                            this.UpdateSymcMngWork(syncMngDict, work3);
                        }
                        if (sendReqDataList.Count > 0 && sendReqDataList[0].SyncTargetDiv == 0)
                        {
                            syncStatus = controller.SyncWrite(transactionId, sendReqDataList, true);
                            sendReqDataList.Clear();
                        }
                    }
                    #endregion
                }
                catch (Exception ex2)
                {
                    syncStatus = 3000;
                    syncMessage = ex2.Message;
                    base.WriteErrorLog(ex2, "SyncExecDBWork.SyncExecWorkProc Exception=" + ex2.Message);
                }
                finally
                {
                    if (sqlReader != null && !sqlReader.IsClosed)
                    {
                        sqlReader.Close();
                    }
                }

                #region 結果書き戻し
                if (syncStatus == 0)
                {
                    ArrayList syncMngList = new ArrayList();
                    foreach (SyncMngWork work in syncMngDict.Values)
                    {
                        syncMngList.Add(work);
                    }
                    status = SyncSuccessWorkProc(ref sqlConnection, ref sqlTransaction, this._worker.SyncAuthInfo.EnterpriseCode, transactionId, syncMngList, 0);
                }
                else
                {
                    syncMessage = (controller != null) ? controller.ErrorMessage : syncMessage;
                    status = SyncFailWorkProc(ref sqlConnection, ref sqlTransaction, this._worker.SyncAuthInfo.EnterpriseCode, transactionId, syncStatus, syncMessage, 0);
                }
                #endregion
            }
            catch (SqlException ex)
            {
                try
                {
                    if (sqlTransaction != null) sqlTransaction.Rollback();
                }
                catch
                {
                }
                //基底クラスに例外を渡して処理してもらう
                base.WriteSQLErrorLog(ex);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                try
                {
                    if (sqlTransaction != null) sqlTransaction.Rollback();
                }
                catch
                {
                }
                base.WriteErrorLog(ex, "SyncExecDBWork.SyncExecWorkProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                SyncExecWorkDB.CloseQuietly(sqlReader);
                SyncExecWorkDB.CloseQuietly(sqlCommand);
                SyncExecWorkDB.CommitCloseQuietly(sqlTransaction, status);
                SyncExecWorkDB.CloseQuietly(sqlConnection);
            }
            if (syncStatus != ReplicaDBAccessControl.STATUS_NORMAL)
            {
                Thread.Sleep(this._worker.XmlSetting.RetryIntervalTime * 1000);
            }
            return status;
        }

        /// <summary>
        /// 同期処理(バッチ)
        /// </summary>
        /// <returns></returns>
        protected int SyncExecBatchWorkProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlReader = null;
            int syncStatus = 3000;
            string syncMessage = "";
            long transactionId = 0;
            Dictionary<string, SyncMngWork> syncMngDict = new Dictionary<string, SyncMngWork>();
            List<SyncReqDataWork> sendReqDataList = new List<SyncReqDataWork>();
            ReplicaDBAccessControl controller = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                while (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // トランザクションを開始
                    sqlTransaction = this.CreateTransaction(ref sqlConnection);

                    try
                    {
                        sqlCommand.Parameters.Clear();
                        sqlReader = this.GetSyncRequestReader(sqlConnection, sqlTransaction, sqlCommand, false);
                        if (sqlReader == null)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            continue;
                        }
                        SyncReqDataWork work1 = null;
                        SyncReqDataWork work2 = null;
                        SyncReqDataWork work3 = null;
                        ArrayList responseList = new ArrayList();
                        controller = new ReplicaDBAccessControl(this._worker.SyncAuthInfo.ToSyncBasicInfo());
                        List<SyncReqDataWork> sendWorkList = new List<SyncReqDataWork>();
                        while (sqlReader.Read())
                        {
                            work2 = CopyToSyncReqWorkFromReader(ref sqlReader);
                            transactionId = work2.TransctId;
                            if (work2.SyncTargetDiv == 0)
                            {
                                #region 同期(バッチ)　行単位処理
                                work3 = this.ConvertSendData(work1, work2);
                                if (work3 != null)
                                {
                                    sendReqDataList.Add(work3);
                                    this.UpdateSymcMngWork(syncMngDict, work3);
                                }
                                if (sendReqDataList.Count >= this._worker.XmlSetting.DataSendLimitSize)
                                {
                                    syncStatus = controller.SyncWrite(transactionId, sendReqDataList, false);
                                    if (syncStatus != ReplicaDBAccessControl.STATUS_NORMAL)
                                    {
                                        break;
                                    }
                                    sendReqDataList.Clear();
                                }
                                #endregion
                                work1 = work2;
                            }
                            else
                            {
                                #region 同期(バッチ) 表単位処理
                                syncStatus = this.InnerTableSyncProc(controller, syncMngDict, work2, transactionId, false);
                                if (syncStatus != ReplicaDBAccessControl.STATUS_NORMAL)
                                {
                                    break;
                                }
                                sendReqDataList.Clear();
                                #endregion
                            }
                        }
                        #region 最後の1つを追加&送信
                        if (work1 != null)
                        {
                            work3 = this.ConvertSendData(work1, null);
                            if (work3 != null)
                            {
                                sendReqDataList.Add(work3);
                                this.UpdateSymcMngWork(syncMngDict, work3);
                            }
                            if (sendReqDataList.Count > 0 && sendReqDataList[0].SyncTargetDiv == 0)
                            {
                                syncStatus = controller.SyncWrite(transactionId, sendReqDataList, false);
                                sendReqDataList.Clear();
                            }
                        }
                        #endregion
                    }
                    catch (Exception ex2)
                    {
                        syncStatus = 3000;
                        syncMessage = ex2.Message;
                        base.WriteErrorLog(ex2, "SyncExecDBWork.SyncExecWorkProc Exception=" + ex2.Message);
                    }
                    finally
                    {
                        if (sqlReader != null && !sqlReader.IsClosed)
                        {
                            sqlReader.Close();
                        }
                    }

                    #region 結果書き戻し
                    if (syncStatus == 0)
                    {
                        ArrayList syncMngList = new ArrayList();
                        foreach (SyncMngWork work in syncMngDict.Values)
                        {
                            syncMngList.Add(work);
                        }
                        status = SyncSuccessWorkProc(ref sqlConnection, ref sqlTransaction, this._worker.SyncAuthInfo.EnterpriseCode, transactionId, syncMngList, 1);
                    }
                    else
                    {
                        syncMessage = (controller != null) ? controller.ErrorMessage : syncMessage;
                        status = SyncFailWorkProc(ref sqlConnection, ref sqlTransaction, this._worker.SyncAuthInfo.EnterpriseCode, transactionId, syncStatus, syncMessage, 1);
                    }
                    SyncExecWorkDB.CommitCloseQuietly(sqlTransaction, status);
                    #endregion
                }
            }
            catch (SqlException ex)
            {
                try
                {
                    if (sqlTransaction != null) sqlTransaction.Rollback();
                }
                catch
                {
                }

                //基底クラスに例外を渡して処理してもらう
                base.WriteSQLErrorLog(ex);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                try
                {
                    if (sqlTransaction != null) sqlTransaction.Rollback();
                }
                catch
                {
                }

                base.WriteErrorLog(ex, "SyncExecDBWork.SyncExecWorkProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                SyncExecWorkDB.CloseQuietly(sqlReader);
                SyncExecWorkDB.CloseQuietly(sqlCommand);
                SyncExecWorkDB.CommitCloseQuietly(sqlTransaction, status);
                SyncExecWorkDB.CloseQuietly(sqlConnection);
            }
            if (syncStatus != ReplicaDBAccessControl.STATUS_NORMAL)
            {
                Thread.Sleep(this._worker.XmlSetting.RetryIntervalTime * 1000);
            }
            return status;
        }

        /// <summary>
        /// 表単位の同期出力処理
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="syncMngDict"></param>
        /// <param name="tableIdWork"></param>
        /// <param name="transactionId"></param>
        /// <param name="isReal"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/18</br>
        /// </remarks>
        private int InnerTableSyncProc(ReplicaDBAccessControl controller, Dictionary<string, SyncMngWork> syncMngDict, SyncReqDataWork tableIdWork, long transactionId, bool isReal)
        {
            int status = ReplicaDBAccessControl.STATUS_NORMAL;

            Dictionary<string, ColumnType> columnDict = new Dictionary<string, ColumnType>();
            List<string> keyColumnList = new List<string>();
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlCommand sqlTableReadCommand = null;
            SqlDataReader sqlTableReader = null;
            SyncReqDataWork work = null;
            List<SyncReqDataWork> sendReqDataList = new List<SyncReqDataWork>();
            string tableId;
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
            try
            {
                sqlConnection = this.CreateSqlConnection();
                sqlConnection.Open();
                sqlTransaction = null;
                tableId = this._worker.XmlSetting.GetSyncTableIdFromJsonId(tableIdWork.SyncTableID);
                status = FirstSyncExecThreadDB.LoadDefineSchema(sqlConnection, sqlTransaction, tableId, keyColumnList, columnDict);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
                else if (columnDict.Count == 0)
                {
                    return status;
                }
                sqlTableReadCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                sqlTableReader = FirstSyncExecThreadDB.GetTableReader(sqlConnection, sqlTransaction, sqlTableReadCommand, transactionId, tableId, this._worker.SyncAuthInfo.EnterpriseCode);
                while (sqlTableReader.Read())
                {
                    // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                    //work = FirstSyncExecThreadDB.CopyToSyncReqWorkFromReader(transactionId, tableId, keyColumnList, columnDict, ref sqlTableReader);
                    work = FirstSyncExecThreadDB.CopyToSyncReqWorkFromReader(transactionId, tableId, keyColumnList, columnDict, ref sqlTableReader, convertDoubleRelease);
                    // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
                    work.SyncTableID = tableIdWork.SyncTableID;
                    sendReqDataList.Add(work);
                    this.UpdateSymcMngWork(syncMngDict, work);

                    //分割送信
                    if (sendReqDataList.Count >= this._worker.XmlSetting.DataSendLimitSize)
                    {
                        if (controller.SyncWrite(transactionId, sendReqDataList, isReal) != ReplicaDBAccessControl.STATUS_NORMAL)
                        {
                            status = ReplicaDBAccessControl.STATUS_ERROR_SENDSTART;
                            break;
                        }
                        sendReqDataList.Clear();
                    }
                }
                //分割送信
                if (status == ReplicaDBAccessControl.STATUS_NORMAL && sendReqDataList.Count > 0)
                {
                    if (controller.SyncWrite(transactionId, sendReqDataList, isReal) != ReplicaDBAccessControl.STATUS_NORMAL)
                    {
                        status = ReplicaDBAccessControl.STATUS_ERROR_SENDSTART;
                    }
                    sendReqDataList.Clear();
                }
            }
            finally
            {
                SyncExecWorkDB.CloseQuietly(sqlTableReader);
                SyncExecWorkDB.CloseQuietly(sqlTableReadCommand);
                SyncExecWorkDB.CloseQuietly(sqlConnection);
                // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
            }
            return status;
        }


        /// <summary>
        /// 同期管理マスタ更新
        /// </summary>
        /// <param name="syncMngDict"></param>
        /// <param name="work"></param>
        private void UpdateSymcMngWork(Dictionary<string, SyncMngWork> syncMngDict, SyncReqDataWork work)
        {
            SyncMngWork syncMng = null;
            string tableId = this._worker.XmlSetting.GetSyncTableIdFromJsonId(work.SyncTableID);
            if (syncMngDict.ContainsKey(tableId))
            {
                if (syncMngDict[tableId].LastSyncUpdDtTm < SyncExecWorkDB.DateTimeToYYYYMMDDHHMMSS(work.UpdateDateTime))
                {
                    syncMngDict[tableId].LastSyncUpdDtTm = SyncExecWorkDB.DateTimeToYYYYMMDDHHMMSS(work.UpdateDateTime);
                }
            }
            else
            {
                syncMng = new SyncMngWork();
                syncMng.EnterpriseCode = work.EnterpriseCode;
                syncMng.SyncTableID = tableId;
                syncMng.LastSyncUpdDtTm = SyncExecWorkDB.DateTimeToYYYYMMDDHHMMSS(DateTime.Now);
                syncMng.SyncTableName = this._worker.XmlSetting.GetSyncTableNm(tableId);
                syncMng.LastDataUpdDate = SyncExecWorkDB.DateTimeToYYYYMMDDHHMMSS(work.UpdateDateTime);
                syncMngDict.Add(tableId, syncMng);
            }
        }

        /// <summary>
        /// 同期要求データの取得。
        /// 
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="isReal"></param>
        /// <returns></returns>
        private SqlDataReader GetSyncRequestReader(SqlConnection sqlConnection, SqlTransaction sqlTransaction, SqlCommand sqlCommand, bool isReal)
        {
            const string sqlBeginTextForFirst = " UPDATE SYNCREQDATARF  "
                           + "   SET SYNCEXECRSLTRF=1 "
                           + "   OUTPUT INSERTED.CREATEDATETIMERF,	INSERTED.UPDATEDATETIMERF,	INSERTED.ENTERPRISECODERF,	INSERTED.FILEHEADERGUIDRF,	INSERTED.SYNCREQDIVRF,	INSERTED.TRANSCTIDRF,	INSERTED.SYNCTABLEIDRF,	INSERTED.SYNCTARGETDIVRF,	INSERTED.SYNCPROCDIVRF, INSERTED.SYNCOBJRECKEYITMIDRF,	INSERTED.SYNCOBJRECKEYVALRF,	INSERTED.SYNCOBJRECUPDITMIDRF,	INSERTED.SYNCOBJRECUPDVALRF,	INSERTED.SYNCEXECRSLTRF,	INSERTED.RETRYCOUNTRF,	INSERTED.ERRORSTATUSRF,	INSERTED.ERRORCONTENTSRF "
                           + "   FROM SYNCREQDATARF  AS SUB03 WITH(READUNCOMMITTED) "
                           + "   INNER JOIN ( "
                           + "   SELECT "
                           + "   TOP 1 * "
                           + "   FROM SYNCREQDATARF AS SUB02 WITH(READUNCOMMITTED) "
                           + "   WHERE SUB02.SYNCEXECRSLTRF IN (0,2)  "
                           + "     AND SUB02.SYNCPROCDIVRF = @FINDSYNCPROCDIV "
                           + "     AND SUB02.ENTERPRISECODERF = @FINDENTERPRISECODE "
                           + "   ORDER BY CREATEDATETIMERF,SYNCPROCDIVRF  "
                           + "   ) AS SUB04 ON  "
                           + "   (      SUB04.TRANSCTIDRF > 0  "
                           + "      AND SUB04.TRANSCTIDRF = SUB03.TRANSCTIDRF  "
                           + "      AND SUB04.ENTERPRISECODERF = SUB03.ENTERPRISECODERF "
                           + "      AND SUB04.TRANSCTIDRF = SUB03.TRANSCTIDRF "
                           + "      AND SUB04.SYNCPROCDIVRF = SUB03.SYNCPROCDIVRF  "
                           + "      AND SUB04.SYNCPROCDIVRF = @FINDSYNCPROCDIV  "
                           + "   )  ";
            SqlDataReader reader = null;
            try
            {
                #region 対象データ取得①

                #region パラメータ設定
                //企業コード
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(this._worker.SyncAuthInfo.EnterpriseCode);

                // 最大再試行回数
                SqlParameter paraMaxRetryCount = sqlCommand.Parameters.Add("@FINDMAXRETRYCOUNT", SqlDbType.Int);
                paraMaxRetryCount.Value = SqlDataMediator.SqlSetInt32(this._worker.XmlSetting.MaxRetryCount);

                // 再試行間隔
                SqlParameter paraRetryIntervalTime = sqlCommand.Parameters.Add("@FINDRETRYINTERVALTIME", SqlDbType.BigInt);
                paraRetryIntervalTime.Value = SqlDataMediator.SqlSetInt64(this._worker.XmlSetting.RetryIntervalTime * 1000 * 10000);

                // 同期処理区分 (0:即時、1:バッチ)
                SqlParameter paraSyncProcDiv = sqlCommand.Parameters.Add("@FINDSYNCPROCDIV", SqlDbType.BigInt);
                paraSyncProcDiv.Value = SqlDataMediator.SqlSetInt32((isReal ? 0 : 1));

                // 現在日時
                SqlParameter paraNowDateTime = sqlCommand.Parameters.Add("@FINDNOWDATETIMETICKS", SqlDbType.BigInt);
                paraNowDateTime.Value = SqlDataMediator.SqlSetInt64(DateTime.Now.Ticks);
                #endregion

                sqlCommand.CommandText = sqlBeginTextForFirst;
                sqlCommand.Transaction = sqlTransaction;
                reader = sqlCommand.ExecuteReader();
                //1つめだけで読み込む
                SyncReqDataWork work = null;
                try
                {
                    if (reader.Read())
                    {
                        work = this.CopyToSyncReqWorkFromReader(ref reader);
                    }
                    else
                    {
                        return null;
                    }
                    reader.Close();
                }
                catch
                {
                    //タイムアウトエラーは無視
                    return null;
                }
                #endregion

                #region 最大再試行回数チェック
                if (this._worker.XmlSetting.MaxRetryCount > 0 && work.RetryCount >= this._worker.XmlSetting.MaxRetryCount)
                {
                    return null;
                }
                #endregion

                #region 対象データ取得②
                const string sqlText1 = " SELECT "
                                        + " SUB01.CREATEDATETIMERF, "
                                        + " SUB01.UPDATEDATETIMERF, "
                                        + " SUB01.ENTERPRISECODERF, "
                                        + " SUB01.FILEHEADERGUIDRF, "
                                        + " SUB01.SYNCREQDIVRF, "
                                        + " SUB01.TRANSCTIDRF, "
                                        + " SUB01.SYNCTABLEIDRF, "
                                        + " SUB01.SYNCTARGETDIVRF, "
                                        + " SUB01.SYNCPROCDIVRF, "
                                        + " SUB01.SYNCOBJRECKEYITMIDRF, "
                                        + " SUB01.SYNCOBJRECKEYVALRF, "
                                        + " SUB01.SYNCOBJRECUPDITMIDRF, "
                                        + " SUB01.SYNCOBJRECUPDVALRF, "
                                        + " SUB01.SYNCEXECRSLTRF, "
                                        + " SUB01.RETRYCOUNTRF, "
                                        + " SUB01.ERRORSTATUSRF, "
                                        + " SUB01.ERRORCONTENTSRF "
                                        + " FROM SYNCREQDATARF SUB01 WITH(READUNCOMMITTED) "
                                        + " WHERE  "
                                        + "      SUB01.ENTERPRISECODERF=@FINDENTERPRISECODE "
                                        + "  AND SUB01.TRANSCTIDRF=@FINDTRANSCTID "
                                        + "  AND SUB01.SYNCPROCDIVRF = @FINDSYNCPROCDIV "
                                        + " ORDER BY SYNCTABLEIDRF,SYNCOBJRECKEYVALRF,CREATEDATETIMERF,SYNCREQDIVRF DESC";
                sqlCommand.CommandText = sqlText1;
                sqlCommand.Parameters.Clear();
                //企業コード
                paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(work.EnterpriseCode);

                // 再試行間隔
                SqlParameter paraTransactId = sqlCommand.Parameters.Add("@FINDTRANSCTID", SqlDbType.BigInt);
                paraTransactId.Value = SqlDataMediator.SqlSetInt64(work.TransctId);

                paraSyncProcDiv = sqlCommand.Parameters.Add("@FINDSYNCPROCDIV", SqlDbType.Int);
                paraSyncProcDiv.Value = SqlDataMediator.SqlSetInt32(work.SyncProcDiv);
                #endregion

                return sqlCommand.ExecuteReader();
            }
            finally
            {
                SyncExecWorkDB.CloseQuietly(reader);
            }
        }


        /// <summary>
        /// 同期サーバーへの送信データの変換を行います。
        /// DELETE(work1)+ INSERT(work2)⇒UPDATEへの変換です。
        /// 変換不要な場合は、work1を返します。
        /// 変換が発生した場合は、nullを返します。
        /// </summary>
        /// <param name="work1"></param>
        /// <param name="work2"></param>
        /// <returns></returns>
        private SyncReqDataWork ConvertSendData(SyncReqDataWork work1, SyncReqDataWork work2)
        {
            if (work1 == null)
            {
                return null;
            }
            else if (work2 == null)
            {
                return work1;
            }

            if (work1.SyncTableID != work2.SyncTableID)
            {
                return work1;
            }
            if (work1.SyncObjRecKeyVal != work2.SyncObjRecKeyVal)
            {
                return work1;
            }
            if (work1.SyncReqDiv == 2 && work2.SyncReqDiv == 0)
            {
                work2.SyncReqDiv = 1;
                return null;
            }
            return work1;
        }

        /// <summary>
        /// 同期処理成功処理
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="transactionId"></param>
        /// <param name="dbSyncMngList"></param>
        /// <param name="syncProcDiv"></param>
        /// <returns></returns>
        private int SyncSuccessWorkProc(ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, string enterpriseCode, long transactionId, ArrayList dbSyncMngList, int syncProcDiv)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            const string deleteSyncDataSql = "DELETE FROM SYNCREQDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TRANSCTIDRF=@FINDTRANSCTID AND SYNCPROCDIVRF = @FINDSYNCPROCDIV ";
            try
            {
                #region 同期要求データの削除
                sqlCommand = new SqlCommand(deleteSyncDataSql, sqlConnection, sqlTransaction);

                #region パラメータ設定
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaTransctId = sqlCommand.Parameters.Add("@FINDTRANSCTID", SqlDbType.BigInt);
                SqlParameter findParaSyncProcDiv = sqlCommand.Parameters.Add("@FINDSYNCPROCDIV", SqlDbType.Int);

                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaTransctId.Value = SqlDataMediator.SqlSetInt64(transactionId);
                findParaSyncProcDiv.Value = SqlDataMediator.SqlSetInt32(syncProcDiv);

                #endregion

                sqlCommand.ExecuteNonQuery();
                #endregion

                #region 同期管理マスタの更新
                // 同期管理マスタ更新
                status = this._worker.WorkerSynchConfirmDB.WriteSyncMngData(ref dbSyncMngList, ref sqlConnection, ref sqlTransaction);
                #endregion
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 同期処理失敗処理
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="transactionId"></param>
        /// <param name="errorStatus"></param>
        /// <param name="errorContents"></param>
        /// <param name="syncProcDiv"></param>
        /// <returns></returns>
        private int SyncFailWorkProc(ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, string enterpriseCode, long transactionId, int errorStatus, string errorContents, int syncProcDiv)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            const string updateSyncDataSql = " UPDATE SYNCREQDATARF "
                                           + "    SET SYNCEXECRSLTRF=2, "
                                           + " RETRYCOUNTRF=RETRYCOUNTRF+1, "
                                           + " ERRORSTATUSRF=@ERRORSTATUS, "
                                           + " ERRORCONTENTSRF=@ERRORCONTENTS "
                                           + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TRANSCTIDRF=@FINDTRANSCTID AND SYNCPROCDIVRF = @FINDSYNCPROCDIV ";
            try
            {
                #region 同期要求データの削除
                sqlCommand = new SqlCommand(updateSyncDataSql, sqlConnection, sqlTransaction);

                #region パラメータ設定
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaTransctId = sqlCommand.Parameters.Add("@FINDTRANSCTID", SqlDbType.BigInt);
                SqlParameter findParaSyncProcDiv = sqlCommand.Parameters.Add("@FINDSYNCPROCDIV", SqlDbType.Int);
                SqlParameter paraErrorStatus = sqlCommand.Parameters.Add("@ERRORSTATUS", SqlDbType.Int);
                SqlParameter paraErrorContents = sqlCommand.Parameters.Add("@ERRORCONTENTS", SqlDbType.NVarChar);

                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaTransctId.Value = SqlDataMediator.SqlSetInt64(transactionId);
                findParaSyncProcDiv.Value = SqlDataMediator.SqlSetInt32(syncProcDiv);
                paraErrorStatus.Value = SqlDataMediator.SqlSetInt32(errorStatus);
                paraErrorContents.Value = SqlDataMediator.SqlSetString(errorContents);
                #endregion

                sqlCommand.ExecuteNonQuery();
                #endregion

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            finally
            {
                SyncExecWorkDB.CloseQuietly(sqlCommand);
            }
            return status;
        }

        private void UpdateSyncMngWork(ref Dictionary<string, SyncMngWork> syncMngDict, SyncReqDataWork reqData)
        {
            SyncMngWork syncMng;
            if (syncMngDict.ContainsKey(reqData.SyncTableID))
            {
                syncMng = syncMngDict[reqData.SyncTableID];
            }
            else
            {
                syncMng = new SyncMngWork();
                syncMng.EnterpriseCode = reqData.EnterpriseCode;
                syncMng.SyncTableID = reqData.SyncTableID;
                syncMng.LogicalDeleteCode = 0;
                syncMng.SyncTableName = this._worker.XmlSetting.GetSyncTableNm(reqData.SyncTableID);
                syncMng.LastDataUpdDate = 0;
                syncMngDict.Add(reqData.SyncTableID, syncMng);
            }

            #region データ同期管理マスタ情報初期セット
            syncMng.LastSyncUpdDtTm = SyncExecWorkDB.DateTimeToYYYYMMDDHHMMSS(DateTime.Now);
            if (syncMng.LastDataUpdDate < reqData.UpdateDateTime.Ticks)
            {
                syncMng.LastDataUpdDate = reqData.UpdateDateTime.Ticks;
            }
            #endregion
        }

        /// <summary>
        /// 検索結果の格納
        /// </summary>
        /// <param name="myReader">sqlDataReader</param>
        /// <returns>SyncReqDataWork</returns>
        /// <remarks>
        /// <br>Note       : 同期要求データの格納処理を行う。</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        private SyncReqDataWork CopyToSyncReqWorkFromReader(ref SqlDataReader myReader)
        {
            SyncReqDataWork syncReqWork = new SyncReqDataWork();

            # region クラスへ格納
            syncReqWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            syncReqWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            syncReqWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            syncReqWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            syncReqWork.SyncReqDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYNCREQDIVRF"));
            syncReqWork.TransctId = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TRANSCTIDRF"));
            syncReqWork.SyncTableID = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SYNCTABLEIDRF"));
            syncReqWork.SyncObjRecKeyItmId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SYNCOBJRECKEYITMIDRF"));
            syncReqWork.SyncObjRecKeyVal = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SYNCOBJRECKEYVALRF"));
            syncReqWork.SyncObjRecUpdItmId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SYNCOBJRECUPDITMIDRF"));
            syncReqWork.SyncObjRecUpdVal = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SYNCOBJRECUPDVALRF"));
            syncReqWork.SyncExecRslt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYNCEXECRSLTRF"));
            syncReqWork.SyncProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYNCPROCDIVRF"));
            syncReqWork.SyncTargetDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYNCTARGETDIVRF"));
            syncReqWork.RetryCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETRYCOUNTRF"));
            syncReqWork.ErrorStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERRORSTATUSRF"));
            syncReqWork.ErrorContents = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ERRORCONTENTSRF"));
            #endregion

            #region テーブルID変換
            string tableId2 = this._worker.XmlSetting.GetSyncTableJsonId(syncReqWork.SyncTableID);
            if (!string.IsNullOrEmpty(tableId2))
            {
                syncReqWork.SyncTableID = tableId2;
            }
            #endregion
            return syncReqWork;
        }

        /// <summary>
        /// SqlConnectionオブジェクトを生成します。
        /// </summary>
        /// <returns>SqlConnectionオブジェクト、もしくはnull</returns>
        /// <remarks>
        /// <br>Programmer : 松本宏紀</br>
        /// <br>Date       : 2014/08/25</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            string connectionText = this._worker.SyncAuthInfo.UserDbConnectionText;
            if (string.IsNullOrEmpty(connectionText))
            {
                return null;
            }
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }
        #endregion
    }
}
