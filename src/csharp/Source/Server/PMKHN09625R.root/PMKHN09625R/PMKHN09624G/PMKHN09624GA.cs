//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタメンテナンス
// プログラム概要   : キャンペーン対象商品設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 作 成 日  2011/04/26  修正内容 : 新規作成
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
    /// CampaignMngInfoDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはCampaignMngInfoDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接CampaignMngInfoDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 曹文傑</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br></br>
    /// </remarks>
    public class MediationCampaignObjGoodsStDB
    {
        /// <summary>
        /// UOEConnectInfoDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public MediationCampaignObjGoodsStDB()
        {
        }
        /// <summary>
        /// ICampaignMngInfoDBインターフェース取得
        /// </summary>
        /// <returns>ICampaignMngInfoDBオブジェクト</returns>
        public static ICampaignObjGoodsStDB GetCampaignObjGoodsStDB()
        {
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8009";
#endif
            return (ICampaignObjGoodsStDB)Activator.GetObject(typeof(ICampaignObjGoodsStDB), string.Format("{0}/MyAppCampaignObjGoodsSt", wkStr));
        }
    }
}
