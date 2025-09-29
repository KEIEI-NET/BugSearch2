//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : Class1 の概要の説明です
// プログラム概要   : アプリケーションのメイン エントリ
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張義
// 作 成 日  2010/05/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//

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
            //サーバーログイン部品準備S
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP);

            ITegataConfirmReportResultDB TegataConfirmReportResultDB = new TegataConfirmReportResultDB();
            Console.ReadLine();
        }
    }
}
