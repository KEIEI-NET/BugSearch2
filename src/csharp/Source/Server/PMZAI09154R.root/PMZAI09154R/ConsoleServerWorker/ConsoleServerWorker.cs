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
    /// ConsoleServerWorker の概要の説明です。
    /// </summary>
    public class ConsoleServerWorker
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

#if DEBUG
            Console.WriteLine("在庫履歴現在庫数設定 - Debug");
#else
            Console.WriteLine("在庫履歴現在庫数設定 - Release");
#endif

            StockHistoryUpdateDB stockHistoryUpdateDB = new StockHistoryUpdateDB();
            Console.ReadLine();
        }
    }
}
