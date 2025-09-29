//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   仕入先マスタDB仲介クラス
//                  :   PMKHN09023G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   21112　久保田　誠
// Date             :   2008.4.24
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
    /// SupplierDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISupplierDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SupplierDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2008.4.24</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSupplierDB
    {
        /// <summary>
        /// SupplierDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        /// </remarks>
        public MediationSupplierDB()
        {

        }

        /// <summary>
        /// ISupplierDBインターフェース取得
        /// </summary>
        /// <returns>ISupplierDBオブジェクト</returns>
        public static ISupplierDB GetSupplierDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISupplierDB)Activator.GetObject(typeof(ISupplierDB),string.Format("{0}/MyAppSupplier",wkStr));
        }
    }
}
