using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SCM受発注 DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIGetPMEmployeeDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接GetPMEmployeeDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 22011 Kashihara</br>
    /// <br>Date       : 2013.06.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationGetPMEmployeeDB
    {
        /// <summary>
        /// GetPMEmployeeDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22011 Kashihara</br>
        /// <br>Date       : 2013.06.06</br>
        /// </remarks>
        public MediationGetPMEmployeeDB()
        {
        }

        /// <summary>
        /// IPMEmployeeDBインターフェース取得
        /// </summary>
        /// <returns>IPMEmployeeDBオブジェクト</returns>
        public static IPMEmployeeDB GetPMEmployeeDB()
        {
            // USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);
#if DEBUG
            wkStr = "http://localhost:8009";            
#endif
            // AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPMEmployeeDB)Activator.GetObject(typeof(IPMEmployeeDB), string.Format("{0}/MyAppPMEmployee", wkStr));
        }

    }
}
