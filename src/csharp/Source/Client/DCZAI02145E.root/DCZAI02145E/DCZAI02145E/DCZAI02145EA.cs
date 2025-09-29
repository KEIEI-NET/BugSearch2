//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫分析順位表
// プログラム概要   : 在庫分析順位表テーブルスキーマクラスの定義・初期化及び
//                    インスタンス生成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2006 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木 正臣
// 作 成 日  2007/09/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/02/27  修正内容 : 障害対応12033
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/27  修正内容 : 不具合対応[12783]
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 在庫分析順位表テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫分析順位表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 22018 鈴木 正臣</br>
	/// <br>Date       : 2007.09.19</br>
	/// <br></br>
    /// <br>Update Note: 2009/02/27 30452 上野 俊治</br>
    /// <br>            ・障害対応12033</br>
    /// <br>           : 2009/03/27       照田 貴志　不具合対応[12783]</br>
	/// </remarks>
	public class DCZAI02145EA
	{
		#region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_StockAnalysisOrder = "Tbl_StockAnalysisOrder";

        /// <summary> 拠点コード </summary> 
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> 拠点ガイド名称 </summary> 
        public const string ct_Col_SectionGuideNm = "SectionGuideNm";
        /// <summary> 倉庫コード </summary> 
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary> 倉庫名称 </summary> 
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> 仕入先コード </summary> 
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 仕入先名称 </summary> 
        public const string ct_Col_CustomerName = "CustomerName";
        /// <summary> 仕入先名称2 </summary> 
        public const string ct_Col_CustomerName2 = "CustomerName2";
        ///// <summary> 仕入先略称 </summary> 
        //public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> 商品メーカーコード </summary> 
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー名称 </summary> 
        public const string ct_Col_MakerName = "MakerName";
        ///// <summary> 商品区分グループコード </summary> 
        /// <summary> 商品大分類コード </summary> 
        public const string ct_Col_LargeGoodsGanreCode = "LargeGoodsGanreCode";
        ///// <summary> 商品区分グループ名称 </summary> 
        //public const string ct_Col_LargeGoodsGanreName = "LargeGoodsGanreName"; // DEL 2009/02/27
        ///// <summary> 商品区分コード </summary> 
        /// <summary> 商品中分類コード </summary> 
        public const string ct_Col_MediumGoodsGanreCode = "MediumGoodsGanreCode";
        ///// <summary> 商品区分名称 </summary> 
        //public const string ct_Col_MediumGoodsGanreName = "MediumGoodsGanreName"; // DEL 2009/02/27
        /// <summary> 商品区分詳細コード </summary> 
        /// <summary> グループコード </summary> 
        public const string ct_Col_DetailGoodsGanreCode = "DetailGoodsGanreCode";
        ///// <summary> 商品区分詳細名称 </summary> 
        //public const string ct_Col_DetailGoodsGanreName = "DetailGoodsGanreName"; // DEL 2009/02/27
        /// <summary> 商品番号 </summary> 
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 商品名称 </summary> 
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> 倉庫棚番 </summary> 
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary> 売上金額（税抜き）順位 </summary> 
        public const string ct_Col_SalesMoneyTaxExcOrder = "SalesMoneyTaxExcOrder";
        /// <summary> 売上金額（税抜き） </summary> 
        public const string ct_Col_SalesMoneyTaxExc = "SalesMoneyTaxExc";
        /// <summary> 粗利金額順位 </summary> 
        public const string ct_Col_GrossProfitOrder = "GrossProfitOrder";
        /// <summary> 粗利金額 </summary> 
        public const string ct_Col_GrossProfit = "GrossProfit";
        /// <summary> 出荷数順位 </summary> 
        public const string ct_Col_ShipmentCntOrder = "ShipmentCntOrder";
        /// <summary> 出荷数 </summary> 
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";
        /// <summary> 在庫登録日 </summary> 
        public const string ct_Col_StockCreateDate = "StockCreateDate";
        /// <summary> 出荷可能数 </summary> 
        public const string ct_Col_ShipmentPosCnt = "ShipmentPosCnt";
        /// <summary> 最低在庫数 </summary> 
        public const string ct_Col_MinimumStockCnt = "MinimumStockCnt";
        /// <summary> 最高在庫数 </summary> 
        public const string ct_Col_MaximumStockCnt = "MaximumStockCnt";

        /// <summary> ソート用　拠点コード </summary> 
        public const string ct_Col_Sort_SectionCode = "Sort_SectionCode";
        /// <summary> ソート用　倉庫コード </summary> 
        public const string ct_Col_Sort_WarehouseCode = "Sort_WarehouseCode";
        /// <summary> ソート用　売上金額（税抜き）順位 </summary> 
        public const string ct_Col_Sort_SalesMoneyTaxExcOrder = "Sort_SalesMoneyTaxExcOrder";
        /// <summary> ソート用　粗利金額順位 </summary> 
        public const string ct_Col_Sort_GrossProfitOrder = "Sort_GrossProfitOrder";
        /// <summary> ソート用　出荷数順位 </summary> 
        public const string ct_Col_Sort_ShipmentCntOrder = "Sort_ShipmentCntOrder";
        /// <summary> ソート用　商品番号 </summary> 
        public const string ct_Col_Sort_GoodsNo = "Sort_GoodsNo";
        /// <summary> ソート用　商品メーカーコード </summary> 
        public const string ct_Col_Sort_GoodsMakerCd = "Sort_GoodsMakerCd";

        // ---ADD 2009/03/27 不具合対応[12783] ----------------------------->>>>>
        /// <summary> ソート用　仕入先コード </summary> 
        public const string ct_Col_Sort_CustomerCode = "Sort_CustomerCode";
        /// <summary> ソート用　商品大分類コード </summary> 
        public const string ct_Col_Sort_LargeGoodsGanreCode = "Sort_LargeGoodsGanreCode";
        /// <summary> ソート用　商品中分類コード </summary> 
        public const string ct_Col_Sort_MediumGoodsGanreCode = "Sort_MediumGoodsGanreCode";
        /// <summary> ソート用　グループコード </summary> 
        public const string ct_Col_Sort_DetailGoodsGanreCode = "Sort_DetailGoodsGanreCode";
        // ---ADD 2009/03/27 不具合対応[12783] -----------------------------<<<<<
		#endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 在庫分析順位表テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫分析順位表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCZAI02145EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ DataSetテーブルスキーマ設定
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
			if ( dt != null )
			{
				// テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
				dt.Clear();
			}
			else
			{
                // スキーマ設定
                dt = new DataTable(ct_Tbl_StockAnalysisOrder);

                # region ＜＜　Columnを追加　＞＞

                dt.Columns.Add(ct_Col_SectionCode, typeof(string));// 拠点コード
                dt.Columns[ct_Col_SectionCode].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_SectionGuideNm, typeof(string));// 拠点ガイド名称
                dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));// 倉庫コード
                dt.Columns[ct_Col_WarehouseCode].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_WarehouseName, typeof(string));// 倉庫名称
                dt.Columns[ct_Col_WarehouseName].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));// 仕入先コード
                dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_CustomerName, typeof(string));// 仕入先名称
                dt.Columns[ct_Col_CustomerName].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_CustomerName2, typeof(string));// 仕入先名称2
                dt.Columns[ct_Col_CustomerName2].DefaultValue = "";

                //dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));// 仕入先略称
                //dt.Columns[ct_Col_CustomerSnm].DefaultValue = "";

                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));// 商品メーカーコード
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_MakerName, typeof(string));// メーカー名称
                dt.Columns[ct_Col_MakerName].DefaultValue = "";

                // --- DEL 2009/02/27 -------------------------------->>>>>
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
                // --- DEL 2009/02/27 --------------------------------<<<<<
                // --- ADD 2009/02/27 -------------------------------->>>>>
                dt.Columns.Add(ct_Col_LargeGoodsGanreCode, typeof(Int32)); // 商品大分類コード
                dt.Columns[ct_Col_LargeGoodsGanreCode].DefaultValue = 0;

                dt.Columns.Add(ct_Col_MediumGoodsGanreCode, typeof(Int32)); // 商品中分類コード
                dt.Columns[ct_Col_MediumGoodsGanreCode].DefaultValue = 0;

                dt.Columns.Add(ct_Col_DetailGoodsGanreCode, typeof(Int32)); // グループコード
                dt.Columns[ct_Col_DetailGoodsGanreCode].DefaultValue = 0;
                // --- ADD 2009/02/27 --------------------------------<<<<<
                
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));// 商品番号
                dt.Columns[ct_Col_GoodsNo].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));// 商品名称
                dt.Columns[ct_Col_GoodsName].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));// 倉庫棚番
                dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_SalesMoneyTaxExcOrder, typeof(Int32));// 売上金額（税抜き）順位
                dt.Columns[ct_Col_SalesMoneyTaxExcOrder].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_SalesMoneyTaxExc, typeof(double));// 売上金額（税抜き）
                dt.Columns[ct_Col_SalesMoneyTaxExc].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_GrossProfitOrder, typeof(Int32));// 粗利金額順位
                dt.Columns[ct_Col_GrossProfitOrder].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_GrossProfit, typeof(double));// 粗利金額
                dt.Columns[ct_Col_GrossProfit].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_ShipmentCntOrder, typeof(Int32));// 出荷数順位
                dt.Columns[ct_Col_ShipmentCntOrder].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_ShipmentCnt, typeof(double));// 出荷数
                dt.Columns[ct_Col_ShipmentCnt].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_StockCreateDate, typeof(string));// 在庫登録日
                dt.Columns[ct_Col_StockCreateDate].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_ShipmentPosCnt, typeof(double));// 出荷可能数
                dt.Columns[ct_Col_ShipmentPosCnt].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_MinimumStockCnt, typeof(double));// 最低在庫数
                dt.Columns[ct_Col_MinimumStockCnt].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_MaximumStockCnt, typeof(double));// 最高在庫数
                dt.Columns[ct_Col_MaximumStockCnt].DefaultValue = 0;


                dt.Columns.Add(ct_Col_Sort_SectionCode, typeof(string));// ソート用　拠点コード
                dt.Columns[ct_Col_Sort_SectionCode].DefaultValue = "";

                dt.Columns.Add(ct_Col_Sort_WarehouseCode, typeof(string));// ソート用　倉庫コード
                dt.Columns[ct_Col_Sort_WarehouseCode].DefaultValue = "";

                dt.Columns.Add(ct_Col_Sort_SalesMoneyTaxExcOrder, typeof(Int32));// ソート用　売上金額（税抜き）順位
                dt.Columns[ct_Col_Sort_SalesMoneyTaxExcOrder].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_Sort_GrossProfitOrder, typeof(Int32));// ソート用　粗利金額順位
                dt.Columns[ct_Col_Sort_GrossProfitOrder].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_Sort_ShipmentCntOrder, typeof(Int32));// ソート用　出荷数順位
                dt.Columns[ct_Col_Sort_ShipmentCntOrder].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_Sort_GoodsNo, typeof(string));// ソート用　商品番号
                dt.Columns[ct_Col_Sort_GoodsNo].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_Sort_GoodsMakerCd, typeof(Int32));// ソート用　商品メーカーコード
                dt.Columns[ct_Col_Sort_GoodsMakerCd].DefaultValue = 0;

                // ---ADD 2009/03/27 不具合対応[12783] ----------------------------->>>>>
                dt.Columns.Add(ct_Col_Sort_CustomerCode, typeof(Int32));            // ソート用　仕入先コード
                dt.Columns[ct_Col_Sort_CustomerCode].DefaultValue = 0;

                dt.Columns.Add(ct_Col_Sort_LargeGoodsGanreCode, typeof(Int32));     // ソート用　商品大分類コード
                dt.Columns[ct_Col_Sort_LargeGoodsGanreCode].DefaultValue = 0;

                dt.Columns.Add(ct_Col_Sort_MediumGoodsGanreCode, typeof(Int32));    // ソート用　商品中分類コード
                dt.Columns[ct_Col_Sort_MediumGoodsGanreCode].DefaultValue = 0;

                dt.Columns.Add(ct_Col_Sort_DetailGoodsGanreCode, typeof(Int32));    // ソート用　グループコード
                dt.Columns[ct_Col_Sort_DetailGoodsGanreCode].DefaultValue = 0;
                // ---ADD 2009/03/27 不具合対応[12783] -----------------------------<<<<<
                # endregion ＜＜　Columnを追加　＞＞
            }
		}
		#endregion
		#endregion
	}
}
