using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// PureSettingPmDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPureSettingPmDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接PureSettingPmDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 脇田　靖之</br>
    /// <br>Date       : 2013.02.18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPureSettingPmDB
    {
        /// <summary>
        /// PureSettingPmDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        /// </remarks>
        public MediationPureSettingPmDB()
        {
        }
        /// <summary>
        /// IPureSettingPmDBインターフェース取得
        /// </summary>
        /// <returns>IPureSettingPmDBオブジェクト</returns>
        public static IPureSettingPmDB GetPureSettingPmDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
            
#if DEBUG
    wkStr = "http://localhost:9002";
#endif            

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPureSettingPmDB)Activator.GetObject(typeof(IPureSettingPmDB), string.Format("{0}/MyAppPureSettingPm", wkStr));
        }
    }
}
