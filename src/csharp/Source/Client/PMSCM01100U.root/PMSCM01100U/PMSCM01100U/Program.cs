//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理のエントリポイント
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/06/22  修正内容 : NS待機処理対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/04/09  修正内容 : SCM仕掛一覧№10641対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/11/26  修正内容 : SCM仕掛一覧№10707対応
//----------------------------------------------------------------------------//
using System;
using System.Diagnostics;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Runtime.InteropServices;
using Broadleaf.Application.Controller.Util;   // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応
// 参考コード用
//using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 回答送信処理のエントリクラス
    /// </summary>
    internal static class Program
    {
        #region <Const/>

        /// <summary>プログラムID</summary>
        private const string PROGRAM_ID = "PMSCM001100U";

        /// <summary>正常</summary>
        private const int NORMAL_STATUS = 0;
        /// <summary>異常</summary>
        private const int ERROR_STATUS = -1;    // ApplicationStartControl.StartApplication() の異常コード

        #endregion  // <Const/>

        /// <summary>メインフォーム</summary>
        private static PMSCM01101UA _mainForm;

        #region API定義
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        static extern uint SendMessage(IntPtr window, int msg, IntPtr wParam, ref COPYDATASTRUCT lParam);

        public const Int32 WM_COPYDATA = 0x4A;
        public const Int32 WM_USER = 0x400;

        //COPYDATASTRUCT構造体 
        struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public UInt32 cbData;
            public string lpData;
        }
        #endregion 

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// <remarks>
        /// ログインチェックを行い、メインフレーム（フォーム）を起動します。
        /// </remarks>
        /// <param name="args">コマンドライン引数</param>
        [STAThread]
        private static void Main(string[] args)
        {
            if (args == null || args.Length.Equals(0)) return;
            try
            {
                // メッセージボックスはXPスタイル
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

                // 起動制御
                string msg = string.Empty;
                
                if (args[0] == "/B")
                {
                    System.IO.Directory.SetCurrentDirectory(System.Windows.Forms.Application.StartupPath);
                }
                else
                {
                    int status = ApplicationStartControl.StartApplication(
                        out msg,
                        ref args,
                        ConstantManagement_SF_PRO.ProductCode,  // アプリケーションのソフトウェアコードを指定（できない場合はプロダクトコード）
                        new EventHandler(ReleasedApplicationEventHandler)
                    );
                    if (status.Equals(NORMAL_STATUS))
                    {
                        if (HasSecurityError(out msg))
                        {
                            ShowDefaultAlert(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, status);
                            return;
                        }
                    }
                    else
                    {
                        ShowDefaultAlert(emErrorLevel.ERR_LEVEL_INFO, msg, status);
                        return;
                    }
                }
                if (SCMControllerFacade.IsPM7BatchMode(args))
                {
                    SendPM7AnswerDataIf(args);
                }
                else
                {
                    // 2010/02/13 Add >>>
                    try
                    {
                        //System.Diagnostics.Process.Start("PMSCM01104U.exe");
                        // 2010/02/13 Add <<<
                        // アプリケーション開始
                        // UPD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
                        SCMSendController scmController = SCMControllerFacade.CreateSCMController(args);
                        _mainForm = new PMSCM01101UA(scmController);
                        // UPD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<
                        // UPD 2014/04/09 SCM仕掛一覧№10641対応 ----------------------------------------------->>>>>
                        //System.Windows.Forms.Application.Run(_mainForm);
                        if (!_mainForm.IsBatchMode)
                        {

                            System.Threading.Mutex mutex = new System.Threading.Mutex(false, "回答送信処理");
                            if (mutex.WaitOne(0, false) == false)
                            {
                                MessageBox.Show("すでに回答送信処理画面が起動しています。", "回答送信処理", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
                                SimpleLogger.WriteSlipNumLog(scmController.SettingInfo.SCMDataPath, "回答送信処理画面が重複起動しました。");
                                // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<
                                return;
                            }
                            else
                            {
                                System.Windows.Forms.Application.Run(_mainForm);
                            }
                            //ミューテックスを解放する
                            mutex.ReleaseMutex();
                        }
                        else
                        {
                            System.Windows.Forms.Application.Run(_mainForm);
                        }
                        // UPD 2014/04/09 SCM仕掛一覧№10641対応 -----------------------------------------------<<<<<
                    }
                    finally
                    {
                        SendRecevingClose();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("\n" + e.ToString() + "\n");
                ShowDefaultAlert(emErrorLevel.ERR_LEVEL_STOPDISP, e.Message, ERROR_STATUS);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        #region <お約束/>

        /// <summary>
        /// セキュリティエラーがあるか判定します。
        /// </summary>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>
        /// <c>true</c> :セキュリティエラーあり<br/>
        /// <c>false</c>:セキュリティエラーなし
        /// </returns>
        private static bool HasSecurityError(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!LoginInfoAcquisition.OnlineFlag)
            {
                errorMessage = "オフライン状態で本機能はご使用できません。"; // LITERAL:
                return true;
            }

            return false;
        }

        /// <summary>
        /// アプリケーション終了時のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private static void ReleasedApplicationEventHandler(
            object sender,
            EventArgs e
        )
        {
            // メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();

            // 従業員ログオフのメッセージを表示
            if (_mainForm != null)
            {
                TMsgDisp.Show(
                    _mainForm.Owner,
                    emErrorLevel.ERR_LEVEL_INFO,
                    PROGRAM_ID,
                    e.ToString(),
                    ERROR_STATUS,
                    MessageBoxButtons.OK
                );
            }
            else
            {
                ShowDefaultAlert(emErrorLevel.ERR_LEVEL_INFO, e.ToString(), ERROR_STATUS);
            }

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// デフォルトのアラートを表示します。
        /// </summary>
        /// <param name="errorLevel">エラーレベル</param>
        /// <param name="message">メッセージ</param>
        /// <param name="status">処理結果</param>
        public static void ShowDefaultAlert(
            emErrorLevel errorLevel,
            string message,
            int status
        )
        {
            TMsgDisp.Show(errorLevel, PROGRAM_ID, message, status, MessageBoxButtons.OK);
        }

        #endregion  // <お約束/>


        private static void SendRecevingClose()
        {
            Process[] pr = Process.GetProcessesByName("PMSCM01104U");
            foreach (Process process in pr)
            {
                COPYDATASTRUCT st = new COPYDATASTRUCT();

                string msg = "Close";
                st.dwData = (IntPtr)0;
                st.cbData = (uint)( msg.Length + 1 );
                st.lpData = msg;

                SendMessage(process.MainWindowHandle, WM_COPYDATA, (IntPtr)0, ref st);
            }
        }

        /// <summary>
        /// PM7用送信起動モードの場合、PM7の回答データを送信します。
        /// </summary>
        /// <param name="args">コマンドライン引数</param>
        // DEL 2010/06/22 NS待機処理対応 ---------->>>>>
        //[Conditional("DEBUG")]
        // DEL 2010/06/22 NS待機処理対応 ----------<<<<<
        private static void SendPM7AnswerDataIf(string[] args)
        {
            if (SCMControllerFacade.IsPM7BatchMode(args))
            {
                int status = SCMControllerFacade.SendToWebServerByPM7BatchMode(args[1]);
            }
        }
    }
}