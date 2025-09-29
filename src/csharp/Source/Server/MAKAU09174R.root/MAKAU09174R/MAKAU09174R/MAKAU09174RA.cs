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
	/// ����������p�^�[���ݒ�}�X�^�ݒ�DB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : ����������p�^�[���ݒ�}�X�^�ݒ�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 22035 �O�� �O��</br>
	/// <br>Date       : 2007.07.02</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
    [Serializable]
    public class DmdPrtPtnSetDB : RemoteDB, IDmdPrtPtnSetDB
    {
        #region constructor
        /// <summary>
        /// ����������p�^�[���ݒ�}�X�^�ݒ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        /// </remarks>
        public DmdPrtPtnSetDB()
            :
        base("MAKAU09176D", "Broadleaf.Application.Remoting.ParamData.DmdPrtPtnSetWork", "DMDPRTPTNSETRF")
        {
        }
        #endregion

        #region Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̐���������p�^�[���ݒ�}�X�^�ݒ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̐���������p�^�[���ݒ�}�X�^�ݒ�LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        public int Search(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            try
            {
                return SearchProc(out retobj, paraobj, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DmdPrtPtnSetDB.Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)");
                retobj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̐���������p�^�[���ݒ�}�X�^�ݒ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̐���������p�^�[���ݒ�}�X�^�ݒ�LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        private int SearchProc(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlEncryptInfo sqlEncryptInfo = null;
            SqlDataReader myReader = null;

            DmdPrtPtnSetWork dmdPrtPtnSetWork = null;
            DmdPrtPtnSetWork wkDmdPrtPtnSetWork = null;

            retobj = null;

            ArrayList al = new ArrayList();
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                dmdPrtPtnSetWork = paraobj as DmdPrtPtnSetWork;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "SELECT " 
                    + "DPS.CREATEDATETIMERF DPS_CREATEDATETIMERF, "
                    + "DPS.UPDATEDATETIMERF DPS_UPDATEDATETIMERF, "
                    + "DPS.ENTERPRISECODERF DPS_ENTERPRISECODERF, "
                    + "DPS.FILEHEADERGUIDRF DPS_FILEHEADERGUIDRF, "
                    + "DPS.UPDEMPLOYEECODERF DPS_UPDEMPLOYEECODERF, "
                    + "DPS.UPDASSEMBLYID1RF DPS_UPDASSEMBLYID1RF, "
                    + "DPS.UPDASSEMBLYID2RF DPS_UPDASSEMBLYID2RF, "
                    + "DPS.LOGICALDELETECODERF DPS_LOGICALDELETECODERF, "
                    + "DPS.SECTIONCODERF DPS_SECTIONCODERF, "
                    + "DPS.CUSTOMERCODERF DPS_CUSTOMERCODERF, "
                    + "DPS.DEMANDPTNNORF DPS_DEMANDPTNNORF, "
                    + "DPS.DMDDTLPTNNORF DPS_DMDDTLPTNNORF, "
                    + "DPP.DEMANDPTNNONMRF DPP_DEMANDPTNNONMRF, "
                    + "DDP.DMDDTLPTNNONMRF DDP_DMDDTLPTNNONMRF, "
                    + "CAST(DECRYPTBYKEY(CST.NAMERF) AS NVARCHAR(30)) AS CST_NAMERF, "
                    + "CAST(DECRYPTBYKEY(CST.NAME2RF) AS NVARCHAR(30)) AS CST_NAME2RF "
                    + "FROM DMDPRTPTNSETRF DPS ";
                
                //sqlCommand.CommandText = "SELECT * FROM DMDPRTPTNSETRF ";

                //�f�[�^�Ǎ�
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand.CommandText += "LEFT JOIN DMDPRTPTNRF DPP ON DPP.ENTERPRISECODERF=DPS.ENTERPRISECODERF AND DPP.DEMANDPTNNORF=DPS.DEMANDPTNNORF AND DPP.LOGICALDELETECODERF=0 LEFT JOIN DMDDTLPRTPTNRF DDP ON DDP.ENTERPRISECODERF=DPS.ENTERPRISECODERF AND DDP.DMDDTLPTNNORF=DPS.DMDDTLPTNNORF AND DDP.LOGICALDELETECODERF=0 LEFT JOIN CUSTOMERRF CST ON CST.ENTERPRISECODERF=DPS.ENTERPRISECODERF AND CST.CUSTOMERCODERF=DPS.CUSTOMERCODERF WHERE DPS.ENTERPRISECODERF=@FINDENTERPRISECODE AND DPS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                    //sqlCommand.CommandText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand.CommandText += "LEFT JOIN DMDPRTPTNRF DPP ON DPP.ENTERPRISECODERF=DPS.ENTERPRISECODERF AND DPP.DEMANDPTNNORF=DPS.DEMANDPTNNORF  AND DPP.LOGICALDELETECODERF=0 LEFT JOIN DMDDTLPRTPTNRF DDP ON DDP.ENTERPRISECODERF=DPS.ENTERPRISECODERF AND DDP.DMDDTLPTNNORF=DPS.DMDDTLPTNNORF AND DDP.LOGICALDELETECODERF=0 LEFT JOIN CUSTOMERRF CST ON CST.ENTERPRISECODERF=DPS.ENTERPRISECODERF AND CST.CUSTOMERCODERF=DPS.CUSTOMERCODERF WHERE DPS.ENTERPRISECODERF=@FINDENTERPRISECODE AND DPS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
                    //sqlCommand.CommandText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlCommand.CommandText += "LEFT JOIN DMDPRTPTNRF DPP ON DPP.ENTERPRISECODERF=DPS.ENTERPRISECODERF AND DPP.DEMANDPTNNORF=DPS.DEMANDPTNNORF  AND DPP.LOGICALDELETECODERF=0 LEFT JOIN DMDDTLPRTPTNRF DDP ON DDP.ENTERPRISECODERF=DPS.ENTERPRISECODERF AND DDP.DMDDTLPTNNORF=DPS.DMDDTLPTNNORF AND DDP.LOGICALDELETECODERF=0 LEFT JOIN CUSTOMERRF CST ON CST.ENTERPRISECODERF=DPS.ENTERPRISECODERF AND CST.CUSTOMERCODERF=DPS.CUSTOMERCODERF WHERE DPS.ENTERPRISECODERF=@FINDENTERPRISECODE";
                    //sqlCommand.CommandText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                }
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value        = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.EnterpriseCode);

                //2007.07.05 22035 �O�� add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
                if ((dmdPrtPtnSetWork.SectionCode != null) && (dmdPrtPtnSetWork.SectionCode != ""))
                {
                    sqlCommand.CommandText += " AND DPS.SECTIONCODERF=@FINDSECTIONCODE";
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.SectionCode);
                }
                //2007.07.05 22035 �O�� add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<END

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    wkDmdPrtPtnSetWork = new DmdPrtPtnSetWork();

                    #region �l�̃Z�b�g(�p�^�[�����̎擾�Ή�)
                    wkDmdPrtPtnSetWork.CreateDateTime    = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("DPS_CREATEDATETIMERF"));
                    wkDmdPrtPtnSetWork.UpdateDateTime    = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("DPS_UPDATEDATETIMERF"));
                    wkDmdPrtPtnSetWork.EnterpriseCode    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DPS_ENTERPRISECODERF"));
                    wkDmdPrtPtnSetWork.FileHeaderGuid    = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("DPS_FILEHEADERGUIDRF"));
                    wkDmdPrtPtnSetWork.UpdEmployeeCode   = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DPS_UPDEMPLOYEECODERF"));
                    wkDmdPrtPtnSetWork.UpdAssemblyId1    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DPS_UPDASSEMBLYID1RF"));
                    wkDmdPrtPtnSetWork.UpdAssemblyId2    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DPS_UPDASSEMBLYID2RF"));
                    wkDmdPrtPtnSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DPS_LOGICALDELETECODERF"));
                    wkDmdPrtPtnSetWork.SectionCode       = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DPS_SECTIONCODERF"));
                    wkDmdPrtPtnSetWork.CustomerCode      = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DPS_CUSTOMERCODERF"));
                    wkDmdPrtPtnSetWork.DemandPtnNo       = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DPS_DEMANDPTNNORF"));
                    wkDmdPrtPtnSetWork.DmdDtlPtnNo       = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DPS_DMDDTLPTNNORF"));
                    wkDmdPrtPtnSetWork.DemandPtnNoNm     = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DPP_DEMANDPTNNONMRF"));
                    wkDmdPrtPtnSetWork.DmdDtlPtnNoNm     = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DDP_DMDDTLPTNNONMRF"));
                    wkDmdPrtPtnSetWork.Name              = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CST_NAMERF"));
                    wkDmdPrtPtnSetWork.Name2             = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CST_NAME2RF"));
                    #endregion

                    #region �l�̃Z�b�g(�}�X�^���̂ݎ擾���폜)
                    /*
                    wkDmdPrtPtnSetWork.CreateDateTime    = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkDmdPrtPtnSetWork.UpdateDateTime    = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkDmdPrtPtnSetWork.EnterpriseCode    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkDmdPrtPtnSetWork.FileHeaderGuid    = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkDmdPrtPtnSetWork.UpdEmployeeCode   = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkDmdPrtPtnSetWork.UpdAssemblyId1    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkDmdPrtPtnSetWork.UpdAssemblyId2    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkDmdPrtPtnSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkDmdPrtPtnSetWork.SectionCode       = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkDmdPrtPtnSetWork.CustomerCode      = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    wkDmdPrtPtnSetWork.DemandPtnNo       = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEMANDPTNNORF"));
                    wkDmdPrtPtnSetWork.DmdDtlPtnNo       = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMDDTLPTNNORF"));
                    */
                    #endregion

                    al.Add(wkDmdPrtPtnSetWork);

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
                if (!myReader.IsClosed) myReader.Close();

                if ((sqlEncryptInfo != null) && (sqlEncryptInfo.IsOpen)) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            retobj = al;
            return status;
        }
        #endregion
        
        #region Read
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̐���������p�^�[���ݒ�}�X�^�ݒ��߂��܂�
        /// </summary>
        /// <param name="parabyte">DmdPrtPtnSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̐���������p�^�[���ݒ�}�X�^�ݒ��߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            return this.ReadProc(ref parabyte, readMode); 
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̐���������p�^�[���ݒ�}�X�^�ݒ��߂��܂�
        /// </summary>
        /// <param name="parabyte">DmdPrtPtnSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̐���������p�^�[���ݒ�}�X�^�ݒ��߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        private int ReadProc( ref byte[] parabyte, int readMode )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                SqlConnection sqlConnection = null;
                SqlEncryptInfo sqlEncryptInfo = null;

                SqlDataReader myReader = null;

                DmdPrtPtnSetWork dmdPrtPtnSetWork = new DmdPrtPtnSetWork();

                try
                {
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    // XML�̓ǂݍ���
                    dmdPrtPtnSetWork = (DmdPrtPtnSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(DmdPrtPtnSetWork));

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                    sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                    //Select�R�}���h�̐���
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT "
                    + "DPS.CREATEDATETIMERF DPS_CREATEDATETIMERF, "
                    + "DPS.UPDATEDATETIMERF DPS_UPDATEDATETIMERF, "
                    + "DPS.ENTERPRISECODERF DPS_ENTERPRISECODERF, "
                    + "DPS.FILEHEADERGUIDRF DPS_FILEHEADERGUIDRF, "
                    + "DPS.UPDEMPLOYEECODERF DPS_UPDEMPLOYEECODERF, "
                    + "DPS.UPDASSEMBLYID1RF DPS_UPDASSEMBLYID1RF, "
                    + "DPS.UPDASSEMBLYID2RF DPS_UPDASSEMBLYID2RF, "
                    + "DPS.LOGICALDELETECODERF DPS_LOGICALDELETECODERF, "
                    + "DPS.SECTIONCODERF DPS_SECTIONCODERF, "
                    + "DPS.CUSTOMERCODERF DPS_CUSTOMERCODERF, "
                    + "DPS.DEMANDPTNNORF DPS_DEMANDPTNNORF, "
                    + "DPS.DMDDTLPTNNORF DPS_DMDDTLPTNNORF, "
                    + "DPP.DEMANDPTNNONMRF DPP_DEMANDPTNNONMRF, "
                    + "DDP.DMDDTLPTNNONMRF DDP_DMDDTLPTNNONMRF, "
                    + "CAST(DECRYPTBYKEY(CST.NAMERF) AS NVARCHAR(30)) AS CST_NAMERF, "
                    + "CAST(DECRYPTBYKEY(CST.NAME2RF) AS NVARCHAR(30)) AS CST_NAME2RF "
                    + "FROM DMDPRTPTNSETRF DPS "
                    + "LEFT JOIN DMDPRTPTNRF DPP ON DPP.ENTERPRISECODERF=DPS.ENTERPRISECODERF AND DPP.DEMANDPTNNORF=DPS.DEMANDPTNNORF AND DPP.LOGICALDELETECODERF=0 "
                    + "LEFT JOIN DMDDTLPRTPTNRF DDP ON DDP.ENTERPRISECODERF=DPS.ENTERPRISECODERF AND DDP.DMDDTLPTNNORF=DPS.DMDDTLPTNNORF AND DDP.LOGICALDELETECODERF=0"
                    + "LEFT JOIN CUSTOMERRF CST ON CST.ENTERPRISECODERF=DPS.ENTERPRISECODERF AND CST.CUSTOMERCODERF=DPS.CUSTOMERCODERF "
                    + "WHERE DPS.ENTERPRISECODERF=@FINDENTERPRISECODE AND DPS.SECTIONCODERF=@FINDSECTIONCODERF AND DPS.CUSTOMERCODERF=@FINDCUSTOMERCODERF", sqlConnection))

                    ////Select�R�}���h�̐���
                    //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM DMDPRTPTNSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODERF AND CUSTOMERCODERF=@FINDCUSTOMERCODERF", sqlConnection))
                    {
                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODERF", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnSetWork.CustomerCode);

                        myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                        if (myReader.Read())
                        {

                            #region �l�̃Z�b�g(�p�^�[�����̎擾�Ή�)
                            dmdPrtPtnSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("DPS_CREATEDATETIMERF"));
                            dmdPrtPtnSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("DPS_UPDATEDATETIMERF"));
                            dmdPrtPtnSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DPS_ENTERPRISECODERF"));
                            dmdPrtPtnSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("DPS_FILEHEADERGUIDRF"));
                            dmdPrtPtnSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DPS_UPDEMPLOYEECODERF"));
                            dmdPrtPtnSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DPS_UPDASSEMBLYID1RF"));
                            dmdPrtPtnSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DPS_UPDASSEMBLYID2RF"));
                            dmdPrtPtnSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DPS_LOGICALDELETECODERF"));
                            dmdPrtPtnSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DPS_SECTIONCODERF"));
                            dmdPrtPtnSetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DPS_CUSTOMERCODERF"));
                            dmdPrtPtnSetWork.DemandPtnNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DPS_DEMANDPTNNORF"));
                            dmdPrtPtnSetWork.DmdDtlPtnNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DPS_DMDDTLPTNNORF"));
                            dmdPrtPtnSetWork.DemandPtnNoNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DPP_DEMANDPTNNONMRF"));
                            dmdPrtPtnSetWork.DmdDtlPtnNoNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DDP_DMDDTLPTNNONMRF"));
                            dmdPrtPtnSetWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CST_NAMERF"));
                            dmdPrtPtnSetWork.Name2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CST_NAME2RF"));
                            #endregion

                            #region �l�̃Z�b�g(�}�X�^���̂ݎ擾���폜)
                            /*
                            dmdPrtPtnSetWork.CreateDateTime    = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                            dmdPrtPtnSetWork.UpdateDateTime    = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                            dmdPrtPtnSetWork.EnterpriseCode    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                            dmdPrtPtnSetWork.FileHeaderGuid    = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                            dmdPrtPtnSetWork.UpdEmployeeCode   = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                            dmdPrtPtnSetWork.UpdAssemblyId1    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                            dmdPrtPtnSetWork.UpdAssemblyId2    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                            dmdPrtPtnSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                            dmdPrtPtnSetWork.SectionCode       = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                            dmdPrtPtnSetWork.CustomerCode      = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                            dmdPrtPtnSetWork.DemandPtnNo       = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEMANDPTNNORF"));
                            dmdPrtPtnSetWork.DmdDtlPtnNo       = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMDDTLPTNNORF"));
                            */
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
                finally
                {
                    if (!myReader.IsClosed) myReader.Close();

                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                    }
                }

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(dmdPrtPtnSetWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DmdPrtPtnSetDB.Read");
            }
            return status;
        }
        #endregion

        #region Write(ref byte[] parabyte)
        
        /// <summary>
        /// ����������p�^�[���ݒ�}�X�^�ݒ����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="parabyte">DmdPrtPtnSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����������p�^�[���ݒ�}�X�^�ݒ����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        public int Write(ref byte[] parabyte)
        {
            return this.WriteProc(ref parabyte);
        }

        /// <summary>
        /// ����������p�^�[���ݒ�}�X�^�ݒ����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="parabyte">DmdPrtPtnSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����������p�^�[���ݒ�}�X�^�ݒ����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        private int WriteProc( ref byte[] parabyte )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                SqlConnection sqlConnection = null;
                SqlDataReader myReader = null;
                try
                {
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    // XML�̓ǂݍ���
                    DmdPrtPtnSetWork dmdPrtPtnSetWork = (DmdPrtPtnSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(DmdPrtPtnSetWork));

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    //Select�R�}���h�̐���
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM DMDPRTPTNSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODERF AND CUSTOMERCODERF=@FINDCUSTOMERCODERF", sqlConnection))
                    {
                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODERF", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnSetWork.CustomerCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != dmdPrtPtnSetWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (dmdPrtPtnSetWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (!myReader.IsClosed) myReader.Close();
                                sqlConnection.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE DMDPRTPTNSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME, FILEHEADERGUIDRF=@FILEHEADERGUID, UPDEMPLOYEECODERF=@UPDEMPLOYEECODE, UPDASSEMBLYID1RF=@UPDASSEMBLYID1, UPDASSEMBLYID2RF=@UPDASSEMBLYID2, LOGICALDELETECODERF=@LOGICALDELETECODE, SECTIONCODERF=@SECTIONCODE, CUSTOMERCODERF=@CUSTOMERCODE, DEMANDPTNNORF=@DEMANDPTNNO, DMDDTLPTNNORF=@DMDDTLPTNNO WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODERF AND CUSTOMERCODERF=@FINDCUSTOMERCODERF";
                            //KEY�R�}���h���Đݒ�
                            //Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.SectionCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnSetWork.CustomerCode);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)dmdPrtPtnSetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (dmdPrtPtnSetWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (!myReader.IsClosed) myReader.Close();
                                sqlConnection.Close();
                                return status;
                            }

                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = "INSERT INTO DMDPRTPTNSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CUSTOMERCODERF, DEMANDPTNNORF, DMDDTLPTNNORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @CUSTOMERCODE, @DEMANDPTNNO, @DMDDTLPTNNO) ";

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)dmdPrtPtnSetWork;
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
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraDemandPtnNo = sqlCommand.Parameters.Add("@DEMANDPTNNO", SqlDbType.Int);
                        SqlParameter paraDmdDtlPtnNo = sqlCommand.Parameters.Add("@DMDDTLPTNNO", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dmdPrtPtnSetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dmdPrtPtnSetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dmdPrtPtnSetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnSetWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.SectionCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnSetWork.CustomerCode);
                        paraDemandPtnNo.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnSetWork.DemandPtnNo);
                        paraDmdDtlPtnNo.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnSetWork.DmdDtlPtnNo);

                        sqlCommand.ExecuteNonQuery();

                        // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                        parabyte = XmlByteSerializer.Serialize(dmdPrtPtnSetWork);
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
                    if (myReader.IsClosed == false) myReader.Close();
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DmdPrtPtnSetDB.Write");
            }

            return status;
        }
        #endregion

        #region Delete
        /// <summary>
        /// ����������p�^�[���ݒ�}�X�^�ݒ���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">����������p�^�[���ݒ�}�X�^�ݒ�I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ����������p�^�[���ݒ�}�X�^�ݒ���𕨗��폜���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        public int Delete(byte[] parabyte)
        {
            return this.DeleteProc(parabyte);
        }

        /// <summary>
        /// ����������p�^�[���ݒ�}�X�^�ݒ���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">����������p�^�[���ݒ�}�X�^�ݒ�I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ����������p�^�[���ݒ�}�X�^�ݒ���𕨗��폜���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        private int DeleteProc( byte[] parabyte )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                SqlConnection sqlConnection = null;
                SqlDataReader myReader = null;

                try
                {
                    //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    DmdPrtPtnSetWork dmdPrtPtnSetWork = (DmdPrtPtnSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(DmdPrtPtnSetWork));

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM DMDPRTPTNSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODERF AND CUSTOMERCODERF=@FINDCUSTOMERCODERF", sqlConnection))
                    {
                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODERF", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnSetWork.CustomerCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != dmdPrtPtnSetWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (!myReader.IsClosed) myReader.Close();
                                sqlConnection.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "DELETE FROM DMDPRTPTNSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODERF AND CUSTOMERCODERF=@FINDCUSTOMERCODERF";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.SectionCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnSetWork.CustomerCode);
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
                finally
                {
                    if (myReader.IsClosed == false) myReader.Close();
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DmdPrtPtnSetDB.Delete");
            }
            return status;
        }
        #endregion

        #region LogicalDelete & Revival
        /// <summary>
        /// ����������p�^�[���ݒ�}�X�^�ݒ����_���폜���܂�
        /// </summary>
        /// <param name="parabyte">DmdPrtPtnSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����������p�^�[���ݒ�}�X�^�ݒ����_���폜���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        public int LogicalDelete(ref byte[] parabyte)
        {
            try
            {
                return LogicalDeleteProc(ref parabyte, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DmdPrtPtnSetDB.LogicalDelete");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// �_���폜����������p�^�[���ݒ�}�X�^�ݒ���𕜊����܂�
        /// </summary>
        /// <param name="parabyte">DmdPrtPtnSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜����������p�^�[���ݒ�}�X�^�ݒ���𕜊����܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        public int Revival(ref byte[] parabyte)
        {
            try
            {
                return LogicalDeleteProc(ref parabyte, 1);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DmdPrtPtnSetDB.Revival");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// ����������p�^�[���ݒ�}�X�^�ݒ���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="parabyte">DmdPrtPtnSetWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����������p�^�[���ݒ�}�X�^�ݒ���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        private int LogicalDeleteProc(ref byte[] parabyte, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                // XML�̓ǂݍ���
                DmdPrtPtnSetWork dmdPrtPtnSetWork = (DmdPrtPtnSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(DmdPrtPtnSetWork));

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF , LOGICALDELETECODERF FROM DMDPRTPTNSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODERF AND CUSTOMERCODERF=@FINDCUSTOMERCODERF", sqlConnection))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode    = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode   = sqlCommand.Parameters.Add("@FINDCUSTOMERCODERF", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.EnterpriseCode);
                    findParaSectionCode.Value    = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.SectionCode);
                    findParaCustomerCode.Value   = SqlDataMediator.SqlSetInt32(dmdPrtPtnSetWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != dmdPrtPtnSetWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (!myReader.IsClosed) myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }
                        //���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        sqlCommand.CommandText = "UPDATE DMDPRTPTNSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME, UPDEMPLOYEECODERF=@UPDEMPLOYEECODE, UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODERF AND CUSTOMERCODERF=@FINDCUSTOMERCODERF";

                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.EnterpriseCode);
                        findParaSectionCode.Value    = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.SectionCode);
                        findParaCustomerCode.Value   = SqlDataMediator.SqlSetInt32(dmdPrtPtnSetWork.CustomerCode);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)dmdPrtPtnSetWork;
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
                        else if (logicalDelCd == 0) dmdPrtPtnSetWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                        else dmdPrtPtnSetWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                    }
                    else
                    {
                        if (logicalDelCd == 1) dmdPrtPtnSetWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                    SqlParameter paraUpdateDateTime    = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode   = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1    = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2    = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdateDateTime.Value    = SqlDataMediator.SqlSetDateTimeFromTicks(dmdPrtPtnSetWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value   = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value    = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value    = SqlDataMediator.SqlSetString(dmdPrtPtnSetWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnSetWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();

                    // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                    parabyte = XmlByteSerializer.Serialize(dmdPrtPtnSetWork);
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
                if (myReader.IsClosed == false) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }

            return status;

        }
        #endregion
    }
}

