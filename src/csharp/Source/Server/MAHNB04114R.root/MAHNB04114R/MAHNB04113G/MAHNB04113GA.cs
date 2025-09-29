using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SearchSalesSlipDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISearchSalesSlipDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SalesSlipDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 19026　湯山　美樹</br>
    /// <br>Date       : 2007.03.23</br>
    /// <br></br>
    /// <br>Update Note: 980081 山田 明友</br>
    /// <br>Date       : 2007.10.05</br>
    /// <br>             DistributionCore対応</br>
    /// <br></br>
    /// </remarks>
    public class MediationSearchSalesSlipDB
    {
        /// <summary>
        /// SearchSalesSlipDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.03.23</br>
        /// </remarks>
        public MediationSearchSalesSlipDB()
        {
        }
        /// <summary>
        /// ISearchSalesSlipDBインターフェース取得
        /// </summary>
        /// <returns>ISearchSalesSlipDBオブジェクト</returns>
        public static ISearchSalesSlipDB GetSearchSalesSlipDB()
        {
            //USERデータアプリケーションサーバーのPathを取得
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISearchSalesSlipDB)Activator.GetObject(typeof(ISearchSalesSlipDB), string.Format("{0}/MyAppSearchSalesSlip", wkStr));
        }
    }
}
