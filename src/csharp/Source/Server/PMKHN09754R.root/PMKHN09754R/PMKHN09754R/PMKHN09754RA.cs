//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �D��q�Ƀ}�X�^
// �v���O�����T�v   : �D��q�ɂ̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : huangt
// �� �� ��  K2013/09/10  �C�����e : �V�K�쐬
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
    /// �D��q�ɐݒ�DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �D��q�ɐݒ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : huangt</br>
    /// <br>Date       : K2013/09/10</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ProtyWarehouseDB : RemoteWithAppLockDB, IProtyWarehouseDB
    {
        /// <summary>
        /// �D��q�ɐݒ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public ProtyWarehouseDB() : base("PMKHN09756D", "Broadleaf.Application.Remoting.ParamData.ProtyWarehouseWork", "WAREHECHSLIPSTRF")
        {

        }

        # region [Read]
        /// <summary>
        /// �P��̗D��q�ɐݒ�����擾���܂��B
        /// </summary>
        /// <param name="protyWarehouseList">��������</param>
        /// <param name="protyWarehouseObj">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D��q�ɐݒ�̃L�[�l����v����D��q�ɐݒ�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int Read(ref object protyWarehouseList, object protyWarehouseObj, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList protyWarehouseArray = new ArrayList();
            ProtyWarehouseWork protyWarehouseWork = protyWarehouseObj as ProtyWarehouseWork;
            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref protyWarehouseArray, protyWarehouseWork, logicalMode, ref sqlConnection, ref sqlTransaction);
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
            protyWarehouseList = (object)protyWarehouseArray;

            return status;
        }

        /// <summary>
        /// �P��̗D��q�ɐݒ�����擾���܂��B
        /// </summary>
        /// <param name="protyWarehouseList">��������</param>
        /// <param name="protyWarehouseWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D��q�ɐݒ�̃L�[�l����v����D��q�ɐݒ�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int Read(ref ArrayList protyWarehouseList, ProtyWarehouseWork protyWarehouseWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref protyWarehouseList, protyWarehouseWork, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �P��̗D��q�ɐݒ�����擾���܂��B
        /// </summary>
        /// <param name="protyWarehouseList">��������</param>
        /// <param name="protyWarehouseWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D��q�ɐݒ�̃L�[�l����v����D��q�ɐݒ�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private int ReadProc(ref ArrayList protyWarehouseList, ProtyWarehouseWork protyWarehouseWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                # region [SELECT��]

                sqlText.Append("SELECT ").AppendLine();
                sqlText.Append("PW.CREATEDATETIMERF, ").AppendLine();
                sqlText.Append("PW.UPDATEDATETIMERF, ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF, ").AppendLine();
                sqlText.Append("PW.FILEHEADERGUIDRF, ").AppendLine();
                sqlText.Append("PW.UPDEMPLOYEECODERF, ").AppendLine();
                sqlText.Append("PW.UPDASSEMBLYID1RF, ").AppendLine();
                sqlText.Append("PW.UPDASSEMBLYID2RF, ").AppendLine();
                sqlText.Append("PW.LOGICALDELETECODERF, ").AppendLine();
                sqlText.Append("PW.SECTIONCODERF, ").AppendLine();
                sqlText.Append("SEC.SECTIONGUIDENMRF, ").AppendLine();
                sqlText.Append("PW.WAREHOUSECODERF, ").AppendLine();
                sqlText.Append("WH.WAREHOUSENAMERF, ").AppendLine();
                sqlText.Append("PW.WAREHPROTYODRRF ").AppendLine();
                sqlText.Append("FROM ").AppendLine();
                sqlText.Append("PROTYWAREHOUSERF AS PW WITH (READUNCOMMITTED) ").AppendLine();
                sqlText.Append("LEFT JOIN ").AppendLine();
                sqlText.Append("SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ").AppendLine();
                sqlText.Append("ON ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF = SEC.ENTERPRISECODERF ").AppendLine();
                sqlText.Append("AND PW.SECTIONCODERF = SEC.SECTIONCODERF ").AppendLine();
                sqlText.Append("AND SEC.LOGICALDELETECODERF = 0 ").AppendLine();
                sqlText.Append("LEFT JOIN ").AppendLine();
                sqlText.Append("WAREHOUSERF AS WH WITH (READUNCOMMITTED) ").AppendLine();
                sqlText.Append("ON ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF = WH.ENTERPRISECODERF ").AppendLine();
                sqlText.Append("AND PW.WAREHOUSECODERF = WH.WAREHOUSECODERF ").AppendLine();
                sqlText.Append("AND WH.LOGICALDELETECODERF = 0 ").AppendLine();

                // �������������񐶐��{�����l�ݒ�
                MakeWhereString(ref sqlCommand, ref sqlText, protyWarehouseWork, logicalMode);

                sqlText.Append("ORDER BY ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF, ").AppendLine();
                sqlText.Append("PW.SECTIONCODERF, ").AppendLine();
                sqlText.Append("PW.WAREHPROTYODRRF ").AppendLine();
                
                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    protyWarehouseList.Add(this.CopyToProtyWarehouseWorkFromReader(ref myReader));
                }

                if (protyWarehouseList.Count > 0)
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

        # region [ReadWithWarehouse]
        /// <summary>
        /// �P��̗D��q�ɐݒ�����擾���܂�(���`����̎w�����������̍ۂɎg�p)�B
        /// </summary>
        /// <param name="protyWarehouseList">��������</param>
        /// <param name="protyWarehouseObj">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D��q�ɐݒ�̃L�[�l����v����D��q�ɐݒ�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int ReadWithWarehouse(ref object protyWarehouseList, object protyWarehouseObj, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList protyWarehouseArray = new ArrayList();
            ProtyWarehouseWork protyWarehouseWork = protyWarehouseObj as ProtyWarehouseWork;
            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.ReadWithWarehouse(ref protyWarehouseArray, protyWarehouseWork, logicalMode, ref sqlConnection, ref sqlTransaction);
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
            protyWarehouseList = (object)protyWarehouseArray;

            return status;
        }

        /// <summary>
        /// �P��̗D��q�ɐݒ�����擾���܂�(���`����̎w�����������̍ۂɎg�p)�B
        /// </summary>
        /// <param name="protyWarehouseList">��������</param>
        /// <param name="protyWarehouseWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D��q�ɐݒ�̃L�[�l����v����D��q�ɐݒ�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int ReadWithWarehouse(ref ArrayList protyWarehouseList, ProtyWarehouseWork protyWarehouseWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadWithWarehouseProc(ref protyWarehouseList, protyWarehouseWork, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �P��̗D��q�ɐݒ�����擾���܂�(���`����̎w�����������̍ۂɎg�p)�B
        /// </summary>
        /// <param name="protyWarehouseList">��������</param>
        /// <param name="protyWarehouseWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D��q�ɐݒ�̃L�[�l����v����D��q�ɐݒ�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private int ReadWithWarehouseProc(ref ArrayList protyWarehouseList, ProtyWarehouseWork protyWarehouseWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                # region [SELECT��]

                sqlText.Append("SELECT ").AppendLine();
                sqlText.Append("PW.CREATEDATETIMERF, ").AppendLine();
                sqlText.Append("PW.UPDATEDATETIMERF, ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF, ").AppendLine();
                sqlText.Append("PW.FILEHEADERGUIDRF, ").AppendLine();
                sqlText.Append("PW.UPDEMPLOYEECODERF, ").AppendLine();
                sqlText.Append("PW.UPDASSEMBLYID1RF, ").AppendLine();
                sqlText.Append("PW.UPDASSEMBLYID2RF, ").AppendLine();
                sqlText.Append("PW.LOGICALDELETECODERF, ").AppendLine();
                sqlText.Append("PW.SECTIONCODERF, ").AppendLine();
                sqlText.Append("SEC.SECTIONGUIDENMRF, ").AppendLine();
                sqlText.Append("PW.WAREHOUSECODERF, ").AppendLine();
                sqlText.Append("WH.WAREHOUSENAMERF, ").AppendLine();
                sqlText.Append("PW.WAREHPROTYODRRF ").AppendLine();
                sqlText.Append("FROM ").AppendLine();
                sqlText.Append("PROTYWAREHOUSERF AS PW WITH (READUNCOMMITTED) ").AppendLine();
                sqlText.Append("LEFT JOIN ").AppendLine();
                sqlText.Append("SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ").AppendLine();
                sqlText.Append("ON ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF = SEC.ENTERPRISECODERF ").AppendLine();
                sqlText.Append("AND PW.SECTIONCODERF = SEC.SECTIONCODERF ").AppendLine();
                sqlText.Append("AND SEC.LOGICALDELETECODERF = 0 ").AppendLine();
                sqlText.Append("LEFT JOIN ").AppendLine();
                sqlText.Append("WAREHOUSERF AS WH WITH (READUNCOMMITTED) ").AppendLine();
                sqlText.Append("ON ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF = WH.ENTERPRISECODERF ").AppendLine();
                sqlText.Append("AND PW.WAREHOUSECODERF = WH.WAREHOUSECODERF ").AppendLine();
                sqlText.Append("AND WH.LOGICALDELETECODERF = 0 ").AppendLine();

                // �������������񐶐��{�����l�ݒ�
                MakeWhereStringWithWarehouse(ref sqlCommand, ref sqlText, protyWarehouseWork, logicalMode);

                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    protyWarehouseList.Add(this.CopyToProtyWarehouseWorkFromReader(ref myReader));
                }

                if (protyWarehouseList.Count > 0)
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

        # region [Delete]
        /// <summary>
        /// �D��q�ɐݒ���𕨗��폜���܂�
        /// </summary>
        /// <param name="protyWarehouseList">�����폜����D��q�ɐݒ�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D��q�ɐݒ�̃L�[�l����v����D��q�ɐݒ���𕨗��폜���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int Delete(object protyWarehouseList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = protyWarehouseList as ArrayList;

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
        /// �D��q�ɐݒ���𕨗��폜���܂�
        /// </summary>
        /// <param name="protyWarehouseList">�D��q�ɐݒ�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : protyWarehouseList �Ɋi�[����Ă���D��q�ɐݒ���𕨗��폜���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int Delete(ArrayList protyWarehouseList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(protyWarehouseList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �D��q�ɐݒ���𕨗��폜���܂�
        /// </summary>
        /// <param name="protyWarehouseList">�D��q�ɐݒ�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : protyWarehouseList �Ɋi�[����Ă���D��q�ɐݒ���𕨗��폜���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private int DeleteProc(ArrayList protyWarehouseList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (protyWarehouseList != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    #region [�r���p]
                    ProtyWarehouseWork protyWarehouseWorkTemp = protyWarehouseList[0] as ProtyWarehouseWork;

                    sqlText.Remove(0, sqlText.Length);
                    sqlText.Append("SELECT ").AppendLine();
                    sqlText.Append("MAX(UPDATEDATETIMERF) AS UPDATEDATETIMERF").AppendLine();
                    sqlText.Append("FROM ").AppendLine();
                    sqlText.Append("PROTYWAREHOUSERF ").AppendLine();
                    sqlText.Append("WHERE ").AppendLine();
                    sqlText.Append("ENTERPRISECODERF = @CONDENTERPRISECODE ").AppendLine();
                    sqlText.Append("AND SECTIONCODERF = @CONDSECTIONCODE ").AppendLine();
                    sqlCommand.CommandText = sqlText.ToString();

                    // Prameter�I�u�W�F�N�g�̍쐬
                    sqlCommand.Parameters.Clear();
                    SqlParameter condEnterpriseCode = sqlCommand.Parameters.Add("@CONDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter condSectionCode = sqlCommand.Parameters.Add("@CONDSECTIONCODE", SqlDbType.NChar);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    condEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWorkTemp.EnterpriseCode);
                    condSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWorkTemp.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _maxUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����
                        if (_maxUpdateDateTime != protyWarehouseWorkTemp.MaxUpdateDateTime)
                        {
                            if (protyWarehouseWorkTemp.MaxUpdateDateTime != DateTime.MinValue)
                            {
                                // �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                return (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }
                        }
                    }

                    #endregion

                    for (int i = 0; i < protyWarehouseList.Count; i++)
                    {
                        ProtyWarehouseWork protyWarehouseWork = protyWarehouseList[i] as ProtyWarehouseWork;

                        # region [SELECT��]

                        sqlText.Remove(0, sqlText.Length);
                        sqlText.Append("SELECT ").AppendLine();
                        sqlText.Append("UPDATEDATETIMERF ").AppendLine();
                        sqlText.Append("FROM ").AppendLine();
                        sqlText.Append("PROTYWAREHOUSERF ").AppendLine();
                        sqlText.Append("WHERE ").AppendLine();
                        sqlText.Append("ENTERPRISECODERF = @FINDENTERPRISECODE ").AppendLine();
                        sqlText.Append("AND SECTIONCODERF = @FINDSECTIONCODE ").AppendLine();
                        sqlText.Append("AND WAREHOUSECODERF = @FINDWAREHOUSECODE ").AppendLine();

                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.SectionCode);
                        findWarehouseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.WarehouseCode);

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != protyWarehouseWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText.Remove(0, sqlText.Length);
                            sqlText.Append("DELETE ").AppendLine();
                            sqlText.Append("FROM ").AppendLine();
                            sqlText.Append("PROTYWAREHOUSERF ").AppendLine();
                            sqlText.Append("WHERE ").AppendLine();
                            sqlText.Append("ENTERPRISECODERF = @FINDENTERPRISECODE ").AppendLine();
                            sqlText.Append("AND SECTIONCODERF = @FINDSECTIONCODE ").AppendLine();
                            sqlText.Append("AND WAREHOUSECODERF = @FINDWAREHOUSECODE ").AppendLine();

                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);
                            findSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.SectionCode);
                            findWarehouseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.WarehouseCode);
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
        /// �D��q�ɐݒ���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="protyWarehouseList">��������</param>
        /// <param name="protyWarehouseObj">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D��q�ɐݒ�̃L�[�l����v����A�S�Ă̗D��q�ɐݒ�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int Search(ref object protyWarehouseList, object protyWarehouseObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;


            ArrayList protyWarehouseArray = new ArrayList();
            ProtyWarehouseWork protyWarehouseWork = protyWarehouseObj as ProtyWarehouseWork;
            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref protyWarehouseArray, protyWarehouseWork, ref sqlConnection, ref sqlTransaction);
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
            protyWarehouseList = (object)protyWarehouseArray;

            return status;
        }

        /// <summary>
        /// �D��q�ɐݒ���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="protyWarehouseList">�D��q�ɐݒ�����i�[���� ArrayList</param>
        /// <param name="protyWarehouseWork">��������</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D��q�ɐݒ�̃L�[�l����v����A�S�Ă̗D��q�ɐݒ��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int Search(ref ArrayList protyWarehouseList, ProtyWarehouseWork protyWarehouseWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref protyWarehouseList, protyWarehouseWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �D��q�ɐݒ���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="protyWarehouseList">�D��q�ɐݒ�����i�[���� ArrayList</param>
        /// <param name="protyWarehouseWork">��������</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D��q�ɐݒ�̃L�[�l����v����A�S�Ă̗D��q�ɐݒ��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private int SearchProc(ref ArrayList protyWarehouseList, ProtyWarehouseWork protyWarehouseWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                # region [SELECT��]

                sqlText.Append("SELECT ").AppendLine();
                sqlText.Append("PW.CREATEDATETIMERF, ").AppendLine();
                sqlText.Append("PW.UPDATEDATETIMERF, ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF, ").AppendLine();
                sqlText.Append("PW.FILEHEADERGUIDRF, ").AppendLine();
                sqlText.Append("PW.UPDEMPLOYEECODERF, ").AppendLine();
                sqlText.Append("PW.UPDASSEMBLYID1RF, ").AppendLine();
                sqlText.Append("PW.UPDASSEMBLYID2RF, ").AppendLine();
                sqlText.Append("PW.LOGICALDELETECODERF, ").AppendLine();
                sqlText.Append("PW.SECTIONCODERF, ").AppendLine();
                sqlText.Append("SEC.SECTIONGUIDENMRF, ").AppendLine();
                sqlText.Append("PW.WAREHOUSECODERF, ").AppendLine();
                sqlText.Append("WH.WAREHOUSENAMERF, ").AppendLine();
                sqlText.Append("PW.WAREHPROTYODRRF ").AppendLine();
                sqlText.Append("FROM ").AppendLine();
                sqlText.Append("PROTYWAREHOUSERF AS PW WITH (READUNCOMMITTED) ").AppendLine();
                sqlText.Append("LEFT JOIN ").AppendLine();
                sqlText.Append("SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ").AppendLine();
                sqlText.Append("ON ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF = SEC.ENTERPRISECODERF ").AppendLine();
                sqlText.Append("AND PW.SECTIONCODERF = SEC.SECTIONCODERF ").AppendLine();
                sqlText.Append("AND SEC.LOGICALDELETECODERF = 0 ").AppendLine();
                sqlText.Append("LEFT JOIN ").AppendLine();
                sqlText.Append("WAREHOUSERF AS WH WITH (READUNCOMMITTED) ").AppendLine();
                sqlText.Append("ON ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF = WH.ENTERPRISECODERF ").AppendLine();
                sqlText.Append("AND PW.WAREHOUSECODERF = WH.WAREHOUSECODERF ").AppendLine();
                sqlText.Append("AND WH.LOGICALDELETECODERF = 0 ").AppendLine();
                sqlText.Append("WHERE ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF = @FINDENTERPRISECODE ").AppendLine();
                sqlText.Append("ORDER BY ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF, ").AppendLine();
                sqlText.Append("PW.SECTIONCODERF, ").AppendLine();
                sqlText.Append("PW.WAREHPROTYODRRF ").AppendLine();

                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    protyWarehouseList.Add(this.CopyToProtyWarehouseWorkFromReader(ref myReader));
                }

                if (protyWarehouseList.Count > 0)
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
        /// �D��q�ɐݒ����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="protyWarehouseList">�ǉ��E�X�V����D��q�ɐݒ�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : protyWarehouseList �Ɋi�[����Ă���D��q�ɐݒ����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int Write(ref object protyWarehouseList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = protyWarehouseList as ArrayList;

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
        /// �D��q�ɐݒ����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="protyWarehouseList">�ǉ��E�X�V����D��q�ɐݒ�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : protyWarehouseList �Ɋi�[����Ă���D��q�ɐݒ����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int Write(ref ArrayList protyWarehouseList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref protyWarehouseList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �D��q�ɐݒ����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="protyWarehouseList">�ǉ��E�X�V����D��q�ɐݒ�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : protyWarehouseList �Ɋi�[����Ă���D��q�ɐݒ����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private int WriteProc(ref ArrayList protyWarehouseList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (protyWarehouseList != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    # region �r���p
                    ProtyWarehouseWork protyWarehouseWorkTemp = protyWarehouseList[0] as ProtyWarehouseWork;

                    sqlText.Remove(0, sqlText.Length);
                    sqlText.Append("SELECT ").AppendLine();
                    sqlText.Append("MAX(UPDATEDATETIMERF) AS UPDATEDATETIMERF").AppendLine();
                    sqlText.Append("FROM ").AppendLine();
                    sqlText.Append("PROTYWAREHOUSERF ").AppendLine();
                    sqlText.Append("WHERE ").AppendLine();
                    sqlText.Append("ENTERPRISECODERF = @CONDENTERPRISECODE ").AppendLine();
                    sqlText.Append("AND SECTIONCODERF = @CONDSECTIONCODE ").AppendLine();
                    sqlCommand.CommandText = sqlText.ToString();

                    // Prameter�I�u�W�F�N�g�̍쐬
                    sqlCommand.Parameters.Clear();
                    SqlParameter condEnterpriseCode = sqlCommand.Parameters.Add("@CONDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter condSectionCode = sqlCommand.Parameters.Add("@CONDSECTIONCODE", SqlDbType.NChar);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    condEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWorkTemp.EnterpriseCode);
                    condSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWorkTemp.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _maxUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����
                        if (_maxUpdateDateTime != protyWarehouseWorkTemp.MaxUpdateDateTime)
                        {
                            if (protyWarehouseWorkTemp.MaxUpdateDateTime == DateTime.MinValue)
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
                    }

                    # endregion

                    for (int i = 0; i < protyWarehouseList.Count; i++)
                    {
                        ProtyWarehouseWork protyWarehouseWork = protyWarehouseList[i] as ProtyWarehouseWork;

                        # region [SELECT��]

                        sqlText.Remove(0, sqlText.Length);
                        sqlText.Append("SELECT ").AppendLine();
                        sqlText.Append("CREATEDATETIMERF, ").AppendLine();
                        sqlText.Append("UPDATEDATETIMERF ").AppendLine();
                        sqlText.Append("FROM ").AppendLine();
                        sqlText.Append("PROTYWAREHOUSERF ").AppendLine();
                        sqlText.Append("WHERE ").AppendLine();
                        sqlText.Append("ENTERPRISECODERF = @FINDENTERPRISECODE ").AppendLine();
                        sqlText.Append("AND SECTIONCODERF = @FINDSECTIONCODE ").AppendLine();
                        sqlText.Append("AND WAREHOUSECODERF = @FINDWAREHOUSECODE ").AppendLine();

                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.SectionCode);
                        findWarehouseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.WarehouseCode);

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // �w�b�_���̍쐬�������擾
                            DateTime _createDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));// �쐬����

                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != protyWarehouseWork.UpdateDateTime)
                            {
                                if (protyWarehouseWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText.Remove(0, sqlText.Length);
                            sqlText.Append("UPDATE ").AppendLine();
                            sqlText.Append("PROTYWAREHOUSERF ").AppendLine();
                            sqlText.Append("SET ").AppendLine();
                            sqlText.Append("CREATEDATETIMERF = @CREATEDATETIME, ").AppendLine();
                            sqlText.Append("UPDATEDATETIMERF = @UPDATEDATETIME, ").AppendLine();
                            sqlText.Append("ENTERPRISECODERF = @ENTERPRISECODE, ").AppendLine();
                            sqlText.Append("FILEHEADERGUIDRF = @FILEHEADERGUID, ").AppendLine();
                            sqlText.Append("UPDEMPLOYEECODERF = @UPDEMPLOYEECODE, ").AppendLine();
                            sqlText.Append("UPDASSEMBLYID1RF = @UPDASSEMBLYID1, ").AppendLine();
                            sqlText.Append("UPDASSEMBLYID2RF = @UPDASSEMBLYID2, ").AppendLine();
                            sqlText.Append("LOGICALDELETECODERF = @LOGICALDELETECODE, ").AppendLine();
                            sqlText.Append("SECTIONCODERF = @SECTIONCODE, ").AppendLine();
                            sqlText.Append("WAREHOUSECODERF = @WAREHOUSECODE, ").AppendLine();
                            sqlText.Append("WAREHPROTYODRRF = @WAREHPROTYODR ").AppendLine();
                            sqlText.Append("WHERE ").AppendLine();
                            sqlText.Append("ENTERPRISECODERF = @FINDENTERPRISECODE ").AppendLine();
                            sqlText.Append("AND SECTIONCODERF = @FINDSECTIONCODE ").AppendLine();
                            sqlText.Append("AND WAREHOUSECODERF = @FINDWAREHOUSECODE ").AppendLine();
                            
                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);
                            findSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.SectionCode);
                            findWarehouseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.WarehouseCode);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)protyWarehouseWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                            protyWarehouseWork.CreateDateTime = _createDateTime;
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (protyWarehouseWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText.Remove(0, sqlText.Length);
                            sqlText.Append("INSERT INTO ").AppendLine();
                            sqlText.Append("PROTYWAREHOUSERF ").AppendLine();
                            sqlText.Append("(").AppendLine();
                            sqlText.Append("CREATEDATETIMERF, ").AppendLine();
                            sqlText.Append("UPDATEDATETIMERF, ").AppendLine();
                            sqlText.Append("ENTERPRISECODERF, ").AppendLine();
                            sqlText.Append("FILEHEADERGUIDRF, ").AppendLine();
                            sqlText.Append("UPDEMPLOYEECODERF, ").AppendLine();
                            sqlText.Append("UPDASSEMBLYID1RF, ").AppendLine();
                            sqlText.Append("UPDASSEMBLYID2RF, ").AppendLine();
                            sqlText.Append("LOGICALDELETECODERF, ").AppendLine();
                            sqlText.Append("SECTIONCODERF, ").AppendLine();
                            sqlText.Append("WAREHOUSECODERF, ").AppendLine();
                            sqlText.Append("WAREHPROTYODRRF ").AppendLine();
                            sqlText.Append(") ").AppendLine();
                            sqlText.Append("VALUES ").AppendLine();
                            sqlText.Append("(").AppendLine();
                            sqlText.Append("@CREATEDATETIME, ").AppendLine();
                            sqlText.Append("@UPDATEDATETIME, ").AppendLine();
                            sqlText.Append("@ENTERPRISECODE, ").AppendLine();
                            sqlText.Append("@FILEHEADERGUID, ").AppendLine();
                            sqlText.Append("@UPDEMPLOYEECODE, ").AppendLine();
                            sqlText.Append("@UPDASSEMBLYID1, ").AppendLine();
                            sqlText.Append("@UPDASSEMBLYID2, ").AppendLine();
                            sqlText.Append("@LOGICALDELETECODE, ").AppendLine();
                            sqlText.Append("@SECTIONCODE, ").AppendLine();
                            sqlText.Append("@WAREHOUSECODE, ").AppendLine();
                            sqlText.Append("@WAREHPROTYODR ").AppendLine();
                            sqlText.Append(")").AppendLine();

                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)protyWarehouseWork;
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
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraWarehProtyOdr = sqlCommand.Parameters.Add("@WAREHPROTYODR", SqlDbType.Int);

                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(protyWarehouseWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(protyWarehouseWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(protyWarehouseWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(protyWarehouseWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.SectionCode);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.WarehouseCode);
                        paraWarehProtyOdr.Value = SqlDataMediator.SqlSetInt32(protyWarehouseWork.WarehProtyOdr);

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(protyWarehouseWork);
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

            protyWarehouseList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// �D��q�ɐݒ����_���폜���܂��B
        /// </summary>
        /// <param name="protyWarehouseList">�_���폜����D��q�ɐݒ�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ProtyWarehouseWork �Ɋi�[����Ă���D��q�ɐݒ����_���폜���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int LogicalDelete(ref object protyWarehouseList)
        {
            return this.LogicalDelete(ref protyWarehouseList, 0);
        }

        /// <summary>
        /// �D��q�ɐݒ���̘_���폜���������܂��B
        /// </summary>
        /// <param name="protyWarehouseList">�_���폜����������D��q�ɐݒ�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ProtyWarehouseWork �Ɋi�[����Ă���D��q�ɐݒ���̘_���폜���������܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int RevivalLogicalDelete(ref object protyWarehouseList)
        {
            return this.LogicalDelete(ref protyWarehouseList, 1);
        }

        /// <summary>
        /// �D��q�ɐݒ���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="protyWarehouseList">�_���폜�𑀍삷��D��q�ɐݒ���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ProtyWarehouseWork �Ɋi�[����Ă���D��q�ɐݒ���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private int LogicalDelete(ref object protyWarehouseList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = protyWarehouseList as ArrayList;

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
        /// �D��q�ɐݒ���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="protyWarehouseList">�_���폜�𑀍삷��D��q�ɐݒ�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ProtyWarehouseWork �Ɋi�[����Ă���D��q�ɐݒ���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int LogicalDelete(ref ArrayList protyWarehouseList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref protyWarehouseList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �D��q�ɐݒ���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="protyWarehouseList">�_���폜�𑀍삷��D��q�ɐݒ�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ProtyWarehouseWork �Ɋi�[����Ă���D��q�ɐݒ���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private int LogicalDeleteProc(ref ArrayList protyWarehouseList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (protyWarehouseList != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < protyWarehouseList.Count; i++)
                    {
                        ProtyWarehouseWork protyWarehouseWork = protyWarehouseList[i] as ProtyWarehouseWork;

                        # region [SELECT��]
                        sqlText.Remove(0, sqlText.Length);
                        sqlText.Append("SELECT ").AppendLine();
                        sqlText.Append("UPDATEDATETIMERF, ").AppendLine();
                        sqlText.Append("LOGICALDELETECODERF ").AppendLine();
                        sqlText.Append("FROM ").AppendLine();
                        sqlText.Append("PROTYWAREHOUSERF ").AppendLine();
                        sqlText.Append("WHERE ").AppendLine();
                        sqlText.Append("ENTERPRISECODERF = @FINDENTERPRISECODE ").AppendLine();
                        sqlText.Append("AND SECTIONCODERF = @FINDSECTIONCODE ").AppendLine();
                        sqlText.Append("AND WAREHOUSECODERF = @FINDWAREHOUSECODE ").AppendLine();
                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.SectionCode);
                        findWarehouseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.WarehouseCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != protyWarehouseWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText.Remove(0, sqlText.Length);
                            sqlText.Append("UPDATE ").AppendLine();
                            sqlText.Append("PROTYWAREHOUSERF ").AppendLine();
                            sqlText.Append("SET ").AppendLine();
                            sqlText.Append("UPDATEDATETIMERF = @UPDATEDATETIME, ").AppendLine();
                            sqlText.Append("UPDEMPLOYEECODERF = @UPDEMPLOYEECODE, ").AppendLine();
                            sqlText.Append("UPDASSEMBLYID1RF = @UPDASSEMBLYID1, ").AppendLine();
                            sqlText.Append("UPDASSEMBLYID2RF = @UPDASSEMBLYID2, ").AppendLine();
                            sqlText.Append("LOGICALDELETECODERF = @LOGICALDELETECODE ").AppendLine();
                            sqlText.Append("WHERE ").AppendLine();
                            sqlText.Append("ENTERPRISECODERF = @FINDENTERPRISECODE ").AppendLine();
                            sqlText.Append("AND SECTIONCODERF = @FINDSECTIONCODE ").AppendLine();
                            sqlText.Append("AND WAREHOUSECODERF = @FINDWAREHOUSECODE ").AppendLine();

                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);
                            findSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.SectionCode);
                            findWarehouseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.WarehouseCode);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)protyWarehouseWork;
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
                            else if (logicalDelCd == 0) protyWarehouseWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else protyWarehouseWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                protyWarehouseWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(protyWarehouseWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(protyWarehouseWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(protyWarehouseWork);
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

            protyWarehouseList = al;

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="sqlText">SQL��</param>
        /// <param name="protyWarehouseWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private void MakeWhereString(ref SqlCommand sqlCommand, ref StringBuilder sqlText, ProtyWarehouseWork protyWarehouseWork, ConstantManagement.LogicalMode logicalMode)
        {
            string tempString = string.Empty;
            sqlText.Append("WHERE ").AppendLine();

            // ��ƃR�[�h
            sqlText.Append("PW.ENTERPRISECODERF = @FINDENTERPRISECODE ").AppendLine();
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                tempString = "AND PW.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                tempString = "AND PW.LOGICALDELETECODERF < @FINDLOGICALDELETECODE ";
            }
            if (!string.IsNullOrEmpty(tempString))
            {
                sqlText.Append(tempString).AppendLine();
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // ���_�R�[�h
            if (!string.IsNullOrEmpty(protyWarehouseWork.SectionCode))
            {
                sqlText.Append("AND PW.SECTIONCODERF = @FINDSECTIONCODERF ").AppendLine();
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.SectionCode);
            }
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�(���`����̎w�����������̍ۂɎg�p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="sqlText">SQL��</param>
        /// <param name="protyWarehouseWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private void MakeWhereStringWithWarehouse(ref SqlCommand sqlCommand, ref StringBuilder sqlText, ProtyWarehouseWork protyWarehouseWork, ConstantManagement.LogicalMode logicalMode)
        {
            string tempString = string.Empty;
            sqlText.Append("WHERE ").AppendLine();

            // ��ƃR�[�h
            sqlText.Append("PW.ENTERPRISECODERF = @FINDENTERPRISECODE ").AppendLine();
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                tempString = "AND PW.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                tempString = "AND PW.LOGICALDELETECODERF < @FINDLOGICALDELETECODE ";
            }
            if (!string.IsNullOrEmpty(tempString))
            {
                sqlText.Append(tempString).AppendLine();
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // ���_�R�[�h
            if (!string.IsNullOrEmpty(protyWarehouseWork.SectionCode))
            {
                sqlText.Append("AND PW.SECTIONCODERF = @FINDSECTIONCODE ").AppendLine();
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.SectionCode);
            }

            // �q�ɃR�[�h
            if (!string.IsNullOrEmpty(protyWarehouseWork.WarehouseCode))
            {
                sqlText.Append("AND PW.WAREHOUSECODERF = @FINDWAREHOUSECODE ").AppendLine();
                SqlParameter findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                findWarehouseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.WarehouseCode);
            }
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� ProtyWarehouseWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>ProtyWarehouseWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        private ProtyWarehouseWork CopyToProtyWarehouseWorkFromReader(ref SqlDataReader myReader)
        {
            ProtyWarehouseWork protyWarehouseWork = new ProtyWarehouseWork();

            this.CopyToProtyWarehouseWorkFromReader(ref myReader, ref protyWarehouseWork);

            return protyWarehouseWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� ProtyWarehouseWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="protyWarehouseWork">ProtyWarehouseWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        private void CopyToProtyWarehouseWorkFromReader(ref SqlDataReader myReader, ref ProtyWarehouseWork protyWarehouseWork)
        {
            if (myReader != null && protyWarehouseWork != null)
            {
                # region �N���X�֊i�[
                protyWarehouseWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
                protyWarehouseWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
                protyWarehouseWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
                protyWarehouseWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
                protyWarehouseWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                protyWarehouseWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                protyWarehouseWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                protyWarehouseWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                protyWarehouseWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                protyWarehouseWork.SectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                protyWarehouseWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                protyWarehouseWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                protyWarehouseWork.WarehProtyOdr = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAREHPROTYODRRF"));
                # endregion
            }
        }
        # endregion
    }
}
