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
	/// Program の概要の説明です。
	/// </summary>
    class Program
    {
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,false);
			FPprSchmGrDB fPprSchmGrDB = new FPprSchmGrDB();
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_OfferAP);
            //if (!ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_OfferAP))
            //{
            //    Console.WriteLine("サーバーログイン部品準備の準備に失敗しました。サーバー環境が正しいかどうか確認してください。");
            //}
			Console.ReadLine();
		}
    }
}
