//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : DC送受信履歴ログリモート
// プログラム概要   : DC送受信履歴ログを対象に、複数件一括で登録・修正行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : lushan
// 作 成 日  2011/07/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// RateDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISndRcvHisRFDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接RateDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer  : lushan</br>
    /// <br>Date        : 2011/07/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSndRcvHisRFDB
    {
        /// <summary>
        /// SndRcvHisRFDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer  : lushan</br>
        /// <br>Date        : 2011/07/25</br>
        /// </remarks>
        public MediationSndRcvHisRFDB()
        {
        }
        /// <summary>
        /// ISndRcvHisRFDBインターフェース取得
        /// </summary>
        /// <returns>ISndRcvHisRFDBオブジェクト</returns>
        public static ISndRcvHisDB GetSndRcvHisRFDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_Center_UserAP);
#if DEBUG
            wkStr = "http://localhost:9003";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISndRcvHisDB)Activator.GetObject(typeof(ISndRcvHisDB), string.Format("{0}/MyAppSndRcvHis", wkStr));
        }
    }
}
