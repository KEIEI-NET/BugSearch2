using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using Broadleaf.Application.Remoting;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace ConsoleServerWorker
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
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP);


            FrePStockMoveSlipDB frePStockMoveSlipDB = new FrePStockMoveSlipDB();

# if DEBUG
            Console.WriteLine( " 自由帳票（在庫移動伝票） DEBUG" );
# else
            Console.WriteLine( " 自由帳票（在庫移動伝票） RELEASE" );
# endif
            Console.ReadLine();
		}
	}
}
