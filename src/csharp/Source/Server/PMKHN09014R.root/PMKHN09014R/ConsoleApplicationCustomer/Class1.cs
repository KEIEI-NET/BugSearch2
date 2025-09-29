using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace ConsoleApplicationCar
{
	/// <summary>
	/// Class1 の概要の説明です。
	/// </summary>
	class Class1
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

			//サーバーログイン部品準備
			if (!ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP))
			{
				Console.WriteLine("サーバーログイン部品準備の準備に失敗しました。サーバー環境が正しいかどうか確認してください。");
			}

#if DEBUG
            Console.WriteLine("得意先マスタ リモート - DEBUG -");
#else
            Console.WriteLine("得意先マスタ リモート");
#endif
            CustomerDB customerDB = new CustomerDB();
			Console.ReadLine();
		}
	}
}
