//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル検品照会DB仲介クラス
// プログラム概要   : ハンディターミナル検品照会DB仲介クラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 陳艶丹
// 作 成 日  2017/07/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 検品照会DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIHandyInspectRefDataDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			 完全スタンドアロンにする場合にはこのクラスで直接HandyInspectRefDataDBを</br>
    /// <br>			 インスタンス化して戻します。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/07/20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationHandyInspectRefDataDB
    {
        /// <summary>
        /// HandyInspectDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public MediationHandyInspectRefDataDB()
        {
        }

        /// <summary>
        /// IHandyInspectRefDataDBインターフェース取得
        /// </summary>
        /// <returns>IHandyInspectRefDataDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IHandyInspectRefDataDBインターフェースを取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public static IHandyInspectRefDataDB GetHandyInspectRefDataDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string WkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            WkStr = "http://localhost:8008";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IHandyInspectRefDataDB)Activator.GetObject(typeof(IHandyInspectRefDataDB), string.Format("{0}/MyAppHandyInspectRefData", WkStr));
        }
    }
}
