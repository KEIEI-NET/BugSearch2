//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2009/09/02  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// SCM系データファイルがオープン中の例外クラス
    /// </summary>
    public sealed class SCMFileOpeningException : ApplicationException
    {
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="innerException">元となった例外</param>
        public SCMFileOpeningException(
            string message,
            Exception innerException
        ) : base(message, innerException)
        { }
    }
}
