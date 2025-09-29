//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ڑ�����}�X�^�����e�i���X
// �v���O�����T�v   : �ڑ�����}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10805731-00 �쐬�S�� : �����M
// �� �� ��  2012/12/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �C �� ��  2013/07/05  �C�����e : �ڑ��v���O�����^�C�v�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
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
    /// <br>Programmer : �����M</br>
    /// <br>Date       : 2012/12/15</br>
    /// <br>�Ǘ��ԍ�   : 10805731-00</br>>
    /// <br>UpdateNote : 2013/07/05 �c����</br>
    /// <br>           : �ڑ��v���O�����^�C�v�̒ǉ�</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ConnectInfoPrcPrStDB : RemoteDB, IConnectInfoPrcPrStDB
    {
        /// <summary>
        /// �ڑ�����}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        public ConnectInfoPrcPrStDB()
            : base("PMKHN09717D", "Broadleaf.Application.Remoting.ParamData.ConnectInfoWork", "CONNECTINFORF")
        {

        }

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� ConnectInfoWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>ConnectInfoWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>UpdateNote : 2013/07/05 �c����</br>
        /// <br>           : �ڑ��v���O�����^�C�v�̒ǉ�</br>
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
                connectInfoWork.CnectProgramType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNECTPROGRAMTYPERF")); // ADD 2013/07/05 �c����
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
#if DEBUG
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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

                if (connectInfoPrcPrStList != null)
                {
                    (outConnectInfoPrcPrSt as CustomSerializeArrayList).AddRange(connectInfoPrcPrStList);
                }

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "ConnectInfoPrcPrStDB.Search", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "ConnectInfoPrcPrStDB.Search", status);
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>UpdateNote : 2013/07/05 �c����</br>
        /// <br>           : �ڑ��v���O�����^�C�v�̒ǉ�</br>
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
                sqlText.Append("    ,CONNECTPASSWORDRF" + Environment.NewLine);
                sqlText.Append("    ,CONNECTUSERIDRF" + Environment.NewLine);
                sqlText.Append("    ,DAIHATSUORDREDIVRF" + Environment.NewLine);
                sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);
                sqlText.Append("    ,ORDERURLRF" + Environment.NewLine);
                sqlText.Append("    ,STOCKCHECKURLRF" + Environment.NewLine);
                sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine); // ADD 2013/07/05 �c����
                sqlText.Append(" FROM CONNECTINFORF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                //----- ADD 2013/07/05 �c���� ----->>>>>
                sqlText.Append(" AND SUPPLIERCDRF<>@SUPPLIERCDRF " + Environment.NewLine);
                sqlText.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine);
                //----- ADD 2013/07/05 �c���� -----<<<<<
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);

                //----- ADD 2013/07/05 �c���� ----->>>>>
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                SqlParameter findParaSupplierCdRF = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);
                findParaSupplierCdRF.Value = SqlDataMediator.SqlSetInt32(0);

                SqlParameter findParaCnectProgramType = sqlCommand.Parameters.Add("@FINDCNECTPROGRAMTYPERF", SqlDbType.Int);
                findParaCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                //----- ADD 2013/07/05 �c���� -----<<<<<


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
                status = base.WriteSQLErrorLog(sqlex, "ConnectInfoPrcPrStDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "ConnectInfoPrcPrStDB.SearchProc", status);
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>UpdateNote : 2013/07/05 �c����</br>
        /// <br>           : �ڑ��v���O�����^�C�v�̒ǉ�</br>
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
                sqlText.Append("    ,CONNECTPASSWORDRF" + Environment.NewLine);
                sqlText.Append("    ,CONNECTUSERIDRF" + Environment.NewLine);
                sqlText.Append("    ,DAIHATSUORDREDIVRF" + Environment.NewLine);
                sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);
                sqlText.Append("    ,ORDERURLRF" + Environment.NewLine);
                sqlText.Append("    ,STOCKCHECKURLRF" + Environment.NewLine);
                sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine); // ADD 2013/07/05 �c����
                sqlText.Append(" FROM CONNECTINFORF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                sqlText.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine); // ADD 2013/07/05 �c����
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                SqlParameter findParaSupplierCdRF = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                findParaSupplierCdRF.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

                //----- ADD 2013/07/05 �c���� ----->>>>>
                SqlParameter findParaCnectProgramType = sqlCommand.Parameters.Add("@FINDCNECTPROGRAMTYPERF", SqlDbType.Int);
                findParaCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                //----- ADD 2013/07/05 �c���� -----<<<<<

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
                base.WriteErrorLog(ex, "MediationConnectPrcPrStDB.Read Exception=" + ex.Message);
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>UpdateNote : 2013/07/05 �c����</br>
        /// <br>           : �ڑ��v���O�����^�C�v�̒ǉ�</br>
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
                sqlText.Append("    ,CONNECTPASSWORDRF" + Environment.NewLine);
                sqlText.Append("    ,CONNECTUSERIDRF" + Environment.NewLine);
                sqlText.Append("    ,DAIHATSUORDREDIVRF" + Environment.NewLine);
                sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);
                sqlText.Append("    ,ORDERURLRF" + Environment.NewLine);
                sqlText.Append("    ,STOCKCHECKURLRF" + Environment.NewLine);
                sqlText.Append(" FROM CONNECTINFORF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                sqlText.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine); // ADD 2013/07/05 �c����
                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

                //----- ADD 2013/07/05 �c���� ----->>>>>
                SqlParameter findParaCnectProgramType = sqlCommand.Parameters.Add("@FINDCNECTPROGRAMTYPERF", SqlDbType.Int);
                findParaCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                //----- ADD 2013/07/05 �c���� -----<<<<<

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
                status = base.WriteSQLErrorLog(sqlex, "ConnectInfoPrcPrStDB.Delete", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "ConnectInfoPrcPrStDB.DeleteProc", status);
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
                status = base.WriteSQLErrorLog(sqex, "ConnectInfoPrcPrStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ConnectInfoPrcPrStDB.LogicalDeleteProc", status);
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>UpdateNote : 2013/07/05 �c����</br>
        /// <br>           : �ڑ��v���O�����^�C�v�̒ǉ�</br>
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
                    sqlText.Append("    ,CONNECTPASSWORDRF" + Environment.NewLine);
                    sqlText.Append("    ,CONNECTUSERIDRF" + Environment.NewLine);
                    sqlText.Append("    ,DAIHATSUORDREDIVRF" + Environment.NewLine);
                    sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);
                    sqlText.Append("    ,ORDERURLRF" + Environment.NewLine);
                    sqlText.Append("    ,STOCKCHECKURLRF" + Environment.NewLine);
                    sqlText.Append(" FROM CONNECTINFORF WITH (READUNCOMMITTED)" + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                    sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                    sqlText.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine); // ADD 2013/07/05 �c����
                    sqlCommand.CommandText = sqlText.ToString();
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

                    //----- ADD 2013/07/05 �c���� ----->>>>>
                    SqlParameter findParaCnectProgramType = sqlCommand.Parameters.Add("@FINDCNECTPROGRAMTYPERF", SqlDbType.Int);
                    findParaCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                    //----- ADD 2013/07/05 �c���� -----<<<<<

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
                status = base.WriteSQLErrorLog(sqex, "ConnectInfoPrcPrStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "ConnectInfoPrcPrStDB.DeleteProc", status);
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
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
                status = base.WriteSQLErrorLog(sqlex, "ConnectInfoPrcPrStDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ConnectInfoPrcPrStDB.Write", status);
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
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>UpdateNote : 2013/07/05 �c����</br>
        /// <br>           : �ڑ��v���O�����^�C�v�̒ǉ�</br>
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
                    sqlText.Append("    ,CONNECTPASSWORDRF" + Environment.NewLine);
                    sqlText.Append("    ,CONNECTUSERIDRF" + Environment.NewLine);
                    sqlText.Append("    ,DAIHATSUORDREDIVRF" + Environment.NewLine);
                    sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);
                    sqlText.Append("    ,ORDERURLRF" + Environment.NewLine);
                    sqlText.Append("    ,STOCKCHECKURLRF" + Environment.NewLine);
                    sqlText.Append(" FROM CONNECTINFORF WITH (READUNCOMMITTED)" + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                    sqlText.Append(" AND SUPPLIERCDRF=@FINDSUPPLIERCDRF " + Environment.NewLine);
                    sqlText.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine); // ADD 2013/07/05 �c����
                    sqlCommand.CommandText = sqlText.ToString();
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCDRF", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

                    //----- ADD 2013/07/05 �c���� ----->>>>>
                    SqlParameter findParaCnectProgramType = sqlCommand.Parameters.Add("@FINDCNECTPROGRAMTYPERF", SqlDbType.Int);
                    findParaCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                    //----- ADD 2013/07/05 �c���� -----<<<<<

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
                        sqlText_UPDATE.Append("UPDATE CONNECTINFORF" + Environment.NewLine);
                        sqlText_UPDATE.Append("    SET SUPPLIERCDRF=@SUPPLIERCDRF," + Environment.NewLine);
                        sqlText_UPDATE.Append("    CONNECTPASSWORDRF=@CONNECTPASSWORDRF," + Environment.NewLine);
                        sqlText_UPDATE.Append("    CONNECTUSERIDRF=@CONNECTUSERIDRF," + Environment.NewLine);
                        sqlText_UPDATE.Append("    DAIHATSUORDREDIVRF=@DAIHATSUORDREDIVRF," + Environment.NewLine);
                        sqlText_UPDATE.Append("    LOGINTIMEOUTVALRF=@LOGINTIMEOUTVALRF," + Environment.NewLine);
                        sqlText_UPDATE.Append("    ORDERURLRF=@ORDERURLRF," + Environment.NewLine);
                        sqlText_UPDATE.Append("    STOCKCHECKURLRF=@STOCKCHECKURLRF," + Environment.NewLine);
                        sqlText_UPDATE.Append("    UPDATEDATETIMERF=@UPDATEDATETIMERF" + Environment.NewLine);
                        sqlText_UPDATE.Append(" WHERE ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
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
                        sqlText_INSERT.Append(" UPDEMPLOYEECODERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  UPDASSEMBLYID1RF," + Environment.NewLine);
                        sqlText_INSERT.Append("  UPDASSEMBLYID2RF," + Environment.NewLine);
                        sqlText_INSERT.Append(" LOGICALDELETECODERF," + Environment.NewLine);
                        sqlText_INSERT.Append("     SUPPLIERCDRF," + Environment.NewLine);
                        sqlText_INSERT.Append(" CONNECTPASSWORDRF," + Environment.NewLine);
                        sqlText_INSERT.Append(" CONNECTUSERIDRF," + Environment.NewLine);
                        sqlText_INSERT.Append(" DAIHATSUORDREDIVRF," + Environment.NewLine);
                        sqlText_INSERT.Append(" LOGINTIMEOUTVALRF," + Environment.NewLine);
                        sqlText_INSERT.Append(" ORDERURLRF," + Environment.NewLine);
                        sqlText_INSERT.Append(" CNECTPROGRAMTYPERF," + Environment.NewLine); // ADD 2013/07/05 �c����
                        sqlText_INSERT.Append(" STOCKCHECKURLRF)" + Environment.NewLine);
                        sqlText_INSERT.Append(" VALUES (@CREATEDATETIME," + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDATEDATETIMERF, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @ENTERPRISECODE, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @FILEHEADERGUID," + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDEMPLOYEECODE," + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDASSEMBLYID1, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDASSEMBLYID2, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @LOGICALDELETECODE, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @SUPPLIERCDRF, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @CONNECTPASSWORDRF," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CONNECTUSERIDRF," + Environment.NewLine);
                        sqlText_INSERT.Append("     @DAIHATSUORDREDIVRF," + Environment.NewLine);
                        sqlText_INSERT.Append("     @LOGINTIMEOUTVALRF," + Environment.NewLine);
                        sqlText_INSERT.Append("     @ORDERURLRF," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CNECTPROGRAMTYPERF," + Environment.NewLine); // ADD 2013/07/05 �c����
                        sqlText_INSERT.Append("     @STOCKCHECKURLRF)" + Environment.NewLine);
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
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIMERF", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);
                    SqlParameter paraPassword = sqlCommand.Parameters.Add("@CONNECTPASSWORDRF", SqlDbType.NVarChar);
                    SqlParameter paraUserId = sqlCommand.Parameters.Add("@CONNECTUSERIDRF", SqlDbType.NVarChar);
                    SqlParameter paraDaihatsuOrdreDiv = sqlCommand.Parameters.Add("@DAIHATSUORDREDIVRF", SqlDbType.Int);
                    SqlParameter paraLoginTimeoutVal = sqlCommand.Parameters.Add("@LOGINTIMEOUTVALRF", SqlDbType.Int);
                    SqlParameter paraOrderUrl = sqlCommand.Parameters.Add("@ORDERURLRF", SqlDbType.NVarChar);
                    SqlParameter paraStockCheckUrl = sqlCommand.Parameters.Add("@STOCKCHECKURLRF", SqlDbType.NVarChar);
                    SqlParameter paraCnectProgramType = sqlCommand.Parameters.Add("@CNECTPROGRAMTYPERF", SqlDbType.Int); // ADD 2013/07/05 �c����


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
                    paraCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType); // ADD 2013/07/05 �c����

                    sqlCommand.ExecuteNonQuery();
                    al = connectInfoWork;

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "ConnectInfoPrcPrStDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "ConnectInfoPrcPrStDB.WriteProc", status);
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
