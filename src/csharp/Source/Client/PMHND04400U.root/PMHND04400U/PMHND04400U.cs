//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル循環棚卸照会
// プログラム概要   : ハンディターミナル循環棚卸照会の検索を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ハンディターミナル循環棚卸照会アプリケーションメインクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル循環棚卸照会アプリケーションメインの定義と実装を行うクラス。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/08/16</br>
    /// </remarks>
    static class Program
    {
        private static Form PMHND04401Form = null;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// <param name="args">起動パラメータ</param>
        /// <remarks>
        /// <br>Note       : ハンディターミナル循環棚卸照会を起動するメイン関数を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        [STAThread]
        static void Main(String[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
             
            try
            {
                string msg = "";

                // アプリケーション開始準備処理
                // 第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                int status = ApplicationStartControl.StartApplication(
                    out msg, ref args, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

                if (status == 0)
                {
                    // オンライン状態判断
                    if (!LoginInfoAcquisition.OnlineFlag)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHND04400U",
                            "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        PMHND04401Form = new PMHND04401UA();
                        System.Windows.Forms.Application.Run(PMHND04401Form);
                    }
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMHND04400U", msg, 0, MessageBoxButtons.OK);
                }
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
        /// <remarks>
        /// <br>Note       : ハンディターミナル循環棚卸照会が終了させられる際に呼び出されるイベントハンドラを行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            // メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();

            // 従業員ログオフのメッセージを表示
            if (PMHND04401Form != null)
            {
                TMsgDisp.Show(PMHND04401Form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMHND04400U", e.ToString(), 0, MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMHND04400U", e.ToString(), 0, MessageBoxButtons.OK);
            }

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}