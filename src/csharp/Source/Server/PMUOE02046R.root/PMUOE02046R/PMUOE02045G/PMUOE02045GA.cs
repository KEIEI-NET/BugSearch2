using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// PublicationConfOrderWorkDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPublicationConfOrderWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接OrderListWorkDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2007.10.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPublicationConfOrderWorkDB
    {
        /// <summary>
        /// MediationPublicationConfOrderWorkDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public MediationPublicationConfOrderWorkDB()
        {
        }
        /// <summary>
        /// IPublicationConfOrderWorkDBインターフェース取得
        /// </summary>
        /// <returns>IPublicationConfOrderWorkDBオブジェクト</returns>
        public static IPublicationConfOrderWorkDB GetPublicationConfOrderWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPublicationConfOrderWorkDB)Activator.GetObject(typeof(IPublicationConfOrderWorkDB), string.Format("{0}/MyAppPublicationConfOrderWork", wkStr));
        }
    }
}
