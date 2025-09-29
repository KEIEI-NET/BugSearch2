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
// �Ǘ��ԍ�              �쐬�S�� : 30517�@�Ė� �x�� 
// �� �� ��  2010/07/07  �C�����e : �[�������敪�C�[�������P�ʂ��擾�ł��Ă��Ȃ��s��̏C��
//----------------------------------------------------------------------------//
//#define _RETURN_NULL_IF_    // �������ʂ��Ȃ��ꍇ�Anull��Ԃ��t���O

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType = SalesProcMoneyAcs;
    using RecordType = IList<SalesProcMoney>;
    using ItemType = SalesProcMoney;

    /// <summary>
    /// ������z�����敪�}�X�^�̃A�N�Z�X�N���X�̑㗝�l�N���X
    /// </summary>
    public sealed class SalesProcMoneyAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "������z�����敪�}�X�^";

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SalesProcMoneyAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�Y�����锄����z�����敪</returns>
        public RecordType Find(string enterpriseCode)
        {
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            RealAccesser.IsLocalDBRead = false;
            ArrayList foundRecordList = null;
            int status = RealAccesser.Search(out foundRecordList, enterpriseCode);
            if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            {
                Debug.Assert(false, MY_NAME + "�̌��������s���܂����B");
#if _RETURN_NULL_IF_
                return null;
#else
                return new List<SalesProcMoney>();
#endif
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

#if _RETURN_NULL_IF_
            return foundRecord;
#else
            return foundRecord ?? new List<SalesProcMoney>();
#endif
        }
    }
    // 2010/07/07 Add >>>
}

namespace Broadleaf.Application.Controller.Agent2
{
    using RealAccesserType = StockProcMoneyAcs;
    using RecordType = IList<StockProcMoney>;
    using ItemType = StockProcMoney;
    using Broadleaf.Application.Controller.Agent;
    /// <summary>
    /// �d�����z�����敪�}�X�^�̃A�N�Z�X�N���X�̑㗝�l�N���X
    /// </summary>
    public sealed class StockProcMoneyAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "�d�����z�����敪�}�X�^";

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public StockProcMoneyAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�Y�����锄����z�����敪</returns>
        public RecordType Find(string enterpriseCode)
        {
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            //RealAccesser.IsLocalDBRead = false;
            ArrayList foundRecordList = null;
            int status = RealAccesser.Search(out foundRecordList, enterpriseCode);
            if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            {
                Debug.Assert(false, MY_NAME + "�̌��������s���܂����B");
#if _RETURN_NULL_IF_
                return null;
#else
                return new List<StockProcMoney>();
#endif
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

#if _RETURN_NULL_IF_
            return foundRecord;
#else
            return foundRecord ?? new List<StockProcMoney>();
#endif
        }
    }
    // 2010/07/07 Add <<<
}
