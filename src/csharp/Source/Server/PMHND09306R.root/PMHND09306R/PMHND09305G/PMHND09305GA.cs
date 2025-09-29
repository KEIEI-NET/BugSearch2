//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 商品バーコード関連付けマスタ登録DB仲介クラス
// プログラム概要   : 商品バーコード関連付けマスタ登録DB仲介クラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 譚洪
// 作 成 日  2017/06/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 商品バーコード関連付けマスタ登録DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIHandyGoodsBarCodeDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			 完全スタンドアロンにする場合にはこのクラスで直接HandyGoodsBarCodeDBを</br>
    /// <br>			 インスタンス化して戻します。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/06/05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationHandyGoodsBarCodeDB
    {
        /// <summary>
        /// HandyGoodsBarCodeDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        public MediationHandyGoodsBarCodeDB()
        {
        }

        /// <summary>
        /// IHandyGoodsBarCodeDBインターフェース取得
        /// </summary>
        /// <returns>IHandyGoodsBarCodeDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IHandyGoodsBarCodeDBインターフェースを取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        public static IHandyGoodsBarCodeDB GetHandyGoodsBarCodeDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
# if DEBUG
            wkStr = "http://localhost:8008";
# endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IHandyGoodsBarCodeDB)Activator.GetObject(typeof(IHandyGoodsBarCodeDB), string.Format("{0}/MyAppHandyGoodsBarCode", wkStr));
        }
    }
}
