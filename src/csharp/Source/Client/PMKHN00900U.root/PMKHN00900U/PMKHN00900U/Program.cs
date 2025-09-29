using System;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    internal static class Program
    {
        //private static string[] _parameter; // 起動パラメータ //  DEL dingjx  2011/08/09
        private static Form _form = null;
        private static bool autoMode = false;
        private static bool clientMode = false;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            bool checkSucess = CheckParmter(args);
            //if (checkSucess && !clientMode)   //  DEL dingjx  2011/08/09
            if (checkSucess)    //  ADD dingjx  2011/08/09
            {
                System.Windows.Forms.Application.Run(new PMKHN00900UA(clientMode, autoMode));
            }
            //  DEL dingjx  2011/08/09  ----------------------------------------------->>>>>>
            //else if (checkSucess && clientMode)
            //{
            //    try
            //    {
            //        string msg = "";
            //        _parameter = args;

            //        // アプリケーション開始準備処理
            //        // 第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
            //        int status = ApplicationStartControl.StartApplication(
            //            out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode,
            //            new EventHandler(ApplicationReleased));

            //        if (status == 0)
            //        {
            //            // オンライン状態判断
            //            if (!LoginInfoAcquisition.OnlineFlag)
            //            {
            //                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKHN00900U",
            //                              "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
            //            }
            //            else
            //            {
            //                _form = new PMKHN00900UA(clientMode, autoMode);
            //                System.Windows.Forms.Application.Run(_form);
            //            }
            //        }
            //        else
            //        {
            //            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMKHN00900U", msg, 0, MessageBoxButtons.OK);
            //        }
            //    }
            //    finally
            //    {
            //        ApplicationStartControl.EndApplication();
            //    }
            //}
            //  DEL dingjx  2011/08/09  -----------------------------------------------<<<<<<
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
                TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMKHN00900U", e.ToString(), 0,
                              MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMKHN00900U", e.ToString(), 0, MessageBoxButtons.OK);
            }

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// 起動パラメターチェック
        /// </summary>
        /// <param name="args">起動パラメター<param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 陳建明</br>
        /// <br>Date       : 2011/06/24</br>
        /// <br>Update     : 2011/08/09 丁建雄</br>
        /// <br>           : Redmine 障害報告 #23457</br>
        /// <br>Update     : 2011/08/15 丁建雄</br>
        /// <br>           : Redmine 障害報告 #23638</br>
        /// </remarks>
        private static bool CheckParmter(string[] args)
        {
            //  DEL dingjx  2011/08/09  ---------------------------------------------->>>>>>
            //if (!(args.Length <= 2))
            //    clientMode = true;
            ////クラインアントの場合
            //if (clientMode)
            //{
            //    for (int i = 2; i < ((args.Length == 4) ? 4 : args.Length); i++)
            //    {
            //        if (args[i].ToUpper() == "/AUTO")
            //        {
            //            autoMode = true;
            //        }
            //        else if (args[i].ToUpper() == "/CLIENT")
            //        {
            //        }
            //        else
            //        {
            //            MessageBox.Show("起動パラメータが不正です。{" + args[i] + "}", "起動パラメータ エラー",
            //                            MessageBoxButtons.OK,
            //                            MessageBoxIcon.Warning);
            //            return false;
            //        }
            //    }
            //    //同じなパラメタを指定した場合
            //    if (args.Length == 4 && args[2].ToUpper() == args[3].ToUpper())
            //    {
            //        MessageBox.Show("起動パラメータが不正です。{" + args[2] + "}{" + args[3] + "}",
            //                        "起動パラメータ エラー", MessageBoxButtons.OK,
            //                        MessageBoxIcon.Warning);
            //        return false;
            //    }
            //}
            ////サーバー
            //else
            //{
            //    for (int i = 0; i < args.Length; i++)
            //    {
            //        if (args[i].ToUpper() == "/AUTO")
            //        {
            //            autoMode = true;
            //        }
            //        else
            //        {
            //            MessageBox.Show("起動パラメータが不正です。", "起動パラメータ エラー",
            //                            MessageBoxButtons.OK,
            //                            MessageBoxIcon.Warning);

            //            return false;
            //        }
            //    }
            //}
            //return true;
            //  DEL dingjx  2011/08/09  ----------------------------------------------<<<<<<

            //  DEL dingjx  2011/08/15  ---------------------------------------------->>>>>>
            ////  ADD dingjx  2011/08/09  ---------------------------------------------->>>>>>
            //if (args.Length >= 3)
            //{
            //    MessageBox.Show("起動パラメータが不正です。", "起動パラメータ エラー",
            //                            MessageBoxButtons.OK,
            //                            MessageBoxIcon.Warning);

            //    return false;
            //}
            //else
            //{
            //    // サーバー 手動
            //    if (args.Length == 0)
            //    {
            //        // なし
            //    }
            //    // クラインアント 自動
            //    if (args.Length == 2)
            //    {
            //        for (int i = 0; i < args.Length; i++)
            //        {
            //            if (args[i].ToUpper() == "/AUTO")
            //            {
            //            }
            //            else if (args[i].ToUpper() == "/CLIENT")
            //            {
            //            }
            //            else
            //            {
            //                MessageBox.Show("起動パラメータが不正です。{" + args[i] + "}", "起動パラメータ エラー",
            //                                MessageBoxButtons.OK,
            //                                MessageBoxIcon.Warning);
            //                return false;
            //            }
            //        }
            //        //同じなパラメタを指定した場合
            //        if (args[0].ToUpper() == args[1].ToUpper())
            //        {
            //            MessageBox.Show("起動パラメータが不正です。{" + args[0] + "}{" + args[1] + "}",
            //                            "起動パラメータ エラー", MessageBoxButtons.OK,
            //                            MessageBoxIcon.Warning);
            //            return false;
            //        }

            //        clientMode = true;
            //        autoMode = true;
            //    }
            //    if (args.Length == 1)
            //    {
            //        // サーバー 自動
            //        if (args[0].ToUpper() == "/AUTO")
            //        {
            //            autoMode = true;
            //        }
            //        // クラインアント 手動
            //        else if (args[0].ToUpper() == "/CLIENT")
            //        {
            //            clientMode = true;
            //        }
            //        else
            //        {
            //            MessageBox.Show("起動パラメータが不正です。", "起動パラメータ エラー",
            //                            MessageBoxButtons.OK,
            //                            MessageBoxIcon.Warning);

            //            return false;
            //        }
            //    }
            //}

            //return true;
            ////  ADD dingjx  2011/08/09  ----------------------------------------------<<<<<<
            //  DEL dingjx  2011/08/15  ----------------------------------------------<<<<<<

            //  ADD dingjx  2011/08/15  ---------------------------------------------->>>>>>
            // サーバー 手動
            if (args.Length == 0)
            {
                // なし
            }
            else
            {
                foreach (string str in args)
                {
                    if (str.ToUpper().Equals("/CLIENT"))
                    {
                        clientMode = true;
                    }
                    if (str.ToUpper().Equals("/AUTO"))
                    {
                        autoMode = true;
                    }
                }
                if (!clientMode && !autoMode)
                {
                    MessageBox.Show("起動パラメータが不正です。", "起動パラメータ エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    return false;
                }
            }

            return true;
            //  ADD dingjx  2011/08/15  ----------------------------------------------<<<<<<
        }
    }
}