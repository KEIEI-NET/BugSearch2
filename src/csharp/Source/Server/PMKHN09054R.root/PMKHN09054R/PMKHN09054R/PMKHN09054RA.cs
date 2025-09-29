//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���ʃ}�X�^DB�����[�g�I�u�W�F�N�g
//                  :   PMKHN09054R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008�@�����@���n
// Date             :   2008.06.11
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
    /// ���ʃ}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���ʃ}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008�@�����@���n</br>
    /// <br>Date       : 2008.06.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PartsPosCodeUDB : RemoteWithAppLockDB, IPartsPosCodeUDB
    {
        /// <summary>
        /// ���ʃ}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        public PartsPosCodeUDB() : base("PMKHN09056D", "Broadleaf.Application.Remoting.ParamData.PartsPosCodeUWork", "PARTSPOSCODEURF")
        {

        }

        # region [Read]
        /// <summary>
        /// �P��̕��ʃ}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="partsPosCodeUObj">PartsPosCodeUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���ʃ}�X�^�̃L�[�l����v���镔�ʃ}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int Read(ref object partsPosCodeUObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                PartsPosCodeUWork partsPosCodeUWork = partsPosCodeUObj as PartsPosCodeUWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref partsPosCodeUWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// �P��̕��ʃ}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="partsPosCodeUWork">PartsPosCodeUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���ʃ}�X�^�̃L�[�l����v���镔�ʃ}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int Read(ref PartsPosCodeUWork partsPosCodeUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref partsPosCodeUWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �P��̕��ʃ}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="partsPosCodeUWork">PartsPosCodeUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���ʃ}�X�^�̃L�[�l����v���镔�ʃ}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        private int ReadProc(ref PartsPosCodeUWork partsPosCodeUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "   CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  ,SEARCHPARTSPOSCODERF" + Environment.NewLine;
                sqlText += "  ,SEARCHPARTSPOSNAMERF" + Environment.NewLine;
                sqlText += "  ,POSDISPORDERRF" + Environment.NewLine;
                sqlText += "  ,TBSPARTSCODERF" + Environment.NewLine;
                sqlText += "  ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,OFFERDATADIVRF" + Environment.NewLine;
                sqlText += " FROM PARTSPOSCODEURF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                sqlText += "  AND SEARCHPARTSPOSCODERF=@FINDSEARCHPARTSPOSCODE" + Environment.NewLine;
                sqlText += "  AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaSearchPartsPosCode = sqlCommand.Parameters.Add("@FINDSEARCHPARTSPOSCODE", SqlDbType.Int);
                SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);


                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);
                findParaSectionCode.Value = partsPosCodeUWork.SectionCode;
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);
                findParaSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
                findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);


#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToPartsPosCodeUWorkFromReader(ref myReader, ref partsPosCodeUWork);
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
        /// ���ʃ}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="partsPosCodeUList">�����폜���镔�ʃ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���ʃ}�X�^�̃L�[�l����v���镔�ʃ}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int Delete(object partsPosCodeUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = partsPosCodeUList as ArrayList;

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
        /// ���ʃ}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="partsPosCodeUList">���ʃ}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUList �Ɋi�[����Ă��镔�ʃ}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int Delete(ArrayList partsPosCodeUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(partsPosCodeUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���ʃ}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="partsPosCodeUList">���ʃ}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUList �Ɋi�[����Ă��镔�ʃ}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        private int DeleteProc(ArrayList partsPosCodeUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (partsPosCodeUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < partsPosCodeUList.Count; i++)
                    {
                        PartsPosCodeUWork partsPosCodeUWork = partsPosCodeUList[i] as PartsPosCodeUWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PARTSPOSCODEURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND SEARCHPARTSPOSCODERF=@FINDSEARCHPARTSPOSCODE" + Environment.NewLine;
                        sqlText += "  AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaSearchPartsPosCode = sqlCommand.Parameters.Add("@FINDSEARCHPARTSPOSCODE", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);


                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);
                        findParaSectionCode.Value = partsPosCodeUWork.SectionCode;
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);
                        findParaSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != partsPosCodeUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  PARTSPOSCODEURF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND SEARCHPARTSPOSCODERF=@FINDSEARCHPARTSPOSCODE" + Environment.NewLine;
                            sqlText += "  AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);
                            findParaSectionCode.Value = partsPosCodeUWork.SectionCode;
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);
                            findParaSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
                            findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);

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
        /// ���ʃ}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="partsPosCodeUList">��������</param>
        /// <param name="partsPosCodeUObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���ʃ}�X�^�̃L�[�l����v����A�S�Ă̕��ʃ}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int Search(ref object partsPosCodeUList, object partsPosCodeUObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList partsPosCodeUArray = partsPosCodeUList as ArrayList;
                PartsPosCodeUWork partsPosCodeUWork = partsPosCodeUObj as PartsPosCodeUWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref partsPosCodeUArray, partsPosCodeUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// ���ʃ}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="partsPosCodeUList">���ʃ}�X�^�����i�[���� ArrayList</param>
        /// <param name="partsPosCodeUWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���ʃ}�X�^�̃L�[�l����v����A�S�Ă̕��ʃ}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int Search(ref ArrayList partsPosCodeUList, PartsPosCodeUWork partsPosCodeUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref partsPosCodeUList, partsPosCodeUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���ʃ}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="partsPosCodeUList">���ʃ}�X�^�����i�[���� ArrayList</param>
        /// <param name="partsPosCodeUWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���ʃ}�X�^�̃L�[�l����v����A�S�Ă̕��ʃ}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        private int SearchProc(ref ArrayList partsPosCodeUList, PartsPosCodeUWork partsPosCodeUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "   CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  ,SEARCHPARTSPOSCODERF" + Environment.NewLine;
                sqlText += "  ,SEARCHPARTSPOSNAMERF" + Environment.NewLine;
                sqlText += "  ,POSDISPORDERRF" + Environment.NewLine;
                sqlText += "  ,TBSPARTSCODERF" + Environment.NewLine;
                sqlText += "  ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,OFFERDATADIVRF" + Environment.NewLine;
                sqlText += " FROM PARTSPOSCODEURF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, partsPosCodeUWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    partsPosCodeUList.Add(this.CopyToPartsPosCodeUWorkFromReader(ref myReader));
                }

                if (partsPosCodeUList.Count > 0)
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
        /// ���ʃ}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="partsPosCodeUList">�ǉ��E�X�V���镔�ʃ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUList �Ɋi�[����Ă��镔�ʃ}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int Write(ref object partsPosCodeUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = partsPosCodeUList as ArrayList;

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
        /// ���ʃ}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="partsPosCodeUList">�ǉ��E�X�V���镔�ʃ}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUList �Ɋi�[����Ă��镔�ʃ}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int Write(ref ArrayList partsPosCodeUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref partsPosCodeUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���ʃ}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="partsPosCodeUList">�ǉ��E�X�V���镔�ʃ}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUList �Ɋi�[����Ă��镔�ʃ}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        private int WriteProc(ref ArrayList partsPosCodeUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (partsPosCodeUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < partsPosCodeUList.Count; i++)
                    {
                        PartsPosCodeUWork partsPosCodeUWork = partsPosCodeUList[i] as PartsPosCodeUWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PARTSPOSCODEURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND SEARCHPARTSPOSCODERF=@FINDSEARCHPARTSPOSCODE" + Environment.NewLine;
                        sqlText += "  AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaSearchPartsPosCode = sqlCommand.Parameters.Add("@FINDSEARCHPARTSPOSCODE", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);


                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);
                        findParaSectionCode.Value = partsPosCodeUWork.SectionCode.Trim();
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);
                        findParaSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != partsPosCodeUWork.UpdateDateTime)
                            {
                                if (partsPosCodeUWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText += "UPDATE PARTSPOSCODEURF SET" + Environment.NewLine;
                            sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlText += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " , SEARCHPARTSPOSCODERF=@SEARCHPARTSPOSCODE" + Environment.NewLine;
                            sqlText += " , SEARCHPARTSPOSNAMERF=@SEARCHPARTSPOSNAME" + Environment.NewLine;
                            sqlText += " , POSDISPORDERRF=@POSDISPORDER" + Environment.NewLine;
                            sqlText += " , TBSPARTSCODERF=@TBSPARTSCODE" + Environment.NewLine;
                            sqlText += " , TBSPARTSCDDERIVEDNORF=@TBSPARTSCDDERIVEDNO" + Environment.NewLine;
                            sqlText += " , OFFERDATERF = @OFFERDATE" + Environment.NewLine;
                            sqlText += " , OFFERDATADIVRF = @OFFERDATADIV" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND SEARCHPARTSPOSCODERF=@FINDSEARCHPARTSPOSCODE" + Environment.NewLine;
                            sqlText += "  AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);
                            findParaSectionCode.Value = partsPosCodeUWork.SectionCode;
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);
                            findParaSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
                            findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)partsPosCodeUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            //�񋟃f�[�^���C�������ꍇ�͒񋟃f�[�^�敪�ɂP���Z�b�g����
                            if ((partsPosCodeUWork.OfferDate != DateTime.MinValue) && (partsPosCodeUWork.OfferDataDiv == 0))
                            {
                                partsPosCodeUWork.OfferDataDiv = 1;
                            }
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (partsPosCodeUWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO PARTSPOSCODEURF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "  ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += "  ,SEARCHPARTSPOSCODERF" + Environment.NewLine;
                            sqlText += "  ,SEARCHPARTSPOSNAMERF" + Environment.NewLine;
                            sqlText += "  ,POSDISPORDERRF" + Environment.NewLine;
                            sqlText += "  ,TBSPARTSCODERF" + Environment.NewLine;
                            sqlText += "  ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                            sqlText += "  , OFFERDATERF" + Environment.NewLine;
                            sqlText += "  , OFFERDATADIVRF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "  ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += "  ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  ,@SEARCHPARTSPOSCODE" + Environment.NewLine;
                            sqlText += "  ,@SEARCHPARTSPOSNAME" + Environment.NewLine;
                            sqlText += "  ,@POSDISPORDER" + Environment.NewLine;
                            sqlText += "  ,@TBSPARTSCODE" + Environment.NewLine;
                            sqlText += "  ,@TBSPARTSCDDERIVEDNO" + Environment.NewLine;
                            sqlText += "  ,@OFFERDATE" + Environment.NewLine;
                            sqlText += "  ,@OFFERDATADIV" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)partsPosCodeUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // �쐬����
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // �X�V����
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // �X�V�]�ƈ��R�[�h
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // �X�V�A�Z���u��ID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // �X�V�A�Z���u��ID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // �_���폜�敪
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // ���_�R�[�h
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);  // ���Ӑ�R�[�h
                        SqlParameter paraSearchPartsPosCode = sqlCommand.Parameters.Add("@SEARCHPARTSPOSCODE", SqlDbType.Int);  // �������ʃR�[�h
                        SqlParameter paraSearchPartsPosName = sqlCommand.Parameters.Add("@SEARCHPARTSPOSNAME", SqlDbType.NVarChar);  // �������ʃR�[�h����
                        SqlParameter paraPosDispOrder = sqlCommand.Parameters.Add("@POSDISPORDER", SqlDbType.Int);  // �������ʕ\������
                        SqlParameter paraTbsPartsCode = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);  // �����i�R�[�h
                        SqlParameter paraTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@TBSPARTSCDDERIVEDNO", SqlDbType.Int);  // �����i�R�[�h�}��
                        SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);  // �񋟓��t
                        SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);  // �񋟃f�[�^�敪
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(partsPosCodeUWork.CreateDateTime);  // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(partsPosCodeUWork.UpdateDateTime);  // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);  // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(partsPosCodeUWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.UpdEmployeeCode);  // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.UpdAssemblyId1);  // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.UpdAssemblyId2);  // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.LogicalDeleteCode);  // �_���폜�敪
                        paraSectionCode.Value = partsPosCodeUWork.SectionCode.Trim();  // ���_�R�[�h
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);  // ���Ӑ�R�[�h
                        paraSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);  // �������ʃR�[�h
                        paraSearchPartsPosName.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.SearchPartsPosName);  // �������ʃR�[�h����
                        paraPosDispOrder.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.PosDispOrder);  // �������ʕ\������
                        paraTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);  // �����i�R�[�h
                        paraTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCdDerivedNo);  // �����i�R�[�h�}��
                        paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(partsPosCodeUWork.OfferDate);  // �񋟓��t
                        paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.OfferDataDiv);  // �񋟃f�[�^�敪
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(partsPosCodeUWork);
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

            partsPosCodeUList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// ���ʃ}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="partsPosCodeUList">�_���폜���镔�ʃ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUWork �Ɋi�[����Ă��镔�ʃ}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int LogicalDelete(ref object partsPosCodeUList)
        {
            return this.LogicalDelete(ref partsPosCodeUList, 0);
        }

        /// <summary>
        /// ���ʃ}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="partsPosCodeUList">�_���폜���������镔�ʃ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUWork �Ɋi�[����Ă��镔�ʃ}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int RevivalLogicalDelete(ref object partsPosCodeUList)
        {
            return this.LogicalDelete(ref partsPosCodeUList, 1);
        }

        /// <summary>
        /// ���ʃ}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="partsPosCodeUList">�_���폜�𑀍삷�镔�ʃ}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUWork �Ɋi�[����Ă��镔�ʃ}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        private int LogicalDelete(ref object partsPosCodeUList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = partsPosCodeUList as ArrayList;

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
        /// ���ʃ}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="partsPosCodeUList">�_���폜�𑀍삷�镔�ʃ}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUWork �Ɋi�[����Ă��镔�ʃ}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int LogicalDelete(ref ArrayList partsPosCodeUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref partsPosCodeUList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���ʃ}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="partsPosCodeUList">�_���폜�𑀍삷�镔�ʃ}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUWork �Ɋi�[����Ă��镔�ʃ}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        private int LogicalDeleteProc(ref ArrayList partsPosCodeUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (partsPosCodeUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < partsPosCodeUList.Count; i++)
                    {
                        PartsPosCodeUWork partsPosCodeUWork = partsPosCodeUList[i] as PartsPosCodeUWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PARTSPOSCODEURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND SEARCHPARTSPOSCODERF=@FINDSEARCHPARTSPOSCODE" + Environment.NewLine;
                        sqlText += "  AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaSearchPartsPosCode = sqlCommand.Parameters.Add("@FINDSEARCHPARTSPOSCODE", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);
                        findParaSectionCode.Value = partsPosCodeUWork.SectionCode;
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);
                        findParaSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != partsPosCodeUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  PARTSPOSCODEURF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND SEARCHPARTSPOSCODERF=@FINDSEARCHPARTSPOSCODE" + Environment.NewLine;
                            sqlText += "  AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            // Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);
                            findParaSectionCode.Value = partsPosCodeUWork.SectionCode;
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);
                            findParaSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
                            findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)partsPosCodeUWork;
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
                            else if (logicalDelCd == 0) partsPosCodeUWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else partsPosCodeUWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                partsPosCodeUWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(partsPosCodeUWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(partsPosCodeUWork);
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

            partsPosCodeUList = al;

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="partsPosCodeUWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, PartsPosCodeUWork partsPosCodeUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // ��ƃR�[�h
            retstring += "  ENTERPRISECODERF = @FINDENTERPRISECODE"  + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);

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
            
            //���_�R�[�h
            if (string.IsNullOrEmpty(partsPosCodeUWork.SectionCode) == false)
            {
                retstring += "AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = partsPosCodeUWork.SectionCode;
            }

            //���Ӑ�R�[�h
            if (partsPosCodeUWork.CustomerCode != 0)
            {
                retstring += "AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);

            }

            //�������ʃR�[�h
            if (partsPosCodeUWork.SearchPartsPosCode != 0)
            {
                retstring += "AND SEARCHPARTSPOSCODERF = @FINDSEARCHPARTSPOSCODE"  + Environment.NewLine;
                SqlParameter findSearchPartsPosCode = sqlCommand.Parameters.Add("@FINDSEARCHPARTSPOSCODE", SqlDbType.Int);
                findSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
            }    

            //BL�R�[�h
            if (partsPosCodeUWork.TbsPartsCode != 0)
            {
                retstring += "AND TBSPARTSCODERF = @FINDTBSPARTSCODE"  + Environment.NewLine;
                SqlParameter findTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                findTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);
            }    

            return retstring;
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� PartsPosCodeUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PartsPosCodeUWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        private PartsPosCodeUWork CopyToPartsPosCodeUWorkFromReader(ref SqlDataReader myReader)
        {
            PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();

            this.CopyToPartsPosCodeUWorkFromReader(ref myReader, ref partsPosCodeUWork);

            return partsPosCodeUWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� PartsPosCodeUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="partsPosCodeUWork">PartsPosCodeUWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        private void CopyToPartsPosCodeUWorkFromReader(ref SqlDataReader myReader, ref PartsPosCodeUWork partsPosCodeUWork)
        {
            if (myReader != null && partsPosCodeUWork != null)
            {
                # region �N���X�֊i�[
                partsPosCodeUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
                partsPosCodeUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
                partsPosCodeUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // ��ƃR�[�h
                partsPosCodeUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
                partsPosCodeUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // �X�V�]�ƈ��R�[�h
                partsPosCodeUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // �X�V�A�Z���u��ID1
                partsPosCodeUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // �X�V�A�Z���u��ID2
                partsPosCodeUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // �_���폜�敪
                partsPosCodeUWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // ���_�R�[�h
                partsPosCodeUWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // ���Ӑ�R�[�h
                partsPosCodeUWork.SearchPartsPosCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHPARTSPOSCODERF"));  // �������ʃR�[�h
                partsPosCodeUWork.SearchPartsPosName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSPOSNAMERF"));  // �������ʃR�[�h����
                partsPosCodeUWork.PosDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSDISPORDERRF"));  // �������ʕ\������
                partsPosCodeUWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));  // �����i�R�[�h
                partsPosCodeUWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));  // �����i�R�[�h�}��
                partsPosCodeUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));  // �񋟓��t
                partsPosCodeUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));  // �񋟃f�[�^�敪
                # endregion
            }
        }
        # endregion
    }
}
