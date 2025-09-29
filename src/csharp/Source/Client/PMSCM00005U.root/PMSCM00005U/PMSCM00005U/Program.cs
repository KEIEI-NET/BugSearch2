//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : SCMポップアップ
// プログラム概要   : エントリクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡 
// 作 成 日  2012/07/25  修正内容 : 2012/09/12配信 №10303対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡 
// 作 成 日  2012/08/20  修正内容 : 2012/09/12配信 №10303対応（タスクバーアイコン削除対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2012/08/23  修正内容 : 2012/09/12配信 システムテスト障害№4対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2012/09/11  修正内容 : SCM障害№10365対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30746 高川 悟
// 作 成 日  2012/12/07  修正内容 : SCM障害№10448対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2012/12/19  修正内容 : SCM障害№10423対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2014/06/04  修正内容 : 例外エラーにより終了した場合の調査用ログ追加
//----------------------------------------------------------------------------//
// 管理番号  11070148-00 作成担当 : 宮本 利明
// 作 成 日  2014/10/01  修正内容 : 例外対応：例外発生時に警告メッセージ表示
//----------------------------------------------------------------------------//
// 管理番号  11070148-00 作成担当 : 宮本 利明
// 作 成 日  2014/10/07  修正内容 : システムテスト障害 №133
//                                  エラーメッセージを最前面に表示
//----------------------------------------------------------------------------//
// 管理番号  11100068-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2015/03/06  修正内容 : 企業連結が存在しない場合、起動しないように修正
//----------------------------------------------------------------------------//

using System;
using System.Windows.Forms;

using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Library.Windows.Forms;

// 2012/12/07 ADD TAKAGAWA SCM障害改良No10448 -------->>>>>>>>>>
using Microsoft.Win32;
using System.IO;
// 2012/12/07 ADD TAKAGAWA SCM障害改良No10448 --------<<<<<<<<<<
// >>> 2015/03/06
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using System.Collections.Generic;
// <<< 2015/03/06

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SCMポップアップアプリケーションのエントリクラス
    /// </summary>
	internal static class Program
	{
        private static string[] _parameter;						// 起動パラメータ
        //private static Form _form = null;
        public static bool PM7Mode=false;

        // ADD 2012/08/23 T.Yoshioka 2012/09/12配信システム障害№4 対応 ---------->>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// コマンドライン引数の保管
        /// </summary>
        public static string[] argsSave;
        // ADD 2012/08/23 T.Yoshioka 2012/09/12配信システム障害№4 対応 ----------<<<<<<<<<<<<<<<<<<<<<<<<
        // UPD 2012/09/11 T.Yoshioka SCM障害№10365対応 ---------->>>>>>>>>>>>>>>>>>
        public const string RIGHTCLICK = "rightClick";
        // UPD 2012/09/11 T.Yoshioka SCM障害№10365対応 ----------<<<<<<<<<<<<<<<<<<
        // --- ADD 2014/10/01 T.Miyamoto ------------------------------>>>>>
        public static bool ExceptionFlg = false;
        // --- ADD 2014/10/01 T.Miyamoto ------------------------------<<<<<

        /// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
        /// <param name="args">コマンドライン引数</param>
		[STAThread]
		static void Main(string[] args)
		{
            // --- 2014/06/04 ADD m.suzuki 例外発生時の調査用ログ追加 --->>>>>
            // ハンドルされていない例外を捕捉する
            System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            System.AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            // --- 2014/06/04 ADD m.suzuki 例外発生時の調査用ログ追加 ---<<<<<

            // 2012/12/07 ADD TAKAGAWA SCM障害改良No10448 -------->>>>>>>>>>
            string workDir = null;

            // レジストリキー取得
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Product\Partsman");

            if (key == null)    // 通常はありえない
            {
                workDir = @"C:\Program Files\Partsman";     // レジストリに情報がないため、仮にデフォルトのフォルダを設定
            }
            else
            {
                workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman").ToString();
            }

            // フォルダを作成する
            Directory.CreateDirectory(@"" + workDir + @"\Log\PMCMN06200S");
            // 2012/12/07 ADD TAKAGAWA SCM障害改良No10448 --------<<<<<<<<<<

            // ADD 2012/08/23 T.Yoshioka 2012/09/12配信システム障害№4 対応 ---------->>>>>>>>>>>>>>>>>>>>>>>
            argsSave = args;
            // ADD 2012/08/23 T.Yoshioka 2012/09/12配信システム障害№4 対応 ----------<<<<<<<<<<<<<<<<<<<<<<<<

            // DEL 2012/08/23 T.Yoshioka 2012/09/12配信システム障害№4 対応 ---------->>>>>>>>>>>>>>>>>>>>>>>
            //// ADD 2012/07/25 №10303 T.Yoshioka 2012/09/12配信予定 --------------->>>>>>>>>>>>>>>>>>>
            //try
            //{
            //    // 自身のプロセス名と同じプロセスを取得
            //    System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName);

            //    foreach (System.Diagnostics.Process wPs in ps)
            //    {
            //        // 同一プロセス名で、プロセスIDが違う（自身のプロセスではない）場合
            //        if (System.Diagnostics.Process.GetCurrentProcess().Id != wPs.Id)
            //        {
            //            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            //            // ComSpec（cmd.exe）のパスを取得
            //            psi.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
            //            // ウィンドウを表示しないようにする
            //            psi.CreateNoWindow = true;
            //            // ウィンドウを非表示に
            //            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            //            // ADD 2012/08/20 T.Yoshioka アイコン削除対応 --------------->>>>>>>>>>>>>>>>>>>>>>
            //            // コマンドラインを指定（"/c"は実行後閉じるために必要） /t:通常終了（タスクバーのアイコン消去）
            //            psi.Arguments = @"/C taskkill /t /pid " + wPs.Id.ToString();
            //            // 起動（コマンド実行）
            //            System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);
            //            p.WaitForExit();
            //            // ADD 2012/08/20 T.Yoshioka アイコン削除対応---------------<<<<<<<<<<<<<<<<<<<<<<<

            //            // コマンドラインを指定（"/c"は実行後閉じるために必要）/f:強制終了（上記通常終了だとプロセスが終了されない）
            //            psi.Arguments = @"/C taskkill /f /pid " + wPs.Id.ToString();
            //            // 起動（コマンド実行）
            //            p = System.Diagnostics.Process.Start(psi);
            //            p.WaitForExit();
            //        }
            //    }
            //}
            //catch
            //{
            //}
            //// ADD 2012/07/25 №10303 T.Yoshioka 2012/09/12配信予定 ---------------<<<<<<<<<<<<<<<<<<<
            // DEL 2012/08/23 T.Yoshioka 2012/09/12配信システム障害№4 対応 ----------<<<<<<<<<<<<<<<<<<<

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
                    System.Windows.Forms.Application.Run(new SCMPopupForm(args));
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

                    // >>> 2015/03/06
                    if (!CheckStarting()) return;
                    // <<< 2015/03/06

                    if (status == 0)
                    {
                        // オンライン状態判断
                        if (!LoginInfoAcquisition.OnlineFlag)
                        {
                            if (args.Length <= 2 || args[2] != "/S")
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMSCM00005U",
                                    "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            // ADD 2012/12/19 T.Yoshioka 2013/01/16配信№10423 対応 ---------->>>>>>>>>>>>>>>>>>>
                            // 倉庫設定移行ツールの起動
                            try
                            {
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                string fileName = Path.Combine(Directory.GetCurrentDirectory(), "PMSCM01300U.exe");
                                process.StartInfo.FileName = fileName;
                                process.StartInfo.Arguments = args[0] + " " + args[1] + " /A";
                                process.Start();
                            }
                            catch (Exception ex)
                            {
                            }
                            // ADD 2012/12/19 T.Yoshioka 2016/01/16配信№10423 対応 ----------<<<<<<<<<<<<<<<<<<<

                            // UPD 2012/09/11 T.Yoshioka SCM障害№10365対応 ---------->>>>>>>>>>>>>>>>>>
                            // ADD 2012/08/23 T.Yoshioka 2012/09/12配信システム障害№4 対応 ---------->>>>>>>>>>>>>>>>>>
                            // コマンドライン引数の数　2個：業務メニュー　3個かつ"rightClick"：タスクのパトランプアイコン右クリックメニューの"更新"
                            if (args.Length == 2
                                || !(args.Length == 3 && args[2].Equals(RIGHTCLICK)))
                            {
                            //if (args.Length == 2)
                            //{
                            // ADD 2012/08/23 T.Yoshioka 2012/09/12配信システム障害№4 対応 ----------<<<<<<<<<<<<<<<<<<<
                            // UPD 2012/09/11 T.Yoshioka SCM障害№10365対応 ----------<<<<<<<<<<<<<<<<<<
                                // ポップアップの多重起動防止
                                if (SCMClientUtil.CanRun())
                                {
                                    System.Windows.Forms.Application.EnableVisualStyles();
                                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                                    System.Windows.Forms.Application.Run(new SCMPopupForm(args));
                                }
                                else
                                {
                                    //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMSCM00005U", msg, 0, MessageBoxButtons.OK);
                                }
                                // ADD 2012/08/23 T.Yoshioka 2012/09/12配信システム障害№4 対応 ---------->>>>>>>>>>>>>>>>>>
                            }
                            else
                            {
                                System.Windows.Forms.Application.EnableVisualStyles();
                                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                                System.Windows.Forms.Application.Run(new SCMPopupForm(args));
                            }
                            // ADD 2012/08/23 T.Yoshioka 2012/09/12配信システム障害№4 対応 ----------<<<<<<<<<<<<<<<<<<<
                        }
                    }
                }
                finally
                {
                    ApplicationStartControl.EndApplication();
                }
            }
		}

        // >>> 2015/03/06
        /// <summary>
        /// 起動チェック
        /// </summary>
        /// <returns></returns>
        static bool CheckStarting()
        {
            //-------------------------------------------------------
            // 企業連結が無い場合は、ポップアップを起動しない
            //-------------------------------------------------------
            ScmEpCnectAcs scmEpCnectAcs = new ScmEpCnectAcs();
            List<ScmEpCnect> scmEpCnectList;
            Boolean msgDiv = false;
            string errMsg = string.Empty;

            int status = scmEpCnectAcs.SearchCnectOriginalEp(LoginInfoAcquisition.EnterpriseCode, ConstantManagement.LogicalMode.GetData0, out scmEpCnectList, out msgDiv, out errMsg);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                LogWriter.LogWrite(LoginInfoAcquisition.EnterpriseCode + "：企業拠点連結設定がありません。");
                return false;
            }

            return true;
        }
        //<<< 2015/3/06

        // --- 2014/06/04 ADD m.suzuki 例外発生時の調査用ログ追加 --->>>>>
        /// <summary>
        /// ハンドルされていない例外を捕捉する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            // --- ADD 2014/10/01 T.Miyamoto ------------------------------>>>>>
            ExceptionFlg = true;
            // --- UPD 2014/10/07 T.Miyamoto システムテスト障害 №133 ------------------------------>>>>>
            //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMSCM00005U"
            //             , "企業認証されていないか、企業認証が無効になっています。" + Environment.NewLine + "再度企業認証を行ってください。"
            //             ,0, MessageBoxButtons.OK);
            Form dummyForm = new Form();
            dummyForm.Opacity = 0;
            dummyForm.Show();
            dummyForm.TopMost = true;

            TMsgDisp.Show(dummyForm
                         , emErrorLevel.ERR_LEVEL_EXCLAMATION
                         , "PMSCM00005U"
                         , ex.Message
                         , 0
                         , MessageBoxButtons.OK);

            dummyForm.Dispose();
            dummyForm = null;
            // --- UPD 2014/10/07 T.Miyamoto システムテスト障害 №133 ------------------------------<<<<<
            // --- ADD 2014/10/01 T.Miyamoto ------------------------------<<<<<
            LogWriter.LogWrite("■例外エラーが発生しました■" + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
        }
        // --- 2014/06/04 ADD m.suzuki 例外発生時の調査用ログ追加 ---<<<<<

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
            //if (_form != null)
            //{
                //TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMSCM00005U", e.ToString(), 0, MessageBoxButtons.OK);
            //}
            //else
            //{
                //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMSCM00005U", e.ToString(), 0, MessageBoxButtons.OK);
            //}

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
	}
}