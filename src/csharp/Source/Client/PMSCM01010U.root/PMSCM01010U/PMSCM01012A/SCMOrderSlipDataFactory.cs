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
    using AcptAnOdrTtlStServer = SingletonInstance<AcptAnOdrTtlStAgent>;    // �󔭒��Ǘ��S�̐ݒ�}�X�^

    /// <summary>
    /// SCM�󒍓`�[�f�[�^�̐����N���X
    /// </summary>
    public sealed class SCMOrderSlipDataFactory : SCMSlipDataFactory
    {
        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="scmHeaderRecord">SCM�󒍃f�[�^�̃��R�[�h</param>
        /// <param name="topPriorityIsSCMTotalSetting">SCM�S�̐ݒ���ŗD�悷��t���O</param>
        public SCMOrderSlipDataFactory(
            ISCMOrderHeaderRecord scmHeaderRecord,
            bool topPriorityIsSCMTotalSetting
        )  : base(scmHeaderRecord, topPriorityIsSCMTotalSetting) { }

        #endregion // </Constructor>

        #region <�󔭒��Ǘ��S�̐ݒ�}�X�^>

        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ�}�X�^���擾���܂��B
        /// </summary>
        private static AcptAnOdrTtlStAgent AcptAnOdrTtlStDB
        {
            get { return AcptAnOdrTtlStServer.Singleton.Instance; }
        }

        #endregion // </�󔭒��Ǘ��S�̐ݒ�}�X�^>

        #region <114.�`�[���s�敪>

        /// <summary>
        /// �`�[���s�敪���擾���܂��B
        /// </summary>
        /// <returns>�`�[���s�敪(0:���Ȃ�/1:����)</returns>
        /// <see cref="SCMSlipDataFactory"/>
        public override int GetSlipPrintDivCd()
        {
            int slipPrintDivCd = 0; // 0:���Ȃ�

            // �󔭒��Ǘ��S�̐ݒ�}�X�^���
            AcptAnOdrTtlSt acceptAnOrderTotalSetting = AcptAnOdrTtlStDB.Find(
                SCMHeaderRecord.InqOtherEpCd,
                SCMHeaderRecord.InqOtherSecCd
            );
            if (acceptAnOrderTotalSetting != null)
            {
                slipPrintDivCd = acceptAnOrderTotalSetting.AcpOdrrSlipPrtDiv;   // �󒍓`�[���s�敪
            }
            if (TopPriorityIsSCMTotalSetting)
            {
                // �󔭒��Ǘ��S�̐ݒ�}�X�^�ɑ��݂��Ȃ��ꍇ�ASCM�S�̐ݒ�}�X�^���
                SCMTtlSt scmTotalSetting = SCMTotalSettingDB.Find(
                    SCMHeaderRecord.InqOtherEpCd,
                    SCMHeaderRecord.InqOtherSecCd
                );
                if (!SCMDataHelper.IsAvailableRecord(scmTotalSetting)) scmTotalSetting = null;
                if (scmTotalSetting != null)
                {
                    slipPrintDivCd = scmTotalSetting.AcpOdrrSlipPrtDiv; // �󒍓`�[���s�敪
                }
            }
            return slipPrintDivCd;
        }

        #endregion // </114.�`�[���s�敪>
    }
}
