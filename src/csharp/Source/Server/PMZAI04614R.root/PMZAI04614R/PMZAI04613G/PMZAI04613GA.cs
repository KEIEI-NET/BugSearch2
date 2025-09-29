//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫移動電子元帳
// プログラム概要   : 在庫移動電子元帳 DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 作 成 日  2011/04/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 在庫移動電子元帳 DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIStockMoveWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接StockMoveWorkDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : yangmj</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockMoveWorkDB
    {
        /// <summary>
        /// 在庫移動電子元帳 DB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        /// </remarks>
        public MediationStockMoveWorkDB()
        {
        }

        /// <summary>
        /// IStockMoveWorkDBインターフェース取得
        /// </summary>
        /// <returns>IStockMoveWorkDBオブジェクト</returns>
        public static IStockMoveWorkDB GetStockMoveWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStockMoveWorkDB)Activator.GetObject(typeof(IStockMoveWorkDB), string.Format("{0}/MyAppStockMoveWork", wkStr));
        }
    }
}
