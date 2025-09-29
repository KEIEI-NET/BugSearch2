using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// 提供：ＢＬ情報クラス
    /// </summary>
	public class OfrBLInfo : PartsSerchSub
    {
        # region DataTable 定義
		public const string TABLENAME_BL = "TABLENAME_BL";
		public const string TABLENAME_OFR_BL = "TABLENAME_OFR_BL";

        // 実際のメンバを記述
		public const string COL_BL_TBSPARTSCODE = "TbsPartsCode";
		public const string COL_BL_TBSPARTSFULLNAME = "TbsPartsFullName";
		public const string COL_BL_TBSPARTSHALFNAME = "TbsPartsHalfName";
		public const string COL_BL_OFRKBN = "OfrKbn";

		public const string COL_BL_EQUIPGENRECODE = "EquipGenreCode";
		public const string COL_BL_GROUPCODE = "GroupCode";
		public const string COL_BL_MIDDLEGENRECODE = "MiddleGenreCode";
		public const string COL_BL_TBSPARTSCDDERIVEDNO = "TbsPartsCdDerivedNo";
		public const string COL_BL_PRIMESEARCHFLG = "PrimeSearchFlg";
		public const string COL_BL_SELECTED = "Col_Selected";

		/// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        /// <returns>CarKindInfo用のDataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_BL_TBSPARTSCODE, typeof(int), "BLコード"));
			wkTable.Columns.Add(CreateColumn(COL_BL_TBSPARTSFULLNAME, typeof(String), "BLコード名称（全角）"));
			wkTable.Columns.Add(CreateColumn(COL_BL_TBSPARTSHALFNAME, typeof(String), "BLコード名称（半角）"));
			wkTable.Columns.Add(CreateColumn(COL_BL_OFRKBN, typeof(int), "提供区分"));

			wkTable.Columns.Add(CreateColumn(COL_BL_EQUIPGENRECODE, typeof(int), "装備分類"));
			wkTable.Columns.Add(CreateColumn(COL_BL_GROUPCODE, typeof(int), "グループコード"));
			wkTable.Columns.Add(CreateColumn(COL_BL_MIDDLEGENRECODE, typeof(int), "中分類コード"));
			wkTable.Columns.Add(CreateColumn(COL_BL_TBSPARTSCDDERIVEDNO, typeof(int), "BLコード枝番"));
			wkTable.Columns.Add(CreateColumn(COL_BL_PRIMESEARCHFLG, typeof(int), "優良BL区分"));
			wkTable.Columns.Add(CreateColumn(COL_BL_SELECTED, typeof(int), "選択状態"));


			//wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COL_BL_TBSPARTSCODE] };

            return wkTable;
        }

		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_BL_OFRKBN] = sourcedr[COL_BL_OFRKBN];
			dr[COL_BL_TBSPARTSCODE] = sourcedr[COL_BL_TBSPARTSCODE];
			dr[COL_BL_TBSPARTSFULLNAME] = sourcedr[COL_BL_TBSPARTSFULLNAME];
			dr[COL_BL_TBSPARTSHALFNAME] = sourcedr[COL_BL_TBSPARTSHALFNAME];
			return dr;
		}


        # endregion

    }
}
