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
// �Ǘ��ԍ�              �쐬�S�� : ���X�� ��
// �� �� ��  2010/03/12  �C�����e : ������
//----------------------------------------------------------------------------//
using System;
using System.Diagnostics;
// 2010/03/12 Add >>>
using System.Collections;
using System.Collections.Generic;
// 2010/03/12 Add <<<

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = EstimateDefSetAcsForServer;
    using RecordType        = EstimateDefSet;

    #region <�T�[�o�p�A�N�Z�X�N���X>

    /// <summary>
    /// �T�[�o�p���Ϗ����l�ݒ�A�N�Z�X�N���X
    /// </summary>
    public sealed class EstimateDefSetAcsForServer : EstimateDefSetAcs
    {
        /// <summary>�T�[�o�p�R���X�g���N�^�̃p�����[�^</summary>
        private const int SERVER_MODE = 1;

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public EstimateDefSetAcsForServer() : base(SERVER_MODE) { }
    }

    #endregion // </�T�[�o�p�A�N�Z�X�N���X>

    /// <summary>
    /// ���Ϗ����l�ݒ�}�X�^�̃A�N�Z�X�N���X�̑㗝�l�N���X
    /// </summary>
    public class EstimateDefSetAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "���Ϗ����l�ݒ�}�X�^";

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public EstimateDefSetAgent() : base() { }

        #endregion // </Constructor>

        // 2010/03/12 Add >>>
        Dictionary<string, List<RecordType>> _recordlist;

        /// <summary>
        /// ���ϑS�̐ݒ���A���_�R�[�h�t���Ƀ\�[�g����
        /// </summary>
        /// <remarks></remarks>
        private class EstiamteDefSetComparer : Comparer<RecordType>
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
        /// <returns>�Y�����錩�Ϗ����l�ݒ�</returns>
        public RecordType Find(
            string enterpriseCode,
            string sectionCode
        )
        {
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatSectionCode(sectionCode);
            // 2010/03/12 >>>
            //if (FoundRecordMap.ContainsKey(key))
            //{
            //    return FoundRecordMap[key];
            //}

            //RecordType foundRecord = null;
            //int status = RealAccesser.Read(out foundRecord, enterpriseCode, sectionCode);
            //if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            //{
            //    Debug.Assert(false, MY_NAME + "�̌��������s���܂����B");
            //    return null;
            //}

            //if (foundRecord != null && foundRecord.LogicalDeleteCode.Equals(0))
            //{
            //    FoundRecordMap.Add(key, foundRecord);
            //}

            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            if (_recordlist == null) _recordlist = new Dictionary<string, List<RecordType>>();

            if (!_recordlist.ContainsKey(enterpriseCode))
            {
                _recordlist.Add(enterpriseCode, GetRecordList(enterpriseCode));
            }


            RecordType foundRecord = null;

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
                    foreach (EstimateDefSet rec in al)
                    {
                        retList.Add(rec);
                    }

                    retList.Sort(new EstiamteDefSetComparer());
                }
            }

            return retList;
        }
        // 2010/03/12 Add <<<

        /// <summary>
        /// ���ϗL���������擾���܂��B
        /// </summary>
        /// <param name="estimateDefSet">���Ϗ����l�ݒ�</param>
        /// <returns>�V�X�e�����t + ���Ϗ����l�ݒ�.���Ϗ��L������</returns>
        public static DateTime GetEstimateValidityDate(EstimateDefSet estimateDefSet)
        {
            return DateTime.Now.AddDays(estimateDefSet.EstimateValidityTerm);
        }
    }
}
