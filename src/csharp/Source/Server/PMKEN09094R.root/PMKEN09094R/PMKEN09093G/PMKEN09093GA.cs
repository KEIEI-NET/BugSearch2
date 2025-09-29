//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   部品代替マスタDB仲介クラス
//                  :   PMKEN09093G.DLL
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
    /// PartsSubstUDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPartsSubstUDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接PartsSubstUDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPartsSubstUDB
    {
        /// <summary>
        /// PartsSubstUDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        public MediationPartsSubstUDB()
        {

        }

        /// <summary>
        /// IPartsSubstUDBインターフェース取得
        /// </summary>
        /// <returns>IPartsSubstUDBオブジェクト</returns>
        public static IPartsSubstUDB GetPartsSubstUDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPartsSubstUDB)Activator.GetObject(typeof(IPartsSubstUDB),string.Format("{0}/MyAppPartsSubstU",wkStr));
        }
    }
}
