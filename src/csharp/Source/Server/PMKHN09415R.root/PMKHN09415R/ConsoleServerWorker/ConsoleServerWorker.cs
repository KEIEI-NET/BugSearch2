using System;
using System.Collections.Generic;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;

namespace ConsoleServerWorker
{
    static class ConsoleServerWorker
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            //サーバーログイン部品準備
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP);

            RateQuoteDB _rateQuoteDB = new RateQuoteDB();

            Console.ReadLine();
        }
    }
}