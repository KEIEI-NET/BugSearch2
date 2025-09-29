//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品マスタ（インポート）
// プログラム概要   : 商品マスタ（インポート）DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/05/15  修正内容 : 新規作成
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
    /// GoodsUImportDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIGoodsUImportDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接GoodsUImportDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationGoodsUImportDB
    {
        /// <summary>
        /// GoodsUImportDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public MediationGoodsUImportDB()
        {
        }

        /// <summary>
        /// IGoodsUImportDBインターフェース取得
        /// </summary>
        /// <returns>IGoodsUImportDBオブジェクト</returns>
        public static IGoodsUImportDB GetGoodsUImportDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IGoodsUImportDB)Activator.GetObject(typeof(IGoodsUImportDB), string.Format("{0}/MyAppGoodsUImport", wkStr));
        }
    }
}
