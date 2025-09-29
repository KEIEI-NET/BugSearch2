//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   CustSlipNoSetDB�����[�g�I�u�W�F�N�g
//                  :   PMKHN09104R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 �D�c �E�l
// Date             :   2008.06.16
//----------------------------------------------------------------------
// Update Note      :   21112 �v�ۓc ��
//                  :   2008.12.22  ���Ӑ�`�[�ԍ��擾���\�b�h�̒ǉ�
//----------------------------------------------------------------------
// Update Note      :   ���N�n��
//                  :   2010/12/22  �@���Ӑ�}�X�^�i�`�[�ԍ��j�̒��o�敪�������̏ꍇ�̍̔ԕ��@�̕s����C��  
//----------------------------------------------------------------------
// Update Note      :   2012/02/06 �����Y</br>
// �Ǘ��ԍ�         :   10707327-00 2012/03/28�z�M��</br>
//                      Redmine#28336 ���Ӑ�`�[�ԍ��̔Ԃ̕s��̑Ή�</br>
//----------------------------------------------------------------------
// Update Note      :   2019/05/17 �c����</br>
// �Ǘ��ԍ�         :   11575089-00 </br>
//                      Redmine#49749 �����̏ꍇ�ɁA���Ӑ�`�[�ԍ��̔Ԃ̕s��̑Ή�</br>
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
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
    /// CustSlipNoSetDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : CustSlipNoSet�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.06.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class CustSlipNoSetDB : RemoteWithAppLockDB, ICustSlipNoSetDB
    {
        /// <summary>
        /// CustSlipNoSetDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        /// </remarks>
        public CustSlipNoSetDB()
            : base("PMKHN09106D", "Broadleaf.Application.Remoting.ParamData.CustSlipNoSetWork", "CustSlipNoSetRF")
        {

        }

        # region [Read]
        /// <summary>
        /// �P���CustSlipNoSet�����擾���܂��B
        /// </summary>
        /// <param name="custSlipNoSetObj">CustSlipNoSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSet�̃L�[�l����v����CustSlipNoSet�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        public int Read(ref object custSlipNoSetObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                CustSlipNoSetWork custSlipNoSetWork = custSlipNoSetObj as CustSlipNoSetWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref custSlipNoSetWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// �P���CustSlipNoSet�����擾���܂��B
        /// </summary>
        /// <param name="custSlipNoSetWork">CustSlipNoSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSet�̃L�[�l����v����CustSlipNoSet�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        public int Read(ref CustSlipNoSetWork custSlipNoSetWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref custSlipNoSetWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �P���CustSlipNoSet�����擾���܂��B
        /// </summary>
        /// <param name="custSlipNoSetWork">CustSlipNoSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSet�̃L�[�l����v����CustSlipNoSet�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        private int ReadProc(ref CustSlipNoSetWork custSlipNoSetWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT CUSTSLIP.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.ADDUPYEARMONTHRF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.PRESENTCUSTSLIPNORF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.STARTCUSTSLIPNORF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.ENDCUSTSLIPNORF" + Environment.NewLine;
                sqlText += "    ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " FROM CUSTSLIPNOSETRF CUSTSLIP" + Environment.NewLine;
                sqlText += " LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERCODERF=CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " WHERE CUSTSLIP.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND CUSTSLIP.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                sqlText += "    AND CUSTSLIP.ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
                findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.AddUpYearMonth);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToCustSlipNoSetWorkFromReader(ref myReader, ref custSlipNoSetWork);
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
        /// CustSlipNoSet���𕨗��폜���܂�
        /// </summary>
        /// <param name="custSlipNoSetList">�����폜����CustSlipNoSet�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSet�̃L�[�l����v����CustSlipNoSet���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        public int Delete(object custSlipNoSetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = custSlipNoSetList as ArrayList;

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
        /// CustSlipNoSet���𕨗��폜���܂�
        /// </summary>
        /// <param name="custSlipNoSetList">CustSlipNoSet�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetList �Ɋi�[����Ă���CustSlipNoSet���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        public int Delete(ArrayList custSlipNoSetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(custSlipNoSetList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// CustSlipNoSet���𕨗��폜���܂�
        /// </summary>
        /// <param name="custSlipNoSetList">CustSlipNoSet�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetList �Ɋi�[����Ă���CustSlipNoSet���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        private int DeleteProc(ArrayList custSlipNoSetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (custSlipNoSetList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < custSlipNoSetList.Count; i++)
                    {
                        CustSlipNoSetWork custSlipNoSetWork = custSlipNoSetList[i] as CustSlipNoSetWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM CUSTSLIPNOSETRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "    AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
                        findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.AddUpYearMonth);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != custSlipNoSetWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM CUSTSLIPNOSETRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "    AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
                            findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.AddUpYearMonth);

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
        /// CustSlipNoSet���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="custSlipNoSetList">��������</param>
        /// <param name="custSlipNoSetObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSet�̃L�[�l����v����A�S�Ă�CustSlipNoSet�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        public int Search(ref object custSlipNoSetList, object custSlipNoSetObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList custSlipNoSetArray = custSlipNoSetList as ArrayList;

                if (custSlipNoSetArray == null)
                {
                    custSlipNoSetArray = new ArrayList();
                }

                CustSlipNoSetWork custSlipNoSetWork = custSlipNoSetObj as CustSlipNoSetWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref custSlipNoSetArray, custSlipNoSetWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// CustSlipNoSet���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="custSlipNoSetList">CustSlipNoSet�����i�[���� ArrayList</param>
        /// <param name="custSlipNoSetWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSet�̃L�[�l����v����A�S�Ă�CustSlipNoSet��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        public int Search(ref ArrayList custSlipNoSetList, CustSlipNoSetWork custSlipNoSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref custSlipNoSetList, custSlipNoSetWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// CustSlipNoSet���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="custSlipNoSetList">CustSlipNoSet�����i�[���� ArrayList</param>
        /// <param name="custSlipNoSetWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSet�̃L�[�l����v����A�S�Ă�CustSlipNoSet��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        private int SearchProc(ref ArrayList custSlipNoSetList, CustSlipNoSetWork custSlipNoSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT CUSTSLIP.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.ADDUPYEARMONTHRF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.PRESENTCUSTSLIPNORF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.STARTCUSTSLIPNORF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.ENDCUSTSLIPNORF" + Environment.NewLine;
                sqlText += "    ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " FROM CUSTSLIPNOSETRF CUSTSLIP" + Environment.NewLine;
                sqlText += " LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERCODERF=CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, custSlipNoSetWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    custSlipNoSetList.Add(this.CopyToCustSlipNoSetWorkFromReader(ref myReader));
                }

                if (custSlipNoSetList.Count > 0)
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
        /// CustSlipNoSet����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="custSlipNoSetList">�ǉ��E�X�V����CustSlipNoSet�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetList �Ɋi�[����Ă���CustSlipNoSet����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        public int Write(ref object custSlipNoSetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = custSlipNoSetList as ArrayList;

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
        /// CustSlipNoSet����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="custSlipNoSetList">�ǉ��E�X�V����CustSlipNoSet�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetList �Ɋi�[����Ă���CustSlipNoSet����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        public int Write(ref ArrayList custSlipNoSetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref custSlipNoSetList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// CustSlipNoSet����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="custSlipNoSetList">�ǉ��E�X�V����CustSlipNoSet�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetList �Ɋi�[����Ă���CustSlipNoSet����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        private int WriteProc(ref ArrayList custSlipNoSetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (custSlipNoSetList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < custSlipNoSetList.Count; i++)
                    {
                        CustSlipNoSetWork custSlipNoSetWork = custSlipNoSetList[i] as CustSlipNoSetWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "    ,CUSTOMERCODERF" + Environment.NewLine;
                        sqlText += "    ,ADDUPYEARMONTHRF" + Environment.NewLine;
                        sqlText += "    ,PRESENTCUSTSLIPNORF" + Environment.NewLine;
                        sqlText += "    ,STARTCUSTSLIPNORF" + Environment.NewLine;
                        sqlText += "    ,ENDCUSTSLIPNORF" + Environment.NewLine;
                        sqlText += " FROM CUSTSLIPNOSETRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "    AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
                        findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.AddUpYearMonth);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != custSlipNoSetWork.UpdateDateTime)
                            {
                                if (custSlipNoSetWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText += "UPDATE CUSTSLIPNOSETRF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " , ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine;
                            sqlText += " , PRESENTCUSTSLIPNORF=@PRESENTCUSTSLIPNO" + Environment.NewLine;
                            sqlText += " , STARTCUSTSLIPNORF=@STARTCUSTSLIPNO" + Environment.NewLine;
                            sqlText += " , ENDCUSTSLIPNORF=@ENDCUSTSLIPNO" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "    AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
                            findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.AddUpYearMonth);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custSlipNoSetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (custSlipNoSetWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO CUSTSLIPNOSETRF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += "    ,ADDUPYEARMONTHRF" + Environment.NewLine;
                            sqlText += "    ,PRESENTCUSTSLIPNORF" + Environment.NewLine;
                            sqlText += "    ,STARTCUSTSLIPNORF" + Environment.NewLine;
                            sqlText += "    ,ENDCUSTSLIPNORF" + Environment.NewLine;
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
                            sqlText += "    ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += "    ,@ADDUPYEARMONTH" + Environment.NewLine;
                            sqlText += "    ,@PRESENTCUSTSLIPNO" + Environment.NewLine;
                            sqlText += "    ,@STARTCUSTSLIPNO" + Environment.NewLine;
                            sqlText += "    ,@ENDCUSTSLIPNO" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custSlipNoSetWork;
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
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                        SqlParameter paraPresentCustSlipNo = sqlCommand.Parameters.Add("@PRESENTCUSTSLIPNO", SqlDbType.BigInt);
                        SqlParameter paraStartCustSlipNo = sqlCommand.Parameters.Add("@STARTCUSTSLIPNO", SqlDbType.BigInt);
                        SqlParameter paraEndCustSlipNo = sqlCommand.Parameters.Add("@ENDCUSTSLIPNO", SqlDbType.BigInt);
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custSlipNoSetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custSlipNoSetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(custSlipNoSetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.LogicalDeleteCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
                        paraAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.AddUpYearMonth);
                        paraPresentCustSlipNo.Value = SqlDataMediator.SqlSetInt64(custSlipNoSetWork.PresentCustSlipNo);
                        paraStartCustSlipNo.Value = SqlDataMediator.SqlSetInt64(custSlipNoSetWork.StartCustSlipNo);
                        paraEndCustSlipNo.Value = SqlDataMediator.SqlSetInt64(custSlipNoSetWork.EndCustSlipNo);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(custSlipNoSetWork);
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

            custSlipNoSetList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// CustSlipNoSet����_���폜���܂��B
        /// </summary>
        /// <param name="custSlipNoSetList">�_���폜����CustSlipNoSet�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetWork �Ɋi�[����Ă���CustSlipNoSet����_���폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        public int LogicalDelete(ref object custSlipNoSetList)
        {
            return this.LogicalDelete(ref custSlipNoSetList, 0);
        }

        /// <summary>
        /// CustSlipNoSet���̘_���폜���������܂��B
        /// </summary>
        /// <param name="custSlipNoSetList">�_���폜����������CustSlipNoSet�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetWork �Ɋi�[����Ă���CustSlipNoSet���̘_���폜���������܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        public int RevivalLogicalDelete(ref object custSlipNoSetList)
        {
            return this.LogicalDelete(ref custSlipNoSetList, 1);
        }

        /// <summary>
        /// CustSlipNoSet���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="custSlipNoSetList">�_���폜�𑀍삷��CustSlipNoSet���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetWork �Ɋi�[����Ă���CustSlipNoSet���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        private int LogicalDelete(ref object custSlipNoSetList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = custSlipNoSetList as ArrayList;

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
        /// CustSlipNoSet���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="custSlipNoSetList">�_���폜�𑀍삷��CustSlipNoSet�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetWork �Ɋi�[����Ă���CustSlipNoSet���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        public int LogicalDelete(ref ArrayList custSlipNoSetList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref custSlipNoSetList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// CustSlipNoSet���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="custSlipNoSetList">�_���폜�𑀍삷��CustSlipNoSet�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetWork �Ɋi�[����Ă���CustSlipNoSet���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        private int LogicalDeleteProc(ref ArrayList custSlipNoSetList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (custSlipNoSetList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < custSlipNoSetList.Count; i++)
                    {
                        CustSlipNoSetWork custSlipNoSetWork = custSlipNoSetList[i] as CustSlipNoSetWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " FROM CUSTSLIPNOSETRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "    AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
                        findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.AddUpYearMonth);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != custSlipNoSetWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  CUSTSLIPNOSETRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "    AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
                            findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.AddUpYearMonth);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custSlipNoSetWork;
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
                            else if (logicalDelCd == 0) custSlipNoSetWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else custSlipNoSetWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                custSlipNoSetWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custSlipNoSetWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(custSlipNoSetWork);
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

            custSlipNoSetList = al;

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="custSlipNoSetWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CustSlipNoSetWork custSlipNoSetWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // ��ƃR�[�h
            retstring += "  CUSTSLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND CUSTSLIP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND CUSTSLIP.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // ���Ӑ�R�[�h
            if (custSlipNoSetWork.CustomerCode != 0)
            {
                retstring += "  AND CUSTSLIP.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
            }

            // �v��N��
            if (custSlipNoSetWork.AddUpYearMonth >= 0)
            {
                retstring += "  AND CUSTSLIP.ADDUPYEARMONTHRF = @FINDADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter findAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);
                findAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.AddUpYearMonth);
            }

            return retstring;
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CustSlipNoSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustSlipNoSetWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        /// </remarks>
        private CustSlipNoSetWork CopyToCustSlipNoSetWorkFromReader(ref SqlDataReader myReader)
        {
            CustSlipNoSetWork custSlipNoSetWork = new CustSlipNoSetWork();

            this.CopyToCustSlipNoSetWorkFromReader(ref myReader, ref custSlipNoSetWork);

            return custSlipNoSetWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� CustSlipNoSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="custSlipNoSetWork">CustSlipNoSetWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        /// </remarks>
        private void CopyToCustSlipNoSetWorkFromReader(ref SqlDataReader myReader, ref CustSlipNoSetWork custSlipNoSetWork)
        {
            if (myReader != null && custSlipNoSetWork != null)
            {
                # region �N���X�֊i�[
                custSlipNoSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                custSlipNoSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                custSlipNoSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                custSlipNoSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                custSlipNoSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                custSlipNoSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                custSlipNoSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                custSlipNoSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                custSlipNoSetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                custSlipNoSetWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                custSlipNoSetWork.AddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
                custSlipNoSetWork.PresentCustSlipNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRESENTCUSTSLIPNORF"));
                custSlipNoSetWork.StartCustSlipNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STARTCUSTSLIPNORF"));
                custSlipNoSetWork.EndCustSlipNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ENDCUSTSLIPNORF"));
                # endregion
            }
        }
        # endregion

        # region [���Ӑ�`�[�ԍ��擾����]

        /// <summary>
        /// ���Ӑ�`�[�ԍ��擾�����ł̂ݎg�p����f�[�^�N���X
        /// </summary>
        private class TmpCustSlipNoWork : CustSlipNoSetWork
        {
            public int TotalDay;           // ����
            public int CustomerSlipNoDiv;  // ���Ӑ�`�[�ԍ��敪
        }

        private CompanyInfWork _CompanyInfWork = null;

        private CompanyInfWork GetCompanyInformation(string enterpriseCode)
        {
            if (this._CompanyInfWork == null)
            {
                CompanyInfDB companyInfDB = new CompanyInfDB();

                CompanyInfWork companyInfWork = new CompanyInfWork();

                companyInfWork.EnterpriseCode = enterpriseCode;
                companyInfWork.CompanyCode = 0;

                byte[] paraByte = XmlByteSerializer.Serialize(companyInfWork);

                int status = companyInfDB.Read(ref paraByte, 0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._CompanyInfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(paraByte, typeof(CompanyInfWork));
                }
            }

            return this._CompanyInfWork;
        }

        /// <summary>
        /// ���Ӑ�`�[�ԍ����擾���܂�
        /// </summary>
        /// <param name="enterprisecode">��ƃR�[�h</param>
        /// <param name="customercode">���Ӑ�R�[�h</param>
        /// <param name="salesdate">������t(�v���)</param>
        /// <param name="presentcustslipno">���ݓ��Ӑ�`�[�ԍ�</param>
        /// <param name="connection">DB�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        public int GetCustomerSlipNo(string enterprisecode, int customercode, DateTime salesdate, out Int64 presentcustslipno, ref SqlConnection connection, ref SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
            bool crtTran = false;  // true:�g�����U�N�V�����͎��O�ŗp�Ӂ@false:�g�����U�N�V�����͌ďo�����p��
            presentcustslipno = 0;

            try
            {
                # region [�p�����[�^�`�F�b�N]

                // ���Ӑ�R�[�h
                if (customercode == 0)
                {
                    throw new Exception("���Ӑ�R�[�h�����ݒ�ł�.");
                }

                // ������t
                if (salesdate == DateTime.MinValue)
                {
                    throw new Exception("������t�����ݒ�ł�.");
                }

                // DB�ڑ����
                if (connection == null)
                {
                    connection = this.CreateConnection(true);
                    transaction = this.CreateTransaction(ref connection);
                    crtTran = true;
                }

                # endregion

                status = this.GetCustomerSlipNoProc(enterprisecode, customercode, salesdate, out presentcustslipno, ref connection, ref transaction);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                this.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                # region [�g�����U�N�V����(��)����]
                if (crtTran)
                {
                    if (transaction != null && transaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                        }

                        transaction.Dispose();
                        transaction = null;
                    }

                    if (connection != null)
                    {
                        connection.Dispose();
                        connection = null;
                    }
                }
                # endregion
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�`�[�ԍ����擾���܂�
        /// </summary>
        /// <param name="enterprisecode">��ƃR�[�h</param>
        /// <param name="customercode">���Ӑ�R�[�h</param>
        /// <param name="salesdate">������t(�v���)</param>
        /// <param name="presentcustslipno">���ݓ��Ӑ�`�[�ԍ�</param>
        /// <param name="connection">DB�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <br>Update Note:   2010/12/22 ���N�n��</br>
        /// <br>               �@���Ӑ�}�X�^�i�`�[�ԍ��j�̒��o�敪�������̏ꍇ�̍̔ԕ��@�̕s����C��</br>
        /// <br>Update Note      :   2012/02/06 �����Y</br>
        /// <br>                     Redmine#28336 ���Ӑ�`�[�ԍ��̔Ԃ̕s��̑Ή�</br>
        /// <br>Update Note      :   2019/05/17 �c����</br>
        /// <br>                     Redmine#49749 �����̏ꍇ�ɓ��Ӑ�`�[�ԍ��̔Ԃ̕s��̑Ή�</br>
        /// <br></br>
        /// <returns>STATUS</returns>
        private int GetCustomerSlipNoProc(string enterprisecode, int customercode, DateTime salesdate, out Int64 presentcustslipno, ref SqlConnection connection, ref SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
            SqlCommand command = null;
            SqlDataReader dtReader = null;

            const int DEF_PR_SLIPNO = 1;            // ���ݓ��Ӑ�`�[�ԍ�(�����l)
            const int DEF_ST_SLIPNO = 1;            // �J�n���Ӑ�`�[�ԍ�(�����l)
            const Int64 DEF_ED_SLIPNO = 999999999;  // �I�����Ӑ�`�[�ԍ�(�����l)

            presentcustslipno = DEF_PR_SLIPNO;

            try
            {
                # region [���Ӑ�f�[�^�ǂݍ���]
                
                # region [SELECT��]
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CUST.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,SLIP.*" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF AS CUST LEFT OUTER JOIN CUSTSLIPNOSETRF AS SLIP" + Environment.NewLine;
                sqlText += "  ON  CUST.ENTERPRISECODERF = SLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND CUST.CUSTOMERCODERF = SLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CUST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUST.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                sqlText += "  AND CUST.LOGICALDELETECODERF = 0" + Environment.NewLine;
                
                // ���Ӑ�`�[�ԍ��敪�ɉ����āA�v����t�̍i���ݏ�����ύX����
                sqlText += "  AND LEN(SLIP.ADDUPYEARMONTHRF) = CASE CUST.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += "      WHEN 1 THEN 1" + Environment.NewLine;  // 1:�A�� = �v����t�� 0 �� 1��
                sqlText += "      WHEN 2 THEN 6" + Environment.NewLine;  // 2:���� = �v����t�� YYYYMM �� 6��
                sqlText += "      WHEN 3 THEN 4" + Environment.NewLine;  // 3:���� = �v����t�� YYYY �� 4��
                sqlText += "      ELSE 0 END" + Environment.NewLine;     // ��L�O = 0 �����f�[�^����
                
                sqlText += "ORDER BY" + Environment.NewLine;
                sqlText += "  SLIP.ADDUPYEARMONTHRF DESC" + Environment.NewLine;
                command = new SqlCommand(sqlText, connection, transaction);                
                # endregion                

                SqlParameter findEnterpriseCode = command.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);      // ��ƃR�[�h
                SqlParameter findCustomerCode = command.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);            // ���Ӑ�R�[�h

                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterprisecode);
                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(customercode);

# if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(command));
# endif

                dtReader = command.ExecuteReader();
                
                List<TmpCustSlipNoWork> ctsSlipNoList = new List<TmpCustSlipNoWork>();

                while (dtReader.Read())
                {
                    CustSlipNoSetWork cstSlpNoSetWrk = new TmpCustSlipNoWork();

                    this.CopyToCustSlipNoSetWorkFromReader(ref dtReader, ref cstSlpNoSetWrk);

                    (cstSlpNoSetWrk as TmpCustSlipNoWork).TotalDay = SqlDataMediator.SqlGetInt32(dtReader, dtReader.GetOrdinal("TOTALDAYRF"));                    // ����
                    (cstSlpNoSetWrk as TmpCustSlipNoWork).CustomerSlipNoDiv = SqlDataMediator.SqlGetInt32(dtReader, dtReader.GetOrdinal("CUSTOMERSLIPNODIVRF"));  // ���Ӑ�`�[�ԍ��敪

                    ctsSlipNoList.Add((TmpCustSlipNoWork)cstSlpNoSetWrk);
                }

                dtReader.Close();
                dtReader.Dispose();

                # endregion

                if (ctsSlipNoList.Count > 0)
                {
                    int totalDay = ctsSlipNoList[0].TotalDay;              // ����
                    int CstSlpNoDiv = ctsSlipNoList[0].CustomerSlipNoDiv;  // ���Ӑ�`�[�ԍ��敪

                    // �ǉ��E�X�V�p�f�[�^
                    TmpCustSlipNoWork wrtCstSlpNoWrk = new TmpCustSlipNoWork();

                    # region [�����l�ݒ�]
                    // �����ŗ\�ߐݒ肵�Ă������ŁA�Ώۃf�[�^�����݂��Ȃ��ۂ̒ǉ��f�[�^�쐬�������ȗ�
                    wrtCstSlpNoWrk.EnterpriseCode = enterprisecode;                                   // ��ƃR�[�h
                    wrtCstSlpNoWrk.CustomerCode = customercode;                                       // ���Ӑ�R�[�h
                    wrtCstSlpNoWrk.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;  // �_���폜�敪
                    wrtCstSlpNoWrk.AddUpYearMonth = 0;                                                // �v��N��
                    wrtCstSlpNoWrk.PresentCustSlipNo = DEF_PR_SLIPNO;                                 // ���ݓ��Ӑ�`�[�ԍ�
                    wrtCstSlpNoWrk.StartCustSlipNo = DEF_ST_SLIPNO;                                   // �J�n���Ӑ�`�[�ԍ�
                    wrtCstSlpNoWrk.EndCustSlipNo = DEF_ED_SLIPNO;                                     // �I�����Ӑ�`�[�ԍ�
                    # endregion

                    // ���Ӑ�`�[�ԍ��敪�ɂ��̔ԏ���
                    switch (CstSlpNoDiv)
                    {
                        case 1:
                            {
                                # region [�A��]

                                // ���Ӑ�}�X�^(�`�[�ԍ�)�̊�ƃR�[�h��NULL�Ŗ����ꍇ�Ƀf�[�^�L��Ƃ���
                                if (!string.IsNullOrEmpty(ctsSlipNoList[0].EnterpriseCode))
                                {
                                    presentcustslipno = ctsSlipNoList[0].PresentCustSlipNo + 1;

                                    if (ctsSlipNoList[0].EndCustSlipNo < presentcustslipno)
                                    {
                                        presentcustslipno = ctsSlipNoList[0].StartCustSlipNo;
                                    }

                                    ctsSlipNoList[0].PresentCustSlipNo = presentcustslipno;
                                    
                                    wrtCstSlpNoWrk = ctsSlipNoList[0];
                                }

                                break;

                                # endregion
                            }
                        case 2:
                            {
                                # region [����]

                                // ������t����A�������܂ޔN�������Z�o����(��������'28'�ȍ~�̏ꍇ�͌����Ƃ��ď�������)
                                int tmpY4 = salesdate.Year;
                                int tmpMM = salesdate.Month;
                                int tmpDD = (totalDay < 28) ? totalDay : DateTime.DaysInMonth(tmpY4, tmpMM);

                                int salesday = tmpY4 * 10000 + tmpMM * 100 + salesdate.Day;   // ���l�^������t // ADD BY �c����  2019/05/17 For Redmine#49749
                                int tmpY4MMDD = tmpY4 * 10000 + tmpMM * 100 + tmpDD;   // �Y���N����
                                DateTime tmpDate = new DateTime(tmpY4, tmpMM, tmpDD);  // ���t�^�ɂ��Ă���

                                int[] objY4MM = new int[2];  // [0]���� [1]�O��

                                // ������t���Y���N�����ȉ��Ŋ����������������̏ꍇ�́A�Y�������P�����߂�
                                // -------- UPD  BY �c����  2019/05/17 For Redmine#49749 -------->>>>>
                                //if (salesdate <= tmpDate && tmpDD < 28)
                                if (salesday <= tmpY4MMDD && tmpDD < 28)
                                // -------- UPD  BY �c����  2019/05/17 For Redmine#49749 --------<<<<<
                                {
                                    tmpDate = tmpDate.AddMonths(-1);
                                    objY4MM[0] = tmpDate.Year * 100 + tmpDate.Month;
                                }
                                else
                                {
                                    objY4MM[0] = tmpY4 * 100 + tmpMM;
                                }

                                // �X�ɂP�����O�̊Y�������Z�o���Ă���
                                DateTime prvDate = tmpDate.AddMonths(-1);
                                objY4MM[1] = prvDate.Year * 100 + prvDate.Month;

                                // ���������Ƃ������Ώ۔N������������
                                for (int i = 0; i < objY4MM.Length; i++)
                                {
                                    int idx = ctsSlipNoList.FindIndex(delegate(TmpCustSlipNoWork item) { return item.AddUpYearMonth == objY4MM[i]; });

                                    if (idx > -1)
                                    {
                                        if (i == 0)
                                        {
                                            // �����Ō��������ꍇ
                                            presentcustslipno = ctsSlipNoList[idx].PresentCustSlipNo + 1;

                                            if (ctsSlipNoList[idx].EndCustSlipNo < presentcustslipno)
                                            {
                                                presentcustslipno = ctsSlipNoList[idx].StartCustSlipNo;
                                            }

                                            ctsSlipNoList[idx].PresentCustSlipNo = presentcustslipno;

                                            wrtCstSlpNoWrk = ctsSlipNoList[idx];
                                            break;
                                        }
                                        else
                                        {
                                            // �O���Ō��������ꍇ
                                            wrtCstSlpNoWrk.AddUpYearMonth = objY4MM[0];
                                            wrtCstSlpNoWrk.StartCustSlipNo = ctsSlipNoList[idx].StartCustSlipNo;
                                            wrtCstSlpNoWrk.EndCustSlipNo = ctsSlipNoList[idx].EndCustSlipNo;
                                            // --- ADD �����Y 2012/02/06 Redmine#28336 ------>>>>>
                                            presentcustslipno = ctsSlipNoList[idx].StartCustSlipNo;
                                            wrtCstSlpNoWrk.PresentCustSlipNo = presentcustslipno;
                                            // --- ADD �����Y 2012/02/06 Redmine#28336 ------<<<<<
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        // �������O���������ꍇ�͌v��N���������l����ύX����(���̍��ڂ́��Őݒ�ς�)
                                        if (i == objY4MM.Length - 1)
                                        {
                                            wrtCstSlpNoWrk.AddUpYearMonth = objY4MM[0];  // �v��N��
                                            break;
                                        }
                                    }
                                }
                                
                                break;

                                # endregion
                            }
                        case 3:
                            {
                                # region [����]

                                // ��������N�x�̎擾���s��
                                CompanyInfWork cmpInf = this.GetCompanyInformation(enterprisecode);
                                FinYearTableGenerator dateGetAcs = new FinYearTableGenerator(cmpInf);
                                int year;
                                DateTime adDate = DateTime.MinValue;
                                //dateGetAcs.GetYearMonth(salesdate, out adDate);// DEL 2010/12/22
                                dateGetAcs.GetYearMonth(salesdate, out adDate, out  year);// ADD 2010/12/22

                                int[] objY4 = new int[2];

                                //---DEL------------2010/12/22-------------------->>>>>
                                //objY4[0] = adDate.Year * 100;  // ���N

                                //adDate = adDate.AddYears(-1);
                                //objY4[1] = adDate.Year * 100;  // �O�N
                                //---DEL------------2010/12/22--------------------<<<<<

                                objY4[0] = year;// ADD 2010/12/22 

                                objY4[1] = year - 1;// ADD 2010/12/22

                                for (int i = 0; i < objY4.Length; i++)
                                {
                                    int idx = ctsSlipNoList.FindIndex(delegate(TmpCustSlipNoWork item) { return item.AddUpYearMonth == objY4[i]; });

                                    if (idx > -1)
                                    {
                                        if (i == 0)
                                        {
                                            // ���N�Ō��������ꍇ
                                            presentcustslipno = ctsSlipNoList[idx].PresentCustSlipNo + 1;

                                            if (ctsSlipNoList[idx].EndCustSlipNo < presentcustslipno)
                                            {
                                                presentcustslipno = ctsSlipNoList[idx].StartCustSlipNo;
                                            }

                                            ctsSlipNoList[idx].PresentCustSlipNo = presentcustslipno;

                                            wrtCstSlpNoWrk = ctsSlipNoList[idx];
                                            break;
                                        }
                                        else
                                        {
                                            // �O�N�Ō��������ꍇ
                                            wrtCstSlpNoWrk.AddUpYearMonth = objY4[0];
                                            wrtCstSlpNoWrk.StartCustSlipNo = ctsSlipNoList[idx].StartCustSlipNo;
                                            wrtCstSlpNoWrk.EndCustSlipNo = ctsSlipNoList[idx].EndCustSlipNo;
                                            // --- ADD �����Y 2012/02/06 Redmine#28336 ------>>>>>
                                            presentcustslipno = ctsSlipNoList[idx].StartCustSlipNo;
                                            wrtCstSlpNoWrk.PresentCustSlipNo = presentcustslipno;
                                            // --- ADD �����Y 2012/02/06 Redmine#28336 ------<<<<<
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        // ���N���O�N�������ꍇ�͌v��N���������l����ύX����(���̍��ڂ́��Őݒ�ς�)
                                        if (i == objY4.Length - 1)
                                        {
                                            wrtCstSlpNoWrk.AddUpYearMonth = objY4[0];  // �v��N��
                                            break;
                                        }
                                    }
                                }

                                break;

                                # endregion
                            }
                        default:
                            {
                                // �g�p���Ȃ��E���̑�(��O)
                                wrtCstSlpNoWrk = null;
                                break;
                            }
                    }

                    if (wrtCstSlpNoWrk != null)
                    {
                        ArrayList custSlipNoSetList = new ArrayList();
                        custSlipNoSetList.Add(wrtCstSlpNoWrk);
                        
                        // ���Ӑ�}�X�^(�`�[�ԍ�)���X�V����
                        status = this.WriteProc(ref custSlipNoSetList, ref connection, ref transaction);
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
                else
                {
                    // ���Ӑ�}�X�^�Ƀf�[�^�������ꍇ�ƂȂ�
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = this.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                this.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (dtReader != null)
                {
                    if (!dtReader.IsClosed)
                    {
                        dtReader.Close();
                    }
                    dtReader.Dispose();
                }

                if (command != null)
                {
                    command.Cancel();
                    command.Dispose();
                }
            }

            return status;
        }

        # endregion

    }
}
