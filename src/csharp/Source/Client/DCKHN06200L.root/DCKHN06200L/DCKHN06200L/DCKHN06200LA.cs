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
    /// ���Џ��}�X�^LC���[�J��DB�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Џ��}�X�^LC�̃��[�J��DB���f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2008.02.08</br>
    /// <br></br>
    /// <br>Update Note: 2008.05.27 20081 �D�c �E�l</br>
    /// <br>           : PM.NS�p�ɕύX</br>
    /// </remarks>
    public class CompanyInfLcDB : IWriteSyncLocalData
    {
        /// <summary>
        /// ���Џ��}�X�^LC���[�J��DB�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.02.08</br>
        /// </remarks>
        public CompanyInfLcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̎��Џ��}�X�^LC���LIST��߂��܂�
        /// </summary>
        /// <param name="companyInfWorkList">��������</param>
        /// <param name="paraCompanyInfWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎��Џ��}�X�^LC���LIST��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.02.08</br>
        public int Search(out List<CompanyInfWork> companyInfWorkList, CompanyInfWork paraCompanyInfWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            companyInfWorkList = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchCompanyInfProcProc(out companyInfWorkList, paraCompanyInfWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "CompanyInfLcDB.Search", 0);
                companyInfWorkList = new List<CompanyInfWork>();
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
        /// �w�肳�ꂽ�����̎��Џ��}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="companyInfWorkList">��������</param>
        /// <param name="companyInfWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎��Џ��}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.02.08</br>
        public int SearchCompanyInfProc(out List<CompanyInfWork> companyInfWorkList, CompanyInfWork companyInfWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            status = SearchCompanyInfProcProc(out companyInfWorkList, companyInfWork, readMode, logicalMode, ref sqlConnection);

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎��Џ��}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="companyInfWorkList">��������</param>
        /// <param name="companyInfWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎��Џ��}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.02.08</br>
        private int SearchCompanyInfProcProc(out List<CompanyInfWork> companyInfWorkList, CompanyInfWork companyInfWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<CompanyInfWork> listdata = new List<CompanyInfWork>();
            try
            {
                // 2008.05.27 upd start ------------------------>>
                //sqlCommand = new SqlCommand("SELECT * FROM COMPANYINFRF  ", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTOTALDAYRF" + Environment.NewLine;
                sqlTxt += "    ,FINANCIALYEARRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYBIGINMONTHRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYBIGINMONTH2RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYBIGINDATERF" + Environment.NewLine;
                sqlTxt += "    ,STARTYEARDIVRF" + Environment.NewLine;
                sqlTxt += "    ,STARTMONTHDIVRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                sqlTxt += "    ,SECMNGDIVRF" + Environment.NewLine;
                sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.27 upd end --------------------------<<

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, companyInfWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listdata.Add(CopyToCompanyInfWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "CompanyInfLcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            companyInfWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̎��Џ��}�X�^LC��߂��܂�
        /// </summary>
        /// <param name="companyInfWork">companyInfWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎��Џ��}�X�^LC��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.02.08</br>
        public int Read(ref CompanyInfWork companyInfWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcProc(ref companyInfWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "CompanyInfLcDB.Read", 0);
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
        /// �w�肳�ꂽ�����̎��Џ��}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="companyInfWork">companyInfWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎��Џ��}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.02.08</br>
        public int ReadProc(ref CompanyInfWork companyInfWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = ReadProcProc(ref companyInfWork, readMode, ref sqlConnection);
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎��Џ��}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="companyInfWork">companyInfWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎��Џ��}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.02.08</br>
        private int ReadProcProc(ref CompanyInfWork companyInfWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Select�R�}���h�̐���
                // 2008.05.27 upd start ---------------------------------->>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYCODERF=@FINDCOMPANYCODE", sqlConnection))
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTOTALDAYRF" + Environment.NewLine;
                sqlTxt += "    ,FINANCIALYEARRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYBIGINMONTHRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYBIGINMONTH2RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYBIGINDATERF" + Environment.NewLine;
                sqlTxt += "    ,STARTYEARDIVRF" + Environment.NewLine;
                sqlTxt += "    ,STARTMONTHDIVRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                sqlTxt += "    ,SECMNGDIVRF" + Environment.NewLine;
                sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND COMPANYCODERF=@FINDCOMPANYCODERF" + Environment.NewLine;                
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))  
                // 2008.05.27 upd end ------------------------------------<<
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCompanyCode = sqlCommand.Parameters.Add("@FINDCOMPANYCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyInfWork.EnterpriseCode);
                    findParaCompanyCode.Value = SqlDataMediator.SqlSetInt32(companyInfWork.CompanyCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        companyInfWork = CopyToCompanyInfWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "CompanyInfLcDB.Read", 0);
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
        /// <br>Date       : 2008.02.08</br>
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
                CompanyInfSyncWork companyInfSyncWork = new CompanyInfSyncWork();

                for (int i = 0; i < paraSyncDataList.Count; i++)
                {
                    syncDataList = (ArrayList)paraSyncDataList[i];
                    if (syncDataList[0].GetType() == companyInfSyncWork.GetType())
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
                WriteErrorLog(ex, "CompanyInfLcDB.WriteSyncLocalData", 0);
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
        /// <br>Date       : 2008.02.08</br>
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
        /// <br>Date       : 2008.02.08</br>
        private int WriteSyncLocalDataProcProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList listdata = new ArrayList();
            string sqlTxt = string.Empty; // 2008.05.27 add
            try
            {
                if (paraSyncDataList != null)
                {
                    if (syncServiceWork.Syncmode == 1)
                    {
                        // 2008.05.27 upd start ---------------------------------->>
                        //sqlCommand = new SqlCommand("DELETE FROM COMPANYINFRF WHERE ENTERPRISECODERF=@DELENTERPRISECODE", sqlConnection, sqlTransaction);
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@DELENTERPRISECODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.27 upd end ------------------------------------<<
                        SqlParameter delEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                        delEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);
                        sqlCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < paraSyncDataList.Count; i++)
                    {
                        CompanyInfSyncWork companyInfSyncWork = paraSyncDataList[i] as CompanyInfSyncWork;
                        object obj;
                        IFileHeader flhd;
                        ClientFileHeader fileHeader;

                        switch (syncServiceWork.Syncmode)
                        {
                            //�������[�h�̃V���N����
                            case 0:
                                //Select�R�}���h�̐���
                                // 2008.05.27 upd start ---------------------------------->>
                                //sqlCommand = new SqlCommand("SELECT * FROM COMPANYINFRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYCODERF=@FINDCOMPANYCODE", sqlConnection, sqlTransaction);
                                sqlTxt = string.Empty;
                                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTOTALDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,FINANCIALYEARRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYBIGINMONTHRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYBIGINMONTH2RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYBIGINDATERF" + Environment.NewLine;
                                sqlTxt += "    ,STARTYEARDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,STARTMONTHDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                                sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                                sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                                sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                                sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                                sqlTxt += "    ,SECMNGDIVRF" + Environment.NewLine;
                                sqlTxt += " FROM COMPANYINFRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND COMPANYCODERF=@FINDCOMPANYCODERF" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.27 upd end ------------------------------------<<

                                //Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaCompanyCode = sqlCommand.Parameters.Add("@FINDCOMPANYCODE", SqlDbType.Int);

                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyInfSyncWork.EnterpriseCode);
                                findParaCompanyCode.Value = SqlDataMediator.SqlSetInt32(companyInfSyncWork.CompanyCode);

                                myReader = sqlCommand.ExecuteReader();
                                if (myReader.Read())
                                {
                                    //Update�R�}���h�̐���
                                    // 2008.05.27 upd start ---------------------------------->>
                                    //sqlCommand.CommandText = "UPDATE COMPANYINFRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , COMPANYCODERF=@COMPANYCODE , COMPANYTOTALDAYRF=@COMPANYTOTALDAY , FINANCIALYEARRF=@FINANCIALYEAR , COMPANYBIGINMONTHRF=@COMPANYBIGINMONTH , COMPANYBIGINMONTH2RF=@COMPANYBIGINMONTH2 , COMPANYBIGINDATERF=@COMPANYBIGINDATE , STARTYEARDIVRF=@STARTYEARDIV , STARTMONTHDIVRF=@STARTMONTHDIV , COMPANYNAME1RF=@COMPANYNAME1 , COMPANYNAME2RF=@COMPANYNAME2 , POSTNORF=@POSTNO , ADDRESS1RF=@ADDRESS1 , ADDRESS2RF=@ADDRESS2 , ADDRESS3RF=@ADDRESS3 , ADDRESS4RF=@ADDRESS4 , COMPANYTELNO1RF=@COMPANYTELNO1 , COMPANYTELNO2RF=@COMPANYTELNO2 , COMPANYTELNO3RF=@COMPANYTELNO3 , COMPANYTELTITLE1RF=@COMPANYTELTITLE1 , COMPANYTELTITLE2RF=@COMPANYTELTITLE2 , COMPANYTELTITLE3RF=@COMPANYTELTITLE3 , SECMNGDIVRF=@SECMNGDIV WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYCODERF=@FINDCOMPANYCODE";
                                    sqlTxt = string.Empty;
                                    sqlTxt += "UPDATE COMPANYINFRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlTxt += " , COMPANYCODERF=@COMPANYCODE" + Environment.NewLine;
                                    sqlTxt += " , COMPANYTOTALDAYRF=@COMPANYTOTALDAY" + Environment.NewLine;
                                    sqlTxt += " , FINANCIALYEARRF=@FINANCIALYEAR" + Environment.NewLine;
                                    sqlTxt += " , COMPANYBIGINMONTHRF=@COMPANYBIGINMONTH" + Environment.NewLine;
                                    sqlTxt += " , COMPANYBIGINMONTH2RF=@COMPANYBIGINMONTH2" + Environment.NewLine;
                                    sqlTxt += " , COMPANYBIGINDATERF=@COMPANYBIGINDATE" + Environment.NewLine;
                                    sqlTxt += " , STARTYEARDIVRF=@STARTYEARDIV" + Environment.NewLine;
                                    sqlTxt += " , STARTMONTHDIVRF=@STARTMONTHDIV" + Environment.NewLine;
                                    sqlTxt += " , COMPANYNAME1RF=@COMPANYNAME1" + Environment.NewLine;
                                    sqlTxt += " , COMPANYNAME2RF=@COMPANYNAME2" + Environment.NewLine;
                                    sqlTxt += " , POSTNORF=@POSTNO" + Environment.NewLine;
                                    sqlTxt += " , ADDRESS1RF=@ADDRESS1" + Environment.NewLine;
                                    sqlTxt += " , ADDRESS2RF=@ADDRESS2" + Environment.NewLine;
                                    sqlTxt += " , ADDRESS3RF=@ADDRESS3" + Environment.NewLine;
                                    sqlTxt += " , ADDRESS4RF=@ADDRESS4" + Environment.NewLine;
                                    sqlTxt += " , COMPANYTELNO1RF=@COMPANYTELNO1" + Environment.NewLine;
                                    sqlTxt += " , COMPANYTELNO2RF=@COMPANYTELNO2" + Environment.NewLine;
                                    sqlTxt += " , COMPANYTELNO3RF=@COMPANYTELNO3" + Environment.NewLine;
                                    sqlTxt += " , COMPANYTELTITLE1RF=@COMPANYTELTITLE1" + Environment.NewLine;
                                    sqlTxt += " , COMPANYTELTITLE2RF=@COMPANYTELTITLE2" + Environment.NewLine;
                                    sqlTxt += " , COMPANYTELTITLE3RF=@COMPANYTELTITLE3" + Environment.NewLine;
                                    sqlTxt += " , SECMNGDIVRF=@SECMNGDIV" + Environment.NewLine;
                                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += "    AND COMPANYCODERF=@FINDCOMPANYCODE" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.27 upd end ------------------------------------<<
                                    //KEY�R�}���h���Đݒ�
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyInfSyncWork.EnterpriseCode);
                                    findParaCompanyCode.Value = SqlDataMediator.SqlSetInt32(companyInfSyncWork.CompanyCode);
                                    //�X�V�w�b�_����ݒ�
                                    //FileHeaderGuid��Select���ʂ���擾
                                    companyInfSyncWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                                    obj = (object)this;
                                    flhd = (IFileHeader)companyInfSyncWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);

                                }
                                else
                                {
                                    //Insert�R�}���h�̐���
                                    // 2008.05.27 upd start ---------------------------------->>
                                    //sqlCommand.CommandText = "INSERT INTO COMPANYINFRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMPANYCODERF, COMPANYTOTALDAYRF, FINANCIALYEARRF, COMPANYBIGINMONTHRF, COMPANYBIGINMONTH2RF, COMPANYBIGINDATERF, STARTYEARDIVRF, STARTMONTHDIVRF, COMPANYNAME1RF, COMPANYNAME2RF, POSTNORF, ADDRESS1RF, ADDRESS2RF, ADDRESS3RF, ADDRESS4RF, COMPANYTELNO1RF, COMPANYTELNO2RF, COMPANYTELNO3RF, COMPANYTELTITLE1RF, COMPANYTELTITLE2RF, COMPANYTELTITLE3RF, SECMNGDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @COMPANYCODE, @COMPANYTOTALDAY, @FINANCIALYEAR, @COMPANYBIGINMONTH, @COMPANYBIGINMONTH2, @COMPANYBIGINDATE, @STARTYEARDIV, @STARTMONTHDIV, @COMPANYNAME1, @COMPANYNAME2, @POSTNO, @ADDRESS1, @ADDRESS2, @ADDRESS3, @ADDRESS4, @COMPANYTELNO1, @COMPANYTELNO2, @COMPANYTELNO3, @COMPANYTELTITLE1, @COMPANYTELTITLE2, @COMPANYTELTITLE3, @SECMNGDIV)";
                                    sqlTxt = string.Empty;
                                    sqlTxt += "INSERT INTO COMPANYINFRF" + Environment.NewLine;
                                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYTOTALDAYRF" + Environment.NewLine;
                                    sqlTxt += "    ,FINANCIALYEARRF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYBIGINMONTHRF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYBIGINMONTH2RF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYBIGINDATERF" + Environment.NewLine;
                                    sqlTxt += "    ,STARTYEARDIVRF" + Environment.NewLine;
                                    sqlTxt += "    ,STARTMONTHDIVRF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                                    sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                                    sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                                    sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                                    sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                                    sqlTxt += "    ,SECMNGDIVRF" + Environment.NewLine;
                                    sqlTxt += " )" + Environment.NewLine;
                                    sqlTxt += " VALUES" + Environment.NewLine;
                                    sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                                    sqlTxt += "    ,@UPDATEDATETIME" + Environment.NewLine;
                                    sqlTxt += "    ,@ENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += "    ,@FILEHEADERGUID" + Environment.NewLine;
                                    sqlTxt += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlTxt += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlTxt += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlTxt += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYCODE" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYTOTALDAY" + Environment.NewLine;
                                    sqlTxt += "    ,@FINANCIALYEAR" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYBIGINMONTH" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYBIGINMONTH2" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYBIGINDATE" + Environment.NewLine;
                                    sqlTxt += "    ,@STARTYEARDIV" + Environment.NewLine;
                                    sqlTxt += "    ,@STARTMONTHDIV" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYNAME1" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYNAME2" + Environment.NewLine;
                                    sqlTxt += "    ,@POSTNO" + Environment.NewLine;
                                    sqlTxt += "    ,@ADDRESS1" + Environment.NewLine;
                                    sqlTxt += "    ,@ADDRESS3" + Environment.NewLine;
                                    sqlTxt += "    ,@ADDRESS4" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYTELNO1" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYTELNO2" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYTELNO3" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYTELTITLE1" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYTELTITLE2" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYTELTITLE3" + Environment.NewLine;
                                    sqlTxt += "    ,@SECMNGDIV" + Environment.NewLine;
                                    sqlTxt += " )" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.27 upd end ------------------------------------<<
                                    //�o�^�w�b�_����ݒ�
                                    obj = (object)this;
                                    flhd = (IFileHeader)companyInfSyncWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetInsertHeader(ref flhd, obj);
                                }
                                if (myReader.IsClosed == false) myReader.Close();
                                break;

                            //�S���o�^�̃V���N����
                            case 1:
                                //Insert�R�}���h�̐���
                                // 2008.05.27 upd start ---------------------------------->>
                                //sqlCommand = new SqlCommand("INSERT INTO COMPANYINFRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMPANYCODERF, COMPANYTOTALDAYRF, FINANCIALYEARRF, COMPANYBIGINMONTHRF, COMPANYBIGINMONTH2RF, COMPANYBIGINDATERF, STARTYEARDIVRF, STARTMONTHDIVRF, COMPANYNAME1RF, COMPANYNAME2RF, POSTNORF, ADDRESS1RF, ADDRESS2RF, ADDRESS3RF, ADDRESS4RF, COMPANYTELNO1RF, COMPANYTELNO2RF, COMPANYTELNO3RF, COMPANYTELTITLE1RF, COMPANYTELTITLE2RF, COMPANYTELTITLE3RF, SECMNGDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @COMPANYCODE, @COMPANYTOTALDAY, @FINANCIALYEAR, @COMPANYBIGINMONTH, @COMPANYBIGINMONTH2, @COMPANYBIGINDATE, @STARTYEARDIV, @STARTMONTHDIV, @COMPANYNAME1, @COMPANYNAME2, @POSTNO, @ADDRESS1, @ADDRESS2, @ADDRESS3, @ADDRESS4, @COMPANYTELNO1, @COMPANYTELNO2, @COMPANYTELNO3, @COMPANYTELTITLE1, @COMPANYTELTITLE2, @COMPANYTELTITLE3, @SECMNGDIV)", sqlConnection, sqlTransaction);
                                sqlTxt = string.Empty;
                                sqlTxt += "INSERT INTO COMPANYINFRF" + Environment.NewLine;
                                sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYCODERF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTOTALDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,FINANCIALYEARRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYBIGINMONTHRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYBIGINMONTH2RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYBIGINDATERF" + Environment.NewLine;
                                sqlTxt += "    ,STARTYEARDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,STARTMONTHDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                                sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                                sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                                sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                                sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                                sqlTxt += "    ,SECMNGDIVRF" + Environment.NewLine;
                                sqlTxt += " )" + Environment.NewLine;
                                sqlTxt += " VALUES" + Environment.NewLine;
                                sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                                sqlTxt += "    ,@UPDATEDATETIME" + Environment.NewLine;
                                sqlTxt += "    ,@ENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    ,@FILEHEADERGUID" + Environment.NewLine;
                                sqlTxt += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlTxt += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                                sqlTxt += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                                sqlTxt += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYCODE" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYTOTALDAY" + Environment.NewLine;
                                sqlTxt += "    ,@FINANCIALYEAR" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYBIGINMONTH" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYBIGINMONTH2" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYBIGINDATE" + Environment.NewLine;
                                sqlTxt += "    ,@STARTYEARDIV" + Environment.NewLine;
                                sqlTxt += "    ,@STARTMONTHDIV" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYNAME1" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYNAME2" + Environment.NewLine;
                                sqlTxt += "    ,@POSTNO" + Environment.NewLine;
                                sqlTxt += "    ,@ADDRESS1" + Environment.NewLine;
                                sqlTxt += "    ,@ADDRESS3" + Environment.NewLine;
                                sqlTxt += "    ,@ADDRESS4" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYTELNO1" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYTELNO2" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYTELNO3" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYTELTITLE1" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYTELTITLE2" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYTELTITLE3" + Environment.NewLine;
                                sqlTxt += "    ,@SECMNGDIV" + Environment.NewLine;
                                sqlTxt += " )" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.27 upd end ------------------------------------<<
                                //�o�^�w�b�_����ݒ�
                                obj = (object)this;
                                flhd = (IFileHeader)companyInfSyncWork;
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
                        SqlParameter paraCompanyCode = sqlCommand.Parameters.Add("@COMPANYCODE", SqlDbType.Int);
                        SqlParameter paraCompanyTotalDay = sqlCommand.Parameters.Add("@COMPANYTOTALDAY", SqlDbType.Int);
                        SqlParameter paraFinancialYear = sqlCommand.Parameters.Add("@FINANCIALYEAR", SqlDbType.Int);
                        SqlParameter paraCompanyBiginMonth = sqlCommand.Parameters.Add("@COMPANYBIGINMONTH", SqlDbType.Int);
                        SqlParameter paraCompanyBiginMonth2 = sqlCommand.Parameters.Add("@COMPANYBIGINMONTH2", SqlDbType.Int);
                        SqlParameter paraCompanyBiginDate = sqlCommand.Parameters.Add("@COMPANYBIGINDATE", SqlDbType.Int);
                        SqlParameter paraStartYearDiv = sqlCommand.Parameters.Add("@STARTYEARDIV", SqlDbType.Int);
                        SqlParameter paraStartMonthDiv = sqlCommand.Parameters.Add("@STARTMONTHDIV", SqlDbType.Int);
                        SqlParameter paraCompanyName1 = sqlCommand.Parameters.Add("@COMPANYNAME1", SqlDbType.NVarChar);
                        SqlParameter paraCompanyName2 = sqlCommand.Parameters.Add("@COMPANYNAME2", SqlDbType.NVarChar);
                        SqlParameter paraPostNo = sqlCommand.Parameters.Add("@POSTNO", SqlDbType.NVarChar);
                        SqlParameter paraAddress1 = sqlCommand.Parameters.Add("@ADDRESS1", SqlDbType.NVarChar);
                        //SqlParameter paraAddress2 = sqlCommand.Parameters.Add("@ADDRESS2", SqlDbType.Int); // 2008.05.27 del
                        SqlParameter paraAddress3 = sqlCommand.Parameters.Add("@ADDRESS3", SqlDbType.NVarChar);
                        SqlParameter paraAddress4 = sqlCommand.Parameters.Add("@ADDRESS4", SqlDbType.NVarChar);
                        SqlParameter paraCompanyTelNo1 = sqlCommand.Parameters.Add("@COMPANYTELNO1", SqlDbType.NVarChar);
                        SqlParameter paraCompanyTelNo2 = sqlCommand.Parameters.Add("@COMPANYTELNO2", SqlDbType.NVarChar);
                        SqlParameter paraCompanyTelNo3 = sqlCommand.Parameters.Add("@COMPANYTELNO3", SqlDbType.NVarChar);
                        SqlParameter paraCompanyTelTitle1 = sqlCommand.Parameters.Add("@COMPANYTELTITLE1", SqlDbType.NVarChar);
                        SqlParameter paraCompanyTelTitle2 = sqlCommand.Parameters.Add("@COMPANYTELTITLE2", SqlDbType.NVarChar);
                        SqlParameter paraCompanyTelTitle3 = sqlCommand.Parameters.Add("@COMPANYTELTITLE3", SqlDbType.NVarChar);
                        SqlParameter paraSecMngDiv = sqlCommand.Parameters.Add("@SECMNGDIV", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(companyInfSyncWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(companyInfSyncWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyInfSyncWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(companyInfSyncWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(companyInfSyncWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(companyInfSyncWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(companyInfSyncWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(companyInfSyncWork.LogicalDeleteCode);
                        paraCompanyCode.Value = SqlDataMediator.SqlSetInt32(companyInfSyncWork.CompanyCode);
                        paraCompanyTotalDay.Value = SqlDataMediator.SqlSetInt32(companyInfSyncWork.CompanyTotalDay);
                        paraFinancialYear.Value = SqlDataMediator.SqlSetInt32(companyInfSyncWork.FinancialYear);
                        paraCompanyBiginMonth.Value = SqlDataMediator.SqlSetInt32(companyInfSyncWork.CompanyBiginMonth);
                        paraCompanyBiginMonth2.Value = SqlDataMediator.SqlSetInt32(companyInfSyncWork.CompanyBiginMonth2);
                        paraCompanyBiginDate.Value = SqlDataMediator.SqlSetInt32(companyInfSyncWork.CompanyBiginDate);
                        paraStartYearDiv.Value = SqlDataMediator.SqlSetInt32(companyInfSyncWork.StartYearDiv);
                        paraStartMonthDiv.Value = SqlDataMediator.SqlSetInt32(companyInfSyncWork.StartMonthDiv);
                        paraCompanyName1.Value = SqlDataMediator.SqlSetString(companyInfSyncWork.CompanyName1);
                        paraCompanyName2.Value = SqlDataMediator.SqlSetString(companyInfSyncWork.CompanyName2);
                        paraPostNo.Value = SqlDataMediator.SqlSetString(companyInfSyncWork.PostNo);
                        paraAddress1.Value = SqlDataMediator.SqlSetString(companyInfSyncWork.Address1);
                        //paraAddress2.Value = SqlDataMediator.SqlSetInt32(companyInfSyncWork.Address2); // 2008.05.27 del
                        paraAddress3.Value = SqlDataMediator.SqlSetString(companyInfSyncWork.Address3);
                        paraAddress4.Value = SqlDataMediator.SqlSetString(companyInfSyncWork.Address4);
                        paraCompanyTelNo1.Value = SqlDataMediator.SqlSetString(companyInfSyncWork.CompanyTelNo1);
                        paraCompanyTelNo2.Value = SqlDataMediator.SqlSetString(companyInfSyncWork.CompanyTelNo2);
                        paraCompanyTelNo3.Value = SqlDataMediator.SqlSetString(companyInfSyncWork.CompanyTelNo3);
                        paraCompanyTelTitle1.Value = SqlDataMediator.SqlSetString(companyInfSyncWork.CompanyTelTitle1);
                        paraCompanyTelTitle2.Value = SqlDataMediator.SqlSetString(companyInfSyncWork.CompanyTelTitle2);
                        paraCompanyTelTitle3.Value = SqlDataMediator.SqlSetString(companyInfSyncWork.CompanyTelTitle3);
                        paraSecMngDiv.Value = SqlDataMediator.SqlSetInt32(companyInfSyncWork.SecMngDiv);
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
                status = WriteSQLErrorLog(ex, "CompanyInfLcDB.WriteSyncLocalDataProc", 0);
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
        /// <param name="companyInfWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.02.08</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CompanyInfWork companyInfWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyInfWork.EnterpriseCode);

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

            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CompanyInfWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CompanyInfWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.02.08</br>
        /// </remarks>
        private CompanyInfWork CopyToCompanyInfWorkFromReader(ref SqlDataReader myReader)
        {
            CompanyInfWork wkCompanyInfWork = new CompanyInfWork();

            #region �N���X�֊i�[
            wkCompanyInfWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkCompanyInfWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkCompanyInfWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkCompanyInfWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkCompanyInfWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkCompanyInfWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkCompanyInfWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkCompanyInfWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkCompanyInfWork.CompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYCODERF"));
            wkCompanyInfWork.CompanyTotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYTOTALDAYRF"));
            wkCompanyInfWork.FinancialYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FINANCIALYEARRF"));
            wkCompanyInfWork.CompanyBiginMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYBIGINMONTHRF"));
            wkCompanyInfWork.CompanyBiginMonth2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYBIGINMONTH2RF"));
            wkCompanyInfWork.CompanyBiginDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYBIGINDATERF"));
            wkCompanyInfWork.StartYearDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STARTYEARDIVRF"));
            wkCompanyInfWork.StartMonthDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STARTMONTHDIVRF"));
            wkCompanyInfWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME1RF"));
            wkCompanyInfWork.CompanyName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME2RF"));
            wkCompanyInfWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
            wkCompanyInfWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
            //wkCompanyInfWork.Address2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESS2RF"));  // 2008.05.27 del
            wkCompanyInfWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
            wkCompanyInfWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
            wkCompanyInfWork.CompanyTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO1RF"));
            wkCompanyInfWork.CompanyTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO2RF"));
            wkCompanyInfWork.CompanyTelNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO3RF"));
            wkCompanyInfWork.CompanyTelTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE1RF"));
            wkCompanyInfWork.CompanyTelTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE2RF"));
            wkCompanyInfWork.CompanyTelTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE3RF"));
            wkCompanyInfWork.SecMngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECMNGDIVRF"));
            #endregion

            return wkCompanyInfWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.02.08</br>
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
