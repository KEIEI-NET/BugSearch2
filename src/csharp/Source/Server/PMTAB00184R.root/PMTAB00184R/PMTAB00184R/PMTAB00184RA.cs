//**********************************************************************//
// �V�X�e��         �FPM.NS                                             //
// �v���O��������   �FPMTAB�A�b�v���[�h�r�����䌟���}�X�^DBRemoteObject // 
// �v���O�����T�v   �FPMTAB�A�b�v���[�h�r�����䌟���}�X�^DBRemoteObject //
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����                                                                 //
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �A����                              //
// �� �� ��  2013/06/24  �쐬���e : �V�K�쐬                            //
//----------------------------------------------------------------------//
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMTAB�A�b�v���[�h�r�����䌟���}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTAB�A�b�v���[�h�r�����䌟���}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �A���� </br>
    /// <br>Date       : 2013/06/24</br>  
    /// </remarks>
    [Serializable]
    public class PmTabUpldExclsvDB : RemoteDB, IPmTabUpldExclsvDB
    {
        /// <summary>
        /// PMTAB�A�b�v���[�h�r�����䌟���}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �A���� </br>
        /// <br>Date       : 2013/06/24</br>
        /// </remarks>
        public PmTabUpldExclsvDB()
            :
            base("PMTAB00186D", "Broadleaf.Application.Remoting.ParamData.PmTabUpldExclsvWork", "PMTABUPLDEXCLSVRF")
        {
        }

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽPM�A�b�v���[�h�r������Guid��PM�A�b�v���[�h�r�������߂��܂�
        /// </summary>
        /// <param name="parabyte">PMEmployeeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        public int Read(ref object parabyte, int readMode)
        {
            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                sqlConnection.Open();

                PmTabUpldExclsvWork pmTabUpldExclsvWork = parabyte as PmTabUpldExclsvWork;

                return ReadProc(ref pmTabUpldExclsvWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PmTabUpldExclsvDB.Read Exception = " + ex.Message);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                DisposeSqlConnection(ref sqlConnection);
            }
        }

        /// <summary>
        /// �w�肳�ꂽPM�A�b�v���[�h�r������Guid��PM�A�b�v���[�h�r�������߂��܂�
        /// </summary>
        /// <param name="pmTabUpldExclsvWork">PMEmployeeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        private int ReadProc(ref PmTabUpldExclsvWork pmTabUpldExclsvWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlText = new StringBuilder();

                sqlText.Append("SELECT" + Environment.NewLine);
                sqlText.Append("CREATEDATETIMERF" + Environment.NewLine);
                sqlText.Append(", UPDATEDATETIMERF" + Environment.NewLine);
                sqlText.Append(", ENTERPRISECODERF" + Environment.NewLine);
                sqlText.Append(", FILEHEADERGUIDRF" + Environment.NewLine);
                sqlText.Append(", UPDEMPLOYEECODERF" + Environment.NewLine);
                sqlText.Append(", UPDASSEMBLYID1RF" + Environment.NewLine);
                sqlText.Append(", UPDASSEMBLYID2RF" + Environment.NewLine);
                sqlText.Append(", LOGICALDELETECODERF" + Environment.NewLine);
                sqlText.Append(", SECTIONCODERF" + Environment.NewLine);
                sqlText.Append(", CLIENTMULTICASTVERRF" + Environment.NewLine);
                sqlText.Append(", UPLOADPROCESSDIVCDRF" + Environment.NewLine);
                sqlText.Append("FROM" + Environment.NewLine);
                sqlText.Append("  PMTABUPLDEXCLSVRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append("WHERE" + Environment.NewLine);
                sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine);
                sqlText.Append("  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine);
                sqlText.Append("  AND CLIENTMULTICASTVERRF=@FINDCLIENTMULTICASTVER" + Environment.NewLine);

                // Select�R�}���h�̐���
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectioncode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaClientMultiCastver = sqlCommand.Parameters.Add("@FINDCLIENTMULTICASTVER", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.EnterpriseCode);
                findParaSectioncode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.SectionCode);
                findParaClientMultiCastver.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.ClientMulticastVer);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (myReader.Read())
                {
                    pmTabUpldExclsvWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    pmTabUpldExclsvWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    pmTabUpldExclsvWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    pmTabUpldExclsvWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    pmTabUpldExclsvWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    pmTabUpldExclsvWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    pmTabUpldExclsvWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    pmTabUpldExclsvWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    pmTabUpldExclsvWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    pmTabUpldExclsvWork.ClientMulticastVer = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLIENTMULTICASTVERRF"));
                    pmTabUpldExclsvWork.UploadProcessDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPLOADPROCESSDIVCDRF"));
                    
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                }
            }

            return status;
        }
        #endregion [Read]

        #region [Write]
        /// <summary>
        /// PM�A�b�v���[�h�r���������o�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraobj">PMEmployeeWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PM�A�b�v���[�h�r���������o�^�A�X�V���܂�</br>
        /// <br>Programmer : 22011 Kashihara</br>
        /// <br>Date       : 2013.05.28</br>
        public int Write(ref object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                PmTabUpldExclsvWork pmTabUpldExclsvWork =  paraobj as PmTabUpldExclsvWork;
                status = WriteProc(pmTabUpldExclsvWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PmTabUpldExclsvDB.Write:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // ���R�l�N�V�����j��
                if (sqlConnection.State == ConnectionState.Open)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        // ���R�~�b�gor���[���o�b�N
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            sqlTransaction.Commit();
                        else
                            sqlTransaction.Rollback();
                    }
                    DisposeSqlConnection(ref sqlConnection);
                }
            }
            return status;
        }

        /// <summary>
        /// PM�A�b�v���[�h�r���������o�^�A�X�V���܂�
        /// </summary>
        /// <param name="pmTabUpldExclsvWork">pmemployeeWork</param>
        /// <param name="sqlConnection">Sql�ڑ����</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        private int WriteProc(PmTabUpldExclsvWork pmTabUpldExclsvWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            
            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlText.Append("SELECT" + Environment.NewLine);
                sqlText.Append(" UPDATEDATETIMERF" + Environment.NewLine);
                sqlText.Append(" FROM" + Environment.NewLine);
                sqlText.Append(" PMTABUPLDEXCLSVRF" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine);
                sqlText.Append(" AND CLIENTMULTICASTVERRF=@FINDCLIENTMULTICASTVER" + Environment.NewLine);
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectioncode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaClientMultiCastver = sqlCommand.Parameters.Add("@FINDCLIENTMULTICASTVER", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.EnterpriseCode);
                findParaSectioncode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.SectionCode);
                findParaClientMultiCastver.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.ClientMulticastVer);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != pmTabUpldExclsvWork.UpdateDateTime)
                    {
                        //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                        if (pmTabUpldExclsvWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                        //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                        else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        myReader.Close();
                        return status;
                    }

                    # region [UPDATE��]
                    sqlText = new StringBuilder();
                    sqlText.Append("UPDATE PMTABUPLDEXCLSVRF" + Environment.NewLine);
                    sqlText.Append(" SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine);
                    sqlText.Append(" ,UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine);
                    sqlText.Append(" ,ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine);
                    sqlText.Append(" ,FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine);
                    sqlText.Append(" ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine);
                    sqlText.Append(" ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine);
                    sqlText.Append(" ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine);
                    sqlText.Append(" ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine);
                    sqlText.Append(" ,SECTIONCODERF=@SECTIONCODE" + Environment.NewLine);
                    sqlText.Append(" ,CLIENTMULTICASTVERRF=@CLIENTMULTICASTVER" + Environment.NewLine);
                    sqlText.Append(" ,UPLOADPROCESSDIVCDRF=@UPLOADPROCESSDIVCD" + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                    sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine);
                    sqlText.Append(" AND CLIENTMULTICASTVERRF=@FINDCLIENTMULTICASTVER" + Environment.NewLine);
                    #endregion

                    sqlCommand.CommandText = sqlText.ToString();

                    //KEY�R�}���h���Đݒ�
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.EnterpriseCode);
                    findParaSectioncode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.SectionCode);
                    findParaClientMultiCastver.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.ClientMulticastVer);

                    //�X�V�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)pmTabUpldExclsvWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    if (pmTabUpldExclsvWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        myReader.Close();
                        return status;
                    }

                    # region [INSERT��]
                    sqlText = new StringBuilder();
                    sqlText.Append("INSERT INTO PMTABUPLDEXCLSVRF" + Environment.NewLine);
                    sqlText.Append("(CREATEDATETIMERF" + Environment.NewLine);
                    sqlText.Append(",UPDATEDATETIMERF" + Environment.NewLine);
                    sqlText.Append(",ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append(",FILEHEADERGUIDRF" + Environment.NewLine);
                    sqlText.Append(",UPDEMPLOYEECODERF" + Environment.NewLine);
                    sqlText.Append(",UPDASSEMBLYID1RF" + Environment.NewLine);
                    sqlText.Append(",UPDASSEMBLYID2RF" + Environment.NewLine);
                    sqlText.Append(",LOGICALDELETECODERF" + Environment.NewLine);
                    sqlText.Append(",SECTIONCODERF" + Environment.NewLine);
                    sqlText.Append(",CLIENTMULTICASTVERRF" + Environment.NewLine);
                    sqlText.Append(",UPLOADPROCESSDIVCDRF)" + Environment.NewLine);
                    sqlText.Append("VALUES" + Environment.NewLine);
                    sqlText.Append(" (@CREATEDATETIME" + Environment.NewLine);
                    sqlText.Append(",@UPDATEDATETIME" + Environment.NewLine);
                    sqlText.Append(",@ENTERPRISECODE" + Environment.NewLine);
                    sqlText.Append(",@FILEHEADERGUID" + Environment.NewLine);
                    sqlText.Append(",@UPDEMPLOYEECODE" + Environment.NewLine);
                    sqlText.Append(",@UPDASSEMBLYID1" + Environment.NewLine);
                    sqlText.Append(",@UPDASSEMBLYID2" + Environment.NewLine);
                    sqlText.Append(",@LOGICALDELETECODE" + Environment.NewLine);
                    sqlText.Append(",@SECTIONCODE" + Environment.NewLine);
                    sqlText.Append(",@CLIENTMULTICASTVER" + Environment.NewLine);
                    sqlText.Append(",@UPLOADPROCESSDIVCD)" + Environment.NewLine);
                    #endregion

                    //�V�K�쐬����SQL���𐶐�
                    sqlCommand.CommandText = sqlText.ToString();

                    //�o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)pmTabUpldExclsvWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }
                myReader.Close();

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraClientMulticastVer = sqlCommand.Parameters.Add("@CLIENTMULTICASTVER", SqlDbType.NVarChar);
                SqlParameter paraUploadProcessDivCd = sqlCommand.Parameters.Add("@UPLOADPROCESSDIVCD", SqlDbType.Int);


                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabUpldExclsvWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabUpldExclsvWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(pmTabUpldExclsvWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmTabUpldExclsvWork.LogicalDeleteCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.SectionCode);
                paraClientMulticastVer.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.ClientMulticastVer);
                paraUploadProcessDivCd.Value = SqlDataMediator.SqlSetInt32(pmTabUpldExclsvWork.UploadProcessDivCd);

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PmTabUpldExclsvDB.Write Exception = " + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion [Write]

        #region [Delete]
        /// <summary>
        /// �A�b�v���[�h�r������}�X�^��������
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �A�b�v���[�h�r������}�X�^�𕨗��폜���܂�</br>
        /// <br>Programmer : �A���� </br>
        /// <br>Date       : 2013/06/24</br>
        /// </remarks>
        public int Delete(ref object paraList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string errMsg = string.Empty;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection =CreateSqlConnection();

                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                PmTabUpldExclsvWork pmTabUpldExclsvWork  = paraList as PmTabUpldExclsvWork;
                // Delete����
                status = DeleteProc(pmTabUpldExclsvWork, ref sqlConnection, ref sqlTransaction);
                //����I�����A�R�~�b�g���܂��@���̑��̏ꍇ�A���[���o�b�N���܂�
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
            catch (SqlException ex)
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    errMsg = "�A�b�v���[�h�r�����䌟���̍폜�������Ƀ^�C���A�E�g���������܂����B";
                else
                    errMsg = "�A�b�v���[�h�r�����䌟���̍폜�����Ɏ��s���܂����B";
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();


                status = base.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
            }
            catch (Exception ex)
            {
                errMsg = "�A�b�v���[�h�r�����䌟���̍폜�����Ɏ��s���܂����B";
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                base.WriteErrorLog(ex, errMsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                    sqlTransaction.Dispose();

                DisposeSqlConnection(ref sqlConnection);
            }

            return status;
        }

        /// <summary>
        /// �A�b�v���[�h�r������}�X�^�����폜����
        /// </summary>
        /// <param name="pmTabUpldExclsvWork">PmTabUpldExclsvWork</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �A�b�v���[�h�r������}�X�^�𕨗��폜���܂�</br>
        /// <br>Programmer : �A���� </br>
        /// <br>Date       : 2013/06/24</br>
        /// </remarks>
        private int DeleteProc(PmTabUpldExclsvWork pmTabUpldExclsvWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                //Select�R�}���h�̐���
                #region [SELECT��]
                sqlText.Append("SELECT" + Environment.NewLine);
                sqlText.Append(" UPDATEDATETIMERF" + Environment.NewLine);
                sqlText.Append(" FROM" + Environment.NewLine);
                sqlText.Append(" PMTABUPLDEXCLSVRF" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                sqlText.Append("AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine);
                sqlText.Append("AND CLIENTMULTICASTVERRF=@FINDCLIENTMULTICASTVER" + Environment.NewLine);

                sqlCommand.CommandText = sqlText.ToString();
                #endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                sqlCommand.Parameters.Clear();
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectioncode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaClientMultiCastver = sqlCommand.Parameters.Add("@FINDCLIENTMULTICASTVER", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.EnterpriseCode);
                findParaSectioncode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.SectionCode);
                findParaClientMultiCastver.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.ClientMulticastVer);
                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != pmTabUpldExclsvWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        return status;
                    }

                    //Delete�R�}���h�̐���
                    #region [DELETE��]
                    sqlText = new StringBuilder();
                    sqlText.Append("DELETE" + Environment.NewLine);
                    sqlText.Append(" FROM PMTABUPLDEXCLSVRF" + Environment.NewLine);
                    sqlText.Append(" WHERE" + Environment.NewLine);
                    sqlText.Append("    ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                    sqlText.Append("AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine);
                    sqlText.Append("AND CLIENTMULTICASTVERRF=@FINDCLIENTMULTICASTVER" + Environment.NewLine);

                    sqlCommand.CommandText = sqlText.ToString();
                    #endregion

                    // KEY�R�}���h���Đݒ�
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.EnterpriseCode);
                    findParaSectioncode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.SectionCode);
                    findParaClientMultiCastver.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.ClientMulticastVer);
                }
                else
                {
                    // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                    if ((myReader != null) && (!myReader.IsClosed))
                    {
                        myReader.Close();
                        myReader.Dispose();
                    }

                    return status;
                }

                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                if ((myReader != null) && (!myReader.IsClosed))
                {
                    myReader.Close();
                    myReader.Dispose();
                }

                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "�A�b�v���[�h�r������}�X�^�̕����폜�Ɏ��s���܂����B", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "�A�b�v���[�h�r������}�X�^�̕����폜�Ɏ��s���܂����B", status);
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
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
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

        /// <summary>
        /// SQL�R�l�N�V������j�����܂�
        /// </summary>
        /// <param name="sqlConnection">�j���Ώۂ�SQL�R�l�N�V����</param>
        private void DisposeSqlConnection(ref SqlConnection sqlConnection)
        {
            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
        

    }
}
