//****************************************************************************//
// システム         : 操作履歴表示
// プログラム名称   : 操作履歴表示
// プログラム概要   : セキュリティ管理の操作履歴表示／エラーログ表示のみに限定した参照用ＰＧ
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/02/22  修正内容 : 新規作成
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
    /// 操作履歴表示メインフレームのエントリポイントクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 操作履歴表示・ログ表示を行います。</br>
    /// <br>Programmer   : 22018 鈴木　正臣</br>
    /// <br>Date         : 2010.02.22</br>
    /// <br></br>
    /// </remarks>

    internal static class Program
    {
        #region <Const/>

        /// <summary>プログラムID</summary>
        // --- UPD m.suzuki 2010/02/22 ---------->>>>>
        //private const string PROGRAM_ID = "PMKHN09120";
        private const string PROGRAM_ID = "PMKHN09122";
        // --- UPD m.suzuki 2010/02/22 ----------<<<<<

        /// <summary>正常</summary>
        private const int NORMAL_STATUS = 0;
        /// <summary>異常</summary>
        private const int ERROR_STATUS = -1;    // HACK:ApplicationStartControl.StartApplication() の異常コード

        // --- DEL m.suzuki 2010/02/22 ---------->>>>>
        ///// <summary>管理者を表す値</summary>
        //private const int ADMIN_USER_NO = 1;    // HACK:LoginInfoAcquisition.Employee.UserAdminFlag の管理者フラグ

        ///// <summary>サポートを表す値</summary>
        //private const int SUPPORT_USER_NO = 2;    // HACK:LoginInfoAcquisition.Employee.UserAdminFlag のサポートフラグ
        // --- DEL m.suzuki 2010/02/22 ----------<<<<<

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
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, PROGRAM_ID, msg, status, MessageBoxButtons.OK);
                        return;
                    }
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PROGRAM_ID, msg, status, MessageBoxButtons.OK);
                    return;
                }

                // アプリケーション開始
                _mainFrameForm = new PMKHN09122UA();
                System.Windows.Forms.Application.Run(_mainFrameForm);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n" + ex.ToString() + "\n");
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PROGRAM_ID, ex.Message, ERROR_STATUS, MessageBoxButtons.OK);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// セキュリティエラーがあるか判定します。
        /// </summary>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>true :セキュリティエラーあり<br/>false:セキュリティエラーなし</returns>
        private static bool HasSecurityError(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!LoginInfoAcquisition.OnlineFlag)
            {
                errorMessage = "オフライン状態で本機能はご使用できません。"; // LITERAL:
                return true;
            }

            // --- DEL m.suzuki 2010/02/22 ---------->>>>>
            //// --- CHG 2009/02/26 障害ID:11960対応------------------------------------------------------>>>>>
            ////if (!LoginInfoAcquisition.Employee.UserAdminFlag.Equals(ADMIN_USER_NO))
            //if ((!LoginInfoAcquisition.Employee.UserAdminFlag.Equals(ADMIN_USER_NO)) &&
            //    (!LoginInfoAcquisition.Employee.UserAdminFlag.Equals(SUPPORT_USER_NO)))
            //// --- CHG 2009/02/26 障害ID:11960対応------------------------------------------------------<<<<<
            //{
            //    errorMessage = "本機能は管理者以外は実行できません。" + Environment.NewLine + "終了します。"; // LITERAL:
            //    return true;
            //}
            // --- DEL m.suzuki 2010/02/22 ----------<<<<<

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
                    emErrorLevel.ERR_LEVEL_INFO, PROGRAM_ID,
                    e.ToString(),
                    ERROR_STATUS,
                    MessageBoxButtons.OK
                );
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PROGRAM_ID, e.ToString(), ERROR_STATUS, MessageBoxButtons.OK);
            }

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}