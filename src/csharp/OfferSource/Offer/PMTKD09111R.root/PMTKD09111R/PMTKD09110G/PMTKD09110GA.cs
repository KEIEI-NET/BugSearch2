using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 検索品目制御 DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISearchPrtCtlDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで部位マスタDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSearchPrtCtlDB
    {
        /// <summary>
        /// 検索品目制御 DB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.11.11</br>
        /// </remarks>
        public MediationSearchPrtCtlDB()
        {
        }
        /// <summary>
        /// ISearchPrtCtlDBインターフェース取得
        /// </summary>
        /// <returns>ISearchPrtCtlDBオブジェクト</returns>
        public static ISearchPrtCtlDB GetSearchPrtCtlDB()
        {
            //提供データアプリケーションサーバーのPathを取得
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISearchPrtCtlDB)Activator.GetObject(typeof(ISearchPrtCtlDB), string.Format("{0}/MyAppSearchPrtCtl", wkStr));
        }
    }
}
