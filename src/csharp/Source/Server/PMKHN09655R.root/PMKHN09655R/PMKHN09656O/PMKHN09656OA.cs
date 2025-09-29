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
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// キャンペーン目標設定マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン目標設定マスタDBインターフェースです。</br>
    /// <br>Programmer : 徐佳</br>
    /// <br>Date       : 2011/04/27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICampaignTargetUDB
    {
        /// <summary>
        /// 単一のキャンペーン目標設定マスタ情報を取得します。
        /// </summary>
        /// <param name="campaignTargetObj">CampaignTargetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン目標設定マスタのキー値が一致するキャンペーン目標設定マスタ情報を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09657D", "Broadleaf.Application.Remoting.ParamData.CampaignTargetWork")]
            ref object campaignTargetObj,
            int readMode);

        /// <summary>
        /// キャンペーン目標設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">物理削除するキャンペーン目標設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン目標設定マスタのキー値が一致するキャンペーン目標設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09657D", "Broadleaf.Application.Remoting.ParamData.CampaignTargetWork")]
            byte[] parabyte);

        /// <summary>
        /// キャンペーン目標設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="campaignTargetList">検索結果</param>
        /// <param name="campaignTargetObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン目標設定マスタのキー値が一致する、全てのキャンペーン目標設定マスタ情報を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09657D", "Broadleaf.Application.Remoting.ParamData.CampaignTargetWork")]
            ref object campaignTargetList,
            object campaignTargetObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// キャンペーン目標設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="campaignTargetList">追加・更新するキャンペーン目標設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetList に格納されているキャンペーン目標設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09657D", "Broadleaf.Application.Remoting.ParamData.CampaignTargetWork")]
            ref object campaignTargetList);

        /// <summary>
        /// キャンペーン目標設定マスタ情報を論理削除します。
        /// </summary>
        /// <param name="campaignTargetList">論理削除するキャンペーン目標設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUWork に格納されているキャンペーン目標設定マスタ情報を論理削除します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09657D", "Broadleaf.Application.Remoting.ParamData.CampaignTargetWork")]
            ref object campaignTargetList);

        /// <summary>
        /// キャンペーン目標設定マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="campaignTargetList">論理削除を解除するキャンペーン目標設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUWork に格納されているキャンペーン目標設定マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09657D", "Broadleaf.Application.Remoting.ParamData.CampaignTargetWork")]
            ref object campaignTargetList);
    }
}
