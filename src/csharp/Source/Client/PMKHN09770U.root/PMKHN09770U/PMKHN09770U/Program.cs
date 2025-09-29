//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫一括削除画面
// プログラム概要   : 在庫一括削除画面エントリポイント
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// 管理番号  11570249-00  作成担当 : 譚洪
// 作 成 日  2020/03/09   修正内容 : 新規作成
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
    /// 在庫一括削除画面メインフレームのエントリポイントクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 在庫一括削除画面メインフレームのエントリポイントクラス。</br>
    /// <br>Programmer	: 譚洪</br>
    /// <br>Date		: 2020/03/09</br>
    /// </remarks>
    internal static class Program
    {
        #region <Const/>

        /// <summary>プログラムID</summary>
        private const string ProGramId = "PMKHN09770U";
        /// <summary>正常</summary>
        private const int NormalStatus = 0;
        /// <summary>異常</summary>
        private const int ErrorStatus = -1;    
        
        #endregion  // <Const/>

        /// <summary>メインフレーム</summary>
        private static Form MainForm;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// <param name="args">コマンドライン引数</param>
        /// <remarks>
        /// <br>Note		: ログインチェックを行い、メインフレーム（フォーム）を起動します。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
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
                if (status.Equals(NormalStatus))
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
                MainForm = new PMKHN09770UA();
                System.Windows.Forms.Application.Run(MainForm);
            }
            catch (Exception e)
            {
                Debug.WriteLine("\n" + e.ToString() + "\n");
                ShowDefaultAlert(emErrorLevel.ERR_LEVEL_STOPDISP, e.Message, ErrorStatus);
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
        /// <remarks>
        /// <br>Note		: セキュリティエラーがあるか判定します。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        private static bool HasSecurityError(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!LoginInfoAcquisition.OnlineFlag)
            {
                errorMessage = "オフライン状態で本機能はご使用できません。"; // LITERAL:
                return true;
            }
            else
            {
                //なし
            }

            return false;
        }

        /// <summary>
        /// アプリケーション終了時のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: アプリケーション終了時のイベントハンドラ。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        private static void ReleasedApplicationEventHandler(
            object sender,
            EventArgs e
        )
        {
            // メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();

            // 従業員ログオフのメッセージを表示
            if (MainForm != null)
            {
                TMsgDisp.Show(
                    MainForm.Owner,
                    emErrorLevel.ERR_LEVEL_INFO,
                    ProGramId,
                    e.ToString(),
                    ErrorStatus,
                    MessageBoxButtons.OK
                );
            }
            else
            {
                ShowDefaultAlert(emErrorLevel.ERR_LEVEL_INFO, e.ToString(), ErrorStatus);
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
        /// <remarks>
        /// <br>Note		: デフォルトのアラートを表示します。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        public static void ShowDefaultAlert(
            emErrorLevel errorLevel, 
            string message, 
            int status
        )
        {
            TMsgDisp.Show(errorLevel, ProGramId, message, status, MessageBoxButtons.OK);
        }

        #endregion  // <お約束/>
    }
}