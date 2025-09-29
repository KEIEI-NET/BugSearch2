//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品管理情報マスタ（インポート）
// プログラム概要   : 商品管理情報マスタ（インポート）DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 張曼
// 作 成 日  2012/06/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// GoodsMngImportDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIGoodsMngImportDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接GoodsMngImportDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 張曼</br>
    /// <br>Date       : 2012/06/04</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationGoodsMngImportDB
    {
        /// <summary>
        /// GoodsMngImportDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// </remarks>
        public MediationGoodsMngImportDB()
        {
        }

        /// <summary>
        /// IGoodsMngImportDBインターフェース取得
        /// </summary>
        /// <returns>IGoodsMngImportDBオブジェクト</returns>
        public static IGoodsMngImportDB GetGoodsMngImportDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IGoodsMngImportDB)Activator.GetObject(typeof(IGoodsMngImportDB), string.Format("{0}/MyAppGoodsMngImport", wkStr));
        }
    }
}
