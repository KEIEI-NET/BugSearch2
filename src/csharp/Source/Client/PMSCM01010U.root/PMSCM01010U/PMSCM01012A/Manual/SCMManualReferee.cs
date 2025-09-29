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
// 作 成 日  2009/05/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Manual
{
    using SCMOrderHeaderRecordType  = ISCMOrderHeaderRecord;    // SCM受注データ
    using SCMOrderCarRecordType     = ISCMOrderCarRecord;       // SCM受注データ(車両情報)
    using SCMOrderDetailRecordType  = ISCMOrderDetailRecord;    // SCM受注明細データ(問合せ・発注)
    using SCMOrderAnswerRecordType  = ISCMOrderAnswerRecord;    // SCM受注明細データ(回答)

    /// <summary>
    /// SCM手動用回答判定処理クラス
    /// </summary>
    public sealed class SCMManualReferee : SCMReferee
    {
        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="searcher">SCM検索処理</param>
        public SCMManualReferee(SCMSearcher searcher) : base(searcher) { }

        #endregion // </Constructor>
    }
}
