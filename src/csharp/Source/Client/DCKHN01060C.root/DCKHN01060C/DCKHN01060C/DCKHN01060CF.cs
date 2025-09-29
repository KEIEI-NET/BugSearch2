using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Common
{
	internal static class DCKHN01060CF
	{
        // ===================================================================================== //
        // パブリック変数
        // ===================================================================================== //		
        #region ■Public Members

		/// <summary>端数処理対象金額区分（金額）</summary>
		public const int ctFracProcMoneyDiv_Price = 0;
		/// <summary>端数処理対象金額区分（消費税）</summary>
		public const int ctFracProcMoneyDiv_Tax = 1;
		/// <summary>端数処理対象金額区分（単価）</summary>
		public const int ctFracProcMoneyDiv_UnitPrice = 2;
        ///// <summary>端数処理対象金額区分（原価単価）</summary>
        //public const int ctFracProcMoneyDiv_CostUnitPrice = 3;
        ///// <summary>端数処理対象金額区分（原価）</summary>
        //public const int ctFracProcMoneyDiv_CostPrice = 4;

		#endregion

        // ===================================================================================== //
        // パブリック スタティックメソッド
        // ===================================================================================== //		
        #region ■Public Static Methods

		/// <summary>
		/// 端数処理対象金額設定区分に従った端数処理単位のデフォルト値を取得します。
		/// </summary>
		/// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
		/// <returns>端数処理単位</returns>
		public static double GetDefaultFractionProcUnit( int fracProcMoneyDiv )
		{
			switch (fracProcMoneyDiv)
			{
				// 金額、原価、消費税は1円単位
				case ctFracProcMoneyDiv_Price:
				//case ctFracProcMoneyDiv_CostPrice:
				case ctFracProcMoneyDiv_Tax:
					{
						return 1;
					}
				default:
					{
						return 0.01;
					}
			}
		}

		/// <summary>
		/// 端数処理区分初期値取得
		/// </summary>
		/// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
		/// <returns>端数処理区分</returns>
		public static int GetDefaultFractionProcCd( int fracProcMoneyDiv )
		{
			// 1:切捨て
			return 1;
		}

        /// <summary>
        /// 仕入金額処理区分マスタデータ比較クラス(端数処理対象金額(昇順)、端数処理コード(昇順)、上限金額(昇順))
        /// </summary>
        /// <remarks></remarks>
        internal class StockProcMoneyComparer : Comparer<StockProcMoney>
        {

            public override int Compare(StockProcMoney x, StockProcMoney y)
            {
                int result = x.FracProcMoneyDiv.CompareTo(y.FracProcMoneyDiv);
                if (result != 0) return result;

                result = x.FractionProcCode.CompareTo(y.FractionProcCode);
                if (result != 0) return result;

                result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }

        /// <summary>
        /// 売上金額処理区分マスタデータ比較クラス(端数処理対象金額(昇順)、端数処理コード(昇順)、上限金額(昇順))
        /// </summary>
        /// <remarks></remarks>
        internal class SalesProcMoneyComparer : Comparer<SalesProcMoney>
        {

            public override int Compare(SalesProcMoney x, SalesProcMoney y)
            {
                int result = x.FracProcMoneyDiv.CompareTo(y.FracProcMoneyDiv);
                if (result != 0) return result;

                result = x.FractionProcCode.CompareTo(y.FractionProcCode);
                if (result != 0) return result;

                result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }

        /// <summary>
        /// 掛率優先管理データ比較クラス(拠点コード(昇順)、単価種類(昇順)、掛率優先順位(昇順))
        /// </summary>
        /// <remarks></remarks>
        internal class RateProtyMngComparer : Comparer<RateProtyMng>
        {

            public override int Compare(RateProtyMng x, RateProtyMng y)
            {
                int result = x.SectionCode.CompareTo(y.SectionCode);
                if (result != 0) return result;

                result = x.UnitPriceKind.CompareTo(y.UnitPriceKind);
                if (result != 0) return result;

                result = x.RatePriorityOrder.CompareTo(y.RatePriorityOrder);
                return result;
            }
        }

        /// <summary>
        /// 掛率データ比較クラス(ロット(昇順))
        /// </summary>
        /// <remarks></remarks>
        internal class RateComparer : Comparer<Rate>
        {
            public override int Compare(Rate x, Rate y)
            {
                int result = x.LotCount.CompareTo(y.LotCount);
                return result;
            }
        }

        // 2011/07/20 add wangf start
        /// <summary>
        /// 掛率優先管理データ比較クラス(単価種類(昇順)、掛率優先順位(昇順)、拠点コード(降順))
        /// </summary>
        /// <remarks></remarks>
        internal class RateProtyMngComparerUnitPriceKind : Comparer<RateProtyMng>
        {
            public override int Compare(RateProtyMng x, RateProtyMng y)
            {
                int result = x.UnitPriceKind.CompareTo(y.UnitPriceKind);
                if (result != 0) return result;

                result = x.RatePriorityOrder.CompareTo(y.RatePriorityOrder);
                if (result != 0) return result;

                result = y.SectionCode.CompareTo(x.SectionCode);
                return result;
            }
        }
        // 2011/07/20 add wangf end

		#endregion
	}
}
