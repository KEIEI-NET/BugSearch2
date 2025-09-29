//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : SCM�S�̐ݒ�}�X�^�A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : duzg
// �� �� ��  2011/07/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 20056 ���n ���
// �� �� ��  2012/05/01  �C�����e : PCC�S�̐ݒ�@�S�Ѓ��R�[�h�Q�ƑΉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Collections; // 2012/05/01

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType = SCMTtlStAcs;
    using RecordType = SCMTtlSt;

    /// <summary>
    /// SCM�S�̐ݒ�}�X�^�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public class SCMTtlStAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        // ���O�p
        private const string MY_NAME = "SCM�S�̐ݒ�}�X�^";
        private const string CLASS_NAME = "SCMTtlStAgent";

        //>>>2012/05/01
        Dictionary<string, List<RecordType>> _recordlist;

        /// <summary>
        /// PCC�S�̐ݒ���A���_�R�[�h�t���Ƀ\�[�g����
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
        //<<<2012/05/01

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
            // ���O�p
            const string METHOD_NAME = "Find()";

            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatEmployeeCode(sectionCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            //>>>2012/05/01
            //SCMTtlSt foundSCMTtlSt = null;
            //int status = RealAccesser.Read(out foundSCMTtlSt, enterpriseCode, sectionCode);
            //if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            //{
            //    #region <Log>

            //    string msg = string.Format(
            //        "SCM�S�̐ݒ�}�X�^�̌����G���[�F{0}(��ƃR�[�h={1}, ���_�R�[�h={2})",
            //        status,
            //        enterpriseCode,
            //        sectionCode
            //    );
            //    EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            //    #endregion // </Log>

            //    Debug.Assert(false, MY_NAME + "�̌��������s���܂����B");
            //}

            //if (foundSCMTtlSt != null && foundSCMTtlSt.LogicalDeleteCode.Equals(0))
            //{
            //    FoundRecordMap.Add(key, foundSCMTtlSt);
            //}

            //return foundSCMTtlSt ?? new RecordType();

            RecordType foundRecord = null;

            if (_recordlist == null) _recordlist = new Dictionary<string, List<RecordType>>();

            if (!_recordlist.ContainsKey(enterpriseCode))
            {
                _recordlist.Add(enterpriseCode, GetRecordList(enterpriseCode));
            }

            if (_recordlist[enterpriseCode] != null && _recordlist[enterpriseCode].Count > 0)
            {
                foundRecord = ((List<RecordType>)_recordlist[enterpriseCode]).Find(
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

            return foundRecord ?? new RecordType();
            //<<<2012/05/01

        }

        //2012/05/01
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
        //<<<2012/05/01
    }
}
