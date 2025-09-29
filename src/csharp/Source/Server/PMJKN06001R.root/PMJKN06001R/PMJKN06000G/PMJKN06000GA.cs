using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// FreeSearchModelSearch仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIFreeSearchModelSearchクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接FreeSearchModelSearchDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 99033　岩本　勇</br>
    /// <br>Date       : 2005.04.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationFreeSearchModelSearchDB
    {
        /// <summary>
        /// FreeSearchModelSearch仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.02.15</br>
        /// </remarks>
        public MediationFreeSearchModelSearchDB()
        {

        }

        /// <summary>
        /// IFreeSearchModelSearchインターフェース取得
        /// </summary>
        /// <returns>ICarModelSearchオブジェクト</returns>
        public static IFreeSearchModelSearchDB GetRemoteObject()
        {
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "HTTP://localhost:9012";
#endif
            return (IFreeSearchModelSearchDB)Activator.GetObject( typeof( IFreeSearchModelSearchDB ), string.Format( "{0}/MyAppFreeSearchModelSearch", wkStr ) );
        }
    }
}
