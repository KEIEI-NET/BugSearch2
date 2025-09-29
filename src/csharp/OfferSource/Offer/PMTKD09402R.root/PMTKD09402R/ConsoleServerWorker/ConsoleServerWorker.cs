using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;


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
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            //サーバーログイン部品準備
            Console.WriteLine( "ServerLoginInfoAcquisition calling" );
            if (!ServerLoginInfoAcquisition.Initialize( ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_OfferAP ))
            {
                Console.WriteLine( "ServerLoginInfoAcquisition.Initialize エラー" );
            }

            OfferPrmPartsBrcdInfoDB offerPrmPartsBrcdDB = new OfferPrmPartsBrcdInfoDB();
            Console.ReadLine();
        }
    }
}
