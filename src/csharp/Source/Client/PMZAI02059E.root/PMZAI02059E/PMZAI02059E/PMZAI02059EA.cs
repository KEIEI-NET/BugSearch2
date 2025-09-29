using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 在庫看板印刷 リモート抽出結果クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫看板印刷のリモート抽出結果を保持する。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.12.12</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMZAI02059EA
    {
        #region ■ Public定数
        // テーブル名称
        public const string ct_Tbl_StockSignResult = "ct_Tbl_StockSignResult";
        // 企業コード
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        // 倉庫コード
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        // 倉庫棚番
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        // 商品番号
        public const string ct_Col_GoodsNo = "GoodsNo";
        // 商品名称カナ
        public const string ct_Col_GoodsNameKana = "GoodsNameKana";
        // 最低在庫数
        public const string ct_Col_MinimumStockCnt = "MinimumStockCnt";
        // 最高在庫数
        public const string ct_Col_MaximumStockCnt = "MaximumStockCnt";
        // 在庫登録日
        public const string ct_Col_StockCreateDate = "StockCreateDate";
        // 価格開始日
        public const string ct_Col_PriceStartDate = "PriceStartDate";
        // 定価（浮動）
        public const string ct_Col_ListPrice = "ListPrice";
        // 商品メーカーコード
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        // 拠点コード
        public const string ct_Col_SectionCode = "SectionCode";
        // 仕入在庫数
        public const string ct_Col_SupplierStock = "SupplierStock";

        #endregion

        #region ■ コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public PMZAI02059EA()
        {
        }

        #endregion

        #region ■ publicメソッド
        /// <summary>
        /// 在庫看板印刷DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="dt">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 在庫看板印刷データセットのスキーマを設定する。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.12.12</br>
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
                dt = new DataTable(ct_Tbl_StockSignResult);

                // 企業コード
                dt.Columns.Add(ct_Col_EnterpriseCode, typeof(string));
                dt.Columns[ct_Col_EnterpriseCode].DefaultValue = string.Empty;

                // 倉庫コード
                dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));
                dt.Columns[ct_Col_WarehouseCode].DefaultValue = string.Empty;

                // 倉庫棚番
                dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = string.Empty;

                // 商品番号
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = string.Empty;

                // 商品名称カナ
                dt.Columns.Add(ct_Col_GoodsNameKana, typeof(string));
                dt.Columns[ct_Col_GoodsNameKana].DefaultValue = string.Empty;

                // 最低在庫数
                dt.Columns.Add(ct_Col_MinimumStockCnt, typeof(double));
                dt.Columns[ct_Col_MinimumStockCnt].DefaultValue = 0;

                // 最高在庫数
                dt.Columns.Add(ct_Col_MaximumStockCnt, typeof(double));
                dt.Columns[ct_Col_MaximumStockCnt].DefaultValue = 0;

                // 在庫登録日
                dt.Columns.Add(ct_Col_StockCreateDate, typeof(DateTime));
                dt.Columns[ct_Col_StockCreateDate].DefaultValue = DateTime.MinValue;

                // 価格開始日
                dt.Columns.Add(ct_Col_PriceStartDate, typeof(DateTime));
                dt.Columns[ct_Col_PriceStartDate].DefaultValue = DateTime.MinValue;

                // 定価（浮動）
                dt.Columns.Add(ct_Col_ListPrice, typeof(double));
                dt.Columns[ct_Col_ListPrice].DefaultValue = 0;

                // 商品メーカーコード
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = 0;

                // 拠点コード
                dt.Columns.Add(ct_Col_SectionCode, typeof(string));
                dt.Columns[ct_Col_SectionCode].DefaultValue = string.Empty;

                // 仕入在庫数
                dt.Columns.Add(ct_Col_SupplierStock, typeof(double));
                dt.Columns[ct_Col_SupplierStock].DefaultValue = 0;
            }
        }
        #endregion
    }
}
