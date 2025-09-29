using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SalesProcMoneyDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISalesProcMoneyDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接ISalesProcMoneyDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 22008　長内　数馬</br>
    /// <br>Date       : 2007.08.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSalesProcMoneyDB
    {
        /// <summary>
        /// SalesProcMoneyDB仲介クラスコンストラクタ
        /// </summary>
        public MediationSalesProcMoneyDB()
        {
        }

        /// <summary>
        /// インターフェース取得
        /// </summary>
        /// <returns>オブジェクト</returns>
        public static ISalesProcMoneyDB GetSalesProcMoneyDB()
        {
            //USERデータアプリケーションサーバーのPathを取得
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISalesProcMoneyDB)Activator.GetObject(typeof(ISalesProcMoneyDB), string.Format("{0}/MyAppSalesProcMoney", wkStr));
        }
    }
}
