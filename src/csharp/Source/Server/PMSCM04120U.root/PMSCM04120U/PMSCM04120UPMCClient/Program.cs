//****************************************************************************//
// システム         : ＰＭ.ＮＳ
// プログラム名称   : PMデータ同期処理起動画面
// プログラム概要   : アクセスクラスの同期処理をコールする
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 林超凡
// 作 成 日  2014/08/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Microsoft.Win32;

namespace Broadleaf.Windows.Forms
{
    static class Program
    {
        private static string[] _parameter;						// 起動パラメータ
        private static System.Windows.Forms.Form _form = null;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            try
            {
                string msg = string.Empty;
                _parameter = args;
                string workDir = null;

                // ﾚｼﾞｽﾄﾘｷｰ取得
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Product\Partsman");
                if (key == null) // あってはいけないケース
                {
                    workDir = @"C:\Program Files\Partsman"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
                }
                else
                {
                    // カレントフォルダの設定
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman").ToString();
                }
                System.IO.Directory.SetCurrentDirectory(workDir);
                DebugLog("起動処理確認:" + _parameter.Length);
                // アプリケーション開始準備処理
                // 第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード                
                int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                DebugLog("起動処理:" + status + ":" + msg);
                if (status == 0)
                {
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    // アクセスクラスの同期処理をコールしたら処理を終了する。
                    _form = new PMSCM04120UA();
                    if (_parameter.Length >= 1 && _parameter[0].Trim() == "/T")
                    {
                        ((PMSCM04120UA)_form).TranslateExecute(); // 自動起動時処理          
                    }
                    else
                    {
                        ((PMSCM04120UA)_form).RegularStart(); // 自動起動時処理          
                    }
                }
            }
            catch (Exception e)
            {
                DebugLog("エラー発生:" + e.Message + "\r\n" + e.StackTrace);
            }
            finally
            {
                DebugLog("終了処理");
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// 調査用ログ
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        static void DebugLog(string message)
        {
            RegistryKey keyForLog = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Product\Partsman");
            string homeDir = keyForLog.GetValue("InstallDirectory", @"C:\Program Files\Partsman").ToString();
            StreamWriter writer = null;
            try
            {
                try
                {
                    if (!Directory.Exists(Path.Combine(homeDir, @"Log\PMSCM04120U")))
                    {
                        Directory.CreateDirectory(Path.Combine(homeDir, @"Log\PMSCM04120U"));
                    }
                }
                catch
                {
                }
                DirectoryInfo dir = new DirectoryInfo(Path.Combine(homeDir, @"Log\PMSCM04120U"));
                if (dir.Exists)
                {
                    DateTime deleteTime = DateTime.Now.AddMonths(-1);
                    foreach (FileInfo f in dir.GetFiles())
                    {
                        if (f.LastWriteTime <= deleteTime)
                        {
                            f.Delete();
                        }
                    }
                }
                writer = new StreamWriter(Path.Combine(homeDir, @"Log\PMSCM04120U\" + DateTime.Now.ToString("yyyyMMdd", null) + ".txt"), true);
                writer.WriteLine(string.Format(DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + " : " + message));
            }
            catch
            {
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
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
            ApplicationStartControl.EndApplication();
            //従業員ログオフのメッセージを表示
            if (_form != null)
                TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "", e.ToString(), 0, MessageBoxButtons.OK);
            else
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "", e.ToString(), 0, MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

    }
}