//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������}�X�^�A�N�Z�X�N���X
// �v���O�����T�v   : ����S�̐ݒ�}�X�^�A�N�Z�X������s���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30744 �������q
// �� �� ��  2015/02/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
//using Broadleaf.Application.UIData.Util;

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
        /// <summary>��ƃR�[�h�̃t�H�[�}�b�g</summary>
        private const string ENTERPRISE_CODE_FORMAT = "0000000000000000";
        /// <summary>�S�Аݒ�</summary>
        public const string ALL_SECTION_CODE = "00";

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
            string key = FormatEnterpriseCode(enterpriseCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            RealAccesser.IsLocalDBRead = false;
            ArrayList foundRecordList = null;
            int status = RealAccesser.SearchOnlySalesTtlInfo(out foundRecordList, enterpriseCode);
            if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            {
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
                string key = FormatEnterpriseCode(enterpriseCode);
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
                int sectionCodeNo = ConvertNumber(sectionCode.Trim());
                if (sectionCodeNo > 0)
                {
                    return Find(enterpriseCode, ALL_SECTION_CODE);
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

        /// <summary>
        /// ��ƃR�[�h�������t�ϊ����܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>enterpriseCodeNo.ToString("0000000000000000") ��16��</returns>
        private string FormatEnterpriseCode(string enterpriseCode)
        {
            return FormatCode(enterpriseCode, ENTERPRISE_CODE_FORMAT);
        }

        /// <summary>
        /// �����R�[�h�������t�ϊ����܂��B
        /// </summary>
        /// <param name="code">�����R�[�h�l</param>
        /// <param name="format">����</param>
        /// <returns>codeNo.ToString(format)</returns>
        private static string FormatCode(
            string code,
            string format
        )
        {
            long codeNo = 0;
            if (!long.TryParse(code.Trim(), out codeNo))
            {
                codeNo = 0;
            }
            return codeNo.ToString(format);
        }

        /// <summary>
        /// ���l�ɕϊ����܂��B
        /// </summary>
        /// <param name="target">�Ώە�����</param>
        /// <returns>���l�ɕϊ��ł��Ȃ��ꍇ�A<c>0</c>��Ԃ��܂��B</returns>
        private int ConvertNumber(string target)
        {
            if (string.IsNullOrEmpty(target.Trim())) return 0;

            int number = 0;
            return int.TryParse(target.Trim(), out number) ? number : 0;
        }

    }
}
