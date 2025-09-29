using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 売上仕入対比表テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 売上仕入対比表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 96186 立花 裕輔</br>
	/// <br>Date       : 2007.03.14</br>
	/// <br></br>
    /// <br>Update Note: 2008.12.09 30452 上野 俊治</br>
    /// <br>            ・PM.NS対応</br>
	/// </remarks>
	public class DCTOK02154EA
	{
		#region ■ Public Const

		/// <summary> テーブル名称 </summary>
		public const string ct_Tbl_SalStcCompMonthYearReportData = "Tbl_SalStcCompMonthYearReportData";

		/// <summary> 拠点コード </summary>
		public const string ct_Col_SectionCd = "SectionCd";
		/// <summary> 自社名称1 </summary>
		public const string ct_Col_SectionGuideNm = "SectionGuideNm";
        // --- DEL 2008/12/09 -------------------------------->>>>>
        ///// <summary> 仕入先コード </summary>
        //public const string ct_Col_CustomerCode = "CustomerCode";
        ///// <summary> 仕入先略称 </summary>
        //public const string ct_Col_CustomerSnm = "CustomerSnm";
        // --- DEL 2008/12/09 --------------------------------<<<<<
        // --- ADD 2008/12/09 -------------------------------->>>>>
        /// <summary> 仕入先コード </summary>
        public const string ct_Col_SupplierCode = "SupplierCode";
        /// <summary> 仕入先略称 </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        // --- ADD 2008/12/09 --------------------------------<<<<<
		/// <summary> 売上金額(在庫) </summary>
		public const string ct_Col_StockSalesMoney = "StockSalesMoney";
		/// <summary> 売上金額(取寄) </summary>
		public const string ct_Col_OrderSalesMoney = "OrderSalesMoney";
		/// <summary> 売上金額(合計) </summary>
		public const string ct_Col_SalesMoney = "SalesMoney";
		/// <summary> 粗利金額 </summary>
		public const string ct_Col_GrossMoney = "GrossMoney";
		/// <summary> 粗利率 </summary>
		public const string ct_Col_GrossMarginRate = "GrossMarginRate";
        /// <summary> 移動出荷額 </summary>
        public const string ct_Col_MoveShipmentPrice = "MoveShipmentPrice"; // ADD 2008/12/09
        /// <summary> 原価金額 </summary>
		public const string ct_Col_CostMoney = "CostMoney";

		/// <summary> 仕入金額(在庫) </summary>
		public const string ct_Col_StockStockMoney = "StockStockMoney";
		/// <summary> 仕入金額(取寄) </summary>
		public const string ct_Col_OrderStockMoney = "OrderStockMoney";
		/// <summary> 仕入金額(合計) </summary>
		public const string ct_Col_StockMoney = "StockMoney";
        /// <summary> 移動入荷額 </summary>
        public const string ct_Col_MoveArrivalPrice = "MoveArrivalPric"; // ADD 2008/12/09

		/// <summary> 差額 </summary>
		public const string ct_Col_Difference = "Difference";

        /// <summary> 売上金額(合計) 金額適用無し</summary>
        public const string ct_Col_SalesMoneyOrg = "SalesMoneyOrg";
        /// <summary> 粗利金額 金額適用無し </summary>
        public const string ct_Col_GrossMoneyOrg = "GrossMoneyOrg";
		
        // 以下累計項目
        /// <summary> 累計売上金額(在庫) </summary>
		public const string ct_Col_TotalStockSalesMoney = "TotalStockSalesMoney";
		/// <summary> 累計売上金額(取寄) </summary>
		public const string ct_Col_TotalOrderSalesMoney = "TotalOrderSalesMoney";
		/// <summary> 累計売上金額(合計) </summary>
		public const string ct_Col_TotalSalesMoney = "TotalSalesMoney";
		/// <summary> 累計粗利金額 </summary>
		public const string ct_Col_TotalGrossMoney = "TotalGrossMoney";
		/// <summary> 累計粗利率 </summary>
		public const string ct_Col_TotalGrossMarginRate = "TotalGrossMarginRate";
        /// <summary> 累計移動出荷額 </summary>
        public const string ct_Col_TotalMoveShipmentPrice = "TotalMoveShipmentPrice"; // ADD 2008/12/09
		/// <summary> 累計原価金額 </summary>
		public const string ct_Col_TotalCostMoney = "TotalCostMoney";

		/// <summary> 累計仕入金額(在庫) </summary>
		public const string ct_Col_TotalStockStockMoney = "TotalStockStockMoney";
		/// <summary> 累計仕入金額(取寄) </summary>
		public const string ct_Col_TotalOrderStockMoney = "TotalOrderStockMoney";
		/// <summary> 累計仕入金額(合計) </summary>
		public const string ct_Col_TotalStockMoney = "TotalStockMoney";
        /// <summary> 累計移動入荷額 </summary>
        public const string ct_Col_TotalMoveArrivalPrice = "TotalMoveArrivalPric"; // ADD 2008/12/09

		/// <summary> 累計差額 </summary>
		public const string ct_Col_TotalDifference = "TotalDifference";

        /// <summary> 累計売上金額(合計) 金額適用無し</summary>
        public const string ct_Col_TotalSalesMoneyOrg = "TotalSalesMoneyOrg";
        /// <summary> 累計粗利金額 金額適用無し</summary>
        public const string ct_Col_TotalGrossMoneyOrg = "TotalGrossMoneyOrg";

		/// <summary> 月売上対比 </summary>
		public const string ct_Col_TermSalesComp = "TermSalesComp";
		/// <summary> 年売上対比 </summary>
        public const string ct_Col_YearSalesComp = "YearSalesComp";
		/// <summary> 月仕入対比 </summary>
		public const string ct_Col_TermStockComp = "TermStockComp";
		/// <summary> 年仕入対比 </summary>
        public const string ct_Col_YearStockComp = "YearStockComp";

		/// <summary> DailyHeaderField </summary>
		public const string ct_Col_DailyHeaderField = "DailyHeaderField";
		/// <summary> SectionHeaderField </summary>
		public const string ct_Col_SectionHeaderField = "SectionHeaderField";

		/// <summary> SectionHeaderLine </summary>
		public const string ct_Col_SectionHeaderLine = "SectionHeaderLine";
		/// <summary> SectionHeaderLineName </summary>
		public const string ct_Col_SectionHeaderLineName = "SectionHeaderLineName";

		/// <summary> DailyHeaderLine </summary>
		public const string ct_Col_DailyHeaderLine = "DailyHeaderLine";
		/// <summary> DetailLine </summary>
		public const string ct_Col_DetailLine = "DetailLine";
		/// <summary> DetailLineName </summary>
		public const string ct_Col_DetailLineName = "DetailLineName";

		#endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 売上仕入対比表テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上仕入対比表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 96186 立花 裕輔</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		public DCTOK02154EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ 在庫・倉庫移動DataSetテーブルスキーマ設定
		/// <summary>
		/// 在庫・倉庫移動DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="dt">設定対象データテーブル</param>
		/// <remarks>
		/// <br>Note       : 在庫・倉庫移動データセットのスキーマを設定する。</br>
		/// <br>Programmer : 96186 立花 裕輔</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		static public void CreateDataTable(ref DataTable dt)
		{
			// テーブルが存在するかどうかのチェック
			if ( dt != null )
			{
				// テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
				dt.Clear();
			}
			else
			{
				// スキーマ設定
				dt = new DataTable(ct_Tbl_SalStcCompMonthYearReportData);

				//拠点コード
                dt.Columns.Add(ct_Col_SectionCd, typeof(string));
                dt.Columns[ct_Col_SectionCd].DefaultValue = "";
				//自社名称1
				dt.Columns.Add(ct_Col_SectionGuideNm, typeof(string));
				dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";
                // --- DEL 2008/12/09 -------------------------------->>>>>
                ////仕入先コード
                //dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
                //dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;
                ////仕入先略称
                //dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                //dt.Columns[ct_Col_CustomerSnm].DefaultValue = "";
                // --- DEL 2008/12/09 --------------------------------<<<<<
                // --- ADD 2008/12/09 -------------------------------->>>>>
                //仕入先コード
                dt.Columns.Add(ct_Col_SupplierCode, typeof(Int32));
                dt.Columns[ct_Col_SupplierCode].DefaultValue = 0;
                //仕入先略称
                dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));
                dt.Columns[ct_Col_SupplierSnm].DefaultValue = "";
                // --- ADD 2008/12/09 --------------------------------<<<<<
				//売上金額(在庫)
				dt.Columns.Add(ct_Col_StockSalesMoney, typeof(Int64));
				dt.Columns[ct_Col_StockSalesMoney].DefaultValue = 0;
				//売上金額(取寄)
				dt.Columns.Add(ct_Col_OrderSalesMoney, typeof(Int64));
				dt.Columns[ct_Col_OrderSalesMoney].DefaultValue = 0;
				//売上金額(合計)
				dt.Columns.Add(ct_Col_SalesMoney, typeof(Int64));
				dt.Columns[ct_Col_SalesMoney].DefaultValue = 0;
				//粗利金額
				dt.Columns.Add(ct_Col_GrossMoney, typeof(Int64));
				dt.Columns[ct_Col_GrossMoney].DefaultValue = 0;
				//粗利率
				dt.Columns.Add(ct_Col_GrossMarginRate, typeof(double));
				dt.Columns[ct_Col_GrossMarginRate].DefaultValue = 0;
                //移動出荷額
                dt.Columns.Add(ct_Col_MoveShipmentPrice, typeof(Int64)); // ADD 2008/12/09
                dt.Columns[ct_Col_MoveShipmentPrice].DefaultValue = 0; // ADD 2008/12/09
				//原価金額
				dt.Columns.Add(ct_Col_CostMoney, typeof(Int64));
				dt.Columns[ct_Col_CostMoney].DefaultValue = 0;
				//仕入金額(在庫)
				dt.Columns.Add(ct_Col_StockStockMoney, typeof(Int64));
				dt.Columns[ct_Col_StockStockMoney].DefaultValue = 0;
				//仕入金額(取寄)
				dt.Columns.Add(ct_Col_OrderStockMoney, typeof(Int64));
				dt.Columns[ct_Col_OrderStockMoney].DefaultValue = 0;
				//仕入金額(合計)
				dt.Columns.Add(ct_Col_StockMoney, typeof(Int64));
				dt.Columns[ct_Col_StockMoney].DefaultValue = 0;
                //移動入荷額
                dt.Columns.Add(ct_Col_MoveArrivalPrice, typeof(Int64)); // ADD 2008/12/09
                dt.Columns[ct_Col_MoveArrivalPrice].DefaultValue = 0; // ADD 2008/12/09
				//差額
				dt.Columns.Add(ct_Col_Difference, typeof(Int64));
				dt.Columns[ct_Col_Difference].DefaultValue = 0;
                //売上金額(合計) 金額単位適用無し
                dt.Columns.Add(ct_Col_SalesMoneyOrg, typeof(Int64));
                dt.Columns[ct_Col_SalesMoneyOrg].DefaultValue = 0;
                //粗利金額金額単位適用無し
                dt.Columns.Add(ct_Col_GrossMoneyOrg, typeof(Int64));
                dt.Columns[ct_Col_GrossMoneyOrg].DefaultValue = 0;
				//累計売上金額(在庫)
				dt.Columns.Add(ct_Col_TotalStockSalesMoney, typeof(Int64));
				dt.Columns[ct_Col_TotalStockSalesMoney].DefaultValue = 0;
				//累計売上金額(取寄)
				dt.Columns.Add(ct_Col_TotalOrderSalesMoney, typeof(Int64));
				dt.Columns[ct_Col_TotalOrderSalesMoney].DefaultValue = 0;
				//累計売上金額(合計)
				dt.Columns.Add(ct_Col_TotalSalesMoney, typeof(Int64));
				dt.Columns[ct_Col_TotalSalesMoney].DefaultValue = 0;
				//累計粗利金額
				dt.Columns.Add(ct_Col_TotalGrossMoney, typeof(Int64));
				dt.Columns[ct_Col_TotalGrossMoney].DefaultValue = 0;
				//累計粗利率
				dt.Columns.Add(ct_Col_TotalGrossMarginRate, typeof(double));
				dt.Columns[ct_Col_TotalGrossMarginRate].DefaultValue = 0;
                //累計移動出荷額
                dt.Columns.Add(ct_Col_TotalMoveShipmentPrice, typeof(Int64)); // ADD 2008/12/09
                dt.Columns[ct_Col_TotalMoveShipmentPrice].DefaultValue = 0; // ADD 2008/12/09
				//累計原価金額
				dt.Columns.Add(ct_Col_TotalCostMoney, typeof(Int64));
				dt.Columns[ct_Col_TotalCostMoney].DefaultValue = 0;
				//累計仕入金額(在庫)
				dt.Columns.Add(ct_Col_TotalStockStockMoney, typeof(Int64));
				dt.Columns[ct_Col_TotalStockStockMoney].DefaultValue = 0;
				//累計仕入金額(取寄)
				dt.Columns.Add(ct_Col_TotalOrderStockMoney, typeof(Int64));
				dt.Columns[ct_Col_TotalOrderStockMoney].DefaultValue = 0;
				//累計仕入金額(合計)
				dt.Columns.Add(ct_Col_TotalStockMoney, typeof(Int64));
				dt.Columns[ct_Col_TotalStockMoney].DefaultValue = 0;
                //累計移動入荷額
                dt.Columns.Add(ct_Col_TotalMoveArrivalPrice, typeof(Int64)); // ADD 2008/12/09
                dt.Columns[ct_Col_TotalMoveArrivalPrice].DefaultValue = 0; // ADD 2008/12/09
				//累計差額
				dt.Columns.Add(ct_Col_TotalDifference, typeof(Int64));
				dt.Columns[ct_Col_TotalDifference].DefaultValue = 0;
                //累計売上金額(合計) 金額単位適用無し
                dt.Columns.Add(ct_Col_TotalSalesMoneyOrg, typeof(Int64));
                dt.Columns[ct_Col_TotalSalesMoneyOrg].DefaultValue = 0;
                //累計粗利金額 金額単位適用無し
                dt.Columns.Add(ct_Col_TotalGrossMoneyOrg, typeof(Int64));
                dt.Columns[ct_Col_TotalGrossMoneyOrg].DefaultValue = 0;

				//月売上対比
				dt.Columns.Add(ct_Col_TermSalesComp, typeof(Int64));
				dt.Columns[ct_Col_TermSalesComp].DefaultValue = 0;
				//年売上対比
				dt.Columns.Add(ct_Col_YearSalesComp, typeof(Int64));
				dt.Columns[ct_Col_YearSalesComp].DefaultValue = 0;
				//月仕入対比
				dt.Columns.Add(ct_Col_TermStockComp, typeof(Int64));
				dt.Columns[ct_Col_TermStockComp].DefaultValue = 0;
				//年仕入対比
				dt.Columns.Add(ct_Col_YearStockComp, typeof(Int64));
				dt.Columns[ct_Col_YearStockComp].DefaultValue = 0;

				//DailyHeaderField
				dt.Columns.Add(ct_Col_DailyHeaderField, typeof(string));
				dt.Columns[ct_Col_DailyHeaderField].DefaultValue = "";
				//SectionHeaderField
				dt.Columns.Add(ct_Col_SectionHeaderField, typeof(string));
				dt.Columns[ct_Col_SectionHeaderField].DefaultValue = "";

				//DailyHeaderLine
				dt.Columns.Add(ct_Col_DailyHeaderLine, typeof(string));
				dt.Columns[ct_Col_DailyHeaderLine].DefaultValue = "";
				//SectionHeaderLine
				dt.Columns.Add(ct_Col_SectionHeaderLine, typeof(string));
				dt.Columns[ct_Col_SectionHeaderLine].DefaultValue = "";
				//SectionHeaderLineName
				dt.Columns.Add(ct_Col_SectionHeaderLineName, typeof(string));
				dt.Columns[ct_Col_SectionHeaderLineName].DefaultValue = "";
				//DetailLine
				dt.Columns.Add(ct_Col_DetailLine, typeof(string));
				dt.Columns[ct_Col_DetailLine].DefaultValue = "";
				//DetailLineName
				dt.Columns.Add(ct_Col_DetailLineName, typeof(string));
				dt.Columns[ct_Col_DetailLineName].DefaultValue = "";
			}
		}
		#endregion
		#endregion
	}
}
