//****************************************************************************//
// �V�X�e��         : �����񓚏��� �\���敪�}�X�^�̑㗝�l�N���X
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
    using RealAccesserType = PriceSelectSetAcs;
    using RecordType = List<PriceSelectSet>;
    using ItemType = PriceSelectSet;


    /// <summary>
    /// �\���敪�}�X�^�̑㗝�l�N���X
    /// </summary>
    public sealed class PriceSelectSetAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "���Ӑ�|���O���[�v�}�X�^";

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PriceSelectSetAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�Y�����锄��S�̐ݒ�</returns>
        public RecordType FindList(string enterpriseCode)
        {
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode);

            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            ArrayList foundRecordList = null;
            int status = RealAccesser.Search(out foundRecordList, enterpriseCode);
            if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            {
                //Debug.Assert(false, MY_NAME + "�̌��������s���܂����B");
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

            return FoundRecordMap[key];
        }

        /// <summary>
        /// �\���敪�擾���������i�f���Q�[�g�Ɏg�p�j
        /// </summary>
        /// <param name="displayDivList"></param>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <param name="blGoodsCode"></param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <param name="priceSelectDiv"></param>
        /// <remarks>
        /// <br>Note       : �\���敪�}�X�^���������܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/30</br>
        /// </remarks>
        public void GetDisplayDiv(List<PriceSelectSet> displayDivList, Int32 goodsMakerCode, Int32 blGoodsCode, Int32 customerCode, Int32 custRateGrpCode, out Int32 priceSelectDiv)
        {
            priceSelectDiv = -1;
            if (displayDivList == null) return;

            //-----------------------------------------------------------------------------
            // �\���敪����
            //-----------------------------------------------------------------------------
            RealAccesser.GetDisplayDiv(displayDivList, goodsMakerCode, blGoodsCode, customerCode, custRateGrpCode, out priceSelectDiv);
        }
    }
}
