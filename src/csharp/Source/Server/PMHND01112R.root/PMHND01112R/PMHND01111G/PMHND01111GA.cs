//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル在庫仕入（入庫更新）DB仲介クラス
// プログラム概要   : ハンディターミナル在庫仕入（入庫更新）DB仲介クラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ハンディターミナル在庫仕入（入庫更新）DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIHandyStockSupplierDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			 完全スタンドアロンにする場合にはこのクラスで直接HandyStockSupplierDBを</br>
    /// <br>			 インスタンス化して戻します。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/08/11</br>
    /// </remarks>
    public class MediationHandyStockSupplierDB
    {
        /// <summary>
        /// HandyStockSupplierDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public MediationHandyStockSupplierDB()
        {
        }

        /// <summary>
        /// IHandyStockSupplierDBインターフェース取得
        /// </summary>
        /// <returns>IHandyLoginInfoDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IHandyStockSupplierDBインターフェースを取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public static IHandyStockSupplierDB GetHandyStockSuppliersDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

# if DEBUG
            wkStr = "http://localhost:8008";
# endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IHandyStockSupplierDB)Activator.GetObject(typeof(IHandyStockSupplierDB), string.Format("{0}/MyAppHandyStockSupplier", wkStr));
        }
    }
}
