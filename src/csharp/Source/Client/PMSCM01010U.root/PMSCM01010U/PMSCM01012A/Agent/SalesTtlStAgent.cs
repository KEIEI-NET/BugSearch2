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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = SalesTtlStAcs;
    using RecordType        = IList<SalesTtlSt>;
    using ItemType          = SalesTtlSt;

    /// <summary>
    /// �������ݒ莞�敪�񋓌^
    /// </summary>
    public enum UnPrcNonSettingDiv : int
    {
        /// <summary>0:�[���\��</summary>
        Zero = 0,
        /// <summary>1:�艿�\��</summary>
        List = 1
    }

    /// <summary>
    /// ����S�̐ݒ�}�X�^�̃A�N�Z�X�N���X�̑㗝�l�N���X
    /// </summary>
    public sealed class SalesTtlStAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "����S�̐ݒ�}�X�^";

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SalesTtlStAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�Y�����锄��S�̐ݒ�</returns>
        public RecordType Find(string enterpriseCode)
        {
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            RealAccesser.IsLocalDBRead = false;
            ArrayList foundRecordList = null;
            int status = RealAccesser.SearchOnlySalesTtlInfo(out foundRecordList, enterpriseCode);
            if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            {
                Debug.Assert(false, MY_NAME + "�̌��������s���܂����B");
                return null;
            }

            RecordType foundRecord = null;
            if (foundRecordList != null)
            {
                foundRecord = new List<ItemType>((ItemType[])foundRecordList.ToArray(typeof(ItemType)));
            }

            if (foundRecord != null)
            {
                FoundRecordMap.Add(key, foundRecord);
            }

            return foundRecord;
        }

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�Y�����锄��S�̐ݒ� ���Y��������̂��Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
        public ItemType Find(
            string enterpriseCode,
            string sectionCode
        )
        {
            RecordType foundRecord = null;
            {
                string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode);
                if (FoundRecordMap.ContainsKey(key))
                {
                    foundRecord = FoundRecordMap[key];
                }
                else
                {
                    foundRecord = Find(enterpriseCode);
                }
                if (foundRecord == null) return null;

                foreach (ItemType foundItem in foundRecord)
                {
                    if (foundItem.SectionCode.Trim().Equals(sectionCode.Trim()))
                    {
                        return foundItem;
                    }
                }

                // �S�Аݒ�ōČ���
                int sectionCodeNo = SCMEntityUtil.ConvertNumber(sectionCode.Trim());
                if (sectionCodeNo > 0)
                {
                    return Find(enterpriseCode, SecInfoSetAgent.ALL_SECTION_CODE);
                }

                return null;
            }
        }

        /// <summary>
        /// ���������ݒ�̏ꍇ�A�艿���g�p���邩���f���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�艿���g�p���܂��B�i�Y�����锄��S�̐ݒ�̔������ݒ莞�敪���u1:�艿�\���v�j<br/>
        /// <c>false</c>:�艿���g�p���܂���B
        /// </returns>
        public bool UsesListPriceIfSalesPriceIsNone(
            string enterpriseCode,
            string sectionCode
        )
        {
            ItemType foundRecord = Find(enterpriseCode, sectionCode);
            if (foundRecord != null)
            {
                return foundRecord.UnPrcNonSettingDiv.Equals((int)UnPrcNonSettingDiv.List);
            }
            return false;
        }
    }
}
