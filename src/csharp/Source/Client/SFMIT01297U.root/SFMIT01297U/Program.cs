using System;
using System.Diagnostics;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
        /// <remarks>
        /// <br>Note		: PM.NS用に修正</br>
        /// <br>Programmer	: 32427 田村顕成</br>
        /// <br>Date		: 2024/01/05</br>
        /// </remarks>
		[STAThread]
		static void Main(string[] args)
		{
			// ポップアップの多重起動防止
			if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length <= 1)
			{
				try
				{
					// ログインチェック
					string msg = "";
					// アプリケーション開始(終了イベント登録）
					int status = ApplicationStartControl.StartApplication(out msg, ref args, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
					if (status == 0)
					{
						if (LoginInfoAcquisition.OnlineFlag)
						{
							// 電子帳簿連携オプションチェック
							//PurchaseStatus purchaseStatus = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_ELECTRONIC_BOOK_LINK);// DEL 2024/01/05 田村顕成
                            PurchaseStatus purchaseStatus = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_EBooks);// ADD 2024/01/05 田村顕成
                            if (purchaseStatus > PurchaseStatus.Uncontract)
							{
								// アプリケーションを終了する
								return;
							}
							else
							{
								//--------------------------------------------------
								// 電子帳簿連携通知の終了日を過ぎていたらアプリケーションを終了する
								//--------------------------------------------------
								// 設定XMLファイルから対象となる地域の情報を取得
								EBookLinkSettingsNtcSetAcs eBookLinkSettingsNtcSetAcs = new EBookLinkSettingsNtcSetAcs();
								EBookLinkSettingsNtcSet settingInfo;
								status = eBookLinkSettingsNtcSetAcs.ReadSettingInfo(out settingInfo);
								if (status != 0)
									return;
								// 終了日を過ぎていた場合
								DateTime notificationDateEd = TDateTime.LongDateToDateTime(EBookLinkSettingsNtcHelper.CT_FORMAT_DATE, settingInfo.NotificationDateEd);
								DateTime today = DateTime.Today;
								if (today.CompareTo(notificationDateEd) > 0)
								{
									// アプリケーションを終了する
									return;
								}

								// カスタムアプリケーション制御の開始
								status = CustomApplicationStartControl.StartApplication(out msg, ref args);
								if (status == 0)
								{
									SFMIT01297UA form = new SFMIT01297UA();

									System.Windows.Forms.Application.EnableVisualStyles();
									System.Windows.Forms.Application.Run(form);
								}
							}
						}
					}
					else
					{
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, EBookLinkSettingsNtcHelper.CT_PGID, msg, 0, MessageBoxButtons.OK);
					}
				}
				catch (Exception ex)
				{
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, EBookLinkSettingsNtcHelper.CT_PGID, ex.Message, 0, MessageBoxButtons.OK);
				}
				finally
				{
					// カスタムアプリケーション制御の終了
					CustomApplicationStartControl.EndApplication();
					ApplicationStartControl.EndApplication();
				}
			}
		}

		/// <summary>
		/// アプリケーション終了イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private static void ApplicationReleased(object sender, EventArgs e)
		{
			// カスタムアプリケーション制御の終了
			CustomApplicationStartControl.EndApplication();
			//メッセージを出す前に全て開放
			ApplicationStartControl.EndApplication();
			//アプリケーション終了
			System.Windows.Forms.Application.Exit();
		}
	}
}