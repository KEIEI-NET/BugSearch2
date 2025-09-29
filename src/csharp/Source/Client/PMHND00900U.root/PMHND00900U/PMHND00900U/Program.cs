using System;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    internal static class Program
    {
        //private static string[] _parameter; // 起動パラメータ
        private static Form _form = null;
        private static bool autoMode = false;
        private static bool clientMode = false;
        private static string copyFolder = string.Empty;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            bool checkSucess = CheckParmter(args);
            if (checkSucess)
            {
                System.Windows.Forms.Application.Run(new PMHND00900UA(clientMode, autoMode, copyFolder));
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
            if (_form != null)
            {
                TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMHND00900U", e.ToString(), 0,
                              MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMHND00900U", e.ToString(), 0, MessageBoxButtons.OK);
            }

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// 起動パラメターチェック
        /// </summary>
        /// <param name="args">起動パラメター<param>
        private static bool CheckParmter(string[] args)
        {
            // サーバー 手動
            if (args.Length == 0)
            {
                // なし
            }
            else
            {
                foreach (string str in args)
                {
                    // 起動モード取得
                    if (str.ToUpper().Equals("/CLIENT"))
                    {
                        clientMode = true;
                    }
                    else if (str.ToUpper().Equals("/AUTO"))
                    {
                        autoMode = true;
                    }
                }

                string str2 = args[args.Length - 1];
                if (!(str2.ToUpper().Equals("/CLIENT")) && !(str2.ToUpper().Equals("/AUTO")))
                {
                    // フォルダ取得
                    copyFolder = str2;
                }

                if ((!clientMode && !autoMode) || string.IsNullOrEmpty(copyFolder))
                {
                    MessageBox.Show("起動パラメータが不正です。", "起動パラメータ エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    return false;
                }
            }

            return true;
        }
    }
}