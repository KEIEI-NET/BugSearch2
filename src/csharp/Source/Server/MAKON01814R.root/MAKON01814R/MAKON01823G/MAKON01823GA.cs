using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockSlip仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIStockSlipDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接StockSlipDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.01.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockSlipDB
    {
        /// <summary>
        /// StockSlipDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.11</br>
        /// </remarks>
        public MediationStockSlipDB()
        {
        }
        /// <summary>
        /// IStockSlipDBインターフェース取得
        /// </summary>
        /// <returns>StockSlipDBオブジェクト</returns>
        public static IStockSlipDB GetStockSlipDB()
        {
            //USERデータアプリケーションサーバーのPathを取得
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            
#if DEBUG
         wkStr = "http://localhost:9001";
#endif
            
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStockSlipDB)Activator.GetObject(typeof(IStockSlipDB), string.Format("{0}/MyAppStockSlip", wkStr));
        }
    }
}
