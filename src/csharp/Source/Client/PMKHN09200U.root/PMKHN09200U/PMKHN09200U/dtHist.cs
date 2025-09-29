using System;
using System.Data;
using System.Text;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    // ADD 2009/01/22 機能追加：価格改正、優良設定マスタの追加 ---------->>>>>
    /// <summary>
    /// 履歴表示／更新処理データセット
    /// </summary>
    partial class dtHist
    {
        /// <summary>
        /// 更新対象となる基準日付を取得します。
        /// </summary>
        /// <returns>更新対象となる基準日付（"yyyyMMdd"）</returns>
        public DateTime GetTargetDate()
        {
            StringBuilder orderBy = new StringBuilder();
            {
                orderBy.Append(this.Update.PrevUpdDateColumn.ColumnName).Append(ADOUtil.DESC);
            }
            DataRow[] foundRows = this.Update.Select(string.Empty, orderBy.ToString());

            return DateTime.Parse(((dtHist.UpdateRow)foundRows[0]).PrevUpdDate);
        }

        /// <summary>
        /// 前回処理日を取得します。
        /// </summary>
        /// <param name="previousDate">前回処理日の日時</param>
        /// <returns><c>previousDate.ToString()</c> ※<c>DateTime.Minvalue</c>の場合、<c>string.Empty</c>を返します。</returns>
        public static string GetPrevUpdDate(DateTime previousDate)
        {
            if (!previousDate.Equals(DateTime.MinValue))
            {
                return previousDate.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 更新件数を取得します。
        /// </summary>
        /// <param name="previousCount">更新件数の数値</param>
        /// <returns><c>previousCount.ToString()</c> ※<c>0</c>の場合、<c>string.Empty</c>を返します。</returns>
        public static string GetRowCnt(int previousCount)
        {
            if (!previousCount.Equals(0))
            {
                return previousCount.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
    // ADD 2009/01/22 機能追加：価格改正、優良設定マスタの追加 ---------->>>>>
}
