using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// 提供：カラー情報クラス
    /// </summary>
	public class OfrColorInfo : PartsSerchSub
    {
        # region DataTable 定義
		public const string TABLENAME_COLOR = "TABLENAME_COLOR";

        // 実際のメンバを記述
		public const string COL_COLOR_COLORCDINFONO = "colorCdInfoNo";
		/// <summary>
		/// 部品固有番号
		/// </summary>
		public const string COL_COLOR_PARTSPROPERNO = "partsproperno";


		public const string COL_PARTS_SELECTED = "Col_Selected";

		/// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        /// <returns>CarKindInfo用のDataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_COLOR_COLORCDINFONO, typeof(string), "カラーコード情報No"));
			wkTable.Columns.Add(CreateColumn(COL_COLOR_PARTSPROPERNO, typeof(Int64), "部品固有番号"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_SELECTED, typeof(int), "行選択"));

			return wkTable;
        }

		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_COLOR_COLORCDINFONO] = sourcedr[COL_COLOR_COLORCDINFONO];
			dr[COL_COLOR_PARTSPROPERNO] = sourcedr[COL_COLOR_PARTSPROPERNO];
			return dr;
		}

        # endregion

    }
}
