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
// 作 成 日  2009/06/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 田建委
// 修 正 日  2020/05/15  修正内容 : PMKOBETSU-3932 BLP障害（ログ強化）
//                                : 既存コードのログ出力強化を行う
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Diagnostics;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = SecInfoSetAcs;
    using RecordType        = SecInfoSet;

    /// <summary>
    /// 拠点設定アクセスの代理人クラス
    /// </summary>
    public class SecInfoSetAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "拠点設定マスタ";

        /// <summary>全社設定</summary>
        public const string ALL_SECTION_CODE = "00";

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SecInfoSetAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>該当する拠点設定</returns>
        public RecordType Find(
            string enterpriseCode,
            string sectionCode
        )
        {
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatSectionCode(sectionCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            RecordType foundRecord = null;
            EasyLogger.Write(MY_NAME, "Find()", "該当する拠点設定検索　開始" + "パラメータ：" + "enterpriseCode:" + enterpriseCode + "sectionCode:" + sectionCode.Trim()); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            int status = RealAccesser.Read(out foundRecord, enterpriseCode, sectionCode);
            EasyLogger.Write(MY_NAME, "Find()", "該当する拠点設定検索　完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            {
                Debug.Assert(false, MY_NAME + "の検索が失敗しました。");
            }

            if (foundRecord != null && foundRecord.LogicalDeleteCode.Equals(0))
            {
                FoundRecordMap.Add(key, foundRecord);
            }

            return foundRecord ?? new RecordType();
        }

        /// <summary>
        /// 倉庫が存在するか判断します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>
        /// <c>true</c> :存在します。<br/>
        /// <c>false</c>:存在しません。
        /// </returns>
        public bool ExistsWarehouse(
            string enterpriseCode,
            string sectionCode,
            string warehouseCode
        )
        {
            RecordType foundSectionSet = Find(enterpriseCode, sectionCode);
            {
                if (foundSectionSet == null) return false;

                if (foundSectionSet.SectWarehouseCd1.Trim().Equals(warehouseCode.Trim()))
                {
                    return true;
                }
                if (foundSectionSet.SectWarehouseCd2.Trim().Equals(warehouseCode.Trim()))
                {
                    return true;
                }
                if (foundSectionSet.SectWarehouseCd3.Trim().Equals(warehouseCode.Trim()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
