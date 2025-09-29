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

namespace Broadleaf.Application.LocalAccess
{
    /// <summary>
    /// �[���Ǘ��}�X�^���[�J��DB�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �[���Ǘ��}�X�^�̃��[�J��DB���f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20096�@�����@����</br>
    /// <br>Date       : 2007.04.13</br>
    /// <br></br>
    /// <br>Update Note: �e�[�u���̎g�p����敪�t�B�[���h�ǉ��ɔ����C��</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.04.24</br>
    /// <br></br>
    /// <br>Update Note: �o�l.�m�r�p�ɕύX</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.05.30</br>
    /// <br>Update Note: ���ڒǉ�</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2009.05.20</br>
    /// </remarks>
    public class PosTerminalMgLcDB
    {
        /// <summary>
        /// �[���Ǘ��}�X�^���[�J��DB�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        /// </remarks>
        public PosTerminalMgLcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̒[���Ǘ��}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="posTerminalMgWorkList">��������</param>
        /// <param name="paraposTerminalMgWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒[���Ǘ��}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        public int Search(out List<PosTerminalMgWork> posTerminalMgWorkList, PosTerminalMgWork paraposTerminalMgWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            posTerminalMgWorkList = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchPosTerminalMgProcProc(out posTerminalMgWorkList, paraposTerminalMgWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "PosTerminalMgLcDB.Search", 0);
                posTerminalMgWorkList = new List<PosTerminalMgWork>();
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
        /// �w�肳�ꂽ�����̒[���Ǘ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="posterminalmgWorkList">��������</param>
        /// <param name="posterminalmgWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒[���Ǘ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        public int SearchPosTerminalMgProc(out List<PosTerminalMgWork> posterminalmgWorkList, PosTerminalMgWork posterminalmgWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            status = SearchPosTerminalMgProcProc(out posterminalmgWorkList, posterminalmgWork, readMode, logicalMode, ref sqlConnection);

            return status;

        }

        /// <summary>
        /// �w�肳�ꂽ�����̒[���Ǘ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="posterminalmgWorkList">��������</param>
        /// <param name="posterminalmgWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒[���Ǘ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        private int SearchPosTerminalMgProcProc(out List<PosTerminalMgWork> posterminalmgWorkList, PosTerminalMgWork posterminalmgWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlTxt = string.Empty; // 2008.05.30 add

            List<PosTerminalMgWork> listdata = new List<PosTerminalMgWork>();
            try
            {
                // 2008.05.30 upd start -------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM POSTERMINALMGRF  ", sqlConnection);
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,CASHREGISTERNORF" + Environment.NewLine;
                sqlTxt += "    ,POSPCTERMCDRF" + Environment.NewLine;
                sqlTxt += "    ,USELANGUAGEDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,USECULTUREDIVCDRF" + Environment.NewLine;
                // ADD 2009.5.20 ------>>
                sqlTxt += "    ,MACHINEIPADDRRF " + Environment.NewLine;
                sqlTxt += "    ,MACHINENAMERF " + Environment.NewLine;
                // ADD 2009.5.20 ------<<
                sqlTxt += " FROM POSTERMINALMGRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.30 upd end ----------------------------<<

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, posterminalmgWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    listdata.Add(CopyToPosTerminalMgWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "PosTerminalMgLcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)if (!myReader.IsClosed) myReader.Close();
            }

            posterminalmgWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̒[���Ǘ��}�X�^��߂��܂�
        /// </summary>
        /// <param name="posterminalmgWork">PosTerminalMgWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒[���Ǘ��}�X�^��߂��܂�</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        public int Read(ref PosTerminalMgWork posterminalmgWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref posterminalmgWork, readMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "PosTerminalMgLcDB.Read", 0);
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
        /// �w�肳�ꂽ�����̒[���Ǘ��}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="posterminalmgWork">PosTerminalMgWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒[���Ǘ��}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        private int ReadProc(ref PosTerminalMgWork posterminalmgWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    // 2008.05.30 upd start -------------------------->>
                    //string commandText = "SELECT * FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                    string sqlTxt = string.Empty;
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,CASHREGISTERNORF" + Environment.NewLine;
                    sqlTxt += "    ,POSPCTERMCDRF" + Environment.NewLine;
                    sqlTxt += "    ,USELANGUAGEDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,USECULTUREDIVCDRF" + Environment.NewLine;
                    // ADD 2009.5.20 ------>>
                    sqlTxt += "    ,MACHINEIPADDRRF " + Environment.NewLine;
                    sqlTxt += "    ,MACHINENAMERF " + Environment.NewLine;
                    // ADD 2009.5.20 ------<<
                    sqlTxt += " FROM POSTERMINALMGRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    string commandText = sqlTxt;
                    // 2008.05.30 upd end ----------------------------<<
                    // 2008.05.30 del start -------------------------->>
                    //if (posterminalmgWork.SectionCode != string.Empty)
                    //{
                    //    commandText = commandText + "AND SECTIONCODERF=@FINDSECTIONCODE";
                    //    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    //    findParaSectionCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.SectionCode);
                    //}
                    // 2008.05.30 del end ----------------------------<<
                    if (posterminalmgWork.CashRegisterNo != 0)
                    {
                        commandText = commandText + "AND CASHREGISTERNORF=@FINDCASHREGISTERNO";
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);
                    }
                    sqlCommand.CommandText = commandText;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Connection = sqlConnection;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);                    

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);                    

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        posterminalmgWork = CopyToPosTerminalMgWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "PosTerminalMgLcDB.Read", 0);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// �[���Ǘ��}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �[���Ǘ��}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        public int Write(ref List<PosTerminalMgWork> posTerminalMgWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                List<PosTerminalMgWork> paraList = posTerminalMgWorkList;
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WritePosTerminalMgProcProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                posTerminalMgWorkList = paraList;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "PosTerminalMgLcDB.Write(ref object posTerminalMgWork)", 0);
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
        /// �[���Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �[���Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        public int WritePosTerminalMgProc(ref List<PosTerminalMgWork> posTerminalMgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            List<PosTerminalMgWork> paraList = posTerminalMgWorkList;
            if (paraList == null) return status;


            status = WritePosTerminalMgProcProc(ref paraList, ref sqlConnection, ref sqlTransaction);
            return status;
        }


        /// <summary>
        /// �[���Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �[���Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        private int WritePosTerminalMgProcProc(ref List<PosTerminalMgWork> posTerminalMgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            List<PosTerminalMgWork> listdata = new List<PosTerminalMgWork>();
            string sqlTxt = string.Empty; // 2008.05.30 add
            try
            {
                if (posTerminalMgWorkList != null)
                {
                    for (int i = 0; i < posTerminalMgWorkList.Count; i++)
                    {
                        PosTerminalMgWork posterminalmgWork = posTerminalMgWorkList[i];

                        //Select�R�}���h�̐���
                        // 2008.05.30 upd start --------------------------------------->>
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO", sqlConnection, sqlTransaction);
                        sqlTxt = string.Empty;
                        sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += " FROM POSTERMINALMGRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.30 upd end -----------------------------------------<<

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // 2008.05.30 del
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);
                        //findParaSectionCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.SectionCode);           // 2008.05.30 del
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != posterminalmgWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (posterminalmgWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            // 2008.05.30 upd start --------------------------------------->>
                            //sqlCommand.CommandText = "UPDATE POSTERMINALMGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , CASHREGISTERNORF=@CASHREGISTERNO , POSPCTERMCDRF = @POSPCTERMCD , USELANGUAGEDIVCDRF = @USELANGUAGEDIVCD , USECULTUREDIVCDRF = @USECULTUREDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO";
                            sqlTxt += "UPDATE POSTERMINALMGRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " , CASHREGISTERNORF=@CASHREGISTERNO" + Environment.NewLine;
                            sqlTxt += " , POSPCTERMCDRF=@POSPCTERMCD" + Environment.NewLine;
                            sqlTxt += " , USELANGUAGEDIVCDRF=@USELANGUAGEDIVCD" + Environment.NewLine;
                            sqlTxt += " , USECULTUREDIVCDRF=@USECULTUREDIVCD" + Environment.NewLine;
                            // ADD 2009.5.20 ------>>
                            sqlTxt += " , MACHINEIPADDRRF = @MACHINEIPADDR" + Environment.NewLine;
                            sqlTxt += " , MACHINENAMERF = @MACHINENAME" + Environment.NewLine;
                            // ADD 2009.5.20 ------<<
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.30 upd end -----------------------------------------<<
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);
                            //findParaSectionCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.SectionCode); // 2008.05.30 del
                            findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)posterminalmgWork;
                            ClientFileHeader fileHeader = new ClientFileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (posterminalmgWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //�V�K�쐬����SQL���𐶐�
                            // 2008.05.30 upd start --------------------------------------->>
                            //sqlCommand.CommandText = "INSERT INTO POSTERMINALMGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CASHREGISTERNORF, POSPCTERMCDRF, USELANGUAGEDIVCDRF, USECULTUREDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @CASHREGISTERNO, @POSPCTERMCD, @USELANGUAGEDIVCD, @USECULTUREDIVCD)";
                            sqlTxt += "INSERT INTO POSTERMINALMGRF" + Environment.NewLine;
                            sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,CASHREGISTERNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSPCTERMCDRF" + Environment.NewLine;
                            sqlTxt += "    ,USELANGUAGEDIVCDRF" + Environment.NewLine;
                            sqlTxt += "    ,USECULTUREDIVCDRF" + Environment.NewLine;
                            // ADD 2009.5.20 ------>>
                            sqlTxt += "    ,MACHINEIPADDRRF" + Environment.NewLine;
                            sqlTxt += "    ,MACHINENAMERF" + Environment.NewLine;
                            // ADD 2009.5.20 ------<<
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
                            sqlTxt += "    ,@CASHREGISTERNO" + Environment.NewLine;
                            sqlTxt += "    ,@POSPCTERMCD" + Environment.NewLine;
                            sqlTxt += "    ,@USELANGUAGEDIVCD" + Environment.NewLine;
                            sqlTxt += "    ,@USECULTUREDIVCD" + Environment.NewLine;
                            // ADD 2009.5.20 ------>>
                            sqlTxt += "    ,@MACHINEIPADDR" + Environment.NewLine;
                            sqlTxt += "    ,@MACHINENAME" + Environment.NewLine;
                            // ADD 2009.5.20 ------<<
                            sqlTxt += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.30 upd end -----------------------------------------<<
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)posterminalmgWork;
                            ClientFileHeader fileHeader = new ClientFileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                        SqlParameter paraPosPCTermCd = sqlCommand.Parameters.Add("@POSPCTERMCD", SqlDbType.Int);
                        SqlParameter paraUseLanguageDivCd = sqlCommand.Parameters.Add("@USELANGUAGEDIVCD", SqlDbType.NVarChar);
                        SqlParameter paraUseCultureDivCd = sqlCommand.Parameters.Add("@USECULTUREDIVCD", SqlDbType.NVarChar);
                        // ADD 2009.5.20 ------>>
                        SqlParameter paraMachineIpAddr = sqlCommand.Parameters.Add("@MACHINEIPADDR", SqlDbType.NVarChar);  // �[��IP�A�h���X
                        SqlParameter paraMachineName = sqlCommand.Parameters.Add("@MACHINENAME", SqlDbType.NVarChar);  // �[������
                        // ADD 2009.5.20 ------<<
                        #endregion
                        
                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(posterminalmgWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(posterminalmgWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(posterminalmgWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.LogicalDeleteCode);
                        paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);
                        paraPosPCTermCd.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.PosPCTermCd);
                        paraUseLanguageDivCd.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UseLanguageDivCd);
                        paraUseCultureDivCd.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UseCultureDivCd);
                        // ADD 2009.5.20 ------>>
                        paraMachineIpAddr.Value = SqlDataMediator.SqlSetString(posterminalmgWork.MachineIpAddr);  // �[��IP�A�h���X
                        paraMachineName.Value = SqlDataMediator.SqlSetString(posterminalmgWork.MachineName);  // �[������
                        // ADD 2009.5.20 ------<<
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        listdata.Add(posterminalmgWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "PosTerminalMgLcDB.WritePosTerminalMgProc", 0);
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

            posTerminalMgWorkList = listdata;

            return status;
        }
        #endregion

        #region [ChangeLanguage]
        /* ����݂̂̕ύX��ʂ͂Ȃ����߁A�R�����g�A�E�g����B�����I�ɕK�v�ɂȂ�ƃ����e���Ďg�����ƁB
         
        /// <summary>
        /// ����ݒ�ύX�݂̂̏������s���܂�
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWork�I�u�W�F�N�g�̃��X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����ݒ�ύX�݂̂̏������s���܂�</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.04.24</br>
        public int ChangeLanguage(List<PosTerminalMgWork> posTerminalMgWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                List<PosTerminalMgWork> paraList = posTerminalMgWorkList;
                if (paraList == null)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    return status;
                }
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = ChangeLanguageProc(paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                posTerminalMgWorkList = paraList;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "PosTerminalMgLcDB.ChangeLanguage(object posTerminalMgWork)", 0);
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
        /// �[���Ǘ��}�X�^���̌���ݒ���X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �[���Ǘ��}�X�^���̌���ݒ���X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.04.24</br>
        private int ChangeLanguageProc(List<PosTerminalMgWork> posTerminalMgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            List<PosTerminalMgWork> listdata = new List<PosTerminalMgWork>();
            try
            {
                if (posTerminalMgWorkList != null)
                {
                    for (int i = 0; i < posTerminalMgWorkList.Count; i++)
                    {
                        PosTerminalMgWork posterminalmgWork = posTerminalMgWorkList[i];

                        string SqlText = "";
                        SqlText += "SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO";
                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(SqlText, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.SectionCode);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != posterminalmgWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (posterminalmgWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE POSTERMINALMGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , USELANGUAGEDIVCDRF = @USELANGUAGEDIVCD USECULTUREDIVCDRF = @USECULTUREDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.SectionCode);
                            findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)posterminalmgWork;
                            ClientFileHeader fileHeader = new ClientFileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraUseLanguageDivCd = sqlCommand.Parameters.Add("@USELANGUAGEDIVCD", SqlDbType.NVarChar);
                        SqlParameter paraUseCultureDivCd = sqlCommand.Parameters.Add("@USECULTUREDIVCD", SqlDbType.NVarChar);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(posterminalmgWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UpdAssemblyId2);
                        paraUseLanguageDivCd.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UseLanguageDivCd);
                        paraUseCultureDivCd.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UseCultureDivCd);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        listdata.Add(posterminalmgWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "PosTerminalMgLcDB.ChangeLanguageProc", 0);
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

            posTerminalMgWorkList = listdata;

            return status;
        }
        */
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// �[���Ǘ��}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �[���Ǘ��}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        public int LogicalDelete(ref List<PosTerminalMgWork> posTerminalMgWorkList)
        {
            return LogicalDeletePosTerminalMg(ref posTerminalMgWorkList, 0);
        }

        /// <summary>
        /// �_���폜�[���Ǘ��}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�[���Ǘ��}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        public int RevivalLogicalDelete(ref List<PosTerminalMgWork> posTerminalMgWorkList)
        {
            return LogicalDeletePosTerminalMg(ref posTerminalMgWorkList, 1);
        }

        /// <summary>
        /// �[���Ǘ��}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �[���Ǘ��}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        private int LogicalDeletePosTerminalMg(ref List<PosTerminalMgWork> posTerminalMgWorkList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                List<PosTerminalMgWork> paraList = posTerminalMgWorkList;
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeletePosTerminalMgProcProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                WriteErrorLog(ex, "PosTerminalMgLcDB.LogicalDeletePosTerminalMg :" + procModestr, 0);

                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// �[���Ǘ��}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �[���Ǘ��}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        public int LogicalDeletePosTerminalMgProc(ref List<PosTerminalMgWork> posTerminalMgWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            List<PosTerminalMgWork> paraList = posTerminalMgWorkList;
            if (paraList == null) return status;

            status = LogicalDeletePosTerminalMgProcProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);
            return status;
        }

        /// <summary>
        /// �[���Ǘ��}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �[���Ǘ��}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        private int LogicalDeletePosTerminalMgProcProc(ref List<PosTerminalMgWork> posTerminalMgWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            List<PosTerminalMgWork> listdata = new List<PosTerminalMgWork>();
            string sqlTxt = string.Empty; // 2008.05.30 add

            try
            {
                if (posTerminalMgWorkList != null)
                {
                    for (int i = 0; i < posTerminalMgWorkList.Count; i++)
                    {
                        PosTerminalMgWork posterminalmgWork = posTerminalMgWorkList[i];

                        //Select�R�}���h�̐���
                        // 2008.05.30 upd start --------------------------------------->>
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO", sqlConnection, sqlTransaction);
                        sqlTxt = string.Empty;
                        sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += " FROM POSTERMINALMGRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.30 upd end -----------------------------------------<<

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // 2008.05.30 del
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);
                        //findParaSectionCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.SectionCode); // 2008.05.30 del
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != posterminalmgWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            // 2008.05.30 upd start --------------------------------------->>
                            //sqlCommand.CommandText = "UPDATE POSTERMINALMGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO";
                            sqlTxt += "UPDATE POSTERMINALMGRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.30 upd end -----------------------------------------<<
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);
                            //findParaSectionCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.SectionCode); // 2008.05.30 del
                            findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)posterminalmgWork;
                            ClientFileHeader fileHeader = new ClientFileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();

                        //�_���폜���[�h�̏ꍇ
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) posterminalmgWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else posterminalmgWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) posterminalmgWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
                                sqlCommand.Cancel();
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(posterminalmgWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        listdata.Add(posterminalmgWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "PosTerminalMgLcDB.LogicalDeletePosTerminalMgProc", 0);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            posTerminalMgWorkList = listdata;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// �[���Ǘ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="posTerminalMgWorkList">�[���Ǘ��}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �[���Ǘ��}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        public int Delete(List<PosTerminalMgWork> posTerminalMgWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {

                List<PosTerminalMgWork> paraList = posTerminalMgWorkList;
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeletePosTerminalMgProcProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                WriteErrorLog(ex, "PosTerminalMgLcDB.Delete", 0);

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
        /// �[���Ǘ��}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="posterminalmgWorkList">�[���Ǘ��}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �[���Ǘ��}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        public int DeletePosTerminalMgProc(List<PosTerminalMgWork> posterminalmgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            List<PosTerminalMgWork> paraList = posterminalmgWorkList;
            if (paraList == null) return status;
            status = DeletePosTerminalMgProcProc(paraList, ref sqlConnection, ref sqlTransaction);
            return status;

        }


        /// <summary>
        /// �[���Ǘ��}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="posterminalmgWorkList">�[���Ǘ��}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �[���Ǘ��}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        private int DeletePosTerminalMgProcProc(List<PosTerminalMgWork> posterminalmgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlTxt = string.Empty; // 2008.05.30 add
            try
            {

                for (int i = 0; i < posterminalmgWorkList.Count; i++)
                {
                    PosTerminalMgWork posterminalmgWork = posterminalmgWorkList[i];
                    // 2008.05.30 upd start ------------------------------->>
                    //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO", sqlConnection, sqlTransaction);
                    sqlTxt = string.Empty;
                    sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += " FROM POSTERMINALMGRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                    // 2008.05.30 upd end ---------------------------------<<

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // 2008.05.30 del
                    SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);
                    //findParaSectionCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.SectionCode); // 2008.05.30 del
                    findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);


                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != posterminalmgWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        // 2008.05.30 upd start ------------------------------->>
                        //sqlCommand.CommandText = "DELETE FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO";
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM POSTERMINALMGRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.30 upd end ---------------------------------<<

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);
                        //findParaSectionCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.SectionCode); // 2008.05.30 del
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "PosTerminalMgLcDB.DeletePosTerminalMgProc", 0);
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
        /// <param name="posTerminalMgWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, PosTerminalMgWork posTerminalMgWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);

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
        /// �N���X�i�[���� Reader �� PosTerminalMgWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PosTerminalMgWork</returns>
        /// <remarks>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        /// </remarks>
        private PosTerminalMgWork CopyToPosTerminalMgWorkFromReader(ref SqlDataReader myReader)
        {
            PosTerminalMgWork wkPosTerminalMgWork = new PosTerminalMgWork();

            #region �N���X�֊i�[
            wkPosTerminalMgWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkPosTerminalMgWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkPosTerminalMgWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkPosTerminalMgWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkPosTerminalMgWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkPosTerminalMgWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkPosTerminalMgWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkPosTerminalMgWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            //wkPosTerminalMgWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkPosTerminalMgWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
            wkPosTerminalMgWork.PosPCTermCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSPCTERMCDRF"));
            wkPosTerminalMgWork.UseLanguageDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USELANGUAGEDIVCDRF"));
            wkPosTerminalMgWork.UseCultureDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USECULTUREDIVCDRF"));
            // ADD 2009.5.20 ------>>
            wkPosTerminalMgWork.MachineIpAddr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MACHINEIPADDRRF"));  // �[��IP�A�h���X
            wkPosTerminalMgWork.MachineName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MACHINENAMERF"));  // �[������
            // ADD 2009.5.20 ------<<
            #endregion

            return wkPosTerminalMgWork;
        }
        #endregion

        #region [�o�b�N�A�b�v�[���Ǘ��}�X�^���֘A�����[���݂͕s�v]
        //PM.NS�͎g��Ȃ��\��ł��邪�A�O�̂��ߎc���Ă����B
#if false   
        #region [BkReWrite]
        /// <summary>
        /// �o�b�N�A�b�v�f�[�^���[���Ǘ��}�X�^�������ɖ߂��܂�
        /// </summary>
        /// <param name="posBkTerminalMgWorkList">BkPosTerminalMgWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �o�b�N�A�b�v�f�[�^���[���Ǘ��}�X�^�������ɖ߂��܂�</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.07.04</br>
        public int BkReWrite(ref ArrayList posBkTerminalMgWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                ArrayList paraList = posBkTerminalMgWorkList;
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteBkRePosTerminalMgProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                posBkTerminalMgWorkList = paraList;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "PosTerminalMgLcDB.BkReWrite(ref object posBkTerminalMgWork)", 0);
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
        /// �o�b�N�A�b�v�f�[�^���[���Ǘ��}�X�^�������ɖ߂��܂� (�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="posBkTerminalMgWorkList">PosBkReTerminalMgWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �o�b�N�A�b�v�f�[�^���[���Ǘ��}�X�^�������ɖ߂��܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.07.03</br>
        public int WriteBkRePosTerminalMgProc(ref ArrayList posBkTerminalMgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList listdata = new ArrayList();
            try
            {
                if (posBkTerminalMgWorkList != null)
                {
                    for (int i = 0; i < posBkTerminalMgWorkList.Count; i++)
                    {
                        BkPosTerminalMgWork bkposterminalmgWork = (BkPosTerminalMgWork)posBkTerminalMgWorkList[i];

                        //�o�b�N�A�b�v�̓���������Ȃ��߁A���ӂ��K�v
                        //��ƁA���_�A���W�ԍ����v���C�}���ɂȂ��Ă��邪�A��ʂ̐���ɂĊ�Ƃ�1�s�����f�[�^���o���Ȃ��d�l�炵��
                        //�������R�[�h�`�F�b�N�͊�ƃR�[�h�̂�

                        //Select�R�}���h�̐���
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO", sqlConnection, sqlTransaction);
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        //SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bkposterminalmgWork.EnterpriseCode);
                        //findParaSectionCode.Value = SqlDataMediator.SqlSetString(bkposterminalmgWork.SectionCode);
                        //findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(bkposterminalmgWork.CashRegisterNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
 
                            //sqlCommand.CommandText = "UPDATE POSTERMINALMGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , CASHREGISTERNORF=@CASHREGISTERNO , POSPCTERMCDRF = @POSPCTERMCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO";
                            sqlCommand.CommandText = "UPDATE POSTERMINALMGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , CASHREGISTERNORF=@CASHREGISTERNO , POSPCTERMCDRF = @POSPCTERMCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bkposterminalmgWork.EnterpriseCode);
                            //findParaSectionCode.Value = SqlDataMediator.SqlSetString(bkposterminalmgWork.SectionCode);
                            //findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(bkposterminalmgWork.CashRegisterNo);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)bkposterminalmgWork;
                            ClientFileHeader fileHeader = new ClientFileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
 
                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = "INSERT INTO POSTERMINALMGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CASHREGISTERNORF, POSPCTERMCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @CASHREGISTERNO, @POSPCTERMCD)";
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)bkposterminalmgWork;
                            ClientFileHeader fileHeader = new ClientFileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

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
                        SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                        SqlParameter paraPosPCTermCd = sqlCommand.Parameters.Add("@POSPCTERMCD", SqlDbType.Int);
        #endregion

        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(bkposterminalmgWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(bkposterminalmgWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(bkposterminalmgWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(bkposterminalmgWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(bkposterminalmgWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(bkposterminalmgWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(bkposterminalmgWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(bkposterminalmgWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(bkposterminalmgWork.SectionCode);
                        paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(bkposterminalmgWork.CashRegisterNo);
                        paraPosPCTermCd.Value = SqlDataMediator.SqlSetInt32(bkposterminalmgWork.PosPCTermCd);
        #endregion

                        sqlCommand.ExecuteNonQuery();
                        listdata.Add(bkposterminalmgWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "PosTerminalMgLcDB.WriteBkPosTerminalMgProc", 0);
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

            posBkTerminalMgWorkList = listdata;

            return status;
        }
        #endregion

        #region [BkSearch]
        /// <summary>
        /// �w�肳�ꂽ�����̃o�b�N�A�b�v�p�[���Ǘ��}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="bkposTerminalMgArrayList">��������</param>
        /// <param name="paraposTerminalMgWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃o�b�N�A�b�v�p�[���Ǘ��}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        public int BkSearch(out ArrayList bkposTerminalMgArrayList, PosTerminalMgWork paraposTerminalMgWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //List<BkPosTerminalMgWork> bkposTerminalMgWorkList = null;
            List<PosTerminalMgWork> posTerminalMgWorkList = null;
            bkposTerminalMgArrayList = null;
            ArrayList al = new ArrayList();

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchPosTerminalMgProc(out posTerminalMgWorkList, paraposTerminalMgWork, readMode, logicalMode, ref sqlConnection);
                
                //�o�b�N�A�b�v�f�[�^�p�ɉ��H
                if (posTerminalMgWorkList != null)
                {
                    for (int i = 0; i < posTerminalMgWorkList.Count; i++)
                    {
                        PosTerminalMgWork posTerminalMgWork = posTerminalMgWorkList[i];
                        BkPosTerminalMgWork bkposTerminalMgWork = new BkPosTerminalMgWork();
                        bkposTerminalMgWork = CopyToBkPosTerminalMgWorkFromPosTerminalMgWork(posTerminalMgWork);
                        al.Add(bkposTerminalMgWork);
                    }
                }
                bkposTerminalMgArrayList = al;
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "PosTerminalMgLcDB.BkSearch", 0);
                posTerminalMgWorkList = new List<PosTerminalMgWork>();
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

        #endregion

        #region [�o�b�N�A�b�v�p�N���X�ϊ�����]
        /// <summary>
        /// �N���X�i�[���� PosTerminalMgWork �� BkPosTerminalMgWork
        /// </summary>
        /// <param name="posTerminalMgWork">posTerminalMgWork</param>
        /// <returns>BkPosTerminalMgWork</returns>
        /// <remarks>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
        /// </remarks>
        private BkPosTerminalMgWork CopyToBkPosTerminalMgWorkFromPosTerminalMgWork(PosTerminalMgWork posTerminalMgWork)
        {
            BkPosTerminalMgWork wkBkPosTerminalMgWork = new BkPosTerminalMgWork();

        #region �N���X�֊i�[
            wkBkPosTerminalMgWork.CreateDateTime = posTerminalMgWork.CreateDateTime;
            wkBkPosTerminalMgWork.UpdateDateTime = posTerminalMgWork.UpdateDateTime;
            wkBkPosTerminalMgWork.EnterpriseCode = posTerminalMgWork.EnterpriseCode;
            wkBkPosTerminalMgWork.FileHeaderGuid = posTerminalMgWork.FileHeaderGuid;
            wkBkPosTerminalMgWork.UpdEmployeeCode = posTerminalMgWork.UpdEmployeeCode;
            wkBkPosTerminalMgWork.UpdAssemblyId1 = posTerminalMgWork.UpdAssemblyId1;
            wkBkPosTerminalMgWork.UpdAssemblyId2 = posTerminalMgWork.UpdAssemblyId2;
            wkBkPosTerminalMgWork.LogicalDeleteCode = posTerminalMgWork.LogicalDeleteCode;
            wkBkPosTerminalMgWork.SectionCode = posTerminalMgWork.SectionCode;
            wkBkPosTerminalMgWork.CashRegisterNo = posTerminalMgWork.CashRegisterNo;
            wkBkPosTerminalMgWork.PosPCTermCd = posTerminalMgWork.PosPCTermCd; 
        #endregion

            return wkBkPosTerminalMgWork;
        }
        #endregion
#endif
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20096�@�����@����</br>
        /// <br>Date       : 2007.04.13</br>
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
