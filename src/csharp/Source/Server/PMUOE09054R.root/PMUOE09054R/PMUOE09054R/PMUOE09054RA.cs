//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : UOE�ڑ�����}�X�^�����e�i���X
// �v���O�����T�v   : UOE�ڑ�����}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : caowj
// �� �� ��  2010/07/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
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
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// UOE�ڑ�����DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE�ڑ�����̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : caowj</br>
    /// <br>Date       : 2010/07/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class UOEConnectInfoDB : RemoteDB, IUOEConnectInfoDB
    {
        #region constructor
        /// <summary>
        /// UOE�ڑ�����DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        public UOEConnectInfoDB()
            :
            base("PMUOE09056D", "Broadleaf.Application.Remoting.ParamData.UOEConnectInfoWork", "UOECONNECTINFORF")
        {
        }
        #endregion

        #region Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h��UOE�ڑ�����LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��UOE�ڑ�����LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        public int Search(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            try
            {
                return SearchProc(out retobj, paraobj, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UOEConnectInfoDB.Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)");
                retobj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h��UOE�ڑ�����LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��UOE�ڑ�����LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        private int SearchProc(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            UOEConnectInfoWork uOEConnectInfoWork = null;
            UOEConnectInfoWork wkUOEConnectInfoWork = null;

            retobj = null;

            ArrayList al = new ArrayList();
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                uOEConnectInfoWork = paraobj as UOEConnectInfoWork;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //�f�[�^�Ǎ�
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ", sqlConnection);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ", sqlConnection);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection);
                }
                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    wkUOEConnectInfoWork = new UOEConnectInfoWork();

                    #region �l�̃Z�b�g

                    wkUOEConnectInfoWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkUOEConnectInfoWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkUOEConnectInfoWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkUOEConnectInfoWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkUOEConnectInfoWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkUOEConnectInfoWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkUOEConnectInfoWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkUOEConnectInfoWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkUOEConnectInfoWork.CommAssemblyId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMASSEMBLYIDRF"));
                    wkUOEConnectInfoWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
                    wkUOEConnectInfoWork.SocketCommPort = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SOCKETCOMMPORTRF"));
                    wkUOEConnectInfoWork.ReceiveComputerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVECOMPUTERNMRF"));
                    wkUOEConnectInfoWork.ClientTimeOut = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLIENTTIMEOUTRF"));

                    #endregion

                    al.Add(wkUOEConnectInfoWork);

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
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retobj = al;
            return status;
        }
        #endregion

        #region Search(out ArrayList retArray,UOEConnectInfoWork uOEConnectInfoWork, int readMode,ConstantManagement.LogicalMode logicalMode , ref SqlConnection sqlConnection)

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h��UOE�ڑ�����LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retArray">��������</param>
        /// <param name="uOEConnectInfoWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��UOE�ڑ�����LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        public int Search(out ArrayList retArray, UOEConnectInfoWork uOEConnectInfoWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            try
            {
                UOEConnectInfoWork wkUOEConnectInfoWork = null;
                retArray = null;

                ArrayList al = new ArrayList();
                try
                {
                    //�f�[�^�Ǎ�
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ", sqlConnection);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ", sqlConnection);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection);
                    }
                    SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        wkUOEConnectInfoWork = new UOEConnectInfoWork();
                        #region �l�̃Z�b�g
                        wkUOEConnectInfoWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        wkUOEConnectInfoWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        wkUOEConnectInfoWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        wkUOEConnectInfoWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        wkUOEConnectInfoWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        wkUOEConnectInfoWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        wkUOEConnectInfoWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        wkUOEConnectInfoWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        wkUOEConnectInfoWork.CommAssemblyId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMASSEMBLYIDRF"));
                        wkUOEConnectInfoWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
                        wkUOEConnectInfoWork.SocketCommPort = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SOCKETCOMMPORTRF"));
                        wkUOEConnectInfoWork.ReceiveComputerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVECOMPUTERNMRF"));
                        wkUOEConnectInfoWork.ClientTimeOut = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLIENTTIMEOUTRF"));

                        #endregion

                        al.Add(wkUOEConnectInfoWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                catch (SqlException ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                }

                retArray = al;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UOEConnectInfoDB.Search(out ArrayList retArray,UOEConnectInfoWork uOEConnectInfoWork, int readMode,ConstantManagement.LogicalMode logicalMode , ref SqlConnection sqlConnection)");
                retArray = new ArrayList();
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region Read(ref byte[] parabyte, int readMode)

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h��UOE�ڑ������߂��܂�
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��UOE�ڑ������߂��܂�</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        public int Read(ref byte[] parabyte, int readMode)
        {
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                UOEConnectInfoWork uOEConnectInfoWork = new UOEConnectInfoWork();

                try
                {
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    // XML�̓ǂݍ���
                    uOEConnectInfoWork = (UOEConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(UOEConnectInfoWork));

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    //Select�R�}���h�̐���
                    using (sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMMASSEMBLYIDRF=@FINDCOMMASSEMBLYID AND CASHREGISTERNORF=@FINDCASHREGISTERNO ", sqlConnection))
                    {
                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCommAssemblyId = sqlCommand.Parameters.Add("@FINDCOMMASSEMBLYID", SqlDbType.NVarChar);
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);
                        findParaCommAssemblyId.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.CommAssemblyId);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.CashRegisterNo);

                        myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                        if (myReader.Read())
                        {
                            #region �l�̃Z�b�g
                            uOEConnectInfoWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                            uOEConnectInfoWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                            uOEConnectInfoWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                            uOEConnectInfoWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                            uOEConnectInfoWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                            uOEConnectInfoWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                            uOEConnectInfoWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                            uOEConnectInfoWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                            uOEConnectInfoWork.CommAssemblyId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMASSEMBLYIDRF"));
                            uOEConnectInfoWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
                            uOEConnectInfoWork.SocketCommPort = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SOCKETCOMMPORTRF"));
                            uOEConnectInfoWork.ReceiveComputerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVECOMPUTERNMRF"));
                            uOEConnectInfoWork.ClientTimeOut = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLIENTTIMEOUTRF"));
                            #endregion
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                }

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(uOEConnectInfoWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UOEConnectInfoDB.Read");
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        #endregion

        #region Search(out byte[] retbyte, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h��UOE�ڑ�����}�X�^LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retbyte">��������</param>
        /// <param name="parabyte">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��UOE�ڑ�����}�X�^LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/27</br>
        /// </remarks>
        public int Search(out byte[] retbyte, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            bool nextData;
            int retTotalCnt;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retbyte = null;
            try
            {
                status = SearchUOEConnectInfoProc(out retbyte, out retTotalCnt, out nextData, parabyte, readMode, logicalMode, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MailInfoSettingDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region SearchUOEConnectInfoProc(out byte[] retbyte, out int retTotalCnt, out bool nextData, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h��UOE�ڑ�����}�X�^LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retbyte">��������</param>
        /// <param name="retTotalCnt">�����Ώۑ�����</param>		
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="parabyte">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��UOE�ڑ�����}�X�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/27</br>
        /// </remarks>
        private int SearchUOEConnectInfoProc(out byte[] retbyte, out int retTotalCnt, out bool nextData, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommandCount = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            UOEConnectInfoWork uOEConnectInfoWork = new UOEConnectInfoWork();
            uOEConnectInfoWork = null;

            retbyte = null;

            //��������0�ŏ�����
            retTotalCnt = 0;

            //�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
            int _readCnt = readCnt;
            if (_readCnt > 0) _readCnt += 1;
            //�����R�[�h�����ŏ�����
            nextData = false;

            ArrayList al = new ArrayList();

            try
            {
                try
                {
                    // XML�̓ǂݍ���
                    uOEConnectInfoWork = (UOEConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(UOEConnectInfoWork));

                    //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                    //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    //SQL������
                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    //�����w�胊�[�h�ňꌏ�ڃ��[�h�̏ꍇ�f�[�^���������擾
                    if (readCnt > 0)
                    {
                        if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                        {
                            sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ", sqlConnection);
                            //�_���폜�敪�ݒ�
                            SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                        }
                        else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                        {
                            sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ", sqlConnection);
                            //�_���폜�敪�ݒ�
                            SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                            if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                            else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                        }
                        else
                        {
                            sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection);
                        }
                        SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);

                        retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
                    }

                    //�f�[�^�Ǎ�
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ", sqlConnection);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ", sqlConnection);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection);
                    }
                    SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    int retCnt = 0;
                    while (myReader.Read())
                    {
                        //�߂�l�J�E���^�J�E���g
                        retCnt += 1;
                        if (readCnt > 0)
                        {
                            //�߂�l�̌������擾�w�������𒴂����ꍇ�I��
                            if (readCnt < retCnt)
                            {
                                nextData = true;
                                break;
                            }
                        }

                        al.Add(CopyToUOEConnectInfoWorkFromReader(ref myReader));

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                catch (SqlException ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                }

                // XML�֕ϊ����A������̃o�C�i����
                UOEConnectInfoWork[] UOEConnectInfoWorks = (UOEConnectInfoWork[])al.ToArray(typeof(UOEConnectInfoWork));
                retbyte = XmlByteSerializer.Serialize(UOEConnectInfoWorks);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UOEConnectInfoDB.SearchUOEConnectInfoProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommandCount != null) sqlCommandCount.Dispose();
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region Write(ref byte[] parabyte)

        /// <summary>
        /// UOE�ڑ������o�^�A�X�V���܂�
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE�ڑ������o�^�A�X�V���܂�</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        public int Write(ref byte[] parabyte)
        {
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                try
                {
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    // XML�̓ǂݍ���
                    UOEConnectInfoWork uOEConnectInfoWork = (UOEConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(UOEConnectInfoWork));

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    //Select�R�}���h�̐���
                    using (sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMMASSEMBLYIDRF=@FINDCOMMASSEMBLYID AND CASHREGISTERNORF=@FINDCASHREGISTERNO ", sqlConnection))
                    {

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCommAssemblyId = sqlCommand.Parameters.Add("@FINDCOMMASSEMBLYID", SqlDbType.NVarChar);
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);
                        findParaCommAssemblyId.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.CommAssemblyId);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.CashRegisterNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != uOEConnectInfoWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (uOEConnectInfoWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (!myReader.IsClosed) myReader.Close();
                                sqlConnection.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE UOECONNECTINFORF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , COMMASSEMBLYIDRF=@COMMASSEMBLYID , CASHREGISTERNORF=@CASHREGISTERNO , SOCKETCOMMPORTRF=@SOCKETCOMMPORT , RECEIVECOMPUTERNMRF=@RECEIVECOMPUTERNM , CLIENTTIMEOUTRF=@CLIENTTIMEOUT WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMMASSEMBLYIDRF=@FINDCOMMASSEMBLYID AND CASHREGISTERNORF=@FINDCASHREGISTERNO ";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);
                            findParaCommAssemblyId.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.CommAssemblyId);
                            findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.CashRegisterNo);
                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uOEConnectInfoWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (uOEConnectInfoWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (!myReader.IsClosed) myReader.Close();
                                sqlConnection.Close();
                                return status;
                            }

                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = "INSERT INTO UOECONNECTINFORF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @COMMASSEMBLYID, @CASHREGISTERNO, @SOCKETCOMMPORT, @RECEIVECOMPUTERNM, @CLIENTTIMEOUT) ";

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uOEConnectInfoWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (!myReader.IsClosed) myReader.Close();

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraCommAssemblyId = sqlCommand.Parameters.Add("@COMMASSEMBLYID", SqlDbType.NVarChar);
                        SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                        SqlParameter paraSocketCommPort = sqlCommand.Parameters.Add("@SOCKETCOMMPORT", SqlDbType.Int);
                        SqlParameter paraReceiveComputerNm = sqlCommand.Parameters.Add("@RECEIVECOMPUTERNM", SqlDbType.NVarChar);
                        SqlParameter paraClientTimeOut = sqlCommand.Parameters.Add("@CLIENTTIMEOUT", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uOEConnectInfoWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uOEConnectInfoWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(uOEConnectInfoWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.LogicalDeleteCode);
                        paraCommAssemblyId.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.CommAssemblyId);
                        paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.CashRegisterNo);
                        paraSocketCommPort.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.SocketCommPort);
                        paraReceiveComputerNm.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.ReceiveComputerNm);
                        paraClientTimeOut.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.ClientTimeOut);
                        sqlCommand.ExecuteNonQuery();

                        // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                        parabyte = XmlByteSerializer.Serialize(uOEConnectInfoWork);

                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UOEConnectInfoDB.Write");
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader.IsClosed == false) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        #endregion

        #region LogicalDelete & RevivalLogicalDelete

        /// <summary>
        /// UOE�ڑ������_���폜���܂�
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE�ڑ������_���폜���܂�</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        public int LogicalDelete(ref byte[] parabyte)
        {
            try
            {
                return LogicalDeleteProc(ref parabyte, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UOEConnectInfoDB.LogicalDelete");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// �_���폜UOE�ڑ�����𕜊����܂�
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �_���폜UOE�ڑ�����𕜊����܂�</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref byte[] parabyte)
        {
            try
            {
                return LogicalDeleteProc(ref parabyte, 1);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UOEConnectInfoDB.RevivalLogicalDelete");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// UOE�ڑ�����̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE�ڑ�����̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        private int LogicalDeleteProc(ref byte[] parabyte, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                // XML�̓ǂݍ���
                UOEConnectInfoWork uOEConnectInfoWork = (UOEConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(UOEConnectInfoWork));

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                using (sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMMASSEMBLYIDRF=@FINDCOMMASSEMBLYID AND CASHREGISTERNORF=@FINDCASHREGISTERNO ", sqlConnection))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCommAssemblyId = sqlCommand.Parameters.Add("@FINDCOMMASSEMBLYID", SqlDbType.NVarChar);
                    SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);
                    findParaCommAssemblyId.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.CommAssemblyId);
                    findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.CashRegisterNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != uOEConnectInfoWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (!myReader.IsClosed) myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }
                        //���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        sqlCommand.CommandText = "UPDATE UOECONNECTINFORF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMMASSEMBLYIDRF=@FINDCOMMASSEMBLYID AND CASHREGISTERNORF=@FINDCASHREGISTERNO ";
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);
                        findParaCommAssemblyId.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.CommAssemblyId);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.CashRegisterNo);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)uOEConnectInfoWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        if (!myReader.IsClosed) myReader.Close();
                        sqlConnection.Close();
                        return status;
                    }
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();

                    //�_���폜���[�h�̏ꍇ
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                            sqlCommand.Cancel();
                            if (!myReader.IsClosed) myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }
                        else if (logicalDelCd == 0) uOEConnectInfoWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                        else uOEConnectInfoWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                    }
                    else
                    {
                        if (logicalDelCd == 1) uOEConnectInfoWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                        else
                        {
                            if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                            else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
                            sqlCommand.Cancel();
                            if (!myReader.IsClosed) myReader.Close();
                            sqlConnection.Close();
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
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uOEConnectInfoWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();

                    // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                    parabyte = XmlByteSerializer.Serialize(uOEConnectInfoWork);
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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader.IsClosed == false) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;

        }
        #endregion

        #region Delete(byte[] parabyte)

        /// <summary>
        /// UOE�ڑ�����𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">UOE�ڑ�����I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : UOE�ڑ�����𕨗��폜���܂�</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        public int Delete(byte[] parabyte)
        {
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                try
                {
                    //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    UOEConnectInfoWork uOEConnectInfoWork = (UOEConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(UOEConnectInfoWork));

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    using (sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMMASSEMBLYIDRF=@FINDCOMMASSEMBLYID AND CASHREGISTERNORF=@FINDCASHREGISTERNO ", sqlConnection))
                    {
                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCommAssemblyId = sqlCommand.Parameters.Add("@FINDCOMMASSEMBLYID", SqlDbType.NVarChar);
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);
                        findParaCommAssemblyId.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.CommAssemblyId);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.CashRegisterNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != uOEConnectInfoWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (!myReader.IsClosed) myReader.Close();
                                sqlConnection.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "DELETE FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMMASSEMBLYIDRF=@FINDCOMMASSEMBLYID AND CASHREGISTERNORF=@FINDCASHREGISTERNO ";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);
                            findParaCommAssemblyId.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.CommAssemblyId);
                            findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.CashRegisterNo);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (!myReader.IsClosed) myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }
                        if (!myReader.IsClosed) myReader.Close();

                        sqlCommand.ExecuteNonQuery();
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UOEConnectInfoDB.Delete");
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader.IsClosed == false) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion

        # region -- �N���X�����o�[�R�s�[���� --
        /// <summary>
        /// UOE�ڑ�����}�X�^�N���X�i�[���� Reader �� UOEConnectInfoWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>UOEConnectInfoWork</returns>
        /// <remarks>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/27</br>
        /// </remarks>
        private UOEConnectInfoWork CopyToUOEConnectInfoWorkFromReader(ref SqlDataReader myReader)
        {
            UOEConnectInfoWork wkUOEConnectInfoWork = new UOEConnectInfoWork();

            #region �N���X�֊i�[
            wkUOEConnectInfoWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkUOEConnectInfoWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkUOEConnectInfoWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkUOEConnectInfoWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkUOEConnectInfoWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkUOEConnectInfoWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkUOEConnectInfoWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkUOEConnectInfoWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkUOEConnectInfoWork.CommAssemblyId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMASSEMBLYIDRF"));
            wkUOEConnectInfoWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
            wkUOEConnectInfoWork.SocketCommPort = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SOCKETCOMMPORTRF"));
            wkUOEConnectInfoWork.ReceiveComputerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVECOMPUTERNMRF"));
            wkUOEConnectInfoWork.ClientTimeOut = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLIENTTIMEOUTRF"));
            #endregion

            return wkUOEConnectInfoWork;
        }
        #endregion
    }
}

