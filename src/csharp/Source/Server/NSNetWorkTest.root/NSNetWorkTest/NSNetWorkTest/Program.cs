using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Microsoft.Win32;

namespace NSNetworkTest
{
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
            string msg = "";
            _parameter = args;
            string workDir = null;

            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

            if (key == null) // あってはいけないケース
            {
                workDir = @"C:\Program Files\Partsman\USER_AP"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
            }
            else
            {
                // ログ書き込みﾌｫﾙﾀﾞ指定
                workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
            }

            try
            {
                System.IO.Directory.SetCurrentDirectory(workDir);

                //アプリケーション開始準備処理
                //第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                int status = ServerApplicationMethodCallControl.StartApplication(
                        out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode);


                if (status == 0)
                {
                    _form = new NSNetWorkTestForm();

                    ((NSNetWorkTestForm)_form).NetWorkTestToAP(); // 自動起動時処理

                }

            }
            catch (Exception ex)
            {
                // なし。
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