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
// �� �� ��  2009/06/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���X�� ��
// �� �� ��  2010/03/12  �C�����e : ������
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Diagnostics;
// 2010/03/12 Add >>>
using System.Collections;
// 2010/03/12 Add <<<

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = SCMTtlStAcs;
    using RecordType        = SCMTtlSt;

    /// <summary>
    /// SCM�S�̐ݒ�}�X�^�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public class SCMTotalSettingAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "SCM�S�̐ݒ�}�X�^";

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SCMTotalSettingAgent() { }

        #endregion // </Constructor>

        // 2010/03/12 Add >>>
        Dictionary<string, List<RecordType>> _recordlist;

        /// <summary>
        /// ���ϑS�̐ݒ���A���_�R�[�h�t���Ƀ\�[�g����
        /// </summary>
        /// <remarks></remarks>
        private class SCMTtlStComparer : Comparer<RecordType>
        {
            public override int Compare(RecordType x, RecordType y)
            {
                int result = y.SectionCode.Trim().CompareTo(x.SectionCode.Trim());
                if (result != 0) return result;

                return result;
            }
        }
        // 2010/03/12 Add <<<


        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�Y������SCM�S�̐ݒ�</returns>
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
            // 2010/03/12 >>>
            //int status = RealAccesser.Read(out foundRecord, enterpriseCode, sectionCode);
            //if (foundRecord == null || !status.Equals((int)ResultUtil.ResultCode.Normal))// && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            //{
            //    Debug.Assert(false, MY_NAME + "�̌��������s���܂����B");
                
            //    // �S�̂Ŏ擾������
            //    int allSection = int.Parse(sectionCode);
            //    if (!allSection.Equals(0))
            //    {
            //        allSection = 0;
            //        return Find(enterpriseCode, allSection.ToString("00"));
            //    }
            //}

            //if (foundRecord != null)
            //{
            //    // �_���폜���R�[�h�����������̂ŁA����͖���
            //    if (!foundRecord.LogicalDeleteCode.Equals(0))
            //    {
            //        // �S�̂Ŏ擾������
            //        int allSection = int.Parse(sectionCode);
            //        if (!allSection.Equals(0))
            //        {
            //            allSection = 0;
            //            return Find(enterpriseCode, allSection.ToString("00"));
            //        }
            //    }
            //    FoundRecordMap.Add(key, foundRecord);
            //}

            if (_recordlist == null) _recordlist = new Dictionary<string, List<RecordType>>();

            if (!_recordlist.ContainsKey(enterpriseCode))
            {
                _recordlist.Add(enterpriseCode, GetRecordList(enterpriseCode));
            }

            if (_recordlist[enterpriseCode] != null && _recordlist[enterpriseCode].Count > 0)
            {
                foundRecord = ( (List<RecordType>)_recordlist[enterpriseCode] ).Find(
                     delegate(RecordType rec)
                     {
                         if (rec.SectionCode.Trim() == sectionCode.Trim() || rec.SectionCode.Trim() == "00")
                         {
                             return true;
                         }
                         return false;
                     });
            }

            if (foundRecord != null && foundRecord.LogicalDeleteCode.Equals(0))
            {
                FoundRecordMap.Add(key, foundRecord);
            }
            // 2010/03/12 <<<

            return foundRecord ?? new RecordType();
        }

        // 2010/03/12 Add >>>
        private List<RecordType> GetRecordList(string enterpriseCode)
        {
            List<RecordType> retList = new List<RecordType>();
            ArrayList al;
            int status = RealAccesser.Search(out al, enterpriseCode);

            if (status.Equals((int)ResultUtil.ResultCode.Normal))
            {
                if (al != null && al.Count > 0)
                {
                    foreach (SCMTtlSt rec in al)
                    {
                        if (rec.LogicalDeleteCode == 0)
                        {
                            retList.Add(rec);
                        }
                    }

                    retList.Sort(new SCMTtlStComparer());
                }
            }

            return retList;
        }
        // 2010/03/12 Add <<<
    }
}
