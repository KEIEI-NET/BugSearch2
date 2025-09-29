using System;
using System.Windows.Forms;

using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SCMポップアップアプリケーションのエントリクラス
    /// </summary>
	internal static class Program
	{
        private static string[] _parameter;	// 起動パラメータ
        public static bool PM7Mode=false;
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
        /// <param name="args">コマンドライン引数</param>
		[STAThread]
		static void Main(string[] args)
		{
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            if (args[0] == "/B")
            {
                PM7Mode = true;
                // ポップアップの多重起動防止
                if (SCMClientUtil.CanRun())
                {
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    System.Windows.Forms.Application.Run(new PMKYO01910UA(args));
                }
            }
            else
            {
                try
                {
                    string msg = "";
                    _parameter = args;

                    // アプリケーション開始準備処理
                    // 第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                    int status = ApplicationStartControl.StartApplication(
                        out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                     
                    if (status == 0)
                    {
                        // オンライン状態判断
                        if (!LoginInfoAcquisition.OnlineFlag)
                        {
                            if (args.Length <= 2 || args[2] != "/S")
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKYO01910UA",
                                    "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            // ポップアップの多重起動防止
                            if (SCMClientUtil.CanRun())
                            {
                                System.Windows.Forms.Application.EnableVisualStyles();
                                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                                System.Windows.Forms.Application.Run(new PMKYO01910UA(args));
                            }
                            else
                            {

                            }
                        }
                    }
                }
                finally
                {
                    ApplicationStartControl.EndApplication();
                }
            }
		}

        /// <summary>
        /// アプリケーション終了イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            // メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
	}
}