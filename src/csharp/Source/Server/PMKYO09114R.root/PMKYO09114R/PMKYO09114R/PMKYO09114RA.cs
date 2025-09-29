//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���_�Ǘ���Ɛݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ���_�Ǘ��ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/03/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ��ƃR�[�h�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��ƃR�[�h�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.3.27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class EnterpriseSetDB : RemoteDB, IEnterpriseSetDB
    {
        /// <summary>
        /// ��ƃR�[�h�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        /// </remarks>
        public EnterpriseSetDB()
            : base("PMKYO09116D", "Broadleaf.Application.Remoting.ParamData.SecMngEpSetWork", "ENTERPRISESET")
        {

        }

        # region [Delete]
        /// <summary>
        /// ��ƃR�[�h�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">SecMngEpSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��ƃR�[�h�}�X�^�̃L�[�l����v�����ƃR�[�h�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        public int Delete(ref object parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // XML�̓ǂݍ���
                //SecMngEpSetWork enterpriseSetWork = (SecMngEpSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngEpSetWork));
                SecMngEpSetWork enterpriseSetWork = parabyte as SecMngEpSetWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(ref enterpriseSetWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EnterpriseSetDB.Delete(byte[])", status);
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
        /// ��ƃR�[�h�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="enterpriseSetWork">��ƃR�[�h�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : enterpriseSetList �Ɋi�[����Ă����ƃR�[�h�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        public int Delete(ref SecMngEpSetWork enterpriseSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(ref enterpriseSetWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ��ƃR�[�h�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="enterpriseSetWork">��ƃR�[�h�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : enterpriseSetList �Ɋi�[����Ă����ƃR�[�h�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        private int DeleteProc(ref SecMngEpSetWork enterpriseSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (enterpriseSetWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SECMNGEPSETRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.EnterpriseCode);
                    findSectionCode.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != enterpriseSetWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        # region [DELETE��]
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  SECMNGEPSETRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.EnterpriseCode);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.SectionCode);
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

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "EnterpriseSetDB.DeleteProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "EnterpriseSetDB.DeleteProc" + status);
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
        # endregion

        # region [Search]
        /// <summary>
        /// ��ƃR�[�h�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outenterpriseSetList">��������</param>
        /// <param name="paraenterpriseSetWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��ƃR�[�h�}�X�^�̃L�[�l����v����A�S�Ă̊�ƃR�[�h�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        public int Search(out object outenterpriseSetList, object paraenterpriseSetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList _enterpriseList = null;
            SecMngEpSetWork enterpriseSetWork = null;

            outenterpriseSetList = new CustomSerializeArrayList();

            try
            {
                if (paraenterpriseSetWork is SecMngEpSetWork)
                {
                    enterpriseSetWork = paraenterpriseSetWork as SecMngEpSetWork;
                }
                else if (paraenterpriseSetWork is ArrayList)
                {
                    if ((paraenterpriseSetWork as ArrayList).Count > 0)
                    {
                        enterpriseSetWork = (paraenterpriseSetWork as ArrayList)[0] as SecMngEpSetWork;
                    }
                }

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(out _enterpriseList, enterpriseSetWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);

                if (_enterpriseList != null)
                {
                    (outenterpriseSetList as CustomSerializeArrayList).AddRange(_enterpriseList);
                }

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EnterpriseSetDB.Search(out object, object, int, LogicalMode)", status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
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
        /// ��ƃR�[�h�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="enterpriseList">��ƃR�[�h�}�X�^�����i�[���� ArrayList</param>
        /// <param name="enterpriseSetWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��ƃR�[�h�}�X�^�̃L�[�l����v����A�S�Ă̊�ƃR�[�h�}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        public int Search(out ArrayList enterpriseList, SecMngEpSetWork enterpriseSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(out enterpriseList, enterpriseSetWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ��ƃR�[�h�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="enterpriseList">��ƃR�[�h�}�X�^�����i�[���� ArrayList</param>
        /// <param name="enterpriseSetWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��ƃR�[�h�}�X�^�̃L�[�l����v����A�S�Ă̊�ƃR�[�h�}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        private int SearchProc(out ArrayList enterpriseList, SecMngEpSetWork enterpriseSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  SUPL.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,SUPL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,SUPL.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.SECTIONCODERF" + Environment.NewLine;
                sqlText += " ,SUPL.PMENTERPRISECODERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SECMNGEPSETRF AS SUPL WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlCommand.CommandText += sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, enterpriseSetWork, logicalMode);
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToEnterpriseSetWorkFromReader(ref myReader));
                }

                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "EnterpriseSetDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "EnterpriseSetDB.SearchProc" + status);
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

            enterpriseList = al;

            return status;

        }

        # endregion

        # region [Write]
        /// <summary>
        /// ��ƃR�[�h�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="enterpriseSetWork">�ǉ��E�X�V�����ƃR�[�h�}�X�^���</param>
        /// <param name="writeMode">�X�V�敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : enterpriseSetWork �Ɋi�[����Ă����ƃR�[�h�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        public int Write(ref object enterpriseSetWork, int writeMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                // XML�̓ǂݍ���
                //SecMngEpSetWork wkEnterpriseSetWork = (SecMngEpSetWork)XmlByteSerializer.Deserialize(enterpriseSetWork, typeof(SecMngEpSetWork));
                SecMngEpSetWork wkEnterpriseSetWork = enterpriseSetWork as SecMngEpSetWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = this.Write(ref wkEnterpriseSetWork, ref sqlConnection, ref sqlTransaction);

                // �߂�l�Z�b�g
                enterpriseSetWork = wkEnterpriseSetWork;

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EnterpriseSetDB.Write(ref object)", status);
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
        /// ��ƃR�[�h�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="enterpriseSetWork">�ǉ��E�X�V�����ƃR�[�h�}�X�^�����i�[����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : enterpriseSetWork �Ɋi�[����Ă����ƃR�[�h�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        public int Write(ref SecMngEpSetWork enterpriseSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref enterpriseSetWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ��ƃR�[�h�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="enterpriseSetWork">�ǉ��E�X�V�����ƃR�[�h�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : enterpriseSetWork �Ɋi�[����Ă����ƃR�[�h�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        private int WriteProc(ref SecMngEpSetWork enterpriseSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            SecMngEpSetWork al = new SecMngEpSetWork();

            try
            {
                if (enterpriseSetWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SECMNGEPSETRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.EnterpriseCode);
                    findSectionCode.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != enterpriseSetWork.UpdateDateTime)
                        {
                            if (enterpriseSetWork.UpdateDateTime == DateTime.MinValue)
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
                        sqlText = string.Empty;
                        sqlText += "UPDATE" + Environment.NewLine;
                        sqlText += "  SECMNGEPSETRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,PMENTERPRISECODERF = @PMENTERPRISECODE" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.EnterpriseCode);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.SectionCode);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)enterpriseSetWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (enterpriseSetWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        # region [INSERT��]
                        sqlText = string.Empty;
                        sqlText += "INSERT INTO SECMNGEPSETRF" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                        sqlText += " ,PMENTERPRISECODERF" + Environment.NewLine;
                        sqlText += ")" + Environment.NewLine;
                        sqlText += "VALUES" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,@SECTIONCODE" + Environment.NewLine;
                        sqlText += " ,@PMENTERPRISECODE" + Environment.NewLine;
                        sqlText += ")" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // �o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)enterpriseSetWork;
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
                    SqlParameter paraPmEnterpriseCode = sqlCommand.Parameters.Add("@PMENTERPRISECODE", SqlDbType.NChar);
                    # endregion

                    # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(enterpriseSetWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(enterpriseSetWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(enterpriseSetWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(enterpriseSetWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.SectionCode);
                    paraPmEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.PmEnterpriseCode);

                    # endregion

                    sqlCommand.ExecuteNonQuery();
                    al = enterpriseSetWork;

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "EnterpriseSetDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "EnterpriseSetDB.Write" + status);
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

            enterpriseSetWork = al;

            return status;
        }

        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// ��ƃR�[�h�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="enterpriseSetWork">�_���폜�����ƃR�[�h�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : enterpriseSetWork �Ɋi�[����Ă����ƃR�[�h�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        public int LogicalDelete(ref object enterpriseSetWork)
        {
            return this.LogicalDeleteProc(ref enterpriseSetWork, 0);
        }

        /// <summary>
        /// ��ƃR�[�h�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="enterpriseSetWork">�_���폜�����������ƃR�[�h�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : enterpriseSetWork �Ɋi�[����Ă����ƃR�[�h�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2008.4.24</br>
        public int RevivalLogicalDelete(ref object enterpriseSetWork)
        {
            return this.LogicalDeleteProc(ref enterpriseSetWork, 1);
        }

        /// <summary>
        /// ��ƃR�[�h�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="enterpriseSetWork">�_���폜�𑀍삷���ƃR�[�h�}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : enterpriseSetWork �Ɋi�[����Ă����ƃR�[�h�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        private int LogicalDeleteProc(ref object enterpriseSetWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // XML�̓ǂݍ���
                //SecMngEpSetWork paraList = (SecMngEpSetWork)XmlByteSerializer.Deserialize(enterpriseSetWork, typeof(SecMngEpSetWork));
                SecMngEpSetWork paraList = enterpriseSetWork as SecMngEpSetWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                enterpriseSetWork = paraList;

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EnterpriseSetDB.LogicalDelete(ref object, int[" + procMode.ToString() + "])", status);
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
        /// ��ƃR�[�h�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="enterpriseSetWork">�_���폜�𑀍삷���ƃR�[�h�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : enterpriseSetWork �Ɋi�[����Ă����ƃR�[�h�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        public int LogicalDelete(ref SecMngEpSetWork enterpriseSetWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref enterpriseSetWork, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ��ƃR�[�h�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="enterpriseSetWork">�_���폜�𑀍삷���ƃR�[�h�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : enterpriseSetWork �Ɋi�[����Ă����ƃR�[�h�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        private int LogicalDeleteProc(ref SecMngEpSetWork enterpriseSetWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (enterpriseSetWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "SECMNGEPSETRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.EnterpriseCode);
                    findSectionCode.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != enterpriseSetWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // ���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        # region [UPDATE��]
                        sqlText = string.Empty;
                        sqlText += "UPDATE" + Environment.NewLine;
                        sqlText += "  SECMNGEPSETRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.EnterpriseCode);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.SectionCode);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)enterpriseSetWork;
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

                    // �_���폜���[�h�̏ꍇ
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // ���ɍ폜�ς݂̏ꍇ����
                            return status;
                        }
                        else if (logicalDelCd == 0) enterpriseSetWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                        else enterpriseSetWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            enterpriseSetWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
                        }
                        else
                        {
                            if (logicalDelCd == 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // ���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  // ���S�폜�̓f�[�^�Ȃ���߂�
                            }

                            return status;
                        }
                    }

                    // Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(enterpriseSetWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(enterpriseSetWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                    al.Add(enterpriseSetWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "EnterpriseSetDB.LogicalDelete(ref SecMngEpSetWork, ref SqlConnection, ref SqlTransaction)", ex.Number);
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

        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="enterpriseSetWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SecMngEpSetWork enterpriseSetWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // ��ƃR�[�h
            retstring += "  SUPL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseSetWork.EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND SUPL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND SUPL.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            retstring += " ORDER BY" + Environment.NewLine;
            retstring += " SUPL.SECTIONCODERF" + Environment.NewLine;

            return retstring;
        }

        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SecMngEpSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SupplierWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        /// </remarks>
        private SecMngEpSetWork CopyToEnterpriseSetWorkFromReader(ref SqlDataReader myReader)
        {
            SecMngEpSetWork enterpriseSetWork = new SecMngEpSetWork();

            this.CopyToEnterpriseSetWorkFromReader(ref myReader, ref enterpriseSetWork);

            return enterpriseSetWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� SecMngEpSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="enterpriseSetWork">SupplierWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        /// </remarks>
        private void CopyToEnterpriseSetWorkFromReader(ref SqlDataReader myReader, ref SecMngEpSetWork enterpriseSetWork)
        {
            if (myReader != null && enterpriseSetWork != null)
            {
                # region �N���X�֊i�[
                enterpriseSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                enterpriseSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                enterpriseSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                enterpriseSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                enterpriseSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                enterpriseSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                enterpriseSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                enterpriseSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                enterpriseSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                enterpriseSetWork.PmEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMENTERPRISECODERF"));
                # endregion
            }
        }

        # endregion

        # region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
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

        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DB�ɐڑ�����Ă��Ȃ��ꍇ�͂����Őڑ�����
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // �g�����U�N�V�����̐���(�J�n)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
        # endregion
    }
}
