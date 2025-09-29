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
    public class DCTOK02034EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_SalStcCompReportData = "Tbl_SalStcCompReportData";

        /// <summary> 拠点コード </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> 拠点ガイド名称 </summary>
        public const string ct_Col_SectionGuideNm = "SectionGuideNm";
        // --- DEL 2008/12/09 -------------------------------->>>>>
        ///// <summary> 部門コード </summary>
        //public const string ct_Col_SubSectionCode = "SubSectionCode";
        ///// <summary> 部門名称 </summary>
        //public const string ct_Col_SubSectionName = "SubSectionName";
        ///// <summary> 課コード </summary>
        //public const string ct_Col_MinSectionCode = "MinSectionCode";
        ///// <summary> 課名称 </summary>
        //public const string ct_Col_MinSectionName = "MinSectionName";
        // --- DEL 2008/12/09 --------------------------------<<<<<
        /// <summary> 仕入先コード </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> 仕入先略称 </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        // --- DEL 2008/12/09 -------------------------------->>>>>
        ///// <summary> 期間売上合計取寄分（税抜き） </summary>
        //public const string ct_Col_TermSalesByOrderTotalTaxExc = "TermSalesByOrderTotalTaxExc";
        ///// <summary> 期間売上合計在庫分（税抜き） </summary>
        //public const string ct_Col_TermSalesByStockTotalTaxExc = "TermSalesByStockTotalTaxExc";
        ///// <summary> 期間原価合計 </summary>
        //public const string ct_Col_TermTotalCost = "TermTotalCost";
        ///// <summary> 期間仕入合計取寄分（税抜き） </summary>
        //public const string ct_Col_TermBuyForOrderTotalTaxExc = "TermBuyForOrderTotalTaxExc";
        ///// <summary> 期間仕入合計在庫分（税抜き） </summary>
        //public const string ct_Col_TermBuyForStockTotalTaxExc = "TermBuyForStockTotalTaxExc";
        ///// <summary> 月次期間売上合計取寄分（税抜き） </summary>
        //public const string ct_Col_MonthSalesByOrderTotalTaxExc = "MonthSalesByOrderTotalTaxExc";
        ///// <summary> 月次売上合計在庫分（税抜き） </summary>
        //public const string ct_Col_MonthSalesByStockTotalTaxExc = "MonthSalesByStockTotalTaxExc";
        ///// <summary> 月次原価合計 </summary>
        //public const string ct_Col_MonthTotalCost = "MonthTotalCost";
        ///// <summary> 月次仕入合計取寄分（税抜き） </summary>
        //public const string ct_Col_MonthBuyForOrderTotalTaxExc = "MonthBuyForOrderTotalTaxExc";
        ///// <summary> 月次仕入合計在庫分（税抜き） </summary>
        //public const string ct_Col_MonthBuyForStockTotalTaxExc = "MonthBuyForStockTotalTaxExc";
        ///// <summary> 在庫取寄せ区分 </summary>
        //public const string ct_Col_OrderDivCd = "OrderDivCd";
        // --- DEL 2008/12/09 --------------------------------<<<<<
        // --- ADD 2008/12/09 -------------------------------->>>>>
        /// <summary> 売上金額(日計合計)</summary>
        public const string ct_Col_SalesMoney = "SalesMoney";
        /// <summary> 売上金額(日計在庫)</summary>
        public const string ct_Col_SalesMoneyStock = "SalesMoneyStock";
        /// <summary> 原価金額計(日計)</summary>
        public const string ct_Col_TotalCost = "TotalCost";
        /// <summary> 移動数(日計売上)</summary>
        public const string ct_Col_MoveCountSales = "MoveCountSales";
        /// <summary> 仕入単価（日計売上）</summary>
        public const string ct_Col_StockUnitPriceFlSales = "StockUnitPriceFlSales";

        /// <summary> 仕入金額(日計合計)</summary>
        public const string ct_Col_StockPriceTaxExc = "StockPriceTaxExc";
        /// <summary> 仕入金額(日計在庫)</summary>
        public const string ct_Col_StockPriceTaxExcStock = "StockPriceTaxExcStock";
        /// <summary> 移動数(日計仕入)</summary>
        public const string ct_Col_MoveCountSalesSlip = "MoveCountSalesSlip";
        /// <summary> 仕入単価（日計仕入）</summary>
        public const string ct_Col_StockUnitPriceFlSalesSlip = "StockUnitPriceFlSalesSlip";
        
        /// <summary> 売上金額(累計合計)</summary>
        public const string ct_Col_MonthSalesMoney = "MonthSalesMoney";
        /// <summary> 売上金額(累計在庫)</summary>
        public const string ct_Col_MonthSalesMoneyStock = "MonthSalesMoneyStock";
        /// <summary> 原価金額計(累計)</summary>
        public const string ct_Col_MonthTotalCost = "MonthTotalCost";
        /// <summary> 移動数(累計売上)</summary>
        public const string ct_Col_MonthMoveCountSales = "MonthMoveCountSales";
        /// <summary> 仕入単価（累計売上）</summary>
        public const string ct_Col_MonthStockUnitPriceFlSales = "MonthStockUnitPriceFlSales";

        /// <summary> 仕入金額(累計合計)</summary>
        public const string ct_Col_MonthStockPriceTaxExc = "MonthStockPriceTaxExc";
        /// <summary> 仕入金額(累計在庫)</summary>
        public const string ct_Col_MonthStockPriceTaxExcStock = "MonthStockPriceTaxExcStock";
        /// <summary> 移動数(累計仕入)</summary>
        public const string ct_Col_MonthMoveCountSalesSlip = "MonthMoveCountSalesSlip";
        /// <summary> 仕入単価（累計仕入）</summary>
        public const string ct_Col_MonthStockUnitPriceFlSalesSlip = "MonthStockUnitPriceFlSalesSlip";

        // --- ADD 2008/12/09 --------------------------------<<<<<

        // --- DEL 2008/12/09 -------------------------------->>>>>
        ///// <summary> 期間売上合計（税抜き） </summary>
        //public const string ct_Col_TermSalesTotalTaxExc = "TermSalesTotalTaxExc";
        ///// <summary> 月次売上合計（税抜き） </summary>
        //public const string ct_Col_MonthSalesTotalTaxExc = "MonthSalesTotalTaxExc";
        ///// <summary> 期間粗利益 </summary>
        //public const string ct_Col_TermProfit = "TermProfit";
        ///// <summary> 月次粗利益 </summary>
        //public const string ct_Col_MonthProfit = "MonthProfit";
        ///// <summary> 期間粗利率 </summary>
        //public const string ct_Col_TermProfitRate = "TermProfitRate";
        ///// <summary> 月次粗利率 </summary>
        //public const string ct_Col_MonthProfitRate = "MonthProfitRate";
        ///// <summary> 期間仕入合計（税抜き） </summary>
        //public const string ct_Col_TermStockTotalTaxExc = "TermStockTotalTaxExc";
        ///// <summary> 月次仕入合計（税抜き） </summary>
        //public const string ct_Col_MonthStockTotalTaxExc = "MonthStockTotalTaxExc";
        ///// <summary> 期間売上対比 </summary>
        //public const string ct_Col_TermSalesComp = "TermSalesComp";
        ///// <summary> 月次売上対比 </summary>
        //public const string ct_Col_MonthSalesComp = "MonthSalesComp";
        ///// <summary> 期間仕入対比 </summary>
        //public const string ct_Col_TermStockComp = "TermStockComp";
        ///// <summary> 月次仕入対比 </summary>
        //public const string ct_Col_MonthStockComp = "MonthStockComp";
        ///// <summary> 期間差額 </summary>
        //public const string ct_Col_TermBalance = "TermBalance";
        ///// <summary> 月次差額 </summary>
        //public const string ct_Col_MonthBalance = "MonthBalance";
        // --- DEL 2008/12/09 --------------------------------<<<<<
        
        // --- ADD 2008/12/09 -------------------------------->>>>>
        // 以下帳票印字用項目
        /// <summary> 売上金額(日計取寄)</summary>
        public const string ct_Col_SalesMoneyOrder = "SalesMoneyOrder";
        /// <summary> 粗利金額(日計)</summary>
        public const string ct_Col_GrossProfit = "GrossProfit";
        /// <summary> 移動出庫(日計売上)</summary>
        public const string ct_Col_MoveMoney = "MoveMoney";

        /// <summary> 仕入金額(日計取寄)</summary>
        public const string ct_Col_StockPriceTaxExcOrder = "StockPriceTaxExcOrder";
        /// <summary> 移動入庫(日計仕入)</summary>
        public const string ct_Col_StockMoveMoney = "StockMoveMoney";

        /// <summary> 期間売上対比 </summary>
        public const string ct_Col_TermSalesComp = "TermSalesComp";
        /// <summary> 期間仕入対比 </summary>
        public const string ct_Col_TermStockComp = "TermStockComp";
        /// <summary> 期間差額 </summary>
        public const string ct_Col_TermBalance = "TermBalance";


        /// <summary> 売上金額(累計取寄)</summary>
        public const string ct_Col_MonthSalesMoneyOrder = "MonthSalesMoneyOrder";
        /// <summary> 粗利金額(累計)</summary>
        public const string ct_Col_MonthGrossProfit = "MonthGrossProfit";
        /// <summary> 移動出庫(累計売上)</summary>
        public const string ct_Col_MonthMoveMoney = "MonthMoveMoney";

        /// <summary> 仕入金額(累計取寄)</summary>
        public const string ct_Col_MonthStockPriceTaxExcOrder = "MonthStockPriceTaxExcOrder";
        /// <summary> 移動入庫(累計仕入)</summary>
        public const string ct_Col_MonthStockMoveMoney = "MonthStockMoveMoney";

        /// <summary> 累計売上対比 </summary>
        public const string ct_Col_MonthSalesComp = "MonthSalesComp";
        /// <summary> 累計仕入対比 </summary>
        public const string ct_Col_MonthStockComp = "MonthStockComp";
        /// <summary> 累計差額 </summary>
        public const string ct_Col_MonthBalance = "MonthBalance";
        // --- ADD 2008/12/09 --------------------------------<<<<<

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
        public DCTOK02034EA()
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
            if (dt != null)
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                dt.Clear();
            }
            else
            {
                // スキーマ設定
                dt = new DataTable(ct_Tbl_SalStcCompReportData);

                //拠点コード
                dt.Columns.Add(ct_Col_SectionCode, typeof(string));
                dt.Columns[ct_Col_SectionCode].DefaultValue = "";
                //拠点ガイド名称
                dt.Columns.Add(ct_Col_SectionGuideNm, typeof(string));
                dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";
                // --- DEL 2008/12/09 -------------------------------->>>>>
                ////部門コード
                //dt.Columns.Add(ct_Col_SubSectionCode, typeof(Int32));
                //dt.Columns[ct_Col_SubSectionCode].DefaultValue = 0;
                ////部門名称
                //dt.Columns.Add(ct_Col_SubSectionName, typeof(string));
                //dt.Columns[ct_Col_SubSectionName].DefaultValue = "";
                ////課コード
                //dt.Columns.Add(ct_Col_MinSectionCode, typeof(Int32));
                //dt.Columns[ct_Col_MinSectionCode].DefaultValue = 0;
                ////課名称
                //dt.Columns.Add(ct_Col_MinSectionName, typeof(string));
                //dt.Columns[ct_Col_MinSectionName].DefaultValue = "";
                // --- DEL 2008/12/09 --------------------------------<<<<<
                //仕入先コード
                dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));
                dt.Columns[ct_Col_SupplierCd].DefaultValue = 0;
                //仕入先略称
                dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));
                dt.Columns[ct_Col_SupplierSnm].DefaultValue = "";
                // --- DEL 2008/12/09 -------------------------------->>>>>
                ////期間売上合計取寄分（税抜き）
                //dt.Columns.Add(ct_Col_TermSalesByOrderTotalTaxExc, typeof(Int64));
                //dt.Columns[ct_Col_TermSalesByOrderTotalTaxExc].DefaultValue = 0;
                ////期間売上合計在庫分（税抜き）
                //dt.Columns.Add(ct_Col_TermSalesByStockTotalTaxExc, typeof(Int64));
                //dt.Columns[ct_Col_TermSalesByStockTotalTaxExc].DefaultValue = 0;
                ////期間原価合計
                //dt.Columns.Add(ct_Col_TermTotalCost, typeof(Int64));
                //dt.Columns[ct_Col_TermTotalCost].DefaultValue = 0;
                ////期間仕入合計取寄分（税抜き）
                //dt.Columns.Add(ct_Col_TermBuyForOrderTotalTaxExc, typeof(Int64));
                //dt.Columns[ct_Col_TermBuyForOrderTotalTaxExc].DefaultValue = 0;
                ////期間仕入合計在庫分（税抜き）
                //dt.Columns.Add(ct_Col_TermBuyForStockTotalTaxExc, typeof(Int64));
                //dt.Columns[ct_Col_TermBuyForStockTotalTaxExc].DefaultValue = 0;
                ////月次期間売上合計取寄分（税抜き）
                //dt.Columns.Add(ct_Col_MonthSalesByOrderTotalTaxExc, typeof(Int64));
                //dt.Columns[ct_Col_MonthSalesByOrderTotalTaxExc].DefaultValue = 0;
                ////月次売上合計在庫分（税抜き）
                //dt.Columns.Add(ct_Col_MonthSalesByStockTotalTaxExc, typeof(Int64));
                //dt.Columns[ct_Col_MonthSalesByStockTotalTaxExc].DefaultValue = 0;
                ////月次原価合計
                //dt.Columns.Add(ct_Col_MonthTotalCost, typeof(Int64));
                //dt.Columns[ct_Col_MonthTotalCost].DefaultValue = 0;
                ////月次仕入合計取寄分（税抜き）
                //dt.Columns.Add(ct_Col_MonthBuyForOrderTotalTaxExc, typeof(Int64));
                //dt.Columns[ct_Col_MonthBuyForOrderTotalTaxExc].DefaultValue = 0;
                ////月次仕入合計在庫分（税抜き）
                //dt.Columns.Add(ct_Col_MonthBuyForStockTotalTaxExc, typeof(Int64));
                //dt.Columns[ct_Col_MonthBuyForStockTotalTaxExc].DefaultValue = 0;
                ////在庫取寄せ区分
                //dt.Columns.Add(ct_Col_OrderDivCd, typeof(Int32));
                //dt.Columns[ct_Col_OrderDivCd].DefaultValue = 0;


                ////期間売上合計（税抜き）
                //dt.Columns.Add(ct_Col_TermSalesTotalTaxExc, typeof(Int64));
                //dt.Columns[ct_Col_TermSalesTotalTaxExc].DefaultValue = 0;
                ////月次売上合計（税抜き）
                //dt.Columns.Add(ct_Col_MonthSalesTotalTaxExc, typeof(Int64));
                //dt.Columns[ct_Col_MonthSalesTotalTaxExc].DefaultValue = 0;
                ////期間粗利率
                //dt.Columns.Add(ct_Col_TermProfit, typeof(double));
                //dt.Columns[ct_Col_TermProfit].DefaultValue = 0;
                ////月次粗利益
                //dt.Columns.Add(ct_Col_MonthProfit, typeof(double));
                //dt.Columns[ct_Col_MonthProfit].DefaultValue = 0;
                ////期間粗利率
                //dt.Columns.Add(ct_Col_TermProfitRate, typeof(double));
                //dt.Columns[ct_Col_TermProfitRate].DefaultValue = 0;
                ////月次粗利率
                //dt.Columns.Add(ct_Col_MonthProfitRate, typeof(double));
                //dt.Columns[ct_Col_MonthProfitRate].DefaultValue = 0;
                ////期間仕入合計（税抜き）
                //dt.Columns.Add(ct_Col_TermStockTotalTaxExc, typeof(Int64));
                //dt.Columns[ct_Col_TermStockTotalTaxExc].DefaultValue = 0;
                ////月次仕入合計（税抜き）
                //dt.Columns.Add(ct_Col_MonthStockTotalTaxExc, typeof(Int64));
                //dt.Columns[ct_Col_MonthStockTotalTaxExc].DefaultValue = 0;
                // --- DEL 2008/12/09 --------------------------------<<<<<

                // --- ADD 2008/12/09 -------------------------------->>>>>
                // 売上金額(日計合計)
                dt.Columns.Add(ct_Col_SalesMoney, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney].DefaultValue = 0;
                // 売上金額(日計在庫)
                dt.Columns.Add(ct_Col_SalesMoneyStock, typeof(Int64));
                dt.Columns[ct_Col_SalesMoneyStock].DefaultValue = 0;
                // 原価金額計(日計)
                dt.Columns.Add(ct_Col_TotalCost, typeof(Int64));
                dt.Columns[ct_Col_TotalCost].DefaultValue = 0;
                // 移動数(日計売上)
                dt.Columns.Add(ct_Col_MoveCountSales, typeof(double));
                dt.Columns[ct_Col_MoveCountSales].DefaultValue = 0;
                // 仕入単価（日計売上）
                dt.Columns.Add(ct_Col_StockUnitPriceFlSales, typeof(double));
                dt.Columns[ct_Col_StockUnitPriceFlSales].DefaultValue = 0;
                // 仕入金額(日計合計)
                dt.Columns.Add(ct_Col_StockPriceTaxExc, typeof(Int64));
                dt.Columns[ct_Col_StockPriceTaxExc].DefaultValue = 0;
                // 仕入金額(日計在庫)
                dt.Columns.Add(ct_Col_StockPriceTaxExcStock, typeof(Int64));
                dt.Columns[ct_Col_StockPriceTaxExcStock].DefaultValue = 0;
                // 移動数(日計仕入)
                dt.Columns.Add(ct_Col_MoveCountSalesSlip, typeof(double));
                dt.Columns[ct_Col_MoveCountSalesSlip].DefaultValue = 0;
                // 仕入単価（日計仕入）
                dt.Columns.Add(ct_Col_StockUnitPriceFlSalesSlip, typeof(double));
                dt.Columns[ct_Col_StockUnitPriceFlSalesSlip].DefaultValue = 0;

                // 売上金額(累計合計)
                dt.Columns.Add(ct_Col_MonthSalesMoney, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesMoney].DefaultValue = 0;
                // 売上金額(累計在庫)
                dt.Columns.Add(ct_Col_MonthSalesMoneyStock, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesMoneyStock].DefaultValue = 0;
                // 原価金額計(累計)
                dt.Columns.Add(ct_Col_MonthTotalCost, typeof(Int64));
                dt.Columns[ct_Col_MonthTotalCost].DefaultValue = 0;
                // 移動数(累計売上)
                dt.Columns.Add(ct_Col_MonthMoveCountSales, typeof(double));
                dt.Columns[ct_Col_MonthMoveCountSales].DefaultValue = 0;
                // 仕入単価（累計売上）
                dt.Columns.Add(ct_Col_MonthStockUnitPriceFlSales, typeof(double));
                dt.Columns[ct_Col_MonthStockUnitPriceFlSales].DefaultValue = 0;
                // 仕入金額(累計合計)
                dt.Columns.Add(ct_Col_MonthStockPriceTaxExc, typeof(Int64));
                dt.Columns[ct_Col_MonthStockPriceTaxExc].DefaultValue = 0;
                // 仕入金額(累計在庫)
                dt.Columns.Add(ct_Col_MonthStockPriceTaxExcStock, typeof(Int64));
                dt.Columns[ct_Col_MonthStockPriceTaxExcStock].DefaultValue = 0;
                // 移動数(累計仕入)
                dt.Columns.Add(ct_Col_MonthMoveCountSalesSlip, typeof(double));
                dt.Columns[ct_Col_MonthMoveCountSalesSlip].DefaultValue = 0;
                // 仕入単価（累計仕入）
                dt.Columns.Add(ct_Col_MonthStockUnitPriceFlSalesSlip, typeof(double));
                dt.Columns[ct_Col_MonthStockUnitPriceFlSalesSlip].DefaultValue = 0;
                // --- ADD 2008/12/09 --------------------------------<<<<<

                // --- ADD 2008/12/09 -------------------------------->>>>>
                // 以下帳票印字用項目
                // 売上金額(日計取寄)
                dt.Columns.Add(ct_Col_SalesMoneyOrder, typeof(Int64));
                dt.Columns[ct_Col_SalesMoneyOrder].DefaultValue = 0;
                // 粗利金額(日計)
                dt.Columns.Add(ct_Col_GrossProfit, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit].DefaultValue = 0;
                // 移動出庫(日計売上)
                dt.Columns.Add(ct_Col_MoveMoney, typeof(double));
                dt.Columns[ct_Col_MoveMoney].DefaultValue = 0;

                // 仕入金額(日計取寄)
                dt.Columns.Add(ct_Col_StockPriceTaxExcOrder, typeof(Int64));
                dt.Columns[ct_Col_StockPriceTaxExcOrder].DefaultValue = 0;
                // 移動入庫(日計仕入)
                dt.Columns.Add(ct_Col_StockMoveMoney, typeof(double));
                dt.Columns[ct_Col_StockMoveMoney].DefaultValue = 0;

                // 売上金額(累計取寄)
                dt.Columns.Add(ct_Col_MonthSalesMoneyOrder, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesMoneyOrder].DefaultValue = 0;
                // 粗利金額(累計)
                dt.Columns.Add(ct_Col_MonthGrossProfit, typeof(Int64));
                dt.Columns[ct_Col_MonthGrossProfit].DefaultValue = 0;
                // 移動出庫(累計売上)
                dt.Columns.Add(ct_Col_MonthMoveMoney, typeof(double));
                dt.Columns[ct_Col_MonthMoveMoney].DefaultValue = 0;

                // 仕入金額(累計取寄)
                dt.Columns.Add(ct_Col_MonthStockPriceTaxExcOrder, typeof(Int64));
                dt.Columns[ct_Col_MonthStockPriceTaxExcOrder].DefaultValue = 0;
                // 移動入庫(累計仕入)
                dt.Columns.Add(ct_Col_MonthStockMoveMoney, typeof(double));
                dt.Columns[ct_Col_MonthStockMoveMoney].DefaultValue = 0;
                // --- ADD 2008/12/09 --------------------------------<<<<<

                // 期間売上対比
                dt.Columns.Add(ct_Col_TermSalesComp, typeof(Int64));
                dt.Columns[ct_Col_TermSalesComp].DefaultValue = 0;
                // 期間仕入対比
                dt.Columns.Add(ct_Col_TermStockComp, typeof(Int64));
                dt.Columns[ct_Col_TermStockComp].DefaultValue = 0;
                // 期間差額
                dt.Columns.Add(ct_Col_TermBalance, typeof(Int64));
                dt.Columns[ct_Col_TermBalance].DefaultValue = 0;
                // 累計売上対比
                dt.Columns.Add(ct_Col_MonthSalesComp, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesComp].DefaultValue = 0;
                // 累計仕入対比
                dt.Columns.Add(ct_Col_MonthStockComp, typeof(Int64));
                dt.Columns[ct_Col_MonthStockComp].DefaultValue = 0;
                // 累計差額
                dt.Columns.Add(ct_Col_MonthBalance, typeof(Int64));
                dt.Columns[ct_Col_MonthBalance].DefaultValue = 0;

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
                //DetailLine
                dt.Columns.Add(ct_Col_DetailLine, typeof(string));
                dt.Columns[ct_Col_DetailLine].DefaultValue = "";

                //SectionHeaderLineName
                dt.Columns.Add(ct_Col_SectionHeaderLineName, typeof(string));
                dt.Columns[ct_Col_SectionHeaderLineName].DefaultValue = "";
                //DetailLineName
                dt.Columns.Add(ct_Col_DetailLineName, typeof(string));
                dt.Columns[ct_Col_DetailLineName].DefaultValue = "";
            }
        }
        #endregion
        #endregion
    }
}
