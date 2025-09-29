//**********************************************************************//
// システム         ：PM.NS
// プログラム名称   ：PMTAB 自動回答処理(検索) テーブルアクセスクラス
// プログラム概要   ：PMTAB常駐処理よりパラメータで車両、部品検索条件が渡される
//                    車両、部品検索条件より車両、部品の検索を行い、
//                    取得した情報をSCM_DBの検索結果関連のテーブルに書込む
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
//----------------------------------------------------------------------//
// 管理番号  10902622-01  作成担当 : songg
// 作 成 日  2013/05/29   作成内容 : PMTAB 自動回答処理(検索)
//----------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType = SalesTtlStAcs;
    using RecordType = IList<SalesTtlSt>;
    using ItemType = SalesTtlSt;

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
    public sealed class SalesTtlStAgentForTablet : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "売上全体設定マスタ";

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SalesTtlStAgentForTablet() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>該当する売上全体設定</returns>
        public RecordType Find(string enterpriseCode)
        {
            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            RealAccesser.IsLocalDBRead = false;
            ArrayList foundRecordList = null;
            int status = RealAccesser.SearchOnlySalesTtlInfo(out foundRecordList, enterpriseCode);
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
                string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode);
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
                int sectionCodeNo = SCMEntityUtil.ConvertNumber(sectionCode.Trim());
                if (sectionCodeNo > 0)
                {
                    return Find(enterpriseCode, "00");
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
    }

    /// <summary>
    /// SCM受注データユーティリティ
    /// </summary>
    public static class SCMEntityUtil
    {
        #region <日時>

        /// <summary>日付フォーマット</summary>
        public const string YYYYMMDD = "yyyyMMdd";
        /// <summary>日時フォーマット</summary>
        public const string YYYYMMDDHHMMSS = "yyyyMMddhhmmss";

        /// <summary>
        /// 日付を数値に変換します。
        /// </summary>
        /// <param name="date">日付</param>
        /// <returns>yyyyMMdd</returns>
        public static int ConvertToYYYYMMDD(DateTime date)
        {
            string yyyyMMdd = date.ToString(YYYYMMDD);
            return int.Parse(yyyyMMdd);
        }

        /// <summary>
        /// 日付に変換します。
        /// </summary>
        /// <param name="yyyyMMdd">日付数(yyyyMMdd)</param>
        /// <returns>"yyyy/MM/dd"</returns>
        public static DateTime ConvertToDate(int yyyyMMdd)
        {
            #region <Guard Phrase>

            if (yyyyMMdd <= 0) return DateTime.MinValue;

            #endregion // </Guard Phrase>

            string yyyy = yyyyMMdd.ToString().Substring(0, 4);
            string MM = yyyyMMdd.ToString().Substring(4, 2);
            string dd = yyyyMMdd.ToString().Substring(6, 2);

            return new DateTime(int.Parse(yyyy), int.Parse(MM), int.Parse(dd));
        }

        /// <summary>
        /// 日時に変換します。
        /// </summary>
        /// <param name="longNumber">日時数</param>
        /// <returns>"yyyy/MM/dd hh:mm:ss"</returns>
        public static DateTime ConvertToDateTime(long longNumber)
        {
            #region <Guard Phrase>

            if (longNumber <= 0) return DateTime.MinValue;

            #endregion // </Guard Phrase>

            return new DateTime(longNumber);
        }

        /// <summary>
        /// 日時を数値に変換します。
        /// </summary>
        /// <param name="dateTime">日時</param>
        /// <returns>Convert.ToInt64(dateTime)</returns>
        public static long ConvertToLong(DateTime dateTime)
        {
            return dateTime.Ticks;
        }

        #endregion // </日時>



        #region <書式付コード>

        /// <summary>企業コードのフォーマット</summary>
        private const string ENTERPRISE_CODE_FORMAT = "0000000000000000";
        /// <summary>拠点コードのフォーマット</summary>
        private const string SECTION_CODE_FORMAT = "00";
        /// <summary>問合せ番号のフォーマット</summary>
        private const string INQUIRY_NUMBER_FORMAT = ENTERPRISE_CODE_FORMAT;
        /// <summary>更新年月日のフォーマット</summary>
        private const string UPDATE_DATE_FORMAT = "yyyyMMdd";
        /// <summary>更新時分秒ミリ秒のフォーマット</summary>
        private const string UPDATE_TIME_FORMAT = "000000000";
        /// <summary>問合せ・発注種別のフォーマット</summary>
        private const string INQ_ORD_DIV_CD_FORMAT = "00";
        /// <summary>問合せ行番号のフォーマット</summary>
        private const string INQ_ROW_NUMBER_FORMAT = "00";
        /// <summary>問合せ行番号枝番のフォーマット</summary>
        private const string INQ_ROW_NUM_DERIVED_NO_FORMAT = "00";
        /// <summary>受注ステータスのフォーマット</summary>
        private const string ACPT_AN_ODR_STATUS = "00";
        /// <summary>売上伝票番号のフォーマット</summary>
        // 2011/02/09 >>>
        //private const string SALES_SLIP_NUM_FORMAT = "000000000";
        public const string SALES_SLIP_NUM_FORMAT = "000000000";
        // 2011/02/09 <<<
        /// <summary>従業員コードのフォーマット</summary>
        private const string EMPLOYEE_CODE_FORMAT = "000000000";

        /// <summary>
        /// 企業コードを書式付変換します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>enterpriseCodeNo.ToString("0000000000000000") ※16桁</returns>
        public static string FormatEnterpriseCode(string enterpriseCode)
        {
            return FormatCode(enterpriseCode, ENTERPRISE_CODE_FORMAT);
        }

        /// <summary>
        /// 拠点コードを書式付変換します。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>sectionCodeNo.ToString("00") ※2桁</returns>
        public static string FormatSectionCode(string sectionCode)
        {
            return FormatCode(sectionCode, SECTION_CODE_FORMAT);
        }

        /// <summary>
        /// 売上伝票番号を書式付変換します。
        /// </summary>
        /// <param name="salseSlipNum">売上伝票番号</param>
        /// <returns>sectionCodeNo.ToString("00") ※9桁</returns>
        public static string FormatSalseSlipNum(string salseSlipNum)
        {
            return FormatCode(salseSlipNum, SALES_SLIP_NUM_FORMAT);
        }

        /// <summary>
        /// 従業員コードを書式付変換します。
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>employeeCode.ToString("000000000") ※9桁</returns>
        public static string FormatEmployeeCode(string employeeCode)
        {
            return FormatCode(employeeCode, EMPLOYEE_CODE_FORMAT);
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

        #endregion // </書式付コード>

        /// <summary>
        /// 数値に変換します。
        /// </summary>
        /// <param name="target">対象文字列</param>
        /// <returns>数値に変換できない場合、<c>0</c>を返します。</returns>
        public static int ConvertNumber(string target)
        {
            if (string.IsNullOrEmpty(target.Trim())) return 0;

            int number = 0;
            return int.TryParse(target.Trim(), out number) ? number : 0;
        }
    }
}
