using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace ConsoleServer
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
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,false);

            //サーバーログイン部品準備
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            Console.WriteLine("優良設定マスタ（ユーザー登録分） - Debug");
#else
            Console.WriteLine("優良設定マスタ（ユーザー登録分） - Release");
#endif

            PrmSettingUDB PrmSettingUDB = new PrmSettingUDB();
			Console.ReadLine();
		}
	}
}
