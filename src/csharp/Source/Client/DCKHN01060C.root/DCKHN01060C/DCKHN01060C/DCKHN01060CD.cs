using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library;
using Broadleaf.Application.UIData;
using System.Data;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 仕入金額計算クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入に関する金額の計算を行います。</br>
	/// <br>Programmer : 21024　佐々木 健</br>
	/// <br>Date       : 2008.06.19</br>
	/// </remarks>
	public class StockPriceCalculate
	{
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //		
        #region ■Private Members

		private List<StockProcMoney> _stockProcMoneyList;

		#endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //		
        #region ■Constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public StockPriceCalculate()
		{
		}

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="stockProcMoneyList">仕入金額処理区分設定マスタリスト</param>
        public StockPriceCalculate( List<StockProcMoney> stockProcMoneyList )
        {
            this.CacheStockProcMoneyList(stockProcMoneyList);
        }
		#endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //		
        #region ■Public Method

		/// <summary>
		/// 仕入金額端数処理区分設定マスタキャッシュ
		/// </summary>
		/// <param name="stockProcMoneyList">仕入金額処理区分設定マスタリスト</param>
		public void CacheStockProcMoneyList(List<StockProcMoney> stockProcMoneyList)
		{
			this._stockProcMoneyList = stockProcMoneyList;
            this._stockProcMoneyList.Sort(new DCKHN01060CF.StockProcMoneyComparer());
		}

        /// <summary>
        /// 税抜き金額、税込金額を算定します。（オーバーロード）
        /// </summary>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="stockCnsTaxFrcProcCd">仕入消費税端数処理コード</param>
        /// <param name="taxRate">税率</param>
        /// <param name="priceTaxExc">税抜き金額</param>
        /// <param name="priceTaxInc">税込み金額</param>
        /// <param name="priceConsTax">消費税金額</param>
        /// <param name="taxFracProcUnit">消費税端数処理単位</param>
        /// <param name="taxFracProcCd">消費税端数処理区分</param>
        public void CalculatePrice( int taxationCode, double targetPrice, double taxRate, int stockCnsTaxFrcProcCd, out double priceTaxExc, out double priceTaxInc, out double priceConsTax, out double taxFracProcUnit, out int taxFracProcCd )
        {
            this.GetStockFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, stockCnsTaxFrcProcCd, targetPrice, out taxFracProcUnit, out taxFracProcCd);

            CalculateTax.CalculatePrice(taxationCode, targetPrice, taxRate, taxFracProcUnit, taxFracProcCd, out priceTaxExc, out priceTaxInc, out priceConsTax);
        }

        /// <summary>
        /// 税抜き金額、税込金額を算定します。（オーバーロード）
        /// </summary>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="stockCnsTaxFrcProcCd">仕入消費税端数処理コード</param>
        /// <param name="taxRate">税率</param>
        /// <param name="priceTaxExc">税抜き金額</param>
        /// <param name="priceTaxInc">税込み金額</param>
        /// <param name="priceConsTax">消費税金額</param>
        /// <param name="taxFracProcUnit">消費税端数処理単位</param>
        /// <param name="taxFracProcCd">消費税端数処理区分</param>
        public void CalculatePrice( int taxationCode, long targetPrice, double taxRate, int stockCnsTaxFrcProcCd, out long priceTaxExc, out long priceTaxInc, out long priceConsTax, out double taxFracProcUnit, out int taxFracProcCd )
        {
            this.GetStockFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, stockCnsTaxFrcProcCd, targetPrice, out taxFracProcUnit, out taxFracProcCd);

            CalculateTax.CalculatePrice(taxationCode, targetPrice, taxRate, taxFracProcUnit, taxFracProcCd, out priceTaxExc, out priceTaxInc, out priceConsTax);
        }
      
        /// <summary>
        /// 仕入税込み金額算定（数量,単価(税抜),金額(税抜)より価格算定）（オーバーロード）
        /// </summary>
        /// <param name="taxationCode">課税区分：0:課税,1:非課税,2:課税（内税）</param>
        /// <param name="count">仕入数</param>
        /// <param name="unitPriceExc">原単価（税抜き）</param>
        /// <param name="unitPriceInc">原単価（税込み）</param>
        /// <param name="unitPriceTax">原単価（消費税）</param>
        /// <param name="priceExc">価格（税抜き）</param>
        /// <param name="priceInc">価格（税込み）</param>
        /// <param name="priceTax">価格（消費税）</param>
        /// <param name="taxRate">消費税率</param>
        /// <param name="stockMoneyFrcProcCd">仕入金額端数処理コード</param>
        /// <param name="stockCnsTaxFrcProcCd">仕入消費税端数処理コード</param>
        /// <param name="taxFracProcUnit">消費税端数処理単位</param>
        /// <param name="taxFracProcCd">消費税端数処理区分</param>
        public void CalcTaxIncFromTaxExc( int taxationCode, double count, ref double unitPriceExc, out double unitPriceInc, out double unitPriceTax,
            ref long priceExc, out long priceInc, out long priceTax, int stockMoneyFrcProcCd, double taxRate, int stockCnsTaxFrcProcCd, out double taxFracProcUnit, out int taxFracProcCd )
        {
            this.GetStockFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, stockCnsTaxFrcProcCd, unitPriceExc, out taxFracProcUnit, out taxFracProcCd);

            this.CalcTaxIncFromTaxExc(taxationCode, count, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);
        }


		/// <summary>
        /// 仕入税込み金額算定（数量,単価(税抜),金額(税抜)より価格算定）（オーバーロード）
		/// </summary>
		/// <param name="taxationCode">課税区分：0:課税,1:非課税,2:課税（内税）</param>
		/// <param name="count">仕入数</param>
		/// <param name="unitPriceExc">原単価（税抜き）</param>
		/// <param name="unitPriceInc">原単価（税込み）</param>
		/// <param name="unitPriceTax">原単価（消費税）</param>
		/// <param name="priceExc">価格（税抜き）</param>
		/// <param name="priceInc">価格（税込み）</param>
		/// <param name="priceTax">価格（消費税）</param>
		/// <param name="stockMoneyFrcProcCd">仕入金額端数処理コード</param>
		/// <param name="taxRate">消費税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
        public void CalcTaxIncFromTaxExc( int taxationCode, double count, ref double unitPriceExc, out double unitPriceInc, out double unitPriceTax,
			ref long priceExc, out long priceInc, out long priceTax, int stockMoneyFrcProcCd, double taxRate, double taxFracProcUnit, int taxFracProcCd )
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
					priceExc = this.CalcPrice(count, unitPriceExc, stockMoneyFrcProcCd);

					// ③－２ 消費税額(価格)を算定する(消費税額(価格)＝税抜き価格×消費税率)
					priceTax = CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, priceExc);

					// ③－３ 税込み価格を算定する    (税込み価格＝税抜き価格＋消費税額(価格))
					priceInc = priceExc + priceTax;
				}
				else
				{
					// 内税の場合

					// ③－４ 税込み価格を算出        (税込み価格＝数量×税込み単価)
					priceInc = this.CalcPrice(count, unitPriceInc, stockMoneyFrcProcCd);

					// 税込みから税抜きを算定しなおす
					CalcTaxExcFromTaxInc(taxationCode, count, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);
				}
			}
		}

        /// <summary>
        /// 仕入税抜き金額算定処理（数量,単価(税込),金額(税込)より価格算定）
        /// </summary>
        /// <param name="taxationCode">課税区分：0:課税,1:非課税,2:課税（内税）</param>
        /// <param name="count">仕入数</param>
        /// <param name="unitPriceExc">原単価（税抜き）</param>
        /// <param name="unitPriceInc">原単価（税込み）</param>
        /// <param name="unitPriceTax">原単価（消費税）</param>
        /// <param name="priceExc">価格（税抜き）</param>
        /// <param name="priceInc">価格（税込み）</param>
        /// <param name="priceTax">価格（消費税）</param>
        /// <param name="stockMoneyFrcProcCd">仕入金額端数処理コード</param>
        /// <param name="stockCnsTaxFrcProcCd">仕入消費税端数処理コード</param>
        /// <param name="taxRate">消費税率</param>
        /// <param name="taxFracProcUnit">消費税端数処理単位</param>
        /// <param name="taxFracProcCd">消費税端数処理区分</param>
        public void CalcTaxExcFromTaxInc( int taxationCode, double count, out double unitPriceExc, ref double unitPriceInc, out double unitPriceTax,
            out long priceExc, ref long priceInc, out long priceTax, int stockMoneyFrcProcCd, int stockCnsTaxFrcProcCd, double taxRate, out double taxFracProcUnit, out int taxFracProcCd )
        {
            this.GetStockFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, stockCnsTaxFrcProcCd, unitPriceInc, out taxFracProcUnit, out taxFracProcCd);

            this.CalcTaxExcFromTaxInc(taxationCode, count, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);
        }

		/// <summary>
        /// 仕入税抜き金額算定処理（数量,単価(税込),金額(税込)より価格算定）
		/// </summary>
		/// <param name="taxationCode">課税区分：0:課税,1:非課税,2:課税（内税）</param>
		/// <param name="count">仕入数</param>
		/// <param name="unitPriceExc">原単価（税抜き）</param>
		/// <param name="unitPriceInc">原単価（税込み）</param>
		/// <param name="unitPriceTax">原単価（消費税）</param>
		/// <param name="priceExc">価格（税抜き）</param>
		/// <param name="priceInc">価格（税込み）</param>
		/// <param name="priceTax">価格（消費税）</param>
		/// <param name="stockMoneyFrcProcCd">仕入金額端数処理コード</param>
		/// <param name="taxRate">消費税率</param>
		/// <param name="taxFracProcUnit">消費税端数処理単位</param>
		/// <param name="taxFracProcCd">消費税端数処理区分</param>
        public void CalcTaxExcFromTaxInc( int taxationCode, double count, out double unitPriceExc, ref double unitPriceInc, out double unitPriceTax,
			out long priceExc, ref long priceInc, out long priceTax, int stockMoneyFrcProcCd, double taxRate, double taxFracProcUnit, int taxFracProcCd )
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
					priceInc = this.CalcPrice(count, unitPriceInc, stockMoneyFrcProcCd);

					// ③－２ 消費税額(価格)を算定する(消費税額(価格)＝(税込み価格×消費税率)÷(１．０＋消費税率))
					priceTax = CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, priceInc);

					// ③－３ 税抜き価格を算定する    (税抜き価格＝税込み価格－消費税額(価格)
					priceExc = priceInc - priceTax;
				}
				else
				{
					// 外税の場合
					// ③－４   税抜き価格を算定する  (税抜き価格＝数量×税抜き単価)
					priceExc = this.CalcPrice(count, unitPriceExc, stockMoneyFrcProcCd);
					// 税抜きから税込みを算定し直す
					CalcTaxIncFromTaxExc(taxationCode, count, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);
				}
			}
		}


        /// <summary>
        /// 仕入金額の丸め処理を行います。（オーバーロード）
        /// </summary>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="stockPrice">仕入金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// <returns>まるめた仕入金額</returns>
        public long RoundStockPrice(int fractionProcCode, long stockPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            return this.RoundStockPriceProc(stockPrice, fractionProcCode, out fractionProcUnit, out fractionProcCd);
        }

        /// <summary>
        /// 仕入金額の丸め処理を行います。（オーバーロード）
        /// </summary>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="stockPrice">対象金額</param>
        /// <returns>まるめた仕入金額</returns>
        public long RoundStockPrice(int fractionProcCode, long stockPrice)
        {
            double fractionProcUnit;
            int fractionProcCd;
            return this.RoundStockPriceProc(stockPrice, fractionProcCode, out fractionProcUnit, out fractionProcCd);
        }

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
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <returns>端数処理した金額</returns>
		private long CalcPrice( double count, double unitPrice, int fractionProcCode )
		{
			// そのまま計算（数量×単価）
			double retPrice = unitPrice * count;

			// 端数処理方法を取得
			double fracProcUnit;
			int fracProcCd;
			this.GetStockFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Price, fractionProcCode, retPrice, out fracProcUnit, out fracProcCd);

			//　端数処理
			FractionCalculate.FracCalcMoney(retPrice, fracProcUnit, fracProcCd, out retPrice);

			return (long)retPrice;
		}

        /// <summary>
        /// 仕入金額丸め処理
        /// </summary>
        /// <returns></returns>
        private long RoundStockPriceProc(long stockPrice, int fractionProcCode, out double fracProcUnit, out int fracProcCd)
        {
            this.GetStockFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Price, fractionProcCode, stockPrice, out fracProcUnit, out fracProcCd);

            //　端数処理
            long retPrice;
            FractionCalculate.FracCalcMoney(stockPrice, fracProcUnit, fracProcCd, out retPrice);

            return retPrice;
        }

		/// <summary>
        /// 単価丸め処理
		/// </summary>
		/// <param name="unitPrice">単価</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="fracProcUnit">端数処理単位</param>
		/// <param name="fracProcCd">端数処理区分</param>
		/// <returns>端数処理した単価</returns>
		private double RoundStockUnitPriceProc( double unitPrice, int fractionProcCode, out double fracProcUnit, out int fracProcCd )
		{
			this.GetStockFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_UnitPrice, fractionProcCode, unitPrice, out fracProcUnit, out fracProcCd);

			//　端数処理
			double retPrice;
			FractionCalculate.FracCalcMoney(unitPrice, fracProcUnit, fracProcCd, out retPrice);

			return retPrice;
		}



		/// <summary>
		/// 仕入金額処理区分設定マスタより、対象金額に該当する端数処理単位、端数処理コードを取得します。
		/// </summary>
		/// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="price">対象金額</param>
		/// <param name="fractionProcUnit">端数処理単位</param>
		/// <param name="fractionProcCd">端数処理区分</param>
		private void GetStockFractionProcInfo( int fracProcMoneyDiv, int fractionProcCode, double price, out double fractionProcUnit, out int fractionProcCd )
		{
			fractionProcUnit = DCKHN01060CF.GetDefaultFractionProcUnit(fracProcMoneyDiv);
			fractionProcCd = DCKHN01060CF.GetDefaultFractionProcCd(fracProcMoneyDiv);

            if (_stockProcMoneyList == null || _stockProcMoneyList.Count == 0) return;

            List<StockProcMoney> stockProcMoneyList = _stockProcMoneyList.FindAll(
                                        delegate(StockProcMoney stockProcMoney)
                                        {
                                            if (( stockProcMoney.FracProcMoneyDiv == fracProcMoneyDiv ) &&
                                                ( stockProcMoney.FractionProcCode == fractionProcCode ) &&
                                                ( stockProcMoney.UpperLimitPrice >= price ))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
            if (stockProcMoneyList != null && stockProcMoneyList.Count > 0)
            {
                fractionProcUnit = stockProcMoneyList[0].FractionProcUnit;
                fractionProcCd = stockProcMoneyList[0].FractionProcCd;
            }
		}
		#endregion
	}
}
