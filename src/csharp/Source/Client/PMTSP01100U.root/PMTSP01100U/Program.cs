//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : TSPデータ送信処理
// プログラム概要   : TSPデータ送信処理 起動
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670305-00 作成担当 : 小原
// 作 成 日  2020/12/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Threading ;  // for Mutex
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Application
{
    class PMTSP01100UA 
    {
        private static Mutex mutex;
        private static string[] _parameter;						// 起動パラメータ
        private static Form _form = null;

        static void Main(string[] args)
        {
            try
            {
#if DEBUG
                MessageBox.Show("test");
#endif
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
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMTSP01100U",
                            "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (args[2] == "/M")
                        {

                            mutex = new Mutex(false, "PMTSP01100U_MANU");  // Mutex 生成 ; false = 所有権なし
                            if (!mutex.WaitOne(0, false))             // Mutex 取得 ; false = 再取得なし
                            {
                                MessageBox.Show("TSPデータ送信処理が起動しています。", "TSPデータ送信処理", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            _form = new PMTSP01103UA();
                            _form.ShowDialog();
                        }
                        else if (args[2] == "/A")
                        {
                            mutex = new Mutex(false, "PMTSP01100U_AUTO");  // Mutex 生成 ; false = 所有権なし
                            if (!mutex.WaitOne(0, false))             // Mutex 取得 ; false = 再取得なし
                            {
                                return;
                            }

                            TspSendController TspController = new TspSendController();
                            if (TspController.OpenErrorLog() == -1) return;

                            if (TspController.ReadTSPList() > 0)
                            {


                                TspController.WriteErrorLog("自動送信");

                                _form = new PMTSP01103UC(ref TspController, FormStartPosition.Manual);
                                _form.ShowDialog();

                                TspController.WriteErrorLog("終了\r\n");
                                TspController.CloseErrorLog();
                            }
                        }
                        else
                        {

                        }
                    }
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMTSP01100U", msg, 0, MessageBoxButtons.OK);
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
        /// <remarks>
        /// Note       : アプリケーション終了イベント処理です。<br />
        /// Programmer : 小原<br />
        /// Date       : 2020/12/02<br />
        /// </remarks>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            // メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();

            // 従業員ログオフのメッセージを表示
            if (_form != null)
            {
                TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMTSP01100U", e.ToString(), 0, MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMTSP01100U", e.ToString(), 0, MessageBoxButtons.OK);
            }

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}
