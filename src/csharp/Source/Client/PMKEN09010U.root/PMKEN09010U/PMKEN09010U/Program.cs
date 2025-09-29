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
		/// <summary>フローティングウィンドウ(SFCMN00025C)</summary>
		//public static Broadleaf.Windows.Forms.FloatingWindow _floatingWindow = new FloatingWindow();  // DEL 2008/07/01
		/// <summary>起動パラメータ</summary>
		public static string[] _param = null;
		/// <summary>起動するフォームクラス</summary>
		private static Form _form;
		/// <summary>プログラムID</summary>
		public const string PGID = "NSKEN90100";

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main(string[] Args)
		{
			try
			{
				// メッセージボックスをXPスタイルに
				System.Windows.Forms.Application.EnableVisualStyles();

				// 起動用フローティングウィンドウ(Show)
				//_floatingWindow.Show(null);  // DEL 2008/07/01

				// ログインチェック
				string msg = "";

				// アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。出来ない場合はプロダクトコード
				//int status = ApplicationStartControl.StartApplication(out msg, ref Args, ConstantManagement_PM.ProductCode, new EventHandler(ApplicationReleased));
                int status = ApplicationStartControl.StartApplication(out msg, ref Args, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

				_param = Args;

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
                        _form = new PMKEN09010UA();
                        System.Windows.Forms.Application.Run(_form);
                        /*
						if (((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput) > 0))
						{
							// アプリケーション開始
							_form = new NSKEN90100UA();
							System.Windows.Forms.Application.Run(_form);
						}
						else
						{
							msg = "未契約ソフトウェアです。";
							TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, PGID, msg, 0, MessageBoxButtons.OK);
							return;
						}
                         * */
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
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PGID, ex.Message, 0, MessageBoxButtons.OK);
			}
			finally
			{
				// 起動用フローティングウィンドウ(Close)
				//_floatingWindow.Close();  // DEL 2008/07/01
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