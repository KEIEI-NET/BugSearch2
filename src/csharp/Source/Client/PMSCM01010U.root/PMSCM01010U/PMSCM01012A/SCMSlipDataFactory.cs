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
// 作 成 日  2009/06/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517　夏野 駿希 
// 作 成 日  2010/07/07  修正内容 : 在庫商品合計金額(税抜)がセットされていない不具合の修正
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using SCMTotalSettingServer = SingletonInstance<SCMTotalSettingAgent>;  // SCM全体設定マスタ

    /// <summary>
    /// SCM伝票データの生成クラス
    /// </summary>
    public abstract class SCMSlipDataFactory
    {
        #region <SCM受注データ>

        /// <summary>SCM受注データのレコード</summary>
        private readonly ISCMOrderHeaderRecord _scmHeaderRecord;
        /// <summary>SCM受注データのレコードを取得します。</summary>
        protected ISCMOrderHeaderRecord SCMHeaderRecord { get { return _scmHeaderRecord; } }

        #endregion // </SCM受注データ>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="scmHeaderRecord">SCM受注データのレコード</param>
        /// <param name="topPriorityIsSCMTotalSetting">SCM全体設定を最優先するフラグ</param>
        protected SCMSlipDataFactory(
            ISCMOrderHeaderRecord scmHeaderRecord,
            bool topPriorityIsSCMTotalSetting
        )
        {
            _scmHeaderRecord = scmHeaderRecord;
            _topPriorityIsSCMTotalSetting = topPriorityIsSCMTotalSetting;
        }

        #endregion // </Constructor>

        #region <SCM全体設定マスタ>

        /// <summary>SCM全体設定を最優先するフラグ</summary>
        private readonly bool _topPriorityIsSCMTotalSetting;
        /// <summary>SCM全体設定を最優先するフラグを取得します。</summary>
        protected bool TopPriorityIsSCMTotalSetting { get { return _topPriorityIsSCMTotalSetting; } }

        /// <summary>
        /// SCM全体設定マスタを取得します。
        /// </summary>
        protected static SCMTotalSettingAgent SCMTotalSettingDB
        {
            get { return SCMTotalSettingServer.Singleton.Instance; }
        }

        #endregion // <SCM全体設定マスタ>

        #region <042.売上部品合計(税込み)>

        /// <summary>
        /// 売上部品合計(税込み)を取得します。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <returns>売上部品小計(税込み) + 部品値引対象額合計(税込み)</returns>
        public static long GetSalesPrtTotalTaxInc(SalesSlip salesSlip)
        {
            return salesSlip.SalesPrtSubttlInc + salesSlip.ItdedPartsDisInTax;
        }

        #endregion // </042.売上部品合計(税込み)>

        #region <043.売上部品合計(税抜き)>

        /// <summary>
        /// 売上部品合計(税抜き)を取得します。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <returns>売上部品小計(税抜き) + 部品値引対象額合計(税抜き)</returns>
        public static long GetSalesPrtTotalTaxExc(SalesSlip salesSlip)
        {
            return salesSlip.SalesPrtSubttlExc + salesSlip.ItdedPartsDisOutTax;
        }

        #endregion // </043.売上部品合計(税抜き)>

        #region <044.売上作業合計(税込み)>

        /// <summary>
        /// 売上作業合計(税込み)を取得します。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <returns>売上作業小計(税込み) + 作業値引対象額合計(税込み)</returns>
        public static long GetSalesWorkTotalTaxInc(SalesSlip salesSlip)
        {
            return salesSlip.SalesWorkSubttlInc + salesSlip.ItdedWorkDisInTax;
        }

        #endregion // </044.売上作業合計(税抜き)>

        #region <045.売上作業合計(税抜き)>

        /// <summary>
        /// 売上作業合計(税抜き)を取得します。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <returns>売上作業小計(税抜き) + 作業値引対象額合計(税抜き)</returns>
        public static long GetSalesWorkTotalTaxExc(SalesSlip salesSlip)
        {
            return salesSlip.SalesWorkSubttlExc + salesSlip.ItdedWorkDisOutTax;
        }

        #endregion // </044.売上作業合計(税抜き)>

        #region <046.売上小計(税込み)>

        /// <summary>
        /// 売上小計(税込み)を取得します。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <returns>
        /// 値引き後の明細金額の合計(非課税含まず)
        /// ∴売上伝票合計(税込み) - 売上小計非課税対象額 + 売上値引非課税対象額合計
        ///</returns>
        public static long GetSalesSubtotalTaxInc(SalesSlip salesSlip)
        {
            return salesSlip.SalesTotalTaxInc - salesSlip.SalSubttlSubToTaxFre + salesSlip.ItdedSalesDisTaxFre;
        }

        #endregion // </046.売上小計(税込み)>

        #region <047.売上小計(税抜き)>

        /// <summary>
        /// 売上小計(税抜き)を取得します。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <returns>
        /// 値引き後の明細金額の合計(非課税含まず)
        /// ∴売上伝票合計(税抜き) - 売上小計非課税対象額 + 売上値引非課税対象額合計
        ///</returns>
        public static long GetSalesSubtotalTaxExc(SalesSlip salesSlip)
        {
            return salesSlip.SalesTotalTaxExc - salesSlip.SalSubttlSubToTaxFre + salesSlip.ItdedSalesDisTaxFre;
        }

        #endregion // </047.売上小計(税抜き)>

        #region <052.売上正価金額>

        /// <summary>
        /// 売上正価金額を取得します。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <returns>売上伝票合計(税抜き) - 売上値引金額計(税抜き)</returns>
        public static long GetSalesNetPrice(SalesSlip salesSlip)
        {
            return salesSlip.SalesTotalTaxExc - salesSlip.SalesDisTtlTaxExc;
        }

        #endregion // </052.売上正価金額>

        #region <069.部品値引率>

        /// <summary>
        /// 部品値引率を取得します。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <returns>
        /// 小計に対しての部品値引率
        /// ∴部品値引対象額合計(税込み) / 売上部品小計(税込み)
        ///</returns>
        public static double GetPartsDiscountRate(SalesSlip salesSlip)
        {
            if (salesSlip.ItdedPartsDisInTax.Equals(0)) return 0;

            return salesSlip.SalesPrtSubttlInc / salesSlip.ItdedPartsDisInTax;
        }

        #endregion // </069.部品値引率>

        #region <079.入金引当残高>

        /// <summary>
        /// 入金引当残高を取得します。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <returns>
        /// 売上伝票合計(税込) 消費税転嫁方式が「請求転嫁、非課税」の場合は税抜金額
        ///</returns>
        public static long GetConsTaxLayMethod(SalesSlip salesSlip)
        {
            if (salesSlip.ConsTaxLayMethod.Equals((int)ConsTaxLayMethod.Slip)
                    ||
                salesSlip.ConsTaxLayMethod.Equals((int)ConsTaxLayMethod.SlipDetail))
            {
                return salesSlip.SalesTotalTaxInc;
            }
            else
            {
                return salesSlip.SalesTotalTaxExc;
            }
        }

        #endregion // </079.入金引当残高>

        #region <070.工賃値引率>

        /// <summary>
        /// 工賃値引率を取得します。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <returns>
        /// 小計に対しての工賃値引率
        /// ∴作業値引対象額合計(税込み) / 売上作業小計(税込み)
        ///</returns>
        public static double GetRavorDiscountRate(SalesSlip salesSlip)
        {
            if (salesSlip.ItdedWorkDisInTax.Equals(0)) return 0;

            return salesSlip.SalesWorkSubttlInc / salesSlip.ItdedWorkDisInTax;
        }

        #endregion // </070.工賃値引率>

        #region <114.伝票発行区分>

        /// <summary>
        /// 伝票発行区分を取得します。
        /// </summary>
        /// <returns>伝票発行区分(0:しない/1:する)</returns>
        public abstract int GetSlipPrintDivCd();

        #endregion // </114.伝票発行区分>

        #region <115.伝票発行済区分>

        /// <summary>
        /// 伝票発行済区分を取得します。
        /// </summary>
        /// <returns>伝票発行済区分(0:未発行/1:発行済)</returns>
        public virtual int GetSlipPrintFinishCd()
        {
            return GetSlipPrintDivCd(); // HACK:伝票発行区分と同じでよい？
        }

        #endregion // </115.伝票発行済区分>

        #region <128.在庫商品合計金額(税抜)>

        /// <summary>
        /// 在庫商品合計金額(税抜)を取得します。
        /// </summary>
        /// <param name="salesDetailList">売上明細データのリスト</param>
        /// <returns>在庫取寄区分が0の明細金額の集計</returns>
        public static long GetStockGoodsTtlTaxExc(IList<SalesDetail> salesDetailList)
        {
            long stockGoodsTtlTaxExc = 0;
            foreach (SalesDetail salesDetail in salesDetailList)
            {
                // 売上在庫取寄せ区分(0:取寄せ, 1:在庫)
                // 2010/07/07 >>>
                //if (salesDetail.SalesOrderDivCd.Equals(0))
                if (salesDetail.SalesOrderDivCd.Equals(1))
                // 2010/07/07 <<<
                {
                    stockGoodsTtlTaxExc += salesDetail.SalesMoneyTaxExc;    // 売上金額(税抜き)
                }
            }
            return stockGoodsTtlTaxExc;
        }

        #endregion // </128.在庫商品合計金額>

        #region <129.純正商品合計金額(税抜)>

        /// <summary>
        /// 純正商品合計金額(税抜)を取得します。
        /// </summary>
        /// <param name="salesDetailList">売上明細データのリスト</param>
        /// <returns>商品属性が0の明細金額の集計</returns>
        public static long GetPureGoodsTtlTaxExc(IList<SalesDetail> salesDetailList)
        {
            long pureGoodsTtlTaxExc = 0;
            foreach (SalesDetail salesDetail in salesDetailList)
            {
                // 商品属性(0:純正, 1:優良)
                if (salesDetail.GoodsKindCode.Equals(0))
                {
                    pureGoodsTtlTaxExc += salesDetail.SalesMoneyTaxExc; // 売上金額(税抜き)
                }
            }
            return pureGoodsTtlTaxExc;
        }

        #endregion // </129.純正商品合計金額(税抜)>
    }
}
