using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// PartsLayerStPmDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPartsCodeDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接PartsLayerStPmDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 脇田　靖之</br>
    /// <br>Date       : 2013.02.18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPartsLayerStPmDB
    {
        /// <summary>
        /// PartsLayerStPmDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        /// </remarks>
        public MediationPartsLayerStPmDB()
        {
        }
        /// <summary>
        /// IPartsLayerStPmDBインターフェース取得
        /// </summary>
        /// <returns>IPartsLayerStPmDBオブジェクト</returns>
        public static IPartsLayerStPmDB GetPartsLayerStPmDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
            
#if DEBUG
    wkStr = "http://localhost:9002";
#endif            

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
    return (IPartsLayerStPmDB)Activator.GetObject(typeof(IPartsLayerStPmDB), string.Format("{0}/MyAppPartsLayerStPm", wkStr));
        }
    }
}
