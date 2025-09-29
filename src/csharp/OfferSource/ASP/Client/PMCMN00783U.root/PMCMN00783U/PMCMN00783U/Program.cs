//#define Use_Mutex

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;


namespace Broadleaf.Windows.Forms
{
	static class Program
	{
		internal static string[] MainArgs;

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
#if Use_Mutex
			// Mutexクラスの作成
			using (Mutex mutex = new Mutex(false, "MutexKey_PMCMN00783U"))
			{
				if (mutex.WaitOne(0, false))
				{
#else
			{
				string curProcessName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

				if (System.Diagnostics.Process.GetProcessesByName(curProcessName).Length <= 1)
				{
#endif
					try
					{
						System.Windows.Forms.Application.EnableVisualStyles();
						System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

						MainArgs = args;

						// アプリケーション開始(終了イベント登録）
						string msg = "";
						int status = ApplicationStartControl.StartApplication(out msg, ref args, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
						if (status == 0)
						{
							// オフライン時は終了
							if (!LoginInfoAcquisition.OnlineFlag) return;

							PMCMN00783UA.InitializeApplication();

							if (PMCMN00783UA.IsSuccess)
							{
								System.Windows.Forms.Application.Run(new PMCMN00783UA());
							}
						}
						else
						{
							TMsgDisp.Show(
								emErrorLevel.ERR_LEVEL_NODISP,
								PMCMN00783UA.ctPGID,
								"アプリケーション開始処理[StartApplication]に失敗しました。\r\n" + msg,
								status,
								MessageBoxButtons.OK,
								MessageBoxDefaultButton.Button1);
						}
					}
					catch (Exception ex)
					{
						TMsgDisp.Show(
							emErrorLevel.ERR_LEVEL_NODISP,
							PMCMN00783UA.ctPGID,
							"アプリケーションの実行に失敗しました。",
							0,
							ex,
							MessageBoxButtons.OK,
							MessageBoxDefaultButton.Button1);
					}
#if Use_Mutex
					mutex.ReleaseMutex();
#endif
				}
			}
		}

		/// <summary>
		/// アプリケーション終了イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e">メッセージ</param>
		private static void ApplicationReleased(object sender, EventArgs e)
		{
			// メッセージを出す前に全て開放
			ApplicationStartControl.EndApplication();

			// アプリケーション終了
			System.Windows.Forms.Application.Exit();

			// プロセス終了
			Environment.Exit(0);
		}
	}
}