using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.LocalAccess
{
    /// <summary>
    /// �]�ƈ��ڍ׃}�X�^LC���[�J��DB�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �]�ƈ��ڍ׃}�X�^LC�̃��[�J��DB���f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2008.01.23</br>
    /// <br></br>
    /// <br>Update Note: 2008.05.30 20081 �D�c �E�l</br>
    /// <br>           : PM.NS�p�ɕύX</br>
    /// <br>Update Note: UOE���̋敪�ǉ�</br>
    /// <br>Programmer : 30009 �a�J ���</br>
    /// <br>Date       : 2008.11.10</br>
    /// <br></br>
        /// </remarks>
    public class EmployeeDtlLcDB : IWriteSyncLocalData
    {
        /// <summary>
        /// �]�ƈ��ڍ׃}�X�^LC���[�J��DB�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        /// </remarks>
        public EmployeeDtlLcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ��ڍ׃}�X�^LC���LIST��߂��܂�
        /// </summary>
        /// <param name="employeeDtlWorkList">��������</param>
        /// <param name="paraEmployeeDtlWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��ڍ׃}�X�^LC���LIST��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        public int Search(out List<EmployeeDtlWork> employeeDtlWorkList, EmployeeDtlWork paraEmployeeDtlWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            employeeDtlWorkList = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchEmployeeDtlProcProc(out employeeDtlWorkList, paraEmployeeDtlWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "EmployeeDtlLcDB.Search", 0);
                employeeDtlWorkList = new List<EmployeeDtlWork>();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ��ڍ׃}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="employeeDtlWorkList">��������</param>
        /// <param name="employeeDtlWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��ڍ׃}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        public int SearchEmployeeDtlProc(out List<EmployeeDtlWork> employeeDtlWorkList, EmployeeDtlWork employeeDtlWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            status = SearchEmployeeDtlProcProc(out employeeDtlWorkList, employeeDtlWork, readMode, logicalMode, ref sqlConnection);
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ��ڍ׃}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="employeeDtlWorkList">��������</param>
        /// <param name="employeeDtlWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��ڍ׃}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        private int SearchEmployeeDtlProcProc(out List<EmployeeDtlWork> employeeDtlWorkList, EmployeeDtlWork employeeDtlWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<EmployeeDtlWork> listdata = new List<EmployeeDtlWork>();
            try
            {
                // 2008.05.30 upd start --------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEEDTLRF  ", sqlConnection);
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,BELONGSUBSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE6RF" + Environment.NewLine;
                // 2008.11.10 add start --------------------------------------------->>
                sqlText += " ,UOESNMDIVRF" + Environment.NewLine;
                // 2008.11.10 add end -----------------------------------------------<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  EMPLOYEEDTLRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                // 2008.05.30 upd end -----------------------------<<

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, employeeDtlWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listdata.Add(CopyToEmployeeDtlWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "EmployeeDtlLcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            employeeDtlWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ��ڍ׃}�X�^LC��߂��܂�
        /// </summary>
        /// <param name="employeeDtlWork">employeeDtlWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��ڍ׃}�X�^LC��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        public int Read(ref EmployeeDtlWork employeeDtlWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcProc(ref employeeDtlWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "EmployeeDtlLcDB.Read", 0);
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
        /// �w�肳�ꂽ�����̏]�ƈ��ڍ׃}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="employeeDtlWork">employeeDtlWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��ڍ׃}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        public int ReadProc(ref EmployeeDtlWork employeeDtlWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = ReadProcProc(ref employeeDtlWork, readMode, ref sqlConnection);
            return status;

        }

        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ��ڍ׃}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="employeeDtlWork">employeeDtlWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��ڍ׃}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        private int ReadProcProc(ref EmployeeDtlWork employeeDtlWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Select�R�}���h�̐���
                // 2008.05.30 upd start ----------------------->>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEEDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE", sqlConnection))
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,BELONGSUBSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE6RF" + Environment.NewLine;
                // 2008.11.10 add start --------------------------------------------->>
                sqlText += " ,UOESNMDIVRF" + Environment.NewLine;
                // 2008.11.10 add end -----------------------------------------------<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  EMPLOYEEDTLRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                // 2008.05.30 upd end -------------------------<<
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EnterpriseCode);
                    findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EmployeeCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        employeeDtlWork = CopyToEmployeeDtlWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "EmployeeDtlLcDB.Read", 0);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [WriteSyncLocalData]
        /// <summary>
        /// ���[�U�f�[�^�V���N�Ǘ��}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="syncServiceWork">syncLocalDataWork�I�u�W�F�N�g</param>
        /// <param name="paraSyncDataList">paraSyncDataList�I�u�W�F�N�g</param>
        /// <param name="readMode">readMode(���g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�U�f�[�^�V���N�Ǘ��}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        public int WriteSyncLocalData(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ArrayList syncDataList = new ArrayList();
            try
            {
                if (syncServiceWork == null) return status;
                if (paraSyncDataList == null) return status;

                //�g�p����p�����[�^�̃L���X�g
                EmployeeDtlWork employeeDtlWork = new EmployeeDtlWork();

                for (int i = 0; i < paraSyncDataList.Count; i++)
                {
                    syncDataList = (ArrayList)paraSyncDataList[i];
                    if (syncDataList[0].GetType() == employeeDtlWork.GetType())
                    {
                        break;
                    }
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteSyncLocalDataProcProc(syncServiceWork, syncDataList, readMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "EmployeeDtlLcDB.WriteSyncLocalData", 0);
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���[�U�f�[�^�V���N�Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="syncServiceWork">syncLocalDataWork�I�u�W�F�N�g</param>
        /// <param name="paraSyncDataList">paraSyncDataList�I�u�W�F�N�g</param>
        /// <param name="readMode">readMode(���g�p)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�U�f�[�^�V���N�Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        public int WriteSyncLocalDataProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList syncDataList = new ArrayList();
            status = WriteSyncLocalDataProcProc(syncServiceWork, syncDataList, readMode, ref sqlConnection, ref sqlTransaction);
            return status;
        }

        /// <summary>
        /// ���[�U�f�[�^�V���N�Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="syncServiceWork">syncLocalDataWork�I�u�W�F�N�g</param>
        /// <param name="paraSyncDataList">paraSyncDataList�I�u�W�F�N�g</param>
        /// <param name="readMode">readMode(���g�p)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�U�f�[�^�V���N�Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        private int WriteSyncLocalDataProcProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList listdata = new ArrayList();
            string sqlText = string.Empty; // 2008.05.30 add
            try
            {
                if (paraSyncDataList != null)
                {
                    if (syncServiceWork.Syncmode == 1)
                    {
                        // 2008.05.30 upd start -------------------------------------->>
                        //sqlCommand = new SqlCommand("DELETE FROM EMPLOYEEDTLRF WHERE ENTERPRISECODERF=@DELENTERPRISECODE", sqlConnection, sqlTransaction);
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += " FROM EMPLOYEEDTLRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@DELENTERPRISECODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                        // 2008.05.30 upd end ----------------------------------------<<
                        
                        SqlParameter delEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                        delEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);
                        sqlCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < paraSyncDataList.Count; i++)
                    {
                        EmployeeDtlWork employeeDtlWork = paraSyncDataList[i] as EmployeeDtlWork;
                        object obj;
                        IFileHeader flhd;
                        ClientFileHeader fileHeader;

                        switch (syncServiceWork.Syncmode)
                        {
                            //�������[�h�̃V���N����
                            case 0:
                                //Select�R�}���h�̐���
                                // 2008.05.30 upd start -------------------------------------->>
                                //sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEEDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE", sqlConnection, sqlTransaction);
                                sqlText = string.Empty;
                                sqlText += "SELECT" + Environment.NewLine;
                                sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                                sqlText += " ,BELONGSUBSECTIONCODERF" + Environment.NewLine;
                                sqlText += " ,EMPLOYANALYSCODE1RF" + Environment.NewLine;
                                sqlText += " ,EMPLOYANALYSCODE2RF" + Environment.NewLine;
                                sqlText += " ,EMPLOYANALYSCODE3RF" + Environment.NewLine;
                                sqlText += " ,EMPLOYANALYSCODE4RF" + Environment.NewLine;
                                sqlText += " ,EMPLOYANALYSCODE5RF" + Environment.NewLine;
                                sqlText += " ,EMPLOYANALYSCODE6RF" + Environment.NewLine;
                                // 2008.11.10 add start --------------------------------------------->>
                                sqlText += " ,UOESNMDIVRF" + Environment.NewLine;
                                // 2008.11.10 add end -----------------------------------------------<<
                                sqlText += "FROM" + Environment.NewLine;
                                sqlText += "  EMPLOYEEDTLRF" + Environment.NewLine;
                                sqlText += "WHERE" + Environment.NewLine;
                                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                                // 2008.05.30 upd end ----------------------------------------<<

                                //Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EnterpriseCode);
                                findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EmployeeCode);

                                myReader = sqlCommand.ExecuteReader();
                                if (myReader.Read())
                                {
                                    //Update�R�}���h�̐���
                                    // 2008.05.30 upd start -------------------------------------->>
                                    //sqlCommand.CommandText = "UPDATE EMPLOYEEDTLRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , EMPLOYEECODERF=@EMPLOYEECODE , BELONGSUBSECTIONCODERF=@BELONGSUBSECTIONCODE , BELONGSUBSECTIONNAMERF=@BELONGSUBSECTIONNAME , BELONGMINSECTIONCODERF=@BELONGMINSECTIONCODE , BELONGMINSECTIONNAMERF=@BELONGMINSECTIONNAME , BELONGSALESAREACODERF=@BELONGSALESAREACODE , BELONGSALESAREANAMERF=@BELONGSALESAREANAME , EMPLOYANALYSCODE1RF=@EMPLOYANALYSCODE1 , EMPLOYANALYSCODE2RF=@EMPLOYANALYSCODE2 , EMPLOYANALYSCODE3RF=@EMPLOYANALYSCODE3 , EMPLOYANALYSCODE4RF=@EMPLOYANALYSCODE4 , EMPLOYANALYSCODE5RF=@EMPLOYANALYSCODE5 , EMPLOYANALYSCODE6RF=@EMPLOYANALYSCODE6 , OLDBELONGSECTIONCDRF=@OLDBELONGSECTIONCD , OLDBELONGSECTIONNMRF=@OLDBELONGSECTIONNM , OLDBELONGSUBSECCDRF=@OLDBELONGSUBSECCD , OLDBELONGSUBSECNMRF=@OLDBELONGSUBSECNM , OLDBELONGMINSECCDRF=@OLDBELONGMINSECCD , OLDBELONGMINSECNMRF=@OLDBELONGMINSECNM , SECTIONCHGDATERF=@SECTIONCHGDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                                    sqlText = string.Empty;
                                    sqlText += "UPDATE" + Environment.NewLine;
                                    sqlText += "  EMPLOYEEDTLRF" + Environment.NewLine;
                                    sqlText += "SET" + Environment.NewLine;
                                    sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                                    sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                                    sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                                    sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                                    sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                                    sqlText += " ,EMPLOYEECODERF = @EMPLOYEECODE" + Environment.NewLine;
                                    sqlText += " ,BELONGSUBSECTIONCODERF = @BELONGSUBSECTIONCODE" + Environment.NewLine;
                                    sqlText += " ,EMPLOYANALYSCODE1RF = @EMPLOYANALYSCODE1" + Environment.NewLine;
                                    sqlText += " ,EMPLOYANALYSCODE2RF = @EMPLOYANALYSCODE2" + Environment.NewLine;
                                    sqlText += " ,EMPLOYANALYSCODE3RF = @EMPLOYANALYSCODE3" + Environment.NewLine;
                                    sqlText += " ,EMPLOYANALYSCODE4RF = @EMPLOYANALYSCODE4" + Environment.NewLine;
                                    sqlText += " ,EMPLOYANALYSCODE5RF = @EMPLOYANALYSCODE5" + Environment.NewLine;
                                    sqlText += " ,EMPLOYANALYSCODE6RF = @EMPLOYANALYSCODE6" + Environment.NewLine;
                                    // 2008.11.10 add start --------------------------------------------->>
                                    sqlText += " ,UOESNMDIVRF = @UOESNMDIV" + Environment.NewLine;
                                    // 2008.11.10 add end -----------------------------------------------<<
                                    sqlText += "WHERE" + Environment.NewLine;
                                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlText += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlText;
                                    // 2008.05.30 upd end ----------------------------------------<<
                                    //KEY�R�}���h���Đݒ�
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EnterpriseCode);
                                    findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EmployeeCode);
                                    //�X�V�w�b�_����ݒ�
                                    //FileHeaderGuid��Select���ʂ���擾
                                    employeeDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                                    obj = (object)this;
                                    flhd = (IFileHeader)employeeDtlWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);

                                }
                                else
                                {
                                    //Insert�R�}���h�̐���
                                    // 2008.05.30 upd start -------------------------------------->>
                                    //sqlCommand.CommandText = "INSERT INTO EMPLOYEEDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, EMPLOYEECODERF, BELONGSUBSECTIONCODERF, BELONGSUBSECTIONNAMERF, BELONGMINSECTIONCODERF, BELONGMINSECTIONNAMERF, BELONGSALESAREACODERF, BELONGSALESAREANAMERF, EMPLOYANALYSCODE1RF, EMPLOYANALYSCODE2RF, EMPLOYANALYSCODE3RF, EMPLOYANALYSCODE4RF, EMPLOYANALYSCODE5RF, EMPLOYANALYSCODE6RF, OLDBELONGSECTIONCDRF, OLDBELONGSECTIONNMRF, OLDBELONGSUBSECCDRF, OLDBELONGSUBSECNMRF, OLDBELONGMINSECCDRF, OLDBELONGMINSECNMRF, SECTIONCHGDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @EMPLOYEECODE, @BELONGSUBSECTIONCODE, @BELONGSUBSECTIONNAME, @BELONGMINSECTIONCODE, @BELONGMINSECTIONNAME, @BELONGSALESAREACODE, @BELONGSALESAREANAME, @EMPLOYANALYSCODE1, @EMPLOYANALYSCODE2, @EMPLOYANALYSCODE3, @EMPLOYANALYSCODE4, @EMPLOYANALYSCODE5, @EMPLOYANALYSCODE6, @OLDBELONGSECTIONCD, @OLDBELONGSECTIONNM, @OLDBELONGSUBSECCD, @OLDBELONGSUBSECNM, @OLDBELONGMINSECCD, @OLDBELONGMINSECNM, @SECTIONCHGDATE)";
                                    sqlText = string.Empty;
                                    sqlText += "INSERT INTO EMPLOYEEDTLRF" + Environment.NewLine;
                                    sqlText += "(" + Environment.NewLine;
                                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                                    sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                                    sqlText += " ,BELONGSUBSECTIONCODERF" + Environment.NewLine;
                                    sqlText += " ,EMPLOYANALYSCODE1RF" + Environment.NewLine;
                                    sqlText += " ,EMPLOYANALYSCODE2RF" + Environment.NewLine;
                                    sqlText += " ,EMPLOYANALYSCODE3RF" + Environment.NewLine;
                                    sqlText += " ,EMPLOYANALYSCODE4RF" + Environment.NewLine;
                                    sqlText += " ,EMPLOYANALYSCODE5RF" + Environment.NewLine;
                                    sqlText += " ,EMPLOYANALYSCODE6RF" + Environment.NewLine;
                                    // 2008.11.10 add start --------------------------------------------->>
                                    sqlText += " ,UOESNMDIVRF" + Environment.NewLine;
                                    // 2008.11.10 add end -----------------------------------------------<<
                                    sqlText += ")" + Environment.NewLine;
                                    sqlText += "VALUES" + Environment.NewLine;
                                    sqlText += "(" + Environment.NewLine;
                                    sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                                    sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                                    sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                                    sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                                    sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlText += " ,@EMPLOYEECODE" + Environment.NewLine;
                                    sqlText += " ,@BELONGSUBSECTIONCODE" + Environment.NewLine;
                                    sqlText += " ,@EMPLOYANALYSCODE1" + Environment.NewLine;
                                    sqlText += " ,@EMPLOYANALYSCODE2" + Environment.NewLine;
                                    sqlText += " ,@EMPLOYANALYSCODE3" + Environment.NewLine;
                                    sqlText += " ,@EMPLOYANALYSCODE4" + Environment.NewLine;
                                    sqlText += " ,@EMPLOYANALYSCODE5" + Environment.NewLine;
                                    sqlText += " ,@EMPLOYANALYSCODE6" + Environment.NewLine;
                                    sqlText += ")" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlText;
                                    // 2008.05.30 upd end ----------------------------------------<<
                                    //�o�^�w�b�_����ݒ�
                                    obj = (object)this;
                                    flhd = (IFileHeader)employeeDtlWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetInsertHeader(ref flhd, obj);
                                }
                                if (myReader.IsClosed == false) myReader.Close();
                                break;

                            //�S���o�^�̃V���N����
                            case 1:
                                //Insert�R�}���h�̐���
                                // 2008.05.30 upd start -------------------------------------->>
                                //sqlCommand = new SqlCommand("INSERT INTO EMPLOYEEDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, EMPLOYEECODERF, BELONGSUBSECTIONCODERF, BELONGSUBSECTIONNAMERF, BELONGMINSECTIONCODERF, BELONGMINSECTIONNAMERF, BELONGSALESAREACODERF, BELONGSALESAREANAMERF, EMPLOYANALYSCODE1RF, EMPLOYANALYSCODE2RF, EMPLOYANALYSCODE3RF, EMPLOYANALYSCODE4RF, EMPLOYANALYSCODE5RF, EMPLOYANALYSCODE6RF, OLDBELONGSECTIONCDRF, OLDBELONGSECTIONNMRF, OLDBELONGSUBSECCDRF, OLDBELONGSUBSECNMRF, OLDBELONGMINSECCDRF, OLDBELONGMINSECNMRF, SECTIONCHGDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @EMPLOYEECODE, @BELONGSUBSECTIONCODE, @BELONGSUBSECTIONNAME, @BELONGMINSECTIONCODE, @BELONGMINSECTIONNAME, @BELONGSALESAREACODE, @BELONGSALESAREANAME, @EMPLOYANALYSCODE1, @EMPLOYANALYSCODE2, @EMPLOYANALYSCODE3, @EMPLOYANALYSCODE4, @EMPLOYANALYSCODE5, @EMPLOYANALYSCODE6, @OLDBELONGSECTIONCD, @OLDBELONGSECTIONNM, @OLDBELONGSUBSECCD, @OLDBELONGSUBSECNM, @OLDBELONGMINSECCD, @OLDBELONGMINSECNM, @SECTIONCHGDATE)", sqlConnection, sqlTransaction);
                                sqlText = string.Empty;
                                sqlText += "INSERT INTO EMPLOYEEDTLRF" + Environment.NewLine;
                                sqlText += "(" + Environment.NewLine;
                                sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                                sqlText += " ,BELONGSUBSECTIONCODERF" + Environment.NewLine;
                                sqlText += " ,EMPLOYANALYSCODE1RF" + Environment.NewLine;
                                sqlText += " ,EMPLOYANALYSCODE2RF" + Environment.NewLine;
                                sqlText += " ,EMPLOYANALYSCODE3RF" + Environment.NewLine;
                                sqlText += " ,EMPLOYANALYSCODE4RF" + Environment.NewLine;
                                sqlText += " ,EMPLOYANALYSCODE5RF" + Environment.NewLine;
                                sqlText += " ,EMPLOYANALYSCODE6RF" + Environment.NewLine;
                                // 2008.11.10 add start --------------------------------------------->>
                                sqlText += " ,UOESNMDIVRF" + Environment.NewLine;
                                // 2008.11.10 add end -----------------------------------------------<<
                                sqlText += ")" + Environment.NewLine;
                                sqlText += "VALUES" + Environment.NewLine;
                                sqlText += "(" + Environment.NewLine;
                                sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                                sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                                sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                                sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                                sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                                sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                                sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                                sqlText += " ,@EMPLOYEECODE" + Environment.NewLine;
                                sqlText += " ,@BELONGSUBSECTIONCODE" + Environment.NewLine;
                                sqlText += " ,@EMPLOYANALYSCODE1" + Environment.NewLine;
                                sqlText += " ,@EMPLOYANALYSCODE2" + Environment.NewLine;
                                sqlText += " ,@EMPLOYANALYSCODE3" + Environment.NewLine;
                                sqlText += " ,@EMPLOYANALYSCODE4" + Environment.NewLine;
                                sqlText += " ,@EMPLOYANALYSCODE5" + Environment.NewLine;
                                sqlText += " ,@EMPLOYANALYSCODE6" + Environment.NewLine;
                                sqlText += ")" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                                // 2008.05.30 upd end ----------------------------------------<<
                                //�o�^�w�b�_����ݒ�
                                obj = (object)this;
                                flhd = (IFileHeader)employeeDtlWork;
                                fileHeader = new ClientFileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);
                                break;
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
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraBelongSubSectionCode = sqlCommand.Parameters.Add("@BELONGSUBSECTIONCODE", SqlDbType.Int);
                        // 2008.05.30 del start -------------------------------------->>
                        //SqlParameter paraBelongSubSectionName = sqlCommand.Parameters.Add("@BELONGSUBSECTIONNAME", SqlDbType.NVarChar);
                        //SqlParameter paraBelongMinSectionCode = sqlCommand.Parameters.Add("@BELONGMINSECTIONCODE", SqlDbType.Int);
                        //SqlParameter paraBelongMinSectionName = sqlCommand.Parameters.Add("@BELONGMINSECTIONNAME", SqlDbType.NVarChar);
                        //SqlParameter paraBelongSalesAreaCode = sqlCommand.Parameters.Add("@BELONGSALESAREACODE", SqlDbType.Int);
                        //SqlParameter paraBelongSalesAreaName = sqlCommand.Parameters.Add("@BELONGSALESAREANAME", SqlDbType.NVarChar);
                        // 2008.05.30 del end ----------------------------------------<<
                        SqlParameter paraEmployAnalysCode1 = sqlCommand.Parameters.Add("@EMPLOYANALYSCODE1", SqlDbType.Int);
                        SqlParameter paraEmployAnalysCode2 = sqlCommand.Parameters.Add("@EMPLOYANALYSCODE2", SqlDbType.Int);
                        SqlParameter paraEmployAnalysCode3 = sqlCommand.Parameters.Add("@EMPLOYANALYSCODE3", SqlDbType.Int);
                        SqlParameter paraEmployAnalysCode4 = sqlCommand.Parameters.Add("@EMPLOYANALYSCODE4", SqlDbType.Int);
                        SqlParameter paraEmployAnalysCode5 = sqlCommand.Parameters.Add("@EMPLOYANALYSCODE5", SqlDbType.Int);
                        SqlParameter paraEmployAnalysCode6 = sqlCommand.Parameters.Add("@EMPLOYANALYSCODE6", SqlDbType.Int);
                        // 2008.11.10 add start --------------------------------------------->>
                        SqlParameter paraUOESnmDiv = sqlCommand.Parameters.Add("@UOESNMDIV", SqlDbType.NChar);
                        // 2008.11.10 add end -----------------------------------------------<<
                        // 2008.05.30 del start -------------------------------------->>
                        //SqlParameter paraOldBelongSectionCd = sqlCommand.Parameters.Add("@OLDBELONGSECTIONCD", SqlDbType.NChar);
                        //SqlParameter paraOldBelongSectionNm = sqlCommand.Parameters.Add("@OLDBELONGSECTIONNM", SqlDbType.NVarChar);
                        //SqlParameter paraOldBelongSubSecCd = sqlCommand.Parameters.Add("@OLDBELONGSUBSECCD", SqlDbType.Int);
                        //SqlParameter paraOldBelongSubSecNm = sqlCommand.Parameters.Add("@OLDBELONGSUBSECNM", SqlDbType.NVarChar);
                        //SqlParameter paraOldBelongMinSecCd = sqlCommand.Parameters.Add("@OLDBELONGMINSECCD", SqlDbType.Int);
                        //SqlParameter paraOldBelongMinSecNm = sqlCommand.Parameters.Add("@OLDBELONGMINSECNM", SqlDbType.NVarChar);
                        //SqlParameter paraSectionChgDate = sqlCommand.Parameters.Add("@SECTIONCHGDATE", SqlDbType.Int);
                        // 2008.05.30 del end ----------------------------------------<<
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeDtlWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeDtlWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(employeeDtlWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(employeeDtlWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(employeeDtlWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.LogicalDeleteCode);
                        paraEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EmployeeCode);
                        paraBelongSubSectionCode.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.BelongSubSectionCode);
                        // 2008.05.30 del start -------------------------------------->>
                        //paraBelongSubSectionName.Value = SqlDataMediator.SqlSetString(employeeDtlWork.BelongSubSectionName);
                        //paraBelongMinSectionCode.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.BelongMinSectionCode);
                        //paraBelongMinSectionName.Value = SqlDataMediator.SqlSetString(employeeDtlWork.BelongMinSectionName);
                        //paraBelongSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.BelongSalesAreaCode);
                        //paraBelongSalesAreaName.Value = SqlDataMediator.SqlSetString(employeeDtlWork.BelongSalesAreaName);
                        // 2008.05.30 del end ----------------------------------------<<
                        paraEmployAnalysCode1.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.EmployAnalysCode1);
                        paraEmployAnalysCode2.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.EmployAnalysCode2);
                        paraEmployAnalysCode3.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.EmployAnalysCode3);
                        paraEmployAnalysCode4.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.EmployAnalysCode4);
                        paraEmployAnalysCode5.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.EmployAnalysCode5);
                        paraEmployAnalysCode6.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.EmployAnalysCode6);
                        // 2008.11.10 add start --------------------------------------------->>
                        paraUOESnmDiv.Value = SqlDataMediator.SqlSetString(employeeDtlWork.UOESnmDiv);
                        // 2008.11.10 add end -----------------------------------------------<<
                        // 2008.05.30 del start -------------------------------------->>
                        //paraOldBelongSectionCd.Value = SqlDataMediator.SqlSetString(employeeDtlWork.OldBelongSectionCd);
                        //paraOldBelongSectionNm.Value = SqlDataMediator.SqlSetString(employeeDtlWork.OldBelongSectionNm);
                        //paraOldBelongSubSecCd.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.OldBelongSubSecCd);
                        //paraOldBelongSubSecNm.Value = SqlDataMediator.SqlSetString(employeeDtlWork.OldBelongSubSecNm);
                        //paraOldBelongMinSecCd.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.OldBelongMinSecCd);
                        //paraOldBelongMinSecNm.Value = SqlDataMediator.SqlSetString(employeeDtlWork.OldBelongMinSecNm);
                        //paraSectionChgDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(employeeDtlWork.SectionChgDate);
                        // 2008.05.30 del end ----------------------------------------<<
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                    }

                    //���[�U�f�[�^�V���N�Ǘ��}�X�^�֍X�V
                    DataSyncMngWork dataSyncMngWork = new DataSyncMngWork();
                    DataSyncMngLcDB dataSyncMngLcDB = new DataSyncMngLcDB();
                    List<DataSyncMngWork> dataSyncMngWorkList = new List<DataSyncMngWork>();
                    dataSyncMngWork.EnterpriseCode = syncServiceWork.EnterpriseCode;
                    dataSyncMngWork.LastDataUpdDate = syncServiceWork.SyncDateTimeEd;
                    dataSyncMngWork.SyncExecDate = syncServiceWork.SyncExecDate;
                    dataSyncMngWork.ManagementTableName = syncServiceWork.ManagementTableName;
                    dataSyncMngWork.DataDeleteDateTime = syncServiceWork.DataDeleteDateTime;
                    dataSyncMngWorkList.Add(dataSyncMngWork);
                    status = dataSyncMngLcDB.WriteDataSyncMngProc(ref dataSyncMngWorkList, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "EmployeeDtlLcDB.WriteSyncLocalDataProc", 0);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="employeeDtlWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, EmployeeDtlWork employeeDtlWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EnterpriseCode);

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //�e�}�X�^��Where���L�q
            //�]�ƈ��R�[�h
            if (employeeDtlWork.EmployeeCode != "")
            {
                retstring += "AND EMPLOYEECODERF=@FINDEMPLOYEECODE ";
                SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                paraEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EmployeeCode);
            }

            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� EmployeeDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>EmployeeDtlWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        /// </remarks>
        private EmployeeDtlWork CopyToEmployeeDtlWorkFromReader(ref SqlDataReader myReader)
        {
            EmployeeDtlWork wkEmployeeDtlWork = new EmployeeDtlWork();

            #region �N���X�֊i�[
            wkEmployeeDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkEmployeeDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkEmployeeDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkEmployeeDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkEmployeeDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkEmployeeDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkEmployeeDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkEmployeeDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkEmployeeDtlWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            wkEmployeeDtlWork.BelongSubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BELONGSUBSECTIONCODERF"));
            // 2008.05.30 del start ----------------------------------->>
            //wkEmployeeDtlWork.BelongSubSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGSUBSECTIONNAMERF"));
            //wkEmployeeDtlWork.BelongMinSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BELONGMINSECTIONCODERF"));
            //wkEmployeeDtlWork.BelongMinSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGMINSECTIONNAMERF"));
            //wkEmployeeDtlWork.BelongSalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BELONGSALESAREACODERF"));
            //wkEmployeeDtlWork.BelongSalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGSALESAREANAMERF"));
            // 2008.05.30 del end -------------------------------------<<
            wkEmployeeDtlWork.EmployAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYANALYSCODE1RF"));
            wkEmployeeDtlWork.EmployAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYANALYSCODE2RF"));
            wkEmployeeDtlWork.EmployAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYANALYSCODE3RF"));
            wkEmployeeDtlWork.EmployAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYANALYSCODE4RF"));
            wkEmployeeDtlWork.EmployAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYANALYSCODE5RF"));
            wkEmployeeDtlWork.EmployAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYANALYSCODE6RF"));
            // 2008.11.10 add start --------------------------------------------->>
            wkEmployeeDtlWork.UOESnmDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESNMDIVRF"));
            // 2008.11.10 add end -----------------------------------------------<<
            // 2008.05.30 del start ----------------------------------->>
            //wkEmployeeDtlWork.OldBelongSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDBELONGSECTIONCDRF"));
            //wkEmployeeDtlWork.OldBelongSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDBELONGSECTIONNMRF"));
            //wkEmployeeDtlWork.OldBelongSubSecCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OLDBELONGSUBSECCDRF"));
            //wkEmployeeDtlWork.OldBelongSubSecNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDBELONGSUBSECNMRF"));
            //wkEmployeeDtlWork.OldBelongMinSecCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OLDBELONGMINSECCDRF"));
            //wkEmployeeDtlWork.OldBelongMinSecNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDBELONGMINSECNMRF"));
            //wkEmployeeDtlWork.SectionChgDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SECTIONCHGDATERF"));
            // 2008.05.30 del end -------------------------------------<<
            #endregion

            return wkEmployeeDtlWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.23</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            ClientSqlConnectionInfo clientSqlConnectionInfo = new ClientSqlConnectionInfo();
            string connectionText = clientSqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Local_UserDB);
            if (connectionText == null || connectionText == "") return null;
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }
        #endregion

        #region [�G���[���O�o�͏���]
        private void WriteErrorLog(Exception ex, string errorText, int status)
        {
            string message = "";
            if (ex != null)
            {
                if (ex is SqlException)
                {
                    this.WriteSQLErrorLog((SqlException)ex, errorText, status);
                }
                else
                {
                    message = string.Concat(new object[] { "Index #", 0, "\nMessage: ", ex.Message, "\n", errorText, "\nSource: ", ex.Source, "\nStatus = ", status.ToString(), "\n" });
                    new ClientLogTextOut().Output(ex.Source, message, status, ex);
                }
            }
            else
            {
                new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, errorText, status);
            }
        }

        private int WriteSQLErrorLog(SqlException ex, string errorText, int status)
        {
            string message = "";
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                object obj2 = message;
                message = string.Concat(new object[] { obj2, "Index #", i, "\nMessage: ", ex.Errors[i].Message, "\nLineNumber: ", ex.Errors[i].LineNumber, "\nSource: ", ex.Errors[i].Source, "\nProcedure: ", ex.Errors[i].Procedure, "\n" });
            }
            if (!errorText.Trim().Equals(""))
            {
                message = message + errorText + "\n";
            }
            message = message + "Status = " + status.ToString() + "\n";
            new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, message, status);
            if (ex.Number == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
            {
                return (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
            }
            if (ex.Number == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }
            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
        }
        #endregion

    }
}
