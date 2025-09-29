using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockProcMoneyDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIStockProcMoneyDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接IStockProcMoneyDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2006.12.12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockProcMoneyDB
    {
        /// <summary>
        /// StockProcMoneyDB仲介クラスコンストラクタ
        /// </summary>
        public MediationStockProcMoneyDB()
        {
        }

        /// <summary>
        /// インターフェース取得
        /// </summary>
        /// <returns>オブジェクト</returns>
        public static IStockProcMoneyDB GetStockProcMoneyDB()
        {
            //USERデータアプリケーションサーバーのPathを取得
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStockProcMoneyDB)Activator.GetObject(typeof(IStockProcMoneyDB), string.Format("{0}/MyAppStockProcMoney", wkStr));
        }
    }
}
