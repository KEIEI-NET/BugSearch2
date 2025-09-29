//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �����S�̐ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
//                  :   SFUKK09104R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2008.06.05
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����S�̐ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����S�̐ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.06.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class BillAllStDB : RemoteWithAppLockDB, IBillAllStDB
    {
        /// <summary>
        /// �����S�̐ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        /// </remarks>
        public BillAllStDB() : base("SFUKK09106D", "Broadleaf.Application.Remoting.ParamData.BillAllStWork", "BILLALLSTRF")
        {

        }

        # region [Read]
        /// <summary>
        /// �P��̐����S�̐ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="billAllStObj">BillAllStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����S�̐ݒ�}�X�^�̃L�[�l����v���鐿���S�̐ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        public int Read(ref object billAllStObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                BillAllStWork billAllStWork = billAllStObj as BillAllStWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref billAllStWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// �P��̐����S�̐ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="billAllStWork">BillAllStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����S�̐ݒ�}�X�^�̃L�[�l����v���鐿���S�̐ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        public int Read(ref BillAllStWork billAllStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return ReadProc(ref billAllStWork, readMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// �P��̐����S�̐ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="billAllStWork">BillAllStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����S�̐ݒ�}�X�^�̃L�[�l����v���鐿���S�̐ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        private int ReadProc(ref BillAllStWork billAllStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  BIL.*, SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  BILLALLSTRF AS BIL" + Environment.NewLine;
                sqlText += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     BIL.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND BIL.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "WHERE BIL.ENTERPRISECODERF=@FINDENTERPRISECODE AND BIL.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billAllStWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(billAllStWork.SectionCode);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToBillAllStWorkFromReader(ref myReader, ref billAllStWork);
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
        /// �����S�̐ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="billAllStList">�����폜���鐿���S�̐ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����S�̐ݒ�}�X�^�̃L�[�l����v���鐿���S�̐ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        public int Delete(object billAllStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = billAllStList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, ref sqlConnection, ref sqlTransaction);
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
        /// �����S�̐ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="billAllStList">�����S�̐ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStList �Ɋi�[����Ă��鐿���S�̐ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        public int Delete(ArrayList billAllStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(billAllStList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// �����S�̐ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="billAllStList">�����S�̐ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStList �Ɋi�[����Ă��鐿���S�̐ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        private int DeleteProc(ArrayList billAllStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (billAllStList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < billAllStList.Count; i++)
                    {
                        BillAllStWork billAllStWork = billAllStList[i] as BillAllStWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  BILLALLSTRF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);


                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billAllStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(billAllStWork.SectionCode);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != billAllStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  BILLALLSTRF" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billAllStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(billAllStWork.SectionCode);

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
        /// �����S�̐ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="billAllStList">��������</param>
        /// <param name="billAllStObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����S�̐ݒ�}�X�^�̃L�[�l����v����A�S�Ă̐����S�̐ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        public int Search(ref object billAllStList, object billAllStObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList billAllStArray = billAllStList as ArrayList;
                BillAllStWork billAllStWork = billAllStObj as BillAllStWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref billAllStArray, billAllStWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// �����S�̐ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="billAllStList">�����S�̐ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="billAllStWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����S�̐ݒ�}�X�^�̃L�[�l����v����A�S�Ă̐����S�̐ݒ�}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        public int Search(ref ArrayList billAllStList, BillAllStWork billAllStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref billAllStList, billAllStWork,readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// �����S�̐ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="billAllStList">�����S�̐ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="billAllStWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����S�̐ݒ�}�X�^�̃L�[�l����v����A�S�Ă̐����S�̐ݒ�}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        private int SearchProc(ref ArrayList billAllStList, BillAllStWork billAllStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  BIL.*, SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  BILLALLSTRF AS BIL" + Environment.NewLine;
                sqlText += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     BIL.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND BIL.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, billAllStWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    billAllStList.Add(this.CopyToBillAllStWorkFromReader(ref myReader));
                }

                if (billAllStList.Count > 0)
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
        /// �����S�̐ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="billAllStList">�ǉ��E�X�V���鐿���S�̐ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStList �Ɋi�[����Ă��鐿���S�̐ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        public int Write(ref object billAllStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = billAllStList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);
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
        /// �����S�̐ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="billAllStList">�ǉ��E�X�V���鐿���S�̐ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStList �Ɋi�[����Ă��鐿���S�̐ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        public int Write(ref ArrayList billAllStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref billAllStList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// �����S�̐ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="billAllStList">�ǉ��E�X�V���鐿���S�̐ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStList �Ɋi�[����Ă��鐿���S�̐ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        private int WriteProc(ref ArrayList billAllStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (billAllStList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < billAllStList.Count; i++)
                    {
                        BillAllStWork billAllStWork = billAllStList[i] as BillAllStWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  BILLALLSTRF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);


                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billAllStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(billAllStWork.SectionCode);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != billAllStWork.UpdateDateTime)
                            {
                                if (billAllStWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText = "UPDATE BILLALLSTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , ALLOWANCEPROCCDRF=@ALLOWANCEPROCCD , DEPOSITSLIPMNTCDRF=@DEPOSITSLIPMNTCD , COLLECTPLNDIVRF=@COLLECTPLNDIV ,CUSTOMERTOTALDAY1RF=@CUSTOMERTOTALDAY1 , CUSTOMERTOTALDAY2RF=@CUSTOMERTOTALDAY2 , CUSTOMERTOTALDAY3RF=@CUSTOMERTOTALDAY3 , CUSTOMERTOTALDAY4RF=@CUSTOMERTOTALDAY4 , CUSTOMERTOTALDAY5RF=@CUSTOMERTOTALDAY5 , CUSTOMERTOTALDAY6RF=@CUSTOMERTOTALDAY6 , CUSTOMERTOTALDAY7RF=@CUSTOMERTOTALDAY7 , CUSTOMERTOTALDAY8RF=@CUSTOMERTOTALDAY8 , CUSTOMERTOTALDAY9RF=@CUSTOMERTOTALDAY9 , CUSTOMERTOTALDAY10RF=@CUSTOMERTOTALDAY10 , CUSTOMERTOTALDAY11RF=@CUSTOMERTOTALDAY11 , CUSTOMERTOTALDAY12RF=@CUSTOMERTOTALDAY12 , SUPPLIERTOTALDAY1RF=@SUPPLIERTOTALDAY1 , SUPPLIERTOTALDAY2RF=@SUPPLIERTOTALDAY2 , SUPPLIERTOTALDAY3RF=@SUPPLIERTOTALDAY3 , SUPPLIERTOTALDAY4RF=@SUPPLIERTOTALDAY4 , SUPPLIERTOTALDAY5RF=@SUPPLIERTOTALDAY5 , SUPPLIERTOTALDAY6RF=@SUPPLIERTOTALDAY6 , SUPPLIERTOTALDAY7RF=@SUPPLIERTOTALDAY7 , SUPPLIERTOTALDAY8RF=@SUPPLIERTOTALDAY8 , SUPPLIERTOTALDAY9RF=@SUPPLIERTOTALDAY9 , SUPPLIERTOTALDAY10RF=@SUPPLIERTOTALDAY10 , SUPPLIERTOTALDAY11RF=@SUPPLIERTOTALDAY11 , SUPPLIERTOTALDAY12RF=@SUPPLIERTOTALDAY12 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billAllStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(billAllStWork.SectionCode);


                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)billAllStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (billAllStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO BILLALLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, ALLOWANCEPROCCDRF, DEPOSITSLIPMNTCDRF, COLLECTPLNDIVRF, CUSTOMERTOTALDAY1RF, CUSTOMERTOTALDAY2RF, CUSTOMERTOTALDAY3RF, CUSTOMERTOTALDAY4RF, CUSTOMERTOTALDAY5RF, CUSTOMERTOTALDAY6RF, CUSTOMERTOTALDAY7RF, CUSTOMERTOTALDAY8RF, CUSTOMERTOTALDAY9RF, CUSTOMERTOTALDAY10RF, CUSTOMERTOTALDAY11RF, CUSTOMERTOTALDAY12RF, SUPPLIERTOTALDAY1RF, SUPPLIERTOTALDAY2RF, SUPPLIERTOTALDAY3RF, SUPPLIERTOTALDAY4RF, SUPPLIERTOTALDAY5RF, SUPPLIERTOTALDAY6RF, SUPPLIERTOTALDAY7RF, SUPPLIERTOTALDAY8RF, SUPPLIERTOTALDAY9RF, SUPPLIERTOTALDAY10RF, SUPPLIERTOTALDAY11RF, SUPPLIERTOTALDAY12RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @ALLOWANCEPROCCD, @DEPOSITSLIPMNTCD, @COLLECTPLNDIV, @CUSTOMERTOTALDAY1, @CUSTOMERTOTALDAY2, @CUSTOMERTOTALDAY3, @CUSTOMERTOTALDAY4, @CUSTOMERTOTALDAY5, @CUSTOMERTOTALDAY6, @CUSTOMERTOTALDAY7, @CUSTOMERTOTALDAY8, @CUSTOMERTOTALDAY9, @CUSTOMERTOTALDAY10, @CUSTOMERTOTALDAY11, @CUSTOMERTOTALDAY12, @SUPPLIERTOTALDAY1, @SUPPLIERTOTALDAY2, @SUPPLIERTOTALDAY3, @SUPPLIERTOTALDAY4, @SUPPLIERTOTALDAY5, @SUPPLIERTOTALDAY6, @SUPPLIERTOTALDAY7, @SUPPLIERTOTALDAY8, @SUPPLIERTOTALDAY9, @SUPPLIERTOTALDAY10, @SUPPLIERTOTALDAY11, @SUPPLIERTOTALDAY12)";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)billAllStWork;
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
                        SqlParameter paraAllowanceProcCd = sqlCommand.Parameters.Add("@ALLOWANCEPROCCD", SqlDbType.Int);
                        SqlParameter paraDepositSlipMntCd = sqlCommand.Parameters.Add("@DEPOSITSLIPMNTCD", SqlDbType.Int);
                        SqlParameter paraCollectPlnDiv = sqlCommand.Parameters.Add("@COLLECTPLNDIV", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay1 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY1", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay2 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY2", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay3 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY3", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay4 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY4", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay5 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY5", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay6 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY6", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay7 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY7", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay8 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY8", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay9 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY9", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay10 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY10", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay11 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY11", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay12 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY12", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay1 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY1", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay2 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY2", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay3 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY3", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay4 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY4", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay5 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY5", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay6 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY6", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay7 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY7", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay8 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY8", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay9 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY9", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay10 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY10", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay11 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY11", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay12 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY12", SqlDbType.Int);

                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(billAllStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(billAllStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(billAllStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(billAllStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(billAllStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(billAllStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(billAllStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(billAllStWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(billAllStWork.SectionCode);
                        paraAllowanceProcCd.Value = SqlDataMediator.SqlSetInt32(billAllStWork.AllowanceProcCd);
                        paraDepositSlipMntCd.Value = SqlDataMediator.SqlSetInt32(billAllStWork.DepositSlipMntCd);
                        paraCollectPlnDiv.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CollectPlnDiv);
                        paraCustomerTotalDay1.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay1);
                        paraCustomerTotalDay2.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay2);
                        paraCustomerTotalDay3.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay3);
                        paraCustomerTotalDay4.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay4);
                        paraCustomerTotalDay5.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay5);
                        paraCustomerTotalDay6.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay6);
                        paraCustomerTotalDay7.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay7);
                        paraCustomerTotalDay8.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay8);
                        paraCustomerTotalDay9.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay9);
                        paraCustomerTotalDay10.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay10);
                        paraCustomerTotalDay11.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay11);
                        paraCustomerTotalDay12.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay12);
                        paraSupplierTotalDay1.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay1);
                        paraSupplierTotalDay2.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay2);
                        paraSupplierTotalDay3.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay3);
                        paraSupplierTotalDay4.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay4);
                        paraSupplierTotalDay5.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay5);
                        paraSupplierTotalDay6.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay6);
                        paraSupplierTotalDay7.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay7);
                        paraSupplierTotalDay8.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay8);
                        paraSupplierTotalDay9.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay9);
                        paraSupplierTotalDay10.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay10);
                        paraSupplierTotalDay11.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay11);
                        paraSupplierTotalDay12.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay12);

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(billAllStWork);
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
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            billAllStList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// �����S�̐ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="billAllStList">�_���폜���鐿���S�̐ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStWork �Ɋi�[����Ă��鐿���S�̐ݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        public int LogicalDelete(ref object billAllStList)
        {
            return this.LogicalDelete(ref billAllStList, 0);
        }

        /// <summary>
        /// �����S�̐ݒ�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="billAllStList">�_���폜���������鐿���S�̐ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStWork �Ɋi�[����Ă��鐿���S�̐ݒ�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        public int RevivalLogicalDelete(ref object billAllStList)
        {
            return this.LogicalDelete(ref billAllStList, 1);
        }

        /// <summary>
        /// �����S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="billAllStList">�_���폜�𑀍삷�鐿���S�̐ݒ�}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStWork �Ɋi�[����Ă��鐿���S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        private int LogicalDelete(ref object billAllStList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = billAllStList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);
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
        /// �����S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="billAllStList">�_���폜�𑀍삷�鐿���S�̐ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStWork �Ɋi�[����Ă��鐿���S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        public int LogicalDelete(ref ArrayList billAllStList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref billAllStList, procMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// �����S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="billAllStList">�_���폜�𑀍삷�鐿���S�̐ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStWork �Ɋi�[����Ă��鐿���S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        private int LogicalDeleteProc(ref ArrayList billAllStList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (billAllStList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < billAllStList.Count; i++)
                    {
                        BillAllStWork billAllStWork = billAllStList[i] as BillAllStWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  BILLALLSTRF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);


                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billAllStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(billAllStWork.SectionCode);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != billAllStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  BILLALLSTRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billAllStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(billAllStWork.SectionCode);


                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)billAllStWork;
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
                            else if (logicalDelCd == 0) billAllStWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else billAllStWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                billAllStWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(billAllStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(billAllStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(billAllStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(billAllStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(billAllStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(billAllStWork);
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

            billAllStList = al;

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="billAllStWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, BillAllStWork billAllStWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // ��ƃR�[�h
            retstring += "  BIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(billAllStWork.EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND BIL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND BIL.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //���_�R�[�h
            if (string.IsNullOrEmpty(billAllStWork.SectionCode) == false)
            {
                wkstring += " AND BIL.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(billAllStWork.SectionCode);
            }

            return retstring;
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� BillAllStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>BillAllStWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        /// </remarks>
        private BillAllStWork CopyToBillAllStWorkFromReader(ref SqlDataReader myReader)
        {
            BillAllStWork billAllStWork = new BillAllStWork();

            this.CopyToBillAllStWorkFromReader(ref myReader, ref billAllStWork);

            return billAllStWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� BillAllStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="billAllStWork">BillAllStWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        /// </remarks>
        private void CopyToBillAllStWorkFromReader(ref SqlDataReader myReader, ref BillAllStWork billAllStWork)
        {
            if (myReader != null && billAllStWork != null)
            {
                # region �N���X�֊i�[
                billAllStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
                billAllStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
                billAllStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
                billAllStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
                billAllStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                billAllStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                billAllStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                billAllStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                billAllStWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
                billAllStWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONGUIDENMRF"));
                billAllStWork.AllowanceProcCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ALLOWANCEPROCCDRF"));
                billAllStWork.DepositSlipMntCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPMNTCDRF"));
                billAllStWork.CollectPlnDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTPLNDIVRF"));
                billAllStWork.CustomerTotalDay1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERTOTALDAY1RF"));
                billAllStWork.CustomerTotalDay2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY2RF"));
                billAllStWork.CustomerTotalDay3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY3RF"));
                billAllStWork.CustomerTotalDay4 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY4RF"));
                billAllStWork.CustomerTotalDay5 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY5RF"));
                billAllStWork.CustomerTotalDay6 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY6RF"));
                billAllStWork.CustomerTotalDay7 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY7RF"));
                billAllStWork.CustomerTotalDay8 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY8RF"));
                billAllStWork.CustomerTotalDay9 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY9RF"));
                billAllStWork.CustomerTotalDay10 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY10RF"));
                billAllStWork.CustomerTotalDay11 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY11RF"));
                billAllStWork.CustomerTotalDay12 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY12RF"));
                billAllStWork.SupplierTotalDay1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY1RF"));
                billAllStWork.SupplierTotalDay2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY2RF"));
                billAllStWork.SupplierTotalDay3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY3RF"));
                billAllStWork.SupplierTotalDay4 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY4RF"));
                billAllStWork.SupplierTotalDay5 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY5RF"));
                billAllStWork.SupplierTotalDay6 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY6RF"));
                billAllStWork.SupplierTotalDay7 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY7RF"));
                billAllStWork.SupplierTotalDay8 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY8RF"));
                billAllStWork.SupplierTotalDay9 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY9RF"));
                billAllStWork.SupplierTotalDay10 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY10RF"));
                billAllStWork.SupplierTotalDay11 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY11RF"));
                billAllStWork.SupplierTotalDay12 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY12RF"));

                # endregion
            }
        }
        # endregion
    }
}
