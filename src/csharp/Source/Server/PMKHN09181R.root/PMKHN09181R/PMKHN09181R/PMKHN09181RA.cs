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
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �[���Ǘ��}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �[���Ǘ��}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350�@�N��@����</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    [Serializable]
    public class PosTerminalMgDB : RemoteDB, IPosTerminalMgDB
    {
        /// <summary>
        /// �[���Ǘ��}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public PosTerminalMgDB()
            :
            base("PMKHN09174D", "Broadleaf.Application.Remoting.ParamData.posTerminalMgWork", "POSTERMINALMGRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̒[���Ǘ��}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="posTerminalMgWork">��������</param>
        /// <param name="paraposTerminalMgWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒[���Ǘ��}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int Search(out object posTerminalMgWork, object paraposTerminalMgWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            posTerminalMgWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchPosTerminalMgProc(out posTerminalMgWork, paraposTerminalMgWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PosTerminalMgDB.Search");
                posTerminalMgWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̒[���Ǘ��}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objsposTerminalMgWork">��������</param>
        /// <param name="paraposTerminalMgWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒[���Ǘ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int SearchPosTerminalMgProc(out object objsposTerminalMgWork, object paraposTerminalMgWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            PosTerminalMgServerWork posTerminalMgWork = null; 

            ArrayList posTerminalMgWorkList = paraposTerminalMgWork as ArrayList;
            if (posTerminalMgWorkList == null)
            {
                posTerminalMgWork = paraposTerminalMgWork as PosTerminalMgServerWork;
            }
            else
            {
                if (posTerminalMgWorkList.Count > 0)
                    posTerminalMgWork = posTerminalMgWorkList[0] as PosTerminalMgServerWork;
            }

            int status = SearchPosTerminalMgProc(out posTerminalMgWorkList, posTerminalMgWork, readMode, logicalMode, ref sqlConnection);
            objsposTerminalMgWork = posTerminalMgWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̒[���Ǘ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="posTerminalMgWorkList">��������</param>
        /// <param name="posTerminalMgWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒[���Ǘ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int SearchPosTerminalMgProc(out ArrayList posTerminalMgWorkList, PosTerminalMgServerWork posTerminalMgWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchPosTerminalMgProcProc(out posTerminalMgWorkList, posTerminalMgWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̒[���Ǘ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="posTerminalMgWorkList">��������</param>
        /// <param name="posTerminalMgWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒[���Ǘ��}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        private int SearchPosTerminalMgProcProc(out ArrayList posTerminalMgWorkList, PosTerminalMgServerWork posTerminalMgWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;

                #region SELECT��
                selectTxt += " SELECT CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,CASHREGISTERNORF " + Environment.NewLine;
                selectTxt += "         ,POSPCTERMCDRF " + Environment.NewLine;
                selectTxt += "         ,USELANGUAGEDIVCDRF " + Environment.NewLine;
                selectTxt += "         ,USECULTUREDIVCDRF " + Environment.NewLine;
                selectTxt += "         ,MACHINEIPADDRRF " + Environment.NewLine;
                selectTxt += "         ,MACHINENAMERF " + Environment.NewLine;
                selectTxt += "  FROM POSTERMINALMGRF " + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, posTerminalMgWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {


                    al.Add(CopyToscmPriorStWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            posTerminalMgWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ������SCM�D��ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">scmPriorStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒[���Ǘ��}�X�^��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                PosTerminalMgServerWork posTerminalMgWork = new PosTerminalMgServerWork();

                // XML�̓ǂݍ���
                posTerminalMgWork = (PosTerminalMgServerWork)XmlByteSerializer.Deserialize(parabyte, typeof(PosTerminalMgServerWork));
                if (posTerminalMgWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref posTerminalMgWork, readMode, ref sqlConnection,ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(posTerminalMgWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PosTerminalMgDB.Read");
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
        /// <param name="posTerminalMgWork">posTerminalMgWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������S�[���Ǘ��}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int ReadProc(ref PosTerminalMgServerWork posTerminalMgWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref posTerminalMgWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̒[���Ǘ��}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="posTerminalMgWork">posTerminalMgWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̒[���Ǘ��}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        private int ReadProcProc(ref PosTerminalMgServerWork posTerminalMgWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region SELECT��
                selectTxt += " SELECT CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,CASHREGISTERNORF " + Environment.NewLine;
                selectTxt += "         ,POSPCTERMCDRF " + Environment.NewLine;
                selectTxt += "         ,USELANGUAGEDIVCDRF " + Environment.NewLine;
                selectTxt += "         ,USECULTUREDIVCDRF " + Environment.NewLine;
                selectTxt += "         ,MACHINEIPADDRRF " + Environment.NewLine;
                selectTxt += "         ,MACHINENAMERF " + Environment.NewLine;
                selectTxt += "  FROM POSTERMINALMGRF " + Environment.NewLine;
                selectTxt += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "         AND CASHREGISTERNORF = @FINDCASHREGISTERNO " + Environment.NewLine;
                #endregion�@

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                    SqlParameter findCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);  // �}�V���ԍ�

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);  // ��ƃR�[�h
                    findCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.CashRegisterNo);  // �}�V���ԍ�

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        posTerminalMgWork = CopyToscmPriorStWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// �[���Ǘ��}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="posTerminalMgWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �[���Ǘ��}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int Write(ref object posTerminalMgWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(posTerminalMgWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WritePosTerminalMgProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                PosTerminalMgServerWork paraWork = paraList[0] as PosTerminalMgServerWork;
                
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                posTerminalMgWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PosTerminalMgDB.Write(ref object posTerminalMgWork)");
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
        /// <param name="posTerminalMgWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �[���Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int WritePosTerminalMgProc(ref ArrayList posTerminalMgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WritePosTerminalMgProcProc(ref posTerminalMgWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �[���Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="posTerminalMgWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �[���Ǘ��}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        private int WritePosTerminalMgProcProc(ref ArrayList posTerminalMgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (posTerminalMgWorkList != null)
                {
                    foreach (PosTerminalMgServerWork posTerminalMgWork in posTerminalMgWorkList)
                    {
                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CASHREGISTERNORF = @FINDCASHREGISTERNO", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                        SqlParameter findCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);  // �}�V���ԍ�

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);  // ��ƃR�[�h
                        findCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.CashRegisterNo);  // POS/PC�[���g�p�敪

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != posTerminalMgWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (posTerminalMgWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region UPDATE��
                            string sqlText = string.Empty;

                            sqlText += " UPDATE POSTERMINALMGRF SET  " + Environment.NewLine;
                            sqlText += " CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                            sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "  , CASHREGISTERNORF = @CASHREGISTERNO " + Environment.NewLine;
                            sqlText += "  , POSPCTERMCDRF = @POSPCTERMCD " + Environment.NewLine;
                            sqlText += "  , USELANGUAGEDIVCDRF = @USELANGUAGEDIVCD " + Environment.NewLine;
                            sqlText += "  , USECULTUREDIVCDRF = @USECULTUREDIVCD " + Environment.NewLine;
                            sqlText += "  , MACHINEIPADDRRF = @MACHINEIPADDR " + Environment.NewLine;
                            sqlText += "  , MACHINENAMERF = @MACHINENAME " + Environment.NewLine;
                            sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         AND CASHREGISTERNORF = @FINDCASHREGISTERNO " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);  // ��ƃR�[�h
                            findCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.CashRegisterNo);  // �}�V���ԍ�

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)posTerminalMgWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (posTerminalMgWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region INSERT��
                            string sqlText = string.Empty;
                            sqlText += " INSERT INTO POSTERMINALMGRF " + Environment.NewLine;
                            sqlText += "  (CREATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,ENTERPRISECODERF " + Environment.NewLine;
                            sqlText += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                            sqlText += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                            sqlText += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                            sqlText += "         ,CASHREGISTERNORF " + Environment.NewLine;
                            sqlText += "         ,POSPCTERMCDRF " + Environment.NewLine;
                            sqlText += "         ,USELANGUAGEDIVCDRF " + Environment.NewLine;
                            sqlText += "         ,USECULTUREDIVCDRF " + Environment.NewLine;
                            sqlText += "         ,MACHINEIPADDRRF " + Environment.NewLine;
                            sqlText += "         ,MACHINENAMERF " + Environment.NewLine;
                            sqlText += "  ) " + Environment.NewLine;
                            sqlText += "  VALUES " + Environment.NewLine;
                            sqlText += "  (@CREATEDATETIME " + Environment.NewLine;
                            sqlText += "         ,@UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "         ,@ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         ,@FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "         ,@UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "         ,@UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "         ,@UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "         ,@LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "         ,@CASHREGISTERNO " + Environment.NewLine;
                            sqlText += "         ,@POSPCTERMCD " + Environment.NewLine;
                            sqlText += "         ,@USELANGUAGEDIVCD " + Environment.NewLine;
                            sqlText += "         ,@USECULTUREDIVCD " + Environment.NewLine;
                            sqlText += "         ,@MACHINEIPADDR " + Environment.NewLine;
                            sqlText += "         ,@MACHINENAME " + Environment.NewLine;
                            sqlText += "  )" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)posTerminalMgWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // �쐬����
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // �X�V����
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // �X�V�]�ƈ��R�[�h
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // �X�V�A�Z���u��ID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // �X�V�A�Z���u��ID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // �_���폜�敪
                        SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);  // ���W�ԍ�
                        SqlParameter paraPosPCTermCd = sqlCommand.Parameters.Add("@POSPCTERMCD", SqlDbType.Int);  // POS/PC�[���g�p�敪
                        SqlParameter paraUseLanguageDivCd = sqlCommand.Parameters.Add("@USELANGUAGEDIVCD", SqlDbType.NVarChar);  // �g�p����敪
                        SqlParameter paraUseCultureDivCd = sqlCommand.Parameters.Add("@USECULTUREDIVCD", SqlDbType.NVarChar);  // �g�p�J���`���[�敪
                        SqlParameter paraMachineIpAddr = sqlCommand.Parameters.Add("@MACHINEIPADDR", SqlDbType.NVarChar);  // �[��IP�A�h���X
                        SqlParameter paraMachineName = sqlCommand.Parameters.Add("@MACHINENAME", SqlDbType.NVarChar);  // �[������
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(posTerminalMgWork.CreateDateTime);  // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(posTerminalMgWork.UpdateDateTime);  // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);  // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(posTerminalMgWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.UpdEmployeeCode);  // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.UpdAssemblyId1);  // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.UpdAssemblyId2);  // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.LogicalDeleteCode);  // �_���폜�敪
                        paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.CashRegisterNo);  // ���W�ԍ�
                        paraPosPCTermCd.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.PosPCTermCd);  // POS/PC�[���g�p�敪
                        paraUseLanguageDivCd.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.UseLanguageDivCd);  // �g�p����敪
                        paraUseCultureDivCd.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.UseCultureDivCd);  // �g�p�J���`���[�敪
                        paraMachineIpAddr.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.MachineIpAddr);  // �[��IP�A�h���X
                        paraMachineName.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.MachineName);  // �[������
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(posTerminalMgWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            posTerminalMgWorkList = al;

            return status;
        }

        

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// �[���Ǘ��}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="posTerminalMgWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �[���Ǘ��}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int LogicalDelete(ref object posTerminalMgWork)
        {
            return LogicalDeletePosTerminalMg(ref posTerminalMgWork, 0);
        }

        /// <summary>
        /// �_���폜�[���Ǘ��}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="posTerminalMgWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�[���Ǘ��}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int RevivalLogicalDelete(ref object posTerminalMgWork)
        {
            return LogicalDeletePosTerminalMg(ref posTerminalMgWork, 1);
        }

        /// <summary>
        /// �[���Ǘ��}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="posTerminalMgWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        private int LogicalDeletePosTerminalMg(ref object posTerminalMgWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(posTerminalMgWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeletePosTerminalMgProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "PosTerminalMgDB.LogicalDeletePosTerminalMg :" + procModestr);

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
        /// <param name="posTerminalMgWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �[���Ǘ��}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int LogicalDeletePosTerminalMgProc(ref ArrayList posTerminalMgWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeletePosTerminalMgProcProc(ref posTerminalMgWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �[���Ǘ��}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="posTerminalMgWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        private int LogicalDeletePosTerminalMgProcProc(ref ArrayList posTerminalMgWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (posTerminalMgWorkList != null)
                {
                    foreach (PosTerminalMgServerWork posTerminalMgWork in posTerminalMgWorkList)
                    {
                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CASHREGISTERNORF = @FINDCASHREGISTERNO ", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                        SqlParameter findCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);  // POS/PC�[���g�p�敪

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);  // ��ƃR�[�h
                        findCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.CashRegisterNo);  // POS/PC�[���g�p�敪

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != posTerminalMgWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE POSTERMINALMGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND CASHREGISTERNORF = @FINDCASHREGISTERNO ";
                            //KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);  // ��ƃR�[�h
                            findCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.CashRegisterNo);  // POS/PC�[���g�p�敪

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)posTerminalMgWork;
                            FileHeader fileHeader = new FileHeader(obj);
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
                            else if (logicalDelCd == 0) posTerminalMgWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else posTerminalMgWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) posTerminalMgWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(posTerminalMgWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(posTerminalMgWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }


                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            posTerminalMgWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// SCM�D��ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">SCM�D��ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeletePosTerminalMgProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "SCMPriorStDB.Delete");
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
        /// SCM�D��ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="posTerminalMgWorkList">SCM�D��ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        public int DeletePosTerminalMgProc(ArrayList posTerminalMgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeletePosTerminalMgProcProc(posTerminalMgWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM�D��ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="posTerminalMgWorkList">SCM�D��ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        private int DeletePosTerminalMgProcProc(ArrayList posTerminalMgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                foreach (PosTerminalMgServerWork posTerminalMgWork in posTerminalMgWorkList)
                {
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CASHREGISTERNORF = @FINDCASHREGISTERNO", sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                    SqlParameter findCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);  // POS/PC�[���g�p�敪

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);  // ��ƃR�[�h
                    findCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.CashRegisterNo);  // POS/PC�[���g�p�敪

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != posTerminalMgWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CASHREGISTERNORF = @FINDCASHREGISTERNO";
                        //KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);  // ��ƃR�[�h
                        findCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.CashRegisterNo);  // POS/PC�[���g�p�敪
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
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
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

	    #region [Where���쐬����]
	    /// <summary>
	    /// �������������񐶐��{�����l�ݒ�
	    /// </summary>
	    /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="posTerminalMgWork">���������i�[�N���X</param>
	    /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
	    /// <returns>Where����������</returns>
	    /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>POSPCTERMCDRF
        private string MakeWhereString(ref SqlCommand sqlCommand, PosTerminalMgServerWork posTerminalMgWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //��ƃR�[�h
		    retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);

            // �}�V���ԍ�
            if (posTerminalMgWork.CashRegisterNo != 0)
            {
                retstring += " AND CASHREGISTERNORF=@CASHREGISTERNO ";
                SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.CashRegisterNo);
            }
            
            //�_���폜�敪
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
			    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
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
        /// �N���X�i�[���� Reader �� StockMngTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockMngTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private PosTerminalMgServerWork CopyToscmPriorStWorkFromReader(ref SqlDataReader myReader)
        {
            PosTerminalMgServerWork wkposTerminalMgWork = new PosTerminalMgServerWork();

            #region �N���X�֊i�[
            wkposTerminalMgWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
            wkposTerminalMgWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
            wkposTerminalMgWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // ��ƃR�[�h
            wkposTerminalMgWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkposTerminalMgWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // �X�V�]�ƈ��R�[�h
            wkposTerminalMgWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // �X�V�A�Z���u��ID1
            wkposTerminalMgWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // �X�V�A�Z���u��ID2
            wkposTerminalMgWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // �_���폜�敪
            wkposTerminalMgWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));  // ���W�ԍ�
            wkposTerminalMgWork.PosPCTermCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSPCTERMCDRF"));  // POS/PC�[���g�p�敪
            wkposTerminalMgWork.UseLanguageDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USELANGUAGEDIVCDRF"));  // �g�p����敪
            wkposTerminalMgWork.UseCultureDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USECULTUREDIVCDRF"));  // �g�p�J���`���[�敪
            wkposTerminalMgWork.MachineIpAddr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MACHINEIPADDRRF"));  // �[��IP�A�h���X
            wkposTerminalMgWork.MachineName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MACHINENAMERF"));  // �[������
            #endregion

            return wkposTerminalMgWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            PosTerminalMgServerWork[] posTerminalMgWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is PosTerminalMgServerWork)
                    {
                        PosTerminalMgServerWork wkposTerminalMgWork = paraobj as PosTerminalMgServerWork;
                        if (wkposTerminalMgWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkposTerminalMgWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            posTerminalMgWorkArray = (PosTerminalMgServerWork[])XmlByteSerializer.Deserialize(byteArray, typeof(PosTerminalMgServerWork[]));
                        }
                        catch (Exception) { }
                        if (posTerminalMgWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(posTerminalMgWorkArray);
                        }
                        else
                        {
                            try
                            {
                                PosTerminalMgServerWork wkposTerminalMgWork = (PosTerminalMgServerWork)XmlByteSerializer.Deserialize(byteArray, typeof(PosTerminalMgServerWork));
                                if (wkposTerminalMgWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkposTerminalMgWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //���ɉ������Ȃ�
                }

            return retal;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
