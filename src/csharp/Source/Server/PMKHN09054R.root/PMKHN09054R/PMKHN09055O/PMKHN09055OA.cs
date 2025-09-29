//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   部位マスタDBインターフェース
//                  :   PMKHN09055O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008　長内　数馬
// Date             :   2008.06.11
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
    /// 部位マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部位マスタDBインターフェースです。</br>
    /// <br>Programmer : 22008　長内　数馬</br>
    /// <br>Date       : 2008.06.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPartsPosCodeUDB
    {
        /// <summary>
        /// 単一の部位マスタ情報を取得します。
        /// </summary>
        /// <param name="partsPosCodeUObj">PartsPosCodeUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部位マスタのキー値が一致する部位マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09056D", "Broadleaf.Application.Remoting.ParamData.PartsPosCodeUWork")]
            ref object partsPosCodeUObj,
            int readMode);

        /// <summary>
        /// 部位マスタ情報を物理削除します
        /// </summary>
        /// <param name="partsPosCodeUList">物理削除する部位マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部位マスタのキー値が一致する部位マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09056D", "Broadleaf.Application.Remoting.ParamData.PartsPosCodeUWork")]
            object partsPosCodeUList);

        /// <summary>
        /// 部位マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="partsPosCodeUList">検索結果</param>
        /// <param name="partsPosCodeUObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部位マスタのキー値が一致する、全ての部位マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09056D", "Broadleaf.Application.Remoting.ParamData.PartsPosCodeUWork")]
            ref object partsPosCodeUList,
            object partsPosCodeUObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 部位マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="partsPosCodeUList">追加・更新する部位マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUList に格納されている部位マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09056D", "Broadleaf.Application.Remoting.ParamData.PartsPosCodeUWork")]
            ref object partsPosCodeUList);

        /// <summary>
        /// 部位マスタ情報を論理削除します。
        /// </summary>
        /// <param name="partsPosCodeUList">論理削除する部位マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUWork に格納されている部位マスタ情報を論理削除します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09056D", "Broadleaf.Application.Remoting.ParamData.PartsPosCodeUWork")]
            ref object partsPosCodeUList);

        /// <summary>
        /// 部位マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="partsPosCodeUList">論理削除を解除する部位マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUWork に格納されている部位マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09056D","Broadleaf.Application.Remoting.ParamData.PartsPosCodeUWork")]
            ref object partsPosCodeUList);
    }
}
