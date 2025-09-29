//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上不整合確認表
// プログラム概要   : 売上不整合確認表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 売上不整合確認表DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISalesStockInfoTableDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SalesStockInfoTableDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.04.10</br>
    /// </remarks>
    public class MediationSalesStockInfoTableDB
    {
        /// <summary>
        /// SalesStockInfoTableDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.10</br>
        /// </remarks>
        public MediationSalesStockInfoTableDB()
        {
        }
        /// <summary>
        /// IPrtmanageDBインターフェース取得
        /// </summary>
        /// <returns>IPrtmanageDBオブジェクト</returns>
        public static ISalesStockInfoTableDB GetSalesStockInfoTableDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            //
#if DEBUG
            wkStr = "http://localhost:8009";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISalesStockInfoTableDB)Activator.GetObject(typeof(ISalesStockInfoTableDB), string.Format("{0}/MyAppSalesStockInfoTable", wkStr));
        }
    }

}
