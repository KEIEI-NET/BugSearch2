using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SupplierSendErOrderWorkDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISupplierSendErOrderWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SupplierSendErOrderWorkDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 30350 櫻井 亮太</br>
    /// <br>Date       : 2008.9.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSupplierSendErOrderWorkDB
    {
        /// <summary>
        /// MediationSupplierSendErOrderWorkDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.9.22</br>
        /// </remarks>
        public MediationSupplierSendErOrderWorkDB()
        {
        }
        /// <summary>
        /// ISupplierSendErOrderWorkDBインターフェース取得
        /// </summary>+
        /// <returns>ISupplierSendErOrderWorkDBオブジェクト</returns>
        public static ISupplierSendErOrderWorkDB GetSupplierSendErOrderWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISupplierSendErOrderWorkDB)Activator.GetObject(typeof(ISupplierSendErOrderWorkDB), string.Format("{0}/MyAppSupplierSendErOrderWork", wkStr));
        }
    }
}
