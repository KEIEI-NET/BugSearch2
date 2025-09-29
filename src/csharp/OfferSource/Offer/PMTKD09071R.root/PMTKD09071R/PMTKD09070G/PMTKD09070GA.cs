//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   車種名称マスタDB仲介クラス
//                  :   PMTKD09070G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   30290
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
    /// ModelNameDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIModelNameDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接ModelNameDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationModelNameDB
    {
        /// <summary>
        /// ModelNameDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        public MediationModelNameDB()
        {

        }

        /// <summary>
        /// IModelNameDBインターフェース取得
        /// </summary>
        /// <returns>IModelNameDBオブジェクト</returns>
        public static IModelNameDB GetModelNameDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "http://localhost:9002";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IModelNameDB)Activator.GetObject(typeof(IModelNameDB), string.Format("{0}/MyAppModelName", wkStr));
        }
    }
}
