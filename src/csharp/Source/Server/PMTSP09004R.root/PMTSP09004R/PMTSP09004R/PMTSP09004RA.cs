//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : TSP�A�g�}�X�^�ݒ�
// �v���O�����T�v   : TSP�A�g�}�X�^�ݒ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11670305-00  �쐬�S�� : 3H ������
// �� �� �� : 2020/11/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Resources;
using System.Text;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    ///  TSP�A�g�}�X�^�ݒ�@�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : TSP�A�g�}�X�^�ݒ�}�X�^�擾���s���N���X�ł��B</br>
    /// <br>Programmer : 3H ������</br>
    /// <br>Date       : 2020/11/23</br>
    /// <br>�˗��ԍ�   : 11670305-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class TspCprtStDB : RemoteDB, ITspCprtStDB
    {
        #region [�R���X�g���N�^]
        /// <summary>
        ///  TSP�A�g�}�X�^�ݒ�@�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : TSP�A�g�}�X�^�ݒ�@�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public TspCprtStDB()
        {
            // �Ȃ�
        }
        #endregion

        #region [Search����]
        /// <summary>
        /// �w�肳�ꂽ������TSP�A�g�}�X�^�ݒ���LIST�̌�����߂��܂��B
        /// </summary>
        /// <param name="tspCprtStWork">��������</param>
        /// <param name="tspCprtStWorkList">TSP�A�g�}�X�^�ݒ���LIST</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ������TSP�A�g�}�X�^�ݒ���LIST�̌�����߂��܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public int Search(object tspCprtStWork, out object tspCprtStWorkList, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            tspCprtStWorkList = null;
            ArrayList retList = null;
            SqlConnection sqlConnection = null;

            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    // ��������
                    TspCprtStWork param = tspCprtStWork as TspCprtStWork;

                    // ����
                    status = SearchProc(param, out retList, logicalMode, ref sqlConnection);
                    // �߂�l�Z�b�g
                    tspCprtStWorkList = retList;
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "TspCprtStDB.Search", status);
                }
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ������TSP�A�g�}�X�^�ݒ���LIST�̌�����߂��܂��B
        /// </summary>
        /// <param name="param">��������</param>
        /// <param name="tspCprtStWorkList">TSP�A�g�}�X�^�ݒ���LIST</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="sqlConnection">�N�G���R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ������TSP�A�g�}�X�^�ݒ���LIST�̌�����߂��܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private int SearchProc(TspCprtStWork param, out ArrayList tspCprtStWorkList, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            tspCprtStWorkList = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            ArrayList al = new ArrayList();

            try
            {
                using (sqlCommand = new SqlCommand("", sqlConnection))
                {
                    // �����N�G���̍쐬
                    string selectSqlText = MakeSelectSqlText(param, logicalMode, ref sqlCommand);
                    sqlCommand.CommandText = selectSqlText;
                    // �����^�C���A�E�g�̐ݒ�(600�b)
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);

                    using (myReader = sqlCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            // �������ʂ̊i�[
                            al.Add(CopyToTspCprtStWorkFromReader(ref myReader));
                        }
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
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "TspCprtStDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TspCprtStDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            tspCprtStWorkList = al;

            return status;
        }

        /// <summary>
        /// �����N�G�����̍쐬
        /// </summary>
        /// <param name="param">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="sqlCommand">�N�G���R�}���h</param>
        /// <returns>�����N�G����</returns>
        /// <remarks>
        /// <br>Note       : �����N�G�����̍쐬</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private string MakeSelectSqlText(TspCprtStWork param, ConstantManagement.LogicalMode logicalMode, ref SqlCommand sqlCommand)
        {
            StringBuilder sqlText = new StringBuilder();
            sqlText.AppendLine(" SELECT ");
            sqlText.AppendLine("  CREATEDATETIMERF ");                      // �쐬����
            sqlText.AppendLine("  ,UPDATEDATETIMERF ");                     // �X�V����
            sqlText.AppendLine("  ,ENTERPRISECODERF ");                     // ��ƃR�[�h
            sqlText.AppendLine("  ,FILEHEADERGUIDRF ");                     // GUID
            sqlText.AppendLine("  ,UPDEMPLOYEECODERF ");                    // �X�V�]�ƈ��R�[�h
            sqlText.AppendLine("  ,UPDASSEMBLYID1RF ");                     // �X�V�A�Z���u��ID1
            sqlText.AppendLine("  ,UPDASSEMBLYID2RF ");                     // �X�V�A�Z���u��ID2
            sqlText.AppendLine("  ,LOGICALDELETECODERF ");                  // �_���폜�敪
            sqlText.AppendLine("  ,CUSTOMERCODERF ");                       // ���Ӑ�R�[�h
            sqlText.AppendLine("  ,SENDCODERF ");                           // ���M�敪
            sqlText.AppendLine("  ,DEBITNSENDCODERF ");                     // �ԓ`���M�敪
            sqlText.AppendLine("  ,SENDENTERPRISECODERF ");                 // ���M��ƃR�[�h
            sqlText.AppendLine(" FROM TSPCPRTRF WITH (READUNCOMMITTED) ");
            // Where��
            sqlText.AppendLine(MakeWhereString(param, logicalMode, ref sqlCommand));

            return sqlText.ToString();
        }

        /// <summary>
        /// ����Where���̍쐬
        /// </summary>
        /// <param name="param">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="sqlCommand">�N�G���R�}���h</param>
        /// <returns>����Where��</returns>
        /// <remarks>
        /// <br>Note       : ����Where���̍쐬</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private string MakeWhereString(TspCprtStWork param, ConstantManagement.LogicalMode logicalMode, ref SqlCommand sqlCommand)
        {
            StringBuilder sqlText = new StringBuilder();

            sqlText.AppendLine(" WHERE ");

            // ��ƃR�[�h
            sqlText.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(param.EnterpriseCode);

            // �_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                   (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                   (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                   (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                sqlText.AppendLine(" AND LOGICALDELETECODERF=@LOGICALDELETECODE ");
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                sqlText.AppendLine(" AND LOGICALDELETECODERF<@LOGICALDELETECODE ");
            }
            SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

            // ���Ӑ�R�[�h
            if (param.CustomerCode > 0)
            {
                sqlText.AppendLine(" AND CUSTOMERCODERF=@CUSTOMERCODE ");
                SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(param.CustomerCode);
            }

            return sqlText.ToString();
        }

        /// <summary>
        /// �������ʂ̊i�[
        /// </summary>
        /// <param name="myReader">���ʃ��[�_</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �������ʂ̊i�[</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private TspCprtStWork CopyToTspCprtStWorkFromReader(ref SqlDataReader myReader)
        {
            TspCprtStWork resultWork = new TspCprtStWork();
            resultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));      // �쐬����
            resultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));      // �X�V����
            resultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));                 // ��ƃR�[�h
            resultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                   // GUID
            resultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));               // �X�V�]�ƈ��R�[�h
            resultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));                 // �X�V�A�Z���u��ID1
            resultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));                 // �X�V�A�Z���u��ID2
            resultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));            // �_���폜�敪
            resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));                      // ���Ӑ�R�[�h
            resultWork.SendCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SENDCODERF"));                              // ���M�敪
            resultWork.DebitNSendCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNSENDCODERF"));                  // �ԓ`���M�敪
            resultWork.SendEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDENTERPRISECODERF")).Trim();  // ���M��ƃR�[�h
            
            return resultWork;
        }
        #endregion

        #region [Write����]
        /// <summary>
        /// TSP�A�g�}�X�^�ݒ����o�^�A�X�V���܂��B
        /// </summary>
        /// <param name="tspCprtStWork">TSP�A�g�}�X�^�ݒ���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : TSP�A�g�}�X�^�ݒ����o�^�A�X�V���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public int Write(ref object tspCprtStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            using (sqlConnection = CreateSqlConnection(true))
            {
                using (sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default))
                {
                    try
                    {
                        // �o�^�f�[�^
                        TspCprtStWork writeWork = tspCprtStWork as TspCprtStWork;

                        // �o�^
                        status = WriteProc(ref writeWork, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            if (sqlTransaction.Connection != null)
                            {
                                sqlTransaction.Rollback();
                            }
                        }
                        //�߂�l�Z�b�g
                        tspCprtStWork = writeWork;
                    }
                    catch (Exception ex)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        base.WriteErrorLog(ex, "TspCprtSDB.Write", status);
                        // ���[���o�b�N
                        if (sqlTransaction.Connection != null)
                        {
                            sqlTransaction.Rollback();
                        }
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// TSP�A�g�}�X�^�ݒ����o�^�A�X�V���܂��B
        /// </summary>
        /// <param name="tspCprtStWork">�o�^�f�[�^</param>
        /// <param name="sqlConnection">�N�G���R�l�N�V����</param>
        /// <param name="sqlTransaction">�N�G���g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : TSP�A�g�}�X�^�ݒ����o�^�A�X�V���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private int WriteProc(ref TspCprtStWork tspCprtStWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (tspCprtStWork != null)
                {
                    using (sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
                    {
                        string sqlText = string.Empty;

                        // �r���p�����N�G��
                        sqlText = MakeSelectSqlTextBeforeUpdateDB(tspCprtStWork, ref sqlCommand);

                        sqlCommand.CommandText = sqlText.ToString();
                        using (myReader = sqlCommand.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                                DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF")); //�X�V����
                                if (updateDateTime != tspCprtStWork.UpdateDateTime)
                                {
                                    // �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                    if (tspCprtStWork.UpdateDateTime == DateTime.MinValue)
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                    }
                                    // �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                    else
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                    }
                                    return status;
                                }

                                #region �X�V����SQL������
                                sqlText = MakeUpdateSqlText();
                                #endregion

                                // KEY�R�}���h���Đݒ�(WHERE�����p)
                                // ��ƃR�[�h
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@UPDATEENTERPRISECODE", SqlDbType.NChar);
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tspCprtStWork.EnterpriseCode);

                                // ���Ӑ�R�[�h
                                SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@UPDATECUSTOMERCODE", SqlDbType.Int);
                                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(tspCprtStWork.CustomerCode);

                                sqlCommand.CommandText = sqlText;

                                // �X�V�w�b�_����ݒ�
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)tspCprtStWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);
                            }
                            else
                            {
                                // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                                if (tspCprtStWork.UpdateDateTime > DateTime.MinValue)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                    return status;
                                }

                                #region �V�K�쐬����SQL���𐶐�
                                sqlText = MakeInsertSqlText();
                                #endregion

                                sqlCommand.CommandText = sqlText;

                                // �o�^�w�b�_����ݒ�
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)tspCprtStWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);
                            }
                        }

                        #region Parameter�I�u�W�F�N�g�̍쐬�ƒl�ݒ�
                        SetParameterForUpdateDB(tspCprtStWork, ref sqlCommand);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "TspCprtStDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "TspCprtStDB.WriteProc", status);
            }

            return status;
        }

        /// <summary>
        /// �r���p�����N�G�����̍쐬
        /// </summary>
        /// <param name="param">��������</param>
        /// <param name="sqlCommand">�N�G���R�}���h</param>
        /// <returns>�r���p�����N�G����</returns>
        /// <remarks>
        /// <br>Note       : �r���p�����N�G�����̍쐬</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private string MakeSelectSqlTextBeforeUpdateDB(TspCprtStWork param, ref SqlCommand sqlCommand)
        {
            string sqlText = "SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM TSPCPRTRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";

            // ��ƃR�[�h
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(param.EnterpriseCode);

            // ���Ӑ�R�[�h
            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(param.CustomerCode);

            return sqlText;
        }

        /// <summary>
        /// �X�V�N�G�����̍쐬
        /// </summary>
        /// <returns>�X�V�N�G����</returns>
        /// <remarks>
        /// <br>Note       : �X�V�N�G�����̍쐬</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private string MakeUpdateSqlText()
        {
            StringBuilder sqlText = new StringBuilder();

            sqlText.AppendLine(" UPDATE TSPCPRTRF SET ");
            sqlText.AppendLine(" CREATEDATETIMERF=@CREATEDATETIME ");                 // �쐬����
            sqlText.AppendLine(" ,UPDATEDATETIMERF=@UPDATEDATETIME ");                // �X�V����
            sqlText.AppendLine(" ,ENTERPRISECODERF=@ENTERPRISECODE ");                // ��ƃR�[�h
            sqlText.AppendLine(" ,FILEHEADERGUIDRF=@FILEHEADERGUID ");                // GUID
            sqlText.AppendLine(" ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE ");              // �X�V�]�ƈ��R�[�h
            sqlText.AppendLine(" ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1 ");                // �X�V�A�Z���u��ID1
            sqlText.AppendLine(" ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2 ");                // �X�V�A�Z���u��ID2
            sqlText.AppendLine(" ,LOGICALDELETECODERF=@LOGICALDELETECODE ");          // �_���폜�敪
            sqlText.AppendLine(" ,CUSTOMERCODERF=@CUSTOMERCODE ");                    // ���Ӑ�R�[�h
            sqlText.AppendLine(" ,SENDCODERF=@SENDCODE ");                            // ���M�敪
            sqlText.AppendLine(" ,DEBITNSENDCODERF=@DEBITNSENDCODE ");                // �ԓ`���M�敪
            sqlText.AppendLine(" ,SENDENTERPRISECODERF=@SENDENTERPRISECODE ");        // ���M��ƃR�[�h
            sqlText.AppendLine(" WHERE ENTERPRISECODERF=@UPDATEENTERPRISECODE ");
            sqlText.AppendLine(" AND CUSTOMERCODERF=@UPDATECUSTOMERCODE ");

            return sqlText.ToString();
        }

        /// <summary>
        /// �V�K�N�G�����̍쐬
        /// </summary>
        /// <returns>�V�K�N�G����</returns>
        /// <remarks>
        /// <br>Note       : �V�K�N�G�����̍쐬</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private string MakeInsertSqlText()
        {
            StringBuilder sqlText = new StringBuilder();

            sqlText.AppendLine(" INSERT INTO TSPCPRTRF ( ");
            sqlText.AppendLine(" CREATEDATETIMERF ");                  // �쐬����
            sqlText.AppendLine(" ,UPDATEDATETIMERF ");                 // �X�V����
            sqlText.AppendLine(" ,ENTERPRISECODERF ");                 // ��ƃR�[�h
            sqlText.AppendLine(" ,FILEHEADERGUIDRF ");                 // GUID
            sqlText.AppendLine(" ,UPDEMPLOYEECODERF ");                // �X�V�]�ƈ��R�[�h
            sqlText.AppendLine(" ,UPDASSEMBLYID1RF ");                 // �X�V�A�Z���u��ID1
            sqlText.AppendLine(" ,UPDASSEMBLYID2RF ");                 // �X�V�A�Z���u��ID2
            sqlText.AppendLine(" ,LOGICALDELETECODERF ");              // �_���폜�敪
            sqlText.AppendLine(" ,CUSTOMERCODERF ");                   // ���Ӑ�R�[�h
            sqlText.AppendLine(" ,SENDCODERF ");                       // ���M�敪
            sqlText.AppendLine(" ,DEBITNSENDCODERF ");                 // �ԓ`���M�敪
            sqlText.AppendLine(" ,SENDENTERPRISECODERF ");             // ���M��ƃR�[�h
            sqlText.AppendLine(" ) VALUES ( ");
            sqlText.AppendLine(" @CREATEDATETIME ");                   // �쐬����
            sqlText.AppendLine(" ,@UPDATEDATETIME ");                  // �X�V����
            sqlText.AppendLine(" ,@ENTERPRISECODE ");                  // ��ƃR�[�h
            sqlText.AppendLine(" ,@FILEHEADERGUID ");                  // GUID
            sqlText.AppendLine(" ,@UPDEMPLOYEECODE ");                 // �X�V�]�ƈ��R�[�h
            sqlText.AppendLine(" ,@UPDASSEMBLYID1 ");                  // �X�V�A�Z���u��ID1
            sqlText.AppendLine(" ,@UPDASSEMBLYID2 ");                  // �X�V�A�Z���u��ID2
            sqlText.AppendLine(" ,@LOGICALDELETECODE ");               // �_���폜�敪
            sqlText.AppendLine(" ,@CUSTOMERCODE ");                    // ���Ӑ�R�[�h
            sqlText.AppendLine(" ,@SENDCODE ");                        // ���M�敪
            sqlText.AppendLine(" ,@DEBITNSENDCODE ");                  // �ԓ`���M�敪
            sqlText.AppendLine(" ,@SENDENTERPRISECODE ");              // ���M��ƃR�[�h
            sqlText.AppendLine(" ) ");

            return sqlText.ToString();
        }

        /// <summary>
        /// �X�VDB�p�R�}���h�p�����[�^�̍쐬
        /// </summary>
        /// <param name="param">�X�V�f�[�^</param>
        /// <param name="sqlCommand">�N�G���R�}���h</param>
        /// <remarks>
        /// <br>Note       : �X�VDB�p�R�}���h�p�����[�^�̍쐬</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void SetParameterForUpdateDB(TspCprtStWork param, ref SqlCommand sqlCommand)
        {
            #region Parameter�I�u�W�F�N�g�̍쐬
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
            SqlParameter paraSendCode = sqlCommand.Parameters.Add("@SENDCODE", SqlDbType.Int);
            SqlParameter paraDebitNSendCode = sqlCommand.Parameters.Add("@DEBITNSENDCODE", SqlDbType.Int);
            SqlParameter paraSendEnterpriseCode = sqlCommand.Parameters.Add("@SENDENTERPRISECODE", SqlDbType.NChar);
            #endregion

            #region Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(param.CreateDateTime);          // �쐬����
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(param.UpdateDateTime);          // �X�V����
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(param.EnterpriseCode);                     // ��ƃR�[�h
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(param.FileHeaderGuid);                       // GUID
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(param.UpdEmployeeCode);                   // �X�V�]�ƈ��R�[�h
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(param.UpdAssemblyId1);                     // �X�V�A�Z���u��ID1
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(param.UpdAssemblyId2);                     // �X�V�A�Z���u��ID2
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(param.LogicalDeleteCode);                // �_���폜�敪
            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(param.CustomerCode);                          // ���Ӑ�R�[�h
            paraSendCode.Value = SqlDataMediator.SqlSetInt32(param.SendCode);                                  // ���M�敪
            paraDebitNSendCode.Value = SqlDataMediator.SqlSetInt32(param.DebitNSendCode);                      // �ԓ`���M�敪
            paraSendEnterpriseCode.Value = SqlDataMediator.SqlSetString(param.SendEnterpriseCode);             // ���M��ƃR�[�h
            #endregion
        }
        #endregion

        #region [Delete����]
        /// <summary>
        /// TSP�A�g�}�X�^�ݒ�������S�폜���܂��B
        /// </summary>
        /// <param name="tspCprtStWork">TSP�A�g�}�X�^�ݒ���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : TSP�A�g�}�X�^�ݒ�������S�폜���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public int Delete(object tspCprtStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            using (sqlConnection = CreateSqlConnection(true))
            {
                using (sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default))
                {
                    try
                    {
                        // �폜�f�[�^
                        TspCprtStWork deleteWork = tspCprtStWork as TspCprtStWork;

                        // �폜
                        status = DeleteProc(deleteWork, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            if (sqlTransaction.Connection != null)
                            {
                                sqlTransaction.Rollback();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        base.WriteErrorLog(ex, "tspCprtStDB.Delete", status);
                        // ���[���o�b�N
                        if (sqlTransaction.Connection != null)
                        {
                            sqlTransaction.Rollback();
                        }
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// TSP�A�g�}�X�^�ݒ�������S�폜���܂��B
        /// </summary>
        /// <param name="tspCprtStWork">�폜�f�[�^</param>
        /// <param name="sqlConnection">�N�G���R�l�N�V����</param>
        /// <param name="sqlTransaction">�N�G���g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : TSP�A�g�}�X�^�ݒ�������S�폜���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private int DeleteProc(TspCprtStWork tspCprtStWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (tspCprtStWork != null)
                {
                    using (sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
                    {
                        string sqlText = string.Empty;

                        // �r���p�����N�G��
                        sqlText = MakeSelectSqlTextBeforeUpdateDB(tspCprtStWork, ref sqlCommand);

                        sqlCommand.CommandText = sqlText.ToString();
                        using (myReader = sqlCommand.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                                DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF")); //�X�V����
                                if (updateDateTime != tspCprtStWork.UpdateDateTime)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                    return status;
                                }

                                #region �폜����SQL������
                                sqlText = "DELETE FROM TSPCPRTRF WHERE ENTERPRISECODERF=@DELENTERPRISECODE AND CUSTOMERCODERF=@DELCUSTOMERCODE";
                                #endregion

                                // KEY�R�}���h���Đݒ�(WHERE�����p)
                                // ��ƃR�[�h
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tspCprtStWork.EnterpriseCode);

                                // ���Ӑ�R�[�h
                                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@DELCUSTOMERCODE", SqlDbType.Int);
                                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(tspCprtStWork.CustomerCode);

                                sqlCommand.CommandText = sqlText;
                            }
                            else
                            {
                                //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }
                        }

                        sqlCommand.ExecuteNonQuery();
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "TspCprtStDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "TspCprtStDB.WriteProc", status);
            }

            return status;
        }
        #endregion

        #region [LogicalDelete����]
        /// <summary>
        /// TSP�A�g�}�X�^�ݒ����_���폜���܂��B
        /// </summary>
        /// <param name="tspCprtStWork">TSP�A�g�}�X�^�ݒ���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : TSP�A�g�}�X�^�ݒ����_���폜���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public int LogicalDelete(ref object tspCprtStWork)
        {
            // �_���폜
            return LogicalDeleteOrRelive(ref tspCprtStWork, 0);
        }
        #endregion

        #region [Revival����]
        /// <summary>
        /// TSP�A�g�}�X�^�ݒ���𕜊����܂��B
        /// </summary>
        /// <param name="tspCprtStWork">TSP�A�g�}�X�^�ݒ���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : TSP�A�g�}�X�^�ݒ���𕜊����܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public int Revival(ref object tspCprtStWork)
        {
            // ����
            return LogicalDeleteOrRelive(ref tspCprtStWork, 1);
        }

        /// <summary>
        /// TSP�A�g�}�X�^�ݒ����_���폜�A�������܂��B
        /// </summary>
        /// <param name="tspCprtStWork">�X�V�f�[�^</param>
        /// <param name="mode">���[�h�i0:�_���폜 1:�����j</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : TSP�A�g�}�X�^�ݒ����_���폜�A�������܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private int LogicalDeleteOrRelive(ref object tspCprtStWork, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            using (sqlConnection = CreateSqlConnection(true))
            {
                using (sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default))
                {
                    try
                    {
                        // �X�V�f�[�^
                        TspCprtStWork updateWork = tspCprtStWork as TspCprtStWork;

                        // �X�V
                        status = LogicalDeleteOrReliveProc(ref updateWork, mode, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            if (sqlTransaction.Connection != null)
                            {
                                sqlTransaction.Rollback();
                            }
                        }
                        //�߂�l�Z�b�g
                        tspCprtStWork = updateWork;
                    }
                    catch (Exception ex)
                    {
                        string procModestr = mode == 0 ? "LogicalDelete" : "Revival";
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        base.WriteErrorLog(ex, "TspCprtStDB.LogicalDeleteOrRelive: " + procModestr, status);
                        // ���[���o�b�N
                        if (sqlTransaction.Connection != null)
                        {
                            sqlTransaction.Rollback();
                        }
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// TSP�A�g�}�X�^�ݒ����_���폜�A�������܂��B
        /// </summary>
        /// <param name="tspCprtStWork">�X�V�f�[�^</param>
        /// <param name="mode">���[�h�i0:�_���폜 1:�����j</param>
        /// <param name="sqlConnection">�N�G���R�l�N�V����</param>
        /// <param name="sqlTransaction">�N�G���g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : TSP�A�g�}�X�^�ݒ����_���폜�A�������܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private int LogicalDeleteOrReliveProc(ref TspCprtStWork tspCprtStWork, int mode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            int logicalDelCd = 0;
            string procModestr = mode == 0 ? "LogicalDelete" : "Revival";

            try
            {
                if (tspCprtStWork != null)
                {
                    using (sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
                    {
                        string sqlText = string.Empty;

                        // �r���p�����N�G��
                        sqlText = MakeSelectSqlTextBeforeUpdateDB(tspCprtStWork, ref sqlCommand);

                        sqlCommand.CommandText = sqlText.ToString();
                        using (myReader = sqlCommand.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                                DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF")); // �X�V����
                                if (updateDateTime != tspCprtStWork.UpdateDateTime)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                    return status;
                                }

                                // ���݂̘_���폜�敪���擾
                                logicalDelCd =  SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                                #region �X�V����SQL������
                                sqlText = MakeUpdateSqlText();
                                #endregion

                                // KEY�R�}���h���Đݒ�(WHERE�����p)
                                // ��ƃR�[�h
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@UPDATEENTERPRISECODE", SqlDbType.NChar);
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tspCprtStWork.EnterpriseCode);

                                // ���Ӑ�R�[�h
                                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@UPDATECUSTOMERCODE", SqlDbType.Int);
                                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(tspCprtStWork.CustomerCode);

                                sqlCommand.CommandText = sqlText;

                                // �X�V�w�b�_����ݒ�
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)tspCprtStWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);
                            }
                            else
                            {
                                // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }
                        }

                        // �_���폜���[�h�̏ꍇ
                        if (mode == 0)
                        {
                            tspCprtStWork.LogicalDeleteCode = 1; // �_���폜�t���O���Z�b�g
                        }
                        // �������[�h�̏ꍇ
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                tspCprtStWork.LogicalDeleteCode = 0; // �_���폜�t���O������
                            }
                            else
                            {
                                // ���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                if (logicalDelCd == 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND; // ���S�폜�̓f�[�^�Ȃ���߂�
                                }
                                return status;
                            }
                        }

                        #region Parameter�I�u�W�F�N�g�̍쐬�ƒl�ݒ�
                        SetParameterForUpdateDB(tspCprtStWork, ref sqlCommand);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "TspCprtStDB.LogicalDeleteOrReliveProc: " + procModestr, status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "TspCprtStDB.LogicalDeleteOrReliveProcc: " + procModestr, status);
            }

            return status;
        }
        #endregion

        # region [�R�l�N�V������������]

        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Note       : SqlConnection��������</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }
            return retSqlConnection;
        }
        # endregion [�R�l�N�V������������]
    }
}