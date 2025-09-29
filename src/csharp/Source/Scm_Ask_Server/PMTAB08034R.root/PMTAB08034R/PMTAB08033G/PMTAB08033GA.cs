//**********************************************************************
// System           : PM.NS
// Sub System       :
// Program name     : PMTAB汎用検索結果セッション管理トランザクションデータ RemoteObject仲介クラス
//                  : PMTAB08033G.DLL
// Name Space       : Broadleaf.Application.Remoting
// Programmer       : 30746 高川 悟
// Date             : 2014/09/26
//----------------------------------------------------------------------
//                  (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// PmtGeneralSrRstDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPmtGeneralSrRstDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接PmtGeneralSrRstDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 30746 高川 悟</br>
    /// <br>Date       : 2014/09/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPmtGeneralSrRstDB
    {
        /// <summary>
        /// PmtGeneralSrRstDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2014/09/26</br>  
        /// </remarks>
        public MediationPmtGeneralSrRstDB()
        {
        }
        /// <summary>
        /// IPmtGeneralSrRstDBインターフェース取得
        /// </summary>
        /// <returns>IPmtGeneralSrRstDBオブジェクト</returns>
        public static IPmtGeneralSrRstDB GetPmtGeneralSrRstDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);

#if DEBUG
            wkStr = "http://localhost:9014";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPmtGeneralSrRstDB)Activator.GetObject(typeof(IPmtGeneralSrRstDB), string.Format("{0}/MyAppPmtGeneralSrRst", wkStr));
        }
    }
}
