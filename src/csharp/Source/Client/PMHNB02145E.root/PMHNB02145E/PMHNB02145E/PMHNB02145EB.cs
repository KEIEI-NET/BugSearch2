using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 出荷商品優良対応表 帳票印字用データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出荷商品優良対応表の帳票印字用の１行データを保持する。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.11.14</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMHNB02145EB
    {
        #region ■ Public定数
        // --共通--
        // テーブル名称
        public const string ct_Tbl_ShipGdsPrimeListResultForPrint = "ShipGdsPrimeListResultForPrint";
        // 拠点コード
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        // 拠点名称
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";

        // --制御用--
        // 1行に含まれる優良品数
        public const string ct_Col_PartsCount = "PartsCount";
        // 同明細の何行目か
        public const string ct_Col_RowNumber = "RowNumber";
        
        // --計印字用--
        // 1純正品の売上数計(在庫)合計
        public const string ct_Col_Pure_StockTotalSalesCountSum = "Pure_StockTotalSalesCountSum";
        // 1純正品の売上数計(取寄)合計
        public const string ct_Col_Pure_OrderTotalSalesCountSum = "Pure_OrderTotalSalesCountSum";
        // 1行の優良品売上数計(在庫)合計
        public const string ct_Col_Parts_StockTotalSalesCountSum = "Parts_StockTotalSalesCountSum";
        // 1行の優良品売上数計(取寄)合計
        public const string ct_Col_Parts_OrderTotalSalesCountSum = "Parts_OrderTotalSalesCountSum";

        // --純正品関連--
        // 棚番
        public const string ct_Col_Pure_WarehouseShelfNo = "Pure_WarehouseShelfNo";
        // 純正メーカーコード
        public const string ct_Col_Pure_MakerCode = "Pure_MakerCode";
        // 純正メーカー名称
        public const string ct_Col_Pure_GoodsMakerName = "Pure_GoodsMakerName";
        // 商品中分類コード
        public const string ct_Col_Pure_GoodsMGroup = "Pure_GoodsMGroup";
        // 商品中分類名称
        public const string ct_Col_Pure_GoodsMGroupName = "Pure_GoodsMGroupName";
        // グループコード
        public const string ct_Col_Pure_BLGroupCode = "Pure_BLGroupCode";
        // グループコード名称
        public const string ct_Col_Pure_BLGroupCodeName = "Pure_BLGroupCodeName";
        // 純正品番
        public const string ct_Col_Pure_GoodsNo = "Pure_GoodsNo";
        // 品名
        public const string ct_Col_Pure_GoodsName = "Pure_GoodsName";
        // 粗利率
        public const string ct_Col_Pure_GrossProfitRate = "Pure_GrossProfitRate";
        // 価格
        public const string ct_Col_Pure_GoodsPrice = "Pure_GoodsPrice";
        // 現在庫（仕入在庫数）
        public const string ct_Col_Pure_SupplierStock = "Pure_SupplierStock";
        // 売上数計(在庫)
        public const string ct_Col_Pure_StockTotalSalesCount = "Pure_StockTotalSalesCount";
        // 売上数計(取寄)
        public const string ct_Col_Pure_OrderTotalSalesCount = "Pure_OrderTotalSalesCount";

        // --優良品番1関連--
        // 棚番1
        public const string ct_Col_Parts1_WarehouseShelfNo = "Parts1_WarehouseShelfNo";
        // グループコード1
        public const string ct_Col_Parts1_BLGroupCode = "Parts1_BLGroupCode";
        // 参考品番1
        public const string ct_Col_Parts1_GoodsNo = "Parts1_GoodsNo";
        // 仕入先1
        public const string ct_Col_Parts1_SuplierCode = "Parts1_SuplierCode";
        // メーカー1
        public const string ct_Col_Parts1_MakerCode = "Parts1_MakerCode";
        // 価格1
        public const string ct_Col_Parts1_GoodsPrice = "Parts1_GoodsPrice";
        // 粗利率1
        public const string ct_Col_Parts1_GrossProfitRate = "Parts1_GrossProfitRate";
        // 現在庫1（仕入在庫数）
        public const string ct_Col_Parts1_SupplierStock = "Parts1_SupplierStock";
        // 売上数計1（在庫）
        public const string ct_Col_Parts1_StockTotalSalesCount = "Parts1_StockTotalSalesCount";
        // 売上数計1（取寄）
        public const string ct_Col_Parts1_OrderTotalSalesCount = "Parts1_OrderTotalSalesCount";

        // --優良品番2関連--
        // 棚番2
        public const string ct_Col_Parts2_WarehouseShelfNo = "Parts2_WarehouseShelfNo";
        // グループコード2
        public const string ct_Col_Parts2_BLGroupCode = "Parts2_BLGroupCode";
        // 参考品番2
        public const string ct_Col_Parts2_GoodsNo = "Parts2_GoodsNo";
        // 仕入先2
        public const string ct_Col_Parts2_SuplierCode = "Parts2_SuplierCode";
        // メーカー2
        public const string ct_Col_Parts2_MakerCode = "Parts2_MakerCode";
        // 価格2
        public const string ct_Col_Parts2_GoodsPrice = "Parts2_GoodsPrice";
        // 粗利率2
        public const string ct_Col_Parts2_GrossProfitRate = "Parts2_GrossProfitRate";
        // 現在庫2（仕入在庫数）
        public const string ct_Col_Parts2_SupplierStock = "Parts2_SupplierStock";
        // 売上数計2（在庫）
        public const string ct_Col_Parts2_StockTotalSalesCount = "Parts2_StockTotalSalesCount";
        // 売上数計2（取寄）
        public const string ct_Col_Parts2_OrderTotalSalesCount = "Parts2_OrderTotalSalesCount";
        
        #endregion

        #region ■ コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public PMHNB02145EB()
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
                dt = new DataTable(ct_Tbl_ShipGdsPrimeListResultForPrint);

                // --共通--
                // 拠点コード
                dt.Columns.Add(ct_Col_AddUpSecCode, typeof(string));
                dt.Columns[ct_Col_AddUpSecCode].DefaultValue = string.Empty;

                // 拠点名称
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = string.Empty;

                // --制御用--
                // 1行に含まれる優良品数
                dt.Columns.Add(ct_Col_PartsCount, typeof(Int32));
                dt.Columns[ct_Col_PartsCount].DefaultValue = 0;

                // // 同明細の何行目か
                dt.Columns.Add(ct_Col_RowNumber, typeof(Int32));
                dt.Columns[ct_Col_RowNumber].DefaultValue = 0;

                // --計印字用--
                // 1純正品の売上数計(在庫)合計
                dt.Columns.Add(ct_Col_Pure_StockTotalSalesCountSum, typeof(double));
                dt.Columns[ct_Col_Pure_StockTotalSalesCountSum].DefaultValue = 0;

                // 1純正品の売上数計(取寄)合計
                dt.Columns.Add(ct_Col_Pure_OrderTotalSalesCountSum, typeof(double));
                dt.Columns[ct_Col_Pure_OrderTotalSalesCountSum].DefaultValue = 0;

                // 1行の優良品売上数計(在庫)合計
                dt.Columns.Add(ct_Col_Parts_StockTotalSalesCountSum, typeof(double));
                dt.Columns[ct_Col_Parts_StockTotalSalesCountSum].DefaultValue = 0;

                // 1行の優良品売上数計(取寄)合計
                dt.Columns.Add(ct_Col_Parts_OrderTotalSalesCountSum, typeof(double));
                dt.Columns[ct_Col_Parts_OrderTotalSalesCountSum].DefaultValue = 0;

                // --純正品関連--
                // 棚番
                dt.Columns.Add(ct_Col_Pure_WarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_Pure_WarehouseShelfNo].DefaultValue = string.Empty;

                // 純正メーカーコード
                dt.Columns.Add(ct_Col_Pure_MakerCode, typeof(Int32));
                dt.Columns[ct_Col_Pure_MakerCode].DefaultValue = 0;

                // 純正メーカー名称
                dt.Columns.Add(ct_Col_Pure_GoodsMakerName, typeof(string));
                dt.Columns[ct_Col_Pure_GoodsMakerName].DefaultValue = string.Empty;

                // 商品中分類コード
                dt.Columns.Add(ct_Col_Pure_GoodsMGroup, typeof(Int32));
                dt.Columns[ct_Col_Pure_GoodsMGroup].DefaultValue = 0;

                // 商品中分類名称
                dt.Columns.Add(ct_Col_Pure_GoodsMGroupName, typeof(string));
                dt.Columns[ct_Col_Pure_GoodsMGroupName].DefaultValue = string.Empty;

                // グループコード
                dt.Columns.Add(ct_Col_Pure_BLGroupCode, typeof(Int32));
                dt.Columns[ct_Col_Pure_BLGroupCode].DefaultValue = 0;

                // グループコード名称
                dt.Columns.Add(ct_Col_Pure_BLGroupCodeName, typeof(string));
                dt.Columns[ct_Col_Pure_BLGroupCodeName].DefaultValue = string.Empty;

                // 純正品番
                dt.Columns.Add(ct_Col_Pure_GoodsNo, typeof(string));
                dt.Columns[ct_Col_Pure_GoodsNo].DefaultValue = string.Empty;

                // 品名
                dt.Columns.Add(ct_Col_Pure_GoodsName, typeof(string));
                dt.Columns[ct_Col_Pure_GoodsName].DefaultValue = string.Empty;

                // 粗利率
                dt.Columns.Add(ct_Col_Pure_GrossProfitRate, typeof(double));
                dt.Columns[ct_Col_Pure_GrossProfitRate].DefaultValue = 0;

                // 価格
                dt.Columns.Add(ct_Col_Pure_GoodsPrice, typeof(double));
                dt.Columns[ct_Col_Pure_GoodsPrice].DefaultValue = 0;

                // 現在庫（仕入在庫数）
                dt.Columns.Add(ct_Col_Pure_SupplierStock, typeof(double));
                dt.Columns[ct_Col_Pure_SupplierStock].DefaultValue = 0;

                // 売上数計(在庫)
                dt.Columns.Add(ct_Col_Pure_StockTotalSalesCount, typeof(double));
                dt.Columns[ct_Col_Pure_StockTotalSalesCount].DefaultValue = 0;

                // 売上数計(取寄)
                dt.Columns.Add(ct_Col_Pure_OrderTotalSalesCount, typeof(double));
                dt.Columns[ct_Col_Pure_OrderTotalSalesCount].DefaultValue = 0;

                // --優良品番1関連--
                // 棚番1
                dt.Columns.Add(ct_Col_Parts1_WarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_Parts1_WarehouseShelfNo].DefaultValue = string.Empty;
                
                // グループコード1
                dt.Columns.Add(ct_Col_Parts1_BLGroupCode, typeof(Int32));
                dt.Columns[ct_Col_Parts1_BLGroupCode].DefaultValue = 0;

                // 参考品番1
                dt.Columns.Add(ct_Col_Parts1_GoodsNo, typeof(string));
                dt.Columns[ct_Col_Parts1_GoodsNo].DefaultValue = string.Empty;

                // 仕入先1
                dt.Columns.Add(ct_Col_Parts1_SuplierCode, typeof(Int32));
                dt.Columns[ct_Col_Parts1_SuplierCode].DefaultValue = 0;

                // メーカー1
                dt.Columns.Add(ct_Col_Parts1_MakerCode, typeof(Int32));
                dt.Columns[ct_Col_Parts1_MakerCode].DefaultValue = 0;

                // 価格1
                dt.Columns.Add(ct_Col_Parts1_GoodsPrice, typeof(double));
                dt.Columns[ct_Col_Parts1_GoodsPrice].DefaultValue = 0;

                // 粗利率1
                dt.Columns.Add(ct_Col_Parts1_GrossProfitRate, typeof(double));
                dt.Columns[ct_Col_Parts1_GrossProfitRate].DefaultValue = 0;

                // 現在庫1（仕入在庫数）
                dt.Columns.Add(ct_Col_Parts1_SupplierStock, typeof(double));
                dt.Columns[ct_Col_Parts1_SupplierStock].DefaultValue = 0;

                // 売上数計1（在庫）
                dt.Columns.Add(ct_Col_Parts1_StockTotalSalesCount, typeof(double));
                dt.Columns[ct_Col_Parts1_StockTotalSalesCount].DefaultValue = 0;

                // 売上数計1（取寄）
                dt.Columns.Add(ct_Col_Parts1_OrderTotalSalesCount, typeof(double));
                dt.Columns[ct_Col_Parts1_OrderTotalSalesCount].DefaultValue = 0;

                // --優良品番2関連--
                // 棚番2
                dt.Columns.Add(ct_Col_Parts2_WarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_Parts2_WarehouseShelfNo].DefaultValue = string.Empty;

                // グループコード2
                dt.Columns.Add(ct_Col_Parts2_BLGroupCode, typeof(Int32));
                dt.Columns[ct_Col_Parts2_BLGroupCode].DefaultValue = 0;

                // 参考品番2
                dt.Columns.Add(ct_Col_Parts2_GoodsNo, typeof(string));
                dt.Columns[ct_Col_Parts2_GoodsNo].DefaultValue = string.Empty;

                // 仕入先2
                dt.Columns.Add(ct_Col_Parts2_SuplierCode, typeof(Int32));
                dt.Columns[ct_Col_Parts2_SuplierCode].DefaultValue = 0;

                // メーカー2
                dt.Columns.Add(ct_Col_Parts2_MakerCode, typeof(Int32));
                dt.Columns[ct_Col_Parts2_MakerCode].DefaultValue = 0;

                // 価格2
                dt.Columns.Add(ct_Col_Parts2_GoodsPrice, typeof(double));
                dt.Columns[ct_Col_Parts2_GoodsPrice].DefaultValue = 0;

                // 粗利率2
                dt.Columns.Add(ct_Col_Parts2_GrossProfitRate, typeof(double));
                dt.Columns[ct_Col_Parts2_GrossProfitRate].DefaultValue = 0;

                // 現在庫2（仕入在庫数）
                dt.Columns.Add(ct_Col_Parts2_SupplierStock, typeof(double));
                dt.Columns[ct_Col_Parts2_SupplierStock].DefaultValue = 0;

                // 売上数計2（在庫）
                dt.Columns.Add(ct_Col_Parts2_StockTotalSalesCount, typeof(double));
                dt.Columns[ct_Col_Parts2_StockTotalSalesCount].DefaultValue = 0;

                // 売上数計2（取寄）
                dt.Columns.Add(ct_Col_Parts2_OrderTotalSalesCount, typeof(double));
                dt.Columns[ct_Col_Parts2_OrderTotalSalesCount].DefaultValue = 0;
            }
        }
        #endregion
    }
}
