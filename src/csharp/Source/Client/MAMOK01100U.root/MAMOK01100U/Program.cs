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
		// 起動パラメータ
		internal static string[] _param = null;
		// プログラムID
		private static string ctPGID = "MAMOK01100U";
		// フローティング・ウィンドウ定義
        //internal static FloatingWindow _floatingWindow = new FloatingWindow();
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
				// 起動用フローティングウィンドウ(Show)
                //_floatingWindow.Show(null);

				// ログインチェック
				string msg = "";
				_param = args;

				// アプリケーション開始(終了イベント登録）
				int status = ApplicationStartControl.StartApplication(out msg, ref args, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
				if (status == 0)
				{
					// オンライン状態判断
					if (!LoginInfoAcquisition.OnlineFlag)
					{
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, ctPGID,
							"オフライン状態で本機能はご使用できません", 0, MessageBoxButtons.OK);
					}
					else
					{
						_form = new MAMOK01100UA();

						System.Windows.Forms.Application.EnableVisualStyles();
						System.Windows.Forms.Application.Run(_form);
					}
				}
				else
				{
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, ctPGID, msg, 0, MessageBoxButtons.OK);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\b" + ex.StackTrace);
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, ctPGID, ex.Message, 0, MessageBoxButtons.OK);
			}
			finally
			{
				// 起動用フローティングウィンドウ(Close)
                //_floatingWindow.Close();
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
			{
				TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, ctPGID, e.ToString(), 0, MessageBoxButtons.OK);
			}
			else
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, ctPGID, e.ToString(), 0, MessageBoxButtons.OK);
			}
			//アプリケーション終了
			System.Windows.Forms.Application.Exit();
		}
		#endregion
	}
}