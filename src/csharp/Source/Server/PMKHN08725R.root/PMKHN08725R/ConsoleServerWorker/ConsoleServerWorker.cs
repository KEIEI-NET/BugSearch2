using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;

namespace ConsoleServer
{
    /// <summary>
    /// Class1 の概要の説明です。
    /// </summary>
    class ConsoleServerWorker
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            //サーバーログイン部品準備
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP);

            PriceSelectSetWorkDB priceSelectSetWorkDB = new PriceSelectSetWorkDB();
            Console.ReadLine();
        }
    }
}
