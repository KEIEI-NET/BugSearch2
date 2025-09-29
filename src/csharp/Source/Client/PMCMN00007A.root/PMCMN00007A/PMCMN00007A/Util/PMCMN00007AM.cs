using System;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// メッセージユーティリティ
    /// </summary>
    public static class MsgUtil
    {
        /// <summary>
        /// 許可名を取得します。
        /// </summary>
        /// <param name="operationLimit">オペレーション権限値</param>
        /// <returns>操作権限名（該当するオペレーション権限値がない場合、<code>string.Empty</code>を返します）</returns>
        public static string GetAdmissionName(OperationLimit operationLimit)
        {
            switch (operationLimit)
            {
                //case OperationLimit.Enable:
                //    return "可";            // LITERAL:
                case OperationLimit.EnableWithLog:
                    return "可(ログ記録)";  // LITERAL:
                case OperationLimit.Disable:
                    return "不可";          // LITERAL:
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// ログ種別名を取得します。
        /// </summary>
        /// <param name="logDataKind">ログ種別値</param>
        /// <returns>ログ種別名（該当するログ種別値がない場合、<code>string.Empty</code>を返します）</returns>
        public static string GetLogDataKindName(LogDataKind logDataKind)
        {
            switch (logDataKind)
            {
                case LogDataKind.OperationLog:
                    return "操作";      // LITERAL:
                case LogDataKind.ErrorLog:
                    return "エラー";    // LITERAL:
                case LogDataKind.SystemLog:
                    return "システム";  // LITERAL:
                case LogDataKind.UoeDspLog:
                    return "UOE(DSP)";  // LITERAL:
                case LogDataKind.UoeCommLog:
                    return "UOE(通信)"; // LITERAL:
                default:
                    return string.Empty;
            }
        }

        #region [GetMsg]
        /// <summary>
        /// メッセージを取得します。
        /// </summary>
        /// <param name="status">ステータスコード</param>
        /// <param name="str">文字列</param>
        /// <returns>"ステータス：[{0}]　文字列：[{1}]"</returns>
        public static string GetMsg(
            int status,
            string str
        )
        {
            const string FORMAT = "ステータス：[{0}]　文字列：[{1}]";
            return string.Format(FORMAT, status, str);
        }

        /// <summary>
        /// メッセージを取得します。
        /// </summary>
        /// <param name="status">ステータスコード</param>
        /// <param name="number">数値</param>
        /// <returns>"ステータス：[{0}]　数値：[{1}]"</returns>
        public static string GetMsg(
            int status,
            int number
        )
        {
            const string FORMAT = "ステータス：[{0}]　数値：[{1}]";
            return string.Format(FORMAT, status, number);
        }

        /// <summary>
        /// メッセージを取得します。
        /// </summary>
        /// <param name="status">ステータスコード</param>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <returns>"ステータス：[{0}]　カテゴリコード：[{1}]　プログラムID：[{2}]"</returns>
        public static string GetMsg(
            int status,
            int categoryCode,
            string pgId
        )
        {
            const string FORMAT = "ステータス：[{0}]　カテゴリコード：[{1}]　プログラムID：[{2}]";
            return string.Format(FORMAT, status, categoryCode, pgId);
        }
        #endregion
    }
}
