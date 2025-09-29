using System;
using System.Runtime.Remoting;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace ConsoleServer
{
	class Program
	{
		static void Main(string[] args)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
			FrePrtPSetDB frePrtPSetDB = new FrePrtPSetDB();
			//サーバーログイン部品準備
			if (!ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP))
			{
				Console.WriteLine("サーバーログイン部品準備の準備に失敗しました。サーバー環境が正しいかどうか確認してください。");
			}
# if DEBUG
            Console.WriteLine( "自由帳票印字位置設定 DEBUG" );
# endif
			Console.ReadLine();
		}
	}
}
