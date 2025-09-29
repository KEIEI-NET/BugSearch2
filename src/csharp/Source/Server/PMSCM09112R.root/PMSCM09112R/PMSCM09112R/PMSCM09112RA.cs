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
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ������ԕ\���[���ݒ�DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������ԕ\���[���ݒ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2014/08/18</br>
    /// <br></br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SyncStateDspTermStDB : RemoteDB, ISyncStateDspTermStDB
    {
        /// <summary>
        /// ������ԕ\���[���ݒ�DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : ����</br>														   
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        public SyncStateDspTermStDB()
            :
        base("PMSCM09115D", "Broadleaf.Application.Remoting.ParamData.SyncStateDspTermStWork", "SYNCSTATEDSPTERMSTRF")
        {
        }

        #region [Write]
        /// <summary>
        /// ������ԕ\���[���ݒ����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="syncStateDspTermStWork">SyncStateDspTermStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ������ԕ\���[���ݒ����o�^�A�X�V���܂�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        public int Write(ref object syncStateDspTermStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(syncStateDspTermStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteSyncStateProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                syncStateDspTermStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SyncStateDspTermStDB.Write(ref object syncStateDspTermStWork)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ������ԕ\���[���ݒ����o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="syncStateDspTermStWorkList">SyncStateDspTermStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ������ԕ\���[���ݒ����o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        /// <br></br>
        /// <br></br>
        public int WriteSyncStateProc(ref ArrayList syncStateDspTermStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteSyncStateProcProc(ref syncStateDspTermStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ������ԕ\���[���ݒ����o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="syncStateDspTermStWorkList">SyncStateDspTermStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ������ԕ\���[���ݒ����o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        /// <br></br>
        private int WriteSyncStateProcProc( ref ArrayList syncStateDspTermStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlText = string.Empty;
            try
            {
                if (syncStateDspTermStWorkList != null)
                {
                    for (int i = 0; i < syncStateDspTermStWorkList.Count; i++)
                    {
                        SyncStateDspTermStWork syncStateDspTermStWork = syncStateDspTermStWorkList[i] as SyncStateDspTermStWork;

                        //  �������狒�_�R�[�h(SectionCode)���͂���
                        //Select�R�}���h�̐���
                        sqlText = string.Empty;
                        sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CASHREGISTERNORF FROM SYNCSTATEDSPTERMSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.SectionCode);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt(syncStateDspTermStWork.CashRegisterNo);
                        //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != syncStateDspTermStWork.UpdateDateTime)
                            {
                                string _sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); //���_�R�[�h
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (syncStateDspTermStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ŋ��_�R�[�h�Ⴂ�̏ꍇ�͏d�� 
                                else if (_sectionCode != syncStateDspTermStWork.SectionCode) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlText = string.Empty;
                            sqlText += "UPDATE SYNCSTATEDSPTERMSTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , CASHREGISTERNORF=@CASHREGISTERNO WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.SectionCode);
                            findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(syncStateDspTermStWork.CashRegisterNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)syncStateDspTermStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (syncStateDspTermStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //�V�K�쐬����SQL���𐶐�
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO SYNCSTATEDSPTERMSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CASHREGISTERNORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @CASHREGISTERNO)" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)syncStateDspTermStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncStateDspTermStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncStateDspTermStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(syncStateDspTermStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(syncStateDspTermStWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.SectionCode);
                        paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(syncStateDspTermStWork.CashRegisterNo);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(syncStateDspTermStWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            syncStateDspTermStWorkList = al;

            return status;
        }
        #endregion

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̓�����ԕ\���[���ݒ�߂�f�[�^���LIST��߂��܂�
        /// </summary>
        /// <param name="syncStateDspTermStWork">��������</param>
        /// <param name="parseSyncStateDspTermStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓�����ԕ\���[���ݒ�߂�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        public int Search(out object syncStateDspTermStWork, object parseSyncStateDspTermStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            syncStateDspTermStWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSyncStateProc(out syncStateDspTermStWork, parseSyncStateDspTermStWork, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SyncStateDspTermStDB.Search");
                syncStateDspTermStWork = new ArrayList();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// �w�肳�ꂽ�����̓�����ԕ\���[���ݒ�߂�f�[�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objsyncStateDspTermStWork">��������</param>
        /// <param name="parasyncStateDspTermStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓�����ԕ\���[���ݒ�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        public int SearchSyncStateProc(out object objsyncStateDspTermStWork, object parasyncStateDspTermStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SyncStateDspTermStWork syncStateDspTermStWork = null;

            ArrayList syncStateDspTermStWorkList = parasyncStateDspTermStWork as ArrayList;
            if (syncStateDspTermStWorkList == null)
            {
                syncStateDspTermStWork = parasyncStateDspTermStWork as SyncStateDspTermStWork;
            }
            else
            {
                if (syncStateDspTermStWorkList.Count > 0)
                    syncStateDspTermStWork = syncStateDspTermStWorkList[0] as SyncStateDspTermStWork;
            }

            int status = SearchSyncStateProc(out syncStateDspTermStWorkList, syncStateDspTermStWork, readMode, logicalMode, ref sqlConnection);
            objsyncStateDspTermStWork = syncStateDspTermStWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̓�����ԕ\���[���ݒ�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="syncStateDspTermStWorkList">��������</param>
        /// <param name="syncStateDspTermStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������e-JIBAI�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        public int SearchSyncStateProc(out ArrayList syncStateDspTermStWorkList, SyncStateDspTermStWork syncStateDspTermStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchSyncStateProcProc(out syncStateDspTermStWorkList, syncStateDspTermStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̓�����ԕ\���[���ݒ�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="syncStateDspTermStWorkList">��������</param>
        /// <param name="syncStateDspTermStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������e-JIBAI�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        private int SearchSyncStateProcProc( out ArrayList syncStateDspTermStWorkList, SyncStateDspTermStWork syncStateDspTermStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlText = string.Empty;
                sqlText += "SELECT SYNCSTATE.CREATEDATETIMERF ,SYNCSTATE.UPDATEDATETIMERF ,SYNCSTATE.ENTERPRISECODERF ,SYNCSTATE.FILEHEADERGUIDRF ,SYNCSTATE.UPDEMPLOYEECODERF ,SYNCSTATE.UPDASSEMBLYID1RF ,SYNCSTATE.UPDASSEMBLYID2RF ,SYNCSTATE.LOGICALDELETECODERF ,SYNCSTATE.SECTIONCODERF ,SYNCSTATE.CASHREGISTERNORF FROM SYNCSTATEDSPTERMSTRF AS SYNCSTATE WITH (READUNCOMMITTED) LEFT JOIN SECINFOSETRF AS SECINF WITH (READUNCOMMITTED) ON SECINF.ENTERPRISECODERF = SYNCSTATE.ENTERPRISECODERF AND SECINF.SECTIONCODERF = SYNCSTATE.SECTIONCODERF  AND SECINF.LOGICALDELETECODERF = 0 LEFT JOIN POSTERMINALMGRF AS POST WITH (READUNCOMMITTED) ON POST.ENTERPRISECODERF = SYNCSTATE.ENTERPRISECODERF AND POST.CASHREGISTERNORF = SYNCSTATE.CASHREGISTERNORF AND POST.LOGICALDELETECODERF = 0 WHERE SYNCSTATE.ENTERPRISECODERF = @FINDENTERPRISECODE ORDER BY SECTIONCODERF, CASHREGISTERNORF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.EnterpriseCode);
                //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToSyncStateDspTermStWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            syncStateDspTermStWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// ������ԕ\���[���ݒ�߂�f�[�^����_���폜���܂�
        /// </summary>
        /// <param name="syncStateDspTermStWork">SyncStateDspTermStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ������ԕ\���[���ݒ�߂�f�[�^����_���폜���܂�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        public int LogicalDelete(ref object syncStateDspTermStWork)
        {
            return LogicalDeleteSyncState(ref syncStateDspTermStWork, 0);
        }

        /// <summary>
        /// �_���폜������ԕ\���[���ݒ�߂�f�[�^���𕜊����܂�
        /// </summary>
        /// <param name="syncStateDspTermStWork">SyncStateDspTermStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜������ԕ\���[���ݒ�߂�f�[�^���𕜊����܂�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        public int RevivalLogicalDelete(ref object syncStateDspTermStWork)
        {
            return LogicalDeleteSyncState(ref syncStateDspTermStWork, 1);
        }

        /// <summary>
        /// ������ԕ\���[���ݒ�߂�f�[�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="syncStateDspTermStWork">SyncStateDspTermStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ������ԕ\���[���ݒ�߂�f�[�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        private int LogicalDeleteSyncState(ref object syncStateDspTermStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(syncStateDspTermStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteSyncStateProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "SyncStateDspTermStDB.LogicalDeleteCarrier :" + procModestr);

                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ������ԕ\���[���ݒ�߂�f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="syncStateDspTermStWorkList">SyncStateDspTermStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ������ԕ\���[���ݒ�߂�f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        public int LogicalDeleteSyncStateProc(ref ArrayList syncStateDspTermStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteSyncStateProcProc(ref syncStateDspTermStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ������ԕ\���[���ݒ�߂�f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="syncStateDspTermStWorkList">SyncStateDspTermStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ������ԕ\���[���ݒ�߂�f�[�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        private int LogicalDeleteSyncStateProcProc( ref ArrayList syncStateDspTermStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlText = string.Empty;
            try
            {
                if (syncStateDspTermStWorkList != null)
                {
                    for (int i = 0; i < syncStateDspTermStWorkList.Count; i++)
                    {
                        SyncStateDspTermStWork syncStateDspTermStWork = syncStateDspTermStWorkList[i] as SyncStateDspTermStWork;

                        //Select�R�}���h�̐���
                        sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CASHREGISTERNORF FROM SYNCSTATEDSPTERMSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                        sqlText = string.Empty;

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.SectionCode);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(syncStateDspTermStWork.CashRegisterNo);
                        //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != syncStateDspTermStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlText += "UPDATE SYNCSTATEDSPTERMSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME, UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.SectionCode);
                            findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(syncStateDspTermStWork.CashRegisterNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)syncStateDspTermStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();

                        //�_���폜���[�h�̏ꍇ
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) syncStateDspTermStWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else syncStateDspTermStWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) syncStateDspTermStWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
                                sqlCommand.Cancel();
                                return status;
                            }
                        }

                        //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncStateDspTermStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(syncStateDspTermStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(syncStateDspTermStWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            syncStateDspTermStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// ������ԕ\���[���ݒ�߂�f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="paraobj">������ԕ\���[���ݒ�߂�f�[�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ������ԕ\���[���ݒ�߂�f�[�^���𕨗��폜���܂�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        public int Delete(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(paraobj);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteSyncStateProc(paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SyncStateDspTermStDB.Delete");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// ������ԕ\���[���ݒ�߂�f�[�^���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="syncStateDspTermStWorkList">������ԕ\���[���ݒ�߂�f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ������ԕ\���[���ݒ�߂�f�[�^���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        public int DeleteSyncStateProc(ArrayList syncStateDspTermStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteSyncStateProcProc(syncStateDspTermStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ������ԕ\���[���ݒ�߂�f�[�^���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="syncStateDspTermStWorkList">������ԕ\���[���ݒ�߂�f�[�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ������ԕ\���[���ݒ�߂�f�[�^���𕨗��폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        private int DeleteSyncStateProcProc( ArrayList syncStateDspTermStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = string.Empty;
            try
            {

                for (int i = 0; i < syncStateDspTermStWorkList.Count; i++)
                {
                    SyncStateDspTermStWork syncStateDspTermStWork = syncStateDspTermStWorkList[i] as SyncStateDspTermStWork;
                    sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CASHREGISTERNORF FROM SYNCSTATEDSPTERMSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                    sqlText = string.Empty;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.SectionCode);
                    findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(syncStateDspTermStWork.CashRegisterNo);
                    //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != syncStateDspTermStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlText += "DELETE FROM SYNCSTATEDSPTERMSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        sqlText = string.Empty;
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.SectionCode);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(syncStateDspTermStWork.CashRegisterNo);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            SyncStateDspTermStWork[] SyncStateDspTermStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is SyncStateDspTermStWork)
                    {
                        SyncStateDspTermStWork wkSyncStateDspTermStWork = paraobj as SyncStateDspTermStWork;
                        if (wkSyncStateDspTermStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkSyncStateDspTermStWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            SyncStateDspTermStWorkArray = (SyncStateDspTermStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SyncStateDspTermStWork[]));
                        }
                        catch (Exception) { }
                        if (SyncStateDspTermStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(SyncStateDspTermStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                SyncStateDspTermStWork wkSyncStateDspTermStWork = (SyncStateDspTermStWork)XmlByteSerializer.Deserialize(byteArray, typeof(SyncStateDspTermStWork));
                                if (wkSyncStateDspTermStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkSyncStateDspTermStWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //���ɉ������Ȃ�
                }

            return retal;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SyncStateDspTermStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SyncStateDspTermStWork</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        private SyncStateDspTermStWork CopyToSyncStateDspTermStWorkFromReader(ref SqlDataReader myReader)
        {
            SyncStateDspTermStWork wkSyncStateDspTermStWork = new SyncStateDspTermStWork();

            #region �N���X�֊i�[
            wkSyncStateDspTermStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkSyncStateDspTermStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkSyncStateDspTermStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkSyncStateDspTermStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkSyncStateDspTermStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkSyncStateDspTermStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkSyncStateDspTermStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkSyncStateDspTermStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkSyncStateDspTermStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkSyncStateDspTermStWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
            #endregion

            return wkSyncStateDspTermStWork;
        }
        #endregion

    }
}