using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockTransListResultDB 仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIStockTransListResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接StockTransListResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 山田 明友</br>
    /// <br>Date       : 2007.11.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockTransListResultDB
    {
        /// <summary>
        /// StockTransListResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 山田 明友</br>
        /// <br>Date       : 2007.11.30</br>
        /// </remarks>
        public MediationStockTransListResultDB()
        {
        }
        /// <summary>
        /// IStockTransListResultDBインターフェース取得
        /// </summary>
        /// <returns>IStockTransListResultDBオブジェクト</returns>
        public static IStockTransListResultDB GetStockTransListResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStockTransListResultDB)Activator.GetObject(typeof(IStockTransListResultDB), string.Format("{0}/MyAppStockTransListResult", wkStr));
        }
    }
}
