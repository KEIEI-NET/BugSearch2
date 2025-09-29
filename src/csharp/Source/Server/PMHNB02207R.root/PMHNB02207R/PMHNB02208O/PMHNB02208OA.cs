//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売価原価アンマッチリスト
// プログラム概要   : 売価原価アンマッチリストDBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売価原価アンマッチリストDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売価原価アンマッチリストDBインターフェースです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.04.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IRateUnMatchDB
    {
        /// <summary>
        /// 売価原価アンマッチリストを取得します。
        /// </summary>
        /// <param name="unMatchList">アンマッチリスト</param>
        /// <param name="secCodes">拠点コード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売価原価アンマッチリスト情報を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.03</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMHNB02209D", "Broadleaf.Application.Remoting.ParamData.RateUnMatchWork")]
            out object unMatchList,
            string[] secCodes);

    }
}
