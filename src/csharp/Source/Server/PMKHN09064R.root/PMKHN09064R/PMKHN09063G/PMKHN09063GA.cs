//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   BLグループマスタDB仲介クラス
//                  :   PMKHN09063G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   22008 長内 数馬
// Date             :   2008.06.05
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// BLGroupUDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIBLGroupUDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接BLGroupUDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.06.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationBLGroupUDB
    {
        /// <summary>
        /// BLGroupUDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        /// </remarks>
        public MediationBLGroupUDB()
        {

        }

        /// <summary>
        /// IBLGroupUDBインターフェース取得
        /// </summary>
        /// <returns>IBLGroupUDBオブジェクト</returns>
        public static IBLGroupUDB GetBLGroupUDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IBLGroupUDB)Activator.GetObject(typeof(IBLGroupUDB),string.Format("{0}/MyAppBLGroupU",wkStr));
        }
    }
}
