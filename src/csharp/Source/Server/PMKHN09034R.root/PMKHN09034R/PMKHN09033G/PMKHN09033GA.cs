//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   車種名称マスタDB仲介クラス
//                  :   PMKHN09033G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   22008　長内 数馬
// Date             :   2008.06.10
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
    /// ModelNameUDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIModelNameUDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接ModelNameUDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationModelNameUDB
    {
        /// <summary>
        /// ModelNameUDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        public MediationModelNameUDB()
        {

        }

        /// <summary>
        /// IModelNameUDBインターフェース取得
        /// </summary>
        /// <returns>IModelNameUDBオブジェクト</returns>
        public static IModelNameUDB GetModelNameUDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IModelNameUDB)Activator.GetObject(typeof(IModelNameUDB),string.Format("{0}/MyAppModelNameU",wkStr));
        }
    }
}
