using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// OrderListWorkDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIOrderListWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接OrderListWorkDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2007.10.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSendBeforOrderWorkDB
    {
        /// <summary>
        /// MediationOrderListWorkDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public MediationSendBeforOrderWorkDB()
        {
        }
        /// <summary>
        /// IOrderListWorkDBインターフェース取得
        /// </summary>
        /// <returns>IOrderListWorkDBオブジェクト</returns>
        public static ISendBeforOrdeWorkDB GetSendBeforOrderWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISendBeforOrdeWorkDB)Activator.GetObject(typeof(ISendBeforOrdeWorkDB), string.Format("{0}/MyAppSendBeforOrderWork", wkStr));
        }
    }
}
