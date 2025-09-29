using System;
using System.Diagnostics;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// SCMクライアントユーティリティ
    /// </summary>
    public static class SCMClientUtil
    {
        /// <summary>
        /// 起動できるか判定します。
        /// </summary>
        /// <returns><c>true</c> :起動可能<br/><c>false</c>:起動不可</returns>
        public static bool CanRun()
        {
            return Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length <= 1;
        }
    }
}
