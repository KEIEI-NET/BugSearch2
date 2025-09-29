//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PCC品目グループマスタメンテ
// プログラム概要   : PCC品目グループマスタメンテDB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011.07.20  修正内容 : 新規作成
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
    /// PccItemGrpDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPccItemGrpDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接PccItemGrpDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date       : 2011.07.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPccItemGrpDB
    {
        /// <summary>
        /// PccItemGrpDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public MediationPccItemGrpDB()
        {
        }

		/// <summary>
        /// IPccItemGrpDBインターフェース取得
		/// </summary>
        /// <returns>IPccItemGrpDBオブジェクト</returns>
        public static IPccItemGrpDB GetPccItemGrpDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);
#if DEBUG
            wkStr = "http://localhost:9002";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPccItemGrpDB)Activator.GetObject(typeof(IPccItemGrpDB), string.Format("{0}/MyAppPccItemGrp", wkStr));
        }
    }
}
