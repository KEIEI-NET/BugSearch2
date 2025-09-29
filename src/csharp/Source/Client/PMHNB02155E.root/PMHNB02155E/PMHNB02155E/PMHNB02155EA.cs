using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 出荷商品優良対応表2 データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出荷商品優良対応表2のリモート抽出結果を保持する。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.11.25</br>
    /// <br>           : </br>
    /// <br>Update Note  : 2014/12/30 尹晶晶</br>
    /// <br>管理番号     : 11070263-00</br>
    /// <br>             :・明治産業様Seiken品番変更</br>
    /// <br>Update Note  : 2015/04/10 時シン</br>
    /// <br>管理番号     : 11070263-00</br>
    /// <br>             :「出力区分」が有効になっている対応</br>
    /// </remarks>
    public class PMHNB02155EA
    {
        #region ■ Public定数
        // テーブル名称
        public const string ct_Tbl_ShipGdsPrimeListResult = "ShipGdsPrimeListResult";
        // 企業コード
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        // 計上拠点コード
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        // 拠点ガイド略称
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";
        // メーカーコード
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        // メーカー名称
        public const string ct_Col_GoodsMakerName = "GoodsMakerName";
        // 品番
        public const string ct_Col_GoodsNo = "GoodsNo";
        //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
        //対応商品番号
        public const string ct_Col_OldGoodsNo = "OldGoodsNo";
        //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
        //------ ADD START 2015/04/10 時シン FOR Redmine#44209 「出力区分」が有効になっている対応 ------>>>>>
        //在庫/取寄のフラグ
        public const string ct_Col_StockYNFlag = "StockYNFlag";
        //------ ADD END   2015/04/10 時シン FOR Redmine#44209 「出力区分」が有効になっている対応 ------<<<<<
        // 売上回数（在庫）
        public const string ct_Col_St_SalesTimes = "St_SalesTimes";
        // 売上数計（在庫）
        public const string ct_Col_St_TotalSalesCount = "St_TotalSalesCount";
        // 売上金額（在庫）
        public const string ct_Col_St_SalesMoney = "St_SalesMoney";
        // 返品額（在庫）
        public const string ct_Col_St_SalesRetGoodsPrice = "St_SalesRetGoodsPrice";
        // 値引金額（在庫）
        public const string ct_Col_St_DiscountPrice = "St_DiscountPrice";
        // 粗利金額（在庫）
        public const string ct_Col_St_GrossProfit = "St_GrossProfit";
        // 売上回数（取寄）
        public const string ct_Col_Or_SalesTimes = "Or_SalesTimes";
        // 売上数計（取寄）
        public const string ct_Col_Or_TotalSalesCount = "Or_TotalSalesCount";
        // 売上金額（取寄）
        public const string ct_Col_Or_SalesMoney = "Or_SalesMoney";
        // 返品額（取寄）
        public const string ct_Col_Or_SalesRetGoodsPrice = "Or_SalesRetGoodsPrice";
        // 値引金額（取寄）
        public const string ct_Col_Or_DiscountPrice = "Or_DiscountPrice";
        // 粗利金額（取寄）
        public const string ct_Col_Or_GrossProfit = "Or_GrossProfit";

        // 商品大分類
        public const string ct_Col_GoodsLGroup = "GoodsLGroup";
        // 商品中分類
        public const string ct_Col_GoodsMGroup = "GoodsMGroup";
        // BLグループコード
        public const string ct_Col_BLGroupCode = "BLGroupCode";
        // 品名
        public const string ct_Col_GoodsName = "GoodsName";
        // 棚番
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";

        // 結合品数
        public const string ct_Col_PartsCount = "PartsCount";
        // 結合品 商品情報リスト
        public const string ct_Col_GoodsUnitDataList = "GoodsUnitDataList";
        // 結合品 月次集計情報リスト
        public const string ct_Col_ShipGdsPrimeListResultList = "ShipGdsPrimeListResultList";
        #endregion

        #region ■ コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public PMHNB02155EA()
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
                dt = new DataTable(ct_Tbl_ShipGdsPrimeListResult);

                // 企業コード
                dt.Columns.Add(ct_Col_EnterpriseCode, typeof(string));
                dt.Columns[ct_Col_EnterpriseCode].DefaultValue = string.Empty;

                // 計上拠点コード
                dt.Columns.Add(ct_Col_AddUpSecCode, typeof(string));
                dt.Columns[ct_Col_AddUpSecCode].DefaultValue = string.Empty;

                // 拠点ガイド略称
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = string.Empty;

                // 商品メーカーコード
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = 0;

                // メーカー名称
                dt.Columns.Add(ct_Col_GoodsMakerName, typeof(string));
                dt.Columns[ct_Col_GoodsMakerName].DefaultValue = string.Empty;

                // 商品番号
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = string.Empty;

                //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                //対応商品番号
                dt.Columns.Add(ct_Col_OldGoodsNo, typeof(string));
                dt.Columns[ct_Col_OldGoodsNo].DefaultValue = string.Empty;
                //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

                //------ ADD START 2015/04/10 時シン FOR Redmine#44209 「出力区分」が有効になっている対応 ------>>>>>
                //在庫/取寄のフラグ
                dt.Columns.Add(ct_Col_StockYNFlag, typeof(bool));
                dt.Columns[ct_Col_StockYNFlag].DefaultValue = false;
                //------ ADD END   2015/04/10 時シン FOR Redmine#44209 「出力区分」が有効になっている対応 ------<<<<<

                // 売上回数（在庫）
                dt.Columns.Add(ct_Col_St_SalesTimes, typeof(Int32));
                dt.Columns[ct_Col_St_SalesTimes].DefaultValue = 0;

                // 売上数計（在庫）
                dt.Columns.Add(ct_Col_St_TotalSalesCount, typeof(double));
                dt.Columns[ct_Col_St_TotalSalesCount].DefaultValue = 0;

                // 売上金額（在庫）
                dt.Columns.Add(ct_Col_St_SalesMoney, typeof(Int64));
                dt.Columns[ct_Col_St_SalesMoney].DefaultValue = 0;

                // 返品額（在庫）
                dt.Columns.Add(ct_Col_St_SalesRetGoodsPrice, typeof(Int64));
                dt.Columns[ct_Col_St_SalesRetGoodsPrice].DefaultValue = 0;

                // 値引金額（在庫）
                dt.Columns.Add(ct_Col_St_DiscountPrice, typeof(Int64));
                dt.Columns[ct_Col_St_DiscountPrice].DefaultValue = 0;

                // 粗利金額（在庫）
                dt.Columns.Add(ct_Col_St_GrossProfit, typeof(Int64));
                dt.Columns[ct_Col_St_GrossProfit].DefaultValue = 0;

                // 売上回数（取寄）
                dt.Columns.Add(ct_Col_Or_SalesTimes, typeof(Int32));
                dt.Columns[ct_Col_Or_SalesTimes].DefaultValue = 0;

                // 売上数計（取寄）
                dt.Columns.Add(ct_Col_Or_TotalSalesCount, typeof(double));
                dt.Columns[ct_Col_Or_TotalSalesCount].DefaultValue = 0;

                // 売上金額（取寄）
                dt.Columns.Add(ct_Col_Or_SalesMoney, typeof(Int64));
                dt.Columns[ct_Col_Or_SalesMoney].DefaultValue = 0;

                // 返品額（取寄）
                dt.Columns.Add(ct_Col_Or_SalesRetGoodsPrice, typeof(Int64));
                dt.Columns[ct_Col_Or_SalesRetGoodsPrice].DefaultValue = 0;

                // 値引金額（取寄）
                dt.Columns.Add(ct_Col_Or_DiscountPrice, typeof(Int64));
                dt.Columns[ct_Col_Or_DiscountPrice].DefaultValue = 0;

                // 粗利金額（取寄）
                dt.Columns.Add(ct_Col_Or_GrossProfit, typeof(Int64));
                dt.Columns[ct_Col_Or_GrossProfit].DefaultValue = 0;


                // 商品大分類
                dt.Columns.Add(ct_Col_GoodsLGroup, typeof(Int32));
                dt.Columns[ct_Col_GoodsLGroup].DefaultValue = 0;

                // 商品中分類
                dt.Columns.Add(ct_Col_GoodsMGroup, typeof(Int32));
                dt.Columns[ct_Col_GoodsMGroup].DefaultValue = 0;

                // BLグループコード
                dt.Columns.Add(ct_Col_BLGroupCode, typeof(Int32));
                dt.Columns[ct_Col_BLGroupCode].DefaultValue = 0;

                // 品名
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));
                dt.Columns[ct_Col_GoodsName].DefaultValue = string.Empty;

                // 棚番
                dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = string.Empty;

                // 結合品数
                dt.Columns.Add(ct_Col_PartsCount, typeof(Int32));
                dt.Columns[ct_Col_PartsCount].DefaultValue = 0;

                // 結合品 商品情報リスト
                dt.Columns.Add(ct_Col_GoodsUnitDataList, typeof(List<GoodsUnitData>));
                dt.Columns[ct_Col_GoodsUnitDataList].DefaultValue = new List<GoodsUnitData>();

                // 結合品 月次集計情報リスト
                dt.Columns.Add(ct_Col_ShipGdsPrimeListResultList, typeof(ArrayList));
                dt.Columns[ct_Col_ShipGdsPrimeListResultList].DefaultValue = new ArrayList();
            }
        }

        #endregion
    }
}
