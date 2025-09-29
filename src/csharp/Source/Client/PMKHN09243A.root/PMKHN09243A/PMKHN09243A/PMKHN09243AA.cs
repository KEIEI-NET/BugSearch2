using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���Ӑ�}�X�^(�����ݒ�)�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���Ӑ�}�X�^(�����ݒ�)�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer	: 30414 �E�@�K�j</br>
    /// <br>Date		: 2008/10/29</br>
    /// </remarks>
    public class SumCustStAcs
    {
        #region �� Private Members

        private ISumCustStDB _iSumCustStDB = null;

        #endregion �� Private Members


        # region �� Constructor

        /// <summary>
        /// ���Ӑ�}�X�^(�����ݒ�)�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�����ݒ�)�A�N�Z�X�N���X�̐V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public SumCustStAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iSumCustStDB = (ISumCustStDB)MediationSumCustStDB.GetSumCustStDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iSumCustStDB = null;
            }
        }

        # endregion �� Constructor


        #region �� Public Methods

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if ((this._iSumCustStDB == null) || (this._iSumCustStDB == null))
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�����ݒ�)�Ǎ�����
        /// </summary>
        /// <param name="sumCustSt">���Ӑ�}�X�^(�����ݒ�)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sumClaimCustCode">�����������Ӑ�R�[�h</param>
        /// <param name="demandAddUpSecCd">�����v�㋒�_�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�����ݒ�)���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public int Read(out SumCustSt sumCustSt, string enterpriseCode, int sumClaimCustCode, string demandAddUpSecCd)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            sumCustSt = new SumCustSt();

            try
            {
                // ���������ݒ�
                SumCustStWork paraWork = new SumCustStWork();
                paraWork.EnterpriseCode = enterpriseCode;
                paraWork.SumClaimCustCode = sumClaimCustCode;
                paraWork.DemandAddUpSecCd = demandAddUpSecCd;

                object paraObj = paraWork;

                status = this._iSumCustStDB.Read(ref paraObj, 0);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;

                    // �N���X�����o�R�s�[����(D��E)
                    sumCustSt = CopyToSumCustStFromSumCustStWork((SumCustStWork)retList[0]);
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�����ݒ�)�擾����
        /// </summary>
        /// <param name="sumCustStList">���Ӑ�}�X�^(�����ݒ�)���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�����ݒ�)���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public int Search(out ArrayList sumCustStList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out sumCustStList, enterpriseCode, 0, "", logicalMode);

            return (status);
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�����ݒ�)�擾����
        /// </summary>
        /// <param name="sumCustStList">���Ӑ�}�X�^(�����ݒ�)���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sumClaimCustCode">�����������Ӑ�R�[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�����ݒ�)���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public int Search(out ArrayList sumCustStList, string enterpriseCode, int sumClaimCustCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out sumCustStList, enterpriseCode, sumClaimCustCode, "", logicalMode);

            return (status);
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�����ݒ�)�擾����
        /// </summary>
        /// <param name="sumCustStList">���Ӑ�}�X�^(�����ݒ�)���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sumClaimCustCode">�����������Ӑ�R�[�h</param>
        /// <param name="demandAddUpSecCd">�����v�㋒�_�R�[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�����ݒ�)���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public int Search(out ArrayList sumCustStList, string enterpriseCode, int sumClaimCustCode, string demandAddUpSecCd, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out sumCustStList, enterpriseCode, sumClaimCustCode, demandAddUpSecCd, logicalMode);

            return (status);
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�����ݒ�)�X�V����
        /// </summary>
        /// <param name="sumCustStList">���Ӑ�}�X�^(�����ݒ�)���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�����ݒ�)���X�V���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public int Write(ref ArrayList sumCustStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (SumCustSt sumCustSt in sumCustStList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    workList.Add(CopyToSumCustStWorkFromSumCustSt(sumCustSt));
                }

                object paraObj = workList;

                status = this._iSumCustStDB.Write(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    sumCustStList = new ArrayList();
                    foreach (SumCustStWork sumCustStWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        sumCustStList.Add(CopyToSumCustStFromSumCustStWork(sumCustStWork));
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�����ݒ�)�_���폜����
        /// </summary>
        /// <param name="sumCustStList">���Ӑ�}�X�^(�����ݒ�)���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�����ݒ�)��_���폜���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList sumCustStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (SumCustSt sumCustSt in sumCustStList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    workList.Add(CopyToSumCustStWorkFromSumCustSt(sumCustSt));
                }

                object paraObj = workList;

                // �_���폜����
                status = this._iSumCustStDB.LogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    sumCustStList = new ArrayList();
                    foreach (SumCustStWork sumCustStWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        sumCustStList.Add(CopyToSumCustStFromSumCustStWork(sumCustStWork));
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�����ݒ�)�폜����
        /// </summary>
        /// <param name="sumCustStList">���Ӑ�}�X�^(�����ݒ�)���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�����ݒ�)���폜���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public int Delete(ArrayList sumCustStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (SumCustSt sumCustSt in sumCustStList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    workList.Add(CopyToSumCustStWorkFromSumCustSt(sumCustSt));
                }

                object paraObj = workList;

                // �����폜����
                status = this._iSumCustStDB.Delete(paraObj);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�����ݒ�)��������
        /// </summary>
        /// <param name="sumCustStList">���Ӑ�}�X�^(�����ݒ�)���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�����ݒ�)�𕜊����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        public int Revival(ref ArrayList sumCustStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (SumCustSt sumCustSt in sumCustStList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    workList.Add(CopyToSumCustStWorkFromSumCustSt(sumCustSt));
                }

                object paraObj = workList;

                // ��������
                status = this._iSumCustStDB.RevivalLogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    sumCustStList = new ArrayList();
                    foreach (SumCustStWork sumCustStWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        sumCustStList.Add(CopyToSumCustStFromSumCustStWork(sumCustStWork));
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        #endregion �� Public Methods


        #region �� Private Methods
        /// <summary>
        /// ���Ӑ�}�X�^(�����ݒ�)�擾����
        /// </summary>
        /// <param name="sumCustStList">���Ӑ�}�X�^(�����ݒ�)���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sumClaimCustCode">�����������Ӑ�R�[�h</param>
        /// <param name="demandAddUpSecCd">�����v�㋒�_�R�[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�����ݒ�)���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private int SearchProc(out ArrayList sumCustStList, string enterpriseCode, int sumClaimCustCode, string demandAddUpSecCd, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            sumCustStList = new ArrayList();

            try
            {
                // ���������ݒ�
                SumCustStWork paraWork = new SumCustStWork();
                paraWork.EnterpriseCode = enterpriseCode;
                paraWork.SumClaimCustCode = sumClaimCustCode;
                paraWork.DemandAddUpSecCd= demandAddUpSecCd;

                object paraObj = paraWork;

                ArrayList retList = new ArrayList();
                object retObj = retList;

                status = this._iSumCustStDB.Search(ref retObj, paraObj, 0, logicalMode);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    foreach (SumCustStWork sumCustStWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        sumCustStList.Add(CopyToSumCustStFromSumCustStWork(sumCustStWork));
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(E��D)
        /// </summary>
        /// <param name="sumCustSt">���Ӑ�}�X�^(�����ݒ�)�N���X</param>
        /// <returns>���Ӑ�}�X�^(�����ݒ�)���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private SumCustStWork CopyToSumCustStWorkFromSumCustSt(SumCustSt sumCustSt)
        {
            SumCustStWork sumCustStWork = new SumCustStWork();

            sumCustStWork.CreateDateTime = sumCustSt.CreateDateTime;
            sumCustStWork.UpdateDateTime = sumCustSt.UpdateDateTime;
            sumCustStWork.EnterpriseCode = sumCustSt.EnterpriseCode;
            sumCustStWork.FileHeaderGuid = sumCustSt.FileHeaderGuid;
            sumCustStWork.UpdEmployeeCode = sumCustSt.UpdEmployeeCode;
            sumCustStWork.UpdAssemblyId1 = sumCustSt.UpdAssemblyId1;
            sumCustStWork.UpdAssemblyId2 = sumCustSt.UpdAssemblyId2;
            sumCustStWork.LogicalDeleteCode = sumCustSt.LogicalDeleteCode;
            sumCustStWork.SumClaimCustCode = sumCustSt.SumClaimCustCode;
            sumCustStWork.DemandAddUpSecCd = sumCustSt.DemandAddUpSecCd;
            sumCustStWork.CustomerCode = sumCustSt.CustomerCode;

            return sumCustStWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(D��E)
        /// </summary>
        /// <param name="custRateGroupWork">���Ӑ�}�X�^(�����ݒ�)���[�N�N���X</param>
        /// <returns>���Ӑ�}�X�^(�����ݒ�)�N���X</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/29</br>
        /// </remarks>
        private SumCustSt CopyToSumCustStFromSumCustStWork(SumCustStWork sumCustStWork)
        {
            SumCustSt sumCustSt = new SumCustSt();

            sumCustSt.CreateDateTime = sumCustStWork.CreateDateTime;
            sumCustSt.UpdateDateTime = sumCustStWork.UpdateDateTime;
            sumCustSt.EnterpriseCode = sumCustStWork.EnterpriseCode;
            sumCustSt.FileHeaderGuid = sumCustStWork.FileHeaderGuid;
            sumCustSt.UpdEmployeeCode = sumCustStWork.UpdEmployeeCode;
            sumCustSt.UpdAssemblyId1 = sumCustStWork.UpdAssemblyId1;
            sumCustSt.UpdAssemblyId2 = sumCustStWork.UpdAssemblyId2;
            sumCustSt.LogicalDeleteCode = sumCustStWork.LogicalDeleteCode;
            sumCustSt.SumClaimCustCode = sumCustStWork.SumClaimCustCode;
            sumCustSt.DemandAddUpSecCd = sumCustStWork.DemandAddUpSecCd;
            sumCustSt.CustomerCode = sumCustStWork.CustomerCode;

            return sumCustSt;
        }

        #endregion �� Private Methods
    }
}
