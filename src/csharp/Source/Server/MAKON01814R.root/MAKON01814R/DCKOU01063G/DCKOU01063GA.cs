using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockSlipHistDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIStockHistoryDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接StockHistoryDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.10.24</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockSlipHistDB
    {
        /// <summary>
        /// StockHistoryDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        public MediationStockSlipHistDB()
        {
        }
        /// <summary>
        /// IStockHistoryDBインターフェース取得
        /// </summary>
        /// <returns>IStockHistoryDBオブジェクト</returns>
        public static IStockSlipHistDB GetStockHistoryDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStockSlipHistDB)Activator.GetObject(typeof(IStockSlipHistDB), string.Format("{0}/MyAppStockSlipHist", wkStr));
        }
    }
}
