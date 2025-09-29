using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using Broadleaf.Application.Remoting;

namespace ConsoleApplicationWorker
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            Broadleaf.Application.Common.ServerLoginInfoAcquisition.Initialize(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ProductCode, Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ServerCode_UserAP);
            SingleGoodsRateDB singleGoodsRateDB = new SingleGoodsRateDB();
            Console.ReadLine();
        }
    }
}