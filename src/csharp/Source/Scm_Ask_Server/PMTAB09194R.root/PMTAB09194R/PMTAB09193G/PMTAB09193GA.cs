//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PMTAB初期表示従業員設定マスタDB仲介クラス
// プログラム概要   : PMTAB初期表示従業員設定マスタDB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/08/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// IPmtDefEmpDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPmtDefEmpDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接PmtDefEmpDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPmtDefEmpDB
    {
        /// <summary>
        /// PmtDefEmpDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// </remarks>
        public MediationPmtDefEmpDB()
        {

        }

        /// <summary>
        /// IPmtDefEmpDBインターフェース取得
        /// </summary>
        /// <returns>IPmtDefEmpDBオブジェクト</returns>
        public static IPmtDefEmpDB GetPmtDefEmpDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);
#if DEBUG
            wkStr = "http://localhost:9004";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPmtDefEmpDB)Activator.GetObject(typeof(IPmtDefEmpDB), string.Format("{0}/MyAppPmtDefEmp", wkStr));
        }
    }
}