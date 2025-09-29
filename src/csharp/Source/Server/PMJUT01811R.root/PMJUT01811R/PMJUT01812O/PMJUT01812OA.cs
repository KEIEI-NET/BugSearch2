//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   受注マスタ(車両)DBインターフェース
//                  :   PMJUT01812O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112　久保田
// Date             :   2008.05.28
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
    /// 受注マスタ(車両)DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 受注マスタ(車両)DBインターフェースです。</br>
    /// <br>Programmer : 21112　久保田</br>
    /// <br>Date       : 2008.05.28</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IAcceptOdrCarDB
    {
        /// <summary>
        /// 単一の受注マスタ(車両)情報を取得します。
        /// </summary>
        /// <param name="acceptOdrCarObj">AcceptOdrCarWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する受注マスタ(車両)情報を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMJUT01813D", "Broadleaf.Application.Remoting.ParamData.AcceptOdrCarWork")]
            ref object acceptOdrCarObj,
            int readMode);

        /// <summary>
        /// 受注マスタ(車両)情報リストを取得します。
        /// </summary>
        /// <param name="acceptOdrCarObj">抽出条件リスト(AcceptOdrCarWork)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する受注マスタ(車両)情報を取得します。</br>
        /// <br>Programmer : 22008　長内</br>
        /// <br>Date       : 2009.05.28</br>
        int ReadAll(
            [CustomSerializationMethodParameterAttribute("PMJUT01813D", "Broadleaf.Application.Remoting.ParamData.AcceptOdrCarWork")]
            ref object acceptOdrCarObj);
        
        /// <summary>
        /// 受注マスタ(車両)情報を物理削除します
        /// </summary>
        /// <param name="acceptOdrCarList">物理削除する受注マスタ(車両)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する受注マスタ(車両)情報を物理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            object acceptOdrCarList);

        /// <summary>
        /// 受注マスタ(車両)情報のリストを取得します。
        /// </summary>
        /// <param name="acceptOdrCarList">検索結果</param>
        /// <param name="acceptOdrCarObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する、全ての受注マスタ(車両)情報を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object acceptOdrCarList,
            object acceptOdrCarObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 受注マスタ(車両)情報を追加・更新します。
        /// </summary>
        /// <param name="acceptOdrCarList">追加・更新する受注マスタ(車両)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarList に格納されている受注マスタ(車両)情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object acceptOdrCarList);

        /// <summary>
        /// 受注マスタ(車両)情報を論理削除します。
        /// </summary>
        /// <param name="acceptOdrCarList">論理削除する受注マスタ(車両)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarWork に格納されている受注マスタ(車両)情報を論理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object acceptOdrCarList);

        /// <summary>
        /// 受注マスタ(車両)情報の論理削除を解除します。
        /// </summary>
        /// <param name="acceptOdrCarList">論理削除を解除する受注マスタ(車両)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarWork に格納されている受注マスタ(車両)情報の論理削除を解除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMJUT01813D","Broadleaf.Application.Remoting.ParamData.AcceptOdrCarWork")]
            ref object acceptOdrCarList);
    }
}
