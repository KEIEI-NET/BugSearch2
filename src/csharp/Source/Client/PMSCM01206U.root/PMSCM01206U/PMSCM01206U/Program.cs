using System;
using System.Windows.Forms;

using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 自動送受信バッチポップアップUIクラス
    /// </summary>
	internal static class Program
	{
        private static string[] _parameter;						// 起動パラメータ
        private static Form _form = null;
        public static bool PM7Mode=false;
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
        /// <param name="args">コマンドライン引数</param>
        /// <remarks>
        /// <br>Note		: 自動送受信バッチポップアップUIクラス。</br>
        /// <br>Programmer	: qianl</br>
        /// <br>Date		: 2007/07/21</br>
        /// <br>Update Note: 障害報告 #24342対応</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.09.02</br>
        /// <br>Update Note: 仕様連絡 #25604対応</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.09.28</br>
        /// </remarks>
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
                    System.Windows.Forms.Application.Run(new PMSCM01206UA());
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
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMSCM01206U",
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
                                System.Windows.Forms.Application.Run(new PMSCM01206UA());
                            }
                            else
                            {
                                /*------------DEL START 2011.09.28 gaoy FOR 仕様連絡 #25604------->>>>
                                msg = "既に起動しています。";              // ADD 2011.09.02 gaoy FOR 障害報告 #24342
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMSCM01206U", msg, 0, MessageBoxButtons.OK);
                                 ------------DEL END 2011.09.28 gaoy FOR 仕様連絡 #25604-------<<<<*/
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
        /// <remarks>
        /// <br>Note		: 自動送受信バッチポップアップUIクラス。</br>
        /// <br>Programmer	: qianl</br>
        /// <br>Date		: 2007/07/21</br>
        /// </remarks>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            // メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();

            //従業員ログオフのメッセージを表示
            if (_form != null)
            {
                TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMSCM01206U", e.ToString(), 0, MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMSCM01206U", e.ToString(), 0, MessageBoxButtons.OK);
            }

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
	}
}