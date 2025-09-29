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
// �� �� ��  2009/06/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using EstimateDefSetServer = SingletonInstance<EstimateDefSetAgent>;   // ���Ϗ����l�ݒ�}�X�^

    /// <summary>
    /// SCM���ϓ`�[�f�[�^�̐����N���X
    /// </summary>
    public sealed class SCMEstimateSlipDataFactory : SCMSlipDataFactory
    {
        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="scmHeaderRecord">SCM�󒍃f�[�^�̃��R�[�h</param>
        /// <param name="topPriorityIsSCMTotalSetting">SCM�S�̐ݒ���ŗD�悷��t���O</param>
        public SCMEstimateSlipDataFactory(
            ISCMOrderHeaderRecord scmHeaderRecord,
            bool topPriorityIsSCMTotalSetting
        ) : base(scmHeaderRecord, topPriorityIsSCMTotalSetting) { }

        #endregion // </Constructor>

        #region <���Ϗ����l�}�X�^>

        /// <summary>
        /// ���Ϗ����l�ݒ�}�X�^���擾���܂��B
        /// </summary>
        private static EstimateDefSetAgent EstimateDefSetDB
        {
            get { return EstimateDefSetServer.Singleton.Instance; }
        }

        #endregion // </���Ϗ����l�}�X�^>

        #region <114.�`�[���s�敪>

        /// <summary>
        /// �`�[���s�敪���擾���܂��B
        /// </summary>
        /// <returns>�`�[���s�敪(0:���Ȃ�/1:����)</returns>
        /// <see cref="SCMSlipDataFactory"/>
        public override int GetSlipPrintDivCd()
        {
            int slipPrintDivCd = 0; // 0:���Ȃ�

            // ���Ϗ����l�ݒ�}�X�^���
            EstimateDefSet salesTotalSetting = EstimateDefSetDB.Find(
                SCMHeaderRecord.InqOtherEpCd,
                SCMHeaderRecord.InqOtherSecCd
            );
            if (salesTotalSetting != null)
            {
                slipPrintDivCd = salesTotalSetting.EstimateDtCreateDiv; // ���σf�[�^�쐬�敪
            }
            if (TopPriorityIsSCMTotalSetting)
            {
                // ���Ϗ����l�ݒ�}�X�^�ɑ��݂��Ȃ��ꍇ�ASCM�S�̐ݒ�}�X�^���
                SCMTtlSt scmTotalSetting = SCMTotalSettingDB.Find(
                    SCMHeaderRecord.InqOtherEpCd,
                    SCMHeaderRecord.InqOtherSecCd
                );
                if (!SCMDataHelper.IsAvailableRecord(scmTotalSetting)) scmTotalSetting = null;
                if (scmTotalSetting != null)
                {
                    slipPrintDivCd = scmTotalSetting.EstimatePrtDiv;    // ���Ϗ����s�敪
                }
            }
            return slipPrintDivCd;
        }

        #endregion // </114.�`�[���s�敪>
    }
}
