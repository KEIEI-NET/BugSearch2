//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   離島価格マスタDBインターフェース
//                  :   PMKHN09045O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008　長内 数馬
// Date             :   2008.06.10
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
    /// 離島価格マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 離島価格マスタDBインターフェースです。</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IIsolIslandPrcDB
    {
        /// <summary>
        /// 単一の離島価格マスタ情報を取得します。
        /// </summary>
        /// <param name="isolIslandPrcObj">IsolIslandPrcWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 離島価格マスタのキー値が一致する離島価格マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09046D", "Broadleaf.Application.Remoting.ParamData.IsolIslandPrcWork")]
            ref object isolIslandPrcObj,
            int readMode);

        /// <summary>
        /// 離島価格マスタ情報を物理削除します
        /// </summary>
        /// <param name="isolIslandPrcList">物理削除する離島価格マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 離島価格マスタのキー値が一致する離島価格マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09046D", "Broadleaf.Application.Remoting.ParamData.IsolIslandPrcWork")]
            object isolIslandPrcList);

        /// <summary>
        /// 離島価格マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="isolIslandPrcList">検索結果</param>
        /// <param name="isolIslandPrcObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 離島価格マスタのキー値が一致する、全ての離島価格マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09046D", "Broadleaf.Application.Remoting.ParamData.IsolIslandPrcWork")]
            ref object isolIslandPrcList,
            object isolIslandPrcObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 離島価格マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="isolIslandPrcList">追加・更新する離島価格マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : isolIslandPrcList に格納されている離島価格マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09046D", "Broadleaf.Application.Remoting.ParamData.IsolIslandPrcWork")]
            ref object isolIslandPrcList);

        /// <summary>
        /// 離島価格マスタ情報を論理削除します。
        /// </summary>
        /// <param name="isolIslandPrcList">論理削除する離島価格マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : isolIslandPrcWork に格納されている離島価格マスタ情報を論理削除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09046D", "Broadleaf.Application.Remoting.ParamData.IsolIslandPrcWork")]
            ref object isolIslandPrcList);

        /// <summary>
        /// 離島価格マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="isolIslandPrcList">論理削除を解除する離島価格マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : isolIslandPrcWork に格納されている離島価格マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09046D", "Broadleaf.Application.Remoting.ParamData.IsolIslandPrcWork")]
            ref object isolIslandPrcList);
    }
}
