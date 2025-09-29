//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点管理企業設定マスタメンテナンス
// プログラム概要   : 拠点管理設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
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
    /// 企業コードマスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 企業コードマスタDBインターフェースです。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.3.27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IEnterpriseSetDB
    {
        /// <summary>
        /// 企業コードマスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">SecMngEpSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 企業コードマスタのキー値が一致する企業コードマスタ情報を物理削除します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.3.27</br>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMKYO09116D", "Broadleaf.Application.Remoting.ParamData.SecMngEpSetWork")]
            ref object parabyte);

        /// <summary>
        /// 企業コードマスタ情報のリストを取得します。
        /// </summary>
        /// <param name="outenterpriseSetList">検索結果</param>
        /// <param name="paraenterpriseSetWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 企業コードマスタのキー値が一致する、全ての企業コードマスタ情報を取得します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.3.27</br>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMKYO09116D", "Broadleaf.Application.Remoting.ParamData.SecMngEpSetWork")]
            out object outenterpriseSetList, object paraenterpriseSetWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 企業コードマスタ情報を追加・更新します。
        /// </summary>
        /// <param name="enterpriseSetWorkbyte">追加・更新する企業コードマスタ情報</param>
        /// <returns>STATUS</returns>
        /// <param name="writeMode">更新区分</param>
        /// <br>Note       : SecMngEpSetWork に格納されている企業コードマスタ情報を追加・更新します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.3.27</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMKYO09116D", "Broadleaf.Application.Remoting.ParamData.SecMngEpSetWork")]
            ref object enterpriseSetWorkbyte, int writeMode);

        /// <summary>
        /// 企業コードマスタ情報を論理削除します。
        /// </summary>
        /// <param name="enterpriseSetWork">論理削除する企業コードマスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SecMngEpSetWork に格納されている企業コードマスタ情報を論理削除します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.3.27</br>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMKYO09116D", "Broadleaf.Application.Remoting.ParamData.SecMngEpSetWork")]
            ref object enterpriseSetWork);

        /// <summary>
        /// 企業コードマスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="enterpriseSetWork">論理削除を解除する企業コードマスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SecMngEpSetWork に格納されている企業コードマスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.3.27</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMKYO09116D", "Broadleaf.Application.Remoting.ParamData.SecMngEpSetWork")]
            ref object enterpriseSetWork);
    }
}
