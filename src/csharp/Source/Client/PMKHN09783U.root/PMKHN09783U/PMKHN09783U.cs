//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メーカーパターン検索履歴照会
// プログラム概要   : メーカーパターン検索履歴照会の検索を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 管理番号  11570249-00 作成担当 : 陳艶丹
// 作 成 日  2020/03/09  修正内容 : 新規作成
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
    /// メーカーパターン検索履歴照会アプリケーションメインクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : メーカーパターン検索履歴照会アプリケーションメインの定義と実装を行うクラス。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2020/03/09</br>
    /// </remarks>
	static class Program
	{
        private static Form PMKHN09783Form = null;

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
        /// <param name="args">起動パラメータ</param>
        /// <remarks>
        /// <br>Note       : メーカーパターン検索履歴照会を起動するメイン関数を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
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
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKHN09783U",
							"オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
					}
					else
					{
                        PMKHN09783Form = new PMKHN09783UB();
                        System.Windows.Forms.Application.Run(PMKHN09783Form);
					}
				}
				else
				{
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMKHN09783U", msg, 0, MessageBoxButtons.OK);
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
        /// <br>Note       : メーカーパターン検索履歴照会が終了させられる際に呼び出されるイベントハンドラを行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
		private static void ApplicationReleased(object sender, EventArgs e)
		{
			// メッセージを出す前に全て開放
			ApplicationStartControl.EndApplication();

			// 従業員ログオフのメッセージを表示
            if (PMKHN09783Form != null)
			{
                TMsgDisp.Show(PMKHN09783Form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMKHN09783U", e.ToString(), 0, MessageBoxButtons.OK);
			}
			else
			{
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMKHN09783U", e.ToString(), 0, MessageBoxButtons.OK);
			}

			// アプリケーション終了
			System.Windows.Forms.Application.Exit();
		}
	}
}