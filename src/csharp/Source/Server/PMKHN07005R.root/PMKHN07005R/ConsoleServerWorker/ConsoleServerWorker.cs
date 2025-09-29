using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using System.Runtime.Remoting;

namespace ConsoleServerWorker
{
    class ConsoleServerWorker
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP);
            UseMastDB ro = new UseMastDB();
            Console.ReadLine();
        }
    }
}
