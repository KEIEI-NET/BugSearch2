//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーンマスタ印刷
// プログラム概要   : キャンペーンマスタ印刷 DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// キャンペーンマスタ印刷 DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICampaignMasterWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接CampaignMasterWorkDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCampaignMasterWorkDB
    {
        /// <summary>
        /// キャンペーンマスタ印刷 DB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public MediationCampaignMasterWorkDB()
        {
        }

        /// <summary>
        /// ICampaignMasterWorkDBインターフェース取得
        /// </summary>
        /// <returns>ICampaignMasterWorkDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : ICampaignMasterWorkDBインターフェースを取得する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public static ICampaignMasterWorkDB GetCampaignMasterWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICampaignMasterWorkDB)Activator.GetObject(typeof(ICampaignMasterWorkDB), string.Format("{0}/MyAppCampaignMasterWork", wkStr));
        }
    }
}
