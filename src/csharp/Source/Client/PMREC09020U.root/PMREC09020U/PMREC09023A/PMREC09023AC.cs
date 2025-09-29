//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買得情報マスタアクセスクラス
// プログラム概要   : 売上全体設定マスタアクセス制御を行います
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上千加子
// 作 成 日  2015/02/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
//using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = SalesTtlStAcs;
    using RecordType        = IList<SalesTtlSt>;
    using ItemType          = SalesTtlSt;

    /// <summary>
    /// 売価未設定時区分列挙型
    /// </summary>
    public enum UnPrcNonSettingDiv : int
    {
        /// <summary>0:ゼロ表示</summary>
        Zero = 0,
        /// <summary>1:定価表示</summary>
        List = 1
    }

    /// <summary>
    /// 売上全体設定マスタのアクセスクラスの代理人クラス
    /// </summary>
    public sealed class SalesTtlStAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "売上全体設定マスタ";
        /// <summary>企業コードのフォーマット</summary>
        private const string ENTERPRISE_CODE_FORMAT = "0000000000000000";
        /// <summary>全社設定</summary>
        public const string ALL_SECTION_CODE = "00";

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SalesTtlStAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>該当する売上全体設定</returns>
        public RecordType Find(string enterpriseCode)
        {
            string key = FormatEnterpriseCode(enterpriseCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            RealAccesser.IsLocalDBRead = false;
            ArrayList foundRecordList = null;
            int status = RealAccesser.SearchOnlySalesTtlInfo(out foundRecordList, enterpriseCode);
            if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            {
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
        /// <returns>該当する売上全体設定 ※該当するものがない場合、<c>null</c>を返します。</returns>
        public ItemType Find(
            string enterpriseCode,
            string sectionCode
        )
        {
            RecordType foundRecord = null;
            {
                string key = FormatEnterpriseCode(enterpriseCode);
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

                // 全社設定で再検索
                int sectionCodeNo = ConvertNumber(sectionCode.Trim());
                if (sectionCodeNo > 0)
                {
                    return Find(enterpriseCode, ALL_SECTION_CODE);
                }

                return null;
            }
        }

        /// <summary>
        /// 売価が未設定の場合、定価を使用するか判断します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>
        /// <c>true</c> :定価を使用します。（該当する売上全体設定の売価未設定時区分が「1:定価表示」）<br/>
        /// <c>false</c>:定価を使用しません。
        /// </returns>
        public bool UsesListPriceIfSalesPriceIsNone(
            string enterpriseCode,
            string sectionCode
        )
        {
            ItemType foundRecord = Find(enterpriseCode, sectionCode);
            if (foundRecord != null)
            {
                return foundRecord.UnPrcNonSettingDiv.Equals((int)UnPrcNonSettingDiv.List);
            }
            return false;
        }

        /// <summary>
        /// 企業コードを書式付変換します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>enterpriseCodeNo.ToString("0000000000000000") ※16桁</returns>
        private string FormatEnterpriseCode(string enterpriseCode)
        {
            return FormatCode(enterpriseCode, ENTERPRISE_CODE_FORMAT);
        }

        /// <summary>
        /// ○○コードを書式付変換します。
        /// </summary>
        /// <param name="code">○○コード値</param>
        /// <param name="format">書式</param>
        /// <returns>codeNo.ToString(format)</returns>
        private static string FormatCode(
            string code,
            string format
        )
        {
            long codeNo = 0;
            if (!long.TryParse(code.Trim(), out codeNo))
            {
                codeNo = 0;
            }
            return codeNo.ToString(format);
        }

        /// <summary>
        /// 数値に変換します。
        /// </summary>
        /// <param name="target">対象文字列</param>
        /// <returns>数値に変換できない場合、<c>0</c>を返します。</returns>
        private int ConvertNumber(string target)
        {
            if (string.IsNullOrEmpty(target.Trim())) return 0;

            int number = 0;
            return int.TryParse(target.Trim(), out number) ? number : 0;
        }

    }
}
