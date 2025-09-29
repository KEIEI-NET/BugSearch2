using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace Broadleaf.Windows.Forms
{
    static class Program
    {
        /// <summary>起動パラメータ</summary>
        public  static string[] _param = null;
        /// <summary>起動するフォームクラス</summary>
        private static Form _form;
        /// <summary>プログラムID</summary>
        public const string PGID = "SFNETMENU2";

        public static AddRegsiterMenuApp arm;
        public static LoginInfoFromExt gloginInfo;

        private static Mutex mutex;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);
//            Application.Run(new SFNETMENU2());
            try
            {
                // ログインチェック
                string ErrMsg = "";

                mutex = new Mutex(false, "SFNETMENU2 PM.NS1.0") ;  // Mutex 生成 ; false = 所有権なし
                if (!mutex.WaitOne(0, false))             // Mutex 取得 ; false = 再取得なし
                {
                    SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "Init", "情報", "業務メニューは既に起動しています！", "");
                    System.Windows.Forms.Application.Exit();
                    return;
                }

               arm = new AddRegsiterMenuApp();

                // アプリケーション開始(終了イベント登録）
               int status = arm.Startup(ref Args, out ErrMsg, out gloginInfo, new EventHandler(ApplicationReleased));
               _param = Args;

                if ((status == 0) || (status == 1))
                {
                    try
                    {
                        // アプリケーション開始
                        System.Windows.Forms.Application.EnableVisualStyles();
                        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                        _form = new SFNETMENU2A();
                        System.Windows.Forms.Application.Run(_form);

                    }
                    catch (Exception er)
                    {
                        SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelError, "Main", "実行時エラー", er.Message, "-999");
                    }
                }
                else
                {
                    //	ログイン失敗
                    if (status == 4)
                    {
                        //	ログイン失敗(このパターンは他のアプリと同じ仕様に合わせる為特別：品管障害対応)
                        SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "Init", "認証エラー", "従業員ログインを行ってください。", "-999");
                    }
                    else
                    {
                        if (ErrMsg.Trim().Length == 0)
                        {
                            //  もしメッセージが空なら、起動不可の旨だけ伝える
                            ErrMsg = "ログインに失敗しました。\n\n起動できません。";
                        }
                        SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "Init", "認証エラー", ErrMsg, status.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                // 例外エラー表示
                //  引数エラーでアプリケーション終了
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelError, "Init", "認証エラー", ex.Message, "-991");
            }
            finally
            {
                // 起動用フローティングウィンドウ(Close)
                if (arm != null)
                {
                    arm.Fihisher();
                }
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
            arm.Fihisher();
            //従業員ログオフのメッセージを表示
            if (_form != null)
            {
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "End", "エラー",  e.ToString(), "-999");
            }
            else
            {
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "End", "エラー",  e.ToString(), "-999");
            }
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}