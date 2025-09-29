using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SalesSlipDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISalesSlipDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			 完全スタンドアロンにする場合にはこのクラスで直接SalesSlipDBを</br>
    /// <br>			 インスタンス化して戻します。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.11.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSalesSlipDB
    {
        /// <summary>
        /// SalesSlipDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.21</br>
        /// </remarks>
        public MediationSalesSlipDB()
        {
        }
        /// <summary>
        /// ISalesSlipDBインターフェース取得
        /// </summary>
        /// <returns>StockSlipDBオブジェクト</returns>
        public static ISalesSlipDB GetSalesSlipDB()
        {
            //USERデータアプリケーションサーバーのPathを取得
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            
#if DEBUG
         wkStr = "http://localhost:9001";
#endif
            
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISalesSlipDB)Activator.GetObject(typeof(ISalesSlipDB), string.Format("{0}/MyAppSalesSlip", wkStr));
        }
    }
}
