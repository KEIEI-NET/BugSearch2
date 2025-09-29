//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PCC自社設定マスタメンテ
// プログラム概要   : PCC自社設定マスタメンテDBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011.08.04  修正内容 : 新規作成
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
    /// PCC自社設定マスタメンテDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC自社設定マスタメンテDBインターフェースです。</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date       : 2011.08.04</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    public interface IPccCmpnyStDB
    {

        /// <summary>
        /// PCC自社設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMPCC09016D", "Broadleaf.Application.Remoting.ParamData.PccCmpnyStWork")]
            ref object pccCmpnyStWorkList);

        /// <summary>
        /// PCC自社設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <param name="parsePccCmpnyStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMPCC09016D", "Broadleaf.Application.Remoting.ParamData.PccCmpnyStWork")]
            out object pccCmpnyStWorkList, 
            PccCmpnyStWork parsePccCmpnyStWork, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PCC自社設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMPCC09016D", "Broadleaf.Application.Remoting.ParamData.PccCmpnyStWork")]
            ref object pccCmpnyStWorkList, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PCC自社設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC09016D", "Broadleaf.Application.Remoting.ParamData.PccCmpnyStWork")]
            ref object pccCmpnyStWorkList);

        /// <summary>
        /// PCC自社設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMPCC09016D", "Broadleaf.Application.Remoting.ParamData.PccCmpnyStWork")]
            ref object pccCmpnyStWorkList);

        /// <summary>
        /// PCC自社設定マスタメンテ復活処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC09016D", "Broadleaf.Application.Remoting.ParamData.PccCmpnyStWork")]
            ref object pccCmpnyStWorkList);

    }
}