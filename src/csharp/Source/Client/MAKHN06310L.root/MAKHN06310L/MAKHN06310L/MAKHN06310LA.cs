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
    /// �S�̏����l�ݒ�}�X�^LC���[�J��DB�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �S�̏����l�ݒ�}�X�^LC�̃��[�J��DB���f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 19026�@���R�@����</br>
    /// <br>Date       : 2007.05.21</br>
    /// <br></br>
    /// <br>Update Note: 2008.01.29 980081 �R�c ���F</br>
    /// <br>           : ���ʊ�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2008.05.30 20081 �D�c �E�l</br>
    /// <br>           : PM.NS�p�ɕύX</br>
    /// </remarks>
    /// <br>Update Note: 2010.02.05 30531 ��� �r��</br>
    /// <br>           : �������^�C�v���̏o�͋敪�̒ǉ�(�R����)</br>
    /// </remarks>
    public class AllDefSetLcDB : IWriteSyncLocalData
    {
        /// <summary>
        /// �S�̏����l�ݒ�}�X�^LC���[�J��DB�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.21</br>
        /// </remarks>
        public AllDefSetLcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̑S�̏����l�ݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="allDefSetWorkList">��������</param>
        /// <param name="paraAllDefSetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑S�̏����l�ݒ�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.21</br>
        public int Search(out List<AllDefSetWork> allDefSetWorkList, AllDefSetWork paraAllDefSetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            allDefSetWorkList = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchAllDefSetProcProc(out allDefSetWorkList, paraAllDefSetWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AllDefSetLcDB.Search",0);
                allDefSetWorkList = new List<AllDefSetWork>();
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
        /// �w�肳�ꂽ�����̑S�̏����l�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="allDefSetWorkList">��������</param>
        /// <param name="allDefSetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑S�̏����l�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.21</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        public int SearchAllDefSetProc(out List<AllDefSetWork> allDefSetWorkList, AllDefSetWork allDefSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            status = SearchAllDefSetProcProc(out allDefSetWorkList, allDefSetWork, readMode, logicalMode, ref sqlConnection);
            return status;
        }


        /// <summary>
        /// �w�肳�ꂽ�����̑S�̏����l�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="allDefSetWorkList">��������</param>
        /// <param name="allDefSetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑S�̏����l�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.21</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        private int SearchAllDefSetProcProc(out List<AllDefSetWork> allDefSetWorkList, AllDefSetWork allDefSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<AllDefSetWork> listdata = new List<AllDefSetWork>();
            try
            {
                // �� 2008.01.29 980081 c
                //sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTOMERDELCHKDIVCDRF, CUSTCDAUTONUMBERINGRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, MEMBERINFODISPCDRF FROM ALLDEFSETRF", sqlConnection);
                // 2008.05.30 upd start ----------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM ALLDEFSETRF", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                // --- ADD  ���r��  2010/02/05 ---------->>>>>
                sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                // --- ADD  ���r��  2010/02/05 ----------<<<<<
                sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.30 upd end -------------------------------<<
                // �� 2008.01.29 980081 c

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, allDefSetWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listdata.Add(CopyToAllDefSetWorkFromReader(ref myReader));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "AllDefSetLcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            allDefSetWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̑S�̏����l�ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="allDefSetWork">AllDefSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑S�̏����l�ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.21</br>
        public int Read(ref AllDefSetWork allDefSetWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
               //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcProc(ref allDefSetWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AllDefSetLcDB.Read",0);
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
        /// �w�肳�ꂽ�����̑S�̏����l�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="allDefSetWork">AllDefSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑S�̏����l�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.21</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        public int ReadProc(ref AllDefSetWork allDefSetWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = ReadProcProc(ref allDefSetWork, readMode, ref sqlConnection);
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̑S�̏����l�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="allDefSetWork">AllDefSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑S�̏����l�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.21</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        private int ReadProcProc(ref AllDefSetWork allDefSetWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Select�R�}���h�̐���
                // �� 2008.01.29 980081 c
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTOMERDELCHKDIVCDRF, CUSTCDAUTONUMBERINGRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, MEMBERINFODISPCDRF FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection))
                // 2008.05.30 upd start ------------------------------------->>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection))
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                // --- ADD  ���r��  2010/02/05 ---------->>>>>
                sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                // --- ADD  ���r��  2010/02/05 ----------<<<<<
                sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))    
                // 2008.05.30 upd end ---------------------------------------<<
                // �� 2008.01.29 980081 c
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        allDefSetWork = CopyToAllDefSetWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "AllDefSetLcDB.Read", 0);
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
        /// <br>Programmer : 19026�@���R�@����</br>
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
                AllDefSetWork allDefSetWork = new AllDefSetWork();

                for (int i = 0; i < paraSyncDataList.Count; i++)
                {
                    syncDataList = (ArrayList)paraSyncDataList[i];
                    if (syncDataList[0].GetType() == allDefSetWork.GetType())
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
        /// <br>Programmer : 19026�@���R�@����</br>
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
        /// <br>Programmer : 19026�@���R�@����</br>
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
            string sqlTxt = string.Empty; // 2008.05.30 add
            try
            {
                if (paraSyncDataList != null)
                {
                    if (syncServiceWork.Syncmode == 1)
                    {   // 2008.05.30 upd start ------------------------------->>
                        //sqlCommand = new SqlCommand("DELETE FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@DELENTERPRISECODE", sqlConnection, sqlTransaction);
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@DELENTERPRISECODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.30 upd end ---------------------------------<<
                        SqlParameter delEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                        delEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);
                        sqlCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < paraSyncDataList.Count; i++)
                    {
                        AllDefSetWork allDefSetWork = paraSyncDataList[i] as AllDefSetWork;
                        object obj;
                        IFileHeader flhd;
                        ClientFileHeader fileHeader;

                        switch (syncServiceWork.Syncmode)
                        {
                            //�������[�h�̃V���N����
                            case 0:
                                //Select�R�}���h�̐���
                                // �� 2008.01.29 980081 c
                                //sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTOMERDELCHKDIVCDRF, CUSTCDAUTONUMBERINGRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, MEMBERINFODISPCDRF FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);
                                // 2008.05.30 upd start ------------------------------->>
                                //sqlCommand = new SqlCommand("SELECT * FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);
                                sqlTxt = string.Empty;
                                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                                sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                                // --- ADD  ���r��  2010/02/05 ---------->>>>>
                                sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                                // --- ADD  ���r��  2010/02/05 ----------<<<<<
                                sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction); 
                                // 2008.05.30 upd end ---------------------------------<<
                                // �� 2008.01.29 980081 c

                                //Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.EnterpriseCode);
                                findParaSectionCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.SectionCode);

                                myReader = sqlCommand.ExecuteReader();
                                if (myReader.Read())
                                {
                                    // 2008.05.30 upd start ------------------------------->>
                                    // �� 2008.01.29 980081 c
                                    //sqlCommand.CommandText = "UPDATE ALLDEFSETRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , TOTALAMOUNTDISPWAYCDRF=@TOTALAMOUNTDISPWAYCD , CUSTOMERDELCHKDIVCDRF=@CUSTOMERDELCHKDIVCD , CUSTCDAUTONUMBERINGRF=@CUSTCDAUTONUMBERING , DEFDSPCUSTTTLDAYRF=@DEFDSPCUSTTTLDAY , DEFDSPCUSTCLCTMNYDAYRF=@DEFDSPCUSTCLCTMNYDAY , DEFDSPCLCTMNYMONTHCDRF=@DEFDSPCLCTMNYMONTHCD , INIDSPPRSLORCORPCDRF=@INIDSPPRSLORCORPCD , INITDSPDMDIVRF=@INITDSPDMDIV , DEFDSPBILLPRTDIVCDRF=@DEFDSPBILLPRTDIVCD , MEMBERINFODISPCDRF=@MEMBERINFODISPCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                                    //sqlCommand.CommandText = "UPDATE ALLDEFSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , TOTALAMOUNTDISPWAYCDRF=@TOTALAMOUNTDISPWAYCD , CUSTOMERDELCHKDIVCDRF=@CUSTOMERDELCHKDIVCD , CUSTCDAUTONUMBERINGRF=@CUSTCDAUTONUMBERING , DEFDSPCUSTTTLDAYRF=@DEFDSPCUSTTTLDAY , DEFDSPCUSTCLCTMNYDAYRF=@DEFDSPCUSTCLCTMNYDAY , DEFDSPCLCTMNYMONTHCDRF=@DEFDSPCLCTMNYMONTHCD , INIDSPPRSLORCORPCDRF=@INIDSPPRSLORCORPCD , INITDSPDMDIVRF=@INITDSPDMDIV , DEFDSPBILLPRTDIVCDRF=@DEFDSPBILLPRTDIVCD , MEMBERINFODISPCDRF=@MEMBERINFODISPCD , ERANAMEDISPCD1RF=@ERANAMEDISPCD1 , ERANAMEDISPCD2RF=@ERANAMEDISPCD2 , ERANAMEDISPCD3RF=@ERANAMEDISPCD3 , GOODSNOINPDIVRF=@GOODSNOINPDIV , JANCODEINPDIVRF=@JANCODEINPDIV , UNCSTLINKDIVRF=@UNCSTLINKDIV , CNSTAXAUTOCORRDIVRF=@CNSTAXAUTOCORRDIV , REMAINCNTMNGDIVRF=@REMAINCNTMNGDIV , MEMOMOVEDIVRF=@MEMOMOVEDIV , REMCNTAUTODSPDIVRF=@REMCNTAUTODSPDIV , TTLAMNTDSPRATEDIVCDRF=@TTLAMNTDSPRATEDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                                    // �� 2008.01.29 980081 c
                                    sqlTxt = string.Empty;
                                    sqlTxt += "UPDATE ALLDEFSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                                    sqlTxt += " , TOTALAMOUNTDISPWAYCDRF=@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                                    sqlTxt += " , DEFDSPCUSTTTLDAYRF=@DEFDSPCUSTTTLDAY" + Environment.NewLine;
                                    sqlTxt += " , DEFDSPCUSTCLCTMNYDAYRF=@DEFDSPCUSTCLCTMNYDAY" + Environment.NewLine;
                                    sqlTxt += " , DEFDSPCLCTMNYMONTHCDRF=@DEFDSPCLCTMNYMONTHCD" + Environment.NewLine;
                                    sqlTxt += " , INIDSPPRSLORCORPCDRF=@INIDSPPRSLORCORPCD" + Environment.NewLine;
                                    sqlTxt += " , INITDSPDMDIVRF=@INITDSPDMDIV" + Environment.NewLine;
                                    sqlTxt += " , DEFDSPBILLPRTDIVCDRF=@DEFDSPBILLPRTDIVCD" + Environment.NewLine;
                                    sqlTxt += " , ERANAMEDISPCD1RF=@ERANAMEDISPCD1" + Environment.NewLine;
                                    sqlTxt += " , ERANAMEDISPCD2RF=@ERANAMEDISPCD2" + Environment.NewLine;
                                    sqlTxt += " , ERANAMEDISPCD3RF=@ERANAMEDISPCD3" + Environment.NewLine;
                                    sqlTxt += " , GOODSNOINPDIVRF=@GOODSNOINPDIV" + Environment.NewLine;
                                    sqlTxt += " , CNSTAXAUTOCORRDIVRF=@CNSTAXAUTOCORRDIV" + Environment.NewLine;
                                    sqlTxt += " , REMAINCNTMNGDIVRF=@REMAINCNTMNGDIV" + Environment.NewLine;
                                    sqlTxt += " , MEMOMOVEDIVRF=@MEMOMOVEDIV" + Environment.NewLine;
                                    sqlTxt += " , REMCNTAUTODSPDIVRF=@REMCNTAUTODSPDIV" + Environment.NewLine;
                                    sqlTxt += " , TTLAMNTDSPRATEDIVCDRF=@TTLAMNTDSPRATEDIVCD" + Environment.NewLine;
                                    // --- ADD  ���r��  2010/02/05 ---------->>>>>
                                    sqlTxt += " , DEFTTLBILLOUTPUTRF=@DEFTTLBILLOUTPUT" + Environment.NewLine;
                                    sqlTxt += " , DEFDTLBILLOUTPUTRF=@DEFDTLBILLOUTPUT" + Environment.NewLine;
                                    sqlTxt += " , DEFSLTTLBILLOUTPUTRF=@DEFSLTTLBILLOUTPUT" + Environment.NewLine;                                                                        
                                    // --- ADD  ���r��  2010/02/05 ----------<<<<<
                                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.30 upd end ---------------------------------<<

                                    //KEY�R�}���h���Đݒ�
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.EnterpriseCode);
                                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.SectionCode);

                                    //�X�V�w�b�_����ݒ�
                                    obj = (object)this;
                                    flhd = (IFileHeader)allDefSetWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);
                                }
                                else
                                {
                                    //�V�K�쐬����SQL���𐶐�
                                    // 2008.05.30 upd start ------------------------------->>
                                    // �� 2008.01.29 980081 c
                                    //sqlCommand.CommandText = "INSERT INTO ALLDEFSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTOMERDELCHKDIVCDRF, CUSTCDAUTONUMBERINGRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, MEMBERINFODISPCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @TOTALAMOUNTDISPWAYCD, @CUSTOMERDELCHKDIVCD, @CUSTCDAUTONUMBERING, @DEFDSPCUSTTTLDAY, @DEFDSPCUSTCLCTMNYDAY, @DEFDSPCLCTMNYMONTHCD, @INIDSPPRSLORCORPCD, @INITDSPDMDIV, @DEFDSPBILLPRTDIVCD, @MEMBERINFODISPCD)";
                                    //sqlCommand.CommandText = "INSERT INTO ALLDEFSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTOMERDELCHKDIVCDRF, CUSTCDAUTONUMBERINGRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, MEMBERINFODISPCDRF, ERANAMEDISPCD1RF, ERANAMEDISPCD2RF, ERANAMEDISPCD3RF, GOODSNOINPDIVRF, JANCODEINPDIVRF, UNCSTLINKDIVRF, CNSTAXAUTOCORRDIVRF, REMAINCNTMNGDIVRF, MEMOMOVEDIVRF, REMCNTAUTODSPDIVRF, TTLAMNTDSPRATEDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @TOTALAMOUNTDISPWAYCD, @CUSTOMERDELCHKDIVCD, @CUSTCDAUTONUMBERING, @DEFDSPCUSTTTLDAY, @DEFDSPCUSTCLCTMNYDAY, @DEFDSPCLCTMNYMONTHCD, @INIDSPPRSLORCORPCD, @INITDSPDMDIV, @DEFDSPBILLPRTDIVCD, @MEMBERINFODISPCD, @ERANAMEDISPCD1, @ERANAMEDISPCD2, @ERANAMEDISPCD3, @GOODSNOINPDIV, @JANCODEINPDIV, @UNCSTLINKDIV, @CNSTAXAUTOCORRDIV, @REMAINCNTMNGDIV, @MEMOMOVEDIV, @REMCNTAUTODSPDIV, @TTLAMNTDSPRATEDIVCD)";
                                    // �� 2008.01.29 980081 c
                                    sqlTxt = string.Empty;
                                    sqlTxt += "INSERT INTO ALLDEFSETRF" + Environment.NewLine;
                                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                    sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                                    sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                                    sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                                    sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                                    sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                                    sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                                    sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                                    sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                                    sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                                    sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                                    sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                                    sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                                    sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                                    sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                                    sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                                    sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                                    // --- ADD  ���r��  2010/02/05 ---------->>>>>
                                    sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                                    sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                                    sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine; 
                                    // --- ADD  ���r��  2010/02/05 ----------<<<<<
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
                                    sqlTxt += "    ,@SECTIONCODE" + Environment.NewLine;
                                    sqlTxt += "    ,@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                                    sqlTxt += "    ,@DEFDSPCUSTTTLDAY" + Environment.NewLine;
                                    sqlTxt += "    ,@DEFDSPCUSTCLCTMNYDAY" + Environment.NewLine;
                                    sqlTxt += "    ,@DEFDSPCLCTMNYMONTHCD" + Environment.NewLine;
                                    sqlTxt += "    ,@INIDSPPRSLORCORPCD" + Environment.NewLine;
                                    sqlTxt += "    ,@INITDSPDMDIV" + Environment.NewLine;
                                    sqlTxt += "    ,@DEFDSPBILLPRTDIVCD" + Environment.NewLine;
                                    sqlTxt += "    ,@ERANAMEDISPCD1" + Environment.NewLine;
                                    sqlTxt += "    ,@ERANAMEDISPCD2" + Environment.NewLine;
                                    sqlTxt += "    ,@ERANAMEDISPCD3" + Environment.NewLine;
                                    sqlTxt += "    ,@GOODSNOINPDIV" + Environment.NewLine;
                                    sqlTxt += "    ,@CNSTAXAUTOCORRDIV" + Environment.NewLine;
                                    sqlTxt += "    ,@REMAINCNTMNGDIV" + Environment.NewLine;
                                    sqlTxt += "    ,@MEMOMOVEDIV" + Environment.NewLine;
                                    sqlTxt += "    ,@REMCNTAUTODSPDIV" + Environment.NewLine;
                                    sqlTxt += "    ,@TTLAMNTDSPRATEDIVCD" + Environment.NewLine;
                                    // --- ADD  ���r��  2010/02/05 ---------->>>>>
                                    sqlTxt += "    ,@DEFTTLBILLOUTPUT" + Environment.NewLine;
                                    sqlTxt += "    ,@DEFDTLBILLOUTPUT" + Environment.NewLine;
                                    sqlTxt += "    ,@DEFSLTTLBILLOUTPUT" + Environment.NewLine;
                                    // --- ADD  ���r��  2010/02/05 ----------<<<<<
                                    sqlTxt += " )" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.30 upd end ---------------------------------<<

                                    //�o�^�w�b�_����ݒ�
                                    obj = (object)this;
                                    flhd = (IFileHeader)allDefSetWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetInsertHeader(ref flhd, obj);
                                }
                                if (myReader.IsClosed == false) myReader.Close();

                                break;

                            //�S���o�^�̃V���N����
                            case 1:
                                //�V�K�쐬����SQL���𐶐�
                                // 2008.05.30 upd start ------------------------------->>
                                // �� 2008.01.29 980081 c
                                //sqlCommand = new SqlCommand("INSERT INTO ALLDEFSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTOMERDELCHKDIVCDRF, CUSTCDAUTONUMBERINGRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, MEMBERINFODISPCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @TOTALAMOUNTDISPWAYCD, @CUSTOMERDELCHKDIVCD, @CUSTCDAUTONUMBERING, @DEFDSPCUSTTTLDAY, @DEFDSPCUSTCLCTMNYDAY, @DEFDSPCLCTMNYMONTHCD, @INIDSPPRSLORCORPCD, @INITDSPDMDIV, @DEFDSPBILLPRTDIVCD, @MEMBERINFODISPCD)", sqlConnection, sqlTransaction);
                                //sqlCommand = new SqlCommand("INSERT INTO ALLDEFSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTOMERDELCHKDIVCDRF, CUSTCDAUTONUMBERINGRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, MEMBERINFODISPCDRF, ERANAMEDISPCD1RF, ERANAMEDISPCD2RF, ERANAMEDISPCD3RF, GOODSNOINPDIVRF, JANCODEINPDIVRF, UNCSTLINKDIVRF, CNSTAXAUTOCORRDIVRF, REMAINCNTMNGDIVRF, MEMOMOVEDIVRF, REMCNTAUTODSPDIVRF, TTLAMNTDSPRATEDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @TOTALAMOUNTDISPWAYCD, @CUSTOMERDELCHKDIVCD, @CUSTCDAUTONUMBERING, @DEFDSPCUSTTTLDAY, @DEFDSPCUSTCLCTMNYDAY, @DEFDSPCLCTMNYMONTHCD, @INIDSPPRSLORCORPCD, @INITDSPDMDIV, @DEFDSPBILLPRTDIVCD, @MEMBERINFODISPCD, @ERANAMEDISPCD1, @ERANAMEDISPCD2, @ERANAMEDISPCD3, @GOODSNOINPDIV, @JANCODEINPDIV, @UNCSTLINKDIV, @CNSTAXAUTOCORRDIV, @REMAINCNTMNGDIV, @MEMOMOVEDIV, @REMCNTAUTODSPDIV, @TTLAMNTDSPRATEDIVCD)", sqlConnection, sqlTransaction);
                                // �� 2008.01.29 980081 c
                                sqlTxt = string.Empty;
                                sqlTxt += "INSERT INTO ALLDEFSETRF" + Environment.NewLine;
                                sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                                sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                                // --- ADD  ���r��  2010/02/05 ---------->>>>>
                                sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                                // --- ADD  ���r��  2010/02/05 ----------<<<<<
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
                                sqlTxt += "    ,@SECTIONCODE" + Environment.NewLine;
                                sqlTxt += "    ,@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                                sqlTxt += "    ,@DEFDSPCUSTTTLDAY" + Environment.NewLine;
                                sqlTxt += "    ,@DEFDSPCUSTCLCTMNYDAY" + Environment.NewLine;
                                sqlTxt += "    ,@DEFDSPCLCTMNYMONTHCD" + Environment.NewLine;
                                sqlTxt += "    ,@INIDSPPRSLORCORPCD" + Environment.NewLine;
                                sqlTxt += "    ,@INITDSPDMDIV" + Environment.NewLine;
                                sqlTxt += "    ,@DEFDSPBILLPRTDIVCD" + Environment.NewLine;
                                sqlTxt += "    ,@ERANAMEDISPCD1" + Environment.NewLine;
                                sqlTxt += "    ,@ERANAMEDISPCD2" + Environment.NewLine;
                                sqlTxt += "    ,@ERANAMEDISPCD3" + Environment.NewLine;
                                sqlTxt += "    ,@GOODSNOINPDIV" + Environment.NewLine;
                                sqlTxt += "    ,@CNSTAXAUTOCORRDIV" + Environment.NewLine;
                                sqlTxt += "    ,@REMAINCNTMNGDIV" + Environment.NewLine;
                                sqlTxt += "    ,@MEMOMOVEDIV" + Environment.NewLine;
                                sqlTxt += "    ,@REMCNTAUTODSPDIV" + Environment.NewLine;
                                sqlTxt += "    ,@TTLAMNTDSPRATEDIVCD" + Environment.NewLine;
                                // --- ADD  ���r��  2010/02/05 ---------->>>>>
                                sqlTxt += "    ,@DEFTTLBILLOUTPUT" + Environment.NewLine;
                                sqlTxt += "    ,@DEFDTLBILLOUTPUT" + Environment.NewLine;
                                sqlTxt += "    ,@DEFSLTTLBILLOUTPUT" + Environment.NewLine;
                                // --- ADD  ���r��  2010/02/05 ----------<<<<<
                                sqlTxt += " )" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.30 upd end ---------------------------------<<

                                //�o�^�w�b�_����ݒ�
                                obj = (object)this;
                                flhd = (IFileHeader)allDefSetWork;
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
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraTotalAmountDispWayCd = sqlCommand.Parameters.Add("@TOTALAMOUNTDISPWAYCD", SqlDbType.Int);
                        SqlParameter paraDefDspCustTtlDay = sqlCommand.Parameters.Add("@DEFDSPCUSTTTLDAY", SqlDbType.Int);
                        SqlParameter paraDefDspCustClctMnyDay = sqlCommand.Parameters.Add("@DEFDSPCUSTCLCTMNYDAY", SqlDbType.Int);
                        SqlParameter paraDefDspClctMnyMonthCd = sqlCommand.Parameters.Add("@DEFDSPCLCTMNYMONTHCD", SqlDbType.Int);
                        SqlParameter paraIniDspPrslOrCorpCd = sqlCommand.Parameters.Add("@INIDSPPRSLORCORPCD", SqlDbType.Int);
                        SqlParameter paraInitDspDmDiv = sqlCommand.Parameters.Add("@INITDSPDMDIV", SqlDbType.Int);
                        SqlParameter paraDefDspBillPrtDivCd = sqlCommand.Parameters.Add("@DEFDSPBILLPRTDIVCD", SqlDbType.Int);
                        // �� 2008.01.29 980081 a
                        SqlParameter paraEraNameDispCd1 = sqlCommand.Parameters.Add("@ERANAMEDISPCD1", SqlDbType.Int);
                        SqlParameter paraEraNameDispCd2 = sqlCommand.Parameters.Add("@ERANAMEDISPCD2", SqlDbType.Int);
                        SqlParameter paraEraNameDispCd3 = sqlCommand.Parameters.Add("@ERANAMEDISPCD3", SqlDbType.Int);
                        SqlParameter paraGoodsNoInpDiv = sqlCommand.Parameters.Add("@GOODSNOINPDIV", SqlDbType.Int);
                        SqlParameter paraCnsTaxAutoCorrDiv = sqlCommand.Parameters.Add("@CNSTAXAUTOCORRDIV", SqlDbType.Int);
                        SqlParameter paraRemainCntMngDiv = sqlCommand.Parameters.Add("@REMAINCNTMNGDIV", SqlDbType.Int);
                        SqlParameter paraMemoMoveDiv = sqlCommand.Parameters.Add("@MEMOMOVEDIV", SqlDbType.Int);
                        SqlParameter paraRemCntAutoDspDiv = sqlCommand.Parameters.Add("@REMCNTAUTODSPDIV", SqlDbType.Int);
                        SqlParameter paraTtlAmntDspRateDivCd = sqlCommand.Parameters.Add("@TTLAMNTDSPRATEDIVCD", SqlDbType.Int);
                        // �� 2008.01.29 980081 a
                        // --- ADD  ���r��  2010/02/05 ---------->>>>>
                        SqlParameter paraDefTtlBillOutput = sqlCommand.Parameters.Add("@DEFTTLBILLOUTPUT", SqlDbType.Int);
                        SqlParameter paraDefDtlBillOutput = sqlCommand.Parameters.Add("@DEFDTLBILLOUTPUT", SqlDbType.Int);
                        SqlParameter paraDefSlTtlBillOutput = sqlCommand.Parameters.Add("@DEFSLTTLBILLOUTPUT", SqlDbType.Int);
                        // --- ADD  ���r��  2010/02/05 ----------<<<<<
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(allDefSetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(allDefSetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(allDefSetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(allDefSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(allDefSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.SectionCode);
                        paraTotalAmountDispWayCd.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.TotalAmountDispWayCd);
                        paraDefDspCustTtlDay.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.DefDspCustTtlDay);
                        paraDefDspCustClctMnyDay.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.DefDspCustClctMnyDay);
                        paraDefDspClctMnyMonthCd.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.DefDspClctMnyMonthCd);
                        paraIniDspPrslOrCorpCd.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.IniDspPrslOrCorpCd);
                        paraInitDspDmDiv.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.InitDspDmDiv);
                        paraDefDspBillPrtDivCd.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.DefDspBillPrtDivCd);
                        // �� 2008.01.29 980081 a
                        paraEraNameDispCd1.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.EraNameDispCd1);
                        paraEraNameDispCd2.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.EraNameDispCd2);
                        paraEraNameDispCd3.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.EraNameDispCd3);
                        paraGoodsNoInpDiv.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.GoodsNoInpDiv);
                        paraCnsTaxAutoCorrDiv.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.CnsTaxAutoCorrDiv);
                        paraRemainCntMngDiv.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.RemainCntMngDiv);
                        paraMemoMoveDiv.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.MemoMoveDiv);
                        paraRemCntAutoDspDiv.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.RemCntAutoDspDiv);
                        paraTtlAmntDspRateDivCd.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.TtlAmntDspRateDivCd);
                        // �� 2008.01.29 980081 a
                        // --- ADD  ���r��  2010/02/05 ---------->>>>>
                        paraDefTtlBillOutput.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.DefTtlBillOutput);
                        paraDefDtlBillOutput.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.DefDtlBillOutput);
                        paraDefSlTtlBillOutput.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.DefSlTtlBillOutput);
                        // --- ADD  ���r��  2010/02/05 ----------<<<<<
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
        /// <param name="allDefSetWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.21</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, AllDefSetWork allDefSetWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = " WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.EnterpriseCode);

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
        /// �N���X�i�[���� Reader �� AllDefSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>AllDefSetWork</returns>
        /// <remarks>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.21</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        /// </remarks>
        private AllDefSetWork CopyToAllDefSetWorkFromReader(ref SqlDataReader myReader)
        {
            AllDefSetWork allDefSetWork = new AllDefSetWork();

            #region �N���X�֊i�[
            allDefSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            allDefSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            allDefSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            allDefSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            allDefSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            allDefSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            allDefSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            allDefSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            allDefSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            allDefSetWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
            allDefSetWork.DefDspCustTtlDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFDSPCUSTTTLDAYRF"));
            allDefSetWork.DefDspCustClctMnyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFDSPCUSTCLCTMNYDAYRF"));
            allDefSetWork.DefDspClctMnyMonthCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFDSPCLCTMNYMONTHCDRF"));
            allDefSetWork.IniDspPrslOrCorpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INIDSPPRSLORCORPCDRF"));
            allDefSetWork.InitDspDmDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INITDSPDMDIVRF"));
            allDefSetWork.DefDspBillPrtDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFDSPBILLPRTDIVCDRF"));
            // �� 2008.01.29 980081 a
            allDefSetWork.EraNameDispCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD1RF"));
            allDefSetWork.EraNameDispCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD2RF"));
            allDefSetWork.EraNameDispCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD3RF"));
            allDefSetWork.GoodsNoInpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSNOINPDIVRF"));
            allDefSetWork.CnsTaxAutoCorrDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNSTAXAUTOCORRDIVRF"));
            allDefSetWork.RemainCntMngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REMAINCNTMNGDIVRF"));
            allDefSetWork.MemoMoveDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MEMOMOVEDIVRF"));
            allDefSetWork.RemCntAutoDspDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REMCNTAUTODSPDIVRF"));
            allDefSetWork.TtlAmntDspRateDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDSPRATEDIVCDRF"));
            // �� 2008.01.29 980081 a
            // --- ADD  ���r��  2010/01/25 ---------->>>>>
            allDefSetWork.DefTtlBillOutput = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFTTLBILLOUTPUTRF"));
            allDefSetWork.DefDtlBillOutput = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFDTLBILLOUTPUTRF"));
            allDefSetWork.DefSlTtlBillOutput = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFSLTTLBILLOUTPUTRF"));
            // --- ADD  ���r��  2010/01/25 ----------<<<<<
            #endregion

            return allDefSetWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.21</br>
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
