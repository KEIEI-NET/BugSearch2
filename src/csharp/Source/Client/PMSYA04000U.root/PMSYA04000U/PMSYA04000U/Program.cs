//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌出荷部品表示
// プログラム概要   : 車輌出荷部品表示を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/09/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
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
    /// 車輌出荷部品表示 フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車輌出荷部品表示のフォームクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.09.10</br>
    /// </remarks>
    static class Program
    {
        private static string[] _parameter;						// 起動パラメータ
        private static Form _form = null;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// <remarks>
        /// Note       : 車輌出荷部品表示設定処理です。<br />
        /// Programmer : 譚洪<br />
        /// Date       : 2009.09.10<br />
        /// </remarks>
        [STAThread]
        static void Main(String[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                string msg = "";
                _parameter = args;

                // アプリケーション開始準備処理
                // 第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                int status = ApplicationStartControl.StartApplication(
                    out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

                if (status == 0)
                {
                    // オンライン状態判断
                    if (!LoginInfoAcquisition.OnlineFlag)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMSYA04000U",
                            "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        _form = new PMSYA04000UA();
                        System.Windows.Forms.Application.Run(_form);
                    }
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMSYA04000U", msg, 0, MessageBoxButtons.OK);
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
        /// Note       : 車輌出荷部品表示設定処理です。<br />
        /// Programmer : 譚洪<br />
        /// Date       : 2009.09.10<br />
        /// </remarks>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            // メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();

            // 従業員ログオフのメッセージを表示
            if (_form != null)
            {
                TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMSYA04000U", e.ToString(), 0, MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMSYA04000U", e.ToString(), 0, MessageBoxButtons.OK);
            }

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
    }
}