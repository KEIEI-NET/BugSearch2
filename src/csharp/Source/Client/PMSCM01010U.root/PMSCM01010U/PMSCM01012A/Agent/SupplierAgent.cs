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

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = SupplierAcs;
    using RecordType        = Int32;

    /// <summary>
    /// 仕入先マスタのアクセスクラスの代理人クラス
    /// </summary>
    public sealed class SupplierAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SupplierAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// 仕入消費税端数処理コードを取得します。
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>仕入消費税端数処理コード</returns>
        public int GetStockFractionProcCdOfTax(GoodsUnitData goodsUnitData)
        {
            return RealAccesser.GetStockFractionProcCd(
                goodsUnitData.EnterpriseCode,
                goodsUnitData.SupplierCd,
                SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd
            );
        }

        /// <summary>
        /// 仕入単価端数処理コードを取得します。
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>仕入単価端数処理コード</returns>
        public int GetStockFractionProcCdOfUnit(GoodsUnitData goodsUnitData
        )
        {
            return RealAccesser.GetStockFractionProcCd(
                goodsUnitData.EnterpriseCode,
                goodsUnitData.SupplierCd,
                SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd
            );
        }
    }
}
