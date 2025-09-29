//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PMTABセッション管理データ  DB 仲介クラス
// プログラム概要   : PMTABセッション管理データテーブルに対して追加・更新・削除処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11300141-00 作成担当 : 譚洪
// 作 成 日  2017/04/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : 
// 修 正 日               修正内容 : 
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
    /// MediationPmTabSessionMngDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはMediationPmTabSessionMngDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接MediationPmTabSessionMngDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/04/06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationPmTabSessionMngDB
    {
        /// <summary>
        /// APBaseDataExtraDefSetDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
        public MediationPmTabSessionMngDB()
        {
        }
        /// <summary>
        /// ISalesSlipDBインターフェース取得
        /// </summary>
        /// <returns>IIOWriteMAHNBDBオブジェクト</returns>
        public static IPmTabSessionMngDB GetDeletePmTabSessionDateDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

# if DEBUG
            wkStr = "http://localhost:9001";
# endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPmTabSessionMngDB)Activator.GetObject(typeof(IPmTabSessionMngDB), string.Format("{0}/MyAppPmTabSessionMng", wkStr));
        }
    }
}
