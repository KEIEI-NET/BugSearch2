//********************************************************************//
// System           :   PM.NS                                         //
// Sub System       :                                                 //
// Program name     :   売上連携設定DB仲介クラス                      //
//                  :   PMSCM09073G.DLL                               //
// Name Space       :   Broadleaf.Application.Remoting.Adapter        //
// Programmer       :   gaoy                                          //
// Date             :   2011.07.23                                    //
//--------------------------------------------------------------------//
// Update Note      :                                                 //
//--------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.               //
//********************************************************************//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// PM7RkSettingDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPM7RkSettingDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接PM7RkSettingDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : gaoy</br>
    /// <br>Date       : 2011.07.25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPM7RkSettingDB
    {
        /// <summary>
        /// BackUpExecutionDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 自動生成</br>
        /// <br>Date       : 2011.06.22</br>
        /// </remarks>
        public MediationPM7RkSettingDB()
        {
        }

		/// <summary>
        /// IPM7RkSettingDBインターフェース取得
		/// </summary>
        /// <returns>IPM7RkSettingDBオブジェクト</returns>
        public static IPM7RkSettingDB GetPM7RkSettingDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPM7RkSettingDB)Activator.GetObject(typeof(IPM7RkSettingDB), string.Format("{0}/MyAppPM7RkSetting", wkStr));
        }
    }
}
