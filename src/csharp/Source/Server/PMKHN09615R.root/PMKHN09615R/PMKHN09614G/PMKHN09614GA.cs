//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン売価優先設定マスタメンテナンス
// プログラム概要   : キャンペーン売価優先設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// CampaignPrcPrStDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICampaignPrcPrStDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接CampaignPrcPrStDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 鄧潘ハン</br>
    /// <br>Date       : 2011/04/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCampaignPrcPrStDB 
    {
        /// <summary>
        /// ICampaignPrcPrStDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public MediationCampaignPrcPrStDB()
        {
        }
        /// <summary>
        /// ICampaignPrcPrStDBインターフェース取得
        /// </summary>
        /// <returns>ISlipPrtSetDBオブジェクト</returns>
        public static ICampaignPrcPrStDB GetCampaignPrcPrStDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
# if DEBUG
            wkStr = "http://localhost:9001";
# endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICampaignPrcPrStDB)Activator.GetObject(typeof(ICampaignPrcPrStDB), string.Format("{0}/MyAppCampaignPrcPrSt", wkStr));
        }
    }
}
