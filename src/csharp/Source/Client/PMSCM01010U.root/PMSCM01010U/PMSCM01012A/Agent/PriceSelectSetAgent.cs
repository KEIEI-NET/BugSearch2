//****************************************************************************//
// システム         : 自働回答処理 表示区分マスタの代理人クラス
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/30  修正内容 : 新規作成
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
    /// 表示区分マスタの代理人クラス
    /// </summary>
    public sealed class PriceSelectSetAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "得意先掛率グループマスタ";

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PriceSelectSetAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>該当する売上全体設定</returns>
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
                //Debug.Assert(false, MY_NAME + "の検索が失敗しました。");
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
        /// 表示区分取得検索処理（デリゲートに使用）
        /// </summary>
        /// <param name="displayDivList"></param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="blGoodsCode"></param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <param name="priceSelectDiv"></param>
        /// <remarks>
        /// <br>Note       : 表示区分マスタを検索します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/30</br>
        /// </remarks>
        public void GetDisplayDiv(List<PriceSelectSet> displayDivList, Int32 goodsMakerCode, Int32 blGoodsCode, Int32 customerCode, Int32 custRateGrpCode, out Int32 priceSelectDiv)
        {
            priceSelectDiv = -1;
            if (displayDivList == null) return;

            //-----------------------------------------------------------------------------
            // 表示区分検索
            //-----------------------------------------------------------------------------
            RealAccesser.GetDisplayDiv(displayDivList, goodsMakerCode, blGoodsCode, customerCode, custRateGrpCode, out priceSelectDiv);
        }
    }
}
