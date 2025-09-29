using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Broadleaf.Application.Partsman.Developers
{
    public class UnZipMergeCommand
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
        public UnZipMergeCommand(DirectoryInfo srcDir, DirectoryInfo dstDir)
        {
            this._srcDir = srcDir;
            this._dstDir = dstDir;
        }


        public void Execute()
        {
            DirectoryInfo dstSubDir;
            foreach (DirectoryInfo srcSubDir in this._srcDir.GetDirectories())
            {
                dstSubDir = new DirectoryInfo(Path.Combine(this._dstDir.FullName, srcSubDir.Name));
                if (dstSubDir.Exists)
                {
                    dstSubDir.Create();
                }
                Console.WriteLine(string.Format(" src:{0} , dst:{1}", srcSubDir.Name, dstSubDir.Name));
                this.UnZipMerge(srcSubDir, dstSubDir);
            }
        }

        public void UnZipMerge(DirectoryInfo src, DirectoryInfo dst)
        {
            DirectoryInfo dstSubDir;
            foreach (DirectoryInfo srcSubDir in src.GetDirectories())
            {
                dstSubDir = new DirectoryInfo(Path.Combine(dst.FullName, srcSubDir.Name));
                if (dstSubDir.Exists)
                {
                    dstSubDir.Create();
                }
                Console.WriteLine(string.Format("   src:{0} , dst:{1}", srcSubDir.Name, dstSubDir.Name));
                this.UnZipMerge(srcSubDir, dstSubDir);
            }

            string name;
            FileInfo dstSubFile;
            FileInfo[] subFiles = src.GetFiles("*.zip");
            Array.Sort(subFiles, delegate(FileInfo a, FileInfo b) { return a.Name.CompareTo(b.Name); });
            foreach (FileInfo srcSubFile in subFiles)
            {
                //出力ファイルは、
                name = srcSubFile.Name;
                name = name.Substring(0, name.LastIndexOf('_'));
                name += ".txt";
                dstSubFile = new FileInfo(Path.Combine(dst.FullName, name));
                Console.WriteLine(string.Format("     src:{0} , dst:{1}", srcSubFile.Name, dstSubFile.Name));

                this.UnZipMerge(srcSubFile, dstSubFile);
            }
        }


        public void UnZipMerge(FileInfo srcFile, FileInfo dstFile)
        {
            #region unzip
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.Arguments = string.Format("x -y -o\"{0}\" \"{1}\"", dstFile.Directory.FullName, srcFile.FullName);
            processStartInfo.FileName = ToolApplication.GetInstance().ZipCommand;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardInput = false;
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;

            Process p = Process.Start(processStartInfo);
            p.OutputDataReceived += OutputHandler;

            p.BeginOutputReadLine();
            p.WaitForExit();
            p.Close();
            #endregion

            #region merge
            FileStream inFs = null;
            StreamReader reader = null;
            StreamWriter writer = null;
            try
            {
                FileInfo srcTxtFile = new FileInfo(Path.Combine(dstFile.Directory.FullName, srcFile.Name.Replace("zip", "txt")));
                inFs = new FileStream(srcTxtFile.FullName, FileMode.Open);
                reader = new StreamReader(inFs,Encoding.UTF8);

                writer = new StreamWriter(dstFile.FullName,true,Encoding.GetEncoding("Shift_JIS"));
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        writer.WriteLine(line);
                    }
                }
                writer.Flush();

                if (reader != null) reader.Close();
                if (inFs != null) inFs.Close();
                srcTxtFile.Delete();
            }
            finally
            {
                if (writer != null) writer.Close();
                if (reader != null) reader.Close();
                if (inFs != null) inFs.Close();
            }
            #endregion
        }

        // 子プロセスが標準出力に出力したときに呼び出されるメソッド
        static void OutputHandler(object o, DataReceivedEventArgs args)
        {
            //Console.WriteLine(args.Data); // 出力されたデータを保存
        }
    }
}
