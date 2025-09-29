//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理エントリポイント
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/17  修正内容 : 新規作成
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
    /// セキュリティ管理メインフレームのエントリポイントクラス
    /// </summary>
    internal static class Program
    {
        #region <Const/>

        /// <summary>プログラムID</summary>
        private const string PROGRAM_ID = "PMUOE01300U";

        /// <summary>正常</summary>
        private const int NORMAL_STATUS = 0;
        /// <summary>異常</summary>
        private const int ERROR_STATUS = -1;    // TODO:ApplicationStartControl.StartApplication() の異常コード
        
        #endregion  // <Const/>

        /// <summary>メインフレーム</summary>
        private static Form _mainFrameForm;

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
                _mainFrameForm = new PMUOE01300UA();
                System.Windows.Forms.Application.Run(_mainFrameForm);
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
            if (_mainFrameForm != null)
            {
                TMsgDisp.Show(
                    _mainFrameForm.Owner,
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