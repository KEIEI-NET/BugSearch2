using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics; // 2010/05/19 Add

using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;

using Microsoft.Win32;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SCM Webサーバチェッカーアプリケーションのエントリクラス
    /// </summary>
    /// <remarks>
    /// <br>Update Note	: ログファイル名を変更（SCMChcker.log⇒SCMCheker_日付.log)</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2010/03/05</br>
    /// <br></br>
    /// <br>Update Note	: 二重起動の防止</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2010/05/19</br>
    /// </remarks>
    /// <br>Update Note	: クライアントアセンブリ起動の対応</br>
    /// <br>Programmer	: 20056 對馬 大輔</br>
    /// <br>Date		: 2010/07/30</br>
    /// </remarks>
    internal static class Program
	{
        private static string[] _parameter;						// 起動パラメータ
        private static Form _form = null;

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
        static void Main(String[] args)
		{
            if (!CanRun()) return;  // 2010/05/19 Add

            #region ログ書き込み初期設定
            string msg = "";
            _parameter = args;
            string workDir = null;

            // ﾚｼﾞｽﾄﾘｷｰ取得
            StreamWriter writer = null;                          // テキストログ用
            //>>>2010/07/30
            //RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Product\Partsman");
            //<<<2010/07/30

            if (key == null) // あってはいけないケース
            {
                //>>>2010/07/30
                //workDir = @"C:\Program Files\Partsman\USER_AP"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
                workDir = @"C:\Program Files\Partsman"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
                //<<<2010/07/30
            }
            else
            {
                // ログ書き込みﾌｫﾙﾀﾞ指定
                //>>>2010/07/30
                //workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman").ToString();
                //<<<2010/07/30
            }

            Directory.CreateDirectory(@"" + workDir + @"\Log\PMCMN06200S");

            // ﾃｷｽﾄﾛｸﾞ書込み (Main())
            // 2010/03/05 >>>
            //writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\SCMChecker.Log", true, System.Text.Encoding.GetEncoding("shift-jis"));
            writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\" + string.Format("SCMChecker_{0}.Log", DateTime.Now.ToString("yyyyMMdd")), true, System.Text.Encoding.GetEncoding("shift-jis"));
            // 2010/03/05 <<<
            writer.Write(DateTime.Now + " PMSCM01000U.exe　Main() " + "\r\n");
            writer.Flush();
            if (writer != null) writer.Close();
            #endregion

            try
            {
                Console.WriteLine("START");
                Console.ReadLine();

                // カレントディレクトリ設定
                System.IO.Directory.SetCurrentDirectory(workDir);

                //アプリケーション開始準備処理
                //第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                //>>>2010/07/30
                //int status = ServerApplicationMethodCallControl.StartApplication(
                //        out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode);
                //<<<2010/07/30

                // 第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                //int status = ApplicationStartControl.StartApplication(
                //    out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                //>>>2010/07/30
                int status = ApplicationStartControl.StartApplication(
                    out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                //<<<2010/07/30

                if (status == 0)
                {
                    // ﾃｷｽﾄﾛｸﾞ書込み (自動処理起動)
                    // 2010/03/05 >>>
                    //writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\SCMChecker.Log", true, System.Text.Encoding.GetEncoding("shift-jis"));
                    writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\" + string.Format("SCMChecker_{0}.Log", DateTime.Now.ToString("yyyyMMdd")), true, System.Text.Encoding.GetEncoding("shift-jis"));
                    // 2010/03/05 <<<
                    writer.Write(DateTime.Now + " ログイン情報取得成功 " + "\r\n");
                    writer.Flush();
                    if (writer != null) writer.Close();

                    // オンライン状態判断
                    //if (!LoginInfoAcquisition.OnlineFlag)
                    //{
                     //   TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMSCM01000U",
                     //       "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    //}
                    //else
                    //{
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

                        using (IRunable scmWebServerChecker = new SCMCheckerForm())
                        {
                            scmWebServerChecker.Run();
                        }
                    //}
                }
                else
                {
                   // TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMSCM01000U", msg, 0, MessageBoxButtons.OK);
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
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            // メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();

            // 従業員ログオフのメッセージを表示
            if (_form != null)
            {
                //TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMSCM01000U", e.ToString(), 0, MessageBoxButtons.OK);
            }
            else
            {
                //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMSCM01000U", e.ToString(), 0, MessageBoxButtons.OK);
            }

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

        // 2010/05/19 Add >>>
        /// <summary>
        /// 起動できるか判定します。
        /// </summary>
        /// <returns><c>true</c> :起動可能<br/><c>false</c>:起動不可</returns>
        private static bool CanRun()
        {
            return Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length <= 1;
        }
        // 2010/05/19 Add <<<
	}
}