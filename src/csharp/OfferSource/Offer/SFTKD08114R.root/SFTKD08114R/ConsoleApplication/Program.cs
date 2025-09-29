using System;
using System.Runtime.Remoting;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace ConsoleApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
			PrtItemSetDB prtItemSetDB = new PrtItemSetDB();
			//サーバーログイン部品準備
			if (!ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_OfferAP))
			{
				Console.WriteLine("サーバーログイン部品準備の準備に失敗しました。サーバー環境が正しいかどうか確認してください。");
			}

			Console.ReadLine();
		}
	}
}
