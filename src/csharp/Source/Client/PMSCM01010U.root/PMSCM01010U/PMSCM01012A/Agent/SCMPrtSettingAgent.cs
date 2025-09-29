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
using System.Collections.Generic;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = SCMPrtSettingAcs;
    using RecordType        = IList<SCMPrtSetting>;

    /// <summary>
    /// SCM�i�ڐݒ�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public sealed class SCMPrtSettingAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "SCMPrtSettingAgent";    // ���O�p

        /// <summary>
        /// �����񓚋敪�񋓌^
        /// </summary>
        public enum AutoAnswerDiv : int
        {
            /// <summary>0:���Ȃ�</summary>
            None = 0,
            /// <summary>1:�[��</summary>
            DeliveryDate = 1,
            /// <summary>2:���i</summary>
            Price = 2
        }

        /// <summary>
        /// �����񓚋敪�̖��̂��擾���܂��B
        /// </summary>
        /// <param name="scmPrtSetting">SCM�i�ڐݒ�</param>
        /// <returns></returns>
        public static string GetAutoAnswerDivName(SCMPrtSetting scmPrtSetting)
        {
            if (scmPrtSetting == null) return string.Empty;

            switch (scmPrtSetting.AutoAnswerDiv)
            {
                case (int)AutoAnswerDiv.None:
                    return "���Ȃ�";
                case (int)AutoAnswerDiv.DeliveryDate:
                    return "�[��";
                case (int)AutoAnswerDiv.Price:
                    return "���i";
                default:
                    return string.Empty;
            }
        }

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SCMPrtSettingAgent() { }

        #endregion // </Constructor>

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>��������(SCM�i�ڐݒ�}�X�^�̃��R�[�h���X�g)</returns>
        public IList<SCMPrtSetting> Find(
            GoodsUnitData goodsUnitData,
            int customerCode
        )
        {
            // 1�p����
            SCMPrtSettingOrder searchingCondition = new SCMPrtSettingOrder();
            {
                // ��ƃR�[�h
                searchingCondition.EnterpriseCode = goodsUnitData.EnterpriseCode;

                // ���_�R�[�h
                if (customerCode <= 0)
                {
                    searchingCondition.SectionCode = goodsUnitData.SectionCode;
                }

                // ���Ӑ�R�[�h
                searchingCondition.St_CustomerCode = customerCode;
                searchingCondition.Ed_CustomerCode = customerCode;

                // ���i�����ރR�[�h
                searchingCondition.St_GoodsMGroup = goodsUnitData.GoodsMGroup;
                searchingCondition.Ed_GoodsMGroup = goodsUnitData.GoodsMGroup;

                // BL���i�R�[�h
                searchingCondition.St_BLGoodsCode = goodsUnitData.BLGoodsCode;
                searchingCondition.Ed_BLGoodsCode = goodsUnitData.BLGoodsCode;

                // ���i���[�J�[�R�[�h
                searchingCondition.St_GoodsMakerCd = goodsUnitData.GoodsMakerCd;
                searchingCondition.Ed_GoodsMakerCd = goodsUnitData.GoodsMakerCd;

                // ���i�ԍ�
                searchingCondition.GoodsNo = goodsUnitData.GoodsNo;

                // BL�O���[�v�R�[�h
                searchingCondition.St_BLGroupCode = goodsUnitData.BLGroupCode;
                searchingCondition.Ed_BLGroupCode = goodsUnitData.BLGroupCode;
            }

            // 2�p����
            List<SCMPrtSetting> searchedList = null;

            // 3�p����
            string msg = string.Empty;

            // ����
            RealAccesser.EnterpriseCode = goodsUnitData.EnterpriseCode;
            RealAccesser.SectionCode    = goodsUnitData.SectionCode;
            int status = RealAccesser.Search(searchingCondition, out searchedList, out msg);
            if (searchedList == null && customerCode > 0)
            {
                // ���Ӑ�R�[�h�Ō������Ă����ꍇ�A���_�R�[�h�ōČ���
                searchingCondition.St_CustomerCode = 0;
                searchingCondition.Ed_CustomerCode = 0;
                searchingCondition.SectionCode = goodsUnitData.SectionCode;
                status = RealAccesser.Search(searchingCondition, out searchedList, out msg);
            }

            // TODO:�S�������ʂ��_���v

            return searchedList ?? new List<SCMPrtSetting>();
        }
    }
}
