using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    static class Program
    {
        private static string[] _parameter;						// 起動パラメータ
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
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
                    Form1_1 form = new Form1_1();
                    form.ShowDialog();
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "", msg, 0, MessageBoxButtons.OK);
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


            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}