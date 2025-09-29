//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ���[���O���[�v�����ݒ�}�X�^                    //
//                      �����[�g�I�u�W�F�N�g                            //
//                  :   PMKHN09734R.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting                  //
// Programmer       :   30746 ���� ��                                   //
// Date             :   2013/02/18                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���[���O���[�v�����ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[���O���[�v�����ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30746 ���� ��</br>
    /// <br>Date       : 2013/02/18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class RoleGroupAuthDB : RemoteWithAppLockDB, IRoleGroupAuthDB 
    {
        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public RoleGroupAuthDB()
            : base("PMKHN09736D", "Broadleaf.Application.Remoting.ParamData.RoleGroupAuthWork", "ROLEGRPAUTHRTSTRF")
        {
        }

        # region [Read]
        /// <summary>
        /// �P��̃��[���O���[�v�����ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="roleGroupAuthObj">RoleGroupAuthWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v�����ݒ�}�X�^�̃L�[�l����v���郍�[���O���[�v�����ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int Read(ref object roleGroupAuthObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                RoleGroupAuthWork roleGroupAuthWork = roleGroupAuthObj as RoleGroupAuthWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref roleGroupAuthWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// �P��̃��[���O���[�v�����ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="roleGroupAuthWork">RoleGroupAuthWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v�����ݒ�}�X�^�̃L�[�l����v���郍�[���O���[�v�����ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int Read(ref RoleGroupAuthWork roleGroupAuthWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref roleGroupAuthWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �P��̃��[���O���[�v�����ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="roleGroupAuthWork">RoleGroupAuthWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v�����ݒ�}�X�^�̃L�[�l����v���郍�[���O���[�v�����ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        private int ReadProc(ref RoleGroupAuthWork roleGroupAuthWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT *" + Environment.NewLine;
                sqlText += "FROM   ROLEGRPAUTHRTSTRF" + Environment.NewLine;
                sqlText += "WHERE  ENTERPRISECODERF    = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND  ROLEGROUPCODERF     = @FINDROLEGROUPCODE" + Environment.NewLine;
                sqlText += "  AND  ROLECATEGORYIDRF    = @FINDROLECATEGORYID" + Environment.NewLine;
                sqlText += "  AND  ROLECATEGORYSUBIDRF = @FINDROLECATEGORYSUBID" + Environment.NewLine;
                sqlText += "  AND  ROLEITEMIDRF        = @FINDROLEITEMID" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);
                SqlParameter findParaRoleCategoryID = sqlCommand.Parameters.Add("@FINDROLECATEGORYID", SqlDbType.Int);
                SqlParameter findParaRoleCategorySubID = sqlCommand.Parameters.Add("@FINDROLECATEGORYSUBID", SqlDbType.Int);
                SqlParameter findParaRoleItemID = sqlCommand.Parameters.Add("@FINDROLEITEMID", SqlDbType.Int);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.EnterpriseCode);
                findParaRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleGroupCode);
                findParaRoleCategoryID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategoryID);
                findParaRoleCategorySubID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategorySubID);
                findParaRoleItemID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleItemID);


#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToRoleGroupAuthWorkFromReader(ref myReader, ref roleGroupAuthWork);
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
        /// ���[���O���[�v�����ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="roleGroupAuthList">�����폜���郍�[���O���[�v�����ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v�����ݒ�}�X�^�̃L�[�l����v���郍�[���O���[�v�����ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int Delete(object roleGroupAuthList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = roleGroupAuthList as ArrayList;

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
        /// ���[���O���[�v�����ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="roleGroupAuthList">���[���O���[�v�����ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList �Ɋi�[����Ă��郍�[���O���[�v�����ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int Delete(ArrayList roleGroupAuthList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(roleGroupAuthList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="roleGroupAuthList">���[���O���[�v�����ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList �Ɋi�[����Ă��郍�[���O���[�v�����ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        private int DeleteProc(ArrayList roleGroupAuthList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (roleGroupAuthList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < roleGroupAuthList.Count; i++)
                    {
                        RoleGroupAuthWork roleGroupAuthWork = roleGroupAuthList[i] as RoleGroupAuthWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM   ROLEGRPAUTHRTSTRF" + Environment.NewLine;
                        sqlText += "WHERE  ENTERPRISECODERF    = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND  ROLEGROUPCODERF     = @FINDROLEGROUPCODE" + Environment.NewLine;
                        sqlText += "  AND  ROLECATEGORYIDRF    = @FINDROLECATEGORYID" + Environment.NewLine;
                        sqlText += "  AND  ROLECATEGORYSUBIDRF = @FINDROLECATEGORYSUBID" + Environment.NewLine;
                        sqlText += "  AND  ROLEITEMIDRF        = @FINDROLEITEMID" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaRoleCategoryID = sqlCommand.Parameters.Add("@FINDROLECATEGORYID", SqlDbType.Int);
                        SqlParameter findParaRoleCategorySubID = sqlCommand.Parameters.Add("@FINDROLECATEGORYSUBID", SqlDbType.Int);
                        SqlParameter findParaRoleItemID = sqlCommand.Parameters.Add("@FINDROLEITEMID", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.EnterpriseCode);
                        findParaRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleGroupCode);
                        findParaRoleCategoryID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategoryID);
                        findParaRoleCategorySubID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategorySubID);
                        findParaRoleItemID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleItemID);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != roleGroupAuthWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM   ROLEGRPAUTHRTSTRF" + Environment.NewLine;
                            sqlText += "WHERE  ENTERPRISECODERF    = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND  ROLEGROUPCODERF     = @FINDROLEGROUPCODE" + Environment.NewLine;
                            sqlText += "  AND  ROLECATEGORYIDRF    = @FINDROLECATEGORYID" + Environment.NewLine;
                            sqlText += "  AND  ROLECATEGORYSUBIDRF = @FINDROLECATEGORYSUBID" + Environment.NewLine;
                            sqlText += "  AND  ROLEITEMIDRF        = @FINDROLEITEMID" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.EnterpriseCode);
                            findParaRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleGroupCode);
                            findParaRoleCategoryID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategoryID);
                            findParaRoleCategorySubID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategorySubID);
                            findParaRoleItemID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleItemID);

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
        /// ���[���O���[�v�����ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="roleGroupAuthList">��������</param>
        /// <param name="roleGroupAuthObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v�����ݒ�}�X�^�̃L�[�l����v����A�S�Ă̎Ԏ햼�̃}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int Search(ref object roleGroupAuthList, object roleGroupAuthObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;


            try
            {
                ArrayList roleGroupAuthArray = roleGroupAuthList as ArrayList;
                RoleGroupAuthWork roleGroupAuthWork = roleGroupAuthObj as RoleGroupAuthWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref roleGroupAuthArray, roleGroupAuthWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// ���[���O���[�v�����ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="roleGroupAuthList">���[���O���[�v�����ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="roleGroupAuthWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v�����ݒ�}�X�^�̃L�[�l����v����A�S�Ẵ��[���O���[�v�����ݒ�}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int Search(ref ArrayList roleGroupAuthList, RoleGroupAuthWork roleGroupAuthWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref roleGroupAuthList, roleGroupAuthWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="roleGroupAuthList">���[���O���[�v�����ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="modelNamroleGroupAuthWorkeUWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v�����ݒ�}�X�^�̃L�[�l����v����A�S�Ẵ��[���O���[�v�����ݒ�}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        private int SearchProc(ref ArrayList roleGroupAuthList, RoleGroupAuthWork roleGroupAuthWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT *" + Environment.NewLine;
                sqlText += "FROM   ROLEGRPAUTHRTSTRF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, roleGroupAuthWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    roleGroupAuthList.Add(this.CopyToRoleGroupAuthWorkFromReader(ref myReader));
                }

                if (roleGroupAuthList.Count > 0)
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
        /// ���[���O���[�v�����ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="roleGroupAuthList">�ǉ��E�X�V���郍�[���O���[�v�����ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList �Ɋi�[����Ă���Ԏ햼�̃}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int Write(ref object roleGroupAuthList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = roleGroupAuthList as ArrayList;

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
        /// ���[���O���[�v�����ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="roleGroupAuthList">�ǉ��E�X�V���郍�[���O���[�v�����ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList�Ɋi�[����Ă��郍�[���O���[�v�����ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int Write(ref ArrayList roleGroupAuthList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref roleGroupAuthList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="roleGroupAuthList">�ǉ��E�X�V���郍�[���O���[�v�����ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList �Ɋi�[����Ă��郍�[���O���[�v�����ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        private int WriteProc(ref ArrayList roleGroupAuthList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (roleGroupAuthList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < roleGroupAuthList.Count; i++)
                    {
                        RoleGroupAuthWork roleGroupAuthWork = roleGroupAuthList[i] as RoleGroupAuthWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM   ROLEGRPAUTHRTSTRF" + Environment.NewLine;
                        sqlText += "WHERE  ENTERPRISECODERF    = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND  ROLEGROUPCODERF     = @FINDROLEGROUPCODE" + Environment.NewLine;
                        sqlText += "  AND  ROLECATEGORYIDRF    = @FINDROLECATEGORYID" + Environment.NewLine;
                        sqlText += "  AND  ROLECATEGORYSUBIDRF = @FINDROLECATEGORYSUBID" + Environment.NewLine;
                        sqlText += "  AND  ROLEITEMIDRF        = @FINDROLEITEMID" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaRoleCategoryID = sqlCommand.Parameters.Add("@FINDROLECATEGORYID", SqlDbType.Int);
                        SqlParameter findParaRoleCategorySubID = sqlCommand.Parameters.Add("@FINDROLECATEGORYSUBID", SqlDbType.Int);
                        SqlParameter findParaRoleItemID = sqlCommand.Parameters.Add("@FINDROLEITEMID", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.EnterpriseCode);
                        findParaRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleGroupCode);
                        findParaRoleCategoryID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategoryID);
                        findParaRoleCategorySubID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategorySubID);
                        findParaRoleItemID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleItemID);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != roleGroupAuthWork.UpdateDateTime)
                            {
                                if (roleGroupAuthWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText += "UPDATE ROLEGRPAUTHRTSTRF" + Environment.NewLine;
                            sqlText += "SET    CREATEDATETIMERF    = @CREATEDATETIME," + Environment.NewLine;
                            sqlText += "       UPDATEDATETIMERF    = @UPDATEDATETIME," + Environment.NewLine;
                            sqlText += "       ENTERPRISECODERF    = @ENTERPRISECODE," + Environment.NewLine;
                            sqlText += "       FILEHEADERGUIDRF    = @FILEHEADERGUID," + Environment.NewLine;
                            sqlText += "       UPDEMPLOYEECODERF   = @UPDEMPLOYEECODE," + Environment.NewLine;
                            sqlText += "       UPDASSEMBLYID1RF    = @UPDASSEMBLYID1," + Environment.NewLine;
                            sqlText += "       UPDASSEMBLYID2RF    = @UPDASSEMBLYID2," + Environment.NewLine;
                            sqlText += "       LOGICALDELETECODERF = @LOGICALDELETECODE," + Environment.NewLine;
                            sqlText += "       ROLEGROUPCODERF     = @ROLEGROUPCODE," + Environment.NewLine;
                            sqlText += "       ROLECATEGORYIDRF    = @ROLECATEGORYID," + Environment.NewLine;
                            sqlText += "       ROLECATEGORYSUBIDRF = @ROLECATEGORYSUBID," + Environment.NewLine;
                            sqlText += "       ROLEITEMIDRF        = @ROLEITEMID," + Environment.NewLine;
                            sqlText += "       ROLELIMITDIVRF      = @ROLELIMITDIV" + Environment.NewLine;
                            sqlText += "WHERE  ENTERPRISECODERF    = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND  ROLEGROPCODERF      = @FINDROLEGROPCODE" + Environment.NewLine;
                            sqlText += "  AND  ROLECATEGORYIDRF    = @FINDROLECATEGORYID" + Environment.NewLine;
                            sqlText += "  AND  ROLECATEGORYSUBIDRF = @FINDROLECATEGORYSUBID" + Environment.NewLine;
                            sqlText += "  AND  ROLEITEMIDRF        = @FINDROLEITEMID" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.EnterpriseCode);
                            findParaRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleGroupCode);
                            findParaRoleCategoryID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategoryID);
                            findParaRoleCategorySubID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategorySubID);
                            findParaRoleItemID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleItemID);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)roleGroupAuthWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (roleGroupAuthWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO ROLEGRPAUTHRTSTRF (" + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF," + Environment.NewLine;
                            sqlText += "    UPDATEDATETIMERF," + Environment.NewLine;
                            sqlText += "    ENTERPRISECODERF," + Environment.NewLine;
                            sqlText += "    FILEHEADERGUIDRF," + Environment.NewLine;
                            sqlText += "    UPDEMPLOYEECODERF," + Environment.NewLine;
                            sqlText += "    UPDASSEMBLYID1RF," + Environment.NewLine;
                            sqlText += "    UPDASSEMBLYID2RF," + Environment.NewLine;
                            sqlText += "    LOGICALDELETECODERF," + Environment.NewLine;
                            sqlText += "    ROLEGROUPCODERF," + Environment.NewLine;
                            sqlText += "    ROLECATEGORYIDRF," + Environment.NewLine;
                            sqlText += "    ROLECATEGORYSUBIDRF," + Environment.NewLine;
                            sqlText += "    ROLEITEMIDRF," + Environment.NewLine;
                            sqlText += "    ROLELIMITDIVRF" + Environment.NewLine;
                            sqlText += ") VALUES (" + Environment.NewLine;
                            sqlText += "    @CREATEDATETIME," + Environment.NewLine;
                            sqlText += "    @UPDATEDATETIME," + Environment.NewLine;
                            sqlText += "    @ENTERPRISECODE," + Environment.NewLine;
                            sqlText += "    @FILEHEADERGUID," + Environment.NewLine;
                            sqlText += "    @UPDEMPLOYEECODE," + Environment.NewLine;
                            sqlText += "    @UPDASSEMBLYID1," + Environment.NewLine;
                            sqlText += "    @UPDASSEMBLYID2," + Environment.NewLine;
                            sqlText += "    @LOGICALDELETECODE," + Environment.NewLine;
                            sqlText += "    @ROLEGROUPCODE," + Environment.NewLine;
                            sqlText += "    @ROLECATEGORYID," + Environment.NewLine;
                            sqlText += "    @ROLECATEGORYSUBID," + Environment.NewLine;
                            sqlText += "    @ROLEITEMID," + Environment.NewLine;
                            sqlText += "    @ROLELIMITDIV" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;

                            IFileHeader flhd = (IFileHeader)roleGroupAuthWork;
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
                        SqlParameter paraRoleGroupCode = sqlCommand.Parameters.Add("@ROLEGROUPCODE", SqlDbType.Int);
                        SqlParameter paraRoleCategoryID = sqlCommand.Parameters.Add("@ROLECATEGORYID", SqlDbType.Int);
                        SqlParameter paraRoleCategorySubID = sqlCommand.Parameters.Add("@ROLECATEGORYSUBID", SqlDbType.Int);
                        SqlParameter paraRoleItemID = sqlCommand.Parameters.Add("@ROLEITEMID", SqlDbType.Int);
                        SqlParameter paraRoleLimitDiv = sqlCommand.Parameters.Add("@ROLELIMITDIV", SqlDbType.Int);

                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(roleGroupAuthWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(roleGroupAuthWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(roleGroupAuthWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.LogicalDeleteCode);
                        paraRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleGroupCode);
                        paraRoleCategoryID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategoryID);
                        paraRoleCategorySubID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategorySubID);
                        paraRoleItemID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleItemID);
                        paraRoleLimitDiv.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleLimitDiv);

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(roleGroupAuthWork);
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

            roleGroupAuthList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="roleGroupAuthList">�_���폜���郍�[���O���[�v�����ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList �Ɋi�[����Ă��郍�[���O���[�v�����ݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int LogicalDelete(ref object roleGroupAuthList)
        {
            return this.LogicalDelete(ref roleGroupAuthList, 0);
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="roleGroupAuthList">�_���폜���������郍�[���O���[�v�����ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList �Ɋi�[����Ă��郍�[���O���[�v�����ݒ�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int RevivalLogicalDelete(ref object roleGroupAuthList)
        {
            return this.LogicalDelete(ref roleGroupAuthList, 1);
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="roleGroupAuthList">�_���폜�𑀍삷�郍�[���O���[�v�����ݒ�}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList �Ɋi�[����Ă��郍�[���O���[�v�����}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        private int LogicalDelete(ref object roleGroupAuthList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = roleGroupAuthList as ArrayList;

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
        /// ���[���O���[�v�����ݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="roleGroupAuthList">�_���폜�𑀍삷�郍�[���O���[�v�����ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList �Ɋi�[����Ă��郍�[���O���[�v�����ݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int LogicalDelete(ref ArrayList roleGroupAuthList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref roleGroupAuthList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="roleGroupAuthList">�_���폜�𑀍삷�郍�[���O���[�v�����ݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : roleGroupAuthList �Ɋi�[����Ă��郍�[���O���[�v�����ݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        private int LogicalDeleteProc(ref ArrayList roleGroupAuthList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (roleGroupAuthList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < roleGroupAuthList.Count; i++)
                    {
                        RoleGroupAuthWork roleGroupAuthWork = roleGroupAuthList[i] as RoleGroupAuthWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF," + Environment.NewLine;
                        sqlText += "       LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM   ROLEGRPAUTHRTSTRF" + Environment.NewLine;
                        sqlText += "WHERE  ENTERPRISECODERF    = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND  ROLEGROUPCODERF     = @FINDROLEGROUPCODE" + Environment.NewLine;
                        sqlText += "  AND  ROLECATEGORYIDRF    = @FINDROLECATEGORYID" + Environment.NewLine;
                        sqlText += "  AND  ROLECATEGORYSUBIDRF = @FINDROLECATEGORYSUBID" + Environment.NewLine;
                        sqlText += "  AND  ROLEITEMIDRF        = @FINDROLEITEMID" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaRoleCategoryID = sqlCommand.Parameters.Add("@FINDROLECATEGORYID", SqlDbType.Int);
                        SqlParameter findParaRoleCategorySubID = sqlCommand.Parameters.Add("@FINDROLECATEGORYSUBID", SqlDbType.Int);
                        SqlParameter findParaRoleItemID = sqlCommand.Parameters.Add("@FINDROLEITEMID", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.EnterpriseCode);
                        findParaRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleGroupCode);
                        findParaRoleCategoryID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategoryID);
                        findParaRoleCategorySubID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategorySubID);
                        findParaRoleItemID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleItemID);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != roleGroupAuthWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE ROLEGRPAUTHRTSTRF" + Environment.NewLine;
                            sqlText += "SET    UPDATEDATETIMERF    = @UPDATEDATETIME," + Environment.NewLine;
                            sqlText += "       UPDEMPLOYEECODERF   = @UPDEMPLOYEECODE," + Environment.NewLine;
                            sqlText += "       UPDASSEMBLYID1RF    = @UPDASSEMBLYID1," + Environment.NewLine;
                            sqlText += "       UPDASSEMBLYID2RF    = @UPDASSEMBLYID2," + Environment.NewLine;
                            sqlText += "       LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE  ENTERPRISECODERF    = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND  ROLEGROUPCODERF     = @FINDROLEGROUPCODE" + Environment.NewLine;
                            sqlText += "  AND  ROLECATEGORYIDRF    = @FINDROLECATEGORYID" + Environment.NewLine;
                            sqlText += "  AND  ROLECATEGORYSUBIDRF = @FINDROLECATEGORYSUBID" + Environment.NewLine;
                            sqlText += "  AND  ROLEITEMIDRF        = @FINDROLEITEMID" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.EnterpriseCode);
                            findParaRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleGroupCode);
                            findParaRoleCategoryID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategoryID);
                            findParaRoleCategorySubID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategorySubID);
                            findParaRoleItemID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleItemID);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)roleGroupAuthWork;
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
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;             // ���ɍ폜�ς݂̏ꍇ����
                                return status;
                            }
                            else if (logicalDelCd == 0) roleGroupAuthWork.LogicalDeleteCode = 1;    // �_���폜�t���O���Z�b�g
                            else roleGroupAuthWork.LogicalDeleteCode = 3;                           // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                roleGroupAuthWork.LogicalDeleteCode = 0;                            // �_���폜�t���O������
                            }
                            else
                            {
                                if (logicalDelCd == 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;         // ���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;      // ���S�폜�̓f�[�^�Ȃ���߂�
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(roleGroupAuthWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(roleGroupAuthWork);
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

            roleGroupAuthList = al;

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="roleGroupAuthWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, RoleGroupAuthWork roleGroupAuthWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE  ";

            // ��ƃR�[�h
            retstring += "ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupAuthWork.EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // ���[���O���[�v�R�[�h���w�肳��Ă����璊�o�����ɒǉ�
            if (roleGroupAuthWork.RoleGroupCode != 0)
            {
                retstring += "  AND  ROLEGROUPCODERF = @FINDROLEGROUPCODE" + Environment.NewLine;
                SqlParameter findRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);
                findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleGroupCode);

                // �J�e�S��ID���w�肳��Ă����璊�o�����ɒǉ�
                if (roleGroupAuthWork.RoleCategoryID != 0)
                {
                    retstring += "  AND  ROLECATEGORYIDRF = @FINDROLECATEGORYID" + Environment.NewLine;
                    SqlParameter findRoleCategoryID = sqlCommand.Parameters.Add("@FINDROLECATEGORYID", SqlDbType.Int);
                    findRoleCategoryID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategoryID);

                    // �T�u�J�e�S��ID���w�肳��Ă����璊�o�����ɒǉ�
                    if (roleGroupAuthWork.RoleCategorySubID != 0)
                    {
                        retstring += "  AND  ROLECATEGORYSUBIDRF = @FINDROLECATEGORYSUBID" + Environment.NewLine;
                        SqlParameter findRoleCategorySubID = sqlCommand.Parameters.Add("@FINDROLECATEGORYSUBID", SqlDbType.Int);
                        findRoleCategorySubID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleCategorySubID);

                        // �A�C�e��ID���w�肳��Ă����璊�o�����ɒǉ�
                        if (roleGroupAuthWork.RoleItemID != 0)
                        {
                            retstring += "  AND  ROLEITEMIDRF = @FINDROLEITEMID" + Environment.NewLine;
                            SqlParameter findRoleItemID = sqlCommand.Parameters.Add("@FINDROLEITEMID", SqlDbType.Int);
                            findRoleItemID.Value = SqlDataMediator.SqlSetInt32(roleGroupAuthWork.RoleItemID);
                        }
                    }
                }
            }

            return retstring;
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� RoleGroupAuthWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RoleGroupAuthWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private RoleGroupAuthWork CopyToRoleGroupAuthWorkFromReader(ref SqlDataReader myReader)
        {
            RoleGroupAuthWork roleGroupAuthWork = new RoleGroupAuthWork();

            this.CopyToRoleGroupAuthWorkFromReader(ref myReader, ref roleGroupAuthWork);

            return roleGroupAuthWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� RoleGroupAuthWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="roleGroupAuthWork">RoleGroupAuthWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private void CopyToRoleGroupAuthWorkFromReader(ref SqlDataReader myReader, ref RoleGroupAuthWork roleGroupAuthWork)
        {
            if (myReader != null && roleGroupAuthWork != null)
            {
                # region �N���X�֊i�[
                roleGroupAuthWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                roleGroupAuthWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                roleGroupAuthWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                roleGroupAuthWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                roleGroupAuthWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                roleGroupAuthWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                roleGroupAuthWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                roleGroupAuthWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                roleGroupAuthWork.RoleGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLEGROUPCODERF"));
                roleGroupAuthWork.RoleCategoryID = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLECATEGORYIDRF"));
                roleGroupAuthWork.RoleCategorySubID = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLECATEGORYSUBIDRF"));
                roleGroupAuthWork.RoleItemID = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLEITEMIDRF"));
                roleGroupAuthWork.RoleLimitDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLELIMITDIVRF"));

                # endregion
            }
        }
        # endregion

    }
}