//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限設定アクセス
// プログラム概要   : DataTime関連の共通処理を実装します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/07/31  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// DateTimeユーティリティ
    /// </summary>
    public static class DateTimeUtil
    {
        /// <summary>デフォルトの日付フォーマット</summary>
        public const string DEFAULT_DATE_TIME_FORMAT = "yyyy/MM/dd";

        /// <summary>デフォルトの開始時間</summary>
        public const string DEFAULT_FROM_TIME = "00:00:00";

        /// <summary>デフォルトの終了時間</summary>
        public const string DEFAULT_TO_TIME = "23:59:59";

        /// <summary>
        /// DateTime型の日付に変換します。
        /// </summary>
        /// <param name="yyyyMMdd">int型の日付</param>
        /// <returns>DateTime型の日付</returns>
        public static DateTime ToDateTime(int yyyyMMdd)
        {
            const string DATE_TIME_FORMAT = "yyyyMMdd";
            return Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(DATE_TIME_FORMAT, yyyyMMdd);
        }

        /// <summary>
        /// long型の日時に変換します。
        /// </summary>
        /// <param name="dateTime">DateTime型の日時</param>
        /// <returns>long型の日時</returns>
        public static long ToLong(DateTime dateTime)
        {
            return (long)Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate(dateTime);
        }

        /// <summary>
        /// 日時に不正があるか判定します。
        /// </summary>
        /// <remarks>
        /// 開始日付と終了日付の期間が3ヶ月を超える場合、エラーとみなします。
        /// </remarks>
        /// <param name="from">開始日時</param>
        /// <param name="to">終了日時</param>
        /// <returns>true :あり<br/>false:なし</returns>
        public static bool HasError(
            DateTime from,
            DateTime to
        )
        {
            if (from > to) return true;

            DateTime fromDate   = new DateTime(from.Year, from.Month, from.Day);
            DateTime maxDate    = fromDate.AddMonths(3);

            DateTime toDate = new DateTime(to.Year, to.Month, to.Day);
            if (toDate > maxDate) return true;

            return false;
        }

        /// <summary>
        /// 降順の比較者クラス
        /// </summary>
        public class ReverseComparer : IComparer<DateTime>
        {
            #region IComparer<DateTime> メンバ

            /// <summary>
            /// 比較します。
            /// </summary>
            /// <param name="x">左辺</param>
            /// <param name="y">右辺</param>
            /// <returns>
            /// <c>x < y</c> :<c>1</c><br/>
            /// <c>x > y</c> :<c>-1</c><br/>
            /// <c>x == y</c>:<c>0</c>
            /// </returns>
            public int Compare(DateTime x, DateTime y)
            {
                if (x < y) return 1;
                if (x > y) return -1;
                return 0;
            }

            #endregion

            #region <Constructor/>

            /// <summary>
            /// デフォルトコンストラクタ
            /// </summary>
            public ReverseComparer() { }

            #endregion  // <Constructor/>
        }
    }

    /// <summary>
    /// アセンブリユーティリティ
    /// </summary>
    public static class AssemblyUtil
    {
        /// <summary>
        /// 名称を取得します。
        /// </summary>
        /// <param name="assembly">アセンブリ</param>
        /// <returns>名称</returns>
        public static string GetName(Assembly assembly)
        {
            string[] fullNames = assembly.FullName.Split(',');
            return fullNames[0];
        }
    }
}
