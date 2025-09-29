//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ユーザー価格・原価一括設定
// プログラム概要   : ユーザー価格・原価一括設定
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/05/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// DCコントロールDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : DCコントロールDBインターフェースです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IUserPriceDB
    {
        /// <summary>
        /// 価格設定
        /// </summary>
        /// <param name="rateList">掛率マスタ</param>
        /// <param name="goodsPriceUList">価格マスタ</param>
        /// <param name="rateDelList">掛率マスタ削除リスト</param>
        /// <param name="goodsPriceUDelList">価格マスタ削除リスト</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>ステータス</returns>
        int Write(object rateList, object goodsPriceUList, object rateDelList, object goodsPriceUDelList, ref string msg);
    }
}
