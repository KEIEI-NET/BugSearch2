//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE 自社設定マスタDB仲介クラス
//                  :   PMUOE09043G.DLL
// Name Space       :   Broadleaf.Application.Remoting.Adapter
// Programmer       :   20081 疋田 勇人
// Date             :   2008.06.06
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
    /// UOESettingDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIUOESettingDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接UOESettingDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationUOESettingDB
    {
        /// <summary>
        /// UOESettingDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        public MediationUOESettingDB()
        {

        }

        /// <summary>
        /// IUOESettingDBインターフェース取得
        /// </summary>
        /// <returns>IUOESettingDBオブジェクト</returns>
        public static IUOESettingDB GetUOESettingDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IUOESettingDB)Activator.GetObject(typeof(IUOESettingDB),string.Format("{0}/MyAppUOESetting",wkStr));
        }
    }
}
