//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車検期日の更新
// プログラム概要   : 車検期日を更新します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王海立
// 作 成 日  2010/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace ConsoleServerWorker
{
    /// <summary>
    /// 車検期日更新処理
    /// </summary>
    /// <remarks>
    /// Note       : 車検期日更新処理です。<br />
    /// Programmer : 王海立<br />
    /// Date       : 2010/04/21<br />
    /// </remarks>
    class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            InspectDateUpdDB inspectDateUpdDB = new InspectDateUpdDB();
            if (!ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP))
            {
                // WriteErrorLog(this.ServiceName, "OnStart", "サーバーログイン部品準備の準備に失敗しました。サーバー環境が正しいかどうか確認してください。", null, -8);
            }
            Console.ReadLine();
        }
    }
}
