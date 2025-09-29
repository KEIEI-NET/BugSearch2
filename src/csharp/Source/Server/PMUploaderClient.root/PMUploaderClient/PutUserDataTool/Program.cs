using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.IO;
using Microsoft.Win32;
using System.Configuration;

namespace PutUserDataTool
{
    static class Program
    {
        #region [Const]

        /// <summary>プログラムID</summary>
        public const string PGID = "PutUserDataTool";

        #endregion

        private static string[] _parameter;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _parameter = new string[0];
            try
            {
                //起動モード(初期値:"-A"(画面有手動実行))
                int procMode = 0;

                if (args.Length > 0)
                {
                    //起動モード判定
                    procMode = DecideProcMode(args[0]);
                }

                RegistryKey keyForLog = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
                string homeDir = keyForLog.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                System.IO.Directory.SetCurrentDirectory(homeDir);

                //ログインチェック&認証取得
                string msg = string.Empty;
                int status = 0;
                status = ServerApplicationMethodCallControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode);

                #region ログ出力ディレクトリの初期化
                try
                {
                    //企業コードと拠点コードを設定
                    string enterpriseCode = LoginInfoAcquisition.EnterpriseCode; //企業コード
                    ToolApplication.Initialize(homeDir, enterpriseCode);
                }
                catch
                {
                }
                string logDir = Path.Combine(homeDir, @"Log\TOOLS\");
                try
                {
                    if (!Directory.Exists(logDir))
                    {
                        Directory.CreateDirectory(logDir);
                    }
                    ToolApplication.GetInstance().LogFile = logDir + "\\" + DateTime.Now.ToString("yyyyMMdd", null) + ".txt";
                }
                catch
                {
                }
                if (string.IsNullOrEmpty(ToolApplication.GetInstance().BaseUrl))
                {
                    return;
                }
                #endregion

                if (status != 0)
                {
                    Logger.GetInstance().Log("起動ステータス:" + status, true);
                    if (procMode == 0)
                    {
                        MessageBox.Show(
                            string.Format("企業認証が行えません。[ST={0}]\nLSMWinServiceが起動していること、USBプロテクタが認識していることをご確認してください。", status)
                            , "起動失敗"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Information);
                    }
                    return;
                }
                AddExitEvent();
                Logger.GetInstance().Log("処理を開始します。モード:" + procMode, true);
                //2:non-guimode,else:gui mode
                if (procMode == 2)
                {
                    if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
                    {
                        Logger.GetInstance().Log("既にプログラムが起動しています。", true);
                        return;
                    }
                    Logger.GetInstance().Log("指定秒数遅延させます。", true);
                    ToolApplication.GetInstance().ApplicationExecRandomSleep();
                    Logger.GetInstance().Log("実行情報を取得します。", true);
                    TaskManager taskManager = new TaskManager();
                    List<Task> taskList = taskManager.GetTask();
                    Logger.GetInstance().Log(string.Format("実行情報を取得しました。[残実行数={0}]", taskList.Count), true);
                    if (taskList.Count > 0)
                    {
                        ICommand cmd = CommandFactory.GetInstance().GetCommand(taskList);
                        cmd.Execute();
                        Logger.GetInstance().Log("全ての処理が完了しました。", true);
                    }
                }
                else
                {
                    Process[] processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
                    if (processes.Length > 1)
                    {
                        DialogResult dialogResult = MessageBox.Show("既にプログラムが起動しています。多重起動はできません。\r\n起動しているプログラムを終了してよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                        foreach (Process p in processes)
                        {
                            if (p != null && !p.HasExited && p.Id != Process.GetCurrentProcess().Id)
                            {
                                p.Kill();
                            }
                        }
                    }
                    // アプリケーション開始
                    Application.Run(new Form1());
                }

            }
            catch (Exception)
            {
                //ignore
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        #region [Methods]
        /// <summary>
        /// 処理モードの判断を行います。
        /// 0:"-A"(画面表示有り手動実行)、1:"-B"(画面表示有り自動実行)、2:"-C"(画面表示無し自動実行)
        /// </summary>
        /// <returns></returns>
        private static int DecideProcMode(string arg)
        {
            int ret = 0;
            switch (arg)
            {
                case "1":  //画面表示有り自動実行
                    ret = 1;
                    break;
                case "2":  //画面表示無し自動実行
                    ret = 2;
                    break;
                default:    //画面表示有り手動実行
                    break;
            }
            return ret;
        }

        private static void AddExitEvent()
        {
            Process[] processes = Process.GetProcessesByName("PMCMN06200S");
            if (processes == null || processes.Length == 0)
            {
                Logger.GetInstance().Log("プロセスを発見できないため処理を終了します。", true);
                Environment.Exit(0);//強制終了
            }
            else
            {
                processes[0].EnableRaisingEvents = true;
                processes[0].Exited -= OnParentProcessExited;
                processes[0].Exited += OnParentProcessExited;
            }
        }

        private static void OnParentProcessExited(object sender, EventArgs e)
        {
            try
            {
                Logger.GetInstance().Log("スケジューラーが停止したため、処理を終了します。", true);
            }
            finally
            {
                Environment.Exit(0);//強制終了
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

            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
        #endregion
    }
}