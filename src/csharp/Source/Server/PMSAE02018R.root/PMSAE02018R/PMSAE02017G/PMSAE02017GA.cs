//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : S&E売上データテキスト
// プログラム概要   : S&E売上データテキスト帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/08/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SalesHistoryJoinWorkDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISalesHistoryJoinWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SalesHistoryJoinWorkDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.08.14</br>
    /// <br></br>
    /// </remarks>
    public class MediationSalesHistoryJoinResultDB
    {
        /// <summary>
        /// SalesHistoryJoinWorkDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.14</br>
        /// </remarks>
        public MediationSalesHistoryJoinResultDB()
        {
        }
        /// <summary>
        /// IPrtmanageDBインターフェース取得
        /// </summary>
        /// <returns>IPrtmanageDBオブジェクト</returns>
        public static ISalesHistoryJoinWorkDB GetSalesHistoryJoinWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            
            // デバッグ用
#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISalesHistoryJoinWorkDB)Activator.GetObject(typeof(ISalesHistoryJoinWorkDB), string.Format("{0}/MyAppSalesHistoryJoin", wkStr));
        }
    }
}
