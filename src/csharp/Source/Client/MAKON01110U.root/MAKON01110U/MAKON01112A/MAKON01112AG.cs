using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 仕入伝票金額計算クラス
    /// </summary>
    public class StockSlipPriceCalculator
    {
        /// <summary>
        /// 仕入合計金額設定処理
        /// </summary>
        /// <param name="stockSlipWork">仕入データワーク</param>
        /// <param name="stockDetailWorkList">仕入明細データワークリスト</param>
        /// <param name="taxFracProcUnit">消費税端数処理単位</param>
        /// <param name="taxFracProcCd">消費税端数処理区分</param>
        public static void TotalPriceSetting(ref StockSlipWork stockSlipWork, List<StockDetailWork> stockDetailWorkList, double taxFracProcUnit, int taxFracProcCd)
        {
            TotalPriceSettingProc(ref stockSlipWork, stockDetailWorkList, taxFracProcUnit, taxFracProcCd);
        }

        /// <summary>
        /// 仕入合計金額設定処理
        /// </summary>
        /// <param name="stockSlipWork">仕入データワーク</param>
        /// <param name="stockDetailWork">仕入明細データワークリスト</param>
        /// <param name="taxFracProcUnit">消費税端数処理単位</param>
        /// <param name="taxFracProcCd">消費税端数処理区分</param>
        private static void TotalPriceSettingProc(ref StockSlipWork stockSlipWork, List<StockDetailWork> stockDetailWork, double taxFracProcUnit, int taxFracProcCd)
        {
            long stockTtlPricTaxInc = 0;	// 仕入金額計（税込み）
            long stockTtlPricTaxExc = 0;	// 仕入金額計（税抜き）
            long stockPriceConsTax = 0;		// 仕入金額消費税額
            long ttlItdedStcOutTax = 0;		// 仕入外税対象額合計
            long ttlItdedStcInTax = 0;		// 仕入内税対象額合計
            long ttlItdedStcTaxFree = 0;	// 仕入非課税対象額合計
            long stockOutTax = 0;			// 仕入金額消費税額（外税）
            long stckPrcConsTaxInclu = 0;	// 仕入金額消費税額（内税）
            long stckDisTtlTaxExc = 0;		// 仕入値引金額計（税抜き）
            long itdedStockDisOutTax = 0;	// 仕入値引外税対象額合計
            long itdedStockDisInTax = 0;	// 仕入値引内税対象額合計
            long itdedStockDisTaxFre = 0;	// 仕入値引非課税対象額合計
            long stockDisOutTax = 0;		// 仕入値引消費税額（外税）
            long stckDisTtlTaxInclu = 0;	// 仕入値引消費税額（内税）
            long balanceAdjust = 0;			// 残高調整額
            long taxAdjust = 0;				// 消費税調整額

            CalculateStockTotalPrice(stockDetailWork, stockSlipWork.StockGoodsCd, stockSlipWork.SupplierConsTaxRate, stockSlipWork.SuppTtlAmntDspWayCd, stockSlipWork.SuppCTaxLayCd, taxFracProcUnit, taxFracProcCd, out stockTtlPricTaxInc, out stockTtlPricTaxExc, out stockPriceConsTax, out ttlItdedStcOutTax, out ttlItdedStcInTax, out ttlItdedStcTaxFree, out stockOutTax, out stckPrcConsTaxInclu, out stckDisTtlTaxExc, out itdedStockDisOutTax, out itdedStockDisInTax, out itdedStockDisTaxFre, out stockDisOutTax, out stckDisTtlTaxInclu, out balanceAdjust, out taxAdjust);

            switch (stockSlipWork.StockGoodsCd)
            {
                case 2:	// 消費税調整
                case 4: // 買掛用消費税調整
                    {
                        stockSlipWork.StockTtlPricTaxInc = 0;		// 仕入金額計（税込み）
                        stockSlipWork.StockTtlPricTaxExc = 0;		// 仕入金額計（税抜き）
                        stockSlipWork.StockPriceConsTax = taxAdjust;// 仕入金額消費税額
                        stockSlipWork.TtlItdedStcOutTax = 0;		// 仕入外税対象額合計
                        stockSlipWork.TtlItdedStcInTax = 0;			// 仕入内税対象額合計
                        stockSlipWork.TtlItdedStcTaxFree = 0;		// 仕入非課税対象額合計
                        stockSlipWork.StockOutTax = 0;				// 仕入金額消費税額（外税）
                        stockSlipWork.StckPrcConsTaxInclu = 0;		// 仕入金額消費税額（内税）
                        stockSlipWork.StckDisTtlTaxExc = 0;			// 仕入値引金額計（税抜き）
                        stockSlipWork.ItdedStockDisOutTax = 0;		// 仕入値引外税対象額合計
                        stockSlipWork.ItdedStockDisInTax = 0;		// 仕入値引内税対象額合計
                        stockSlipWork.ItdedStockDisTaxFre = 0;		// 仕入値引非課税対象額合計
                        stockSlipWork.StockDisOutTax = 0;			// 仕入値引消費税額（外税）
                        stockSlipWork.StckDisTtlTaxInclu = 0;		// 仕入値引消費税額（内税）
                        stockSlipWork.StockNetPrice = 0;			// 仕入正価金額 = 外税対象金額 + 内税対象金額 + 非課税対象金額
                        stockSlipWork.StockTotalPrice = 0;			// 仕入金額合計
                        stockSlipWork.StockSubttlPrice = 0;			// 仕入金額小計
                        stockSlipWork.AccPayConsTax = taxAdjust;	// 買掛消費税
                        break;
                    }
                case 3: // 残高調整
                case 5: // 買掛用残高調整
                    {
                        stockSlipWork.StockTtlPricTaxInc = 0;		// 仕入金額計（税込み）
                        stockSlipWork.StockTtlPricTaxExc = 0;		// 仕入金額計（税抜き）
                        stockSlipWork.StockPriceConsTax = 0;        // 仕入金額消費税額
                        stockSlipWork.TtlItdedStcOutTax = 0;		// 仕入外税対象額合計
                        stockSlipWork.TtlItdedStcInTax = 0;			// 仕入内税対象額合計
                        stockSlipWork.TtlItdedStcTaxFree = 0;		// 仕入非課税対象額合計
                        stockSlipWork.StockOutTax = 0;				// 仕入金額消費税額（外税）
                        stockSlipWork.StckPrcConsTaxInclu = 0;		// 仕入金額消費税額（内税）
                        stockSlipWork.StckDisTtlTaxExc = 0;			// 仕入値引金額計（税抜き）
                        stockSlipWork.ItdedStockDisOutTax = 0;		// 仕入値引外税対象額合計
                        stockSlipWork.ItdedStockDisInTax = 0;		// 仕入値引内税対象額合計
                        stockSlipWork.ItdedStockDisTaxFre = 0;		// 仕入値引非課税対象額合計
                        stockSlipWork.StockDisOutTax = 0;			// 仕入値引消費税額（外税）
                        stockSlipWork.StckDisTtlTaxInclu = 0;		// 仕入値引消費税額（内税）
                        stockSlipWork.StockNetPrice = 0;			// 仕入正価金額 = 外税対象金額 + 内税対象金額 + 非課税対象金額
                        stockSlipWork.StockTotalPrice = balanceAdjust;	// 仕入金額合計
                        stockSlipWork.StockSubttlPrice = 0;			// 仕入金額小計
                        stockSlipWork.AccPayConsTax = 0;			// 買掛消費税
                        break;
                    }
                default:
                    {
                        stockSlipWork.StockTtlPricTaxInc = stockTtlPricTaxInc;		// 仕入金額計（税込み）
                        stockSlipWork.StockTtlPricTaxExc = stockTtlPricTaxExc;		// 仕入金額計（税抜き）
                        stockSlipWork.StockPriceConsTax = stockPriceConsTax + stockSlipWork.TaxAdjust;		// 仕入金額消費税額 + 消費税調整額
                        stockSlipWork.TtlItdedStcOutTax = ttlItdedStcOutTax;		// 仕入外税対象額合計
                        stockSlipWork.TtlItdedStcInTax = ttlItdedStcInTax;			// 仕入内税対象額合計
                        stockSlipWork.TtlItdedStcTaxFree = ttlItdedStcTaxFree;		// 仕入非課税対象額合計
                        stockSlipWork.StockOutTax = stockOutTax;					// 仕入金額消費税額（外税）
                        stockSlipWork.StckPrcConsTaxInclu = stckPrcConsTaxInclu;	// 仕入金額消費税額（内税）
                        stockSlipWork.StckDisTtlTaxExc = stckDisTtlTaxExc;			// 仕入値引金額計（税抜き）
                        stockSlipWork.ItdedStockDisOutTax = itdedStockDisOutTax;	// 仕入値引外税対象額合計
                        stockSlipWork.ItdedStockDisInTax = itdedStockDisInTax;		// 仕入値引内税対象額合計
                        stockSlipWork.ItdedStockDisTaxFre = itdedStockDisTaxFre;	// 仕入値引非課税対象額合計
                        stockSlipWork.StockDisOutTax = stockDisOutTax;				// 仕入値引消費税額（外税）
                        stockSlipWork.StckDisTtlTaxInclu = stckDisTtlTaxInclu;		// 仕入値引消費税額（内税）
                        stockSlipWork.StockNetPrice = ttlItdedStcOutTax + ttlItdedStcInTax + ttlItdedStcTaxFree;	// 仕入正価金額 = 外税対象金額 + 内税対象金額 + 非課税対象金額
                        stockSlipWork.StockTotalPrice = stockTtlPricTaxInc + ttlItdedStcTaxFree + itdedStockDisTaxFre + stockSlipWork.TaxAdjust + stockSlipWork.BalanceAdjust;		// 仕入金額合計 = 仕入金額計（税込み）+ 仕入非課税対象額合計 + 仕入非課税対象額合計 + 消費税調整額 + 残高調整額
                        stockSlipWork.StockSubttlPrice = stockTtlPricTaxExc + ttlItdedStcTaxFree + itdedStockDisTaxFre;					// 仕入金額小計 = 仕入金額計（税抜き）+ 仕入非課税対象額合計 + 仕入非課税対象額合計
                        stockSlipWork.AccPayConsTax = stockOutTax + stckPrcConsTaxInclu + stockDisOutTax + stckDisTtlTaxInclu + stockSlipWork.TaxAdjust;// 買掛消費税 = 仕入金額消費税額（外税）+ 仕入金額消費税額（内税）+ 仕入値引消費税額（外税）+ 仕入値引消費税額（内税）+ 消費税調整額
                        break;
                    }
            }
        }


        /// <summary>
        /// 仕入金額の合計を計算します。
        /// </summary>
        /// <param name="stockDetailWorkList">仕入明細データワークリスト</param>
        /// <param name="stockGoodsCd">商品区分</param>
        /// <param name="supplierConsTaxRate">仕入先消費税税率</param>
        /// <param name="suppTtlAmntDspWayCd">仕入先総額表示方法区分</param>
        /// <param name="suppCTaxLayCd">消費税転嫁方式</param>
        /// <param name="taxFracProcUnit">消費税端数処理単位</param>
        /// <param name="taxFracProcCd">消費税端数処理区分</param>
        /// <param name="stockTtlPricTaxInc">仕入金額計（税込み）</param>
        /// <param name="stockTtlPricTaxExc">仕入金額計（税抜き）</param>
        /// <param name="stockPriceConsTax">仕入金額消費税額</param>
        /// <param name="ttlItdedStcOutTax">仕入外税対象額合計</param>
        /// <param name="ttlItdedStcInTax">仕入内税対象額合計</param>
        /// <param name="ttlItdedStcTaxFree">仕入非課税対象額合計</param>
        /// <param name="stockOutTax">仕入金額消費税額（外税）</param>
        /// <param name="stckPrcConsTaxInclu">仕入金額消費税額（内税）</param>
        /// <param name="stckDisTtlTaxExc">仕入値引金額計（税抜き）</param>
        /// <param name="itdedStockDisOutTax">仕入値引外税対象額合計</param>
        /// <param name="itdedStockDisInTax">仕入値引内税対象額合計</param>
        /// <param name="itdedStockDisTaxFre">仕入値引非課税対象額合計</param>
        /// <param name="stockDisOutTax">仕入値引消費税額（外税）</param>
        /// <param name="stckDisTtlTaxInclu">仕入値引消費税額（内税）</param>
        /// <param name="balanceAdjust">残高調整合計額</param>
        /// <param name="taxAdjust">消費税合計額</param>
        private static void CalculateStockTotalPrice(List<StockDetailWork> stockDetailWorkList, int stockGoodsCd, double supplierConsTaxRate, int suppTtlAmntDspWayCd, int suppCTaxLayCd, double taxFracProcUnit, int taxFracProcCd, out long stockTtlPricTaxInc, out long stockTtlPricTaxExc, out long stockPriceConsTax, out long ttlItdedStcOutTax, out long ttlItdedStcInTax, out long ttlItdedStcTaxFree, out long stockOutTax, out long stckPrcConsTaxInclu, out long stckDisTtlTaxExc, out long itdedStockDisOutTax, out long itdedStockDisInTax, out long itdedStockDisTaxFre, out long stockDisOutTax, out long stckDisTtlTaxInclu, out long balanceAdjust, out long taxAdjust)
        {
            stockTtlPricTaxInc = 0;		// 仕入金額計（税込み）
            stockTtlPricTaxExc = 0;		// 仕入金額計（税抜き）
            stockPriceConsTax = 0;		// 仕入金額消費税額
            ttlItdedStcOutTax = 0;		// 仕入外税対象額合計
            ttlItdedStcInTax = 0;		// 仕入内税対象額合計
            ttlItdedStcTaxFree = 0;		// 仕入非課税対象額合計
            stockOutTax = 0;			// 仕入金額消費税額（外税）
            stckPrcConsTaxInclu = 0;	// 仕入金額消費税額（内税）
            stckDisTtlTaxExc = 0;		// 仕入値引金額計（税抜き）
            itdedStockDisOutTax = 0;	// 仕入値引外税対象額合計
            itdedStockDisInTax = 0;		// 仕入値引内税対象額合計
            itdedStockDisTaxFre = 0;	// 仕入値引非課税対象額合計
            stockDisOutTax = 0;			// 仕入値引消費税額（外税）
            stckDisTtlTaxInclu = 0;		// 仕入値引消費税額（内税）
            balanceAdjust = 0;			// 残高調整額
            taxAdjust = 0;				// 消費税調整額

            long ttlItdedStcInTax_TaxInc = 0;       // 仕入内税対象額合計（税込）

            long itdedStockDisInTax_TaxInc = 0;     // 値引内税対象金額合計(税込み)

            //--------------------------------------------------
            // 計算に必要な金額の計算
            //--------------------------------------------------
            #region 計算に必要な金額の計算
            foreach (StockDetailWork stockDetailWork in stockDetailWorkList)
            {
                // 仕入外税対象額合計
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc ) &&
                    ( stockDetailWork.StockSlipCdDtl != 2 ))
                {
                    ttlItdedStcOutTax += stockDetailWork.StockPriceTaxExc;
                }

                // 仕入金額消費税額（外税）
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc ) &&
                    ( stockDetailWork.StockSlipCdDtl != 2 ))
                {
                    stockOutTax += stockDetailWork.StockPriceConsTax;
                }

                // 仕入内税対象額合計
                if (( stockDetailWork.TaxationCode ==  (int)CalculateTax.TaxationCode.TaxInc) &&
                    ( stockDetailWork.StockSlipCdDtl != 2 ))
                {
                    ttlItdedStcInTax += stockDetailWork.StockPriceTaxExc;
                }

                // 仕入内税対象額合計（税込）
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) &&
                    ( stockDetailWork.StockSlipCdDtl != 2 ))
                {
                    ttlItdedStcInTax_TaxInc += stockDetailWork.StockPriceTaxInc;
                }

                // 仕入金額消費税額（内税）
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) &&
                    ( stockDetailWork.StockSlipCdDtl != 2 ))
                {
                    stckPrcConsTaxInclu += stockDetailWork.StockPriceConsTax;
                }

                // 仕入非課税対象額合計
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxNone ) &&
                    ( stockDetailWork.StockSlipCdDtl != 2 ))
                {
                    ttlItdedStcTaxFree += stockDetailWork.StockPriceTaxInc;
                }

                // 仕入値引外税対象額合計
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc ) &&
                    ( stockDetailWork.StockSlipCdDtl == 2 ))
                {
                    itdedStockDisOutTax += stockDetailWork.StockPriceTaxExc;
                }

                // 仕入値引消費税額（外税）
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc ) &&
                    ( stockDetailWork.StockSlipCdDtl == 2 ))
                {
                    stockDisOutTax += stockDetailWork.StockPriceConsTax;
                }

                // 仕入値引内税対象額合計
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) &&
                    ( stockDetailWork.StockSlipCdDtl == 2 ))
                {
                    itdedStockDisInTax += stockDetailWork.StockPriceTaxExc;
                }

                // 値引内税対象金額合計(税込み)
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) &&
                    ( stockDetailWork.StockSlipCdDtl == 2 ))
                {
                    itdedStockDisInTax_TaxInc += stockDetailWork.StockPriceTaxInc;
                }

                // 仕入値引消費税額（内税）
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) &&
                    ( stockDetailWork.StockSlipCdDtl == 2 ))
                {
                    stckDisTtlTaxInclu += stockDetailWork.StockPriceConsTax;
                }

                // 仕入値引非課税対象額合計
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxNone ) &&
                    ( stockDetailWork.StockSlipCdDtl == 2 ))
                {
                    itdedStockDisTaxFre += stockDetailWork.StockPriceTaxInc;
                }

                // 残高調整額
                if (( stockDetailWork.StockGoodsCd == 3 ) ||
                    ( stockDetailWork.StockGoodsCd == 5 ))
                {
                    balanceAdjust += stockDetailWork.StockPriceTaxInc;
                }

                // 消費税調整額
                if (( stockDetailWork.StockGoodsCd == 2 ) ||
                    ( stockDetailWork.StockGoodsCd == 4 ))
                {
                    taxAdjust += stockDetailWork.StockPriceConsTax;
                }
            }

            // 仕入値引金額計（税抜き） = 仕入値引外税対象額合計 + 仕入値引内税対象額合計 + 仕入値引非課税対象額合計
            stckDisTtlTaxExc = itdedStockDisOutTax + itdedStockDisInTax + itdedStockDisTaxFre;

            #endregion

            // 転嫁方式：非課税の場合に金額を調整する
            if (suppCTaxLayCd == 9)
            {
                // 仕入金額消費税額（外税）
                stockOutTax = 0;

                // 仕入金額消費税額（内税）
                stckPrcConsTaxInclu = 0;

                // 仕入非課税対象額合計 = 仕入非課税対象額合計 + 仕入外税対象額合計 + 仕入内税対象額合計
                ttlItdedStcTaxFree += ttlItdedStcOutTax + ttlItdedStcInTax;

                // 仕入外税対象額合計
                ttlItdedStcOutTax = 0;

                // 仕入内税対象額合計
                ttlItdedStcInTax = 0;

                // 仕入内税対象額合計（税込）
                ttlItdedStcInTax_TaxInc = 0;

                // 仕入値引消費税額（外税）
                stockDisOutTax = 0;

                // 仕入値引消費税額（内税）
                stckDisTtlTaxInclu = 0;

                // 仕入値引非課税対象額合計 = 仕入値引非課税対象額合計 + 仕入値引外税対象額合計 + 仕入値引内税対象額合計
                itdedStockDisTaxFre += itdedStockDisOutTax + itdedStockDisInTax;

                // 仕入値引外税対象額合計
                itdedStockDisOutTax = 0;

                // 仕入値引内税対象額合計
                itdedStockDisInTax = 0;

                // 仕入値引内税対象額合計（税込)
                itdedStockDisInTax_TaxInc = 0;

                // 仕入値引金額計（税抜き） = 仕入値引外税対象額合計 + 仕入値引内税対象額合計 + 仕入値引非課税対象額合計
                stckDisTtlTaxExc = itdedStockDisOutTax + itdedStockDisInTax + itdedStockDisTaxFre;
            }

            if (stockGoodsCd == 6)
            {
                // 総額表示
                if (suppTtlAmntDspWayCd == 1)
                {
                    //--------------------------------------------------
                    // ① 仕入金額計（税込み）：仕入外税対象額合計 + 仕入金額消費税額（外税）+ 仕入値引外税対象額合計 + 仕入値引消費税額（外税） + 仕入内税対象額合計（税込） +  値引内税対象金額合計(税込み)
                    //--------------------------------------------------
                    stockTtlPricTaxInc = ttlItdedStcOutTax + stockOutTax + itdedStockDisOutTax + stockDisOutTax + ttlItdedStcInTax_TaxInc + itdedStockDisInTax_TaxInc;

                    //--------------------------------------------------
                    // ② 仕入金額消費税額：消費税(内税) + 消費税(外税)
                    //--------------------------------------------------
                    stockPriceConsTax = stckPrcConsTaxInclu + stockOutTax;

                    //--------------------------------------------------
                    // ③ 仕入金額計（税抜き）：① - ②
                    //--------------------------------------------------
                    stockTtlPricTaxExc = stockTtlPricTaxInc - stockPriceConsTax;
                }
                else
                {
                    //--------------------------------------------------
                    // ① 仕入金額計(税抜き)：仕入外税対象額合計 + 仕入内税対象額合計 + 値引外税対象金額合計 + 値引内税対象金額合計
                    //--------------------------------------------------
                    stockTtlPricTaxExc = ttlItdedStcOutTax + ttlItdedStcInTax + itdedStockDisOutTax + itdedStockDisInTax;

                    //--------------------------------------------------
                    // ② 仕入金額消費税額：消費税(内税) + 消費税(外税)
                    //--------------------------------------------------
                    stockPriceConsTax = stockOutTax + stckPrcConsTaxInclu;

                    //--------------------------------------------------
                    // ③ 仕入金額計（税込）：① + ②
                    //--------------------------------------------------
                    stockTtlPricTaxInc = stockTtlPricTaxExc + stockPriceConsTax;
                }
            }
            else
            {
                // 明細転嫁以外
                if (suppCTaxLayCd != 1)
                {
                    //--------------------------------------------------
                    // ① 仕入金額計(税抜き)：仕入外税対象額合計 + 仕入内税対象額合計 + 値引外税対象金額合計 + 値引内税対象金額合計 
                    //--------------------------------------------------
                    stockTtlPricTaxExc = ttlItdedStcOutTax + ttlItdedStcInTax + itdedStockDisOutTax + itdedStockDisInTax;

                    //--------------------------------------------------
                    // ② 仕入金額計(税込み)：仕入内税対象額合計(税込み) + 値引内税対象額合計(税込み) + 仕入外税対象額合計 + 値引外税対象金額合計 ＋ (仕入外税対象額合計 + 値引外税対象金額合計)×税率)
                    //--------------------------------------------------
                    stockTtlPricTaxInc = ttlItdedStcInTax_TaxInc + itdedStockDisInTax_TaxInc + ttlItdedStcOutTax + itdedStockDisOutTax + CalculateTax.GetTaxFromPriceExc(supplierConsTaxRate, taxFracProcUnit, taxFracProcCd, ttlItdedStcOutTax + itdedStockDisOutTax);

                    //--------------------------------------------------
                    // ③ 消費税合計：② - ①
                    //--------------------------------------------------
                    stockPriceConsTax = stockTtlPricTaxInc - stockTtlPricTaxExc;

                    //--------------------------------------------------
                    // ④ 仕入金額消費税額（外税）：仕入外税対象額合計 × 税率
                    //--------------------------------------------------
                    stockOutTax = CalculateTax.GetTaxFromPriceExc(supplierConsTaxRate, taxFracProcUnit, taxFracProcCd, ttlItdedStcOutTax);

                    //--------------------------------------------------
                    // ⑤ 外税対象消費税(税抜き、値引き含む) ：(仕入外税対象額合計 + 仕入値引外税対象額合計) × 税率
                    //--------------------------------------------------
                    long stockOutTax_All = CalculateTax.GetTaxFromPriceExc(supplierConsTaxRate, taxFracProcUnit, taxFracProcCd, ttlItdedStcOutTax + itdedStockDisOutTax);

                    //--------------------------------------------------
                    // ⑥ 値引外税消費税合計：④ - ⑤
                    //--------------------------------------------------
                    stockDisOutTax = stockOutTax_All - stockOutTax;
                }
                // 明細転嫁
                else
                {
                    //--------------------------------------------------
                    // ① 仕入金額消費税額：仕入金額消費税額（外税） + 仕入金額消費税額（内税） +  仕入値引消費税額（外税） + 仕入値引消費税額（内税）
                    //--------------------------------------------------
                    stockPriceConsTax = stockOutTax + stckPrcConsTaxInclu + stockDisOutTax + stckDisTtlTaxInclu;

                    //--------------------------------------------------
                    // ② 仕入金額計(税抜き)：仕入外税対象額合計 + 仕入内税対象額合計 + 値引外税対象金額合計 + 値引内税対象金額合計
                    //--------------------------------------------------
                    stockTtlPricTaxExc = ttlItdedStcOutTax + ttlItdedStcInTax + itdedStockDisOutTax + itdedStockDisInTax;

                    //--------------------------------------------------
                    // ③ 仕入金額計(税込み)：① + ②
                    //--------------------------------------------------
                    stockTtlPricTaxInc = stockTtlPricTaxExc + stockPriceConsTax;
                }
            }
        }
    }
}
