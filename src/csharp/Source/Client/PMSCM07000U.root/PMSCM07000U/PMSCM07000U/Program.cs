//****************************************************************************//
// システム         : NS待機処理
// プログラム名称   : NS待機処理のエントリポイント
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/06/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2010/10/08  修正内容 : PM7待機処理でデータ送信可能とする
//----------------------------------------------------------------------------//
using System;
using System.Diagnostics;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// NS待機処理
    /// </summary>
    internal static class Program
    {
        #region Const

        /// <summary>プログラムID</summary>
        private const string PROGRAM_ID = "PMSCM001100U";   // UNDONE:仮プログラムID

        /// <summary>正常</summary>
        private const int NORMAL_STATUS = 0;
        /// <summary>異常</summary>
        private const int ERROR_STATUS = -1;    // ApplicationStartControl.StartApplication() の異常コード

        #endregion  // Const

        /// <summary>メインフォーム</summary>
        private static SCMSendingDataWatcherForm _mainForm;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// <param name="args">コマンドライン引数</param>
        [STAThread]
        private static void Main(string[] args)
        {
            if (args == null || args.Length.Equals(0)) return;

            string[] svArgs = args; // 2010/10/08

            try
            {
                // メッセージボックスはXPスタイル
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

                // 起動制御
                string msg = string.Empty;

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

                // アプリケーション開始
                _mainForm = new SCMSendingDataWatcherForm();
                _mainForm.Args = svArgs; // 2010/10/08
                System.Windows.Forms.Application.Run(_mainForm);
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
    }
}