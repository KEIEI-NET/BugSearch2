//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタ一括削除
// プログラム概要   : キャンペーン対象商品設定マスタ一括削除
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2011/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// キャンペーン対象商品設定マスタ一括削除DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスは受信データDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SupplierDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCampaignGoodsStDB
    {
        /// <summary>
        /// キャンペーン対象商品設定マスタ一括削除仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public MediationCampaignGoodsStDB()
        {

        }

        /// <summary>
        /// ICampaignGoodsStDBインターフェース取得
        /// </summary>
        /// <returns>ICampaignGoodsStDBオブジェクト</returns>
        public static ICampaignGoodsStDB GetCampaignGoodsStDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICampaignGoodsStDB)Activator.GetObject(typeof(ICampaignGoodsStDB), string.Format("{0}/MyAppCampaignGoodsSt", wkStr));
        }
    }
}
