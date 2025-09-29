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

    #region <サーバ用アクセスクラス>

    /// <summary>
    /// サーバ用得意先マスタ(伝票管理)アクセスクラス
    /// </summary>
    public sealed class CustSlipMngAcsForServer : CustSlipMngAcs
    {
        /// <summary>サーバ用コンストラクタのパラメータ</summary>
        private const int SERVER_MODE = 1;

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public CustSlipMngAcsForServer() : base(SERVER_MODE) { }
    }

    #endregion // </サーバ用アクセスクラス>

    /// <summary>
    /// 得意先マスタ(伝票管理)のアクセスクラスの代理人クラス
    /// </summary>
    public sealed class CustSlipMngAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "得意先マスタ(伝票管理)";

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public CustSlipMngAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>該当する得意先マスタ(伝票管理)</returns>
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
                Debug.Assert(false, MY_NAME + "の検索が失敗しました。");
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
