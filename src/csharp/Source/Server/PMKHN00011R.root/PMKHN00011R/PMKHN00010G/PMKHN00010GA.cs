using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// VersionChkWorkDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : DB,APバージョンを取得します</br>
    /// <br>Programmer : 30350 櫻井 亮太</br>
    /// <br>Date       : 2009.01.23</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationVersionChkWorkDB
    {
        /// <summary>
        /// MediationVersionChkWorkDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2009.01.23</br>
        /// </remarks>
        public MediationVersionChkWorkDB()
        {
        }
        /// <summary>
        /// IVersionChkWorkDBインターフェース取得
        /// </summary>
        /// <returns>IVersionChkWorkDBオブジェクト</returns>
        public static IVersionChkWorkDB GetVersionChkWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IVersionChkWorkDB)Activator.GetObject(typeof(IVersionChkWorkDB), string.Format("{0}/MyAppVersionChkWork", wkStr));
        }
    }
}
