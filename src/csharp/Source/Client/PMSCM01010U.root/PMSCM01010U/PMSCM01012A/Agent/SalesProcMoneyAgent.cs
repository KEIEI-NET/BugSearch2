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
// 管理番号              作成担当 : 30517　夏野 駿希 
// 作 成 日  2010/07/07  修正内容 : 端数処理区分，端数処理単位が取得できていない不具合の修正
//----------------------------------------------------------------------------//
//#define _RETURN_NULL_IF_    // 検索結果がない場合、nullを返すフラグ

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
    /// 売上金額処理区分マスタのアクセスクラスの代理人クラス
    /// </summary>
    public sealed class SalesProcMoneyAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "売上金額処理区分マスタ";

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SalesProcMoneyAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>該当する売上金額処理区分</returns>
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
    /// 仕入金額処理区分マスタのアクセスクラスの代理人クラス
    /// </summary>
    public sealed class StockProcMoneyAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "仕入金額処理区分マスタ";

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public StockProcMoneyAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>該当する売上金額処理区分</returns>
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
                Debug.Assert(false, MY_NAME + "の検索が失敗しました。");
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
