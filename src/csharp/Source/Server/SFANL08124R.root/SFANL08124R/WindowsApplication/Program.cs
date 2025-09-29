using System;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace WindowsApplication
{
	static class Program
	{
		private static string[] _parameter;
		private static Form _form = null;

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

				// アプリケーション開始準備処理
				// 第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は指定
				// できない場合はプロダクトコード
				int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
				if (status == 0)
				{
					_form = new Form1();

					Application.Run(_form);
				}
				if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "Sample", msg, 0, MessageBoxButtons.OK);
			}
			catch (Exception ex)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "Sample", ex.Message, 0, MessageBoxButtons.OK);
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
			if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "Sample", e.ToString(), 0, MessageBoxButtons.OK);
			else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "Sample", e.ToString(), 0, MessageBoxButtons.OK);
			//アプリケーション終了
			Application.Exit();
		}
	}
}