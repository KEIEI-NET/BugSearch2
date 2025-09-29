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
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// キャンペーン対象商品設定マスタ一括登録DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン対象商品設定マスタ一括登録DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 鄧潘ハン</br>
    /// <br>Date       : 2011/05/20</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICampaignLoginDB
    {
    
        /// <summary>
        /// 商品マスタ(ユーザー)検索処理
        /// </summary>
        /// <param name="campaignGoodsDataWorkList">検索結果</param>
        /// <param name="campaignGoodsDataWork">検索条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行う。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("MAKHN09286D", "Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
			ref object campaignGoodsDataWorkList,
            object campaignGoodsDataWork
           );

        /// <summary>
        /// キャンペーン管理マスタ検索処理
        /// </summary>
        /// <param name="campaignMngList">検索結果</param>
        /// <param name="campaignGoodsDataWork">検索条件</param>
        /// <param name="readMode">readMode</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行う。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09627D", "Broadleaf.Application.Remoting.ParamData.CampaignMngWork")]
			ref object campaignMngList,
            object campaignGoodsDataWork, 
            int readMode
           );

        /// <summary>
        /// キャンペーン管理マスタの登録処理
        /// </summary>
        /// <param name="campaignGoodsDataWorkList">登録品物リスト</param>
        /// <param name="campaignGoodsData">条件</param>
        /// <param name="objcampaignLinklist">得意先リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 登録条件を行う。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        int Write(
        [CustomSerializationMethodParameterAttribute("PMKHN09627D", "Broadleaf.Application.Remoting.ParamData.CampaignMngWork")]
			object campaignGoodsDataWorkList, 
            object campaignGoodsData, 
            object objcampaignLinklist
      　 );

        /// <summary>
        /// キャンペーン名称設定マスタ検索処理
        /// </summary>
        /// <param name="campaignStList">検索結果</param>
        /// <param name="CampaignStWork">検索条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン名称設定マスタ検索処理を行う。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchCampaignSt(
            [CustomSerializationMethodParameterAttribute("PMKHN09566D", "Broadleaf.Application.Remoting.ParamData.CampaignStWork")]
            ref object campaignStList,
            object CampaignStWork
           );

        /// <summary>
        /// キャンペーン対象得意先設定マスタ検索処理
        /// </summary>
        /// <param name="searchParaObj">検索条件</param>
        /// <param name="objcampaignLinkList">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン対象得意先設定マスタ検索処理を行う。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchCustomer(
            [CustomSerializationMethodParameterAttribute("PMKHN09576D", "Broadleaf.Application.Remoting.ParamData.CampaignLinkWork")]
            object searchParaObj,
            ref object objcampaignLinkList
          ); 
    }
}
