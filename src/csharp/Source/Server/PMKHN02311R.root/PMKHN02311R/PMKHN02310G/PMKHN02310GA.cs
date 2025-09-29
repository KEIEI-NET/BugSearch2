//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 卸商商品価格改正
// プログラム概要   : 卸商商品価格改正を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// TrustStockOrderWorkDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはITrustStockOrderWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接TrustStockOrderWorkDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009/04/28</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationGoodsInfoWorkDB
    {
        /// <summary>
        /// MediationTrustStockOrderWorkDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        public MediationGoodsInfoWorkDB()
        {
        }
        /// <summary>
        /// ITrustStockOrderWorkDBインターフェース取得
        /// </summary>+
        /// <returns>ITrustStockOrderWorkDBオブジェクト</returns>
        public static IGoodsInfoWorkDB GetGoodsInfoWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IGoodsInfoWorkDB)Activator.GetObject(typeof(IGoodsInfoWorkDB), string.Format("{0}/MyAppGoodsInfoWork", wkStr));
        }
    }
}
