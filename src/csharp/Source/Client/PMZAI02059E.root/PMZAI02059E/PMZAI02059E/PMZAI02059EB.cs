using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 在庫看板印刷 帳票1行データ保持クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫看板印刷の帳票１行形式でデータを保持する。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.12.12</br>
    /// <br>       
    public class PMZAI02059EB
    {
        #region ■ Public定数
        // テーブル名称
        public const string ct_Tbl_StockSignResultForPrint = "ct_Tbl_StockSignResultForPrint";
        
        // 開始空行
        // 0:空行 1:印字行
        public const string ct_Col_InvisibleRow = "InvisibleRow";
        // 1行の設定数
        public const string ct_Col_DataNum = "DataNum";

        // 拠点コード
        public const string ct_Col_SectionCode1 = "SectionCode1";
        // 倉庫コード
        public const string ct_Col_WarehouseCode1 = "WarehouseCode1";
        // 商品メーカーコード
        public const string ct_Col_GoodsMakerCd1 = "GoodsMakerCd1";
        // 倉庫棚番
        public const string ct_Col_WarehouseShelfNo1 = "WarehouseShelfNo1";
        // 商品番号
        public const string ct_Col_GoodsNo1 = "GoodsNo1";
        // 商品名称カナ
        public const string ct_Col_GoodsNameKana1 = "GoodsNameKana1";
        // 最低在庫数
        public const string ct_Col_MinimumStockCnt1 = "MinimumStockCnt1";
        // 最高在庫数
        public const string ct_Col_MaximumStockCnt1 = "MaximumStockCnt1";
        // 在庫登録日
        public const string ct_Col_StockCreateDate1 = "StockCreateDate1";
        // 定価（浮動）
        public const string ct_Col_ListPrice1 = "ListPrice1";

        // 拠点コード
        public const string ct_Col_SectionCode2 = "SectionCode2";
        // 倉庫コード
        public const string ct_Col_WarehouseCode2 = "WarehouseCode2";
        // 商品メーカーコード
        public const string ct_Col_GoodsMakerCd2 = "GoodsMakerCd2";
        // 倉庫棚番
        public const string ct_Col_WarehouseShelfNo2 = "WarehouseShelfNo2";
        // 商品番号
        public const string ct_Col_GoodsNo2 = "GoodsNo2";
        // 商品名称カナ
        public const string ct_Col_GoodsNameKana2 = "GoodsNameKana2";
        // 最低在庫数
        public const string ct_Col_MinimumStockCnt2 = "MinimumStockCnt2";
        // 最高在庫数
        public const string ct_Col_MaximumStockCnt2 = "MaximumStockCnt2";
        // 在庫登録日
        public const string ct_Col_StockCreateDate2 = "StockCreateDate2";
        // 定価（浮動）
        public const string ct_Col_ListPrice2 = "ListPrice2";

        // 拠点コード
        public const string ct_Col_SectionCode3 = "SectionCode3";
        // 倉庫コード
        public const string ct_Col_WarehouseCode3 = "WarehouseCode3";
        // 商品メーカーコード
        public const string ct_Col_GoodsMakerCd3 = "GoodsMakerCd3";
        // 倉庫棚番
        public const string ct_Col_WarehouseShelfNo3 = "WarehouseShelfNo3";
        // 商品番号
        public const string ct_Col_GoodsNo3 = "GoodsNo3";
        // 商品名称カナ
        public const string ct_Col_GoodsNameKana3 = "GoodsNameKana3";
        // 最低在庫数
        public const string ct_Col_MinimumStockCnt3 = "MinimumStockCnt3";
        // 最高在庫数
        public const string ct_Col_MaximumStockCnt3 = "MaximumStockCnt3";
        // 在庫登録日
        public const string ct_Col_StockCreateDate3 = "StockCreateDate3";
        // 定価（浮動）
        public const string ct_Col_ListPrice3 = "ListPrice3";

        // 拠点コード
        public const string ct_Col_SectionCode4 = "SectionCode4";
        // 倉庫コード
        public const string ct_Col_WarehouseCode4 = "WarehouseCode4";
        // 商品メーカーコード
        public const string ct_Col_GoodsMakerCd4 = "GoodsMakerCd4";
        // 倉庫棚番
        public const string ct_Col_WarehouseShelfNo4 = "WarehouseShelfNo4";
        // 商品番号
        public const string ct_Col_GoodsNo4 = "GoodsNo4";
        // 商品名称カナ
        public const string ct_Col_GoodsNameKana4 = "GoodsNameKana4";
        // 最低在庫数
        public const string ct_Col_MinimumStockCnt4 = "MinimumStockCnt4";
        // 最高在庫数
        public const string ct_Col_MaximumStockCnt4 = "MaximumStockCnt4";
        // 在庫登録日
        public const string ct_Col_StockCreateDate4 = "StockCreateDate4";
        // 定価（浮動）
        public const string ct_Col_ListPrice4 = "ListPrice4";

        // 拠点コード
        public const string ct_Col_SectionCode5 = "SectionCode5";
        // 倉庫コード
        public const string ct_Col_WarehouseCode5 = "WarehouseCode5";
        // 商品メーカーコード
        public const string ct_Col_GoodsMakerCd5 = "GoodsMakerCd5";
        // 倉庫棚番
        public const string ct_Col_WarehouseShelfNo5 = "WarehouseShelfNo5";
        // 商品番号
        public const string ct_Col_GoodsNo5 = "GoodsNo5";
        // 商品名称カナ
        public const string ct_Col_GoodsNameKana5 = "GoodsNameKana5";
        // 最低在庫数
        public const string ct_Col_MinimumStockCnt5 = "MinimumStockCnt5";
        // 最高在庫数
        public const string ct_Col_MaximumStockCnt5 = "MaximumStockCnt5";
        // 在庫登録日
        public const string ct_Col_StockCreateDate5 = "StockCreateDate5";
        // 定価（浮動）
        public const string ct_Col_ListPrice5 = "ListPrice5";
        #endregion

        #region ■ コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public PMZAI02059EB()
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
                dt = new DataTable(ct_Tbl_StockSignResultForPrint);

                // 開始空行
                dt.Columns.Add(ct_Col_InvisibleRow, typeof(Int32));
                dt.Columns[ct_Col_InvisibleRow].DefaultValue = 0;
                // 1行の設定数
                dt.Columns.Add(ct_Col_DataNum, typeof(Int32));
                dt.Columns[ct_Col_DataNum].DefaultValue = 0;

                // 1列目
                // 拠点コード
                dt.Columns.Add(ct_Col_SectionCode1, typeof(string));
                dt.Columns[ct_Col_SectionCode1].DefaultValue = string.Empty;
                // 倉庫コード
                dt.Columns.Add(ct_Col_WarehouseCode1, typeof(string));
                dt.Columns[ct_Col_WarehouseCode1].DefaultValue = string.Empty;
                // 商品メーカーコード
                dt.Columns.Add(ct_Col_GoodsMakerCd1, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd1].DefaultValue = 0;
                // 倉庫棚番
                dt.Columns.Add(ct_Col_WarehouseShelfNo1, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNo1].DefaultValue = string.Empty;
                // 商品番号
                dt.Columns.Add(ct_Col_GoodsNo1, typeof(string));
                dt.Columns[ct_Col_GoodsNo1].DefaultValue = string.Empty;
                // 商品名称カナ
                dt.Columns.Add(ct_Col_GoodsNameKana1, typeof(string));
                dt.Columns[ct_Col_GoodsNameKana1].DefaultValue = string.Empty;
                // 最低在庫数
                dt.Columns.Add(ct_Col_MinimumStockCnt1, typeof(double));
                dt.Columns[ct_Col_MinimumStockCnt1].DefaultValue = 0;
                // 最高在庫数
                dt.Columns.Add(ct_Col_MaximumStockCnt1, typeof(double));
                dt.Columns[ct_Col_MaximumStockCnt1].DefaultValue = 0;
                // 在庫登録日
                dt.Columns.Add(ct_Col_StockCreateDate1, typeof(DateTime));
                dt.Columns[ct_Col_StockCreateDate1].DefaultValue = DateTime.MinValue;
                // 定価（浮動）
                dt.Columns.Add(ct_Col_ListPrice1, typeof(double));
                dt.Columns[ct_Col_ListPrice1].DefaultValue = 0;

                // 2列目
                // 拠点コード
                dt.Columns.Add(ct_Col_SectionCode2, typeof(string));
                dt.Columns[ct_Col_SectionCode2].DefaultValue = string.Empty;
                // 倉庫コード
                dt.Columns.Add(ct_Col_WarehouseCode2, typeof(string));
                dt.Columns[ct_Col_WarehouseCode2].DefaultValue = string.Empty;
                // 商品メーカーコード
                dt.Columns.Add(ct_Col_GoodsMakerCd2, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd2].DefaultValue = 0;
                // 倉庫棚番
                dt.Columns.Add(ct_Col_WarehouseShelfNo2, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNo2].DefaultValue = string.Empty;
                // 商品番号
                dt.Columns.Add(ct_Col_GoodsNo2, typeof(string));
                dt.Columns[ct_Col_GoodsNo2].DefaultValue = string.Empty;
                // 商品名称カナ
                dt.Columns.Add(ct_Col_GoodsNameKana2, typeof(string));
                dt.Columns[ct_Col_GoodsNameKana2].DefaultValue = string.Empty;
                // 最低在庫数
                dt.Columns.Add(ct_Col_MinimumStockCnt2, typeof(double));
                dt.Columns[ct_Col_MinimumStockCnt2].DefaultValue = 0;
                // 最高在庫数
                dt.Columns.Add(ct_Col_MaximumStockCnt2, typeof(double));
                dt.Columns[ct_Col_MaximumStockCnt2].DefaultValue = 0;
                // 在庫登録日
                dt.Columns.Add(ct_Col_StockCreateDate2, typeof(DateTime));
                dt.Columns[ct_Col_StockCreateDate2].DefaultValue = DateTime.MinValue;
                // 定価（浮動）
                dt.Columns.Add(ct_Col_ListPrice2, typeof(double));
                dt.Columns[ct_Col_ListPrice2].DefaultValue = 0;

                // 3列目
                // 拠点コード
                dt.Columns.Add(ct_Col_SectionCode3, typeof(string));
                dt.Columns[ct_Col_SectionCode3].DefaultValue = string.Empty;
                // 倉庫コード
                dt.Columns.Add(ct_Col_WarehouseCode3, typeof(string));
                dt.Columns[ct_Col_WarehouseCode3].DefaultValue = string.Empty;
                // 商品メーカーコード
                dt.Columns.Add(ct_Col_GoodsMakerCd3, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd3].DefaultValue = 0;
                // 倉庫棚番
                dt.Columns.Add(ct_Col_WarehouseShelfNo3, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNo3].DefaultValue = string.Empty;
                // 商品番号
                dt.Columns.Add(ct_Col_GoodsNo3, typeof(string));
                dt.Columns[ct_Col_GoodsNo3].DefaultValue = string.Empty;
                // 商品名称カナ
                dt.Columns.Add(ct_Col_GoodsNameKana3, typeof(string));
                dt.Columns[ct_Col_GoodsNameKana3].DefaultValue = string.Empty;
                // 最低在庫数
                dt.Columns.Add(ct_Col_MinimumStockCnt3, typeof(double));
                dt.Columns[ct_Col_MinimumStockCnt3].DefaultValue = 0;
                // 最高在庫数
                dt.Columns.Add(ct_Col_MaximumStockCnt3, typeof(double));
                dt.Columns[ct_Col_MaximumStockCnt3].DefaultValue = 0;
                // 在庫登録日
                dt.Columns.Add(ct_Col_StockCreateDate3, typeof(DateTime));
                dt.Columns[ct_Col_StockCreateDate3].DefaultValue = DateTime.MinValue;
                // 定価（浮動）
                dt.Columns.Add(ct_Col_ListPrice3, typeof(double));
                dt.Columns[ct_Col_ListPrice3].DefaultValue = 0;

                // 4列目
                // 拠点コード
                dt.Columns.Add(ct_Col_SectionCode4, typeof(string));
                dt.Columns[ct_Col_SectionCode4].DefaultValue = string.Empty;
                // 倉庫コード
                dt.Columns.Add(ct_Col_WarehouseCode4, typeof(string));
                dt.Columns[ct_Col_WarehouseCode4].DefaultValue = string.Empty;
                // 商品メーカーコード
                dt.Columns.Add(ct_Col_GoodsMakerCd4, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd4].DefaultValue = 0;
                // 倉庫棚番
                dt.Columns.Add(ct_Col_WarehouseShelfNo4, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNo4].DefaultValue = string.Empty;
                // 商品番号
                dt.Columns.Add(ct_Col_GoodsNo4, typeof(string));
                dt.Columns[ct_Col_GoodsNo4].DefaultValue = string.Empty;
                // 商品名称カナ
                dt.Columns.Add(ct_Col_GoodsNameKana4, typeof(string));
                dt.Columns[ct_Col_GoodsNameKana4].DefaultValue = string.Empty;
                // 最低在庫数
                dt.Columns.Add(ct_Col_MinimumStockCnt4, typeof(double));
                dt.Columns[ct_Col_MinimumStockCnt4].DefaultValue = 0;
                // 最高在庫数
                dt.Columns.Add(ct_Col_MaximumStockCnt4, typeof(double));
                dt.Columns[ct_Col_MaximumStockCnt4].DefaultValue = 0;
                // 在庫登録日
                dt.Columns.Add(ct_Col_StockCreateDate4, typeof(DateTime));
                dt.Columns[ct_Col_StockCreateDate4].DefaultValue = DateTime.MinValue;
                // 定価（浮動）
                dt.Columns.Add(ct_Col_ListPrice4, typeof(double));
                dt.Columns[ct_Col_ListPrice4].DefaultValue = 0;

                // 5列目
                // 拠点コード
                dt.Columns.Add(ct_Col_SectionCode5, typeof(string));
                dt.Columns[ct_Col_SectionCode5].DefaultValue = string.Empty;
                // 倉庫コード
                dt.Columns.Add(ct_Col_WarehouseCode5, typeof(string));
                dt.Columns[ct_Col_WarehouseCode5].DefaultValue = string.Empty;
                // 商品メーカーコード
                dt.Columns.Add(ct_Col_GoodsMakerCd5, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd5].DefaultValue = 0;
                // 倉庫棚番
                dt.Columns.Add(ct_Col_WarehouseShelfNo5, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNo5].DefaultValue = string.Empty;
                // 商品番号
                dt.Columns.Add(ct_Col_GoodsNo5, typeof(string));
                dt.Columns[ct_Col_GoodsNo5].DefaultValue = string.Empty;
                // 商品名称カナ
                dt.Columns.Add(ct_Col_GoodsNameKana5, typeof(string));
                dt.Columns[ct_Col_GoodsNameKana5].DefaultValue = string.Empty;
                // 最低在庫数
                dt.Columns.Add(ct_Col_MinimumStockCnt5, typeof(double));
                dt.Columns[ct_Col_MinimumStockCnt5].DefaultValue = 0;
                // 最高在庫数
                dt.Columns.Add(ct_Col_MaximumStockCnt5, typeof(double));
                dt.Columns[ct_Col_MaximumStockCnt5].DefaultValue = 0;
                // 在庫登録日
                dt.Columns.Add(ct_Col_StockCreateDate5, typeof(DateTime));
                dt.Columns[ct_Col_StockCreateDate5].DefaultValue = DateTime.MinValue;
                // 定価（浮動）
                dt.Columns.Add(ct_Col_ListPrice5, typeof(double));
                dt.Columns[ct_Col_ListPrice5].DefaultValue = 0;
            }
        }
        #endregion
    }
}
