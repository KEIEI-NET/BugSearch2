using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// MakerUDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIMakerUDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接MakerUDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 21024　佐々木　健</br>
    /// <br>Date       : 2007.08.13</br>
    /// </remarks>
    public class MediationMakerUDB
    {
        /// <summary>
        /// MakerUDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        /// </remarks>
        public MediationMakerUDB()
        {
        }
        /// <summary>
        /// IPrtmanageDBインターフェース取得
        /// </summary>
        /// <returns>IPrtmanageDBオブジェクト</returns>
        public static IMakerUDB GetMakerUDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IMakerUDB)Activator.GetObject(typeof(IMakerUDB), string.Format("{0}/MyAppMakerU", wkStr));
        }
    }
}
