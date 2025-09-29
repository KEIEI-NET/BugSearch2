using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 委託在庫補充処理表用テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 委託在庫補充処理表用テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 30414 忍 幸史</br>
	/// <br>Date       : 2008/11/12</br>
    /// </remarks>
	public class PMZAI02069EA
	{
        # region Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_TrustStockOrder = "Tbl_TrustStockOrder";

        /// <summary> メーカーコード </summary>
        public const string ct_Col_MakerCode = "MakerCode";

        /// <summary> メーカー名 </summary>
        public const string ct_Col_MakerName = "MakerName";

        /// <summary> 品番 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";

        /// <summary> 品名 </summary>
        public const string ct_Col_GoodsName = "GoodsName";

        /// <summary> 補充先倉庫コード </summary>
        public const string ct_Col_AfWarehouseCode = "AfWarehouseCode";

        /// <summary> 補充先倉庫名 </summary>
        public const string ct_Col_AfWarehouseName = "AfWarehouseName";

        /// <summary> 補充先棚番 </summary>
        public const string ct_Col_AfWarehouseShelfNo = "AfWarehouseShelfNo";

        /// <summary> 最高在庫数 </summary>
        public const string ct_Col_MaximumStockCnt = "MaximumStockCnt";

        /// <summary> 補充先現在庫数 </summary>
        public const string ct_Col_AfSupplierStock = "AfSupplierStock";

        /// <summary> 補充数 </summary>
        public const string ct_Col_Replenishment = "Replenishment";

        /// <summary> 補充元倉庫コード </summary>
        public const string ct_Col_BfWarehouseCode = "BfWarehouseCode";

        /// <summary> 補充元倉庫名 </summary>
        public const string ct_Col_BfWarehouseName = "BfWarehouseName";

        /// <summary> 補充元棚番 </summary>
        public const string ct_Col_BfWarehouseShelfNo = "BfWarehouseShelfNo";

        /// <summary> 補充元現在庫数 </summary>
        public const string ct_Col_BfSupplierStock = "BfSupplierStock";

        /// <summary> 補充後現在庫数 </summary>
        public const string ct_Col_BfAfterSupplierStock = "BfAfterSupplierStock";

        /// <summary> コメント </summary>
        public const string ct_Col_Note = "Note";

        # endregion Public Const


        # region Constructor
        /// <summary>
        /// 委託在庫補充処理表用テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 委託在庫補充処理表用テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        public PMZAI02069EA()
        {
        }
        # endregion Constructor


        # region Public Method
        /// <summary>
        /// 委託在庫補充処理表DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="ds">設定対象データセット</param>
        /// <remarks>
        /// <br>Note       : 委託在庫補充処理表データセットのスキーマを設定する。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        static public void CreateDataTableTrustStockOrder(ref DataTable dt)
        {
            if (dt == null)
                dt = new DataTable();

            if (dt.TableName == ct_Tbl_TrustStockOrder)
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                dt.Clear();
            }
            else
            {
                // スキーマ設定

                // メーカーコード
                dt.Columns.Add(ct_Col_MakerCode, typeof(string));			
                dt.Columns[ct_Col_MakerCode].DefaultValue = "0";
                // メーカー名
                dt.Columns.Add(ct_Col_MakerName, typeof(string));		
                dt.Columns[ct_Col_MakerName].DefaultValue = "";
                // 品番
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = "";
                // 品名
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));		
                dt.Columns[ct_Col_GoodsName].DefaultValue = "";
                // 補充先倉庫コード
                dt.Columns.Add(ct_Col_AfWarehouseCode, typeof(string));
                dt.Columns[ct_Col_AfWarehouseCode].DefaultValue = "";
                // 補充先倉庫名
                dt.Columns.Add(ct_Col_AfWarehouseName, typeof(string));
                dt.Columns[ct_Col_AfWarehouseName].DefaultValue = "";
                // 補充先棚番
                dt.Columns.Add(ct_Col_AfWarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_AfWarehouseShelfNo].DefaultValue = "";
                // 最高在庫数
                dt.Columns.Add(ct_Col_MaximumStockCnt, typeof(double));
                dt.Columns[ct_Col_MaximumStockCnt].DefaultValue = 0;
                // 補充先現在庫数
                dt.Columns.Add(ct_Col_AfSupplierStock, typeof(double));
                dt.Columns[ct_Col_AfSupplierStock].DefaultValue = 0;
                // 補充数
                dt.Columns.Add(ct_Col_Replenishment, typeof(double));
                dt.Columns[ct_Col_Replenishment].DefaultValue = 0;
                // 補充元倉庫コード
                dt.Columns.Add(ct_Col_BfWarehouseCode, typeof(string));
                dt.Columns[ct_Col_BfWarehouseCode].DefaultValue = "";
                // 補充元倉庫名
                dt.Columns.Add(ct_Col_BfWarehouseName, typeof(string));
                dt.Columns[ct_Col_BfWarehouseName].DefaultValue = "";
                // 補充元棚番
                dt.Columns.Add(ct_Col_BfWarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_BfWarehouseShelfNo].DefaultValue = "";
                // 補充元現在庫数
                dt.Columns.Add(ct_Col_BfSupplierStock, typeof(double));
                dt.Columns[ct_Col_BfSupplierStock].DefaultValue = 0;
                // 補充後現在庫数
                dt.Columns.Add(ct_Col_BfAfterSupplierStock, typeof(double));
                dt.Columns[ct_Col_BfAfterSupplierStock].DefaultValue = 0;
                // コメント
                dt.Columns.Add(ct_Col_Note, typeof(string));
                dt.Columns[ct_Col_Note].DefaultValue = "";
            }
        }
        # endregion Public Method
    }
}
