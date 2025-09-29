﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	static class Program
	{
		private static string[] _parameter;						// 起動パラメータ
		private static Form _form = null;

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
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
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "DCKOU04100U",
							"オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
					}
					else
					{
						_form = new DCKOU04100UA();
						System.Windows.Forms.Application.Run(_form);
					}
				}
				else
				{
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "DCKOU04100U", msg, 0, MessageBoxButtons.OK);
				}
			}
			finally
			{
				ApplicationStartControl.EndApplication();
			}
			/*
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MAKON01100UA());
			 */
		}

		/// <summary>
		/// アプリケーション終了イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private static void ApplicationReleased(object sender, EventArgs e)
		{
			// メッセージを出す前に全て開放
			ApplicationStartControl.EndApplication();

			// 従業員ログオフのメッセージを表示
			if (_form != null)
			{
				TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "DCKOU04100U", e.ToString(), 0, MessageBoxButtons.OK);
			}
			else
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "DCKOU04100U", e.ToString(), 0, MessageBoxButtons.OK);
			}

			// アプリケーション終了
			System.Windows.Forms.Application.Exit();
		}
	}
}