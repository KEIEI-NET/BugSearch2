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
            try
            {
                string msg = "";
                _parameter = args;

                //アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。出来ない場合はプロダクトコード
                int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    if (!LoginInfoAcquisition.OnlineFlag)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMCMN00084U",
                            "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        _form = new PMCMN00084UA(autoMode);
                        System.Windows.Forms.Application.Run(new PMCMN00084UA(autoMode));
                    }
                }
            }
            // --- DEL 2015/11/18 T.Miyamoto ③ ------------------------------>>>>>
            //catch (Exception ex)
            //{
            //    LogTextOut logTextOut = new LogTextOut();
            //    logTextOut.Output("PMCMN00084U", ex.Message, 0);
            //}
            // --- DEL 2015/11/18 T.Miyamoto ③ ------------------------------<<<<<
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