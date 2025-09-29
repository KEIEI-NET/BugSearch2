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
    /// �a�k���i�R�[�h�}�X�^���[�J��DB�A�N�Z�X�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �a�k���i�R�[�h�}�X�^���[�J��DB���f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.06.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br></br>
    /// </remarks>
    public class BLGoodsCdULcDB : IWriteSyncLocalData
    {
        /// <summary>
        /// �a�k���i�R�[�h�}�X�^���[�J��DB�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        public BLGoodsCdULcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̂a�k���i�R�[�h�}�X�^LC���LIST��߂��܂�
        /// </summary>
        /// <param name="blGoodsCdUWorkList">��������</param>
        /// <param name="paraBLGoodsCdUWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̂a�k���i�R�[�h�}�X�^LC���LIST��߂��܂�</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        public int Search(out List<BLGoodsCdUWork> blGoodsCdUWorkList, BLGoodsCdUWork paraBLGoodsCdUWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            blGoodsCdUWorkList = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchBLGoodsCdUProcProc(out blGoodsCdUWorkList, paraBLGoodsCdUWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "BLGoodsCdULcDB.Search", 0);
                blGoodsCdUWorkList = new List<BLGoodsCdUWork>();
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
        /// �w�肳�ꂽ�����̂a�k���i�R�[�h�}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="blGoodsCdUWorkList">��������</param>
        /// <param name="blGoodsCdUWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̂a�k���i�R�[�h�}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        public int SearchBLGoodsCdUProc(out List<BLGoodsCdUWork> blGoodsCdUWorkList, BLGoodsCdUWork blGoodsCdUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            status = SearchBLGoodsCdUProcProc(out blGoodsCdUWorkList, blGoodsCdUWork, readMode, logicalMode, ref sqlConnection);
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̂a�k���i�R�[�h�}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="blGoodsCdUWorkList">��������</param>
        /// <param name="blGoodsCdUWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̂a�k���i�R�[�h�}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        private int SearchBLGoodsCdUProcProc(out List<BLGoodsCdUWork> blGoodsCdUWorkList, BLGoodsCdUWork blGoodsCdUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<BLGoodsCdUWork> listdata = new List<BLGoodsCdUWork>();
            try
            {
                string sqlText = string.Empty;
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,BLGROUPCODERF" + Environment.NewLine;
                sqlText += "    ,BLGOODSCODERF" + Environment.NewLine;
                sqlText += "    ,BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlText += "    ,BLGOODSHALFNAMERF" + Environment.NewLine;
                sqlText += "    ,BLGOODSGENRECODERF" + Environment.NewLine;
                sqlText += "    ,GOODSRATEGRPCODERF" + Environment.NewLine;
                sqlText += " FROM BLGOODSCDURF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, blGoodsCdUWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listdata.Add(CopyToBLGoodsCdUWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "BLGoodsCdULcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            blGoodsCdUWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̂a�k���i�R�[�h�}�X�^LC��߂��܂�
        /// </summary>
        /// <param name="blGoodsCdUWork">blGoodsCdUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̂a�k���i�R�[�h�}�X�^LC��߂��܂�</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        public int Read(ref BLGoodsCdUWork blGoodsCdUWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcProc(ref blGoodsCdUWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "BLGoodsCdULcDB.Read", 0);
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
        /// �w�肳�ꂽ�����̂a�k���i�R�[�h�}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="blGoodsCdUWork">blGoodsCdUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̂a�k���i�R�[�h�}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        public int ReadProc(ref BLGoodsCdUWork blGoodsCdUWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = ReadProcProc(ref blGoodsCdUWork, readMode, ref sqlConnection);
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̂a�k���i�R�[�h�}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="blGoodsCdUWork">blGoodsCdUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̂a�k���i�R�[�h�}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        private int ReadProcProc(ref BLGoodsCdUWork blGoodsCdUWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Select�R�}���h�̐���
                string sqlText = string.Empty;
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,BLGROUPCODERF" + Environment.NewLine;
                sqlText += "    ,BLGOODSCODERF" + Environment.NewLine;
                sqlText += "    ,BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlText += "    ,BLGOODSHALFNAMERF" + Environment.NewLine;
                sqlText += "    ,BLGOODSGENRECODERF" + Environment.NewLine;
                sqlText += "    ,GOODSRATEGRPCODERF" + Environment.NewLine;
                sqlText += " FROM BLGOODSCDURF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND BLGLOUPCODERF=@FINDBLGLOUPCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))    

                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaBLGloupCode = sqlCommand.Parameters.Add("@FINDBLGLOUPCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.EnterpriseCode);
                    findParaBLGloupCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCdUWork.BLGroupCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        blGoodsCdUWork = CopyToBLGoodsCdUWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "BLGoodsCdULcDB.Read", 0);
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
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
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
                BLGoodsCdUWork blGoodsCdUWork = new BLGoodsCdUWork();

                for (int i = 0; i < paraSyncDataList.Count; i++)
                {
                    syncDataList = (ArrayList)paraSyncDataList[i];
                    if (syncDataList[0].GetType() == blGoodsCdUWork.GetType())
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
                WriteErrorLog(ex, "BLGoodsCdULcDB.WriteSyncLocalData", 0);
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
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
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
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        private int WriteSyncLocalDataProcProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList listdata = new ArrayList();
            string sqlText = string.Empty;
            try
            {
                if (paraSyncDataList != null)
                {
                    if (syncServiceWork.Syncmode == 1)
                    {
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += " FROM BLGOODSCDURF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@DELENTERPRISECODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        SqlParameter delEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                        delEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);
                        sqlCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < paraSyncDataList.Count; i++)
                    {
                        BLGoodsCdUWork blGoodsCdUWork = paraSyncDataList[i] as BLGoodsCdUWork;
                        object obj;
                        IFileHeader flhd;
                        ClientFileHeader fileHeader;

                        switch (syncServiceWork.Syncmode)
                        {
                            //�������[�h�̃V���N����
                            case 0:
                                //Select�R�}���h�̐���
                                sqlText = string.Empty;
                                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlText += "    ,BLGROUPCODERF" + Environment.NewLine;
                                sqlText += "    ,BLGOODSCODERF" + Environment.NewLine;
                                sqlText += "    ,BLGOODSFULLNAMERF" + Environment.NewLine;
                                sqlText += "    ,BLGOODSHALFNAMERF" + Environment.NewLine;
                                sqlText += "    ,BLGOODSGENRECODERF" + Environment.NewLine;
                                sqlText += "    ,GOODSRATEGRPCODERF" + Environment.NewLine;
                                sqlText += " FROM BLGOODSCDURF" + Environment.NewLine;
                                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "    AND BLGLOUPCODERF=@FINDBLGLOUPCODE" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                                //Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaBLGloupCode = sqlCommand.Parameters.Add("@FINDBLGLOUPCODE", SqlDbType.Int);

                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.EnterpriseCode);
                                findParaBLGloupCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCdUWork.BLGroupCode);

                                myReader = sqlCommand.ExecuteReader();
                                if (myReader.Read())
                                {
                                    //Update�R�}���h�̐���
                                    sqlText = string.Empty;
                                    sqlText += "UPDATE BLGOODSCDURF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                                    sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                    sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                    sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                    sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlText += " , BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                                    sqlText += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                                    sqlText += " , BLGOODSFULLNAMERF=@BLGOODSFULLNAME" + Environment.NewLine;
                                    sqlText += " , BLGOODSHALFNAMERF=@BLGOODSHALFNAME" + Environment.NewLine;
                                    sqlText += " , BLGOODSGENRECODERF=@BLGOODSGENRECODE" + Environment.NewLine;
                                    sqlText += " , GOODSRATEGRPCODERF=@GOODSRATEGRPCODE" + Environment.NewLine;
                                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlText += "    AND BLGLOUPCODERF=@FINDBLGLOUPCODE" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlText;
                                    
                                    //KEY�R�}���h���Đݒ�
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.EnterpriseCode);
                                    findParaBLGloupCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCdUWork.BLGroupCode);
                                    
                                    //�X�V�w�b�_����ݒ�
                                    //FileHeaderGuid��Select���ʂ���擾
                                    blGoodsCdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                                    obj = (object)this;
                                    flhd = (IFileHeader)blGoodsCdUWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);

                                }
                                else
                                {
                                    //Insert�R�}���h�̐���
                                    sqlText = string.Empty;
                                    sqlText += "INSERT INTO BLGOODSCDURF" + Environment.NewLine;
                                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                                    sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                    sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                    sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                    sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                    sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                    sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                    sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                    sqlText += "    ,BLGROUPCODERF" + Environment.NewLine;
                                    sqlText += "    ,BLGOODSCODERF" + Environment.NewLine;
                                    sqlText += "    ,BLGOODSFULLNAMERF" + Environment.NewLine;
                                    sqlText += "    ,BLGOODSHALFNAMERF" + Environment.NewLine;
                                    sqlText += "    ,BLGOODSGENRECODERF" + Environment.NewLine;
                                    sqlText += "    ,GOODSRATEGRPCODERF" + Environment.NewLine;
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
                                    sqlText += "    ,@BLGROUPCODE" + Environment.NewLine;
                                    sqlText += "    ,@BLGOODSCODE" + Environment.NewLine;
                                    sqlText += "    ,@BLGOODSFULLNAME" + Environment.NewLine;
                                    sqlText += "    ,@BLGOODSHALFNAME" + Environment.NewLine;
                                    sqlText += "    ,@BLGOODSGENRECODE" + Environment.NewLine;
                                    sqlText += "    ,@GOODSRATEGRPCODE" + Environment.NewLine;
                                    sqlText += " )" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlText;

                                    //�o�^�w�b�_����ݒ�
                                    obj = (object)this;
                                    flhd = (IFileHeader)blGoodsCdUWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetInsertHeader(ref flhd, obj);
                                }
                                if (myReader.IsClosed == false) myReader.Close();
                                break;

                            //�S���o�^�̃V���N����
                            case 1:
                                //Insert�R�}���h�̐���
                                sqlText = string.Empty;
                                sqlText += "INSERT INTO BLGOODSCDURF" + Environment.NewLine;
                                sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlText += "    ,BLGROUPCODERF" + Environment.NewLine;
                                sqlText += "    ,BLGOODSCODERF" + Environment.NewLine;
                                sqlText += "    ,BLGOODSFULLNAMERF" + Environment.NewLine;
                                sqlText += "    ,BLGOODSHALFNAMERF" + Environment.NewLine;
                                sqlText += "    ,BLGOODSGENRECODERF" + Environment.NewLine;
                                sqlText += "    ,GOODSRATEGRPCODERF" + Environment.NewLine;
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
                                sqlText += "    ,@BLGROUPCODE" + Environment.NewLine;
                                sqlText += "    ,@BLGOODSCODE" + Environment.NewLine;
                                sqlText += "    ,@BLGOODSFULLNAME" + Environment.NewLine;
                                sqlText += "    ,@BLGOODSHALFNAME" + Environment.NewLine;
                                sqlText += "    ,@BLGOODSGENRECODE" + Environment.NewLine;
                                sqlText += "    ,@GOODSRATEGRPCODE" + Environment.NewLine;
                                sqlText += " )" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                                //�o�^�w�b�_����ݒ�
                                obj = (object)this;
                                flhd = (IFileHeader)blGoodsCdUWork;
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
                        SqlParameter paraBLGloupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                        SqlParameter paraBLGoodsHalfName = sqlCommand.Parameters.Add("@BLGOODSHALFNAME", SqlDbType.NVarChar);
                        SqlParameter paraBLGoodsGenreCode = sqlCommand.Parameters.Add("@BLGOODSGENRECODE", SqlDbType.Int);
                        SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@GOODSRATEGRPCODE", SqlDbType.Int);

                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(blGoodsCdUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(blGoodsCdUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(blGoodsCdUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCdUWork.LogicalDeleteCode);
                        paraBLGloupCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCdUWork.BLGroupCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCdUWork.BLGoodsCode);
                        paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.BLGoodsFullName);
                        paraBLGoodsHalfName.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.BLGoodsHalfName);
                        paraBLGoodsGenreCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCdUWork.BLGoodsGenreCode);
                        paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCdUWork.GoodsRateGrpCode);
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
                status = WriteSQLErrorLog(ex, "BLGoodsCdULcDB.WriteSyncLocalDataProc", 0);
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
        /// <param name="blGoodsCdUWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, BLGoodsCdUWork blGoodsCdUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.EnterpriseCode);

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
            // BL�O���[�v�R�[�h
            if (blGoodsCdUWork.BLGroupCode != 0)
            {
                retstring += "AND BLGROUPCODERF=@FINDBLGLOUPCODE ";
                SqlParameter paraBLGloupCode = sqlCommand.Parameters.Add("@FINDBLGLOUPCODE", SqlDbType.Int);
                paraBLGloupCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCdUWork.BLGroupCode);
            }


            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� BLGoodsCdUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>BLGoodsCdUWork</returns>
        /// <remarks>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        private BLGoodsCdUWork CopyToBLGoodsCdUWorkFromReader(ref SqlDataReader myReader)
        {
            BLGoodsCdUWork wkBLGoodsCdUWork = new BLGoodsCdUWork();

            #region �N���X�֊i�[
            wkBLGoodsCdUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkBLGoodsCdUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkBLGoodsCdUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkBLGoodsCdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkBLGoodsCdUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkBLGoodsCdUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkBLGoodsCdUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkBLGoodsCdUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkBLGoodsCdUWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkBLGoodsCdUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkBLGoodsCdUWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkBLGoodsCdUWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            wkBLGoodsCdUWork.BLGoodsGenreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSGENRECODERF"));
            wkBLGoodsCdUWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            #endregion

            return wkBLGoodsCdUWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
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
