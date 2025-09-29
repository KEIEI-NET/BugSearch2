using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Windows.Forms;

namespace MAZAI02050U
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MAZAI02050UA());
		}
	}
}