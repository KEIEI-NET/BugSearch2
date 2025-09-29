//****************************************************************************//
// システム         : 自働回答処理 得意先掛率グループマスタの代理人クラス
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
    using RealAccesserType = CustRateGroupAcs;
    using RecordType = IList<CustRateGroup>;
    using ItemType = CustRateGroup;


    /// <summary>
    /// 得意先掛率グループマスタの代理人クラス
    /// </summary>
    public sealed class CustRateGroupAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "得意先掛率グループマスタ";

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public CustRateGroupAgent() : base() { }

        #endregion // </Constructor>


        #region キャッシュ 
        #endregion

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>得意先掛率グループリスト</returns>
        public ArrayList FindList(string enterpriseCode)
        {
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode);

            if (FoundRecordMap.ContainsKey(key))
            {
                return new ArrayList(( (List<ItemType>)FoundRecordMap[key] ).ToArray());
            }

            ArrayList foundRecordList = null;
            int status = RealAccesser.Search(out foundRecordList, enterpriseCode, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
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
            else
            {
                foundRecord = new List<ItemType>();
            }

            if (foundRecord != null)
            {
                FoundRecordMap.Add(key, foundRecord);
            }

            return new ArrayList(( (List<ItemType>)FoundRecordMap[key] ).ToArray());
        }

        /// <summary>
        /// 得意先掛率グループ検索処理（デリゲートに使用）
        /// </summary>
        /// <param name="custRateGrpCodeList">得意先マスタ(掛率グループ)リスト</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループ情報を検索します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/30</br>
        /// </remarks>
        public void GetCustRateGrpCode(ArrayList custRateGrpCodeList, int customerCode, int goodsMakerCode, out int custRateGrpCode)
        {
            custRateGrpCode = 0;
            if (custRateGrpCodeList == null) return;

            RealAccesser.GetCustRateGrp(custRateGrpCodeList, customerCode, goodsMakerCode, out custRateGrpCode);
        }
    }
}
