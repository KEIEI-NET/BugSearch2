using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Windows.Forms;

namespace PMUOE02040U
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
			Application.Run(new PMUOE02040UA());
		}
	}
}