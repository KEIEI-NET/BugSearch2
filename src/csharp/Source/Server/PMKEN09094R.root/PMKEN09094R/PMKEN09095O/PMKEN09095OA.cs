//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   部品代替マスタDBインターフェース
//                  :   PMKEN09095O.DLL
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
    /// 部品代替マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部品代替マスタDBインターフェースです。</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPartsSubstUDB
    {
        /// <summary>
        /// 単一の部品代替マスタ情報を取得します。
        /// </summary>
        /// <param name="partsSubstUObj">PartsSubstUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部品代替マスタのキー値が一致する部品代替マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKEN09096D", "Broadleaf.Application.Remoting.ParamData.PartsSubstUWork")]
            ref object partsSubstUObj,
            int readMode);

        /// <summary>
        /// 部品代替マスタ情報を物理削除します
        /// </summary>
        /// <param name="partsSubstUList">物理削除する部品代替マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部品代替マスタのキー値が一致する部品代替マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKEN09096D", "Broadleaf.Application.Remoting.ParamData.PartsSubstUWork")]
            object partsSubstUList);

        /// <summary>
        /// 部品代替マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="partsSubstUList">検索結果</param>
        /// <param name="partsSubstUObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部品代替マスタのキー値が一致する、全ての部品代替マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKEN09096D", "Broadleaf.Application.Remoting.ParamData.PartsSubstUWork")]
            ref object partsSubstUList,
            object partsSubstUObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 部品代替マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="partsSubstUList">追加・更新する部品代替マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUList に格納されている部品代替マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKEN09096D", "Broadleaf.Application.Remoting.ParamData.PartsSubstUWork")]
            ref object partsSubstUList);

        /// <summary>
        /// 部品代替マスタ情報を論理削除します。
        /// </summary>
        /// <param name="partsSubstUList">論理削除する部品代替マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUWork に格納されている部品代替マスタ情報を論理削除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKEN09096D", "Broadleaf.Application.Remoting.ParamData.PartsSubstUWork")]
            ref object partsSubstUList);

        /// <summary>
        /// 部品代替マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="partsSubstUList">論理削除を解除する部品代替マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUWork に格納されている部品代替マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKEN09096D","Broadleaf.Application.Remoting.ParamData.PartsSubstUWork")]
            ref object partsSubstUList);
    }
}
