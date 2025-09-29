//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ送信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 修 正 日  2009/06/25  修正内容 : PVCS票＃282の動作ディレクトリ設定の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Microsoft.Win32;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// データ送信処理自起動
    /// </summary>
    static class Program
    {
        internal static string[] _parameter;						// 起動パラメータ
        private static System.Windows.Forms.Form _form = null;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string msg = "";
                _parameter = args;

                // ADD 2009/06/25 ---->>>
                string workDir = null;
                // ﾚｼﾞｽﾄﾘｷｰ取得
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
                if (key == null) // あってはいけないケース
                {
                    workDir = @"C:\Program Files\Partsman\USER_AP"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
                }
                else
                {
                    // カレントフォルダの設定
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }
                System.IO.Directory.SetCurrentDirectory(workDir);
                // ADD 2009/06/25 ----<<<

                //アプリケーション開始準備処理
                //第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード

				int status = ServerApplicationMethodCallControl.StartApplication(
						out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode);				

                if (status == 0)
                {
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    _form = new PMKYO01050UA();
                    ((PMKYO01050UA)_form).MergeOfferToUser(); // 自動起動時処理
                }
                else
                {
                    MessageBox.Show(msg, "PMKYO01050U", MessageBoxButtons.OK);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
            MessageBox.Show(e.ToString(), "PMKYO01050U", MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}