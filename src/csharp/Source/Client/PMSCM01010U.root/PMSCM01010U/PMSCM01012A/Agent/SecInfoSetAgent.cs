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
// �� �� ��  2009/06/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11600006-00 �쐬�S�� : �c����
// �C �� ��  2020/05/15  �C�����e : PMKOBETSU-3932 BLP��Q�i���O�����j
//                                : �����R�[�h�̃��O�o�͋������s��
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Diagnostics;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = SecInfoSetAcs;
    using RecordType        = SecInfoSet;

    /// <summary>
    /// ���_�ݒ�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public class SecInfoSetAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "���_�ݒ�}�X�^";

        /// <summary>�S�Аݒ�</summary>
        public const string ALL_SECTION_CODE = "00";

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SecInfoSetAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�Y�����鋒�_�ݒ�</returns>
        public RecordType Find(
            string enterpriseCode,
            string sectionCode
        )
        {
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatSectionCode(sectionCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            RecordType foundRecord = null;
            EasyLogger.Write(MY_NAME, "Find()", "�Y�����鋒�_�ݒ茟���@�J�n" + "�p�����[�^�F" + "enterpriseCode:" + enterpriseCode + "sectionCode:" + sectionCode.Trim()); // ADD 2020/05/15 �c���� PMKOBETSU-3932 BLP��Q�i���O�����j
            int status = RealAccesser.Read(out foundRecord, enterpriseCode, sectionCode);
            EasyLogger.Write(MY_NAME, "Find()", "�Y�����鋒�_�ݒ茟���@����"); // ADD 2020/05/15 �c���� PMKOBETSU-3932 BLP��Q�i���O�����j
            if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            {
                Debug.Assert(false, MY_NAME + "�̌��������s���܂����B");
            }

            if (foundRecord != null && foundRecord.LogicalDeleteCode.Equals(0))
            {
                FoundRecordMap.Add(key, foundRecord);
            }

            return foundRecord ?? new RecordType();
        }

        /// <summary>
        /// �q�ɂ����݂��邩���f���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <returns>
        /// <c>true</c> :���݂��܂��B<br/>
        /// <c>false</c>:���݂��܂���B
        /// </returns>
        public bool ExistsWarehouse(
            string enterpriseCode,
            string sectionCode,
            string warehouseCode
        )
        {
            RecordType foundSectionSet = Find(enterpriseCode, sectionCode);
            {
                if (foundSectionSet == null) return false;

                if (foundSectionSet.SectWarehouseCd1.Trim().Equals(warehouseCode.Trim()))
                {
                    return true;
                }
                if (foundSectionSet.SectWarehouseCd2.Trim().Equals(warehouseCode.Trim()))
                {
                    return true;
                }
                if (foundSectionSet.SectWarehouseCd3.Trim().Equals(warehouseCode.Trim()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
