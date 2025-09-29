//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : BL�R�[�h�ϊ��}�X�^�擾�ݒ�}�X�^�����e
// �v���O�����T�v   : BL�R�[�h�ϊ��擾�ݒ�}�X�^�����eDB�����[�g�I�u�W�F�N�g   
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g�� �F�� 30745
// �� �� ��  2012/08/01  �C�����e : �V�K�쐬
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
    /// BL�R�[�h�ϊ��}�X�^�擾�ݒ�}�X�^�����e�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : BL�R�[�h�ϊ��}�X�^�擾�ݒ�}�X�^�����e�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �g�� �F�� 30745</br>
    /// <br>Date       : 2012/08/01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class BLGoodsCdChgUDB : RemoteDB, IBLGoodsCdChgUDB
    {

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public BLGoodsCdChgUDB()
            : base("PMKHN09696D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdChgUWork", "BLGOODSCDCHGURF")
        {
        }

        #region [�R�l�N�V������������]

        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
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
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }

        #endregion  //�g�����U�N�V������������

        #region IBLGoodsCdChgUDB �����o

        /// <summary>
        /// BL�R�[�h�ϊ��擾�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="blCodeChangeObj">BL�R�[�h�ϊ��擾�ݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int Read(ref object blCodeChangeObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                BLGoodsCdChgUWork blCodeChangeWork = blCodeChangeObj as BLGoodsCdChgUWork;

                status = ReadProc(ref blCodeChangeWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLGoodsCdChgUDB.Read");
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
        /// BL�R�[�h�ϊ��擾�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="blCodeChangeWork">BL�R�[�h�ϊ��擾�ݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int ReadProc(ref BLGoodsCdChgUWork blCodeChangeWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT��]
                sqlText.Append("SELECT ").Append(Environment.NewLine);
                sqlText.Append("  CREATEDATETIMERF ").Append(Environment.NewLine);
                sqlText.Append("  , UPDATEDATETIMERF ").Append(Environment.NewLine);
                sqlText.Append("  , ENTERPRISECODERF ").Append(Environment.NewLine);
                sqlText.Append("  , FILEHEADERGUIDRF ").Append(Environment.NewLine);
                sqlText.Append("  , UPDEMPLOYEECODERF ").Append(Environment.NewLine);
                sqlText.Append("  , UPDASSEMBLYID1RF ").Append(Environment.NewLine);
                sqlText.Append("  , UPDASSEMBLYID2RF ").Append(Environment.NewLine);
                sqlText.Append("  , LOGICALDELETECODERF ").Append(Environment.NewLine);
                sqlText.Append("  , SECTIONCODERF ").Append(Environment.NewLine);
                sqlText.Append("  , CUSTOMERCODERF ").Append(Environment.NewLine);
                sqlText.Append("  , PMBLGOODSCODERF ").Append(Environment.NewLine);
                sqlText.Append("  , PMBLGOODSCODEDERIVNORF ").Append(Environment.NewLine);
                sqlText.Append("  , SFBLGOODSCODERF ").Append(Environment.NewLine);
                sqlText.Append("  , SFBLGOODSCODEDERIVNORF ").Append(Environment.NewLine);
                sqlText.Append("  , BLGOODSFULLNAMERF ").Append(Environment.NewLine);
                sqlText.Append("  , BLGOODSHALFNAMERF  ").Append(Environment.NewLine);
                sqlText.Append("FROM ").Append(Environment.NewLine);
                sqlText.Append("  BLGOODSCDCHGURF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlText.Append("WHERE ").Append(Environment.NewLine);
                sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE  ").Append(Environment.NewLine);
                sqlText.Append("  AND SECTIONCODERF = @FINDSECTIONCODE  ").Append(Environment.NewLine);
                sqlText.Append("  AND CUSTOMERCODERF = @FINDCUSTOMERCODE  ").Append(Environment.NewLine);
                sqlText.Append("  AND PMBLGOODSCODERF = @FINDPMBLGOODSCODE ").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaPMBlGoodsCode = sqlCommand.Parameters.Add("@FINDPMBLGOODSCODE", SqlDbType.Int);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.SectionCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.CustomerCode);
                findParaPMBlGoodsCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.PMBLGoodsCode);

                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToBLGoodsCdChgUWorkFromReader(ref myReader, ref blCodeChangeWork);
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
        /// BL�R�[�h�ϊ��擾�ݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="blCodeChangeList">BL�R�[�h�ϊ��擾�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int Delete(ref object blCodeChangeList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = blCodeChangeList as ArrayList;

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
                base.WriteErrorLog(ex, "BLGoodsCdChgUDB.Delete");
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
        /// BL�R�[�h�ϊ��擾�ݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="blCodeChangeList">BL�R�[�h�ϊ��擾�ݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>    
        public int DeleteProc(ref ArrayList blCodeChangeList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (blCodeChangeList != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < blCodeChangeList.Count; i++)
                    {
                        BLGoodsCdChgUWork blCodeChangeWork = blCodeChangeList[i] as BLGoodsCdChgUWork;

                        # region [SELECT��]
                        sqlText = new StringBuilder();
                        sqlText.Append("SELECT UPDATEDATETIMERF").Append(Environment.NewLine);
                        sqlText.Append(" FROM BLGOODSCDCHGURF").Append(Environment.NewLine);
                        sqlText.Append("WHERE ").Append(Environment.NewLine);
                        sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE  ").Append(Environment.NewLine);
                        sqlText.Append("  AND SECTIONCODERF = @FINDSECTIONCODE  ").Append(Environment.NewLine);
                        sqlText.Append("  AND CUSTOMERCODERF = @FINDCUSTOMERCODE  ").Append(Environment.NewLine);
                        sqlText.Append("  AND PMBLGOODSCODERF = @FINDPMBLGOODSCODE ").Append(Environment.NewLine);

                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaPMBlGoodsCode = sqlCommand.Parameters.Add("@FINDPMBLGOODSCODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.CustomerCode);
                        findParaPMBlGoodsCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.PMBLGoodsCode);

                        //�^�C���A�E�g���Ԃ̐ݒ�
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != blCodeChangeWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = new StringBuilder();
                            sqlText.Append("DELETE  ").Append(Environment.NewLine);
                            sqlText.Append("FROM ").Append(Environment.NewLine);
                            sqlText.Append("  BLGOODSCDCHGURF  ").Append(Environment.NewLine);
                            sqlText.Append("WHERE ").Append(Environment.NewLine);
                            sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE  ").Append(Environment.NewLine);
                            sqlText.Append("  AND SECTIONCODERF = @FINDSECTIONCODE  ").Append(Environment.NewLine);
                            sqlText.Append("  AND CUSTOMERCODERF = @FINDCUSTOMERCODE  ").Append(Environment.NewLine);
                            sqlText.Append("  AND PMBLGOODSCODERF = @FINDPMBLGOODSCODE ").Append(Environment.NewLine);
                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.SectionCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.CustomerCode);
                            findParaPMBlGoodsCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.PMBLGoodsCode);

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
                base.WriteErrorLog(ex, "BLGoodsCdChgUDB.Delete");
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
        /// BL�R�[�h�ϊ��擾�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="blCodeChangeList">BL�R�[�h�ϊ��擾�ݒ�f�[�^���X�g</param>
        /// <param name="blCodeChangeObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int Search(ref object blCodeChangeList, BLGoodsCdChgUWork blCodeChangeObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            blCodeChangeList = null;
            SqlConnection sqlConnection = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                BLGoodsCdChgUWork blCodeChangeWork = blCodeChangeObj as BLGoodsCdChgUWork;
                status = SearchProc(ref blCodeChangeList, blCodeChangeWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLGoodsCdChgUDB.Search");
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
        /// BL�R�[�h�ϊ��擾�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="blCodeChangeList">BL�R�[�h�ϊ��擾�ݒ�f�[�^���X�g</param>
        /// <param name="blCodeChangeWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>  
        public int SearchProc(ref object blCodeChangeList, BLGoodsCdChgUWork blCodeChangeWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList blCodeChangeArray = blCodeChangeList as ArrayList;

            if (blCodeChangeArray == null)
            {
                blCodeChangeArray = new ArrayList();
            }
            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT��]
                                sqlText.Append("SELECT ").Append(Environment.NewLine);
                sqlText.Append("  CREATEDATETIMERF ").Append(Environment.NewLine);
                sqlText.Append("  , UPDATEDATETIMERF ").Append(Environment.NewLine);
                sqlText.Append("  , ENTERPRISECODERF ").Append(Environment.NewLine);
                sqlText.Append("  , FILEHEADERGUIDRF ").Append(Environment.NewLine);
                sqlText.Append("  , UPDEMPLOYEECODERF ").Append(Environment.NewLine);
                sqlText.Append("  , UPDASSEMBLYID1RF ").Append(Environment.NewLine);
                sqlText.Append("  , UPDASSEMBLYID2RF ").Append(Environment.NewLine);
                sqlText.Append("  , LOGICALDELETECODERF ").Append(Environment.NewLine);
                sqlText.Append("  , SECTIONCODERF ").Append(Environment.NewLine);
                sqlText.Append("  , CUSTOMERCODERF ").Append(Environment.NewLine);
                sqlText.Append("  , PMBLGOODSCODERF ").Append(Environment.NewLine);
                sqlText.Append("  , PMBLGOODSCODEDERIVNORF ").Append(Environment.NewLine);
                sqlText.Append("  , SFBLGOODSCODERF ").Append(Environment.NewLine);
                sqlText.Append("  , SFBLGOODSCODEDERIVNORF ").Append(Environment.NewLine);
                sqlText.Append("  , BLGOODSFULLNAMERF ").Append(Environment.NewLine);
                sqlText.Append("  , BLGOODSHALFNAMERF  ").Append(Environment.NewLine);
                sqlText.Append("FROM ").Append(Environment.NewLine);
                sqlText.Append("  BLGOODSCDCHGURF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlText.Append("WHERE ").Append(Environment.NewLine);
                sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE  ").Append(Environment.NewLine);
                sqlText.Append("ORDER BY ").Append(Environment.NewLine);
                sqlText.Append("  ENTERPRISECODERF, SECTIONCODERF, CUSTOMERCODERF, PMBLGOODSCODERF ").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.EnterpriseCode);

                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                myReader = sqlCommand.ExecuteReader();
                status = CopyToListForSearch(ref myReader, out blCodeChangeArray);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "BLGoodsCdChgUDB.Search");
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
            blCodeChangeList = blCodeChangeArray;
            return status;

        }

        /// <summary>
        /// BL�R�[�h�ϊ��擾�ݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="blCodeChangeList">BL�R�[�h�ϊ��擾�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int Write(ref object blCodeChangeList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = blCodeChangeList as ArrayList;

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
                base.WriteErrorLog(ex, "BLGoodsCdChgUDB.Write");
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
        /// BL�R�[�h�ϊ��擾�ݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="blCodeChangeList">BL�R�[�h�ϊ��擾�ݒ�f�[�^���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int WriteProc(ref ArrayList blCodeChangeList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (blCodeChangeList != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < blCodeChangeList.Count; i++)
                    {
                        BLGoodsCdChgUWork blCodeChangeWork = blCodeChangeList[i] as BLGoodsCdChgUWork;

                        # region [SELECT��]
                        sqlText = new StringBuilder();
                        sqlText.Append("SELECT UPDATEDATETIMERF").Append(Environment.NewLine);
                        sqlText.Append(" FROM BLGOODSCDCHGURF").Append(Environment.NewLine);
                        sqlText.Append("WHERE ").Append(Environment.NewLine);
                        sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE  ").Append(Environment.NewLine);
                        sqlText.Append("  AND SECTIONCODERF = @FINDSECTIONCODE  ").Append(Environment.NewLine);
                        sqlText.Append("  AND CUSTOMERCODERF = @FINDCUSTOMERCODE  ").Append(Environment.NewLine);
                        sqlText.Append("  AND PMBLGOODSCODERF = @FINDPMBLGOODSCODE ").Append(Environment.NewLine);

                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaPMBlGoodsCode = sqlCommand.Parameters.Add("@FINDPMBLGOODSCODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.CustomerCode);
                        findParaPMBlGoodsCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.PMBLGoodsCode);

                        //�^�C���A�E�g���Ԃ̐ݒ�
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != blCodeChangeWork.UpdateDateTime)
                            {
                                if (blCodeChangeWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText.Append("UPDATE BLGOODSCDCHGURF  ").Append(Environment.NewLine);
                            sqlText.Append("SET ").Append(Environment.NewLine);
                            sqlText.Append("  CREATEDATETIMERF = @CREATEDATETIME ").Append(Environment.NewLine);
                            sqlText.Append("  , UPDATEDATETIMERF = @UPDATEDATETIME ").Append(Environment.NewLine);
                            sqlText.Append("  , ENTERPRISECODERF = @ENTERPRISECODE ").Append(Environment.NewLine);
                            sqlText.Append("  , FILEHEADERGUIDRF = @FILEHEADERGUID ").Append(Environment.NewLine);
                            sqlText.Append("  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE ").Append(Environment.NewLine);
                            sqlText.Append("  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 ").Append(Environment.NewLine);
                            sqlText.Append("  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 ").Append(Environment.NewLine);
                            sqlText.Append("  , LOGICALDELETECODERF = @LOGICALDELETECODE ").Append(Environment.NewLine);
                            sqlText.Append("  , SECTIONCODERF = @SECTIONCODE ").Append(Environment.NewLine);
                            sqlText.Append("  , CUSTOMERCODERF = @CUSTOMERCODE ").Append(Environment.NewLine);
                            sqlText.Append("  , PMBLGOODSCODERF = @PMBLGOODSCODE ").Append(Environment.NewLine);
                            sqlText.Append("  , PMBLGOODSCODEDERIVNORF = @PMBLGOODSCODEDERIVNO ").Append(Environment.NewLine);
                            sqlText.Append("  , SFBLGOODSCODERF = @SFBLGOODSCODE ").Append(Environment.NewLine);
                            sqlText.Append("  , SFBLGOODSCODEDERIVNORF = @SFBLGOODSCODEDERIVNO ").Append(Environment.NewLine);
                            sqlText.Append("  , BLGOODSFULLNAMERF = @BLGOODSFULLNAME ").Append(Environment.NewLine);
                            sqlText.Append("  , BLGOODSHALFNAMERF = @BLGOODSHALFNAME ").Append(Environment.NewLine);
                            sqlText.Append("WHERE ").Append(Environment.NewLine);
                            sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE  ").Append(Environment.NewLine);
                            sqlText.Append("  AND SECTIONCODERF = @FINDSECTIONCODE  ").Append(Environment.NewLine);
                            sqlText.Append("  AND CUSTOMERCODERF = @FINDCUSTOMERCODE  ").Append(Environment.NewLine);
                            sqlText.Append("  AND PMBLGOODSCODERF = @FINDPMBLGOODSCODE ").Append(Environment.NewLine);
                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.SectionCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.CustomerCode);
                            findParaPMBlGoodsCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.PMBLGoodsCode);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)blCodeChangeWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (blCodeChangeWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = new StringBuilder();
                            sqlText.Append("INSERT  ").Append(Environment.NewLine);
                            sqlText.Append("INTO BLGOODSCDCHGURF(  ").Append(Environment.NewLine);
                            sqlText.Append("  CREATEDATETIMERF ").Append(Environment.NewLine);
                            sqlText.Append("  , UPDATEDATETIMERF ").Append(Environment.NewLine);
                            sqlText.Append("  , ENTERPRISECODERF ").Append(Environment.NewLine);
                            sqlText.Append("  , FILEHEADERGUIDRF ").Append(Environment.NewLine);
                            sqlText.Append("  , UPDEMPLOYEECODERF ").Append(Environment.NewLine);
                            sqlText.Append("  , UPDASSEMBLYID1RF ").Append(Environment.NewLine);
                            sqlText.Append("  , UPDASSEMBLYID2RF ").Append(Environment.NewLine);
                            sqlText.Append("  , LOGICALDELETECODERF ").Append(Environment.NewLine);
                            sqlText.Append("  , SECTIONCODERF ").Append(Environment.NewLine);
                            sqlText.Append("  , CUSTOMERCODERF ").Append(Environment.NewLine);
                            sqlText.Append("  , PMBLGOODSCODERF ").Append(Environment.NewLine);
                            sqlText.Append("  , PMBLGOODSCODEDERIVNORF ").Append(Environment.NewLine);
                            sqlText.Append("  , SFBLGOODSCODERF ").Append(Environment.NewLine);
                            sqlText.Append("  , SFBLGOODSCODEDERIVNORF ").Append(Environment.NewLine);
                            sqlText.Append("  , BLGOODSFULLNAMERF ").Append(Environment.NewLine);
                            sqlText.Append("  , BLGOODSHALFNAMERF ").Append(Environment.NewLine);
                            sqlText.Append(")  ").Append(Environment.NewLine);
                            sqlText.Append("VALUES (  ").Append(Environment.NewLine);
                            sqlText.Append("  @CREATEDATETIME ").Append(Environment.NewLine);
                            sqlText.Append("  , @UPDATEDATETIME ").Append(Environment.NewLine);
                            sqlText.Append("  , @ENTERPRISECODE ").Append(Environment.NewLine);
                            sqlText.Append("  , @FILEHEADERGUID ").Append(Environment.NewLine);
                            sqlText.Append("  , @UPDEMPLOYEECODE ").Append(Environment.NewLine);
                            sqlText.Append("  , @UPDASSEMBLYID1 ").Append(Environment.NewLine);
                            sqlText.Append("  , @UPDASSEMBLYID2 ").Append(Environment.NewLine);
                            sqlText.Append("  , @LOGICALDELETECODE ").Append(Environment.NewLine);
                            sqlText.Append("  , @SECTIONCODE ").Append(Environment.NewLine);
                            sqlText.Append("  , @CUSTOMERCODE ").Append(Environment.NewLine);
                            sqlText.Append("  , @PMBLGOODSCODE ").Append(Environment.NewLine);
                            sqlText.Append("  , @PMBLGOODSCODEDERIVNO ").Append(Environment.NewLine);
                            sqlText.Append("  , @SFBLGOODSCODE ").Append(Environment.NewLine);
                            sqlText.Append("  , @SFBLGOODSCODEDERIVNO ").Append(Environment.NewLine);
                            sqlText.Append("  , @BLGOODSFULLNAME ").Append(Environment.NewLine);
                            sqlText.Append("  , @BLGOODSHALFNAME ").Append(Environment.NewLine);
                            sqlText.Append(")  ").Append(Environment.NewLine); sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)blCodeChangeWork;
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
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);

                        SqlParameter paraPMBLGoodsCode = sqlCommand.Parameters.Add("@PMBLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraPMBLGoodsCodeDerivNo = sqlCommand.Parameters.Add("@PMBLGOODSCODEDERIVNO", SqlDbType.Int);
                        SqlParameter paraSFBLGoodsCode = sqlCommand.Parameters.Add("@SFBLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraSFBLGoodsCodeDerivNo = sqlCommand.Parameters.Add("@SFBLGOODSCODEDERIVNO", SqlDbType.Int);
                        SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NChar);
                        SqlParameter paraBLGoodsHalfName = sqlCommand.Parameters.Add("@BLGOODSHALFNAME", SqlDbType.NChar);

                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(blCodeChangeWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(blCodeChangeWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(blCodeChangeWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(blCodeChangeWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.SectionCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(blCodeChangeWork.CustomerCode);

                        paraPMBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blCodeChangeWork.PMBLGoodsCode);
                        paraPMBLGoodsCodeDerivNo.Value = SqlDataMediator.SqlSetInt32(blCodeChangeWork.PMBLGoodsCodeDerivNo);
                        paraSFBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blCodeChangeWork.SFBLGoodsCode);
                        paraSFBLGoodsCodeDerivNo.Value = SqlDataMediator.SqlSetInt32(blCodeChangeWork.SFBLGoodsCodeDerivNo);
                        paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.BLGoodsFullName);
                        paraBLGoodsHalfName.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.BLGoodsHalfName);

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
                base.WriteErrorLog(ex, "BLGoodsCdChgUDB.LogicalDelete");
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
        /// BL�R�[�h�ϊ��擾�ݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="blCodeChangeList">BL�R�[�h�ϊ��擾�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int LogicalDelete(ref object blCodeChangeList)
        {
            return this.LogicalDelete(ref blCodeChangeList, 0);
        }

        /// <summary>
        /// UOE ���Аݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="blCodeChangeList">�_���폜�𑀍삷��UOE ���Аݒ�}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLGoodsCdChgUWork �Ɋi�[����Ă���UOE ���Аݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer :�g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        public int LogicalDelete(ref object blCodeChangeList, int procMode)
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

                status = this.LogicalDeleteProc(ref blCodeChangeList, procMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "BLGoodsCdChgUDB.LogicalDelete");
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
        /// <param name="blCodeChangeList">�_���폜�𑀍삷��UOE ���Аݒ�}�X�^�����i�[����</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLGoodsCdChgUWork �Ɋi�[����Ă���UOE ���Аݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer :�g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        private int LogicalDeleteProc(ref object blCodeChangeList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList blCodeChangeArrList = null;
            ArrayList blCodeChangeArrListNew = null;
            try
            {

                if (blCodeChangeList != null)
                {
                    blCodeChangeArrList = blCodeChangeList as ArrayList;
                }
                if (blCodeChangeArrList == null || blCodeChangeArrList.Count == 0)
                {
                    return status;

                }
                blCodeChangeArrListNew = new ArrayList();

                for (int i = 0; i < blCodeChangeArrList.Count; i++)
                {
                    BLGoodsCdChgUWork blCodeChangeWorkEach = blCodeChangeArrList[i] as BLGoodsCdChgUWork;
                    status = LogicalDeleteProcEach(ref blCodeChangeWorkEach, procMode, ref  sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    blCodeChangeArrListNew.Add(blCodeChangeWorkEach);

                    blCodeChangeList = blCodeChangeArrListNew as object;

                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "BLGoodsCdChgUWorkDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLGoodsCdChgUWorkDB.LogicalDeleteProc Exception=" + ex.Message);
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
        /// <param name="blCodeChangeWorkEach">�_���폜�𑀍삷��UOE ���Аݒ�}�X�^�����i�[����</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">�g�����U�N�V�������</param>
        /// <param name="myReader">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLGoodsCdChgUWork �Ɋi�[����Ă���UOE ���Аݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer :�g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        private int LogicalDeleteProcEach(ref BLGoodsCdChgUWork blCodeChangeWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int logicalDelCd = 0;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            StringBuilder sqlText = new StringBuilder();

            sqlText.Append("SELECT").Append(Environment.NewLine);
            sqlText.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlText.Append(" ,LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlText.Append("FROM").Append(Environment.NewLine);
            sqlText.Append("  BLGOODSCDCHGURF").Append(Environment.NewLine);
            sqlText.Append("WHERE ").Append(Environment.NewLine);
            sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE  ").Append(Environment.NewLine);
            sqlText.Append("  AND SECTIONCODERF = @FINDSECTIONCODE  ").Append(Environment.NewLine);
            sqlText.Append("  AND CUSTOMERCODERF = @FINDCUSTOMERCODE  ").Append(Environment.NewLine);
            sqlText.Append("  AND PMBLGOODSCODERF = @FINDPMBLGOODSCODE ").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);


            // Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
            SqlParameter findParaPMBlGoodsCode = sqlCommand.Parameters.Add("@FINDPMBLGOODSCODE", SqlDbType.Int);

            // Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWorkEach.EnterpriseCode);
            findParaSectionCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWorkEach.SectionCode);
            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWorkEach.CustomerCode);
            findParaPMBlGoodsCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWorkEach.PMBLGoodsCode);

            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                if (_updateDateTime != blCodeChangeWorkEach.UpdateDateTime)
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
                sqlText.Append("  BLGOODSCDCHGURF").Append(Environment.NewLine);
                sqlText.Append("SET").Append(Environment.NewLine);
                sqlText.Append("  UPDATEDATETIMERF = @UPDATEDATETIME").Append(Environment.NewLine);
                sqlText.Append(" ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE").Append(Environment.NewLine);
                sqlText.Append(" ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1").Append(Environment.NewLine);
                sqlText.Append(" ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2").Append(Environment.NewLine);
                sqlText.Append(" ,LOGICALDELETECODERF = @LOGICALDELETECODE").Append(Environment.NewLine);
                sqlText.Append("WHERE ").Append(Environment.NewLine);
                sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE  ").Append(Environment.NewLine);
                sqlText.Append("  AND SECTIONCODERF = @FINDSECTIONCODE  ").Append(Environment.NewLine);
                sqlText.Append("  AND CUSTOMERCODERF = @FINDCUSTOMERCODE  ").Append(Environment.NewLine);
                sqlText.Append("  AND PMBLGOODSCODERF = @FINDPMBLGOODSCODE ").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                // KEY�R�}���h���Đݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWorkEach.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWorkEach.SectionCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWorkEach.CustomerCode);
                findParaPMBlGoodsCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWorkEach.PMBLGoodsCode);


                // �X�V�w�b�_����ݒ�
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)blCodeChangeWorkEach;
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

                if (logicalDelCd == 0) blCodeChangeWorkEach.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g

            }
            else
            {
                if (logicalDelCd == 1) blCodeChangeWorkEach.LogicalDeleteCode = 0;//�_���폜�t���O������

            }


            // Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

            // Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(blCodeChangeWorkEach.UpdateDateTime);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWorkEach.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(blCodeChangeWorkEach.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(blCodeChangeWorkEach.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(blCodeChangeWorkEach.LogicalDeleteCode);

            //�^�C���A�E�g���Ԃ̐ݒ�
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            return status;

        }

        /// <summary>
        /// BL�R�[�h�ϊ��擾�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="blCodeChangeList">BL�R�[�h�ϊ��擾�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object blCodeChangeList)
        {
            return this.LogicalDelete(ref blCodeChangeList, 1);
        }

        #endregion

        #region ��������

        # region [�N���X�i�[����]

        /// <summary>
        /// �N���X�i�[���� Reader �� BLGoodsCdChgUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>BLGoodsCdChgUWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer :�g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private BLGoodsCdChgUWork CopyToBLGoodsCdChgUWorkFromReader(ref SqlDataReader myReader)
        {
            BLGoodsCdChgUWork blCodeChangeWork = new BLGoodsCdChgUWork();

            this.CopyToBLGoodsCdChgUWorkFromReader(ref myReader, ref blCodeChangeWork);

            return blCodeChangeWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� BLGoodsCdChgUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="blCodeChangeWork">BLGoodsCdChgUWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer :�g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void CopyToBLGoodsCdChgUWorkFromReader(ref SqlDataReader myReader, ref BLGoodsCdChgUWork blCodeChangeWork)
        {
            if (myReader != null && blCodeChangeWork != null)
            {
                # region �N���X�֊i�[


                blCodeChangeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                blCodeChangeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                blCodeChangeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                blCodeChangeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                blCodeChangeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                blCodeChangeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                blCodeChangeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                blCodeChangeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                blCodeChangeWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

                blCodeChangeWork.PMBLGoodsCode = SqlDataMediator.SqlGetInt(myReader, myReader.GetOrdinal("PMBLGOODSCODERF"));
                blCodeChangeWork.PMBLGoodsCodeDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PMBLGOODSCODEDERIVNORF"));
                blCodeChangeWork.SFBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SFBLGOODSCODERF"));
                blCodeChangeWork.SFBLGoodsCodeDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SFBLGOODSCODEDERIVNORF"));
                blCodeChangeWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                blCodeChangeWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
                # endregion
            }
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� BLGoodsCdChgUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="blCodeChangeWork">BLGoodsCdChgUWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer :�g�� �F�� 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private int CopyToListForSearch(ref SqlDataReader myReader, out ArrayList blCodeChangeWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            blCodeChangeWorkList = new ArrayList();
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
            //���Ӑ�R�[�h
            int colIndex_CustomerCode = 0;

            //PM��BL���i�R�[�h
            int colIndex_PMBLGoodsCode = 0;
            //PM��BL���i�R�[�h�}��
            int colIndex_PMBLGoodsCodeDerivNo = 0;
            //SF��BL���i�R�[�h
            int colIndex_SFBLGoodsCode = 0;
            //SF��BL���i�R�[�h�}��
            int colIndex_SFBLGoodsCodeDerivNo = 0;
            //BL���i�R�[�h���́i�S�p�j
            int colIndex_BLGoodsFullName = 0;
            //BL���i�R�[�h���́i���p�j
            int colIndex_BLGoodsHalfName = 0;

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
                //���Ӑ�R�[�h
                colIndex_CustomerCode = myReader.GetOrdinal("CUSTOMERCODERF");

                //PM��BL���i�R�[�h
                colIndex_PMBLGoodsCode = myReader.GetOrdinal("PMBLGOODSCODERF");
                //PM��BL���i�R�[�h�}��
                colIndex_PMBLGoodsCodeDerivNo = myReader.GetOrdinal("PMBLGOODSCODEDERIVNORF");
                //SF��BL���i�R�[�h
                colIndex_SFBLGoodsCode = myReader.GetOrdinal("SFBLGOODSCODERF");
                //SF��BL���i�R�[�h�}��
                colIndex_SFBLGoodsCodeDerivNo = myReader.GetOrdinal("SFBLGOODSCODEDERIVNORF");
                //BL���i�R�[�h���́i�S�p�j
                colIndex_BLGoodsFullName = myReader.GetOrdinal("BLGOODSFULLNAMERF");
                //BL���i�R�[�h���́i���p�j
                colIndex_BLGoodsHalfName = myReader.GetOrdinal("BLGOODSHALFNAMERF");
            }
            while (myReader.Read())
            {
                BLGoodsCdChgUWork blCodeChangeWork = new BLGoodsCdChgUWork();
                //�쐬����
                blCodeChangeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                //�X�V����
                blCodeChangeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                //��ƃR�[�h
                blCodeChangeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, colIndex_EnterpriseCode);
                //GUID
                blCodeChangeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, colIndex_FileHeaderGuid);
                //�X�V�]�ƈ��R�[�h
                blCodeChangeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, colIndex_UpdEmployeeCode);
                //�X�V�A�Z���u��ID1
                blCodeChangeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, colIndex_UpdAssemblyId1);
                //�X�V�A�Z���u��ID2
                blCodeChangeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, colIndex_UpdAssemblyId2);
                //�_���폜�敪
                blCodeChangeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                //���_�R�[�h
                blCodeChangeWork.SectionCode = SqlDataMediator.SqlGetString(myReader, colIndex_SectionCode);
                //���Ӑ�R�[�h
                blCodeChangeWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_CustomerCode);

                //PM��BL���i�R�[�h
                blCodeChangeWork.PMBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_PMBLGoodsCode);
                //PM��BL���i�R�[�h�}��
                blCodeChangeWork.PMBLGoodsCodeDerivNo = SqlDataMediator.SqlGetInt32(myReader, colIndex_PMBLGoodsCodeDerivNo);
                //SF��BL���i�R�[�h
                blCodeChangeWork.SFBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_SFBLGoodsCode);
                //SF��BL���i�R�[�h�}��
                blCodeChangeWork.SFBLGoodsCodeDerivNo = SqlDataMediator.SqlGetInt32(myReader, colIndex_SFBLGoodsCodeDerivNo);
                //BL���i�R�[�h���́i�S�p�j
                blCodeChangeWork.BLGoodsFullName= SqlDataMediator.SqlGetString(myReader, colIndex_BLGoodsFullName);
                //BL���i�R�[�h���́i���p�j
                blCodeChangeWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, colIndex_BLGoodsHalfName);
                
                blCodeChangeWorkList.Add(blCodeChangeWork);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            if (blCodeChangeWorkList.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            return status;
        }
        # endregion

        #endregion

    }
}
