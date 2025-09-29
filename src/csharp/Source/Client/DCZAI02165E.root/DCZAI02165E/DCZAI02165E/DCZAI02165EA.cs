using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 在庫未出荷一覧表テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 在庫未出荷一覧表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 22018 鈴木 正臣</br>
	/// <br>Date       : 2007.09.19</br>
	/// <br></br>
    /// <br>Update Note: 2009/03/18       照田 貴志　不具合対応[12544]</br>
    /// <br>           : </br>
	/// </remarks>
	public class DCZAI02165EA
	{
		#region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_StockNoShipment = "Tbl_StockNoShipment";

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
        ///// <summary> 仕入先略称 </summary>
        //public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> 商品メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー名称 </summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary> 倉庫棚番 </summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary> ＢＬ商品コード </summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary> ＢＬ商品コード名称(全角) </summary>
        public const string ct_Col_BLGoodsFullName = "BLGoodsFullName";
        /// <summary> 商品番号 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 商品名称 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> 最低在庫数 </summary>
        public const string ct_Col_MinimumStockCnt = "MinimumStockCnt";
        /// <summary> 最高在庫数 </summary>
        public const string ct_Col_MaximumStockCnt = "MaximumStockCnt";
        /// <summary> 在庫総数 </summary>
        public const string ct_Col_StockTotal = "StockTotal";
        /// <summary> 出荷数 </summary>
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";
        /// <summary> マシン在庫額 </summary>
        public const string ct_Col_StockMashinePrice = "StockMashinePrice";
        /// <summary> 在庫登録日 </summary>
        public const string ct_Col_StockCreateDate = "StockCreateDate";
        /// <summary> 最終売上日 </summary>
        public const string ct_Col_LastSalesDate = "LastSalesDate";
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
        // ---ADD 2009/03/18 不具合対応[12544] ---------------------------------->>>>>
        /// <summary> ソート用　BLコード </summary>
        public const string ct_Col_Sort_BLGoodsCode = "Sort_BLGoodsCode";
        // ---ADD 2009/03/18 不具合対応[12544] ----------------------------------<<<<<

        //--- ADD 2008.07.22 ---------->>>>>
        /// <summary> 部品管理区分１ </summary>
        public const string ct_Col_PartsManagementDivide1 = "PartsManagementDivide1";
        /// <summary> 部品管理区分２ </summary>
        public const string ct_Col_PartsManagementDivide2 = "PartsManagementDivide2";
        //--- ADD 2008.07.22 ----------<<<<<
        
		#endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 在庫未出荷一覧表テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫未出荷一覧表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCZAI02165EA()
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
                dt = new DataTable(ct_Tbl_StockNoShipment);

                dt.Columns.Add(ct_Col_SectionCode, typeof(string)); // 拠点コード
                dt.Columns[ct_Col_SectionCode].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_SectionGuideNm, typeof(string)); // 拠点ガイド名称
                dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_WarehouseCode, typeof(string)); // 倉庫コード
                dt.Columns[ct_Col_WarehouseCode].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_WarehouseName, typeof(string)); // 倉庫名称
                dt.Columns[ct_Col_WarehouseName].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32)); // 仕入先コード
                dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_CustomerName, typeof(string)); // 仕入先名称
                dt.Columns[ct_Col_CustomerName].DefaultValue = "";

                //dt.Columns.Add(ct_Col_CustomerSnm, typeof(string)); // 仕入先略称
                //dt.Columns[ct_Col_CustomerSnm].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32)); // 商品メーカーコード
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_MakerName, typeof(string)); // メーカー名称
                dt.Columns[ct_Col_MakerName].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string)); // 倉庫棚番
                dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32)); // ＢＬ商品コード
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_BLGoodsFullName, typeof(string)); // ＢＬ商品コード名称(全角)
                dt.Columns[ct_Col_BLGoodsFullName].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string)); // 商品番号
                dt.Columns[ct_Col_GoodsNo].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_GoodsName, typeof(string)); // 商品名称
                dt.Columns[ct_Col_GoodsName].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_MinimumStockCnt, typeof(Double)); // 最低在庫数
                dt.Columns[ct_Col_MinimumStockCnt].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_MaximumStockCnt, typeof(Double)); // 最高在庫数
                dt.Columns[ct_Col_MaximumStockCnt].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_StockTotal, typeof(Double)); // 在庫総数
                dt.Columns[ct_Col_StockTotal].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_ShipmentCnt, typeof(Double)); // 出荷数
                dt.Columns[ct_Col_ShipmentCnt].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_StockMashinePrice, typeof(Int64)); // マシン在庫額
                dt.Columns[ct_Col_StockMashinePrice].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_StockCreateDate, typeof(string)); // 在庫登録日
                dt.Columns[ct_Col_StockCreateDate].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_LastSalesDate, typeof(string)); // 最終売上日
                dt.Columns[ct_Col_LastSalesDate].DefaultValue = 0;

                dt.Columns.Add(ct_Col_WarehouseShelfNoBreak, typeof(string)); // 倉庫棚番ブレイク
                dt.Columns[ct_Col_WarehouseShelfNoBreak].DefaultValue = "";

                
                dt.Columns.Add(ct_Col_Sort_SectionCode, typeof(string)); // ソート用　拠点コード
                dt.Columns[ct_Col_Sort_SectionCode].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_Sort_WarehouseCode, typeof(string)); // ソート用　倉庫コード
                dt.Columns[ct_Col_Sort_WarehouseCode].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_Sort_CustomerCode, typeof(Int32)); // ソート用　仕入先コード
                dt.Columns[ct_Col_Sort_CustomerCode].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_Sort_GoodsMakerCd, typeof(Int32)); // ソート用　商品メーカーコード
                dt.Columns[ct_Col_Sort_GoodsMakerCd].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_Sort_GoodsNo, typeof(string)); // ソート用　商品番号
                dt.Columns[ct_Col_Sort_GoodsNo].DefaultValue = "";

                dt.Columns.Add(ct_Col_Sort_WarehouseShelfNo, typeof(string)); // ソート用　倉庫棚番
                dt.Columns[ct_Col_Sort_WarehouseShelfNo].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_Sort_WarehouseShelfNoBreak, typeof(string)); // ソート用　倉庫棚番ブレイク
                dt.Columns[ct_Col_Sort_WarehouseShelfNoBreak].DefaultValue = "";

                //--- ADD 2008.07.22 ---------->>>>>
                dt.Columns.Add(ct_Col_PartsManagementDivide1, typeof(string)); // 部品管理区分１
                dt.Columns[ct_Col_PartsManagementDivide1].DefaultValue = "";

                dt.Columns.Add(ct_Col_PartsManagementDivide2, typeof(string)); // 部品管理区分２
                dt.Columns[ct_Col_PartsManagementDivide2].DefaultValue = "";
                //--- ADD 2008.07.22 ----------<<<<<

                // ---ADD 2009/03/18 不具合対応[12544] ---------------------------------->>>>>
                dt.Columns.Add(ct_Col_Sort_BLGoodsCode, typeof(Int32)); // ソート用　ＢＬ商品コード
                dt.Columns[ct_Col_Sort_BLGoodsCode].DefaultValue = 0;
                // ---ADD 2009/03/18 不具合対応[12544] ----------------------------------<<<<<
            }
		}
		#endregion
		#endregion
	}
}
