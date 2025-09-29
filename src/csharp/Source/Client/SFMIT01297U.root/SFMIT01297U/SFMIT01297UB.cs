using System;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 電帳DX通知アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note        : 電帳DX通知設定のデータ操作を行います。</br>
	/// <br>Programmer  : 32281 高村 省吾</br>
	/// <br>Date        : 2023.12.20</br>
	/// </remarks>
	public class EBookLinkSettingsNtcSetAcs
	{
		#region Public Methods
		/// <summary>
		/// 電帳DX通知情報読込処理
		/// </summary>
		/// <param name="settingInfo">電帳DX通知情報</param>
		/// <returns>ステータス</returns>
		public int ReadSettingInfo(out EBookLinkSettingsNtcSet settingInfo)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			settingInfo = null;
			// 設定ファイルのフルパス
			string fullPath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, EBookLinkSettingsNtcHelper.CT_FILE_SETTING);
			if (UserSettingController.ExistUserSetting(fullPath))
			{
				try
				{
					// 電帳DX通知情報をデシリアライズする
					settingInfo = UserSettingController.DeserializeUserSetting<EBookLinkSettingsNtcSet>(fullPath);
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
				catch (Exception)
				{
					settingInfo = null;
					
				}
			}
			return status;
		}

		/// <summary>
		/// 通知情報書込処理
		/// </summary>
		/// <param name="settingInfo">電帳DX通知情報</param>
		/// <returns>ステータス</returns>
		public int WriteSettingInfo(ref EBookLinkSettingsNtcSet settingInfo)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			// 設定ファイルのフルパス
			string fullPath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, EBookLinkSettingsNtcHelper.CT_FILE_SETTING);
			try
			{
				//電帳DX通知情報をシリアライズする
				UserSettingController.SerializeUserSetting(settingInfo, fullPath);
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (Exception)
			{
				// なし
			}
			return status;
		}
		#endregion
	}
}
