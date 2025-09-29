using System;
using System.Windows.Forms;

using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using System.Diagnostics;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SCMポップアップアプリケーションのエントリクラス
    /// </summary>
	internal static class Program
	{
        private static string[] _parameter;						// 起動パラメータ
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
        /// <param name="args">コマンドライン引数</param>
        [STAThread]
        static void Main(string[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

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
                        //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMSCM00008U",
                        //    "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (CanRun())
                        {
                            System.Windows.Forms.Application.EnableVisualStyles();
                            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                            System.Windows.Forms.Application.Run(new PMSCM00008UA(args));
                        }
                    }
                }
            }
            finally
            {
                ApplicationStartControl.EndApplication();
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

            // 従業員ログオフのメッセージを表示
            //if (_form != null)
            //{
                //TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMSCM00005U", e.ToString(), 0, MessageBoxButtons.OK);
            //}
            //else
            //{
                //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMSCM00005U", e.ToString(), 0, MessageBoxButtons.OK);
            //}

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// 起動できるか判定します。
        /// </summary>
        /// <returns><c>true</c> :起動可能<br/><c>false</c>:起動不可</returns>
        private static bool CanRun()
        {
            return Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length <= 1;
        }
	}
}