using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ＢＬグループマスタ(提供)更新DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIBlGroupDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接BLGroupDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.13</br>
    /// </remarks>
    public class MediationBLGroupDB
    {
        /// <summary>
        /// BLGroupDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.13</br>
        /// </remarks>
        public MediationBLGroupDB()
        {
        }

        /// <summary>
        /// IBlGroupDBインターフェース取得
        /// </summary>
        /// <returns>IBlGroupDBオブジェクト</returns>
        public static IBlGroupDB GetBLGroupDB()
        {
            //提供データアプリケーションサーバーのPathを取得
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IBlGroupDB)Activator.GetObject(typeof(IBlGroupDB), string.Format("{0}/MyAppBLGroup", wkStr));
        }
    }
}
