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
    /// �󔭒��S�̐ݒ�}�X�^LC���[�J��DB�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �󔭒��S�̐ݒ�}�X�^LC�̃��[�J��DB���f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2008.01.24</br>
    /// <br></br>
    /// <br>Update Note: 2008.06.09 �D�c �E�l</br>
    /// <br>           : �o�l.�m�r�p�ɕύX</br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class AcptAnOdrTtlStLcDB : IWriteSyncLocalData
    {
        /// <summary>
        /// �󔭒��S�̐ݒ�}�X�^LC���[�J��DB�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.24</br>
        /// </remarks>
        public AcptAnOdrTtlStLcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̎󔭒��S�̐ݒ�}�X�^LC���LIST��߂��܂�
        /// </summary>
        /// <param name="acptAnOdrTtlStWorkList">��������</param>
        /// <param name="paraAcptAnOdrTtlStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎󔭒��S�̐ݒ�}�X�^LC���LIST��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.24</br>
        public int Search(out List<AcptAnOdrTtlStWork> acptAnOdrTtlStWorkList, SearchAcptAnOdrTtlStParaWork paraAcptAnOdrTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            acptAnOdrTtlStWorkList = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchAcptAnOdrTtlStProcProc(out acptAnOdrTtlStWorkList, paraAcptAnOdrTtlStWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AcptAnOdrTtlStLcDB.Search", 0);
                acptAnOdrTtlStWorkList = new List<AcptAnOdrTtlStWork>();
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
        /// �w�肳�ꂽ�����̎󔭒��S�̐ݒ�}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="acptAnOdrTtlStWorkList">��������</param>
        /// <param name="acptAnOdrTtlStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎󔭒��S�̐ݒ�}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.24</br>
        public int SearchAcptAnOdrTtlStProc(out List<AcptAnOdrTtlStWork> acptAnOdrTtlStWorkList, SearchAcptAnOdrTtlStParaWork acptAnOdrTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            status = SearchAcptAnOdrTtlStProcProc(out acptAnOdrTtlStWorkList, acptAnOdrTtlStWork, readMode, logicalMode, ref sqlConnection);

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎󔭒��S�̐ݒ�}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="acptAnOdrTtlStWorkList">��������</param>
        /// <param name="acptAnOdrTtlStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎󔭒��S�̐ݒ�}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.24</br>
        private int SearchAcptAnOdrTtlStProcProc(out List<AcptAnOdrTtlStWork> acptAnOdrTtlStWorkList, SearchAcptAnOdrTtlStParaWork acptAnOdrTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<AcptAnOdrTtlStWork> listdata = new List<AcptAnOdrTtlStWork>();
            try
            {
                // 2008.06.09 upd start -------------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM ACPTANODRTTLSTRF  ", sqlConnection);
                string sqlText = string.Empty;
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,ESTMCOUNTREFLECTDIVRF" + Environment.NewLine;
                sqlText += "    ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += "    ,FAXORDERDIVRF" + Environment.NewLine;
                sqlText += " FROM ACPTANODRTTLSTRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                // 2008.06.09 upd end ----------------------------------<<

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, acptAnOdrTtlStWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listdata.Add(CopyToAcptAnOdrTtlStWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "AcptAnOdrTtlStLcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            acptAnOdrTtlStWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̎󔭒��S�̐ݒ�}�X�^LC��߂��܂�
        /// </summary>
        /// <param name="acptAnOdrTtlStWork">acptAnOdrTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎󔭒��S�̐ݒ�}�X�^LC��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.24</br>
        public int Read(ref AcptAnOdrTtlStWork acptAnOdrTtlStWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcProc(ref acptAnOdrTtlStWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AcptAnOdrTtlStLcDB.Read", 0);
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
        /// �w�肳�ꂽ�����̎󔭒��S�̐ݒ�}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="acptAnOdrTtlStWork">acptAnOdrTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎󔭒��S�̐ݒ�}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.24</br>
        public int ReadProc(ref AcptAnOdrTtlStWork acptAnOdrTtlStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            status = ReadProcProc(ref acptAnOdrTtlStWork, readMode, ref sqlConnection);

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎󔭒��S�̐ݒ�}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="acptAnOdrTtlStWork">acptAnOdrTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎󔭒��S�̐ݒ�}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.24</br>
        private int ReadProcProc(ref AcptAnOdrTtlStWork acptAnOdrTtlStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Select�R�}���h�̐���
                // 2008.06.09 upd start --------------------------------------->>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ACPTANODRTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection))
                string sqlText = string.Empty;
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,ESTMCOUNTREFLECTDIVRF" + Environment.NewLine;
                sqlText += "    ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += "    ,FAXORDERDIVRF" + Environment.NewLine;
                sqlText += " FROM ACPTANODRTTLSTRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))    
                // 2008.06.09 upd end -----------------------------------------<<
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // 2008.06.09 add

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.SectionCode);              // 2008.06.09 add

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        acptAnOdrTtlStWork = CopyToAcptAnOdrTtlStWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "AcptAnOdrTtlStLcDB.Read", 0);
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
        /// <br>Date       : 2008.01.24</br>
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
                AcptAnOdrTtlStWork acptAnOdrTtlStWork = new AcptAnOdrTtlStWork();

                for (int i = 0; i < paraSyncDataList.Count; i++)
                {
                    syncDataList = (ArrayList)paraSyncDataList[i];
                    if (syncDataList[0].GetType() == acptAnOdrTtlStWork.GetType())
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
                WriteErrorLog(ex, "AcptAnOdrTtlStLcDB.WriteSyncLocalData", 0);
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
        /// <br>Date       : 2008.01.24</br>
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
        /// <br>Date       : 2008.01.24</br>
        private int WriteSyncLocalDataProcProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList listdata = new ArrayList();
            string sqlText = string.Empty; // 2008.06.09 add
            try
            {
                if (paraSyncDataList != null)
                {
                    if (syncServiceWork.Syncmode == 1)
                    {
                        // 2008.06.09 upd start ---------------------------------------->>
                        //sqlCommand = new SqlCommand("DELETE FROM ACPTANODRTTLSTRF WHERE ENTERPRISECODERF=@DELENTERPRISECODE", sqlConnection, sqlTransaction);
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += " FROM ACPTANODRTTLSTRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@DELENTERPRISECODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                        // 2008.06.09 upd end ------------------------------------------<<
                        SqlParameter delEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                        delEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

                        sqlCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < paraSyncDataList.Count; i++)
                    {
                        AcptAnOdrTtlStWork acptAnOdrTtlStWork = paraSyncDataList[i] as AcptAnOdrTtlStWork;
                        object obj;
                        IFileHeader flhd;
                        ClientFileHeader fileHeader;

                        switch (syncServiceWork.Syncmode)
                        {
                            //�������[�h�̃V���N����
                            case 0:
                                //Select�R�}���h�̐���
                                // 2008.06.09 upd start ---------------------------------------->>
                                //sqlCommand = new SqlCommand("SELECT * FROM ACPTANODRTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection, sqlTransaction);
                                sqlText = string.Empty;
                                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlText += "    ,ESTMCOUNTREFLECTDIVRF" + Environment.NewLine;
                                sqlText += "    ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                                sqlText += "    ,FAXORDERDIVRF" + Environment.NewLine;
                                sqlText += " FROM ACPTANODRTTLSTRF" + Environment.NewLine;
                                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                                // 2008.06.09 upd end ------------------------------------------<<

                                //Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // 2008.06.09 add

                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.EnterpriseCode);
                                findParaSectionCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.SectionCode); // 2008.06.09 add

                                myReader = sqlCommand.ExecuteReader();
                                if (myReader.Read())
                                {
                                    //Update�R�}���h�̐���
                                    // 2008.06.09 upd start ---------------------------------------->>
                                    //sqlCommand.CommandText = "UPDATE ACPTANODRTTLSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , ORDERNUMBERCOMPORF=@ORDERNUMBERCOMPO , ESTMCOUNTREFLECTDIVRF=@ESTMCOUNTREFLECTDIV , ACPODRRSLIPPRTDIVRF=@ACPODRRSLIPPRTDIV , FAXORDERDIVRF=@FAXORDERDIV , DOTKULORDERDIVRF=@DOTKULORDERDIV ";
                                    sqlText = string.Empty;
                                    sqlText += "UPDATE ACPTANODRTTLSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                    sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                    sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                    sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                                    sqlText += " , ESTMCOUNTREFLECTDIVRF=@ESTMCOUNTREFLECTDIV" + Environment.NewLine;
                                    sqlText += " , ACPODRRSLIPPRTDIVRF=@ACPODRRSLIPPRTDIV" + Environment.NewLine;
                                    sqlText += " , FAXORDERDIVRF=@FAXORDERDIV" + Environment.NewLine;
                                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlText;
                                    // 2008.06.09 upd end ------------------------------------------<<
                                    
                                    //KEY�R�}���h���Đݒ�
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.EnterpriseCode);
                                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.SectionCode); // 2008.06.09 add

                                    //�X�V�w�b�_����ݒ�
                                    //FileHeaderGuid��Select���ʂ���擾
                                    acptAnOdrTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                                    obj = (object)this;
                                    flhd = (IFileHeader)acptAnOdrTtlStWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);

                                }
                                else
                                {
                                    //Insert�R�}���h�̐���
                                    // 2008.06.09 upd start ---------------------------------------->>
                                    //sqlCommand.CommandText = "INSERT INTO ACPTANODRTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ORDERNUMBERCOMPORF,  ESTMCOUNTREFLECTDIVRF, ACPODRRSLIPPRTDIVRF,  FAXORDERDIVRF, DOTKULORDERDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ORDERNUMBERCOMPO, @ESTMCOUNTREFLECTDIV, @ACPODRRSLIPPRTDIV, @FAXORDERDIV, @DOTKULORDERDIV)";
                                    sqlText = string.Empty;
                                    sqlText += "INSERT INTO ACPTANODRTTLSTRF" + Environment.NewLine;
                                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                                    sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                    sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                    sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                    sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                    sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                    sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                    sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                    sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                                    sqlText += "    ,ESTMCOUNTREFLECTDIVRF" + Environment.NewLine;
                                    sqlText += "    ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                                    sqlText += "    ,FAXORDERDIVRF" + Environment.NewLine;
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
                                    sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                                    sqlText += "    ,@ESTMCOUNTREFLECTDIV" + Environment.NewLine;
                                    sqlText += "    ,@ACPODRRSLIPPRTDIV" + Environment.NewLine;
                                    sqlText += "    ,@FAXORDERDIV" + Environment.NewLine;
                                    sqlText += " )" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlText;
                                    // 2008.06.09 upd end ------------------------------------------<<
                                    //�o�^�w�b�_����ݒ�
                                    obj = (object)this;
                                    flhd = (IFileHeader)acptAnOdrTtlStWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetInsertHeader(ref flhd, obj);
                                }
                                if (myReader.IsClosed == false) myReader.Close();
                                break;

                            //�S���o�^�̃V���N����
                            case 1:
                                //Insert�R�}���h�̐���
                                // 2008.06.09 upd start ---------------------------------------->>
                                //sqlCommand = new SqlCommand("INSERT INTO ACPTANODRTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ORDERNUMBERCOMPORF,  ESTMCOUNTREFLECTDIVRF, ACPODRRSLIPPRTDIVRF,  FAXORDERDIVRF, DOTKULORDERDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ORDERNUMBERCOMPO, @ESTMCOUNTREFLECTDIV, @ACPODRRSLIPPRTDIV, @FAXORDERDIV, @DOTKULORDERDIV)", sqlConnection, sqlTransaction);
                                sqlText = string.Empty;
                                sqlText += "INSERT INTO ACPTANODRTTLSTRF" + Environment.NewLine;
                                sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlText += "    ,ESTMCOUNTREFLECTDIVRF" + Environment.NewLine;
                                sqlText += "    ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                                sqlText += "    ,FAXORDERDIVRF" + Environment.NewLine;
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
                                sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                                sqlText += "    ,@ESTMCOUNTREFLECTDIV" + Environment.NewLine;
                                sqlText += "    ,@ACPODRRSLIPPRTDIV" + Environment.NewLine;
                                sqlText += "    ,@FAXORDERDIV" + Environment.NewLine;
                                sqlText += " )" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                                // 2008.06.09 upd end ------------------------------------------<<
                                //�o�^�w�b�_����ݒ�
                                obj = (object)this;
                                flhd = (IFileHeader)acptAnOdrTtlStWork;
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
                        //SqlParameter paraOrderNumberCompo = sqlCommand.Parameters.Add("@ORDERNUMBERCOMPO", SqlDbType.Int); // 2008.06.09 del
                        SqlParameter paraEstmCountReflectDiv = sqlCommand.Parameters.Add("@ESTMCOUNTREFLECTDIV", SqlDbType.Int);
                        SqlParameter paraAcpOdrrSlipPrtDiv = sqlCommand.Parameters.Add("@ACPODRRSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraFaxOrderDiv = sqlCommand.Parameters.Add("@FAXORDERDIV", SqlDbType.Int);
                        //SqlParameter paraDotKulOrderDiv = sqlCommand.Parameters.Add("@DOTKULORDERDIV", SqlDbType.Int); // 2008.06.09 del
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar); // 2008.06.09 add
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acptAnOdrTtlStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acptAnOdrTtlStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(acptAnOdrTtlStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(acptAnOdrTtlStWork.LogicalDeleteCode);
                        //paraOrderNumberCompo.Value = SqlDataMediator.SqlSetInt32(acptAnOdrTtlStWork.OrderNumberCompo);
                        paraEstmCountReflectDiv.Value = SqlDataMediator.SqlSetInt32(acptAnOdrTtlStWork.EstmCountReflectDiv);
                        paraAcpOdrrSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(acptAnOdrTtlStWork.AcpOdrrSlipPrtDiv);
                        paraFaxOrderDiv.Value = SqlDataMediator.SqlSetInt32(acptAnOdrTtlStWork.FaxOrderDiv);
                        //paraDotKulOrderDiv.Value = SqlDataMediator.SqlSetInt32(acptAnOdrTtlStWork.DotKulOrderDiv);// 2008.06.09 del
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.SectionCode); // 2008.06.09 add
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
                status = WriteSQLErrorLog(ex, "AcptAnOdrTtlStLcDB.WriteSyncLocalDataProc", 0);
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
        /// <param name="acptAnOdrTtlStWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.24</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SearchAcptAnOdrTtlStParaWork acptAnOdrTtlStWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.EnterpriseCode);

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
            // 2008.06.09 del start ----------------------------->>
            //���_�R�[�h
            if (acptAnOdrTtlStWork.SectionCode != "")
            {
                retstring += "AND SECTIONCODERF=@FINDSECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.SectionCode);
            }
            // 2008.06.09 del end ------------------------------<<

            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� AcptAnOdrTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>AcptAnOdrTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.24</br>
        /// </remarks>
        private AcptAnOdrTtlStWork CopyToAcptAnOdrTtlStWorkFromReader(ref SqlDataReader myReader)
        {
            AcptAnOdrTtlStWork wkAcptAnOdrTtlStWork = new AcptAnOdrTtlStWork();

            #region �N���X�֊i�[
            wkAcptAnOdrTtlStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkAcptAnOdrTtlStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkAcptAnOdrTtlStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkAcptAnOdrTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkAcptAnOdrTtlStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkAcptAnOdrTtlStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkAcptAnOdrTtlStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkAcptAnOdrTtlStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            //wkAcptAnOdrTtlStWork.OrderNumberCompo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERNUMBERCOMPORF")); // 2008.06.09 del
            wkAcptAnOdrTtlStWork.EstmCountReflectDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTMCOUNTREFLECTDIVRF"));
            wkAcptAnOdrTtlStWork.AcpOdrrSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRRSLIPPRTDIVRF"));
            wkAcptAnOdrTtlStWork.FaxOrderDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FAXORDERDIVRF"));
            //wkAcptAnOdrTtlStWork.DotKulOrderDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOTKULORDERDIVRF")); // 2008.06.09 del
            wkAcptAnOdrTtlStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); // 2008.06.09 add

            #endregion

            return wkAcptAnOdrTtlStWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.24</br>
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
