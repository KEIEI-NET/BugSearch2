using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 在庫月報年報テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 在庫月報年報テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 30416 長沼 賢二</br>
	/// <br>Date       : 2008.07.17</br>
	/// <br></br>
    /// <br>Update Note: 2008/10/10 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>           : </br>
	/// </remarks>
	public class PMZAI02014EA
	{
		#region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_StockNoShipment = "Tbl_StockNoShipment";

        /// <summary> 倉庫コード </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary> 倉庫名称 </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> 在庫発注先コード </summary>
        public const string ct_Col_StockSupplierCode = "StockSupplierCode";
        /// <summary> 仕入先略称 </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        /// <summary> 商品番号 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 商品名称 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> 倉庫棚番 </summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary> 前月末在庫数 </summary>
        public const string ct_Col_LMonthStockCnt = "LMonthStockCnt";
        /// <summary> 仕入数 </summary>
        public const string ct_Col_StockCount = "StockCount";
        /// <summary> 移動入荷数 </summary>
        public const string ct_Col_MoveArrivalCnt = "MoveArrivalCnt";
        /// <summary> 総入荷数 </summary>
        public const string ct_Col_TotalArrivalCnt = "TotalArrivalCnt";
        /// <summary> 売上数 </summary>
        public const string ct_Col_SalesCount = "SalesCount";
        /// <summary> 移動出荷数 </summary>
        public const string ct_Col_MoveShipmentCnt = "MoveShipmentCnt";
        /// <summary> 総出荷数 </summary>
        public const string ct_Col_TotalShipmentCnt = "TotalShipmentCnt";
        /// <summary> 最高在庫数 </summary>
        public const string ct_Col_MaximumStockCnt = "MaximumStockCnt";
        /// <summary> 最低在庫数 </summary>
        public const string ct_Col_MinimumStockCnt = "MinimumStockCnt";
        /// <summary> 原価 </summary>
        public const string ct_Col_SalesCost = "SalesCost";
        /// <summary> 前月末在庫額 </summary>
        public const string ct_Col_LMonthStockPrice = "LMonthStockPrice";
        /// <summary> 仕入金額(税抜き) </summary>
        public const string ct_Col_StockPriceTaxExc = "StockPriceTaxExc";
        /// <summary> 移動入荷額 </summary>
        public const string ct_Col_MoveArrivalPrice = "MoveArrivalPrice";
        /// <summary> 総入荷金額 </summary>
        public const string ct_Col_TotalArrivalPrice = "TotalArrivalPrice";
        /// <summary> 売上金額(税抜き) </summary>
        public const string ct_Col_SalesMoneyTaxExc = "SalesMoneyTaxExc";
        /// <summary> 移動出荷額 </summary>
        public const string ct_Col_MoveShipmentPrice = "MoveShipmentPrice";
        /// <summary> 総出荷金額 </summary>
        public const string ct_Col_TotalShipmentPrice = "TotalShipmentPrice";
        /// <summary> 粗利金額 </summary>
        public const string ct_Col_GrossProfit = "GrossProfit";
        /// <summary> 粗利率 </summary>
        public const string ct_Col_GrossProfitRate = "GrossProfitRate";
        /// <summary> 在庫総数 </summary>
        public const string ct_Col_StockTotal = "StockTotal";
        /// <summary> マシン在庫額 </summary>
        public const string ct_Col_StockMashinePrice = "StockMashinePrice";
        /// <summary> 回転率 </summary>
        public const string ct_Col_TurnOver = "TurnOver";
        /// <summary> マーク </summary>
        public const string ct_Col_Mark = "Mark";
        /// <summary> メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー名称 </summary>
        public const string ct_Col_MakerName = "MakerName";

        /// <summary> 倉庫棚番ブレイク </summary>
        public const string ct_Col_WarehouseShelfNoBreak = "WarehouseShelfNoBreak";

        /// <summary> ソート用　拠点コード </summary>
        public const string ct_Col_Sort_SectionCode = "Sort_SectionCode";
        /// <summary> ソート用　倉庫コード </summary>
        public const string ct_Col_Sort_WarehouseCode = "Sort_WarehouseCode";
        /// <summary> ソート用　仕入先コード </summary>
        public const string ct_Col_Sort_CustomerCode = "Sort_CustomerCode";
        /// <summary> ソート用　商品メーカーコード </summary>
        public const string ct_Col_Sort_GoodsMakerCd = "Sort_GoodsMakerCd";
        /// <summary> ソート用　商品番号 </summary>
        public const string ct_Col_Sort_GoodsNo = "Sort_GoodsNo";
        /// <summary> ソート用　倉庫棚番ブレイク </summary>
        public const string ct_Col_Sort_WarehouseShelfNoBreak = "Sort_WarehouseShelfNoBreak";
        /// <summary> ソート用　倉庫棚番 </summary>
        public const string ct_Col_Sort_WarehouseShelfNo = "Sort_WarehouseShelfNo";

        /// <summary> ソート用　商品大分類コード </summary>
        public const string ct_Col_Sort_GoodsLGroupCode = "Sort_GoodsLGroupCode";
        /// <summary> ソート用　商品中分類コード </summary>
        public const string ct_Col_Sort_GoodsMGroupCode = "Sort_GoodsMGroupCode";
        /// <summary> ソート用　BLグループコード </summary>
        public const string ct_Col_Sort_BLGroupCode = "Sort_BLGroupCode";
        /// <summary> ソート用　商品大分類名称 </summary>
        public const string ct_Col_Sort_GoodsLGroupName = "Sort_GoodsLGroupName";
        /// <summary> ソート用　商品中分類名称 </summary>
        public const string ct_Col_Sort_GoodsMGroupName = "Sort_GoodsMGroupName";
        /// <summary> ソート用　BLグループ名称 </summary>
        public const string ct_Col_Sort_BLGroupName = "Sort_BLGroupName";

		#endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 在庫月報年報テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 在庫月報年報テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 30416 長沼 賢二</br>
		/// <br>Date       : 2008.07.17</br>
		/// </remarks>
		public PMZAI02014EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ DataSetテーブルスキーマ設定
		/// <summary>
		/// DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="dt">設定対象データテーブル</param>
		/// <remarks>
		/// <br>Note       : データセットのスキーマを設定する。</br>
		/// <br>Programmer : 30416 長沼 賢二</br>
		/// <br>Date       : 2008.07.17</br>
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
                dt = new DataTable(ct_Tbl_StockNoShipment);
                            
                dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));               // 倉庫コード
                dt.Columns[ct_Col_WarehouseCode].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_WarehouseName, typeof(string));               // 倉庫名称
                dt.Columns[ct_Col_WarehouseName].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_StockSupplierCode, typeof(Int32));            // 在庫発注先コード
                dt.Columns[ct_Col_StockSupplierCode].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));                 // 仕入先略称
                dt.Columns[ct_Col_SupplierSnm].DefaultValue = 0;

                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));                     // 商品番号
                dt.Columns[ct_Col_GoodsNo].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));                   // 商品名称
                dt.Columns[ct_Col_GoodsName].DefaultValue = "";

                dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));            // 倉庫棚番
                dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = "";

                dt.Columns.Add(ct_Col_LMonthStockCnt, typeof(Double));              // 前月末在庫数
                dt.Columns[ct_Col_LMonthStockCnt].DefaultValue = 0;

                dt.Columns.Add(ct_Col_StockCount, typeof(Double));                  // 仕入数
                dt.Columns[ct_Col_StockCount].DefaultValue = 0;

                dt.Columns.Add(ct_Col_MoveArrivalCnt, typeof(Double));              // 移動入荷数
                dt.Columns[ct_Col_MoveArrivalCnt].DefaultValue = 0;

                dt.Columns.Add(ct_Col_TotalArrivalCnt, typeof(Double));             // 総入荷数
                dt.Columns[ct_Col_TotalArrivalCnt].DefaultValue = 0;

                dt.Columns.Add(ct_Col_SalesCount, typeof(Double));                  // 売上数
                dt.Columns[ct_Col_SalesCount].DefaultValue = 0;

                dt.Columns.Add(ct_Col_MoveShipmentCnt, typeof(Double));             // 移動出荷数
                dt.Columns[ct_Col_MoveShipmentCnt].DefaultValue = 0;

                dt.Columns.Add(ct_Col_TotalShipmentCnt, typeof(Double));            // 総出荷数
                dt.Columns[ct_Col_TotalShipmentCnt].DefaultValue = 0;

                dt.Columns.Add(ct_Col_MaximumStockCnt, typeof(Double));             // 最高在庫数
                dt.Columns[ct_Col_MaximumStockCnt].DefaultValue = 0;

                dt.Columns.Add(ct_Col_MinimumStockCnt, typeof(Double));             // 最低在庫数
                dt.Columns[ct_Col_MinimumStockCnt].DefaultValue = 0;

                dt.Columns.Add(ct_Col_SalesCost, typeof(Double));                   // 原価
                dt.Columns[ct_Col_SalesCost].DefaultValue = 0;

                dt.Columns.Add(ct_Col_LMonthStockPrice, typeof(Double));            // 前月末在庫額
                dt.Columns[ct_Col_LMonthStockPrice].DefaultValue = 0;

                dt.Columns.Add(ct_Col_StockPriceTaxExc, typeof(Double));            // 仕入金額(税抜き)
                dt.Columns[ct_Col_StockPriceTaxExc].DefaultValue = 0;

                dt.Columns.Add(ct_Col_MoveArrivalPrice, typeof(Double));            // 移動入荷額
                dt.Columns[ct_Col_MoveArrivalPrice].DefaultValue = 0;

                dt.Columns.Add(ct_Col_TotalArrivalPrice, typeof(Double));           // 総入荷金額
                dt.Columns[ct_Col_TotalArrivalPrice].DefaultValue = 0;

                dt.Columns.Add(ct_Col_SalesMoneyTaxExc, typeof(Double));            // 売上金額(税抜き)
                dt.Columns[ct_Col_SalesMoneyTaxExc].DefaultValue = 0;

                dt.Columns.Add(ct_Col_MoveShipmentPrice, typeof(Double));           // 移動出荷額
                dt.Columns[ct_Col_MoveShipmentPrice].DefaultValue = 0;

                dt.Columns.Add(ct_Col_TotalShipmentPrice, typeof(Double));          // 総出荷金額
                dt.Columns[ct_Col_TotalShipmentPrice].DefaultValue = 0;

                dt.Columns.Add(ct_Col_GrossProfit, typeof(Double));                 // 粗利金額
                dt.Columns[ct_Col_GrossProfit].DefaultValue = 0;

                //dt.Columns.Add(ct_Col_GrossProfitRate, typeof(Int64));              // 粗利率     //DEL 2008/10/10 小数点以下を表示
                dt.Columns.Add(ct_Col_GrossProfitRate, typeof(Double));             // 粗利率       //ADD 2008/10/10
                dt.Columns[ct_Col_GrossProfitRate].DefaultValue = 0;
  
                dt.Columns.Add(ct_Col_StockTotal, typeof(Double));                  // 在庫総数
                dt.Columns[ct_Col_StockTotal].DefaultValue = 0;

                dt.Columns.Add(ct_Col_StockMashinePrice, typeof(Double));           // マシン在庫額
                dt.Columns[ct_Col_StockMashinePrice].DefaultValue = 0;

                dt.Columns.Add(ct_Col_TurnOver, typeof(Double));                    // 回転率
                dt.Columns[ct_Col_TurnOver].DefaultValue = 0;

                dt.Columns.Add(ct_Col_Mark, typeof(string));                        // マーク
                dt.Columns[ct_Col_Mark].DefaultValue = 0;

                dt.Columns.Add(ct_Col_WarehouseShelfNoBreak, typeof(string));       // 倉庫棚番ブレイク
                dt.Columns[ct_Col_WarehouseShelfNoBreak].DefaultValue = "";

                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(string));              // メーカーコード
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = "";

                dt.Columns.Add(ct_Col_MakerName, typeof(string));                   // メーカー名称
                dt.Columns[ct_Col_MakerName].DefaultValue = "";
                


                dt.Columns.Add(ct_Col_Sort_SectionCode, typeof(string));            // ソート用　拠点コード
                dt.Columns[ct_Col_Sort_SectionCode].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_Sort_WarehouseCode, typeof(string));          // ソート用　倉庫コード
                dt.Columns[ct_Col_Sort_WarehouseCode].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_Sort_CustomerCode, typeof(Int32));            // ソート用　仕入先コード
                dt.Columns[ct_Col_Sort_CustomerCode].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_Sort_GoodsMakerCd, typeof(Int32));            // ソート用　商品メーカーコード
                dt.Columns[ct_Col_Sort_GoodsMakerCd].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_Sort_GoodsNo, typeof(string));                // ソート用　商品番号
                dt.Columns[ct_Col_Sort_GoodsNo].DefaultValue = "";

                dt.Columns.Add(ct_Col_Sort_WarehouseShelfNo, typeof(string));       // ソート用　倉庫棚番
                dt.Columns[ct_Col_Sort_WarehouseShelfNo].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_Sort_WarehouseShelfNoBreak, typeof(string));  // ソート用　倉庫棚番ブレイク
                dt.Columns[ct_Col_Sort_WarehouseShelfNoBreak].DefaultValue = "";


                dt.Columns.Add(ct_Col_Sort_GoodsLGroupCode, typeof(string));            // ソート用　商品大分類
                dt.Columns[ct_Col_Sort_GoodsLGroupCode].DefaultValue = "";
                dt.Columns.Add(ct_Col_Sort_GoodsMGroupCode, typeof(string));            // ソート用　商品中分類
                dt.Columns[ct_Col_Sort_GoodsMGroupCode].DefaultValue = "";
                dt.Columns.Add(ct_Col_Sort_BLGroupCode, typeof(string));            // ソート用　BLグループ
                dt.Columns[ct_Col_Sort_BLGroupCode].DefaultValue = "";

                dt.Columns.Add(ct_Col_Sort_GoodsLGroupName, typeof(string));            // ソート用　商品大分類
                dt.Columns[ct_Col_Sort_GoodsLGroupName].DefaultValue = "";
                dt.Columns.Add(ct_Col_Sort_GoodsMGroupName, typeof(string));            // ソート用　商品中分類
                dt.Columns[ct_Col_Sort_GoodsMGroupName].DefaultValue = "";
                dt.Columns.Add(ct_Col_Sort_BLGroupName, typeof(string));            // ソート用　BLグループ
                dt.Columns[ct_Col_Sort_BLGroupName].DefaultValue = "";

            }
		}
		#endregion
		#endregion
	}
}
