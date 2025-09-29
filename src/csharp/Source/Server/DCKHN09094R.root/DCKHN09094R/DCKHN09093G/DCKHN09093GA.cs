using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// BLGoodsCdUDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIBLGoodsCdUDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接BLGoodsCdUDBを</br>
    /// <br>			       インスタンス化して戻します。</br>
    /// <br>Programmer : 22008　長内　数馬</br>
    /// <br>Date       : 2007.08.17</br>
    /// </remarks>
    public class MediationBLGoodsCdUDB
    {
        /// <summary>
        /// BLGoodsCdUDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
        /// </remarks>
        public MediationBLGoodsCdUDB()
        {
        }
        /// <summary>
        /// IPrtmanageDBインターフェース取得
        /// </summary>
        /// <returns>IPrtmanageDBオブジェクト</returns>
        public static IBLGoodsCdUDB GetBLGoodsCdUDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IBLGoodsCdUDB)Activator.GetObject(typeof(IBLGoodsCdUDB), string.Format("{0}/MyAppBLGoodsCdU", wkStr));
        }
    }
}
