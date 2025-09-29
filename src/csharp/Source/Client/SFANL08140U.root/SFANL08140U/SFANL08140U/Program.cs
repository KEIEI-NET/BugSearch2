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
		private static string[] _parameter;
		private static FPprSearchGuide _form = null;

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
        /// <param name="args"></param>
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
					_form = new FPprSearchGuide();

					System.Windows.Forms.Application.Run(_form);
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
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		private static void ApplicationReleased(object sender, EventArgs e)
		{
			//メッセージを出す前に全て開放
			ApplicationStartControl.EndApplication();
			//自由帳票ガイドログオフのメッセージを表示
			if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "Sample", e.ToString(), 0, MessageBoxButtons.OK);
			else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "Sample", e.ToString(), 0, MessageBoxButtons.OK);
			//アプリケーション終了
			System.Windows.Forms.Application.Exit();
		}

    }
}