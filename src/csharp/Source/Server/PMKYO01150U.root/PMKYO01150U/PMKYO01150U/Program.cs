using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Microsoft.Win32;

namespace Broadleaf.Windows.Forms
{
    static class Program
    {
        internal static string[] _parameter;						// 起動パラメータ
        private static System.Windows.Forms.Form _form = null;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string msg = "";
                _parameter = args;

                // ↓ 2009/06/25 劉洋 add PVCS.283
                string workDir = null;
                // ﾚｼﾞｽﾄﾘｷｰ取得
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
                if (key == null) // あってはいけないケース
                {
                    workDir = @"C:\Program Files\Partsman\USER_AP"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
                }
                else
                {
                    // カレントフォルダの設定
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }
                System.IO.Directory.SetCurrentDirectory(workDir);
                // ↑ 2009/06/25 劉洋 add


                //アプリケーション開始準備処理
                //第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                int status = ServerApplicationMethodCallControl.StartApplication(
                        out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode);

                //int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

                if (status == 0)
                {
                    ////オンライン状態判断
                    //if (!LoginInfoAcquisition.OnlineFlag)
                    //{
                    //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKHN09210U",
                    //        "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    //}
                    //else
                    //{
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    _form = new PMKYO01150UA();
                    //if (_parameter.Length > 0) // 引数がある場合は画面表示せず終了するため、下記処理を行わない。
                    //{
                        ((PMKYO01150UA)_form).MergeOfferToUser(); // 自動起動時処理
                    //}
                    //else // サービス設定画面表示
                    //{
                    //    System.Windows.Forms.Application.Run(_form);
                    //}
                    //}
                }
                else
                {
                    MessageBox.Show(msg, "PMKYO01150U", MessageBoxButtons.OK);
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
        /// <param name="sender"></param>
        /// <param name="e">メッセージ</param>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();
            //従業員ログオフのメッセージを表示
            MessageBox.Show(e.ToString(), "PMKYO01150U", MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}