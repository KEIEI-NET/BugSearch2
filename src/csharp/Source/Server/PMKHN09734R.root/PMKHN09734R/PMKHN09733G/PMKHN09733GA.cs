//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ロールグループ権限設定マスタ                    //
//                      DB仲介クラス                                    //
//                  :   PMKHN09733G.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting.Adapter          //
// Programmer       :   30746 高川 悟                                   //
// Date             :   2013/02/18                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// RoleGroupAuthDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIRoleGroupAuthDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接RoleGroupAuthDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 30746 高川 悟</br>
    /// <br>Date       : 2013/02/18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRoleGroupAuthDB
    {
        /// <summary>
        /// RoleGroupAuthDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public MediationRoleGroupAuthDB()
        {
        }

        /// <summary>
        /// IRoleGroupAuthDBインターフェース取得
        /// </summary>
        /// <returns>IRoleGroupAuthDBオブジェクト</returns>
        public static IRoleGroupAuthDB GetRoleGroupAuthDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IRoleGroupAuthDB)Activator.GetObject(typeof(IRoleGroupAuthDB), string.Format("{0}/MyAppRoleGroupAuth", wkStr));
        }
    }
}