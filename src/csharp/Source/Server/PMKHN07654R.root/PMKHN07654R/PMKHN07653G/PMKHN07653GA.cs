//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : セットマスタ（インポート）
// プログラム概要   : セットマスタ（インポート）DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
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
    /// GoodsSetImportDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIGoodsSetImportDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接GoodsSetImportDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationGoodsSetImportDB
    {
        /// <summary>
        /// GoodsSetImportDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public MediationGoodsSetImportDB()
        {
        }

        /// <summary>
        /// IGoodsSetImportDBインターフェース取得
        /// </summary>
        /// <returns>IGoodsSetImportDBオブジェクト</returns>
        public static IGoodsSetImportDB GetGoodsSetImportDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IGoodsSetImportDB)Activator.GetObject(typeof(IGoodsSetImportDB), string.Format("{0}/MyAppGoodsSetImport", wkStr));
        }
    }
}
