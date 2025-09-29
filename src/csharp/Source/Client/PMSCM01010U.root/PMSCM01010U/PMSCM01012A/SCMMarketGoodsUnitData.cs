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
// 作 成 日  2009/08/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// SCM相場回答用の情報付商品連結データのヘルパクラス
    /// </summary>
    /// <remarks>
    /// TODO:相場回答用の処理が多くなったきた場合、本クラスでオーバーライドし、集約すること。<br/>
    /// なお、対象メソッドは<c>HasMarketPrice</c>で場合分けしているメソッドです。
    /// </remarks>
    public sealed class SCMMarketGoodsUnitData : SCMGoodsUnitData
    {
        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realGoodsUnitData">本物の商品連結データ</param>
        /// <param name="searchedType">検索種別</param>
        /// <param name="sourceDetailRecord">元となったSCM受注明細データ(問合せ・発注)</param>
        /// <param name="customerCode">得意先コード</param>
        public SCMMarketGoodsUnitData(
            GoodsUnitData realGoodsUnitData,
            SCMSearchedResult.GoodsSearchDivCd searchedType,
            ISCMOrderDetailRecord sourceDetailRecord,
            int customerCode
        ) : base(realGoodsUnitData, searchedType, sourceDetailRecord, customerCode, false)
        { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realGoodsUnitData">本物の商品連結データ</param>
        /// <param name="searchedType">検索種別</param>
        /// <param name="sourceDetailRecord">元となったSCM受注明細データ(問合せ・発注)</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="createdManually">手動回答の判定にて生成されたか判断するフラグ</param>
        public SCMMarketGoodsUnitData(
            GoodsUnitData realGoodsUnitData,
            SCMSearchedResult.GoodsSearchDivCd searchedType,
            ISCMOrderDetailRecord sourceDetailRecord,
            int customerCode,
            bool createdManually
        ) : base(realGoodsUnitData, searchedType, sourceDetailRecord, customerCode, createdManually)
        { }

        #endregion // </Constructor>
    }
}
