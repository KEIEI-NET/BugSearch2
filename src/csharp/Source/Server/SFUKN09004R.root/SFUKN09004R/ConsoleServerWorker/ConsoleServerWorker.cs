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
    class Class1
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            Console.WriteLine("ServerLoginInfoAcquisition calling");
            if (!ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP))
            {
                Console.WriteLine("ServerLoginInfoAcquisition.Initialize エラー");
            }
            CompanyInfDB companyInfDB = new CompanyInfDB();
            Console.ReadLine();

            
            
            //RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            //Broadleaf.Application.Common.ServerLoginInfoAcquisition.Initialize(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ProductCode, Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ServerCode_UserAP);
            //CompanyInfDB companyInfDB = new CompanyInfDB();
            //Console.ReadLine();
        }
    }
}
