using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Broadleaf.Application.Partsman.Developers
{
    public class SqlImportCommand
    {
        /// <summary>zipファイル読み込みディレクトリ</summary>
        private DirectoryInfo _srcDir;

        /// <summary>zipファイル展開＆マージ出力結果ディレクトリ</summary>
        private DirectoryInfo _dstDir;

        /// <summary>
        /// コンストラクタ。
        /// zipファイルが保存されているルートディレクトリを指定します。
        /// どちらも存在するディレクトリを指定してください。
        /// </summary>
        /// <param name="srcDir"></param>
        /// <param name="dstDir"></param>
        public SqlImportCommand(DirectoryInfo srcDir, DirectoryInfo dstDir)
        {
            this._srcDir = srcDir;
            this._dstDir = dstDir;
        }

        public void Execute()
        {
            this.BcpImport(this._dstDir);
        }

        public void BcpImport(DirectoryInfo dir)
        {
            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                this.BcpImport(subDir);
            }
            foreach (FileInfo subFile in dir.GetFiles())
            {
                this.BcpImport(subFile);
            }
        }

        public void BcpImport(FileInfo srcFile)
        {
            if (!Regex.IsMatch(srcFile.Name, @"task_[0-9]{10}\.txt"))
            {
                return;
            }
            else if (srcFile.Length == 0)
            {
                return;
            }
            ToolApplication apps = ToolApplication.GetInstance();
            string tableName = apps.GetImportTable(srcFile);
            if (string.IsNullOrEmpty(tableName))
            {
                return;
            }

            #region bcp-import
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.Arguments = string.Format(
                                            " {0} IN {1} -c -t \\t -S {2} -U {3} -P {4} -E "
                                            , tableName
                                            , srcFile.FullName
                                            , apps.SqlServerName
                                            , apps.SqlServerUser
                                            , apps.SqlServerPass);
            processStartInfo.FileName = ToolApplication.GetInstance().BcpCommand;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardInput = false;
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;

            Console.WriteLine("bcp args:" + processStartInfo.Arguments);
            Process p = Process.Start(processStartInfo);
            p.OutputDataReceived += OutputHandler;

            p.BeginOutputReadLine();
            p.WaitForExit();
            p.Close();
            #endregion
        }

        // 子プロセスが標準出力に出力したときに呼び出されるメソッド
        static void OutputHandler(object o, DataReceivedEventArgs args)
        {
            Console.WriteLine(args.Data); // 出力されたデータを保存
        }
    }
}
