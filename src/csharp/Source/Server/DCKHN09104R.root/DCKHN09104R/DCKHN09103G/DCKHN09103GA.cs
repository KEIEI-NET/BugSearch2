using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// RateProtyMngDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIRateProtyMngDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			 完全スタンドアロンにする場合にはこのクラスで直接RateProtyMngDBを</br>
    /// <br>			 インスタンス化して戻します。</br>
    /// <br>Programmer : 20081　疋田　勇人</br>
    /// <br>Date       : 2007.09.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRateProtyMngDB
    {
        /// <summary>
        /// RateProtyMngDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
        /// </remarks>
        public MediationRateProtyMngDB()
        {
        }
        /// <summary>
        /// IRateProtyMngDBインターフェース取得
        /// </summary>
        /// <returns>IRateProtyMngDBオブジェクト</returns>
        public static IRateProtyMngDB GetRateProtyMngDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IRateProtyMngDB)Activator.GetObject(typeof(IRateProtyMngDB), string.Format("{0}/MyAppRateProtyMng", wkStr));
        }
    }
}
