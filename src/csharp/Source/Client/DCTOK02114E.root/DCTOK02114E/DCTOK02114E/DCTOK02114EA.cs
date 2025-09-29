using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 売上実績表テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上実績表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.09.19</br>
    /// <br>Update Note: 2008.10.08 30452 上野 俊治</br>
    /// <br>            ・PM.NS対応</br>
    /// <br>Update Note: 2009.04.11 張莉莉</br>
    /// <br>            ・売上実績表（仕入先別）の追加</br>
    /// </remarks>
    public class DCTOK02114EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_SalesRsltList = "Tbl_SalesRsltList";

        /// <summary> 計上拠点コード </summary>
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        /// <summary> 自社名称1 </summary>
        public const string ct_Col_CompanyName1 = "CompanyName1";
        ///// <summary> 自社名称2 </summary>
        //public const string ct_Col_CompanyName2 = "CompanyName2"; // DEL 2008/10/08
        ///// <summary> 拠点ガイド名称 </summary>
        //public const string ct_Col_SectionGuideNm = "SectionGuideNm"; // DEL 2008/10/08
        /// <summary> 倉庫コード </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode"; // ADD 2008/10/08
        /// <summary> 倉庫名称 </summary>
        public const string ct_Col_WarehouseName = "WarehouseName"; // ADD 2008/10/08
        /// <summary> 従業員コード </summary>
        public const string ct_Col_EmployeeCode = "EmployeeCode";
        /// <summary> 従業員名称 </summary>
        //public const string ct_Col_EmployeeName = "EmployeeName"; // DEL 2008/10/08
        public const string ct_Col_EmployeeName = "Name"; // ADD 2008/10/08
        /// <summary> 得意先コード </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 得意先略称 </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> 仕入先コード </summary>
        public const string ct_Col_SupplierCode = "SupplierCode";　// ADD 2009/04/11
        /// <summary> 仕入先略称 </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm"; // ADD 2009/04/11
        /// <summary> 商品メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー略称 </summary>
        public const string ct_Col_MakerShortName = "MakerShortName"; // ADD 2008/10/08
        ///// <summary> メーカー名称 </summary>
        //public const string ct_Col_MakerName = "MakerName"; // DEL 2008/10/08
        /// <summary> 商品大分類コード </summary>
        //public const string ct_Col_LargeGoodsGanreCode = "LargeGoodsGanreCode"; // DEL 2008/10/08
        public const string ct_Col_GoodsLGroup = "GoodsLGroup"; // ADD 2008/10/08
        /// <summary> 商品大分類名称 </summary>
        //public const string ct_Col_LargeGoodsGanreName = "LargeGoodsGanreName"; // DEL 2008/10/08
        public const string ct_Col_GoodsLGroupName = "GoodsLGroupName"; // ADD 2008/10/08
        /// <summary> 商品中分類コード </summary>
        //public const string ct_Col_MediumGoodsGanreCode = "MediumGoodsGanreCode"; // DEL 2008/10/08
        public const string ct_Col_GoodsMGroup = "GoodsMGroup"; // ADD 2008/10/08
        /// <summary> 商品中分類名称 </summary>
        //public const string ct_Col_MediumGoodsGanreName = "MediumGoodsGanreName"; // DEL 2008/10/08
        public const string ct_Col_GoodsMGroupName = "GoodsMGroupName"; // ADD 2008/10/08
        /// <summary> グループコード </summary>
        //public const string ct_Col_DetailGoodsGanreCode = "DetailGoodsGanreCode"; // DEL 2008/10/08
        public const string ct_Col_BLGroupCode = "BLGroupCode"; // ADD 2008/10/08
        /// <summary> グループコード名称 </summary>
        //public const string ct_Col_DetailGoodsGanreName = "DetailGoodsGanreName"; // DEL 2008/10/08
        public const string ct_Col_BLGroupKanaName = "BLGroupKanaName"; // ADD 2008/10/08
        /// <summary> BLコード </summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary> BLコード名称（半角） </summary>
        public const string ct_Col_BLGoodsHalfName = "BLGoodsHalfName";
        /// <summary> 商品番号 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 商品名称 </summary>
        public const string ct_Col_GoodsNameKana = "GoodsNameKana"; // ADD 2008/10/08
        ///// <summary> 商品名略称 </summary>
        //public const string ct_Col_GoodsShortName = "GoodsShortName"; // DEL 2008/10/08

        // --- ADD 2008/10/08 -------------------------------->>>>>
        /// <summary>当月出荷数</summary>
        public const string ct_Col_MonthTotalSalesCount = "MonthTotalSalesCount";
        /// <summary>当月売上額</summary>
        public const string ct_Col_MonthSalesMoney = "MonthSalesMoney";
        /// <summary>当月返品額</summary>
        public const string ct_Col_MonthSalesRetGoodsPrice = "MonthSalesRetGoodsPrice";
        /// <summary>当月値引額</summary>
        public const string ct_Col_MonthDiscountPrice = "MonthDiscountPrice";
        /// <summary>当月粗利額</summary>
        public const string ct_Col_MonthGrossProfit = "MonthGrossProfit";
        /// <summary>当月純売上額 </summary>
        public const string ct_Col_MonthPureSalesMoney = "MonthPureSalesMoney";

        /// <summary>当期出荷数</summary>
        public const string ct_Col_AnnualTotalSalesCount = "AnnualTotalSalesCount";
        /// <summary>当期売上額</summary>
        public const string ct_Col_AnnualSalesMoney = "AnnualSalesMoney";
        /// <summary>当期返品額</summary>
        public const string ct_Col_AnnualSalesRetGoodsPrice = "AnnualSalesRetGoodsPrice";
        /// <summary>当期値引額</summary>
        public const string ct_Col_AnnualDiscountPrice = "AnnualDiscountPrice";
        /// <summary>当期粗利額</summary>
        public const string ct_Col_AnnualGrossProfit = "AnnualGrossProfit";
        /// <summary>当期純売上額</summary>
        public const string ct_Col_AnnualPureSalesMoney = "AnnualPureSalesMoney";

        /// <summary> 当月粗利率 </summary>
        public const string ct_Col_MonthGrossProfitRate = "MonthGrossProfitRate";
        /// <summary> 当期粗利率 </summary>
        public const string ct_Col_AnnualGrossProfitRate = "AnnualGrossProfitRate";

        /// <summary> 当月純売上額(粗利率計算用) </summary>
        public const string ct_Col_MonthPureSalesMoneyOrg = "MonthPureSalesMoneyOrg";
        /// <summary> 当期純売上額(粗利率計算用) </summary>
        public const string ct_Col_AnnualPureSalesMoneyOrg = "AnnualPureSalesMoneyOrg";
        /// <summary> 当月粗利額(粗利率計算用、金額単位変換しない) </summary>
        public const string ct_Col_MonthGrossProfitOrg = "MonthGrossProfitOrg";
        /// <summary> 当期粗利額(粗利率計算用、金額単位変換しない) </summary>
        public const string ct_Col_AnnualGrossProfitOrg = "AnnualGrossProfitOrg";
        // --- ADD 2008/10/08 --------------------------------<<<<<

        // --- DEL 2008/10/08 -------------------------------->>>>>
        ///// <summary> 当月売上回数 </summary>
        //public const string ct_Col_SalesTimes = "SalesTimes";
        ///// <summary> 当月売上数計 </summary>
        //public const string ct_Col_TotalSalesCount = "TotalSalesCount";
        ///// <summary> 当月売上伝票合計（税抜き） </summary>
        //public const string ct_Col_SalesTotalTaxExc = "SalesTotalTaxExc";
        ///// <summary> 当月返品額 </summary>
        //public const string ct_Col_SalesRetGoodsPrice = "SalesRetGoodsPrice";
        ///// <summary> 当月値引金額 </summary>
        //public const string ct_Col_DiscountPrice = "DiscountPrice";
        ///// <summary> 当月粗利金額 </summary>
        //public const string ct_Col_GrossProfit = "GrossProfit";
        ///// <summary> 当期売上回数 </summary>
        //public const string ct_Col_TtlSalesTimes = "TtlSalesTimes";
        ///// <summary> 当期売上数計 </summary>
        //public const string ct_Col_TtlTotalSalesCount = "TtlTotalSalesCount";
        ///// <summary> 当期売上伝票合計（税抜き） </summary>
        //public const string ct_Col_TtlSalesTotalTaxExc = "TtlSalesTotalTaxExc";
        ///// <summary> 当期返品額 </summary>
        //public const string ct_Col_TtlSalesRetGoodsPrice = "TtlSalesRetGoodsPrice";
        ///// <summary> 当期値引金額 </summary>
        //public const string ct_Col_TtlDiscountPrice = "TtlDiscountPrice";
        ///// <summary> 当期粗利金額 </summary>
        //public const string ct_Col_TtlGrossProfit = "TtlGrossProfit";
        ///// <summary> 当月純売上金額 </summary>
        //public const string ct_Col_SalesPrice = "SalesPrice";
        ///// <summary> 当月粗利率 </summary>
        //public const string ct_Col_GrossProfitRate = "GrossProfitRate";
        ///// <summary> 当期純売上金額 </summary>
        //public const string ct_Col_TtlSalesPrice = "TtlSalesPrice";
        ///// <summary> 当期粗利率 </summary>
        //public const string ct_Col_TtlGrossProfitRate = "TtlGrossProfitRate";
        ///// <summary> 当月売上伝票合計（計算用） </summary>
        //public const string ct_Col_SalesTotalTaxExcOrg = "SalesTotalTaxExcOrg";
        ///// <summary> 当月返品額（計算用） </summary>
        //public const string ct_Col_SalesRetGoodsPriceOrg = "SalesRetGoodsPriceOrg";
        ///// <summary> 当月値引金額（計算用） </summary>
        //public const string ct_Col_DiscountPriceOrg = "DiscountPriceOrg";
        ///// <summary> 当月粗利金額（計算用） </summary>
        //public const string ct_Col_GrossProfitOrg = "GrossProfitOrg";
        ///// <summary> 当月純売上金額（計算用） </summary>
        //public const string ct_Col_SalesPriceOrg = "SalesPriceOrg";
        ///// <summary> 当期売上伝票合計（計算用） </summary>
        //public const string ct_Col_TtlSalesTotalTaxExcOrg = "TtlSalesTotalTaxExcOrg";
        ///// <summary> 当期返品額（計算用） </summary>
        //public const string ct_Col_TtlSalesRetGoodsPriceOrg = "TtlSalesRetGoodsPriceOrg";
        ///// <summary> 当期値引金額（計算用） </summary>
        //public const string ct_Col_TtlDiscountPriceOrg = "TtlDiscountPriceOrg";
        ///// <summary> 当期粗利金額（計算用） </summary>
        //public const string ct_Col_TtlGrossProfitOrg = "TtlGrossProfitOrg";
        ///// <summary> 当期純売上金額（計算用） </summary>
        //public const string ct_Col_TtlSalesPriceOrg = "TtlSalesPriceOrg";
        // --- DEL 2008/10/08 --------------------------------<<<<<
        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
        /// 売上実績表テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上実績表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public DCTOK02114EA()
        {
        }
        #endregion

        #region ■ Static Public Method
        #region ◆ テーブルスキーマ設定
        /// <summary>
        /// 在庫・倉庫移動DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="dt">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 在庫・倉庫移動データセットのスキーマを設定する。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
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
                dt = new DataTable(ct_Tbl_SalesRsltList);

                // デフォルト値
                string defaultValueOfstring = string.Empty;
                Int32 defaultValueOfInt32 = 0;
                Int64 defaultValueOfInt64 = 0;
                double defaultValueOfDouble = 0;
                DateTime defaultValueOfDateTime = DateTime.MinValue;

                # region <Column追加>

                // 計上拠点コード
                dt.Columns.Add(ct_Col_AddUpSecCode, typeof(string));
                dt.Columns[ct_Col_AddUpSecCode].DefaultValue = defaultValueOfstring;

                // 自社名称1
                dt.Columns.Add(ct_Col_CompanyName1, typeof(string));
                dt.Columns[ct_Col_CompanyName1].DefaultValue = defaultValueOfstring;

                //// 自社名称2
                //dt.Columns.Add( ct_Col_CompanyName2, typeof( string ) );
                //dt.Columns[ct_Col_CompanyName2].DefaultValue = defaultValueOfstring;

                //// 拠点ガイド名称
                //dt.Columns.Add( ct_Col_SectionGuideNm, typeof( string ) );
                //dt.Columns[ct_Col_SectionGuideNm].DefaultValue = defaultValueOfstring;

                // --- ADD 2008/10/08 -------------------------------->>>>>
                // 倉庫コード
                dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));
                dt.Columns[ct_Col_WarehouseCode].DefaultValue = defaultValueOfstring;

                // 倉庫名称
                dt.Columns.Add(ct_Col_WarehouseName, typeof(string));
                dt.Columns[ct_Col_WarehouseName].DefaultValue = defaultValueOfstring;
                // --- ADD 2008/10/08 --------------------------------<<<<<
                // 従業員コード
                dt.Columns.Add(ct_Col_EmployeeCode, typeof(string));
                dt.Columns[ct_Col_EmployeeCode].DefaultValue = defaultValueOfstring;

                // 従業員名称
                dt.Columns.Add(ct_Col_EmployeeName, typeof(string));
                dt.Columns[ct_Col_EmployeeName].DefaultValue = defaultValueOfstring;

                // 得意先コード
                dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = defaultValueOfInt32;

                // 得意先略称
                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = defaultValueOfstring;

                // --- ADD 2009/04/11------------------------------------>>>>>
                // 仕入先コード 
                dt.Columns.Add(ct_Col_SupplierCode, typeof(Int32)); 
                dt.Columns[ct_Col_SupplierCode].DefaultValue = defaultValueOfInt32; 

                // 仕入先略称
                dt.Columns.Add(ct_Col_SupplierSnm, typeof(string)); 
                dt.Columns[ct_Col_SupplierSnm].DefaultValue = defaultValueOfstring;
                // --- ADD 2009/04/11------------------------------------<<<<<

                // 商品メーカーコード
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defaultValueOfInt32;

                //// メーカー名称
                //dt.Columns.Add( ct_Col_MakerName, typeof( string ) ); // DEL 2008/10/08
                //dt.Columns[ct_Col_MakerName].DefaultValue = defaultValueOfstring; // DEL 2008/10/08
                dt.Columns.Add(ct_Col_MakerShortName, typeof(string));
                dt.Columns[ct_Col_MakerShortName].DefaultValue = defaultValueOfstring;

                // 商品大分類コード
                //dt.Columns.Add( ct_Col_LargeGoodsGanreCode, typeof( string ) ); // DEL 2008/10/08
                //dt.Columns[ct_Col_LargeGoodsGanreCode].DefaultValue = defaultValueOfstring; // DEL 2008/10/08
                dt.Columns.Add(ct_Col_GoodsLGroup, typeof(Int32)); // ADD 2008/10/08
                dt.Columns[ct_Col_GoodsLGroup].DefaultValue = defaultValueOfInt32; // ADD 2008/10/08

                // 商品大分類名称
                //dt.Columns.Add( ct_Col_LargeGoodsGanreName, typeof( string ) ); // DEL 2008/10/08
                //dt.Columns[ct_Col_LargeGoodsGanreName].DefaultValue = defaultValueOfstring; // DEL 2008/10/08
                dt.Columns.Add(ct_Col_GoodsLGroupName, typeof(string)); // ADD 2008/10/08
                dt.Columns[ct_Col_GoodsLGroupName].DefaultValue = defaultValueOfstring; // ADD 2008/10/08

                // 商品中分類コード
                //dt.Columns.Add( ct_Col_MediumGoodsGanreCode, typeof( string ) ); // DEL 2008/10/08
                //dt.Columns[ct_Col_MediumGoodsGanreCode].DefaultValue = defaultValueOfstring; // DEL 2008/10/08
                dt.Columns.Add(ct_Col_GoodsMGroup, typeof(Int32)); // ADD 2008/10/08
                dt.Columns[ct_Col_GoodsMGroup].DefaultValue = defaultValueOfInt32; // ADD 2008/10/08

                // 商品中分類名称
                //dt.Columns.Add( ct_Col_MediumGoodsGanreName, typeof( string ) ); // DEL 2008/10/08
                //dt.Columns[ct_Col_MediumGoodsGanreName].DefaultValue = defaultValueOfstring; // DEL 2008/10/08
                dt.Columns.Add(ct_Col_GoodsMGroupName, typeof(string)); // ADD 2008/10/08
                dt.Columns[ct_Col_GoodsMGroupName].DefaultValue = defaultValueOfstring; // ADD 2008/10/08

                // グループコード
                //dt.Columns.Add( ct_Col_DetailGoodsGanreCode, typeof( string ) ); // DEL 2008/10/08
                //dt.Columns[ct_Col_DetailGoodsGanreCode].DefaultValue = defaultValueOfstring; // DEL 2008/10/08
                dt.Columns.Add(ct_Col_BLGroupCode, typeof(Int32)); // ADD 2008/10/08
                dt.Columns[ct_Col_BLGroupCode].DefaultValue = defaultValueOfInt32; // ADD 2008/10/08

                // グループコード名称
                //dt.Columns.Add( ct_Col_DetailGoodsGanreName, typeof( string ) ); // DEL 2008/10/08
                //dt.Columns[ct_Col_DetailGoodsGanreName].DefaultValue = defaultValueOfstring; // DEL 2008/10/08
                dt.Columns.Add(ct_Col_BLGroupKanaName, typeof(string)); // ADD 2008/10/08
                dt.Columns[ct_Col_BLGroupKanaName].DefaultValue = defaultValueOfstring; // ADD 2008/10/08

                // BLコード
                dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = defaultValueOfInt32;

                // BLコード名称（全角）
                dt.Columns.Add(ct_Col_BLGoodsHalfName, typeof(string));
                dt.Columns[ct_Col_BLGoodsHalfName].DefaultValue = defaultValueOfstring;

                // 商品番号
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;

                // 商品名略称
                //dt.Columns.Add( ct_Col_GoodsShortName, typeof( string ) );
                //dt.Columns[ct_Col_GoodsShortName].DefaultValue = defaultValueOfstring;
                dt.Columns.Add(ct_Col_GoodsNameKana, typeof(string));
                dt.Columns[ct_Col_GoodsNameKana].DefaultValue = defaultValueOfstring;

                // --- ADD 2008/10/08 -------------------------------->>>>>
                // 当月出荷数
                dt.Columns.Add(ct_Col_MonthTotalSalesCount, typeof(double));
                dt.Columns[ct_Col_MonthTotalSalesCount].DefaultValue = defaultValueOfDouble;
                // 当月売上額
                dt.Columns.Add(ct_Col_MonthSalesMoney, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesMoney].DefaultValue = defaultValueOfInt64;
                // 当月返品額
                dt.Columns.Add(ct_Col_MonthSalesRetGoodsPrice, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesRetGoodsPrice].DefaultValue = defaultValueOfInt64;
                // 当月値引額
                dt.Columns.Add(ct_Col_MonthDiscountPrice, typeof(Int64));
                dt.Columns[ct_Col_MonthDiscountPrice].DefaultValue = defaultValueOfInt64;
                // 当月粗利額
                dt.Columns.Add(ct_Col_MonthGrossProfit, typeof(Int64));
                dt.Columns[ct_Col_MonthGrossProfit].DefaultValue = defaultValueOfInt64;
                // 当月純売上額
                dt.Columns.Add(ct_Col_MonthPureSalesMoney, typeof(Int64));
                dt.Columns[ct_Col_MonthPureSalesMoney].DefaultValue = defaultValueOfInt64;

                // 当期出荷数
                dt.Columns.Add(ct_Col_AnnualTotalSalesCount, typeof(double));
                dt.Columns[ct_Col_AnnualTotalSalesCount].DefaultValue = defaultValueOfDouble;
                // 当期売上額
                dt.Columns.Add(ct_Col_AnnualSalesMoney, typeof(Int64));
                dt.Columns[ct_Col_AnnualSalesMoney].DefaultValue = defaultValueOfInt64;
                // 当期返品額
                dt.Columns.Add(ct_Col_AnnualSalesRetGoodsPrice, typeof(Int64));
                dt.Columns[ct_Col_AnnualSalesRetGoodsPrice].DefaultValue = defaultValueOfInt64;
                // 当期値引額
                dt.Columns.Add(ct_Col_AnnualDiscountPrice, typeof(Int64));
                dt.Columns[ct_Col_AnnualDiscountPrice].DefaultValue = defaultValueOfInt64;
                // 当期粗利額
                dt.Columns.Add(ct_Col_AnnualGrossProfit, typeof(Int64));
                dt.Columns[ct_Col_AnnualGrossProfit].DefaultValue = defaultValueOfInt64;
                // 当期純売上額
                dt.Columns.Add(ct_Col_AnnualPureSalesMoney, typeof(Int64));
                dt.Columns[ct_Col_AnnualPureSalesMoney].DefaultValue = defaultValueOfInt64;

                // 当月粗利率
                dt.Columns.Add(ct_Col_MonthGrossProfitRate, typeof(double));
                dt.Columns[ct_Col_MonthGrossProfitRate].DefaultValue = defaultValueOfDouble;
                // 当期粗利率
                dt.Columns.Add(ct_Col_AnnualGrossProfitRate, typeof(double));
                dt.Columns[ct_Col_AnnualGrossProfitRate].DefaultValue = defaultValueOfDouble;

                // 当月純売上額
                dt.Columns.Add(ct_Col_MonthPureSalesMoneyOrg, typeof(Int64));
                dt.Columns[ct_Col_MonthPureSalesMoneyOrg].DefaultValue = defaultValueOfInt64;
                // 当期純売上額
                dt.Columns.Add(ct_Col_AnnualPureSalesMoneyOrg, typeof(Int64));
                dt.Columns[ct_Col_AnnualPureSalesMoneyOrg].DefaultValue = defaultValueOfInt64;

                // 当月粗利額(粗利率計算用、金額単位変換しない)
                dt.Columns.Add(ct_Col_MonthGrossProfitOrg, typeof(Int64));
                dt.Columns[ct_Col_AnnualGrossProfit].DefaultValue = defaultValueOfInt64;
                // 当期粗利額(粗利率計算用、金額単位変換しない)
                dt.Columns.Add(ct_Col_AnnualGrossProfitOrg, typeof(Int64));
                dt.Columns[ct_Col_AnnualGrossProfit].DefaultValue = defaultValueOfInt64;
                // --- ADD 2008/10/08 --------------------------------<<<<< 

                // --- DEL 2008/10/08 -------------------------------->>>>>
                //// 当月売上回数
                //dt.Columns.Add( ct_Col_SalesTimes, typeof( Int32 ) );
                //dt.Columns[ct_Col_SalesTimes].DefaultValue = defaultValueOfInt32;

                //// 当月売上数計
                //dt.Columns.Add( ct_Col_TotalSalesCount, typeof( Double ) );
                //dt.Columns[ct_Col_TotalSalesCount].DefaultValue = defaultValueOfDouble;

                //// 当月売上伝票合計（税抜き）
                //dt.Columns.Add( ct_Col_SalesTotalTaxExc, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesTotalTaxExc].DefaultValue = defaultValueOfInt64;

                //// 当月返品額
                //dt.Columns.Add( ct_Col_SalesRetGoodsPrice, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesRetGoodsPrice].DefaultValue = defaultValueOfInt64;

                //// 当月値引金額
                //dt.Columns.Add( ct_Col_DiscountPrice, typeof( Int64 ) );
                //dt.Columns[ct_Col_DiscountPrice].DefaultValue = defaultValueOfInt64;

                //// 当月粗利金額
                //dt.Columns.Add( ct_Col_GrossProfit, typeof( Int64 ) );
                //dt.Columns[ct_Col_GrossProfit].DefaultValue = defaultValueOfInt64;

                //// 当期売上回数
                //dt.Columns.Add( ct_Col_TtlSalesTimes, typeof( Int32 ) );
                //dt.Columns[ct_Col_TtlSalesTimes].DefaultValue = defaultValueOfInt32;

                //// 当期売上数計
                //dt.Columns.Add( ct_Col_TtlTotalSalesCount, typeof( Double ) );
                //dt.Columns[ct_Col_TtlTotalSalesCount].DefaultValue = defaultValueOfDouble;

                //// 当期売上伝票合計（税抜き）
                //dt.Columns.Add( ct_Col_TtlSalesTotalTaxExc, typeof( Int64 ) );
                //dt.Columns[ct_Col_TtlSalesTotalTaxExc].DefaultValue = defaultValueOfInt64;

                //// 当期返品額
                //dt.Columns.Add( ct_Col_TtlSalesRetGoodsPrice, typeof( Int64 ) );
                //dt.Columns[ct_Col_TtlSalesRetGoodsPrice].DefaultValue = defaultValueOfInt64;

                //// 当期値引金額
                //dt.Columns.Add( ct_Col_TtlDiscountPrice, typeof( Int64 ) );
                //dt.Columns[ct_Col_TtlDiscountPrice].DefaultValue = defaultValueOfInt64;

                //// 当期粗利金額
                //dt.Columns.Add( ct_Col_TtlGrossProfit, typeof( Int64 ) );
                //dt.Columns[ct_Col_TtlGrossProfit].DefaultValue = defaultValueOfInt64;

                //// 当月純売上金額
                //dt.Columns.Add( ct_Col_SalesPrice, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesPrice].DefaultValue = defaultValueOfInt64;

                //// 当月粗利率
                //dt.Columns.Add( ct_Col_GrossProfitRate, typeof( Double ) );
                //dt.Columns[ct_Col_GrossProfitRate].DefaultValue = defaultValueOfDouble;

                //// 当期純売上金額
                //dt.Columns.Add( ct_Col_TtlSalesPrice, typeof( Int64 ) );
                //dt.Columns[ct_Col_TtlSalesPrice].DefaultValue = defaultValueOfInt64;

                //// 当期粗利率
                //dt.Columns.Add( ct_Col_TtlGrossProfitRate, typeof( Double ) );
                //dt.Columns[ct_Col_TtlGrossProfitRate].DefaultValue = defaultValueOfDouble;

                //// 当月売上伝票合計（計算用）
                //dt.Columns.Add( ct_Col_SalesTotalTaxExcOrg, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesTotalTaxExcOrg].DefaultValue = defaultValueOfInt64;

                //// 当月返品額（計算用）
                //dt.Columns.Add( ct_Col_SalesRetGoodsPriceOrg, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesRetGoodsPriceOrg].DefaultValue = defaultValueOfInt64;

                //// 当月値引金額（計算用）
                //dt.Columns.Add( ct_Col_DiscountPriceOrg, typeof( Int64 ) );
                //dt.Columns[ct_Col_DiscountPriceOrg].DefaultValue = defaultValueOfInt64;

                //// 当月粗利金額（計算用）
                //dt.Columns.Add( ct_Col_GrossProfitOrg, typeof( Int64 ) );
                //dt.Columns[ct_Col_GrossProfitOrg].DefaultValue = defaultValueOfInt64;

                //// 当月純売上金額（計算用）
                //dt.Columns.Add( ct_Col_SalesPriceOrg, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesPriceOrg].DefaultValue = defaultValueOfInt64;

                //// 当期売上伝票合計（計算用）
                //dt.Columns.Add( ct_Col_TtlSalesTotalTaxExcOrg, typeof( Int64 ) );
                //dt.Columns[ct_Col_TtlSalesTotalTaxExcOrg].DefaultValue = defaultValueOfInt64;

                //// 当期返品額（計算用）
                //dt.Columns.Add( ct_Col_TtlSalesRetGoodsPriceOrg, typeof( Int64 ) );
                //dt.Columns[ct_Col_TtlSalesRetGoodsPriceOrg].DefaultValue = defaultValueOfInt64;

                //// 当期値引金額（計算用）
                //dt.Columns.Add( ct_Col_TtlDiscountPriceOrg, typeof( Int64 ) );
                //dt.Columns[ct_Col_TtlDiscountPriceOrg].DefaultValue = defaultValueOfInt64;

                //// 当期粗利金額（計算用）
                //dt.Columns.Add( ct_Col_TtlGrossProfitOrg, typeof( Int64 ) );
                //dt.Columns[ct_Col_TtlGrossProfitOrg].DefaultValue = defaultValueOfInt64;

                //// 当期純売上金額（計算用）
                //dt.Columns.Add( ct_Col_TtlSalesPriceOrg, typeof( Int64 ) );
                //dt.Columns[ct_Col_TtlSalesPriceOrg].DefaultValue = defaultValueOfInt64;
                // --- DEL 2008/10/08 --------------------------------<<<<<

                # endregion
            }
        }
        #endregion
        #endregion
    }
}
