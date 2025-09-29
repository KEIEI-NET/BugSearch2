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
    /// �ŗ��ݒ�}�X�^LC���[�J��DB�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ŗ��ݒ�}�X�^LC�̃��[�J��DB���f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���R�@����</br>
    /// <br>Date       : 2007.05.18</br>
    /// <br></br>
    /// <br>Update Note: 2008.01.29 980081 �R�c ���F</br>
    /// <br>           : ���ʊ�Ή�</br>
    /// <br></br>
    /// <br>Update Note: PM.NS�p�ɕύX</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.05.27</br>
    /// </remarks>
    public class TaxRateSetLcDB : IWriteSyncLocalData
    {
        /// <summary>
        /// �ŗ��ݒ�}�X�^LC���[�J��DB�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���R�@����</br>
        /// <br>Date       : 2007.05.18</br>
        /// </remarks>
        public TaxRateSetLcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̐ŗ��ݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="taxRateSetWorkList">��������</param>
        /// <param name="paraTaxRateSetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̐ŗ��ݒ�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : ���R�@����</br>
        /// <br>Date       : 2007.05.18</br>
        public int Search(out List<TaxRateSetWork> taxRateSetWorkList, TaxRateSetWork paraTaxRateSetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            taxRateSetWorkList = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchTaxRateSetProcProc(out taxRateSetWorkList, paraTaxRateSetWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "TaxRateSetLcDB.Search",0);
                taxRateSetWorkList = new List<TaxRateSetWork>();
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
        /// �w�肳�ꂽ�����̐ŗ��ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="taxRateSetWorkList">��������</param>
        /// <param name="taxRateSetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̐ŗ��ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���R�@����</br>
        /// <br>Date       : 2007.05.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        public int SearchTaxRateSetProc(out List<TaxRateSetWork> taxRateSetWorkList, TaxRateSetWork taxRateSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            status = SearchTaxRateSetProcProc(out taxRateSetWorkList, taxRateSetWork, readMode, logicalMode, ref sqlConnection);
            return status;

        }


        /// <summary>
        /// �w�肳�ꂽ�����̐ŗ��ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="taxRateSetWorkList">��������</param>
        /// <param name="taxRateSetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̐ŗ��ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���R�@����</br>
        /// <br>Date       : 2007.05.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        private int SearchTaxRateSetProcProc(out List<TaxRateSetWork> taxRateSetWorkList, TaxRateSetWork taxRateSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<TaxRateSetWork> listdata = new List<TaxRateSetWork>();
            try
            {
                // �� 2008.01.29 980081 c
                //sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, TAXRATECODERF, TAXRATEPROPERNOUNNMRF, TAXRATENAMERF, FRACTIONPROCCDRF, TAXRATESTARTDATERF, TAXRATEENDDATERF, TAXRATERF, TAXRATESTARTDATE2RF, TAXRATEENDDATE2RF, TAXRATE2RF, TAXRATESTARTDATE3RF, TAXRATEENDDATE3RF, TAXRATE3RF FROM TAXRATESETRF", sqlConnection);
                // 2008.05.27 upd start -------------------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM TAXRATESETRF", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.27 upd end ----------------------------------------<<
                // �� 2008.01.29 980081 c

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, taxRateSetWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listdata.Add(CopyToTaxRateSetWorkFromReader(ref myReader));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "TaxRateSetLcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            taxRateSetWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̐ŗ��ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="taxRateSetWork">TaxRateSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̐ŗ��ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : ���R�@����</br>
        /// <br>Date       : 2007.05.18</br>
        public int Read(ref TaxRateSetWork taxRateSetWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
               //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcProc(ref taxRateSetWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "TaxRateSetLcDB.Read",0);
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
        /// �w�肳�ꂽ�����̐ŗ��ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="taxRateSetWork">TaxRateSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
          /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̐ŗ��ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���R�@����</br>
        /// <br>Date       : 2007.05.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        public int ReadProc(ref TaxRateSetWork taxRateSetWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = ReadProcProc(ref taxRateSetWork, readMode, ref sqlConnection);
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̐ŗ��ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="taxRateSetWork">TaxRateSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
          /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̐ŗ��ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���R�@����</br>
        /// <br>Date       : 2007.05.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        private int ReadProcProc(ref TaxRateSetWork taxRateSetWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Select�R�}���h�̐���
                // �� 2008.01.29 980081 c
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, TAXRATECODERF, TAXRATEPROPERNOUNNMRF, TAXRATENAMERF, FRACTIONPROCCDRF, TAXRATESTARTDATERF, TAXRATEENDDATERF, TAXRATERF, TAXRATESTARTDATE2RF, TAXRATEENDDATE2RF, TAXRATE2RF, TAXRATESTARTDATE3RF, TAXRATEENDDATE3RF, TAXRATE3RF FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE", sqlConnection))
                // 2008.05.27 upd start ---------------------------------->>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE", sqlConnection))
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND TAXRATECODERF=@FINDTAXRATECODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.27 upd end -----------------------------------<<
                    
                // �� 2008.01.29 980081 c
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaTaxRateCode = sqlCommand.Parameters.Add("@FINDTAXRATECODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(taxRateSetWork.EnterpriseCode);
                    findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxRateSetWork.TaxRateCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        taxRateSetWork = CopyToTaxRateSetWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "TaxRateSetLcDB.Read", 0);
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
        /// <br>Programmer : ���R�@����</br>
        /// <br>Date       : 2007.04.13</br>
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
                TaxRateSetWork taxRateSetWork = new TaxRateSetWork();

                for (int i = 0; i < paraSyncDataList.Count; i++)
                {
                    syncDataList = (ArrayList)paraSyncDataList[i];
                    if (syncDataList[0].GetType() == taxRateSetWork.GetType())
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
                //�߂�l�Z�b�g
                //dataSyncMngWorkList = syncDataList;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "DataSyncMngLcDB.Write", 0);
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
        /// <br>Programmer : ���R�@����</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
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
        /// <br>Programmer : ���R�@����</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        private int WriteSyncLocalDataProcProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList listdata = new ArrayList();
            string sqlTxt = string.Empty; // 2008.05.26 add
            try
            {
                if (paraSyncDataList != null)
                {
                    if (syncServiceWork.Syncmode == 1)
                    {
                        // 2008.05.27 upd start -------------------------------->>
                        //sqlCommand = new SqlCommand("DELETE FROM TAXRATESETRF WHERE ENTERPRISECODERF=@DELENTERPRISECODE", sqlConnection, sqlTransaction);
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.27 upd end ----------------------------------<<
                        SqlParameter delEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                        delEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);
                        sqlCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < paraSyncDataList.Count; i++)
                    {
                        TaxRateSetWork taxRateSetWork = paraSyncDataList[i] as TaxRateSetWork;
                        object obj;
                        IFileHeader flhd;
                        ClientFileHeader fileHeader;

                        switch (syncServiceWork.Syncmode)
                        {
                            //�������[�h�̃V���N����
                            case 0:
                                //Select�R�}���h�̐���
                                // �� 2008.01.29 980081 c
                                //sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, TAXRATECODERF, TAXRATEPROPERNOUNNMRF, TAXRATENAMERF, FRACTIONPROCCDRF, TAXRATESTARTDATERF, TAXRATEENDDATERF, TAXRATERF, TAXRATESTARTDATE2RF, TAXRATEENDDATE2RF, TAXRATE2RF, TAXRATESTARTDATE3RF, TAXRATEENDDATE3RF, TAXRATE3RF FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE", sqlConnection, sqlTransaction);
                                // 2008.05.27 upd start ----------------------------------->>
                                //sqlCommand = new SqlCommand("SELECT * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE", sqlConnection, sqlTransaction);
                                sqlTxt = string.Empty;
                                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                                sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                                sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND TAXRATECODERF=@FINDTAXRATECODE" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.27 upd end ----------------------------------<<
                                // �� 2008.01.29 980081 c

                                //Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaTaxRateCode = sqlCommand.Parameters.Add("@FINDTAXRATECODE", SqlDbType.Int);

                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(taxRateSetWork.EnterpriseCode);
                                findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxRateSetWork.TaxRateCode);

                                myReader = sqlCommand.ExecuteReader();
                                if (myReader.Read())
                                {
                                    // �� 2008.01.29 980081 c
                                    //sqlCommand.CommandText = "UPDATE TAXRATESETRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , TAXRATECODERF=@TAXRATECODE , TAXRATEPROPERNOUNNMRF=@TAXRATEPROPERNOUNNM , TAXRATENAMERF=@TAXRATENAME , FRACTIONPROCCDRF=@FRACTIONPROCCD , TAXRATESTARTDATERF=@TAXRATESTARTDATE , TAXRATEENDDATERF=@TAXRATEENDDATE , TAXRATERF=@TAXRATE , TAXRATESTARTDATE2RF=@TAXRATESTARTDATE2 , TAXRATEENDDATE2RF=@TAXRATEENDDATE2 , TAXRATE2RF=@TAXRATE2 , TAXRATESTARTDATE3RF=@TAXRATESTARTDATE3 , TAXRATEENDDATE3RF=@TAXRATEENDDATE3 , TAXRATE3RF=@TAXRATE3 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE";
                                    // 2008.05.27 upd start ---------------------------->>
                                    //sqlCommand.CommandText = "UPDATE TAXRATESETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , TAXRATECODERF=@TAXRATECODE , TAXRATEPROPERNOUNNMRF=@TAXRATEPROPERNOUNNM , TAXRATENAMERF=@TAXRATENAME , CONSTAXLAYMETHODRF=@CONSTAXLAYMETHOD , TAXRATESTARTDATERF=@TAXRATESTARTDATE , TAXRATEENDDATERF=@TAXRATEENDDATE , TAXRATERF=@TAXRATE , TAXRATESTARTDATE2RF=@TAXRATESTARTDATE2 , TAXRATEENDDATE2RF=@TAXRATEENDDATE2 , TAXRATE2RF=@TAXRATE2 , TAXRATESTARTDATE3RF=@TAXRATESTARTDATE3 , TAXRATEENDDATE3RF=@TAXRATEENDDATE3 , TAXRATE3RF=@TAXRATE3 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE";
                                    sqlTxt = string.Empty;
                                    sqlTxt += "UPDATE TAXRATESETRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlTxt += " , TAXRATECODERF=@TAXRATECODE" + Environment.NewLine;
                                    sqlTxt += " , TAXRATEPROPERNOUNNMRF=@TAXRATEPROPERNOUNNM" + Environment.NewLine;
                                    sqlTxt += " , TAXRATENAMERF=@TAXRATENAME" + Environment.NewLine;
                                    sqlTxt += " , CONSTAXLAYMETHODRF=@CONSTAXLAYMETHOD" + Environment.NewLine;
                                    sqlTxt += " , TAXRATESTARTDATERF=@TAXRATESTARTDATE" + Environment.NewLine;
                                    sqlTxt += " , TAXRATEENDDATERF=@TAXRATEENDDATE" + Environment.NewLine;
                                    sqlTxt += " , TAXRATERF=@TAXRATE" + Environment.NewLine;
                                    sqlTxt += " , TAXRATESTARTDATE2RF=@TAXRATESTARTDATE2" + Environment.NewLine;
                                    sqlTxt += " , TAXRATEENDDATE2RF=@TAXRATEENDDATE2" + Environment.NewLine;
                                    sqlTxt += " , TAXRATE2RF=@TAXRATE2" + Environment.NewLine;
                                    sqlTxt += " , TAXRATESTARTDATE3RF=@TAXRATESTARTDATE3" + Environment.NewLine;
                                    sqlTxt += " , TAXRATEENDDATE3RF=@TAXRATEENDDATE3" + Environment.NewLine;
                                    sqlTxt += " , TAXRATE3RF=@TAXRATE3" + Environment.NewLine;
                                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += "    AND TAXRATECODERF=@FINDTAXRATECODE" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.27 upd end ------------------------------<<
                                    // �� 2008.01.29 980081 c

                                    //KEY�R�}���h���Đݒ�
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(taxRateSetWork.EnterpriseCode);
                                    findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxRateSetWork.TaxRateCode);

                                    //�X�V�w�b�_����ݒ�
                                    obj = (object)this;
                                    flhd = (IFileHeader)taxRateSetWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);
                                }
                                else
                                {
                                    //�V�K�쐬����SQL���𐶐�
                                    // �� 2008.01.29 980081 c
                                    //sqlCommand.CommandText = "INSERT INTO TAXRATESETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, TAXRATECODERF, TAXRATEPROPERNOUNNMRF, TAXRATENAMERF, FRACTIONPROCCDRF, TAXRATESTARTDATERF, TAXRATEENDDATERF, TAXRATERF, TAXRATESTARTDATE2RF, TAXRATEENDDATE2RF, TAXRATE2RF, TAXRATESTARTDATE3RF, TAXRATEENDDATE3RF, TAXRATE3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @TAXRATECODE, @TAXRATEPROPERNOUNNM, @TAXRATENAME, @FRACTIONPROCCD, @TAXRATESTARTDATE, @TAXRATEENDDATE, @TAXRATE, @TAXRATESTARTDATE2, @TAXRATEENDDATE2, @TAXRATE2, @TAXRATESTARTDATE3, @TAXRATEENDDATE3, @TAXRATE3)";
                                    // 2008.05.27 upd start ---------------------------->>
                                    //sqlCommand.CommandText = "INSERT INTO TAXRATESETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, TAXRATECODERF, TAXRATEPROPERNOUNNMRF, TAXRATENAMERF, CONSTAXLAYMETHODRF, TAXRATESTARTDATERF, TAXRATEENDDATERF, TAXRATERF, TAXRATESTARTDATE2RF, TAXRATEENDDATE2RF, TAXRATE2RF, TAXRATESTARTDATE3RF, TAXRATEENDDATE3RF, TAXRATE3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @TAXRATECODE, @TAXRATEPROPERNOUNNM, @TAXRATENAME, @CONSTAXLAYMETHOD, @TAXRATESTARTDATE, @TAXRATEENDDATE, @TAXRATE, @TAXRATESTARTDATE2, @TAXRATEENDDATE2, @TAXRATE2, @TAXRATESTARTDATE3, @TAXRATEENDDATE3, @TAXRATE3)";
                                    sqlTxt = string.Empty;
                                    sqlTxt += "INSERT INTO TAXRATESETRF" + Environment.NewLine;
                                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                                    sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
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
                                    sqlTxt += "    ,@TAXRATECODE" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATEPROPERNOUNNM" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATENAME" + Environment.NewLine;
                                    sqlTxt += "    ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATESTARTDATE" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATEENDDATE" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATE" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATESTARTDATE2" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATEENDDATE2" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATE2" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATESTARTDATE3" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATEENDDATE3" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATE3" + Environment.NewLine;
                                    sqlTxt += " )" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.27 upd end ------------------------------<<
                                    // �� 2008.01.29 980081 c

                                    //�o�^�w�b�_����ݒ�
                                    obj = (object)this;
                                    flhd = (IFileHeader)taxRateSetWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetInsertHeader(ref flhd, obj);
                                }
                                if (myReader.IsClosed == false) myReader.Close();

                                break;

                            //�S���o�^�̃V���N����
                            case 1:
                                //�V�K�쐬����SQL���𐶐�
                                // �� 2008.01.29 980081 c
                                //sqlCommand = new SqlCommand("INSERT INTO TAXRATESETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, TAXRATECODERF, TAXRATEPROPERNOUNNMRF, TAXRATENAMERF, FRACTIONPROCCDRF, TAXRATESTARTDATERF, TAXRATEENDDATERF, TAXRATERF, TAXRATESTARTDATE2RF, TAXRATEENDDATE2RF, TAXRATE2RF, TAXRATESTARTDATE3RF, TAXRATEENDDATE3RF, TAXRATE3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @TAXRATECODE, @TAXRATEPROPERNOUNNM, @TAXRATENAME, @FRACTIONPROCCD, @TAXRATESTARTDATE, @TAXRATEENDDATE, @TAXRATE, @TAXRATESTARTDATE2, @TAXRATEENDDATE2, @TAXRATE2, @TAXRATESTARTDATE3, @TAXRATEENDDATE3, @TAXRATE3)", sqlConnection, sqlTransaction);
                                // 2008.05.27 upd start ---------------------------->>
                                //sqlCommand = new SqlCommand("INSERT INTO TAXRATESETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, TAXRATECODERF, TAXRATEPROPERNOUNNMRF, TAXRATENAMERF, CONSTAXLAYMETHODRF, TAXRATESTARTDATERF, TAXRATEENDDATERF, TAXRATERF, TAXRATESTARTDATE2RF, TAXRATEENDDATE2RF, TAXRATE2RF, TAXRATESTARTDATE3RF, TAXRATEENDDATE3RF, TAXRATE3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @TAXRATECODE, @TAXRATEPROPERNOUNNM, @TAXRATENAME, @CONSTAXLAYMETHOD, @TAXRATESTARTDATE, @TAXRATEENDDATE, @TAXRATE, @TAXRATESTARTDATE2, @TAXRATEENDDATE2, @TAXRATE2, @TAXRATESTARTDATE3, @TAXRATEENDDATE3, @TAXRATE3)", sqlConnection, sqlTransaction);
                                sqlTxt += "INSERT INTO TAXRATESETRF" + Environment.NewLine;
                                sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                                sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
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
                                sqlTxt += "    ,@TAXRATECODE" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATEPROPERNOUNNM" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATENAME" + Environment.NewLine;
                                sqlTxt += "    ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATESTARTDATE" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATEENDDATE" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATE" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATESTARTDATE2" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATEENDDATE2" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATE2" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATESTARTDATE3" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATEENDDATE3" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATE3" + Environment.NewLine;
                                sqlTxt += " )" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.27 upd end ------------------------------<<
                                // �� 2008.01.29 980081 c

                                //�o�^�w�b�_����ݒ�
                                obj = (object)this;
                                flhd = (IFileHeader)taxRateSetWork;
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
                        SqlParameter paraTaxRateCode = sqlCommand.Parameters.Add("@TAXRATECODE", SqlDbType.Int);
                        SqlParameter paraTaxRateProperNounNm = sqlCommand.Parameters.Add("@TAXRATEPROPERNOUNNM", SqlDbType.NVarChar);
                        SqlParameter paraTaxRateName = sqlCommand.Parameters.Add("@TAXRATENAME", SqlDbType.NVarChar);
                        // �� 2008.01.29 980081 c
                        //SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                        SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                        // �� 2008.01.29 980081 c
                        SqlParameter paraTaxRateStartDate = sqlCommand.Parameters.Add("@TAXRATESTARTDATE", SqlDbType.Int);
                        SqlParameter paraTaxRateEndDate = sqlCommand.Parameters.Add("@TAXRATEENDDATE", SqlDbType.Int);
                        SqlParameter paraTaxRate = sqlCommand.Parameters.Add("@TAXRATE", SqlDbType.Float);
                        SqlParameter paraTaxRateStartDate2 = sqlCommand.Parameters.Add("@TAXRATESTARTDATE2", SqlDbType.Int);
                        SqlParameter paraTaxRateEndDate2 = sqlCommand.Parameters.Add("@TAXRATEENDDATE2", SqlDbType.Int);
                        SqlParameter paraTaxRate2 = sqlCommand.Parameters.Add("@TAXRATE2", SqlDbType.Float);
                        SqlParameter paraTaxRateStartDate3 = sqlCommand.Parameters.Add("@TAXRATESTARTDATE3", SqlDbType.Int);
                        SqlParameter paraTaxRateEndDate3 = sqlCommand.Parameters.Add("@TAXRATEENDDATE3", SqlDbType.Int);
                        SqlParameter paraTaxRate3 = sqlCommand.Parameters.Add("@TAXRATE3", SqlDbType.Float);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(taxRateSetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(taxRateSetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(taxRateSetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(taxRateSetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(taxRateSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(taxRateSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(taxRateSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(taxRateSetWork.LogicalDeleteCode);
                        paraTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxRateSetWork.TaxRateCode);
                        paraTaxRateProperNounNm.Value = SqlDataMediator.SqlSetString(taxRateSetWork.TaxRateProperNounNm);
                        paraTaxRateName.Value = SqlDataMediator.SqlSetString(taxRateSetWork.TaxRateName);
                        // �� 2008.01.29 980081 c
                        //paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(taxRateSetWork.FractionProcCd);
                        paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(taxRateSetWork.ConsTaxLayMethod);
                        // �� 2008.01.29 980081 c
                        paraTaxRateStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(taxRateSetWork.TaxRateStartDate);
                        paraTaxRateEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(taxRateSetWork.TaxRateEndDate);
                        paraTaxRate.Value = SqlDataMediator.SqlSetDouble(taxRateSetWork.TaxRate);
                        paraTaxRateStartDate2.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(taxRateSetWork.TaxRateStartDate2);
                        paraTaxRateEndDate2.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(taxRateSetWork.TaxRateEndDate2);
                        paraTaxRate2.Value = SqlDataMediator.SqlSetDouble(taxRateSetWork.TaxRate2);
                        paraTaxRateStartDate3.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(taxRateSetWork.TaxRateStartDate3);
                        paraTaxRateEndDate3.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(taxRateSetWork.TaxRateEndDate3);
                        paraTaxRate3.Value = SqlDataMediator.SqlSetDouble(taxRateSetWork.TaxRate3);
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
                status = WriteSQLErrorLog(ex, "DataSyncMngLcDB.WriteDataSyncMngProc", 0);
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
        /// <param name="taxRateSetWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���R�@����</br>
        /// <br>Date       : 2007.05.18</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, TaxRateSetWork taxRateSetWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = " WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(taxRateSetWork.EnterpriseCode);

            //�_���폜�敪
            string wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if    (    (logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if(wkstring != "")
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
        /// �N���X�i�[���� Reader �� TaxRateSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>TaxRateSetWork</returns>
        /// <remarks>
        /// <br>Programmer : ���R�@����</br>
        /// <br>Date       : 2007.05.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        /// </remarks>
        private TaxRateSetWork CopyToTaxRateSetWorkFromReader(ref SqlDataReader myReader)
        {
            TaxRateSetWork taxRateSetWork = new TaxRateSetWork();

            #region �N���X�֊i�[
            taxRateSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            taxRateSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            taxRateSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            taxRateSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            taxRateSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            taxRateSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            taxRateSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            taxRateSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            taxRateSetWork.TaxRateCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXRATECODERF"));
            taxRateSetWork.TaxRateProperNounNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TAXRATEPROPERNOUNNMRF"));
            taxRateSetWork.TaxRateName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TAXRATENAMERF"));
            // �� 2008.01.29 980081 c
            //taxRateSetWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
            taxRateSetWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            // �� 2008.01.29 980081 c
            taxRateSetWork.TaxRateStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATERF"));
            taxRateSetWork.TaxRateEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATERF"));
            taxRateSetWork.TaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATERF"));
            taxRateSetWork.TaxRateStartDate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATE2RF"));
            taxRateSetWork.TaxRateEndDate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATE2RF"));
            taxRateSetWork.TaxRate2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATE2RF"));
            taxRateSetWork.TaxRateStartDate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATE3RF"));
            taxRateSetWork.TaxRateEndDate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATE3RF"));
            taxRateSetWork.TaxRate3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATE3RF"));
            #endregion

            return taxRateSetWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���R�@����</br>
        /// <br>Date       : 2007.05.18</br>
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
