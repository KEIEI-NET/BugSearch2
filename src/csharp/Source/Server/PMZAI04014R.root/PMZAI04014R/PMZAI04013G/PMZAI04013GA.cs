using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockAdjRefSearchDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISearchStockSlipDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接StockSlipDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 22018　鈴木　正臣</br>
    /// <br>Date       : 2008.08.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockAdjRefSearchDB
    {
        /// <summary>
        /// StockAdjRefSearchDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 22018　鈴木　正臣</br>
        /// <br>Date       : 2008.08.20</br>
        /// </remarks>
        public MediationStockAdjRefSearchDB()
        {
        }
        /// <summary>
        /// IStockAdjRefSearchDBインターフェース取得
        /// </summary>
        /// <returns>IStockAdjRefSearchDBオブジェクト</returns>
        public static IStockAdjRefSearchDB GetStockAdjRefSearchDB()
        {
            //USERデータアプリケーションサーバーのPathを取得
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";   
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStockAdjRefSearchDB)Activator.GetObject( typeof( IStockAdjRefSearchDB ), string.Format( "{0}/MyAppStockAdjRefSearch", wkStr ) );
        }
    }
}
