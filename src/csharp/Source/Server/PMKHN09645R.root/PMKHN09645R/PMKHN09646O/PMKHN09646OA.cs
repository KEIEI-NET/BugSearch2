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
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// キャンペーン対象商品設定マスタ一括削除DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン対象商品設定マスタ一括削除DBインターフェースです。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICampaignGoodsStDB
    {
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="searchParaObj">検索条件</param>
        /// <param name="objCampaignMngStWorkList">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行う。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            object searchParaObj,
            [CustomSerializationMethodParameterAttribute("PMKHN09647D", "Broadleaf.Application.Remoting.ParamData.CampaignMngStWork")]
            ref object objCampaignMngStWorkList);

        /// <summary>
        /// 一括削除処理
        /// </summary>
        /// <param name="deleteParaObj">削除条件</param>
        /// <param name="campaignGoodsListobj">排他処理条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 一括削除処理を行う。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int DeleteAll(
            object campaignGoodsListobj,
            [CustomSerializationMethodParameterAttribute("PMKHN09647D", "Broadleaf.Application.Remoting.ParamData.CampaignGoodsDataWork")]
            ref object deleteParaObj);
    }
}
