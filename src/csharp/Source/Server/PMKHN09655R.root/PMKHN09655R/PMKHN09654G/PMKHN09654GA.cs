//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン目標設定マスタ
// プログラム概要   : キャンペーン目標設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 徐佳
// 作 成 日  2011/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// PartsPosCodeUDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIPartsPosCodeUDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接PartsPosCodeUDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 徐佳</br>
    /// <br>Date       : 2011/04/27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCampaignTargetUDB
    {
        /// <summary>
        /// CampaignTargetUDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        /// </remarks>
        public MediationCampaignTargetUDB()
        {

        }

        /// <summary>
        /// ICampaignTargetUDBインターフェース取得
        /// </summary>
        /// <returns>ICampaignTargetUDBオブジェクト</returns>
        public static ICampaignTargetUDB GetCampaignTargetUDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICampaignTargetUDB)Activator.GetObject(typeof(ICampaignTargetUDB), string.Format("{0}/MyAppCampaignTargetU", wkStr));
        }
    }
}
