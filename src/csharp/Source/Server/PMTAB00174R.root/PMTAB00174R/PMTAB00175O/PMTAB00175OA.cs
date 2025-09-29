//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 受注マスタ(車両)DBインターフェース
// プログラム概要   : 受注マスタ(車両)DBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : huangt
// 作 成 日  2013/05/30  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 受注マスタ(車両)DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 受注マスタ(車両)DBインターフェースです。</br>
    /// <br>Programmer : huangt</br>
    /// <br>Date       : 2013/05/30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPmTabAcpOdrCarDB
    { 
        /// <summary>
        /// 単一の受注マスタ(車両)情報を取得します。
        /// </summary>
        /// <param name="pmTabAcceptOdrCarObj">PmTabAcpOdrCarWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する受注マスタ(車両)情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMTAB00176D", "Broadleaf.Application.Remoting.ParamData.PmTabAcpOdrCarWork")]
            ref object pmTabAcceptOdrCarObj,
            int readMode);

        /// <summary>
        /// 受注マスタ(車両)情報リストを取得します。
        /// </summary>
        /// <param name="pmTabAcceptOdrCarObj">抽出条件リスト(PmTabAcpOdrCarWork)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する受注マスタ(車両)情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        int ReadAll(
            [CustomSerializationMethodParameterAttribute("PMTAB00176D", "Broadleaf.Application.Remoting.ParamData.PmTabAcpOdrCarWork")]
            ref object pmTabAcceptOdrCarObj);

        /// <summary>
        /// 受注マスタ(車両)情報を物理削除します
        /// </summary>
        /// <param name="pmTabAcceptOdrCarList">物理削除する受注マスタ(車両)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する受注マスタ(車両)情報を物理削除します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMTAB00176D", "Broadleaf.Application.Remoting.ParamData.PmTabAcpOdrCarWork")]
            object pmTabAcceptOdrCarList);

        /// <summary>
        /// 受注マスタ(車両)情報のリストを取得します。
        /// </summary>
        /// <param name="pmTabAcceptOdrCarList">検索結果</param>
        /// <param name="pmTabAcceptOdrCarObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する、全ての受注マスタ(車両)情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTAB00176D", "Broadleaf.Application.Remoting.ParamData.PmTabAcpOdrCarWork")]
            ref object pmTabAcceptOdrCarList,
            object pmTabAcceptOdrCarObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 受注マスタ(車両)情報を追加・更新します。
        /// </summary>
        /// <param name="pmTabAcceptOdrCarList">追加・更新する受注マスタ(車両)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcceptOdrCarList に格納されている受注マスタ(車両)情報を追加・更新します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMTAB00176D", "Broadleaf.Application.Remoting.ParamData.PmTabAcpOdrCarWork")]
            ref object pmTabAcceptOdrCarList);

        /// <summary>
        /// 受注マスタ(車両)情報を論理削除します。
        /// </summary>
        /// <param name="pmTabAcceptOdrCarList">論理削除する受注マスタ(車両)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcceptOdrCarWork に格納されている受注マスタ(車両)情報を論理削除します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMTAB00176D", "Broadleaf.Application.Remoting.ParamData.PmTabAcpOdrCarWork")]
            ref object pmTabAcceptOdrCarList);

        /// <summary>
        /// 受注マスタ(車両)情報の論理削除を解除します。
        /// </summary>
        /// <param name="pmTabAcceptOdrCarList">論理削除を解除する受注マスタ(車両)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcceptOdrCarWork に格納されている受注マスタ(車両)情報の論理削除を解除します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMTAB00176D", "Broadleaf.Application.Remoting.ParamData.PmTabAcpOdrCarWork")]
            ref object pmTabAcceptOdrCarList);
    }
}
