//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE ���Аݒ�}�X�^DB�����[�g�I�u�W�F�N�g
//                  :   PMUOE09044R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 �D�c �E�l
// Date             :   2008.06.06
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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// UOE ���Аݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE ���Аݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class UOESettingDB : RemoteWithAppLockDB, IUOESettingDB, IGetSyncdataList
    {
        /// <summary>
        /// UOE ���Аݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        public UOESettingDB() : base("PMUOE09046D", "Broadleaf.Application.Remoting.ParamData.UOESettingWork", "UOESettingRF")
        {

        }

        # region [Read]
        /// <summary>
        /// �P���UOE ���Аݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="uoeSettingObj">UOESettingWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ���Аݒ�}�X�^�̃L�[�l����v����UOE ���Аݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Read(ref object uoeSettingObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                UOESettingWork uoeSettingWork = uoeSettingObj as UOESettingWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref uoeSettingWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// �P���UOE ���Аݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="uoeSettingWork">UOESettingWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ���Аݒ�}�X�^�̃L�[�l����v����UOE ���Аݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Read(ref UOESettingWork uoeSettingWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref uoeSettingWork, readMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// �P���UOE ���Аݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="uoeSettingWork">UOESettingWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ���Аݒ�}�X�^�̃L�[�l����v����UOE ���Аݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int ReadProc(ref UOESettingWork uoeSettingWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SLIPOUTPUTDIVCDRF" + Environment.NewLine;
                sqlText += "    ,FOLLOWSLIPOUTPUTDIVRF" + Environment.NewLine;
                sqlText += "    ,ADDUPADATEDIVRF" + Environment.NewLine;
                sqlText += "    ,STOCKBLNKTPRTNODIVRF" + Environment.NewLine;
                sqlText += "    ,MAKERFOLLOWADDUPDIVRF" + Environment.NewLine;
                sqlText += "    ,CIRCUITERRPRTDIVRF" + Environment.NewLine;
                sqlText += "    ,DISTENTERDIVRF" + Environment.NewLine;
                sqlText += "    ,DISTSECTIONSETDIVRF" + Environment.NewLine;
                sqlText += "    ,MEIJIREMARKRF" + Environment.NewLine;
                sqlText += "    ,INPSEARCHREMARKRF" + Environment.NewLine;
                sqlText += "    ,STOCKBLNKTREMARKRF" + Environment.NewLine;
                sqlText += "    ,SLIPOUTPUTREMARKRF" + Environment.NewLine;
                sqlText += "    ,SLIPOUTPUTREMARKDIVRF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " FROM UOESETTINGRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.SectionCode);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToUOESettingWorkFromReader(ref myReader, ref uoeSettingWork);
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
        /// UOE ���Аݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeSettingList">�����폜����UOE ���Аݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ���Аݒ�}�X�^�̃L�[�l����v����UOE ���Аݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Delete(object uoeSettingList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = uoeSettingList as ArrayList;

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
        /// UOE ���Аݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeSettingList">UOE ���Аݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESettingList �Ɋi�[����Ă���UOE ���Аݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Delete(ArrayList uoeSettingList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(uoeSettingList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// UOE ���Аݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeSettingList">UOE ���Аݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESettingList �Ɋi�[����Ă���UOE ���Аݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int DeleteProc(ArrayList uoeSettingList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (uoeSettingList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeSettingList.Count; i++)
                    {
                        UOESettingWork uoeSettingWork = uoeSettingList[i] as UOESettingWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM UOESETTINGRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != uoeSettingWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM UOESETTINGRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.SectionCode);

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
        /// UOE ���Аݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeSettingList">��������</param>
        /// <param name="uoeSettingObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ���Аݒ�}�X�^�̃L�[�l����v����A�S�Ă�UOE ���Аݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Search(ref object uoeSettingList, object uoeSettingObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList uoeSettingArray = uoeSettingList as ArrayList;

                if (uoeSettingArray == null)
                {
                    uoeSettingArray = new ArrayList();
                }

                UOESettingWork uoeSettingWork = uoeSettingObj as UOESettingWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref uoeSettingArray, uoeSettingWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// UOE ���Аݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeSettingList">UOE ���Аݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="uoeSettingWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ���Аݒ�}�X�^�̃L�[�l����v����A�S�Ă�UOE ���Аݒ�}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Search(ref ArrayList uoeSettingList, UOESettingWork uoeSettingWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref uoeSettingList, uoeSettingWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// UOE ���Аݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeSettingList">UOE ���Аݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="uoeSettingWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ���Аݒ�}�X�^�̃L�[�l����v����A�S�Ă�UOE ���Аݒ�}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int SearchProc(ref ArrayList uoeSettingList, UOESettingWork uoeSettingWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SLIPOUTPUTDIVCDRF" + Environment.NewLine;
                sqlText += "    ,FOLLOWSLIPOUTPUTDIVRF" + Environment.NewLine;
                sqlText += "    ,ADDUPADATEDIVRF" + Environment.NewLine;
                sqlText += "    ,STOCKBLNKTPRTNODIVRF" + Environment.NewLine;
                sqlText += "    ,MAKERFOLLOWADDUPDIVRF" + Environment.NewLine;
                sqlText += "    ,CIRCUITERRPRTDIVRF" + Environment.NewLine;
                sqlText += "    ,DISTENTERDIVRF" + Environment.NewLine;
                sqlText += "    ,DISTSECTIONSETDIVRF" + Environment.NewLine;
                sqlText += "    ,MEIJIREMARKRF" + Environment.NewLine;
                sqlText += "    ,INPSEARCHREMARKRF" + Environment.NewLine;
                sqlText += "    ,STOCKBLNKTREMARKRF" + Environment.NewLine;
                sqlText += "    ,SLIPOUTPUTREMARKRF" + Environment.NewLine;
                sqlText += "    ,SLIPOUTPUTREMARKDIVRF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " FROM UOESETTINGRF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, uoeSettingWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    uoeSettingList.Add(this.CopyToUOESettingWorkFromReader(ref myReader));
                }

                if (uoeSettingList.Count > 0)
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
        /// UOE ���Аݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeSettingList">�ǉ��E�X�V����UOE ���Аݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESettingList �Ɋi�[����Ă���UOE ���Аݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Write(ref object uoeSettingList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = uoeSettingList as ArrayList;

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
        /// UOE ���Аݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeSettingList">�ǉ��E�X�V����UOE ���Аݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESettingList �Ɋi�[����Ă���UOE ���Аݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Write(ref ArrayList uoeSettingList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref uoeSettingList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// UOE ���Аݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeSettingList">�ǉ��E�X�V����UOE ���Аݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESettingList �Ɋi�[����Ă���UOE ���Аݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int WriteProc(ref ArrayList uoeSettingList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (uoeSettingList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeSettingList.Count; i++)
                    {
                        UOESettingWork uoeSettingWork = uoeSettingList[i] as UOESettingWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM UOESETTINGRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != uoeSettingWork.UpdateDateTime)
                            {
                                if (uoeSettingWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText += "UPDATE UOESETTINGRF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , SLIPOUTPUTDIVCDRF=@SLIPOUTPUTDIVCD" + Environment.NewLine;
                            sqlText += " , FOLLOWSLIPOUTPUTDIVRF=@FOLLOWSLIPOUTPUTDIV" + Environment.NewLine;
                            sqlText += " , ADDUPADATEDIVRF=@ADDUPADATEDIV" + Environment.NewLine;
                            sqlText += " , STOCKBLNKTPRTNODIVRF=@STOCKBLNKTPRTNODIV" + Environment.NewLine;
                            sqlText += " , MAKERFOLLOWADDUPDIVRF=@MAKERFOLLOWADDUPDIV" + Environment.NewLine;
                            sqlText += " , CIRCUITERRPRTDIVRF=@CIRCUITERRPRTDIV" + Environment.NewLine;
                            sqlText += " , DISTENTERDIVRF=@DISTENTERDIV" + Environment.NewLine;
                            sqlText += " , DISTSECTIONSETDIVRF=@DISTSECTIONSETDIV" + Environment.NewLine;
                            sqlText += " , MEIJIREMARKRF=@MEIJIREMARK" + Environment.NewLine;
                            sqlText += " , INPSEARCHREMARKRF=@INPSEARCHREMARK" + Environment.NewLine;
                            sqlText += " , STOCKBLNKTREMARKRF=@STOCKBLNKTREMARK" + Environment.NewLine;
                            sqlText += " , SLIPOUTPUTREMARKRF=@SLIPOUTPUTREMARK" + Environment.NewLine;
                            sqlText += " , SLIPOUTPUTREMARKDIVRF=@SLIPOUTPUTREMARKDIV" + Environment.NewLine;
                            sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlText += " , UOESLIPPRTDIVRF=@UOESLIPPRTDIV" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.SectionCode);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeSettingWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (uoeSettingWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO UOESETTINGRF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,SLIPOUTPUTDIVCDRF" + Environment.NewLine;
                            sqlText += "    ,FOLLOWSLIPOUTPUTDIVRF" + Environment.NewLine;
                            sqlText += "    ,ADDUPADATEDIVRF" + Environment.NewLine;
                            sqlText += "    ,STOCKBLNKTPRTNODIVRF" + Environment.NewLine;
                            sqlText += "    ,MAKERFOLLOWADDUPDIVRF" + Environment.NewLine;
                            sqlText += "    ,CIRCUITERRPRTDIVRF" + Environment.NewLine;
                            sqlText += "    ,DISTENTERDIVRF" + Environment.NewLine;
                            sqlText += "    ,DISTSECTIONSETDIVRF" + Environment.NewLine;
                            sqlText += "    ,MEIJIREMARKRF" + Environment.NewLine;
                            sqlText += "    ,INPSEARCHREMARKRF" + Environment.NewLine;
                            sqlText += "    ,STOCKBLNKTREMARKRF" + Environment.NewLine;
                            sqlText += "    ,SLIPOUTPUTREMARKRF" + Environment.NewLine;
                            sqlText += "    ,SLIPOUTPUTREMARKDIVRF" + Environment.NewLine;
                            sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += "    ,UOESLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,@SLIPOUTPUTDIVCD" + Environment.NewLine;
                            sqlText += "    ,@FOLLOWSLIPOUTPUTDIV" + Environment.NewLine;
                            sqlText += "    ,@ADDUPADATEDIV" + Environment.NewLine;
                            sqlText += "    ,@STOCKBLNKTPRTNODIV" + Environment.NewLine;
                            sqlText += "    ,@MAKERFOLLOWADDUPDIV" + Environment.NewLine;
                            sqlText += "    ,@CIRCUITERRPRTDIV" + Environment.NewLine;
                            sqlText += "    ,@DISTENTERDIV" + Environment.NewLine;
                            sqlText += "    ,@DISTSECTIONSETDIV" + Environment.NewLine;
                            sqlText += "    ,@MEIJIREMARK" + Environment.NewLine;
                            sqlText += "    ,@INPSEARCHREMARK" + Environment.NewLine;
                            sqlText += "    ,@STOCKBLNKTREMARK" + Environment.NewLine;
                            sqlText += "    ,@SLIPOUTPUTREMARK" + Environment.NewLine;
                            sqlText += "    ,@SLIPOUTPUTREMARKDIV" + Environment.NewLine;
                            sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += "    ,@UOESLIPPRTDIV" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeSettingWork;
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
                        SqlParameter paraSlipOutputDivCd = sqlCommand.Parameters.Add("@SLIPOUTPUTDIVCD", SqlDbType.Int);
                        SqlParameter paraFollowSlipOutputDiv = sqlCommand.Parameters.Add("@FOLLOWSLIPOUTPUTDIV", SqlDbType.Int);
                        SqlParameter paraAddUpADateDiv = sqlCommand.Parameters.Add("@ADDUPADATEDIV", SqlDbType.Int);
                        SqlParameter paraStockBlnktPrtNoDiv = sqlCommand.Parameters.Add("@STOCKBLNKTPRTNODIV", SqlDbType.Int);
                        SqlParameter paraMakerFollowAddUpDiv = sqlCommand.Parameters.Add("@MAKERFOLLOWADDUPDIV", SqlDbType.Int);
                        SqlParameter paraCircuitErrPrtDiv = sqlCommand.Parameters.Add("@CIRCUITERRPRTDIV", SqlDbType.Int);
                        SqlParameter paraDistEnterDiv = sqlCommand.Parameters.Add("@DISTENTERDIV", SqlDbType.Int);
                        SqlParameter paraDistSectionSetDiv = sqlCommand.Parameters.Add("@DISTSECTIONSETDIV", SqlDbType.Int);
                        SqlParameter paraMeijiRemark = sqlCommand.Parameters.Add("@MEIJIREMARK", SqlDbType.Int);
                        SqlParameter paraInpSearchRemark = sqlCommand.Parameters.Add("@INPSEARCHREMARK", SqlDbType.NVarChar);
                        SqlParameter paraStockBlnktRemark = sqlCommand.Parameters.Add("@STOCKBLNKTREMARK", SqlDbType.NVarChar);
                        SqlParameter paraSlipOutputRemark = sqlCommand.Parameters.Add("@SLIPOUTPUTREMARK", SqlDbType.NVarChar);
                        SqlParameter paraSlipOutputRemarkDiv = sqlCommand.Parameters.Add("@SLIPOUTPUTREMARKDIV", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraUOESlipPrtDiv = sqlCommand.Parameters.Add("@UOESLIPPRTDIV", SqlDbType.Int);

                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeSettingWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeSettingWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(uoeSettingWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uoeSettingWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uoeSettingWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(uoeSettingWork.LogicalDeleteCode);
                        paraSlipOutputDivCd.Value = SqlDataMediator.SqlSetInt32(uoeSettingWork.SlipOutputDivCd);
                        paraFollowSlipOutputDiv.Value = SqlDataMediator.SqlSetInt32(uoeSettingWork.FollowSlipOutputDiv);
                        paraAddUpADateDiv.Value = SqlDataMediator.SqlSetInt32(uoeSettingWork.AddUpADateDiv);
                        paraStockBlnktPrtNoDiv.Value = SqlDataMediator.SqlSetInt32(uoeSettingWork.StockBlnktPrtNoDiv);
                        paraMakerFollowAddUpDiv.Value = SqlDataMediator.SqlSetInt32(uoeSettingWork.MakerFollowAddUpDiv);
                        paraCircuitErrPrtDiv.Value = SqlDataMediator.SqlSetInt32(uoeSettingWork.CircuitErrPrtDiv);
                        paraDistEnterDiv.Value = SqlDataMediator.SqlSetInt32(uoeSettingWork.DistEnterDiv);
                        paraDistSectionSetDiv.Value = SqlDataMediator.SqlSetInt32(uoeSettingWork.DistSectionSetDiv);
                        paraMeijiRemark.Value = SqlDataMediator.SqlSetInt32(uoeSettingWork.MeijiRemark);
                        paraInpSearchRemark.Value = SqlDataMediator.SqlSetString(uoeSettingWork.InpSearchRemark);
                        paraStockBlnktRemark.Value = SqlDataMediator.SqlSetString(uoeSettingWork.StockBlnktRemark);
                        paraSlipOutputRemark.Value = SqlDataMediator.SqlSetString(uoeSettingWork.SlipOutputRemark);
                        paraSlipOutputRemarkDiv.Value = SqlDataMediator.SqlSetInt32(uoeSettingWork.SlipOutputRemarkDiv);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.SectionCode);
                        paraUOESlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(uoeSettingWork.UOESlipPrtDiv);

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(uoeSettingWork);
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

            uoeSettingList = al;

            return status;
        }
        # endregion

        #region [GetSyncdataList]
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������UOE���Аݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081  �D�c�@�E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������UOE���Аݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081  �D�c�@�E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlText = string.Empty;
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SLIPOUTPUTDIVCDRF" + Environment.NewLine;
                sqlText += "    ,FOLLOWSLIPOUTPUTDIVRF" + Environment.NewLine;
                sqlText += "    ,ADDUPADATEDIVRF" + Environment.NewLine;
                sqlText += "    ,STOCKBLNKTPRTNODIVRF" + Environment.NewLine;
                sqlText += "    ,MAKERFOLLOWADDUPDIVRF" + Environment.NewLine;
                sqlText += "    ,CIRCUITERRPRTDIVRF" + Environment.NewLine;
                sqlText += "    ,DISTENTERDIVRF" + Environment.NewLine;
                sqlText += "    ,DISTSECTIONSETDIVRF" + Environment.NewLine;
                sqlText += "    ,MEIJIREMARKRF" + Environment.NewLine;
                sqlText += "    ,INPSEARCHREMARKRF" + Environment.NewLine;
                sqlText += "    ,STOCKBLNKTREMARKRF" + Environment.NewLine;
                sqlText += "    ,SLIPOUTPUTREMARKRF" + Environment.NewLine;
                sqlText += "    ,SLIPOUTPUTREMARKDIVRF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " FROM UOESETTINGRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToUOESettingWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            arraylistdata = al;

            return status;
        }
        #endregion

        # region [LogicalDelete]
        /// <summary>
        /// UOE ���Аݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="uoeSettingList">�_���폜����UOE ���Аݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESettingWork �Ɋi�[����Ă���UOE ���Аݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int LogicalDelete(ref object uoeSettingList)
        {
            return this.LogicalDelete(ref uoeSettingList, 0);
        }

        /// <summary>
        /// UOE ���Аݒ�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="uoeSettingList">�_���폜����������UOE ���Аݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESettingWork �Ɋi�[����Ă���UOE ���Аݒ�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int RevivalLogicalDelete(ref object uoeSettingList)
        {
            return this.LogicalDelete(ref uoeSettingList, 1);
        }

        /// <summary>
        /// UOE ���Аݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="uoeSettingList">�_���폜�𑀍삷��UOE ���Аݒ�}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESettingWork �Ɋi�[����Ă���UOE ���Аݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int LogicalDelete(ref object uoeSettingList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = uoeSettingList as ArrayList;

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
        /// UOE ���Аݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="uoeSettingList">�_���폜�𑀍삷��UOE ���Аݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESettingWork �Ɋi�[����Ă���UOE ���Аݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int LogicalDelete(ref ArrayList uoeSettingList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref uoeSettingList, procMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// UOE ���Аݒ�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="uoeSettingList">�_���폜�𑀍삷��UOE ���Аݒ�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESettingWork �Ɋi�[����Ă���UOE ���Аݒ�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int LogicalDeleteProc(ref ArrayList uoeSettingList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (uoeSettingList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeSettingList.Count; i++)
                    {
                        UOESettingWork uoeSettingWork = uoeSettingList[i] as UOESettingWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  UOESettingRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != uoeSettingWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  UOESettingRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.SectionCode);


                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeSettingWork;
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
                            else if (logicalDelCd == 0) uoeSettingWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else uoeSettingWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                uoeSettingWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeSettingWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uoeSettingWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uoeSettingWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(uoeSettingWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(uoeSettingWork);
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

            uoeSettingList = al;

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="uoeSettingWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, UOESettingWork uoeSettingWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // ��ƃR�[�h
            retstring += "  ENTERPRISECODERF = @FINDENTERPRISECODE"  + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.EnterpriseCode);
            // ���_�R�[�h
            retstring += "  SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
            SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            findSectionCode.Value = SqlDataMediator.SqlSetString(uoeSettingWork.SectionCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return retstring;
        }
        # endregion

        #region [�V���N�pWhere���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="syncServiceWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20081  �D�c�@�E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            // ���_�R�[�h
            retstring += "  SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
            SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            findSectionCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.SectionCode);

            //�����V���N�̏ꍇ�͍X�V���t�͈͎̔w��
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        #endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� UOESettingWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>UOESettingWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        private UOESettingWork CopyToUOESettingWorkFromReader(ref SqlDataReader myReader)
        {
            UOESettingWork uoeSettingWork = new UOESettingWork();

            this.CopyToUOESettingWorkFromReader(ref myReader, ref uoeSettingWork);

            return uoeSettingWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� UOESettingWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="uoeSettingWork">UOESettingWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        private void CopyToUOESettingWorkFromReader(ref SqlDataReader myReader, ref UOESettingWork uoeSettingWork)
        {
            if (myReader != null && uoeSettingWork != null)
            {
                # region �N���X�֊i�[
                uoeSettingWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                uoeSettingWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                uoeSettingWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                uoeSettingWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                uoeSettingWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                uoeSettingWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                uoeSettingWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                uoeSettingWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                uoeSettingWork.SlipOutputDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPOUTPUTDIVCDRF"));
                uoeSettingWork.FollowSlipOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FOLLOWSLIPOUTPUTDIVRF"));
                uoeSettingWork.AddUpADateDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPADATEDIVRF"));
                uoeSettingWork.StockBlnktPrtNoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKBLNKTPRTNODIVRF"));
                uoeSettingWork.MakerFollowAddUpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERFOLLOWADDUPDIVRF"));
                uoeSettingWork.CircuitErrPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CIRCUITERRPRTDIVRF"));
                uoeSettingWork.DistEnterDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISTENTERDIVRF"));
                uoeSettingWork.DistSectionSetDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISTSECTIONSETDIVRF"));
                uoeSettingWork.MeijiRemark = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MEIJIREMARKRF"));
                uoeSettingWork.InpSearchRemark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPSEARCHREMARKRF"));
                uoeSettingWork.StockBlnktRemark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKBLNKTREMARKRF"));
                uoeSettingWork.SlipOutputRemark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPOUTPUTREMARKRF"));
                uoeSettingWork.SlipOutputRemarkDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPOUTPUTREMARKDIVRF"));
                uoeSettingWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                uoeSettingWork.UOESlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESLIPPRTDIVRF"));
                # endregion
            }
        }
        # endregion

        # region [�R�l�N�V������������]
        /*
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
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
         /// <br>Programmer : 20081 �D�c �E�l</br>
         /// <br>Date       : 2008.06.06</br>
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
         */
        # endregion
    }
}
