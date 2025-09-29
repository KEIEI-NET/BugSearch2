//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタ（インポート）
// プログラム概要   : 在庫マスタ（インポート）DBRemoteObject仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhangy3
// 作 成 日  2012/06/12  修正内容 : 新規作成
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
    /// <br>Programmer : zhangy3</br>
    /// <br>Date       : 2012/06/12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockImportDB
    {
        /// <summary>
        /// GoodsUImportDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        public MediationStockImportDB()
        {
        }

        /// <summary>
        /// IGoodsUImportDBインターフェース取得
        /// </summary>
        /// <returns>IGoodsUImportDBオブジェクト</returns>
        public static IStockImportDB GetStockImportDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9856";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStockImportDB)Activator.GetObject(typeof(IStockImportDB), string.Format("{0}/MyAppStockImport", wkStr));
        }
    }
}
