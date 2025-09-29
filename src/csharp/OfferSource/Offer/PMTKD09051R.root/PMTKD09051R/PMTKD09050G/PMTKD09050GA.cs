using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 商品中分類マスタDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIGoodsMGroupDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接商品中分類マスタDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationGoodsMGroupDB
    {
        /// <summary>
        /// GoodsMGroupDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        public MediationGoodsMGroupDB()
        {
        }
        /// <summary>
        /// IGoodsMGroupDBインターフェース取得
        /// </summary>
        /// <returns>IGoodsMGroupDBオブジェクト</returns>
        public static IGoodsMGroupDB GetGoodsMGroupDB()
        {
            //提供データアプリケーションサーバーのPathを取得
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IGoodsMGroupDB)Activator.GetObject(typeof(IGoodsMGroupDB), string.Format("{0}/MyAppGoodsMGroup", wkStr));
        }
    }
}
