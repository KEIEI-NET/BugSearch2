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
    using RealAccesserType  = AcptAnOdrTtlStAcs;
    using RecordType        = IList<AcptAnOdrTtlSt>;
    using ItemType          = AcptAnOdrTtlSt;

    /// <summary>
    /// 受発注管理全体設定マスタのアクセスクラスの代理人クラス
    /// </summary>
    public sealed class AcptAnOdrTtlStAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "受発注管理全体設定マスタ";

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public AcptAnOdrTtlStAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>該当する受発注管理全体設定</returns>
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
        /// <returns>該当する受発注管理全体設定 ※該当するものがない場合、<c>null</c>を返します。</returns>
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
                return null;
            }
        }
    }
}
