using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// GoodsPriceUDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIGoodsPriceUDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>            完全スタンドアロンにする場合にはこのクラスで直接GoodsPriceUDBを</br>
    /// <br>            インスタンス化して戻します。</br>
    /// <br>Programmer : 18322  木村 武正</br>
    /// <br>Date       : 2007.04.18</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: DC.NS対応</br>
    /// <br>Programmer : 21024　佐々木　健</br>
    /// <br>Date       : 2007.08.13</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
    public class MediationGoodsPriceUDB
    {
        /// <summary>
        /// GoodsPriceUDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        public MediationGoodsPriceUDB()
        {
        }
        /// <summary>
        /// IPrtmanageDBインターフェース取得
        /// </summary>
        /// <returns>IGoodsPriceUDBオブジェクト</returns>
        public static IGoodsPriceUDB GetGoodsPriceUDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IGoodsPriceUDB)Activator.GetObject(typeof(IGoodsPriceUDB),string.Format("{0}/MyAppGoodsPriceU",wkStr));
        }
    }
}
