//**********************************************************************//
// �V�X�e��         �FPM.NS
// �v���O��������   �FPMTAB �����񓚏���(����) �e�[�u���A�N�Z�X�N���X
// �v���O�����T�v   �FPMTAB�풓�������p�����[�^�Ŏԗ��A���i�����������n�����
//                    �ԗ��A���i�����������ԗ��A���i�̌������s���A
//                    �擾��������SCM_DB�̌������ʊ֘A�̃e�[�u���ɏ�����
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01  �쐬�S�� : songg
// �� �� ��  2013/05/29   �쐬���e : PMTAB �����񓚏���(����)
//----------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType = SalesTtlStAcs;
    using RecordType = IList<SalesTtlSt>;
    using ItemType = SalesTtlSt;

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
    public sealed class SalesTtlStAgentForTablet : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "����S�̐ݒ�}�X�^";

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SalesTtlStAgentForTablet() : base() { }

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
                    return Find(enterpriseCode, "00");
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

    /// <summary>
    /// SCM�󒍃f�[�^���[�e�B���e�B
    /// </summary>
    public static class SCMEntityUtil
    {
        #region <����>

        /// <summary>���t�t�H�[�}�b�g</summary>
        public const string YYYYMMDD = "yyyyMMdd";
        /// <summary>�����t�H�[�}�b�g</summary>
        public const string YYYYMMDDHHMMSS = "yyyyMMddhhmmss";

        /// <summary>
        /// ���t�𐔒l�ɕϊ����܂��B
        /// </summary>
        /// <param name="date">���t</param>
        /// <returns>yyyyMMdd</returns>
        public static int ConvertToYYYYMMDD(DateTime date)
        {
            string yyyyMMdd = date.ToString(YYYYMMDD);
            return int.Parse(yyyyMMdd);
        }

        /// <summary>
        /// ���t�ɕϊ����܂��B
        /// </summary>
        /// <param name="yyyyMMdd">���t��(yyyyMMdd)</param>
        /// <returns>"yyyy/MM/dd"</returns>
        public static DateTime ConvertToDate(int yyyyMMdd)
        {
            #region <Guard Phrase>

            if (yyyyMMdd <= 0) return DateTime.MinValue;

            #endregion // </Guard Phrase>

            string yyyy = yyyyMMdd.ToString().Substring(0, 4);
            string MM = yyyyMMdd.ToString().Substring(4, 2);
            string dd = yyyyMMdd.ToString().Substring(6, 2);

            return new DateTime(int.Parse(yyyy), int.Parse(MM), int.Parse(dd));
        }

        /// <summary>
        /// �����ɕϊ����܂��B
        /// </summary>
        /// <param name="longNumber">������</param>
        /// <returns>"yyyy/MM/dd hh:mm:ss"</returns>
        public static DateTime ConvertToDateTime(long longNumber)
        {
            #region <Guard Phrase>

            if (longNumber <= 0) return DateTime.MinValue;

            #endregion // </Guard Phrase>

            return new DateTime(longNumber);
        }

        /// <summary>
        /// �����𐔒l�ɕϊ����܂��B
        /// </summary>
        /// <param name="dateTime">����</param>
        /// <returns>Convert.ToInt64(dateTime)</returns>
        public static long ConvertToLong(DateTime dateTime)
        {
            return dateTime.Ticks;
        }

        #endregion // </����>



        #region <�����t�R�[�h>

        /// <summary>��ƃR�[�h�̃t�H�[�}�b�g</summary>
        private const string ENTERPRISE_CODE_FORMAT = "0000000000000000";
        /// <summary>���_�R�[�h�̃t�H�[�}�b�g</summary>
        private const string SECTION_CODE_FORMAT = "00";
        /// <summary>�⍇���ԍ��̃t�H�[�}�b�g</summary>
        private const string INQUIRY_NUMBER_FORMAT = ENTERPRISE_CODE_FORMAT;
        /// <summary>�X�V�N�����̃t�H�[�}�b�g</summary>
        private const string UPDATE_DATE_FORMAT = "yyyyMMdd";
        /// <summary>�X�V�����b�~���b�̃t�H�[�}�b�g</summary>
        private const string UPDATE_TIME_FORMAT = "000000000";
        /// <summary>�⍇���E������ʂ̃t�H�[�}�b�g</summary>
        private const string INQ_ORD_DIV_CD_FORMAT = "00";
        /// <summary>�⍇���s�ԍ��̃t�H�[�}�b�g</summary>
        private const string INQ_ROW_NUMBER_FORMAT = "00";
        /// <summary>�⍇���s�ԍ��}�Ԃ̃t�H�[�}�b�g</summary>
        private const string INQ_ROW_NUM_DERIVED_NO_FORMAT = "00";
        /// <summary>�󒍃X�e�[�^�X�̃t�H�[�}�b�g</summary>
        private const string ACPT_AN_ODR_STATUS = "00";
        /// <summary>����`�[�ԍ��̃t�H�[�}�b�g</summary>
        // 2011/02/09 >>>
        //private const string SALES_SLIP_NUM_FORMAT = "000000000";
        public const string SALES_SLIP_NUM_FORMAT = "000000000";
        // 2011/02/09 <<<
        /// <summary>�]�ƈ��R�[�h�̃t�H�[�}�b�g</summary>
        private const string EMPLOYEE_CODE_FORMAT = "000000000";

        /// <summary>
        /// ��ƃR�[�h�������t�ϊ����܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>enterpriseCodeNo.ToString("0000000000000000") ��16��</returns>
        public static string FormatEnterpriseCode(string enterpriseCode)
        {
            return FormatCode(enterpriseCode, ENTERPRISE_CODE_FORMAT);
        }

        /// <summary>
        /// ���_�R�[�h�������t�ϊ����܂��B
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>sectionCodeNo.ToString("00") ��2��</returns>
        public static string FormatSectionCode(string sectionCode)
        {
            return FormatCode(sectionCode, SECTION_CODE_FORMAT);
        }

        /// <summary>
        /// ����`�[�ԍ��������t�ϊ����܂��B
        /// </summary>
        /// <param name="salseSlipNum">����`�[�ԍ�</param>
        /// <returns>sectionCodeNo.ToString("00") ��9��</returns>
        public static string FormatSalseSlipNum(string salseSlipNum)
        {
            return FormatCode(salseSlipNum, SALES_SLIP_NUM_FORMAT);
        }

        /// <summary>
        /// �]�ƈ��R�[�h�������t�ϊ����܂��B
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>employeeCode.ToString("000000000") ��9��</returns>
        public static string FormatEmployeeCode(string employeeCode)
        {
            return FormatCode(employeeCode, EMPLOYEE_CODE_FORMAT);
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

        #endregion // </�����t�R�[�h>

        /// <summary>
        /// ���l�ɕϊ����܂��B
        /// </summary>
        /// <param name="target">�Ώە�����</param>
        /// <returns>���l�ɕϊ��ł��Ȃ��ꍇ�A<c>0</c>��Ԃ��܂��B</returns>
        public static int ConvertNumber(string target)
        {
            if (string.IsNullOrEmpty(target.Trim())) return 0;

            int number = 0;
            return int.TryParse(target.Trim(), out number) ? number : 0;
        }
    }
}
