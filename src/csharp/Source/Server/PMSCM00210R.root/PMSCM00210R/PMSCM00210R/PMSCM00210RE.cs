//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �������s�Ǘ� �����[�g�I�u�W�F�N�g
//                  :   PMSCM00210R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   �c����
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
    /// �������s�X���b�h(����)�̃I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������s�X���b�h(����)�̃I�u�W�F�N�g</br>
    /// <br>Programmer : ���{ �G�I</br>
    /// <br>Date       : 2014/08/07</br>
    /// </remarks>
    public class SyncWatchThreadDB : RemoteWithAppLockDB
    {
        private static object _syncOneThreadLock = new object();

        private SyncExecWorkDB _worker;

        /// <summary>
        /// �������s�X���b�h(����)�̃R���X�g���N�^
        /// </summary>
        public SyncWatchThreadDB(SyncExecWorkDB worker)
        {
            this._worker = worker;
        }

        /// <summary>
        /// ����Ď��X���b�h����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����Ď��X���b�h�������s���B</br>
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

                                    //�����ς݂łȂ��Ȃ�A���񓯊��X���b�h���N��������B
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
        /// �ϊ��������{�B
        /// </summary>
        public void TranslateStart()
        {
            while (true)
            {
                this._worker.TranslateThreadWait();
                try
                {
                    //�����Ȃ炸1�������s�����Ȃ��I
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
                                base.WriteErrorLog("TranslateStart:�ϊ��������s ST=" + syncStatus);
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
        /// �����Ǘ��}�X�^�ɕۗ��f�[�^�̍X�V�A�y�ѓ����v���f�[�^�̍쐬�B
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
                        #region �������݃`�F�b�N(�����v���f�[�^)
                        sqlCommand = new SqlCommand(checkSqlText1, sqlConnection, sqlTransaction);
                        #region �p�����[�^�ݒ�
                        sqlCommand.Parameters.Clear();
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(this._worker.SyncAuthInfo.EnterpriseCode);
                        #endregion
                        sqlReader = sqlCommand.ExecuteReader();
                        if (sqlReader.Read())
                        {
                            //���ɏ��񓯊��v�������݂���B
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }
                        sqlReader.Close();
                        #endregion

                        #region �������݃`�F�b�N(�����v���f�[�^)
                        sqlCommand.CommandText = checkSqlText2;
                        #region �p�����[�^�ݒ�
                        sqlCommand.Parameters.Clear();
                        paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(this._worker.SyncAuthInfo.EnterpriseCode);
                        #endregion
                        sqlReader = sqlCommand.ExecuteReader();
                        if (sqlReader.Read())
                        {
                            //���ɏ��񓯊��v�������݂���B
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }
                        sqlReader.Close();
                        #endregion
                    }
                    {
                        #region �����v���f�[�^�쐬
                        sqlCommand.Parameters.Clear();
                        sqlCommand.CommandText = "INSERT INTO SYNCREQDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, SYNCREQDIVRF, TRANSCTIDRF, SYNCTABLEIDRF, SYNCTARGETDIVRF, SYNCPROCDIVRF, SYNCOBJRECKEYITMIDRF, SYNCOBJRECKEYVALRF, SYNCOBJRECUPDITMIDRF, SYNCOBJRECUPDVALRF, SYNCEXECRSLTRF, RETRYCOUNTRF, ERRORSTATUSRF, ERRORCONTENTSRF) VALUES (@CREATEDATETIME ,@UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @SYNCREQDIV, @TRANSCTID, @SYNCTABLEID, @SYNCTARGETDIV, @SYNCPROCDIV, @SYNCOBJRECKEYITMID, @SYNCOBJRECKEYVAL, @SYNCOBJRECUPDITMID, @SYNCOBJRECUPDVAL, @SYNCEXECRSLT, @RETRYCOUNT, @ERRORSTATUS, @ERRORCONTENTS) ";
                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
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

                        //�o�^�w�b�_����ݒ�
                        DateTime now = DateTime.Now;
                        foreach (SyncTableInfo tableInfo in syncTableList)
                        {
                            #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
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
                        #region �����Ǘ��}�X�^�X�V
                        sqlCommand.Parameters.Clear();
                        sqlCommand.CommandText = "INSERT INTO SYNCMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SYNCTABLEIDRF, SYNCTABLENAMERF, LASTSYNCUPDDTTMRF, LASTDATAUPDDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SYNCTABLEID, @SYNCTABLENAME, @LASTSYNCUPDDTTM, @LASTDATAUPDDATE) ";
                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
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

                        //�o�^�w�b�_����ݒ�
                        DateTime now = DateTime.Now;
                        foreach (SyncTableInfo tableInfo in syncTableList)
                        {
                            #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
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
        /// �����Ǘ��}�X�^�ɕۗ��f�[�^�̍X�V�A�y�ѓ����v���f�[�^�̍쐬�B
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
                    #region �p�����[�^�ݒ�
                    sqlCommand.Parameters.Clear();
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(this._worker.SyncAuthInfo.EnterpriseCode);
                    #endregion
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.Read())
                    {
                        //���ɏ��񓯊��v�������݂���B
                        return false;
                    }
                    sqlReader.Close();
                    sqlReader.Dispose();

                    sqlCommand.CommandText = checkSqlText2;
                    #region �p�����[�^�ݒ�
                    sqlCommand.Parameters.Clear();
                    paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(this._worker.SyncAuthInfo.EnterpriseCode);
                    #endregion
                    sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.Read())
                    {
                        //���񓯊����J�n����Ă���
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
        /// �����������������B
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
                #region �����v���f�[�^�̍폜
                sqlCommand = new SqlCommand(deleteSyncDataSql, sqlConnection, sqlTransaction);

                #region �p�����[�^�ݒ�
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
        /// �������ʂ̊i�[
        /// </summary>
        /// <param name="myReader">sqlDataReader</param>
        /// <returns>SyncReqDataWork</returns>
        /// <remarks>
        /// <br>Note       : �����v���f�[�^�̊i�[�������s���B</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        private SyncReqDataWork CopyToSyncReqWorkFromReader(ref SqlDataReader myReader)
        {
            SyncReqDataWork syncReqWork = new SyncReqDataWork();
            # region �N���X�֊i�[
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
        /// SqlConnection�I�u�W�F�N�g�𐶐����܂��B
        /// </summary>
        /// <returns>SqlConnection�I�u�W�F�N�g�A��������null</returns>
        /// <remarks>
        /// <br>Programmer : ���{�G�I</br>
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
