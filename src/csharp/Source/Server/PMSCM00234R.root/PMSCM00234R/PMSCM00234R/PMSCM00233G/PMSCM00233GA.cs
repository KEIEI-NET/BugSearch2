//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : オプション管理マスタDB仲介クラス
// プログラム概要   : オプション管理マスタDB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡
// 作 成 日  2014/08/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// PMOptMngDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIIPMOptMngDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接IPMOptMngDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : limm</br>
    /// <br>Date       : 2014/08/05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPMOptMngDB
    {
        /// <summary>
        /// PMOptMngDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        /// </remarks>
        public MediationPMOptMngDB()
        {

        }

        /// <summary>
        /// IPMOptMngDBインターフェース取得
        /// </summary>
        /// <returns>IPMOptMngDBオブジェクト</returns>
        public static IPMOptMngDB GetPMOptMngDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPMOptMngDB)Activator.GetObject(typeof(IPMOptMngDB), string.Format("{0}/MyAppPMOptMng", wkStr));
        }
    }
}
