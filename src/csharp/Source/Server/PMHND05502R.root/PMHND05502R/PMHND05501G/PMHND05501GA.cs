//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル棚卸DB仲介クラス
// プログラム概要   : ハンディターミナル棚卸DB仲介クラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ハンディターミナル棚卸DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIHandyInventoryDataDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			 完全スタンドアロンにする場合にはこのクラスで直接MediationHandyInventoryDataDBを</br>
    /// <br>			 インスタンス化して戻します。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/08/16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationHandyInventoryDataDB
    {
        /// <summary>
        /// ハンディターミナル棚卸DB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public MediationHandyInventoryDataDB()
        {
        }
        /// <summary>
        /// IHandyInventoryDataDBインターフェース取得
        /// </summary>
        /// <returns>IHandyInventoryDataDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IHandyInventoryDataDBインターフェースを取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public static IHandyInventoryDataDB GetHandyInventoryDataDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
# if DEBUG
            wkStr = "http://localhost:8008";
# endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IHandyInventoryDataDB)Activator.GetObject(typeof(IHandyInventoryDataDB), string.Format("{0}/MyAppHandyInventoryData", wkStr));
        }
    }
}
