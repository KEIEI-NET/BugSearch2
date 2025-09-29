//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : UOE接続先情報マスタメンテナンス
// プログラム概要   : UOE接続先情報マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : caowj
// 作 成 日  2010/07/26  修正内容 : 新規作成
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
    /// UOEConnectInfoDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIUOEConnectInfoDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接UOEConnectInfoDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : caowj</br>
    /// <br>Date       : 2010/07/26</br>
    /// <br></br>
    /// </remarks>
    public class MediationUOEConnectInfoDB
    {
        /// <summary>
        /// UOEConnectInfoDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        public MediationUOEConnectInfoDB()
        {
        }
        /// <summary>
        /// IUOEConnectInfoDBインターフェース取得
        /// </summary>
        /// <returns>IUOEConnectInfoDBオブジェクト</returns>
        public static IUOEConnectInfoDB GetUOEConnectInfoDB()
        {
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            #if DEBUG
            wkStr = "http://localhost:8009";
            #endif
            return (IUOEConnectInfoDB)Activator.GetObject(typeof(IUOEConnectInfoDB), string.Format("{0}/MyAppUOEConnectInfo", wkStr));
        }
    }
}
