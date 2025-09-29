using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using System.Windows.Forms;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// AutoEstmPtNoChgDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPartsCodeDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接AutoEstmPtNoChgDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 20073　西　毅</br>
    /// <br>Date       : 2012.05.25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationAutoEstmPtNoChgDB
    {
        /// <summary>
        /// AutoEstmPtNoChgDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20073　西　毅</br>
        /// <br>Date       : 2012.05.25</br>
        /// </remarks>
        public MediationAutoEstmPtNoChgDB()
        {
        }
        /// <summary>
        /// IAutoEstmPtNoChgDBインターフェース取得
        /// </summary>
        /// <returns>IAutoEstmPtNoChgDBオブジェクト</returns>
        public static IAutoEstmPtNoChgDB GetAutoEstmPtNoChgDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
            
#if DEBUG
    wkStr = "http://localhost:9012";
#endif            

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
    return (IAutoEstmPtNoChgDB)Activator.GetObject(typeof(IAutoEstmPtNoChgDB), string.Format("{0}/MyAppAutoEstmPtNoChg", wkStr));
        }
    }
}
