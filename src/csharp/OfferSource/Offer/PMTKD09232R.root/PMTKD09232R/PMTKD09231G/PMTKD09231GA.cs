//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : リコメンド商品関連設定マスタメンテ
// プログラム概要   : リコメンド商品関連設定マスタメンテDB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2015.01.16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// RecGoodsLkODB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIRecGoodsLkODBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接RecGoodsLkODBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 自動生成</br>
    /// <br>Date       : 2015.01.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRecGoodsLkODB
    {
        /// <summary>
        /// RecGoodsLkODB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 自動生成</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public MediationRecGoodsLkODB()
        {
        }

		/// <summary>
        /// IRecGoodsLkODBインターフェース取得
		/// </summary>
        /// <returns>IRecGoodsLkODBオブジェクト</returns>
        public static IRecGoodsLkODB GetRecGoodsLkODB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IRecGoodsLkODB)Activator.GetObject(typeof(IRecGoodsLkODB), string.Format("{0}/MyAppRecGoodsLkO", wkStr));
        }
    }
}
