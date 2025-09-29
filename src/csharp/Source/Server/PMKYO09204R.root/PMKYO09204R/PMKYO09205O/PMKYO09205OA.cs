//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送受信対象設定マスタメンテナンス
// プログラム概要   : 送受信対象設定の変更を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/04/22  修正内容 : 新規作成
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
    /// 送受信対象設定マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 送受信対象設定マスタDBインターフェースです。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.04.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISendSetDB
    {
        /// <summary>
        /// 送受信対象設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="outSecMngSndRcvList">検索結果</param>
        /// <param name="paraSecMngSndRcvWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送受信対象設定マスタのキー値が一致する、全ての送受信対象設定マスタ情報を取得します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMKYO09206D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvWork")]
            out object outSecMngSndRcvList, object paraSecMngSndRcvWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 送受信対象詳細設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="outSecMngSndRcvDtlList">検索結果</param>
        /// <param name="paraSecMngSndRcvDtlWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送受信対象詳細設定マスタのキー値が一致する、全ての送受信対象詳細設定マスタ情報を取得します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        [MustCustomSerialization]
        int SearchDtl([CustomSerializationMethodParameterAttribute("PMKYO09206D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvDtlWork")]
            out object outSecMngSndRcvDtlList, object paraSecMngSndRcvDtlWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 送受信対象マスタ情報を更新します。
        /// </summary>
        /// <param name="objsecMngSndRcvWorkList">更新する送受信対象マスタ情報</param>
        /// <param name="objsecMngSndRcvDtlWorkList">更新する送受信対象詳細マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <param name="writeMode">更新区分</param>
        /// <br>Note       : SecMngEpSetWork に格納されている送受信対象マスタ情報を更新します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMKYO09206D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvWork")]
            ref object objsecMngSndRcvWorkList,
            [CustomSerializationMethodParameterAttribute("PMKYO09206D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvDtlWork")]
            ref object objsecMngSndRcvDtlWorkList, int writeMode);
    }
}
