using System;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    static class Program
    {
        /// <summary>起動パラメータ</summary>
        public static string[] Param = null;
        /// <summary>起動するフォームクラス</summary>
        private static Form _form;
        /// <summary>プログラムID</summary>
        public const string PGID = "PMSCM01220U";

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // ログインチェック
                string msg = "";

                int status = ApplicationStartControl.StartApplication(out msg, ref Args, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

                Param = Args;

                if (status == 0)
                {
                    if (!Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag)
                    {
                        msg = "オフライン状態で本機能はご使用できません。";
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, PGID, msg, 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        // アプリケーション開始
                        _form = new PMSCM01220UA();

                        System.Windows.Forms.Application.Run(_form);
                    }
                }
                else
                {
                    // エラー表示
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PGID, msg, 0, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                // 例外エラー表示
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PGID, ex.Message, 0, ex, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
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
        /// <remarks>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();

            //従業員ログオフのメッセージを表示
            if (_form != null)
                TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, PGID, e.ToString(), 0, MessageBoxButtons.OK);
            else
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PGID, e.ToString(), 0, MessageBoxButtons.OK);

            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}