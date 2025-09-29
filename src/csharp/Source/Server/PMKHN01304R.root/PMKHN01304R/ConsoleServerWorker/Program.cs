//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入先変換ツール
// プログラム概要   : 商品管理情報マスタの最適化の為、不要なレコードを削除する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/07/13  修正内容 : 新規作成
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
    /// 仕入先変換処理
    /// </summary>
    /// <remarks>
    /// Note       : 仕入先変換処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2009/07/13<br />
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
            SupplierChangeProcDB supplierChangeProcDB = new SupplierChangeProcDB();
            if (!ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP))
            {
                // WriteErrorLog(this.ServiceName, "OnStart", "サーバーログイン部品準備の準備に失敗しました。サーバー環境が正しいかどうか確認してください。", null, -8);
            }
            Console.ReadLine();
        }
    }
}
