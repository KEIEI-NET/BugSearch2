//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 過剰在庫一覧表
// プログラム概要   : 過剰在庫一覧表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 疋田 勇人
// 作 成 日  2007/11/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/23  修正内容 : 不具合対応[12778]
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 在庫過剰一覧表テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 在庫過剰一覧表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 20081 疋田 勇人</br>
	/// <br>Date       : 2007.11.13</br>
    /// <br>Update Note: 2009/04/23 照田 貴志　不具合対応[12778]</br>
    /// <br>           : </br>
	/// </remarks>
	public class DCZAI02184EA
	{
		#region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_StockOver = "Tbl_StockOver";

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
        /// <summary> 商品メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー名称 </summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary> 倉庫棚番 </summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary> 商品番号 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 商品名称 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> 最低在庫数 </summary>
        public const string ct_Col_MinimumStockCnt = "MinimumStockCnt";
        /// <summary> 最高在庫数 </summary>
        public const string ct_Col_MaximumStockCnt = "MaximumStockCnt";
        /// <summary> 出荷可能数 </summary>
        public const string ct_Col_ShipmentPosCnt = "ShipmentPosCnt";
        /// <summary> 出荷数 </summary>
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";
        /// <summary> 発注数 </summary>
        public const string ct_Col_SalesOrderCount = "SalesOrderCount";
        /// <summary> 過剰数 </summary>
        public const string ct_Col_StockOverCount = "StockOverCount";
        /// <summary> 在庫金額 </summary>
        public const string ct_Col_StockPrice = "StockPrice";
        /// <summary> 最終仕入年月日 </summary>
        public const string ct_Col_LastStockDate = "LastStockDate";
     
        //--- ADD 2008/07/15 ---------->>>>>
        /// <summary>BLコード</summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary>部品管理区分１</summary>
        public const string ct_Col_PartsManagementDivide1 = "PartsManagementDivide1";
        /// <summary>部品管理区分２</summary>
        public const string ct_Col_PartsManagementDivide2 = "PartsManagementDivide2";
        //--- ADD 2008/07/15 ---------->>>>>

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
        // ---ADD 2009/04/23 不具合対応[12778] -------------------------------------------->>>>>
        /// <summary> ソート用　BLコード </summary>
        public const string ct_Col_Sort_BLGoodsCode = "Sort_BLGoodsCode";
        // ---ADD 2009/04/23 不具合対応[12778] --------------------------------------------<<<<<
		#endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 在庫過剰一覧表テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫過剰一覧表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.13</br>
		/// </remarks>
		public DCZAI02184EA()
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
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.13</br>
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
                dt = new DataTable(ct_Tbl_StockOver);

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

                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32)); // 商品メーカーコード
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_MakerName, typeof(string)); // メーカー名称
                dt.Columns[ct_Col_MakerName].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string)); // 倉庫棚番
                dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string)); // 商品番号
                dt.Columns[ct_Col_GoodsNo].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_GoodsName, typeof(string)); // 商品名称
                dt.Columns[ct_Col_GoodsName].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_MinimumStockCnt, typeof(Double)); // 最低在庫数
                dt.Columns[ct_Col_MinimumStockCnt].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_MaximumStockCnt, typeof(Double)); // 最高在庫数
                dt.Columns[ct_Col_MaximumStockCnt].DefaultValue = 0;

                dt.Columns.Add(ct_Col_ShipmentPosCnt, typeof(Double)); // 出荷可能数
                dt.Columns[ct_Col_ShipmentPosCnt].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_ShipmentCnt, typeof(Double)); // 出荷数
                dt.Columns[ct_Col_ShipmentCnt].DefaultValue = 0;

                dt.Columns.Add(ct_Col_SalesOrderCount, typeof(Double)); // 発注数
                dt.Columns[ct_Col_SalesOrderCount].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_StockOverCount, typeof(Double)); // 過剰数
                dt.Columns[ct_Col_StockOverCount].DefaultValue = 0;

                dt.Columns.Add(ct_Col_StockPrice, typeof(Int64));    // 在庫金額
                dt.Columns[ct_Col_StockPrice].DefaultValue = 0;
                
                dt.Columns.Add(ct_Col_LastStockDate, typeof(string)); // 最終仕入年月日
                dt.Columns[ct_Col_LastStockDate].DefaultValue = 0;

                dt.Columns.Add(ct_Col_WarehouseShelfNoBreak, typeof(string)); // 倉庫棚番ブレイク
                dt.Columns[ct_Col_WarehouseShelfNoBreak].DefaultValue = "";

                //--- ADD 2008/07/15 ---------->>>>>
                dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));      // BLコード
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = 0;

                dt.Columns.Add(ct_Col_PartsManagementDivide1, typeof(string)); // 部品管理区分１
                dt.Columns[ct_Col_PartsManagementDivide1].DefaultValue = "";

                dt.Columns.Add(ct_Col_PartsManagementDivide2, typeof(string)); // 部品管理区分２
                dt.Columns[ct_Col_PartsManagementDivide2].DefaultValue = "";
                //--- ADD 2008/07/15 ---------->>>>>
                
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

                // ---ADD 2009/04/23 不具合対応[12778] ------------------------------------------------>>>>>
                dt.Columns.Add(ct_Col_Sort_BLGoodsCode, typeof(Int32)); // ソート用　BLコード
                dt.Columns[ct_Col_Sort_BLGoodsCode].DefaultValue = 0;
                // ---ADD 2009/04/23 不具合対応[12778] ------------------------------------------------<<<<<
            }
		}
		#endregion
		#endregion
	}
}
