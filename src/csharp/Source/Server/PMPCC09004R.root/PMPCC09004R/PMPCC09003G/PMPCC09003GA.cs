//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PCC全体設定マスタ取得設定マスタメンテ
// プログラム概要   : PCC全体設定マスタ取得設定マスタメンテDB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葉巧燕
// 作 成 日  2011.08.01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// PccTtlStDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPccTtlStDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接PccTtlStDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 葉巧燕</br>
    /// <br>Date       : 2011.08.01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPccTtlStDB
    {
        /// <summary>
        /// PccTtlStDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public MediationPccTtlStDB()
        {
        }

        /// <summary>
        /// IPccTtlStDBインターフェース取得
        /// </summary>
        /// <returns>IPccTtlStDBオブジェクト</returns>
        public static IPccTtlStDB GetPccTtlStDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPccTtlStDB)Activator.GetObject(typeof(IPccTtlStDB), string.Format("{0}/MyAppPccTtlSt", wkStr));
        }
    }
}
