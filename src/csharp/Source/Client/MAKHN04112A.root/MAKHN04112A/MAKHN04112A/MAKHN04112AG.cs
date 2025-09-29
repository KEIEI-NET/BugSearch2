using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.LocalAccess;

using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.InteropServices;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�A�N�Z�X�N���X(�|��(�P�i����)���)�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2008.09.10</br>
    /// <br>Update Note: 2009/02/10 30414 �E �K�j ��QID:11264�Ή�</br>
    /// </remarks>
    public partial class GoodsAcs
    {
        /// <summary>�|���A�N�Z�X�N���X</summary>
        private RateAcs _rateAcs;

        /// <summary>
        /// �|��.�P�i�����ǂݍ��ݏ���
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="logicalMode"></param>
        /// <param name="unitRateList"></param>
        /// <returns></returns>
        public int ReadUnitRate( GoodsUnitData goodsUnitData, ConstantManagement.LogicalMode logicalMode, out List<Rate> unitRateList )
        {
            // �����ݒ�,�i��+���[�J�[,���Ӑ�O���[�v�̋敪�l��1A4
            const string ct_UnitPriceKind_Sa = "1";
            // --- CHG 2009/02/10 ��QID:11264�Ή�------------------------------------------------------>>>>>
            //const string ct_RateSettingDiv_GnMkCgr = "A4";
            //const string ct_UnitRateSetDiv_SaGnMkCgr = "1A4";
            const string ct_RateSettingDiv_GnMkCgr = "4A";
            const string ct_UnitRateSetDiv_SaGnMkCgr = "14A";
            // --- CHG 2009/02/10 ��QID:11264�Ή�------------------------------------------------------<<<<<
            // �S���_��\�����_�R�[�h
            const string ct_SectionCode_All = "00";


            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            unitRateList = new List<Rate>();

            //------------------------------------------
            // �A�N�Z�X�N���X�C���X�^���X����
            //------------------------------------------
            if ( _rateAcs == null )
            {
                _rateAcs = new RateAcs();
            }

            //------------------------------------------
            // ���������̃Z�b�g
            //------------------------------------------
            Rate paraRate = new Rate();
            paraRate.EnterpriseCode = goodsUnitData.EnterpriseCode;     // ��ƃR�[�h
            paraRate.GoodsNo = goodsUnitData.GoodsNo;                   // �i��
            paraRate.GoodsMakerCd = goodsUnitData.GoodsMakerCd;         // ���[�J�[�R�[�h
            paraRate.SectionCode = ct_SectionCode_All;                  // ���_(���S�Ђ��w��)
            paraRate.UnitPriceKind = ct_UnitPriceKind_Sa;
            paraRate.RateSettingDivide = ct_RateSettingDiv_GnMkCgr;
            paraRate.UnitRateSetDivCd = ct_UnitRateSetDiv_SaGnMkCgr;    // �P���|���ݒ�敪(�������ݒ�,�i��+���[�J�[,���Ӑ�O���[�v)
            paraRate.LotCount = -1;                                     // ���b�g��(-1:����)

            //------------------------------------------
            // ����
            //------------------------------------------
            ArrayList retList;
            string msg;

            // ��SearchRate�����҂��铮������Ȃ��̂�
            //   SearchAll�őS���擾���Ę_���폜�������O����B

            status = _rateAcs.SearchAll( out retList, ref paraRate, out msg );
            if ( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                // �ԋp���ʂ��Z�b�g
                foreach ( Rate rate in retList )
                {
                    // �_���폜�͏��O
                    if ( rate.LogicalDeleteCode != 0 ) continue;

                    // �|�����X�g�ɒǉ�
                    unitRateList.Add( rate );
                }
            }

            return status;
        }
        /// <summary>
        /// �|�����X�g�ϊ������iRateWorkList��RateList�j
        /// </summary>
        /// <param name="rateWorkList"></param>
        private List<Rate> CopyToRateFromRateWork( ArrayList rateWorkList )
        {
            List<Rate> rateList = new List<Rate>();
            foreach ( RateWork rateWork in rateWorkList )
            {
                rateList.Add( GetRateFromRateWork( rateWork ) );
            }
            return rateList;
        }
        /// <summary>
        /// �|�����X�g�擾����
        /// </summary>
        /// <param name="rateWorkList"></param>
        /// <param name="rateList"></param>
        private void CreateRateWorkListFromRateList( ref ArrayList rateWorkList, List<Rate> rateList )
        {
            if ( rateWorkList == null )
            {
                rateWorkList = new ArrayList();
            }

            // ���e�R�s�[
            foreach ( Rate rate in rateList )
            {
                rateWorkList.Add( GetRateWorkFromRate( rate ) );
            }
        }
        /// <summary>
        /// �|���ϊ������i�|�����|��Work�j
        /// </summary>
        /// <param name="rate"></param>
        /// <returns></returns>
        private RateWork GetRateWorkFromRate( Rate rate )
        {
            RateWork rateWork = new RateWork();

            # region [�|��]
            rateWork.CreateDateTime = rate.CreateDateTime; // �쐬����
            rateWork.UpdateDateTime = rate.UpdateDateTime; // �X�V����
            rateWork.EnterpriseCode = rate.EnterpriseCode; // ��ƃR�[�h
            rateWork.FileHeaderGuid = rate.FileHeaderGuid; // GUID
            rateWork.UpdEmployeeCode = rate.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            rateWork.UpdAssemblyId1 = rate.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            rateWork.UpdAssemblyId2 = rate.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            rateWork.LogicalDeleteCode = rate.LogicalDeleteCode; // �_���폜�敪
            rateWork.SectionCode = rate.SectionCode; // ���_�R�[�h
            rateWork.UnitRateSetDivCd = rate.UnitRateSetDivCd; // �P���|���ݒ�敪
            rateWork.UnitPriceKind = rate.UnitPriceKind; // �P�����
            rateWork.RateSettingDivide = rate.RateSettingDivide; // �|���ݒ�敪
            rateWork.RateMngGoodsCd = rate.RateMngGoodsCd; // �|���ݒ�敪�i���i�j
            rateWork.RateMngGoodsNm = rate.RateMngGoodsNm; // �|���ݒ薼�́i���i�j
            rateWork.RateMngCustCd = rate.RateMngCustCd; // �|���ݒ�敪�i���Ӑ�j
            rateWork.RateMngCustNm = rate.RateMngCustNm; // �|���ݒ薼�́i���Ӑ�j
            rateWork.GoodsMakerCd = rate.GoodsMakerCd; // ���i���[�J�[�R�[�h
            rateWork.GoodsNo = rate.GoodsNo; // ���i�ԍ�
            rateWork.GoodsRateRank = rate.GoodsRateRank; // ���i�|�������N
            rateWork.GoodsRateGrpCode = rate.GoodsRateGrpCode; // ���i�|���O���[�v�R�[�h
            rateWork.BLGroupCode = rate.BLGroupCode; // BL�O���[�v�R�[�h
            rateWork.BLGoodsCode = rate.BLGoodsCode; // BL���i�R�[�h
            rateWork.CustomerCode = rate.CustomerCode; // ���Ӑ�R�[�h
            rateWork.CustRateGrpCode = rate.CustRateGrpCode; // ���Ӑ�|���O���[�v�R�[�h
            rateWork.SupplierCd = rate.SupplierCd; // �d����R�[�h
            rateWork.LotCount = rate.LotCount; // ���b�g��
            rateWork.PriceFl = rate.PriceFl; // ���i�i�����j
            rateWork.RateVal = rate.RateVal; // �|��
            rateWork.UpRate = rate.UpRate; // UP��
            rateWork.GrsProfitSecureRate = rate.GrsProfitSecureRate; // �e���m�ۗ�
            rateWork.UnPrcFracProcUnit = rate.UnPrcFracProcUnit; // �P���[�������P��
            rateWork.UnPrcFracProcDiv = rate.UnPrcFracProcDiv; // �P���[�������敪
            # endregion

            return rateWork;
        }
        /// <summary>
        /// �|���ϊ������i�|��Work���|���j
        /// </summary>
        /// <param name="rateWork"></param>
        /// <returns></returns>
        private Rate GetRateFromRateWork( RateWork rateWork )
        {
            Rate rate = new Rate();

            # region [�|��]
            rate.CreateDateTime = rateWork.CreateDateTime; // �쐬����
            rate.UpdateDateTime = rateWork.UpdateDateTime; // �X�V����
            rate.EnterpriseCode = rateWork.EnterpriseCode; // ��ƃR�[�h
            rate.FileHeaderGuid = rateWork.FileHeaderGuid; // GUID
            rate.UpdEmployeeCode = rateWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            rate.UpdAssemblyId1 = rateWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            rate.UpdAssemblyId2 = rateWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            rate.LogicalDeleteCode = rateWork.LogicalDeleteCode; // �_���폜�敪
            rate.SectionCode = rateWork.SectionCode; // ���_�R�[�h
            rate.UnitRateSetDivCd = rateWork.UnitRateSetDivCd; // �P���|���ݒ�敪
            rate.UnitPriceKind = rateWork.UnitPriceKind; // �P�����
            rate.RateSettingDivide = rateWork.RateSettingDivide; // �|���ݒ�敪
            rate.RateMngGoodsCd = rateWork.RateMngGoodsCd; // �|���ݒ�敪�i���i�j
            rate.RateMngGoodsNm = rateWork.RateMngGoodsNm; // �|���ݒ薼�́i���i�j
            rate.RateMngCustCd = rateWork.RateMngCustCd; // �|���ݒ�敪�i���Ӑ�j
            rate.RateMngCustNm = rateWork.RateMngCustNm; // �|���ݒ薼�́i���Ӑ�j
            rate.GoodsMakerCd = rateWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
            rate.GoodsNo = rateWork.GoodsNo; // ���i�ԍ�
            rate.GoodsRateRank = rateWork.GoodsRateRank; // ���i�|�������N
            rate.GoodsRateGrpCode = rateWork.GoodsRateGrpCode; // ���i�|���O���[�v�R�[�h
            rate.BLGroupCode = rateWork.BLGroupCode; // BL�O���[�v�R�[�h
            rate.BLGoodsCode = rateWork.BLGoodsCode; // BL���i�R�[�h
            rate.CustomerCode = rateWork.CustomerCode; // ���Ӑ�R�[�h
            rate.CustRateGrpCode = rateWork.CustRateGrpCode; // ���Ӑ�|���O���[�v�R�[�h
            rate.SupplierCd = rateWork.SupplierCd; // �d����R�[�h
            rate.LotCount = rateWork.LotCount; // ���b�g��
            rate.PriceFl = rateWork.PriceFl; // ���i�i�����j
            rate.RateVal = rateWork.RateVal; // �|��
            rate.UpRate = rateWork.UpRate; // UP��
            rate.GrsProfitSecureRate = rateWork.GrsProfitSecureRate; // �e���m�ۗ�
            rate.UnPrcFracProcUnit = rateWork.UnPrcFracProcUnit; // �P���[�������P��
            rate.UnPrcFracProcDiv = rateWork.UnPrcFracProcDiv; // �P���[�������敪
            # endregion

            return rate;
        }
    }
}
