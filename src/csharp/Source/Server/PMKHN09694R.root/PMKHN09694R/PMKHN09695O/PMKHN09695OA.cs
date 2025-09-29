//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : BLコード変換マスタ取得設定マスタメンテ
// プログラム概要   : BLコード変換マスタ取得設定マスタメンテDBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡 孝憲 30745
// 作 成 日  2012/08/01  修正内容 : 新規作成
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
    /// BLコード変換マスタ取得設定マスタメンテDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLコード変換マスタ取得設定マスタメンテDBインターフェースです。</br>
    /// <br>Programmer : 吉岡 孝憲 30745</br>
    /// <br>Date       :2012/08/01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IBLGoodsCdChgUDB
    {

        /// <summary>
        /// BLコード変換取得設定マスタメンテ検索処理
        /// </summary>
        /// <param name="blCodeChangeObj">BLコード変換取得設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       :2012/08/01</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09696D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdChgUWork")]
            ref object blCodeChangeObj,
            int readMode);


        /// <summary>
        /// BLコード変換取得設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="blCodeChangeList">BLコード変換取得設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       :2012/08/01</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09696D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdChgUWork")]
            ref object blCodeChangeList);

        /// <summary>
        /// BLコード変換取得設定マスタメンテ検索処理
        /// </summary>
        /// <param name="blCodeChangeList">BLコード変換取得設定データリスト</param>
        /// <param name="blCodeChangeObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       :2012/08/01</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09696D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdChgUWork")]
            ref object blCodeChangeList,
            BLGoodsCdChgUWork blCodeChangeObj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// BLコード変換取得設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="blCodeChangeList">BLコード変換取得設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       :2012/08/01</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09696D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdChgUWork")]
            ref object blCodeChangeList);

        /// <summary>
        /// BLコード変換取得設定マスタメンテ復活処理
        /// </summary>
        /// <param name="blCodeChangeList">BLコード変換取得設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       :2012/08/01</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09696D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdChgUWork")]
            ref object blCodeChangeList);


        /// <summary>
        /// BLコード変換取得設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="blCodeChangeList">BLコード変換取得設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       :2012/08/01</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09696D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdChgUWork")]
            ref object blCodeChangeList);



    }
}