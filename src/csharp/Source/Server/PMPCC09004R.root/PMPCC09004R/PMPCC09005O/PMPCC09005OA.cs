//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PCC全体設定マスタ取得設定マスタメンテ
// プログラム概要   : PCC全体設定マスタ取得設定マスタメンテDBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葉巧燕
// 作 成 日  2011.08.01  修正内容 : 新規作成
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
    /// PCC全体設定マスタ取得設定マスタメンテDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC全体設定マスタ取得設定マスタメンテDBインターフェースです。</br>
    /// <br>Programmer : 葉巧燕</br>
    /// <br>Date       :2011.08.01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPccTtlStDB
    {

        /// <summary>
        /// PCC全体設定取得設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccTtlStObj">PCC全体設定取得設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       :2011.08.01</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMPCC09006D", "Broadleaf.Application.Remoting.ParamData.PccTtlStWork")]
            ref object pccTtlStObj,
            int readMode);


        /// <summary>
        /// PCC全体設定取得設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="pccTtlStList">PCC全体設定取得設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       :2011.08.01</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMPCC09006D", "Broadleaf.Application.Remoting.ParamData.PccTtlStWork")]
            ref object pccTtlStList);

        /// <summary>
        /// PCC全体設定取得設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccTtlStList">PCC全体設定取得設定データリスト</param>
        /// <param name="pccTtlStObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       :2011.08.01</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMPCC09006D", "Broadleaf.Application.Remoting.ParamData.PccTtlStWork")]
            ref object pccTtlStList,
            PccTtlStWork pccTtlStObj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PCC全体設定取得設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccTtlStList">PCC全体設定取得設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       :2011.08.01</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC09006D", "Broadleaf.Application.Remoting.ParamData.PccTtlStWork")]
            ref object pccTtlStList);

        /// <summary>
        /// PCC全体設定取得設定マスタメンテ復活処理
        /// </summary>
        /// <param name="pccTtlStList">PCC全体設定取得設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       :2011.08.01</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC09006D", "Broadleaf.Application.Remoting.ParamData.PccTtlStWork")]
            ref object pccTtlStList);


        /// <summary>
        /// PCC全体設定取得設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pccTtlStList">PCC全体設定取得設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       :2011.08.01</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMPCC09006D", "Broadleaf.Application.Remoting.ParamData.PccTtlStWork")]
            ref object pccTtlStList);



    }
}