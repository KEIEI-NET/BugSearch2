using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using Broadleaf.Application.Common;
using System.Diagnostics;   // 2015/08/07 ADD 鹿庭 SCMポップアップのプロセスが実行中の場合は強制終了する

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// システム・ログインUI制御メインクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : システム・ログインUI制御メインクラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2008.08.28</br>
    /// <br></br>
    /// <br>Update Note: 2009.01.20 鹿野　幸生</br>
    /// <br>Update Note: 2012.11.13 matsunaga</br>
    /// <br>Update Note: 2015.08.07 鹿庭　一郎</br>
    /// </remarks>
    static class Program
    {

        /// <summary>起動するフォームクラス</summary>
        private static SFCMN00047UAF _form;
        /// <summary>プログラムID</summary>
        public const string PGID = "SFCMN00047U";

        private static Mutex mutex;

        // 2015/08/07 ADD 鹿庭 SCMポップアップのプロセスが実行中の場合は強制終了する -------->>>>>>>>>>
        /// <summary>プロセス名（SCMポップアップ）</summary>
        private const string PROCESSNAME_POPUP = "PMSCM00005U"; // SCMポップアップのPGID
        // 2015/08/07 ADD 鹿庭 SCMポップアップのプロセスが実行中の場合は強制終了する --------<<<<<<<<<<

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);

            // 2015/08/07 ADD 鹿庭 SCMポップアップのプロセスが実行中の場合は強制終了する -------->>>>>>>>>>
            // 他プロダクト起動対応 
            // Argsの３番目に文字列(プロダクトコード)が渡された場合はそれを使用。
            string productCode = "Partsman";
            if (Args.Length > 2)
            {
                productCode = Args[2];
            }
            // 2015/08/07 ADD 鹿庭 SCMポップアップのプロセスが実行中の場合は強制終了する -------->>>>>>>>>>

            // 2015/08/07 UPD 鹿庭 SCMポップアップのプロセスが実行中の場合は強制終了する -------->>>>>>>>>>
            mutex = new Mutex(false, "SFCMN00047U" + productCode);  // Mutex 生成 ; false = 所有権なし
            // mutex = new Mutex(false, "SFCMN00047U");  // Mutex 生成 ; false = 所有権なし
            // 2015/08/07 UPD 鹿庭 SCMポップアップのプロセスが実行中の場合は強制終了する --------<<<<<<<<<<

            if (!mutex.WaitOne(0, false))              // Mutex 取得 ; false = 再取得なし
            {
                System.Windows.Forms.Application.Exit();
                return;
            }

            // アプリケーション開始(終了イベント登録）
            string errMsg = "";

            try
            {
                // 2012.11.13 matsunaga >>>
                // 他プロダクト起動対応 
                // Argsの３番目に文字列(プロダクトコード)が渡された場合はそれを使用。
                // 関係ない場合にはSuperfrontmanで起動
                //int status = ApplicationStartControl.StartApplication(out errMsg, ref Args, "SuperFrontman", new EventHandler(ApplicationReleased));
                // 2015/08/07 DEL 鹿庭 SCMポップアップのプロセスが実行中の場合は強制終了する -------->>>>>>>>>>
                //string productCode = "SuperFrontman";
                //if (Args.Length > 2)
                //{
                //    productCode = Args[2];
                //}
                // 2015/08/07 DEL 鹿庭 SCMポップアップのプロセスが実行中の場合は強制終了する --------<<<<<<<<<<
                int status = ApplicationStartControl.StartApplication(out errMsg, ref Args, productCode, new EventHandler(ApplicationReleased));
                // 2012.11.13 matsunaga <<<

                if ((status == 0) || (status == 1))
                {
                    try
                    {
                        // アプリケーション開始
                        System.Windows.Forms.Application.EnableVisualStyles();
                        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                        _form = new SFCMN00047UAF();
                        _form.Visible = false;
                        _form._Visible = false;
                        _form._Finish = false;
                        System.Windows.Forms.Application.Run(_form);
                    }
                    catch (Exception er)
                    {
                        //SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelError, "Main", "実行時エラー", er.Message, "-999");
                    }
                }
                else
                {
                    //	ログイン失敗
                    if (status == 4)
                    {
                        //	ログイン失敗(このパターンは他のアプリと同じ仕様に合わせる為特別：品管障害対応)
                        //SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "Init", "認証エラー", "従業員ログインを行ってください。", "-999");
                    }
                    else
                    {
                        if (errMsg.Trim().Length == 0)
                        {
                            //  もしメッセージが空なら、起動不可の旨だけ伝える
                            errMsg = "ログインに失敗しました。\n\n起動できません。";
                        }
                        //SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "Init", "認証エラー", ErrMsg, status.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                // 例外エラー表示
                //  引数エラーでアプリケーション終了
                //SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelError, "Init", "認証エラー", ex.Message, "-991");
            }
            finally
            {
                // 起動用フローティングウィンドウ(Close)
                //if (arm != null)
                //{
                    //arm.Fihisher();
                //}
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
            //arm.Fihisher();
            //従業員ログオフのメッセージを表示
            //if (_form != null)
            //{
                //SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "End", "エラー",  e.ToString(), "-999");
            //}
            //else
            //{
                //SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelInfo, "End", "エラー",  e.ToString(), "-999");
            //}

            // 2015/08/07 ADD 鹿庭 SCMポップアップのプロセスが実行中の場合は強制終了する -------->>>>>>>>>>
            // SCMポップアップのプロセスが実行中の場合は強制終了する。
            Process[] processList = Process.GetProcessesByName(PROCESSNAME_POPUP);
            foreach (Process process in processList)
            {
                try
                {
                    process.Kill();
                }
                catch
                {
                    // process終了中、終了済の場合、exceptionが発生した際の次ループ用
                }
            }
            // 2015/08/07 ADD 鹿庭 SCMポップアップのプロセスが実行中の場合は強制終了する --------<<<<<<<<<<
            
            //  終了時警告を出す必要が有る場合には画面表示                      //  2009.01.16  追加
            if (_form._SpecialKilled == true)
            {
                SFCMN00047UBF endWin = new SFCMN00047UBF();
                endWin.ShowMessageDialog(_form._KilledReason);
            }
            _form.Invoke( (MethodInvoker)delegate()
                    {
                        _form.CloseWindow();
                    });
            
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}