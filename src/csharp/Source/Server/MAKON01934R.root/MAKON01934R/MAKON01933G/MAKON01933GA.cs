using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SearchStockSlipDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISearchStockSlipDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接StockSlipDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.02.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSearchStockSlipDB
    {
        /// <summary>
        /// SearchStockSlipDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.15</br>
        /// </remarks>
        public MediationSearchStockSlipDB()
        {
        }
        /// <summary>
        /// ISearchStockSlipDBインターフェース取得
        /// </summary>
        /// <returns>ISearchStockSlipDBオブジェクト</returns>
        public static ISearchStockSlipDB GetSearchStockSlipDB()
        {
            //USERデータアプリケーションサーバーのPathを取得
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";   
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISearchStockSlipDB)Activator.GetObject(typeof(ISearchStockSlipDB), string.Format("{0}/MyAppSearchStockSlip", wkStr));
        }
    }
}
