//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PCC品目マスタメンテ
// プログラム概要   : PCC品目マスタメンテDBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011.07.20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PCC品目マスタメンテDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC品目マスタメンテDBインターフェースです。</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date       : 2011.07.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    public interface IPccItemGrpDB
    {

        /// <summary>
        /// PCC品目設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemGrpWork")]
            ref object pccItemGrpWorkList,
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemStWork")]
            ref object pccItemStWorkList);

        /// <summary>
        /// PCC品目設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <param name="parsePccItemGrpWork">検索パラメータ</param>
        /// <param name="parsePccItemStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemGrpWork")]
            out object pccItemGrpWorkList,
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemStWork")]
            out object pccItemStWorkList,
            PccItemGrpWork parsePccItemGrpWork,
            PccItemStWork parsePccItemStWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PCC品目設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemGrpWork")]
            ref object pccItemGrpWorkList,
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemStWork")]
            ref object pccItemStWorkList,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PCC品目設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemGrpWork")]
            ref object pccItemGrpWorkList,
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemStWork")]
            ref object pccItemStWorkList);

        /// <summary>
        /// PCC品目設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemGrpWork")]
            ref object pccItemGrpWorkList,
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemStWork")]
            ref object pccItemStWorkList);

        /// <summary>
        /// PCC品目設定マスタメンテ復活処理
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC品目グループデータリスト</param>
        /// <param name="pccItemStWorkList">PCC品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemGrpWork")]
            ref object pccItemGrpWorkList,
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemStWork")]
            ref object pccItemStWorkList);

        /// <summary>
        /// PCCBLコードマスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pMBLGdsCdWorkList">PCCBLコードデータリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int WritePMBLGdsCd(
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PMBLGdsCdWork")]
            ref object pMBLGdsCdWorkList);

        /// <summary>
        /// PCCBLコードマスタメンテ検索処理
        /// </summary>
        /// <param name="pMBLGdsCdWork">PCCBLコードデータリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int ReadPMBLGdsCd(
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PMBLGdsCdWork")]
            ref object pMBLGdsCdWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PCCBLコードマスタメンテ検索処理
        /// </summary>
        /// <param name="pMBLGdsCdWorkList">PCCBLコードデータリスト</param>
        /// <param name="parsePMBLGdsCdWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchPMBLGdsCd(
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PMBLGdsCdWork")]
            out object pMBLGdsCdWorkList,
            PMBLGdsCdWork parsePMBLGdsCdWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PMBLコード,PCC品目グループ,PCC品目設定検索処理
        /// </summary>
        /// <param name="retInfosList">PMBLコード,PCC品目グループ,PCC品目設定データリスト</param>
        /// <param name="paraInfosList">PMBLコード,PCC品目グループ,PCC品目設定検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchFourInfos(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retInfosList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object paraInfosList,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);
    }
}