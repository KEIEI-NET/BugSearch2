using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Broadleaf.Application.Controller
{
    public class ReplicaDBAccessUtils
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        private ReplicaDBAccessUtils()
        {
        }

        /// <summary>
        /// オブジェクトの破棄を行います。
        /// 例外が発生しても無視します。
        /// </summary>
        /// <param name="obj"></param>
        public static void CloseQuietly(IDisposable obj)
        {
            try
            {
                if (obj != null)
                {
                    obj.Dispose();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="logCotents">ログ</param>
        /// <remarks>
        /// <br>Note       : ログ出力を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/11</br>
        /// </remarks>
        public static void LogOutput(string file, string message)
        {
            StreamWriter writer = null;
            const string msgFmt = "{0} {1}\r\n";
            try
            {
                // ﾃｷｽﾄﾛｸﾞ書込み
                writer = new StreamWriter(file, true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(string.Format(msgFmt, DateTime.Now, message));
                writer.Flush();
                if (writer != null) writer.Close();
            }
            catch
            {
            }
        }


        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="logCotents">ログ</param>
        /// <remarks>
        /// <br>Note       : ログ出力を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/11</br>
        /// </remarks>
        public static void LogOutput(string file, string message, Exception ex)
        {
            StreamWriter writer = null;
            const string msgFmt = "{0} {1} {2} MSG:{3}\r\nSTACK:{4}\r\n";
            try
            {
                // ﾃｷｽﾄﾛｸﾞ書込み
                writer = new StreamWriter(file, true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(string.Format(msgFmt, DateTime.Now, message,ex.GetType().ToString(), ex.Message, ex.StackTrace));
                writer.Flush();
                if (writer != null) writer.Close();
            }
            catch
            {
            }
        }
    }
}
