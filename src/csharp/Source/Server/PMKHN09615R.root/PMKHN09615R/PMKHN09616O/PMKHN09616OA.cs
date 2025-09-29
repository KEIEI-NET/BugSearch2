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
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// キャンペーン売価優先設定DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン売価優先設定DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 鄧潘ハン</br>
    /// <br>Date       : 2011/04/25</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICampaignPrcPrStDB
    {
        /// <summary>
        ///  キャンペーン売価優先設定設定LISTを全て戻します
        /// </summary>
        /// <param name="outCampaignPrcPrSt">検索結果</param>
        /// <param name="paraCampaignPrcPrStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09617D", "Broadleaf.Application.Remoting.ParamData.CampaignPrcPrStWork")]
			out object outCampaignPrcPrSt,
            object paraCampaignPrcPrStWork,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 指定されたキャンペーン売価優先設定Guidのキャンペーン売価優先設定を戻します
        /// </summary>
        /// <param name="parabyte">CampaignPrcPrStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :  指定されたキャンペーン売価優先設定Guidのキャンペーン売価優先設定を戻します</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        int Read(ref byte[] parabyte, int readMode);
        
        /// <summary>
        /// キャンペーン売価優先設定マスタ情報を論理削除します。
        /// </summary>
        /// <param name="campaignPrcPrStWork">論理削除するキャンペーン売価優先設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMKHN09617D", "Broadleaf.Application.Remoting.ParamData.CampaignPrcPrStWork")]
            ref object campaignPrcPrStWork);

        /// <summary>
        /// キャンペーン売価優先設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="campaignPrcPrStWorkbyte">追加・更新するキャンペーン売価優先設定マスタ情報</param>
        /// <param name="writeMode">更新区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMKHN09617D", "Broadleaf.Application.Remoting.ParamData.CampaignPrcPrStWork")]
            ref object campaignPrcPrStWorkbyte, int writeMode);

        /// <summary>
        /// キャンペーン売価優先設定マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="campaignPrcPrStWork">論理削除を解除するキャンペーン売価優先設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMKHN09617D", "Broadleaf.Application.Remoting.ParamData.CampaignPrcPrStWork")]
            ref object campaignPrcPrStWork);

        /// <summary>
        /// キャンペーン売価優先設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">CampaignPrcPrStWorkブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン売価優先設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        int Delete(byte[] parabyte);

      
    }
}
