//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品バーコード更新リモート
// プログラム概要   : 商品バーコード更新DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00  作成担当 : 30757 佐々木貴英
// 作 成 日  2017/09/20   修正内容 : ハンディターミナル二次対応（新規作成）
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 商品バーコード更新DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPrmGoodsBarCodeRevnUpdateDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接PrmGoodsBarCodeRevnUpdateDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 30757 佐々木　貴英</br>
    /// <br>Date       : 2017/09/20</br>
    /// </remarks>
    public class MediationIPrmGoodsBarCodeRevnUpdateDB
    {
        /// <summary>
        /// 商品バーコード更新DB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30757 佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        public MediationIPrmGoodsBarCodeRevnUpdateDB()
        {
        }
        /// <summary>
        /// 商品バーコード更新インターフェース取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : UserAPプロキシサービスより商品バーコード更新インターフェース型のオブジェクトを取得する</br>
        /// <br>Programmer : 30757 佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        /// <returns>商品バーコード更新インターフェース型オブジェクト</returns>
        public static IPrmGoodsBarCodeRevnUpdateDB GetIPrmGoodsBarCodeRevnUpdateDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            return (IPrmGoodsBarCodeRevnUpdateDB)Activator.GetObject(typeof(IPrmGoodsBarCodeRevnUpdateDB), string.Format("{0}/MyAppPrmGoodsBarCodeRevnUpdate", wkStr));
        }

    }
}
