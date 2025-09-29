//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ハンディターミナル在庫情報取得(通常)DB仲介クラス
// プログラム概要   : ハンディターミナル在庫情報取得(通常)DB仲介クラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 譚洪
// 作 成 日  2017/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ハンディターミナル在庫情報取得(通常)DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIHandyStockDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			 完全スタンドアロンにする場合にはこのクラスで直接HandyStockDBを</br>
    /// <br>			 インスタンス化して戻します。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/06/15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationHandyStockDB
    {
        /// <summary>
        /// HandyStockDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/15</br>
        /// </remarks>
        public MediationHandyStockDB()
        {
        }

        /// <summary>
        /// IHandyStockDBインターフェース取得
        /// </summary>
        /// <returns>IHandyStockDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IHandyStockDBインターフェースを取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/15</br>
        /// </remarks>
        public static IHandyStockDB GetHandyStockDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
# if DEBUG
            wkStr = "http://localhost:8008";
# endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IHandyStockDB)Activator.GetObject(typeof(IHandyStockDB), string.Format("{0}/MyAppHandyStock", wkStr));
        }
    }
}
