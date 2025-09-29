//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタ引用登録
// プログラム概要   : 掛率マスタ引用登録
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 掛率マスタ引用登録DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率マスタ引用登録DBインターフェースです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IRateQuoteDB
    {
        /// <summary>
        /// データ追加処理
        /// </summary>
        /// <param name="rateInsertList">追加リスト</param>
        /// <param name="rateDeleteList">削除リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
            ref object rateInsertList,
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
            ref object rateDeleteList);

        /// <summary>
        /// データ追加・更新処理
        /// </summary>
        /// <param name="rateInsertList">追加リスト</param>
        /// <param name="rateUpdateList">更新リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        [MustCustomSerialization]
        int Update(
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
            ref object rateInsertList,
           [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
            ref object rateUpdateList);
    }
}
