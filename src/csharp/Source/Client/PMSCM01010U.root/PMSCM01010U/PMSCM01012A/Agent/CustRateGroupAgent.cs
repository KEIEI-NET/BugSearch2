//****************************************************************************//
// �V�X�e��         : �����񓚏��� ���Ӑ�|���O���[�v�}�X�^�̑㗝�l�N���X
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/03/30  �C�����e : �V�K�쐬
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
    using RealAccesserType = CustRateGroupAcs;
    using RecordType = IList<CustRateGroup>;
    using ItemType = CustRateGroup;


    /// <summary>
    /// ���Ӑ�|���O���[�v�}�X�^�̑㗝�l�N���X
    /// </summary>
    public sealed class CustRateGroupAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "���Ӑ�|���O���[�v�}�X�^";

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public CustRateGroupAgent() : base() { }

        #endregion // </Constructor>


        #region �L���b�V�� 
        #endregion

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>���Ӑ�|���O���[�v���X�g</returns>
        public ArrayList FindList(string enterpriseCode)
        {
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode);

            if (FoundRecordMap.ContainsKey(key))
            {
                return new ArrayList(( (List<ItemType>)FoundRecordMap[key] ).ToArray());
            }

            ArrayList foundRecordList = null;
            int status = RealAccesser.Search(out foundRecordList, enterpriseCode, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
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
            else
            {
                foundRecord = new List<ItemType>();
            }

            if (foundRecord != null)
            {
                FoundRecordMap.Add(key, foundRecord);
            }

            return new ArrayList(( (List<ItemType>)FoundRecordMap[key] ).ToArray());
        }

        /// <summary>
        /// ���Ӑ�|���O���[�v���������i�f���Q�[�g�Ɏg�p�j
        /// </summary>
        /// <param name="custRateGrpCodeList">���Ӑ�}�X�^(�|���O���[�v)���X�g</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�|���O���[�v�����������܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/30</br>
        /// </remarks>
        public void GetCustRateGrpCode(ArrayList custRateGrpCodeList, int customerCode, int goodsMakerCode, out int custRateGrpCode)
        {
            custRateGrpCode = 0;
            if (custRateGrpCodeList == null) return;

            RealAccesser.GetCustRateGrp(custRateGrpCodeList, customerCode, goodsMakerCode, out custRateGrpCode);
        }
    }
}
