using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// CustSalesTargetDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICustSalesTargetDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接CustSalesTargetDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 横川昌令</br>
    /// <br>Date       : 2007.12.04</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCustSalesTargetDB
    {
        /// <summary>
        /// CustSalesTargetDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        /// </remarks>
        public MediationCustSalesTargetDB()
        {
        }
        /// <summary>
        /// ICustSalesTargetDBインターフェース取得
        /// </summary>
        /// <returns>ICustSalesTargetDBオブジェクト</returns>
        public static ICustSalesTargetDB GetCustSalesTargetDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:8008";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICustSalesTargetDB)Activator.GetObject(typeof(ICustSalesTargetDB), string.Format("{0}/MyAppCustSalesTarget", wkStr));
        }
    }
}
