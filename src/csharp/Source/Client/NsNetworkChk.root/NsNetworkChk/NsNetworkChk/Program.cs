using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

using Broadleaf.NSNetworkChk.UI;

namespace Broadleaf.NSNetworkChk.UI
{
    static class Program
    {
        /// <summary>プログラムＩＤ</summary>
        internal static readonly string CT_PGID = "NSNetworkChk";

        /// <summary>アプリケーション</summary>
        private static ApplicationContext _apli = null;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                //ミューテックス名称取得
                string mutexName = "NSNetworkChk-Mutex";
                //二重起動チェック（True⇒PG終了）
                if (MutexCheck(mutexName))
                {
                    MessageBox.Show("多重起動は出来ません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                System.Windows.Forms.Application.Run(new NSNetworkChk_Form());
            }
            else
            {
                try
                {
                    // ログインチェック
                    string msg = "";
                    // アプリケーション開始(終了イベント登録）
                    int status = ApplicationStartControl.StartApplication(out msg, ref args, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                    if (status == 0)
                    {
                        if (LoginInfoAcquisition.OnlineFlag)
                        {
                            // カスタムアプリケーション制御の開始
                            status = CustomApplicationStartControl.StartApplication(out msg, ref args);
                            if (status == 0)
                            {
                                if (args.Length == 0)
                                {
                                    System.Windows.Forms.Application.Run(new NSNetworkChk_Form());
                                }
                                else if (int.Parse(args[0]) == 1)
                                {
                                    // アプリケーション開始
                                    _apli = new NSNetworkChkA();

                                    System.Windows.Forms.Application.Run(_apli);
                                }
                            }
                        }
                    }
                    else
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, 0, MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, ex.Message, 0, MessageBoxButtons.OK);
                }
                finally
                {
                    // カスタムアプリケーション制御の終了
                    CustomApplicationStartControl.EndApplication();
                    ApplicationStartControl.EndApplication();

                }
            }
        }



        /// <summary>
        /// ニューテックスのチェック処理
        /// </summary>
        static private bool MutexCheck(string mutexName)
        {
            bool result = false;
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, mutexName);
            try
            {
                //ミューテックスの所有権を要求する
                if( mutex.WaitOne(0, false) == false )
                {
                    //すでに起動していると判断する
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// アプリケーション終了イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            // カスタムアプリケーション制御の終了
            CustomApplicationStartControl.EndApplication();
            //メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}