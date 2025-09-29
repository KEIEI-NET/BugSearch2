using System;
using System.Windows.Forms;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	static class Program
	{
		#region PrivateStaticMember
		// メインフレームフォーム
		private static Form _form = null;
		#endregion

		#region InternalStaticMember
		// プログラムID
		internal static string ctASSEMBLY_ID = "SFANL08170U";
		#endregion

		#region Main
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				// ログインチェック
				string msg = "";

				// アプリケーション開始(終了イベント登録）
				int status = ApplicationStartControl.StartApplication(out msg, ref args, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
				if (status == 0)
				{
					// オンライン状態判断
					if (!LoginInfoAcquisition.OnlineFlag)
					{
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, ctASSEMBLY_ID,
							"オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
					}
					else
					{
						_form = new SFANL08170UA();

						System.Windows.Forms.Application.EnableVisualStyles();
						System.Windows.Forms.Application.Run(_form);
					}
				}
				else
				{
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, ctASSEMBLY_ID, msg, 0, MessageBoxButtons.OK);
				}
			}
			catch (Exception ex)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ctASSEMBLY_ID, ex.Message, 0, MessageBoxButtons.OK);
			}
			finally
			{
				ApplicationStartControl.EndApplication();
			}
		}
		#endregion

		#region StaticEvent
		/// <summary>
		/// アプリケーション終了イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e">メッセージ</param>
		private static void ApplicationReleased(object sender, EventArgs e)
		{
			//メッセージを出す前に全て開放
			ApplicationStartControl.EndApplication();
			//従業員ログオフのメッセージを表示
			if (_form != null)
				TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, ctASSEMBLY_ID, e.ToString(), 0, MessageBoxButtons.OK);
			else
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, ctASSEMBLY_ID, e.ToString(), 0, MessageBoxButtons.OK);
			//アプリケーション終了
			System.Windows.Forms.Application.Exit();
		}
		#endregion
	}
}