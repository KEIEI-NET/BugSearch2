//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 出品一括更新
// プログラム名称   : 出品一括更新 仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00   作成担当 : 宋剛
// 作 成 日 : 2016/01/22    修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// PartsMaxStockUpdDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : このクラスはIPartsMaxStockUpdDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>    完全スタンドアロンにする場合にはこのクラスで直接IPartsMaxStockUpdDBを</br>
    /// <br>    インスタンス化して戻します。</br>
    /// <br>Programmer  : 宋剛</br>
    /// <br>Date        : 2016/01/22</br>
    /// <br></br>
    /// </remarks>
    public class MediationPartsMaxStockUpdDB
    {
        /// <summary>
        /// PartsMaxStockUpdDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        public MediationPartsMaxStockUpdDB()
        {
        }

        /// <summary>
        /// IPartsMaxStockUpdDBインターフェース取得
        /// </summary>
        /// <returns>IPartsMaxStockUpdDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note        : IPartsMaxStockUpdDBインターフェース取得。</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// <br></br>
        /// </remarks>
        public static IPartsMaxStockUpdDB GetPartsMaxStockUpdDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
# if DEBUG
            wkStr = "http://localhost:9001";
# endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPartsMaxStockUpdDB)Activator.GetObject(typeof(IPartsMaxStockUpdDB), string.Format("{0}/MyAppPartsMaxStockUpd", wkStr));
        }
    }
}
