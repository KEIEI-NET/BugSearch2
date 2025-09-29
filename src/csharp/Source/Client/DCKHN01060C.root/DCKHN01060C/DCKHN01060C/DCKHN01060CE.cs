using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library;
using Broadleaf.Application.UIData;
using System.Data;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 売上金額計算クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 売上に関する金額の計算を行います。</br>
	/// <br>Programmer : 21024　佐々木 健</br>
	/// <br>Date       : 2008.06.19</br>
	/// </remarks>
	public class SalesPriceCalculate
	{
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //		
        #region ■Private Member

		private List<SalesProcMoney> _salesProcMoneyList;

		#endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //		
        #region ■Constructor

		/// <summary>
        /// コンストラクタ
		/// </summary>
		public SalesPriceCalculate()
		{
		}

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="salesProcMoneyList">売上金額処理区分設定マスタリスト</param>
        public SalesPriceCalculate( List<SalesProcMoney> salesProcMoneyList )
        {
            this.CacheSalesProcMoneyList(salesProcMoneyList);
        }

		#endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //		
        #region ■Public Method

		/// <summary>
		/// 売上金額端数処理区分設定マスタキャッシュ
		/// </summary>
		/// <param name="salesProcMoneyList">売上金額処理区分設定マスタリスト</param>
		public void CacheSalesProcMoneyList( List<SalesProcMoney> salesProcMoneyList )
		{
			this._salesProcMoneyList = salesProcMoneyList;

            this._salesProcMoneyList.Sort(new DCKHN01060CF.SalesProcMoneyComparer());
        }

		#region 原価金額算定用メソッド
#if false
		/// <summary>
		/// 原価金額税込み価格算定（数量、単価（税抜き）、金額（税込）より価格算定）
		/// </summary>
		/// <param name="taxationCode">課税区分：0:課税,1:非課税,2:課税（内税）</param>
		/// <param name="count">数量</param>
		/// <param name="unitPriceExc">単価（税抜き）</param>
		/// <param name="unitPriceInc">単価（税込み）</param>
		/// <param name="unitPriceTax">単価（消費税）</param>
		/// <param name="priceExc">価格（税抜き）</param>
		/// <param name="priceInc">価格（税込み）</param>
		/// <param name="priceTax">価格（消費税）</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="taxRate">消費税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
		public void CalcCostTaxIncFromTaxExc( int taxationCode, double count, ref double unitPriceExc, out double unitPriceInc, out double unitPriceTax,
			ref long priceExc, out long priceInc, out long priceTax, int fractionProcCode, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			this.CalcTaxIncFromTaxExc(taxationCode, 
									  count, 
									  ref unitPriceExc, 
									  out unitPriceInc, 
									  out unitPriceTax, 
									  ref priceExc, 
									  out priceInc, 
									  out priceTax, 
									  DCKHN01060CF.ctFracProcMoneyDiv_CostPrice, 
									  fractionProcCode, 
									  taxRate, 
									  taxFracProcUnit, 
									  taxFracProcCd);
        }
#endif

#if false
		/// <summary>
		/// 原価税抜き価格算定処理（数量,単価(税込),金額(税込)より価格算定）
		/// </summary>
		/// <param name="taxationCode">課税区分：0:課税,1:非課税,2:課税（内税）</param>
		/// <param name="count">数量</param>
		/// <param name="unitPriceExc">単価（税抜き）</param>
		/// <param name="unitPriceInc">単価（税込み）</param>
		/// <param name="unitPriceTax">単価（消費税）</param>
		/// <param name="priceExc">価格（税抜き）</param>
		/// <param name="priceInc">価格（税込み）</param>
		/// <param name="priceTax">価格（消費税）</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="taxRate">消費税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
		public void CalcCostTaxExcFromTaxInc( int taxationCode, double count, out double unitPriceExc, ref double unitPriceInc, out double unitPriceTax,
			out long priceExc, ref long priceInc, out long priceTax, int fractionProcCode, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			this.CalcTaxExcFromTaxInc(taxationCode,
									  count,
									  out unitPriceExc,
									  ref unitPriceInc,
									  out unitPriceTax,
									  out priceExc,
									  ref priceInc,
									  out priceTax,
									  DCKHN01060CF.ctFracProcMoneyDiv_CostPrice,
									  fractionProcCode,
									  taxRate,
									  taxFracProcUnit,
									  taxFracProcCd);
		}
#endif
        #endregion

        /// <summary>
        /// 税抜き金額、税込金額を算定します。（オーバーロード）
        /// </summary>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="salesCnsTaxFrcProcCd">売上消費税端数処理コード</param>
        /// <param name="taxRate">税率</param>
        /// <param name="priceTaxExc">税抜き金額</param>
        /// <param name="priceTaxInc">税込み金額</param>
        /// <param name="priceConsTax">消費税金額</param>
        /// <param name="taxFracProcUnit">消費税端数処理単位</param>
        /// <param name="taxFracProcCd">消費税端数処理区分</param>
        public void CalculatePrice( int taxationCode, double targetPrice, double taxRate, int salesCnsTaxFrcProcCd, out double priceTaxExc, out double priceTaxInc, out double priceConsTax, out double taxFracProcUnit, out int taxFracProcCd )
        {
            this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, targetPrice, out taxFracProcUnit, out taxFracProcCd);

            CalculateTax.CalculatePrice(taxationCode, targetPrice, taxRate, taxFracProcUnit, taxFracProcCd, out priceTaxExc, out priceTaxInc, out priceConsTax);
        }

        /// <summary>
        /// 税抜き金額、税込金額を算定します。（オーバーロード）
        /// </summary>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="salesCnsTaxFrcProcCd">売上消費税端数処理コード</param>
        /// <param name="taxRate">税率</param>
        /// <param name="priceTaxExc">税抜き金額</param>
        /// <param name="priceTaxInc">税込み金額</param>
        /// <param name="priceConsTax">消費税金額</param>
        /// <param name="taxFracProcUnit">消費税端数処理単位</param>
        /// <param name="taxFracProcCd">消費税端数処理区分</param>
        public void CalculatePrice( int taxationCode, long targetPrice, double taxRate, int salesCnsTaxFrcProcCd, out long priceTaxExc, out long priceTaxInc, out long priceConsTax, out double taxFracProcUnit, out int taxFracProcCd )
        {
            this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, targetPrice, out taxFracProcUnit, out taxFracProcCd);

            CalculateTax.CalculatePrice(taxationCode, targetPrice, taxRate, taxFracProcUnit, taxFracProcCd, out priceTaxExc, out priceTaxInc, out priceConsTax);
        }

        #region 売上金額用メソッド

        /// <summary>
        /// 売上税込み価格算定（数量、単価（税抜き）、金額（税込）より価格算定）（オーバーロード）
        /// </summary>
        /// <param name="taxationCode">課税区分：0:課税,1:非課税,2:課税（内税）</param>
        /// <param name="count">数量</param>
        /// <param name="unitPriceExc">単価（税抜き）</param>
        /// <param name="unitPriceInc">単価（税込み）</param>
        /// <param name="unitPriceTax">単価（消費税）</param>
        /// <param name="priceExc">価格（税抜き）</param>
        /// <param name="priceInc">価格（税込み）</param>
        /// <param name="priceTax">価格（消費税）</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="salesCnsTaxFrcProcCd">売上消費税端数処理コード</param>
        /// <param name="taxRate">消費税率</param>
        /// <param name="taxFracProcUnit">消費税端数処理単位</param>
        /// <param name="taxFracProcCd">消費税端数処理区分</param>
        public void CalcTaxIncFromTaxExc( int taxationCode, double count, ref double unitPriceExc, out double unitPriceInc, out double unitPriceTax,
            ref long priceExc, out long priceInc, out long priceTax, int fractionProcCode, int salesCnsTaxFrcProcCd, double taxRate, out double taxFracProcUnit, out int taxFracProcCd )
        {
            this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            this.CalcTaxIncFromTaxExc(taxationCode,
                                      count,
                                      ref unitPriceExc,
                                      out unitPriceInc,
                                      out unitPriceTax,
                                      ref priceExc,
                                      out priceInc,
                                      out priceTax,
                                      DCKHN01060CF.ctFracProcMoneyDiv_Price,
                                      fractionProcCode,
                                      taxRate,
                                      taxFracProcUnit,
                                      taxFracProcCd);
        }

        /// <summary>
        /// 売上税込み価格算定（数量、単価（税抜き）、金額（税込）より価格算定）（オーバーロード）
		/// </summary>
		/// <param name="taxationCode">課税区分：0:課税,1:非課税,2:課税（内税）</param>
		/// <param name="count">数量</param>
		/// <param name="unitPriceExc">単価（税抜き）</param>
		/// <param name="unitPriceInc">単価（税込み）</param>
		/// <param name="unitPriceTax">単価（消費税）</param>
		/// <param name="priceExc">価格（税抜き）</param>
		/// <param name="priceInc">価格（税込み）</param>
		/// <param name="priceTax">価格（消費税）</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="taxRate">消費税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
        public void CalcTaxIncFromTaxExc( int taxationCode, double count, ref double unitPriceExc, out double unitPriceInc, out double unitPriceTax,
			ref long priceExc, out long priceInc, out long priceTax, int fractionProcCode, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			this.CalcTaxIncFromTaxExc(taxationCode,
									  count,
									  ref unitPriceExc,
									  out unitPriceInc,
									  out unitPriceTax,
									  ref priceExc,
									  out priceInc,
									  out priceTax,
									  DCKHN01060CF.ctFracProcMoneyDiv_Price,
									  fractionProcCode,
									  taxRate,
									  taxFracProcUnit,
									  taxFracProcCd);
		}

        /// <summary>
        /// 売上税抜き価格算定処理（数量,単価(税込),金額(税込)より価格算定）
        /// </summary>
        /// <param name="taxationCode">課税区分：0:課税,1:非課税,2:課税（内税）</param>
        /// <param name="count">数量</param>
        /// <param name="unitPriceExc">単価（税抜き）</param>
        /// <param name="unitPriceInc">単価（税込み）</param>
        /// <param name="unitPriceTax">単価（消費税）</param>
        /// <param name="priceExc">価格（税抜き）</param>
        /// <param name="priceInc">価格（税込み）</param>
        /// <param name="priceTax">価格（消費税）</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="salesCnsTaxFrcProcCd">売上消費税端数処理コード</param>
        /// <param name="taxRate">消費税率</param>
        /// <param name="taxFracProcUnit">消費税端数処理単位</param>
        /// <param name="taxFracProcCd">消費税端数処理区分</param>
        public void CalcTaxExcFromTaxInc( int taxationCode, double count, out double unitPriceExc, ref double unitPriceInc, out double unitPriceTax,
            out long priceExc, ref long priceInc, out long priceTax, int fractionProcCode, int salesCnsTaxFrcProcCd, double taxRate, out  double taxFracProcUnit, out int taxFracProcCd )
        {
            this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            this.CalcTaxExcFromTaxInc(taxationCode,
                                      count,
                                      out unitPriceExc,
                                      ref unitPriceInc,
                                      out unitPriceTax,
                                      out priceExc,
                                      ref priceInc,
                                      out priceTax,
                                      DCKHN01060CF.ctFracProcMoneyDiv_Price,
                                      fractionProcCode,
                                      taxRate,
                                      taxFracProcUnit,
                                      taxFracProcCd);
        }

		/// <summary>
        /// 売上税抜き価格算定処理（数量,単価(税込),金額(税込)より価格算定）
		/// </summary>
		/// <param name="taxationCode">課税区分：0:課税,1:非課税,2:課税（内税）</param>
		/// <param name="count">数量</param>
		/// <param name="unitPriceExc">単価（税抜き）</param>
		/// <param name="unitPriceInc">単価（税込み）</param>
		/// <param name="unitPriceTax">単価（消費税）</param>
		/// <param name="priceExc">価格（税抜き）</param>
		/// <param name="priceInc">価格（税込み）</param>
		/// <param name="priceTax">価格（消費税）</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="taxRate">消費税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
        public void CalcTaxExcFromTaxInc( int taxationCode, double count, out double unitPriceExc, ref double unitPriceInc, out double unitPriceTax,
			out long priceExc, ref long priceInc, out long priceTax, int fractionProcCode, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			this.CalcTaxExcFromTaxInc(taxationCode,
									  count,
									  out unitPriceExc,
									  ref unitPriceInc,
									  out unitPriceTax,
									  out priceExc,
									  ref priceInc,
									  out priceTax,
									  DCKHN01060CF.ctFracProcMoneyDiv_Price,
									  fractionProcCode,
									  taxRate,
									  taxFracProcUnit,
									  taxFracProcCd);
		}

        /// <summary>
        /// 売上金額の丸め処理を行います。
        /// </summary>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="salesMoney">売上金額</param>
        /// <returns>まるめた売上金額</returns>
        public long RoundSalesMoney(int fractionProcCode, long salesMoney)
        {
            double fractionProcUnit;
            int fractionProcCd;

            return this.RoundSalesMoneyProc(salesMoney, fractionProcCode, out fractionProcUnit, out fractionProcCd);
        }

        /// <summary>
        /// 売上金額の丸め処理を行います。
        /// </summary>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="salesMoney">売上金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// <returns>まるめた売上金額</returns>
        public long RoundSalesMoney(int fractionProcCode, long salesMoney, out double fractionProcUnit, out int fractionProcCd)
        {
            return this.RoundSalesMoneyProc(salesMoney, fractionProcCode, out fractionProcUnit, out fractionProcCd);
        }

		#endregion

		#region 金額計算
		/// <summary>
		/// 税込み価格算定（数量,単価(税抜),金額(税抜)より価格算定）
		/// </summary>
		/// <param name="taxationCode">課税区分：0:課税,1:非課税,2:課税（内税）</param>
		/// <param name="count">数量</param>
		/// <param name="unitPriceExc">単価（税抜き）</param>
		/// <param name="unitPriceInc">単価（税込み）</param>
		/// <param name="unitPriceTax">単価（消費税）</param>
		/// <param name="priceExc">価格（税抜き）</param>
		/// <param name="priceInc">価格（税込み）</param>
		/// <param name="priceTax">価格（消費税）</param>
		/// <param name="fracProcMoneyDiv">端数処理金額区分</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="taxRate">消費税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
		private void CalcTaxIncFromTaxExc( int taxationCode, double count, ref double unitPriceExc, out double unitPriceInc, out double unitPriceTax,
			ref long priceExc, out long priceInc, out long priceTax, int fracProcMoneyDiv, int fractionProcCode, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			// 税抜き単価が０円の場合
			if (unitPriceExc == 0)
			{
				CalculateTax.CalcTaxIncFromTaxExc(taxationCode, ref priceExc, out priceInc, out priceTax, taxRate, taxFracProcUnit, taxFracProcCd);

				// 税込み単価←０円
				unitPriceInc = 0;

				// 消費税額(単価)←０円
				unitPriceTax = 0;
			}
			else
			{
				// 非課税の場合は税率を０にする
				if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
				{
					taxRate = 0;
				}

				// ① 消費税額(単価)を算定する        (消費税額(単価)＝(税抜き単価×消費税率))
				unitPriceTax = CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceExc);

				// ② 税込み単価を算定する            (税込み単価＝税抜き単価＋消費税額(単価))
				unitPriceInc = unitPriceExc + unitPriceTax;

				// ③ 税込み価格を算定する
				if (( taxationCode == (int)CalculateTax.TaxationCode.TaxExc ) || ( taxationCode == (int)CalculateTax.TaxationCode.TaxNone ))
				{
					// 外税、非課税の場合

					// ③－１ 税抜き価格を算定する    (税抜き価格＝数量×税抜き単価)
					priceExc = this.CalcPrice(count, unitPriceExc, fracProcMoneyDiv, fractionProcCode);

					// ③－２ 消費税額(価格)を算定する(消費税額(価格)＝税抜き価格×消費税率)
					priceTax = CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, priceExc);

					// ③－３ 税込み価格を算定する    (税込み価格＝税抜き価格＋消費税額(価格))
					priceInc = priceExc + priceTax;
				}
				else
				{
					// 内税の場合

					// ③－４ 税込み価格を算出        (税込み価格＝数量×税込み単価)
					priceInc = this.CalcPrice(count, unitPriceInc, fracProcMoneyDiv, fractionProcCode);

					// 税込みから税抜きを算定しなおす
					CalcTaxExcFromTaxInc(taxationCode, count, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, fracProcMoneyDiv, fractionProcCode, taxRate, taxFracProcUnit, taxFracProcCd);
				}
			}
		}

		/// <summary>
		/// 税抜き価格算定処理（数量,単価(税込),金額(税込)より価格算定）
		/// </summary>
		/// <param name="taxationCode">課税区分：0:課税,1:非課税,2:課税（内税）</param>
		/// <param name="count">数量</param>
		/// <param name="unitPriceExc">単価（税抜き）</param>
		/// <param name="unitPriceInc">単価（税込み）</param>
		/// <param name="unitPriceTax">単価（消費税）</param>
		/// <param name="priceExc">価格（税抜き）</param>
		/// <param name="priceInc">価格（税込み）</param>
		/// <param name="priceTax">価格（消費税）</param>
		/// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="taxRate">消費税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
        private void CalcTaxExcFromTaxInc( int taxationCode, double count, out double unitPriceExc, ref double unitPriceInc, out double unitPriceTax,
			out long priceExc, ref long priceInc, out long priceTax, int fracProcMoneyDiv, int fractionProcCode, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			// 税込み単価が０円の場合
			if (unitPriceInc == 0)
			{
				CalculateTax.CalcTaxExcFromTaxInc(taxationCode, out priceExc, ref priceInc, out priceTax, taxRate, taxFracProcUnit, taxFracProcCd);

				// 税抜き単価←０円
				unitPriceExc = 0;

				// 消費税額(単価)←０円
				unitPriceTax = 0;
			}
			else
			{
				// 非課税の場合は消費税率を０にする
				if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
				{
					taxRate = 0;
				}

				// ① 消費税額(単価)を算定する        (消費税額(単価)＝(税込み単価×消費税率)÷(１．０＋消費税率))
				unitPriceTax = CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceInc);

				// ② 税抜き単価を算定する            (税抜き単価＝税込み単価－消費税額(単価))
				unitPriceExc = unitPriceInc - unitPriceTax;

				if (( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ) || ( taxationCode == (int)CalculateTax.TaxationCode.TaxNone ))
				{
					// 内税の場合
					// ③－１ 税込み価格を算出        (税込み価格＝数量×税込み単価)
					priceInc = this.CalcPrice(count, unitPriceInc, fracProcMoneyDiv, fractionProcCode);

					// ③－２ 消費税額(価格)を算定する(消費税額(価格)＝(税込み価格×消費税率)÷(１．０＋消費税率))
					priceTax = CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, priceInc);

					// ③－３ 税抜き価格を算定する    (税抜き価格＝税込み価格－消費税額(価格)
					priceExc = priceInc - priceTax;
				}
				else
				{
					// 外税の場合
					// ③－４   税抜き価格を算定する  (税抜き価格＝数量×税抜き単価)
					priceExc = this.CalcPrice(count, unitPriceExc, fracProcMoneyDiv, fractionProcCode);
					// 税抜きから税込みを算定し直す
					CalcTaxIncFromTaxExc(taxationCode, count, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, fracProcMoneyDiv, fractionProcCode, taxRate, taxFracProcUnit, taxFracProcCd);
				}
			}
		}
		#endregion

		#region 粗利関係

		/// <summary>
		/// 粗利率算定（端数処理単位:0.001円、端数処理区分:四捨五入)固定
		/// </summary>
		/// <param name="unitCost">原価</param>
		/// <param name="salesPrice">売上金額</param>
		/// <returns></returns>
		public double CalculateMarginRate( double unitCost, double salesPrice )
		{
			// 端数処理固定呼出
			return this.CalcRateFrac(unitCost, salesPrice);
		}

		#endregion

		#endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //		
        #region ■Private Method

		/// <summary>
		/// 金額計算
		/// </summary>
		/// <param name="count">数量</param>	
		/// <param name="unitPrice">単価</param>
		/// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>	
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <returns>端数処理した金額</returns>
		private long CalcPrice( double count, double unitPrice, int fracProcMoneyDiv, int fractionProcCode )
		{
			// そのまま計算（数量×単価）
			double retPrice = unitPrice * count;

			// 端数処理方法を取得
			double fracProcUnit;
			int fracProcCd;
			this.GetSalesFractionProcInfo(fracProcMoneyDiv, fractionProcCode, retPrice, out fracProcUnit, out fracProcCd);

			//　端数処理
			FractionCalculate.FracCalcMoney(retPrice, fracProcUnit, fracProcCd, out retPrice);

			return (long)retPrice;
		}

        /// <summary>
        /// 金額まるめ処理
        /// </summary>
        /// <param name="salesMoney">売上金額</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="fracProcUnit">端数処理単位</param>
        /// <param name="fracProcCd">端数処理区分</param>
        /// <returns>まるめた売上金額</returns>
        private long RoundSalesMoneyProc(long salesMoney, int fractionProcCode, out double fracProcUnit, out int fracProcCd)
        {
            this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Price, fractionProcCode, salesMoney, out fracProcUnit, out fracProcCd);

            //　端数処理
            long retPrice;
            FractionCalculate.FracCalcMoney(salesMoney, fracProcUnit, fracProcCd, out retPrice);

            return retPrice;
        }

		/// <summary>
		/// 単価まるめ処理
		/// </summary>
		/// <param name="unitPrice">単価</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="fracProcUnit">端数処理単位</param>
		/// <param name="fracProcCd">端数処理区分</param>
		/// <returns>まるめた単価</returns>
		private double RountSalesUnitPrice( double unitPrice, int fractionProcCode, out double fracProcUnit, out int fracProcCd )
		{
			this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_UnitPrice, fractionProcCode, unitPrice, out fracProcUnit, out fracProcCd);

			//　端数処理
			double retPrice;
			FractionCalculate.FracCalcMoney(unitPrice, fracProcUnit, fracProcCd, out retPrice);

			return retPrice;
		}

		/// <summary>
		/// 売上金額処理区分設定マスタより、対象金額に該当する端数処理単位、端数処理コードを取得します。
		/// </summary>
		/// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="price">対象金額</param>
		/// <param name="fractionProcUnit">端数処理単位</param>
		/// <param name="fractionProcCd">端数処理区分</param>
		private void GetSalesFractionProcInfo( int fracProcMoneyDiv, int fractionProcCode, double price, out double fractionProcUnit, out int fractionProcCd )
		{
			fractionProcUnit = DCKHN01060CF.GetDefaultFractionProcUnit(fracProcMoneyDiv);
			fractionProcCd = DCKHN01060CF.GetDefaultFractionProcCd(fracProcMoneyDiv);

            if (_salesProcMoneyList == null || _salesProcMoneyList.Count == 0) return;

            List<SalesProcMoney> salesProcMoneyList = _salesProcMoneyList.FindAll(
                                        delegate(SalesProcMoney salesProcMoney)
                                        {
                                            if (( salesProcMoney.FracProcMoneyDiv == fracProcMoneyDiv ) &&
                                                ( salesProcMoney.FractionProcCode == fractionProcCode ) &&
                                                ( salesProcMoney.UpperLimitPrice >= price ))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
            if (salesProcMoneyList != null && salesProcMoneyList.Count > 0)
            {
                fractionProcUnit = salesProcMoneyList[0].FractionProcUnit;
                fractionProcCd = salesProcMoneyList[0].FractionProcCd;
            }
		}

		/// <summary>
		/// 率端数処理
		/// </summary>
		/// <param name="numerator">数値(分子)</param>
		/// <param name="denominator">数値(分母)</param>
		/// <returns></returns>
		private double CalcRateFrac( double numerator, double denominator )
		{
			double fracProcUnit = 0.0001; // 小数点以下第３位
			int fracProcCd = 2; // 四捨五入

			//　端数処理
			double retRate;
			FractionCalculate.FracCalcRate(numerator, denominator, fracProcUnit, fracProcCd, out retRate);

			return retRate;
		}

		#endregion
	}
}
