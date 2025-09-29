//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : Class1 の概要の説明です
// プログラム概要   : アプリケーションのメイン エントリ
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号             作成担当 : FSI菅原　要
// 作 成 日  2012/09/07 修正内容 : 新規作成
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
            //サーバーログイン部品準備
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP);

            ISumSuppStPrintResultDB SumSuppStResultDB = new SumSuppStPrintResultDB();
            Console.ReadLine();
        }
    }
}
