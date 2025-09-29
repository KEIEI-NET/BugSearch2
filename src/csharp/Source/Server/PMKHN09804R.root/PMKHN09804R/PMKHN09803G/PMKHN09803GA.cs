using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 初期取得マスタリモート仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIInitialSearchDBクラスオブジェクトを戻します。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2010/04/22</br>
    /// </remarks>
    public class MediationVariousMasterSearchDB
    {
        /// <summary>
        /// InitialSearchDB仲介クラスコンストラクタ
        /// </summary>
        public MediationVariousMasterSearchDB()
        {
        }

        /// <summary>
        /// IInitialSearchDBインターフェース取得
        /// </summary>
        /// <returns>IInitialSearchDBオブジェクト</returns>
        public static IVariousMasterSearchDB GetRemoteObject()
        {
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "HTTP://localhost:9001";
#endif
            return (IVariousMasterSearchDB)Activator.GetObject(typeof(IVariousMasterSearchDB), string.Format("{0}/MyAppVariousMasterSearch", wkStr));
        }
    }
}
