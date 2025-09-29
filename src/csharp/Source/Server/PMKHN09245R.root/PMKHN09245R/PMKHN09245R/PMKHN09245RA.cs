//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���Ӑ�}�X�^�i�����ݒ�jDB�����[�g�I�u�W�F�N�g
//                  :   PMKHN09245R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2008.10.14
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
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�}�X�^�i�����ݒ�jDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�}�X�^�i�����ݒ�j�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.10.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SumCustStDB : RemoteWithAppLockDB, ISumCustStDB
    {
        /// <summary>
        /// ���Ӑ�}�X�^�i�����ݒ�jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        /// </remarks>
        public SumCustStDB() : base("PMKHN09247D", "Broadleaf.Application.Remoting.ParamData.SumCustStWork", "SUMCUSTSTRF")
        {

        }

        # region [Read]
        /// <summary>
        /// �P��̓��Ӑ�}�X�^�i�����ݒ�j�����擾���܂��B
        /// </summary>
        /// <param name="sumCustStObj">SumCustStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�����ݒ�j�̃L�[�l����v���链�Ӑ�}�X�^�i�����ݒ�j�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        public int Read(ref object sumCustStObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SumCustStWork sumCustStWork = sumCustStObj as SumCustStWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref sumCustStWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// �P��̓��Ӑ�}�X�^�i�����ݒ�j�����擾���܂��B
        /// </summary>
        /// <param name="sumCustStWork">SumCustStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�����ݒ�j�̃L�[�l����v���链�Ӑ�}�X�^�i�����ݒ�j�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        public int Read(ref SumCustStWork sumCustStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref sumCustStWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �P��̓��Ӑ�}�X�^�i�����ݒ�j�����擾���܂��B
        /// </summary>
        /// <param name="sumCustStWork">SumCustStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�����ݒ�j�̃L�[�l����v���链�Ӑ�}�X�^�i�����ݒ�j�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        private int ReadProc(ref SumCustStWork sumCustStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "  *" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SUMCUSTSTRF" + Environment.NewLine;
                sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUMCLAIMCUSTCODERF=@FINDSUMCLAIMCUSTCODE AND DEMANDADDUPSECCDRF=@FINDDEMANDADDUPSECCD AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSumClaimCustCode = sqlCommand.Parameters.Add("@FINDSUMCLAIMCUSTCODE", SqlDbType.Int);
                SqlParameter findParaDemandAddUpSecCd = sqlCommand.Parameters.Add("@FINDDEMANDADDUPSECCD", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);


                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumCustStWork.EnterpriseCode);
                findParaSumClaimCustCode.Value = SqlDataMediator.SqlSetInt32(sumCustStWork.SumClaimCustCode);
                findParaDemandAddUpSecCd.Value = SqlDataMediator.SqlSetString(sumCustStWork.DemandAddUpSecCd);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(sumCustStWork.CustomerCode);


#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToSumCustStWorkFromReader(ref myReader, ref sumCustStWork);
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
        /// ���Ӑ�}�X�^�i�����ݒ�j���𕨗��폜���܂�
        /// </summary>
        /// <param name="sumCustStList">�����폜���链�Ӑ�}�X�^�i�����ݒ�j�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�����ݒ�j�̃L�[�l����v���链�Ӑ�}�X�^�i�����ݒ�j���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        public int Delete(object sumCustStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = sumCustStList as ArrayList;

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
        /// ���Ӑ�}�X�^�i�����ݒ�j���𕨗��폜���܂�
        /// </summary>
        /// <param name="sumCustStList">���Ӑ�}�X�^�i�����ݒ�j�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStList �Ɋi�[����Ă��链�Ӑ�}�X�^�i�����ݒ�j���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        public int Delete(ArrayList sumCustStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(sumCustStList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�����ݒ�j���𕨗��폜���܂�
        /// </summary>
        /// <param name="sumCustStList">���Ӑ�}�X�^�i�����ݒ�j�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStList �Ɋi�[����Ă��链�Ӑ�}�X�^�i�����ݒ�j���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        private int DeleteProc(ArrayList sumCustStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (sumCustStList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < sumCustStList.Count; i++)
                    {
                        SumCustStWork sumCustStWork = sumCustStList[i] as SumCustStWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  SUMCUSTSTRF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUMCLAIMCUSTCODERF=@FINDSUMCLAIMCUSTCODE AND DEMANDADDUPSECCDRF=@FINDDEMANDADDUPSECCD AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSumClaimCustCode = sqlCommand.Parameters.Add("@FINDSUMCLAIMCUSTCODE", SqlDbType.Int);
                        SqlParameter findParaDemandAddUpSecCd = sqlCommand.Parameters.Add("@FINDDEMANDADDUPSECCD", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);


                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumCustStWork.EnterpriseCode);
                        findParaSumClaimCustCode.Value = SqlDataMediator.SqlSetInt32(sumCustStWork.SumClaimCustCode);
                        findParaDemandAddUpSecCd.Value = SqlDataMediator.SqlSetString(sumCustStWork.DemandAddUpSecCd);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(sumCustStWork.CustomerCode);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != sumCustStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  SUMCUSTSTRF" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUMCLAIMCUSTCODERF=@FINDSUMCLAIMCUSTCODE AND DEMANDADDUPSECCDRF=@FINDDEMANDADDUPSECCD AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumCustStWork.EnterpriseCode);
                            findParaSumClaimCustCode.Value = SqlDataMediator.SqlSetInt32(sumCustStWork.SumClaimCustCode);
                            findParaDemandAddUpSecCd.Value = SqlDataMediator.SqlSetString(sumCustStWork.DemandAddUpSecCd);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(sumCustStWork.CustomerCode);

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
        /// ���Ӑ�}�X�^�i�����ݒ�j���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="sumCustStList">��������</param>
        /// <param name="sumCustStObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�����ݒ�j�̃L�[�l����v����A�S�Ă̓��Ӑ�}�X�^�i�����ݒ�j�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        public int Search(ref object sumCustStList, object sumCustStObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList sumCustStArray = sumCustStList as ArrayList;

                if (sumCustStArray == null)
                {
                    sumCustStArray = new ArrayList();
                }

                SumCustStWork sumCustStWork = sumCustStObj as SumCustStWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref sumCustStArray, sumCustStWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// ���Ӑ�}�X�^�i�����ݒ�j���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="sumCustStList">���Ӑ�}�X�^�i�����ݒ�j�����i�[���� ArrayList</param>
        /// <param name="sumCustStWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�����ݒ�j�̃L�[�l����v����A�S�Ă̓��Ӑ�}�X�^�i�����ݒ�j��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        public int Search(ref ArrayList sumCustStList, SumCustStWork sumCustStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref sumCustStList, sumCustStWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�����ݒ�j���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="sumCustStList">���Ӑ�}�X�^�i�����ݒ�j�����i�[���� ArrayList</param>
        /// <param name="sumCustStWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�����ݒ�j�̃L�[�l����v����A�S�Ă̓��Ӑ�}�X�^�i�����ݒ�j��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        private int SearchProc(ref ArrayList sumCustStList, SumCustStWork sumCustStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "  *" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SUMCUSTSTRF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, sumCustStWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    sumCustStList.Add(this.CopyToSumCustStWorkFromReader(ref myReader));
                }

                if (sumCustStList.Count > 0)
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
        /// ���Ӑ�}�X�^�i�����ݒ�j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="sumCustStList">�ǉ��E�X�V���链�Ӑ�}�X�^�i�����ݒ�j�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStList �Ɋi�[����Ă��链�Ӑ�}�X�^�i�����ݒ�j����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        public int Write(ref object sumCustStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = sumCustStList as ArrayList;

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
        /// ���Ӑ�}�X�^�i�����ݒ�j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="sumCustStList">�ǉ��E�X�V���链�Ӑ�}�X�^�i�����ݒ�j�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStList �Ɋi�[����Ă��链�Ӑ�}�X�^�i�����ݒ�j����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        public int Write(ref ArrayList sumCustStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref sumCustStList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�����ݒ�j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="sumCustStList">�ǉ��E�X�V���链�Ӑ�}�X�^�i�����ݒ�j�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStList �Ɋi�[����Ă��链�Ӑ�}�X�^�i�����ݒ�j����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        private int WriteProc(ref ArrayList sumCustStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (sumCustStList != null)
                {
                    string sqlText = string.Empty;
                    SumCustStWork sumCustStWork = sumCustStList[0] as SumCustStWork;

                    sqlText = string.Empty;
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SUMCUSTSTRF" + Environment.NewLine;
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUMCLAIMCUSTCODERF=@FINDSUMCLAIMCUSTCODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameter�I�u�W�F�N�g�̍쐬
                    sqlCommand.Parameters.Clear();
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSumClaimCustCode = sqlCommand.Parameters.Add("@FINDSUMCLAIMCUSTCODE", SqlDbType.Int);

                    // KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumCustStWork.EnterpriseCode);
                    findParaSumClaimCustCode.Value = SqlDataMediator.SqlSetInt32(sumCustStWork.SumClaimCustCode);

                    sqlCommand.ExecuteNonQuery();

                    # region [INSERT��]
                    sqlText = string.Empty;
                    sqlText = "INSERT INTO SUMCUSTSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SUMCLAIMCUSTCODERF, DEMANDADDUPSECCDRF, CUSTOMERCODERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SUMCLAIMCUSTCODE, @DEMANDADDUPSECCD, @CUSTOMERCODE)";
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSumClaimCustCode = sqlCommand.Parameters.Add("@SUMCLAIMCUSTCODE", SqlDbType.Int);
                    SqlParameter paraDemandAddUpSecCd = sqlCommand.Parameters.Add("@DEMANDADDUPSECCD", SqlDbType.NChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    # endregion

                    for (int i = 0; i < sumCustStList.Count; i++)
                    {
                        sumCustStWork = sumCustStList[i] as SumCustStWork;

                        // �o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sumCustStWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sumCustStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sumCustStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumCustStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(sumCustStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sumCustStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sumCustStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sumCustStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sumCustStWork.LogicalDeleteCode);
                        paraSumClaimCustCode.Value = SqlDataMediator.SqlSetInt32(sumCustStWork.SumClaimCustCode);
                        paraDemandAddUpSecCd.Value = SqlDataMediator.SqlSetString(sumCustStWork.DemandAddUpSecCd);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(sumCustStWork.CustomerCode);

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(sumCustStWork);
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

            sumCustStList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// ���Ӑ�}�X�^�i�����ݒ�j����_���폜���܂��B
        /// </summary>
        /// <param name="sumCustStList">�_���폜���链�Ӑ�}�X�^�i�����ݒ�j�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStWork �Ɋi�[����Ă��链�Ӑ�}�X�^�i�����ݒ�j����_���폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        public int LogicalDelete(ref object sumCustStList)
        {
            return this.LogicalDelete(ref sumCustStList, 0);
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�����ݒ�j���̘_���폜���������܂��B
        /// </summary>
        /// <param name="sumCustStList">�_���폜���������链�Ӑ�}�X�^�i�����ݒ�j�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStWork �Ɋi�[����Ă��链�Ӑ�}�X�^�i�����ݒ�j���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        public int RevivalLogicalDelete(ref object sumCustStList)
        {
            return this.LogicalDelete(ref sumCustStList, 1);
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�����ݒ�j���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="sumCustStList">�_���폜�𑀍삷�链�Ӑ�}�X�^�i�����ݒ�j���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStWork �Ɋi�[����Ă��链�Ӑ�}�X�^�i�����ݒ�j���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        private int LogicalDelete(ref object sumCustStList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = sumCustStList as ArrayList;

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
        /// ���Ӑ�}�X�^�i�����ݒ�j���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="sumCustStList">�_���폜�𑀍삷�链�Ӑ�}�X�^�i�����ݒ�j�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStWork �Ɋi�[����Ă��链�Ӑ�}�X�^�i�����ݒ�j���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        public int LogicalDelete(ref ArrayList sumCustStList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref sumCustStList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�����ݒ�j���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="sumCustStList">�_���폜�𑀍삷�链�Ӑ�}�X�^�i�����ݒ�j�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStWork �Ɋi�[����Ă��链�Ӑ�}�X�^�i�����ݒ�j���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        private int LogicalDeleteProc(ref ArrayList sumCustStList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (sumCustStList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < sumCustStList.Count; i++)
                    {
                        SumCustStWork sumCustStWork = sumCustStList[i] as SumCustStWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  SUMCUSTSTRF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUMCLAIMCUSTCODERF=@FINDSUMCLAIMCUSTCODE AND DEMANDADDUPSECCDRF=@FINDDEMANDADDUPSECCD AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSumClaimCustCode = sqlCommand.Parameters.Add("@FINDSUMCLAIMCUSTCODE", SqlDbType.Int);
                        SqlParameter findParaDemandAddUpSecCd = sqlCommand.Parameters.Add("@FINDDEMANDADDUPSECCD", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);


                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumCustStWork.EnterpriseCode);
                        findParaSumClaimCustCode.Value = SqlDataMediator.SqlSetInt32(sumCustStWork.SumClaimCustCode);
                        findParaDemandAddUpSecCd.Value = SqlDataMediator.SqlSetString(sumCustStWork.DemandAddUpSecCd);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(sumCustStWork.CustomerCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != sumCustStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  SUMCUSTSTRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUMCLAIMCUSTCODERF=@FINDSUMCLAIMCUSTCODE AND DEMANDADDUPSECCDRF=@FINDDEMANDADDUPSECCD AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumCustStWork.EnterpriseCode);
                            findParaSumClaimCustCode.Value = SqlDataMediator.SqlSetInt32(sumCustStWork.SumClaimCustCode);
                            findParaDemandAddUpSecCd.Value = SqlDataMediator.SqlSetString(sumCustStWork.DemandAddUpSecCd);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(sumCustStWork.CustomerCode);


                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)sumCustStWork;
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
                            else if (logicalDelCd == 0) sumCustStWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else sumCustStWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                sumCustStWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sumCustStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sumCustStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sumCustStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sumCustStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sumCustStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(sumCustStWork);
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

            sumCustStList = al;

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="sumCustStWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SumCustStWork sumCustStWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // ��ƃR�[�h
            retstring += "  ENTERPRISECODERF = @FINDENTERPRISECODE"  + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumCustStWork.EnterpriseCode);

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

            if (sumCustStWork.SumClaimCustCode != 0)
            {
                retstring += " AND SUMCLAIMCUSTCODERF=@FINDSUMCLAIMCUSTCODE" + Environment.NewLine;
                SqlParameter findSumClaimCustCode = sqlCommand.Parameters.Add("@FINDSUMCLAIMCUSTCODE", SqlDbType.Int);
                findSumClaimCustCode.Value = SqlDataMediator.SqlSetInt32(sumCustStWork.SumClaimCustCode);
            }

            if (string.IsNullOrEmpty(sumCustStWork.DemandAddUpSecCd) == false)
            {
                retstring += " AND DEMANDADDUPSECCDRF=@FINDDEMANDADDUPSECCD"  + Environment.NewLine;
                SqlParameter findDemandAddUpSecCd = sqlCommand.Parameters.Add("@FINDDEMANDADDUPSECCD", SqlDbType.NChar);
                findDemandAddUpSecCd.Value = SqlDataMediator.SqlSetString(sumCustStWork.DemandAddUpSecCd);
            }

            if (sumCustStWork.CustomerCode != 0)
            {
                retstring += " AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(sumCustStWork.CustomerCode);
            }

            return retstring;
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SumCustStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SumCustStWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        /// </remarks>
        private SumCustStWork CopyToSumCustStWorkFromReader(ref SqlDataReader myReader)
        {
            SumCustStWork sumCustStWork = new SumCustStWork();

            this.CopyToSumCustStWorkFromReader(ref myReader, ref sumCustStWork);

            return sumCustStWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� SumCustStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="sumCustStWork">SumCustStWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        /// </remarks>
        private void CopyToSumCustStWorkFromReader(ref SqlDataReader myReader, ref SumCustStWork sumCustStWork)
        {
            if (myReader != null && sumCustStWork != null)
            {
                # region �N���X�֊i�[
                sumCustStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                sumCustStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                sumCustStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                sumCustStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                sumCustStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                sumCustStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                sumCustStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                sumCustStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                sumCustStWork.SumClaimCustCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMCLAIMCUSTCODERF"));
                sumCustStWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
                sumCustStWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));

                # endregion
            }
        }
        # endregion
    }
}
