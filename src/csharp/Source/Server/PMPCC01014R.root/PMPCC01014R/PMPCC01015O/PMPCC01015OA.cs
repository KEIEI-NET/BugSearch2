//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メールメッセージ設定処理
// プログラム概要   : メールメッセージ設定処理DBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011.08.09  修正内容 : 新規作成
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
    /// メールメッセージ設定処理DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : メールメッセージ設定処理DBインターフェースです。</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date       : 2011.08.09</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    public interface IPccMailDtDB
    {

        /// <summary>
        /// メールメッセージ設定処理登録、更新処理
        /// </summary>
        /// <param name="pccMailDtWorkList">PCCメールデータリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMPCC01016D", "Broadleaf.Application.Remoting.ParamData.PccMailDtWork")]
            ref object pccMailDtWorkList);

        /// <summary>
        /// メールメッセージ設定検索処理
        /// </summary>
        /// <param name="pccMailDtWorkList">PCCメールデータリスト</param>
        /// <param name="parsePccMailDtWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMPCC01016D", "Broadleaf.Application.Remoting.ParamData.PccMailDtWork")]
            ref object pccMailDtWorkList, 
            PccMailDtWork parsePccMailDtWork, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// メールメッセージ設定検索処理
        /// </summary>
        /// <param name="pccMailDtWorkList">PCCメールデータリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMPCC01016D", "Broadleaf.Application.Remoting.ParamData.PccMailDtWork")]
            ref object pccMailDtWorkList, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// メールメッセージ設定論理削除処理
        /// </summary>
        /// <param name="pccMailDtWorkList">PCCメールデータリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC01016D", "Broadleaf.Application.Remoting.ParamData.PccMailDtWork")]
            ref object pccMailDtWorkList);

        /// <summary>
        /// メールメッセージ設定物理削除処理
        /// </summary>
        /// <param name="pccMailDtWorkList">PCCメールデータリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMPCC01016D", "Broadleaf.Application.Remoting.ParamData.PccMailDtWork")]
            ref object pccMailDtWorkList);

        /// <summary>
        /// メールメッセージ設定復活処理
        /// </summary>
        /// <param name="pccMailDtWorkList">PCCメールデータリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC01016D", "Broadleaf.Application.Remoting.ParamData.PccMailDtWork")]
            ref object pccMailDtWorkList);

    }
}