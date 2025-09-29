//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜
// �v���O�����T�v   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2011/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/28  �C�����e : Redmine#23278 ���[�U�[��ł͔������Ȃ��������̊�Ƃ����ڂ���c�ƃf���@�ȂǂŔ�������̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br></br>
    /// <br>Update Note: 2011/07/28 Redmine#23278 ���[�U�[��ł͔������Ȃ��������̊�Ƃ����ڂ���c�ƃf���@�ȂǂŔ�������̑Ή�</br>
    /// </remarks>
    [Serializable]
    public class CampaignGoodsStDB : RemoteDB, ICampaignGoodsStDB
    {
        # region ��������
        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="objCampaignMngStWorkList">��������</param>
        /// <param name="searchParaObj">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^�̃L�[�l����v����A�S�ẴL�����y�[���Ǘ��}�X�^�����擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int Search(object searchParaObj, ref object objCampaignMngStWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CampaignGoodsDataWork campaignGoodsDataWork = (CampaignGoodsDataWork)searchParaObj;
            ArrayList campaignMngStWorkList = objCampaignMngStWorkList as ArrayList;

            SqlConnection sqlConnection = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // ����
                status = SearchProc(campaignGoodsDataWork, ref campaignMngStWorkList, ref sqlConnection);
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "CampaignGoodsStDB.Search", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignGoodsStDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            objCampaignMngStWorkList = campaignMngStWorkList;

            return status;
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^�����擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="campaignMngStWorkList">��������</param>
        /// <param name="campaignGoodsDataWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^�̃L�[�l����v����A�S�ẴL�����y�[���Ǘ��}�X�^�����擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>Update Note: 2011/07/28 Redmine#23278 ���[�U�[��ł͔������Ȃ��������̊�Ƃ����ڂ���c�ƃf���@�ȂǂŔ�������̑Ή�</br>
        /// </remarks>
        private int SearchProc(CampaignGoodsDataWork campaignGoodsDataWork, ref ArrayList campaignMngStWorkList, ref SqlConnection sqlConnection)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                # region [SELECT��]
                sqlText += "SELECT CAMPAIGNMNGRF.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.GOODSNORF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.PRICEFLRF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.RATEVALRF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.CAMPAIGNSETTINGKINDRF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.SALESPRICESETDIVRF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.DISCOUNTRATERF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.PRICESTARTDATERF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.PRICEENDDATERF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNMNGRF.SALESPRICESETDIVRF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNSTRF.CAMPAIGNNAMERF AS CAMPAIGNNAMERF" + Environment.NewLine;    // �L�����y�[���R�[�h����
                sqlText += "  ,SECINFOSETRF.SECTIONGUIDESNMRF AS SECTIONNAMERF" + Environment.NewLine;  // ���_����
                sqlText += "  ,MAKERURF.MAKERNAMERF AS GOODSMAKERNMRF" + Environment.NewLine;           // ���[�J�[����
                sqlText += "  ,GOODSURF.GOODSNAMERF AS GOODSNAMERF" + Environment.NewLine;              // �i��
                sqlText += "  ,CUSTOMERRF.CUSTOMERSNMRF AS CUSTOMERNAMERF" + Environment.NewLine;       // ���Ӑ旪��
                sqlText += "  ,CAMPAIGNMNGRF.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM";
                sqlText += "  CAMPAIGNMNGRF" + Environment.NewLine;
                sqlText += "LEFT JOIN" + Environment.NewLine;
                sqlText += "  CAMPAIGNSTRF" + Environment.NewLine;  // �L�����y�[���ݒ�}�X�^
                sqlText += "ON" + Environment.NewLine;
                sqlText += "  CAMPAIGNMNGRF.ENTERPRISECODERF=CAMPAIGNSTRF.ENTERPRISECODERF" + Environment.NewLine;  // ADD 2011/07/28
                sqlText += "  AND CAMPAIGNMNGRF.CAMPAIGNCODERF = CAMPAIGNSTRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNSTRF.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "LEFT JOIN" + Environment.NewLine;
                sqlText += "  SECINFOSETRF" + Environment.NewLine;  // ���_���ݒ�}�X�^
                sqlText += "ON" + Environment.NewLine;
                sqlText += "  CAMPAIGNMNGRF.ENTERPRISECODERF=SECINFOSETRF.ENTERPRISECODERF" + Environment.NewLine;  // ADD 2011/07/28
                sqlText += "  AND CAMPAIGNMNGRF.SECTIONCODERF = SECINFOSETRF.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  AND SECINFOSETRF.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "LEFT JOIN" + Environment.NewLine;
                sqlText += "  MAKERURF" + Environment.NewLine;      // ���[�J�[�}�X�^
                sqlText += "ON" + Environment.NewLine;
                sqlText += "  CAMPAIGNMNGRF.ENTERPRISECODERF=MAKERURF.ENTERPRISECODERF" + Environment.NewLine;  // ADD 2011/07/28
                sqlText += "  AND CAMPAIGNMNGRF.GOODSMAKERCDRF = MAKERURF.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  AND MAKERURF.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "LEFT JOIN" + Environment.NewLine;
                sqlText += "  GOODSURF" + Environment.NewLine;      // ���i�}�X�^
                sqlText += "ON" + Environment.NewLine;
                sqlText += "  CAMPAIGNMNGRF.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF" + Environment.NewLine;  // ADD 2011/07/28
                sqlText += "  AND CAMPAIGNMNGRF.GOODSNORF = GOODSURF.GOODSNORF" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNMNGRF.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  AND GOODSURF.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "LEFT JOIN" + Environment.NewLine;
                sqlText += "  CUSTOMERRF" + Environment.NewLine;    // ���Ӑ�}�X�^
                sqlText += "ON" + Environment.NewLine;
                sqlText += "  CAMPAIGNMNGRF.ENTERPRISECODERF=CUSTOMERRF.ENTERPRISECODERF" + Environment.NewLine;  // ADD 2011/07/28
                sqlText += "  AND CAMPAIGNMNGRF.CUSTOMERCODERF = CUSTOMERRF.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  AND CUSTOMERRF.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "WHERE " + Environment.NewLine;
                sqlText += "  CAMPAIGNMNGRF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNMNGRF.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNMNGRF.CAMPAIGNSETTINGKINDRF=@FINDCAMPAIGNSETTINGKIND" + Environment.NewLine;
                if (!"00".Equals(campaignGoodsDataWork.SectionCode.Trim()))
                {
                    sqlText += "  AND CAMPAIGNMNGRF.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                }
                if (campaignGoodsDataWork.HeaderGoodsNo.Trim() != "")
                {
                    sqlText += " AND REPLACE(CAMPAIGNMNGRF.GOODSNORF,'-','') LIKE REPLACE(@FINDHEADERGOODSNO,'-','')" + Environment.NewLine;
                }
                # endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaCampaignSettingKind = sqlCommand.Parameters.Add("@FINDCAMPAIGNSETTINGKIND", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDHEADERGOODSNO", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = campaignGoodsDataWork.EnterpriseCode;
                findParaSectionCode.Value = campaignGoodsDataWork.SectionCode;
                findParaGoodsMakerCd.Value = campaignGoodsDataWork.GoodsMakerCd;
                findParaCampaignSettingKind.Value = 1;
                findParaGoodsNo.Value = campaignGoodsDataWork.HeaderGoodsNo + "%";

                sqlCommand.CommandText += sqlText;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToCampaignMngStWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "CampaignGoodsStDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignGoodsStDB.SearchProc" + status);
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

            campaignMngStWorkList = al;

            return status;
        }
        # endregion

        #region �폜����
        /// <summary>
        /// �ꊇ�폜����
        /// </summary>
        /// <param name="deleteParaObj">�폜�����ƌ���</param>
        /// <param name="campaignGoodsListobj">�r����������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ꊇ�폜�������s���B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int DeleteAll(object campaignGoodsListobj, ref object deleteParaObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList deleteParaList = deleteParaObj as ArrayList;

                CampaignGoodsDataWork campaignGoodsDataWork = new CampaignGoodsDataWork();
                if (deleteParaList != null && deleteParaList.Count > 0)
                {
                    campaignGoodsDataWork = (CampaignGoodsDataWork)deleteParaList[0];
                }
                else
                {
                    return status;
                }
                ArrayList campaignGoodsList = campaignGoodsListobj as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);
                // SqlTransaction��������
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // �ꊇ�폜����
                status = DeleteAllProc(ref campaignGoodsDataWork, campaignGoodsList, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "CampaignGoodsStDB.DeleteAll", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignGoodsStDB.DeleteAll", status);
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
        /// �ꊇ�폜����
        /// </summary>
        /// <param name="campaignGoodsDataWork">�폜�����ƌ���</param>
        /// <param name="campaignGoodsList">�r����������</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ꊇ�폜�������s���B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int DeleteAllProc(ref CampaignGoodsDataWork campaignGoodsDataWork, ArrayList campaignGoodsList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int deleteCount = 0;
            SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            string str = "";
            int i = 0;
            int endvalue = campaignGoodsList.Count;
         
            try
            {
                foreach (CampaignMngStWork campaignMngStWorks in campaignGoodsList)
                {
                    i++;
                    if (i == endvalue)
                    {
                        str = str + campaignMngStWorks.CampaignCode.ToString("000000");
                    }
                    else
                    {
                        str = str + campaignMngStWorks.CampaignCode.ToString("000000") + ",";
                    }
                    
                    // �L�����y�[���Ǘ��}�X�^�̍폜����
                    status = this.DeleteCampaignMng(ref campaignGoodsDataWork, campaignMngStWorks, ref deleteCount, ref sqlCommand, ref sqlConnection, ref sqlTransaction);
                    if (status != 0)
                    {
                        return status;
                    }
                }

                // �L�����y�[���ݒ�}�X�^�̐���
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.DeleteCampaignSt(ref campaignGoodsDataWork, ref sqlConnection, ref sqlTransaction, str);
                }
                // �L�����y�[���֘A�}�X�^�̐���
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.DeleteCampaignLink(ref campaignGoodsDataWork, ref sqlConnection, ref sqlTransaction, str);
                }
                // �L�����y�[���ڕW�}�X�^�̐���
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.DeleteCampaignTarget(ref campaignGoodsDataWork, ref sqlConnection, ref sqlTransaction, str);
                }

            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "CampaignGoodsStDB.DeleteAllProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignGoodsStDB.DeleteAllProc" + status);
            }
            finally
            {

            }

            return status;
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^�̍폜����
        /// </summary>
        /// <param name="campaignGoodsDataWork">�폜����</param>
        /// <param name="campaignMngStWork">�r������</param>
        /// <param name="deleteCount">�폜����</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int DeleteCampaignMng(ref CampaignGoodsDataWork campaignGoodsDataWork, CampaignMngStWork campaignMngStWork, ref int deleteCount, ref SqlCommand sqlCommand, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            
          
            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText = string.Empty;
                sqlText += "SELECT  UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CAMPAIGNMNGRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNCODERF=@FINDCAMPAIGNCODE" + Environment.NewLine;
                sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNSETTINGKINDRF=@FINDCAMPAIGNSETTINGKIND" + Environment.NewLine;
                sqlText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                sqlText += "  AND PRICESTARTDATERF=@FINDPRICESTARTDATE" + Environment.NewLine;
                sqlText += "  AND PRICEENDDATERF=@FINDPRICEENDDATE" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                # endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
                SqlParameter findParaCampaignSettingKind = sqlCommand.Parameters.Add("@FINDCAMPAIGNSETTINGKIND", SqlDbType.Int);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);
                SqlParameter findParaPriceEndDate = sqlCommand.Parameters.Add("@FINDPRICEENDDATE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = campaignGoodsDataWork.EnterpriseCode;
                findParaSectionCode.Value = campaignMngStWork.SectionCode;
                findParaGoodsMakerCd.Value = campaignMngStWork.GoodsMakerCd;
                findParaCampaignSettingKind.Value = campaignMngStWork.CampaignSettingKind;
                findParaGoodsNo.Value = campaignMngStWork.GoodsNo;
                findParaCampaignCode.Value = campaignMngStWork.CampaignCode;
                findParaCampaignSettingKind.Value = campaignMngStWork.CampaignSettingKind;
                findParaCustomerCode.Value = campaignMngStWork.CustomerCode;
                findParaPriceStartDate.Value = campaignMngStWork.PriceStartDate;
                findParaPriceEndDate.Value = campaignMngStWork.PriceEndDate;

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {

                    // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                    if (_updateDateTime != campaignMngStWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        return status;
                    }

                    # region [DELETE��]
                    sqlText = string.Empty;
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  CAMPAIGNMNGRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND CAMPAIGNCODERF=@FINDCAMPAIGNCODE" + Environment.NewLine;
                    sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    sqlText += "  AND CAMPAIGNSETTINGKINDRF=@FINDCAMPAIGNSETTINGKIND" + Environment.NewLine;
                    sqlText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                    sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "  AND PRICESTARTDATERF=@FINDPRICESTARTDATE" + Environment.NewLine;
                    sqlText += "  AND PRICEENDDATERF=@FINDPRICEENDDATE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    # endregion


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
                deleteCount++;
                

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "CampaignGoodsStDB.DeleteCampaignMng", sqlex.Number);
                deleteCount = 0;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignGoodsStDB.DeleteCampaignMng" + status);
                deleteCount = 0;
            }
            finally
            {
                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                campaignGoodsDataWork.GoodsStCount = deleteCount;
            }

            return status;
        }

        /// <summary>
        /// �L�����y�[���ݒ�}�X�^�̐���
        /// </summary>
        /// <param name="campaignGoodsDataWork">�폜����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="str">CAMPAIGNCODE�͈�</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ݒ�}�X�^���𐮗����܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int DeleteCampaignSt(ref CampaignGoodsDataWork campaignGoodsDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, string str)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [DELETE��]
                sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CAMPAIGNSTRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CAMPAIGNSTRF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNSTRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  NOT IN (" + Environment.NewLine;
                sqlText += "    SELECT CAMPAIGNMNGRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "    FROM CAMPAIGNMNGRF" + Environment.NewLine;
                sqlText += "    WHERE" + Environment.NewLine;
                sqlText += "       CAMPAIGNMNGRF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  )" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNSTRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  IN (" + Environment.NewLine;
                sqlText += str + Environment.NewLine;
                sqlText += "  )" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = campaignGoodsDataWork.EnterpriseCode;

                int deleteCount = sqlCommand.ExecuteNonQuery();
                campaignGoodsDataWork.NameStCount = deleteCount;

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "CampaignGoodsStDB.DeleteCampaignSt", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignGoodsStDB.DeleteCampaignSt" + status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �L�����y�[���֘A�}�X�^�̐���
        /// </summary>
        /// <param name="campaignGoodsDataWork">�폜����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="str">CAMPAIGNCODE�͈�</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���֘A�}�X�^���𐮗����܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int DeleteCampaignLink(ref CampaignGoodsDataWork campaignGoodsDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, string str)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [DELETE��]
                sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CAMPAIGNLINKRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CAMPAIGNLINKRF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNLINKRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  NOT IN (" + Environment.NewLine;
                sqlText += "    SELECT CAMPAIGNMNGRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "    FROM CAMPAIGNMNGRF" + Environment.NewLine;
                sqlText += "    WHERE" + Environment.NewLine;
                sqlText += "       CAMPAIGNMNGRF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  )" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNLINKRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  IN (" + Environment.NewLine;
                sqlText += str + Environment.NewLine;
                sqlText += "  )" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = campaignGoodsDataWork.EnterpriseCode;

                int deleteCount = sqlCommand.ExecuteNonQuery();
                campaignGoodsDataWork.CustomStCount = deleteCount;

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "CampaignGoodsStDB.DeleteCampaignLink", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignGoodsStDB.DeleteCampaignLink" + status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �L�����y�[���ڕW�}�X�^�̐���
        /// </summary>
        /// <param name="campaignGoodsDataWork">�폜����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="str">CAMPAIGNCODE�͈�</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�}�X�^�𐮗����܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int DeleteCampaignTarget(ref CampaignGoodsDataWork campaignGoodsDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, string str)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [DELETE��]
                sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CAMPAIGNTARGETRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CAMPAIGNTARGETRF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNTARGETRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  NOT IN (" + Environment.NewLine;
                sqlText += "    SELECT CAMPAIGNMNGRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "    FROM CAMPAIGNMNGRF" + Environment.NewLine;
                sqlText += "    WHERE" + Environment.NewLine;
                sqlText += "       CAMPAIGNMNGRF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  )" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNTARGETRF.CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  IN (" + Environment.NewLine;
                sqlText += str + Environment.NewLine;
                sqlText += "  )" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = campaignGoodsDataWork.EnterpriseCode;

                int deleteCount = sqlCommand.ExecuteNonQuery();
                campaignGoodsDataWork.TargetStCount = deleteCount;

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "CampaignGoodsStDB.DeleteCampaignTarget", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignGoodsStDB.DeleteCampaignTarget" + status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CampaignMngStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CampaignMngStWork</returns>
        /// <remarks>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private CampaignMngStWork CopyToCampaignMngStWorkFromReader(ref SqlDataReader myReader)
        {
            CampaignMngStWork campaignMngStWork = new CampaignMngStWork();

            if (myReader != null && campaignMngStWork != null)
            {
                # region �N���X�֊i�[
                campaignMngStWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));
                campaignMngStWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF"));
                campaignMngStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                campaignMngStWork.SectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONNAMERF"));
                campaignMngStWork.CampaignSettingKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNSETTINGKINDRF"));
                campaignMngStWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                campaignMngStWork.GoodsMakerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMAKERNMRF"));
                campaignMngStWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                campaignMngStWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                campaignMngStWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                campaignMngStWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                campaignMngStWork.DiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISCOUNTRATERF"));
                campaignMngStWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));
                campaignMngStWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));
                campaignMngStWork.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                campaignMngStWork.PriceEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEENDDATERF"));
                campaignMngStWork.SalesPriceSetDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESPRICESETDIVRF"));
                campaignMngStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));

                # endregion
            }
            return campaignMngStWork;
        }
        # endregion

        # region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/04/26</br>
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
        #endregion
    }
}
