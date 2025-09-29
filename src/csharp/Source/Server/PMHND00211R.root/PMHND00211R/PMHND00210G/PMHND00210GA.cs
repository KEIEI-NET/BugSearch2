//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 検品データ  DB 仲介クラス
// プログラム概要   : 検品データテーブルに対して削除処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 張小磊
// 作 成 日  2017/05/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;


namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// MediationInspectDataDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはMediationInspectDataDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接MediationInspectDataDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 3H 張小磊</br>
    /// <br>Date       : 2017/05/22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationInspectDataDB
    {
        /// <summary>
        /// InspectDataDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/05/22</br>
        /// </remarks>
        public MediationInspectDataDB()
        {
        }
        /// <summary>
        /// IInspectDataDBインターフェース取得
        /// </summary>
        /// <returns>IInspectDataDBオブジェクト</returns>
        public static IInspectDataDB GetDeleteInspectDataDB()
        {
            // USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

# if DEBUG
            wkStr = "http://localhost:9001";
# endif

            // AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IInspectDataDB)Activator.GetObject(typeof(IInspectDataDB), string.Format("{0}/MyAppInspectData", wkStr));
        }
    }
}
