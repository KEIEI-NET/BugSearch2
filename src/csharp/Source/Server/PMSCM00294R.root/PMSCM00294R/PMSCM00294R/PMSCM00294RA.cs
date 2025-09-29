//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PMDBID�Ǘ��}�X�^DB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : PMDBID�Ǘ��}�X�^DB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/08/18  �C�����e : �V�K�쐬
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMDBID�Ǘ��}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMDBID�Ǘ��}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// </remarks>
    [Serializable]
    public class PmDbIdMngDB : RemoteWithAppLockDB, IPmDbIdMngDB
    {

        /// <summary>
        /// PMDBID�Ǘ��}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// </remarks>
        public PmDbIdMngDB()
            : base("PMSCM00296D", "Broadleaf.Application.Remoting.ParamData.PmDbIdMngWork", "PmDbIdMngRF")
        {
        }

        # region [Read]
        /// <summary>
        /// �P���PMDBID�Ǘ��}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="pmDbIdMngObj">PmDbIdMngWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID�Ǘ��}�X�^�̃L�[�l����v����PMDBID�Ǘ��}�X�^�����擾���܂��B</br>
        public int Read(ref object pmDbIdMngObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                PmDbIdMngWork pmDbIdMngWork = pmDbIdMngObj as PmDbIdMngWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref pmDbIdMngWork, readMode, sqlConnection, sqlTransaction);
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
        /// �P���PMDBID�Ǘ��}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="pmDbIdMngWork">PmDbIdMngWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID�Ǘ��}�X�^�̃L�[�l����v����PMDBID�Ǘ��}�X�^�����擾���܂��B</br>
        public int Read(ref PmDbIdMngWork pmDbIdMngWork, int readMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref pmDbIdMngWork, readMode, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// PMDBID�Ǘ��}�X�^��񃊃X�g���擾���܂��B
        /// </summary>
        /// <param name="pmDbIdMngObj">���o�������X�g(PmDbIdMngWork)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID�Ǘ��}�X�^�̃L�[�l����v����PMDBID�Ǘ��}�X�^�����擾���܂��B</br>
        public int ReadAll(ref object pmDbIdMngObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList paraList = pmDbIdMngObj as ArrayList;
                ArrayList pmDbIdMngList = new ArrayList();

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.ReadAll(ref pmDbIdMngList, paraList, sqlConnection, sqlTransaction);

                pmDbIdMngObj = pmDbIdMngList;

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
        /// �P���PMDBID�Ǘ��}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="pmDbIdMngList">���o���ʃ��X�g(PmDbIdMngWork)</param>
        /// <param name="paraList">���o�������X�g(PmDbIdMngWork)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID�Ǘ��}�X�^�̃L�[�l����v����PMDBID�Ǘ��}�X�^�����擾���܂��B</br>
        public int ReadAll(ref ArrayList pmDbIdMngList, ArrayList paraList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            foreach (PmDbIdMngWork pmDbIdMngWork in paraList)
            {
                PmDbIdMngWork pararetWork = pmDbIdMngWork;

                status = this.ReadProc(ref pararetWork, 0, sqlConnection, sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    pmDbIdMngList.Add(pararetWork);
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
        /// �P���PMDBID�Ǘ��}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="pmDbIdMngWork">PmDbIdMngWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID�Ǘ��}�X�^�̃L�[�l����v����PMDBID�Ǘ��}�X�^�����擾���܂��B</br>
        private int ReadProc(ref PmDbIdMngWork pmDbIdMngWork, int readMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sb = new StringBuilder();
                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction);

                # region [SELECT��]

                sb.AppendLine("SELECT");
                sb.AppendLine("  CREATEDATETIMERF");          // �쐬����
                sb.AppendLine("  , UPDATEDATETIMERF");        // �X�V����
                sb.AppendLine("  , ENTERPRISECODERF");        // ��ƃR�[�h
                sb.AppendLine("  , DBIDMNGGUIDRF");           // DBID�Ǘ�GUID
                sb.AppendLine("FROM");
                sb.AppendLine("  PMDBIDMNGRF ");

                sqlCommand.CommandText = sb.ToString();
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, ref pmDbIdMngWork);

                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToRecieveSecTableWorkFromReader(ref myReader, ref pmDbIdMngWork);
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
        /// PMDBID�Ǘ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="pmDbIdMngList">�����폜����PMDBID�Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID�Ǘ��}�X�^�̃L�[�l����v����PMDBID�Ǘ��}�X�^���𕨗��폜���܂��B</br>
        public int Delete(object pmDbIdMngList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = pmDbIdMngList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

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
        /// PMDBID�Ǘ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="pmDbIdMngList">PMDBID�Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngList �Ɋi�[����Ă���PMDBID�Ǘ��}�X�^���𕨗��폜���܂��B</br>
        public int Delete(ArrayList pmDbIdMngList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(pmDbIdMngList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// PMDBID�Ǘ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="pmDbIdMngList">PMDBID�Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngList �Ɋi�[����Ă���PMDBID�Ǘ��}�X�^���𕨗��폜���܂��B</br>
        private int DeleteProc(ArrayList pmDbIdMngList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (pmDbIdMngList != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < pmDbIdMngList.Count; i++)
                    {
                        PmDbIdMngWork pmDbIdMngWork = pmDbIdMngList[i] as PmDbIdMngWork;

                        # region [SELECT��]

                        sb.AppendLine("SELECT");
                        sb.AppendLine("  UPDATEDATETIMERF");
                        sb.AppendLine("FROM");
                        sb.AppendLine("  PMDBIDMNGRF ");

                        sqlCommand.CommandText = sb.ToString();
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, ref pmDbIdMngWork);

                        # endregion

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (pmDbIdMngWork.DbIdMngGuid != "" && _updateDateTime != pmDbIdMngWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]

                            sb = new StringBuilder();
                            sb.AppendLine("DELETE FROM");
                            sb.AppendLine("  PMDBIDMNGRF ");

                            bool isWhere = false;
                            if (pmDbIdMngWork.EnterpriseCode != "")
                            {
                                isWhere = true;
                                sb.AppendLine("WHERE");
                                sb.AppendLine("  ENTERPRISECODERF = @DELETEENTERPRISECODE ");

                                sqlCommand.Parameters.Clear();
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter updateParaEnterpriseCode = sqlCommand.Parameters.Add("@DELETEENTERPRISECODE", SqlDbType.NChar);
                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                updateParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmDbIdMngWork.EnterpriseCode);
                            }


                            if (pmDbIdMngWork.DbIdMngGuid != "")
                            {
                                if (isWhere)
                                {
                                    sb.AppendLine("  AND DBIDMNGGUIDRF = @DELETEDBIDMNGGUID ");
                                }
                                else
                                {
                                    sb.AppendLine("WHERE");
                                    sb.AppendLine("  DBIDMNGGUIDRF = @DELETEDBIDMNGGUID ");
                                }
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter updateParaDbIdGuid = sqlCommand.Parameters.Add("@DELETEDBIDMNGGUID", SqlDbType.NChar);
                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                updateParaDbIdGuid.Value = SqlDataMediator.SqlSetString(pmDbIdMngWork.DbIdMngGuid);
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
        /// PMDBID�Ǘ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="pmDbIdMngList">��������</param>
        /// <param name="pmDbIdMngObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID�Ǘ��}�X�^�̃L�[�l����v����A�S�Ă�PMDBID�Ǘ��}�X�^�����擾���܂��B</br>
        public int Search(ref object pmDbIdMngList, object pmDbIdMngObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList pmDbIdMngArray = pmDbIdMngList as ArrayList;
                PmDbIdMngWork pmDbIdMngWork = pmDbIdMngObj as PmDbIdMngWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Search(ref pmDbIdMngArray, pmDbIdMngWork, readMode, logicalMode, sqlConnection, sqlTransaction);

                //TEST
                if (status == 0)
                {
                    pmDbIdMngList = pmDbIdMngArray as object;
                }
                else
                {
                    ArrayList workArray = new ArrayList();
                    pmDbIdMngList = workArray as object;
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
        /// PMDBID�Ǘ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="pmDbIdMngList">PMDBID�Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="pmDbIdMngWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID�Ǘ��}�X�^�̃L�[�l����v����A�S�Ă�PMDBID�Ǘ��}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        public int Search(ref ArrayList pmDbIdMngList, PmDbIdMngWork pmDbIdMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref pmDbIdMngList, pmDbIdMngWork, readMode, logicalMode, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// PMDBID�Ǘ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="pmDbIdMngList">PMDBID�Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="pmDbIdMngWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID�Ǘ��}�X�^�̃L�[�l����v����A�S�Ă�PMDBID�Ǘ��}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        private int SearchProc(ref ArrayList pmDbIdMngList, PmDbIdMngWork pmDbIdMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            pmDbIdMngList = new ArrayList();
            try
            {
                StringBuilder sb = new StringBuilder();
                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction);

                # region [SELECT��]

                sb.AppendLine("SELECT");
                sb.AppendLine("  CREATEDATETIMERF");          // �쐬����
                sb.AppendLine("  , UPDATEDATETIMERF");        // �X�V����
                sb.AppendLine("  , ENTERPRISECODERF");        // ��ƃR�[�h
                sb.AppendLine("  , DBIDMNGGUIDRF");           // DBID�Ǘ�GUID
                sb.AppendLine("FROM");
                sb.AppendLine("  PMDBIDMNGRF ");

                sqlCommand.CommandText = sb.ToString();
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, ref pmDbIdMngWork);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    pmDbIdMngList.Add(this.CopyToRecieveSecTableWorkFromReader(ref myReader));
                }

                if (pmDbIdMngList.Count > 0)
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
        /// PMDBID�Ǘ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="pmDbIdMngList">�ǉ��E�X�V����PMDBID�Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngList �Ɋi�[����Ă���PMDBID�Ǘ��}�X�^����ǉ��E�X�V���܂��B</br>
        public int Write(ref object pmDbIdMngList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = pmDbIdMngList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

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
        /// PMDBID�Ǘ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="pmDbIdMngList">�ǉ��E�X�V����PMDBID�Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngList �Ɋi�[����Ă���PMDBID�Ǘ��}�X�^����ǉ��E�X�V���܂��B</br>
        public int Write(ref ArrayList pmDbIdMngList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref pmDbIdMngList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// PMDBID�Ǘ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="pmDbIdMngList">�ǉ��E�X�V����PMDBID�Ǘ��}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngList �Ɋi�[����Ă���PMDBID�Ǘ��}�X�^����ǉ��E�X�V���܂��B</br>
        private int WriteProc(ref ArrayList pmDbIdMngList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (pmDbIdMngList != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < pmDbIdMngList.Count; i++)
                    {
                        PmDbIdMngWork pmDbIdMngWork = pmDbIdMngList[i] as PmDbIdMngWork;

                        # region [SELECT��]

                        sb.AppendLine("SELECT");
                        sb.AppendLine("  CREATEDATETIMERF");          // �쐬����
                        sb.AppendLine("  , UPDATEDATETIMERF");        // �X�V����
                        sb.AppendLine("  , ENTERPRISECODERF");        // ��ƃR�[�h
                        sb.AppendLine("  , DBIDMNGGUIDRF");           // DBID�Ǘ�GUID
                        sb.AppendLine("FROM");
                        sb.AppendLine("  PMDBIDMNGRF ");

                        sqlCommand.Parameters.Clear();

                        sqlCommand.CommandText = sb.ToString();
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, ref pmDbIdMngWork);

                        # endregion

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            pmDbIdMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����

                            # region [UPDATE��]

                            sb = new StringBuilder();

                            sb.AppendLine("UPDATE PMDBIDMNGRF ");
                            sb.AppendLine("SET");
                            sb.AppendLine("  CREATEDATETIMERF = @CREATEDATETIME");
                            sb.AppendLine("  , UPDATEDATETIMERF = @UPDATEDATETIME");
                            sb.AppendLine("  , ENTERPRISECODERF = @ENTERPRISECODE");
                            sb.AppendLine("  , DBIDMNGGUIDRF = @DBIDMNGGUID");

                            bool isWhere = false;
                            if (pmDbIdMngWork.EnterpriseCode != "")
                            {
                                isWhere = true;
                                sb.AppendLine("WHERE");
                                sb.AppendLine("  ENTERPRISECODERF = @UPDATEENTERPRISECODE ");

                                sqlCommand.Parameters.Clear();
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter updateParaEnterpriseCode = sqlCommand.Parameters.Add("@UPDATEENTERPRISECODE", SqlDbType.NChar);
                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                updateParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmDbIdMngWork.EnterpriseCode);
                            }


                            if (pmDbIdMngWork.DbIdMngGuid != "")
                            {
                                if (isWhere)
                                {
                                    sb.AppendLine("  AND DBIDMNGGUIDRF = @UPDATEDBIDMNGGUID ");
                                }
                                else
                                {
                                    sb.AppendLine("WHERE");
                                    sb.AppendLine("  DBIDMNGGUIDRF = @UPDATEDBIDMNGGUID ");
                                }
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter updateParaDbIdGuid = sqlCommand.Parameters.Add("@UPDATEDBIDMNGGUID", SqlDbType.NChar);
                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                updateParaDbIdGuid.Value = SqlDataMediator.SqlSetString(pmDbIdMngWork.DbIdMngGuid);
                            }

                            #endregion

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmDbIdMngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            sqlCommand.CommandText = sb.ToString();

                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (pmDbIdMngWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            #region INSERT��

                            sb = new StringBuilder();
                            sb.AppendLine("INSERT ");
                            sb.AppendLine("INTO PMDBIDMNGRF( ");
                            sb.AppendLine("  CREATEDATETIMERF");
                            sb.AppendLine("  , UPDATEDATETIMERF");
                            sb.AppendLine("  , ENTERPRISECODERF");
                            sb.AppendLine("  , DBIDMNGGUIDRF");
                            sb.AppendLine(") ");
                            sb.AppendLine("VALUES ( ");
                            sb.AppendLine("  @CREATEDATETIME");
                            sb.AppendLine("  , @UPDATEDATETIME");
                            sb.AppendLine("  , @ENTERPRISECODE");
                            sb.AppendLine("  , @DBIDMNGGUID");
                            sb.AppendLine(") ");

                            #endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmDbIdMngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            sqlCommand.CommandText = sb.ToString();
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }


                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);               // �쐬����
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);               // �X�V����
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);                // ��ƃR�[�h
                        SqlParameter paraDbIdMngGuid = sqlCommand.Parameters.Add("@DBIDMNGGUID", SqlDbType.NChar);                   // DBID�Ǘ�GUID
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmDbIdMngWork.CreateDateTime);           // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmDbIdMngWork.UpdateDateTime);           // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmDbIdMngWork.EnterpriseCode);                      // ��ƃR�[�h
                        paraDbIdMngGuid.Value = SqlDataMediator.SqlSetString(pmDbIdMngWork.DbIdMngGuid);                        // DBID�Ǘ�GUID
                        #endregion

                        int cnt = sqlCommand.ExecuteNonQuery();
                        al.Add(pmDbIdMngWork);
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

            pmDbIdMngList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// PMDBID�Ǘ��}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="pmDbIdMngList">�_���폜����PMDBID�Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngWork �Ɋi�[����Ă���PMDBID�Ǘ��}�X�^����_���폜���܂��B</br>
        public int LogicalDelete(ref object pmDbIdMngList)
        {
            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
        }

        /// <summary>
        /// PMDBID�Ǘ��}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="pmDbIdMngList">�_���폜����������PMDBID�Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngWork �Ɋi�[����Ă���PMDBID�Ǘ��}�X�^���̘_���폜���������܂��B</br>
        public int RevivalLogicalDelete(ref object pmDbIdMngList)
        {
            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="pmDbIdMngWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ref PmDbIdMngWork pmDbIdMngWork)
        {
            StringBuilder sb = new StringBuilder();

            bool isWhere = false;

            if (pmDbIdMngWork.EnterpriseCode != "")
            {
                isWhere = true;
                sb.AppendLine("WHERE");
                sb.AppendLine("  ENTERPRISECODERF = @FINDENTERPRISECODE ");

                sqlCommand.Parameters.Clear();
                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmDbIdMngWork.EnterpriseCode);
            }

            if (pmDbIdMngWork.DbIdMngGuid != "")
            {
                if (isWhere)
                {
                    sb.AppendLine("  AND DBIDMNGGUIDRF = @FINDDBIDMNGGUID ");
                }
                else
                {
                    sb.AppendLine("WHERE");
                    sb.AppendLine("  DBIDMNGGUIDRF = @FINDDBIDMNGGUID ");
                }
                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaDbIdGuid = sqlCommand.Parameters.Add("@FINDDBIDMNGGUID", SqlDbType.NChar);
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaDbIdGuid.Value = SqlDataMediator.SqlSetString(pmDbIdMngWork.DbIdMngGuid);
            }

            return sb.ToString();
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� PmDbIdMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PmDbIdMngWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// </remarks>
        private PmDbIdMngWork CopyToRecieveSecTableWorkFromReader(ref SqlDataReader myReader)
        {
            PmDbIdMngWork pmDbIdMngWork = new PmDbIdMngWork();

            this.CopyToRecieveSecTableWorkFromReader(ref myReader, ref pmDbIdMngWork);

            return pmDbIdMngWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� PmDbIdMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="pmDbIdMngWork">PmDbIdMngWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// </remarks>
        private void CopyToRecieveSecTableWorkFromReader(ref SqlDataReader myReader, ref PmDbIdMngWork pmDbIdMngWork)
        {
            if (myReader != null && pmDbIdMngWork != null)
            {
                # region �N���X�֊i�[
                pmDbIdMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
                pmDbIdMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
                pmDbIdMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));             // ��ƃR�[�h
                pmDbIdMngWork.DbIdMngGuid = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DBIDMNGGUIDRF"));                  // DBID�Ǘ�GUID
                # endregion
            }
        }
        # endregion
    }
}