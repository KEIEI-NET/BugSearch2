//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[���ڕW�ݒ�}�X�^
// �v���O�����T�v   : �L�����y�[���ڕW�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �L�����y�[���ڕW�ݒ�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���ڕW�ݒ�A�N�Z�X�N���X</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2011/04/28</br>
    /// </remarks>
    public class CampaignTargetAcs
    {
        #region �� Private Members

        private ICampaignTargetUDB _iCampaignTargetDB;      // �L�����y�[���ڕW�����[�g
        #endregion �� Private Members


        #region �� Constructor
        /// <summary>
        /// �L�����y�[���ڕW�ݒ�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�A�N�Z�X�N���X</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/28</br>
        /// </remarks>
        public CampaignTargetAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iCampaignTargetDB = (ICampaignTargetUDB)MediationCampaignTargetUDB.GetCampaignTargetUDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iCampaignTargetDB = null;
            }
        }
        #endregion �� Constructor


        #region �� Public Methods

        #region �I�����C�����[�h�擾
        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/28</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iCampaignTargetDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
        #endregion �I�����C�����[�h�擾

        #region ��������
        #endregion ��������

        #region �X�V����
        /// <summary>
        /// �X�V����(�L�����y�[���ڕW)
        /// </summary>
        /// <param name="campaignTargetList">�L�����y�[���ڕW���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^���X�V���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/28</br>
        /// </remarks>
        public int Write(ref List<CampaignTarget> campaignTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (CampaignTarget campaignTarget in campaignTargetList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraList.Add(CopyToSearchCampaignTargetParaWorkFromCampaignTarget(campaignTarget));
                }

                object paraObj = paraList;

                // �X�V����
                status = this._iCampaignTargetDB.Write(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List������
                    campaignTargetList.Clear();

                    // �f�[�^�ϊ�
                    foreach (CampaignTargetWork CampaignTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        campaignTargetList.Add(CopyToCampaignTargetFromSearchCampaignTargetParaWork(CampaignTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion �X�V����

        #region �_���폜����
        /// <summary>
        /// �_���폜����(�L�����y�[���ڕW)
        /// </summary>
        /// <param name="campaignTargetList">�L�����y�[���ڕW���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^��_���폜���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/28</br>
        /// </remarks>
        public int LogicalDelete(ref List<CampaignTarget> campaignTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (CampaignTarget campaignTarget in campaignTargetList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraList.Add(CopyToSearchCampaignTargetParaWorkFromCampaignTarget(campaignTarget));
                }

                object paraObj = paraList;

                // �_���폜����
                status = this._iCampaignTargetDB.LogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List������
                    campaignTargetList.Clear();

                    // �f�[�^�ϊ�
                    foreach (CampaignTargetWork CampaignTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        campaignTargetList.Add(CopyToCampaignTargetFromSearchCampaignTargetParaWork(CampaignTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion �_���폜����

        #region �����폜����
        /// <summary>
        /// �����폜����(�L�����y�[���ڕW)
        /// </summary>
        /// <param name="campaignTargetList">�L�����y�[���ڕW���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�𕨗��폜���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/28</br>
        /// </remarks>
        public int Delete(List<CampaignTarget> campaignTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                CampaignTargetWork[] paraWorkArray = new CampaignTargetWork[campaignTargetList.Count];

                for (int index = 0; index < campaignTargetList.Count; index++)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraWorkArray[index] = CopyToSearchCampaignTargetParaWorkFromCampaignTarget(campaignTargetList[index]);
                }

                // XML�֕ϊ����A������̃o�C�i����
                byte[] paraByte = XmlByteSerializer.Serialize(paraWorkArray);

                // �����폜����
                status = this._iCampaignTargetDB.Delete(paraByte);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        #endregion �����폜����

        #region ��������
        /// <summary>
        /// ��������(�L�����y�[���ڕW)
        /// </summary>
        /// <param name="campaignTargetList">�L�����y�[���ڕW���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�𕜊����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/28</br>
        /// </remarks>
        public int Revival(ref List<CampaignTarget> campaignTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (CampaignTarget campaignTarget in campaignTargetList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraList.Add(CopyToSearchCampaignTargetParaWorkFromCampaignTarget(campaignTarget));
                }

                object paraObj = paraList;

                // �_���폜����
                status = this._iCampaignTargetDB.RevivalLogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List������
                    campaignTargetList.Clear();

                    // �f�[�^�ϊ�
                    foreach (CampaignTargetWork CampaignTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        campaignTargetList.Add(CopyToCampaignTargetFromSearchCampaignTargetParaWork(CampaignTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        #endregion ��������
        #region ��������
        /// <summary>
        /// ��������(�L�����y�[���ڕW)
        /// </summary>
        /// <param name="campaignTargetList">�L�����y�[���ڕW���X�g</param>
        /// <param name="searchCampaignTargetPara">�L�����y�[���ڕW��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �L�����y�[���ڕW��}�X�^���������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/28</br>
        /// </remarks>
        public int Search(ref List<CampaignTarget> campaignTargetList, CampaignTarget searchCampaignTargetPara, ConstantManagement.LogicalMode logicalMode)
        {
            campaignTargetList = new List<CampaignTarget>();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                // �N���X�����o�R�s�[����(E��D)
                CampaignTargetWork paraWork = CopyToSearchCampaignTargetParaWorkFromCampaignTarget(searchCampaignTargetPara);

                object paraObj = paraWork;
                ArrayList list = new ArrayList();
                object retObj = (object)list;

                // ��������
                status = this._iCampaignTargetDB.Search(ref retObj, paraObj, 0, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = retObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // �f�[�^�ϊ�
                    foreach (CampaignTargetWork CampaignTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        campaignTargetList.Add(CopyToCampaignTargetFromSearchCampaignTargetParaWork(CampaignTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion ��������
        #endregion �� Public Methods


        #region �� Private Methods

        #region �N���X�����o�R�s�[����(E��D)
        /// <summary>
        /// �N���X�����o�R�s�[����(�L�����y�[���ڕW)
        /// </summary>
        /// <param name="campaignTarget">�L�����y�[���ڕW�ݒ�}�X�^</param>
        /// <returns>�L�����y�[���ڕW�ݒ�}�X�^���[�N</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/28</br>
        /// </remarks>
        private CampaignTargetWork CopyToSearchCampaignTargetParaWorkFromCampaignTarget(CampaignTarget campaignTarget)
        {
            CampaignTargetWork CampaignTargetWork = new CampaignTargetWork();

            //�쐬����
            CampaignTargetWork.CreateDateTime = campaignTarget.CreateDateTime;
            //�X�V����
            CampaignTargetWork.UpdateDateTime = campaignTarget.UpdateDateTime;
            //��ƃR�[�h
            CampaignTargetWork.EnterpriseCode = campaignTarget.EnterpriseCode;
            //�X�V�]�ƈ��R�[�h
            CampaignTargetWork.UpdEmployeeCode = campaignTarget.UpdEmployeeCode;
            //�X�V�A�Z���u��ID1
            CampaignTargetWork.UpdAssemblyId1 = campaignTarget.UpdAssemblyId1;
            //�X�V�A�Z���u��ID2
            CampaignTargetWork.UpdAssemblyId2 = campaignTarget.UpdAssemblyId2;
            //�_���폜�敪
            CampaignTargetWork.LogicalDeleteCode = campaignTarget.LogicalDeleteCode;
            //�L�����y�[���R�[�h
            CampaignTargetWork.CampaignCode = campaignTarget.CampaignCode;
            //�ڕW�Δ�敪
            CampaignTargetWork.TargetContrastCd = campaignTarget.TargetContrastCd;
            //�]�ƈ��敪
            CampaignTargetWork.EmployeeDivCd = campaignTarget.EmployeeDivCd;
            //���_�R�[�h
            CampaignTargetWork.SectionCode = campaignTarget.SectionCode;
            //�]�ƈ��R�[�h
            CampaignTargetWork.EmployeeCode = campaignTarget.EmployeeCode;
            //���Ӑ�R�[�h
            CampaignTargetWork.CustomerCode = campaignTarget.CustomerCode;
            //�̔��G���A�R�[�h
            CampaignTargetWork.SalesAreaCode = campaignTarget.SalesAreaCode;
            //BL�O���[�v�R�[�h
            CampaignTargetWork.BLGroupCode = campaignTarget.BLGroupCode;
            //BL���i�R�[�h
            CampaignTargetWork.BLGoodsCode = campaignTarget.BLGoodsCode;
            //�̔��敪�R�[�h
            CampaignTargetWork.SalesCode = campaignTarget.SalesCode;
            //����ڕW���z1
            CampaignTargetWork.SalesTargetMoney1 = campaignTarget.SalesTargetMoney1;
            //����ڕW���z2
            CampaignTargetWork.SalesTargetMoney2 = campaignTarget.SalesTargetMoney2;
            //����ڕW���z3
            CampaignTargetWork.SalesTargetMoney3 = campaignTarget.SalesTargetMoney3;
            //����ڕW���z4
            CampaignTargetWork.SalesTargetMoney4 = campaignTarget.SalesTargetMoney4;
            //����ڕW���z5
            CampaignTargetWork.SalesTargetMoney5 = campaignTarget.SalesTargetMoney5;
            //����ڕW���z6
            CampaignTargetWork.SalesTargetMoney6 = campaignTarget.SalesTargetMoney6;
            //����ڕW���z7
            CampaignTargetWork.SalesTargetMoney7 = campaignTarget.SalesTargetMoney7;
            //����ڕW���z8
            CampaignTargetWork.SalesTargetMoney8 = campaignTarget.SalesTargetMoney8;
            //����ڕW���z9
            CampaignTargetWork.SalesTargetMoney9 = campaignTarget.SalesTargetMoney9;
            //����ڕW���z10
            CampaignTargetWork.SalesTargetMoney10 = campaignTarget.SalesTargetMoney10;
            //����ڕW���z11
            CampaignTargetWork.SalesTargetMoney11 = campaignTarget.SalesTargetMoney11;
            //����ڕW���z12
            CampaignTargetWork.SalesTargetMoney12 = campaignTarget.SalesTargetMoney12;
            //���Ԕ���ڕW���z
            CampaignTargetWork.MonthlySalesTarget = campaignTarget.MonthlySalesTarget;
            //������ԖڕW���z
            CampaignTargetWork.TermSalesTarget = campaignTarget.TermSalesTarget;
            //����ڕW�e���z1
            CampaignTargetWork.SalesTargetProfit1 = campaignTarget.SalesTargetProfit1;
            //����ڕW�e���z2
            CampaignTargetWork.SalesTargetProfit2 = campaignTarget.SalesTargetProfit2;
            //����ڕW�e���z3
            CampaignTargetWork.SalesTargetProfit3 = campaignTarget.SalesTargetProfit3;
            //����ڕW�e���z4
            CampaignTargetWork.SalesTargetProfit4 = campaignTarget.SalesTargetProfit4;
            //����ڕW�e���z5
            CampaignTargetWork.SalesTargetProfit5 = campaignTarget.SalesTargetProfit5;
            //����ڕW�e���z6
            CampaignTargetWork.SalesTargetProfit6 = campaignTarget.SalesTargetProfit6;
            //����ڕW�e���z7
            CampaignTargetWork.SalesTargetProfit7 = campaignTarget.SalesTargetProfit7;
            //����ڕW�e���z8
            CampaignTargetWork.SalesTargetProfit8 = campaignTarget.SalesTargetProfit8;
            //����ڕW�e���z9
            CampaignTargetWork.SalesTargetProfit9 = campaignTarget.SalesTargetProfit9;
            //����ڕW�e���z10
            CampaignTargetWork.SalesTargetProfit10 = campaignTarget.SalesTargetProfit10;
            //����ڕW�e���z11
            CampaignTargetWork.SalesTargetProfit11 = campaignTarget.SalesTargetProfit11;
            //����ڕW�e���z12
            CampaignTargetWork.SalesTargetProfit12 = campaignTarget.SalesTargetProfit12;
            //���㌎�ԖڕW�e���z
            CampaignTargetWork.MonthlySalesTargetProfit = campaignTarget.MonthlySalesTargetProfit;
            //������ԖڕW�e���z
            CampaignTargetWork.TermSalesTargetProfit = campaignTarget.TermSalesTargetProfit;
            //����ڕW����1
            CampaignTargetWork.SalesTargetCount1 = campaignTarget.SalesTargetCount1;
            //����ڕW����2
            CampaignTargetWork.SalesTargetCount2 = campaignTarget.SalesTargetCount2;
            //����ڕW����3
            CampaignTargetWork.SalesTargetCount3 = campaignTarget.SalesTargetCount3;
            //����ڕW����4
            CampaignTargetWork.SalesTargetCount4 = campaignTarget.SalesTargetCount4;
            //����ڕW����5
            CampaignTargetWork.SalesTargetCount5 = campaignTarget.SalesTargetCount5;
            //����ڕW����6
            CampaignTargetWork.SalesTargetCount6 = campaignTarget.SalesTargetCount6;
            //����ڕW����7
            CampaignTargetWork.SalesTargetCount7 = campaignTarget.SalesTargetCount7;
            //����ڕW����8
            CampaignTargetWork.SalesTargetCount8 = campaignTarget.SalesTargetCount8;
            //����ڕW����9
            CampaignTargetWork.SalesTargetCount9 = campaignTarget.SalesTargetCount9;
            //����ڕW����10
            CampaignTargetWork.SalesTargetCount10 = campaignTarget.SalesTargetCount10;
            //����ڕW����11
            CampaignTargetWork.SalesTargetCount11 = campaignTarget.SalesTargetCount11;
            //����ڕW����12
            CampaignTargetWork.SalesTargetCount12 = campaignTarget.SalesTargetCount12;
            //���㌎�ԖڕW����
            CampaignTargetWork.MonthlySalesTargetCount = campaignTarget.MonthlySalesTargetCount;
            //������ԖڕW����
            CampaignTargetWork.TermSalesTargetCount = campaignTarget.TermSalesTargetCount;

            return CampaignTargetWork;
        }

        #endregion �N���X�����o�R�s�[����(E��D)

        #region �N���X�����o�R�s�[����(D��E)
        /// <summary>
        /// �N���X�����o�R�s�[����(�L�����y�[���ڕW)
        /// </summary>
        /// <param name="CampaignTargetWork">�L�����y�[���ڕW�ݒ�}�X�^���[�N</param>
        /// <returns>�L�����y�[���ڕW�ݒ�}�X�^</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/28</br>
        /// </remarks>
        private CampaignTarget CopyToCampaignTargetFromSearchCampaignTargetParaWork(CampaignTargetWork CampaignTargetWork)
        {
            CampaignTarget campaignTarget = new CampaignTarget();

            //�쐬����
            campaignTarget.CreateDateTime = CampaignTargetWork.CreateDateTime;
            //�X�V����
            campaignTarget.UpdateDateTime = CampaignTargetWork.UpdateDateTime;
            //��ƃR�[�h
            campaignTarget.EnterpriseCode = CampaignTargetWork.EnterpriseCode;
            //�X�V�]�ƈ��R�[�h
            campaignTarget.UpdEmployeeCode = CampaignTargetWork.UpdEmployeeCode;
            //�X�V�A�Z���u��ID1
            campaignTarget.UpdAssemblyId1 = CampaignTargetWork.UpdAssemblyId1;
            //�X�V�A�Z���u��ID2
            campaignTarget.UpdAssemblyId2 = CampaignTargetWork.UpdAssemblyId2;
            //�_���폜�敪
            campaignTarget.LogicalDeleteCode = CampaignTargetWork.LogicalDeleteCode;
            //�L�����y�[���R�[�h
            campaignTarget.CampaignCode = CampaignTargetWork.CampaignCode;
            //�ڕW�Δ�敪
            campaignTarget.TargetContrastCd = CampaignTargetWork.TargetContrastCd;
            //�]�ƈ��敪
            campaignTarget.EmployeeDivCd = CampaignTargetWork.EmployeeDivCd;
            //���_�R�[�h
            campaignTarget.SectionCode = CampaignTargetWork.SectionCode;
            //�]�ƈ��R�[�h
            campaignTarget.EmployeeCode = CampaignTargetWork.EmployeeCode;
            //���Ӑ�R�[�h
            campaignTarget.CustomerCode = CampaignTargetWork.CustomerCode;
            //�̔��G���A�R�[�h
            campaignTarget.SalesAreaCode = CampaignTargetWork.SalesAreaCode;
            //BL�O���[�v�R�[�h
            campaignTarget.BLGroupCode = CampaignTargetWork.BLGroupCode;
            //BL���i�R�[�h
            campaignTarget.BLGoodsCode = CampaignTargetWork.BLGoodsCode;
            //�̔��敪�R�[�h
            campaignTarget.SalesCode = CampaignTargetWork.SalesCode;
            //����ڕW���z1
            campaignTarget.SalesTargetMoney1 = CampaignTargetWork.SalesTargetMoney1;
            //����ڕW���z2
            campaignTarget.SalesTargetMoney2 = CampaignTargetWork.SalesTargetMoney2;
            //����ڕW���z3
            campaignTarget.SalesTargetMoney3 = CampaignTargetWork.SalesTargetMoney3;
            //����ڕW���z4
            campaignTarget.SalesTargetMoney4 = CampaignTargetWork.SalesTargetMoney4;
            //����ڕW���z5
            campaignTarget.SalesTargetMoney5 = CampaignTargetWork.SalesTargetMoney5;
            //����ڕW���z6
            campaignTarget.SalesTargetMoney6 = CampaignTargetWork.SalesTargetMoney6;
            //����ڕW���z7
            campaignTarget.SalesTargetMoney7 = CampaignTargetWork.SalesTargetMoney7;
            //����ڕW���z8
            campaignTarget.SalesTargetMoney8 = CampaignTargetWork.SalesTargetMoney8;
            //����ڕW���z9
            campaignTarget.SalesTargetMoney9 = CampaignTargetWork.SalesTargetMoney9;
            //����ڕW���z10
            campaignTarget.SalesTargetMoney10 = CampaignTargetWork.SalesTargetMoney10;
            //����ڕW���z11
            campaignTarget.SalesTargetMoney11 = CampaignTargetWork.SalesTargetMoney11;
            //����ڕW���z12
            campaignTarget.SalesTargetMoney12 = CampaignTargetWork.SalesTargetMoney12;
            //���Ԕ���ڕW���z
            campaignTarget.MonthlySalesTarget = CampaignTargetWork.MonthlySalesTarget;
            //������ԖڕW���z
            campaignTarget.TermSalesTarget = CampaignTargetWork.TermSalesTarget;
            //����ڕW�e���z1
            campaignTarget.SalesTargetProfit1 = CampaignTargetWork.SalesTargetProfit1;
            //����ڕW�e���z2
            campaignTarget.SalesTargetProfit2 = CampaignTargetWork.SalesTargetProfit2;
            //����ڕW�e���z3
            campaignTarget.SalesTargetProfit3 = CampaignTargetWork.SalesTargetProfit3;
            //����ڕW�e���z4
            campaignTarget.SalesTargetProfit4 = CampaignTargetWork.SalesTargetProfit4;
            //����ڕW�e���z5
            campaignTarget.SalesTargetProfit5 = CampaignTargetWork.SalesTargetProfit5;
            //����ڕW�e���z6
            campaignTarget.SalesTargetProfit6 = CampaignTargetWork.SalesTargetProfit6;
            //����ڕW�e���z7
            campaignTarget.SalesTargetProfit7 = CampaignTargetWork.SalesTargetProfit7;
            //����ڕW�e���z8
            campaignTarget.SalesTargetProfit8 = CampaignTargetWork.SalesTargetProfit8;
            //����ڕW�e���z9
            campaignTarget.SalesTargetProfit9 = CampaignTargetWork.SalesTargetProfit9;
            //����ڕW�e���z10
            campaignTarget.SalesTargetProfit10 = CampaignTargetWork.SalesTargetProfit10;
            //����ڕW�e���z11
            campaignTarget.SalesTargetProfit11 = CampaignTargetWork.SalesTargetProfit11;
            //����ڕW�e���z12
            campaignTarget.SalesTargetProfit12 = CampaignTargetWork.SalesTargetProfit12;
            //���㌎�ԖڕW�e���z
            campaignTarget.MonthlySalesTargetProfit = CampaignTargetWork.MonthlySalesTargetProfit;
            //������ԖڕW�e���z
            campaignTarget.TermSalesTargetProfit = CampaignTargetWork.TermSalesTargetProfit;
            //����ڕW����1
            campaignTarget.SalesTargetCount1 = CampaignTargetWork.SalesTargetCount1;
            //����ڕW����2
            campaignTarget.SalesTargetCount2 = CampaignTargetWork.SalesTargetCount2;
            //����ڕW����3
            campaignTarget.SalesTargetCount3 = CampaignTargetWork.SalesTargetCount3;
            //����ڕW����4
            campaignTarget.SalesTargetCount4 = CampaignTargetWork.SalesTargetCount4;
            //����ڕW����5
            campaignTarget.SalesTargetCount5 = CampaignTargetWork.SalesTargetCount5;
            //����ڕW����6
            campaignTarget.SalesTargetCount6 = CampaignTargetWork.SalesTargetCount6;
            //����ڕW����7
            campaignTarget.SalesTargetCount7 = CampaignTargetWork.SalesTargetCount7;
            //����ڕW����8
            campaignTarget.SalesTargetCount8 = CampaignTargetWork.SalesTargetCount8;
            //����ڕW����9
            campaignTarget.SalesTargetCount9 = CampaignTargetWork.SalesTargetCount9;
            //����ڕW����10
            campaignTarget.SalesTargetCount10 = CampaignTargetWork.SalesTargetCount10;
            //����ڕW����11
            campaignTarget.SalesTargetCount11 = CampaignTargetWork.SalesTargetCount11;
            //����ڕW����12
            campaignTarget.SalesTargetCount12 = CampaignTargetWork.SalesTargetCount12;
            //���㌎�ԖڕW����
            campaignTarget.MonthlySalesTargetCount = CampaignTargetWork.MonthlySalesTargetCount;
            //������ԖڕW����
            campaignTarget.TermSalesTargetCount = CampaignTargetWork.TermSalesTargetCount;


            return campaignTarget;
        }
        #endregion �N���X�����o�R�s�[����(D��E)

        #endregion �� Private Methods
    }
}
