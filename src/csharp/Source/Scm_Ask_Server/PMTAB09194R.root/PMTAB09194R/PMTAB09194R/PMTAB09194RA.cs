//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PMTAB�����\���]�ƈ��ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : PMTAB�����\���]�ƈ��ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/08/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/10/23  �C�����e : ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/10/28  �C�����e : �_���폜�����f�[�^���\������Ȃ����̑Ή�
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
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Data.SqlClient;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMTAB�����\���]�ƈ��ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// </remarks>
    [Serializable]
    public class PmtDefEmpDB : RemoteDB, IPmtDefEmpDB
    {
        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// </remarks>
        public PmtDefEmpDB()
            : base("PMTAB09196D", "Broadleaf.Application.Remoting.ParamData.PmtDefEmpWork", "PmtDefEmpRF")
        {
        }

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
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
        /// SqlTransaction��������
        /// </summary>
        /// <returns>SqlTransaction</returns>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }
        #endregion  //�g�����U�N�V������������

        # region [Read]
        /// <summary>
        /// �P���PMTAB�����\���]�ƈ��ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="pmtDefEmpObj">PmtDefEmpWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̃L�[�l����v����PMTAB�����\���]�ƈ��ݒ�}�X�^�����擾���܂��B</br>
        public int Read(ref object pmtDefEmpObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            try
            {
                PmtDefEmpWork pmtDefEmpWork = pmtDefEmpObj as PmtDefEmpWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = this.Read(ref pmtDefEmpWork, sqlConnection);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// �P���PMTAB�����\���]�ƈ��ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="pmtDefEmpWork">PmtDefEmpWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̃L�[�l����v����PMTAB�����\���]�ƈ��ݒ�}�X�^�����擾���܂��B</br>
        public int Read(ref PmtDefEmpWork pmtDefEmpWork, SqlConnection sqlConnection)
        {
            return this.ReadProc(ref pmtDefEmpWork, sqlConnection);
        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^��񃊃X�g���擾���܂��B
        /// </summary>
        /// <param name="pmtDefEmpObj">���o�������X�g(PmtDefEmpWork)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̃L�[�l����v����PMTAB�����\���]�ƈ��ݒ�}�X�^�����擾���܂��B</br>
        public int ReadAll(ref object pmtDefEmpObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList paraList = pmtDefEmpObj as ArrayList;
                ArrayList pmtDefEmpList = new ArrayList();

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection();

                status = this.ReadAll(ref pmtDefEmpList, paraList, sqlConnection);

                pmtDefEmpObj = pmtDefEmpList;

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
        /// �P���PMTAB�����\���]�ƈ��ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="pmtDefEmpList">���o���ʃ��X�g(PmtDefEmpWork)</param>
        /// <param name="paraList">���o�������X�g(PmtDefEmpWork)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̃L�[�l����v����PMTAB�����\���]�ƈ��ݒ�}�X�^�����擾���܂��B</br>
        public int ReadAll(ref ArrayList pmtDefEmpList, ArrayList paraList, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            foreach (PmtDefEmpWork pmtDefEmpWork in paraList)
            {
                PmtDefEmpWork pararetWork = pmtDefEmpWork;

                status = this.ReadProc(ref pararetWork, sqlConnection);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    pmtDefEmpList.Add(pararetWork);
                }
                else
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        return status;
                    }
            }

            //�����̗L���͊֌W�����ňُ�n�ȊO�̓m�[�}���Ƃ���
            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            return status;
        }

        /// <summary>
        /// �P���PMTAB�����\���]�ƈ��ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="pmtDefEmpWork">PmtDefEmpWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̃L�[�l����v����PMTAB�����\���]�ƈ��ݒ�}�X�^�����擾���܂��B</br>
        private int ReadProc(ref PmtDefEmpWork pmtDefEmpWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sb = new StringBuilder();
                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);

                # region [SELECT��]

                sb.AppendLine("SELECT");
                sb.AppendLine("  CREATEDATETIMERF");            // �쐬����
                sb.AppendLine("  , UPDATEDATETIMERF");          // �X�V����
                sb.AppendLine("  , ENTERPRISECODERF");          // ��ƃR�[�h
                sb.AppendLine("  , FILEHEADERGUIDRF");          // GUID
                sb.AppendLine("  , UPDEMPLOYEECODERF");         // �X�V�]�ƈ��R�[�h
                sb.AppendLine("  , UPDASSEMBLYID1RF");          // �X�V�A�Z���u��ID1
                sb.AppendLine("  , UPDASSEMBLYID2RF");          // �X�V�A�Z���u��ID2
                sb.AppendLine("  , LOGICALDELETECODERF");       // �_���폜�敪
                sb.AppendLine("  , LOGINAGENCODERF");           // ���O�C���S���҃R�[�h
                sb.AppendLine("  , SALESEMPDIVRF");             // �S���ҋ敪
                sb.AppendLine("  , SALESEMPLOYEECDRF");         // �̔��]�ƈ��R�[�h
                sb.AppendLine("  , FRONTEMPDIVRF");             // �󒍎ҋ敪
                sb.AppendLine("  , FRONTEMPLOYEECDRF");         // ��t�]�ƈ��R�[�h
                sb.AppendLine("  , SALESINPUTDIVRF");           // ���s�ҋ敪
                sb.AppendLine("  , SALESINPUTCODERF");          // ������͎҃R�[�h
                sb.AppendLine("FROM");
                sb.AppendLine("  PMTDEFEMPRF ");

                sqlCommand.CommandText = sb.ToString();
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, ref pmtDefEmpWork);

                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToRecieveSecTableWorkFromReader(ref myReader, ref pmtDefEmpWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

        # region [Delete]
        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="pmtDefEmpList">�����폜����PMTAB�����\���]�ƈ��ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̃L�[�l����v����PMTAB�����\���]�ƈ��ݒ�}�X�^���𕨗��폜���܂��B</br>
        public int Delete(object pmtDefEmpList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = pmtDefEmpList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                status = this.Delete(paraList, sqlConnection, sqlTransaction);
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
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="pmtDefEmpList">PMTAB�����\���]�ƈ��ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpList �Ɋi�[����Ă���PMTAB�����\���]�ƈ��ݒ�}�X�^���𕨗��폜���܂��B</br>
        public int Delete(ArrayList pmtDefEmpList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(pmtDefEmpList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="pmtDefEmpList">PMTAB�����\���]�ƈ��ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpList �Ɋi�[����Ă���PMTAB�����\���]�ƈ��ݒ�}�X�^���𕨗��폜���܂��B</br>
        private int DeleteProc(ArrayList pmtDefEmpList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (pmtDefEmpList != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < pmtDefEmpList.Count; i++)
                    {
                        PmtDefEmpWork pmtDefEmpWork = pmtDefEmpList[i] as PmtDefEmpWork;

                        # region [SELECT��]

                        sb.AppendLine("SELECT");
                        sb.AppendLine("  UPDATEDATETIMERF");          // �X�V����
                        sb.AppendLine("FROM");
                        sb.AppendLine("  PMTDEFEMPRF ");

                        sqlCommand.CommandText = sb.ToString();
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, ref pmtDefEmpWork);

                        # endregion

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (pmtDefEmpWork.LoginAgenCode != "" && _updateDateTime != pmtDefEmpWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]

                            sb = new StringBuilder();
                            sb.AppendLine("DELETE FROM");
                            sb.AppendLine("  PMTDEFEMPRF ");

                            bool isWhere = false;
                            if (pmtDefEmpWork.EnterpriseCode != "")
                            {
                                isWhere = true;
                                sb.AppendLine("WHERE");
                                sb.AppendLine("  ENTERPRISECODERF = @DELETEENTERPRISECODE ");

                                sqlCommand.Parameters.Clear();
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter updateParaEnterpriseCode = sqlCommand.Parameters.Add("@DELETEENTERPRISECODE", SqlDbType.NChar);
                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                updateParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.EnterpriseCode);
                            }


                            if (pmtDefEmpWork.LoginAgenCode != "")
                            {
                                if (isWhere)
                                {
                                    sb.AppendLine("  AND LOGINAGENCODERF = @DELETELOGINAGENCODE ");
                                }
                                else
                                {
                                    sb.AppendLine("WHERE");
                                    sb.AppendLine("  LOGINAGENCODERF = @DELETELOGINAGENCODE ");
                                }
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter updateParaDbIdGuid = sqlCommand.Parameters.Add("@DELETELOGINAGENCODE", SqlDbType.NChar);
                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                updateParaDbIdGuid.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.LoginAgenCode);
                            }

                            sqlCommand.CommandText = sb.ToString();

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

                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="pmtDefEmpList">��������</param>
        /// <param name="pmtDefEmpObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̃L�[�l����v����A�S�Ă�PMTAB�����\���]�ƈ��ݒ�}�X�^�����擾���܂��B</br>
        public int Search(ref object pmtDefEmpList, object pmtDefEmpObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            try
            {
                ArrayList pmtDefEmpArray = pmtDefEmpList as ArrayList;
                PmtDefEmpWork pmtDefEmpWork = pmtDefEmpObj as PmtDefEmpWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = this.Search(ref pmtDefEmpArray, pmtDefEmpWork, readMode, logicalMode, sqlConnection);

                if (status == 0)
                {
                    pmtDefEmpList = pmtDefEmpArray as object;
                }
                else
                {
                    ArrayList workArray = new ArrayList();
                    pmtDefEmpList = workArray as object;
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="pmtDefEmpList">PMTAB�����\���]�ƈ��ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="pmtDefEmpWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̃L�[�l����v����A�S�Ă�PMTAB�����\���]�ƈ��ݒ�}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        public int Search(ref ArrayList pmtDefEmpList, PmtDefEmpWork pmtDefEmpWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection)
        {
            return this.SearchProc(ref pmtDefEmpList, pmtDefEmpWork, readMode, logicalMode, sqlConnection);
        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="pmtDefEmpList">PMTAB�����\���]�ƈ��ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="pmtDefEmpWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̃L�[�l����v����A�S�Ă�PMTAB�����\���]�ƈ��ݒ�}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        private int SearchProc(ref ArrayList pmtDefEmpList, PmtDefEmpWork pmtDefEmpWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            pmtDefEmpList = new ArrayList();
            try
            {
                StringBuilder sb = new StringBuilder();
                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);

                # region [SELECT��]

                sb.AppendLine("SELECT");
                sb.AppendLine("  CREATEDATETIMERF");            // �쐬����
                sb.AppendLine("  , UPDATEDATETIMERF");          // �X�V����
                sb.AppendLine("  , ENTERPRISECODERF");          // ��ƃR�[�h
                sb.AppendLine("  , FILEHEADERGUIDRF");          // GUID
                sb.AppendLine("  , UPDEMPLOYEECODERF");         // �X�V�]�ƈ��R�[�h
                sb.AppendLine("  , UPDASSEMBLYID1RF");          // �X�V�A�Z���u��ID1
                sb.AppendLine("  , UPDASSEMBLYID2RF");          // �X�V�A�Z���u��ID2
                sb.AppendLine("  , LOGICALDELETECODERF");       // �_���폜�敪
                sb.AppendLine("  , LOGINAGENCODERF");           // ���O�C���S���҃R�[�h
                sb.AppendLine("  , SALESEMPDIVRF");             // �S���ҋ敪
                sb.AppendLine("  , SALESEMPLOYEECDRF");         // �̔��]�ƈ��R�[�h
                sb.AppendLine("  , FRONTEMPDIVRF");             // �󒍎ҋ敪
                sb.AppendLine("  , FRONTEMPLOYEECDRF");         // ��t�]�ƈ��R�[�h
                sb.AppendLine("  , SALESINPUTDIVRF");           // ���s�ҋ敪
                sb.AppendLine("  , SALESINPUTCODERF");          // ������͎҃R�[�h
                sb.AppendLine("FROM");
                sb.AppendLine("  PMTDEFEMPRF ");

                sqlCommand.CommandText = sb.ToString();
                // DEL 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� --->>>>>>
                //sqlCommand.CommandText += MakeWhereString(ref sqlCommand, ref pmtDefEmpWork);
                // DEL 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� ---<<<<<<
                // ADD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� --->>>>>>
                string str = MakeWhereString(ref sqlCommand, ref pmtDefEmpWork);
                string delFlagSql = string.Empty;
                if (string.IsNullOrEmpty(str))
                {
                    delFlagSql = "WHERE"  + Environment.NewLine;
                    delFlagSql = "  ";
                }
                else
                {
                    sqlCommand.CommandText += str;
                    delFlagSql = "  AND ";
                }
                int logicalDeleteCode = -1;

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    delFlagSql += "LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    logicalDeleteCode = (int)logicalMode;
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    // UPD 2014/10/28 k.toyosawa �_���폜�����f�[�^���\������Ȃ����̑Ή� --->>>>>>
                    delFlagSql += "LOGICALDELETECODERF <= @FINDLOGICALDELETECODE" + Environment.NewLine;
                    // UPD 2014/10/28 k.toyosawa �_���폜�����f�[�^���\������Ȃ����̑Ή� ---<<<<<<
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01)
                    {
                        logicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData1;
                    }
                    if (logicalMode == ConstantManagement.LogicalMode.GetData012)
                    {
                        logicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData2;
                    }
                }

                if (logicalDeleteCode != -1)
                {
                    sqlCommand.CommandText += delFlagSql;
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalDeleteCode);
                }
                // ADD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� ---<<<<<<
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    pmtDefEmpList.Add(this.CopyToRecieveSecTableWorkFromReader(ref myReader));
                }

                if (pmtDefEmpList.Count > 0)
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
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

        # region [Write]
        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="pmtDefEmpList">�ǉ��E�X�V����PMTAB�����\���]�ƈ��ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpList �Ɋi�[����Ă���PMTAB�����\���]�ƈ��ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        public int Write(ref object pmtDefEmpList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = pmtDefEmpList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                // write���s
                status = this.Write(ref paraList, sqlConnection, sqlTransaction);
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
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="pmtDefEmpList">�ǉ��E�X�V����PMTAB�����\���]�ƈ��ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpList �Ɋi�[����Ă���PMTAB�����\���]�ƈ��ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        public int Write(ref ArrayList pmtDefEmpList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref pmtDefEmpList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="pmtDefEmpList">�ǉ��E�X�V����PMTAB�����\���]�ƈ��ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpList �Ɋi�[����Ă���PMTAB�����\���]�ƈ��ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        private int WriteProc(ref ArrayList pmtDefEmpList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (pmtDefEmpList != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < pmtDefEmpList.Count; i++)
                    {
                        PmtDefEmpWork pmtDefEmpWork = pmtDefEmpList[i] as PmtDefEmpWork;

                        # region [SELECT��]
                        sb.AppendLine("SELECT");
                        sb.AppendLine("  CREATEDATETIMERF");            // �쐬����
                        sb.AppendLine("  , UPDATEDATETIMERF");          // �X�V����
                        sb.AppendLine("  , ENTERPRISECODERF");          // ��ƃR�[�h
                        sb.AppendLine("  , FILEHEADERGUIDRF");          // GUID
                        sb.AppendLine("  , UPDEMPLOYEECODERF");         // �X�V�]�ƈ��R�[�h
                        sb.AppendLine("  , UPDASSEMBLYID1RF");          // �X�V�A�Z���u��ID1
                        sb.AppendLine("  , UPDASSEMBLYID2RF");          // �X�V�A�Z���u��ID2
                        sb.AppendLine("  , LOGICALDELETECODERF");       // �_���폜�敪
                        sb.AppendLine("  , LOGINAGENCODERF");           // ���O�C���S���҃R�[�h
                        sb.AppendLine("  , SALESEMPDIVRF");             // �S���ҋ敪
                        sb.AppendLine("  , SALESEMPLOYEECDRF");         // �̔��]�ƈ��R�[�h
                        sb.AppendLine("  , FRONTEMPDIVRF");             // �󒍎ҋ敪
                        sb.AppendLine("  , FRONTEMPLOYEECDRF");         // ��t�]�ƈ��R�[�h
                        sb.AppendLine("  , SALESINPUTDIVRF");           // ���s�ҋ敪
                        sb.AppendLine("  , SALESINPUTCODERF");          // ������͎҃R�[�h
                        sb.AppendLine("FROM");
                        sb.AppendLine("  PMTDEFEMPRF ");
                        sqlCommand.Parameters.Clear();

                        sqlCommand.CommandText = sb.ToString();
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, ref pmtDefEmpWork);
                        # endregion

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            pmtDefEmpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����

                            # region [UPDATE��]

                            sb = new StringBuilder();

                            sb.AppendLine("UPDATE PMTDEFEMPRF ");
                            sb.AppendLine("SET");
                            sb.AppendLine("  CREATEDATETIMERF = @CREATEDATETIME");
                            sb.AppendLine("  , UPDATEDATETIMERF = @UPDATEDATETIME");
                            sb.AppendLine("  , ENTERPRISECODERF = @ENTERPRISECODE");
                            sb.AppendLine("  , FILEHEADERGUIDRF = @FILEHEADERGUID");
                            sb.AppendLine("  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE");
                            sb.AppendLine("  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1");
                            sb.AppendLine("  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2");
                            sb.AppendLine("  , LOGICALDELETECODERF = @LOGICALDELETECODE");
                            sb.AppendLine("  , LOGINAGENCODERF = @LOGINAGENCODE");
                            sb.AppendLine("  , SALESEMPDIVRF = @SALESEMPDIV");
                            sb.AppendLine("  , SALESEMPLOYEECDRF = @SALESEMPLOYEECD");
                            sb.AppendLine("  , FRONTEMPDIVRF = @FRONTEMPDIV");
                            sb.AppendLine("  , FRONTEMPLOYEECDRF = @FRONTEMPLOYEECD");
                            sb.AppendLine("  , SALESINPUTDIVRF = @SALESINPUTDIV");
                            sb.AppendLine("  , SALESINPUTCODERF = @SALESINPUTCODE");

                            bool isWhere = false;
                            if (pmtDefEmpWork.EnterpriseCode != "")
                            {
                                isWhere = true;
                                sb.AppendLine("WHERE");
                                sb.AppendLine("  ENTERPRISECODERF = @UPDATEENTERPRISECODE ");

                                sqlCommand.Parameters.Clear();
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter updateParaEnterpriseCode = sqlCommand.Parameters.Add("@UPDATEENTERPRISECODE", SqlDbType.NChar);
                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                updateParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.EnterpriseCode);
                            }


                            if (pmtDefEmpWork.LoginAgenCode != "")
                            {
                                if (isWhere)
                                {
                                    sb.AppendLine("  AND LOGINAGENCODERF = @UPDATELOGINAGENCODE ");
                                }
                                else
                                {
                                    sb.AppendLine("WHERE");
                                    sb.AppendLine("  LOGINAGENCODERF = @UPDATELOGINAGENCODE ");
                                }
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter updateParaDbIdGuid = sqlCommand.Parameters.Add("@UPDATELOGINAGENCODE", SqlDbType.NChar);
                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                updateParaDbIdGuid.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.LoginAgenCode);
                            }

                            #endregion

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmtDefEmpWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            sqlCommand.CommandText = sb.ToString();

                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (pmtDefEmpWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            #region INSERT��

                            sb = new StringBuilder();
                            sb.AppendLine("INSERT ");
                            sb.AppendLine("INTO PMTDEFEMPRF( ");
                            sb.AppendLine("  CREATEDATETIMERF");
                            sb.AppendLine("  , UPDATEDATETIMERF");
                            sb.AppendLine("  , ENTERPRISECODERF");
                            sb.AppendLine("  , FILEHEADERGUIDRF");
                            sb.AppendLine("  , UPDEMPLOYEECODERF");
                            sb.AppendLine("  , UPDASSEMBLYID1RF");
                            sb.AppendLine("  , UPDASSEMBLYID2RF");
                            sb.AppendLine("  , LOGICALDELETECODERF");
                            sb.AppendLine("  , LOGINAGENCODERF");
                            sb.AppendLine("  , SALESEMPDIVRF");
                            sb.AppendLine("  , SALESEMPLOYEECDRF");
                            sb.AppendLine("  , FRONTEMPDIVRF");
                            sb.AppendLine("  , FRONTEMPLOYEECDRF");
                            sb.AppendLine("  , SALESINPUTDIVRF");
                            sb.AppendLine("  , SALESINPUTCODERF");
                            sb.AppendLine(") ");
                            sb.AppendLine("VALUES ( ");
                            sb.AppendLine("  @CREATEDATETIME");
                            sb.AppendLine("  , @UPDATEDATETIME");
                            sb.AppendLine("  , @ENTERPRISECODE");
                            sb.AppendLine("  , @FILEHEADERGUID");
                            sb.AppendLine("  , @UPDEMPLOYEECODE");
                            sb.AppendLine("  , @UPDASSEMBLYID1");
                            sb.AppendLine("  , @UPDASSEMBLYID2");
                            sb.AppendLine("  , @LOGICALDELETECODE");
                            sb.AppendLine("  , @LOGINAGENCODE");
                            sb.AppendLine("  , @SALESEMPDIV");
                            sb.AppendLine("  , @SALESEMPLOYEECD");
                            sb.AppendLine("  , @FRONTEMPDIV");
                            sb.AppendLine("  , @FRONTEMPLOYEECD");
                            sb.AppendLine("  , @SALESINPUTDIV");
                            sb.AppendLine("  , @SALESINPUTCODE");
                            sb.AppendLine(") ");
                            #endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmtDefEmpWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            sqlCommand.CommandText = sb.ToString();
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        #region //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraLoginAgenCode = sqlCommand.Parameters.Add("@LOGINAGENCODE", SqlDbType.NChar);
                        SqlParameter paraSalesEmpDiv = sqlCommand.Parameters.Add("@SALESEMPDIV", SqlDbType.Int);
                        SqlParameter paraSalesEmployeeCd = sqlCommand.Parameters.Add("@SALESEMPLOYEECD", SqlDbType.NChar);
                        SqlParameter paraFrontEmpDiv = sqlCommand.Parameters.Add("@FRONTEMPDIV", SqlDbType.Int);
                        SqlParameter paraFrontEmployeeCd = sqlCommand.Parameters.Add("@FRONTEMPLOYEECD", SqlDbType.NChar);
                        SqlParameter paraSalesInputDiv = sqlCommand.Parameters.Add("@SALESINPUTDIV", SqlDbType.Int);
                        SqlParameter paraSalesInputCode = sqlCommand.Parameters.Add("@SALESINPUTCODE", SqlDbType.NChar);
                        #endregion

                        #region //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmtDefEmpWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmtDefEmpWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(pmtDefEmpWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmtDefEmpWork.LogicalDeleteCode);
                        paraLoginAgenCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.LoginAgenCode);
                        paraSalesEmpDiv.Value = SqlDataMediator.SqlSetInt32(pmtDefEmpWork.SalesEmpDiv);
                        paraSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.SalesEmployeeCd);
                        paraFrontEmpDiv.Value = SqlDataMediator.SqlSetInt32(pmtDefEmpWork.FrontEmpDiv);
                        paraFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.FrontEmployeeCd);
                        paraSalesInputDiv.Value = SqlDataMediator.SqlSetInt32(pmtDefEmpWork.SalesInputDiv);
                        paraSalesInputCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.SalesInputCode);
                        #endregion

                        int cnt = sqlCommand.ExecuteNonQuery();
                        al.Add(pmtDefEmpWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
                    sqlCommand.Dispose();
                }
            }

            pmtDefEmpList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="pmtDefEmpList">�_���폜����PMTAB�����\���]�ƈ��ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpWork �Ɋi�[����Ă���PMTAB�����\���]�ƈ��ݒ�}�X�^����_���폜���܂��B</br>
        public int LogicalDelete(ref object pmtDefEmpList)
        {
            return this.LogicalDelete(ref pmtDefEmpList, 0);
        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="pmtDefEmpList">�_���폜����������PMTAB�����\���]�ƈ��ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpWork �Ɋi�[����Ă���PMTAB�����\���]�ƈ��ݒ�}�X�^���̘_���폜���������܂��B</br>
        public int RevivalLogicalDelete(ref object pmtDefEmpList)
        {
            return this.LogicalDelete(ref pmtDefEmpList, 1);
        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="pmtDefEmpList">�_���폜�𑀍삷��PMTAB�����\���]�ƈ��ݒ�}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpList �Ɋi�[����Ă���PMTAB�����\���]�ƈ��ݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        private int LogicalDelete(ref object pmtDefEmpList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = pmtDefEmpList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();


                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, sqlConnection, sqlTransaction);
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
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="pmtDefEmpList">�_���폜�𑀍삷��PMTAB�����\���]�ƈ��ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sCMRcveTgtInfWork �Ɋi�[����Ă���PMTAB�����\���]�ƈ��ݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        public int LogicalDelete(ref ArrayList pmtDefEmpList, int procMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref pmtDefEmpList, procMode, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="pmtDefEmpList">�_���폜�𑀍삷��PMTAB�����\���]�ƈ��ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpList �Ɋi�[����Ă���PMTAB�����\���]�ƈ��ݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        private int LogicalDeleteProc(ref ArrayList pmtDefEmpList, int procMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (pmtDefEmpList != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < pmtDefEmpList.Count; i++)
                    {
                        PmtDefEmpWork pmtDefEmpWork = pmtDefEmpList[i] as PmtDefEmpWork;

                        # region [SELECT��]

                        sb.AppendLine("SELECT");
                        sb.AppendLine("  CREATEDATETIMERF");            // �쐬����
                        sb.AppendLine("  , UPDATEDATETIMERF");          // �X�V����
                        sb.AppendLine("  , FILEHEADERGUIDRF");          // GUID
                        sb.AppendLine("  , LOGICALDELETECODERF");       // �_���폜�敪
                        sb.AppendLine("FROM");
                        sb.AppendLine("  PMTDEFEMPRF ");

                        sqlCommand.CommandText = sb.ToString();
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, ref pmtDefEmpWork);

                        # endregion

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (updateDateTime != pmtDefEmpWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sb = new StringBuilder();

                            sb.AppendLine("UPDATE PMTDEFEMPRF  ");
                            sb.AppendLine("SET");
                            sb.AppendLine("    UPDATEDATETIMERF = @UPDATEDATETIME");
                            sb.AppendLine("  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE");
                            sb.AppendLine("  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1");
                            sb.AppendLine("  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2");
                            sb.AppendLine("  , LOGICALDELETECODERF = @LOGICALDELETECODE");

                            bool isWhere = false;
                            if (pmtDefEmpWork.EnterpriseCode != "")
                            {
                                isWhere = true;
                                sb.AppendLine("WHERE");
                                sb.AppendLine("  ENTERPRISECODERF = @UPDATEENTERPRISECODE ");

                                sqlCommand.Parameters.Clear();
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter updateParaEnterpriseCode = sqlCommand.Parameters.Add("@UPDATEENTERPRISECODE", SqlDbType.NChar);
                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                updateParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.EnterpriseCode);
                            }


                            if (pmtDefEmpWork.LoginAgenCode != "")
                            {
                                if (isWhere)
                                {
                                    sb.AppendLine("  AND LOGINAGENCODERF = @UPDATELOGINAGENCODE ");
                                }
                                else
                                {
                                    sb.AppendLine("WHERE");
                                    sb.AppendLine("  LOGINAGENCODERF = @UPDATELOGINAGENCODE ");
                                }
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter updateParaDbIdGuid = sqlCommand.Parameters.Add("@UPDATELOGINAGENCODE", SqlDbType.NChar);
                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                updateParaDbIdGuid.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.LoginAgenCode);
                            }
                            # endregion

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmtDefEmpWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            sqlCommand.CommandText = sb.ToString();
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
                            else if (logicalDelCd == 0) pmtDefEmpWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else pmtDefEmpWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                pmtDefEmpWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmtDefEmpWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmtDefEmpWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(pmtDefEmpWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
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

            pmtDefEmpList = al;

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="pmtDefEmpWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ref PmtDefEmpWork pmtDefEmpWork)
        {
            StringBuilder sb = new StringBuilder();
            bool isWhere = false;

            if (pmtDefEmpWork.EnterpriseCode != "")
            {
                isWhere = true;
                sb.AppendLine("WHERE");
                sb.AppendLine("  ENTERPRISECODERF = @FINDENTERPRISECODE ");

                sqlCommand.Parameters.Clear();
                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.EnterpriseCode);
            }

            if (pmtDefEmpWork.LoginAgenCode != "")
            {
                if (isWhere)
                {
                    sb.AppendLine("  AND LOGINAGENCODERF = @FINDLOGINAGENCODE ");
                }
                else
                {
                    sb.AppendLine("WHERE");
                    sb.AppendLine("  LOGINAGENCODERF = @FINDLOGINAGENCODE ");
                }
                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findLoginAgenCode = sqlCommand.Parameters.Add("@FINDLOGINAGENCODE", SqlDbType.NChar);
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findLoginAgenCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.LoginAgenCode);
            }

            return sb.ToString();
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� PmtDefEmpWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PmtDefEmpWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// </remarks>
        private PmtDefEmpWork CopyToRecieveSecTableWorkFromReader(ref SqlDataReader myReader)
        {
            PmtDefEmpWork pmtDefEmpWork = new PmtDefEmpWork();

            this.CopyToRecieveSecTableWorkFromReader(ref myReader, ref pmtDefEmpWork);

            return pmtDefEmpWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� PmtDefEmpWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="pmtDefEmpWork">PmtDefEmpWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// </remarks>
        private void CopyToRecieveSecTableWorkFromReader(ref SqlDataReader myReader, ref PmtDefEmpWork pmtDefEmpWork)
        {
            if (myReader != null && pmtDefEmpWork != null)
            {
                # region �N���X�֊i�[
                pmtDefEmpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
                pmtDefEmpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
                pmtDefEmpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));             // ��ƃR�[�h
                pmtDefEmpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));               // GUID
                pmtDefEmpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));           // �X�V�]�ƈ��R�[�h
                pmtDefEmpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));             // �X�V�A�Z���u��ID1
                pmtDefEmpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));             // �X�V�A�Z���u��ID2
                pmtDefEmpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));        // �_���폜�敪
                pmtDefEmpWork.LoginAgenCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINAGENCODERF"));               // ���O�C���S���҃R�[�h
                pmtDefEmpWork.SalesEmpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESEMPDIVRF"));                    // �S���ҋ敪
                pmtDefEmpWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));           // �̔��]�ƈ��R�[�h
                pmtDefEmpWork.FrontEmpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRONTEMPDIVRF"));                    // �󒍎ҋ敪
                pmtDefEmpWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));           // ��t�]�ƈ��R�[�h
                pmtDefEmpWork.SalesInputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESINPUTDIVRF"));                // ���s�ҋ敪
                pmtDefEmpWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));             // ������͎҃R�[�h            }
                # endregion
            }
        }
        # endregion
    }
}