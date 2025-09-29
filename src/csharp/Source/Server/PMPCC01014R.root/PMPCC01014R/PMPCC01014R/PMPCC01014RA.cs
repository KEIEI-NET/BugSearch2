//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�����b�Z�[�W�ݒ菈��
// �v���O�����T�v   : ���[�����b�Z�[�W�ݒ菈��DB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011.08.09  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
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
    /// ���[�����b�Z�[�W�ݒ菈�������[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�����b�Z�[�W�ݒ菈���̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2011.08.09</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PccMailDtDB : RemoteDB, IPccMailDtDB
    {

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public PccMailDtDB() : base("PMPCC01016D", "Broadleaf.Application.Remoting.ParamData.PccMailDtWork", "PCCMAILDTRF")
        {
        }

        #region [�R�l�N�V������������]
        /// <summary>
        /// �R�l�N�V������������
        /// </summary>
        /// <returns>�R�l�N�V����</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
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

        #region [�g�����U�N�V������������]
        /// <summary>
        /// �g�����U�N�V������������
        /// </summary>
        /// <returns>�g�����U�N�V����</returns>
        /// <remarks>
        /// <br>Note       : �g�����U�N�V������������</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }
        #endregion  //�g�����U�N�V������������

        #region IPccMailDtDB �����o

        /// <summary>
        /// ���[�����b�Z�[�W�ݒ菈���o�^�A�X�V����
        /// </summary>
        /// <param name="pccMailDtWorkList">PCC���[���f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int Write(ref object pccMailDtWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = pccMailDtWorkList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // �g�����U�N�V�����J�n
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
        /// ���[�����b�Z�[�W�ݒ菈���o�^�A�X�V����
        /// </summary>
        /// <param name="pccMailDtWorkList">PCC���[���f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
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

                        # region [SELECT��]
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

                        // Prameter�I�u�W�F�N�g�̍쐬

                        SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                        SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                        SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                        SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                        SqlParameter findParaUpdateDate = sqlCommand.Parameters.Add("@FINDUPDATEDATE", SqlDbType.Int);
                        SqlParameter findParaUpdateTime = sqlCommand.Parameters.Add("@FINDUPDATETIME", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalEpCd);
                        findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalSecCd);
                        findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherEpCd);
                        findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherSecCd);
                        findParaUpdateDate.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateDate);
                        findParaUpdateTime.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateTime);
                        //�^�C���A�E�g���Ԃ̐ݒ�
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        myReader = sqlCommand.ExecuteReader();

                         if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != pccMailDtWork.UpdateDateTime)
                            {
                                if (pccMailDtWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    // �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                else
                                {
                                    // �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }

                                return status;
                            }
                              # region [UPDATE��]
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
                        
                            // �X�V�w�b�_����ݒ�
                            pccMailDtWork.UpdateDateTime = DateTime.Now;
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (pccMailDtWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
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

                            // �o�^�w�b�_����ݒ�
                            pccMailDtWork.UpdateDateTime = DateTime.Now;
                            pccMailDtWork.CreateDateTime = DateTime.Now;
                            pccMailDtWork.LogicalDeleteCode = 0;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
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

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
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
                        //�^�C���A�E�g���Ԃ̐ݒ�
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                        sqlCommand.ExecuteNonQuery();
                        
                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            
            
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// ���[�����b�Z�[�W�ݒ茟������
        /// </summary>
        /// <param name="pccMailDtWorkList">PCC���[���f�[�^���X�g</param>
        /// <param name="parsePccMailDtWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int Search(ref object pccMailDtWorkList, PccMailDtWork parsePccMailDtWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            pccMailDtWorkList = null;
            try
            {
                // �R�l�N�V��������
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
        /// ���[�����b�Z�[�W�ݒ茟������
        /// </summary>
        /// <param name="pccMailDtWorkList">PCC���[���f�[�^���X�g</param>
        /// <param name="parsePccMailDtWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
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

                # region [SELECT��]
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
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
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
                //�_���폜�敪
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
                //�^�C���A�E�g���Ԃ̐ݒ�
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
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// ���[�����b�Z�[�W�ݒ茟������
        /// </summary>
        /// <param name="pccMailDtWorkList">PCC���[���f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int Read(ref object pccMailDtWorkList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            try
            {
                // �R�l�N�V��������
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
        /// ���[�����b�Z�[�W�ݒ茟������
        /// </summary>
        /// <param name="pccMailDtWork">PCC���[���f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
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

                # region [SELECT��]
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
                //�_���폜�敪
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

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                SqlParameter findParaUpdateDate = sqlCommand.Parameters.Add("@FINDUPDATEDATE", SqlDbType.Int);
                SqlParameter findParaUpdateTime = sqlCommand.Parameters.Add("@FINDUPDATETIME", SqlDbType.Int);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalEpCd);
                findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalSecCd);
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherSecCd);
                findParaUpdateDate.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateDate);
                findParaUpdateTime.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateTime);

                # endregion
                //�^�C���A�E�g���Ԃ̐ݒ�
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
        /// ���[�����b�Z�[�W�ݒ�_���폜����
        /// </summary>
        /// <param name="pccMailDtWorkList">PCC���[���f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int LogicalDelete(ref object pccMailDtWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // �g�����U�N�V�����J�n
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
        /// ���[�����b�Z�[�W�ݒ�_���폜����
        /// </summary>
        /// <param name="pccMailDtWorkList">PCC���[���f�[�^���X�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
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
                // myReader�̎ߕ�
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
        ///  ���[�����b�Z�[�W�ݒ�_���폜����
        /// </summary>
        /// <param name="pccMailDtWorkEach">PCC���[���f�[�^</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
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

            // Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaUpdateDate = sqlCommand.Parameters.Add("@FINDUPDATEDATE", SqlDbType.Int);
            SqlParameter findParaUpdateTime = sqlCommand.Parameters.Add("@FINDUPDATETIME", SqlDbType.Int);

           // Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWorkEach.InqOriginalEpCd);
            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWorkEach.InqOriginalSecCd);
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWorkEach.InqOtherSecCd);
            findParaUpdateDate.Value = SqlDataMediator.SqlSetInt32(pccMailDtWorkEach.UpdateDate);
            findParaUpdateTime.Value = SqlDataMediator.SqlSetInt32(pccMailDtWorkEach.UpdateTime);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            
            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                if (_updateDateTime != pccMailDtWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }

                // ���݂̘_���폜�敪���擾
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                # region [UPDATE��]
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

                // KEY�R�}���h���Đݒ�
                findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWorkEach.InqOriginalEpCd);
                findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWorkEach.InqOriginalSecCd);
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWorkEach.InqOtherSecCd);
                findParaUpdateDate.Value = SqlDataMediator.SqlSetInt32(pccMailDtWorkEach.UpdateDate);
                findParaUpdateTime.Value = SqlDataMediator.SqlSetInt32(pccMailDtWorkEach.UpdateTime);
                  

                // �X�V�w�b�_����ݒ�
                pccMailDtWorkEach.UpdateDateTime = DateTime.Now;
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
            //�_���폜���[�h�̏ꍇ
            if (procMode == 0)
            {

                if (logicalDelCd == 0) pccMailDtWorkEach.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g

            }
            else
            {
                if (logicalDelCd == 1) pccMailDtWorkEach.LogicalDeleteCode = 0;//�_���폜�t���O������

            }
            // Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
           
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

            // Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccMailDtWorkEach.UpdateDateTime);

            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccMailDtWorkEach.LogicalDeleteCode);
            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

            sqlCommand.ExecuteNonQuery();




            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            return status;

        }

        /// <summary>
        /// ���[�����b�Z�[�W�ݒ蕨���폜����
        /// </summary>
        /// <param name="pccMailDtWorkList">PCC���[���f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int Delete(ref object pccMailDtWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = pccMailDtWorkList as ArrayList;
               
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // �g�����U�N�V�����J�n
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
        /// ���[�����b�Z�[�W�ݒ蕨���폜����
        /// </summary>
        /// <param name="pccMailDtWorkList">PCC���[���f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
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

                        # region [SELECT��]
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

                        // Prameter�I�u�W�F�N�g�̍쐬

                        SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                        SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                        SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                        SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                        SqlParameter findParaUpdateDate = sqlCommand.Parameters.Add("@FINDUPDATEDATE", SqlDbType.Int);
                        SqlParameter findParaUpdateTime = sqlCommand.Parameters.Add("@FINDUPDATETIME", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalEpCd);
                        findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalSecCd);
                        findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherEpCd);
                        findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherSecCd);
                        findParaUpdateDate.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateDate);
                        findParaUpdateTime.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateTime);
                        //�^�C���A�E�g���Ԃ̐ݒ�
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != pccMailDtWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
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

                            // Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalEpCd);
                            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOriginalSecCd);
                            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherEpCd);
                            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(pccMailDtWork.InqOtherSecCd);
                            findParaUpdateDate.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateDate);
                            findParaUpdateTime.Value = SqlDataMediator.SqlSetInt32(pccMailDtWork.UpdateTime);

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
                        //�^�C���A�E�g���Ԃ̐ݒ�
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// ���[�����b�Z�[�W�ݒ蕜������
        /// </summary>
        /// <param name="pccMailDtWorkList">PCC���[���f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object pccMailDtWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // �g�����U�N�V�����J�n
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
        /// ���[�����b�Z�[�W�ݒ蕜������
        /// </summary>
        /// <param name="pccMailDtWorkList">PCC���[���f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int RevivalLogicalDeleteProc(ref object pccMailDtWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            status = LogicalDeleteProc(ref pccMailDtWorkList, 1, ref sqlConnection, ref sqlTransaction);
            return status;
        }


        #endregion

        #region ��������
         /// <summary>
        /// PCC���[�����b�Z�[�W�ݒ�擾����
        /// </summary>
        /// <param name="myReader">���[�����b�Z�[�W�ݒ�Reader</param>
        /// <param name="pccMailDtWorkList">���[�����b�Z�[�W�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyToPccMailDtListFromReader(ref SqlDataReader myReader, ref ArrayList pccMailDtWorkList)
        {
            pccMailDtWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //�쐬����
            int colIndex_CreateDateTime = 0;
            //�X�V����
            int colIndex_UpdateDateTime = 0;
            //�_���폜�敪
            int colIndex_LogicalDeleteCode = 0;
            //�⍇������ƃR�[�h
            int colIndex_InqOriginalEpCd = 0;
            //�⍇�������_�R�[�h
            int colIndex_InqOriginalSecCd = 0;
            //�⍇�����ƃR�[�h
            int colIndex_InqOtherEpCd = 0;
            //�⍇���拒�_�R�[�h
            int colIndex_InqOtherSecCd = 0;
            //�X�V�N����
            int colIndex_UpdateDate = 0;
            //�X�V�����b�~���b
            int colIndex_UpdateTime = 0;
            //PCC���[������
            int colIndex_PccMailTitle = 0;
            //PCC���[���{��
            int colIndex_PccMailDocCnts = 0;
            try
            {
                if (myReader.HasRows)
                {
                    //�쐬����
                    colIndex_CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
                    //�X�V����
                    colIndex_UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
                    //�_���폜�敪
                    colIndex_LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
                    //�⍇������ƃR�[�h
                    colIndex_InqOriginalEpCd = myReader.GetOrdinal("INQORIGINALEPCDRF");
                    //�⍇�������_�R�[�h
                    colIndex_InqOriginalSecCd = myReader.GetOrdinal("INQORIGINALSECCDRF");
                    //�⍇�����ƃR�[�h
                    colIndex_InqOtherEpCd = myReader.GetOrdinal("INQOTHEREPCDRF");
                    //�⍇���拒�_�R�[�h
                    colIndex_InqOtherSecCd = myReader.GetOrdinal("INQOTHERSECCDRF");
                    //�X�V�N����
                    colIndex_UpdateDate = myReader.GetOrdinal("UPDATEDATERF");
                    //�X�V�����b�~���b
                    colIndex_UpdateTime = myReader.GetOrdinal("UPDATETIMERF");
                    //PCC���[������
                    colIndex_PccMailTitle = myReader.GetOrdinal("PCCMAILTITLERF");
                    //PCC���[���{��
                    colIndex_PccMailDocCnts = myReader.GetOrdinal("PCCMAILDOCCNTSRF");
                }
                while (myReader.Read())
                {
                    PccMailDtWork pccMailDtWork = new PccMailDtWork();
                    //�쐬����
                    pccMailDtWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                    //�X�V����
                    pccMailDtWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                    //�_���폜�敪
                    pccMailDtWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                    //�⍇������ƃR�[�h
                    pccMailDtWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd).Trim();//@@@@20230303
                    //�⍇�������_�R�[�h
                    pccMailDtWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
                    //�⍇�����ƃR�[�h
                    pccMailDtWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                    //�⍇���拒�_�R�[�h
                    pccMailDtWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                    //�X�V�N����
                    pccMailDtWork.UpdateDate = SqlDataMediator.SqlGetInt32(myReader, colIndex_UpdateDate);
                    //�X�V�����b�~���b
                    pccMailDtWork.UpdateTime = SqlDataMediator.SqlGetInt32(myReader, colIndex_UpdateTime);
                    //PCC���[������
                    pccMailDtWork.PccMailTitle = SqlDataMediator.SqlGetString(myReader, colIndex_PccMailTitle);
                    //PCC���[���{��
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
        /// PCC���[���f�[�^�擾����
        /// </summary>
        /// <param name="myReader">PCC���[���f�[�^Reader</param>
        /// <returns>�oPCC���[���f�[�^</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private PccMailDtWork CopyToPccMailDtWorkFromReader(ref SqlDataReader myReader)
        {
            PccMailDtWork pccMailDtWork = new PccMailDtWork();
            if (myReader != null && pccMailDtWork != null)
            {
                # region �N���X�֊i�[
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
