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
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2010/03/12  修正内容 : 高速化
//----------------------------------------------------------------------------//
using System;
using System.Diagnostics;
// 2010/03/12 Add >>>
using System.Collections;
using System.Collections.Generic;
// 2010/03/12 Add <<<

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = EstimateDefSetAcsForServer;
    using RecordType        = EstimateDefSet;

    #region <サーバ用アクセスクラス>

    /// <summary>
    /// サーバ用見積初期値設定アクセスクラス
    /// </summary>
    public sealed class EstimateDefSetAcsForServer : EstimateDefSetAcs
    {
        /// <summary>サーバ用コンストラクタのパラメータ</summary>
        private const int SERVER_MODE = 1;

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public EstimateDefSetAcsForServer() : base(SERVER_MODE) { }
    }

    #endregion // </サーバ用アクセスクラス>

    /// <summary>
    /// 見積初期値設定マスタのアクセスクラスの代理人クラス
    /// </summary>
    public class EstimateDefSetAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "見積初期値設定マスタ";

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public EstimateDefSetAgent() : base() { }

        #endregion // </Constructor>

        // 2010/03/12 Add >>>
        Dictionary<string, List<RecordType>> _recordlist;

        /// <summary>
        /// 見積全体設定を、拠点コード逆順にソートする
        /// </summary>
        /// <remarks></remarks>
        private class EstiamteDefSetComparer : Comparer<RecordType>
        {
            public override int Compare(RecordType x, RecordType y)
            {
                int result = y.SectionCode.Trim().CompareTo(x.SectionCode.Trim());
                if (result != 0) return result;

                return result;
            }
        }
        // 2010/03/12 Add <<<

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>該当する見積初期値設定</returns>
        public RecordType Find(
            string enterpriseCode,
            string sectionCode
        )
        {
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatSectionCode(sectionCode);
            // 2010/03/12 >>>
            //if (FoundRecordMap.ContainsKey(key))
            //{
            //    return FoundRecordMap[key];
            //}

            //RecordType foundRecord = null;
            //int status = RealAccesser.Read(out foundRecord, enterpriseCode, sectionCode);
            //if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            //{
            //    Debug.Assert(false, MY_NAME + "の検索が失敗しました。");
            //    return null;
            //}

            //if (foundRecord != null && foundRecord.LogicalDeleteCode.Equals(0))
            //{
            //    FoundRecordMap.Add(key, foundRecord);
            //}

            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            if (_recordlist == null) _recordlist = new Dictionary<string, List<RecordType>>();

            if (!_recordlist.ContainsKey(enterpriseCode))
            {
                _recordlist.Add(enterpriseCode, GetRecordList(enterpriseCode));
            }


            RecordType foundRecord = null;

            if (_recordlist[enterpriseCode] != null && _recordlist[enterpriseCode].Count > 0)
            {
                foundRecord = ( (List<RecordType>)_recordlist[enterpriseCode] ).Find(
                     delegate(RecordType rec)
                     {
                         if (rec.SectionCode.Trim() == sectionCode.Trim() || rec.SectionCode.Trim() == "00")
                         {
                             return true;
                         }
                         return false;
                     });
            }

            if (foundRecord != null && foundRecord.LogicalDeleteCode.Equals(0))
            {
                FoundRecordMap.Add(key, foundRecord);
            }
            // 2010/03/12 <<<

            return foundRecord ?? new RecordType();
        }

        // 2010/03/12 Add >>>
        private List<RecordType> GetRecordList(string enterpriseCode)
        {
            List<RecordType> retList = new List<RecordType>();
            ArrayList al;
            int status = RealAccesser.Search(out al, enterpriseCode);

            if (status.Equals((int)ResultUtil.ResultCode.Normal))
            {
                if (al != null && al.Count > 0)
                {
                    foreach (EstimateDefSet rec in al)
                    {
                        retList.Add(rec);
                    }

                    retList.Sort(new EstiamteDefSetComparer());
                }
            }

            return retList;
        }
        // 2010/03/12 Add <<<

        /// <summary>
        /// 見積有効期限を取得します。
        /// </summary>
        /// <param name="estimateDefSet">見積初期値設定</param>
        /// <returns>システム日付 + 見積初期値設定.見積書有効期限</returns>
        public static DateTime GetEstimateValidityDate(EstimateDefSet estimateDefSet)
        {
            return DateTime.Now.AddDays(estimateDefSet.EstimateValidityTerm);
        }
    }
}
