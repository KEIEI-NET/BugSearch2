using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���Ӑ�}�X�^(�|���O���[�v)�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���Ӑ�}�X�^(�|���O���[�v)�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer	: 30414 �E�@�K�j</br>
    /// <br>Date		: 2008/10/03</br>
    /// <br>Update Note : 2009/10/19 ��r�� ���Ӑ�|���O���[�v�R�[�h���擾���郁�\�b�h�̒ǉ��B</br>
    /// <br>Update Note : 2012/04/23 �{�� �@�|��G������0000����F�����Q�̏C��</br>
    //----------------------------------------------------------------------------//
    // �Ǘ��ԍ�              �쐬�S�� : �g���@�F��
    // �C �� ��  2013/01/18  �C�����e : 2013/03/13�z�M�@SCM��Q��10475�Ή� ���x���P
    //----------------------------------------------------------------------------//
    /// </remarks>
    public class CustRateGroupAcs
    {
        // ADD 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        object retObjAuto = null;
        // ADD 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        #region �� Private Members

        private ICustRateGroupDB _iCustRateGroupDB = null;

        #endregion �� Private Members


        # region �� Constructor

        /// <summary>
        /// ���Ӑ�}�X�^(�|���O���[�v)�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�|���O���[�v)�A�N�Z�X�N���X�̐V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public CustRateGroupAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iCustRateGroupDB = (ICustRateGroupDB)MediationCustRateGroupDB.GetCustRateGroupDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iCustRateGroupDB = null;
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
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if ((this._iCustRateGroupDB == null) || (this._iCustRateGroupDB == null))
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�|���O���[�v)�Ǎ�����
        /// </summary>
        /// <param name="custRateGroup">���Ӑ�}�X�^(�|���O���[�v)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="pureCode">�����敪</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�|���O���[�v)���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public int Read(out CustRateGroup custRateGroup, string enterpriseCode, int customerCode, int pureCode, int makerCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            custRateGroup = new CustRateGroup();

            try
            {
                // ���������ݒ�
                CustRateGroupWork paraWork = new CustRateGroupWork();
                paraWork.EnterpriseCode = enterpriseCode;
                paraWork.CustomerCode = customerCode;
                paraWork.PureCode = pureCode;
                paraWork.GoodsMakerCd = makerCode;

                object paraObj = paraWork;

                status = this._iCustRateGroupDB.Read(ref paraObj, 0);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;

                    // �N���X�����o�R�s�[����(D��E)
                    custRateGroup = CopyToCustRateGroupFromCustRateGroupWork((CustRateGroupWork)retList[0]);
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�|���O���[�v)�擾����
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�}�X�^(�|���O���[�v)���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�|���O���[�v)���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public int Search(out ArrayList custRateGroupList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out custRateGroupList, enterpriseCode, 0, 0, logicalMode);

            return (status);
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�|���O���[�v)�擾����
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�}�X�^(�|���O���[�v)���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�|���O���[�v)���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public int Search(out ArrayList custRateGroupList, string enterpriseCode, int customerCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out custRateGroupList, enterpriseCode, customerCode, 0, logicalMode);

            return (status);
        }

        // ADD 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���Ӑ�}�X�^(�|���O���[�v)�擾����
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�}�X�^(�|���O���[�v)���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�|���O���[�v)���擾���܂��B</br>
        /// </remarks>
        public int SearchForAuto(out ArrayList custRateGroupList, string enterpriseCode, int customerCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            custRateGroupList = new ArrayList();

            try
            {
                // ���������ݒ�
                CustRateGroupWork paraWork = new CustRateGroupWork();
                paraWork.EnterpriseCode = enterpriseCode;
                paraWork.CustomerCode = customerCode;
                paraWork.PureCode = 0;

                object paraObj = paraWork;

                ArrayList retList = new ArrayList();
                if (retObjAuto == null)
                {
                    retObjAuto = retList;
                    status = this._iCustRateGroupDB.Search(ref retObjAuto, paraObj, 0, logicalMode);
                    if (status == 0)
                    {
                        retList = retObjAuto as ArrayList;
                        foreach (CustRateGroupWork custRateGroupWork in retList)
                        {
                            // �N���X�����o�R�s�[����(D��E)
                            custRateGroupList.Add(CopyToCustRateGroupFromCustRateGroupWork(custRateGroupWork));
                        }
                    }
                }
                else
                {
                    retList = retObjAuto as ArrayList;
                    foreach (CustRateGroupWork custRateGroupWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        custRateGroupList.Add(CopyToCustRateGroupFromCustRateGroupWork(custRateGroupWork));
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return status;
        }
        // ADD 2013/01/18 T.Yoshioka 2013/03/13�z�M�\�� SCM��Q��10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// ���Ӑ�}�X�^(�|���O���[�v)�擾����
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�}�X�^(�|���O���[�v)���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="pureCode">�����敪</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�|���O���[�v)���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public int Search(out ArrayList custRateGroupList, string enterpriseCode, int customerCode, int pureCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out custRateGroupList, enterpriseCode, customerCode, pureCode, logicalMode);

            return (status);
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�|���O���[�v)�X�V����
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�}�X�^(�|���O���[�v)���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�|���O���[�v)���X�V���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public int Write(ref ArrayList custRateGroupList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (CustRateGroup custRateGroup in custRateGroupList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    workList.Add(CopyToCustRateGroupWorkFromCustRateGroup(custRateGroup));
                }

                object paraObj = workList;

                status = this._iCustRateGroupDB.Write(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    custRateGroupList = new ArrayList();
                    foreach (CustRateGroupWork custRateGroupWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        custRateGroupList.Add(CopyToCustRateGroupFromCustRateGroupWork(custRateGroupWork));
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
        /// ���Ӑ�}�X�^(�|���O���[�v)�_���폜����
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�}�X�^(�|���O���[�v)���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�|���O���[�v)��_���폜���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList custRateGroupList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (CustRateGroup custRateGroup in custRateGroupList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    workList.Add(CopyToCustRateGroupWorkFromCustRateGroup(custRateGroup));
                }

                object paraObj = workList;

                // �_���폜����
                status = this._iCustRateGroupDB.LogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    custRateGroupList = new ArrayList();
                    foreach (CustRateGroupWork custRateGroupWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        custRateGroupList.Add(CopyToCustRateGroupFromCustRateGroupWork(custRateGroupWork));
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
        /// ���Ӑ�}�X�^(�|���O���[�v)�폜����
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�}�X�^(�|���O���[�v)���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�|���O���[�v)���폜���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public int Delete(ArrayList custRateGroupList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (CustRateGroup custRateGroup in custRateGroupList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    workList.Add(CopyToCustRateGroupWorkFromCustRateGroup(custRateGroup));
                }

                // ArrayList����z��𐶐�
                CustRateGroupWork[] works = (CustRateGroupWork[])workList.ToArray(typeof(CustRateGroupWork));

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(works);

                // �����폜����
                status = this._iCustRateGroupDB.Delete(parabyte);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�|���O���[�v)��������
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�}�X�^(�|���O���[�v)���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�|���O���[�v)�𕜊����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        public int Revival(ref ArrayList custRateGroupList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (CustRateGroup custRateGroup in custRateGroupList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    workList.Add(CopyToCustRateGroupWorkFromCustRateGroup(custRateGroup));
                }

                object paraObj = workList;

                // ��������
                status = this._iCustRateGroupDB.RevivalLogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    custRateGroupList = new ArrayList();
                    foreach (CustRateGroupWork custRateGroupWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        custRateGroupList.Add(CopyToCustRateGroupFromCustRateGroupWork(custRateGroupWork));
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
        /// ���Ӑ�|���O���[�v�R�[�h�̎擾�B
        /// </summary>
        /// <param name="custRateGrpCodeList">���Ӑ�}�X�^(�|���O���[�v)���X�g</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <remarks>
        /// <br>Note      : ���Ӑ�|���O���[�v�R�[�h���擾���܂��B</br>
        /// <br>Programmer: ��r��</br>
        /// <br>Date      : 2009/10/19</br>
        /// </remarks>
        public void GetCustRateGrp(ArrayList custRateGrpCodeList, int customerCode, int goodsMakerCode, out int custRateGrpCode)
        {
            // -- UPD 2012/04/23 ------------------------------------->>>>
            //custRateGrpCode = 0;
            custRateGrpCode = -1;
            // -- UPD 2012/04/23 -------------------------------------<<<<

            // �����^�D�Ǐ��擾
            int pureCode = (goodsMakerCode < 1000) ? 0 : 1;

            // �P�ƃL�[����
            foreach (CustRateGroup custRateGroup in custRateGrpCodeList)
            {
                // -- UPD 2012/04/23 ------------------------------------->>>>
                //if ((customerCode == custRateGroup.CustomerCode) && (goodsMakerCode == custRateGroup.GoodsMakerCd) && (pureCode == custRateGroup.PureCode))
                if ((customerCode == custRateGroup.CustomerCode) &&
                    (goodsMakerCode == custRateGroup.GoodsMakerCd) &&
                    (pureCode == custRateGroup.PureCode) &&
                    (custRateGroup.CustRateGrpCode >= 0))
                // -- UPD 2012/04/23 -------------------------------------<<<<
                {
                    custRateGrpCode = custRateGroup.CustRateGrpCode;
                    return;
                }
            }

            // ���ʃL�[����
            foreach (CustRateGroup custRateGroup in custRateGrpCodeList)
            {
                if ((customerCode == custRateGroup.CustomerCode) && (0 == custRateGroup.GoodsMakerCd) && (pureCode == custRateGroup.PureCode))
                {
                    custRateGrpCode = custRateGroup.CustRateGrpCode;
                    return;
                }
            }
        }

        #endregion �� Public Methods


        #region �� Private Methods
        /// <summary>
        /// ���Ӑ�}�X�^(�|���O���[�v)�擾����
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�}�X�^(�|���O���[�v)���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="pureCode">�����敪</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^(�|���O���[�v)���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private int SearchProc(out ArrayList custRateGroupList, string enterpriseCode, int customerCode, int pureCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            custRateGroupList = new ArrayList();

            try
            {
                // ���������ݒ�
                CustRateGroupWork paraWork = new CustRateGroupWork();
                paraWork.EnterpriseCode = enterpriseCode;
                paraWork.CustomerCode = customerCode;
                paraWork.PureCode = pureCode;

                object paraObj = paraWork;

                ArrayList retList = new ArrayList();
                object retObj = retList;
                status = this._iCustRateGroupDB.Search(ref retObj, paraObj, 0, logicalMode);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    foreach (CustRateGroupWork custRateGroupWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        custRateGroupList.Add(CopyToCustRateGroupFromCustRateGroupWork(custRateGroupWork));
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
        /// <param name="custRateGroup">���Ӑ�}�X�^(�|���O���[�v)�N���X</param>
        /// <returns>���Ӑ�}�X�^(�|���O���[�v)���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private CustRateGroupWork CopyToCustRateGroupWorkFromCustRateGroup(CustRateGroup custRateGroup)
        {
            CustRateGroupWork custRateGroupWork = new CustRateGroupWork();

            custRateGroupWork.CreateDateTime = custRateGroup.CreateDateTime;
            custRateGroupWork.UpdateDateTime = custRateGroup.UpdateDateTime;
            custRateGroupWork.EnterpriseCode = custRateGroup.EnterpriseCode;
            custRateGroupWork.FileHeaderGuid = custRateGroup.FileHeaderGuid;
            custRateGroupWork.UpdEmployeeCode = custRateGroup.UpdEmployeeCode;
            custRateGroupWork.UpdAssemblyId1 = custRateGroup.UpdAssemblyId1;
            custRateGroupWork.UpdAssemblyId2 = custRateGroup.UpdAssemblyId2;
            custRateGroupWork.LogicalDeleteCode = custRateGroup.LogicalDeleteCode;
            custRateGroupWork.CustomerCode = custRateGroup.CustomerCode;
            custRateGroupWork.PureCode = custRateGroup.PureCode;
            custRateGroupWork.GoodsMakerCd = custRateGroup.GoodsMakerCd;
            custRateGroupWork.CustRateGrpCode = custRateGroup.CustRateGrpCode;

            return custRateGroupWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(D��E)
        /// </summary>
        /// <param name="custRateGroupWork">���Ӑ�}�X�^(�|���O���[�v)���[�N�N���X</param>
        /// <returns>���Ӑ�}�X�^(�|���O���[�v)�N���X</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/10/03</br>
        /// </remarks>
        private CustRateGroup CopyToCustRateGroupFromCustRateGroupWork(CustRateGroupWork custRateGroupWork)
        {
            CustRateGroup custRateGroup = new CustRateGroup();

            custRateGroup.CreateDateTime = custRateGroupWork.CreateDateTime;
            custRateGroup.UpdateDateTime = custRateGroupWork.UpdateDateTime;
            custRateGroup.EnterpriseCode = custRateGroupWork.EnterpriseCode;
            custRateGroup.FileHeaderGuid = custRateGroupWork.FileHeaderGuid;
            custRateGroup.UpdEmployeeCode = custRateGroupWork.UpdEmployeeCode;
            custRateGroup.UpdAssemblyId1 = custRateGroupWork.UpdAssemblyId1;
            custRateGroup.UpdAssemblyId2 = custRateGroupWork.UpdAssemblyId2;
            custRateGroup.LogicalDeleteCode = custRateGroupWork.LogicalDeleteCode;
            custRateGroup.CustomerCode = custRateGroupWork.CustomerCode;
            custRateGroup.PureCode = custRateGroupWork.PureCode;
            custRateGroup.GoodsMakerCd = custRateGroupWork.GoodsMakerCd;
            custRateGroup.CustRateGrpCode = custRateGroupWork.CustRateGrpCode;

            return custRateGroup;
        }

        #endregion �� Private Methods
    }
}
