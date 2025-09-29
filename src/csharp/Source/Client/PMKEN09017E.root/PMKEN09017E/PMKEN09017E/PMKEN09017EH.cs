using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// 提供：トリム情報クラス
    /// </summary>
	public class OfrTrimInfo : PartsSerchSub
    {

        # region DataTable 定義
		public const string TABLENAME_TRIM = "TABLENAME_TRIM";
		/// <summary>
		/// トリムコード
		/// </summary>
		public const string COL_TRIM_TRIMCODE = "trimCode";
		/// <summary>
		/// 部品固有番号
		/// </summary>
		public const string COL_TRIM_PARTSPROPERNO = "partsproperno";


		public const string COL_PARTS_SELECTED = "Col_Selected";

		/// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        /// <returns>CarKindInfo用のDataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_TRIM_TRIMCODE, typeof(string), "トリムコード"));
			wkTable.Columns.Add(CreateColumn(COL_TRIM_PARTSPROPERNO, typeof(Int64), "部品固有番号"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_SELECTED, typeof(int), "行選択"));
			return wkTable;
        }

		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_TRIM_TRIMCODE] = sourcedr[COL_TRIM_TRIMCODE];
			dr[COL_TRIM_PARTSPROPERNO] = sourcedr[COL_TRIM_PARTSPROPERNO];
			return dr;
		}

        # endregion

    }
}
