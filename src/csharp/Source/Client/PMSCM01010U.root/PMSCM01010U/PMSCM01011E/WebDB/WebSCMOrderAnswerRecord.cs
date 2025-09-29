//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.UIData.WebDB
{
    using RecordType = Broadleaf.Application.UIData.ScmOdDtAns;

    /// <summary>
    /// Web-DB SCM受注明細データ(回答)のレコードクラス
    /// </summary>
    public class WebSCMOrderAnswerRecord : WebSCMOrderAnswerWrapper
    {
        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public WebSCMOrderAnswerRecord() : base() { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realRecord">本物のレコード</param>
        public WebSCMOrderAnswerRecord(RecordType realRecord) : base(realRecord) { }

        #endregion // </Constructor>
    }
}
