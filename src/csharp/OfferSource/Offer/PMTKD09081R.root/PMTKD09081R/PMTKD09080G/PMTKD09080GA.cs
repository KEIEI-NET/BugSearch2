using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 部位マスタ（提供）DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPartsPosCodeDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで部位マスタDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPartsPosCodeDB
    {
        /// <summary>
        /// PartsPosCodeDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        public MediationPartsPosCodeDB()
        {
        }
        /// <summary>
        /// IPartsPosCodeDBインターフェース取得
        /// </summary>
        /// <returns>IPartsPosCodeDBオブジェクト</returns>
        public static IPartsPosCodeDB GetPartsPosCodeDB()
        {
            //提供データアプリケーションサーバーのPathを取得
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPartsPosCodeDB)Activator.GetObject(typeof(IPartsPosCodeDB), string.Format("{0}/MyAppPartsPosCode", wkStr));
        }
    }
}
