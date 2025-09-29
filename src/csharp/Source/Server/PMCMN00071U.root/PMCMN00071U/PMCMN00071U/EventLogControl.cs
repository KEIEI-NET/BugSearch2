using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Broadleaf.Application.Batch
{
    /// <summary>
    /// イベントログ操作クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : イベントログにメッセージを設定します。</br>
    /// <br>Programmer : 佐々木 亘</br>
    /// <br>Date       : 2015/05/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class EventLogControl
    {
        /// <summary>
        /// イベントログにメッセージを出力する
        /// </summary>
        /// <param name="className">クラス名</param>
        /// <param name="methodName">メソッド名</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        public static void SetEventLogOut(string className, string methodName, string errorMessage)
        {
            string source = Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]);
            string message = string.Format("[{0}].[{1}] {2} Loginfo:PgId[{3}]", className, methodName, errorMessage, source);
            try
            {
                // イベントログ出力
                EventLog.WriteEntry(source, message, EventLogEntryType.Error);
            }
            catch
            {
                //イベントログに出力できない場合、エラーにはしない
            }
        }
    }
}
