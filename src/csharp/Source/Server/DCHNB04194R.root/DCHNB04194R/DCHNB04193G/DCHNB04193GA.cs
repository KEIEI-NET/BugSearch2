using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SalesAnnualDataSelectResultDB 仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISalesAnnualDataSelectResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SalesAnnualDataSelectResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 横川昌令</br>
    /// <br>Date       : 2007.10.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSalesAnnualDataSelectResultDB
    {
        /// <summary>
        /// SalesAnnualDataSelectResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.10.26</br>
        /// </remarks>
        public MediationSalesAnnualDataSelectResultDB()
        {
        }
        /// <summary>
        /// ISalesAnnualDataSelectResultDBインターフェース取得
        /// </summary>
        /// <returns>ISalesAnnualDataSelectResultDBオブジェクト</returns>
        public static ISalesAnnualDataSelectResultDB GetSalesAnnualDataSelectResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:8008";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISalesAnnualDataSelectResultDB)Activator.GetObject(typeof(ISalesAnnualDataSelectResultDB), string.Format("{0}/MyAppSalesAnnualDataSelectResult", wkStr));
        }
    }
}
