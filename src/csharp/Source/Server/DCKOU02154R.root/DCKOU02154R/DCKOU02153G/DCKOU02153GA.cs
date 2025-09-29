using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockDayTotalDataDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIStockDayTotalDataDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接StockDayTotalDataDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.09.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockDayTotalDataDB
    {
        /// <summary>
        /// StockDayTotalDataDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.13</br>
        /// </remarks>
        public MediationStockDayTotalDataDB()
        {
        }

        /// <summary>
        /// IStockDayTotalDataDBインターフェース取得
        /// </summary>
        /// <returns>IStockDayTotalDataDBオブジェクト</returns>
        public static IStockDayTotalDataDB GetStockDayTotalDataDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8008";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStockDayTotalDataDB)Activator.GetObject(typeof(IStockDayTotalDataDB),string.Format("{0}/MyAppStockDayTotalData",wkStr));
        }
    }
}
