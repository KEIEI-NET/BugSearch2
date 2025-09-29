using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �|���}�X�^�ꊇ�C���E�o�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���}�X�^�ꊇ�C���E�o�^�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 30414 �E �K�j</br>
    /// <br>Date       : 2009/01/19</br>
    /// <br>UpdateNote : Redmine#37884 �|���}�X�^�ꊇ�o�^�C��������Q�̑Ή��˗�</br>
    /// <br>Programmer : liuyu</br>
    /// <br>Date       : 2013/07/08</br>
    /// </remarks>
    public class RatePackageUpdateAcs
    {
        #region �� Private Members
        // �|���}�X�^�����[�g
        private IRateDB _iRateDB = null;
        #endregion �� Private Members


        #region �� Construcstor
        /// <summary>
        /// �|���}�X�^�ꊇ�C���E�o�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�ꊇ�C���E�o�^�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2009/01/19</br>
        /// </remarks>
        public RatePackageUpdateAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iRateDB = (IRateDB)MediationRateDB.GetRateDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iRateDB = null;
            }
        }
        #endregion �� Construcstor


        #region �� Public Methods
        /// <summary>
        /// �|���}�X�^�X�V����
        /// </summary>
        /// <param name="saveList">�ۑ����X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^���X�V���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2009/01/19</br>
        /// </remarks>
        public int Write(ArrayList saveList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraRateList = new ArrayList();

                for (int i = 0; i < saveList.Count; i++)
                {
                    // �N���X�����o�R�s�[����
                    paraRateList.Add(CopyToRateWorkFromRate((Rate)saveList[i]));
                }

                object paraObj = (object)paraRateList;

                status = this._iRateDB.Write(ref paraObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// �|���}�X�^�폜����
        /// </summary>
        /// <param name="deleteList">�폜���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^���폜���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2009/01/19</br>
        /// </remarks>
        public int Delete(ArrayList deleteList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                byte[] paraRateWork = null;
                ArrayList rateWorkList = new ArrayList();

                for (int i = 0; i < deleteList.Count; i++)
                {
                    // �N���X�����o�R�s�[����
                    rateWorkList.Add(CopyToRateWorkFromRate((Rate)deleteList[i]));
                }

                // ArrayList����z��𐶐�
                RateWork[] rateWorks = (RateWork[])rateWorkList.ToArray(typeof(RateWork));

                // �V���A���C�Y
                paraRateWork = XmlByteSerializer.Serialize(rateWorks);

                // �����폜����
                //status = this._iRateDB.Delete(paraRateWork);
                status = this._iRateDB.DeleteRate(paraRateWork);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// �|���}�X�^��������
        /// </summary>
        /// <param name="rateSearchResultList">�|���}�X�^�������ʃ��X�g</param>
        /// <param name="rateSearchParam">�|���}�X�^��������</param>
        /// <remarks>
        /// <br>Note       : �|���}�X�^���������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2009/01/19</br>
        /// </remarks>
        public int Search(out List<RateSearchResult> rateSearchResultList, RateSearchParam rateSearchParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            rateSearchResultList = new List<RateSearchResult>();

            try
            {
                // �N���X�����o�R�s�[����(E��D)
                RateSearchParamWork paraWork = CopyToRateSearchParamWorkFromRateSearchParam(rateSearchParam);

                object paraObj = paraWork;
                object retObj;

                //status = this._iRateDB.SearchRate(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);//DEL 2013/07/08 �|���}�X�^�ꊇ�o�^�C��������Q�̑Ή��˗�
                status = this._iRateDB.SearchRate(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData01);//ADD 2013/07/08 �|���}�X�^�ꊇ�o�^�C��������Q�̑Ή��˗�
                if (status == 0)
                {
                    ArrayList retWorkList = retObj as ArrayList;

                    foreach (RateSearchResultWork retWork in retWorkList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        rateSearchResultList.Add(CopyToRateSearchResultFromRateSearchResultWork(retWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                rateSearchResultList = new List<RateSearchResult>();
            }

            return (status);
        }

        #endregion �� Public Methods


        #region �� Private Methods
        /// <summary>
        /// �N���X�����o�R�s�[����(E��D)
        /// </summary>
        /// <param name="rateSearchParam">�|���}�X�^��������</param>
        /// <returns>�|���}�X�^�����������[�N</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2009/01/19</br>
        /// </remarks>
        private RateSearchParamWork CopyToRateSearchParamWorkFromRateSearchParam(RateSearchParam rateSearchParam)
        {
            RateSearchParamWork paraWork = new RateSearchParamWork();

            paraWork.EnterpriseCode = rateSearchParam.EnterpriseCode;       // ��ƃR�[�h
            paraWork.SectionCode = rateSearchParam.SectionCode;             // ���_�R�[�h
            paraWork.SupplierCd = rateSearchParam.SupplierCd;               // �d����R�[�h
            paraWork.GoodsRateGrpCode = rateSearchParam.GoodsRateGrpCode;   // ���i�|���O���[�v�R�[�h
            paraWork.GoodsMakerCd = rateSearchParam.GoodsMakerCd;           // ���[�J�[�R�[�h
            paraWork.CustomerCode = rateSearchParam.CustomerCode;           // ���Ӑ�R�[�h
            paraWork.CustRateGrpCode = rateSearchParam.CustRateGrpCode;     // ���Ӑ�|���O���[�v�R�[�h
            paraWork.PrmSectionCode = rateSearchParam.PrmSectionCode;       // ���O�C�����_�R�[�h

            return paraWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(D��E)
        /// </summary>
        /// <param name="rateSearchResultWork">�|���}�X�^�������ʃ��[�N</param>
        /// <returns>�|���}�X�^��������</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2009/01/19</br>
        /// </remarks>
        private RateSearchResult CopyToRateSearchResultFromRateSearchResultWork(RateSearchResultWork rateSearchResultWork)
        {
            RateSearchResult result = new RateSearchResult();

            // �|���}�X�^���擾
            result.CreateDateTime = rateSearchResultWork.CreateDateTime;            // �쐬����
            result.UpdateDateTime = rateSearchResultWork.UpdateDateTime;            // �X�V����
            result.EnterpriseCode = rateSearchResultWork.EnterpriseCode;            // ��ƃR�[�h
            result.FileHeaderGuid = rateSearchResultWork.FileHeaderGuid;            // GUID
            result.UpdEmployeeCode = rateSearchResultWork.UpdEmployeeCode;          // �X�V�]�ƈ��R�[�h
            result.UpdAssemblyId1 = rateSearchResultWork.UpdAssemblyId1;            // �X�V�A�Z���u��ID1
            result.UpdAssemblyId2 = rateSearchResultWork.UpdAssemblyId2;            // �X�V�A�Z���u��ID2
            result.LogicalDeleteCode = rateSearchResultWork.LogicalDeleteCode;      // �_���폜�敪
            result.SectionCode = rateSearchResultWork.SectionCode;                  // ���_�R�[�h
            result.UnitRateSetDivCd = rateSearchResultWork.UnitRateSetDivCd;        // �P���|���ݒ�敪
            result.UnitPriceKind = rateSearchResultWork.UnitPriceKind;              // �P�����
            result.RateSettingDivide = rateSearchResultWork.RateSettingDivide;      // �|���ݒ�敪
            result.RateMngGoodsCd = rateSearchResultWork.RateMngGoodsCd;            // �|���ݒ�敪�i���i�j
            result.RateMngGoodsNm = rateSearchResultWork.RateMngGoodsNm;            // �|���ݒ薼�́i���i�j
            result.RateMngCustCd = rateSearchResultWork.RateMngCustCd;              // �|���ݒ�敪�i���Ӑ�j
            result.RateMngCustNm = rateSearchResultWork.RateMngCustNm;              // �|���ݒ薼�́i���Ӑ�j
            result.GoodsMakerCd = rateSearchResultWork.GoodsMakerCd;                // ���i���[�J�[�R�[�h
            result.GoodsNo = rateSearchResultWork.GoodsNo;                          // ���i�ԍ�
            result.GoodsRateRank = rateSearchResultWork.GoodsRateRank;              // ���i�|�������N
            result.GoodsRateGrpCode = rateSearchResultWork.GoodsRateGrpCode;        // ���i�|���O���[�v�R�[�h
            result.BLGroupCode = rateSearchResultWork.BLGroupCode;                  // BL�O���[�v�R�[�h
            result.BLGoodsCode = rateSearchResultWork.BLGoodsCode;                  // BL���i�R�[�h
            result.CustomerCode = rateSearchResultWork.CustomerCode;                // ���Ӑ�R�[�h
            result.CustRateGrpCode = rateSearchResultWork.CustRateGrpCode;          // ���Ӑ�|���O���[�v�R�[�h
            result.SupplierCd = rateSearchResultWork.SupplierCd;                    // �d����R�[�h
            result.LotCount = rateSearchResultWork.LotCount;                        // ���b�g��
            result.PriceFl = rateSearchResultWork.PriceFl;                          // ���i�i�����j
            result.RateVal = rateSearchResultWork.RateVal;                          // �|��
            result.UpRate = rateSearchResultWork.UpRate;                            // UP��
            result.GrsProfitSecureRate = rateSearchResultWork.GrsProfitSecureRate;  // �e���m�ۗ�
            result.UnPrcFracProcUnit = rateSearchResultWork.UnPrcFracProcUnit;      // �P���[�������P��
            result.UnPrcFracProcDiv = rateSearchResultWork.UnPrcFracProcDiv;        // �P���[�������敪
            // �D�ǐݒ�}�X�^�A���i�Ǘ����}�X�^���擾
            result.PrmGoodsMGroup = rateSearchResultWork.PrmGoodsMGroup;            // ���i�����ރR�[�h
            result.PrmTbsPartsCode = rateSearchResultWork.PrmTbsPartsCode;          // BL�R�[�h
            result.BLGoodsHalfName = rateSearchResultWork.BLGoodsHalfName;          // BL���i�R�[�h���́i���p�j
            result.PrmPartsMakerCd = rateSearchResultWork.PrmPartsMakerCd;          // ���i���[�J�[�R�[�h
            result.MakerName = rateSearchResultWork.MakerName;                      // ���[�J�[����
            result.GoodsSupplierCd = rateSearchResultWork.GoodsSupplierCd;          // �d����R�[�h

            return result;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�|���ݒ�N���X�ˊ|���ݒ胏�[�N�N���X�j
        /// </summary>
        /// <param name="rate">�|���ݒ�N���X</param>
        /// <returns>RateWork</returns>
        /// <remarks>
        /// <br>Note       : �|���ݒ�N���X����|���ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2009/01/19</br>
        /// </remarks>
        private RateWork CopyToRateWorkFromRate(Rate rate)
        {
            RateWork rateWork = new RateWork();

            rateWork.CreateDateTime = rate.CreateDateTime;              // �쐬����
            rateWork.UpdateDateTime = rate.UpdateDateTime;              // �X�V����
            rateWork.EnterpriseCode = rate.EnterpriseCode;              // ��ƃR�[�h
            rateWork.FileHeaderGuid = rate.FileHeaderGuid;              // GUID
            rateWork.UpdEmployeeCode = rate.UpdEmployeeCode;            // �X�V�]�ƈ��R�[�h
            rateWork.UpdAssemblyId1 = rate.UpdAssemblyId1;              // �X�V�A�Z���u��ID1
            rateWork.UpdAssemblyId2 = rate.UpdAssemblyId2;              // �X�V�A�Z���u��ID2
            rateWork.LogicalDeleteCode = rate.LogicalDeleteCode;        // �_���폜�敪
            rateWork.SectionCode = rate.SectionCode;                    // ���_�R�[�h
            rateWork.UnitRateSetDivCd = rate.UnitRateSetDivCd;          // �P���|���ݒ�敪
            rateWork.UnitPriceKind = rate.UnitPriceKind;                // �P�����
            rateWork.RateSettingDivide = rate.RateSettingDivide;        // �|���ݒ�敪
            rateWork.RateMngGoodsCd = rate.RateMngGoodsCd;              // �|���ݒ�敪�i���i�j
            rateWork.RateMngGoodsNm = rate.RateMngGoodsNm;              // �|���ݒ薼�́i���i�j
            rateWork.RateMngCustCd = rate.RateMngCustCd;                // �|���ݒ�敪�i���Ӑ�j
            rateWork.RateMngCustNm = rate.RateMngCustNm;                // �|���ݒ薼�́i���Ӑ�j
            rateWork.GoodsMakerCd = rate.GoodsMakerCd;                  // ���i���[�J�[�R�[�h
            rateWork.GoodsNo = rate.GoodsNo;                            // ���i�ԍ�
            rateWork.GoodsRateRank = rate.GoodsRateRank;                // ���i�|�������N
            rateWork.BLGoodsCode = rate.BLGoodsCode;                    // BL���i�R�[�h
            rateWork.CustomerCode = rate.CustomerCode;                  // ���Ӑ�R�[�h
            rateWork.CustRateGrpCode = rate.CustRateGrpCode;            // ���Ӑ�|���O���[�v�R�[�h
            rateWork.SupplierCd = rate.SupplierCd;                      // �d����R�[�h
            rateWork.LotCount = rate.LotCount;                          // ���b�g�� 
            rateWork.PriceFl = rate.PriceFl;                            // ���i
            rateWork.RateVal = rate.RateVal;                            // �|��
            rateWork.UnPrcFracProcUnit = rate.UnPrcFracProcUnit;        // �P���[�������P��
            rateWork.UnPrcFracProcDiv = rate.UnPrcFracProcDiv;          // �P���[�������敪
            rateWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;          // ���i�|���O���[�v�R�[�h
            rateWork.BLGroupCode = rate.BLGroupCode;                    // BL�O���[�v�R�[�h
            rateWork.UpRate = rate.UpRate;                              // UP��
            rateWork.GrsProfitSecureRate = rate.GrsProfitSecureRate;    // �e���m�ۗ�

            return rateWork;
        }
        #endregion �� Private Methods
    }
}
