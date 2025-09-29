using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;

namespace ConsoleServer
{
    /// <summary>
    /// Class2 の概要の説明です。
    /// </summary>
    public class Class2
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
            Console.WriteLine("手形データマスタ - Debug ");
#else
            Console.WriteLine("手形データマスタ - Release ");
#endif

            PayDraftDataDB _payDraftDataDB = new PayDraftDataDB();

            Console.ReadLine();
        }
    }
}
