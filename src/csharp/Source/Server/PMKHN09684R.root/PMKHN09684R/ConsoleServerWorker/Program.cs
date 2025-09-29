//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタコンバート
// プログラム概要   : 在庫管理全体設定の現在庫表示区分より、出荷可能数を更新する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2011/08/26  修正内容 : 新規作成
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
    /// 在庫マスタコンバート処理
    /// </summary>
    /// <remarks>
    /// Note       : 在庫マスタコンバート処理です。<br />
    /// Programmer : 李占川<br />
    /// Date       : 2011/08/26<br />
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
            //サーバーログイン部品準備
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP);

            StockConvertDB stockConvertDB = new StockConvertDB();

            Console.ReadLine();
        }
    }
}
