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
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/04/05  修正内容 : 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Auto
{
    using SCMOrderHeaderRecordType  = ISCMOrderHeaderRecord;    // SCM受注データ
    using SCMOrderCarRecordType     = ISCMOrderCarRecord;       // SCM受注データ(車両情報)
    using SCMOrderDetailRecordType  = ISCMOrderDetailRecord;    // SCM受注明細データ(問合せ・発注)
    using SCMOrderAnswerRecordType  = ISCMOrderAnswerRecord;    // SCM受注明細データ(回答)

    /// <summary>
    /// SCM自動回答処理クラス
    /// </summary>
    public sealed class SCMAutoRespondent : SCMRespondent
    {
        private const string MY_NAME = "SCMAutoRespondent"; // ログ用

        #region <Constructor>

        // DEL 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
        #region 削除コード

        ///// <summary>
        ///// カスタムコンストラクタ
        ///// </summary>
        ///// <param name="seacher">SCM検索処理</param>
        ///// <param name="referee">SCM回答判定処理</param>
        ///// <param name="salesDataMaker">SCM売上データ作成処理</param>
        //public SCMAutoRespondent(
        //    SCMSearcher seacher,
        //    SCMReferee referee,
        //    SCMSalesDataMaker salesDataMaker
        //) : base(
        //    seacher.HeaderRecordList,
        //    seacher.CarRecordList,
        //    seacher.DetailRecordList,
        //    seacher,
        //    referee,
        //    salesDataMaker
        //)
        //{
        //    EasyLogger.Write(MY_NAME, "Constructor()", LogHelper.GetRunMsg("自動回答処理"));
        //}

        #endregion // 削除コード
        // DEL 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<
        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="seacher">SCM検索処理</param>
        /// <param name="referee">SCM回答判定処理</param>
        /// <param name="salesDataMaker">SCM売上データ作成処理</param>
        public SCMAutoRespondent(
            SCMSearcher seacher,
            SCMReferee referee,
            SCMSalesDataMaker salesDataMaker
        ) : base(seacher, referee, salesDataMaker)
        {
            EasyLogger.Write(MY_NAME, "Constructor()", LogHelper.GetRunMsg("自動回答処理"));
        }
        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<

        #endregion // </Constructor>
    }
}
