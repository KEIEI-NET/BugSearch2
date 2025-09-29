//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 決済手形消込処理
// プログラム概要   : オプションフラグ（手形）が「あり」の場合に満期日が過ぎた手形データに対してデータの消し込み処理を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張義
// 作 成 日  2010/04/22  修正内容 : 新規作成
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
    /// 決済手形消込処理
    /// </summary>
    /// <remarks>
    /// Note       : 決済手形消込処理です。<br />
    /// Programmer : 張義<br />
    /// Date       : 2010/04/22<br />
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
            SettlementBillDelDB settlementBillDelDB = new SettlementBillDelDB();
            if (!ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP))
            {
                // WriteErrorLog(this.ServiceName, "OnStart", "サーバーログイン部品準備の準備に失敗しました。サーバー環境が正しいかどうか確認してください。", null, -8);
            }
            Console.ReadLine();
        }
    }
}
