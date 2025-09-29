//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   同期実行管理 リモートオブジェクト
//                  :   PMSCM00210R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   田建委
// Date             :   2014/08/01
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

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 同期実行スレッド(即時)のオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 同期実行スレッド(即時)のオブジェクト</br>
    /// <br>Programmer : 松本 宏紀</br>
    /// <br>Date       : 2014/08/07</br>
    /// </remarks>
    public class SyncWatchThreadDB : RemoteWithAppLockDB
    {
        private static object _syncOneThreadLock = new object();

        private SyncExecWorkDB _worker;

        /// <summary>
        /// 同期実行スレッド(即時)のコンストラクタ
        /// </summary>
        public SyncWatchThreadDB(SyncExecWorkDB worker)
        {
            this._worker = worker;
        }

        /// <summary>
        /// 定期監視スレッド処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 定期監視スレッド処理を行う。</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        public void RegularWatchOnWork()
        {
            ReplicaDBAccessControl controller = null;
            BlSyncControlRequest req = new BlSyncControlRequest();
            BlSyncControlResponse res = null;
            while (true)
            {
                try
                {
                    this._worker.UpdateSyncMonitMngData();

                    if (this._worker.IsValidWachWorker)
                    {
                        lock (_syncOneThreadLock)
                        {
                            req.EnterpriseCode = this._worker.SyncAuthInfo.EnterpriseCode;
                            req.PmDbID = this._worker.SyncAuthInfo.PmDbId;
                            req.TransactionID = 0;

                            controller = new ReplicaDBAccessControl(this._worker.SyncAuthInfo.ToSyncBasicInfo());
                            try
                            {
                                res = controller.GetSyncControlInfo(req);
                            }
                            catch
                            {
                                res = null;
                            }
                            if (res != null && (res.Status == 0 || res.Status == 200))
                            {
                                this._worker.SyncWorkInfo.DataCheckInterval = res.DataCheckInterval;
                                if (res.FirstSyncDuration != null)
                                {
                                    this._worker.SyncWorkInfo.FirstSyncDate = res.FirstSyncDuration.Date;
                                    this._worker.SyncWorkInfo.FirstSyncStartTime = res.FirstSyncDuration.StartTime;
                                    this._worker.SyncWorkInfo.FirsySyncEndTime = res.FirstSyncDuration.EndTime;

                                    //同期済みでないなら、初回同期スレッドを起動させる。
                                    if (this._worker.StaticFirstSyncDiv < 2 && this._worker.SyncWorkInfo.CheckFirstSyncExecTime())
                                    {
                                        if (this._worker.StaticFirstSyncDiv == 0)
                                        {
                                            InitializeFirsySync();
                                        }
                                        this._worker.FirstSyncThreadWakeUp();
                                    }
                                    else if (this._worker.StaticFirstSyncDiv == 2)
                                    {
                                        this._worker.SyncThreadWakeUp();
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    base.WriteErrorLog(e, "RegularWatchOnWork:" + e.Message);
                }
                finally
                {
                    Thread.Sleep(this._worker.XmlSetting.WatchOnReplicaDBIntervalTime * 1000);
                }
            }
        }

        /// <summary>
        /// 変換処理実施。
        /// </summary>
        public void TranslateStart()
        {
            while (true)
            {
                this._worker.TranslateThreadWait();
                try
                {
                    //★かならず1つしか実行させない！
                    lock (_syncOneThreadLock)
                    {
                        if (this._worker.StaticFirstSyncDiv == 2 || this.CheckFirstSyncFinished())
                        {
                            ReplicaDBAccessControl controller = new ReplicaDBAccessControl(this._worker.SyncAuthInfo.ToSyncBasicInfo());
                            int syncStatus = 0;
                            lock (this._worker.SyncExecLock)
                            {
                                syncStatus = controller.TranslateStart();
                            }
                            if (syncStatus != 0)
                            {
                                base.WriteErrorLog("TranslateStart:変換処理失敗 ST=" + syncStatus);
                            }
                            else if (this._worker.StaticFirstSyncDiv != 2)
                            {
                                SyncSuccessWorkProc();
                                this._worker.UpdateStaticFirstSyncDiv();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    base.WriteErrorLog(e, "TranslateStart:" + e.Message);
                }
            }
        }

        /// <summary>
        /// 同期管理マスタに保留データの更新、及び同期要求データの作成。
        /// </summary>
        /// <returns></returns>
        private int InitializeFirsySync()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            List<SyncTableInfo> syncTableList = this._worker.XmlSetting.TablesInfoList;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlReader = null;
            const string checkSqlText1 = "SELECT SYNCTABLEIDRF FROM SYNCREQDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SYNCTARGETDIVRF=2 ";
            const string checkSqlText2 = "SELECT SYNCTABLEIDRF FROM SYNCMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
            ArrayList syncMngList = new ArrayList();
            try
            {
                lock (_syncOneThreadLock)
                {
                    sqlConnection = this.CreateSqlConnection();
                    sqlConnection.Open();
                    sqlTransaction = this.CreateTransaction(ref sqlConnection);
                    {
                        #region 書き込みチェック(同期要求データ)
                        sqlCommand = new SqlCommand(checkSqlText1, sqlConnection, sqlTransaction);
                        #region パラメータ設定
                        sqlCommand.Parameters.Clear();
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(this._worker.SyncAuthInfo.EnterpriseCode);
                        #endregion
                        sqlReader = sqlCommand.ExecuteReader();
                        if (sqlReader.Read())
                        {
                            //既に初回同期要求が存在する。
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }
                        sqlReader.Close();
                        #endregion

                        #region 書き込みチェック(同期要求データ)
                        sqlCommand.CommandText = checkSqlText2;
                        #region パラメータ設定
                        sqlCommand.Parameters.Clear();
                        paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(this._worker.SyncAuthInfo.EnterpriseCode);
                        #endregion
                        sqlReader = sqlCommand.ExecuteReader();
                        if (sqlReader.Read())
                        {
                            //既に初回同期要求が存在する。
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }
                        sqlReader.Close();
                        #endregion
                    }
                    {
                        #region 同期要求データ作成
                        sqlCommand.Parameters.Clear();
                        sqlCommand.CommandText = "INSERT INTO SYNCREQDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, SYNCREQDIVRF, TRANSCTIDRF, SYNCTABLEIDRF, SYNCTARGETDIVRF, SYNCPROCDIVRF, SYNCOBJRECKEYITMIDRF, SYNCOBJRECKEYVALRF, SYNCOBJRECUPDITMIDRF, SYNCOBJRECUPDVALRF, SYNCEXECRSLTRF, RETRYCOUNTRF, ERRORSTATUSRF, ERRORCONTENTSRF) VALUES (@CREATEDATETIME ,@UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @SYNCREQDIV, @TRANSCTID, @SYNCTABLEID, @SYNCTARGETDIV, @SYNCPROCDIV, @SYNCOBJRECKEYITMID, @SYNCOBJRECKEYVAL, @SYNCOBJRECUPDITMID, @SYNCOBJRECUPDVAL, @SYNCEXECRSLT, @RETRYCOUNT, @ERRORSTATUS, @ERRORCONTENTS) ";
                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraSyncReqDiv = sqlCommand.Parameters.Add("@SYNCREQDIV", SqlDbType.Int);
                        SqlParameter paraTransctId = sqlCommand.Parameters.Add("@TRANSCTID", SqlDbType.BigInt);
                        SqlParameter paraSyncTableID = sqlCommand.Parameters.Add("@SYNCTABLEID", SqlDbType.NVarChar);
                        SqlParameter paraSyncTargetDiv = sqlCommand.Parameters.Add("@SYNCTARGETDIV", SqlDbType.Int);
                        SqlParameter paraSyncProcDiv = sqlCommand.Parameters.Add("@SYNCPROCDIV", SqlDbType.Int);
                        SqlParameter paraSyncObjRecKeyItmId = sqlCommand.Parameters.Add("@SYNCOBJRECKEYITMID", SqlDbType.NVarChar);
                        SqlParameter paraSyncObjRecKeyVal = sqlCommand.Parameters.Add("@SYNCOBJRECKEYVAL", SqlDbType.NVarChar);
                        SqlParameter paraSyncObjRecUpdItmId = sqlCommand.Parameters.Add("@SYNCOBJRECUPDITMID", SqlDbType.NVarChar);
                        SqlParameter paraSyncObjRecUpdVal = sqlCommand.Parameters.Add("@SYNCOBJRECUPDVAL", SqlDbType.NVarChar);
                        SqlParameter paraSyncExecRslt = sqlCommand.Parameters.Add("@SYNCEXECRSLT", SqlDbType.Int);
                        SqlParameter paraRetryCount = sqlCommand.Parameters.Add("@RETRYCOUNT", SqlDbType.Int);
                        SqlParameter paraErrorStatus = sqlCommand.Parameters.Add("@ERRORSTATUS", SqlDbType.Int);
                        SqlParameter paraErrorContents = sqlCommand.Parameters.Add("@ERRORCONTENTS", SqlDbType.NVarChar);
                        #endregion

                        //登録ヘッダ情報を設定
                        DateTime now = DateTime.Now;
                        foreach (SyncTableInfo tableInfo in syncTableList)
                        {
                            #region Parameterオブジェクトへ値設定(更新用)
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(now);
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(now);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(this._worker.SyncAuthInfo.EnterpriseCode);
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(Guid.NewGuid());
                            paraSyncReqDiv.Value = SqlDataMediator.SqlSetInt32(0);
                            paraTransctId.Value = SqlDataMediator.SqlSetInt64(this._worker.GetTransactionId(sqlConnection, sqlTransaction));
                            paraSyncTableID.Value = SqlDataMediator.SqlSetString(tableInfo.SyncTableId);
                            paraSyncTargetDiv.Value = SqlDataMediator.SqlSetInt32(2);
                            paraSyncProcDiv.Value = SqlDataMediator.SqlSetInt32(1);
                            paraSyncObjRecKeyItmId.Value = SqlDataMediator.SqlSetString(null);
                            paraSyncObjRecKeyVal.Value = SqlDataMediator.SqlSetString(null);
                            paraSyncObjRecUpdItmId.Value = SqlDataMediator.SqlSetString(null);
                            paraSyncObjRecUpdVal.Value = SqlDataMediator.SqlSetString(null);
                            paraSyncExecRslt.Value = SqlDataMediator.SqlSetInt32(0);
                            paraRetryCount.Value = SqlDataMediator.SqlSetInt32(0);
                            paraErrorStatus.Value = SqlDataMediator.SqlSetInt32(0);
                            paraErrorContents.Value = SqlDataMediator.SqlSetString(null);
                            #endregion
                            sqlCommand.ExecuteNonQuery();
                        }
                        #endregion
                    }
                    {
                        #region 同期管理マスタ更新
                        sqlCommand.Parameters.Clear();
                        sqlCommand.CommandText = "INSERT INTO SYNCMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SYNCTABLEIDRF, SYNCTABLENAMERF, LASTSYNCUPDDTTMRF, LASTDATAUPDDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SYNCTABLEID, @SYNCTABLENAME, @LASTSYNCUPDDTTM, @LASTDATAUPDDATE) ";
                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSyncTableID = sqlCommand.Parameters.Add("@SYNCTABLEID", SqlDbType.NVarChar);
                        SqlParameter paraSyncTableName = sqlCommand.Parameters.Add("@SYNCTABLENAME", SqlDbType.NVarChar);
                        SqlParameter paraLastSyncUpdDtTm = sqlCommand.Parameters.Add("@LASTSYNCUPDDTTM", SqlDbType.BigInt);
                        SqlParameter paraLastDataUpdDate = sqlCommand.Parameters.Add("@LASTDATAUPDDATE", SqlDbType.BigInt);
                        #endregion

                        //登録ヘッダ情報を設定
                        DateTime now = DateTime.Now;
                        foreach (SyncTableInfo tableInfo in syncTableList)
                        {
                            #region Parameterオブジェクトへ値設定(更新用)
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(now);
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(now);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(this._worker.SyncAuthInfo.EnterpriseCode);
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(Guid.NewGuid());
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString("Admin");
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString("PMSCM00210R");
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString("PMSCM00210R");
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(2);
                            paraSyncTableID.Value = SqlDataMediator.SqlSetString(tableInfo.SyncTableId);
                            paraSyncTableName.Value = SqlDataMediator.SqlSetString(tableInfo.SyncTableNm);
                            paraLastSyncUpdDtTm.Value = SqlDataMediator.SqlSetInt64(0);
                            paraLastDataUpdDate.Value = SqlDataMediator.SqlSetInt64(0);
                            #endregion
                            sqlCommand.ExecuteNonQuery();
                        }
                        #endregion
                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                return status;
            }
            finally
            {
                SyncExecWorkDB.CloseQuietly(sqlReader);
                SyncExecWorkDB.CloseQuietly(sqlCommand);
                SyncExecWorkDB.CommitCloseQuietly(sqlTransaction, status);
                SyncExecWorkDB.CloseQuietly(sqlConnection);
            }
        }


        /// <summary>
        /// 同期管理マスタに保留データの更新、及び同期要求データの作成。
        /// </summary>
        /// <returns></returns>
        private bool CheckFirstSyncFinished()
        {
            List<SyncTableInfo> syncTableList = this._worker.XmlSetting.TablesInfoList;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlReader = null;
            const string checkSqlText1 = "SELECT TOP 1 SYNCTABLEIDRF FROM SYNCREQDATARF WITH(READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SYNCTARGETDIVRF=2 ";
            const string checkSqlText2 = "SELECT TOP 1 SYNCTABLEIDRF FROM SYNCMNGRF WITH(READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
            ArrayList syncMngList = new ArrayList();
            try
            {
                    sqlConnection = this.CreateSqlConnection();
                    sqlConnection.Open();

                    sqlCommand = new SqlCommand(checkSqlText1, sqlConnection);
                    #region パラメータ設定
                    sqlCommand.Parameters.Clear();
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(this._worker.SyncAuthInfo.EnterpriseCode);
                    #endregion
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.Read())
                    {
                        //既に初回同期要求が存在する。
                        return false;
                    }
                    sqlReader.Close();
                    sqlReader.Dispose();

                    sqlCommand.CommandText = checkSqlText2;
                    #region パラメータ設定
                    sqlCommand.Parameters.Clear();
                    paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(this._worker.SyncAuthInfo.EnterpriseCode);
                    #endregion
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.Read())
                    {
                        //初回同期が開始されている
                        return true;
                    }

                    return false;
            }
            finally
            {
                SyncExecWorkDB.CloseQuietly(sqlReader);
                SyncExecWorkDB.CloseQuietly(sqlCommand);
                SyncExecWorkDB.CloseQuietly(sqlConnection);
            }
        }


        /// <summary>
        /// 同期処理成功処理。
        /// </summary>
        /// <returns></returns>
        private int SyncSuccessWorkProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            const string deleteSyncDataSql = "UPDATE SYNCMNGRF SET LOGICALDELETECODERF=0 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF > 0";
            try
            {
                sqlConnection = this.CreateSqlConnection();
                sqlConnection.Open();
                sqlTransaction = this.CreateTransaction(ref sqlConnection);
                #region 同期要求データの削除
                sqlCommand = new SqlCommand(deleteSyncDataSql, sqlConnection, sqlTransaction);

                #region パラメータ設定
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(this._worker.SyncAuthInfo.EnterpriseCode);
                #endregion

                sqlCommand.ExecuteNonQuery();
                #endregion
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            finally
            {
                SyncExecWorkDB.CloseQuietly(sqlCommand);
                SyncExecWorkDB.CommitCloseQuietly(sqlTransaction, status);
                SyncExecWorkDB.CloseQuietly(sqlConnection);
            }
            return status;
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
    }
}
