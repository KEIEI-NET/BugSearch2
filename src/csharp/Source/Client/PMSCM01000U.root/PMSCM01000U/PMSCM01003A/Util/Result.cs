using System;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 結果ユーティリティ
    /// </summary>
    public static class Result
    {
        /// <summary>
        /// 結果コード列挙体
        /// </summary>
        public enum Code : int
        {
            /// <summary>正常</summary>
            Normal = 0,
            // 2011/03/18 Add >>>
            /// <summary>該当無し</summary>
            NotFound = 4,
            // 2011/03/18 Add <<<
            /// <summary>エラー</summary>
            Error = 1
        }
    }
}
