//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : SCM全体設定マスタアクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : duzg
// 作 成 日  2011/07/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2012/05/01  修正内容 : PCC全体設定　全社レコード参照対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Collections; // 2012/05/01

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType = SCMTtlStAcs;
    using RecordType = SCMTtlSt;

    /// <summary>
    /// SCM全体設定マスタアクセスの代理人クラス
    /// </summary>
    public class SCMTtlStAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        // ログ用
        private const string MY_NAME = "SCM全体設定マスタ";
        private const string CLASS_NAME = "SCMTtlStAgent";

        //>>>2012/05/01
        Dictionary<string, List<RecordType>> _recordlist;

        /// <summary>
        /// PCC全体設定を、拠点コード逆順にソートする
        /// </summary>
        /// <remarks></remarks>
        private class SCMTtlStComparer : Comparer<RecordType>
        {
            public override int Compare(RecordType x, RecordType y)
            {
                int result = y.SectionCode.Trim().CompareTo(x.SectionCode.Trim());
                if (result != 0) return result;

                return result;
            }
        }
        //<<<2012/05/01

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>該当するSCM全体設定</returns>
        public RecordType Find(
            string enterpriseCode,
            string sectionCode
        )
        {
            // ログ用
            const string METHOD_NAME = "Find()";

            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatEmployeeCode(sectionCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            //>>>2012/05/01
            //SCMTtlSt foundSCMTtlSt = null;
            //int status = RealAccesser.Read(out foundSCMTtlSt, enterpriseCode, sectionCode);
            //if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            //{
            //    #region <Log>

            //    string msg = string.Format(
            //        "SCM全体設定マスタの検索エラー：{0}(企業コード={1}, 拠点コード={2})",
            //        status,
            //        enterpriseCode,
            //        sectionCode
            //    );
            //    EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            //    #endregion // </Log>

            //    Debug.Assert(false, MY_NAME + "の検索が失敗しました。");
            //}

            //if (foundSCMTtlSt != null && foundSCMTtlSt.LogicalDeleteCode.Equals(0))
            //{
            //    FoundRecordMap.Add(key, foundSCMTtlSt);
            //}

            //return foundSCMTtlSt ?? new RecordType();

            RecordType foundRecord = null;

            if (_recordlist == null) _recordlist = new Dictionary<string, List<RecordType>>();

            if (!_recordlist.ContainsKey(enterpriseCode))
            {
                _recordlist.Add(enterpriseCode, GetRecordList(enterpriseCode));
            }

            if (_recordlist[enterpriseCode] != null && _recordlist[enterpriseCode].Count > 0)
            {
                foundRecord = ((List<RecordType>)_recordlist[enterpriseCode]).Find(
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

            return foundRecord ?? new RecordType();
            //<<<2012/05/01

        }

        //2012/05/01
        private List<RecordType> GetRecordList(string enterpriseCode)
        {
            List<RecordType> retList = new List<RecordType>();
            ArrayList al;
            int status = RealAccesser.Search(out al, enterpriseCode);

            if (status.Equals((int)ResultUtil.ResultCode.Normal))
            {
                if (al != null && al.Count > 0)
                {
                    foreach (SCMTtlSt rec in al)
                    {
                        if (rec.LogicalDeleteCode == 0)
                        {
                            retList.Add(rec);
                        }
                    }

                    retList.Sort(new SCMTtlStComparer());
                }
            }

            return retList;
        }
        //<<<2012/05/01
    }
}
