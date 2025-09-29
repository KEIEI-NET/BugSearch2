//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PCCキャンペーン設定マスタメンテ
// プログラム概要   : PCCキャンペーン設定マスタメンテDBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011.08.11  修正内容 : 新規作成
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
    /// PCCキャンペーン設定マスタメンテDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCCキャンペーン設定マスタメンテDBインターフェースです。</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date       : 2011.08.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    public interface IPccCpMsgStDB
    {

        /// <summary>
        /// PCCキャンペーンメッセージ設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージマスタ設定データリスト</param>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定データリスト</param>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpMsgStWork")]
            ref object pccCpMsgStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpTgtStWork")]
            ref object pccCpTgtStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpItmStWork")]
            ref object pccCpItmStWorkList);

		/// <summary>
		/// PCCキャンペーン設定情報検索処理
		/// </summary>
		/// <param name="paraObj">検索パラメータ</param>
		/// <param name="pccCpMsgStWorkObj">PCCキャンペーンメッセージ設定情報</param>
		/// <param name="pccCpItmStWorkObj">PCCキャンペーン品目設定情報</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定された条件のPCCキャンペーン設定情報を戻します。</br>
        /// <br>Programmer : 黄海霞</br>
		/// <br>Date       : 2011.08.11</br>
		/// </remarks>
		[MustCustomSerialization]
		int SearchPccCampaign(
			object paraObj,
			[CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpMsgStWork")]
            out object pccCpMsgStWorkObj,
			[CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpItmStWork")]
            out object pccCpItmStWorkObj,
		    out string errMsg);

        /// <summary>
        /// PCCキャンペーンメッセージ設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージマスタ設定データリスト</param>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定データリスト</param>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定データリスト</param>
        /// <param name="parsePccCpMsgStWork">検索パラメータ</param>
        /// <param name="parsePccCpTgtStWork">検索パラメータ</param>
        /// <param name="parsePccCpItmStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="dateSearchFlag">0:日付条件検索なし1：日付条件検索</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpMsgStWork")]
            out object pccCpMsgStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpTgtStWork")]
            out object pccCpTgtStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpItmStWork")]
            out object pccCpItmStWorkList, 
            PccCpMsgStWork parsePccCpMsgStWork,
            PccCpTgtStWork parsePccCpTgtStWork,
            PccCpItmStWork parsePccCpItmStWork,
            int readMode, 
            ConstantManagement.LogicalMode logicalMode,
            int dateSearchFlag);

        /// <summary>
        /// PCCキャンペーンメッセージ設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージマスタ設定データリスト</param>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定データリスト</param>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="dateSearchFlag">0:日付条件検索なし1：日付条件検索</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpMsgStWork")]
            ref object pccCpMsgStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpTgtStWork")]
            ref object pccCpTgtStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpItmStWork")]
            ref object pccCpItmStWorkList, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode,
           int dateSearchFlag);

        /// <summary>
        /// PCCキャンペーンメッセージ設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージマスタ設定データリスト</param>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定データリスト</param>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpMsgStWork")]
            ref object pccCpMsgStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpTgtStWork")]
            ref object pccCpTgtStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpItmStWork")]
            ref object pccCpItmStWorkList);

        /// <summary>
        /// PCCキャンペーンメッセージ設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージマスタ設定データリスト</param>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定データリスト</param>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpMsgStWork")]
            ref object pccCpMsgStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpTgtStWork")]
            ref object pccCpTgtStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpItmStWork")]
            ref object pccCpItmStWorkList);

        /// <summary>
        /// PCCキャンペーンメッセージ設定マスタメンテ復活処理
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージマスタ設定データリスト</param>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定データリスト</param>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpMsgStWork")]
            ref object pccCpMsgStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpTgtStWork")]
            ref object pccCpTgtStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpItmStWork")]
            ref object pccCpItmStWorkList);

    }
}