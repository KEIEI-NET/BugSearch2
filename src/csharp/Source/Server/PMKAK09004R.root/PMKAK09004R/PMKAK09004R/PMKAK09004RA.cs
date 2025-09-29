//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �d����}�X�^�i�����ݒ�jDB�����[�g�I�u�W�F�N�g
//                  :   PMKAK09004R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   FSI�֓� �a�G
// Date             :   2012/08/29
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
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
    /// �d����}�X�^�i�����ݒ�jDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d����}�X�^�i�����ݒ�j�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : FSI�֓� �a�G</br>
    /// <br>Date       : 2012/08/29</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SumSuppStDB : RemoteWithAppLockDB, ISumSuppStDB
    {
        /// <summary>
        /// �d����}�X�^�i�����ݒ�jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        /// </remarks>
        public SumSuppStDB()
            : base("PMKAK09006D", "Broadleaf.Application.Remoting.ParamData.SumSuppStWork", "SUMSUPPSTRF")
        {

        }

        # region [Delete]
        /// <summary>
        /// �d����}�X�^�i�����ݒ�j���𕨗��폜���܂�
        /// </summary>
        /// <param name="sumSuppStList">�����폜����d����}�X�^�i�����ݒ�j�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����}�X�^�i�����ݒ�j�̃L�[�l����v����d����}�X�^�i�����ݒ�j���𕨗��폜���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        public int Delete(object sumSuppStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = sumSuppStList as ArrayList;

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
        /// �d����}�X�^�i�����ݒ�j���𕨗��폜���܂�
        /// </summary>
        /// <param name="sumSuppStList">�d����}�X�^�i�����ݒ�j�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList �Ɋi�[����Ă���d����}�X�^�i�����ݒ�j���𕨗��폜���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        public int Delete(ArrayList sumSuppStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(sumSuppStList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �d����}�X�^�i�����ݒ�j���𕨗��폜���܂�
        /// </summary>
        /// <param name="sumSuppStList">�d����}�X�^�i�����ݒ�j�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList �Ɋi�[����Ă���d����}�X�^�i�����ݒ�j���𕨗��폜���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        private int DeleteProc(ArrayList sumSuppStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            StringBuilder sqlString = new StringBuilder(string.Empty);

            try
            {
                if (sumSuppStList != null)
                {
                    
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // �^�C���A�E�g���Ԃ�10���ɐݒ�
                    sqlCommand.CommandTimeout = 600;

                    for (int i = 0; i < sumSuppStList.Count; i++)
                    {
                        SumSuppStWork sumSuppStWork = sumSuppStList[i] as SumSuppStWork;
                        sqlString = new StringBuilder(string.Empty);

                        # region [SELECT��]
                        sqlString.AppendLine("SELECT");
                        sqlString.AppendLine("  UPDATEDATETIMERF");
                        sqlString.AppendLine("FROM");
                        sqlString.AppendLine("  SUMSUPPSTRF");
                        sqlString.AppendLine("WHERE");
                        sqlString.AppendLine("      ENTERPRISECODERF = @FINDENTERPRISECODE");
                        sqlString.AppendLine("  AND SUMSECTIONCDRF = @FINDSUMSECTIONCODE");
                        sqlString.AppendLine("  AND SUMSUPPLIERCDRF = @FINDSUMSUPPLIERCODE");
                        sqlString.AppendLine("  AND SECTIONCODERF = @FINDSECTIONCODE");
                        sqlString.AppendLine("  AND SUPPLIERCDRF = @FINDSUPPLIERCODE");
                        # endregion

                        sqlCommand.CommandText = sqlString.ToString();

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSumSectionCode = sqlCommand.Parameters.Add("@FINDSUMSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findSumSupplierCode = sqlCommand.Parameters.Add("@FINDSUMSUPPLIERCODE", SqlDbType.Int);
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findSupplierCode = sqlCommand.Parameters.Add("@FINDSUPPLIERCODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.EnterpriseCode);
                        findSumSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SumSectionCd.Trim());
                        findSumSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SumSupplierCd);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SectionCode.Trim());
                        findSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SupplierCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != sumSuppStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }
                            else
                            {
                                sqlString = new StringBuilder(string.Empty);

                                # region [DELETE��]
                                sqlString.AppendLine("DELETE");
                                sqlString.AppendLine("FROM");
                                sqlString.AppendLine("  SUMSUPPSTRF");
                                sqlString.AppendLine("WHERE");
                                sqlString.AppendLine("      ENTERPRISECODERF = @FINDENTERPRISECODE");
                                sqlString.AppendLine("  AND SUMSECTIONCDRF = @FINDSUMSECTIONCODE");
                                sqlString.AppendLine("  AND SUMSUPPLIERCDRF = @FINDSUMSUPPLIERCODE");
                                sqlString.AppendLine("  AND SECTIONCODERF = @FINDSECTIONCODE");
                                sqlString.AppendLine("  AND SUPPLIERCDRF = @FINDSUPPLIERCODE");
                                # endregion

                                sqlCommand.CommandText = sqlString.ToString();

                                // KEY�R�}���h���Đݒ�
                                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.EnterpriseCode);
                                findSumSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SumSectionCd.Trim());
                                findSumSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SumSupplierCd);
                                findSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SectionCode.Trim());
                                findSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SupplierCode);
                            }

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
        /// �d����}�X�^�i�����ݒ�j���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="sumSuppStList">��������</param>
        /// <param name="sumSuppStparaObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����}�X�^�i�����ݒ�j�̃L�[�l����v����A�S�Ă̎d����}�X�^�i�����ݒ�j�����擾���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        public int Search(ref object sumSuppStList, object sumSuppStparaObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList sumSuppStArray = sumSuppStList as ArrayList;

                if (sumSuppStArray == null)
                {
                    sumSuppStArray = new ArrayList();
                }

                SumSuppStWork sumSuppStWork = sumSuppStparaObj as SumSuppStWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref sumSuppStArray, sumSuppStWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// �d����}�X�^�i�����ݒ�j���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="sumSuppStList">�d����}�X�^�i�����ݒ�j�����i�[���� ArrayList</param>
        /// <param name="sumSuppStparaObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����}�X�^�i�����ݒ�j�̃L�[�l����v����A�S�Ă̎d����}�X�^�i�����ݒ�j��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        public int Search(ref ArrayList sumSuppStList, SumSuppStWork sumSuppStparaObj, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref sumSuppStList, sumSuppStparaObj, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �d����}�X�^�i�����ݒ�j���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="sumSuppStList">�d����}�X�^�i�����ݒ�j�����i�[���� ArrayList</param>
        /// <param name="sumSuppStparaObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����}�X�^�i�����ݒ�j�̃L�[�l����v����A�S�Ă̎d����}�X�^�i�����ݒ�j��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        private int SearchProc(ref ArrayList sumSuppStList, SumSuppStWork sumSuppStparaObj, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            StringBuilder sqlString = new StringBuilder(string.Empty);

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                // �^�C���A�E�g���Ԃ�10���ɐݒ�
                sqlCommand.CommandTimeout = 600;

                // READ UNCOMMITTED�̐ݒ�
                sqlCommand.Transaction = sqlConnection.BeginTransaction(IsolationLevel.ReadUncommitted);
                
                # region [SELECT��]
                sqlString.AppendLine("SELECT");
                sqlString.AppendLine("  *");
                sqlString.AppendLine("FROM");
                sqlString.AppendLine("  SUMSUPPSTRF");
                sqlString.AppendLine("WHERE");
                sqlString.AppendLine("        ENTERPRISECODERF = @FINDENTERPRISECODE");
                sqlString.AppendLine("  AND (@FINDSUMSECTIONCODE IS NULL OR @FINDSUMSECTIONCODE = SUMSECTIONCDRF)");
                sqlString.AppendLine("  AND (@FINDSUMSUPPLIERCODE = 0 OR @FINDSUMSUPPLIERCODE = SUMSUPPLIERCDRF)");

                # region [�_���폜�f�[�^���oWhere��ǉ�����]
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlString.AppendLine("  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlString.AppendLine("  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE");
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                # endregion [�_���폜�f�[�^���oWhere��ǉ�����]

                sqlString.AppendLine("ORDER BY");
                sqlString.AppendLine("  SUMSECTIONCDRF, SUMSUPPLIERCDRF");

                sqlCommand.CommandText = sqlString.ToString();

                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findSumSectionCode = sqlCommand.Parameters.Add("@FINDSUMSECTIONCODE", SqlDbType.NChar);
                SqlParameter findSumSupplierCode = sqlCommand.Parameters.Add("@FINDSUMSUPPLIERCODE", SqlDbType.Int);

                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumSuppStparaObj.EnterpriseCode);
                findSumSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStparaObj.SumSectionCd);
                findSumSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStparaObj.SumSupplierCd);
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    sumSuppStList.Add(this.CopyToSumSuppStWorkFromReader(ref myReader));
                }

                if (sumSuppStList.Count > 0)
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
        /// �d����}�X�^�i�����ݒ�j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="sumSuppStList">�ǉ��E�X�V����d����}�X�^�i�����ݒ�j�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList �Ɋi�[����Ă���d����}�X�^�i�����ݒ�j����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        public int Write(ref object sumSuppStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = sumSuppStList as ArrayList;

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
        /// �d����}�X�^�i�����ݒ�j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="sumSuppStList">�ǉ��E�X�V����d����}�X�^�i�����ݒ�j�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList �Ɋi�[����Ă���d����}�X�^�i�����ݒ�j����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        public int Write(ref ArrayList sumSuppStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref sumSuppStList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �d����}�X�^�i�����ݒ�j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="sumSuppStList">�ǉ��E�X�V����d����}�X�^�i�����ݒ�j�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList �Ɋi�[����Ă���d����}�X�^�i�����ݒ�j����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        private int WriteProc(ref ArrayList sumSuppStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            StringBuilder sqlString = new StringBuilder(string.Empty);

            try
            {
                if (sumSuppStList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // �^�C���A�E�g���Ԃ�10���ɐݒ�
                    sqlCommand.CommandTimeout = 600;

                    SumSuppStWork sumSuppStWork = sumSuppStList[0] as SumSuppStWork;

                    #region [DELETE��(INSERT�O)]
                    sqlString.AppendLine("DELETE");
                    sqlString.AppendLine("FROM");
                    sqlString.AppendLine("  SUMSUPPSTRF");
                    sqlString.AppendLine("WHERE");
                    sqlString.AppendLine("      ENTERPRISECODERF = @FINDENTERPRISECODE");
                    sqlString.AppendLine("  AND SUMSECTIONCDRF = @FINDSUMSECTIONCODE");
                    sqlString.AppendLine("  AND SUMSUPPLIERCDRF = @FINDSUMSUPPLIERCODE");
                    #endregion [DELETE��(INSERT�O)]

                    sqlCommand.CommandText = sqlString.ToString();

                    // Prameter�I�u�W�F�N�g�̍쐬
                    sqlCommand.Parameters.Clear();
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSumSectionCode = sqlCommand.Parameters.Add("@FINDSUMSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findSumSupplierCode = sqlCommand.Parameters.Add("@FINDSUMSUPPLIERCODE", SqlDbType.Int);

                    // KEY�R�}���h���Đݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.EnterpriseCode);
                    findSumSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SumSectionCd.Trim());
                    findSumSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SumSupplierCd);

                    sqlCommand.ExecuteNonQuery();

                    sqlString = new StringBuilder(string.Empty);

                    # region [INSERT��]
                    sqlString.AppendLine("INSERT INTO SUMSUPPSTRF");
                    sqlString.AppendLine("  (CREATEDATETIMERF");
                    sqlString.AppendLine("  ,UPDATEDATETIMERF");
                    sqlString.AppendLine("  ,ENTERPRISECODERF");
                    sqlString.AppendLine("  ,FILEHEADERGUIDRF");
                    sqlString.AppendLine("  ,UPDEMPLOYEECODERF");
                    sqlString.AppendLine("  ,UPDASSEMBLYID1RF");
                    sqlString.AppendLine("  ,UPDASSEMBLYID2RF");
                    sqlString.AppendLine("  ,LOGICALDELETECODERF");
                    sqlString.AppendLine("  ,SUMSECTIONCDRF");
                    sqlString.AppendLine("  ,SUMSUPPLIERCDRF");
                    sqlString.AppendLine("  ,SECTIONCODERF");
                    sqlString.AppendLine("  ,SUPPLIERCDRF");
                    sqlString.AppendLine(")");
                    sqlString.AppendLine(" VALUES");
                    sqlString.AppendLine("  (@CREATEDATETIME");
                    sqlString.AppendLine("  ,@UPDATEDATETIME");
                    sqlString.AppendLine("  ,@ENTERPRISECODE");
                    sqlString.AppendLine("  ,@FILEHEADERGUID");
                    sqlString.AppendLine("  ,@UPDEMPLOYEECODE");
                    sqlString.AppendLine("  ,@UPDASSEMBLYID1");
                    sqlString.AppendLine("  ,@UPDASSEMBLYID2");
                    sqlString.AppendLine("  ,@LOGICALDELETECODE");
                    sqlString.AppendLine("  ,@SUMSECTIONCODE");
                    sqlString.AppendLine("  ,@SUMSUPPLIERCODE");
                    sqlString.AppendLine("  ,@SECTIONCODE");
                    sqlString.AppendLine("  ,@SUPPLIERCODE");
                    sqlString.AppendLine(")");
                    # endregion

                    sqlCommand.CommandText = sqlString.ToString();

                    # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSumSectionCode = sqlCommand.Parameters.Add("@SUMSECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraSumSupplierCode = sqlCommand.Parameters.Add("@SUMSUPPLIERCODE", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraSupplierCode = sqlCommand.Parameters.Add("@SUPPLIERCODE", SqlDbType.Int);

                    # endregion

                    for (int i = 0; i < sumSuppStList.Count; i++)
                    {
                        sumSuppStWork = sumSuppStList[i] as SumSuppStWork;

                        // �o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sumSuppStWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sumSuppStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sumSuppStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(sumSuppStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sumSuppStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sumSuppStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.LogicalDeleteCode);
                        paraSumSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SumSectionCd.Trim());
                        paraSumSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SumSupplierCd);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SectionCode.Trim());
                        paraSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SupplierCode);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(sumSuppStWork);
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

            sumSuppStList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// �d����}�X�^�i�����ݒ�j����_���폜���܂��B
        /// </summary>
        /// <param name="sumSuppStList">�_���폜����d����}�X�^�i�����ݒ�j�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList �Ɋi�[����Ă���d����}�X�^�i�����ݒ�j����_���폜���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        public int LogicalDelete(ref object sumSuppStList)
        {
            return this.LogicalDelete(ref sumSuppStList, 0);
        }

        /// <summary>
        /// �d����}�X�^�i�����ݒ�j���̘_���폜���������܂��B
        /// </summary>
        /// <param name="sumSuppStList">�_���폜����������d����}�X�^�i�����ݒ�j�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList �Ɋi�[����Ă���d����}�X�^�i�����ݒ�j���̘_���폜���������܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        public int RevivalLogicalDelete(ref object sumSuppStList)
        {
            return this.LogicalDelete(ref sumSuppStList, 1);
        }

        /// <summary>
        /// �d����}�X�^�i�����ݒ�j���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="sumSuppStList">�_���폜�𑀍삷��d����}�X�^�i�����ݒ�j���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList �Ɋi�[����Ă���d����}�X�^�i�����ݒ�j���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        private int LogicalDelete(ref object sumSuppStList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = sumSuppStList as ArrayList;

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
        /// �d����}�X�^�i�����ݒ�j���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="sumSuppStList">�_���폜�𑀍삷��d����}�X�^�i�����ݒ�j�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList �Ɋi�[����Ă���d����}�X�^�i�����ݒ�j���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        public int LogicalDelete(ref ArrayList sumSuppStList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref sumSuppStList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �d����}�X�^�i�����ݒ�j���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="sumSuppStList">�_���폜�𑀍삷��d����}�X�^�i�����ݒ�j�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumSuppStList �Ɋi�[����Ă���d����}�X�^�i�����ݒ�j���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        private int LogicalDeleteProc(ref ArrayList sumSuppStList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            StringBuilder sqlString = new StringBuilder(string.Empty);

            try
            {
                if (sumSuppStList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // �^�C���A�E�g���Ԃ�10���ɐݒ�
                    sqlCommand.CommandTimeout = 600;

                    for (int i = 0; i < sumSuppStList.Count; i++)
                    {
                        SumSuppStWork sumSuppStWork = sumSuppStList[i] as SumSuppStWork;

                        sqlString = new StringBuilder(string.Empty);

                        # region [SELECT��]
                        sqlString.AppendLine("SELECT");
                        sqlString.AppendLine("  UPDATEDATETIMERF");
                        sqlString.AppendLine(" ,LOGICALDELETECODERF");
                        sqlString.AppendLine("FROM");
                        sqlString.AppendLine("  SUMSUPPSTRF");
                        sqlString.AppendLine("WHERE");
                        sqlString.AppendLine("      ENTERPRISECODERF = @FINDENTERPRISECODE");
                        sqlString.AppendLine("  AND SUMSECTIONCDRF = @FINDSUMSECTIONCODE");
                        sqlString.AppendLine("  AND SUMSUPPLIERCDRF = @FINDSUMSUPPLIERCODE");
                        sqlString.AppendLine("  AND SECTIONCODERF = @FINDSECTIONCODE");
                        sqlString.AppendLine("  AND SUPPLIERCDRF = @FINDSUPPLIERCODE");
                        # endregion

                        sqlCommand.CommandText = sqlString.ToString();
                        
                        // Prameter�I�u�W�F�N�g�̍쐬
                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSumSectionCode = sqlCommand.Parameters.Add("@FINDSUMSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findSumSupplierCode = sqlCommand.Parameters.Add("@FINDSUMSUPPLIERCODE", SqlDbType.Int);
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findSupplierCode = sqlCommand.Parameters.Add("@FINDSUPPLIERCODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.EnterpriseCode);
                        findSumSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SumSectionCd.Trim());
                        findSumSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SumSupplierCd);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SectionCode.Trim());
                        findSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SupplierCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != sumSuppStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            // SQL��������
                            sqlString = new StringBuilder(string.Empty);

                            # region [UPDATE��]
                            sqlString.AppendLine("UPDATE");
                            sqlString.AppendLine("  SUMSUPPSTRF");
                            sqlString.AppendLine("SET");
                            sqlString.AppendLine("  UPDATEDATETIMERF = @UPDATEDATETIME");
                            sqlString.AppendLine(" ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE");
                            sqlString.AppendLine(" ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1");
                            sqlString.AppendLine(" ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2");
                            sqlString.AppendLine(" ,LOGICALDELETECODERF = @LOGICALDELETECODE");
                            sqlString.AppendLine(" WHERE");
                            sqlString.AppendLine("      ENTERPRISECODERF = @FINDENTERPRISECODE");
                            sqlString.AppendLine("  AND SUMSECTIONCDRF = @FINDSUMSECTIONCODE");
                            sqlString.AppendLine("  AND SUMSUPPLIERCDRF = @FINDSUMSUPPLIERCODE");
                            sqlString.AppendLine("  AND SECTIONCODERF = @FINDSECTIONCODE");
                            sqlString.AppendLine("  AND SUPPLIERCDRF = @FINDSUPPLIERCODE");
                            # endregion

                            sqlCommand.CommandText = sqlString.ToString();

                            // KEY�R�}���h���Đݒ�(WHERE��)
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.EnterpriseCode);
                            findSumSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SumSectionCd.Trim());
                            findSumSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SumSupplierCd);
                            findSectionCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.SectionCode.Trim());
                            findSupplierCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.SupplierCode);


                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)sumSuppStWork;
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
                            else if (logicalDelCd == 0) sumSuppStWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else sumSuppStWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                sumSuppStWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sumSuppStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sumSuppStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sumSuppStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sumSuppStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sumSuppStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(sumSuppStWork);
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

            sumSuppStList = al;

            return status;
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SumSuppStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SumSuppStWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        /// </remarks>
        private SumSuppStWork CopyToSumSuppStWorkFromReader(ref SqlDataReader myReader)
        {
            SumSuppStWork sumSuppStWork = new SumSuppStWork();

            this.CopyToSumSuppStWorkFromReader(ref myReader, ref sumSuppStWork);

            return sumSuppStWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� SumSuppStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="sumSuppStWork">SumSuppStWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date       : 2012/08/29</br>
        /// </remarks>
        private void CopyToSumSuppStWorkFromReader(ref SqlDataReader myReader, ref SumSuppStWork sumSuppStWork)
        {
            if (myReader != null && sumSuppStWork != null)
            {
                # region �N���X�֊i�[
                sumSuppStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                sumSuppStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                sumSuppStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                sumSuppStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                sumSuppStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                sumSuppStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                sumSuppStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                sumSuppStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                sumSuppStWork.SumSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUMSECTIONCDRF"));
                sumSuppStWork.SumSupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMSUPPLIERCDRF"));
                sumSuppStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                sumSuppStWork.SupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                # endregion
            }
        }
        # endregion
    }
}
