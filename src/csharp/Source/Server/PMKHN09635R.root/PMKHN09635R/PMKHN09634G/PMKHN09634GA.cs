//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタ一括登録
// プログラム概要   : キャンペーン対象商品設定マスタ一括登録
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/05/20  修正内容 : 新規作成
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
    /// ICampaignLoginDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICampaignLoginDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接ICampaignLoginDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 鄧潘ハン</br>
    /// <br>Date       : 2011/05/20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCampaignLoginDB
    {
        /// <summary>
        /// ICampaignLoginDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public MediationCampaignLoginDB()
        {
        }
        /// <summary>
        /// ICampaignLoginDBインターフェース取得
        /// </summary>
        /// <returns>ICampaignLoginDBオブジェクト</returns>
        public static ICampaignLoginDB GetCampaignLoginDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
# if DEBUG
            wkStr = "http://localhost:9001";
# endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICampaignLoginDB)Activator.GetObject(typeof(ICampaignLoginDB), string.Format("{0}/MyAppCampaignLogin", wkStr));
        }
    }
}
