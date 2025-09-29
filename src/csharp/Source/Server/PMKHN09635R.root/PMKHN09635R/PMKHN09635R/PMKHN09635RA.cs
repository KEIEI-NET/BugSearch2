//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^
// �v���O�����T�v   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2011/05/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/13  �C�����e : Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��
//----------------------------------------------------------------------------//
using System.Data.SqlClient;
using System.Collections;
using System;
using System.Data;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    ///�L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���N�n��</br>
    /// <br>Date       : 2011/05/20</br>
    /// <br>UpdateNote : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
    /// </remarks>
    [Serializable]
    public class CampaignLoginDB : RemoteDB, ICampaignLoginDB
    {
        # region ��������
        /// <summary>
        /// ���i�}�X�^(���[�U�[)��������
        /// </summary>
        /// <param name="campaignGoodsDataWorkList">��������</param>
        /// <param name="campaignGoodsDataWork">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public int Search(ref object campaignGoodsDataWorkList, object campaignGoodsDataWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CampaignGoodsDataWork campaignGoodsDataWorks = campaignGoodsDataWork as CampaignGoodsDataWork;

            ArrayList campaignGoodsDataWorkLists = campaignGoodsDataWorkList as ArrayList;
            SqlConnection sqlConnection = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // ����
                status = SearchProc(ref campaignGoodsDataWorkLists, campaignGoodsDataWorks, ref sqlConnection);
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "CampaignLoginDB.Search", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignLoginDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            campaignGoodsDataWorkList = campaignGoodsDataWorkLists as Object;

            return status;
        }

        /// <summary>
        /// ���i�}�X�^(���[�U�[)��������
        /// </summary>
        /// <param name="campaignGoodsDataWorkList">��������</param>
        /// <param name="campaignGoodsDataWork">��������</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// <br>UpdateNote : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
        /// </remarks>
        private int SearchProc(ref ArrayList campaignGoodsDataWorkList, CampaignGoodsDataWork campaignGoodsDataWork, ref SqlConnection sqlConnection)
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
                sqlText += "SELECT DISTINCT GOODSNORF," + Environment.NewLine;
                sqlText += "GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "FROM GOODSURF" + Environment.NewLine;
                sqlText += "WHERE ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sqlText += "AND LOGICALDELETECODERF =@LOGICALDELETECODE" + Environment.NewLine;
                sqlText += "AND GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                if (campaignGoodsDataWork.GoodsNoNoneHyphen != "")
                {
                    sqlText += " AND REPLACE(GOODSNONONEHYPHENRF,'-','') LIKE REPLACE(@GOODSNO,'-','')" + Environment.NewLine;
                }
                // --- UPD 2011/07/13 --- >>>>>>>>
                if (campaignGoodsDataWork.BLGroupCodeSt != 0)
                {
                    sqlText += "AND BLGOODSCODERF=@BLGROUPCODEST" + Environment.NewLine;
                }
                //if (campaignGoodsDataWork.BLGroupCodeSt != 0)
                //{
                //    sqlText += "AND BLGOODSCODERF>=@BLGROUPCODEST" + Environment.NewLine;
                //}
                //if (campaignGoodsDataWork.BLGroupCodeEd != 0)
                //{
                //    sqlText += "AND BLGOODSCODERF<=@BLGROUPCODEED" + Environment.NewLine;
                //}
                // --- UPD 2011/07/13 --- <<<<<<<<<<
                # endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraBLGroupCodeSt = sqlCommand.Parameters.Add("@BLGROUPCODEST", SqlDbType.Int);
                //SqlParameter paraBLGroupCodeEd = sqlCommand.Parameters.Add("@BLGROUPCODEED", SqlDbType.Int);  // DEL 2011/07/13


                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.EnterpriseCode);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.GoodsMakerCd);
                if (!string.Empty.Equals(campaignGoodsDataWork.GoodsNoNoneHyphen.Trim()))
                {
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.GoodsNoNoneHyphen.Trim())+"%";
                }
                else
                {
                    paraGoodsNo.Value = campaignGoodsDataWork.GoodsNoNoneHyphen.Trim();
                }
                paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.BLGroupCodeSt);
                //paraBLGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.BLGroupCodeEd); // DEL 2011/07/13

                sqlCommand.CommandText += sqlText;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToGoodsUWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "CampaignLoginDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignLoginDB.SearchProc" + status);
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
            campaignGoodsDataWorkList = al;


            return status;
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^��������
        /// </summary>
        /// <param name="campaignMngList">��������</param>
        /// <param name="campaignGoodsDataWork">��������</param>
        /// <param name="readMode">�����L�����y�[���Ǘ��}�X�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public int Search(ref object campaignMngList, object campaignGoodsDataWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CampaignGoodsDataWork campaignGoodsDataWorks = campaignGoodsDataWork as CampaignGoodsDataWork;

            ArrayList campaignMngLists = campaignMngList as ArrayList;
            SqlConnection sqlConnection = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // ����
                status = SearchProc(ref campaignMngLists, campaignGoodsDataWorks, readMode, ref sqlConnection);
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "CampaignLoginDB.Search", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignLoginDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            campaignMngList = campaignMngLists;

            return status;
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^��������
        /// </summary>
        /// <param name="campaignMngLists">��������</param>
        /// <param name="campaignGoodsDataWorks">��������</param>
        /// <param name="readMode">�����L�����y�[���Ǘ��}�X�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private int SearchProc(ref ArrayList campaignMngLists, CampaignGoodsDataWork campaignGoodsDataWorks, int readMode, ref SqlConnection sqlConnection)
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
                sqlText += "SELECT  GOODSNORF," + Environment.NewLine;
                sqlText += "  LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " FROM CAMPAIGNMNGRF" + Environment.NewLine;
                sqlText += "WHERE ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sqlText += "AND GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                sqlText += "AND CAMPAIGNSETTINGKINDRF=@CAMPAIGNSETTINGKIND" + Environment.NewLine;
                sqlText += "AND CAMPAIGNCODERF=@CAMPAIGNCODE" + Environment.NewLine;

                # endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);
                SqlParameter paraCampaingnSettingKind = sqlCommand.Parameters.Add("@CAMPAIGNSETTINGKIND", SqlDbType.Int);
          
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWorks.EnterpriseCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWorks.GoodsMakerCd);
                paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWorks.CampaignCode);
                paraCampaingnSettingKind.Value = SqlDataMediator.SqlSetInt32(1);

                sqlCommand.CommandText += sqlText;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToCampaignObjGoodsStWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "CampaignLoginDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignLoginDB.SearchProc" + status);
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
            campaignMngLists = al;


            return status;
        }

        /// <summary>
        /// �L�����y�[�����̐ݒ�}�X�^��������
        /// </summary>
        /// <param name="campaignStList">��������</param>
        /// <param name="campaignStWork">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�����̐ݒ�}�X�^�����������s���B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public int SearchCampaignSt(ref object campaignStList, object campaignStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            CampaignStWork campaignStWorks = campaignStWork as CampaignStWork;

            ArrayList campaignStLists = campaignStList as ArrayList;

            SqlConnection sqlConnection = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // ����
                status = SearchCampaignStProc(ref campaignStLists, campaignStWorks, ref sqlConnection);
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "CampaignLoginDB.Search", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignLoginDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            campaignStList = campaignStLists;

            return status;
        }

        /// <summary>
        /// �L�����y�[�����̐ݒ�}�X�^��������
        /// </summary>
        /// <param name="campaignStList">��������</param>
        /// <param name="campaignStWork">��������</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[�����̐ݒ�}�X�^�����������s���B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private int SearchCampaignStProc(ref ArrayList campaignStList, CampaignStWork campaignStWork, ref SqlConnection sqlConnection)
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
                sqlText += "SELECT CAMPAIGNNAMERF," + Environment.NewLine;
                sqlText += "CAMPEXECSECCODERF," + Environment.NewLine;
                sqlText += "CAMPAIGNOBJDIVRF," + Environment.NewLine;
                sqlText += "APPLYSTADATERF," + Environment.NewLine;
                sqlText += "APPLYENDDATERF" + Environment.NewLine;
                sqlText += "FROM CAMPAIGNSTRF" + Environment.NewLine;
                sqlText += "WHERE ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sqlText += "AND CAMPAIGNCODERF =@CAMPAIGNCODE" + Environment.NewLine;

                # endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignStWork.EnterpriseCode);
                paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignStWork.CampaignCode);

                sqlCommand.CommandText += sqlText;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToCampaignStWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "CampaignLoginDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignLoginDB.SearchProc" + status);
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


            campaignStList = al;
            return status;
        }

        /// <summary>
        /// �L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^��������
        /// </summary>
        /// <param name="searchParaObj">��������</param>
        /// <param name="objcampaignLinkList">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^�����������s���B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public int SearchCustomer(object searchParaObj, ref object objcampaignLinkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            CampaignLinkWork campaignLinkWork = searchParaObj as CampaignLinkWork;

            ArrayList campaignLinkList = objcampaignLinkList as ArrayList;

            SqlConnection sqlConnection = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // ����
                status = SearchCustomerProc(ref campaignLinkList, campaignLinkWork, ref sqlConnection);
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "CampaignLoginDB.Search", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignLoginDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            objcampaignLinkList = campaignLinkList;

            return status;
        }

        /// <summary>
        /// �L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^��������
        /// </summary>
        /// <param name="campaignLinkList">��������</param>
        /// <param name="campaignLinkWork">��������</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^�����������s���B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private int SearchCustomerProc(ref ArrayList campaignLinkList, CampaignLinkWork campaignLinkWork, ref SqlConnection sqlConnection)
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
                sqlText += "SELECT CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "FROM CAMPAIGNLINKRF" + Environment.NewLine;
                sqlText += "WHERE  CAMPAIGNCODERF=@CAMPAIGNCODE" + Environment.NewLine;
                sqlText += "AND LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                sqlText += "AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                
                # endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);
  
             
                sqlCommand.CommandText += sqlText;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToCampaignLinkWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "CampaignLoginDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignLoginDB.SearchProc" + status);
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

            campaignLinkList = al;
            return status;
        }

        # endregion

        # region �o�^����
        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^�A�L�����y�[���֘A�}�X�^�A�L�����y�[���ݒ�}�X�^�̓o�^����
        /// </summary>
        /// <param name="campaignGoodsDataWorkList">�o�^�i�����X�g</param>
        /// <param name="campaignGoodsDataWork">����</param>
        /// <param name="campaignLinkobjlist">���Ӑ惊�X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �o�^�������s���B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public int Write(object campaignGoodsDataWorkList, object campaignGoodsDataWork, object campaignLinkobjlist)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            CampaignGoodsDataWork campaignGoodsDataWorks = campaignGoodsDataWork  as CampaignGoodsDataWork;
            ArrayList campaignGoodsDataWorkLists = campaignGoodsDataWorkList as ArrayList;
            ArrayList campaignLinkobjlists=campaignLinkobjlist as ArrayList;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = WriteProc(ref campaignGoodsDataWorkLists, campaignGoodsDataWorks, ref sqlConnection, ref sqlTransaction);

                //�L�����y�[���ݒ�}�X�^�̓o�^����
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = WriteCampaignSt(campaignGoodsDataWorks, ref sqlConnection, ref sqlTransaction);
                }

                //�L�����y�[���֘A�}�X�^�̓o�^����
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && campaignLinkobjlists.Count > 0)
                {
                    status = WriteCampaignLink(campaignLinkobjlists, campaignGoodsDataWorks,ref sqlConnection, ref sqlTransaction);
                }

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
        /// �L�����y�[���֘A�}�X�^�̓o�^����
        /// </summary>
        /// <param name="campaignLinkobjlist">���Ӑ惊�X�g</param>
        /// <param name="campaignGoodsDataWork">����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �o�^�������s���B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private int WriteCampaignLink(ArrayList campaignLinkobjlist, CampaignGoodsDataWork campaignGoodsDataWork,ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList campaignLinkLog = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);


                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter ParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter ParaCampaingnCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraLogicalDeleteCode1 = sqlCommand.Parameters.Add("@LOGICALDELETECODE1", SqlDbType.Int);
                SqlParameter paraLogicalDeleteCode2 = sqlCommand.Parameters.Add("@LOGICALDELETECODE2", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                ParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.EnterpriseCode);
                ParaCampaingnCode.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.CampaignCode);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                paraLogicalDeleteCode1.Value = SqlDataMediator.SqlSetInt32(1);
                paraLogicalDeleteCode2.Value = SqlDataMediator.SqlSetInt32(0);



                # region [SELECT��]

                string sqlText_SELECT = string.Empty;
                sqlText_SELECT += "SELECT  CUSTOMERCODERF" + Environment.NewLine;
                sqlText_SELECT += "FROM CAMPAIGNLINKRF" + Environment.NewLine;
                sqlText_SELECT += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText_SELECT += "AND CAMPAIGNCODERF=@FINDCAMPAIGNCODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText_SELECT;
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    campaignLinkLog.Add(this.CopyToCampaignLinkWorkFromReader(ref myReader));
                }

    
                if (!myReader.IsClosed) myReader.Close();

                # region [DELETE��]
                string sqlText_DELETELOG = string.Empty;
                sqlText_DELETELOG += "DELETE " + Environment.NewLine;
                sqlText_DELETELOG += "FROM CAMPAIGNLINKRF" + Environment.NewLine;
                sqlText_DELETELOG += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText_DELETELOG += "AND CAMPAIGNCODERF=@FINDCAMPAIGNCODE" + Environment.NewLine;

                sqlCommand.CommandText = sqlText_DELETELOG;

                # endregion

                sqlCommand.ExecuteNonQuery();

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                SqlParameter paraCustomerAgentCd = sqlCommand.Parameters.Add("@CUSTOMERAGENTCD", SqlDbType.NChar);
                SqlParameter paraInfoSendCode = sqlCommand.Parameters.Add("@INFOSENDCODE", SqlDbType.Int);

                foreach (CampaignLinkWork campaignLinkWork in campaignLinkobjlist)
                {
                    if (campaignLinkWork.LogicalDeleteCode == 1)
                    {
                        continue;
                    }

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);
                    paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(0);
                    paraCustomerAgentCd.Value = "         ";
                    paraInfoSendCode.Value = SqlDataMediator.SqlSetInt32(0);
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignLinkWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignLinkWork.UpdateDateTime);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(campaignLinkWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdAssemblyId2);

                    # region [INSERT��]
                    string sqlText_INSERT = string.Empty;
                    sqlText_INSERT += "INSERT INTO CAMPAIGNLINKRF" + Environment.NewLine;
                    sqlText_INSERT += "  (CREATEDATETIMERF," + Environment.NewLine;
                    sqlText_INSERT += "   UPDATEDATETIMERF," + Environment.NewLine;
                    sqlText_INSERT += "   ENTERPRISECODERF, " + Environment.NewLine;
                    sqlText_INSERT += "   FILEHEADERGUIDRF, " + Environment.NewLine;
                    sqlText_INSERT += "   UPDEMPLOYEECODERF," + Environment.NewLine;
                    sqlText_INSERT += "   UPDASSEMBLYID1RF, " + Environment.NewLine;
                    sqlText_INSERT += "   UPDASSEMBLYID2RF, " + Environment.NewLine;
                    sqlText_INSERT += "   LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText_INSERT += "   CAMPAIGNCODERF," + Environment.NewLine;
                    sqlText_INSERT += "   CUSTOMERCODERF," + Environment.NewLine;
                    sqlText_INSERT += "   SALESAREACODERF," + Environment.NewLine;
                    sqlText_INSERT += "   CUSTOMERAGENTCDRF," + Environment.NewLine;
                    sqlText_INSERT += "   INFOSENDCODERF)" + Environment.NewLine;
                    sqlText_INSERT += "   VALUES (@CREATEDATETIME," + Environment.NewLine;
                    sqlText_INSERT += "   @UPDATEDATETIME," + Environment.NewLine;
                    sqlText_INSERT += "   @FINDENTERPRISECODE," + Environment.NewLine;
                    sqlText_INSERT += "   @FILEHEADERGUID," + Environment.NewLine;
                    sqlText_INSERT += "   @UPDEMPLOYEECODE, " + Environment.NewLine;
                    sqlText_INSERT += "   @UPDASSEMBLYID1, " + Environment.NewLine;
                    sqlText_INSERT += "   @UPDASSEMBLYID2, " + Environment.NewLine;
                    if(campaignLinkWork.LogicalDeleteCode == 1)
                    {
                        sqlText_INSERT += " @LOGICALDELETECODE1," + Environment.NewLine;
                    }
                    else
                    {
                        sqlText_INSERT += " @LOGICALDELETECODE2," + Environment.NewLine;
                    }
                    
                    sqlText_INSERT += "   @FINDCAMPAIGNCODE," + Environment.NewLine;
                    sqlText_INSERT += "   @CUSTOMERCODE," + Environment.NewLine;
                    sqlText_INSERT += "   @SALESAREACODE, " + Environment.NewLine;
                    sqlText_INSERT += "   @CUSTOMERAGENTCD," + Environment.NewLine;
                    sqlText_INSERT += "   @INFOSENDCODE) " + Environment.NewLine;
                    # endregion

                    sqlCommand.CommandText = sqlText_INSERT;

                     //�o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)campaignLinkWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignLinkWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignLinkWork.UpdateDateTime);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(campaignLinkWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdAssemblyId2);

                    sqlCommand.ExecuteNonQuery();
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
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �L�����y�[���ݒ�}�X�^�̓o�^����
        /// </summary>
        /// <param name="campaignGoodsDataWork">����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �o�^�������s���B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private int WriteCampaignSt(CampaignGoodsDataWork campaignGoodsDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try{
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
            
                    # region [SELECT��]

                    string sqlText_SELECT = string.Empty;
                    sqlText_SELECT += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText_SELECT += "FROM CAMPAIGNSTRF" + Environment.NewLine;
                    sqlText_SELECT += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText_SELECT += "AND CAMPAIGNCODERF=@FINDCAMPAIGNCODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText_SELECT;
                    # endregion

                    SqlParameter ParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter ParaCampaingnCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);

                    ParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.EnterpriseCode);
                    ParaCampaingnCode.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.CampaignCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        # region [UPDATE��]
                        string sqlText_UPDATE = string.Empty;
                        sqlText_UPDATE += "UPDATE CAMPAIGNSTRF" + Environment.NewLine;
                        sqlText_UPDATE += "SET LOGICALDELETECODERF ='" + 0 + "'," + Environment.NewLine;
                        sqlText_UPDATE += "CAMPEXECSECCODERF=@CAMPEXECSECCODE," + Environment.NewLine;
                        sqlText_UPDATE += "CAMPAIGNCODERF=@FINDCAMPAIGNCODE," + Environment.NewLine;
                        sqlText_UPDATE += "CAMPAIGNNAMERF=@CAMPAIGNNAMERF," + Environment.NewLine;
                        sqlText_UPDATE += "CAMPAIGNOBJDIVRF=@CAMPAIGNOBJDIVRF," + Environment.NewLine;
                        sqlText_UPDATE += "APPLYSTADATERF=@APPLYSTADATERF," + Environment.NewLine;
                        sqlText_UPDATE += "APPLYENDDATERF=@APPLYENDDATERF" + Environment.NewLine;
                        sqlText_UPDATE += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText_UPDATE += "AND CAMPAIGNCODERF=@FINDCAMPAIGNCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText_UPDATE;
                        # endregion

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)campaignGoodsDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    { 
                        # region [INSERT��]
                        string sqlText_INSERT = string.Empty;
                        sqlText_INSERT += "INSERT  INTO CAMPAIGNSTRF" + Environment.NewLine;
                        sqlText_INSERT += "  (CREATEDATETIMERF," + Environment.NewLine;
                        sqlText_INSERT += "   UPDATEDATETIMERF," + Environment.NewLine;
                        sqlText_INSERT += "   ENTERPRISECODERF, " + Environment.NewLine;
                        sqlText_INSERT += "   FILEHEADERGUIDRF, " + Environment.NewLine;
                        sqlText_INSERT += "   UPDEMPLOYEECODERF," + Environment.NewLine;
                        sqlText_INSERT += "   UPDASSEMBLYID1RF, " + Environment.NewLine;
                        sqlText_INSERT += "   UPDASSEMBLYID2RF, " + Environment.NewLine;
                        sqlText_INSERT += "   LOGICALDELETECODERF," + Environment.NewLine;
                        sqlText_INSERT += "   CAMPEXECSECCODERF," + Environment.NewLine;
                        sqlText_INSERT += "   CAMPAIGNCODERF," + Environment.NewLine;
                        sqlText_INSERT += "   CAMPAIGNNAMERF," + Environment.NewLine;
                        sqlText_INSERT += "   CAMPAIGNOBJDIVRF," + Environment.NewLine;
                        sqlText_INSERT += "   APPLYSTADATERF," + Environment.NewLine;
                        sqlText_INSERT += "   APPLYENDDATERF," + Environment.NewLine;
                        sqlText_INSERT += "   SALESTARGETMONEYRF, " + Environment.NewLine;
                        sqlText_INSERT += "   SALESTARGETPROFITRF, " + Environment.NewLine;
                        sqlText_INSERT += "   SALESTARGETCOUNTRF)" + Environment.NewLine;
                        sqlText_INSERT += "   VALUES (@CREATEDATETIME," + Environment.NewLine;
                        sqlText_INSERT += "   @UPDATEDATETIME," + Environment.NewLine;
                        sqlText_INSERT += "   @FINDENTERPRISECODE," + Environment.NewLine;
                        sqlText_INSERT += "   @FILEHEADERGUID," + Environment.NewLine;
                        sqlText_INSERT += "   @UPDEMPLOYEECODE, " + Environment.NewLine;
                        sqlText_INSERT += "   @UPDASSEMBLYID1, " + Environment.NewLine;
                        sqlText_INSERT += "   @UPDASSEMBLYID2, " + Environment.NewLine;
                        sqlText_INSERT += "   @LOGICALDELETECODE," + Environment.NewLine;
                        sqlText_INSERT += "   @CAMPEXECSECCODE," + Environment.NewLine;
                        sqlText_INSERT += "   @FINDCAMPAIGNCODE," + Environment.NewLine;
                        sqlText_INSERT += "   @CAMPAIGNNAMERF," + Environment.NewLine;
                        sqlText_INSERT += "   @CAMPAIGNOBJDIVRF," + Environment.NewLine;
                        sqlText_INSERT += "   @APPLYSTADATERF," + Environment.NewLine;
                        sqlText_INSERT += "   @APPLYENDDATERF," + Environment.NewLine;
                        sqlText_INSERT += "   @SALESTARGETMONEY, " + Environment.NewLine;
                        sqlText_INSERT += "   @SALESTARGETPROFIT," + Environment.NewLine;
                        sqlText_INSERT += "   @SALESTARGETCOUNT)" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText_INSERT;
                        
                        # endregion
                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)campaignGoodsDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter ParaCampexEcsecCode = sqlCommand.Parameters.Add("@CAMPEXECSECCODE", SqlDbType.NChar);
                    SqlParameter ParaCampaingnName = sqlCommand.Parameters.Add("@CAMPAIGNNAMERF", SqlDbType.NChar);
                    SqlParameter ParaCampaingnObjDiv = sqlCommand.Parameters.Add("@CAMPAIGNOBJDIVRF", SqlDbType.Int);
                    SqlParameter ParaApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATERF", SqlDbType.NChar);
                    SqlParameter ParaApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATERF", SqlDbType.Int);
                    SqlParameter paraSalesTargetMoney = sqlCommand.Parameters.Add("@SALESTARGETMONEY", SqlDbType.BigInt);
                    SqlParameter paraSalesTargetProfit = sqlCommand.Parameters.Add("@SALESTARGETPROFIT", SqlDbType.BigInt);
                    SqlParameter paraSalesTargetCount = sqlCommand.Parameters.Add("@SALESTARGETCOUNT", SqlDbType.Float);
                
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignGoodsDataWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignGoodsDataWork.UpdateDateTime);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(campaignGoodsDataWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.LogicalDeleteCode);
                    ParaCampexEcsecCode.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.SectionCode);
                    ParaCampaingnName.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.CampaignName);
                    ParaCampaingnObjDiv.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.CampaignObjDiv);
                    ParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.ApplyStaDate);
                    ParaApplyEndDate.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.ApplyEndDate);
                    paraSalesTargetMoney.Value = SqlDataMediator.SqlSetInt64(0);
                    paraSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(0);
                    paraSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(0);
    
                    if (!myReader.IsClosed) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                  
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
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader.IsClosed == false) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^�̓o�^����
        /// </summary>
        /// <param name="campaignGoodsDataWorkList">�o�^�i�����X�g</param>
        /// <param name="campaignGoodsDataWork">����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �o�^�������s���B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private int WriteProc(ref ArrayList campaignGoodsDataWorkList, CampaignGoodsDataWork campaignGoodsDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            try
            {

                foreach (GoodsUWork coodsUWork in campaignGoodsDataWorkList)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                    if (coodsUWork.LogicalDeleteCode == 1)
                    {
                        # region [UPDATE��]
                        string sqlText_UPDATE = string.Empty;
                        sqlText_UPDATE += "UPDATE CAMPAIGNMNGRF" + Environment.NewLine;
                        sqlText_UPDATE += "    SET LOGICALDELETECODERF=@LOGICALDELETECODE," + Environment.NewLine;
                        sqlText_UPDATE += " SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine;
                        sqlText_UPDATE += " WHERE GOODSMAKERCDRF=@FINDGOODSMAKERCDRF " + Environment.NewLine;
                        sqlText_UPDATE += " AND GOODSNORF=@FINDGOODSNORF " + Environment.NewLine;
                        sqlText_UPDATE += " AND ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine;
                        sqlText_UPDATE += " AND CAMPAIGNCODERF=@FINDCAMPAIGNCODERF " + Environment.NewLine;
                        sqlText_UPDATE += " AND CAMPAIGNSETTINGKINDRF=@FINDCAMPAIGNSETTINGKINDRF " + Environment.NewLine;
                        sqlCommand.CommandText = sqlText_UPDATE;
                        # endregion

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)coodsUWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);


                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter ParaEnterpriseCode1 = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                        SqlParameter ParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);
                        SqlParameter ParaGoodsMarkerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDRF", SqlDbType.Int);
                        SqlParameter ParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNORF", SqlDbType.NVarChar);
                        SqlParameter ParaCampaingnCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODERF", SqlDbType.Int);
                        SqlParameter ParaCampaingnSettingKind = sqlCommand.Parameters.Add("@FINDCAMPAIGNSETTINGKINDRF", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(coodsUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(coodsUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(coodsUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(coodsUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(coodsUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(coodsUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(coodsUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                        ParaEnterpriseCode1.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.EnterpriseCode);
                        ParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.SectionCode);
                        ParaGoodsMarkerCd.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.GoodsMakerCd);
                        if (!string.Empty.Equals(coodsUWork.GoodsNo.Trim()))
                        {
                            ParaGoodsNo.Value = SqlDataMediator.SqlSetString(coodsUWork.GoodsNo);
                        }
                        else
                        {
                            ParaGoodsNo.Value = coodsUWork.GoodsNo;
                        }
                        ParaCampaingnCode.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.CampaignCode);
                        ParaCampaingnSettingKind.Value = SqlDataMediator.SqlSetInt32(1);

                        sqlCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        # region [INSERT��]
                        string sqlText_INSERT= string.Empty;
                        sqlText_INSERT += "  INSERT INTO CAMPAIGNMNGRF " + Environment.NewLine;
                        sqlText_INSERT += "  (CREATEDATETIMERF," + Environment.NewLine;
                        sqlText_INSERT += "   UPDATEDATETIMERF," + Environment.NewLine;
                        sqlText_INSERT += "   ENTERPRISECODERF, " + Environment.NewLine;
                        sqlText_INSERT += "   FILEHEADERGUIDRF, " + Environment.NewLine;
                        sqlText_INSERT += "   UPDEMPLOYEECODERF," + Environment.NewLine;
                        sqlText_INSERT += "   UPDASSEMBLYID1RF, " + Environment.NewLine;
                        sqlText_INSERT += "   UPDASSEMBLYID2RF, " + Environment.NewLine;
                        sqlText_INSERT += "   LOGICALDELETECODERF," + Environment.NewLine;
                        sqlText_INSERT += "   SECTIONCODERF," + Environment.NewLine;
                        sqlText_INSERT += "   GOODSMGROUPRF, " + Environment.NewLine;
                        sqlText_INSERT += "   BLGOODSCODERF, " + Environment.NewLine;
                        sqlText_INSERT += "   GOODSMAKERCDRF," + Environment.NewLine;
                        sqlText_INSERT += "   GOODSNORF," + Environment.NewLine;
                        sqlText_INSERT += "   SALESTARGETMONEYRF, " + Environment.NewLine;
                        sqlText_INSERT += "   SALESTARGETPROFITRF, " + Environment.NewLine;
                        sqlText_INSERT += "   SALESTARGETCOUNTRF," + Environment.NewLine;
                        sqlText_INSERT += "   CAMPAIGNCODERF," + Environment.NewLine;
                        sqlText_INSERT += "   PRICEFLRF," + Environment.NewLine;
                        sqlText_INSERT += "   RATEVALRF," + Environment.NewLine;
                        sqlText_INSERT += "   BLGROUPCODERF," + Environment.NewLine;
                        sqlText_INSERT += "   SALESCODERF, " + Environment.NewLine;
                        sqlText_INSERT += "   CAMPAIGNSETTINGKINDRF, " + Environment.NewLine;
                        sqlText_INSERT += "   SALESPRICESETDIVRF, " + Environment.NewLine;
                        sqlText_INSERT += "   CUSTOMERCODERF," + Environment.NewLine;
                        sqlText_INSERT += "   PRICESTARTDATERF, " + Environment.NewLine;
                        sqlText_INSERT += "   PRICEENDDATERF, " + Environment.NewLine;
                        sqlText_INSERT += "   DISCOUNTRATERF) " + Environment.NewLine;
                        sqlText_INSERT += "   VALUES (@CREATEDATETIME," + Environment.NewLine;
                        sqlText_INSERT += "   @UPDATEDATETIME," + Environment.NewLine;
                        sqlText_INSERT += "   @ENTERPRISECODE," + Environment.NewLine;
                        sqlText_INSERT += "   @FILEHEADERGUID," + Environment.NewLine;
                        sqlText_INSERT += "   @UPDEMPLOYEECODE, " + Environment.NewLine;
                        sqlText_INSERT += "   @UPDASSEMBLYID1, " + Environment.NewLine;
                        sqlText_INSERT += "   @UPDASSEMBLYID2, " + Environment.NewLine;
                        sqlText_INSERT += "   @LOGICALDELETECODE," + Environment.NewLine;
                        sqlText_INSERT += "   @SECTIONCODE," + Environment.NewLine;
                        sqlText_INSERT += "   @GOODSMGROUP, " + Environment.NewLine;
                        sqlText_INSERT += "   @BLGOODSCODE," + Environment.NewLine;
                        sqlText_INSERT += "   @GOODSMAKERCD, " + Environment.NewLine;
                        sqlText_INSERT += "   @GOODSNO, " + Environment.NewLine;
                        sqlText_INSERT += "   @SALESTARGETMONEY, " + Environment.NewLine;
                        sqlText_INSERT += "   @SALESTARGETPROFIT," + Environment.NewLine;
                        sqlText_INSERT += "   @SALESTARGETCOUNT," + Environment.NewLine;
                        sqlText_INSERT += "   @CAMPAIGNCODE," + Environment.NewLine;
                        sqlText_INSERT += "   @PRICEFL," + Environment.NewLine;
                        sqlText_INSERT += "   @RATEVAL," + Environment.NewLine;
                        sqlText_INSERT += "   @BLGROUPCODE," + Environment.NewLine;
                        sqlText_INSERT += "   @SALESCODE," + Environment.NewLine;
                        sqlText_INSERT += "   @CAMPAIGNSETTINGKIND, " + Environment.NewLine;
                        sqlText_INSERT += "   @SALESPRICESETDIV, " + Environment.NewLine;
                        sqlText_INSERT += "   @CUSTOMERCODE," + Environment.NewLine;
                        sqlText_INSERT += "   @PRICESTARTDATE," + Environment.NewLine;
                        sqlText_INSERT += "   @PRICEENDDATE," + Environment.NewLine;
                        sqlText_INSERT += "   @DISCOUNTRATE)" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText_INSERT;
                       
                        # endregion

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)coodsUWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

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
                        SqlParameter paraDisCountRate = sqlCommand.Parameters.Add("@DISCOUNTRATE", SqlDbType.Float);
                        
                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(coodsUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(coodsUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(coodsUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(coodsUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(coodsUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(coodsUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(coodsUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(coodsUWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(campaignGoodsDataWork.SectionCode);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(0);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(0);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(coodsUWork.GoodsMakerCd);
                        if (!string.Empty.Equals(coodsUWork.GoodsNo.Trim()))
                        {
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(coodsUWork.GoodsNo);
                        }
                        else
                        {
                            paraGoodsNo.Value = coodsUWork.GoodsNo;
                        }
                        
                        paraSalesTargetMoney.Value = SqlDataMediator.SqlSetInt64(0);
                        paraSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(0);
                        paraSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(0);
                        paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignGoodsDataWork.CampaignCode);
                        paraPriceFl.Value = SqlDataMediator.SqlSetDouble(0);
                        paraRateVal.Value = SqlDataMediator.SqlSetDouble(0);
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(0);
                        paraSalesCode.Value = SqlDataMediator.SqlSetInt32(0);
                        paraCampaignSettingKind.Value = SqlDataMediator.SqlSetInt32(1);
                        paraSalesPriceSetDiv.Value = SqlDataMediator.SqlSetInt32(0);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(0);
                        paraPriceStartDate.Value = SqlDataMediator.SqlSetInt32(0);
                        paraPriceEndDate.Value = SqlDataMediator.SqlSetInt32(0);
                        paraDisCountRate.Value = SqlDataMediator.SqlSetDouble(0);

                        sqlCommand.ExecuteNonQuery();

                    }
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
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
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
        /// <br>Date       : 2011/05/20</br>
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
        /// <br>Date       : 2011/05/20</br>
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

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>GoodsUWork</returns>
        /// <remarks>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private GoodsUWork CopyToGoodsUWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsUWork coodsUWork = new GoodsUWork();

            if (myReader != null && coodsUWork != null)
            {
                # region �N���X�֊i�[
                coodsUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                coodsUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                # endregion
            }
            return coodsUWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� CampaignObjGoodsStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CampaignObjGoodsStWork</returns>
        /// <remarks>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private CampaignObjGoodsStWork CopyToCampaignObjGoodsStWorkFromReader(ref SqlDataReader myReader)
        {
            CampaignObjGoodsStWork campaignObjGoodsStWork = new CampaignObjGoodsStWork();

            if (myReader != null && campaignObjGoodsStWork != null)
            {

                # region �N���X�֊i�[

                 campaignObjGoodsStWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                 campaignObjGoodsStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
             
                # endregion
            }
            return campaignObjGoodsStWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� CampaignLinkWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CampaignLinkWork</returns>
        /// <remarks>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private CampaignLinkWork CopyToCampaignLinkWorkFromReader(ref SqlDataReader myReader)
        {

            CampaignLinkWork campaignLinkWork = new CampaignLinkWork();

            if (myReader != null && campaignLinkWork != null)
            {
                # region �N���X�֊i�[

                 campaignLinkWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                # endregion
            }
            return campaignLinkWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� CampaignStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns></returns>
        /// <returns>CampaignStWork</returns>
        /// <remarks>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private CampaignStWork CopyToCampaignStWorkFromReader(ref SqlDataReader myReader)
        {
            CampaignStWork campaignStWork = new CampaignStWork();

            if (myReader != null && campaignStWork != null)
            {
                # region �N���X�֊i�[

                 campaignStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPEXECSECCODERF"));  // ���_�R�[�h
                 campaignStWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF"));  // �L�����y�[������
                 campaignStWork.CampaignObjDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNOBJDIVRF"));  // �L�����y�[���Ώۋ敪
                 campaignStWork.ApplyStaDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYSTADATERF"));  // �K�p�J�n��
                 campaignStWork.ApplyEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYENDDATERF"));  // �K�p�I����

                # endregion
            }
            return campaignStWork;
        }

        # endregion

        
    }
}