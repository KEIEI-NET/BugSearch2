using System;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 電帳DX通知ヘルパークラス
	/// </summary>
	/// <remarks>
	/// <br>Programmer  : 32281 高村　省吾</br>
	/// <br>Date        : 2023.12.20</br>
	/// <br>Update Note :   </br>
	/// </remarks>
	public class EBookLinkSettingsNtcHelper
	{
		/// <summary> プログラムID </summary>
		public static string CT_PGID = "SFMIT01297U";
		/// <summary> 設定ファイル名 </summary>
		public const string CT_FILE_SETTING = "SFMIT01297U_Settings.xml";
		/// <summary> 日付のフォーマット </summary>
		public const string CT_FORMAT_DATE = "YYYYMMDD";
		/// <summary>ポップアップ表示区分 0:表示しない</summary>
		public const Int16 CT_POPUPDSPDIV_NONDSP = 0;
		/// <summary>ポップアップ表示区分 1:表示する</summary>
		public const Int16 CT_POPUPDSPDIV_DSP = 1;
	}

}
