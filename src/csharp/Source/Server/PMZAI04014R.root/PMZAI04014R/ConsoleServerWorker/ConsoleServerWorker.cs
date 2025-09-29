using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace ConsoleServerWorker
{
    class ConsoleServerWorker
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP);
            StockAdjRefSearchDB stockAdjRefSearchDB = new StockAdjRefSearchDB();

            Console.WriteLine( "ç›å…édì¸ì`ï[è∆âÔÉäÉÇÅ[Ég DEBUG" );
            Console.ReadLine();
        }
    }
}
