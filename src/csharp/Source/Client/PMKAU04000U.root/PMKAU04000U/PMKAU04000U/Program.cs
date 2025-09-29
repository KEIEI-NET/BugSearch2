using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    static class Program
    {
        private static string[] _parameter;						// 起動パラメータ
        private static Form _form = null;
        //----- ADD　2018/09/04 譚洪　履歴自動表示の対応------->>>>>
        /// <summary>売上伝票入力PGID</summary>
        private const string CT_SALESSLIP_PGID = "MAHNB01001U";
        //----- ADD　2018/09/04 譚洪　履歴自動表示の対応-------<<<<<

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// <remarks>
        /// <br>Update Note: 2018/09/04 譚洪</br>
        /// <br>管理番号   : 11470152-00</br>
        /// <br>           : 履歴自動表示機能追加対応</br>
        /// </remarks>
        [STAThread]
        static void Main(String[] args)
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
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKAU04000U",
                            "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        //----- ADD　2018/09/04 譚洪　履歴自動表示の対応------->>>>>
                        if (args.Length > 2)
                        {
                            //売上からの起動を判断する
                            if (args[2].Equals(CT_SALESSLIP_PGID) && args.Length > 3)
                            {
                                _form = new PMKAU04000U();
                                string[] commandLineArgs = new string[2];
                                string[] salesCommandArgs = new string[2];
                                Array.Copy(args, 0, commandLineArgs, 0, 2);
                                Array.Copy(args, 2, salesCommandArgs, 0, 2);
                                ((PMKAU04000U)_form).CommandLineArgs = commandLineArgs;
                                ((PMKAU04000U)_form).SalesCommandArgs = salesCommandArgs;
                                System.Windows.Forms.Application.Run(_form);
                            }

                        }
                        else
                        {
                        //----- ADD　2018/09/04 譚洪　履歴自動表示の対応-------<<<<<
                        _form = new PMKAU04000U();
                        ((PMKAU04000U)_form).CommandLineArgs = args;// Add 2011.08.06 duzg for 赤伝発行時、データ送信対応
                        System.Windows.Forms.Application.Run(_form);
                        } // ADD　2018/09/04 譚洪　履歴自動表示の対応
                    }
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMKAU04000U", msg, 0, MessageBoxButtons.OK);
                }
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MAKON01100UA());
             */
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
                // -- Update St 2012/06/13 30182 R.Tachiya --
                //TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMKAU04000U", e.ToString(), 0, MessageBoxButtons.OK);
                // 画面が「非表示」および「タスクバー非表示」の場合はメッセージを表示しない
                if (_form.Visible && _form.ShowInTaskbar)
                {
                    TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMKAU04000U", e.ToString(), 0, MessageBoxButtons.OK);
                }
                // -- Update St 2012/06/13 30182 R.Tachiya --
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMKAU04000U", e.ToString(), 0, MessageBoxButtons.OK);
            }

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}