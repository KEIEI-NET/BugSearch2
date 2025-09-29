//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル在庫（仕入・移動）DB仲介クラス
// プログラム概要   : ハンディターミナル在庫（仕入・移動）DB仲介クラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/02  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ハンディターミナル在庫（仕入・移動）DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIHandyStockMoveDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			 完全スタンドアロンにする場合にはこのクラスで直接MediationHandyStockMoveDBを</br>
    /// <br>			 インスタンス化して戻します。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/08/02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationHandyStockMoveDB
    {
        /// <summary>
        /// ハンディターミナル在庫（仕入・移動）DB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public MediationHandyStockMoveDB()
        {
        }

        /// <summary>
        /// IHandyStockMoveDBインターフェース取得
        /// </summary>
        /// <returns>IHandyStockMoveDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IHandyStockMoveDBインターフェースを取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public static IHandyStockMoveDB GetHandyStockMoveDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
# if DEBUG
            wkStr = "http://localhost:8008";
# endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IHandyStockMoveDB)Activator.GetObject(typeof(IHandyStockMoveDB), string.Format("{0}/MyAppHandyStockMove", wkStr));
        }
    }
}
