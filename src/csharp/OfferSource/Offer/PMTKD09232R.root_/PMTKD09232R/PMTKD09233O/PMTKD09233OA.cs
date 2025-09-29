//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : レコメンド商品関連設定マスタ（提供）
// プログラム概要   : レコメンド商品関連設定マスタ（提供）DBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 作 成 日  2015.01.16  修正内容 : 新規作成
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
    /// レコメンド商品関連設定マスタ（提供）DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : レコメンド商品関連設定マスタ（提供）DBインターフェースです。</br>
    /// <br>Programmer : 西 毅</br>
    /// <br>Date       : 2015.01.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]
    public interface IRecGoodsLkODB
    {
        /// <summary>
        /// レコメンド商品関連設定マスタ（提供）検索処理
        /// </summary>
        /// <param name="RecGoodsLkOWorkList">レコメンド商品関連設定マスタ（提供）データリスト</param>
        /// <param name="parseRecGoodsLkOWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        //[MustCustomSerialization]
        int Search(
            //[CustomSerializationMethodParameterAttribute("PMTKD09234D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkOWork")]
            out object RecGoodsLkOWorkList, 
            RecGoodsLkOWork parseRecGoodsLkOWork, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// レコメンド商品関連設定マスタ（提供）検索処理
        /// </summary>
        /// <param name="RecGoodsLkOWorkList">レコメンド商品関連設定マスタ（提供）データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMTKD09234D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkOWork")]
            ref object RecGoodsLkOWorkList, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode);
    }
}