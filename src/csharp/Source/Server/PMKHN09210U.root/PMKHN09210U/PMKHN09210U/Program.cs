
using System;
using System.Collections.Generic;
//using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.IO;
using Microsoft.Win32;

namespace Broadleaf.Windows.Forms
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

            // ﾚｼﾞｽﾄﾘｷｰ取得
            StreamWriter writer = null;                          // テキストログ用
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

            Directory.CreateDirectory(@"" + workDir + @"\Log\PMCMN06200S");

            // ﾃｷｽﾄﾛｸﾞ書込み (Main())
            writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
            writer.Write(DateTime.Now + " PMKHN09210U.exe　Main() " + "\r\n");
            writer.Flush();
            if (writer != null) writer.Close();

            try
            {

                System.IO.Directory.SetCurrentDirectory(workDir);
                //アプリケーション開始準備処理
                //第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                int status = ServerApplicationMethodCallControl.StartApplication(
                        out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode);

                //int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

                if (status == 0)
                {

                    // ﾃｷｽﾄﾛｸﾞ書込み (自動処理起動)
                    writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                    writer.Write(DateTime.Now + " ログイン情報取得成功 " + "\r\n");
                    writer.Flush();
                    if (writer != null) writer.Close();

                    ////オンライン状態判断
                    //if (!LoginInfoAcquisition.OnlineFlag)
                    //{
                    //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKHN09210U",
                    //        "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    //}
                    //else
                    //{
                    //System.Windows.Forms.Application.EnableVisualStyles();
                    //System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    _form = new PMKHN09210UA();
                    //if (_parameter.Length > 0) // サービス設定画面表示
                    //{
                    //    System.Windows.Forms.Application.Run(_form);
                    //}
                    //else // 引数がある場合は画面表示せず終了するため、下記処理を行わない。
                    //{
                    ((PMKHN09210UA)_form).MergeOfferToUser(); // 自動起動時処理
                    //}
                    //}
                }
                else
                {
                    //MessageBox.Show(msg, "PMKHN09210U", MessageBoxButtons.OK);
                    string parmMsg = "";
                    foreach (string param in _parameter)
                    {
                         parmMsg = param;
                    }


                    // ﾃｷｽﾄﾛｸﾞ書込み (自動処理起動)
                    writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                    writer.Write(DateTime.Now
                        + " ログイン情報取得失敗 " + "\r\n" + "エラーメッセージ " + msg + "\r\n"
                        + " パラメーター " + parmMsg + "\r\n"
                        + " プロダクトコード " + ConstantManagement_SF_PRO.ProductCode + "\r\n"
                        + " ステータス" + status + "\r\n");
                    writer.Flush();
                    if (writer != null) writer.Close();

                }
            }
            catch(Exception ex)
            {
                writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now
                    + " catch() "
                    + " ログイン情報取得失敗 " + "\r\n" + "エラーメッセージ " + ex + "\r\n"
                    + " パラメーター " + _parameter + "\r\n"
                    + " プロダクトコード " + ConstantManagement_SF_PRO.ProductCode + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }

        }


        ///// <summary>
        ///// アプリケーション終了イベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e">メッセージ</param>
        //private static void ApplicationReleased(object sender, EventArgs e)
        //{
        //    //メッセージを出す前に全て開放
        //    ApplicationStartControl.EndApplication();
        //    //従業員ログオフのメッセージを表示
        //    MessageBox.Show(e.ToString(), "PMKHN09210U", MessageBoxButtons.OK);
        //    //アプリケーション終了
        //    System.Windows.Forms.Application.Exit();
        //}
    }
}