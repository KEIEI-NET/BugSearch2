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
// �� �� ��  2009/08/03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// SCM����񓚗p�̏��t���i�A���f�[�^�̃w���p�N���X
    /// </summary>
    /// <remarks>
    /// TODO:����񓚗p�̏����������Ȃ��������ꍇ�A�{�N���X�ŃI�[�o�[���C�h���A�W�񂷂邱�ƁB<br/>
    /// �Ȃ��A�Ώۃ��\�b�h��<c>HasMarketPrice</c>�ŏꍇ�������Ă��郁�\�b�h�ł��B
    /// </remarks>
    public sealed class SCMMarketGoodsUnitData : SCMGoodsUnitData
    {
        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realGoodsUnitData">�{���̏��i�A���f�[�^</param>
        /// <param name="searchedType">�������</param>
        /// <param name="sourceDetailRecord">���ƂȂ���SCM�󒍖��׃f�[�^(�⍇���E����)</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        public SCMMarketGoodsUnitData(
            GoodsUnitData realGoodsUnitData,
            SCMSearchedResult.GoodsSearchDivCd searchedType,
            ISCMOrderDetailRecord sourceDetailRecord,
            int customerCode
        ) : base(realGoodsUnitData, searchedType, sourceDetailRecord, customerCode, false)
        { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realGoodsUnitData">�{���̏��i�A���f�[�^</param>
        /// <param name="searchedType">�������</param>
        /// <param name="sourceDetailRecord">���ƂȂ���SCM�󒍖��׃f�[�^(�⍇���E����)</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="createdManually">�蓮�񓚂̔���ɂĐ������ꂽ�����f����t���O</param>
        public SCMMarketGoodsUnitData(
            GoodsUnitData realGoodsUnitData,
            SCMSearchedResult.GoodsSearchDivCd searchedType,
            ISCMOrderDetailRecord sourceDetailRecord,
            int customerCode,
            bool createdManually
        ) : base(realGoodsUnitData, searchedType, sourceDetailRecord, customerCode, createdManually)
        { }

        #endregion // </Constructor>
    }
}
