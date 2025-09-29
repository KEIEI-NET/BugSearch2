//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　伝票番号変換エントリポイント
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11470153-00 作成担当 : 倉内
// 修 正 日  2018/09/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 伝票番号変換メインフレームのエントリポイントクラス
    /// </summary>
    static class Program
    {
        #region -- Member --

        /// <summary>起動パラメーター</summary>
        private static string[] parameter;
        /// <summary>フォーム</summary>
        private static Form frm = null;
        /// <summary>プログラムID：PMKHN05150U</summary>
        private const string PG_ID = "PMKHN05150U";

        #endregion

        #region -- Method --

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// <remarks>
        /// ログインチェックを行い、メインフレーム（フォーム）を起動します。
        /// </remarks>
        /// <param name="args">コマンドライン引数</param>
        [STAThread]
        static void Main(String[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                string msg = String.Empty;
                parameter = args;

                // アプリケーション開始準備処理
                int status = ApplicationStartControl.StartApplication(
                    out msg, ref parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased)
                    );

                if (status == 0)
                {
                    // オフライン状態判断
                    if (!LoginInfoAcquisition.OnlineFlag)
                    {

                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, PG_ID,
                            "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        frm = new PMKHN05150UA();
                        System.Windows.Forms.Application.Run(frm);
                    }
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PG_ID, msg, 0, MessageBoxButtons.OK);
                }
            } catch (Exception ex) {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PG_ID, ex.ToString(), 0, MessageBoxButtons.OK);   
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
            // メッセージを出す前にすべてを解放
            ApplicationStartControl.EndApplication();

            // 従業員ログオフのメッセージを表示します
            if (frm != null)
            {
                TMsgDisp.Show(frm.Owner, emErrorLevel.ERR_LEVEL_INFO, PG_ID, e.ToString(), 0, MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PG_ID, e.ToString(), 0, MessageBoxButtons.OK);
            }

            // アプリケーションを終了します。
            System.Windows.Forms.Application.Exit();
        }

        #endregion
    }
}