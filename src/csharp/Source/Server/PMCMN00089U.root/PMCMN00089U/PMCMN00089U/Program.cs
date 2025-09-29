using System;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Microsoft.Win32;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Windows.Forms
{
    internal static class Program
    {
        private static string[] _parameter;
        private static System.Windows.Forms.Form _form = null;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            bool autoMode = false;

            if (args.Length > 0)
            {
                foreach (string str in args)
                {
                    if (str.ToUpper().Equals("1"))
                    {
                        autoMode = true;
                    }
                }
            }

            string workDir = null;
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
            if (key == null) // あってはいけないケース
            {
                workDir = @"C:\Program Files\Partsman\USER_AP"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
            }
            else
            {
                // ログ書き込みﾌｫﾙﾀﾞ指定
                workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
            }

            try
            {
                System.IO.Directory.SetCurrentDirectory(workDir);

                string msg = "";
                _parameter = args;
                
                //アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。出来ない場合はプロダクトコード
                int status = ServerApplicationMethodCallControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode);

                if (status == 0)
                {
                    _form = new PMCMN00089UA(autoMode);
                    System.Windows.Forms.Application.Run(new PMCMN00089UA(autoMode));
                }
            }
            catch (Exception ex)
            {
                LogTextOut logTextOut = new LogTextOut();
                logTextOut.Output("PMCMN00089U", ex.Message, 0);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }

        }
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
   }
}