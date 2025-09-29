//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   車両管理マスタDB仲介クラス
//                  :   PMSYR09010G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   21112　久保田
// Date             :   2008.06.02
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
    /// CarManagementDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICarManagementDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接CarManagementDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 21112　久保田</br>
    /// <br>Date       : 2008.06.02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCarManagementDB
    {
        /// <summary>
        /// CarManagementDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.06.02</br>
        /// </remarks>
        public MediationCarManagementDB()
        {

        }

        /// <summary>
        /// ICarManagementDBインターフェース取得
        /// </summary>
        /// <returns>ICarManagementDBオブジェクト</returns>
        public static ICarManagementDB GetCarManagementDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICarManagementDB)Activator.GetObject(typeof(ICarManagementDB),string.Format("{0}/MyAppCarManagement",wkStr));
        }
    }
}
