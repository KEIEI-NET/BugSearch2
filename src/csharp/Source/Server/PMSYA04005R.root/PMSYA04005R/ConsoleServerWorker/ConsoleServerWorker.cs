using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace ConsoleServer
{
    /// <summary>
    /// Program の概要の説明です。
    /// </summary>
    class Program
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
            Console.WriteLine("車輌出荷部品表示 - Debug");
#else
            Console.WriteLine("車輌出荷部品表示 - Release");
#endif

            CarShipmentPartsDispDB carShipmentPartsDispDB = new CarShipmentPartsDispDB();
            Console.ReadLine();
        }
    }
}
