using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 在庫マスタ一覧印刷 テーブルスキーマ情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタ一覧印刷テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2009.01.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class RsltInfo_StockMasterTbl
    {

        /// <summary> テーブル名称 </summary>
        public const string Col_Tbl_Result_StockMaster = "Tbl_Result_StockMaster";

        /// <summary> 拠点コード </summary>
        public const string Col_SectionCode = "SectionCode";

        /// <summary> 倉庫コード </summary>
        public const string Col_WarehouseCode = "WarehouseCode";

        /// <summary> 商品メーカーコード </summary>
        public const string Col_GoodsMakerCd = "GoodsMakerCd";

        /// <summary> 商品番号 </summary>
        public const string Col_GoodsNo = "GoodsNo";

        /// <summary> 仕入単価（税抜,浮動） </summary>
        public const string Col_StockUnitPriceFl = "StockUnitPriceFl";

        /// <summary> 仕入在庫数 </summary>
        public const string Col_SupplierStock = "SupplierStock";

        /// <summary> 受注数 </summary>
        public const string Col_AcpOdrCount = "AcpOdrCount";

        /// <summary> M/O発注数 </summary>
        public const string Col_MonthOrderCount = "MonthOrderCount";

        /// <summary> 発注数 </summary>
        public const string Col_SalesOrderCount = "SalesOrderCount";

        /// <summary> 在庫区分 </summary>
        public const string Col_StockDiv = "StockDiv";

        /// <summary> 移動中仕入在庫数 </summary>
        public const string Col_MovingSupliStock = "MovingSupliStock";

        /// <summary> 出荷可能数 </summary>
        public const string Col_ShipmentPosCnt = "ShipmentPosCnt";

        /// <summary> 在庫保有総額 </summary>
        public const string Col_StockTotalPrice = "StockTotalPrice";

        /// <summary> 最終仕入年月日 </summary>
        public const string Col_LastStockDate = "LastStockDate";

        /// <summary> 最終売上日 </summary>
        public const string Col_LastSalesDate = "LastSalesDate";

        /// <summary> 最終棚卸更新日 </summary>
        public const string Col_LastInventoryUpdate = "LastInventoryUpdate";

        /// <summary> 最低在庫数 </summary>
        public const string Col_MinimumStockCnt = "MinimumStockCnt";

        /// <summary> 最高在庫数 </summary>
        public const string Col_MaximumStockCnt = "MaximumStockCnt";

        /// <summary> 基準発注数 </summary>
        public const string Col_NmlSalOdrCount = "NmlSalOdrCount";

        /// <summary> 発注単位 </summary>
        public const string Col_SalesOrderUnit = "SalesOrderUnit";

        /// <summary> 在庫発注先コード </summary>
        public const string Col_StockSupplierCode = "StockSupplierCode";

        /// <summary> 倉庫棚番 </summary>
        public const string Col_WarehouseShelfNo = "WarehouseShelfNo";

        /// <summary> 重複棚番１ </summary>
        public const string Col_DuplicationShelfNo1 = "DuplicationShelfNo1";

        /// <summary> 重複棚番２ </summary>
        public const string Col_DuplicationShelfNo2 = "DuplicationShelfNo2";

        /// <summary> 部品管理区分１ </summary>
        public const string Col_PartsManagementDivide1 = "PartsManagementDivide1";

        /// <summary> 部品管理区分２ </summary>
        public const string Col_PartsManagementDivide2 = "PartsManagementDivide2";

        /// <summary> 在庫備考１ </summary>
        public const string Col_StockNote1 = "StockNote1";

        /// <summary> 在庫備考２ </summary>
        public const string Col_StockNote2 = "StockNote2";

        /// <summary> 出荷数（未計上） </summary>
        public const string Col_ShipmentCnt = "ShipmentCnt";

        /// <summary> 入荷数（未計上） </summary>
        public const string Col_ArrivalCnt = "ArrivalCnt";

        /// <summary> 在庫登録日 </summary>
        public const string Col_StockCreateDate = "StockCreateDate";

        /// <summary> 更新年月日 </summary>
        public const string Col_UpdateDate = "UpdateDate";

        /// <summary> 拠点ガイド略称 </summary>
        public const string Col_SectionGuideSnm = "SectionGuideSnm";

        /// <summary> 倉庫名称 </summary>
        public const string Col_WarehouseName = "WarehouseName";

        /// <summary> メーカー略称 </summary>
        public const string Col_MakerShortName = "MakerShortName";

        /// <summary> 在庫発注先名称 </summary>
        public const string Col_StockSupplierSnm = "StockSupplierSnm";

        /// <summary> 商品名称 </summary>
        public const string Col_GoodsName = "GoodsName";

        /// <summary> BL商品コード </summary>
        public const string Col_BLGoodsCode = "BLGoodsCode";

        /// <summary> BL商品コード名称（半角） </summary>
        public const string Col_BLGoodsHalfName = "BLGoodsHalfName";

        /// <summary> 商品大分類コード </summary>
        public const string Col_GoodsLGroup = "GoodsLGroup";

        /// <summary> 商品中分類コード </summary>
        public const string Col_GoodsMGroup = "GoodsMGroup";

        /// <summary> BLグループコード </summary>
        public const string Col_BLGroupCode = "BLGroupCode";

        /// <summary> BLグループコードカナ名称 </summary>
        public const string Col_BLGroupKanaName = "BLGroupKanaName";

        /// <summary> 商品大分類名称 </summary>
        public const string Col_GoodsLGroupName = "GoodsLGroupName";

        /// <summary> 商品中分類名称 </summary>
        public const string Col_GoodsMGroupName = "GoodsMGroupName";

        /// <summary> 仕入先コード </summary>
        public const string Col_SupplierCd = "SupplierCd";

        /// <summary> 仕入先略称 </summary>
        public const string Col_SupplierSnm = "SupplierSnm";

        /// <summary> 定価（浮動） </summary>
        public const string Col_ListPrice = "ListPrice";

        /// <summary> 原価単価 </summary>
        public const string Col_SalesUnitCost = "SalesUnitCost";


        /// <summary>
        /// 在庫マスタ一覧印刷テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 在庫マスタ一覧印刷テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        public RsltInfo_StockMasterTbl()
		{
		}

        /// <summary>
		/// DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="ds">設定対象データセット</param>
		/// <remarks>
		/// <br>Note       : データセットのスキーマを設定する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        static public void CreateDataTableResultStockMaster(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Col_Tbl_Result_StockMaster))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Col_Tbl_Result_StockMaster].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(Col_Tbl_Result_StockMaster);

                DataTable dt = ds.Tables[Col_Tbl_Result_StockMaster];

                string defValuestring = "";
                Int32 defValueInt32 = 0;
                Int64 defValueInt64 = 0;
                double defValueDouble = 0.0;

                dt.Columns.Add(Col_SectionCode, typeof(string));                // 拠点コード
                dt.Columns[Col_SectionCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseCode, typeof(string));              // 倉庫コード
                dt.Columns[Col_WarehouseCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsMakerCd, typeof(Int32));                // 商品メーカーコード
                dt.Columns[Col_GoodsMakerCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_GoodsNo, typeof(string));                    // 商品番号
                dt.Columns[Col_GoodsNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_StockUnitPriceFl, typeof(Double));           // 仕入単価（税抜,浮動）
                dt.Columns[Col_StockUnitPriceFl].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_SupplierStock, typeof(Double));              // 仕入在庫数
                dt.Columns[Col_SupplierStock].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_AcpOdrCount, typeof(Double));                // 受注数
                dt.Columns[Col_AcpOdrCount].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_MonthOrderCount, typeof(Double));            // M/O発注数
                dt.Columns[Col_MonthOrderCount].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_SalesOrderCount, typeof(Double));            // 発注数
                dt.Columns[Col_SalesOrderCount].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_StockDiv, typeof(Int32));                    // 在庫区分
                dt.Columns[Col_StockDiv].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MovingSupliStock, typeof(Double));           // 移動中仕入在庫数
                dt.Columns[Col_MovingSupliStock].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_ShipmentPosCnt, typeof(Double));             // 出荷可能数
                dt.Columns[Col_ShipmentPosCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_StockTotalPrice, typeof(Int64));             // 在庫保有総額
                dt.Columns[Col_StockTotalPrice].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_LastStockDate, typeof(Int32));               // 最終仕入年月日
                dt.Columns[Col_LastStockDate].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_LastSalesDate, typeof(Int32));               // 最終売上日
                dt.Columns[Col_LastSalesDate].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_LastInventoryUpdate, typeof(Int32));         // 最終棚卸更新日
                dt.Columns[Col_LastInventoryUpdate].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MinimumStockCnt, typeof(Double));            // 最低在庫数
                dt.Columns[Col_MinimumStockCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_MaximumStockCnt, typeof(Double));            // 最高在庫数
                dt.Columns[Col_MaximumStockCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_NmlSalOdrCount, typeof(Double));             // 基準発注数
                dt.Columns[Col_NmlSalOdrCount].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_SalesOrderUnit, typeof(Int32));              // 発注単位
                dt.Columns[Col_SalesOrderUnit].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_StockSupplierCode, typeof(Int32));           // 在庫発注先コード
                dt.Columns[Col_StockSupplierCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_WarehouseShelfNo, typeof(string));           // 倉庫棚番
                dt.Columns[Col_WarehouseShelfNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_DuplicationShelfNo1, typeof(string));        // 重複棚番１
                dt.Columns[Col_DuplicationShelfNo1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_DuplicationShelfNo2, typeof(string));        // 重複棚番２
                dt.Columns[Col_DuplicationShelfNo2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_PartsManagementDivide1, typeof(string));     // 部品管理区分１
                dt.Columns[Col_PartsManagementDivide1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_PartsManagementDivide2, typeof(string));     // 部品管理区分２
                dt.Columns[Col_PartsManagementDivide2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_StockNote1, typeof(string));                 // 在庫備考１
                dt.Columns[Col_StockNote1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_StockNote2, typeof(string));                 // 在庫備考２
                dt.Columns[Col_StockNote2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_ShipmentCnt, typeof(Double));                // 出荷数（未計上）
                dt.Columns[Col_ShipmentCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_ArrivalCnt, typeof(Double));                 // 入荷数（未計上）
                dt.Columns[Col_ArrivalCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_StockCreateDate, typeof(Int32));             // 在庫登録日
                dt.Columns[Col_StockCreateDate].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UpdateDate, typeof(Int32));                  // 更新年月日
                dt.Columns[Col_UpdateDate].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SectionGuideSnm, typeof(string));            // 拠点ガイド略称
                dt.Columns[Col_SectionGuideSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseName, typeof(string));              // 倉庫名称
                dt.Columns[Col_WarehouseName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MakerShortName, typeof(string));             // メーカー略称
                dt.Columns[Col_MakerShortName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_StockSupplierSnm, typeof(string));           // 在庫発注先名称
                dt.Columns[Col_StockSupplierSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsName, typeof(string));                  // 商品名称
                dt.Columns[Col_GoodsName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BLGoodsCode, typeof(Int32));                 // BL商品コード
                dt.Columns[Col_BLGoodsCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BLGoodsHalfName, typeof(string));            // BL商品コード名称（半角）
                dt.Columns[Col_BLGoodsHalfName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsLGroup, typeof(Int32));                 // 商品大分類コード
                dt.Columns[Col_GoodsLGroup].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_GoodsMGroup, typeof(Int32));                 // 商品中分類コード
                dt.Columns[Col_GoodsMGroup].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BLGroupCode, typeof(Int32));                 // BLグループコード
                dt.Columns[Col_BLGroupCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BLGroupKanaName, typeof(string));            // BLグループコードカナ名称
                dt.Columns[Col_BLGroupKanaName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsLGroupName, typeof(string));            // 商品大分類名称
                dt.Columns[Col_GoodsLGroupName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsMGroupName, typeof(string));            // 商品中分類名称
                dt.Columns[Col_GoodsMGroupName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SupplierCd, typeof(Int32));                  // 仕入先コード
                dt.Columns[Col_SupplierCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SupplierSnm, typeof(string));                // 仕入先略称
                dt.Columns[Col_SupplierSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_ListPrice, typeof(Double));                  // 定価（浮動）
                dt.Columns[Col_ListPrice].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_SalesUnitCost, typeof(Double));              // 原価単価
                dt.Columns[Col_SalesUnitCost].DefaultValue = defValueDouble;

            }
        }
    }
}
