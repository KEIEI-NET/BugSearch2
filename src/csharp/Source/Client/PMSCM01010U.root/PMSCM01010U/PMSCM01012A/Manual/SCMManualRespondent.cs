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
using System.Windows.Forms;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller.Manual
{
    using SCMOrderHeaderRecordType  = ISCMOrderHeaderRecord;    // SCM受注データ
    using SCMOrderCarRecordType     = ISCMOrderCarRecord;       // SCM受注データ(車両情報)
    using SCMOrderDetailRecordType  = ISCMOrderDetailRecord;    // SCM受注明細データ(問合せ・発注)
    using SCMOrderAnswerRecordType  = ISCMOrderAnswerRecord;    // SCM受注明細データ(回答)

    /// <summary>
    /// SCM手動回答処理クラス
    /// </summary>
    public sealed class SCMManualRespondent : SCMRespondent
    {
        private const string MY_NAME = "SCMManualRespondent";

        #region <Constructor>

        // DEL 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
        #region 削除コード

        ///// <summary>
        ///// カスタムコンストラクタ
        ///// </summary>
        ///// <param name="seacher">SCM検索処理</param>
        ///// <param name="referee">SCM回答判定処理</param>
        ///// <param name="salesDataMaker">SCM売上データ作成処理</param>
        //public SCMManualRespondent(
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
        //    EasyLogger.Write(MY_NAME, "Constructor()", LogHelper.GetRunMsg("手動回答処理"));
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
        public SCMManualRespondent(
            SCMSearcher seacher,
            SCMReferee referee,
            SCMSalesDataMaker salesDataMaker
        ) : base(seacher, referee, salesDataMaker)
        {
            EasyLogger.Write(MY_NAME, "Constructor()", LogHelper.GetRunMsg("手動回答処理"));
        }
        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<

        #endregion // </Constructor>

        /// <summary>
        /// 売上データを生成します。（※事前に検索処理を実行していること）
        /// </summary>
        /// <remarks></remarks>
        /// <returns>売上データ（伝票データのみを返します）
        /// （※データが無い場合、空の<c>CustomSerializeArrayList</c>を返します）
        /// </returns>
        public override CustomSerializeArrayList CreateSalesData()
        {
            CustomSerializeArrayList salesDataList = base.CreateSalesData();
            {
                if (salesDataList == null || salesDataList.Count.Equals(0))
                {
                    return new CustomSerializeArrayList();
                }
                CustomSerializeArrayList salesSlipList = salesDataList[0] as CustomSerializeArrayList;
                if (salesSlipList == null)
                {
                    return new CustomSerializeArrayList();
                }
                return salesSlipList;
            }
        }
    }
}
