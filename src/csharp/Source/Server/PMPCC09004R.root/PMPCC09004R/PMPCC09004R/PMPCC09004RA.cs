//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PCC�S�̐ݒ�}�X�^�擾�ݒ�}�X�^�����e
// �v���O�����T�v   : PCC�S�̐ݒ�擾�ݒ�}�X�^�����eDB�����[�g�I�u�W�F�N�g   
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �t�I��
// �� �� ��  2011.08.01  �C�����e : �V�K�쐬
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
    /// PCC�S�̐ݒ�}�X�^�擾�ݒ�}�X�^�����e�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC�S�̐ݒ�}�X�^�擾�ݒ�}�X�^�����e�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �t�I��</br>
    /// <br>Date       : 2011.08.01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PccTtlStDB : RemoteDB, IPccTtlStDB
    {

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public PccTtlStDB()
            : base("PMPCC09006D", "Broadleaf.Application.Remoting.ParamData.PccTtlStWork", "PCCTTLSTRF")
        {
        }

        #region [�R�l�N�V������������]

        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : �t�I��</br>
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

        #region [�g�����U�N�V������������]

        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <returns>SqlTransaction</returns>
        /// <remarks>
        /// <br>Note       : SqlTransaction��������</br>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }

        #endregion  //�g�����U�N�V������������

        #region IPccTtlStDB �����o

        /// <summary>
        /// PCC�S�̐ݒ�擾�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccTtlStObj">PCC�S�̐ݒ�擾�ݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Read(ref object pccTtlStObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            try
            {
                // �R�l�N�V��������
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
        /// PCC�S�̐ݒ�擾�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccTtlStWork">PCC�S�̐ݒ�擾�ݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �t�I��</br>
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

                # region [SELECT��]
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

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.SectionCode);

                //�^�C���A�E�g���Ԃ̐ݒ�
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
        /// PCC�S�̐ݒ�擾�ݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="pccTtlStList">PCC�S�̐ݒ�擾�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Delete(ref object pccTtlStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = pccTtlStList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                status = this.DeleteProc(ref paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// PCC�S�̐ݒ�擾�ݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="pccTtlStList">PCC�S�̐ݒ�擾�ݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �t�I��</br>
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

                        # region [SELECT��]
                        sqlText = new StringBuilder();
                        sqlText.Append("SELECT UPDATEDATETIMERF").Append(Environment.NewLine);
                        sqlText.Append(" FROM PCCTTLSTRF").Append(Environment.NewLine);
                        sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
                        sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);

                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.SectionCode);

                        //�^�C���A�E�g���Ԃ̐ݒ�
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != pccTtlStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = new StringBuilder();
                            sqlText.Append("DELETE").Append(Environment.NewLine);
                            sqlText.Append(" FROM PCCTTLSTRF").Append(Environment.NewLine);
                            sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
                            sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);

                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.SectionCode);

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
        /// PCC�S�̐ݒ�擾�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccTtlStList">PCC�S�̐ݒ�擾�ݒ�f�[�^���X�g</param>
        /// <param name="pccTtlStObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Search(ref object pccTtlStList, PccTtlStWork pccTtlStObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            pccTtlStList = null;
            SqlConnection sqlConnection = null;
            try
            {
                // �R�l�N�V��������
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
        /// PCC�S�̐ݒ�擾�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccTtlStList">PCC�S�̐ݒ�擾�ݒ�f�[�^���X�g</param>
        /// <param name="pccTtlStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �t�I��</br>
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

                # region [SELECT��]
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

                // Prameter�I�u�W�F�N�g�̍쐬
               
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.SectionCode);

                # endregion

                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                myReader = sqlCommand.ExecuteReader();
                status = CopyToListForSearch(ref myReader, out pccTtlStArray);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// PCC�S�̐ݒ�擾�ݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccTtlStList">PCC�S�̐ݒ�擾�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Write(ref object pccTtlStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = pccTtlStList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                // write���s
                status = this.WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// PCC�S�̐ݒ�擾�ݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccTtlStList">PCC�S�̐ݒ�擾�ݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �t�I��</br>
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

                        # region [SELECT��]
                        sqlText = new StringBuilder();
                        sqlText.Append("SELECT UPDATEDATETIMERF").Append(Environment.NewLine);
                        sqlText.Append(" FROM PCCTTLSTRF").Append(Environment.NewLine);
                        sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
                        sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);

                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬

                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.SectionCode);

                        //�^�C���A�E�g���Ԃ̐ݒ�
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != pccTtlStWork.UpdateDateTime)
                            {
                                if (pccTtlStWork.UpdateDateTime == DateTime.MinValue)
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

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(pccTtlStWork.SectionCode);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pccTtlStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (pccTtlStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
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

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pccTtlStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
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

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
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
        /// PCC�S�̐ݒ�擾�ݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccTtlStList">PCC�S�̐ݒ�擾�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int LogicalDelete(ref object pccTtlStList)
        {
            return this.LogicalDelete(ref pccTtlStList, 0);
        }

        /// <summary>
        /// UOE ���Аݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="pccTtlStList">�_���폜�𑀍삷��UOE ���Аݒ�}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PccTtlStWork �Ɋi�[����Ă���UOE ���Аݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer :�t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        public int LogicalDelete(ref object pccTtlStList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                status = this.LogicalDeleteProc(ref pccTtlStList, procMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
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
        /// UOE ���Аݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="pccTtlStList">�_���폜�𑀍삷��UOE ���Аݒ�}�X�^�����i�[����</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PccTtlStWork �Ɋi�[����Ă���UOE ���Аݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer :�t�I��</br>
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
        /// UOE ���Аݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="pccTtlStWorkEach">�_���폜�𑀍삷��UOE ���Аݒ�}�X�^�����i�[����</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">�g�����U�N�V�������</param>
        /// <param name="myReader">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PccTtlStWork �Ɋi�[����Ă���UOE ���Аݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer :�t�I��</br>
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


            // Prameter�I�u�W�F�N�g�̍쐬

            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

            // Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pccTtlStWorkEach.EnterpriseCode);
            findParaSectionCode.Value = SqlDataMediator.SqlSetString(pccTtlStWorkEach.SectionCode);

            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                if (_updateDateTime != pccTtlStWorkEach.UpdateDateTime)
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

                // KEY�R�}���h���Đݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pccTtlStWorkEach.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(pccTtlStWorkEach.SectionCode);


                // �X�V�w�b�_����ݒ�
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)pccTtlStWorkEach;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);
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

                if (logicalDelCd == 0) pccTtlStWorkEach.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g

            }
            else
            {
                if (logicalDelCd == 1) pccTtlStWorkEach.LogicalDeleteCode = 0;//�_���폜�t���O������

            }


            // Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

            // Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccTtlStWorkEach.UpdateDateTime);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pccTtlStWorkEach.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pccTtlStWorkEach.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pccTtlStWorkEach.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccTtlStWorkEach.LogicalDeleteCode);

            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            return status;

        }

        /// <summary>
        /// PCC�S�̐ݒ�擾�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccTtlStList">PCC�S�̐ݒ�擾�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object pccTtlStList)
        {
            return this.LogicalDelete(ref pccTtlStList, 1);
        }

        #endregion

        #region ��������

        # region [�N���X�i�[����]

        /// <summary>
        /// �N���X�i�[���� Reader �� PccTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PccTtlStWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer :�t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private PccTtlStWork CopyToPccTtlStWorkFromReader(ref SqlDataReader myReader)
        {
            PccTtlStWork pccTtlStWork = new PccTtlStWork();

            this.CopyToPccTtlStWorkFromReader(ref myReader, ref pccTtlStWork);

            return pccTtlStWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� PccTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="pccTtlStWork">PccTtlStWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer :�t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void CopyToPccTtlStWorkFromReader(ref SqlDataReader myReader, ref PccTtlStWork pccTtlStWork)
        {
            if (myReader != null && pccTtlStWork != null)
            {
                # region �N���X�֊i�[


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
        /// �N���X�i�[���� Reader �� PccTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="pccTtlStWork">PccTtlStWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer :�t�I��</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private int CopyToListForSearch(ref SqlDataReader myReader, out ArrayList pccTtlStWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            pccTtlStWorkList = new ArrayList();
            //�쐬����
            int colIndex_CreateDateTime = 0;
            //�X�V����
            int colIndex_UpdateDateTime = 0;
            //��ƃR�[�h
            int colIndex_EnterpriseCode = 0;
            //GUID
            int colIndex_FileHeaderGuid = 0;
            //�X�V�]�ƈ��R�[�h
            int colIndex_UpdEmployeeCode = 0;
            //�X�V�A�Z���u��ID1
            int colIndex_UpdAssemblyId1 = 0;
            //�X�V�A�Z���u��ID2
            int colIndex_UpdAssemblyId2 = 0;
            //�_���폜�敪
            int colIndex_LogicalDeleteCode = 0;
            //���_�R�[�h
            int colIndex_SectionCode = 0;
            //��t�]�ƈ��R�[�h
            int colIndex_FrontEmployeeCd = 0;
            //�[�i�敪
            int colIndex_DeliveredGoodsDiv = 0;
            //����`�[���s�敪
            int colIndex_SalesSlipPrtDiv = 0;
            //�󒍓`�[����敪
            int colIndex_AcpOdrrSlipPrtDiv = 0;
            if (myReader.HasRows)
            {
                //�쐬����
                colIndex_CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
                //�X�V����
                colIndex_UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
                //��ƃR�[�h
                colIndex_EnterpriseCode = myReader.GetOrdinal("ENTERPRISECODERF");
                //GUID
                colIndex_FileHeaderGuid = myReader.GetOrdinal("FILEHEADERGUIDRF");
                //�X�V�]�ƈ��R�[�h
                colIndex_UpdEmployeeCode = myReader.GetOrdinal("UPDEMPLOYEECODERF");
                //�X�V�A�Z���u��ID1
                colIndex_UpdAssemblyId1 = myReader.GetOrdinal("UPDASSEMBLYID1RF");
                //�X�V�A�Z���u��ID2
                colIndex_UpdAssemblyId2 = myReader.GetOrdinal("UPDASSEMBLYID2RF");
                //�_���폜�敪
                colIndex_LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
                //���_�R�[�h
                colIndex_SectionCode = myReader.GetOrdinal("SECTIONCODERF");
                //��t�]�ƈ��R�[�h
                colIndex_FrontEmployeeCd = myReader.GetOrdinal("FRONTEMPLOYEECDRF");
                //�[�i�敪
                colIndex_DeliveredGoodsDiv = myReader.GetOrdinal("DELIVEREDGOODSDIVRF");
                //����`�[���s�敪
                colIndex_SalesSlipPrtDiv = myReader.GetOrdinal("SALESSLIPPRTDIVRF");
                //�󒍓`�[����敪
                colIndex_AcpOdrrSlipPrtDiv = myReader.GetOrdinal("ACPODRRSLIPPRTDIVRF");
            }
            while (myReader.Read())
            {
                PccTtlStWork pccTtlStWork = new PccTtlStWork();
                //�쐬����
                pccTtlStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                //�X�V����
                pccTtlStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                //��ƃR�[�h
                pccTtlStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, colIndex_EnterpriseCode);
                //GUID
                pccTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, colIndex_FileHeaderGuid);
                //�X�V�]�ƈ��R�[�h
                pccTtlStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, colIndex_UpdEmployeeCode);
                //�X�V�A�Z���u��ID1
                pccTtlStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, colIndex_UpdAssemblyId1);
                //�X�V�A�Z���u��ID2
                pccTtlStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, colIndex_UpdAssemblyId2);
                //�_���폜�敪
                pccTtlStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                //���_�R�[�h
                pccTtlStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, colIndex_SectionCode);
                //��t�]�ƈ��R�[�h
                pccTtlStWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, colIndex_FrontEmployeeCd);
                //�[�i�敪
                pccTtlStWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_DeliveredGoodsDiv);
                //����`�[���s�敪
                pccTtlStWork.SalesSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_SalesSlipPrtDiv);
                //�󒍓`�[����敪
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
