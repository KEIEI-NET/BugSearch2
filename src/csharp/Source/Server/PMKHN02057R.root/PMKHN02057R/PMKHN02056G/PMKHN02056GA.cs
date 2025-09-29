//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン実績表
// プログラム概要   : キャンペーン実績表　DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/05/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// CampaignRsltListResultDB 仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICampaignRsltListResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接CampaignRsltListResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2011/05/19</br>
    /// <br></br>
    /// </remarks>
    public class MediationCampaignRsltListResultDB
    {
        /// <summary>
        /// CampaignRsltListResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/05/19</br>
        /// <br>Update Note: 2011/07/01 譚洪</br>
        /// <br>           : PMKHN02056Gに記載ミスの対応</br>
        /// </remarks>
        public MediationCampaignRsltListResultDB()
        {
        }
        /// <summary>
        /// ICampaignRsltListResultDBインターフェース取得
        /// </summary>
        /// <returns>ICampaignRsltListResultDBオブジェクト</returns>
        public static ICampaignRsltListResultDB GetCampaignRsltListResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            //return (ICampaignRsltListResultDB)Activator.GetObject(typeof(ICampaignRsltListResultDB), string.Format("{0}/MyAppCampaignstRsltListResultWork", wkStr));  // DEL 2011/07/01
            return (ICampaignRsltListResultDB)Activator.GetObject(typeof(ICampaignRsltListResultDB), string.Format("{0}/MyAppCampaignRsltListResult", wkStr));  // ADD 2011/07/01
        }
    }
}
