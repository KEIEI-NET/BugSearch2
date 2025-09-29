//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/07  �C�����e : Redmine#22810 �o�^���Ă��Ȃ����i�ݒ�ɂ��Ă̂݁A�d�����ēo�^���邱�Ƃ��\�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : ������
// �C �� ��  2011/07/14  �C�����e : Redmine#22962 ���_�Ⴂ�œo�^�\�ɂ���悤�ɕύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/14  �C�����e : Redmine#22984 �����敪���قȂ�ݒ�ɂ���ƁA���ꏤ�i�ݒ���d�����ēo�^���邱�Ƃ��\�ɂȂ��Ă��܂��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : ������
// �C �� ��  2011/07/15  �C�����e : Redmine#22993 ���i�͈̔͂��d�����Ă��܂����o�^�o���Ă��܂��܂�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : ������
// �C �� ��  2011/07/15  �C�����e : Redmine#22984 �����敪���قȂ�ݒ�ɂ���ƁA���ꏤ�i�ݒ���d���`�F�b�N
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/08/15  �C�����e : ���[�U�[��ł͔������Ȃ��������̊�Ƃ����ڂ���c�ƃf���@�ȂǂŔ�������̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �L�����y�[���Ώۏ��i�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br></br>
    /// <br>UpdateNote : 2011/07/15 ������ Redmine#22993 ���i�͈̔͂��d�����Ă��܂����o�^�o���Ă��܂��܂�</br>
    /// <br>UpdateNote : 2011/07/15 ������ Redmine#22984 �����敪���قȂ�ݒ�ɂ���ƁA���ꏤ�i�ݒ���d���`�F�b�N</br>
    /// <br>UpdateNote : 2011/08/15 杍^ Redmine#23556 ���[�U�[��ł͔������Ȃ��������̊�Ƃ����ڂ���c�ƃf���@�ȂǂŔ�������̑Ή�</br>
    /// </remarks>
    [Serializable]
    public class CampaignObjGoodsStDB : RemoteDB, ICampaignObjGoodsStDB
    {
        #region constructor
        /// <summary>
        /// U�L�����y�[���Ώۏ��i�ݒ�}�X�^�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public CampaignObjGoodsStDB()
            :
            base("PMKHN09627D", "Broadleaf.Application.Remoting.ParamData.CampaignObjGoodsStWork", "CampaignMngRF")
        {
        }
        #endregion

        #region Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode, ref string errMsg)
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̃L�����y�[���Ώۏ��i�ݒ�}�X�^���LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="count">count</param>
        /// <param name="errMsg">�G���[msg</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃L�����y�[���Ώۏ��i�ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int Search(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, out int count, ref string errMsg)
        {
            try
            {
                return SearchProc(out retobj, paraobj, readMode, logicalMode, out count, ref errMsg);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignObjGoodsStDB.Search");
                retobj = new ArrayList();
                count = 0;
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̃L�����y�[���Ώۏ��i�ݒ�}�X�^LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="count">count</param>
        /// <param name="errMsg">�G���[msg</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃L�����y�[���Ώۏ��i�ݒ�}�X�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/08/15 杍^ Redmine#23556 ���[�U�[��ł͔������Ȃ��������̊�Ƃ����ڂ���c�ƃf���@�ȂǂŔ�������̑Ή�</br>
        /// </remarks>
        private int SearchProc(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, out int count, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            SearchConditionWork searchConditionWork = null;
            CampaignObjGoodsStWork campaignObjGoodsStWork = null;

            retobj = null;
            count = 0;
            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                searchConditionWork = paraobj as SearchConditionWork;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += " CAMPAIGN.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.GOODSNORF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.SALESTARGETMONEYRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.SALESTARGETPROFITRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.SALESTARGETCOUNTRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.CAMPAIGNCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.PRICEFLRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.RATEVALRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.SALESCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.CAMPAIGNSETTINGKINDRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.SALESPRICESETDIVRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.PRICESTARTDATERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.PRICEENDDATERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.DISCOUNTRATERF" + Environment.NewLine;
                selectTxt += " ,GOODSU.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += " FROM (" + Environment.NewLine;
                selectTxt += "SELECT "+Environment.NewLine;
                selectTxt += " CAMPAIGNMNGRF.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.GOODSNORF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.SALESTARGETMONEYRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.SALESTARGETPROFITRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.SALESTARGETCOUNTRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.CAMPAIGNCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.PRICEFLRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.RATEVALRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.SALESCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.CAMPAIGNSETTINGKINDRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.SALESPRICESETDIVRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.PRICESTARTDATERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.PRICEENDDATERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.DISCOUNTRATERF" + Environment.NewLine;
                selectTxt += " FROM CAMPAIGNMNGRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                selectTxt += this.MakeWhereString(ref sqlCommand, searchConditionWork, logicalMode);

                selectTxt += " ) AS CAMPAIGN" + Environment.NewLine;

                selectTxt += " LEFT JOIN GOODSURF AS GOODSU" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += " GOODSU.ENTERPRISECODERF=CAMPAIGN.ENTERPRISECODERF" + Environment.NewLine;  // ADD 2011/08/15
                selectTxt += " AND GOODSU.GOODSNORF=CAMPAIGN.GOODSNORF" + Environment.NewLine;
                selectTxt += " AND GOODSU.GOODSMAKERCDRF=CAMPAIGN.GOODSMAKERCDRF" + Environment.NewLine;

                selectTxt += "ORDER BY" + Environment.NewLine;
                selectTxt += " CAMPAIGN.CAMPAIGNCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.CAMPAIGNSETTINGKINDRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.GOODSNORF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.SALESPRICESETDIVRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.PRICESTARTDATERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGN.PRICEENDDATERF" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    if (al.Count == 20000)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        retobj = al;
                        count = 20001;
                        return status;
                    }
                    campaignObjGoodsStWork = this.CopyToCampaignMngWorkFromReader(ref myReader);

                    campaignObjGoodsStWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));

                    al.Add(campaignObjGoodsStWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                errMsg = ex.ToString();
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
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

        #region Search(out object retobj, string enterpriseCode, int readMode, ConstantManagement.LogicalMode logicalMode, ref string errMsg)
        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="errMsg">�G���[msg</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        public int Search(out object retobj, string enterpriseCode, int readMode, ConstantManagement.LogicalMode logicalMode, ref string errMsg)
        {
            SqlConnection sqlConnection = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                {
                    retobj = null;
                    return status;
                }

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                return SearchProc(out retobj, enterpriseCode, readMode, logicalMode, ref sqlConnection, ref errMsg);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignObjGoodsStDB.Search");
                retobj = null;
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// �w�肳�ꂽ��ƃR�[�h�̃L�����y�[���Ώۏ��i�ݒ�}�X�^LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="errMsg">�G���[msg</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃L�����y�[���Ώۏ��i�ݒ�}�X�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int SearchProc(out object retobj, string enterpriseCode, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref string errMsg)
        {
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            ArrayList al = new ArrayList();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                CampaignObjGoodsStWork campaignObjGoodsStWork = null;

                try
                {
                    string selectTxt = string.Empty;

                    selectTxt += "SELECT " + Environment.NewLine;
                    selectTxt += " CAMPAIGNMNGRF.CREATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.FILEHEADERGUIDRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.UPDEMPLOYEECODERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.UPDASSEMBLYID1RF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.UPDASSEMBLYID2RF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.SECTIONCODERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.GOODSMGROUPRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.BLGOODSCODERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.GOODSNORF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.SALESTARGETMONEYRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.SALESTARGETPROFITRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.SALESTARGETCOUNTRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.CAMPAIGNCODERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.PRICEFLRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.RATEVALRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.BLGROUPCODERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.SALESCODERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.CAMPAIGNSETTINGKINDRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.SALESPRICESETDIVRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.CUSTOMERCODERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.PRICESTARTDATERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.PRICEENDDATERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.DISCOUNTRATERF" + Environment.NewLine;
                    selectTxt += " FROM CAMPAIGNMNGRF" + Environment.NewLine;
                    selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                    //�f�[�^�Ǎ�
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        selectTxt += " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlCommand.CommandText = selectTxt;

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        selectTxt += " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlCommand.CommandText = selectTxt;
                        
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        //�Ȃ��B
                    }
                    SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        campaignObjGoodsStWork = this.CopyToCampaignMngWorkFromReader(ref myReader);

                        al.Add(campaignObjGoodsStWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                catch (SqlException ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                    errMsg = ex.ToString();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignObjGoodsStDB.SearchProc");
                errMsg = ex.ToString();
            }
            finally
            {
                retobj = al as object;

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
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

        #region Read(out object retobj, object paraobj, ref string errMsg)
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̃L�����y�[���Ώۏ��i�ݒ�}�X�^���LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="errMsg">�G���[msg</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃L�����y�[���Ώۏ��i�ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int Read(out object retobj, object paraobj, ref string errMsg)
        {
            try
            {
                return ReadProc(out retobj, paraobj, ref errMsg);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignObjGoodsStDB.Read");
                retobj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̃L�����y�[���Ώۏ��i�ݒ�}�X�^LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="errMsg">�G���[msg</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃L�����y�[���Ώۏ��i�ݒ�}�X�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int ReadProc(out object retobj, object paraobj, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            CampaignObjGoodsStWork campaignObjGoodsStWork = null;
            CampaignObjGoodsStWork work = null;

            retobj = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                campaignObjGoodsStWork = paraobj as CampaignObjGoodsStWork;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                selectTxt += "SELECT "+Environment.NewLine;
                selectTxt += " CAMPAIGNMNGRF.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.GOODSNORF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.SALESTARGETMONEYRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.SALESTARGETPROFITRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.SALESTARGETCOUNTRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.CAMPAIGNCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.PRICEFLRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.RATEVALRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.SALESCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.CAMPAIGNSETTINGKINDRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.SALESPRICESETDIVRF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.PRICESTARTDATERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.PRICEENDDATERF" + Environment.NewLine;
                selectTxt += " ,CAMPAIGNMNGRF.DISCOUNTRATERF" + Environment.NewLine;
                selectTxt += " FROM CAMPAIGNMNGRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                selectTxt += this.MakeWhereString(ref sqlCommand, campaignObjGoodsStWork);

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    work = this.CopyToCampaignMngWorkFromReader(ref myReader);

                    al.Add(work);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                errMsg = ex.ToString();
            }
            finally
            {
                retobj = al as object;

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
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

        #region ReadDBBeforeSave(object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^��o�^�A�X�V�O�A�d�����R�[�h�̑��݃`�F�b�N���s��
        /// </summary>
        /// <param name="paraobj">CampaignMngWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^��o�^�A�X�V�O�A�d�����R�[�h�̑��݃`�F�b�N���s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/07 杍^ Redmine#22810 �o�^���Ă��Ȃ����i�ݒ�ɂ��Ă̂݁A�d�����ēo�^���邱�Ƃ��\�̑Ή�</br>
        /// <br>UpdateNote : 2011/07/14 ������ Redmine#22962 ���_�Ⴂ�œo�^�\�ɂ���悤�ɕύX�Ή�</br>
        /// <br>UpdateNote : 2011/07/14 杍^ Redmine#22984 �����敪���قȂ�ݒ�ɂ���ƁA���ꏤ�i�ݒ���d�����ēo�^���邱�Ƃ��\�ɂȂ��Ă��܂��̑Ή�</br>
        /// <br>UpdateNote : 2011/07/15 ������ Redmine#22993 ���i�͈̔͂��d�����Ă��܂����o�^�o���Ă��܂��܂�</br>
        /// <br>UpdateNote : 2011/07/15 ������ Redmine#22984 �����敪���قȂ�ݒ�ɂ���ƁA���ꏤ�i�ݒ���d���`�F�b�N</br>
        /// </remarks>
        // ---UPD 2011/07/15-------------->>>>>
        //private int ReadDBBeforeSave(object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int ReadDBBeforeSave(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        // ---UPD 2011/07/15--------------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                try
                {
                    if (sqlConnection == null)
                    {
                        SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                        string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                        if (connectionText == null || connectionText == "") return status;

                        sqlConnection = new SqlConnection(connectionText);
                        sqlConnection.Open();
                    }

                    CampaignObjGoodsStWork campaignObjGoodsStWork = paraobj as CampaignObjGoodsStWork;
                    string selectTxt = string.Empty;

                    selectTxt += "SELECT " + Environment.NewLine;
                    selectTxt += " CAMPAIGNMNGRF.CREATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.FILEHEADERGUIDRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.UPDEMPLOYEECODERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.UPDASSEMBLYID1RF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.UPDASSEMBLYID2RF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.SECTIONCODERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.GOODSMGROUPRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.BLGOODSCODERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.GOODSNORF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.SALESTARGETMONEYRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.SALESTARGETPROFITRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.SALESTARGETCOUNTRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.CAMPAIGNCODERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.PRICEFLRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.RATEVALRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.BLGROUPCODERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.SALESCODERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.CAMPAIGNSETTINGKINDRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.SALESPRICESETDIVRF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.CUSTOMERCODERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.PRICESTARTDATERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.PRICEENDDATERF" + Environment.NewLine;
                    selectTxt += " ,CAMPAIGNMNGRF.DISCOUNTRATERF" + Environment.NewLine;
                    selectTxt += " FROM CAMPAIGNMNGRF" + Environment.NewLine;
                    selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND CAMPAIGNMNGRF.CAMPAIGNSETTINGKINDRF=@CAMPAIGNSETTINGKIND" + Environment.NewLine;

                    //selectTxt += " AND CAMPAIGNMNGRF.SALESPRICESETDIVRF=@SALESPRICESETDIV" + Environment.NewLine;  // ADD 2011/07/07  // DEL 2011/07/14

                    sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                    sqlCommand.Transaction = sqlTransaction;

                    switch (campaignObjGoodsStWork.CampaignSettingKind)
                    {
                        case 1:
                            {
                                selectTxt += " AND CAMPAIGNMNGRF.GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.GoodsMakerCd);

                                selectTxt += " AND CAMPAIGNMNGRF.GOODSNORF=@GOODSNO" + Environment.NewLine;
                                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                                paraGoodsNo.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.GoodsNo.Trim());
                                break;
                            }
                        case 2:
                            {
                                selectTxt += " AND CAMPAIGNMNGRF.GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.GoodsMakerCd);

                                selectTxt += " AND CAMPAIGNMNGRF.BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                                SqlParameter paraBLGoodsCd = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                                paraBLGoodsCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.BLGoodsCode);
                                break;
                            }
                        case 3:
                            {
                                selectTxt += " AND CAMPAIGNMNGRF.GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.GoodsMakerCd);

                                selectTxt += " AND CAMPAIGNMNGRF.BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                                SqlParameter paraBLGroupCd = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                                paraBLGroupCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.BLGroupCode);
                                break;
                            }
                        case 4:
                            {
                                selectTxt += " AND CAMPAIGNMNGRF.GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.GoodsMakerCd);
                                break;
                            }
                        case 5:
                            {
                                selectTxt += " AND CAMPAIGNMNGRF.BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                                SqlParameter paraBLGoodsCd = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                                paraBLGoodsCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.BLGoodsCode);
                                break;
                            }
                        case 6:
                            {
                                selectTxt += " AND CAMPAIGNMNGRF.SALESCODERF=@SALESCODE" + Environment.NewLine;
                                SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
                                paraSalesCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.SalesCode);
                                break;
                            }
                    }

                    if (campaignObjGoodsStWork.SalesPriceSetDiv == 0)
                    {
                        selectTxt += " AND CAMPAIGNMNGRF.CAMPAIGNCODERF=@CAMPAIGNCODE" + Environment.NewLine;
                        SqlParameter paraCampaignCd = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);
                        paraCampaignCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CampaignCode);

                        // ---ADD 2011/07/14-------------->>>>>
                        selectTxt += " AND CAMPAIGNMNGRF.SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.SectionCode.Trim());
                        // ---ADD 2011/07/14--------------<<<<<
                    }
                    else
                    {
                        selectTxt += " AND CAMPAIGNMNGRF.SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.SectionCode.Trim());

                        selectTxt += " AND CAMPAIGNMNGRF.CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                        SqlParameter paraCustomerCd = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        paraCustomerCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CustomerCode);

                        // ---UPD 2011/07/15------------->>>>>
                        //selectTxt += " AND ((CAMPAIGNMNGRF.PRICESTARTDATERF<=@PRICESTARTDATE AND @PRICESTARTDATE<=CAMPAIGNMNGRF.PRICEENDDATERF)" + Environment.NewLine;
                        //selectTxt += " OR (CAMPAIGNMNGRF.PRICESTARTDATERF<=@PRICEENDDATE AND @PRICEENDDATE<=CAMPAIGNMNGRF.PRICEENDDATERF))" + Environment.NewLine;

                        selectTxt += " AND ((CAMPAIGNMNGRF.PRICESTARTDATERF<=@PRICESTARTDATE AND @PRICEENDDATE<=CAMPAIGNMNGRF.PRICEENDDATERF)" + Environment.NewLine;
                        selectTxt += " OR (CAMPAIGNMNGRF.PRICESTARTDATERF>=@PRICESTARTDATE AND @PRICEENDDATE>=CAMPAIGNMNGRF.PRICEENDDATERF)" + Environment.NewLine;
                        selectTxt += " OR (CAMPAIGNMNGRF.PRICESTARTDATERF>=@PRICESTARTDATE AND @PRICEENDDATE>=CAMPAIGNMNGRF.PRICESTARTDATERF)" + Environment.NewLine;
                        selectTxt += " OR (CAMPAIGNMNGRF.PRICEENDDATERF>=@PRICESTARTDATE AND @PRICEENDDATE>=CAMPAIGNMNGRF.PRICEENDDATERF))" + Environment.NewLine;
                        // ---UPD 2011/07/15-------------<<<<<
                        SqlParameter paraStartTime = sqlCommand.Parameters.Add("@PRICESTARTDATE", SqlDbType.Int);
                        paraStartTime.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.PriceStartDate);

                        SqlParameter paraEndTime = sqlCommand.Parameters.Add("@PRICEENDDATE", SqlDbType.Int);
                        paraEndTime.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.PriceEndDate);
                    }

                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.EnterpriseCode);

                    SqlParameter paraCampainSettingDiv = sqlCommand.Parameters.Add("@CAMPAIGNSETTINGKIND", SqlDbType.Int);
                    paraCampainSettingDiv.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CampaignSettingKind);

                    // ----- DEL 2011/07/14 ------- >>>>>>>>>
                    // ----- ADD 2011/07/07 ------- >>>>>>>>>
                    //SqlParameter paraSalesPriceSetDiv = sqlCommand.Parameters.Add("@SALESPRICESETDIV", SqlDbType.Int);
                    //paraSalesPriceSetDiv.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.SalesPriceSetDiv);
                    // ----- ADD 2011/07/07 ------- <<<<<<<<<
                    // ----- DEL 2011/07/14 ------- <<<<<<<<<

                    sqlCommand.CommandText = selectTxt;

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        return status;
                    }

                    // ---UPD 2011/07/15-------------->>>>>
                    if (campaignObjGoodsStWork.SalesPriceSetDiv == 1)
                    {
                        if (myReader.IsClosed == false)
                        {
                            myReader.Close();
                            myReader = null;
                        }

                        string selectTxt2 = string.Empty;

                        selectTxt2 += "SELECT " + Environment.NewLine;
                        selectTxt2 += " CAMPAIGNMNGRF.CREATEDATETIMERF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.FILEHEADERGUIDRF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.UPDEMPLOYEECODERF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.UPDASSEMBLYID1RF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.UPDASSEMBLYID2RF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.SECTIONCODERF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.GOODSMGROUPRF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.BLGOODSCODERF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.GOODSNORF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.SALESTARGETMONEYRF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.SALESTARGETPROFITRF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.SALESTARGETCOUNTRF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.CAMPAIGNCODERF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.PRICEFLRF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.RATEVALRF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.BLGROUPCODERF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.SALESCODERF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.CAMPAIGNSETTINGKINDRF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.SALESPRICESETDIVRF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.CUSTOMERCODERF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.PRICESTARTDATERF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.PRICEENDDATERF" + Environment.NewLine;
                        selectTxt2 += " ,CAMPAIGNMNGRF.DISCOUNTRATERF" + Environment.NewLine;
                        selectTxt2 += " FROM CAMPAIGNMNGRF" + Environment.NewLine;
                        selectTxt2 += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt2 += " AND CAMPAIGNMNGRF.CAMPAIGNSETTINGKINDRF=@CAMPAIGNSETTINGKIND" + Environment.NewLine;
                        selectTxt2 += " AND CAMPAIGNMNGRF.SALESPRICESETDIVRF=0" + Environment.NewLine;

                        sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                        sqlCommand.Transaction = sqlTransaction;

                        switch (campaignObjGoodsStWork.CampaignSettingKind)
                        {
                            case 1:
                                {
                                    selectTxt2 += " AND CAMPAIGNMNGRF.GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.GoodsMakerCd);

                                    selectTxt2 += " AND CAMPAIGNMNGRF.GOODSNORF=@GOODSNO" + Environment.NewLine;
                                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.GoodsNo.Trim());
                                    break;
                                }
                            case 2:
                                {
                                    selectTxt2 += " AND CAMPAIGNMNGRF.GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.GoodsMakerCd);

                                    selectTxt2 += " AND CAMPAIGNMNGRF.BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                                    SqlParameter paraBLGoodsCd = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                                    paraBLGoodsCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.BLGoodsCode);
                                    break;
                                }
                            case 3:
                                {
                                    selectTxt2 += " AND CAMPAIGNMNGRF.GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.GoodsMakerCd);

                                    selectTxt2 += " AND CAMPAIGNMNGRF.BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                                    SqlParameter paraBLGroupCd = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                                    paraBLGroupCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.BLGroupCode);
                                    break;
                                }
                            case 4:
                                {
                                    selectTxt2 += " AND CAMPAIGNMNGRF.GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.GoodsMakerCd);
                                    break;
                                }
                            case 5:
                                {
                                    selectTxt2 += " AND CAMPAIGNMNGRF.BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                                    SqlParameter paraBLGoodsCd = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                                    paraBLGoodsCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.BLGoodsCode);
                                    break;
                                }
                            case 6:
                                {
                                    selectTxt2 += " AND CAMPAIGNMNGRF.SALESCODERF=@SALESCODE" + Environment.NewLine;
                                    SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
                                    paraSalesCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.SalesCode);
                                    break;
                                }
                        }

                        selectTxt2 += " AND CAMPAIGNMNGRF.CAMPAIGNCODERF=@CAMPAIGNCODE" + Environment.NewLine;
                        SqlParameter paraCampaignCd = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);
                        paraCampaignCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CampaignCode);

                        selectTxt2 += " AND CAMPAIGNMNGRF.SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.SectionCode.Trim());

                        SqlParameter paraEnterpriseCd = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        paraEnterpriseCd.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.EnterpriseCode);

                        SqlParameter paraCampainSetting = sqlCommand.Parameters.Add("@CAMPAIGNSETTINGKIND", SqlDbType.Int);
                        paraCampainSetting.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CampaignSettingKind);

                        sqlCommand.CommandText = selectTxt2;

                        myReader = sqlCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                            campaignObjGoodsStWork.SalesPriceSetDiv = 0;
                            paraobj = campaignObjGoodsStWork as object;
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            return status;
                        }
                    }
                    // ---UPD 2011/07/15--------------<<<<<

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException sqlex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(sqlex);
                }
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignObjGoodsStDB.ReadDBBeforeSave", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader.IsClosed == false) myReader.Close();
            }
            return status;
        }
        #endregion

        #region Write(ref byte[] parabyte)
        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^��o�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraobj">CampaignMngWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^��o�^�A�X�V���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int Write(ref object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = this.WriteProc(ref paraobj, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignObjGoodsStDB.Write", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^��o�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraobj">CampaignMngWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^��o�^�A�X�V���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int WriteProc(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                try
                {
                    if (sqlConnection == null)
                    {
                        SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                        string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                        if (connectionText == null || connectionText == "") return status;

                        sqlConnection = new SqlConnection(connectionText);
                        sqlConnection.Open();
                    }

                    CampaignObjGoodsStWork campaignObjGoodsStWork = paraobj as CampaignObjGoodsStWork;

                    //Select�R�}���h�̐���
                    using (sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, GOODSMGROUPRF, BLGOODSCODERF, GOODSMAKERCDRF, GOODSNORF, SALESTARGETMONEYRF, SALESTARGETPROFITRF, SALESTARGETCOUNTRF, CAMPAIGNCODERF, PRICEFLRF, RATEVALRF, BLGROUPCODERF, SALESCODERF, CAMPAIGNSETTINGKINDRF, SALESPRICESETDIVRF, CUSTOMERCODERF, PRICESTARTDATERF, PRICEENDDATERF, DISCOUNTRATERF FROM CAMPAIGNMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSMGROUPRF=@FINDGOODSMGROUP AND BLGOODSCODERF=@FINDBLGOODSCODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND CAMPAIGNCODERF=@FINDCAMPAIGNCODE AND BLGROUPCODERF=@FINDBLGROUPCODE AND SALESCODERF=@FINDSALESCODE AND CAMPAIGNSETTINGKINDRF=@FINDCAMPAIGNSETTINGKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND PRICESTARTDATERF=@FINDPRICESTARTDATE AND PRICEENDDATERF=@FINDPRICEENDDATE", sqlConnection))
                    {

                        if (sqlTransaction != null)
                        {
                            sqlCommand.Transaction = sqlTransaction;
                        }

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
                        SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
                        SqlParameter findParaCampaignSettingKind = sqlCommand.Parameters.Add("@FINDCAMPAIGNSETTINGKIND", SqlDbType.Int);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);
                        SqlParameter findParaPriceEndDate = sqlCommand.Parameters.Add("@FINDPRICEENDDATE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.EnterpriseCode.Trim());
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.SectionCode.Trim());
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.GoodsMGroup);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.BLGoodsCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.GoodsMakerCd);
                        if (!string.Empty.Equals(campaignObjGoodsStWork.GoodsNo.Trim()))
                        {
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.GoodsNo);
                        }
                        else
                        {
                            findParaGoodsNo.Value = campaignObjGoodsStWork.GoodsNo;
                        }
                        findParaCampaignCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CampaignCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.BLGroupCode);
                        findParaSalesCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.SalesCode);
                        findParaCampaignSettingKind.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CampaignSettingKind);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CustomerCode);
                        findParaPriceStartDate.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.PriceStartDate);
                        findParaPriceEndDate.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.PriceEndDate);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != campaignObjGoodsStWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (campaignObjGoodsStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                if (sqlCommand != null)
                                {
                                    sqlCommand.Cancel();
                                    sqlCommand.Dispose();
                                }
                                if (!myReader.IsClosed) myReader.Close();
                                sqlConnection.Close();
                                return status;
                            }
                            sqlCommand.CommandText = "UPDATE CAMPAIGNMNGRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , GOODSMGROUPRF=@GOODSMGROUP , BLGOODSCODERF=@BLGOODSCODE , GOODSMAKERCDRF=@GOODSMAKERCD , GOODSNORF=@GOODSNO , SALESTARGETMONEYRF=@SALESTARGETMONEY , SALESTARGETPROFITRF=@SALESTARGETPROFIT , SALESTARGETCOUNTRF=@SALESTARGETCOUNT , CAMPAIGNCODERF=@CAMPAIGNCODE , PRICEFLRF=@PRICEFL , RATEVALRF=@RATEVAL , BLGROUPCODERF=@BLGROUPCODE , SALESCODERF=@SALESCODE , CAMPAIGNSETTINGKINDRF=@CAMPAIGNSETTINGKIND , SALESPRICESETDIVRF=@SALESPRICESETDIV , CUSTOMERCODERF=@CUSTOMERCODE , PRICESTARTDATERF=@PRICESTARTDATE , PRICEENDDATERF=@PRICEENDDATE, DISCOUNTRATERF=@DISCOUNTRATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSMGROUPRF=@FINDGOODSMGROUP AND BLGOODSCODERF=@FINDBLGOODSCODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND CAMPAIGNCODERF=@FINDCAMPAIGNCODE AND BLGROUPCODERF=@FINDBLGROUPCODE AND SALESCODERF=@FINDSALESCODE AND CAMPAIGNSETTINGKINDRF=@FINDCAMPAIGNSETTINGKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND PRICESTARTDATERF=@FINDPRICESTARTDATE AND PRICEENDDATERF=@FINDPRICEENDDATE";
                            
                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignObjGoodsStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (campaignObjGoodsStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                if (sqlCommand != null)
                                {
                                    sqlCommand.Cancel();
                                    sqlCommand.Dispose();
                                }
                                if (!myReader.IsClosed) myReader.Close();
                                sqlConnection.Close();
                                return status;
                            }

                            //�V�K�쐬����SQL���𐶐�             
                            sqlCommand.CommandText = "INSERT INTO CAMPAIGNMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, GOODSMGROUPRF, BLGOODSCODERF, GOODSMAKERCDRF, GOODSNORF, SALESTARGETMONEYRF, SALESTARGETPROFITRF, SALESTARGETCOUNTRF, CAMPAIGNCODERF, PRICEFLRF, RATEVALRF, BLGROUPCODERF, SALESCODERF, CAMPAIGNSETTINGKINDRF, SALESPRICESETDIVRF, CUSTOMERCODERF, PRICESTARTDATERF, PRICEENDDATERF, DISCOUNTRATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @GOODSMGROUP, @BLGOODSCODE, @GOODSMAKERCD, @GOODSNO, @SALESTARGETMONEY, @SALESTARGETPROFIT, @SALESTARGETCOUNT, @CAMPAIGNCODE, @PRICEFL, @RATEVAL, @BLGROUPCODE, @SALESCODE, @CAMPAIGNSETTINGKIND, @SALESPRICESETDIV, @CUSTOMERCODE, @PRICESTARTDATE, @PRICEENDDATE, @DISCOUNTRATE)";
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignObjGoodsStWork;
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
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraSalesTargetMoney = sqlCommand.Parameters.Add("@SALESTARGETMONEY", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit = sqlCommand.Parameters.Add("@SALESTARGETPROFIT", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetCount = sqlCommand.Parameters.Add("@SALESTARGETCOUNT", SqlDbType.Float);
                        SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);
                        SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFL", SqlDbType.Float);
                        SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVAL", SqlDbType.Float);
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
                        SqlParameter paraCampaignSettingKind = sqlCommand.Parameters.Add("@CAMPAIGNSETTINGKIND", SqlDbType.Int);
                        SqlParameter paraSalesPriceSetDiv = sqlCommand.Parameters.Add("@SALESPRICESETDIV", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraPriceStartDate = sqlCommand.Parameters.Add("@PRICESTARTDATE", SqlDbType.Int);
                        SqlParameter paraPriceEndDate = sqlCommand.Parameters.Add("@PRICEENDDATE", SqlDbType.Int);
                        SqlParameter paraDiscountRate = sqlCommand.Parameters.Add("@DISCOUNTRATE", SqlDbType.Float);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignObjGoodsStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignObjGoodsStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(campaignObjGoodsStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.SectionCode);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.GoodsMGroup);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.BLGoodsCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.GoodsMakerCd);
                        if (!string.Empty.Equals(campaignObjGoodsStWork.GoodsNo.Trim()))
                        {
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.GoodsNo);
                        }
                        else
                        {
                            paraGoodsNo.Value = campaignObjGoodsStWork.GoodsNo;
                        }
                        paraSalesTargetMoney.Value = SqlDataMediator.SqlSetInt64(campaignObjGoodsStWork.SalesTargetMoney);
                        paraSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(campaignObjGoodsStWork.SalesTargetProfit);
                        paraSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(campaignObjGoodsStWork.SalesTargetCount);
                        paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.CampaignCode);
                        paraPriceFl.Value = SqlDataMediator.SqlSetDouble(campaignObjGoodsStWork.PriceFl);
                        paraRateVal.Value = SqlDataMediator.SqlSetDouble(campaignObjGoodsStWork.RateVal);
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.BLGroupCode);
                        paraSalesCode.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.SalesCode);
                        paraCampaignSettingKind.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.CampaignSettingKind);
                        paraSalesPriceSetDiv.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.SalesPriceSetDiv);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.CustomerCode);
                        paraPriceStartDate.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.PriceStartDate);
                        paraPriceEndDate.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.PriceEndDate);
                        paraDiscountRate.Value = SqlDataMediator.SqlSetDouble(campaignObjGoodsStWork.DiscountRate);

                        sqlCommand.ExecuteNonQuery();

                        paraobj = campaignObjGoodsStWork as object;

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
                base.WriteErrorLog(ex, "CAMPAIGNMNGInfoDB.Write");
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose(); 
                }
                if (myReader.IsClosed == false) myReader.Close();
            }

            return status;
        }

        #endregion

        #region LogicalDelete & RevivalLogicalDelete

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^��_���폜���܂�
        /// </summary>
        /// <param name="paraobj">UOEConnectInfoWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^��_���폜���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int LogicalDelete(ref object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = LogicalDeleteProc(ref paraobj, 0, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignMngWork.LogicalDelete");
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
            return status;
        }

        /// <summary>
        /// �_���폜�L�����y�[���Ώۏ��i�ݒ�}�X�^�𕜊����܂�
        /// </summary>
        /// <param name="paraobj">CampaignMngWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�L�����y�[���Ώۏ��i�ݒ�}�X�^�𕜊����܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = LogicalDeleteProc(ref paraobj, 1, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignMngWork.LogicalDelete");
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
            return status;
        }

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="paraobj">CampaignMngWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int LogicalDeleteProc(ref object paraobj, int procMode,ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                if (sqlConnection == null)
                {
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();
                }

                CampaignObjGoodsStWork campaignObjGoodsStWork = paraobj as CampaignObjGoodsStWork;

                using (sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, GOODSMGROUPRF, BLGOODSCODERF, GOODSMAKERCDRF, GOODSNORF, SALESTARGETMONEYRF, SALESTARGETPROFITRF, SALESTARGETCOUNTRF, CAMPAIGNCODERF, PRICEFLRF, RATEVALRF, BLGROUPCODERF, SALESCODERF, CAMPAIGNSETTINGKINDRF, SALESPRICESETDIVRF, CUSTOMERCODERF, PRICESTARTDATERF, PRICEENDDATERF, DISCOUNTRATERF FROM CAMPAIGNMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSMGROUPRF=@FINDGOODSMGROUP AND BLGOODSCODERF=@FINDBLGOODSCODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND CAMPAIGNCODERF=@FINDCAMPAIGNCODE AND BLGROUPCODERF=@FINDBLGROUPCODE AND SALESCODERF=@FINDSALESCODE AND CAMPAIGNSETTINGKINDRF=@FINDCAMPAIGNSETTINGKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND PRICESTARTDATERF=@FINDPRICESTARTDATE AND PRICEENDDATERF=@FINDPRICEENDDATE", sqlConnection))
                {
                    if (sqlTransaction != null)
                    {
                        sqlCommand.Transaction = sqlTransaction;
                    }

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
                    SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                    SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
                    SqlParameter findParaCampaignSettingKind = sqlCommand.Parameters.Add("@FINDCAMPAIGNSETTINGKIND", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);
                    SqlParameter findParaPriceEndDate = sqlCommand.Parameters.Add("@FINDPRICEENDDATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.SectionCode);
                    findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.GoodsMGroup);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.BLGoodsCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.GoodsMakerCd);
                    if (campaignObjGoodsStWork.GoodsNo.Trim() == string.Empty)
                    {
                        findParaGoodsNo.Value = campaignObjGoodsStWork.GoodsNo;
                    }
                    else
                    {
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.GoodsNo); 
                    }
                    findParaCampaignCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CampaignCode);
                    findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.BLGroupCode);
                    findParaSalesCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.SalesCode);
                    findParaCampaignSettingKind.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CampaignSettingKind);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CustomerCode);
                    findParaPriceStartDate.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.PriceStartDate);
                    findParaPriceEndDate.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.PriceEndDate);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != campaignObjGoodsStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;

                            if (sqlCommand != null)
                            {
                                sqlCommand.Cancel();
                                sqlCommand.Dispose();
                            }
                            if (!myReader.IsClosed) myReader.Close();

                            return status;
                        }
                        //���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        sqlCommand.CommandText = "UPDATE CAMPAIGNMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSMGROUPRF=@FINDGOODSMGROUP AND BLGOODSCODERF=@FINDBLGOODSCODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND CAMPAIGNCODERF=@FINDCAMPAIGNCODE AND BLGROUPCODERF=@FINDBLGROUPCODE AND SALESCODERF=@FINDSALESCODE AND CAMPAIGNSETTINGKINDRF=@FINDCAMPAIGNSETTINGKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND PRICESTARTDATERF=@FINDPRICESTARTDATE AND PRICEENDDATERF=@FINDPRICEENDDATE";
                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.SectionCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.GoodsMGroup);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.BLGoodsCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.GoodsMakerCd);
                        if (campaignObjGoodsStWork.GoodsNo.Trim() == string.Empty)
                        {
                            findParaGoodsNo.Value = campaignObjGoodsStWork.GoodsNo;
                        }
                        else
                        {
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.GoodsNo);
                        }
                        findParaCampaignCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CampaignCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.BLGroupCode);
                        findParaSalesCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.SalesCode);
                        findParaCampaignSettingKind.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CampaignSettingKind);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CustomerCode);
                        findParaPriceStartDate.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.PriceStartDate);
                        findParaPriceEndDate.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.PriceEndDate);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)campaignObjGoodsStWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                        if (sqlCommand != null)
                        {
                            sqlCommand.Cancel();
                            sqlCommand.Dispose();
                        }
                        if (!myReader.IsClosed) myReader.Close();

                        return status;
                    }
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();

                    //�_���폜���[�h�̏ꍇ
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 0) campaignObjGoodsStWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                        else campaignObjGoodsStWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                    }
                    else
                    {
                        if (logicalDelCd == 1) campaignObjGoodsStWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignObjGoodsStWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();

                    paraobj = campaignObjGoodsStWork as CampaignObjGoodsStWork;
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
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader.IsClosed == false) myReader.Close();
            }

            return status;

        }
        #endregion

        #region Delete(byte[] parabyte)
        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�𕨗��폜���܂�
        /// </summary>
        /// <param name="paraobj">�L�����y�[���Ώۏ��i�ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�𕨗��폜���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int Delete(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = this.DeleteProc(paraobj, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignObjGoodsStDB.Delete");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�𕨗��폜���܂�
        /// </summary>
        /// <param name="paraobj">�L�����y�[���Ώۏ��i�ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�𕨗��폜���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int DeleteProc(object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                try
                {
                    if (sqlConnection == null)
                    {
                        //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                        SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                        string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                        if (connectionText == null || connectionText == "") return status;

                        sqlConnection = new SqlConnection(connectionText);
                        sqlConnection.Open();
                    }

                    CampaignObjGoodsStWork campaignObjGoodsStWork = paraobj as CampaignObjGoodsStWork;

                    using (sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, GOODSMGROUPRF, BLGOODSCODERF, GOODSMAKERCDRF, GOODSNORF, SALESTARGETMONEYRF, SALESTARGETPROFITRF, SALESTARGETCOUNTRF, CAMPAIGNCODERF, PRICEFLRF, RATEVALRF, BLGROUPCODERF, SALESCODERF, CAMPAIGNSETTINGKINDRF, SALESPRICESETDIVRF, CUSTOMERCODERF, PRICESTARTDATERF, PRICEENDDATERF, DISCOUNTRATERF FROM CAMPAIGNMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSMGROUPRF=@FINDGOODSMGROUP AND BLGOODSCODERF=@FINDBLGOODSCODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND CAMPAIGNCODERF=@FINDCAMPAIGNCODE AND BLGROUPCODERF=@FINDBLGROUPCODE AND SALESCODERF=@FINDSALESCODE AND CAMPAIGNSETTINGKINDRF=@FINDCAMPAIGNSETTINGKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND PRICESTARTDATERF=@FINDPRICESTARTDATE AND PRICEENDDATERF=@FINDPRICEENDDATE", sqlConnection))
                    {
                        if (sqlTransaction != null)
                        {
                            sqlCommand.Transaction = sqlTransaction;
                        }

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
                        SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
                        SqlParameter findParaCampaignSettingKind = sqlCommand.Parameters.Add("@FINDCAMPAIGNSETTINGKIND", SqlDbType.Int);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);
                        SqlParameter findParaPriceEndDate = sqlCommand.Parameters.Add("@FINDPRICEENDDATE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.EnterpriseCode.Trim());
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.SectionCode.Trim());
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.GoodsMGroup);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.BLGoodsCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.GoodsMakerCd);
                        if (!string.Empty.Equals(campaignObjGoodsStWork.GoodsNo.Trim()))
                        {
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.GoodsNo);
                        }
                        else
                        {
                            findParaGoodsNo.Value = campaignObjGoodsStWork.GoodsNo;
                        }
                        findParaCampaignCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CampaignCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.BLGroupCode);
                        findParaSalesCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.SalesCode);
                        findParaCampaignSettingKind.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CampaignSettingKind);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CustomerCode);
                        findParaPriceStartDate.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.PriceStartDate);
                        findParaPriceEndDate.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.PriceEndDate);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != campaignObjGoodsStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                if (sqlCommand != null)
                                {
                                    sqlCommand.Cancel();
                                    sqlCommand.Dispose();
                                }
                                if (!myReader.IsClosed) myReader.Close();

                                return status;
                            }

                            sqlCommand.CommandText = "DELETE FROM CAMPAIGNMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND GOODSMGROUPRF=@FINDGOODSMGROUP AND BLGOODSCODERF=@FINDBLGOODSCODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND CAMPAIGNCODERF=@FINDCAMPAIGNCODE AND BLGROUPCODERF=@FINDBLGROUPCODE AND SALESCODERF=@FINDSALESCODE AND CAMPAIGNSETTINGKINDRF=@FINDCAMPAIGNSETTINGKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND PRICESTARTDATERF=@FINDPRICESTARTDATE AND PRICEENDDATERF=@FINDPRICEENDDATE";
                            //Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.SectionCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.GoodsMGroup);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.BLGoodsCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.GoodsMakerCd);
                            if (!string.Empty.Equals(campaignObjGoodsStWork.GoodsNo.Trim()))
                            {
                                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.GoodsNo);
                            }
                            else
                            {
                                findParaGoodsNo.Value = campaignObjGoodsStWork.GoodsNo;
                            }
                            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CampaignCode);
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.BLGroupCode);
                            findParaSalesCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.SalesCode);
                            findParaCampaignSettingKind.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CampaignSettingKind);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.CustomerCode);
                            findParaPriceStartDate.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.PriceStartDate);
                            findParaPriceEndDate.Value = SqlDataMediator.SqlSetInt(campaignObjGoodsStWork.PriceEndDate);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            if (sqlCommand != null)
                            {
                                sqlCommand.Cancel();
                                sqlCommand.Dispose();
                            }
                            if (!myReader.IsClosed) myReader.Close();

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
                base.WriteErrorLog(ex, "CampaignObjGoodsStDB.Delete");
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader.IsClosed == false) myReader.Close();
            }
            return status;
        }
        #endregion


        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^��_���폜�Ɠo�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraDelObj">CampaignMngWork�I�u�W�F�N�g</param>
        /// <param name="paraUpdObj">CampaignMngWork�I�u�W�F�N�g</param>
        /// <param name="errorObj">CampaignMngWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^��_���폜�Ɠo�^�A�X�V���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        public int DeleteAndWrite(object paraDelObj, ref object paraUpdObj, out object errorObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            errorObj = null;
            ArrayList delList = null;
            ArrayList updList = null;

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                {
                    errorObj = null;
                    return status;
                }

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction();

                delList = paraDelObj as ArrayList;
                updList = paraUpdObj as ArrayList;

                foreach (CampaignObjGoodsStWork campaignMngWork in delList)
                {
                    object paraObj = campaignMngWork as object;
                    status = this.DeleteProc(paraObj, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        errorObj = null;
                        return status;
                    }
                }


                foreach (CampaignObjGoodsStWork campaignMngWork in updList)
                {
                    object paraObj = campaignMngWork as object;
                    if (campaignMngWork.LogicalDeleteCode == 0)
                    {
                        // ---UPD 2011/07/15----------------->>>>>
                        //status = this.ReadDBBeforeSave(paraObj, ref sqlConnection, ref sqlTransaction);
                        status = this.ReadDBBeforeSave(ref paraObj, ref sqlConnection, ref sqlTransaction);
                        // ---UPD 2011/07/15-----------------<<<<<
                        if (status != 0)
                        {
                            errorObj = paraObj;
                            return status;
                        }

                        status = this.WriteProc(ref paraObj, ref sqlConnection, ref sqlTransaction);
                    }
                    else
                    {
                        status = this.LogicalDeleteProc(ref paraObj, 0, ref sqlConnection, ref sqlTransaction);
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        errorObj = null;
                        return status;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignMngInfoDB.DeleteAndWrite");
                errorObj = null;
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�����S�폜�A�������܂�
        /// </summary>
        /// <param name="paraDelObj">CampaignMngWork�I�u�W�F�N�g</param>
        /// <param name="paraUpdObj">CampaignMngWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�����S�폜�A�������܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        public int DeleteAndRevival(object paraDelObj, ref object paraUpdObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList delList = null;
            ArrayList updList = null;

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction();

                delList = paraDelObj as ArrayList;
                updList = paraUpdObj as ArrayList;

                foreach (CampaignObjGoodsStWork campaignMngWork in delList)
                {
                    object paraObj = campaignMngWork as object;
                    status = this.DeleteProc(paraObj, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }


                foreach (CampaignObjGoodsStWork campaignMngWork in updList)
                {
                    object paraObj = campaignMngWork as object;
                    status = this.LogicalDeleteProc(ref paraObj, 1, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignMngInfoDB.DeleteAndWrite");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        # region -- �N���X�����o�[�R�s�[���� --
        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�}�X�^�N���X�i�[���� Reader �� CampaignMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CampaignMngWork</returns>
        /// <remarks>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private CampaignObjGoodsStWork CopyToCampaignMngWorkFromReader(ref SqlDataReader myReader)
        {
            CampaignObjGoodsStWork campaignObjGoodsStWork = new CampaignObjGoodsStWork();

            #region �N���X�֊i�[
            campaignObjGoodsStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            campaignObjGoodsStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            campaignObjGoodsStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            campaignObjGoodsStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            campaignObjGoodsStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            campaignObjGoodsStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            campaignObjGoodsStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            campaignObjGoodsStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            campaignObjGoodsStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            campaignObjGoodsStWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            campaignObjGoodsStWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            campaignObjGoodsStWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            campaignObjGoodsStWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            campaignObjGoodsStWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEYRF"));
            campaignObjGoodsStWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFITRF"));
            campaignObjGoodsStWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNTRF"));
            campaignObjGoodsStWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));
            campaignObjGoodsStWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));
            campaignObjGoodsStWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));
            campaignObjGoodsStWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            campaignObjGoodsStWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
            campaignObjGoodsStWork.CampaignSettingKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNSETTINGKINDRF"));
            campaignObjGoodsStWork.SalesPriceSetDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESPRICESETDIVRF"));
            campaignObjGoodsStWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            campaignObjGoodsStWork.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            campaignObjGoodsStWork.PriceEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEENDDATERF"));
            campaignObjGoodsStWork.DiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISCOUNTRATERF"));

            #endregion

            return campaignObjGoodsStWork;
        }

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�}�X�^�N���X�i�[���� Reader �� CampaignMngWork
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="searchConditionWork">searchConditionWork</param>
        /// <param name="logicalMode">logicalMode</param>
        /// <returns>WHERE��</returns>
        /// <remarks>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, SearchConditionWork searchConditionWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = string.Empty;
            retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " CAMPAIGNMNGRF.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(searchConditionWork.EnterpriseCode);

            //�_���폜�敪
            retstring += "  AND CAMPAIGNMNGRF.LOGICALDELETECODERF=@LOGICALDELETECODERF" + Environment.NewLine;
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODERF", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

            //�L�����y�[���R�[�h
            if (searchConditionWork.CampaignCode != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.CAMPAIGNCODERF=@CAMPAIGNCODERF" + Environment.NewLine;
                SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODERF", SqlDbType.Int);
                paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(searchConditionWork.CampaignCode);
            }
            //���_�R�[�h
            if (Convert.ToInt32(searchConditionWork.SectionCode) != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.SECTIONCODERF=@SECTIONCODERF" + Environment.NewLine;
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODERF", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(searchConditionWork.SectionCode.Trim().PadLeft(2, '0'));
            }
            //�̔��敪�i�J�n�j
            if (searchConditionWork.SalesCodeSt != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.SALESCODERF>=@SALESCODESTRF" + Environment.NewLine;
                SqlParameter paraSalesCodeST = sqlCommand.Parameters.Add("@SALESCODESTRF", SqlDbType.Int);
                paraSalesCodeST.Value = SqlDataMediator.SqlSetInt32(searchConditionWork.SalesCodeSt);
            }
            //�̔��敪�i�I���j
            if (searchConditionWork.SalesCodeEd != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.SALESCODERF<=@SALESCODEEDRF" + Environment.NewLine;
                SqlParameter paraSalesCodeED = sqlCommand.Parameters.Add("@SALESCODEEDRF", SqlDbType.Int);
                paraSalesCodeED.Value = SqlDataMediator.SqlSetInt32(searchConditionWork.SalesCodeEd);
            }
            //�a�k�R�[�h�i�J�n�j
            if (searchConditionWork.BLGoodsCodeSt != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.BLGOODSCODERF>=@BLGOODSCODESTRF" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@BLGOODSCODESTRF", SqlDbType.Int);
                paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(searchConditionWork.BLGoodsCodeSt);
            }
            //�a�k�R�[�h�i�I���j
            if (searchConditionWork.BLGoodsCodeEd != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.BLGOODSCODERF<=@BLGOODSCODEEDRF" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@BLGOODSCODEEDRF", SqlDbType.Int);
                paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(searchConditionWork.BLGoodsCodeEd);
            }
            //�i��*
            if (searchConditionWork.GoodsNo.Trim() != string.Empty)
            {
                if (searchConditionWork.GoodsNo.Trim().Substring(searchConditionWork.GoodsNo.Trim().Length - 1, 1) == "*")
                {
                    retstring += " AND REPLACE(CAMPAIGNMNGRF.GOODSNORF,'-','') LIKE REPLACE(@GOODSNO,'-','')" + Environment.NewLine;
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(searchConditionWork.GoodsNo.Trim().Substring(0, searchConditionWork.GoodsNo.Trim().Length - 1) + "%");
                }
                else
                {
                    retstring += " AND REPLACE(CAMPAIGNMNGRF.GOODSNORF,'-','') = REPLACE(@GOODSNO,'-','')" + Environment.NewLine;
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(searchConditionWork.GoodsNo.Trim());
                }
            }
            //�O���[�v�R�[�h�i�J�n�j
            if (searchConditionWork.BLGroupCodeSt != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.BLGROUPCODERF>=@BLGROUPCODESTRF" + Environment.NewLine;
                SqlParameter paraBLGroupCodeST = sqlCommand.Parameters.Add("@BLGROUPCODESTRF", SqlDbType.Int);
                paraBLGroupCodeST.Value = SqlDataMediator.SqlSetInt32(searchConditionWork.BLGroupCodeSt);
            }
            //�O���[�v�R�[�h�i�I���j
            if (searchConditionWork.BLGroupCodeEd != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.BLGROUPCODERF<=@BLGROUPCODEEDRF" + Environment.NewLine;
                SqlParameter paraBLGroupCodeED = sqlCommand.Parameters.Add("@BLGROUPCODEEDRF", SqlDbType.Int);
                paraBLGroupCodeED.Value = SqlDataMediator.SqlSetInt32(searchConditionWork.BLGroupCodeEd);
            }
            //���[�J�[�R�[�h�i�J�n�j
            if (searchConditionWork.GoodsMakerCdSt != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.GOODSMAKERCDRF>=@GOODSMAKERCDSTRF" + Environment.NewLine;
                SqlParameter paraStGoodsMakerCdST = sqlCommand.Parameters.Add("@GOODSMAKERCDSTRF", SqlDbType.Int);
                paraStGoodsMakerCdST.Value = SqlDataMediator.SqlSetInt32(searchConditionWork.GoodsMakerCdSt);
            }
            //���[�J�[�R�[�h�i�I���j
            if (searchConditionWork.GoodsMakerCdEd != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.GOODSMAKERCDRF<=@GOODSMAKERCDEDRF" + Environment.NewLine;
                SqlParameter paraEdGoodsMakerCdED = sqlCommand.Parameters.Add("@GOODSMAKERCDEDRF", SqlDbType.Int);
                paraEdGoodsMakerCdED.Value = SqlDataMediator.SqlSetInt32(searchConditionWork.GoodsMakerCdEd);
            }
            //�l����
            if (searchConditionWork.DiscountRate != 0.00)
            {
                if (searchConditionWork.DiscountRateDiv == 1)
                {
                    retstring += " AND CAMPAIGNMNGRF.DISCOUNTRATERF=@DISCOUNTRATERF" + Environment.NewLine;
                    SqlParameter paraDiscountRate = sqlCommand.Parameters.Add("@DISCOUNTRATERF", SqlDbType.Float);
                    paraDiscountRate.Value = SqlDataMediator.SqlSetDouble(searchConditionWork.DiscountRate);
                }
                else if (searchConditionWork.DiscountRateDiv == 2)
                {
                    retstring += " AND CAMPAIGNMNGRF.DISCOUNTRATERF>=@DISCOUNTRATERF" + Environment.NewLine;
                    SqlParameter paraDiscountRate = sqlCommand.Parameters.Add("@DISCOUNTRATERF", SqlDbType.Float);
                    paraDiscountRate.Value = SqlDataMediator.SqlSetDouble(searchConditionWork.DiscountRate);
                }
                else if (searchConditionWork.DiscountRateDiv == 3)
                {
                    retstring += " AND CAMPAIGNMNGRF.DISCOUNTRATERF<=@DISCOUNTRATERF AND CAMPAIGNMNGRF.DISCOUNTRATERF>0" + Environment.NewLine;
                    SqlParameter paraDiscountRate = sqlCommand.Parameters.Add("@DISCOUNTRATERF", SqlDbType.Float);
                    paraDiscountRate.Value = SqlDataMediator.SqlSetDouble(searchConditionWork.DiscountRate);
                }
                else
                {
                    //�Ȃ��B
                }
            }
            //������
            if (searchConditionWork.RateVal != 0.00)
            {
                if (searchConditionWork.RateValDiv == 1)
                {
                    retstring += " AND CAMPAIGNMNGRF.RATEVALRF=@RATEVALRF" + Environment.NewLine;
                    SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVALRF", SqlDbType.Float);
                    paraRateVal.Value = SqlDataMediator.SqlSetDouble(searchConditionWork.RateVal);
                }
                else if (searchConditionWork.RateValDiv == 2)
                {
                    retstring += " AND CAMPAIGNMNGRF.RATEVALRF>=@RATEVALRF" + Environment.NewLine;
                    SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVALRF", SqlDbType.Float);
                    paraRateVal.Value = SqlDataMediator.SqlSetDouble(searchConditionWork.RateVal);
                }
                else if (searchConditionWork.RateValDiv == 3)
                {
                    retstring += " AND CAMPAIGNMNGRF.RATEVALRF<=@RATEVALRF AND CAMPAIGNMNGRF.RATEVALRF>0" + Environment.NewLine;
                    SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVALRF", SqlDbType.Float);
                    paraRateVal.Value = SqlDataMediator.SqlSetDouble(searchConditionWork.RateVal);
                }
                else
                {
                    //�Ȃ��B
                }
            }
            //�����z
            if (searchConditionWork.PriceFl != 0.00)
            {
                if (searchConditionWork.PriceFlDiv == 1)
                {
                    retstring += " AND CAMPAIGNMNGRF.PRICEFLRF=@PRICEFLRF" + Environment.NewLine;
                    SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFLRF", SqlDbType.Float);
                    paraPriceFl.Value = SqlDataMediator.SqlSetDouble(searchConditionWork.PriceFl);
                }
                else if (searchConditionWork.PriceFlDiv == 2)
                {
                    retstring += " AND CAMPAIGNMNGRF.PRICEFLRF>=@PRICEFLRF" + Environment.NewLine;
                    SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFLRF", SqlDbType.Float);
                    paraPriceFl.Value = SqlDataMediator.SqlSetDouble(searchConditionWork.PriceFl);
                }
                else if (searchConditionWork.PriceFlDiv == 3)
                {
                    retstring += " AND CAMPAIGNMNGRF.PRICEFLRF<=@PRICEFLRF AND CAMPAIGNMNGRF.PRICEFLRF>0" + Environment.NewLine;
                    SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFLRF", SqlDbType.Float);
                    paraPriceFl.Value = SqlDataMediator.SqlSetDouble(searchConditionWork.PriceFl);
                }
                else
                {
                    //�Ȃ��B
                }
            }
            #endregion
            return retstring;
        }

        /// <summary>
        /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�}�X�^�N���X�i�[���� Reader �� CampaignMngWork
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="campaignObjGoodsStWork">campaignObjGoodsStWork</param>
        /// <returns>WHERE��</returns>
        /// <remarks>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, CampaignObjGoodsStWork campaignObjGoodsStWork)
        {
            #region WHERE���쐬
            string retstring = string.Empty;
            retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            if (campaignObjGoodsStWork.EnterpriseCode.Trim() != string.Empty)
            {
                retstring += " CAMPAIGNMNGRF.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.EnterpriseCode);
            }
            //���_�R�[�h
            if (campaignObjGoodsStWork.SectionCode.Trim() != string.Empty)
            {
                retstring += " AND CAMPAIGNMNGRF.SECTIONCODERF=@SECTIONCODERF" + Environment.NewLine;
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODERF", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.SectionCode.Trim().PadLeft(2, '0'));
            }
            //�L�����y�[���R�[�h
            if (campaignObjGoodsStWork.CampaignCode != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.CAMPAIGNCODERF=@CAMPAIGNCODERF" + Environment.NewLine;
                SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODERF", SqlDbType.Int);
                paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.CampaignCode);
            }
            //�L�����y�[���ݒ���
            if (campaignObjGoodsStWork.CampaignSettingKind != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.CAMPAIGNSETTINGKINDRF=@CAMPAIGNSETTINGKINDRF" + Environment.NewLine;
                SqlParameter paraCampaignSettingKind = sqlCommand.Parameters.Add("@CAMPAIGNSETTINGKINDRF", SqlDbType.Int);
                paraCampaignSettingKind.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.CampaignSettingKind);
            }
            //���i�����ރR�[�h
            if (campaignObjGoodsStWork.GoodsMGroup != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.GOODSMGROUPRF=@GOODSMGROUPRF" + Environment.NewLine;
                SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUPRF", SqlDbType.Int);
                paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.GoodsMGroup);
            }
            //�O���[�v�R�[�h
            if (campaignObjGoodsStWork.BLGroupCode != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.BLGROUPCODERF=@BLGROUPCODERF" + Environment.NewLine;
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODERF", SqlDbType.Int);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.BLGroupCode);
            }
            //�a�k�R�[�h
            if (campaignObjGoodsStWork.BLGoodsCode != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.BLGOODSCODERF=@BLGOODSCODERF" + Environment.NewLine;
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODERF", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.BLGoodsCode);
            }
            //�̔��敪
            if (campaignObjGoodsStWork.SalesCode != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.SALESCODERF=@SALESCODEEDRF" + Environment.NewLine;
                SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODEEDRF", SqlDbType.Int);
                paraSalesCode.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.SalesCode);
            }
            //���[�J�[�R�[�h
            if (campaignObjGoodsStWork.GoodsMakerCd != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.GOODSMAKERCDRF=@GOODSMAKERCDSTRF" + Environment.NewLine;
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCDSTRF", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.GoodsMakerCd);
            }
            //�i��
            if (campaignObjGoodsStWork.GoodsNo.Trim() != string.Empty)
            {
                retstring += " AND REPLACE(CAMPAIGNMNGRF.GOODSNORF,'-','') = REPLACE(@GOODSNO,'-','')" + Environment.NewLine;
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(campaignObjGoodsStWork.GoodsNo.Trim());
            }
            //���Ӑ�R�[�h
            if (campaignObjGoodsStWork.CustomerCode != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.CUSTOMERCODERF=@CUSTOMERCODERF" + Environment.NewLine;
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODERF", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.CustomerCode);
            }
            //���i�J�n��
            if (campaignObjGoodsStWork.PriceStartDate != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.PRICEENDDATERF=@PRICEENDDATERF" + Environment.NewLine;
                SqlParameter paraPriceEndDate = sqlCommand.Parameters.Add("@PRICEENDDATERF", SqlDbType.Int);
                paraPriceEndDate.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.PriceStartDate);
            }
            //���i�I����
            if (campaignObjGoodsStWork.PriceEndDate != 0)
            {
                retstring += " AND CAMPAIGNMNGRF.CUSTOMERCODERF=@CUSTOMERCODERF" + Environment.NewLine;
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODERF", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignObjGoodsStWork.PriceEndDate);
            }
            #endregion
            return retstring;
        }
        #endregion
    }
}

