//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PCC自社設定マスタメンテ
// プログラム概要   : PCC自社設定マスタメンテDB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2011.08.04  修正内容 : 新規作成
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
    /// PccCmpnyStDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPccCmpnyStDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接PccCmpnyStDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 自動生成</br>
    /// <br>Date       : 2011.08.04</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPccCmpnyStDB
    {
        /// <summary>
        /// PccCmpnyStDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 自動生成</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public MediationPccCmpnyStDB()
        {
        }

		/// <summary>
        /// IPccCmpnyStDBインターフェース取得
		/// </summary>
        /// <returns>IPccCmpnyStDBオブジェクト</returns>
        public static IPccCmpnyStDB GetPccCmpnyStDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPccCmpnyStDB)Activator.GetObject(typeof(IPccCmpnyStDB), string.Format("{0}/MyAppPccCmpnySt", wkStr));
        }
    }
}
