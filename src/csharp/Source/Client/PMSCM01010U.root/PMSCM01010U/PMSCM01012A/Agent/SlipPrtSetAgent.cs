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
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = SlipPrtSetAcs;
    using RecordType        = IList<SlipPrtSet>;
    using ItemType          = SlipPrtSet;

    using CustSlipMngServer = SingletonInstance<CustSlipMngAgent>;  // 得意先マスタ(伝票管理)

    /// <summary>
    /// 伝票印刷設定マスタのアクセスクラスの代理人クラス
    /// </summary>
    public sealed class SlipPrtSetAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "伝票印刷設定マスタ";

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SlipPrtSetAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>該当する伝票印刷設定</returns>
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
        /// 伝票印刷設定情報を取得します。
        /// </summary>
        /// <param name="slipKind">伝票種別</param>
        /// <param name="salesSlip">売上データ</param>
        /// <returns>伝票印刷設定情報</returns>
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
        /// 伝票印刷設定情報を取得します。
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.GetPrtSlipSet() 14167行目より移植
        /// </remarks>
        /// <param name="slipKind">伝票種別</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>伝票印刷設定情報</returns>
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
