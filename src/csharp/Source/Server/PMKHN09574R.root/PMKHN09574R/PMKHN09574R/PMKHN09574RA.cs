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
    /// �L�����y�[���֘A�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���֘A�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350�@�N��@����</br>
    /// <br>Date       : 2009.05.13</br>
    /// </remarks>
    [Serializable]
    public class CampaignLinkDB : RemoteDB, ICampaignLinkDB
    {
        /// <summary>
        /// �L�����y�[���֘A�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public CampaignLinkDB()
            :
            base("PMKHN09576D", "Broadleaf.Application.Remoting.ParamData.CampaignLinkWork", "CAMPAIGNLINKRF")
        {
        }

        private const string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̃L�����y�[���֘A�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="campaignLinkWork">��������</param>
        /// <param name="paracampaignLinkWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃L�����y�[���֘A�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        public int Search(out object campaignLinkWork, object paracampaignLinkWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            campaignLinkWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchCampaignLinkProc(out campaignLinkWork, paracampaignLinkWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignLinkDB.Search");
                campaignLinkWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̃L�����y�[���֘A�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objcampaignLinkWork">��������</param>
        /// <param name="paracampaignLinkWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃L�����y�[���֘A�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        public int SearchCampaignLinkProc(out object objcampaignLinkWork, object paracampaignLinkWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            CampaignLinkWork campaignLinkWork = null; 

            ArrayList campaignLinkWorkList = paracampaignLinkWork as ArrayList;
            if (campaignLinkWorkList == null)
            {
                campaignLinkWork = paracampaignLinkWork as CampaignLinkWork;
            }
            else
            {
                if (campaignLinkWorkList.Count > 0)
                    campaignLinkWork = campaignLinkWorkList[0] as CampaignLinkWork;
            }

            int status = SearchCampaignLinkProc(out campaignLinkWorkList, campaignLinkWork, readMode, logicalMode, ref sqlConnection);
            objcampaignLinkWork = campaignLinkWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃L�����y�[���֘A�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="campaignLinkWorkList">��������</param>
        /// <param name="campaignLinkWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃L�����y�[���֘A�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        public int SearchCampaignLinkProc(out ArrayList campaignLinkWorkList, CampaignLinkWork campaignLinkWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchCampaignLinkProcProc(out campaignLinkWorkList, campaignLinkWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃L�����y�[���֘A�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">��������</param>
        /// <param name="stockmngttlstWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃L�����y�[���֘A�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        private int SearchCampaignLinkProcProc(out ArrayList campaignLinkWorkList, CampaignLinkWork campaignLinkWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
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
                selectTxt += "         ,CAMPAIGNCODERF " + Environment.NewLine;
                selectTxt += "         ,CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "         ,SALESAREACODERF " + Environment.NewLine;
                selectTxt += "         ,CUSTOMERAGENTCDRF " + Environment.NewLine;
                selectTxt += "         ,INFOSENDCODERF " + Environment.NewLine;
                selectTxt += "  FROM CAMPAIGNLINKRF " + Environment.NewLine;
                #endregion
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, campaignLinkWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToCampaignLinkWorkFromReader(ref myReader));

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

            campaignLinkWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̃L�����y�[���֘A�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">CampaignLinkWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃L�����y�[���֘A�}�X�^��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                CampaignLinkWork campaignLinkWork = new CampaignLinkWork();

                // XML�̓ǂݍ���
                campaignLinkWork = (CampaignLinkWork)XmlByteSerializer.Deserialize(parabyte, typeof(CampaignLinkWork));
                if (campaignLinkWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref campaignLinkWork, readMode, ref sqlConnection,ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(campaignLinkWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignLinkDB.Read");
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
        /// �w�肳�ꂽ�����̃L�����y�[���֘A�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockmngttlstWork">CampaignLinkWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃L�����y�[���֘A�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        public int ReadProc(ref CampaignLinkWork campaignLinkWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref campaignLinkWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃L�����y�[���֘A�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockmngttlstWork">CampaignLinkWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃L�����y�[���֘A�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        private int ReadProcProc(ref CampaignLinkWork campaignLinkWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region�@SELECT��
                selectTxt += " SELECT CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,CAMPAIGNCODERF " + Environment.NewLine;
                selectTxt += "         ,CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "         ,SALESAREACODERF " + Environment.NewLine;
                selectTxt += "         ,CUSTOMERAGENTCDRF " + Environment.NewLine;
                selectTxt += "         ,INFOSENDCODERF " + Environment.NewLine;
                selectTxt += "  FROM CAMPAIGNLINKRF " + Environment.NewLine;
                selectTxt += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "         AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE " + Environment.NewLine;
                selectTxt += "         AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                selectTxt += "         AND SALESAREACODERF = @FINDSALESAREACODE " + Environment.NewLine;
                selectTxt += "         AND CUSTOMERAGENTCDRF = @FINDCUSTOMERAGENTCD " + Environment.NewLine;
                #endregion

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                    SqlParameter findCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);  // �L�����y�[���R�[�h
                    SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);  // ���Ӑ�R�[�h
                    SqlParameter findSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);  // �̔��G���A�R�[�h
                    SqlParameter findCustomerAgentCd = sqlCommand.Parameters.Add("@FINDCUSTOMERAGENTCD", SqlDbType.NChar);  // �ڋq�S���]�ƈ��R�[�h

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);  // ��ƃR�[�h
                    findCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);  // �L�����y�[���R�[�h
                    findCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);  // ���Ӑ�R�[�h
                    findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.SalesAreaCode);  // �̔��G���A�R�[�h
                    findCustomerAgentCd.Value = campaignLinkWork.CustomerAgentCd.Trim(); // �ڋq�S���]�ƈ��R�[�h

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        campaignLinkWork = CopyToCampaignLinkWorkFromReader(ref myReader);
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
        /// �L�����y�[���֘A�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="stockmngttlstWork">CampaignLinkWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���֘A�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        public int Write(ref object campaignLinkWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(campaignLinkWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteCampaignLinkProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                CampaignLinkWork paraWork = paraList[0] as CampaignLinkWork;
                
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                campaignLinkWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignLinkDB.Write(ref object campaignLinkWork)");
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
        /// �L�����y�[���֘A�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���֘A�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        public int WriteCampaignLinkProc(ref ArrayList campaignLinkWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteCampaignLinkProcProc(ref campaignLinkWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �L�����y�[���֘A�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���֘A�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        private int WriteCampaignLinkProcProc(ref ArrayList campaignLinkWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (campaignLinkWorkList != null)
                {
                    foreach (CampaignLinkWork campaignLinkWork in campaignLinkWorkList)
                    {
                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM CAMPAIGNLINKRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND SALESAREACODERF = @FINDSALESAREACODE AND CUSTOMERAGENTCDRF = @FINDCUSTOMERAGENTCD", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                        SqlParameter findCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);  // �L�����y�[���R�[�h
                        SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);  // ���Ӑ�R�[�h
                        SqlParameter findSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);  // �̔��G���A�R�[�h
                        SqlParameter findCustomerAgentCd = sqlCommand.Parameters.Add("@FINDCUSTOMERAGENTCD", SqlDbType.NChar);  // �ڋq�S���]�ƈ��R�[�h

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);  // ��ƃR�[�h
                        findCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);  // �L�����y�[���R�[�h
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);  // ���Ӑ�R�[�h
                        findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.SalesAreaCode);  // �̔��G���A�R�[�h
                        findCustomerAgentCd.Value = campaignLinkWork.CustomerAgentCd.Trim();  // �ڋq�S���]�ƈ��R�[�h

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != campaignLinkWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (campaignLinkWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �X�V����SQL������
                            string sqlText = string.Empty;
                            sqlText += " UPDATE CAMPAIGNLINKRF SET " + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                            sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "  , CAMPAIGNCODERF = @CAMPAIGNCODE " + Environment.NewLine;
                            sqlText += "  , CUSTOMERCODERF = @CUSTOMERCODE " + Environment.NewLine;
                            sqlText += "  , SALESAREACODERF = @SALESAREACODE " + Environment.NewLine;
                            sqlText += "  , CUSTOMERAGENTCDRF = @CUSTOMERAGENTCD " + Environment.NewLine;
                            sqlText += "  , INFOSENDCODERF = @INFOSENDCODE " + Environment.NewLine;
                            sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE " + Environment.NewLine;
                            sqlText += "         AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                            sqlText += "         AND SALESAREACODERF = @FINDSALESAREACODE " + Environment.NewLine;
                            sqlText += "         AND CUSTOMERAGENTCDRF = @FINDCUSTOMERAGENTCD " + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);  // ��ƃR�[�h
                            findCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);  // �L�����y�[���R�[�h
                            findCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);  // ���Ӑ�R�[�h
                            findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.SalesAreaCode);  // �̔��G���A�R�[�h
                            findCustomerAgentCd.Value = campaignLinkWork.CustomerAgentCd.Trim(); // �ڋq�S���]�ƈ��R�[�h


                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignLinkWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (campaignLinkWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �V�K�쐬����SQL���𐶐�
                            string sqlText = string.Empty;
                            sqlText += " INSERT INTO CAMPAIGNLINKRF " + Environment.NewLine;
                            sqlText += "  (CREATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,ENTERPRISECODERF " + Environment.NewLine;
                            sqlText += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                            sqlText += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                            sqlText += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                            sqlText += "         ,CAMPAIGNCODERF " + Environment.NewLine;
                            sqlText += "         ,CUSTOMERCODERF " + Environment.NewLine;
                            sqlText += "         ,SALESAREACODERF " + Environment.NewLine;
                            sqlText += "         ,CUSTOMERAGENTCDRF " + Environment.NewLine;
                            sqlText += "         ,INFOSENDCODERF " + Environment.NewLine;
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
                            sqlText += "         ,@CAMPAIGNCODE " + Environment.NewLine;
                            sqlText += "         ,@CUSTOMERCODE " + Environment.NewLine;
                            sqlText += "         ,@SALESAREACODE " + Environment.NewLine;
                            sqlText += "         ,@CUSTOMERAGENTCD " + Environment.NewLine;
                            sqlText += "         ,@INFOSENDCODE " + Environment.NewLine;
                            sqlText += "  ) " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignLinkWork;
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
                        SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);  // �L�����y�[���R�[�h
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);  // ���Ӑ�R�[�h
                        SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);  // �̔��G���A�R�[�h
                        SqlParameter paraCustomerAgentCd = sqlCommand.Parameters.Add("@CUSTOMERAGENTCD", SqlDbType.NChar);  // �ڋq�S���]�ƈ��R�[�h
                        SqlParameter paraInfoSendCode = sqlCommand.Parameters.Add("@INFOSENDCODE", SqlDbType.Int);  // ��񑗐M�敪
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignLinkWork.CreateDateTime);  // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignLinkWork.UpdateDateTime);  // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);  // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(campaignLinkWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdEmployeeCode);  // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdAssemblyId1);  // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdAssemblyId2);  // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.LogicalDeleteCode);  // �_���폜�敪
                        paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);  // �L�����y�[���R�[�h
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);  // ���Ӑ�R�[�h
                        paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.SalesAreaCode);  // �̔��G���A�R�[�h
                        paraCustomerAgentCd.Value = campaignLinkWork.CustomerAgentCd.Trim();  // �ڋq�S���]�ƈ��R�[�h
                        paraInfoSendCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.InfoSendCode);  // ��񑗐M�敪
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(campaignLinkWork);
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

            campaignLinkWorkList = al;

            return status;
        }

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// �L�����y�[���֘A�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���֘A�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        public int LogicalDelete(ref object campaignLinkWork)
        {
            return LogicalDeleteCampaignLink(ref campaignLinkWork, 0);
        }

        /// <summary>
        /// �_���폜�L�����y�[���֘A�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�L�����y�[���֘A�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        public int RevivalLogicalDelete(ref object campaignLinkWork)
        {
            return LogicalDeleteCampaignLink(ref campaignLinkWork, 1);
        }

        /// <summary>
        /// �L�����y�[���֘A�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���֘A�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        private int LogicalDeleteCampaignLink(ref object campaignLinkWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(campaignLinkWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteCampaignLinkProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "CampaignLinkDB.LogicalDeleteCampaignLink :" + procModestr);

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
        /// �L�����y�[���֘A�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���֘A�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        public int LogicalDeleteCampaignLinkProc(ref ArrayList campaignLinkWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteCampaignLinkProcProc(ref campaignLinkWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �L�����y�[���֘A�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���֘A�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        private int LogicalDeleteCampaignLinkProcProc(ref ArrayList campaignLinkWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (campaignLinkWorkList != null)
                {
                    for (int i = 0; i < campaignLinkWorkList.Count; i++)
                    {
                        CampaignLinkWork campaignLinkWork = campaignLinkWorkList[i] as CampaignLinkWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM CAMPAIGNLINKRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND SALESAREACODERF = @FINDSALESAREACODE AND CUSTOMERAGENTCDRF = @FINDCUSTOMERAGENTCD", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                        SqlParameter findCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);  // �L�����y�[���R�[�h
                        SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);  // ���Ӑ�R�[�h
                        SqlParameter findSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);  // �̔��G���A�R�[�h
                        SqlParameter findCustomerAgentCd = sqlCommand.Parameters.Add("@FINDCUSTOMERAGENTCD", SqlDbType.NChar);  // �ڋq�S���]�ƈ��R�[�h

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);  // ��ƃR�[�h
                        findCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);  // �L�����y�[���R�[�h
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);  // ���Ӑ�R�[�h
                        findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.SalesAreaCode);  // �̔��G���A�R�[�h
                        findCustomerAgentCd.Value = campaignLinkWork.CustomerAgentCd.Trim();  // �ڋq�S���]�ƈ��R�[�h

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != campaignLinkWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE CAMPAIGNLINKRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND SALESAREACODERF = @FINDSALESAREACODE AND CUSTOMERAGENTCDRF = @FINDCUSTOMERAGENTCD";
                            //KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);  // ��ƃR�[�h
                            findCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);  // �L�����y�[���R�[�h
                            findCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);  // ���Ӑ�R�[�h
                            findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.SalesAreaCode);  // �̔��G���A�R�[�h
                            findCustomerAgentCd.Value = campaignLinkWork.CustomerAgentCd.Trim(); // �ڋq�S���]�ƈ��R�[�h

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignLinkWork;
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
                            else if (logicalDelCd == 0) campaignLinkWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else campaignLinkWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) campaignLinkWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignLinkWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(campaignLinkWork);
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

            campaignLinkWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// �L�����y�[���֘A�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">�L�����y�[���֘A�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �L�����y�[���֘A�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
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

                status = DeleteCampaignLinkProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "CampaignLinkDB.Delete");
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
        /// �L�����y�[���֘A�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">�L�����y�[���֘A�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �L�����y�[���֘A�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        public int DeleteCampaignLinkProc(ArrayList campaignLinkWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteCampaignLinkProcProc(campaignLinkWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �L�����y�[���֘A�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="stockmngttlstWorkList">�L�����y�[���֘A�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �L�����y�[���֘A�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        private int DeleteCampaignLinkProcProc(ArrayList campaignLinkWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                foreach (CampaignLinkWork campaignLinkWork in campaignLinkWorkList)
                {
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM CAMPAIGNLINKRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND SALESAREACODERF = @FINDSALESAREACODE AND CUSTOMERAGENTCDRF = @FINDCUSTOMERAGENTCD", sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                    SqlParameter findCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);  // �L�����y�[���R�[�h
                    SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);  // ���Ӑ�R�[�h
                    SqlParameter findSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);  // �̔��G���A�R�[�h
                    SqlParameter findCustomerAgentCd = sqlCommand.Parameters.Add("@FINDCUSTOMERAGENTCD", SqlDbType.NChar);  // �ڋq�S���]�ƈ��R�[�h

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);  // ��ƃR�[�h
                    findCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);  // �L�����y�[���R�[�h
                    findCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);  // ���Ӑ�R�[�h
                    findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.SalesAreaCode);  // �̔��G���A�R�[�h
                    findCustomerAgentCd.Value = campaignLinkWork.CustomerAgentCd.Trim(); // �ڋq�S���]�ƈ��R�[�h

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != campaignLinkWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM CAMPAIGNLINKRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND SALESAREACODERF = @FINDSALESAREACODE AND CUSTOMERAGENTCDRF = @FINDCUSTOMERAGENTCD";
                        //KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);  // ��ƃR�[�h
                        findCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);  // �L�����y�[���R�[�h
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);  // ���Ӑ�R�[�h
                        findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.SalesAreaCode);  // �̔��G���A�R�[�h
                        findCustomerAgentCd.Value = campaignLinkWork.CustomerAgentCd.Trim(); // �ڋq�S���]�ƈ��R�[�h

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
	    /// <param name="stockmngttlstWork">���������i�[�N���X</param>
	    /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
	    /// <returns>Where����������</returns>
	    /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CampaignLinkWork campaignLinkWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //��ƃR�[�h
		    retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);
           
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

            // �L�����y�[���R�[�h
            if(campaignLinkWork.CampaignCode != 0)
            {
                retstring += "AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE ";
                SqlParameter findCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int); 
                findCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);  
            }

            // ���Ӑ�R�[�h
            if(campaignLinkWork.CustomerCode != 0)
            {
                retstring += "AND CUSTOMERCODERF = @FINDCUSTOMERCODE ";
                SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);  
                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);  
            }

            // �̔��G���A�R�[�h
            if(campaignLinkWork.SalesAreaCode != 0)
            {
                retstring += "AND SALESAREACODERF = @FINDSALESAREACODE ";
                SqlParameter findSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);  
                findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.SalesAreaCode);
            }
            
            // �ڋq�S���]�ƈ��R�[�h
            if(string.IsNullOrEmpty(campaignLinkWork.CustomerAgentCd) == false)
            {
                retstring += "AND CUSTOMERAGENTCDRF = @FINDCUSTOMERAGENTC ";
                SqlParameter findCustomerAgentCd = sqlCommand.Parameters.Add("@FINDCUSTOMERAGENTCD", SqlDbType.NChar);
                findCustomerAgentCd.Value = campaignLinkWork.CustomerAgentCd.Trim();
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
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private CampaignLinkWork CopyToCampaignLinkWorkFromReader(ref SqlDataReader myReader)
        {
            CampaignLinkWork wkCampaignLinkWork = new CampaignLinkWork();

            #region �N���X�֊i�[
            wkCampaignLinkWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
            wkCampaignLinkWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
            wkCampaignLinkWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // ��ƃR�[�h
            wkCampaignLinkWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkCampaignLinkWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // �X�V�]�ƈ��R�[�h
            wkCampaignLinkWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // �X�V�A�Z���u��ID1
            wkCampaignLinkWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // �X�V�A�Z���u��ID2
            wkCampaignLinkWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // �_���폜�敪
            wkCampaignLinkWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));  // �L�����y�[���R�[�h
            wkCampaignLinkWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // ���Ӑ�R�[�h
            wkCampaignLinkWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));  // �̔��G���A�R�[�h
            wkCampaignLinkWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));  // �ڋq�S���]�ƈ��R�[�h
            wkCampaignLinkWork.InfoSendCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INFOSENDCODERF")); // ��񑗐M�敪
            #endregion

            return wkCampaignLinkWork;
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
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            CampaignLinkWork[] CampaignLinkWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is CampaignLinkWork)
                    {
                        CampaignLinkWork wkCampaignLinkWork = paraobj as CampaignLinkWork;
                        if (wkCampaignLinkWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkCampaignLinkWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            CampaignLinkWorkArray = (CampaignLinkWork[])XmlByteSerializer.Deserialize(byteArray, typeof(CampaignLinkWork[]));
                        }
                        catch (Exception) { }
                        if (CampaignLinkWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(CampaignLinkWorkArray);
                        }
                        else
                        {
                            try
                            {
                                CampaignLinkWork wkCampaignLinkWork = (CampaignLinkWork)XmlByteSerializer.Deserialize(byteArray, typeof(CampaignLinkWork));
                                if (wkCampaignLinkWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkCampaignLinkWork);
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
        /// <br>Date       : 2009.05.13</br>
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
