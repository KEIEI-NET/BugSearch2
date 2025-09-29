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
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = CustSlipMngAcsForServer;
    using RecordType        = IList<CustSlipMng>;
    using ItemType          = CustSlipMng;

    #region <�T�[�o�p�A�N�Z�X�N���X>

    /// <summary>
    /// �T�[�o�p���Ӑ�}�X�^(�`�[�Ǘ�)�A�N�Z�X�N���X
    /// </summary>
    public sealed class CustSlipMngAcsForServer : CustSlipMngAcs
    {
        /// <summary>�T�[�o�p�R���X�g���N�^�̃p�����[�^</summary>
        private const int SERVER_MODE = 1;

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public CustSlipMngAcsForServer() : base(SERVER_MODE) { }
    }

    #endregion // </�T�[�o�p�A�N�Z�X�N���X>

    /// <summary>
    /// ���Ӑ�}�X�^(�`�[�Ǘ�)�̃A�N�Z�X�N���X�̑㗝�l�N���X
    /// </summary>
    public sealed class CustSlipMngAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "���Ӑ�}�X�^(�`�[�Ǘ�)";

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public CustSlipMngAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�Y�����链�Ӑ�}�X�^(�`�[�Ǘ�)</returns>
        public RecordType Find(string enterpriseCode)
        {
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            RealAccesser.IsLocalDBRead = false;
            int count = 0;
            int status = RealAccesser.SearchOnlyCustSlipMng(out count, enterpriseCode);
            if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            {
                Debug.Assert(false, MY_NAME + "�̌��������s���܂����B");
                return null;
            }

            RecordType foundRecord = null;
            if (count > 0)
            {
                foundRecord = new List<ItemType>((ItemType[])RealAccesser.CustSlipMngList.ToArray(typeof(ItemType)));
            }

            if (foundRecord != null)
            {
                FoundRecordMap.Add(key, foundRecord);
            }

            return foundRecord;
        }
    }
}
