using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using Microsoft.Win32;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// ログ出力クラス
    /// </summary>
    /// <remarks>
    /// <br>Update Note	: ログファイル名を変更（SCMChcker.log⇒SCMCheker_日付.log)</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2010/03/05</br>
    /// </remarks>
    public static class LogWriter
    {
        public static bool isKillLog = false;

        /// <summary>
        /// ログ出力(DEBUG)処理
        /// </summary>
        /// <param name="pMsg"></param>
        public static void LogWrite(string pMsg)
        {
            if (isKillLog) return;

            string workDir = null;

			#region 2012.04.10 TERASAKA DEL STA
//            // ﾚｼﾞｽﾄﾘｷｰ取得
//            StreamWriter writer = null;                          // テキストログ用
			#endregion
            //>>>2010/07/30
            //RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Product\Partsman");
            //<<<2010/07/30

            if (key == null) // あってはいけないケース
            {
                //>>>2010/07/30
                //workDir = @"C:\Program Files\Partsman\USER_AP"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
                workDir = @"C:\Program Files\Partsman"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
                //<<<2010/07/30
            }
            else
            {
                // ログ書き込みﾌｫﾙﾀﾞ指定
                //>>>2010/07/30
                //workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman").ToString();
                //<<<2010/07/30
            }
            // カレントディレクトリ設定
            System.IO.Directory.SetCurrentDirectory(workDir);

            // 2010/03/05 >>>
            //string backupedLog = SimpleLogger.BackupLogIf(workDir + @"\Log\PMCMN06200S\SCMChecker.Log");
            string backupedLog = SimpleLogger.BackupLogIf(workDir + @"\Log\PMCMN06200S\" + string.Format("SCMChecker_{0}.Log", DateTime.Now.ToString("yyyyMMdd")));
            // 2010/03/05 <<<

            System.IO.FileStream _fs;										// ファイルストリーム
            System.IO.StreamWriter _sw;										// ストリームwriter
            if (string.IsNullOrEmpty(backupedLog))
            {
                // 2010/03/05 >>>
                //_fs = new FileStream(workDir + @"\Log\PMCMN06200S\SCMChecker.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
                _fs = new FileStream(workDir + @"\Log\PMCMN06200S\" + string.Format("SCMChecker_{0}.Log", DateTime.Now.ToString("yyyyMMdd")), FileMode.Append, FileAccess.Write, FileShare.Write);
                // 2010/03/05 <<<
            }
            else
            {
                // 2010/03/05 >>>
                //_fs = new FileStream(workDir + @"\Log\PMCMN06200S\SCMChecker.Log", FileMode.Create, FileAccess.Write, FileShare.Write);
                _fs = new FileStream(workDir + @"\Log\PMCMN06200S\" + string.Format("SCMChecker_{0}.Log", DateTime.Now.ToString("yyyyMMdd")), FileMode.Create, FileAccess.Write, FileShare.Write);
                // 2010/03/05 <<<
            }
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
        }

        /// <summary>デバッグログのINIファイル</summary>
        private const string DEBUG_FILE_INI = "_DEBUG_.ini";

        /// <summary>
        /// デバッグログを出力します。
        /// </summary>
        /// <param name="author">筆者</param>
        /// <param name="msg">メッセージ</param>
        public static void WriteDebugLog(
            string author,
            string msg
        )
        {
            //Debug.WriteLine(Environment.CurrentDirectory);
            //if (!File.Exists(DEBUG_FILE_INI)) return;

            string message = "(Debug)" + author + "->";
            message += msg;
            LogWrite(message);
        }
    }
}
