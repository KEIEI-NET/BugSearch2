//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/06/25  修正内容 : 新規作成
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
    using RealAccesserType  = SalesTtlStAcs;
    using RecordType        = IList<SalesTtlSt>;
    using ItemType          = SalesTtlSt;

    /// <summary>
    /// 売価未設定時区分列挙型
    /// </summary>
    public enum UnPrcNonSettingDiv : int
    {
        /// <summary>0:ゼロ表示</summary>
        Zero = 0,
        /// <summary>1:定価表示</summary>
        List = 1
    }

    /// <summary>
    /// 売上全体設定マスタのアクセスクラスの代理人クラス
    /// </summary>
    public sealed class SalesTtlStAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "売上全体設定マスタ";

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SalesTtlStAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>該当する売上全体設定</returns>
        public RecordType Find(string enterpriseCode)
        {
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            RealAccesser.IsLocalDBRead = false;
            ArrayList foundRecordList = null;
            int status = RealAccesser.SearchOnlySalesTtlInfo(out foundRecordList, enterpriseCode);
            if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            {
                Debug.Assert(false, MY_NAME + "の検索が失敗しました。");
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
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>該当する売上全体設定 ※該当するものがない場合、<c>null</c>を返します。</returns>
        public ItemType Find(
            string enterpriseCode,
            string sectionCode
        )
        {
            RecordType foundRecord = null;
            {
                string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode);
                if (FoundRecordMap.ContainsKey(key))
                {
                    foundRecord = FoundRecordMap[key];
                }
                else
                {
                    foundRecord = Find(enterpriseCode);
                }
                if (foundRecord == null) return null;

                foreach (ItemType foundItem in foundRecord)
                {
                    if (foundItem.SectionCode.Trim().Equals(sectionCode.Trim()))
                    {
                        return foundItem;
                    }
                }

                // 全社設定で再検索
                int sectionCodeNo = SCMEntityUtil.ConvertNumber(sectionCode.Trim());
                if (sectionCodeNo > 0)
                {
                    return Find(enterpriseCode, SecInfoSetAgent.ALL_SECTION_CODE);
                }

                return null;
            }
        }

        /// <summary>
        /// 売価が未設定の場合、定価を使用するか判断します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>
        /// <c>true</c> :定価を使用します。（該当する売上全体設定の売価未設定時区分が「1:定価表示」）<br/>
        /// <c>false</c>:定価を使用しません。
        /// </returns>
        public bool UsesListPriceIfSalesPriceIsNone(
            string enterpriseCode,
            string sectionCode
        )
        {
            ItemType foundRecord = Find(enterpriseCode, sectionCode);
            if (foundRecord != null)
            {
                return foundRecord.UnPrcNonSettingDiv.Equals((int)UnPrcNonSettingDiv.List);
            }
            return false;
        }
    }
}
