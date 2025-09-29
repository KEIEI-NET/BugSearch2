//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d����}�X�^(�����ݒ�)�A�N�Z�X�N���X
// �v���O�����T�v   : �d����}�X�^(�����ݒ�)�Ŏg�p����f�[�^���擾����
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI�֓� �a�G
// �� �� ��  2012/08/29  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
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
    /// �d����}�X�^(�����ݒ�)�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d����}�X�^(�����ݒ�)�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : FSI�֓� �a�G</br>
    /// <br>Date       : 2012/08/29</br>
    /// </remarks>
    public class SumSuppStAcs
    {
        #region �� Private Members

        private ISumSuppStDB _iSumSuppStDB = null;

        #endregion �� Private Members

        # region �� Constructor

        /// <summary>
        /// �d����}�X�^(�����ݒ�)�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d����}�X�^(�����ݒ�)�A�N�Z�X�N���X�̐V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        public SumSuppStAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iSumSuppStDB = (ISumSuppStDB)MediationSumSuppStDB.GetSumSuppStDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iSumSuppStDB = null;
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
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if ((this._iSumSuppStDB == null) || (this._iSumSuppStDB == null))
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// �d����}�X�^(�����ݒ�)�擾����
        /// </summary>
        /// <param name="sumSuppStList">�d����}�X�^(�����ݒ�)���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �d����}�X�^(�����ݒ�)���擾���܂��B</br>
        /// <br>             �S���擾��z��</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        public int Search(out ArrayList sumSuppStList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out sumSuppStList, enterpriseCode, 0, string.Empty, logicalMode);

            return (status);
        }

        /// <summary>
        /// �d����}�X�^(�����ݒ�)�擾����
        /// </summary>
        /// <param name="sumSuppStList">�d����}�X�^(�����ݒ�)���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sumSuppCode">�����d����R�[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �d����}�X�^(�����ݒ�)���擾���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        public int Search(out ArrayList sumSuppStList, string enterpriseCode, int sumSuppCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out sumSuppStList, enterpriseCode, sumSuppCode, string.Empty, logicalMode);

            return (status);
        }

        /// <summary>
        /// �d����}�X�^(�����ݒ�)�擾����
        /// </summary>
        /// <param name="sumSuppStList">�d����}�X�^(�����ݒ�)���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sumSuppCode">�����d����R�[�h</param>
        /// <param name="sumSecCd">�������_�R�[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �d����}�X�^(�����ݒ�)���擾���܂��B</br>
        /// <br>             �ڍבS���擾��z��</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        public int Search(out ArrayList sumSuppStList, string enterpriseCode, int sumSuppCode, string sumSecCd, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out sumSuppStList, enterpriseCode, sumSuppCode, sumSecCd, logicalMode);

            return (status);
        }

        /// <summary>
        /// �d����}�X�^(�����ݒ�)�X�V����
        /// </summary>
        /// <param name="sumSuppStList">�d����}�X�^(�����ݒ�)���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �d����}�X�^(�����ݒ�)���X�V���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        public int Write(ref ArrayList sumSuppStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (SumSuppSt sumSuppSt in sumSuppStList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    workList.Add(CopyToSumSuppStWorkFromSumSuppSt(sumSuppSt));
                }

                object paraObj = workList;

                status = this._iSumSuppStDB.Write(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    sumSuppStList = new ArrayList();
                    foreach (SumSuppStWork sumSuppStWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        sumSuppStList.Add(CopyToSumSuppStFromSumSuppStWork(sumSuppStWork));
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
        /// �d����}�X�^(�����ݒ�)�_���폜����
        /// </summary>
        /// <param name="sumSuppStList">�d����}�X�^(�����ݒ�)���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �d����}�X�^(�����ݒ�)��_���폜���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList sumSuppStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (SumSuppSt sumSuppSt in sumSuppStList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    workList.Add(CopyToSumSuppStWorkFromSumSuppSt(sumSuppSt));
                }

                object paraObj = workList;

                // �_���폜����
                status = this._iSumSuppStDB.LogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    sumSuppStList = new ArrayList();
                    foreach (SumSuppStWork sumSuppStWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        sumSuppStList.Add(CopyToSumSuppStFromSumSuppStWork(sumSuppStWork));
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
        /// �d����}�X�^(�����ݒ�)�폜����
        /// </summary>
        /// <param name="sumSuppStList">�d����}�X�^(�����ݒ�)���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �d����}�X�^(�����ݒ�)���폜���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        public int Delete(ArrayList sumSuppStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (SumSuppSt sumSuppSt in sumSuppStList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    workList.Add(CopyToSumSuppStWorkFromSumSuppSt(sumSuppSt));
                }

                object paraObj = workList;

                // �����폜����
                status = this._iSumSuppStDB.Delete(paraObj);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// �d����}�X�^(�����ݒ�)��������
        /// </summary>
        /// <param name="sumSuppStList">�d����}�X�^(�����ݒ�)���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �d����}�X�^(�����ݒ�)�𕜊����܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        public int Revival(ref ArrayList sumSuppStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (SumSuppSt sumSuppSt in sumSuppStList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    workList.Add(CopyToSumSuppStWorkFromSumSuppSt(sumSuppSt));
                }

                object paraObj = workList;

                // ��������
                status = this._iSumSuppStDB.RevivalLogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    sumSuppStList = new ArrayList();
                    foreach (SumSuppStWork sumSuppStWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        sumSuppStList.Add(CopyToSumSuppStFromSumSuppStWork(sumSuppStWork));
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
        /// �d����}�X�^(�����ݒ�)�擾����
        /// </summary>
        /// <param name="sumSuppStList">�d����}�X�^(�����ݒ�)���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sumSuppCode">�����d����R�[�h</param>
        /// <param name="sumSecCd">�������_�R�[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �d����}�X�^(�����ݒ�)���擾���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        private int SearchProc(out ArrayList sumSuppStList, string enterpriseCode, int sumSuppCode, string sumSecCd, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            sumSuppStList = new ArrayList();

            try
            {
                // ���������ݒ�
                SumSuppStWork paraWork  = new SumSuppStWork();
                paraWork.EnterpriseCode = enterpriseCode;
                paraWork.SumSupplierCd  = sumSuppCode;
                paraWork.SumSectionCd   = sumSecCd;

                object paraObj = paraWork;

                ArrayList retList = new ArrayList();
                object retObj = retList;

                // �S��������logicalMode->0
                status = this._iSumSuppStDB.Search(ref retObj, paraObj, 0, logicalMode);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    foreach (SumSuppStWork sumSuppStWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        sumSuppStList.Add(CopyToSumSuppStFromSumSuppStWork(sumSuppStWork));
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
        /// <param name="sumSuppSt">�d����}�X�^(�����ݒ�)�N���X</param>
        /// <returns>�d����}�X�^(�����ݒ�)���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        private SumSuppStWork CopyToSumSuppStWorkFromSumSuppSt(SumSuppSt sumSuppSt)
        {
            SumSuppStWork sumSuppStWork = new SumSuppStWork();

            sumSuppStWork.CreateDateTime = sumSuppSt.CreateDateTime;
            sumSuppStWork.UpdateDateTime = sumSuppSt.UpdateDateTime;
            sumSuppStWork.EnterpriseCode = sumSuppSt.EnterpriseCode;
            sumSuppStWork.FileHeaderGuid = sumSuppSt.FileHeaderGuid;
            sumSuppStWork.UpdEmployeeCode = sumSuppSt.UpdEmployeeCode;
            sumSuppStWork.UpdAssemblyId1 = sumSuppSt.UpdAssemblyId1;
            sumSuppStWork.UpdAssemblyId2 = sumSuppSt.UpdAssemblyId2;
            sumSuppStWork.LogicalDeleteCode = sumSuppSt.LogicalDeleteCode;
            sumSuppStWork.SumSectionCd = sumSuppSt.SumSectionCd;
            sumSuppStWork.SumSupplierCd = sumSuppSt.SumSupplierCd;
            sumSuppStWork.SectionCode = sumSuppSt.SectionCode;
            sumSuppStWork.SupplierCode = sumSuppSt.SupplierCode;

            return sumSuppStWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(D��E)
        /// </summary>
        /// <param name="sumSuppStWork">�d����}�X�^(�����ݒ�)���[�N�N���X</param>
        /// <returns>�d����}�X�^(�����ݒ�)�N���X</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : FSI�֓� �a�G</br>
        /// <br>Date	   : 2012/08/29</br>
        /// </remarks>
        private SumSuppSt CopyToSumSuppStFromSumSuppStWork(SumSuppStWork sumSuppStWork)
        {
            SumSuppSt sumSuppSt = new SumSuppSt();

            sumSuppSt.CreateDateTime = sumSuppStWork.CreateDateTime;
            sumSuppSt.UpdateDateTime = sumSuppStWork.UpdateDateTime;
            sumSuppSt.EnterpriseCode = sumSuppStWork.EnterpriseCode;
            sumSuppSt.FileHeaderGuid = sumSuppStWork.FileHeaderGuid;
            sumSuppSt.UpdEmployeeCode = sumSuppStWork.UpdEmployeeCode;
            sumSuppSt.UpdAssemblyId1 = sumSuppStWork.UpdAssemblyId1;
            sumSuppSt.UpdAssemblyId2 = sumSuppStWork.UpdAssemblyId2;
            sumSuppSt.LogicalDeleteCode = sumSuppStWork.LogicalDeleteCode;
            sumSuppSt.SumSectionCd = sumSuppStWork.SumSectionCd;
            sumSuppSt.SumSupplierCd = sumSuppStWork.SumSupplierCd;
            sumSuppSt.SectionCode = sumSuppStWork.SectionCode;
            sumSuppSt.SupplierCode = sumSuppStWork.SupplierCode;

            return sumSuppSt;
        }

        #endregion �� Private Methods
    }
}
