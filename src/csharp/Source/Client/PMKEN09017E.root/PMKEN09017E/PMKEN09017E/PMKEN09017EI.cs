using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// 提供：装備情報クラス
    /// </summary>
	public class OfrEquipInfo : PartsSerchSub
    {

        # region DataTable 定義
		public const string TABLENAME_EQUIP = "TABLENAME_EQUIP";

        // 実際のメンバを記述
		/// <summary>装備分類コード</summary>
		public const string COL_EQUIP_EQUIPMENTGENRECD = "equipmentGenreCd";
		/// <summary>装備コード</summary>
		public const string COL_EQUIP_EQUIPMENTCODE = "equipmentCode";
		/// <summary>部品固有番号</summary>
		public const string COL_EQUIP_PARTSPROPERNO = "partsproperno";


		public const string COL_PARTS_SELECTED = "Col_Selected";


		/// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        /// <returns>CarKindInfo用のDataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_EQUIP_EQUIPMENTGENRECD, typeof(int), "装備分類コード"));
			wkTable.Columns.Add(CreateColumn(COL_EQUIP_EQUIPMENTCODE, typeof(int), "装備コード"));
			wkTable.Columns.Add(CreateColumn(COL_EQUIP_PARTSPROPERNO, typeof(Int64), "部品固有番号"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_SELECTED, typeof(int), "行選択"));
            return wkTable;
        }

		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_EQUIP_EQUIPMENTGENRECD] = sourcedr[COL_EQUIP_EQUIPMENTGENRECD];
			dr[COL_EQUIP_EQUIPMENTCODE] = sourcedr[COL_EQUIP_EQUIPMENTCODE];
			dr[COL_EQUIP_PARTSPROPERNO] = sourcedr[COL_EQUIP_PARTSPROPERNO];
			return dr;
		}

        # endregion

    }
}
