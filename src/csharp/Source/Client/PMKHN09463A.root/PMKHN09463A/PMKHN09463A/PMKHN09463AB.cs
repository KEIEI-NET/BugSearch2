//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �P�i�����ݒ�ꊇ�o�^�E�C��
// �v���O�����T�v   : �|���}�X�^�̒P�i�ݒ蕪��ΏۂɁA�������ꊇ�œo�^�E�C���A�ꊇ�폜�A���p�o�^���s���B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2010/08/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

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
    /// �P�i�����ݒ�ꊇ�o�^�E�C���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �P�i�����ݒ�ꊇ�o�^�E�C���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer  : ���M</br>
    /// <br>Date        : 2010/08/10</br>
    /// </remarks>
    public class CustomerCodeRateSetUpdateAcs
    {
        #region �� Private Members
        // �|���}�X�^�����[�g
        private ISingleGoodsRateDB _iRateDB = null;
        #endregion �� Private Members


        #region �� Construcstor
        /// <summary>
        /// �P�i�����ݒ�ꊇ�o�^�E�C���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �P�i�����ݒ�ꊇ�o�^�E�C���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        public CustomerCodeRateSetUpdateAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iRateDB = (ISingleGoodsRateDB)MediationSingleGoodsRateDB.GetSingleGoodsRateDB();
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
        /// <param name="rateSearchParam">�|���}�X�^�X�V����</param>
        /// <remarks>
        /// <br>Note       : �|���}�X�^���X�V���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        public int CustomerUpdate(GoodsRateSetSearchParam rateSearchParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                // �N���X�����o�R�s�[����(E��D)
                SingleGoodsRateSearchParamWork paraWork = CopyToRateSearchParamWorkFromCustomerParam(rateSearchParam);

                object paraObj = paraWork;

                status = this._iRateDB.WriteCustomer(ref paraObj);
                if (status == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// �|���}�X�^�X�V����
        /// </summary>
        /// <param name="rateSearchParam">�|���}�X�^�X�V����</param>
        /// <remarks>
        /// <br>Note       : �|���}�X�^���X�V���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        public int CustomerUpdateGrp(out List<GoodsRateSetSearchResult> rateSearchResultList, GoodsRateSetSearchParam rateSearchParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            rateSearchResultList = new List<GoodsRateSetSearchResult>();

            try
            {
                // �N���X�����o�R�s�[����(E��D)
                SingleGoodsRateSearchParamWork paraWork = CopyToRateSearchParamWorkFromCustomerParam(rateSearchParam);

                object paraObj = paraWork;
                object retObj;

                status = this._iRateDB.WriteCustomerGrp(out retObj, ref paraObj);
                if (status == 0)
                {
                    ArrayList retWorkList = retObj as ArrayList;

                    foreach (SingleGoodsRateSearchResultWork retWork in retWorkList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        rateSearchResultList.Add(CopyToRateSearchResultFromRateSearchResultWork(retWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// �|���}�X�^�X�V����
        /// </summary>
        /// <param name="rateSearchParam">�|���}�X�^�X�V����</param>
        /// <remarks>
        /// <br>Note       : �|���}�X�^���X�V���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        public int CustomerAllDelete(GoodsRateSetSearchParam rateSearchParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                // �N���X�����o�R�s�[����(E��D)
                SingleGoodsRateSearchParamWork paraWork = CopyToRateSearchParamWorkFromCustomerParam(rateSearchParam);

                object paraObj = paraWork;

                status = this._iRateDB.CustomerAllDelete(ref paraObj);
                if (status == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        #endregion �� Public Methods


        #region �� Private Methods
        /// <summary>
        /// �N���X�����o�R�s�[����(E��D)
        /// </summary>
        /// <param name="rateSearchParam">�|���}�X�^�X�V����</param>
        /// <returns>�|���}�X�^�X�V�������[�N</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private SingleGoodsRateSearchParamWork CopyToRateSearchParamWorkFromCustomerParam(GoodsRateSetSearchParam rateSearchParam)
        {
            SingleGoodsRateSearchParamWork paraWork = new SingleGoodsRateSearchParamWork();

            paraWork.EnterpriseCode = rateSearchParam.EnterpriseCode;       // ��ƃR�[�h
            paraWork.SectionCode = rateSearchParam.SectionCode;             // ���p��.���_�R�[�h
            paraWork.CustomerCode = rateSearchParam.CustomerCode;           // ���Ӑ�R�[�h
            paraWork.CustRateGrpCode = rateSearchParam.CustRateGrpCode;     // ���Ӑ�|���R�[�h
            paraWork.PrmSectionCode = rateSearchParam.PrmSectionCode;       // ���p��.���_�R�[�h
            paraWork.ObjectDiv = rateSearchParam.ObjectDiv;                 // �X�V�敪
            paraWork.RateMngGoodsCd = rateSearchParam.RateMngGoodsCd;       // �폜�敪
            paraWork.RateMngCustCd = rateSearchParam.RateMngCustCd;         // �w��敪
            paraWork.UnSettingFlg = rateSearchParam.UnSettingFlg;           // ���ݒ�
            paraWork.GoodsNo = rateSearchParam.GoodsNo;                     //���i�ԍ�
            paraWork.GoodsMakerCd = rateSearchParam.GoodsMakerCd;           //���iҰ������ 
            paraWork.BlGoodsCode = rateSearchParam.BlGoodsCode;             //BL���i����
            paraWork.BlGroupCode = rateSearchParam.BlGroupCode;             //BL��ٰ�ߺ���

            return paraWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(D��E)
        /// </summary>
        /// <param name="rateSearchResultWork">�|���}�X�^�������ʃ��[�N</param>
        /// <returns>�|���}�X�^��������</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private GoodsRateSetSearchResult CopyToRateSearchResultFromRateSearchResultWork(SingleGoodsRateSearchResultWork rateSearchResultWork)
        {
            GoodsRateSetSearchResult result = new GoodsRateSetSearchResult();

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

            result.ListPrice = rateSearchResultWork.ListPrice;          // �W�����i
            result.SalesUnitCost = rateSearchResultWork.SalesUnitCost;          // ���P��

            result.BfPriceFl = rateSearchResultWork.BfPriceFl;                          // ���i�i�����j
            result.BfRateVal = rateSearchResultWork.BfRateVal;                          // �|��
            result.BfUpRate = rateSearchResultWork.BfUpRate;                            // UP��
            result.BfGrsProfitSecureRate = rateSearchResultWork.BfGrsProfitSecureRate;  // �e���m�ۗ�
            result.UpdateDiv = rateSearchResultWork.UpdateDiv;

            return result;
        }

        #endregion �� Private Methods
    }
}
