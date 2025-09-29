using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Library;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 消費税計算クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 消費税の計算を行います。</br>
	/// <br>Programmer : 21024　佐々木 健</br>
	/// <br>Date       : 2008.06.19</br>
	/// </remarks>
	public static class CalculateTax
	{
        // ===================================================================================== //
        // 列挙型
        // ===================================================================================== //		
        #region ■Enums
		/// <summary>
		/// 課税区分
		/// </summary>
		public enum TaxationCode : int
		{
			/// <summary>外税</summary>
			TaxExc = 0,
			/// <summary>非課税</summary>
			TaxNone = 1,
			/// <summary>内税</summary>
			TaxInc = 2,
		}
		#endregion

        // ===================================================================================== //
        // パブリック スタティックメソッド
        // ===================================================================================== //		
        #region ■Public Static Methods

        /// <summary>
        /// 税抜き金額、税込金額を算定します。（オーバーロード）
        /// </summary>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="taxfracProcUnit">消費税端数処理単位</param>
        /// <param name="taxFracProcCd">消費税端数処理区分</param>
        /// <param name="taxRate">税率</param>
        /// <param name="priceTaxExc">税抜き金額</param>
        /// <param name="priceTaxInc">税込み金額</param>
        /// <param name="priceConsTax">消費税金額</param>
        public static void CalculatePrice( int taxationCode, double targetPrice, double taxRate, double taxfracProcUnit, int taxFracProcCd, out double priceTaxExc, out double priceTaxInc, out double priceConsTax )
        {
            priceTaxExc = 0;
            priceTaxInc = 0;
            priceConsTax = 0;
            switch (taxationCode)
            {
                // 外税
                case (int)CalculateTax.TaxationCode.TaxExc:
                    {
                        priceTaxExc = targetPrice;
                        CalcTaxIncFromTaxExc(taxationCode, ref priceTaxExc, out priceTaxInc, out priceConsTax, taxRate, taxfracProcUnit, taxFracProcCd);
                        break;
                    }
                // 内税
                case (int)CalculateTax.TaxationCode.TaxInc:
                    {
                        priceTaxInc = targetPrice;
                        CalcTaxExcFromTaxInc(taxationCode, out priceTaxExc, ref priceTaxInc, out priceConsTax, taxRate, taxfracProcUnit, taxFracProcCd);
                        break;
                    }
                // 非課税
                case (int)CalculateTax.TaxationCode.TaxNone:
                    {
                        priceTaxInc = targetPrice;
                        priceTaxExc = targetPrice;
                        priceConsTax = 0;
                        break;
                    }
            }
        }

        /// <summary>
        /// 税抜き金額、税込金額を算定します。（オーバーロード）
        /// </summary>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="taxfracProcUnit">消費税端数処理単位</param>
        /// <param name="taxFracProcCd">消費税端数処理区分</param>
        /// <param name="taxRate">税率</param>
        /// <param name="priceTaxExc">税抜き金額</param>
        /// <param name="priceTaxInc">税込み金額</param>
        /// <param name="priceConsTax">消費税金額</param>
        public static void CalculatePrice( int taxationCode, long targetPrice, double taxRate, double taxfracProcUnit, int taxFracProcCd, out long priceTaxExc, out long priceTaxInc, out long priceConsTax )
        {
            priceTaxExc = 0;
            priceTaxInc = 0;
            priceConsTax = 0;
            switch (taxationCode)
            {
                // 外税
                case (int)CalculateTax.TaxationCode.TaxExc:
                    {
                        priceTaxExc = targetPrice;
                        CalcTaxIncFromTaxExc(taxationCode, ref priceTaxExc, out priceTaxInc, out priceConsTax, taxRate, taxfracProcUnit, taxFracProcCd);
                        break;
                    }
                // 内税
                case (int)CalculateTax.TaxationCode.TaxInc:
                    {
                        priceTaxInc = targetPrice;
                        CalcTaxExcFromTaxInc(taxationCode, out priceTaxExc, ref priceTaxInc, out priceConsTax, taxRate, taxfracProcUnit, taxFracProcCd);
                        break;
                    }
                // 非課税
                case (int)CalculateTax.TaxationCode.TaxNone:
                    {
                        priceTaxInc = targetPrice;
                        priceTaxExc = targetPrice;
                        priceConsTax = 0;
                        break;
                    }
            }
        }

		/// <summary>
		/// 税込み価格算定（金額(税抜)より価格算定）（オーバーロード）
		/// </summary>
		/// <param name="taxationCode">課税区分：0:課税,1:非課税,2:課税（内税）</param>
		/// <param name="priceExc">価格（税抜き）</param>
		/// <param name="priceInc">価格（税込み）</param>
		/// <param name="priceTax">価格（消費税）</param>
		/// <param name="taxRate">税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
		public static void CalcTaxIncFromTaxExc( int taxationCode, ref double priceExc, out double priceInc, out double priceTax, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			// 消費税額を取得
			priceTax = (long)CalculateTax.Fraction(priceExc * taxRate, taxFracProcUnit, taxFracProcCd);

			priceInc = priceExc + priceTax;

			if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
			{
				// 内税の場合
				CalcTaxExcFromTaxInc(taxationCode, out priceExc, ref priceInc, out priceTax, taxRate, taxFracProcUnit, taxFracProcCd);
			}
		}

		/// <summary>
		/// 税込み価格算定（金額(税抜)より価格算定）（オーバーロード）
		/// </summary>
		/// <param name="taxationCode">課税区分：0:課税,1:非課税,2:課税（内税）</param>
		/// <param name="priceExc">価格（税抜き）</param>
		/// <param name="priceInc">価格（税込み）</param>
		/// <param name="priceTax">価格（消費税）</param>
		/// <param name="taxRate">税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
		public static void CalcTaxIncFromTaxExc( int taxationCode, ref long priceExc, out long priceInc, out long priceTax, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			// 消費税額を取得
			priceTax = (long)CalculateTax.Fraction(priceExc * taxRate, taxFracProcUnit, taxFracProcCd);

			priceInc = priceExc + priceTax;

			if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
			{
				// 内税の場合
				CalcTaxExcFromTaxInc(taxationCode, out priceExc, ref priceInc, out priceTax, taxRate, taxFracProcUnit, taxFracProcCd);
			}
		}

		/// <summary>
		/// 税抜き価格算定（単価(税込),税率より価格算定）（オーバーロード）
		/// </summary>
		/// <param name="taxationCode">課税区分：0:課税,1:非課税,2:課税（内税）</param>
		/// <param name="priceExc">価格（税抜き）</param>
		/// <param name="priceInc">価格（税込み）</param>
		/// <param name="priceTax">価格（消費税）</param>
		/// <param name="taxRate">消費税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
		public static void CalcTaxExcFromTaxInc( int taxationCode, out double priceExc, ref double priceInc, out double priceTax, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			// 消費税額を算定 ･･･ （金額(税込) × 消費税率）÷（１．０ ＋ 消費税率）
			priceTax = GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, priceInc);
			priceExc = priceInc - priceTax;

			if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
			{
				// 外税→内税計算を行う！
				CalcTaxIncFromTaxExc(taxationCode, ref priceExc, out priceInc, out priceTax, taxRate, taxFracProcUnit, taxFracProcCd);
			}
		}

		/// <summary>
		/// 税抜き価格算定（単価(税込),税率より価格算定）（オーバーロード）
		/// </summary>
		/// <param name="taxationCode">課税区分：0:課税,1:非課税,2:課税（内税）</param>
		/// <param name="priceExc">価格（税抜き）</param>
		/// <param name="priceInc">価格（税込み）</param>
		/// <param name="priceTax">価格（消費税）</param>
		/// <param name="taxRate">消費税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
		public static void CalcTaxExcFromTaxInc( int taxationCode, out long priceExc, ref long priceInc, out long priceTax, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			// 消費税額を算定 ･･･ （金額(税込) × 消費税率）÷（１．０ ＋ 消費税率）
			priceTax = GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, priceInc);
			priceExc = priceInc - priceTax;

			if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
			{
				// 外税→内税計算を行う！
				CalcTaxIncFromTaxExc(taxationCode, ref priceExc, out priceInc, out priceTax, taxRate, taxFracProcUnit, taxFracProcCd);
			}
		}

		/// <summary>
		/// 税込み金額から消費税金額を算定
		/// </summary>
		/// <param name="taxRate">消費税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
		/// <param name="priceInc">税込み単価</param>
		/// <returns>消費税金額</returns>
		public static long GetTaxFromPriceInc( double taxRate, double taxFracProcUnit, int taxFracProcCd, double priceInc )
		{
			double base_double_rate = CalculateConsTax.Round(taxRate * 1000);
			int base_int32_rate = (int)base_double_rate;

			long priceIncInteger = (Int64)priceInc;
			double priceIncDecimal = (double)( (decimal)priceInc % 1 );

			priceIncDecimal = CalculateConsTax.Round(priceIncDecimal * 10);
			long base_int64_priceinc = ( priceIncInteger * 10 ) + (long)priceIncDecimal;

			long base_int64_tax = base_int64_priceinc * base_int32_rate;
			double base_double_tax = base_int64_tax / ( 1000 + base_int32_rate );
			base_double_tax /= 10;
			base_double_tax = Fraction(base_double_tax, taxFracProcUnit, taxFracProcCd);
			return (long)base_double_tax;
		}

		/// <summary>
		/// 税抜き金額から消費税金額を算定
		/// </summary>
		/// <param name="taxRate">税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理区分</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
		/// <param name="priceExc">単価</param>
		/// <returns>消費税</returns>
		public static long GetTaxFromPriceExc( double taxRate, double taxFracProcUnit, int taxFracProcCd, double priceExc )
		{
			return (long)Fraction(priceExc * taxRate, taxFracProcUnit, taxFracProcCd);
		}

		/// <summary>
		/// 端数処理
		/// </summary>
		/// <param name="targetPrice">消費税</param>
		/// <param name="fracProcUnit">消費税端数処理単位</param>
		/// <param name="fracProcCd">消費税端数処理区分</param>
		/// <returns>端数処理した消費税</returns>
		private static double Fraction( double targetPrice, double fracProcUnit, int fracProcCd )
		{
			double retValue;
			FractionCalculate.FracCalcMoney(targetPrice, fracProcUnit, fracProcCd, out retValue);

			return retValue;
		}

		#endregion
	}
}
