using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;

using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace ConsoleServer
{
    /// <summary>
    /// ConsoleServerWorkerの説明です
    /// </summary>
    public class ConsoleServerWorker
    {
        /// <summary>
        /// アプリケーションのメインエントリポイント
        /// </summary>
        /// <param name="args">実行時の引数</param>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
                // サーバログイン部品準備
                ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP);
                SectionConvertDB work = new SectionConvertDB();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
