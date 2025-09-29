//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ڑ�����}�X�^�����e�i���X
// �v���O�����T�v   : �ڑ�����}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570219-00 �쐬�S�� : �c����
// �� �� ��  2019/12/03  �C�����e : �V�K�쐬
// �Ǘ��ԍ�  11570219-00 �쐬�S�� : ���c�`�[
// �X �V ��  2020/02/04  �C�����e : �i�C�����e�ꗗNo.�Q�j���l�o�͐ݒ荀�ڕύX�Ή�
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
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2019/12/03</br>
    /// <br>�Ǘ��ԍ�   : 11570219-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SalCprtConnectInfoPrcPrStDB : RemoteDB, ISalCprtConnectInfoPrcPrStDB
    {
        /// <summary>
        /// �ڑ�����}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public SalCprtConnectInfoPrcPrStDB()
            : base("PMSDC09016D", "Broadleaf.Application.Remoting.ParamData.SalCprtConnectInfoWork", "SALCPRTCNCTINFRF")
        {

        }

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SalCprtConnectInfoWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalCprtConnectInfoWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private SalCprtConnectInfoWork CopyToSalCprtConnectInfoWorkFromReader(ref SqlDataReader myReader)
        {
            SalCprtConnectInfoWork connectInfoWork = new SalCprtConnectInfoWork();

            this.CopyToSalCprtConnectInfoWorkFromReader(ref myReader, ref connectInfoWork);

            return connectInfoWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� ConnectInfoWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="connectInfoWork">ConnectInfoWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br>Update Note: 2020/02/04 ���c �`�[</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br>           :�i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// <br></br>
        /// </remarks>
        private void CopyToSalCprtConnectInfoWorkFromReader(ref SqlDataReader myReader, ref SalCprtConnectInfoWork connectInfoWork)
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
                string sectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECTIONCODERF")).ToString();
                if (sectionCode == "0")
                {
                    connectInfoWork.SectionCode = sectionCode;
                }
                else
                {
                    connectInfoWork.SectionCode = sectionCode.PadLeft(2, '0');
                }              
                connectInfoWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                connectInfoWork.Protocol = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PROTOCOLRF"));
                connectInfoWork.LoginTimeoutVal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGINTIMEOUTVALRF"));
                connectInfoWork.CprtDomain = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CPRTDOMAINRF"));
                connectInfoWork.CprtUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CPRTURLRF"));
                connectInfoWork.CnectProgramType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNECTPROGRAMTYPERF"));
                connectInfoWork.CnectFileId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CNECTFILEIDRF"));
                connectInfoWork.CnectSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNECTSENDDIVRF"));
                connectInfoWork.CnectObjectDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNECTOBJECTDIVRF"));
                connectInfoWork.RetryCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETRYCNTRF"));
                connectInfoWork.AutoSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOSENDDIVRF"));
                connectInfoWork.BootTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOOTTIMERF"));
                connectInfoWork.EndTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENDTIMERF"));
                connectInfoWork.ExecInterval = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXECINTERVALRF"));
                connectInfoWork.SendMachineIpAddr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDMACHINEIPADDRRF"));
                connectInfoWork.SendMachineName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDMACHINENAMERF"));
                connectInfoWork.SendCcnctPass = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDCCNCTPASSRF"));
                connectInfoWork.SendCcnctUserid = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDCCNCTUSERIDRF"));
                connectInfoWork.CashregiSterno = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
                connectInfoWork.LtAtSadDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("LTATSADDATETIMERF"));
                connectInfoWork.FrstSendDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRSTSENDDATERF"));
                //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                connectInfoWork.Note1SetDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NOTE1SETDIVRF"));
                connectInfoWork.Note2SetDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NOTE2SETDIVRF"));
                connectInfoWork.Note3SetDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NOTE3SETDIVRF"));
                //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public int Search(out object outConnectInfoPrcPrSt, object paraConnectInfoWork, int readMode, Broadleaf.Library.Resources.ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList connectInfoPrcPrStList = null;
            SalCprtConnectInfoWork connectInfoWork = null;

            outConnectInfoPrcPrSt = new CustomSerializeArrayList();

            try
            {
                connectInfoWork = paraConnectInfoWork as SalCprtConnectInfoWork;

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
                status = base.WriteSQLErrorLog(sqlex, "SalCprtConnectInfoPrcPrStDB.Search", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalCprtConnectInfoPrcPrStDB.Search", status);
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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br>Update Note: 2020/02/04 ���c �`�[</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br>           :�i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList connectInfoPrcPrStList, SalCprtConnectInfoWork connectInfoWork, int readMode, Broadleaf.Library.Resources.ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
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
                sqlText.Append("    ,SECTIONCODERF" + Environment.NewLine);         //���_�R�[�h
                sqlText.Append("    ,CUSTOMERCODERF" + Environment.NewLine);        //���Ӑ�R�[�h
                sqlText.Append("    ,PROTOCOLRF" + Environment.NewLine);            //�v���g�R��
                sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);     //���O�C���^�C���A�E�g
                sqlText.Append("    ,CPRTDOMAINRF" + Environment.NewLine);          //�A�g��h���C��
                sqlText.Append("    ,CPRTURLRF" + Environment.NewLine);             //�A�g��URL
                sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);    //�ڑ��v���O�����^�C�v
                sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);         //�ڑ��t�@�C��ID
                sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);        //�ڑ����M�敪
                sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);      //�ڑ��Ώۋ敪
                sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);            //���g���C��
                sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);         //�������M�敪
                sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);            //�N������
                sqlText.Append("    ,ENDTIMERF" + Environment.NewLine);             //�I������
                sqlText.Append("    ,EXECINTERVALRF" + Environment.NewLine);        //���s�Ԋu
                sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);   //���M�[��(IP�A�h���X�j
                sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);     //���M�[��(�R���s���[�^�[���j
                sqlText.Append("    ,SENDCCNCTPASSRF" + Environment.NewLine);       //���M�ڑ��p�X���[�h
                sqlText.Append("    ,SENDCCNCTUSERIDRF" + Environment.NewLine);     //���M�ڑ����[�U�[�R�[�h
                sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);      //���W�ԍ�
                sqlText.Append("    ,LTATSADDATETIMERF" + Environment.NewLine);     //�O�񎩓����M����
                sqlText.Append("    ,FRSTSENDDATERF" + Environment.NewLine);        //���񑗐M���
                //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                sqlText.Append("    ,NOTE1SETDIVRF" + Environment.NewLine);         //���l�P�ݒ�敪
                sqlText.Append("    ,NOTE2SETDIVRF" + Environment.NewLine);         //���l�Q�ݒ�敪
                sqlText.Append("    ,NOTE3SETDIVRF" + Environment.NewLine);         //���l�R�ݒ�敪
                //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                sqlText.Append(" FROM SALCPRTCNCTINFRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                sqlText.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine);
                sqlText.Append(" ORDER BY SECTIONCODERF,  CUSTOMERCODERF" + Environment.NewLine);
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                SqlParameter findParaSupplierCdRF = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);
                findParaSupplierCdRF.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

                SqlParameter findParaCnectProgramType = sqlCommand.Parameters.Add("@FINDCNECTPROGRAMTYPERF", SqlDbType.Int);
                findParaCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(this.CopyToSalCprtConnectInfoWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "SalCprtConnectInfoPrcPrStDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalCprtConnectInfoPrcPrStDB.SearchProc", status);
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
        /// <br>Note       : �w�肳�ꂽ�ڑ�����ݒ�Guid�̐ڑ�����ݒ��߂��܂�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
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
        /// <br>Note       : �w�肳�ꂽ�ڑ�����ݒ�Guid�̐ڑ�����ݒ��߂��܂�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br>Update Note: 2020/02/04 ���c �`�[</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br>           :�i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            SalCprtConnectInfoWork connectInfoWork = new SalCprtConnectInfoWork();
            try
            {
                // XML�̓ǂݍ���
                connectInfoWork = (SalCprtConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(SalCprtConnectInfoWork));

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
                sqlText.Append("    ,SECTIONCODERF" + Environment.NewLine);         //���_�R�[�h
                sqlText.Append("    ,CUSTOMERCODERF" + Environment.NewLine);        //���Ӑ�R�[�h
                sqlText.Append("    ,PROTOCOLRF" + Environment.NewLine);            //�v���g�R��
                sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);     //���O�C���^�C���A�E�g
                sqlText.Append("    ,CPRTDOMAINRF" + Environment.NewLine);          //�A�g��h���C��
                sqlText.Append("    ,CPRTURLRF" + Environment.NewLine);             //�A�g��URL
                sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);    //�ڑ��v���O�����^�C�v
                sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);         //�ڑ��t�@�C��ID
                sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);        //�ڑ����M�敪
                sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);      //�ڑ��Ώۋ敪
                sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);            //���g���C��
                sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);         //�������M�敪
                sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);            //�N������
                sqlText.Append("    ,ENDTIMERF" + Environment.NewLine);             //�I������
                sqlText.Append("    ,EXECINTERVALRF" + Environment.NewLine);        //���s�Ԋu
                sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);   //���M�[��(IP�A�h���X�j
                sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);     //���M�[��(�R���s���[�^�[���j
                sqlText.Append("    ,SENDCCNCTPASSRF" + Environment.NewLine);       //���M�ڑ��p�X���[�h
                sqlText.Append("    ,SENDCCNCTUSERIDRF" + Environment.NewLine);     //���M�ڑ����[�U�[�R�[�h
                sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);      //���W�ԍ�
                sqlText.Append("    ,LTATSADDATETIMERF" + Environment.NewLine);     //�O�񎩓����M����
                sqlText.Append("    ,FRSTSENDDATERF" + Environment.NewLine);        //���񑗐M���
                //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                sqlText.Append("    ,NOTE1SETDIVRF" + Environment.NewLine);         //���l�P�ݒ�敪
                sqlText.Append("    ,NOTE2SETDIVRF" + Environment.NewLine);         //���l�Q�ݒ�敪
                sqlText.Append("    ,NOTE3SETDIVRF" + Environment.NewLine);         //���l�R�ݒ�敪
                //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                sqlText.Append(" FROM SALCPRTCNCTINFRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine);
                sqlText.Append(" AND CUSTOMERCODERF=@FINDCUSTOMERCODERF " + Environment.NewLine);
                sqlText.Append(" AND LOGICALDELETECODERF=@FINDLOGICALDELETECODERF " + Environment.NewLine);
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                SqlParameter findParaSupplierCdRF = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.Int);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODERF", SqlDbType.Int);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODERF", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                findParaSupplierCdRF.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);
                int sectionCd = 0;
                if (connectInfoWork.SectionCode.Equals(""))
                {
                    sectionCd = 0;
                }
                else
                {
                    sectionCd = Convert.ToInt32(connectInfoWork.SectionCode);
                }
                findParaSectionCode.Value = SqlDataMediator.SqlSetInt32(sectionCd);
                findParaCustomerCode.Value = connectInfoWork.CustomerCode;
                findParaLogicalDeleteCode.Value = 0;

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    connectInfoWork = CopyToSalCprtConnectInfoWorkFromReader(ref myReader);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(connectInfoWork);


            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalCprtConnectInfoPrcPrStDB.ReadProc Exception=" + ex.Message);
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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br>Update Note: 2020/02/04 ���c �`�[</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br>           :�i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
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
                SalCprtConnectInfoWork connectInfoWork = (SalCprtConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(SalCprtConnectInfoWork));

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
                sqlText.Append("    ,SECTIONCODERF" + Environment.NewLine);         //���_�R�[�h
                sqlText.Append("    ,CUSTOMERCODERF" + Environment.NewLine);        //���Ӑ�R�[�h
                sqlText.Append("    ,PROTOCOLRF" + Environment.NewLine);            //�v���g�R��
                sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);     //���O�C���^�C���A�E�g
                sqlText.Append("    ,CPRTDOMAINRF" + Environment.NewLine);          //�A�g��h���C��
                sqlText.Append("    ,CPRTURLRF" + Environment.NewLine);             //�A�g��URL
                sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);    //�ڑ��v���O�����^�C�v
                sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);         //�ڑ��t�@�C��ID
                sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);        //�ڑ����M�敪
                sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);      //�ڑ��Ώۋ敪
                sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);            //���g���C��
                sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);         //�������M�敪
                sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);            //�N������
                sqlText.Append("    ,ENDTIMERF" + Environment.NewLine);             //�I������
                sqlText.Append("    ,EXECINTERVALRF" + Environment.NewLine);        //���s�Ԋu
                sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);   //���M�[��(IP�A�h���X�j
                sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);     //���M�[��(�R���s���[�^�[���j
                sqlText.Append("    ,SENDCCNCTPASSRF" + Environment.NewLine);       //���M�ڑ��p�X���[�h
                sqlText.Append("    ,SENDCCNCTUSERIDRF" + Environment.NewLine);     //���M�ڑ����[�U�[�R�[�h
                sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);      //���W�ԍ�
                sqlText.Append("    ,LTATSADDATETIMERF" + Environment.NewLine);     //�O�񎩓����M����
                sqlText.Append("    ,FRSTSENDDATERF" + Environment.NewLine);        //���񑗐M���
                //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                sqlText.Append("    ,NOTE1SETDIVRF" + Environment.NewLine);         //���l�P�ݒ�敪
                sqlText.Append("    ,NOTE2SETDIVRF" + Environment.NewLine);         //���l�Q�ݒ�敪
                sqlText.Append("    ,NOTE3SETDIVRF" + Environment.NewLine);         //���l�R�ݒ�敪
                //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                sqlText.Append(" FROM SALCPRTCNCTINFRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine);
                sqlText.Append(" AND CUSTOMERCODERF=@FINDCUSTOMERCODERF " + Environment.NewLine);
                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODERF", SqlDbType.Int);
                findParaSectionCode.Value = connectInfoWork.SectionCode;
                findParaCustomerCode.Value = connectInfoWork.CustomerCode;

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

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
                    sqlText_DELETE.Append(" DELETE FROM SALCPRTCNCTINFRF" + Environment.NewLine);
                    sqlText_DELETE.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                    sqlText_DELETE.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                    sqlText_DELETE.Append(" AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine);
                    sqlText_DELETE.Append(" AND CUSTOMERCODERF=@FINDCUSTOMERCODERF " + Environment.NewLine);
                    sqlCommand.CommandText = sqlText_DELETE.ToString();
                    # endregion

                    // KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);
                    findParaSectionCode.Value = connectInfoWork.SectionCode;
                    findParaCustomerCode.Value = connectInfoWork.CustomerCode;
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
                status = base.WriteSQLErrorLog(sqlex, "SalCprtConnectInfoPrcPrStDB.DeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalCprtConnectInfoPrcPrStDB.DeleteProc", status);
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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private int LogicalDeleteProc(ref object connectInfoWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SalCprtConnectInfoWork paraList = connectInfoWork as SalCprtConnectInfoWork;

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
                status = base.WriteSQLErrorLog(sqex, "SalCprtConnectInfoPrcPrStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalCprtConnectInfoPrcPrStDB.LogicalDeleteProc", status);
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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br>Update Note: 2020/02/04 ���c �`�[</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br>           :�i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// <br></br>
        /// </remarks>
        private int LogicalDeleteProc(ref SalCprtConnectInfoWork connectInfoWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                    sqlText.Append("    ,SECTIONCODERF" + Environment.NewLine);         //���_�R�[�h
                    sqlText.Append("    ,CUSTOMERCODERF" + Environment.NewLine);        //���Ӑ�R�[�h
                    sqlText.Append("    ,PROTOCOLRF" + Environment.NewLine);            //�v���g�R��
                    sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);     //���O�C���^�C���A�E�g
                    sqlText.Append("    ,CPRTDOMAINRF" + Environment.NewLine);          //�A�g��h���C��
                    sqlText.Append("    ,CPRTURLRF" + Environment.NewLine);             //�A�g��URL
                    sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);    //�ڑ��v���O�����^�C�v
                    sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);         //�ڑ��t�@�C��ID
                    sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);        //�ڑ����M�敪
                    sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);      //�ڑ��Ώۋ敪
                    sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);            //���g���C��
                    sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);         //�������M�敪
                    sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);            //�N������
                    sqlText.Append("    ,ENDTIMERF" + Environment.NewLine);             //�I������
                    sqlText.Append("    ,EXECINTERVALRF" + Environment.NewLine);        //���s�Ԋu
                    sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);   //���M�[��(IP�A�h���X�j
                    sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);     //���M�[��(�R���s���[�^�[���j
                    sqlText.Append("    ,SENDCCNCTPASSRF" + Environment.NewLine);       //���M�ڑ��p�X���[�h
                    sqlText.Append("    ,SENDCCNCTUSERIDRF" + Environment.NewLine);     //���M�ڑ����[�U�[�R�[�h
                    sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);      //���W�ԍ�
                    sqlText.Append("    ,LTATSADDATETIMERF" + Environment.NewLine);     //�O�񎩓����M����
                    sqlText.Append("    ,FRSTSENDDATERF" + Environment.NewLine);        //���񑗐M���
                    //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                    sqlText.Append("    ,NOTE1SETDIVRF" + Environment.NewLine);         //���l�P�ݒ�敪
                    sqlText.Append("    ,NOTE2SETDIVRF" + Environment.NewLine);         //���l�Q�ݒ�敪
                    sqlText.Append("    ,NOTE3SETDIVRF" + Environment.NewLine);         //���l�R�ݒ�敪
                    //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                    sqlText.Append(" FROM SALCPRTCNCTINFRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                    sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                    sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine);
                    sqlText.Append(" AND CUSTOMERCODERF=@FINDCUSTOMERCODERF " + Environment.NewLine);
                    sqlCommand.CommandText = sqlText.ToString();
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODERF", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);
                    findParaSectionCode.Value = connectInfoWork.SectionCode;
                    findParaCustomerCode.Value = connectInfoWork.CustomerCode;

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
                        sqlText_UPDATE.Append("UPDATE SALCPRTCNCTINFRF" + Environment.NewLine);
                        sqlText_UPDATE.Append("    SET UPDATEDATETIMERF=@UPDATEDATETIMERF" + Environment.NewLine);
                        sqlText_UPDATE.Append("    ,LOGICALDELETECODERF=@LOGICALDELETECODERF" + Environment.NewLine);
                        sqlText_UPDATE.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND CUSTOMERCODERF=@FINDCUSTOMERCODERF " + Environment.NewLine);

                        sqlCommand.CommandText = sqlText_UPDATE.ToString();
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);
                        findParaSectionCode.Value = connectInfoWork.SectionCode;
                        findParaCustomerCode.Value = connectInfoWork.CustomerCode;

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
                status = base.WriteSQLErrorLog(sqex, "SalCprtConnectInfoPrcPrStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalCprtConnectInfoPrcPrStDB.LogicalDeleteProc", status);
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
        /// <param name="flag">���ԍX�V�t���O</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ڑ�����}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public int Write(ref object connectInfoWorkbyte, int writeMode, int flag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                SalCprtConnectInfoWork connectInfoWork = connectInfoWorkbyte as SalCprtConnectInfoWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = WriteProc(ref connectInfoWork, ref sqlConnection, ref sqlTransaction);

                // �S���̋N�����ԁA�I�����ԁA���s�Ԋu���X�V
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (flag == 1))
                {
                    status = UpdateDataTime(connectInfoWork, ref sqlConnection, ref sqlTransaction);
                }

                // �߂�l�Z�b�g
                connectInfoWorkbyte = connectInfoWork;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SalCprtConnectInfoPrcPrStDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalCprtConnectInfoPrcPrStDB.Write", status);
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
        /// �S���̋N�����ԁA�I�����ԁA���s�Ԋu���X�V
        /// </summary>
        /// <param name="connectInfoWork">�ǉ��E�X�V����ڑ�����}�X�^���</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �S���̋N�����ԁA�I�����ԁA���s�Ԋu���X�V���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private int UpdateDataTime(SalCprtConnectInfoWork connectInfoWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                IFileHeader flhd = (IFileHeader)new SalCprtConnectInfoWork();
                new FileHeader(this).SetUpdateHeader(ref flhd, this);
                string sqlText = string.Empty;
                sqlText += "UPDATE" + Environment.NewLine;
                sqlText += "  SALCPRTCNCTINFRF " + Environment.NewLine;
                sqlText += "SET" + Environment.NewLine;
                sqlText += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                sqlText += "  ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                sqlText += "  ,BOOTTIMERF=@BOOTTIME" + Environment.NewLine;
                sqlText += "  ,ENDTIMERF=@ENDTIME" + Environment.NewLine;
                sqlText += "  ,EXECINTERVALRF=@EXECINTERVAL" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraBootTime = sqlCommand.Parameters.Add("@BOOTTIME", SqlDbType.Int);
                    SqlParameter paraEndTime = sqlCommand.Parameters.Add("@ENDTIME", SqlDbType.Int);
                    SqlParameter paraExecInterval = sqlCommand.Parameters.Add("@EXECINTERVAL", SqlDbType.Int);

                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                    //KEY�R�}���h���Đݒ�
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(flhd.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(flhd.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(flhd.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(flhd.UpdAssemblyId2);
                    paraBootTime.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.BootTime);
                    paraEndTime.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.EndTime);
                    paraExecInterval.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.ExecInterval);

                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SalCprtConnectInfoPrcPrStDB.UpdateDataTime", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalCprtConnectInfoPrcPrStDB.UpdateDataTime", status);
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
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br>Update Note: 2020/02/04 ���c �`�[</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br>           :�i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// <br></br>
        /// </remarks>
        private int WriteProc(ref SalCprtConnectInfoWork connectInfoWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            SalCprtConnectInfoWork al = new SalCprtConnectInfoWork();

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
                    sqlText.Append("    ,SECTIONCODERF" + Environment.NewLine);         //���_�R�[�h
                    sqlText.Append("    ,CUSTOMERCODERF" + Environment.NewLine);        //���Ӑ�R�[�h
                    sqlText.Append("    ,PROTOCOLRF" + Environment.NewLine);            //�v���g�R��
                    sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);     //���O�C���^�C���A�E�g
                    sqlText.Append("    ,CPRTDOMAINRF" + Environment.NewLine);          //�A�g��h���C��
                    sqlText.Append("    ,CPRTURLRF" + Environment.NewLine);             //�A�g��URL
                    sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);    //�ڑ��v���O�����^�C�v
                    sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);         //�ڑ��t�@�C��ID
                    sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);        //�ڑ����M�敪
                    sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);      //�ڑ��Ώۋ敪
                    sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);            //���g���C��
                    sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);         //�������M�敪
                    sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);            //�N������
                    sqlText.Append("    ,ENDTIMERF" + Environment.NewLine);             //�I������
                    sqlText.Append("    ,EXECINTERVALRF" + Environment.NewLine);        //���s�Ԋu
                    sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);   //���M�[��(IP�A�h���X�j
                    sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);     //���M�[��(�R���s���[�^�[���j
                    sqlText.Append("    ,SENDCCNCTPASSRF" + Environment.NewLine);       //���M�ڑ��p�X���[�h
                    sqlText.Append("    ,SENDCCNCTUSERIDRF" + Environment.NewLine);     //���M�ڑ����[�U�[�R�[�h
                    sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);      //���W�ԍ�
                    sqlText.Append("    ,LTATSADDATETIMERF" + Environment.NewLine);     //�O�񎩓����M����
                    sqlText.Append("    ,FRSTSENDDATERF" + Environment.NewLine);        //���񑗐M���
                    //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                    sqlText.Append("    ,NOTE1SETDIVRF" + Environment.NewLine);         //���l�P�ݒ�敪
                    sqlText.Append("    ,NOTE2SETDIVRF" + Environment.NewLine);         //���l�Q�ݒ�敪
                    sqlText.Append("    ,NOTE3SETDIVRF" + Environment.NewLine);         //���l�R�ݒ�敪
                    //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                    sqlText.Append(" FROM SALCPRTCNCTINFRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                    sqlText.Append(" AND SUPPLIERCDRF=@FINDSUPPLIERCDRF " + Environment.NewLine);
                    sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODE " + Environment.NewLine);
                    sqlText.Append(" AND CUSTOMERCODERF=@FINDCUSTOMERCODE " + Environment.NewLine);
                    sqlCommand.CommandText = sqlText.ToString();
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCDRF", SqlDbType.Int);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = connectInfoWork.EnterpriseCode;
                    findParaSupplierCd.Value = connectInfoWork.SupplierCd;
                    findParaSectionCode.Value = connectInfoWork.SectionCode;
                    findParaCustomerCode.Value = connectInfoWork.CustomerCode;

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
                        sqlText_UPDATE.Append("UPDATE SALCPRTCNCTINFRF SET" + Environment.NewLine);
                        sqlText_UPDATE.Append("    UPDATEDATETIMERF=@UPDATEDATETIME," + Environment.NewLine);
                        sqlText_UPDATE.Append("    PROTOCOLRF=@PROTOCOL," + Environment.NewLine);                    //�v���g�R��
                        sqlText_UPDATE.Append("    LOGINTIMEOUTVALRF=@LOGINTIMEOUTVAL," + Environment.NewLine);      //���O�C���^�C���A�E�g
                        sqlText_UPDATE.Append("    CPRTDOMAINRF=@CPRTDOMAIN," + Environment.NewLine);                //�A�g��h���C��
                        sqlText_UPDATE.Append("    CPRTURLRF=@CPRTURL," + Environment.NewLine);                      //�A�g��URL
                        sqlText_UPDATE.Append("    CNECTPROGRAMTYPERF=@CNECTPROGRAMTYPE," + Environment.NewLine);    //�ڑ��v���O�����^�C�v
                        sqlText_UPDATE.Append("    CNECTFILEIDRF=@CNECTFILEID," + Environment.NewLine);              //�ڑ��t�@�C��ID
                        sqlText_UPDATE.Append("    CNECTSENDDIVRF=@CNECTSENDDIV," + Environment.NewLine);            //�ڑ����M�敪
                        sqlText_UPDATE.Append("    CNECTOBJECTDIVRF=@CNECTOBJECTDIV," + Environment.NewLine);        //�ڑ��Ώۋ敪
                        sqlText_UPDATE.Append("    RETRYCNTRF=@RETRYCNT," + Environment.NewLine);                    //���g���C��
                        sqlText_UPDATE.Append("    AUTOSENDDIVRF=@AUTOSENDDIV," + Environment.NewLine);              //�������M�敪
                        sqlText_UPDATE.Append("    BOOTTIMERF=@BOOTTIME," + Environment.NewLine);                    //�N������
                        sqlText_UPDATE.Append("    ENDTIMERF=@ENDTIME," + Environment.NewLine);                      //�I������
                        sqlText_UPDATE.Append("    EXECINTERVALRF=@EXECINTERVAL," + Environment.NewLine);            //���s�Ԋu
                        sqlText_UPDATE.Append("    SENDMACHINEIPADDRRF=@SENDMACHINEIPADDR," + Environment.NewLine);  //���M�[��(IP�A�h���X�j
                        sqlText_UPDATE.Append("    SENDMACHINENAMERF=@SENDMACHINENAME," + Environment.NewLine);      //���M�[��(�R���s���[�^�[���j
                        sqlText_UPDATE.Append("    SENDCCNCTPASSRF=@SENDCCNCTPASS," + Environment.NewLine);           //���M�ڑ��p�X���[�h
                        sqlText_UPDATE.Append("    SENDCCNCTUSERIDRF=@SENDCCNCTUSERID," + Environment.NewLine);       //���M�ڑ����[�U�[�R�[�h
                        sqlText_UPDATE.Append("    CASHREGISTERNORF=@CASHREGISTERNO," + Environment.NewLine);         //���W�ԍ�
                        sqlText_UPDATE.Append("    LTATSADDATETIMERF=@LTATSADDATETIME," + Environment.NewLine);       //�O�񎩓����M����
                        sqlText_UPDATE.Append("    FRSTSENDDATERF=@FRSTSENDDATE" + Environment.NewLine);              //���񑗐M���
                        //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                        sqlText_UPDATE.Append("    ,NOTE1SETDIVRF=@NOTE1SETDIV" + Environment.NewLine);               //���l�P�ݒ�敪
                        sqlText_UPDATE.Append("    ,NOTE2SETDIVRF=@NOTE2SETDIV" + Environment.NewLine);               //���l�Q�ݒ�敪
                        sqlText_UPDATE.Append("    ,NOTE3SETDIVRF=@NOTE3SETDIV" + Environment.NewLine);               //���l�R�ݒ�敪
                        //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                        sqlText_UPDATE.Append(" WHERE ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND SUPPLIERCDRF=@SUPPLIERCD " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND SECTIONCODERF=@FINDSECTIONCODE " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND CUSTOMERCODERF=@FINDCUSTOMERCODE " + Environment.NewLine);
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
                        sqlText_INSERT.Append("INSERT INTO SALCPRTCNCTINFRF" + Environment.NewLine);
                        sqlText_INSERT.Append(" (CREATEDATETIMERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  UPDATEDATETIMERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  ENTERPRISECODERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  FILEHEADERGUIDRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  UPDEMPLOYEECODERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  UPDASSEMBLYID1RF," + Environment.NewLine);
                        sqlText_INSERT.Append("  UPDASSEMBLYID2RF," + Environment.NewLine);
                        sqlText_INSERT.Append("  LOGICALDELETECODERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  SUPPLIERCDRF," + Environment.NewLine);
                        sqlText_INSERT.Append("    SECTIONCODERF," + Environment.NewLine);         //���_�R�[�h
                        sqlText_INSERT.Append("    CUSTOMERCODERF," + Environment.NewLine);        //���Ӑ�R�[�h
                        sqlText_INSERT.Append("    PROTOCOLRF," + Environment.NewLine);            //�v���g�R��
                        sqlText_INSERT.Append("    LOGINTIMEOUTVALRF," + Environment.NewLine);     //���O�C���^�C���A�E�g
                        sqlText_INSERT.Append("    CPRTDOMAINRF," + Environment.NewLine);          //�A�g��h���C��
                        sqlText_INSERT.Append("    CPRTURLRF," + Environment.NewLine);             //�A�g��URL
                        sqlText_INSERT.Append("    CNECTPROGRAMTYPERF," + Environment.NewLine);    //�ڑ��v���O�����^�C�v
                        sqlText_INSERT.Append("    CNECTFILEIDRF," + Environment.NewLine);         //�ڑ��t�@�C��ID
                        sqlText_INSERT.Append("    CNECTSENDDIVRF," + Environment.NewLine);        //�ڑ����M�敪
                        sqlText_INSERT.Append("    CNECTOBJECTDIVRF," + Environment.NewLine);      //�ڑ��Ώۋ敪
                        sqlText_INSERT.Append("    RETRYCNTRF," + Environment.NewLine);            //���g���C��
                        sqlText_INSERT.Append("    AUTOSENDDIVRF," + Environment.NewLine);         //�������M�敪
                        sqlText_INSERT.Append("    BOOTTIMERF," + Environment.NewLine);            //�N������
                        sqlText_INSERT.Append("    ENDTIMERF," + Environment.NewLine);             //�I������
                        sqlText_INSERT.Append("    EXECINTERVALRF," + Environment.NewLine);        //���s�Ԋu
                        sqlText_INSERT.Append("    SENDMACHINEIPADDRRF," + Environment.NewLine);   //���M�[��(IP�A�h���X�j
                        sqlText_INSERT.Append("    SENDMACHINENAMERF," + Environment.NewLine);     //���M�[��(�R���s���[�^�[���j
                        sqlText_INSERT.Append("    SENDCCNCTPASSRF," + Environment.NewLine);       //���M�ڑ��p�X���[�h
                        sqlText_INSERT.Append("    SENDCCNCTUSERIDRF," + Environment.NewLine);     //���M�ڑ����[�U�[�R�[�h
                        sqlText_INSERT.Append("    CASHREGISTERNORF," + Environment.NewLine);      //���W�ԍ�
                        sqlText_INSERT.Append("    LTATSADDATETIMERF," + Environment.NewLine);     //�O�񎩓����M����
                        //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                        //sqlText_INSERT.Append("    FRSTSENDDATERF)" + Environment.NewLine);        //���񑗐M���
                        sqlText_INSERT.Append("    FRSTSENDDATERF," + Environment.NewLine);        //���񑗐M���
                        sqlText_INSERT.Append("    NOTE1SETDIVRF," + Environment.NewLine);         //���l�P�ݒ�敪
                        sqlText_INSERT.Append("    NOTE2SETDIVRF," + Environment.NewLine);         //���l�Q�ݒ�敪
                        sqlText_INSERT.Append("    NOTE3SETDIVRF)" + Environment.NewLine);         //���l�R�ݒ�敪
                        //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                        sqlText_INSERT.Append("  VALUES (@CREATEDATETIME," + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDATEDATETIME, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @ENTERPRISECODE, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @FILEHEADERGUID," + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDEMPLOYEECODE," + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDASSEMBLYID1, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDASSEMBLYID2, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @LOGICALDELETECODE, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @SUPPLIERCD, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @SECTIONCODE, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @CUSTOMERCODE, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @PROTOCOL, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @LOGINTIMEOUTVAL," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CPRTDOMAIN," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CPRTURL," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CNECTPROGRAMTYPE," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CNECTFILEID," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CNECTSENDDIV," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CNECTOBJECTDIV," + Environment.NewLine);
                        sqlText_INSERT.Append("     @RETRYCNT," + Environment.NewLine);
                        sqlText_INSERT.Append("     @AUTOSENDDIV," + Environment.NewLine);
                        sqlText_INSERT.Append("     @BOOTTIME," + Environment.NewLine);
                        sqlText_INSERT.Append("     @ENDTIME," + Environment.NewLine);
                        sqlText_INSERT.Append("     @EXECINTERVAL," + Environment.NewLine);
                        sqlText_INSERT.Append("     @SENDMACHINEIPADDR," + Environment.NewLine);
                        sqlText_INSERT.Append("     @SENDMACHINENAME," + Environment.NewLine);
                        sqlText_INSERT.Append("     @SENDCCNCTPASS," + Environment.NewLine);
                        sqlText_INSERT.Append("     @SENDCCNCTUSERID," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CASHREGISTERNO," + Environment.NewLine);
                        sqlText_INSERT.Append("     @LTATSADDATETIME," + Environment.NewLine);
                        //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                        //sqlText_INSERT.Append("     @FRSTSENDDATE)" + Environment.NewLine);
                        sqlText_INSERT.Append("     @FRSTSENDDATE," + Environment.NewLine);
                        sqlText_INSERT.Append("     @NOTE1SETDIV," + Environment.NewLine);
                        sqlText_INSERT.Append("     @NOTE2SETDIV," + Environment.NewLine);
                        sqlText_INSERT.Append("     @NOTE3SETDIV)" + Environment.NewLine);
                        //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
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
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraProtocol = sqlCommand.Parameters.Add("@PROTOCOL", SqlDbType.Int);
                    SqlParameter paraLoginTimeoutVal = sqlCommand.Parameters.Add("@LOGINTIMEOUTVAL", SqlDbType.Int);
                    SqlParameter paraCprtDomain = sqlCommand.Parameters.Add("@CPRTDOMAIN", SqlDbType.NVarChar);
                    SqlParameter paraCprtUrl = sqlCommand.Parameters.Add("@CPRTURL", SqlDbType.NVarChar);
                    SqlParameter paraCnectProgramType = sqlCommand.Parameters.Add("@CNECTPROGRAMTYPE", SqlDbType.Int);
                    SqlParameter paraCnectFileId = sqlCommand.Parameters.Add("@CNECTFILEID", SqlDbType.NVarChar);
                    SqlParameter paraCnectSendDiv = sqlCommand.Parameters.Add("@CNECTSENDDIV", SqlDbType.Int);
                    SqlParameter paraCnectObjectDiv = sqlCommand.Parameters.Add("@CNECTOBJECTDIV", SqlDbType.Int);
                    SqlParameter paraRetryCnt = sqlCommand.Parameters.Add("@RETRYCNT", SqlDbType.Int);
                    SqlParameter paraAutoSendDiv = sqlCommand.Parameters.Add("@AUTOSENDDIV", SqlDbType.Int);
                    SqlParameter paraBootTime = sqlCommand.Parameters.Add("@BOOTTIME", SqlDbType.Int);
                    SqlParameter paraEndTime = sqlCommand.Parameters.Add("@ENDTIME", SqlDbType.Int);
                    SqlParameter paraExecInterval = sqlCommand.Parameters.Add("@EXECINTERVAL", SqlDbType.Int);
                    SqlParameter paraSendMachineIpAddr = sqlCommand.Parameters.Add("@SENDMACHINEIPADDR", SqlDbType.NVarChar);
                    SqlParameter paraSendMachineName = sqlCommand.Parameters.Add("@SENDMACHINENAME", SqlDbType.NVarChar);
                    SqlParameter paraSendCcnctPass = sqlCommand.Parameters.Add("@SENDCCNCTPASS", SqlDbType.NVarChar);
                    SqlParameter paraSendCcnctUserid = sqlCommand.Parameters.Add("@SENDCCNCTUSERID", SqlDbType.NVarChar);
                    SqlParameter paraCashregiSterno = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                    SqlParameter paraLtAtSadDateTime = sqlCommand.Parameters.Add("@LTATSADDATETIME", SqlDbType.BigInt);
                    SqlParameter paraFrstSendDate = sqlCommand.Parameters.Add("@FRSTSENDDATE", SqlDbType.Int);
                    //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                    SqlParameter paraNote1SetDiv = sqlCommand.Parameters.Add("@NOTE1SETDIV", SqlDbType.Int);
                    SqlParameter paraNote2SetDiv = sqlCommand.Parameters.Add("@NOTE2SETDIV", SqlDbType.Int);
                    SqlParameter paraNote3SetDiv = sqlCommand.Parameters.Add("@NOTE3SETDIV", SqlDbType.Int);
                    //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2


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
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.SectionCode);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CustomerCode);
                    paraProtocol.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.Protocol);
                    paraLoginTimeoutVal.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.LoginTimeoutVal);
                    paraCprtDomain.Value = SqlDataMediator.SqlSetString(connectInfoWork.CprtDomain);
                    paraCprtUrl.Value = SqlDataMediator.SqlSetString(connectInfoWork.CprtUrl);
                    paraCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                    paraCnectFileId.Value = SqlDataMediator.SqlSetString(connectInfoWork.CnectFileId);
                    paraCnectSendDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectSendDiv);
                    paraCnectObjectDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectObjectDiv);
                    paraRetryCnt.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.RetryCnt);
                    paraAutoSendDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.AutoSendDiv);
                    paraBootTime.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.BootTime);
                    paraEndTime.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.EndTime);
                    paraExecInterval.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.ExecInterval);
                    paraSendMachineIpAddr.Value = SqlDataMediator.SqlSetString(connectInfoWork.SendMachineIpAddr);
                    paraSendMachineName.Value = SqlDataMediator.SqlSetString(connectInfoWork.SendMachineName);
                    paraSendCcnctPass.Value = SqlDataMediator.SqlSetString(connectInfoWork.SendCcnctPass);
                    paraSendCcnctUserid.Value = SqlDataMediator.SqlSetString(connectInfoWork.SendCcnctUserid);
                    paraCashregiSterno.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CashregiSterno);
                    paraLtAtSadDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(connectInfoWork.LtAtSadDateTime);
                    paraFrstSendDate.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.FrstSendDate);
                    //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                    paraNote1SetDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.Note1SetDiv);
                    paraNote2SetDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.Note2SetDiv);
                    paraNote3SetDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.Note3SetDiv);
                    //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2


                    sqlCommand.ExecuteNonQuery();
                    al = connectInfoWork;

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SalCprtConnectInfoPrcPrStDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalCprtConnectInfoPrcPrStDB.WriteProc", status);
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
