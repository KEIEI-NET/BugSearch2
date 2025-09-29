//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ڑ�����}�X�^�����e�i���X
// �v���O�����T�v   : �ڑ�����}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10901034-00 �쐬�S�� : lyc
// �� �� ��  2013/06/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using System;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using System.Data;
using Broadleaf.Xml.Serialization;
using System.Text;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �ڑ�����ݒ�DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ڑ�����ݒ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : lyc</br>
    /// <br>Date       : 2013/06/26</br>
    /// <br>�Ǘ��ԍ�   : 10901034-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SAndEConnectInfoPrcPrStDB : RemoteDB, ISAndEConnectInfoPrcPrStDB
    {
        /// <summary>
        /// �ڑ�����}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        public SAndEConnectInfoPrcPrStDB()
            : base("PMSAE09036D", "Broadleaf.Application.Remoting.ParamData.ConnectInfoWork", "CONNECTINFORF")
        {

        }

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� ConnectInfoWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>ConnectInfoWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private ConnectInfoWork CopyToConnectInfoWorkFromReader(ref SqlDataReader myReader)
        {
            ConnectInfoWork connectInfoWork = new ConnectInfoWork();

            this.CopyToConnectInfoWorkFromReader(ref myReader, ref connectInfoWork);

            return connectInfoWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� ConnectInfoWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="connectInfoWork">ConnectInfoWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private void CopyToConnectInfoWorkFromReader(ref SqlDataReader myReader, ref ConnectInfoWork connectInfoWork)
        {
            if (myReader != null && connectInfoWork != null)
            {
                # region �N���X�֊i�[
                connectInfoWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                connectInfoWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                connectInfoWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                connectInfoWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                connectInfoWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                connectInfoWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                connectInfoWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                connectInfoWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                connectInfoWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                connectInfoWork.ConnectPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONNECTPASSWORDRF"));
                connectInfoWork.ConnectUserId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONNECTUSERIDRF"));
                connectInfoWork.DaihatsuOrdreDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DAIHATSUORDREDIVRF"));
                connectInfoWork.LoginTimeoutVal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGINTIMEOUTVALRF"));
                connectInfoWork.OrderUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERURLRF"));
                connectInfoWork.StockCheckUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKCHECKURLRF"));
                connectInfoWork.CnectProgramType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNECTPROGRAMTYPERF"));
                connectInfoWork.CnectFileId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CNECTFILEIDRF"));
                connectInfoWork.CnectSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNECTSENDDIVRF"));
                connectInfoWork.CnectObjectDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNECTOBJECTDIVRF"));
                connectInfoWork.RetryCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETRYCNTRF"));
                connectInfoWork.AutoSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOSENDDIVRF"));
                connectInfoWork.BootTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOOTTIMERF"));
                connectInfoWork.SendMachineIpAddr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDMACHINEIPADDRRF"));
                connectInfoWork.SendMachineName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDMACHINENAMERF"));
                connectInfoWork.SendMachineIpAddr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDMACHINEIPADDRRF"));
                connectInfoWork.SAndECnctPass = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SANDECNCTPASSRF"));
                connectInfoWork.SAndECnctUserId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SANDECNCTUSERIDRF"));
                connectInfoWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
                # endregion
            }
        }

        # endregion

        # region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            if (sqlConnection != null)
            {
                // DB�ɐڑ�����Ă��Ȃ��ꍇ�͂����Őڑ�����
                if ((sqlConnection.State & ConnectionState.Open) == 0)
                {
                    sqlConnection.Open();
                }

                // �g�����U�N�V�����̐���(�J�n)
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return sqlTransaction;
        }
        # endregion [�R�l�N�V������������]

        #region IConnectInfoPrcPrStDB �����o

        #region Search
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̐ڑ�����ݒ�LIST��S�Ė߂��܂��B
        /// </summary>
        /// <param name="outConnectInfoPrcPrSt">��������</param>
        /// <param name="paraConnectInfoWork">�p�����[</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̐ڑ�����ݒ�LIST��S�Ė߂��܂��B</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        public int Search(out object outConnectInfoPrcPrSt, object paraConnectInfoWork, int readMode, Broadleaf.Library.Resources.ConstantManagement.LogicalMode logicalMode)
        {     
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList connectInfoPrcPrStList = null;
            ConnectInfoWork connectInfoWork = null;

            outConnectInfoPrcPrSt = new CustomSerializeArrayList();

            try
            {
                connectInfoWork = paraConnectInfoWork as ConnectInfoWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // ����
                status = this.SearchProc(out connectInfoPrcPrStList, connectInfoWork, readMode, logicalMode, ref sqlConnection);

                if (connectInfoPrcPrStList != null && connectInfoPrcPrStList.Count != 0)
                {
                    (outConnectInfoPrcPrSt as CustomSerializeArrayList).AddRange(connectInfoPrcPrStList);
                }

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SAndEConnectInfoPrcPrStDB.Search", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEConnectInfoPrcPrStDB.Search", status);
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
        /// �w�肳�ꂽ��ƃR�[�h�̐ڑ�����ݒ�LIST��S�Ė߂��܂��B
        /// </summary>
        /// <param name="connectInfoPrcPrStList">��������</param>
        /// <param name="connectInfoWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̐ڑ�����ݒ�LIST��S�Ė߂��܂��B</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList connectInfoPrcPrStList, ConnectInfoWork connectInfoWork, int readMode, Broadleaf.Library.Resources.ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlText.Append("SELECT CREATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("    ,UPDATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                sqlText.Append("    ,FILEHEADERGUIDRF" + Environment.NewLine);
                sqlText.Append("    ,UPDEMPLOYEECODERF" + Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID1RF" + Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID2RF" + Environment.NewLine);
                sqlText.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                sqlText.Append("    ,SUPPLIERCDRF" + Environment.NewLine);
                sqlText.Append("    ,CONNECTPASSWORDRF" + Environment.NewLine);      //�ڑ��p�X���[�h
                sqlText.Append("    ,CONNECTUSERIDRF" + Environment.NewLine);        //�ڑ����[�UID
                sqlText.Append("    ,DAIHATSUORDREDIVRF" + Environment.NewLine);     //������z�敪�i�_�C�n�c�j
                sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);      //���O�C���^�C���A�E�g
                sqlText.Append("    ,ORDERURLRF" + Environment.NewLine);             //����URL
                sqlText.Append("    ,STOCKCHECKURLRF" + Environment.NewLine);        //�݌Ɋm�FURL
                sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);     //�ڑ��v���O�����^�C�v
                sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);          //�ڑ��t�@�C��ID
                sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);         //�ڑ����M�敪
                sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);       //�ڑ��Ώۋ敪
                sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);             //���g���C��
                sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);          //�������M�敪
                sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);             //�N������
                sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);    //���M�[��(IP�A�h���X�j
                sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);      //���M�[��(�R���s���[�^�[���j
                sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);
                sqlText.Append("    ,SANDECNCTPASSRF" + Environment.NewLine);        //S&E�ڑ��p�X���[�h
                sqlText.Append("    ,SANDECNCTUSERIDRF" + Environment.NewLine);      //S&E�ڑ����[�UID
                sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);       //�[���ԍ�
                sqlText.Append(" FROM CONNECTINFORF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                //----- ADD 2013/07/04 �c���� ----->>>>>
                sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                sqlText.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine);
                //----- ADD 2013/07/04 �c���� -----<<<<<
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);

                //----- ADD 2013/07/04 �c���� ----->>>>>
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                SqlParameter findParaSupplierCdRF = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);
                findParaSupplierCdRF.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

                SqlParameter findParaCnectProgramType = sqlCommand.Parameters.Add("@FINDCNECTPROGRAMTYPERF", SqlDbType.Int);
                findParaCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                //----- ADD 2013/07/04 �c���� -----<<<<<

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(this.CopyToConnectInfoWorkFromReader(ref myReader));
                }

                // �������ʂ�����ꍇ
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SAndEConnectInfoPrcPrStDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEConnectInfoPrcPrStDB.SearchProc", status);
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

            connectInfoPrcPrStList = al;

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�ڑ�����ݒ�Guid�̐ڑ�����ݒ��߂��܂�
        /// </summary>
        /// <param name="parabyte">ConnectInfoWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :  �w�肳�ꂽ�ڑ�����ݒ�Guid�̐ڑ�����ݒ��߂��܂�</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        public int Read(ref byte[] parabyte, int readMode)
        {
            return this.ReadProc(ref parabyte, readMode);
        }

        /// <summary>
        /// �w�肳�ꂽ�ڑ�����ݒ�Guid�̐ڑ�����ݒ��߂��܂�
        /// </summary>
        /// <param name="parabyte">ConnectInfoWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :  �w�肳�ꂽ�ڑ�����ݒ�Guid�̐ڑ�����ݒ��߂��܂�</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ConnectInfoWork connectInfoWork = new ConnectInfoWork();
            try
            {
                // XML�̓ǂݍ���
                connectInfoWork = (ConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(ConnectInfoWork));

                if (connectInfoWork == null)
                {
                    return status;
                }

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                StringBuilder sqlText = new StringBuilder();

                sqlText.Append("SELECT CREATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("    ,UPDATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                sqlText.Append("    ,FILEHEADERGUIDRF" + Environment.NewLine);
                sqlText.Append("    ,UPDEMPLOYEECODERF" + Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID1RF" + Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID2RF" + Environment.NewLine);
                sqlText.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                sqlText.Append("    ,SUPPLIERCDRF" + Environment.NewLine);
                sqlText.Append("    ,CONNECTPASSWORDRF" + Environment.NewLine);      //�ڑ��p�X���[�h
                sqlText.Append("    ,CONNECTUSERIDRF" + Environment.NewLine);        //�ڑ����[�UID
                sqlText.Append("    ,DAIHATSUORDREDIVRF" + Environment.NewLine);     //������z�敪�i�_�C�n�c�j
                sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);      //���O�C���^�C���A�E�g
                sqlText.Append("    ,ORDERURLRF" + Environment.NewLine);             //����URL
                sqlText.Append("    ,STOCKCHECKURLRF" + Environment.NewLine);        //�݌Ɋm�FURL
                sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);     //�ڑ��v���O�����^�C�v
                sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);          //�ڑ��t�@�C��ID
                sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);         //�ڑ����M�敪
                sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);       //�ڑ��Ώۋ敪
                sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);             //���g���C��
                sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);          //�������M�敪
                sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);             //�N������
                sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);    //���M�[��(IP�A�h���X�j
                sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);      //���M�[��(�R���s���[�^�[���j
                sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);
                sqlText.Append("    ,SANDECNCTPASSRF" + Environment.NewLine);        //S&E�ڑ��p�X���[�h
                sqlText.Append("    ,SANDECNCTUSERIDRF" + Environment.NewLine);      //S&E�ڑ����[�UID
                sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);       //�[���ԍ�
                sqlText.Append(" FROM CONNECTINFORF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                sqlText.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine); // ADD 2013/07/04 �c����
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                SqlParameter findParaSupplierCdRF = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                findParaSupplierCdRF.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

                //----- ADD 2013/07/04 �c���� ----->>>>>
                SqlParameter findParaCnectProgramType = sqlCommand.Parameters.Add("@FINDCNECTPROGRAMTYPERF", SqlDbType.Int);
                findParaCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                //----- ADD 2013/07/04 �c���� -----<<<<<

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    connectInfoWork = CopyToConnectInfoWorkFromReader(ref myReader);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(connectInfoWork);


            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndEConnectInfoPrcPrStDB.ReadProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        #endregion

        #region Delete
        /// <summary>
        /// �ڑ�����}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">ConnectInfoWork�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ڑ�����}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        public int Delete(byte[] parabyte)
        {
            return this.DeleteProc(parabyte);
        }

        /// <summary>
        /// �ڑ�����}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">ConnectInfoWork�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ڑ�����}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private int DeleteProc(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // XML�̓ǂݍ���
                ConnectInfoWork connectInfoWork = (ConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(ConnectInfoWork));

                if (connectInfoWork == null)
                {
                    return status;
                }
                StringBuilder sqlText = new StringBuilder();
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT��]
                sqlText.Append("SELECT CREATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("    ,UPDATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                sqlText.Append("    ,FILEHEADERGUIDRF" + Environment.NewLine);
                sqlText.Append("    ,UPDEMPLOYEECODERF" + Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID1RF" + Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID2RF" + Environment.NewLine);
                sqlText.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                sqlText.Append("    ,SUPPLIERCDRF" + Environment.NewLine);
                sqlText.Append("    ,CONNECTPASSWORDRF" + Environment.NewLine);      //�ڑ��p�X���[�h
                sqlText.Append("    ,CONNECTUSERIDRF" + Environment.NewLine);        //�ڑ����[�UID
                sqlText.Append("    ,DAIHATSUORDREDIVRF" + Environment.NewLine);     //������z�敪�i�_�C�n�c�j
                sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);      //���O�C���^�C���A�E�g
                sqlText.Append("    ,ORDERURLRF" + Environment.NewLine);             //����URL
                sqlText.Append("    ,STOCKCHECKURLRF" + Environment.NewLine);        //�݌Ɋm�FURL
                sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);     //�ڑ��v���O�����^�C�v
                sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);          //�ڑ��t�@�C��ID
                sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);         //�ڑ����M�敪
                sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);       //�ڑ��Ώۋ敪
                sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);             //���g���C��
                sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);          //�������M�敪
                sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);             //�N������
                sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);    //���M�[��(IP�A�h���X�j
                sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);      //���M�[��(�R���s���[�^�[���j
                sqlText.Append("     ,SENDMACHINEIPADDRRF" + Environment.NewLine);   //IP�A�h���X
                sqlText.Append("    ,SANDECNCTPASSRF" + Environment.NewLine);        //S&E�ڑ��p�X���[�h
                sqlText.Append("    ,SANDECNCTUSERIDRF" + Environment.NewLine);      //S&E�ڑ����[�UID
                sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);       //�[���ԍ�
                sqlText.Append(" FROM CONNECTINFORF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                sqlText.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine); // ADD 2013/07/04 �c����
                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

                //----- ADD 2013/07/04 �c���� ----->>>>>
                SqlParameter findParaCnectProgramType = sqlCommand.Parameters.Add("@FINDCNECTPROGRAMTYPERF", SqlDbType.Int);
                findParaCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                //----- ADD 2013/07/04 �c���� -----<<<<<

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                    if (_updateDateTime != connectInfoWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        return status;
                    }

                    # region [DELETE��]
                    StringBuilder sqlText_DELETE = new StringBuilder();
                    sqlText_DELETE.Append(" DELETE FROM CONNECTINFORF" + Environment.NewLine);
                    sqlText_DELETE.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                    sqlText_DELETE.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                    sqlCommand.CommandText = sqlText_DELETE.ToString();
                    # endregion

                    // KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);
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

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SAndEConnectInfoPrcPrStDB.DeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEConnectInfoPrcPrStDB.DeleteProc", status);
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

        #endregion Delete

        #region LogicalDelete
        /// <summary>
        /// �ڑ�����}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="connectInfoWork">�_���폜����ڑ�����}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ڑ�����}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        public int LogicalDelete(ref object connectInfoWork)
        {
            return this.LogicalDeleteProc(ref connectInfoWork, 0);
        }

        /// <summary>
        /// �ڑ�����}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="connectInfoWork">�_���폜����ڑ�����}�X�^���</param>
        /// <param name="procMode">�_���폜���[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ڑ�����}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private int LogicalDeleteProc(ref object connectInfoWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ConnectInfoWork paraList = connectInfoWork as ConnectInfoWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDeleteProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                connectInfoWork = paraList;

            }
            catch (SqlException sqex)
            {
                status = base.WriteSQLErrorLog(sqex, "SAndEConnectInfoPrcPrStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndEConnectInfoPrcPrStDB.LogicalDeleteProc", status);
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
        /// �ڑ�����}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="connectInfoWork">�_���폜����������ڑ�����}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ڑ�����}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object connectInfoWork)
        {
            return this.LogicalDeleteProc(ref connectInfoWork, 1);
        }

        /// <summary>
        /// �ڑ�����}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="connectInfoWork">�_���폜����ڑ�����}�X�^���</param>
        /// <param name="procMode">�_���폜���[�h</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ڑ�����}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private int LogicalDeleteProc(ref ConnectInfoWork connectInfoWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (connectInfoWork != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText.Append("SELECT CREATEDATETIMERF" + Environment.NewLine);
                    sqlText.Append("    ,UPDATEDATETIMERF" + Environment.NewLine);
                    sqlText.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append("    ,FILEHEADERGUIDRF" + Environment.NewLine);
                    sqlText.Append("    ,UPDEMPLOYEECODERF" + Environment.NewLine);
                    sqlText.Append("    ,UPDASSEMBLYID1RF" + Environment.NewLine);
                    sqlText.Append("    ,UPDASSEMBLYID2RF" + Environment.NewLine);
                    sqlText.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                    sqlText.Append("    ,SUPPLIERCDRF" + Environment.NewLine);
                    sqlText.Append("    ,CONNECTPASSWORDRF" + Environment.NewLine);      //�ڑ��p�X���[�h
                    sqlText.Append("    ,CONNECTUSERIDRF" + Environment.NewLine);        //�ڑ����[�UID
                    sqlText.Append("    ,DAIHATSUORDREDIVRF" + Environment.NewLine);     //������z�敪�i�_�C�n�c�j
                    sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);      //���O�C���^�C���A�E�g
                    sqlText.Append("    ,ORDERURLRF" + Environment.NewLine);             //����URL
                    sqlText.Append("    ,STOCKCHECKURLRF" + Environment.NewLine);        //�݌Ɋm�FURL
                    sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);     //�ڑ��v���O�����^�C�v
                    sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);          //�ڑ��t�@�C��ID
                    sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);         //�ڑ����M�敪
                    sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);       //�ڑ��Ώۋ敪
                    sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);             //���g���C��
                    sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);          //�������M�敪
                    sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);             //�N������
                    sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);    //���M�[��(IP�A�h���X�j
                    sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);      //���M�[��(�R���s���[�^�[���j
                    sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);    //IP�A�h���X
                    sqlText.Append("    ,SANDECNCTPASSRF" + Environment.NewLine);        //S&E�ڑ��p�X���[�h
                    sqlText.Append("    ,SANDECNCTUSERIDRF" + Environment.NewLine);      //S&E�ڑ����[�UID
                    sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);       //�[���ԍ�
                    sqlText.Append(" FROM CONNECTINFORF WITH (READUNCOMMITTED)" + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                    sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                    sqlText.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine); // ADD 2013/07/04 �c����
                    sqlCommand.CommandText = sqlText.ToString();
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

                    //----- ADD 2013/07/04 �c���� ----->>>>>
                    SqlParameter findParaCnectProgramType = sqlCommand.Parameters.Add("@FINDCNECTPROGRAMTYPERF", SqlDbType.Int);
                    findParaCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                    //----- ADD 2013/07/04 �c���� -----<<<<<

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != connectInfoWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // ���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        # region [UPDATE��]
                        StringBuilder sqlText_UPDATE = new StringBuilder();
                        sqlText_UPDATE.Append("UPDATE CONNECTINFORF" + Environment.NewLine);
                        sqlText_UPDATE.Append("    SET UPDATEDATETIMERF=@UPDATEDATETIMERF" + Environment.NewLine);
                        sqlText_UPDATE.Append("    ,LOGICALDELETECODERF=@LOGICALDELETECODERF" + Environment.NewLine);
                        sqlText_UPDATE.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                        sqlCommand.CommandText = sqlText_UPDATE.ToString();
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)connectInfoWork;
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
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;         // ���ɍ폜�ς݂̏ꍇ����
                            return status;
                        }
                        else if (logicalDelCd == 0) connectInfoWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                        else connectInfoWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            connectInfoWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
                        }
                        else
                        {
                            if (logicalDelCd == 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     // ���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  // ���S�폜�̓f�[�^�Ȃ���߂�
                            }

                            return status;
                        }
                    }

                    //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIMERF", SqlDbType.BigInt);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODERF", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(connectInfoWork.UpdateDateTime);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt64(connectInfoWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                    al.Add(connectInfoWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqex, "SAndEConnectInfoPrcPrStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEConnectInfoPrcPrStDB.LogicalDeleteProc", status);
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
        #endregion LogicalDelete

        #region Write
        /// <summary>
        /// �ڑ�����}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="connectInfoWorkbyte">�ǉ��E�X�V����ڑ�����}�X�^���</param>
        /// <param name="writeMode">�X�V�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ڑ�����}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        public int Write(ref object connectInfoWorkbyte, int writeMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ConnectInfoWork connectInfoWork = connectInfoWorkbyte as ConnectInfoWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = WriteProc(ref connectInfoWork, ref sqlConnection, ref sqlTransaction);

                // �߂�l�Z�b�g
                connectInfoWorkbyte = connectInfoWork;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SAndEConnectInfoPrcPrStDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndEConnectInfoPrcPrStDB.Write", status);
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
        /// �ڑ�����}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="connectInfoWork">�ǉ��E�X�V����ڑ�����}�X�^���</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ڑ�����}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>�Ǘ��ԍ�   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private int WriteProc(ref ConnectInfoWork connectInfoWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ConnectInfoWork al = new ConnectInfoWork();

            try
            {
                if (connectInfoWork != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText.Append("SELECT CREATEDATETIMERF" + Environment.NewLine);
                    sqlText.Append("    ,UPDATEDATETIMERF" + Environment.NewLine);
                    sqlText.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append("    ,FILEHEADERGUIDRF" + Environment.NewLine);
                    sqlText.Append("    ,UPDEMPLOYEECODERF" + Environment.NewLine);
                    sqlText.Append("    ,UPDASSEMBLYID1RF" + Environment.NewLine);
                    sqlText.Append("    ,UPDASSEMBLYID2RF" + Environment.NewLine);
                    sqlText.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                    sqlText.Append("    ,SUPPLIERCDRF" + Environment.NewLine);
                    sqlText.Append("    ,CONNECTPASSWORDRF" + Environment.NewLine);      //�ڑ��p�X���[�h
                    sqlText.Append("    ,CONNECTUSERIDRF" + Environment.NewLine);        //�ڑ����[�UID
                    sqlText.Append("    ,DAIHATSUORDREDIVRF" + Environment.NewLine);     //������z�敪�i�_�C�n�c�j
                    sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);      //���O�C���^�C���A�E�g
                    sqlText.Append("    ,ORDERURLRF" + Environment.NewLine);             //����URL
                    sqlText.Append("    ,STOCKCHECKURLRF" + Environment.NewLine);        //�݌Ɋm�FURL
                    sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);     //�ڑ��v���O�����^�C�v
                    sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);          //�ڑ��t�@�C��ID
                    sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);         //�ڑ����M�敪
                    sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);       //�ڑ��Ώۋ敪
                    sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);             //���g���C��
                    sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);          //�������M�敪
                    sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);             //�N������
                    sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);    //���M�[��(IP�A�h���X�j
                    sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);      //���M�[��(�R���s���[�^�[���j
                    sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);    //IP�A�h���X
                    sqlText.Append("    ,SANDECNCTPASSRF" + Environment.NewLine);        //S&E�ڑ��p�X���[�h
                    sqlText.Append("    ,SANDECNCTUSERIDRF" + Environment.NewLine);      //S&E�ڑ����[�UID
                    sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);       //�[���ԍ�
                    sqlText.Append(" FROM CONNECTINFORF WITH (READUNCOMMITTED)" + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                    sqlText.Append(" AND SUPPLIERCDRF=@FINDSUPPLIERCDRF " + Environment.NewLine);
                    sqlText.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine); // ADD 2013/07/04 �c����
                    sqlCommand.CommandText = sqlText.ToString();
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCDRF", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

                    //----- ADD 2013/07/04 �c���� ----->>>>>
                    SqlParameter findParaCnectProgramType = sqlCommand.Parameters.Add("@FINDCNECTPROGRAMTYPERF", SqlDbType.Int);
                    findParaCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                    //----- ADD 2013/07/04 �c���� -----<<<<<

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != connectInfoWork.UpdateDateTime)
                        {
                            if (connectInfoWork.UpdateDateTime == DateTime.MinValue)
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
                        StringBuilder sqlText_UPDATE = new StringBuilder();
                        sqlText_UPDATE.Append("UPDATE CONNECTINFORF SET" + Environment.NewLine);
                        sqlText_UPDATE.Append("    UPDATEDATETIMERF=@UPDATEDATETIME," + Environment.NewLine);
                        sqlText_UPDATE.Append("    CONNECTPASSWORDRF=@CONNECTPASSWORD," + Environment.NewLine);
                        sqlText_UPDATE.Append("    CONNECTUSERIDRF=@CONNECTUSERID," + Environment.NewLine);
                        sqlText_UPDATE.Append("    DAIHATSUORDREDIVRF=@DAIHATSUORDREDIV," + Environment.NewLine);
                        sqlText_UPDATE.Append("    LOGINTIMEOUTVALRF=@LOGINTIMEOUTVAL," + Environment.NewLine);
                        sqlText_UPDATE.Append("    ORDERURLRF=@ORDERURL," + Environment.NewLine);
                        sqlText_UPDATE.Append("    STOCKCHECKURLRF=@STOCKCHECKURL," + Environment.NewLine);
                        sqlText_UPDATE.Append("    CNECTPROGRAMTYPERF=@CNECTPROGRAMTYPE," + Environment.NewLine);
                        sqlText_UPDATE.Append("    CNECTFILEIDRF=@CNECTFILEID," + Environment.NewLine);
                        sqlText_UPDATE.Append("    CNECTSENDDIVRF=@CNECTSENDDIV," + Environment.NewLine);
                        sqlText_UPDATE.Append("    CNECTOBJECTDIVRF=@CNECTOBJECTDIV," + Environment.NewLine);
                        sqlText_UPDATE.Append("    RETRYCNTRF=@RETRYCNT," + Environment.NewLine);
                        sqlText_UPDATE.Append("    AUTOSENDDIVRF=@AUTOSENDDIV," + Environment.NewLine);
                        sqlText_UPDATE.Append("    BOOTTIMERF=@BOOTTIME," + Environment.NewLine);
                        sqlText_UPDATE.Append("    SENDMACHINENAMERF=@SENDMACHINENAME" + Environment.NewLine);
                        sqlText_UPDATE.Append("    ,SENDMACHINEIPADDRRF=@SENDMACHINEIPADDR" + Environment.NewLine);
                        sqlText_UPDATE.Append("    ,SANDECNCTPASSRF=@SANDECNCTPASS" + Environment.NewLine);
                        sqlText_UPDATE.Append("    ,SANDECNCTUSERIDRF=@SANDECNCTUSERID" + Environment.NewLine);
                        sqlText_UPDATE.Append("    ,CASHREGISTERNORF=@CASHREGISTERNORF" + Environment.NewLine);
                        sqlText_UPDATE.Append(" WHERE ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND SUPPLIERCDRF=@SUPPLIERCD " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine); // ADD 2013/07/04 �c����
                        sqlCommand.CommandText = sqlText_UPDATE.ToString();
                        # endregion

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)connectInfoWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (connectInfoWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        # region [INSERT��]
                        StringBuilder sqlText_INSERT = new StringBuilder();
                        sqlText_INSERT.Append("INSERT INTO CONNECTINFORF" + Environment.NewLine);
                        sqlText_INSERT.Append(" (CREATEDATETIMERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  UPDATEDATETIMERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  ENTERPRISECODERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  FILEHEADERGUIDRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  UPDEMPLOYEECODERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  UPDASSEMBLYID1RF," + Environment.NewLine);
                        sqlText_INSERT.Append("  UPDASSEMBLYID2RF," + Environment.NewLine);
                        sqlText_INSERT.Append("  LOGICALDELETECODERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  SUPPLIERCDRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  CONNECTPASSWORDRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  CONNECTUSERIDRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  DAIHATSUORDREDIVRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  LOGINTIMEOUTVALRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  ORDERURLRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  STOCKCHECKURLRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  CNECTPROGRAMTYPERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  CNECTFILEIDRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  CNECTSENDDIVRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  CNECTOBJECTDIVRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  RETRYCNTRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  AUTOSENDDIVRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  BOOTTIMERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  SENDMACHINENAMERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  SENDMACHINEIPADDRRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  SANDECNCTPASSRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  SANDECNCTUSERIDRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  CASHREGISTERNORF)" + Environment.NewLine);
                        sqlText_INSERT.Append("  VALUES (@CREATEDATETIME," + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDATEDATETIME, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @ENTERPRISECODE, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @FILEHEADERGUID," + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDEMPLOYEECODE," + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDASSEMBLYID1, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDASSEMBLYID2, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @LOGICALDELETECODE, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @SUPPLIERCD, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @CONNECTPASSWORD," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CONNECTUSERID," + Environment.NewLine);
                        sqlText_INSERT.Append("     @DAIHATSUORDREDIV," + Environment.NewLine);
                        sqlText_INSERT.Append("     @LOGINTIMEOUTVAL," + Environment.NewLine);
                        sqlText_INSERT.Append("     @ORDERURL," + Environment.NewLine);
                        sqlText_INSERT.Append("     @STOCKCHECKURL," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CNECTPROGRAMTYPE," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CNECTFILEID," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CNECTSENDDIV," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CNECTOBJECTDIV," + Environment.NewLine);
                        sqlText_INSERT.Append("     @RETRYCNT," + Environment.NewLine);
                        sqlText_INSERT.Append("     @AUTOSENDDIV," + Environment.NewLine);
                        sqlText_INSERT.Append("     @BOOTTIME," + Environment.NewLine);
                        sqlText_INSERT.Append("     @SENDMACHINENAME," + Environment.NewLine);
                        sqlText_INSERT.Append("     @SENDMACHINEIPADDR," + Environment.NewLine);
                        sqlText_INSERT.Append("     @SANDECNCTPASS," + Environment.NewLine);
                        sqlText_INSERT.Append("     @SANDECNCTUSERID," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CASHREGISTERNORF)" + Environment.NewLine);
                        sqlCommand.CommandText = sqlText_INSERT.ToString();
                        # endregion

                        // �o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)connectInfoWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    SqlParameter paraPassword = sqlCommand.Parameters.Add("@CONNECTPASSWORD", SqlDbType.NVarChar);
                    SqlParameter paraUserId = sqlCommand.Parameters.Add("@CONNECTUSERID", SqlDbType.NVarChar);
                    SqlParameter paraDaihatsuOrdreDiv = sqlCommand.Parameters.Add("@DAIHATSUORDREDIV", SqlDbType.Int);
                    SqlParameter paraLoginTimeoutVal = sqlCommand.Parameters.Add("@LOGINTIMEOUTVAL", SqlDbType.Int);
                    SqlParameter paraOrderUrl = sqlCommand.Parameters.Add("@ORDERURL", SqlDbType.NVarChar);
                    SqlParameter paraStockCheckUrl = sqlCommand.Parameters.Add("@STOCKCHECKURL", SqlDbType.NVarChar);
                    SqlParameter paraCnectProgramType = sqlCommand.Parameters.Add("@CNECTPROGRAMTYPE", SqlDbType.NVarChar);
                    SqlParameter paraCnectFileId = sqlCommand.Parameters.Add("@CNECTFILEID", SqlDbType.NVarChar);
                    SqlParameter paraCnectSendDiv = sqlCommand.Parameters.Add("@CNECTSENDDIV", SqlDbType.NVarChar);
                    SqlParameter paraCnectObjectDiv = sqlCommand.Parameters.Add("@CNECTOBJECTDIV", SqlDbType.NVarChar);
                    SqlParameter paraRetryCnt = sqlCommand.Parameters.Add("@RETRYCNT", SqlDbType.NVarChar);
                    SqlParameter paraAutoSendDiv = sqlCommand.Parameters.Add("@AUTOSENDDIV", SqlDbType.NVarChar);
                    SqlParameter paraBootTime = sqlCommand.Parameters.Add("@BOOTTIME", SqlDbType.NVarChar);
                    SqlParameter paraSendMachineName = sqlCommand.Parameters.Add("@SENDMACHINENAME", SqlDbType.NVarChar);
                    SqlParameter paraSendMachineIpAddr = sqlCommand.Parameters.Add("@SENDMACHINEIPADDR", SqlDbType.NVarChar);
                    SqlParameter paraSAndECnctPass = sqlCommand.Parameters.Add("@SANDECNCTPASS", SqlDbType.NVarChar);
                    SqlParameter paraSAndECnctUserId = sqlCommand.Parameters.Add("@SANDECNCTUSERID", SqlDbType.NVarChar);
                    SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNORF", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(connectInfoWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(connectInfoWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(connectInfoWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(connectInfoWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(connectInfoWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.LogicalDeleteCode);
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);
                    paraPassword.Value = SqlDataMediator.SqlSetString(connectInfoWork.ConnectPassword);
                    paraUserId.Value = SqlDataMediator.SqlSetString(connectInfoWork.ConnectUserId);
                    paraDaihatsuOrdreDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.DaihatsuOrdreDiv);
                    paraLoginTimeoutVal.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.LoginTimeoutVal);
                    paraOrderUrl.Value = SqlDataMediator.SqlSetString(connectInfoWork.OrderUrl);
                    paraStockCheckUrl.Value = SqlDataMediator.SqlSetString(connectInfoWork.StockCheckUrl);
                    paraCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                    paraCnectFileId.Value = SqlDataMediator.SqlSetString(connectInfoWork.CnectFileId);
                    paraCnectSendDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectSendDiv);
                    paraCnectObjectDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectObjectDiv);
                    paraRetryCnt.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.RetryCnt);
                    paraAutoSendDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.AutoSendDiv);
                    paraBootTime.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.BootTime);
                    paraSendMachineName.Value = SqlDataMediator.SqlSetString(connectInfoWork.SendMachineName);
                    paraSendMachineIpAddr.Value = SqlDataMediator.SqlSetString(connectInfoWork.SendMachineIpAddr);
                    paraSAndECnctPass.Value=SqlDataMediator.SqlSetString(connectInfoWork.SAndECnctPass);
                    paraSAndECnctUserId.Value=SqlDataMediator.SqlSetString(connectInfoWork.SAndECnctUserId);
                    paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CashRegisterNo);

                    sqlCommand.ExecuteNonQuery();
                    al = connectInfoWork;

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SAndEConnectInfoPrcPrStDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEConnectInfoPrcPrStDB.WriteProc", status);
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

            connectInfoWork = al;

            return status;
        }
        #endregion

        #endregion IConnectInfoPrcPrStDB �����o

    }
}
