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
    /// �I�y���[�V�����ݒ胊���[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : OperationSt�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
    /// <br>Date       : 2008.07.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class OperationStDB : RemoteWithAppLockDB, IOperationStDB
    {
        /// <summary>
        /// OperationStDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.22</br>
        /// </remarks>
        public OperationStDB() : base("PMKHN09136D", "Broadleaf.Application.Remoting.ParamData.OperationStWork", "OperationStRF")
        {

        }

        #region [Read]
        /// <summary>
        /// �P���OperationSt�����擾���܂��B
        /// </summary>
        /// <param name="operationStObj">OperationStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationSt�̃L�[�l����v����OperationSt�����擾���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.22</br>
        public int Read(ref object operationStObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (operationStObj == null) return status;

                //�p�����[�^�̃L���X�g
                OperationStWork operationStWork = operationStObj as OperationStWork;

                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                //Read���s
                status = this.Read(ref operationStWork, readMode, ref sqlConnection);
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
        /// �P���OperationSt�����擾���܂��B
        /// </summary>
        /// <param name="operationStWork">OperationStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationSt�̃L�[�l����v����OperationSt�����擾���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.22</br>
        private int Read(ref OperationStWork operationStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //Select�R�}���h�̐���
                #region [SELECT��]
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,OPERATIONSTDIVRF" + Environment.NewLine;
                sqlText += " ,CATEGORYCODERF" + Environment.NewLine;
                sqlText += " ,PGIDRF" + Environment.NewLine;
                sqlText += " ,OPERATIONCODERF" + Environment.NewLine;
                sqlText += " ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                sqlText += " ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,LIMITDIVRF" + Environment.NewLine;
                sqlText += " ,APPLYSTARTDATERF" + Environment.NewLine;
                sqlText += " ,APPLYENDDATERF" + Environment.NewLine;
                sqlText += " FROM OPERATIONSTRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += " AND CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;
                sqlText += " AND AUTHORITYLEVEL1RF=@FINDAUTHORITYLEVEL1" + Environment.NewLine;
                sqlText += " AND AUTHORITYLEVEL2RF=@FINDAUTHORITYLEVEL2" + Environment.NewLine;
                sqlText += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                #endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
                SqlParameter findParaPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                SqlParameter findParaOperationCode = sqlCommand.Parameters.Add("@FINDOPERATIONCODE", SqlDbType.Int);
                SqlParameter findParaAuthorityLevel1 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL1", SqlDbType.Int);
                SqlParameter findParaAuthorityLevel2 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL2", SqlDbType.Int);
                SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(operationStWork.EnterpriseCode);
                findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.CategoryCode);
                findParaPgId.Value = operationStWork.PgId;
                findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationCode);
                findParaAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel1);
                findParaAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel2);
                findParaEmployeeCode.Value = operationStWork.EmployeeCode;

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToOperationStWorkFromReader(ref myReader, ref operationStWork);
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
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
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
        #endregion

        #region [Search]
        /// <summary>
        /// OperationSt���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="operationStList">��������</param>
        /// <param name="operationStObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationSt�̃L�[�l����v����A�S�Ă�OperationSt�����擾���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.22</br>
        public int Search(ref object operationStList, object operationStObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (operationStObj == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList operationStArray = operationStList as ArrayList;
                if (operationStArray == null)
                {
                    operationStArray = new ArrayList();
                }

                OperationStWork operationStWork = operationStObj as OperationStWork;

                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                //Search���s
                status = this.Search(ref operationStArray, operationStWork, readMode, logicalMode, ref sqlConnection);
                operationStList = operationStArray;
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
        /// OperationSt���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="operationStList">OperationSt�����i�[</param>
        /// <param name="operationStWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationSt�̃L�[�l����v����A�S�Ă�OperationSt��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.22</br>
        private int Search(ref ArrayList operationStList, OperationStWork operationStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //Select�R�}���h�̐���
                #region [SELECT��]
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,OPERATIONSTDIVRF" + Environment.NewLine;
                sqlText += " ,CATEGORYCODERF" + Environment.NewLine;
                sqlText += " ,PGIDRF" + Environment.NewLine;
                sqlText += " ,OPERATIONCODERF" + Environment.NewLine;
                sqlText += " ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                sqlText += " ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,LIMITDIVRF" + Environment.NewLine;
                sqlText += " ,APPLYSTARTDATERF" + Environment.NewLine;
                sqlText += " ,APPLYENDDATERF" + Environment.NewLine;
                sqlText += " FROM OPERATIONSTRF" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                //WHERE��
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, operationStWork, logicalMode);
                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    operationStList.Add(this.CopyToOperationStWorkFromReader(ref myReader));
                }

                if (operationStList.Count > 0)
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
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
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
        #endregion

        #region [Write]
        /// <summary>
        /// OperationSt����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="operationStList">�ǉ��E�X�V����OperationSt���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStList �Ɋi�[����Ă���OperationSt����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.22</br>
        public int Write(ref object operationStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (operationStList == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList paraList = operationStList as ArrayList;
                if (paraList == null)
                {
                    paraList = new ArrayList();
                    OperationStWork operationStWork = operationStList as OperationStWork;
                    paraList.Add(operationStWork);
                }

                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                //�g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //Write���s
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
                            //�R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //���[���o�b�N
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
        /// OperationSt����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="operationStList">�ǉ��E�X�V����OperationSt���</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStList �Ɋi�[����Ă���OperationSt����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.22</br>
        private int Write(ref ArrayList operationStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (operationStList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < operationStList.Count; i++)
                    {
                        OperationStWork operationStWork = operationStList[i] as OperationStWork;

                        //Select�R�}���h�̐���
                        #region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " ,OPERATIONSTDIVRF" + Environment.NewLine;
                        sqlText += " ,CATEGORYCODERF" + Environment.NewLine;
                        sqlText += " ,PGIDRF" + Environment.NewLine;
                        sqlText += " ,OPERATIONCODERF" + Environment.NewLine;
                        sqlText += " ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                        sqlText += " ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                        sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,LIMITDIVRF" + Environment.NewLine;
                        sqlText += " ,APPLYSTARTDATERF" + Environment.NewLine;
                        sqlText += " ,APPLYENDDATERF" + Environment.NewLine;
                        sqlText += " FROM OPERATIONSTRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += " AND CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                        sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                        sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;
                        sqlText += " AND AUTHORITYLEVEL1RF=@FINDAUTHORITYLEVEL1" + Environment.NewLine;
                        sqlText += " AND AUTHORITYLEVEL2RF=@FINDAUTHORITYLEVEL2" + Environment.NewLine;
                        sqlText += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
                        SqlParameter findParaPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                        SqlParameter findParaOperationCode = sqlCommand.Parameters.Add("@FINDOPERATIONCODE", SqlDbType.Int);
                        SqlParameter findParaAuthorityLevel1 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL1", SqlDbType.Int);
                        SqlParameter findParaAuthorityLevel2 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL2", SqlDbType.Int);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(operationStWork.EnterpriseCode);
                        findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.CategoryCode);
                        findParaPgId.Value = operationStWork.PgId;
                        findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationCode);
                        findParaAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel1);
                        findParaAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel2);
                        findParaEmployeeCode.Value = operationStWork.EmployeeCode;

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != operationStWork.UpdateDateTime)
                            {
                                if (operationStWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                else
                                {
                                    //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }

                                return status;
                            }

                            //Update�R�}���h�̐���
                            #region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE OPERATIONSTRF" + Environment.NewLine;
                            sqlText += " SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,OPERATIONSTDIVRF=@OPERATIONSTDIV" + Environment.NewLine;
                            sqlText += " ,CATEGORYCODERF=@CATEGORYCODE" + Environment.NewLine;
                            sqlText += " ,PGIDRF=@PGID" + Environment.NewLine;
                            sqlText += " ,OPERATIONCODERF=@OPERATIONCODE" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVEL1RF=@AUTHORITYLEVEL1" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVEL2RF=@AUTHORITYLEVEL2" + Environment.NewLine;
                            sqlText += " ,EMPLOYEECODERF=@EMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,LIMITDIVRF=@LIMITDIV" + Environment.NewLine;
                            sqlText += " ,APPLYSTARTDATERF=@APPLYSTARTDATE" + Environment.NewLine;
                            sqlText += " ,APPLYENDDATERF=@APPLYENDDATE" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += " AND CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                            sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                            sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;
                            sqlText += " AND AUTHORITYLEVEL1RF=@FINDAUTHORITYLEVEL1" + Environment.NewLine;
                            sqlText += " AND AUTHORITYLEVEL2RF=@FINDAUTHORITYLEVEL2" + Environment.NewLine;
                            sqlText += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(operationStWork.EnterpriseCode);
                            findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.CategoryCode);
                            findParaPgId.Value = operationStWork.PgId;
                            findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationCode);
                            findParaAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel1);
                            findParaAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel2);
                            findParaEmployeeCode.Value = operationStWork.EmployeeCode;

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)operationStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (operationStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            //Insert�R�}���h�̐���
                            #region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO OPERATIONSTRF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,OPERATIONSTDIVRF" + Environment.NewLine;
                            sqlText += " ,CATEGORYCODERF" + Environment.NewLine;
                            sqlText += " ,PGIDRF" + Environment.NewLine;
                            sqlText += " ,OPERATIONCODERF" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                            sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,LIMITDIVRF" + Environment.NewLine;
                            sqlText += " ,APPLYSTARTDATERF" + Environment.NewLine;
                            sqlText += " ,APPLYENDDATERF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@OPERATIONSTDIV" + Environment.NewLine;
                            sqlText += " ,@CATEGORYCODE" + Environment.NewLine;
                            sqlText += " ,@PGID" + Environment.NewLine;
                            sqlText += " ,@OPERATIONCODE" + Environment.NewLine;
                            sqlText += " ,@AUTHORITYLEVEL1" + Environment.NewLine;
                            sqlText += " ,@AUTHORITYLEVEL2" + Environment.NewLine;
                            sqlText += " ,@EMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@LIMITDIV" + Environment.NewLine;
                            sqlText += " ,@APPLYSTARTDATE" + Environment.NewLine;
                            sqlText += " ,@APPLYENDDATE" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)operationStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraOperationStDiv = sqlCommand.Parameters.Add("@OPERATIONSTDIV", SqlDbType.Int);
                        SqlParameter paraCategoryCode = sqlCommand.Parameters.Add("@CATEGORYCODE", SqlDbType.Int);
                        SqlParameter paraPgId = sqlCommand.Parameters.Add("@PGID", SqlDbType.NVarChar);
                        SqlParameter paraOperationCode = sqlCommand.Parameters.Add("@OPERATIONCODE", SqlDbType.Int);
                        SqlParameter paraAuthorityLevel1 = sqlCommand.Parameters.Add("@AUTHORITYLEVEL1", SqlDbType.Int);
                        SqlParameter paraAuthorityLevel2 = sqlCommand.Parameters.Add("@AUTHORITYLEVEL2", SqlDbType.Int);
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraLimitDiv = sqlCommand.Parameters.Add("@LIMITDIV", SqlDbType.Int);
                        SqlParameter paraApplyStartDate = sqlCommand.Parameters.Add("@APPLYSTARTDATE", SqlDbType.Int);
                        SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(operationStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(operationStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(operationStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(operationStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(operationStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(operationStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(operationStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.LogicalDeleteCode);
                        paraOperationStDiv.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationStDiv);
                        paraCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.CategoryCode);
                        paraPgId.Value = operationStWork.PgId;
                        paraOperationCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationCode);
                        paraAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel1);
                        paraAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel2);
                        paraEmployeeCode.Value = operationStWork.EmployeeCode;
                        paraLimitDiv.Value = SqlDataMediator.SqlSetInt32(operationStWork.LimitDiv);
                        paraApplyStartDate.Value = SqlDataMediator.SqlSetInt32(operationStWork.ApplyStartDate);
                        paraApplyEndDate.Value = SqlDataMediator.SqlSetInt32(operationStWork.ApplyEndDate);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(operationStWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
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

            operationStList = al;

            return status;
        }
        #endregion

        #region [Delete]
        /// <summary>
        /// OperationSt���𕨗��폜���܂�
        /// </summary>
        /// <param name="operationStList">�����폜����OperationSt���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationSt�̃L�[�l����v����OperationSt���𕨗��폜���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.22</br>
        public int Delete(object operationStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (operationStList == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList paraList = operationStList as ArrayList;
                if (paraList == null)
                {
                    paraList = new ArrayList();
                    OperationStWork operationStWork = operationStList as OperationStWork;
                    paraList.Add(operationStWork);
                }

                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                //�g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //Delete���s
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
                            //�R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //���[���o�b�N
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
        /// OperationSt���𕨗��폜���܂�
        /// </summary>
        /// <param name="operationStList">OperationSt�����i�[</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStList �Ɋi�[����Ă���OperationSt���𕨗��폜���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.22</br>
        private int Delete(ArrayList operationStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (operationStList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < operationStList.Count; i++)
                    {
                        OperationStWork operationStWork = operationStList[i] as OperationStWork;

                        //Select�R�}���h�̐���
                        #region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM OPERATIONSTRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += " AND CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                        sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                        sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;
                        sqlText += " AND AUTHORITYLEVEL1RF=@FINDAUTHORITYLEVEL1" + Environment.NewLine;
                        sqlText += " AND AUTHORITYLEVEL2RF=@FINDAUTHORITYLEVEL2" + Environment.NewLine;
                        sqlText += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
                        SqlParameter findParaPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                        SqlParameter findParaOperationCode = sqlCommand.Parameters.Add("@FINDOPERATIONCODE", SqlDbType.Int);
                        SqlParameter findParaAuthorityLevel1 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL1", SqlDbType.Int);
                        SqlParameter findParaAuthorityLevel2 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL2", SqlDbType.Int);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(operationStWork.EnterpriseCode);
                        findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.CategoryCode);
                        findParaPgId.Value = operationStWork.PgId;
                        findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationCode);
                        findParaAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel1);
                        findParaAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel2);
                        findParaEmployeeCode.Value = operationStWork.EmployeeCode;

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //�X�V����

                            if (_updateDateTime != operationStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            //Delete�R�}���h�̐���
                            #region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM OPERATIONSTRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += " AND CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                            sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                            sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;
                            sqlText += " AND AUTHORITYLEVEL1RF=@FINDAUTHORITYLEVEL1" + Environment.NewLine;
                            sqlText += " AND AUTHORITYLEVEL2RF=@FINDAUTHORITYLEVEL2" + Environment.NewLine;
                            sqlText += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(operationStWork.EnterpriseCode);
                            findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.CategoryCode);
                            findParaPgId.Value = operationStWork.PgId;
                            findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationCode);
                            findParaAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel1);
                            findParaAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel2);
                            findParaEmployeeCode.Value = operationStWork.EmployeeCode;
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
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
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
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
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// OperationSt����_���폜���܂��B
        /// </summary>
        /// <param name="operationStList">�_���폜����OperationSt���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStWork �Ɋi�[����Ă���OperationSt����_���폜���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.22</br>
        public int LogicalDelete(ref object operationStList)
        {
            return this.LogicalDelete(ref operationStList, 0);
        }

        /// <summary>
        /// OperationSt���̘_���폜���������܂��B
        /// </summary>
        /// <param name="operationStList">�_���폜����������OperationSt���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStWork �Ɋi�[����Ă���OperationSt���̘_���폜���������܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.22</br>
        public int RevivalLogicalDelete(ref object operationStList)
        {
            return this.LogicalDelete(ref operationStList, 1);
        }

        /// <summary>
        /// OperationSt���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="operationStList">�_���폜�𑀍삷��OperationSt���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStWork �Ɋi�[����Ă���OperationSt���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.22</br>
        private int LogicalDelete(ref object operationStList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (operationStList == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList paraList = operationStList as ArrayList;
                if (paraList == null)
                {
                    paraList = new ArrayList();
                    OperationStWork operationStWork = operationStList as OperationStWork;
                    paraList.Add(operationStWork);
                }

                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                //�g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //LogicalDelete���s
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
                            //�R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //���[���o�b�N
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
        /// OperationSt���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="operationStList">�_���폜�𑀍삷��OperationSt���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStWork �Ɋi�[����Ă���OperationSt���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.22</br>
        private int LogicalDelete(ref ArrayList operationStList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (operationStList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < operationStList.Count; i++)
                    {
                        OperationStWork operationStWork = operationStList[i] as OperationStWork;

                        //Select�R�}���h�̐���
                        #region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " FROM OPERATIONSTRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += " AND CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                        sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                        sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;
                        sqlText += " AND AUTHORITYLEVEL1RF=@FINDAUTHORITYLEVEL1" + Environment.NewLine;
                        sqlText += " AND AUTHORITYLEVEL2RF=@FINDAUTHORITYLEVEL2" + Environment.NewLine;
                        sqlText += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                        
                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
                        SqlParameter findParaPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                        SqlParameter findParaOperationCode = sqlCommand.Parameters.Add("@FINDOPERATIONCODE", SqlDbType.Int);
                        SqlParameter findParaAuthorityLevel1 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL1", SqlDbType.Int);
                        SqlParameter findParaAuthorityLevel2 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL2", SqlDbType.Int);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(operationStWork.EnterpriseCode);
                        findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.CategoryCode);
                        findParaPgId.Value = operationStWork.PgId;
                        findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationCode);
                        findParaAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel1);
                        findParaAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel2);
                        findParaEmployeeCode.Value = operationStWork.EmployeeCode;
                        
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != operationStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            //Update�R�}���h�̐���
                            #region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE OPERATIONSTRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += " AND CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                            sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                            sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;
                            sqlText += " AND AUTHORITYLEVEL1RF=@FINDAUTHORITYLEVEL1" + Environment.NewLine;
                            sqlText += " AND AUTHORITYLEVEL2RF=@FINDAUTHORITYLEVEL2" + Environment.NewLine;
                            sqlText += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(operationStWork.EnterpriseCode);
                            findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.CategoryCode);
                            findParaPgId.Value = operationStWork.PgId;
                            findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationCode);
                            findParaAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel1);
                            findParaAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel2);
                            findParaEmployeeCode.Value = operationStWork.EmployeeCode;

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)operationStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        //�_���폜���[�h�̏ꍇ
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;         //���ɍ폜�ς݂̏ꍇ����
                                return status;
                            }
                            else if (logicalDelCd == 0) operationStWork.LogicalDeleteCode = 1;  //�_���폜�t���O���Z�b�g
                            else operationStWork.LogicalDeleteCode = 3;                         //���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                operationStWork.LogicalDeleteCode = 0;                          //�_���폜�t���O������
                            }
                            else
                            {
                                if (logicalDelCd == 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  //���S�폜�̓f�[�^�Ȃ���߂�
                                }

                                return status;
                            }
                        }

                        //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(operationStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(operationStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(operationStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(operationStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(operationStWork);
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
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
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

            operationStList = al;

            return status;
        }
        #endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="operationStWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.22</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, OperationStWork operationStWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            //��ƃR�[�h
            retstring += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(operationStWork.EnterpriseCode);

            //�_���폜�敪
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

            //�J�e�S���[�R�[�h
            if (operationStWork.CategoryCode != 0)
            {
                retstring += "  AND CATEGORYCODERF = @FINDCATEGORYCODE" + Environment.NewLine;
                SqlParameter findCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
                findCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.CategoryCode);
            }

            //�v���O�����h�c
            if (operationStWork.PgId != "")
            {
                retstring += "  AND PGIDRF = @FINDPGID" + Environment.NewLine;
                SqlParameter findPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                findPgId.Value = operationStWork.PgId;
            }

            //�I�y���[�V�����R�[�h
            if (operationStWork.OperationCode != 0)
            {
                retstring += "  AND OPERATIONCODERF = @FINDOPERATIONCODE" + Environment.NewLine;
                SqlParameter findOperationCode = sqlCommand.Parameters.Add("@FINDOPERATIONCODE", SqlDbType.Int);
                findOperationCode.Value = SqlDataMediator.SqlSetInt32(operationStWork.OperationCode);
            }

            //�������x��1
            if (operationStWork.AuthorityLevel1 != 0)
            {
                retstring += "  AND AUTHORITYLEVEL1RF = @FINDAUTHORITYLEVEL1" + Environment.NewLine;
                SqlParameter findAuthorityLevel1 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL1", SqlDbType.Int);
                findAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel1);
            }

            //�������x��2
            if (operationStWork.AuthorityLevel2 != 0)
            {
                retstring += "  AND AUTHORITYLEVEL2RF = @FINDAUTHORITYLEVEL2" + Environment.NewLine;
                SqlParameter findAuthorityLevel2 = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVEL2", SqlDbType.Int);
                findAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(operationStWork.AuthorityLevel2);
            }

            //�]�ƈ��R�[�h
            if (operationStWork.EmployeeCode != "")
            {
                retstring += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                SqlParameter findEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                findEmployeeCode.Value = operationStWork.EmployeeCode;
            }

            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� OperationStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>OperationStWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.22</br>
        /// </remarks>
        private OperationStWork CopyToOperationStWorkFromReader(ref SqlDataReader myReader)
        {
            OperationStWork operationStWork = new OperationStWork();

            this.CopyToOperationStWorkFromReader(ref myReader, ref operationStWork);

            return operationStWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� OperationStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="operationStWork">OperationStWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.22</br>
        /// </remarks>
        private void CopyToOperationStWorkFromReader(ref SqlDataReader myReader, ref OperationStWork operationStWork)
        {
            if (myReader != null && operationStWork != null)
            {
                #region �N���X�֊i�[
                operationStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                operationStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                operationStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                operationStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                operationStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                operationStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                operationStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                operationStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                operationStWork.OperationStDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPERATIONSTDIVRF"));
                operationStWork.CategoryCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYCODERF"));
                operationStWork.PgId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PGIDRF"));
                operationStWork.OperationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPERATIONCODERF"));
                operationStWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL1RF"));
                operationStWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL2RF"));
                operationStWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                operationStWork.LimitDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LIMITDIVRF"));
                operationStWork.ApplyStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYSTARTDATERF"));
                operationStWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
                #endregion
            }
        }
        #endregion
    }
}
