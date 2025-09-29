//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   優良設定マスタ（ユーザー登録分）DB仲介クラス
//                  :   PMKEN09031G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   20081 疋田 勇人
// Date             :   2008.06.11
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
    /// PrmSettingUDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPrmSettingUDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接PrmSettingUDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.06.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPrmSettingUDB
    {
        /// <summary>
        /// PrmSettingUDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        public MediationPrmSettingUDB()
        {

        }

        /// <summary>
        /// IPrmSettingUDBインターフェース取得
        /// </summary>
        /// <returns>IPrmSettingUDBオブジェクト</returns>
        public static IPrmSettingUDB GetPrmSettingUDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPrmSettingUDB)Activator.GetObject(typeof(IPrmSettingUDB),string.Format("{0}/MyAppPrmSettingU",wkStr));
        }
    }
}
