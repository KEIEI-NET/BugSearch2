using System;
using System.Diagnostics;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;

using Microsoft.Win32;
using System.IO;

namespace Broadleaf.Windows.Forms
{
    internal static class Program
    {
        /// <summary>プログラムID</summary>
        private const string PROGRAM_ID = "PMSCM01300U";

        /// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
        /// <param name="args">コマンドライン引数</param>
        [STAThread]
        static void Main(string[] args)
        {
            if (args == null || args.Length.Equals(0)) return;
            try
            {
                // メッセージボックスはXPスタイル
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

                // 起動制御
                string msg = string.Empty;

                // アプリケーション開始準備処理
                int status = ApplicationStartControl.StartApplication(
                    out msg,
                    ref args,
                    ConstantManagement_SF_PRO.ProductCode,  // アプリケーションのソフトウェアコードを指定（できない場合はプロダクトコード）
                    new EventHandler(ReleasedApplicationEventHandler)
                );

                // "/A":ポップアップから呼ばれた（バッチ処理）
                bool modeBatch = (args.Length > 0 && args[0] == "/A");

                if (status.Equals(0))
                {
                    if (HasSecurityError(out msg))
                    {
                        ShowDefaultAlert(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, status, modeBatch);
                        return;
                    }
                    // 移行処理開始
                    if (!modeBatch)
                    {
                        msg = "倉庫移行処理を開始してよろしいですか？";
                        if (TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, PROGRAM_ID, msg, status, MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    Iko _iko = new Iko();
                    status = _iko.Iko_Main(modeBatch);

                    msg = "倉庫移行処理が終了しました。status:" + status;
                    ShowDefaultAlert(emErrorLevel.ERR_LEVEL_INFO, msg, status, modeBatch);
                }
                else
                {
                    ShowDefaultAlert(emErrorLevel.ERR_LEVEL_INFO, msg, status, modeBatch);
                    return;
                }
            }
            catch (Exception e)
            {
                ShowDefaultAlert(emErrorLevel.ERR_LEVEL_STOPDISP, e.Message, -1, true);
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
        private static void ReleasedApplicationEventHandler(object sender, EventArgs e)
        {
            // メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

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
                errorMessage = "オフライン状態で本機能はご使用できません。"; 
                return true;
            }

            return false;
        }

        /// <summary>
        /// デフォルトのアラートを表示します。
        /// </summary>
        /// <param name="errorLevel">エラーレベル</param>
        /// <param name="message">メッセージ</param>
        /// <param name="status">処理結果</param>
        /// <param name="batch">バッチ処理</param>
        public static void ShowDefaultAlert(
            emErrorLevel errorLevel,
            string message,
            int status,
            bool batch
        )
        {
            if (!batch) TMsgDisp.Show(errorLevel, PROGRAM_ID, message, status, MessageBoxButtons.OK);
        }

    }
}
