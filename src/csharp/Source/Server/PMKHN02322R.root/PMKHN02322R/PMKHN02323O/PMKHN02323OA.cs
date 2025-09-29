//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : テキスト出力操作ログ登録処理インターフェース
// プログラム概要   : テキスト出力操作ログ登録処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// 管理番号  11570163-00  作成担当 : 田建委
// 作 成 日  2019/08/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// テキスト出力操作ログ登録処理インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : テキスト出力操作ログ登録処理インターフェースです。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2019/08/12</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITextOutPutOprtnHisLogDB
    {
        /// <summary>
        /// テキスト出力操作ログ登録処理を行う。
        /// </summary>
        /// <param name="textOutPutOprtnHisLogWorkObj">テキスト出力操作ログ登録用対象ワーク</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>実行結果状態</returns>
        /// <remarks>
        /// <br>Note       : テキスト出力操作ログ登録処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/08/12</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(ref object textOutPutOprtnHisLogWorkObj, out string errMsg);
    }
}
