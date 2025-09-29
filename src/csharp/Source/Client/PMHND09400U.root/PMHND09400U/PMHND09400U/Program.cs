//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品バーコード更新処理（手動）
// プログラム概要   : 商品バーコード更新処理（手動）エントリポイント実装クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00  作成担当 : 30757 佐々木貴英
// 作 成 日  2017/09/20   修正内容 : ハンディターミナル二次対応（新規作成）
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Text;
namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品バーコード更新処理（手動）メイン エントリ ポイント実装クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品バーコード更新処理（手動）のメイン エントリ ポイントを実装するクラスの定義と実装</br>
    /// <br>Programmer : 30757　佐々木　貴英</br>
    /// <br>Date       : 2017/09/20</br>
    /// </remarks>
    static class Program
    {
        #region メンバーフィールド

        /// <summary>
        /// 起動パラメータ一時保持領域
        /// </summary>
        private static string[] ExecParameter;

        /// <summary>
        ///  商品バーコード更新処理メインUI
        /// </summary>
        private static Form MainForm = null;

        /// <summary>
        /// アセンブリID
        /// </summary>
        private static string AssemblyId;

        #endregion //メンバーフィールド

        /// <summary>
        /// 商品バーコード更新処理（手動）メイン エントリ ポイント
        /// </summary>
        /// <param name="args">起動パラメータ</param>
        /// <remarks>
        /// <br>Note       : 商品バーコード更新処理（手動）の起動時に実行されるメイン エントリ ポイント</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        [STAThread]
        static void Main(String[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            // アセンブリ名をフルパスで取得
            string fullAssemblyName = typeof(Program).Assembly.Location;
            // アセンブリ名のみを取得
            Program.AssemblyId = System.IO.Path.GetFileName( fullAssemblyName );

            try
            {
                string msg = string.Empty;
                Program.ExecParameter = args;

                // アプリケーション開始準備処理
                // 第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                int status = ApplicationStartControl.StartApplication(
                    out msg, ref ExecParameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

                if (status == (int)PMHND09400U.StatusCode.Normal)
                {
                    // オンライン状態判断
                    if (!LoginInfoAcquisition.OnlineFlag)
                    {
                        TMsgDisp.Show( emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.AssemblyId,
                            "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        MainForm = new PMHND09400U();

                        System.Windows.Forms.Application.Run(MainForm);
                    }
                }
                else
                {
                    TMsgDisp.Show( emErrorLevel.ERR_LEVEL_INFO, Program.AssemblyId, msg, 0, MessageBoxButtons.OK );
                }

            }
            catch (Exception ex)
            {
                TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, Program.AssemblyId, ex.Message, 0, MessageBoxButtons.OK );
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// アプリケーション終了イベントハンドラ
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : アプリケーション終了時に発生するイベントハンドラ</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            // メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();

            // 従業員ログオフのメッセージを表示
            if (MainForm != null)
            {
                TMsgDisp.Show( MainForm.Owner, emErrorLevel.ERR_LEVEL_INFO, Program.AssemblyId, e.ToString(), 0, MessageBoxButtons.OK );
            }
            else
            {
                TMsgDisp.Show( emErrorLevel.ERR_LEVEL_INFO, Program.AssemblyId, e.ToString(), 0, MessageBoxButtons.OK );
            }

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

    }
}