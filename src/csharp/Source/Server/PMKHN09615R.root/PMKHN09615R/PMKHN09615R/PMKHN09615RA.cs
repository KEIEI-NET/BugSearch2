//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[�������D��ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �L�����y�[�������D��ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
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

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// �L�����y�[�������D��ݒ�DB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
    /// <br>Note       : �L�����y�[�������D��ݒ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���N�n��</br>
	/// <br>Date       : 2011/04/25</br>
    /// </remarks>
	[Serializable]
    public class CampaignPrcPrStDB : RemoteDB, ICampaignPrcPrStDB
	{
        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public CampaignPrcPrStDB()
            : base("PMKHN09617D", "Broadleaf.Application.Remoting.ParamData.CampaignPrcPrStWork", "CAMPAIGNPRCPRSTRF")
        {

        }

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CampaignPrcPrStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CampaignPrcPrStWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private CampaignPrcPrStWork CopyToCampaignPrcPrStWorkFromReader(ref SqlDataReader myReader)
        {
            CampaignPrcPrStWork campaignPrcPrStWork = new CampaignPrcPrStWork();

            this.CopyToCampaignPrcPrStWorkFromReader(ref myReader, ref campaignPrcPrStWork);

            return campaignPrcPrStWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� CampaignPrcPrStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="campaignPrcPrStWork">CampaignPrcPrStWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void CopyToCampaignPrcPrStWorkFromReader(ref SqlDataReader myReader, ref CampaignPrcPrStWork campaignPrcPrStWork)
        {
            if (myReader != null && campaignPrcPrStWork != null)
            {
                # region �N���X�֊i�[
                campaignPrcPrStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                campaignPrcPrStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                campaignPrcPrStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                campaignPrcPrStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                campaignPrcPrStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                campaignPrcPrStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                campaignPrcPrStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                campaignPrcPrStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                campaignPrcPrStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                campaignPrcPrStWork.PrioritySettingCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD1RF"));
                campaignPrcPrStWork.PrioritySettingCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD2RF"));
                campaignPrcPrStWork.PrioritySettingCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD3RF"));
                campaignPrcPrStWork.PrioritySettingCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD4RF"));
                campaignPrcPrStWork.PrioritySettingCd5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD5RF"));
                campaignPrcPrStWork.PrioritySettingCd6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD6RF"));

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
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
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
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
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


        #region ICampaignPrcPrStDB �����o

        #region Search
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̃L�����y�[�������D��ݒ�LIST��S�Ė߂��܂��B
        /// </summary>
        /// <param name="outCampaignPrcPrSt">��������</param>
        /// <param name="paraCampaignPrcPrStWork">�p�����[</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃L�����y�[�������D��ݒ�LIST��S�Ė߂��܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Search(out object outCampaignPrcPrSt, object paraCampaignPrcPrStWork, int readMode, Broadleaf.Library.Resources.ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList campaignPrcPrStList = null;
            CampaignPrcPrStWork campaignPrcPrStWork = null;

            outCampaignPrcPrSt = new CustomSerializeArrayList();

            try
            {
                campaignPrcPrStWork = paraCampaignPrcPrStWork as CampaignPrcPrStWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // ����
                status = this.SearchProc(out campaignPrcPrStList, campaignPrcPrStWork, readMode, logicalMode, ref sqlConnection);

                if (campaignPrcPrStList != null)
                {
                    (outCampaignPrcPrSt as CustomSerializeArrayList).AddRange(campaignPrcPrStList);
                }

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "CampaignPrcPrStDB.Search", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignPrcPrStDB.Search", status);
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
        /// �w�肳�ꂽ��ƃR�[�h�̃L�����y�[�������D��ݒ�LIST��S�Ė߂��܂��B
        /// </summary>
        /// <param name="campaignPrcPrStList">��������</param>
        /// <param name="campaignPrcPrStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃L�����y�[�������D��ݒ�LIST��S�Ė߂��܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int SearchProc(out ArrayList campaignPrcPrStList, CampaignPrcPrStWork campaignPrcPrStWork, int readMode, Broadleaf.Library.Resources.ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                String sqlText = null;
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD1RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD2RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD3RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD4RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD5RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD6RF" + Environment.NewLine;
                sqlText += " FROM CAMPAIGNPRCPRSTRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(this.CopyToCampaignPrcPrStWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "CampaignPrcPrStDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignPrcPrStDB.SearchProc", status);
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

            campaignPrcPrStList = al;

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�L�����y�[�������D��ݒ�Guid�̃L�����y�[�������D��ݒ��߂��܂�
        /// </summary>
        /// <param name="parabyte">CampaignPrcPrStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :  �w�肳�ꂽ�L�����y�[�������D��ݒ�Guid�̃L�����y�[�������D��ݒ��߂��܂�</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            return this.ReadProc(ref parabyte, readMode);
        }

        /// <summary>
        /// �w�肳�ꂽ�L�����y�[�������D��ݒ�Guid�̃L�����y�[�������D��ݒ��߂��܂�
        /// </summary>
        /// <param name="parabyte">CampaignPrcPrStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :  �w�肳�ꂽ�L�����y�[�������D��ݒ�Guid�̃L�����y�[�������D��ݒ��߂��܂�</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        private int ReadProc(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            CampaignPrcPrStWork campaignPrcPrStWork = new CampaignPrcPrStWork();
            try
            {
                // XML�̓ǂݍ���
                campaignPrcPrStWork = (CampaignPrcPrStWork)XmlByteSerializer.Deserialize(parabyte, typeof(CampaignPrcPrStWork));

                if (campaignPrcPrStWork == null)
                {
                    return status;
                }

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                String sqlText = null;
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD1RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD2RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD3RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD4RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD5RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD6RF" + Environment.NewLine;
                sqlText += " FROM CAMPAIGNPRCPRSTRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine;
                sqlText += " AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.SectionCode);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    campaignPrcPrStWork = CopyToCampaignPrcPrStWorkFromReader(ref myReader);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

               // XML�֕ϊ����A������̃o�C�i����
               parabyte = XmlByteSerializer.Serialize(campaignPrcPrStWork);


            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MediationCampaignPrcPrStDB.Read Exception=" + ex.Message);
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
        /// �L�����y�[�������D��ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">CampaignPrcPrStWork�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[�������D��ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        public int Delete(byte[] parabyte)
        {
            return this.DeleteProc(parabyte);
        }

        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">CampaignPrcPrStWork�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[�������D��ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        private int DeleteProc(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // XML�̓ǂݍ���
                CampaignPrcPrStWork campaignPrcPrStWork = (CampaignPrcPrStWork)XmlByteSerializer.Deserialize(parabyte, typeof(CampaignPrcPrStWork));

                if (campaignPrcPrStWork == null)
                {
                    return status;
                }
                string sqlText = string.Empty;
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                # region [SELECT��]
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD1RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD2RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD3RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD4RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD5RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD6RF" + Environment.NewLine;
                sqlText += " FROM CAMPAIGNPRCPRSTRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine;
                sqlText += " AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.SectionCode);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                    if (_updateDateTime != campaignPrcPrStWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        return status;
                    }

                    # region [DELETE��]
                    string sqlText_DELETE = string.Empty;
                    sqlText_DELETE += "DELETE FROM CAMPAIGNPRCPRSTRF" + Environment.NewLine;
                    sqlText_DELETE += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine;
                    sqlText_DELETE += " AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine;
                    sqlCommand.CommandText = sqlText_DELETE;
                    # endregion

                    // KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.SectionCode);
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
                status = base.WriteSQLErrorLog(sqlex, "CampaignPrcPrStDB.Delete", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignPrcPrStDB.DeleteProc", status);
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
        /// �L�����y�[�������D��ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="campaignPrcPrStWork">�_���폜����L�����y�[�������D��ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�������D��ݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int LogicalDelete(ref object campaignPrcPrStWork)
        {
            return this.LogicalDeleteProc(ref campaignPrcPrStWork, 0);
        }

        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="campaignPrcPrStWork">�_���폜����L�����y�[�������D��ݒ�}�X�^���</param>
        /// <param name="procMode">�_���폜���[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�������D��ݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int LogicalDeleteProc(ref object campaignPrcPrStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                CampaignPrcPrStWork paraList = campaignPrcPrStWork as CampaignPrcPrStWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDeleteProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                campaignPrcPrStWork = paraList;

            }
            catch (SqlException sqex)
            {
                status = base.WriteSQLErrorLog(sqex, "CampaignPrcPrStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignPrcPrStDB.LogicalDeleteProc", status);
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
        /// �L�����y�[�������D��ݒ�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="campaignPrcPrStWork">�_���폜����������L�����y�[�������D��ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�������D��ݒ�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object campaignPrcPrStWork)
        {
            return this.LogicalDeleteProc(ref campaignPrcPrStWork, 1);
        }

        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="campaignPrcPrStWork">�_���폜����L�����y�[�������D��ݒ�}�X�^���</param>
        /// <param name="procMode">�_���폜���[�h</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�������D��ݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int LogicalDeleteProc(ref CampaignPrcPrStWork campaignPrcPrStWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (campaignPrcPrStWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD1RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD2RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD3RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD4RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD5RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD6RF" + Environment.NewLine;
                    sqlText += " FROM CAMPAIGNPRCPRSTRF" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine;
                    sqlText += " AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != campaignPrcPrStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // ���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        # region [UPDATE��]
                        string sqlText_UPDATE = string.Empty;
                        sqlText_UPDATE += "UPDATE CAMPAIGNPRCPRSTRF" + Environment.NewLine;
                        sqlText_UPDATE += "    SET UPDATEDATETIMERF=@UPDATEDATETIMERF" + Environment.NewLine;


                        sqlText_UPDATE += "    ,LOGICALDELETECODERF=@LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText_UPDATE += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine;
                        sqlText_UPDATE += " AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine;
                        sqlCommand.CommandText = sqlText_UPDATE;
                        # endregion

                        // KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.SectionCode);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)campaignPrcPrStWork;
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
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // ���ɍ폜�ς݂̏ꍇ����
                            return status;
                        }
                        else if (logicalDelCd == 0) campaignPrcPrStWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                        else campaignPrcPrStWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            campaignPrcPrStWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
                        }
                        else
                        {
                            if (logicalDelCd == 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // ���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
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
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignPrcPrStWork.UpdateDateTime);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt64(campaignPrcPrStWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                    al.Add(campaignPrcPrStWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqex, "CampaignPrcPrStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignPrcPrStDB.DeleteProc", status);
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
        /// �L�����y�[�������D��ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="campaignPrcPrStWorkbyte">�ǉ��E�X�V����L�����y�[�������D��ݒ�}�X�^���</param>
        /// <param name="writeMode">�X�V�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�������D��ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Write(ref object campaignPrcPrStWorkbyte, int writeMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                CampaignPrcPrStWork campaignPrcPrStWork = campaignPrcPrStWorkbyte as CampaignPrcPrStWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = WriteProc(ref campaignPrcPrStWork, ref sqlConnection, ref sqlTransaction);

                // �߂�l�Z�b�g
                campaignPrcPrStWorkbyte = campaignPrcPrStWork;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "CampaignPrcPrStDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignPrcPrStDB.Write", status);
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
        /// �L�����y�[�������D��ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="campaignPrcPrStWork">�ǉ��E�X�V����L�����y�[�������D��ݒ�}�X�^���</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�������D��ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int WriteProc(ref CampaignPrcPrStWork campaignPrcPrStWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            CampaignPrcPrStWork al = new CampaignPrcPrStWork();

            try
            {
                if (campaignPrcPrStWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT��]
                    sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD1RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD2RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD3RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD4RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD5RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD6RF" + Environment.NewLine;
                    sqlText += " FROM CAMPAIGNPRCPRSTRF" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine;
                    sqlText += " AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                        if (_updateDateTime != campaignPrcPrStWork.UpdateDateTime)
                        {
                            if (campaignPrcPrStWork.UpdateDateTime == DateTime.MinValue)
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
                        string sqlText_UPDATE = string.Empty;
                        sqlText_UPDATE += "UPDATE CAMPAIGNPRCPRSTRF" + Environment.NewLine;
                        sqlText_UPDATE += "    SET PRIORITYSETTINGCD1RF=@PRIORITYSETTINGCD1," + Environment.NewLine;
                        sqlText_UPDATE += "    PRIORITYSETTINGCD2RF=@PRIORITYSETTINGCD2," + Environment.NewLine;
                        sqlText_UPDATE += "    PRIORITYSETTINGCD3RF=@PRIORITYSETTINGCD3," + Environment.NewLine;
                        sqlText_UPDATE += "    PRIORITYSETTINGCD4RF=@PRIORITYSETTINGCD4," + Environment.NewLine;
                        sqlText_UPDATE += "    PRIORITYSETTINGCD5RF=@PRIORITYSETTINGCD5," + Environment.NewLine;
                        sqlText_UPDATE += "    PRIORITYSETTINGCD6RF=@PRIORITYSETTINGCD6," + Environment.NewLine;
                        sqlText_UPDATE += "    UPDATEDATETIMERF=@UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText_UPDATE += " WHERE ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine;
                        sqlText_UPDATE += " AND SECTIONCODERF=@SECTIONCODE " + Environment.NewLine;
                        sqlCommand.CommandText = sqlText_UPDATE;
                        # endregion

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)campaignPrcPrStWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (campaignPrcPrStWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        # region [INSERT��]
                        string sqlText_INSERT =string.Empty;
                        sqlText_INSERT += "INSERT INTO CAMPAIGNPRCPRSTRF" + Environment.NewLine;
                        sqlText_INSERT += " (CREATEDATETIMERF," + Environment.NewLine;
                        sqlText_INSERT += "  UPDATEDATETIMERF," + Environment.NewLine;
                        sqlText_INSERT += "  ENTERPRISECODERF," + Environment.NewLine;
                        sqlText_INSERT += "  FILEHEADERGUIDRF," + Environment.NewLine;
                        sqlText_INSERT += " UPDEMPLOYEECODERF," + Environment.NewLine;
                        sqlText_INSERT += "  UPDASSEMBLYID1RF," + Environment.NewLine;
                        sqlText_INSERT += "  UPDASSEMBLYID2RF," + Environment.NewLine;
                        sqlText_INSERT += " LOGICALDELETECODERF," + Environment.NewLine;
                        sqlText_INSERT += "     SECTIONCODERF," + Environment.NewLine;
                        sqlText_INSERT += "PRIORITYSETTINGCD1RF," + Environment.NewLine;
                        sqlText_INSERT += "PRIORITYSETTINGCD2RF," + Environment.NewLine;
                        sqlText_INSERT += "PRIORITYSETTINGCD3RF," + Environment.NewLine;
                        sqlText_INSERT += "PRIORITYSETTINGCD4RF," + Environment.NewLine;
                        sqlText_INSERT += "PRIORITYSETTINGCD5RF," + Environment.NewLine;
                        sqlText_INSERT += "PRIORITYSETTINGCD6RF)" + Environment.NewLine;
                        sqlText_INSERT += "VALUES (@CREATEDATETIME," + Environment.NewLine;
                        sqlText_INSERT += "     @UPDATEDATETIMERF, " + Environment.NewLine;
                        sqlText_INSERT += "     @ENTERPRISECODE, " + Environment.NewLine;
                        sqlText_INSERT += "     @FILEHEADERGUID," + Environment.NewLine;
                        sqlText_INSERT += "     @UPDEMPLOYEECODE," + Environment.NewLine;
                        sqlText_INSERT += "     @UPDASSEMBLYID1, " + Environment.NewLine;
                        sqlText_INSERT += "     @UPDASSEMBLYID2, " + Environment.NewLine;
                        sqlText_INSERT += "     @LOGICALDELETECODE, " + Environment.NewLine;
                        sqlText_INSERT += "     @SECTIONCODE, " + Environment.NewLine;
                        sqlText_INSERT += "     @PRIORITYSETTINGCD1," + Environment.NewLine;
                        sqlText_INSERT += "     @PRIORITYSETTINGCD2," + Environment.NewLine;
                        sqlText_INSERT += "     @PRIORITYSETTINGCD3," + Environment.NewLine;
                        sqlText_INSERT += "     @PRIORITYSETTINGCD4," + Environment.NewLine;
                        sqlText_INSERT += "     @PRIORITYSETTINGCD5," + Environment.NewLine;
                        sqlText_INSERT += "     @PRIORITYSETTINGCD6)" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText_INSERT;
                        # endregion

                        // �o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)campaignPrcPrStWork;
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
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraPrioritySettingCd1 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD1", SqlDbType.Int);
                    SqlParameter paraPrioritySettingCd2 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD2", SqlDbType.Int);
                    SqlParameter paraPrioritySettingCd3 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD3", SqlDbType.Int);
                    SqlParameter paraPrioritySettingCd4 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD4", SqlDbType.Int);
                    SqlParameter paraPrioritySettingCd5 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD5", SqlDbType.Int);
                    SqlParameter paraPrioritySettingCd6 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD6", SqlDbType.Int);


                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignPrcPrStWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignPrcPrStWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(campaignPrcPrStWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignPrcPrStWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.SectionCode);
                    paraPrioritySettingCd1.Value = SqlDataMediator.SqlSetInt32(campaignPrcPrStWork.PrioritySettingCd1);
                    paraPrioritySettingCd2.Value = SqlDataMediator.SqlSetInt32(campaignPrcPrStWork.PrioritySettingCd2);
                    paraPrioritySettingCd3.Value = SqlDataMediator.SqlSetInt32(campaignPrcPrStWork.PrioritySettingCd3);
                    paraPrioritySettingCd4.Value = SqlDataMediator.SqlSetInt32(campaignPrcPrStWork.PrioritySettingCd4);
                    paraPrioritySettingCd5.Value = SqlDataMediator.SqlSetInt32(campaignPrcPrStWork.PrioritySettingCd5);
                    paraPrioritySettingCd6.Value = SqlDataMediator.SqlSetInt32(campaignPrcPrStWork.PrioritySettingCd6);

                    sqlCommand.ExecuteNonQuery();
                    al = campaignPrcPrStWork;

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "CampaignPrcPrStDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignPrcPrStDB.WriteProc", status);
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

            campaignPrcPrStWork = al;

            return status;
        }
        #endregion 

        #endregion ICampaignPrcPrStDB �����o

    }
}
