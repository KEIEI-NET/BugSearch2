//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �����󋵊m�F �����[�g�I�u�W�F�N�g
//                  :   PMSCM04112R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   �c����
// Date             :   2014/08/01
//----------------------------------------------------------------------
// Update Note      : 
//----------------------------------------------------------------------
// �Ǘ��ԍ�  11070136-00  �쐬�S�� : �c����
// �� �� ��  2014/08/01   �C�����e : �V�K�쐬
//----------------------------------------------------------------------
// �Ǘ��ԍ�  11070136-00  �쐬�S�� : �c����
// �� �� ��  2014/09/03   �C�����e : Redmine#43408
//                                   �X�e�[�^�X��2�A�܂�MaxErrorCount�܂œ��B���Ă��Ȃ����̂��擾����Ή�
//----------------------------------------------------------------------
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.SqlServer.Server;
using Microsoft.Win32;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;

using System.Runtime.Remoting.Lifetime;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����󋵊m�F �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����󋵊m�F���f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2014/08/01</br>
    /// <br>Update Note: 2014/09/03 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11070136-00 Redmine#43408</br>
    /// <br>           : �X�e�[�^�X��2�A�܂�MaxErrorCount�܂œ��B���Ă��Ȃ����̂��擾����Ή�</br>
    /// </remarks>
    [Serializable]
    public class SynchConfirmDB : RemoteWithAppLockDB, ISynchConfirmDB
    {

        #region [ Constructor]
        /// <summary>
        /// �����󋵊m�FDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public SynchConfirmDB()
        {
        }

        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Note       : SqlConnection��������</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
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

        #region [�����Ǘ��}�X�^�@�����E�X�V]

        #region �����񓯊����{�L�����菈��
        /// <summary>
        /// ���񓯊����{�L�����菈��
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �����Ǘ��}�X�^���Q�Ƃ��A���R�[�h��1���ł�����΁A�����ς݂Ɣ��f���܂�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public bool SyncMngDataExists()
        {
            bool isSyncMngDataExists = false;

            SqlConnection sqlConnection = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return isSyncMngDataExists;
                sqlConnection.Open();

                isSyncMngDataExists = SyncMngDataExistsProc(ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SynchConfirmDB.SearchSyncMngData SyncMngDataExists=" + ex.Message);
                isSyncMngDataExists = false;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return isSyncMngDataExists;
        }

        /// <summary>
        /// ���񓯊����{�L�����菈��
        /// </summary>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �����Ǘ��}�X�^���Q�Ƃ��A���R�[�h��1���ł�����΁A�����ς݂Ɣ��f���܂�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private bool SyncMngDataExistsProc(ref SqlConnection sqlConnection)
        {
            bool isSyncMngDataExists = false;

            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlText = "";
                sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SYNCTABLEIDRF, SYNCTABLENAMERF, LASTSYNCUPDDTTMRF, LASTDATAUPDDATERF FROM SYNCMNGRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";

                //��ƃR�[�h
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();
                string enterpriseCode = loginInfo.EnterpriseCode;
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // �_���폜�敪
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)0);

                sqlCommand.CommandText = sqlText.ToString();

                sqlCommand.CommandTimeout = 600;
                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    isSyncMngDataExists = true;
                }
            }
            catch (SqlException e)
            {
                base.WriteErrorLog(e, "SynchConfirmDB.SyncMngDataExistsProc Exception=" + e.Message);
                isSyncMngDataExists = false;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SynchConfirmDB.SyncMngDataExistsProc Exception=" + ex.Message);
                isSyncMngDataExists = false;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!sqlDataReader.IsClosed) sqlDataReader.Close();
            }

            return isSyncMngDataExists;
        }
        #endregion

        #region �������Ǘ��}�X�^�̌���
        /// <summary>
        /// �����Ǘ��}�X�^�̌���
        /// </summary>
        /// <param name="syncMngResultData">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="param">��������</param>
        /// <param name="logicalMode">�_���폜�R�[�h</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����Ǘ��}�X�^�̌������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int SearchSyncMngData(out object syncMngResultData, out string errMessage, object param, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMessage = string.Empty;
            syncMngResultData = null;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SyncMngWork syncMngWork = param as SyncMngWork;

                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = SearchSyncMngDataProc(out syncMngResultData, out errMessage, syncMngWork, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                base.WriteErrorLog(ex, "SynchConfirmDB.SearchSyncMngData Exception=" + ex.Message);
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
                            //�R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //���[���o�b�N
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
        /// �����Ǘ��}�X�^�̌���(sqlConnection�AsqlTransaction�t��)
        /// </summary>
        /// <param name="syncMngResultData">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="syncMngWork">��������</param>
        /// <param name="logicalMode">�_���폜�R�[�h</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����Ǘ��}�X�^�̌������s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int SearchSyncMngData(out object syncMngResultData, out string errMessage, SyncMngWork syncMngWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            errMessage = string.Empty;
            syncMngResultData = null;

            return SearchSyncMngDataProc(out syncMngResultData, out errMessage, syncMngWork, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �����Ǘ��}�X�^�̌���
        /// </summary>
        /// <param name="syncMngResultData">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="syncMngWork">��������</param>
        /// <param name="logicalMode">�_���폜�R�[�h</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����Ǘ��}�X�^�̌������s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private int SearchSyncMngDataProc(out object syncMngResultData, out string errMessage, SyncMngWork syncMngWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMessage = null;
            syncMngResultData = null;
            ArrayList al = new ArrayList(); // ���o����

            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                sqlText.Append(" SELECT ").Append(Environment.NewLine);
                sqlText.Append("   CREATEDATETIMERF ").Append(Environment.NewLine);
                sqlText.Append("   ,UPDATEDATETIMERF ").Append(Environment.NewLine);
                sqlText.Append("   ,ENTERPRISECODERF ").Append(Environment.NewLine);
                sqlText.Append("   ,FILEHEADERGUIDRF ").Append(Environment.NewLine);
                sqlText.Append("   ,UPDEMPLOYEECODERF ").Append(Environment.NewLine);
                sqlText.Append("   ,UPDASSEMBLYID1RF ").Append(Environment.NewLine);
                sqlText.Append("   ,UPDASSEMBLYID2RF ").Append(Environment.NewLine);
                sqlText.Append("   ,LOGICALDELETECODERF ").Append(Environment.NewLine);
                sqlText.Append("   ,SYNCTABLEIDRF ").Append(Environment.NewLine);
                sqlText.Append("   ,SYNCTABLENAMERF ").Append(Environment.NewLine);
                sqlText.Append("   ,LASTSYNCUPDDTTMRF ").Append(Environment.NewLine);
                sqlText.Append("   ,LASTDATAUPDDATERF ").Append(Environment.NewLine);
                sqlText.Append(" FROM SYNCMNGRF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlText.Append(" WHERE ").Append(Environment.NewLine);

                //��ƃR�[�h
                sqlText.Append(" ENTERPRISECODERF=@FINDENTERPRISECODE ").Append(Environment.NewLine);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncMngWork.EnterpriseCode);

                // �_���폜�敪
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlText.Append(" AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlText.Append(" AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01)
                    {
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    }
                    else
                    {
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                }

                sqlCommand.CommandText = sqlText.ToString();

                sqlCommand.CommandTimeout = 600;
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    al.Add(this.CopyToSyncMngWorkFromReader(ref sqlDataReader));
                }

                // �������ʂ�����ꍇ
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMessage = ex.Message;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SynchConfirmDB.SearchSyncMngDataProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMessage = ex.Message;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!sqlDataReader.IsClosed) sqlDataReader.Close();
            }

            syncMngResultData = al;
            return status;
        }

        /// <summary>
        /// �������ʂ̊i�[
        /// </summary>
        /// <param name="sqlDataReader">sqlDataReader</param>
        /// <returns>SyncMngWork</returns>
        /// <remarks>
        /// <br>Note       : �������ʂ̊i�[���s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private SyncMngWork CopyToSyncMngWorkFromReader(ref SqlDataReader sqlDataReader)
        {
            SyncMngWork syncMngWork = new SyncMngWork();

            # region �N���X�֊i�[
            syncMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("CREATEDATETIMERF"));
            syncMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("UPDATEDATETIMERF"));
            syncMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ENTERPRISECODERF"));
            syncMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("FILEHEADERGUIDRF"));
            syncMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDEMPLOYEECODERF"));
            syncMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID1RF"));
            syncMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID2RF"));
            syncMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("LOGICALDELETECODERF"));
            syncMngWork.SyncTableID = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("SYNCTABLEIDRF"));
            syncMngWork.SyncTableName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("SYNCTABLENAMERF"));
            syncMngWork.LastSyncUpdDtTm = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("LASTSYNCUPDDTTMRF"));
            syncMngWork.LastDataUpdDate = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("LASTDATAUPDDATERF"));

            #endregion

            return syncMngWork;
        }

        #endregion

        #region �������Ǘ��}�X�^�̓o�^
        /// <summary>
        /// �����Ǘ��}�X�^�̓o�^
        /// </summary>
        /// <param name="syncMngData"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �����Ǘ��}�X�^�̓o�^���s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int WriteSyncMngData(ref object syncMngData)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (syncMngData == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList syncMngDataList = syncMngData as ArrayList;
                if (syncMngDataList == null)
                {
                    syncMngDataList = new ArrayList();
                    SyncMngWork syncMngDataWork = syncMngData as SyncMngWork;
                    syncMngDataList.Add(syncMngDataWork);
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //Write���s
                status = this.WriteSyncMngDataProc(ref syncMngDataList, ref sqlConnection, ref sqlTransaction);
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
                            //�R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //���[���o�b�N
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
        /// �����Ǘ��}�X�^�̓o�^(sqlConnection�AsqlTransaction�t��)
        /// </summary>
        /// <param name="syncMngDataList">�����Ǘ��f�[�^���[�N���X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����Ǘ��}�X�^�̓o�^���s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int WriteSyncMngData(ref ArrayList syncMngDataList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteSyncMngDataProc(ref syncMngDataList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �����Ǘ��}�X�^�̓o�^
        /// </summary>
        /// <param name="syncMngDataList">�����Ǘ��f�[�^���[�N���X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����Ǘ��}�X�^�̓o�^���s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private int WriteSyncMngDataProc(ref ArrayList syncMngDataList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (syncMngDataList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < syncMngDataList.Count; i++)
                    {
                        SyncMngWork syncMngDataWork = syncMngDataList[i] as SyncMngWork;

                        //Select�R�}���h�̐���
                        #region [SELECT��]
                        sqlText = string.Empty;
                        sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SYNCTABLEIDRF, SYNCTABLENAMERF, LASTSYNCUPDDTTMRF, LASTDATAUPDDATERF FROM SYNCMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SYNCTABLEIDRF=@FINDSYNCTABLEID ";

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSyncTableID = sqlCommand.Parameters.Add("@FINDSYNCTABLEID", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncMngDataWork.EnterpriseCode);
                        findParaSyncTableID.Value = SqlDataMediator.SqlSetString(syncMngDataWork.SyncTableID);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //Update�R�}���h�̐���
                            #region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText = "UPDATE SYNCMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME, ENTERPRISECODERF=@ENTERPRISECODE, UPDEMPLOYEECODERF=@UPDEMPLOYEECODE, UPDASSEMBLYID1RF=@UPDASSEMBLYID1, UPDASSEMBLYID2RF=@UPDASSEMBLYID2, LOGICALDELETECODERF=@LOGICALDELETECODE, SYNCTABLEIDRF=@SYNCTABLEID, SYNCTABLENAMERF=@SYNCTABLENAME, LASTSYNCUPDDTTMRF=@LASTSYNCUPDDTTM, LASTDATAUPDDATERF= ( CASE WHEN  LASTDATAUPDDATERF IS NULL THEN  @LASTDATAUPDDATE WHEN  LASTDATAUPDDATERF < @LASTDATAUPDDATE THEN  @LASTDATAUPDDATE  ELSE  LASTDATAUPDDATERF END ) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SYNCTABLEIDRF=@FINDSYNCTABLEID ";

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncMngDataWork.EnterpriseCode);
                            findParaSyncTableID.Value = SqlDataMediator.SqlSetString(syncMngDataWork.SyncTableID);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)syncMngDataWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //Insert�R�}���h�̐���
                            #region [INSERT��]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO SYNCMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SYNCTABLEIDRF, SYNCTABLENAMERF, LASTSYNCUPDDTTMRF, LASTDATAUPDDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SYNCTABLEID, @SYNCTABLENAME, @LASTSYNCUPDDTTM, @LASTDATAUPDDATE) ";

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)syncMngDataWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

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

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncMngDataWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncMngDataWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncMngDataWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(syncMngDataWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(syncMngDataWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(syncMngDataWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(syncMngDataWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(syncMngDataWork.LogicalDeleteCode);
                        paraSyncTableID.Value = SqlDataMediator.SqlSetString(syncMngDataWork.SyncTableID);
                        paraSyncTableName.Value = SqlDataMediator.SqlSetString(syncMngDataWork.SyncTableName);
                        paraLastSyncUpdDtTm.Value = SqlDataMediator.SqlSetInt64(syncMngDataWork.LastSyncUpdDtTm);
                        paraLastDataUpdDate.Value = SqlDataMediator.SqlSetInt64(syncMngDataWork.LastDataUpdDate);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(syncMngDataWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
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

            syncMngDataList = al;

            return status;
        }
        #endregion

        #endregion [�����Ǘ��}�X�^]

        #region [PMDBID�Ǘ��}�X�^�@����]

        #region ��PMDBID�Ǘ��}�X�^�̌���
        /// <summary>
        /// PMDBID�Ǘ��}�X�^�̌���
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="pmDbIdMngResultData">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : PMDBID�Ǘ��}�X�^�̌������s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int SearchPmDbIdMngData(string enterpriseCode, out object pmDbIdMngResultData, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMessage = string.Empty;
            pmDbIdMngResultData = null;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = SearchPmDbIdMngDataProc(enterpriseCode, out pmDbIdMngResultData, out errMessage, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                base.WriteErrorLog(ex, "SynchConfirmDB.SearchPmDbIdMngData Exception=" + ex.Message);
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
                            //�R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //���[���o�b�N
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
        /// PMDBID�Ǘ��}�X�^�̌���(sqlConnection�AsqlTransaction�t��)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="pmDbIdMngResultData">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : PMDBID�Ǘ��}�X�^�̌������s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int SearchPmDbIdMngData(string enterpriseCode, out object pmDbIdMngResultData, out string errMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            errMessage = string.Empty;
            pmDbIdMngResultData = null;

            return SearchPmDbIdMngDataProc(enterpriseCode, out pmDbIdMngResultData, out errMessage, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// PMDBID�Ǘ��}�X�^�̌���
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="pmDbIdMngResultData">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : PMDBID�Ǘ��}�X�^�̌������s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private int SearchPmDbIdMngDataProc(string enterpriseCode, out object pmDbIdMngResultData, out string errMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMessage = null;
            pmDbIdMngResultData = null;
            ArrayList al = new ArrayList(); // ���o����

            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, DBIDMNGGUIDRF FROM PMDBIDMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                sqlCommand.CommandText = sqlText;

                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    al.Add(this.CopyToPmDbIdMngWorkFromReader(ref sqlDataReader));
                }

                // �������ʂ�����ꍇ
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                errMessage = ex.Message;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SynchConfirmDB.SearchPmDbIdMngDataProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMessage = ex.Message;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!sqlDataReader.IsClosed) sqlDataReader.Close();
            }

            pmDbIdMngResultData = al;
            return status;
        }

        /// <summary>
        /// �������ʂ̊i�[
        /// </summary>
        /// <param name="sqlDataReader">sqlDataReader</param>
        /// <returns>PmDbIdMngWork</returns>
        /// <remarks>
        /// <br>Note       : �������ʂ̊i�[���s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private PmDbIdMngWork CopyToPmDbIdMngWorkFromReader(ref SqlDataReader sqlDataReader)
        {
            PmDbIdMngWork pmDbIdMngWork = new PmDbIdMngWork();

            # region �N���X�֊i�[
            pmDbIdMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("CREATEDATETIMERF"));
            pmDbIdMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("UPDATEDATETIMERF"));
            pmDbIdMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ENTERPRISECODERF"));
            pmDbIdMngWork.DbIdMngGuid = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DBIDMNGGUIDRF"));

            #endregion

            return pmDbIdMngWork;
        }
        #endregion

        #endregion [PMDBID�Ǘ��}�X�^]

        #region [�����v���f�[�^ �����E�X�V�E�폜]

        #region �������v���f�[�^�̌���

        #region ���������T���擾
        /// <summary>
        /// �����v���f�[�^�����̌���
        /// </summary>
        /// <param name="syncReqResultData">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="param">��������</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����v���f�[�^�����̌������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int GetSyncReqDataCount(out object syncReqResultData, out string errMessage, object param)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMessage = string.Empty;
            syncReqResultData = null;
            SqlConnection sqlConnection = null;

            try
            {
                SyncReqDataWork syncReqDataWork = param as SyncReqDataWork;

                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = GetSyncReqDataCountProc(out syncReqResultData, out errMessage, syncReqDataWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                base.WriteErrorLog(ex, "SynchConfirmDB.GetSyncReqDataCount Exception=" + ex.Message);
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
        /// �����v���f�[�^�����̌���
        /// </summary>
        /// <param name="syncReqResultData">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="syncReqDataWork">��������</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����v���f�[�^�����̌������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private int GetSyncReqDataCountProc(out object syncReqResultData, out string errMessage, SyncReqDataWork syncReqDataWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMessage = null;
            syncReqResultData = null;
            ArrayList al = new ArrayList(); // ���o����

            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlText = "SELECT SYNCTABLEIDRF, SYNCEXECRSLTRF, RETRYCOUNTRF, COUNT(*) AS CNT FROM SYNCREQDATARF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE GROUP BY SYNCTABLEIDRF, SYNCEXECRSLTRF, RETRYCOUNTRF ";

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncReqDataWork.EnterpriseCode);

                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandTimeout = 600;
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    al.Add(this.CopyToSyncReqCountFromReader(ref sqlDataReader));
                }

                // �������ʂ�����ꍇ
                if (al.Count > 0)
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
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                errMessage = ex.Message;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SynchConfirmDB.GetSyncReqDataCountProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMessage = ex.Message;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!sqlDataReader.IsClosed) sqlDataReader.Close();
            }

            syncReqResultData = al;
            return status;
        }

        /// <summary>
        /// �������ʂ̊i�[
        /// </summary>
        /// <param name="myReader">sqlDataReader</param>
        /// <returns>SyncReqDataWork</returns>
        /// <remarks>
        /// <br>Note       : �������ʂ̊i�[���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private SyncReqDataWork CopyToSyncReqCountFromReader(ref SqlDataReader myReader)
        {
            SyncReqDataWork syncReqWork = new SyncReqDataWork();

            # region �N���X�֊i�[
            syncReqWork.SyncTableID = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SYNCTABLEIDRF"));
            syncReqWork.SyncExecRslt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYNCEXECRSLTRF"));
            syncReqWork.RetryCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETRYCOUNTRF"));
            syncReqWork.SyncDataCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNT"));
            #endregion

            return syncReqWork;
        }
        #endregion

        #region �������v���G���[���̎擾
        /// <summary>
        /// �����v���G���[���̎擾
        /// </summary>
        /// <param name="syncReqResultData">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="param">��������</param>
        /// <param name="maxRetryCount">�ő�Ď��s��</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����v���G���[���̎擾���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int SearchSyncReqErrData(out object syncReqResultData, out string errMessage, object param, int maxRetryCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMessage = string.Empty;
            syncReqResultData = null;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SyncReqDataWork syncReqDataWork = param as SyncReqDataWork;

                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = SearchSyncReqErrDataProc(out syncReqResultData, out errMessage, syncReqDataWork, maxRetryCount, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                base.WriteErrorLog(ex, "SynchConfirmDB.SearchSyncReqErrData Exception=" + ex.Message);
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
                            //�R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //���[���o�b�N
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
        /// �����v���G���[���̎擾
        /// </summary>
        /// <param name="syncReqResultData">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="syncReqDataWork">��������</param>
        /// <param name="maxRetryCount">�ő�Ď��s��</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����v���G���[���̎擾���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private int SearchSyncReqErrDataProc(out object syncReqResultData, out string errMessage, SyncReqDataWork syncReqDataWork, int maxRetryCount, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMessage = null;
            syncReqResultData = null;
            ArrayList al = new ArrayList(); // ���o����

            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = " SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, SYNCREQDIVRF, TRANSCTIDRF, SYNCTABLEIDRF, SYNCTARGETDIVRF, SYNCPROCDIVRF, SYNCOBJRECKEYITMIDRF, SYNCOBJRECKEYVALRF, SYNCOBJRECUPDITMIDRF, SYNCOBJRECUPDVALRF, SYNCEXECRSLTRF, RETRYCOUNTRF, ERRORSTATUSRF, ERRORCONTENTSRF FROM (SELECT TOP(1000) CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, SYNCREQDIVRF, TRANSCTIDRF, SYNCTABLEIDRF, SYNCTARGETDIVRF, SYNCPROCDIVRF, SYNCOBJRECKEYITMIDRF, SYNCOBJRECKEYVALRF, SYNCOBJRECUPDITMIDRF, SYNCOBJRECUPDVALRF, SYNCEXECRSLTRF, RETRYCOUNTRF, ERRORSTATUSRF, ERRORCONTENTSRF, ROW_NUMBER() OVER (PARTITION BY SYNCTABLEIDRF ORDER BY CREATEDATETIMERF) AS ROWNUM FROM SYNCREQDATARF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SYNCEXECRSLTRF=2 AND RETRYCOUNTRF >= @FINDRETRYCOUNT ORDER BY CREATEDATETIMERF) AS SUB02 WHERE ROWNUM = 1 ";

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncReqDataWork.EnterpriseCode);

                SqlParameter paraRetryCount = sqlCommand.Parameters.Add("@FINDRETRYCOUNT", SqlDbType.Int);
                paraRetryCount.Value = SqlDataMediator.SqlSetInt32(maxRetryCount);

                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandTimeout = 600;
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    al.Add(this.CopyToSyncReqWorkFromReader(ref sqlDataReader));
                }

                // �������ʂ�����ꍇ
                if (al.Count > 0)
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
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                errMessage = ex.Message;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SynchConfirmDB.SearchSyncReqErrDataProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMessage = ex.Message;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!sqlDataReader.IsClosed) sqlDataReader.Close();
            }

            syncReqResultData = al;
            return status;
        }
        #endregion

        #region ���쐬�����ɂ�蓯���v���G���[���̎擾
        /// <summary>
        /// �쐬�����ɂ�蓯���v���G���[���̎擾
        /// </summary>
        /// <param name="syncReqResultData">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="maxRetryCount">�ő�Ď��s��</param> // ADD 2014/09/03 �c���� Redmine#43408
        /// <param name="param">��������</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �쐬�����ɂ�蓯���v���G���[���̎擾���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// <br>Update Note: 2014/09/03 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11070136-00 Redmine#43408</br>
        /// <br>           : �X�e�[�^�X��2�A�܂�MaxErrorCount�܂œ��B���Ă��Ȃ����̂��擾����Ή�</br>
        /// </remarks>
        //public int SearchSyncReqErrDataByCreateDateTime(out object syncReqResultData, out string errMessage, object param) // DEL 2014/09/03 �c���� Redmine#43408
        public int SearchSyncReqErrDataByCreateDateTime(out object syncReqResultData, out string errMessage, int maxRetryCount, object param) // ADD 2014/09/03 �c���� Redmine#43408
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMessage = string.Empty;
            syncReqResultData = null;
            SqlConnection sqlConnection = null;

            try
            {
                SyncReqDataWork syncReqDataWork = param as SyncReqDataWork;

                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchSyncReqErrDataByCreateDateTimeProc(out syncReqResultData, out errMessage, maxRetryCount, syncReqDataWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                base.WriteErrorLog(ex, "SynchConfirmDB.SearchSyncReqErrDataByCreateDateTime Exception=" + ex.Message);
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
        /// �쐬�����ɂ�蓯���v���G���[���̎擾
        /// </summary>
        /// <param name="syncReqResultData">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="maxRetryCount">�ő�Ď��s��</param> // ADD 2014/09/03 �c���� Redmine#43408
        /// <param name="syncReqDataWork">��������</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �쐬�����ɂ�蓯���v���G���[���̎擾���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// <br>Update Note: 2014/09/03 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11070136-00 Redmine#43408</br>
        /// <br>           : �X�e�[�^�X��2�A�܂�MaxErrorCount�܂œ��B���Ă��Ȃ����̂��擾����Ή�</br>
        /// </remarks>
        //private int SearchSyncReqErrDataByCreateDateTimeProc(out object syncReqResultData, out string errMessage, SyncReqDataWork syncReqDataWork, ref SqlConnection sqlConnection) // DEL 2014/09/03 �c���� Redmine#43408
        private int SearchSyncReqErrDataByCreateDateTimeProc(out object syncReqResultData, out string errMessage, int maxRetryCount, SyncReqDataWork syncReqDataWork, ref SqlConnection sqlConnection) // ADD 2014/09/03 �c���� Redmine#43408
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMessage = null;
            syncReqResultData = null;
            ArrayList al = new ArrayList(); // ���o����

            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, SYNCREQDIVRF, TRANSCTIDRF, SYNCTABLEIDRF, SYNCTARGETDIVRF, SYNCPROCDIVRF, SYNCOBJRECKEYITMIDRF, SYNCOBJRECKEYVALRF, SYNCOBJRECUPDITMIDRF, SYNCOBJRECUPDVALRF, SYNCEXECRSLTRF, RETRYCOUNTRF, ERRORSTATUSRF, ERRORCONTENTSRF FROM SYNCREQDATARF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CREATEDATETIMERF<=@FINDNOWDATETIMETICKS AND (SYNCEXECRSLTRF=0 OR SYNCEXECRSLTRF=1) ORDER BY CREATEDATETIMERF "; // DEL 2014/09/03 �c���� Redmine#43408
                sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, SYNCREQDIVRF, TRANSCTIDRF, SYNCTABLEIDRF, SYNCTARGETDIVRF, SYNCPROCDIVRF, SYNCOBJRECKEYITMIDRF, SYNCOBJRECKEYVALRF, SYNCOBJRECUPDITMIDRF, SYNCOBJRECUPDVALRF, SYNCEXECRSLTRF, RETRYCOUNTRF, ERRORSTATUSRF, ERRORCONTENTSRF FROM SYNCREQDATARF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CREATEDATETIMERF<=@FINDNOWDATETIMETICKS AND (SYNCEXECRSLTRF=0 OR SYNCEXECRSLTRF=1 OR (SYNCEXECRSLTRF=2 AND RETRYCOUNTRF < @FINDRETRYCOUNT)) ORDER BY CREATEDATETIMERF "; // ADD 2014/09/03 �c���� Redmine#43408

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncReqDataWork.EnterpriseCode);

                SqlParameter paraNowDateTime = sqlCommand.Parameters.Add("@FINDNOWDATETIMETICKS", SqlDbType.BigInt);
                paraNowDateTime.Value = SqlDataMediator.SqlSetInt64(syncReqDataWork.CreateDateTime.Ticks);

                //----- ADD 2014/09/03 �c���� Redmine#43408 ----->>>>>
                SqlParameter paraRetryCount = sqlCommand.Parameters.Add("@FINDRETRYCOUNT", SqlDbType.Int);
                paraRetryCount.Value = SqlDataMediator.SqlSetInt32(maxRetryCount);
                //----- ADD 2014/09/03 �c���� Redmine#43408 -----<<<<<

                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandTimeout = 600;
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    al.Add(this.CopyToSyncReqWorkFromReader(ref sqlDataReader));
                }

                // �������ʂ�����ꍇ
                if (al.Count > 0)
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
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                errMessage = ex.Message;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SynchConfirmDB.SearchSyncReqErrDataByCreateDateTimeProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMessage = ex.Message;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!sqlDataReader.IsClosed) sqlDataReader.Close();
            }

            syncReqResultData = al;
            return status;
        }
        #endregion

        #region ���������ʂ̊i�[
        /// <summary>
        /// �������ʂ̊i�[
        /// </summary>
        /// <param name="myReader">sqlDataReader</param>
        /// <returns>SyncReqDataWork</returns>
        /// <remarks>
        /// <br>Note       : �������ʂ̊i�[���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
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
            syncReqWork.SyncTargetDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYNCTARGETDIVRF"));
            syncReqWork.SyncProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYNCPROCDIVRF"));
            syncReqWork.SyncObjRecKeyItmId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SYNCOBJRECKEYITMIDRF"));
            syncReqWork.SyncObjRecKeyVal = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SYNCOBJRECKEYVALRF"));
            syncReqWork.SyncObjRecUpdItmId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SYNCOBJRECUPDITMIDRF"));
            syncReqWork.SyncObjRecUpdVal = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SYNCOBJRECUPDVALRF"));
            syncReqWork.SyncExecRslt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYNCEXECRSLTRF"));
            syncReqWork.RetryCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETRYCOUNTRF"));
            syncReqWork.ErrorStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERRORSTATUSRF"));
            syncReqWork.ErrorContents = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ERRORCONTENTSRF"));
            #endregion

            return syncReqWork;
        }
        #endregion

        #endregion

        #region �������v���f�[�^�̓o�^
        /// <summary>
        /// �����v���f�[�^�̓o�^
        /// </summary>
        /// <param name="syncReqData"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �����v���f�[�^�̓o�^���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int WriteSyncReqDataForFirstTarget(ref object syncReqData)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (syncReqData == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList syncReqDataList = syncReqData as ArrayList;
                if (syncReqDataList == null)
                {
                    syncReqDataList = new ArrayList();
                    SyncReqDataWork syncReqDataWork = syncReqData as SyncReqDataWork;
                    syncReqDataList.Add(syncReqDataWork);
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //Write���s
                status = this.WriteSyncReqDataForFirstTargetProc(ref syncReqDataList, ref sqlConnection, ref sqlTransaction);
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
                            //�R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //���[���o�b�N
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
        /// �����v���f�[�^�̓o�^
        /// </summary>
        /// <param name="syncReqDataList">�����v���f�[�^���X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����v���f�[�^�̓o�^���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private int WriteSyncReqDataForFirstTargetProc(ref ArrayList syncReqDataList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (syncReqDataList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < syncReqDataList.Count; i++)
                    {
                        SyncReqDataWork syncReqDataWork = syncReqDataList[i] as SyncReqDataWork;

                        //Select�R�}���h�̐���
                        #region [SELECT��]
                        sqlText = string.Empty;
                        sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, SYNCREQDIVRF, TRANSCTIDRF, SYNCTABLEIDRF, SYNCTARGETDIVRF, SYNCPROCDIVRF, SYNCOBJRECKEYITMIDRF, SYNCOBJRECKEYVALRF, SYNCOBJRECUPDITMIDRF, SYNCOBJRECUPDVALRF, SYNCEXECRSLTRF, RETRYCOUNTRF, ERRORSTATUSRF, ERRORCONTENTSRF FROM SYNCREQDATARF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SYNCTABLEIDRF=@FINDSYNCTABLEID AND SYNCTARGETDIVRF=@FINDSYNCTARGETDIV ";

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSyncTableID = sqlCommand.Parameters.Add("@FINDSYNCTABLEID", SqlDbType.NVarChar);
                        SqlParameter findParaSyncTargetDiv = sqlCommand.Parameters.Add("@FINDSYNCTARGETDIV", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncReqDataWork.EnterpriseCode);
                        findParaSyncTableID.Value = SqlDataMediator.SqlSetString(syncReqDataWork.SyncTableID);
                        findParaSyncTargetDiv.Value = SqlDataMediator.SqlSetInt32(2);

                        myReader = sqlCommand.ExecuteReader();

                        if (!myReader.Read())
                        {
                            //Insert�R�}���h�̐���
                            #region [INSERT��]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO SYNCREQDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, SYNCREQDIVRF, TRANSCTIDRF, SYNCTABLEIDRF, SYNCTARGETDIVRF, SYNCPROCDIVRF, SYNCOBJRECKEYITMIDRF, SYNCOBJRECKEYVALRF, SYNCOBJRECUPDITMIDRF, SYNCOBJRECUPDVALRF, SYNCEXECRSLTRF, RETRYCOUNTRF, ERRORSTATUSRF, ERRORCONTENTSRF) VALUES (@CREATEDATETIME ,@UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @SYNCREQDIV, @TRANSCTID, @SYNCTABLEID, @SYNCTARGETDIV, @SYNCPROCDIV, @SYNCOBJRECKEYITMID, @SYNCOBJRECKEYVAL, @SYNCOBJRECUPDITMID, @SYNCOBJRECUPDVAL, @SYNCEXECRSLT, @RETRYCOUNT, @ERRORSTATUS, @ERRORCONTENTS) ";

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)syncReqDataWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        else
                        {
                            sqlText = "UPDATE SYNCREQDATARF SET RETRYCOUNTRF=@RETRYCOUNT, ERRORSTATUSRF=@ERRORSTATUS , ERRORCONTENTSRF=@ERRORCONTENTS WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SYNCTABLEIDRF=@FINDSYNCTABLEID AND SYNCTARGETDIVRF=@FINDSYNCTARGETDIV";
                            sqlCommand.CommandText = sqlText;
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)syncReqDataWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

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

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncReqDataWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncReqDataWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncReqDataWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(syncReqDataWork.FileHeaderGuid);
                        paraSyncReqDiv.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.SyncReqDiv);
                        paraTransctId.Value = SqlDataMediator.SqlSetInt64(syncReqDataWork.TransctId);
                        paraSyncTableID.Value = SqlDataMediator.SqlSetString(syncReqDataWork.SyncTableID);
                        paraSyncTargetDiv.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.SyncTargetDiv);
                        paraSyncProcDiv.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.SyncProcDiv);
                        paraSyncObjRecKeyItmId.Value = SqlDataMediator.SqlSetString(syncReqDataWork.SyncObjRecKeyItmId);
                        paraSyncObjRecKeyVal.Value = SqlDataMediator.SqlSetString(syncReqDataWork.SyncObjRecKeyVal);
                        paraSyncObjRecUpdItmId.Value = SqlDataMediator.SqlSetString(syncReqDataWork.SyncObjRecUpdItmId);
                        paraSyncObjRecUpdVal.Value = SqlDataMediator.SqlSetString(syncReqDataWork.SyncObjRecUpdVal);
                        paraSyncExecRslt.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.SyncExecRslt);
                        paraRetryCount.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.RetryCount);
                        paraErrorStatus.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.ErrorStatus);
                        paraErrorContents.Value = SqlDataMediator.SqlSetString(syncReqDataWork.ErrorContents);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(syncReqDataWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
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

            syncReqDataList = al;

            return status;
        }

        #region ���w��e�[�u���̎��A�����v���f�[�^�̓o�^
        /// <summary>
        /// �w��e�[�u�����������̎��A�����v���f�[�^�̓o�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="tableIDList">�w��e�[�u��</param>
        /// <param name="maxRetryCount">�ő�Ď��s��</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �w��e�[�u�����������̎��A�����v���f�[�^�̓o�^���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int WriteSyncReqDataForTable(string enterpriseCode, ArrayList tableIDList, int maxRetryCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (tableIDList == null || tableIDList.Count == 0) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //����
                //�����v���f�[�^�ɓ������s���ʂ��u2:�������s�v�A���u�Ď��s�񐔁v���ݒ�XML���g���C�񐔂̍ő�l�̃f�[�^�����݂���ꍇ�A�����I��
                SyncReqDataWork syncReqDataWork = new SyncReqDataWork();
                syncReqDataWork.EnterpriseCode = enterpriseCode;
                object syncReqResultData = null;
                string errMessage = string.Empty;

                //�����v���G���[���̎擾
                status = SearchSyncReqErrDataProc(out syncReqResultData, out errMessage, syncReqDataWork, maxRetryCount, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    //�����v���f�[�^�փ��R�[�h�ǉ����s���܂��B
                    status = this.WriteSyncReqDataTableProc(enterpriseCode, tableIDList, ref sqlConnection, ref sqlTransaction);
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //�R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //���[���o�b�N
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
        /// �g�����U�N�V����ID�̎擾�B
        /// </summary>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>�g�����U�N�V����ID</returns>
        /// <remarks>
        /// <br>Note       : �g�����U�N�V����ID�̎擾���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private long GetTransactionId(SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            SqlCommand sqlCommand = null;
            try
            {
                sqlCommand = new SqlCommand("SELECT TOP 1 transaction_id FROM sys.dm_tran_current_transaction", sqlConnection, sqlTransaction);
                object o = sqlCommand.ExecuteScalar();
                if (o is Int64)
                {
                    return (long)o;
                }
                else
                {
                    return 0;
                }
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }
        }

        /// <summary>
        /// �w��e�[�u�����������̎��A�����v���f�[�^�̓o�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="tableIDList">�w��e�[�u��</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �w��e�[�u�����������̎��A�����v���f�[�^�̓o�^���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private int WriteSyncReqDataTableProc(string enterpriseCode, ArrayList tableIDList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (tableIDList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    long transactionId = this.GetTransactionId(sqlConnection, sqlTransaction);

                    foreach (string tableID in tableIDList)
                    {
                        //Insert�p�p�����[�^�̍\��
                        SyncReqDataWork syncReqDataWork = new SyncReqDataWork();
                        syncReqDataWork.SyncReqDiv = 0; //0:INSERT
                        syncReqDataWork.TransctId = transactionId;
                        syncReqDataWork.SyncTableID = tableID;
                        syncReqDataWork.SyncTargetDiv = 1; //1:�\�P��
                        syncReqDataWork.SyncProcDiv = (tableID == "STOCKRF") ? 0 : 1; //1:�o�b�`
                        syncReqDataWork.SyncObjRecKeyItmId = string.Empty;
                        syncReqDataWork.SyncObjRecKeyVal = string.Empty;
                        syncReqDataWork.SyncObjRecUpdItmId = string.Empty;
                        syncReqDataWork.SyncObjRecUpdVal = string.Empty;
                        syncReqDataWork.SyncReqDiv = 0; //0:������

                        //Select�R�}���h�̐���
                        #region [SELECT��]
                        sqlText = string.Empty;
                        sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, SYNCREQDIVRF, TRANSCTIDRF, SYNCTABLEIDRF, SYNCTARGETDIVRF, SYNCPROCDIVRF, SYNCOBJRECKEYITMIDRF, SYNCOBJRECKEYVALRF, SYNCOBJRECUPDITMIDRF, SYNCOBJRECUPDVALRF, SYNCEXECRSLTRF, RETRYCOUNTRF, ERRORSTATUSRF, ERRORCONTENTSRF FROM SYNCREQDATARF  WITH(READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SYNCREQDIVRF=@FINDSYNCREQDIV AND SYNCTABLEIDRF=@FINDSYNCTABLEID AND SYNCTARGETDIVRF=@FINDSYNCTARGETDIV ";

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSyncReqDiv = sqlCommand.Parameters.Add("@FINDSYNCREQDIV", SqlDbType.Int);
                        SqlParameter findParaSyncTableID = sqlCommand.Parameters.Add("@FINDSYNCTABLEID", SqlDbType.NVarChar);
                        SqlParameter findParaSyncTargetDiv = sqlCommand.Parameters.Add("@FINDSYNCTARGETDIV", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                        findParaSyncReqDiv.Value = SqlDataMediator.SqlSetInt32(0); //0:INSERT
                        findParaSyncTableID.Value = SqlDataMediator.SqlSetString(tableID);
                        findParaSyncTargetDiv.Value = SqlDataMediator.SqlSetInt32(1); //1:�\�P��

                        myReader = sqlCommand.ExecuteReader();

                        if (!myReader.Read())
                        {
                            //Insert�R�}���h�̐���
                            #region [INSERT��]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO SYNCREQDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, SYNCREQDIVRF, TRANSCTIDRF, SYNCTABLEIDRF, SYNCTARGETDIVRF, SYNCPROCDIVRF, SYNCOBJRECKEYITMIDRF, SYNCOBJRECKEYVALRF, SYNCOBJRECUPDITMIDRF, SYNCOBJRECUPDVALRF, SYNCEXECRSLTRF, RETRYCOUNTRF, ERRORSTATUSRF, ERRORCONTENTSRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @SYNCREQDIV, @TRANSCTID, @SYNCTABLEID, @SYNCTARGETDIV , @SYNCPROCDIV, @SYNCOBJRECKEYITMID, @SYNCOBJRECKEYVAL, @SYNCOBJRECUPDITMID, @SYNCOBJRECUPDVAL, @SYNCEXECRSLT, @RETRYCOUNT, @ERRORSTATUS, @ERRORCONTENTS) ";

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)syncReqDataWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        else
                        {
                            //�f�[�^�����݂���ꍇ�A�����𒆒f���܂�
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

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

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncReqDataWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncReqDataWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncReqDataWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(syncReqDataWork.FileHeaderGuid);
                        paraSyncReqDiv.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.SyncReqDiv);
                        paraTransctId.Value = SqlDataMediator.SqlSetInt64(syncReqDataWork.TransctId);
                        paraSyncTableID.Value = SqlDataMediator.SqlSetString(syncReqDataWork.SyncTableID);
                        paraSyncTargetDiv.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.SyncTargetDiv);
                        paraSyncProcDiv.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.SyncProcDiv);
                        paraSyncObjRecKeyItmId.Value = SqlDataMediator.SqlSetString(syncReqDataWork.SyncObjRecKeyItmId);
                        paraSyncObjRecKeyVal.Value = SqlDataMediator.SqlSetString(syncReqDataWork.SyncObjRecKeyVal);
                        paraSyncObjRecUpdItmId.Value = SqlDataMediator.SqlSetString(syncReqDataWork.SyncObjRecUpdItmId);
                        paraSyncObjRecUpdVal.Value = SqlDataMediator.SqlSetString(syncReqDataWork.SyncObjRecUpdVal);
                        paraSyncExecRslt.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.SyncExecRslt);
                        paraRetryCount.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.RetryCount);
                        paraErrorStatus.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.ErrorStatus);
                        paraErrorContents.Value = SqlDataMediator.SqlSetString(syncReqDataWork.ErrorContents);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
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

        #region �������v���ĊJ�̎��A�Ď��s�񐔂�����������
        /// <summary>
        /// �����v���ĊJ�̎��A�Ď��s�񐔂�����������
        /// </summary>
        /// <param name="retryCount">�ő�Ď��s��</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �����v���ĊJ�̎��A�Ď��s�񐔂�����������B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int UpdateRetryCount(int retryCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //Write���s
                status = this.UpdateRetryCountProc(retryCount, ref sqlConnection, ref sqlTransaction);
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
                            //�R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //���[���o�b�N
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
        /// �����v���ĊJ�̎��A�Ď��s�񐔂�����������
        /// </summary>
        /// <param name="retryCount">�ő�Ď��s��</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �����v���ĊJ�̎��A�Ď��s�񐔂�����������B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private int UpdateRetryCountProc(int retryCount, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Update�R�}���h�̐���
                #region [UPDATE��]
                sqlText = string.Empty;
                sqlText = "UPDATE SYNCREQDATARF SET RETRYCOUNTRF=@RETRYCOUNT WHERE RETRYCOUNTRF>=@FINDRETRYCOUNT ";

                sqlCommand.CommandText = sqlText;
                #endregion

                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraRetryCount = sqlCommand.Parameters.Add("@RETRYCOUNT", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraRetryCount.Value = SqlDataMediator.SqlSetInt32(0);

                //Parameter�I�u�W�F�N�g�̍쐬(�����p)
                SqlParameter findParaRetryCount = sqlCommand.Parameters.Add("@FINDRETRYCOUNT", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
                findParaRetryCount.Value = SqlDataMediator.SqlSetInt32(retryCount);

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        #endregion

        #region ���ʏ�̓����v���f�[�^�̓o�^
        /// <summary>
        /// �����v���f�[�^�̓o�^
        /// </summary>
        /// <param name="syncReqData"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �����v���f�[�^�̓o�^���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int WriteSyncReqData(ref object syncReqData)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (syncReqData == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList syncReqDataList = syncReqData as ArrayList;
                if (syncReqDataList == null)
                {
                    syncReqDataList = new ArrayList();
                    SyncReqDataWork syncReqDataWork = syncReqData as SyncReqDataWork;
                    syncReqDataList.Add(syncReqDataWork);
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //Write���s
                status = this.WriteSyncReqDataProc(ref syncReqDataList, ref sqlConnection, ref sqlTransaction);
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
                            //�R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //���[���o�b�N
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
        /// �����v���f�[�^�̓o�^(sqlConnection�AsqlTransaction�t��)
        /// </summary>
        /// <param name="syncReqDataList">�����v���f�[�^���X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����v���f�[�^�̓o�^���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int WriteSyncReqData(ref ArrayList syncReqDataList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteSyncReqDataProc(ref syncReqDataList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �����v���f�[�^�̓o�^
        /// </summary>
        /// <param name="syncReqDataList">�����v���f�[�^���X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����v���f�[�^�̓o�^���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private int WriteSyncReqDataProc(ref ArrayList syncReqDataList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (syncReqDataList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < syncReqDataList.Count; i++)
                    {
                        SyncReqDataWork syncReqDataWork = syncReqDataList[i] as SyncReqDataWork;

                        //Select�R�}���h�̐���
                        #region [SELECT��]
                        sqlText = string.Empty;
                        sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, SYNCREQDIVRF, TRANSCTIDRF, SYNCTABLEIDRF, SYNCTARGETDIVRF, SYNCPROCDIVRF, SYNCOBJRECKEYITMIDRF, SYNCOBJRECKEYVALRF, SYNCOBJRECUPDITMIDRF, SYNCOBJRECUPDVALRF, SYNCEXECRSLTRF, RETRYCOUNTRF, ERRORSTATUSRF, ERRORCONTENTSRF FROM SYNCREQDATARF WITH(READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CREATEDATETIMERF=@FINDCREATEDATETIME AND FILEHEADERGUIDRF=@FINDFILEHEADERGUID AND TRANSCTIDRF=@FINDTRANSCTID AND SYNCTABLEIDRF=@FINDSYNCTABLEID AND SYNCPROCDIVRF=@FINDSYNCPROCDIV ";
                        sqlCommand.CommandTimeout = 600;
                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaCreateDateTime = sqlCommand.Parameters.Add("@FINDCREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaFileHeaderGuid = sqlCommand.Parameters.Add("@FINDFILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter findParaTransctId = sqlCommand.Parameters.Add("@FINDTRANSCTID", SqlDbType.BigInt);
                        SqlParameter findParaSyncTableID = sqlCommand.Parameters.Add("@FINDSYNCTABLEID", SqlDbType.NVarChar);
                        SqlParameter findParaSyncProcDiv = sqlCommand.Parameters.Add("@FINDSYNCPROCDIV", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncReqDataWork.EnterpriseCode);
                        findParaCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncReqDataWork.CreateDateTime);
                        findParaFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(syncReqDataWork.FileHeaderGuid);
                        findParaTransctId.Value = SqlDataMediator.SqlSetInt64(syncReqDataWork.TransctId);
                        findParaSyncTableID.Value = SqlDataMediator.SqlSetString(syncReqDataWork.SyncTableID);
                        findParaSyncProcDiv.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.SyncProcDiv);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //Update�R�}���h�̐���
                            #region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText = "UPDATE SYNCREQDATARF SET CREATEDATETIMERF=@CREATEDATETIME, UPDATEDATETIMERF=@UPDATEDATETIME, ENTERPRISECODERF=@ENTERPRISECODE, FILEHEADERGUIDRF=@FILEHEADERGUID, SYNCREQDIVRF=@SYNCREQDIV, TRANSCTIDRF=@TRANSCTID, SYNCTABLEIDRF=@SYNCTABLEID, SYNCTARGETDIVRF=@SYNCTARGETDIV, SYNCPROCDIVRF=@SYNCPROCDIV, SYNCOBJRECKEYITMIDRF=@SYNCOBJRECKEYITMID, SYNCOBJRECKEYVALRF=@SYNCOBJRECKEYVAL, SYNCOBJRECUPDITMIDRF=@SYNCOBJRECUPDITMID, SYNCOBJRECUPDVALRF=@SYNCOBJRECUPDVAL, SYNCEXECRSLTRF=@SYNCEXECRSLT, RETRYCOUNTRF=@RETRYCOUNT, ERRORSTATUSRF=@ERRORSTATUS, ERRORCONTENTSRF=@ERRORCONTENTS WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CREATEDATETIMERF=@FINDCREATEDATETIME AND FILEHEADERGUIDRF=@FINDFILEHEADERGUID AND TRANSCTIDRF=@FINDTRANSCTID AND SYNCTABLEIDRF=@FINDSYNCTABLEID AND SYNCPROCDIVRF=@FINDSYNCPROCDIV ";

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)syncReqDataWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //Insert�R�}���h�̐���
                            #region [INSERT��]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO SYNCREQDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, SYNCREQDIVRF, TRANSCTIDRF, SYNCTABLEIDRF, SYNCTARGETDIVRF, SYNCPROCDIVRF, SYNCOBJRECKEYITMIDRF, SYNCOBJRECKEYVALRF, SYNCOBJRECUPDITMIDRF, SYNCOBJRECUPDVALRF, SYNCEXECRSLTRF, RETRYCOUNTRF, ERRORSTATUSRF, ERRORCONTENTSRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @SYNCREQDIV, @TRANSCTID, @SYNCTABLEID, @SYNCTARGETDIV, @SYNCPROCDIV, @SYNCOBJRECKEYITMID, @SYNCOBJRECKEYVAL, @SYNCOBJRECUPDITMID, @SYNCOBJRECUPDVAL, @SYNCEXECRSLT, @RETRYCOUNT, @ERRORSTATUS, @ERRORCONTENTS) ";

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)syncReqDataWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

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

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncReqDataWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncReqDataWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncReqDataWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(syncReqDataWork.FileHeaderGuid);
                        paraSyncReqDiv.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.SyncReqDiv);
                        paraTransctId.Value = SqlDataMediator.SqlSetInt64(syncReqDataWork.TransctId);
                        paraSyncTableID.Value = SqlDataMediator.SqlSetString(syncReqDataWork.SyncTableID);
                        paraSyncTargetDiv.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.SyncTargetDiv);
                        paraSyncProcDiv.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.SyncProcDiv);
                        paraSyncObjRecKeyItmId.Value = SqlDataMediator.SqlSetString(syncReqDataWork.SyncObjRecKeyItmId);
                        paraSyncObjRecKeyVal.Value = SqlDataMediator.SqlSetString(syncReqDataWork.SyncObjRecKeyVal);
                        paraSyncObjRecUpdItmId.Value = SqlDataMediator.SqlSetString(syncReqDataWork.SyncObjRecUpdItmId);
                        paraSyncObjRecUpdVal.Value = SqlDataMediator.SqlSetString(syncReqDataWork.SyncObjRecUpdVal);
                        paraSyncExecRslt.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.SyncExecRslt);
                        paraRetryCount.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.RetryCount);
                        paraErrorStatus.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.ErrorStatus);
                        paraErrorContents.Value = SqlDataMediator.SqlSetString(syncReqDataWork.ErrorContents);
                        #endregion

                        sqlCommand.CommandTimeout = 600;
                        sqlCommand.ExecuteNonQuery();
                        al.Add(syncReqDataWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
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

            syncReqDataList = al;

            return status;
        }
        #endregion

        #endregion

        #region �������v���f�[�^�̍폜
        /// <summary>
        /// �����v���f�[�^�̍폜
        /// </summary>
        /// <param name="syncReqData">�����v���f�[�^</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����v���f�[�^�̍폜���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int DeleteSyncReqData(object syncReqData)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (syncReqData == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList syncReqDataList = syncReqData as ArrayList;
                if (syncReqDataList == null)
                {
                    syncReqDataList = new ArrayList();
                    SyncReqDataWork syncReqDataWork = syncReqData as SyncReqDataWork;
                    syncReqDataList.Add(syncReqDataWork);
                }

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = DeleteSyncReqDataProc(syncReqDataList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
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
        /// �����v���f�[�^�̍폜(sqlConnection�AsqlTransaction�t��)
        /// </summary>
        /// <param name="syncReqDataList">�����v���f�[�^���X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����v���f�[�^�̍폜���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int DeleteSyncReqData(ArrayList syncReqDataList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteSyncReqDataProc(syncReqDataList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �����v���f�[�^�̍폜
        /// </summary>
        /// <param name="syncReqDataList">�����v���f�[�^���X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����v���f�[�^�̍폜���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private int DeleteSyncReqDataProc(ArrayList syncReqDataList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (syncReqDataList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < syncReqDataList.Count; i++)
                    {
                        SyncReqDataWork syncReqDataWork = syncReqDataList[i] as SyncReqDataWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, SYNCREQDIVRF, TRANSCTIDRF, SYNCTABLEIDRF, SYNCTARGETDIVRF , SYNCPROCDIVRF, SYNCOBJRECKEYITMIDRF, SYNCOBJRECKEYVALRF, SYNCOBJRECUPDITMIDRF, SYNCOBJRECUPDVALRF, SYNCEXECRSLTRF, RETRYCOUNTRF, ERRORSTATUSRF, ERRORCONTENTSRF FROM SYNCREQDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CREATEDATETIMERF=@FINDCREATEDATETIME AND FILEHEADERGUIDRF=@FINDFILEHEADERGUID AND TRANSCTIDRF=@FINDTRANSCTID AND SYNCTABLEIDRF=@FINDSYNCTABLEID AND SYNCPROCDIVRF=@FINDSYNCPROCDIV ";

                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaCreateDateTime = sqlCommand.Parameters.Add("@FINDCREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaFileHeaderGuid = sqlCommand.Parameters.Add("@FINDFILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter findParaTransctId = sqlCommand.Parameters.Add("@FINDTRANSCTID", SqlDbType.BigInt);
                        SqlParameter findParaSyncTableID = sqlCommand.Parameters.Add("@FINDSYNCTABLEID", SqlDbType.NVarChar);
                        SqlParameter findParaSyncProcDiv = sqlCommand.Parameters.Add("@FINDSYNCPROCDIV", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncReqDataWork.EnterpriseCode);
                        findParaCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncReqDataWork.CreateDateTime);
                        findParaFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(syncReqDataWork.FileHeaderGuid);
                        findParaTransctId.Value = SqlDataMediator.SqlSetInt64(syncReqDataWork.TransctId);
                        findParaSyncTableID.Value = SqlDataMediator.SqlSetString(syncReqDataWork.SyncTableID);
                        findParaSyncProcDiv.Value = SqlDataMediator.SqlSetInt32(syncReqDataWork.SyncProcDiv);

                        sqlCommand.CommandTimeout = 600;
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (updateDateTime != syncReqDataWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText = "DELETE FROM SYNCREQDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CREATEDATETIMERF=@FINDCREATEDATETIME AND FILEHEADERGUIDRF=@FINDFILEHEADERGUID AND TRANSCTIDRF=@FINDTRANSCTID AND SYNCTABLEIDRF=@FINDSYNCTABLEID AND SYNCPROCDIVRF=@FINDSYNCPROCDIV ";

                            sqlCommand.CommandText = sqlText;
                            # endregion

                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }
                        sqlCommand.CommandTimeout = 600;
                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

        #endregion

        #endregion [�����v���f�[�^]
    }
}