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
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2011/01/11  �C�����e : �q�Ƀ}�X�^�������ɋ��_���g�p���Ȃ��悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g���@�F��
// �� �� ��  2012/06/25  �C�����e : SCM��Q��10281 �����񓚑Ώۂ̑q�ɂ͈ϑ��q�ɁA�D��i�����_�j�q�ɂ̂�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = WarehouseAcs;
    // 2011/01/11 >>>
    //using RecordType        = ArrayList;
    using RecordType = List<Warehouse>;
    // 2011/01/11 <<<

    /// <summary>
    /// SCM�[���ݒ�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public class WarehouseAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "�q�Ƀ}�X�^";

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public WarehouseAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�Y������q��</returns>
        public RecordType Find(
            // 2011/01/11 >>>
            //string enterpriseCode,
            //string sectionCode
            string enterpriseCode
            // 2011/01/11 <<<
        )
        {
            const string METHOD_NAME = "Find(string, string)";  // ���O�p

            // 2011/01/11 >>>
            //string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatSectionCode(sectionCode);
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode);
            // 2011/01/11 <<<
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            RecordType foundRecord = null;
            // 2011/01/11 >>>
            //int status = RealAccesser.Search(out foundRecord, enterpriseCode, sectionCode);
            ArrayList foundArrayList;
            int status = RealAccesser.Search(out foundArrayList, enterpriseCode);
            // 2011/01/11 <<<
            if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            {
                Debug.Assert(false, MY_NAME + "�̌��������s���܂����B");
            }

            // 2011/01/11 >>>
            //if (foundRecord != null)
            if (foundArrayList != null)
            // 2011/01/11 <<<
            {
                // 2011/01/11 >>>
                //FoundRecordMap.Add(key, foundRecord);
                // 2011/01/11 <<<

                #region <Log>

                string msg = string.Format(
                    // 2011/01/11 >>>
                    //"�q�Ƀ}�X�^�̌������F{0}(���=�u{1}�v, ���_=�u{2}�v",
                    //foundRecord.Count,
                    //enterpriseCode,
                    //sectionCode
                    "�q�Ƀ}�X�^�̌������F{0}(���=�u{1}�v",
                    foundArrayList.Count,
                    enterpriseCode
                    // 2011/01/11 <<<
                );
                msg += Environment.NewLine;
                #endregion

                // 2011/01/11 >>>
                //StringBuilder text = new StringBuilder();
                //{
                //    foreach (Warehouse foundWarehouse in foundRecord)
                //    {
                //        text.Append("(W=").Append(foundWarehouse.WarehouseCode).Append(", C=").Append(foundWarehouse.CustomerCode).Append("), ");
                //    }
                //}

                List<Warehouse> warehouseList = new List<Warehouse>();
                StringBuilder text = new StringBuilder();
                foreach (Warehouse foundWarehouse in foundArrayList)
                {
                    if (foundWarehouse.LogicalDeleteCode != 0) continue;
                    warehouseList.Add(foundWarehouse);
                    text.Append("(W=").Append(foundWarehouse.WarehouseCode).Append(", C=").Append(foundWarehouse.CustomerCode).Append("), ");
                }

                FoundRecordMap.Add(key, warehouseList);
                foundRecord = FoundRecordMap[key];
                // 2011/01/11 <<<
                #region <Log>

                msg += text.ToString();

                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>
            }
            else
            {
                #region <Log>

                string msg = string.Format(
                    // 2011/01/11 >>>
                    //"�q�Ƀ}�X�^�̌������ʂ�null�ł��B(���=�u{0}�v, ���_=�u{1}�v",
                    //enterpriseCode,
                    //sectionCode

                    "�q�Ƀ}�X�^�̌������ʂ�null�ł��B(���=�u{0})",
                    enterpriseCode
                    // 2011/01/11 <<<
                );
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                // 2011/01/11 Add >>>
                FoundRecordMap.Add(key, new List<Warehouse>());
                // 2011/01/11 Add <<<
            }

            return foundRecord ?? new RecordType();
        }

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>�Y������q�� ���Y���Ȃ��̏ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
        public Warehouse Find(GoodsUnitData goodsUnitData)
        {
            const string METHOD_NAME = "Find(GoodsUnitData)";   // ���O�p

            #region <Guard Phrase>

            if (goodsUnitData == null) return null;
            if (string.IsNullOrEmpty(goodsUnitData.SelectedWarehouseCode)) return null;

            #endregion // </Guard Phrase>

            string enterpriseCode   = goodsUnitData.EnterpriseCode;
            // 2011/01/11 Del >>>
            //string sectionCode      = goodsUnitData.SectionCode;
            // 2011/01/11 Del <<<

            #region <Log>

            string msg = string.Format(
                // 2011/01/11 >>>
                //"�q�Ƀ}�X�^���������܂��B�i���i�̊��=�u{0}�v, ���i�̋��_=�u{1}�v�j",
                //enterpriseCode,
                //sectionCode
                "�q�Ƀ}�X�^���������܂��B�i���=�u{0}�v�j",
                enterpriseCode
                // 2011/01/11 <<<
                );
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            #endregion // </Log>

            // 2011/01/11 >>>
            //RecordType foundWarehouseList = Find(enterpriseCode, sectionCode);
            RecordType foundWarehouseList = Find(enterpriseCode);
            // 2011/01/11 <<<
            if (foundWarehouseList == null || foundWarehouseList.Count.Equals(0)) return null;

            string warehouseCode = goodsUnitData.SelectedWarehouseCode.Trim();

            // 2011/01/11 >>>
            //foreach (Warehouse warehouse in foundWarehouseList)
            //{
            //    if (warehouse.WarehouseCode.Trim().Equals(warehouseCode) && warehouse.LogicalDeleteCode.Equals(0))
            //    {
            //        return warehouse;
            //    }
            //}
            //return null;

            return foundWarehouseList.Find(
                delegate(Warehouse warehouse)
                {
                    return warehouse.WarehouseCode.Trim().Equals(warehouseCode.Trim());
                });
            // 2011/01/11 <<<
        }

        // ADD 2012/06/25 T.Yoshioka ��10281 ------------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �q�Ƀ}�X�^���X�g���������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�Y������q�� ���Y���Ȃ��̏ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
        public List<Warehouse> GetWarehouseList(string enterpriseCode)
        {
            const string METHOD_NAME = "GetWarehouseList(GoodsUnitData)";   // ���O�p

            #region <Log>

            string msg = string.Format(
                "�q�Ƀ}�X�^���X�g���������܂��B�i���=�u{0}�v�j",
                enterpriseCode
                );
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            #endregion // </Log>

            RecordType foundWarehouseList = Find(enterpriseCode);
            if (foundWarehouseList == null || foundWarehouseList.Count.Equals(0)) return null;

            return foundWarehouseList;
        }
        // ADD 2012/06/25 T.Yoshioka ��10281 ------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2011/01/11 Del >>>
        ///// <summary>
        ///// ���Ӑ悪���݂��邩���f���܂��B
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sectionCode">���_�R�[�h</param>
        ///// <param name="cunstomerCode">���Ӑ�R�[�h</param>
        ///// <param name="warehouseCode">�Y������q�ɃR�[�h</param>
        ///// <param name="warehouseName">�Y������q�ɖ���</param>
        ///// <returns>
        ///// <c>true</c> :���݂��܂��B<br/>
        ///// <c>false</c>:���݂��܂���B
        ///// </returns>
        //private bool ExistsCustomer(
        //    string enterpriseCode,
        //    string sectionCode,
        //    int cunstomerCode,
        //    out string warehouseCode,
        //    out string warehouseName
        //)
        //{
        //    warehouseCode = string.Empty;
        //    warehouseName = string.Empty;

        //    RecordType foundWarehouseList = Find(enterpriseCode, sectionCode);
        //    if (foundWarehouseList == null || foundWarehouseList.Count.Equals(0)) return false;

        //    foreach (Warehouse warehouse in foundWarehouseList)
        //    {
        //        if (warehouse.CustomerCode.Equals(cunstomerCode))
        //        {
        //            warehouseCode = warehouse.WarehouseCode;
        //            warehouseName = warehouse.WarehouseName;
        //            return true;
        //        }
        //    }
            
        //    return false;
        //}
        // 2011/01/11 Del <<<

        /// <summary>
        /// �q�ɃR�[�h���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="cunstomerCode">���Ӑ�R�[�h</param>
        /// <returns>�q�ɃR�[�h ���Y�����Ȃ��ꍇ�A<c>string.Empty</c>��Ԃ��܂��B</returns>
        public string GetWarehouseCode(
            string enterpriseCode,
            string sectionCode,
            int cunstomerCode
        )
        {
            // 2011/01/11 >>>
            //RecordType foundWarehouseList = Find(enterpriseCode, sectionCode);
            RecordType foundWarehouseList = Find(enterpriseCode);
            // 2011/01/11 <<<
            if (foundWarehouseList == null || foundWarehouseList.Count.Equals(0)) return string.Empty;

            string foundWarehouseCode = string.Empty;
            foreach (Warehouse warehouse in foundWarehouseList)
            {
                if (warehouse.CustomerCode.Equals(cunstomerCode))
                {
                    foundWarehouseCode = warehouse.WarehouseCode;
                    break;
                }
            }
            return foundWarehouseCode;
        }
    }
}
