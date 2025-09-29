using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// BL�R�[�h�K�C�h�}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: BL�R�[�h�K�C�h�}�X�^�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer	: 30414 �E�@�K�j</br>
    /// <br>Date		: 2008/09/30</br>
    /// </remarks>
    public class BLCodeGuideAcs
    {
        #region �� Constants

        #endregion �� Constants


        #region �� Private Members

        private IBLCodeGuideDB _iBLCodeGuideDB = null;

        #endregion �� Private Members


        # region �� Constructor

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^�A�N�Z�X�N���X�̐V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public BLCodeGuideAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iBLCodeGuideDB = (IBLCodeGuideDB)MediationBLCodeGuideDB.GetBLCodeGuideDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iBLCodeGuideDB = null;
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
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if ((this._iBLCodeGuideDB == null) || (this._iBLCodeGuideDB == null))
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^�Ǎ�����
        /// </summary>
        /// <param name="bLCodeGuide">BL�R�[�h�K�C�h�}�X�^</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="bLCodeDspPage">BL�R�[�h�\����</param>
        /// <param name="bLCodeDspRow">BL�R�[�h�\���s</param>
        /// <param name="bLCodeDspCol">BL�R�[�h�\����</param>
        /// <param name="bLGoodsCode">BL�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public int Read(out BLCodeGuide bLCodeGuide, string enterpriseCode, string sectionCode, int bLCodeDspPage,
                        int bLCodeDspRow, int bLCodeDspCol, int bLGoodsCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            bLCodeGuide = new BLCodeGuide();

            try
            {
                // ���������ݒ�
                BLCodeGuideWork paraWork = new BLCodeGuideWork();
                paraWork.EnterpriseCode = enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.BLCodeDspPage = bLCodeDspPage;
                paraWork.BLCodeDspRow = bLCodeDspRow;
                paraWork.BLCodeDspCol = bLCodeDspCol;
                paraWork.BLGoodsCode = bLGoodsCode;

                object paraObj = paraWork;

                status = this._iBLCodeGuideDB.Read(ref paraObj, 0);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;

                    // �N���X�����o�R�s�[����(D��E)
                    bLCodeGuide = CopyToBLCodeGuideFromBLCodeGuideWork((BLCodeGuideWork)retList[0]);
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^�擾����
        /// </summary>
        /// <param name="bLCodeGuideList">BL�R�[�h�K�C�h�}�X�^���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public int Search(out ArrayList bLCodeGuideList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out bLCodeGuideList, enterpriseCode, "", 0, logicalMode);

            return (status);
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^�擾����
        /// </summary>
        /// <param name="bLCodeGuideList">BL�R�[�h�K�C�h�}�X�^���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public int Search(out ArrayList bLCodeGuideList, string enterpriseCode, string sectionCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out bLCodeGuideList, enterpriseCode, sectionCode, 0, logicalMode);

            return (status);
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^�擾����
        /// </summary>
        /// <param name="bLCodeGuideList">BL�R�[�h�K�C�h�}�X�^���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="bLGoodsCode">BL�R�[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public int Search(out ArrayList bLCodeGuideList, string enterpriseCode, string sectionCode, int bLGoodsCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = SearchProc(out bLCodeGuideList, enterpriseCode, sectionCode, bLGoodsCode, logicalMode);

            return (status);
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^�X�V����
        /// </summary>
        /// <param name="bLCodeGuideList">BL�R�[�h�K�C�h�}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^���X�V���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public int Write(ref ArrayList bLCodeGuideList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (BLCodeGuide bLCodeGuide in bLCodeGuideList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    workList.Add(CopyToBLCodeGuideWorkFromBLCodeGuide(bLCodeGuide));
                }

                object paraObj = workList;

                status = this._iBLCodeGuideDB.Write(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    bLCodeGuideList = new ArrayList();
                    foreach (BLCodeGuideWork bLCodeGuideWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        bLCodeGuideList.Add(CopyToBLCodeGuideFromBLCodeGuideWork(bLCodeGuideWork));
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
        /// BL�R�[�h�K�C�h�}�X�^�_���폜����
        /// </summary>
        /// <param name="bLCodeGuideList">BL�R�[�h�K�C�h�}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^��_���폜���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList bLCodeGuideList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (BLCodeGuide bLCodeGuide in bLCodeGuideList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    workList.Add(CopyToBLCodeGuideWorkFromBLCodeGuide(bLCodeGuide));
                }

                object paraObj = workList;

                // �_���폜����
                status = this._iBLCodeGuideDB.LogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    bLCodeGuideList = new ArrayList();
                    foreach (BLCodeGuideWork bLCodeGuideWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        bLCodeGuideList.Add(CopyToBLCodeGuideFromBLCodeGuideWork(bLCodeGuideWork));
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
        /// BL�R�[�h�K�C�h�}�X�^�폜����
        /// </summary>
        /// <param name="bLCodeGuideList">BL�R�[�h�K�C�h�}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^���폜���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public int Delete(ArrayList bLCodeGuideList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (BLCodeGuide bLCodeGuide in bLCodeGuideList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    workList.Add(CopyToBLCodeGuideWorkFromBLCodeGuide(bLCodeGuide));
                }

                object paraObj = workList;

                // �����폜����
                status = this._iBLCodeGuideDB.Delete(paraObj);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^��������
        /// </summary>
        /// <param name="bLCodeGuideList">BL�R�[�h�K�C�h�}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^�𕜊����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public int Revival(ref ArrayList bLCodeGuideList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();
                foreach (BLCodeGuide bLCodeGuide in bLCodeGuideList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    workList.Add(CopyToBLCodeGuideWorkFromBLCodeGuide(bLCodeGuide));
                }

                object paraObj = workList;

                // ��������
                status = this._iBLCodeGuideDB.RevivalLogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = paraObj as ArrayList;
                    bLCodeGuideList = new ArrayList();
                    foreach (BLCodeGuideWork bLCodeGuideWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        bLCodeGuideList.Add(CopyToBLCodeGuideFromBLCodeGuideWork(bLCodeGuideWork));
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
        /// BL�R�[�h�K�C�h�}�X�^�擾����
        /// </summary>
        /// <param name="bLCodeGuideList">BL�R�[�h�K�C�h�}�X�^���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="bLGoodsCode">BL�R�[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private int SearchProc(out ArrayList bLCodeGuideList, string enterpriseCode, string sectionCode, int bLGoodsCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            bLCodeGuideList = new ArrayList();

            try
            {
                // ���������ݒ�
                BLCodeGuideWork paraWork = new BLCodeGuideWork();
                paraWork.EnterpriseCode = enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.BLGoodsCode = bLGoodsCode;

                object paraObj = paraWork;
                object retObj = bLCodeGuideList;

                status = this._iBLCodeGuideDB.Search(ref retObj, paraObj, 0, logicalMode);
                if (status == 0)
                {
                    ArrayList retList = retObj as ArrayList;
                    foreach (BLCodeGuideWork bLCodeGuideWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        bLCodeGuideList.Add(CopyToBLCodeGuideFromBLCodeGuideWork(bLCodeGuideWork));
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
        /// <param name="bLCodeGuide">BL�R�[�h�K�C�h�N���X</param>
        /// <returns>BL�R�[�h�K�C�h���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private BLCodeGuideWork CopyToBLCodeGuideWorkFromBLCodeGuide(BLCodeGuide bLCodeGuide)
        {
            BLCodeGuideWork bLCodeGuideWork = new BLCodeGuideWork();

            bLCodeGuideWork.CreateDateTime = bLCodeGuide.CreateDateTime;        // �쐬����
            bLCodeGuideWork.UpdateDateTime = bLCodeGuide.UpdateDateTime;        // �X�V����
            bLCodeGuideWork.EnterpriseCode = bLCodeGuide.EnterpriseCode;        // ��ƃR�[�h
            bLCodeGuideWork.FileHeaderGuid = bLCodeGuide.FileHeaderGuid;        // GUID
            bLCodeGuideWork.UpdEmployeeCode = bLCodeGuide.UpdEmployeeCode;      // �X�V�]�ƈ��R�[�h
            bLCodeGuideWork.UpdAssemblyId1 = bLCodeGuide.UpdAssemblyId1;        // �X�V�A�Z���u��ID1
            bLCodeGuideWork.UpdAssemblyId2 = bLCodeGuide.UpdAssemblyId2;        // �X�V�A�Z���u��ID2
            bLCodeGuideWork.LogicalDeleteCode = bLCodeGuide.LogicalDeleteCode;  // �_���폜�敪
            bLCodeGuideWork.SectionCode = bLCodeGuide.SectionCode;              // ���_�R�[�h
            bLCodeGuideWork.BLCodeDspPage = bLCodeGuide.BLCodeDspPage;          // BL�R�[�h�\����
            bLCodeGuideWork.BLCodeDspRow = bLCodeGuide.BLCodeDspRow;            // BL�R�[�h�\���s
            bLCodeGuideWork.BLCodeDspCol = bLCodeGuide.BLCodeDspCol;            // BL�R�[�h�\����
            bLCodeGuideWork.BLGoodsCode = bLCodeGuide.BLGoodsCode;              // BL�R�[�h
            bLCodeGuideWork.BLGoodsName = bLCodeGuide.BLGoodsName;              // BL�R�[�h��

            return bLCodeGuideWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(D��E)
        /// </summary>
        /// <param name="bLCodeGuideWork">BL�R�[�h���[�N�N���X</param>
        /// <returns>BL�R�[�h�K�C�h�N���X</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private BLCodeGuide CopyToBLCodeGuideFromBLCodeGuideWork(BLCodeGuideWork bLCodeGuideWork)
        {
            BLCodeGuide bLCodeGuide = new BLCodeGuide();

            bLCodeGuide.CreateDateTime = bLCodeGuideWork.CreateDateTime;        // �쐬����
            bLCodeGuide.UpdateDateTime = bLCodeGuideWork.UpdateDateTime;        // �X�V����
            bLCodeGuide.EnterpriseCode = bLCodeGuideWork.EnterpriseCode;        // ��ƃR�[�h
            bLCodeGuide.FileHeaderGuid = bLCodeGuideWork.FileHeaderGuid;        // GUID
            bLCodeGuide.UpdEmployeeCode = bLCodeGuideWork.UpdEmployeeCode;      // �X�V�]�ƈ��R�[�h
            bLCodeGuide.UpdAssemblyId1 = bLCodeGuideWork.UpdAssemblyId1;        // �X�V�A�Z���u��ID1
            bLCodeGuide.UpdAssemblyId2 = bLCodeGuideWork.UpdAssemblyId2;        // �X�V�A�Z���u��ID2
            bLCodeGuide.LogicalDeleteCode = bLCodeGuideWork.LogicalDeleteCode;  // �_���폜�敪
            bLCodeGuide.SectionCode = bLCodeGuideWork.SectionCode;              // ���_�R�[�h
            bLCodeGuide.BLCodeDspPage = bLCodeGuideWork.BLCodeDspPage;          // BL�R�[�h�\����
            bLCodeGuide.BLCodeDspRow = bLCodeGuideWork.BLCodeDspRow;            // BL�R�[�h�\���s
            bLCodeGuide.BLCodeDspCol = bLCodeGuideWork.BLCodeDspCol;            // BL�R�[�h�\����
            bLCodeGuide.BLGoodsCode = bLCodeGuideWork.BLGoodsCode;              // BL�R�[�h
            bLCodeGuide.BLGoodsName = bLCodeGuideWork.BLGoodsName;              // BL�R�[�h��

            return bLCodeGuide;
        }
        #endregion �� Private Methods
    }
}
