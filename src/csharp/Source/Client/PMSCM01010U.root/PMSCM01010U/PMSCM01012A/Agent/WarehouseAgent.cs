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
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/01/11  修正内容 : 倉庫マスタ検索等に拠点を使用しないように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/06/25  修正内容 : SCM障害№10281 自動回答対象の倉庫は委託倉庫、優先（自拠点）倉庫のみ
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
    /// SCM納期設定アクセスの代理人クラス
    /// </summary>
    public class WarehouseAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "倉庫マスタ";

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public WarehouseAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>該当する倉庫</returns>
        public RecordType Find(
            // 2011/01/11 >>>
            //string enterpriseCode,
            //string sectionCode
            string enterpriseCode
            // 2011/01/11 <<<
        )
        {
            const string METHOD_NAME = "Find(string, string)";  // ログ用

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
                Debug.Assert(false, MY_NAME + "の検索が失敗しました。");
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
                    //"倉庫マスタの検索数：{0}(企業=「{1}」, 拠点=「{2}」",
                    //foundRecord.Count,
                    //enterpriseCode,
                    //sectionCode
                    "倉庫マスタの検索数：{0}(企業=「{1}」",
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
                    //"倉庫マスタの検索結果がnullです。(企業=「{0}」, 拠点=「{1}」",
                    //enterpriseCode,
                    //sectionCode

                    "倉庫マスタの検索結果がnullです。(企業=「{0})",
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
        /// 検索します。
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>該当する倉庫 ※該当なしの場合、<c>null</c>を返します。</returns>
        public Warehouse Find(GoodsUnitData goodsUnitData)
        {
            const string METHOD_NAME = "Find(GoodsUnitData)";   // ログ用

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
                //"倉庫マスタを検索します。（商品の企業=「{0}」, 商品の拠点=「{1}」）",
                //enterpriseCode,
                //sectionCode
                "倉庫マスタを検索します。（企業=「{0}」）",
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

        // ADD 2012/06/25 T.Yoshioka №10281 ------------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 倉庫マスタリストを検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>該当する倉庫 ※該当なしの場合、<c>null</c>を返します。</returns>
        public List<Warehouse> GetWarehouseList(string enterpriseCode)
        {
            const string METHOD_NAME = "GetWarehouseList(GoodsUnitData)";   // ログ用

            #region <Log>

            string msg = string.Format(
                "倉庫マスタリストを検索します。（企業=「{0}」）",
                enterpriseCode
                );
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            #endregion // </Log>

            RecordType foundWarehouseList = Find(enterpriseCode);
            if (foundWarehouseList == null || foundWarehouseList.Count.Equals(0)) return null;

            return foundWarehouseList;
        }
        // ADD 2012/06/25 T.Yoshioka №10281 ------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2011/01/11 Del >>>
        ///// <summary>
        ///// 得意先が存在するか判断します。
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="sectionCode">拠点コード</param>
        ///// <param name="cunstomerCode">得意先コード</param>
        ///// <param name="warehouseCode">該当する倉庫コード</param>
        ///// <param name="warehouseName">該当する倉庫名称</param>
        ///// <returns>
        ///// <c>true</c> :存在します。<br/>
        ///// <c>false</c>:存在しません。
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
        /// 倉庫コードを取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="cunstomerCode">得意先コード</param>
        /// <returns>倉庫コード ※該当がない場合、<c>string.Empty</c>を返します。</returns>
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
