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
        internal static string[] _parameter;						// 起動パラメータ
        private static Form _form = null;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// <br>Update Note : 2010/05/25　22008 長内 数馬</br>
        /// <br>              オフライン対応</br>
        [STAThread]
        static void Main(string[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                string msg = "";
                _parameter = args;

                int status;
                try
                {
                    //アプリケーション開始準備処理
                    //第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                    status = ApplicationStartControl.StartApplication(
                        out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                }
                catch
                {
                    status = ServerApplicationMethodCallControl.StartApplication(
                        out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode);
                }
                if (status != 0)
                {
                    status = ServerApplicationMethodCallControl.StartApplication(
                        out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode);
                }
                if (status == 0)
                {
                    // -- UPD 2010/05/25 ------------------------------------>>>
                    //////オンライン状態判断
                    ////if (!LoginInfoAcquisition.OnlineFlag)
                    ////{
                    ////    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKHN09200U",
                    ////        "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    ////}
                    ////else
                    ////{
                    //_form = new PMKHN09200UA();
                    //if (_parameter.Length == 0) // 引数がある場合は画面表示せず終了するため、下記処理を行わない。
                    //{
                    //    System.Windows.Forms.Application.Run(_form);
                    //}
                    //}

                    //オンライン状態判断
                    if (!LoginInfoAcquisition.OnlineFlag)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKHN09200U",
                            "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        _form = new PMKHN09200UA();
                        if (_parameter.Length == 0) // 引数がある場合は画面表示せず終了するため、下記処理を行わない。
                        {
                            System.Windows.Forms.Application.Run(_form);
                        }
                    }
                    // -- UPD 2010/05/25 ------------------------------------<<<
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMKHN09200U", msg, 0, MessageBoxButtons.OK);
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
            if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMKHN09200U", e.ToString(), 0, MessageBoxButtons.OK);
            else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMKHN09200U", e.ToString(), 0, MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}