using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 仕入分析表 リモート抽出結果クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入分析表のリモート抽出結果を保持する。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.11.10</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMKOU02025EA
    {
        #region ■ Public定数
        // テーブル名称
        public const string ct_Tbl_SlipHistAnalyzeResult = "SlipHistAnalyzeResult";

        // 計上拠点コード
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        // 拠点ガイド略称
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";
        // 仕入先コード
        public const string ct_Col_SupplierCd = "SupplierCd";
        // 仕入先略称
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        // 仕入金額合計(当月)
        public const string ct_Col_TotalPrice = "TotalPrice";
        // 仕入返品額(当月)
        public const string ct_Col_RetGoodsPrice = "RetGoodsPrice";
        // 仕入値引計(当月)
        public const string ct_Col_TotalDiscount = "TotalDiscount";
        // 仕入金額合計(当月在庫)
        public const string ct_Col_TotalPriceStock = "TotalPriceStock";
        // 仕入金額合計(当月合計)
        public const string ct_Col_TotalPriceTotal = "TotalPriceTotal";

        // 仕入金額合計(当期)
        public const string ct_Col_AnnualTotalPrice = "AnnualTotalPrice";
        // 仕入返品額(当期)
        public const string ct_Col_AnnualRetGoodsPrice = "AnnualRetGoodsPrice";
        // 仕入値引計(当期)
        public const string ct_Col_AnnualTotalDiscount = "AnnualTotalDiscount";
        // 仕入金額合計(当期在庫)
        public const string ct_Col_AnnualTotalPriceStock = "AnnualTotalPriceStock";
        // 仕入金額合計(当期合計)
        public const string ct_Col_AnnualTotalPriceTotal = "AnnualTotalPriceTotal";

        // --帳票印字項目--
        // 純仕入（当月）
        public const string ct_Col_PureTotalPrice = "PureTotalPrice";
        // 純仕入合計（当月） (構成比用)
        public const string ct_Col_PureTotalPriceSum = "PureTotalPriceSum";
        // 在庫額（当月）
        public const string ct_Col_StockPrice = "StockPrice";
        // 取寄額（当月）
        public const string ct_Col_OrderPrice = "OrderPrice";
        
        // 純仕入（当期）
        public const string ct_Col_AnnualPureTotalPrice = "AnnualPureTotalPrice";
        // 純仕入合計（当期） (構成比用)
        public const string ct_Col_AnnualPureTotalPriceSum = "AnnualPureTotalPriceSum";
        // 在庫額（当期）
        public const string ct_Col_AnnualStockPrice = "AnnualStockPrice";
        // 取寄額（当期）
        public const string ct_Col_AnnualOrderPrice = "AnnualOrderPrice";

        // --率計算用項目(金額単位を考慮しない値)--
        // 仕入金額合計(当月)
        public const string ct_Col_TotalPriceOrg = "TotalPriceOrg";
        // 仕入返品額(当月)
        public const string ct_Col_RetGoodsPriceOrg = "RetGoodsPriceOrg";
        // 仕入値引計(当月)
        public const string ct_Col_TotalDiscountOrg = "TotalDiscountOrg";
        // 純仕入（当月）
        public const string ct_Col_PureTotalPriceOrg = "PureTotalPriceOrg";
        // 在庫額（当月）
        public const string ct_Col_StockPriceOrg = "StockPriceOrg";
        // 取寄額（当月）
        public const string ct_Col_OrderPriceOrg = "OrderPriceOrg";

        // 仕入金額合計(当期)
        public const string ct_Col_AnnualTotalPriceOrg = "AnnualTotalPriceOrg";
        // 仕入返品額(当期)
        public const string ct_Col_AnnualRetGoodsPriceOrg = "AnnualRetGoodsPriceOrg";
        // 仕入値引計(当期)
        public const string ct_Col_AnnualTotalDiscountOrg = "AnnualTotalDiscountOrg";
        // 純仕入（当期）
        public const string ct_Col_AnnualPureTotalPriceOrg = "AnnualPureTotalPriceOrg";
        // 在庫額（当期）
        public const string ct_Col_AnnualStockPriceOrg = "AnnualStockPriceOrg";
        // 取寄額（当期）
        public const string ct_Col_AnnualOrderPriceOrg = "AnnualOrderPriceOrg";
        #endregion

        #region ■ コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public PMKOU02025EA()
        {
        }
        
        #endregion

        #region ■ publicメソッド
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
                dt = new DataTable(ct_Tbl_SlipHistAnalyzeResult);

                // 計上拠点コード
                dt.Columns.Add(ct_Col_AddUpSecCode, typeof(string));
                dt.Columns[ct_Col_AddUpSecCode].DefaultValue = string.Empty;

                // 拠点ガイド略称
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = string.Empty;

                // 仕入先コード
                dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));
                dt.Columns[ct_Col_SupplierCd].DefaultValue = 0;

                // 仕入先略称
                dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));
                dt.Columns[ct_Col_SupplierSnm].DefaultValue = string.Empty;

                // 仕入金額合計(当月)
                dt.Columns.Add(ct_Col_TotalPrice, typeof(Int64));
                dt.Columns[ct_Col_TotalPrice].DefaultValue = 0;

                // 仕入返品額(当月)
                dt.Columns.Add(ct_Col_RetGoodsPrice, typeof(Int64));
                dt.Columns[ct_Col_RetGoodsPrice].DefaultValue = 0;

                // 仕入値引計(当月)
                dt.Columns.Add(ct_Col_TotalDiscount, typeof(Int64));
                dt.Columns[ct_Col_TotalDiscount].DefaultValue = 0;

                // 仕入金額合計(当月在庫)
                dt.Columns.Add(ct_Col_TotalPriceStock, typeof(Int64));
                dt.Columns[ct_Col_TotalPriceStock].DefaultValue = 0;

                // 仕入金額合計(当月合計)
                dt.Columns.Add(ct_Col_TotalPriceTotal, typeof(Int64));
                dt.Columns[ct_Col_TotalPriceTotal].DefaultValue = 0;

                // 仕入金額合計(当期)
                dt.Columns.Add(ct_Col_AnnualTotalPrice, typeof(Int64));
                dt.Columns[ct_Col_AnnualTotalPrice].DefaultValue = 0;

                // 仕入返品額(当期)
                dt.Columns.Add(ct_Col_AnnualRetGoodsPrice, typeof(Int64));
                dt.Columns[ct_Col_AnnualRetGoodsPrice].DefaultValue = 0;

                // 仕入値引計(当期)
                dt.Columns.Add(ct_Col_AnnualTotalDiscount, typeof(Int64));
                dt.Columns[ct_Col_AnnualTotalDiscount].DefaultValue = 0;

                // 仕入金額合計(当期在庫)
                dt.Columns.Add(ct_Col_AnnualTotalPriceStock, typeof(Int64));
                dt.Columns[ct_Col_AnnualTotalPriceStock].DefaultValue = 0;

                // 仕入金額合計(当期合計)
                dt.Columns.Add(ct_Col_AnnualTotalPriceTotal, typeof(Int64));
                dt.Columns[ct_Col_AnnualTotalPriceTotal].DefaultValue = 0;

                // 純仕入（当月）
                dt.Columns.Add(ct_Col_PureTotalPrice, typeof(Int64));
                dt.Columns[ct_Col_PureTotalPrice].DefaultValue = 0;

                // 純仕入合計（当月） (構成比用)
                dt.Columns.Add(ct_Col_PureTotalPriceSum, typeof(Int64));
                dt.Columns[ct_Col_PureTotalPriceSum].DefaultValue = 0;

                // 在庫額（当月）
                dt.Columns.Add(ct_Col_StockPrice, typeof(Int64));
                dt.Columns[ct_Col_StockPrice].DefaultValue = 0;

                // 取寄額（当月）
                dt.Columns.Add(ct_Col_OrderPrice, typeof(Int64));
                dt.Columns[ct_Col_OrderPrice].DefaultValue = 0;

                // 純仕入（当期）
                dt.Columns.Add(ct_Col_AnnualPureTotalPrice, typeof(Int64));
                dt.Columns[ct_Col_AnnualPureTotalPrice].DefaultValue = 0;

                // 純仕入合計（当期） (構成比用)
                dt.Columns.Add(ct_Col_AnnualPureTotalPriceSum, typeof(Int64));
                dt.Columns[ct_Col_AnnualPureTotalPriceSum].DefaultValue = 0;

                // 在庫額（当期）
                dt.Columns.Add(ct_Col_AnnualStockPrice, typeof(Int64));
                dt.Columns[ct_Col_AnnualStockPrice].DefaultValue = 0;

                // 取寄額（当期）
                dt.Columns.Add(ct_Col_AnnualOrderPrice, typeof(Int64));
                dt.Columns[ct_Col_AnnualOrderPrice].DefaultValue = 0;

                // --率計算用項目--
                // 仕入金額合計(当月)
                dt.Columns.Add(ct_Col_TotalPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_TotalPriceOrg].DefaultValue = 0;

                // 仕入返品額(当月)
                dt.Columns.Add(ct_Col_RetGoodsPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_RetGoodsPriceOrg].DefaultValue = 0;

                // 仕入値引計(当月)
                dt.Columns.Add(ct_Col_TotalDiscountOrg, typeof(Int64));
                dt.Columns[ct_Col_TotalDiscountOrg].DefaultValue = 0;

                // 純仕入（当月）
                dt.Columns.Add(ct_Col_PureTotalPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_PureTotalPriceOrg].DefaultValue = 0;

                // 在庫額（当月）
                dt.Columns.Add(ct_Col_StockPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_StockPriceOrg].DefaultValue = 0;

                // 取寄額（当月）
                dt.Columns.Add(ct_Col_OrderPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_OrderPriceOrg].DefaultValue = 0;

                // 仕入金額合計(当期)
                dt.Columns.Add(ct_Col_AnnualTotalPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_AnnualTotalPriceOrg].DefaultValue = 0;

                // 仕入返品額(当期)
                dt.Columns.Add(ct_Col_AnnualRetGoodsPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_AnnualRetGoodsPriceOrg].DefaultValue = 0;

                // 仕入値引計(当期)
                dt.Columns.Add(ct_Col_AnnualTotalDiscountOrg, typeof(Int64));
                dt.Columns[ct_Col_AnnualTotalDiscountOrg].DefaultValue = 0;

                // 純仕入（当期）
                dt.Columns.Add(ct_Col_AnnualPureTotalPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_AnnualPureTotalPriceOrg].DefaultValue = 0;

                // 在庫額（当期）
                dt.Columns.Add(ct_Col_AnnualStockPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_AnnualStockPriceOrg].DefaultValue = 0;

                // 取寄額（当期）
                dt.Columns.Add(ct_Col_AnnualOrderPriceOrg, typeof(Int64));
                dt.Columns[ct_Col_AnnualOrderPriceOrg].DefaultValue = 0;
            }
        }

        #endregion
    }
}
