using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Broadleaf.Application.Resources;


namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 実行時オプション取得クラス
	/// </summary>
	internal class NsEMailSenderOption
	{
		private static string infoPath = Path.Combine(ConstantManagement_ClientDirectory.Temp_UserTemp, "NsEMailSender.xml");

		/// <summary>
		/// メール送信オプション情報取得
		/// </summary>
		/// <param name="optionInfo">オプション情報</param>
		/// <returns></returns>
		public static bool GetOptionInfo(out NsEMailSenderOptionInfo optionInfo)
		{
			optionInfo = null;

			if (UserSettingController.ExistUserSetting(infoPath))
			{
				try
				{
					optionInfo = UserSettingController.DeserializeUserSetting<NsEMailSenderOptionInfo>(infoPath);
					return true;
				}
				catch
				{
					;
				}
			}

			return false;
		}
	}

	/// <summary>
	/// 実行時オプション情報クラス
	/// </summary>
	/// <remarks>実行時オプションの設定データクラスです</remarks>
	public class NsEMailSenderOptionInfo
	{
		private bool _traceMode = false;
		private bool _traceLog = false;
		private string _traceLogPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), Path.Combine(ConstantManagement_ClientDirectory.Temp_UserTemp, "NsEMailSender_.log"));

		/// <summary>
		/// トレースモードプロパティ
		/// </summary>
		/// <value>True:トレースモードON, False:トレースモードOFF</value>
		public bool TraceMode
		{
			get { return this._traceMode; }
			set { this._traceMode = value; }
		}

		/// <summary>
		/// トレースログプロパティ
		/// </summary>
		/// <value>True:ログ出力する, False:ログ出力しない</value>
		public bool TraceLog
		{
			get { return this._traceLog; }
			set { this._traceLog = value; }
		}

		/// <summary>
		/// トレースログパスプロパティ
		/// </summary>
		/// <value>トレースログの出力パス</value>
		public string TraceLogPath
		{
			get { return this._traceLogPath; }
			set { ; }
		}
	}
}
