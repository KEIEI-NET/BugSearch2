using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
    ///  優良データ削除処理 テーブルスキーマ情報クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 優良データ削除テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : caohh</br>
	/// <br>Date       : 2011/07/21</br>
	/// <br></br>
    /// <br>Update Note: </br>
    /// <br>           : </br>
	/// </remarks>
	public class PMKHN01505EA
	{
		#region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_DeleteList = "Tbl_DeleteList";

        /// <summary> 商品メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";

        /// <summary> メーカー名称 </summary>
        public const string ct_Col_MakerName = "MakerName";

        /// <summary> 商品番号 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";

        /// <summary> BL商品コード</summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";

        /// <summary> 商品名称 </summary>
        public const string ct_Col_GoodsName = "GoodsName";

        /// <summary> 倉庫コード </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";

        /// <summary> 倉庫名称 </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";

        /// <summary> 倉庫棚番 </summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";

        /// <summary> 出荷可能数 </summary>
        public const string ct_Col_ShipmentPosCnt = "ShipmentPosCnt";

        /// <summary> 発注数(発注残) </summary>
        public const string ct_Col_SalesOrderCount = "SalesOrderCount";

        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
        /// 優良データ削除処理テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 優良データ削除処理テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : caohh</br>
		/// <br>Date       : 2011/07/21</br>
		/// </remarks>
		public PMKHN01505EA()
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
		/// <br>Programmer : caohh</br>
		/// <br>Date       : 2011/07/21</br>
		/// </remarks>
		static public void CreateDataTable(ref DataTable dt)
		{
            string defValuestring = "";
            Int32 defValueInt32 = 0;
            double defValueDouble = 0.0;

			// テーブルが存在するかどうかのチェック
			if ( dt != null )
			{
				// テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
				dt.Clear();
			}
			else
			{
                // スキーマ設定
                dt = new DataTable(ct_Tbl_DeleteList);

                #region << Column 追加 >>
                // 商品メーカーコード
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defValueInt32;

                // メーカー名称
                dt.Columns.Add(ct_Col_MakerName, typeof(string));
                dt.Columns[ct_Col_MakerName].DefaultValue = defValuestring;

                // 商品番号
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = defValuestring;

                // BL商品コード
                dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = defValueInt32;

                // 商品名称
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));
                dt.Columns[ct_Col_GoodsName].DefaultValue = defValuestring;

                // 倉庫コード
                dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));
                dt.Columns[ct_Col_WarehouseCode].DefaultValue = defValuestring;

                // 倉庫名称
                dt.Columns.Add(ct_Col_WarehouseName, typeof(string));
                dt.Columns[ct_Col_WarehouseName].DefaultValue = defValuestring;

                // 倉庫棚番
                dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = defValuestring;

                // 出荷可能数
                dt.Columns.Add(ct_Col_ShipmentPosCnt, typeof(Double));
                dt.Columns[ct_Col_ShipmentPosCnt].DefaultValue = defValueDouble;

                // 発注数(発注残)
                dt.Columns.Add(ct_Col_SalesOrderCount, typeof(Double));
                dt.Columns[ct_Col_SalesOrderCount].DefaultValue = defValueDouble;
                #endregion << Column 追加 >>
            }
		}
		#endregion
		#endregion
	}
}
