using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using Broadleaf.Application.Remoting;

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
            //Broadleaf.Application.Common.ServerLoginInfoAcquisition.Initialize("SuperFrontman", "USER_AP");
            Broadleaf.Application.Common.ServerLoginInfoAcquisition.Initialize(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ProductCode, Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ServerCode_Center_UserAP);
            AWSCommTstRsltDB aWSCommTstRsltDB = new AWSCommTstRsltDB();
            Console.ReadLine();
        }
    }
}
