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
		//================================================================================
		//  静的メンバ
		//================================================================================
		#region Private Static Members
		internal static string[] _parameter;														// 起動パラメータ
		internal static System.Windows.Forms.Form _form = null;					// 起動フォーム
        internal static int _mode;          // 起動コマンドライン引数  // ADD 王君 2013/05/02 Redmine#35434
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				string msg = "";
				_parameter = args;
                // -------ADD 王君 2013/05/02 Redmine#35434 ----------->>>>>
                if (_parameter.Length >= 3)
                {
                    _mode = Convert.ToInt16(_parameter[2].Trim());
                }
                // ------- ADD 王君 2013/05/02 Redmine#35434 -----------<<<<<
				//アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。出来ない場合はプロダクトコード
				int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
				if (status == 0)
				{
					// オンライン状態判定
					if (!Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag)
					{
						// オフライン情報
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "MAKHN04100U",
							"オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
					}
					else
					{
						System.Windows.Forms.Application.EnableVisualStyles();
						System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
						//_form = new MAKHN04100UA(); // DEL　王君 2013/05/02 Redmine#35434
                        _form = new MAKHN04100UA(_mode); // ADD 王君　2013/05/02 Redmine#35434
						System.Windows.Forms.Application.Run(_form);
					}
				}
				if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "MAKHN04100U", msg, 0, MessageBoxButtons.OK);
			}
			catch (Exception ex)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "MAKHN04100U", ex.Message, 0, MessageBoxButtons.OK);
			}
			finally
			{
				ApplicationStartControl.EndApplication();
			}
		}

		//================================================================================
		//  イベント
		//================================================================================
		#region Event
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
			if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "MAKHN04100U", e.ToString(), 0, MessageBoxButtons.OK);
			else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "MAKHN04100U", e.ToString(), 0, MessageBoxButtons.OK);
			//アプリケーション終了
			System.Windows.Forms.Application.Exit();
		}
		#endregion

	}
}