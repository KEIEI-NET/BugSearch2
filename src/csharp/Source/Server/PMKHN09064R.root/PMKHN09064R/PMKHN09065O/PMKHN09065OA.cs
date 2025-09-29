//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   BLグループマスタDBインターフェース
//                  :   PMKHN09065O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2008.06.05
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
    /// BLグループマスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLグループマスタDBインターフェースです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.06.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IBLGroupUDB
    {
        /// <summary>
        /// 単一のBLグループマスタ情報を取得します。
        /// </summary>
        /// <param name="blGroupUObj">BLGroupUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLグループマスタのキー値が一致するBLグループマスタ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09066D", "Broadleaf.Application.Remoting.ParamData.BLGroupUWork")]
            ref object blGroupUObj,
            int readMode);

        /// <summary>
        /// BLグループマスタ情報を物理削除します
        /// </summary>
        /// <param name="blGroupUList">物理削除するBLグループマスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLグループマスタのキー値が一致するBLグループマスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09066D", "Broadleaf.Application.Remoting.ParamData.BLGroupUWork")]
            object blGroupUList);

        /// <summary>
        /// BLグループマスタ情報のリストを取得します。
        /// </summary>
        /// <param name="blGroupUList">検索結果</param>
        /// <param name="blGroupUObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLグループマスタのキー値が一致する、全てのBLグループマスタ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09066D", "Broadleaf.Application.Remoting.ParamData.BLGroupUWork")]
            ref object blGroupUList,
            object blGroupUObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// BLグループマスタ情報を追加・更新します。
        /// </summary>
        /// <param name="blGroupUList">追加・更新するBLグループマスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : blGroupUList に格納されているBLグループマスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09066D", "Broadleaf.Application.Remoting.ParamData.BLGroupUWork")]
            ref object blGroupUList);

        /// <summary>
        /// BLグループマスタ情報を論理削除します。
        /// </summary>
        /// <param name="blGroupUList">論理削除するBLグループマスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : blGroupUWork に格納されているBLグループマスタ情報を論理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09066D", "Broadleaf.Application.Remoting.ParamData.BLGroupUWork")]
            ref object blGroupUList);

        /// <summary>
        /// BLグループマスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="blGroupUList">論理削除を解除するBLグループマスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : blGroupUWork に格納されているBLグループマスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09066D","Broadleaf.Application.Remoting.ParamData.BLGroupUWork")]
            ref object blGroupUList);
    }
}
