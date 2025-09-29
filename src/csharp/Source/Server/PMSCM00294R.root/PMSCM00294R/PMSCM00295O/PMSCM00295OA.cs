//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PMDBID管理マスタDBインターフェース
// プログラム概要   : PMDBID管理マスタDBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/08/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMDBID管理マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMDBID管理マスタDBインターフェースです。</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPmDbIdMngDB
    {
        /// <summary>
        /// 単一のPMDBID管理マスタ情報を取得します。
        /// </summary>
        /// <param name="pmDbIdMngObj">PmDbIdMngWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID管理マスタのキー値が一致するPMDBID管理マスタ情報を取得します。</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMSCM00296D", "Broadleaf.Application.Remoting.ParamData.PmDbIdMngWork")]
            ref object pmDbIdMngObj,
            int readMode);

        /// <summary>
        /// PMDBID管理マスタ情報リストを取得します。
        /// </summary>
        /// <param name="pmDbIdMngObj">抽出条件リスト(PmDbIdMngWork)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID管理マスタのキー値が一致するPMDBID管理マスタ情報を取得します。</br>
        int ReadAll(
            [CustomSerializationMethodParameterAttribute("PMSCM00296D", "Broadleaf.Application.Remoting.ParamData.PmDbIdMngWork")]
            ref object pmDbIdMngObj);

        /// <summary>
        /// PMDBID管理マスタ情報を物理削除します
        /// </summary>
        /// <param name="pmDbIdMngList">物理削除するPMDBID管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID管理マスタのキー値が一致するPMDBID管理マスタ情報を物理削除します。</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMSCM00296D", "Broadleaf.Application.Remoting.ParamData.PmDbIdMngWork")]
            object pmDbIdMngList);

        /// <summary>
        /// PMDBID管理マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="pmDbIdMngList">検索結果</param>
        /// <param name="pmDbIdMngObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID管理マスタのキー値が一致する、全てのPMDBID管理マスタ情報を取得します。</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMSCM00296D", "Broadleaf.Application.Remoting.ParamData.PmDbIdMngWork")]
            ref object pmDbIdMngList,
            object pmDbIdMngObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PMDBID管理マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="pmDbIdMngList">追加・更新するPMDBID管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngList に格納されているPMDBID管理マスタ情報を追加・更新します。</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMSCM00296D", "Broadleaf.Application.Remoting.ParamData.PmDbIdMngWork")]
            ref object pmDbIdMngList);

        /// <summary>
        /// PMDBID管理マスタ情報を論理削除します。
        /// </summary>
        /// <param name="pmDbIdMngList">論理削除するPMDBID管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngWord に格納されているPMDBID管理マスタ情報を論理削除します。</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM00296D", "Broadleaf.Application.Remoting.ParamData.PmDbIdMngWork")]
            ref object pmDbIdMngList);

        /// <summary>
        /// PMDBID管理マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="pmDbIdMngList">論理削除を解除するPMDBID管理マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngWord に格納されているPMDBID管理マスタ情報の論理削除を解除します。</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM00296D", "Broadleaf.Application.Remoting.ParamData.PmDbIdMngWork")]
            ref object pmDbIdMngList);
    }
}