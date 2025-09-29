using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 仕入先マスタ(提供)DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIOfrSupplierDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで仕入先マスタDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.10.29</br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationOfrSupplierDB
    {
        /// <summary>
        /// OfrSupplierDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.10.29</br>
        /// </remarks>
        public MediationOfrSupplierDB()
        {
        }
        /// <summary>
        /// IOfrSupplierDBインターフェース取得
        /// </summary>
        /// <returns>IOfrSupplierDBオブジェクト</returns>
        public static IOfrSupplierDB GetOfrSupplierDB()
        {
            //提供データアプリケーションサーバーのPathを取得
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IOfrSupplierDB)Activator.GetObject(typeof(IOfrSupplierDB), string.Format("{0}/MyAppOfrSupplier", wkStr));
        }
    }
}
