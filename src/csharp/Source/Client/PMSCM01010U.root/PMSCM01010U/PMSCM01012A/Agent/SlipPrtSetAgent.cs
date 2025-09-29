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
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = SlipPrtSetAcs;
    using RecordType        = IList<SlipPrtSet>;
    using ItemType          = SlipPrtSet;

    using CustSlipMngServer = SingletonInstance<CustSlipMngAgent>;  // ���Ӑ�}�X�^(�`�[�Ǘ�)

    /// <summary>
    /// �`�[����ݒ�}�X�^�̃A�N�Z�X�N���X�̑㗝�l�N���X
    /// </summary>
    public sealed class SlipPrtSetAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "�`�[����ݒ�}�X�^";

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SlipPrtSetAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�Y������`�[����ݒ�</returns>
        public RecordType Find(string enterpriseCode)
        {
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            RealAccesser.IsLocalDBRead = false;
            ArrayList foundRecordList = null;
            int status = RealAccesser.SearchSlipPrtSet(out foundRecordList, enterpriseCode);
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
        /// �`�[����ݒ�����擾���܂��B
        /// </summary>
        /// <param name="slipKind">�`�[���</param>
        /// <param name="salesSlip">����f�[�^</param>
        /// <returns>�`�[����ݒ���</returns>
        public SlipPrtSet GetPrtSlipSet(
            SlipTypeController.SlipKind slipKind,
            SalesSlip salesSlip
        )
        {
            return GetPrtSlipSet(
                slipKind,
                salesSlip.EnterpriseCode.Trim(),
                salesSlip.SectionCode.Trim(),
                salesSlip.CustomerCode
            );
        }

        /// <summary>
        /// �`�[����ݒ�����擾���܂��B
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.GetPrtSlipSet() 14167�s�ڂ��ڐA
        /// </remarks>
        /// <param name="slipKind">�`�[���</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>�`�[����ݒ���</returns>
        private SlipPrtSet GetPrtSlipSet(
            SlipTypeController.SlipKind slipKind,
            string enterpriseCode,
            string sectionCode,
            int customerCode
        )
        {
            SlipTypeController stc = new SlipTypeController();
            {
                stc.EnterpriseCode = enterpriseCode;
                stc.SlipPrtSetList = Find(enterpriseCode) as List<ItemType>;
                stc.CustSlipMngList= CustSlipMngServer.Singleton.Instance.Find(enterpriseCode) as List<CustSlipMng>;
            }
            SlipPrtSet slipPrtSet = null;
            int status = stc.GetSlipType(slipKind, out slipPrtSet, sectionCode, customerCode);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                slipPrtSet = null;
            }
            return slipPrtSet;
        }
    }
}
