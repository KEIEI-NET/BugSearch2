//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   得意先（請求書）DBインターフェース
//                  :   PMKHN09085O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2008.06.06
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先（請求書）DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先（請求書）DBインターフェースです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustDmdSetDB
    {
        /// <summary>
        /// 単一の得意先（請求書）情報を取得します。
        /// </summary>
        /// <param name="custDmdSetObj">CustDmdSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先（請求書）のキー値が一致する得意先（請求書）情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.06</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09086D", "Broadleaf.Application.Remoting.ParamData.CustDmdSetWork")]
            ref object custDmdSetObj,
            int readMode);

        /// <summary>
        /// 得意先（請求書）情報を物理削除します
        /// </summary>
        /// <param name="custDmdSetList">物理削除する得意先（請求書）情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先（請求書）のキー値が一致する得意先（請求書）情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.06</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09086D", "Broadleaf.Application.Remoting.ParamData.CustDmdSetWork")]
            object custDmdSetList);

        /// <summary>
        /// 得意先（請求書）情報のリストを取得します。
        /// </summary>
        /// <param name="custDmdSetList">検索結果</param>
        /// <param name="custDmdSetObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先（請求書）のキー値が一致する、全ての得意先（請求書）情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09086D", "Broadleaf.Application.Remoting.ParamData.CustDmdSetWork")]
            ref object custDmdSetList,
            object custDmdSetObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 得意先（請求書）情報を追加・更新します。
        /// </summary>
        /// <param name="custDmdSetList">追加・更新する得意先（請求書）情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : custDmdSetList に格納されている得意先（請求書）情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09086D", "Broadleaf.Application.Remoting.ParamData.CustDmdSetWork")]
            ref object custDmdSetList);

        /// <summary>
        /// 得意先（請求書）情報を論理削除します。
        /// </summary>
        /// <param name="custDmdSetList">論理削除する得意先（請求書）情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : custDmdSetWork に格納されている得意先（請求書）情報を論理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09086D", "Broadleaf.Application.Remoting.ParamData.CustDmdSetWork")]
            ref object custDmdSetList);

        /// <summary>
        /// 得意先（請求書）情報の論理削除を解除します。
        /// </summary>
        /// <param name="custDmdSetList">論理削除を解除する得意先（請求書）情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : custDmdSetWork に格納されている得意先（請求書）情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09086D", "Broadleaf.Application.Remoting.ParamData.CustDmdSetWork")]
            ref object custDmdSetList);
    }
}
