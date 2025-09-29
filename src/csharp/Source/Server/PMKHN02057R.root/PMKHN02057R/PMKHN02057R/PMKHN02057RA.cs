//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[�����ѕ\
// �v���O�����T�v   : �L�����y�[�����ѕ\�@�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2011/05/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : chenyd
// �� �� ��  2012/04/09  �C�����e : 2012/05/24�z�M���ARedmine#29314           
//                                  �^�C���A�E�g�G���[�̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �L�����y�[�����ѕ\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[�����ѕ\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2011/05/19</br>
    /// </remarks>
    [Serializable]
    public class CampaignRsltListResultDB : RemoteDB, ICampaignRsltListResultDB
    {
        #region [�R���X�g���N�^]
        /// <summary>
        /// �L�����y�[�����ѕ\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/05/19</br>
        /// <br>Update Note: 2012/04/09 chenyd</br>							
        /// <br>�Ǘ��ԍ�   �F10801804-00 2012/05/24�z�M��</br>							
        /// <br>             Redmine#29314�@�^�C���A�E�g�G���[�̑Ή�</br>
        /// </remarks>
        public CampaignRsltListResultDB()
            :
            base("PMKHN02059D", "Broadleaf.Application.Remoting.ParamData.CampaignstRsltListResultWork", "CAMPAIGNSTRSLTLISTRESULTRF")
        {
        }
        #endregion

        IMTtlCampaign mTtlCampaign;

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̃L�����y�[�����уf�[�^��߂��܂��B
        /// </summary>
        /// <param name="campaignstRsltListSalesWork">��������1</param>
        /// <param name="campaignstRsltListTargetWork">��������2</param>
        /// <param name="campaignstRsltListPrtWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        public int Search(out object campaignstRsltListSalesWork, out object campaignstRsltListTargetWork, object campaignstRsltListPrtWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            campaignstRsltListSalesWork = null;
            campaignstRsltListTargetWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchCampaignRsltListData(out campaignstRsltListSalesWork, out campaignstRsltListTargetWork, campaignstRsltListPrtWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignRsltListResultDB.Search");
                campaignstRsltListSalesWork = new ArrayList();
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
        #endregion Search

        #region [SearchCampaignRsltListData]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objCampaignstRsltListSalesWork">��������1</param>
        /// <param name="objCampaignstRsltListTargetWork">��������2</param>
        /// <param name="objCampaignstRsltListPrtWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        private int SearchCampaignRsltListData(out object objCampaignstRsltListSalesWork, out object objCampaignstRsltListTargetWork, object objCampaignstRsltListPrtWork, ref SqlConnection sqlConnection)
        {
            CampaignstRsltListPrtWork paramWork = null;

            ArrayList paramWorkList = objCampaignstRsltListPrtWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objCampaignstRsltListPrtWork as CampaignstRsltListPrtWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as CampaignstRsltListPrtWork;
            }

            ArrayList campaignRsltListSalesWorkList = null;
            ArrayList campaignRsltListTargetWorkList = null;

            switch (paramWork.TotalType)
            {
                case (int)TotalType.Goods:     // ���i��
                    mTtlCampaign = new MTtlCampaignGoods();
                    break;
                case (int)TotalType.Customer:  // ���Ӑ��
                    mTtlCampaign = new MTtlCampaignCust();
                    break;
                case (int)TotalType.Employee:  // �S���ҕ�
                    mTtlCampaign = new MTtlCampaignEmp();
                    break;
                case (int)TotalType.AcceptOdr: // �󒍎ҕ�
                    mTtlCampaign = new MTtlCampaignAcp();
                    break;
                case (int)TotalType.Printer:   // ���s�ҕ�
                    mTtlCampaign = new MTtlCampaignPrt();
                    break;
                case (int)TotalType.Area:      // �n���
                    mTtlCampaign = new MTtlCampaignArea();
                    break;
                case (int)TotalType.Sales:     // �̔��敪��
                    mTtlCampaign = new MTtlCampaignGuide();
                    break;
                default:
                    break;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList campaignstWorkLst = new ArrayList();
            // ������уf�[�^���捞��
            status = SearchCampaignData(out campaignRsltListSalesWorkList, out campaignRsltListTargetWorkList, paramWork, ref sqlConnection);

            objCampaignstRsltListSalesWork = campaignRsltListSalesWorkList;
            objCampaignstRsltListTargetWork = campaignRsltListTargetWorkList;
            return status;
        }
        #endregion SearchCampaignRsltListData

        #region [SearchCampaignData]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignRsltListSalesWorkList">��������</param>
        /// <param name="campaignRsltListTargetWorkList">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns></returns>
        private int SearchCampaignData(out ArrayList campaignRsltListSalesWorkList, out ArrayList campaignRsltListTargetWorkList, CampaignstRsltListPrtWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList campaignSalesList = new ArrayList();
            ArrayList campaignTargetList = new ArrayList();
            try
            {
                // ����f�[�^���擾����
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = mTtlCampaign.MakeSalesSelectString(ref sqlConnection, ref sqlCommand, paramWork);

                //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                //sqlCommand.CommandTimeout = 600; // DEL 2012/04/09 chenyd for Redmine#29314
                sqlCommand.CommandTimeout = 3600;  // ADD 2012/04/09 chenyd for Redmine#29314

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    campaignSalesList.Add(mTtlCampaign.CopyToCampaignSalesWorkFromReader(ref myReader, paramWork));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
                // �ڕW�ݒ�f�[�^���擾����
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = mTtlCampaign.MakeTargetSelectString(ref sqlCommand, paramWork);

                //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                //sqlCommand.CommandTimeout = 600; // DEL 2012/04/09 chenyd for Redmine#29314
                sqlCommand.CommandTimeout = 3600; // ADD 2012/04/09 chenyd for Redmine#29314

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    campaignTargetList.Add(mTtlCampaign.CopyToCampaignTargetWorkFromReader(ref myReader, paramWork));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignRsltListResultDB.SearchCampaignData");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            campaignRsltListSalesWorkList = campaignSalesList;
            campaignRsltListTargetWorkList = campaignTargetList;
            
            return status;
        }
        #endregion SearchCampaignData

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/05/19</br>
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
        #endregion  //�R�l�N�V������������
    }

}
