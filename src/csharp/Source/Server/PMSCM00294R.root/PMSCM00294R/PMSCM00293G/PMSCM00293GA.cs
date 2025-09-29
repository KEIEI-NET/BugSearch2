//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PMDBID管理マスタDB仲介クラス
// プログラム概要   : PMDBID管理マスタDB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
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
    /// IPmDbIdMngDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPmDbIdMngDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接PmDbIdMngDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPmDbIdMngDB
    {
        /// <summary>
        /// PmDbIdMngDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// </remarks>
        public MediationPmDbIdMngDB()
        {

        }

        /// <summary>
        /// IPmDbIdMngDBインターフェース取得
        /// </summary>
        /// <returns>IPmDbIdMngDBオブジェクト</returns>
        public static IPmDbIdMngDB GetPmDbIdMngDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9004";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPmDbIdMngDB)Activator.GetObject(typeof(IPmDbIdMngDB), string.Format("{0}/MyAppPmDbIdMng", wkStr));
        }
    }
}