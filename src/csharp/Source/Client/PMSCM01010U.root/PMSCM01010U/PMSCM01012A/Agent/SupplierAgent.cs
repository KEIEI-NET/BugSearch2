//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/05/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = SupplierAcs;
    using RecordType        = Int32;

    /// <summary>
    /// �d����}�X�^�̃A�N�Z�X�N���X�̑㗝�l�N���X
    /// </summary>
    public sealed class SupplierAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SupplierAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// �d������Œ[�������R�[�h���擾���܂��B
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>�d������Œ[�������R�[�h</returns>
        public int GetStockFractionProcCdOfTax(GoodsUnitData goodsUnitData)
        {
            return RealAccesser.GetStockFractionProcCd(
                goodsUnitData.EnterpriseCode,
                goodsUnitData.SupplierCd,
                SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd
            );
        }

        /// <summary>
        /// �d���P���[�������R�[�h���擾���܂��B
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>�d���P���[�������R�[�h</returns>
        public int GetStockFractionProcCdOfUnit(GoodsUnitData goodsUnitData
        )
        {
            return RealAccesser.GetStockFractionProcCd(
                goodsUnitData.EnterpriseCode,
                goodsUnitData.SupplierCd,
                SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd
            );
        }
    }
}
