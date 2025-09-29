using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace ConsoleApplicationWork
{
    class ConsoleApplicationWork
    {
        [STAThread]
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            Console.WriteLine("ServerLoginInfoAcquisition calling");
            if (!ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP))
            {
                Console.WriteLine("ServerLoginInfoAcquisition.Initialize ÉGÉâÅ[");
            }

            SalesSliptextResultDB salesSliptextResultDB = new SalesSliptextResultDB();
            Console.ReadLine();
        }
    }
}
