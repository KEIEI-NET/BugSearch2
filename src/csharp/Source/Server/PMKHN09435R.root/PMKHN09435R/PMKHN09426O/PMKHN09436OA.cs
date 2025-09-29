//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売価一括設定
// プログラム概要   : 売価一括設定
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/05/05  修正内容 : 新規作成
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
    /// DCコントロールDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : DCコントロールDBインターフェースです。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISaleRateDB
    {
        /// <summary>
        /// 掛率設定
        /// </summary>
        /// <param name="delparaObj">削除データリスト</param>
        /// <param name="updparaObj">更新データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        [MustCustomSerialization]
        int Save(object delparaObj, object updparaObj ,ref string message);
    }
}
