using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 出荷商品優良対応表2 帳票印字用データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出荷商品優良対応表2の帳票印字用の１行データを保持する。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.11.25</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMHNB02155EB
    {
        #region ■ Public定数
        // テーブル名称
        public const string ct_Tbl_ShipGdsPrimeListResultForPrint = "ShipGdsPrimeListResultForPrint";
        // 拠点コード
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        // 拠点名称
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";

        // --ソート用--
        // メーカーコード
        public const string ct_Col_Sort_GoodsMakerCd = "Sort_GoodsMakerCd";
        // 商品大分類コード
        public const string ct_Col_Sort_GoodsLGroup = "Sort_GoodsLGroup";
        // 商品中分類コード
        public const string ct_Col_Sort_GoodsMGroup = "Sort_GoodsMGroup";
        // グループコード
        public const string ct_Col_Sort_BLGroupCode = "Sort_BLGroupCode";

        // --帳票印字制御用--
        // 検索先情報有無(0:なし、1:あり)
        public const string ct_Col_SubInfoCount = "SubInfoCount";
        // 同明細キー
        public const string ct_Col_DetailUnitKey = "DetailUnitKey";

        // --検索元(左側)関連--
        // グループコード
        public const string ct_Col_Main_BLGroupCode = "Main_BLGroupCode";
        // 純正品番
        public const string ct_Col_Main_GoodsNo = "Main_GoodsNo";
        // 品名
        public const string ct_Col_Main_GoodsName = "Main_GoodsName";
        // 棚番
        public const string ct_Col_Main_WarehouseShelfNo = "Main_WarehouseShelfNo";
        // 売上回数（在庫）
        public const string ct_Col_Main_St_SalesTimes = "Main_St_SalesTimes";
        // 売上回数（取寄）
        public const string ct_Col_Main_Or_SalesTimes = "Main_Or_SalesTimes";
        // 売上回数（合計）
        public const string ct_Col_Main_Sum_SalesTimes = "Main_Sum_SalesTimes";


        // --検索先(右側)関連--
        // 順位
        public const string ct_Col_Sub_DisplayOrder = "Sub_DisplayOrder";
        // 仕入先1
        public const string ct_Col_Sub_SuplierCode = "Sub_SuplierCode";
        // メーカー1
        public const string ct_Col_Sub_MakerCode = "Sub_MakerCode";
        // 参考品番1
        public const string ct_Col_Sub_GoodsNo = "Sub_GoodsNo";
        // 棚番1
        public const string ct_Col_Sub_WarehouseShelfNo = "Sub_WarehouseShelfNo";

        // 売上回数（在庫）
        public const string ct_Col_Sub_St_SalesTimes = "Sub_St_SalesTimes";
        // 売上回数（取寄）
        public const string ct_Col_Sub_Or_SalesTimes = "Sub_Or_SalesTimes";
        // 売上回数（合計）
        public const string ct_Col_Sub_Sum_SalesTimes = "Sub_Sum_SalesTimes";

        // --検索先計(右側)関連--
        // 売上回数（在庫）合計
        public const string ct_Col_SubTotal_St_SalesTimes = "SubTotal_St_SalesTimes";
        // 売上回数（取寄）合計
        public const string ct_Col_SubTotal_Or_SalesTimes = "SubTotal_Or_SalesTimes";
        // 売上回数（合計）合計
        public const string ct_Col_SubTotal_Sum_SalesTimes = "SubTotal_Sum_SalesTimes";

        #endregion

        #region ■ コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public PMHNB02155EB()
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

                // --ソート--
                // 商品メーカーコード
                dt.Columns.Add(ct_Col_Sort_GoodsMakerCd, typeof(Int32));
                dt.Columns[ct_Col_Sort_GoodsMakerCd].DefaultValue = 0;

                // 商品大分類
                dt.Columns.Add(ct_Col_Sort_GoodsLGroup, typeof(Int32));
                dt.Columns[ct_Col_Sort_GoodsLGroup].DefaultValue = 0;

                // 商品中分類
                dt.Columns.Add(ct_Col_Sort_GoodsMGroup, typeof(Int32));
                dt.Columns[ct_Col_Sort_GoodsMGroup].DefaultValue = 0;

                // BLグループコード
                dt.Columns.Add(ct_Col_Sort_BLGroupCode, typeof(Int32));
                dt.Columns[ct_Col_Sort_BLGroupCode].DefaultValue = 0;

                // --制御用--
                // 検索先(右側)の情報数(0か1)
                dt.Columns.Add(ct_Col_SubInfoCount, typeof(Int32));
                dt.Columns[ct_Col_SubInfoCount].DefaultValue = 0;

                // 同明細キー
                dt.Columns.Add(ct_Col_DetailUnitKey, typeof(Int32));
                dt.Columns[ct_Col_DetailUnitKey].DefaultValue = 0;

                // --検索元(左側)関連--
                // グループコード
                dt.Columns.Add(ct_Col_Main_BLGroupCode, typeof(Int32));
                dt.Columns[ct_Col_Main_BLGroupCode].DefaultValue = 0;
                
                // 純正品番
                dt.Columns.Add(ct_Col_Main_GoodsNo, typeof(string));
                dt.Columns[ct_Col_Main_GoodsNo].DefaultValue = string.Empty;

                // 品名
                dt.Columns.Add(ct_Col_Main_GoodsName, typeof(string));
                dt.Columns[ct_Col_Main_GoodsName].DefaultValue = string.Empty;

                // 棚番
                dt.Columns.Add(ct_Col_Main_WarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_Main_WarehouseShelfNo].DefaultValue = string.Empty;

                // 売上回数(在庫)
                dt.Columns.Add(ct_Col_Main_St_SalesTimes, typeof(Int32));
                dt.Columns[ct_Col_Main_St_SalesTimes].DefaultValue = 0;

                // 売上回数(取寄)
                dt.Columns.Add(ct_Col_Main_Or_SalesTimes, typeof(Int32));
                dt.Columns[ct_Col_Main_Or_SalesTimes].DefaultValue = 0;

                // 売上回数(合計)
                dt.Columns.Add(ct_Col_Main_Sum_SalesTimes, typeof(Int32));
                dt.Columns[ct_Col_Main_Sum_SalesTimes].DefaultValue = 0;

                // --検索先(右側)関連--
                // 順位
                dt.Columns.Add(ct_Col_Sub_DisplayOrder, typeof(Int32));
                dt.Columns[ct_Col_Sub_DisplayOrder].DefaultValue = 0;

                // 仕入先
                dt.Columns.Add(ct_Col_Sub_SuplierCode, typeof(Int32));
                dt.Columns[ct_Col_Sub_SuplierCode].DefaultValue = 0;

                // メーカー
                dt.Columns.Add(ct_Col_Sub_MakerCode, typeof(Int32));
                dt.Columns[ct_Col_Sub_MakerCode].DefaultValue = 0;

                // 参考品番
                dt.Columns.Add(ct_Col_Sub_GoodsNo, typeof(string));
                dt.Columns[ct_Col_Sub_GoodsNo].DefaultValue = string.Empty;

                // 棚番
                dt.Columns.Add(ct_Col_Sub_WarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_Sub_WarehouseShelfNo].DefaultValue = string.Empty;

                // 売上回数（在庫）
                dt.Columns.Add(ct_Col_Sub_St_SalesTimes, typeof(Int32));
                dt.Columns[ct_Col_Sub_St_SalesTimes].DefaultValue = 0;

                // 売上回数（取寄）
                dt.Columns.Add(ct_Col_Sub_Or_SalesTimes, typeof(Int32));
                dt.Columns[ct_Col_Sub_Or_SalesTimes].DefaultValue = 0;

                // 売上回数（合計）
                dt.Columns.Add(ct_Col_Sub_Sum_SalesTimes, typeof(Int32));
                dt.Columns[ct_Col_Sub_Sum_SalesTimes].DefaultValue = 0;

                // --検索先計(右側)関連--
                // 売上回数（在庫）合計
                dt.Columns.Add(ct_Col_SubTotal_St_SalesTimes, typeof(double));
                dt.Columns[ct_Col_SubTotal_St_SalesTimes].DefaultValue = 0;

                // 売上回数（取寄）合計
                dt.Columns.Add(ct_Col_SubTotal_Or_SalesTimes, typeof(double));
                dt.Columns[ct_Col_SubTotal_Or_SalesTimes].DefaultValue = 0;

                // 売上回数（合計）合計
                dt.Columns.Add(ct_Col_SubTotal_Sum_SalesTimes, typeof(double));
                dt.Columns[ct_Col_SubTotal_Sum_SalesTimes].DefaultValue = 0;
            }
        }
        #endregion
    }
}
