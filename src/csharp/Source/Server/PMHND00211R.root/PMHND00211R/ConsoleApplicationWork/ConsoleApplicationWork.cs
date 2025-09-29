using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace ConsoleApplicationWork
{
    /// <summary>
    /// ConsoleApplicationWork の概要の説明です。
    /// </summary>
    class ConsoleApplicationWork
    {
       /// <summary>
       /// アプリケーションのメイン エントリ ポイントです。
       /// </summary>
       [STAThread]
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            //サーバーログイン部品準備
            Broadleaf.Application.Common.ServerLoginInfoAcquisition.Initialize(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ProductCode, Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ServerCode_UserAP);
            Console.ReadLine();
        }
    }
}
