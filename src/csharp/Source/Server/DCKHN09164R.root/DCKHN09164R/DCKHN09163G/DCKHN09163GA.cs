using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// RateDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIRateDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接RateDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 96050  横川　昌令</br>
    /// <br>Date       : 2007.10.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRateDB
    {
        /// <summary>
        /// RateDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        /// </remarks>
        public MediationRateDB()
        {
        }
        /// <summary>
        /// IRateDBインターフェース取得
        /// </summary>
        /// <returns>IRateDBオブジェクト</returns>
        public static IRateDB GetRateDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IRateDB)Activator.GetObject(typeof(IRateDB), string.Format("{0}/MyAppRate", wkStr));
        }
    }
}
