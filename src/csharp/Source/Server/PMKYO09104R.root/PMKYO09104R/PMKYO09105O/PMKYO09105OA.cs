//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点管理設定マスタメンテナンス
// プログラム概要   : 拠点管理設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/03/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 拠点管理設定マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 拠点管理設定マスタDBインターフェースです。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.03.27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISecMngSetDB
    {
        # region カスタムシリアライズ
        /// <summary>
        /// 拠点管理設定マスタのリストを取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outSecMngSetList">検索結果</param>
        /// <param name="paraSecMngSetWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理設定マスタのキー値が一致する、全ての拠点管理設定マスタ情報を取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMKYO09106D", "Broadleaf.Application.Remoting.ParamData.SecMngSetWork")]
                  out object outSecMngSetList, object paraSecMngSetWork,int readMode, ConstantManagement.LogicalMode logicalMode);
        # endregion

        /// <summary>
        /// 拠点管理設定マスタ情報を追加・更新します。
        /// </summary>
        /// <remarks>
        /// <param name="paraSecMngSetWork">SecMngSetWorkオブジェクト</param>
        /// <param name="writeMode">更新区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理設定マスタを追加・更新します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMKYO09106D", "Broadleaf.Application.Remoting.ParamData.SecMngSetWork")]
            ref object paraSecMngSetWork, int writeMode);

        /// <summary>
        ///  拠点管理設定マスタ情報を物理削除します
        /// </summary>
        /// <remarks>
        /// <param name="paraSecMngSetWork">SecMngSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理設定マスタのキー値が一致する 拠点管理設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMKYO09106D", "Broadleaf.Application.Remoting.ParamData.SecMngSetWork")]
            ref object paraSecMngSetWork);

        /// <summary>
        /// 拠点管理設定マスタ情報を論理削除します。
        /// </summary>
        /// <remarks>
        /// <param name="paraSecMngSetWork">SecMngSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理設定マスタ情報を論理削除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMKYO09106D", "Broadleaf.Application.Remoting.ParamData.SecMngSetWork")]
            ref object paraSecMngSetWork);

        /// <summary>
        /// 拠点管理設定マスタ情報の論理削除を解除します。
        /// </summary>
        /// <remarks>
        /// <param name="paraSecMngSetWork">論理削除を解除する拠点管理設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理設定マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMKYO09106D", "Broadleaf.Application.Remoting.ParamData.SecMngSetWork")]
            ref object paraSecMngSetWork);
    }
}
