using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using Broadleaf.Application.Remoting;

namespace ConsoleServer
{
    class Class1
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            Broadleaf.Application.Common.ServerLoginInfoAcquisition.Initialize(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ProductCode, Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ServerCode_UserAP);
            SalesProcMoneyDB salesProcMoneyDB = new SalesProcMoneyDB();
            Console.ReadLine();
        }
    }
}
