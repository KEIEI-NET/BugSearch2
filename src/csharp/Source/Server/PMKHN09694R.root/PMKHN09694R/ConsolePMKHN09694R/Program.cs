using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace ConsolePMKHN09694R
{
    class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP);
            BLGoodsCdChgUDB blCodeChangeDB = new BLGoodsCdChgUDB();
            Console.ReadLine();
        }
    }
}
