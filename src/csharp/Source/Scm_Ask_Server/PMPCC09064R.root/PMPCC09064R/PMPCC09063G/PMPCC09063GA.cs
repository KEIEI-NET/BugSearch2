//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PCCキャンペーン設定マスタメンテ
// プログラム概要   : PCCキャンペーン設定マスタメンテDB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011.08.11  修正内容 : 新規作成
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
    /// PccCpMsgStDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPccCpMsgStDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接PccCpMsgStDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date       : 2011.08.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPccCpMsgStDB
    {
        /// <summary>
        /// PccCpMsgStDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public MediationPccCpMsgStDB()
        {
        }

		/// <summary>
        /// IPccCpMsgStDBインターフェース取得
		/// </summary>
        /// <returns>IPccCpMsgStDBオブジェクト</returns>
        public static IPccCpMsgStDB GetPccCpMsgStDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);
            //dbg start
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //dbg end
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPccCpMsgStDB)Activator.GetObject(typeof(IPccCpMsgStDB), string.Format("{0}/MyAppPccCpMsgSt", wkStr));
        }
    }
}
