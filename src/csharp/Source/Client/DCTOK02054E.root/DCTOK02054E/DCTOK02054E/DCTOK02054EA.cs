using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 出荷商品分析表テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 出荷商品分析表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 20081 疋田 勇人</br>
	/// <br>Date       : 2007.12.03</br>
	/// <br></br>
    /// <br>Update Note: 2008.10.20 30452 上野 俊治</br>
    /// <br>            ・PM.NS対応</br>
	/// </remarks>
	public class DCTOK02054EA
	{
		#region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_ShipGoodsAnalyze = "Tbl_ShipGoodsAnalyze";

        /// <summary> 拠点コード </summary> 
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> 拠点ガイド名称 </summary> 
        public const string ct_Col_SectionGuideNm = "SectionGuideNm";
        /// <summary> 商品メーカーコード </summary> 
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー名称 </summary> 
        public const string ct_Col_MakerName = "MakerName";
        // --- ADD 2008/10/20 -------------------------------->>>>>
        /// <summary> 仕入先コード </summary> 
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> 仕入先コード </summary> 
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        // --- ADD 2008/10/20 --------------------------------<<<<<
        // --- DEL 2008/10/20 -------------------------------->>>>>
        ///// <summary> 商品区分グループコード </summary> 
        //public const string ct_Col_LargeGoodsGanreCode = "LargeGoodsGanreCode";
        ///// <summary> 商品区分グループ名称 </summary> 
        //public const string ct_Col_LargeGoodsGanreName = "LargeGoodsGanreName";
        ///// <summary> 商品区分コード </summary> 
        //public const string ct_Col_MediumGoodsGanreCode = "MediumGoodsGanreCode";
        ///// <summary> 商品区分名称 </summary> 
        //public const string ct_Col_MediumGoodsGanreName = "MediumGoodsGanreName";
        ///// <summary> 商品区分詳細コード </summary> 
        //public const string ct_Col_DetailGoodsGanreCode = "DetailGoodsGanreCode";
        ///// <summary> 商品区分詳細名称 </summary> 
        //public const string ct_Col_DetailGoodsGanreName = "DetailGoodsGanreName";
        ///// <summary> BL商品コード </summary> 
        //public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        ///// <summary> BL商品コード名称（全角） </summary> 
        //public const string ct_Col_BLGoodsFullName = "BLGoodsFullName";
        // --- DEL 2008/10/20 -------------------------------->>>>>
        /// <summary> 商品番号 </summary> 
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 商品名略称 </summary> 
        public const string ct_Col_GoodsShortName = "GoodsShortName";
        /// <summary> 在庫登録日 </summary> 
        public const string ct_Col_StockCreateDate = "StockCreateDate";
        ///// <summary> 仕入在庫数 </summary> 
        //public const string ct_Col_SupplierStock = "SupplierStock"; // DEL 2008/10/20
        /// <summary>現在庫</summary>
        public const string ct_Col_ShipmentPosCnt = "ShipmentPosCnt"; // ADD 2008/10/20
        /// <summary> 最低在庫数 </summary> 
        public const string ct_Col_MinimumStockCnt = "MinimumStockCnt";
        /// <summary> 最高在庫数 </summary> 
        public const string ct_Col_MaximumStockCnt = "MaximumStockCnt";
        /// <summary> 売上数計（合計） </summary> 
        public const string ct_Col_TotalCount = "TotalCount";
        /// <summary> 売上数計(在庫) </summary> 
        public const string ct_Col_StockCount = "StockCount";
        /// <summary> 売上数計(取寄) </summary> 
        public const string ct_Col_OrderCount = "OrderCount";
        /// <summary> 売上金額 </summary> 
        public const string ct_Col_SalesMoney = "SalesMoney";
        /// <summary> 粗利金額 </summary> 
        public const string ct_Col_GrossMoney = "GrossMoney";
        /// <summary> 返品額 </summary> 
        public const string ct_Col_SalesRetGoodsPrice = "SalesRetGoodsPrice"; // ADD 2008/10/20
        /// <summary> 値引額 </summary> 
        public const string ct_Col_DiscountPrice = "DiscountPrice"; // ADD 2008/10/20
        // --- ADD 2008/10/20 -------------------------------->>>>>
        /// <summary> 売上金額(在庫) </summary> 
        public const string ct_Col_StockSalesMoney = "StockSalesMoney";
        /// <summary> 粗利金額(在庫) </summary> 
        public const string ct_Col_StockGrossProfit = "StockGrossProfit";
        /// <summary> 返品額(在庫) </summary> 
        public const string ct_Col_StockSalesRetGoodsPrice = "StockSalesRetGoodsPrice";
        /// <summary> 値引額(在庫) </summary> 
        public const string ct_Col_StockDiscountPrice = "StockDiscountPrice";
        // --- ADD 2008/10/20 --------------------------------<<<<<
        /// <summary> 粗利率 </summary> 
        public const string ct_Col_GrossMoneyRate = "GrossMoneyRate";
        /// <summary> 売上数順位</summary> 
        public const string ct_Col_RankTotalCount = "RankTotalCount";
        /// <summary> 売上金額順位</summary> 
        public const string ct_Col_RankSalesMoney = "RankSalesMoney";
        /// <summary> 粗利金額順位</summary> 
        public const string ct_Col_RankGrossMoney = "RankGrossMoney";
        ///// <summary> ソート用　拠点コード </summary> 
        //public const string ct_Col_Sort_SectionCode = "Sort_SectionCode";
        ///// <summary> ソート用  メーカーコード </summary> 
        //public const string ct_Col_Sort_GoodsMaker = "Sort_GoodsMaker";
        ///// <summary> ソート用  商品区分グループコード </summary> 
        //public const string ct_Col_Sort_LargeGoodsGanreCode = "Sort_LargeGoodsGanreCode";
        ///// <summary> ソート用  商品区分コード </summary> 
        //public const string ct_Col_Sort_MediumGoodsGanreCode = "Sort_MediumGoodsGanreCode";
        ///// <summary> ソート用  商品区分詳細コード </summary> 
        //public const string ct_Col_Sort_DetailGoodsGanreCode = "Sort_DetailGoodsGanreCode";
        ///// <summary> ソート用  BL商品コード </summary> 
        //public const string ct_Col_Sort_BLGoodsCode = "Sort_BLGoodsCode";
        ///// <summary> ソート用  商品番号 </summary> 
        //public const string ct_Col_Sort_GoodsNo = "Sort_GoodsNo";
        ///// <summary> ソート用  売上数計 </summary> 
        //public const string ct_Col_Sort_TotalCount = "Sort_TotalCount";
        ///// <summary> ソート用  売上金額 </summary> 
        //public const string ct_Col_Sort_SalesMoney = "Sort_SalesMoney";
        ///// <summary> ソート用  粗利金額 </summary> 
        //public const string ct_Col_Sort_GrossMoney = "Sort_GrossMoney";
        /// <summary> 純売上(在取指定反映済) </summary> 
        public const string ct_Col_PureSalesMoney = "PureSalesMoney"; // ADD 2008/10/20
        /// <summary> 粗利額(在取指定反映済) </summary> 
        public const string ct_Col_PrintGrossMoney = "PrintGrossMoney"; // ADD 2008/10/20
        /// <summary> 小計 率計算用純売上(在取指定反映済) </summary> 
        public const string ct_Col_PureSalesMoneyOrg = "PureSalesMoneyOrg"; // ADD 2008/10/20
        /// <summary> 小計 率計算用粗利金額(在取指定反映済) </summary> 
        public const string ct_Col_GrossMoneyOrg = "GrossMoneyOrg"; // ADD 2008/10/20
   		#endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 出荷商品分析表テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 出荷商品分析表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.12.03</br>
		/// </remarks>
		public DCTOK02054EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ DataSetテーブルスキーマ設定
		/// <summary>
		/// 商品別売上集計DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="dt">設定対象データテーブル</param>
		/// <remarks>
		/// <br>Note       : 商品別売上集計データセットのスキーマを設定する。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.12.03</br>
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
                dt = new DataTable(ct_Tbl_ShipGoodsAnalyze);

                # region ＜＜　Columnを追加　＞＞

                dt.Columns.Add(ct_Col_SectionCode, typeof(string));// 拠点コード
                dt.Columns[ct_Col_SectionCode].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_SectionGuideNm, typeof(string));// 拠点ガイド名称
                dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));// 商品メーカーコード
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_MakerName, typeof(string));// メーカー名称
                dt.Columns[ct_Col_MakerName].DefaultValue = "";

                // --- ADD 2008/10/20 -------------------------------->>>>>
                dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32)); // 仕入先コード
                dt.Columns[ct_Col_SupplierCd].DefaultValue = 0;

                dt.Columns.Add(ct_Col_SupplierSnm, typeof(string)); // 仕入先略称
                dt.Columns[ct_Col_SupplierSnm].DefaultValue = "";
                // --- ADD 2008/10/20 --------------------------------<<<<<

                // --- DEL 2008/10/20 -------------------------------->>>>>
                //dt.Columns.Add(ct_Col_LargeGoodsGanreCode, typeof(string));// 商品区分グループコード
                //dt.Columns[ct_Col_LargeGoodsGanreCode].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_LargeGoodsGanreName, typeof(string));// 商品区分グループ名称
                //dt.Columns[ct_Col_LargeGoodsGanreName].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_MediumGoodsGanreCode, typeof(string));// 商品区分コード
                //dt.Columns[ct_Col_MediumGoodsGanreCode].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_MediumGoodsGanreName, typeof(string));// 商品区分名称
                //dt.Columns[ct_Col_MediumGoodsGanreName].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_DetailGoodsGanreCode, typeof(string));// 商品区分詳細コード
                //dt.Columns[ct_Col_DetailGoodsGanreCode].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_DetailGoodsGanreName, typeof(string));// 商品区分詳細名称
                //dt.Columns[ct_Col_DetailGoodsGanreName].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));// BL商品コード
                //dt.Columns[ct_Col_BLGoodsCode].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_BLGoodsFullName, typeof(string));// BL商品コード名称（全角）
                //dt.Columns[ct_Col_BLGoodsFullName].DefaultValue = "";
                // --- DEL 2008/10/20 --------------------------------<<<<<

                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));// 商品番号
                dt.Columns[ct_Col_GoodsNo].DefaultValue = "";

                dt.Columns.Add(ct_Col_GoodsShortName, typeof(string));// 商品略称
                dt.Columns[ct_Col_GoodsShortName].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_StockCreateDate, typeof(DateTime));// 在庫登録日
                dt.Columns[ct_Col_StockCreateDate].DefaultValue = DateTime.MinValue;

                //dt.Columns.Add(ct_Col_SupplierStock, typeof(double));// 仕入在庫数
                //dt.Columns[ct_Col_SupplierStock].DefaultValue = 0; // DEL 2008/10/20

                dt.Columns.Add(ct_Col_ShipmentPosCnt, typeof(double));// 現在庫数
                dt.Columns[ct_Col_ShipmentPosCnt].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_MinimumStockCnt, typeof(double));// 最低在庫数
                dt.Columns[ct_Col_MinimumStockCnt].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_MaximumStockCnt, typeof(double));// 最高在庫数
                dt.Columns[ct_Col_MaximumStockCnt].DefaultValue = 0;

                dt.Columns.Add(ct_Col_TotalCount, typeof(double));// 売上数計（合計）
                dt.Columns[ct_Col_TotalCount].DefaultValue = 0;

                dt.Columns.Add(ct_Col_StockCount, typeof(double));// 売上数計(在庫)
                dt.Columns[ct_Col_StockCount].DefaultValue = 0;

                dt.Columns.Add(ct_Col_OrderCount, typeof(double));// 売上数計(取寄)
                dt.Columns[ct_Col_OrderCount].DefaultValue = 0;

                dt.Columns.Add(ct_Col_SalesMoney, typeof(Int64));// 売上金額
                dt.Columns[ct_Col_SalesMoney].DefaultValue = 0;

                dt.Columns.Add(ct_Col_GrossMoney, typeof(Int64));// 粗利金額
                dt.Columns[ct_Col_GrossMoney].DefaultValue = 0;

                // --- ADD 2008/10/20 -------------------------------->>>>>
                dt.Columns.Add(ct_Col_SalesRetGoodsPrice, typeof(Int64));// 返品額
                dt.Columns[ct_Col_SalesRetGoodsPrice].DefaultValue = 0;

                dt.Columns.Add(ct_Col_DiscountPrice, typeof(Int64));// 値引額
                dt.Columns[ct_Col_DiscountPrice].DefaultValue = 0;
                // --- ADD 2008/10/20 --------------------------------<<<<< 
                // --- ADD 2008/10/20 -------------------------------->>>>>
                dt.Columns.Add(ct_Col_StockSalesMoney, typeof(Int64));// 売上金額(在庫)
                dt.Columns[ct_Col_StockSalesMoney].DefaultValue = 0;

                dt.Columns.Add(ct_Col_StockGrossProfit, typeof(Int64));// 粗利金額(在庫)
                dt.Columns[ct_Col_StockGrossProfit].DefaultValue = 0;

                dt.Columns.Add(ct_Col_StockSalesRetGoodsPrice, typeof(Int64));// 返品額(在庫)
                dt.Columns[ct_Col_StockSalesRetGoodsPrice].DefaultValue = 0;

                dt.Columns.Add(ct_Col_StockDiscountPrice, typeof(Int64));// 値引額(在庫)
                dt.Columns[ct_Col_StockDiscountPrice].DefaultValue = 0;
                // --- ADD 2008/10/20 --------------------------------<<<<<

                dt.Columns.Add(ct_Col_GrossMoneyRate, typeof(double));// 粗利率
                dt.Columns[ct_Col_GrossMoneyRate].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_RankTotalCount, typeof(double));// 売上数順位(上位)
                dt.Columns[ct_Col_RankTotalCount].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_RankSalesMoney, typeof(double));// 売上金額順位(上位)
                dt.Columns[ct_Col_RankSalesMoney].DefaultValue = 0;

                dt.Columns.Add(ct_Col_RankGrossMoney, typeof(double));// 粗利金額順位(上位)
                dt.Columns[ct_Col_RankGrossMoney].DefaultValue = 0;

                //dt.Columns.Add(ct_Col_Sort_SectionCode, typeof(string));// ソート用　拠点コード
                //dt.Columns[ct_Col_Sort_SectionCode].DefaultValue = "";

                //dt.Columns.Add(ct_Col_Sort_GoodsMaker, typeof(Int32));// ソート用　商品メーカーコード
                //dt.Columns[ct_Col_Sort_GoodsMaker].DefaultValue = 0;

                //dt.Columns.Add(ct_Col_Sort_LargeGoodsGanreCode, typeof(string));// ソート用  商品区分グループコード
                //dt.Columns[ct_Col_Sort_LargeGoodsGanreCode].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_Sort_MediumGoodsGanreCode, typeof(string));// ソート用  商品区分コード
                //dt.Columns[ct_Col_Sort_MediumGoodsGanreCode].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_Sort_DetailGoodsGanreCode, typeof(string));// ソート用  商品区分詳細コード
                //dt.Columns[ct_Col_Sort_DetailGoodsGanreCode].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_Sort_BLGoodsCode, typeof(Int32));// ソート用  BL商品コード
                //dt.Columns[ct_Col_Sort_BLGoodsCode].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_Sort_GoodsNo, typeof(string));// ソート用　商品番号
                //dt.Columns[ct_Col_Sort_GoodsNo].DefaultValue = "";

                //dt.Columns.Add(ct_Col_Sort_TotalCount, typeof(double));// ソート用  売上数計
                //dt.Columns[ct_Col_Sort_TotalCount].DefaultValue = 0;
 
                //dt.Columns.Add(ct_Col_Sort_SalesMoney, typeof(long));// ソート用  売上金額
                //dt.Columns[ct_Col_Sort_SalesMoney].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_Sort_GrossMoney, typeof(long));// ソート用  粗利金額
                //dt.Columns[ct_Col_Sort_GrossMoney].DefaultValue = 0;

                dt.Columns.Add(ct_Col_PureSalesMoney, typeof(Int64));// 純売上金額
                dt.Columns[ct_Col_PureSalesMoney].DefaultValue = 0; // ADD 2008/10/20

                dt.Columns.Add(ct_Col_PrintGrossMoney, typeof(Int64));// 印字用粗利金額
                dt.Columns[ct_Col_PrintGrossMoney].DefaultValue = 0; // ADD 2008/10/20

                dt.Columns.Add(ct_Col_PureSalesMoneyOrg, typeof(Int64));// 小計率計算用　純売上金額
                dt.Columns[ct_Col_PureSalesMoneyOrg].DefaultValue = 0; // ADD 2008/10/20

                dt.Columns.Add(ct_Col_GrossMoneyOrg, typeof(Int64));// 小計率計算用　粗利金額
                dt.Columns[ct_Col_GrossMoneyOrg].DefaultValue = 0; // ADD 2008/10/20
                # endregion ＜＜　Columnを追加　＞＞
            }
		}
		#endregion
		#endregion
	}
}
