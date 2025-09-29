using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	static class Program
	{
		/// <summary>起動時スプラッシュウィンドウ(SFCMN00025C)</summary>
		public static Broadleaf.Windows.Forms.FloatingWindow SplashWindow = new FloatingWindow();
		/// <summary>起動パラメータ</summary>
		public static string[] Param = null;
		/// <summary>起動するフォームクラス</summary>
		private static Form _form;
		/// <summary>プログラムID</summary>
        public const string PGID = "MAKAU00120U";

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main(string[] Args)
		{
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

			try
			{
				// ログインチェック
				string msg = "";

				// アプリケーション開始(終了イベント登録）
				int status = ApplicationStartControl.StartApplication(out msg, ref Args, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

				Param = Args;

				if (status == 0)
				{
					if (!Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag)
					{
						msg = "オフライン状態で本機能はご使用できません。";
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, PGID, msg, 0, MessageBoxButtons.OK);
					}
					else
					{
						// アプリケーション開始
						_form = new MAKAU00120UA();
                        if (Param[0] == "1")
                        {
                            // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
                            //_form.Text = "締次更新処理";
                            _form.Text = "売上締次更新";
                            // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<
                        }
						System.Windows.Forms.Application.Run(_form);
					}
				}
				else
				{
					// エラー表示
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PGID, msg, 0, MessageBoxButtons.OK);
				}
			}
			catch (Exception ex)
			{
				// 例外エラー表示
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PGID, ex.Message, 0, ex, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
			finally
			{
				ApplicationStartControl.EndApplication();
			}
		}

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
				TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, PGID, e.ToString(), 0, MessageBoxButtons.OK);
			else
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PGID, e.ToString(), 0, MessageBoxButtons.OK);

			//アプリケーション終了
			System.Windows.Forms.Application.Exit();
		}
	}
}