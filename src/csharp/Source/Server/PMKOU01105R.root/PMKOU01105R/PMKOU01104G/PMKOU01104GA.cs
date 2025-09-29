using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SupplierCheckOrderWorkDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISupplierCheckOrderWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SupplierCheckOrderWorkDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 30350 櫻井 亮太</br>
    /// <br>Date       : 2008.10.2</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSupplierCheckOrderWorkDB
    {
        /// <summary>
        /// MediationSupplierCheckOrderWorkDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.2</br>
        /// </remarks>
        public MediationSupplierCheckOrderWorkDB()
        {
        }
        /// <summary>
        /// ISupplierCheckOrderWorkDBインターフェース取得
        /// </summary>
        /// <returns>ISupplierCheckOrderWorkDBオブジェクト</returns>
        public static ISupplierCheckOrderWorkDB GetSupplierCheckOrderWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISupplierCheckOrderWorkDB)Activator.GetObject(typeof(ISupplierCheckOrderWorkDB), string.Format("{0}/MyAppSupplierCheckOrderWork", wkStr));
        }
    }
}
