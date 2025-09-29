using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockConfDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIStockConfDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接StockConfDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 20098　村瀬　勝也</br>
    /// <br>Date       : 2007.03.19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockConfDB
    {
        /// <summary>
        /// StockConfDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        /// </remarks>
        public MediationStockConfDB()
        {
        }
        /// <summary>
        /// IPrtmanageDBインターフェース取得
        /// </summary>
        /// <returns>IPrtmanageDBオブジェクト</returns>
        public static IStockConfDB GetStockConfDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStockConfDB)Activator.GetObject(typeof(IStockConfDB), string.Format("{0}/MyAppStockConf", wkStr));
        }
    }
}
