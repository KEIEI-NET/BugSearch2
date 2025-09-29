using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// 提供：セット情報クラス
    /// </summary>
	public class OfrSetPartsInfo : PartsSerchSub
    {

        # region DataTable 定義
		public const string TABLENAME_SET = "TABLENAME_SET";

        // 実際のメンバを記述
		public const string COL_SET_MIDDLEGENRECODE = "MiddleGenreCode";
		public const string COL_SET_TBSPARTSCODE = "TbsPartsCode";
		public const string COL_SET_TBSPARTSCDDERIVEDNO = "TbsPartsCdDerivedNo";
		public const string COL_SET_SETMAINMAKERCD = "SetMainMakerCd";
		public const string COL_SET_SETMAINPARTSNO = "SetMainPartsNo";
		public const string COL_SET_SETSUBMAKERCD = "SetSubMakerCd";
		public const string COL_SET_SETSUBPARTSNO = "SetSubPartsNo";
		public const string COL_SET_SETDISPORDER = "SetDispOrder";
		public const string COL_SET_SETQTY = "SetQty";
		public const string COL_SET_SETNAME = "SetName";
		public const string COL_SET_SETSPECIALNOTE = "SetSpecialNote";
		public const string COL_SET_CATALOGSHAPENO = "CatalogShapeNo";
        public const string COL_SET_SETSUBPARTSNAME = "SetSubPartsName";
        public const string COL_SET_SETSUBMAKERNAME = "SetSubMakerName";
        public const string COL_SET_SETPRICE = "SetPrice";
		public const string COL_SET_SELECTED = "Col_Selected";

		/// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        /// <returns>CarKindInfo用のDataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

            wkTable.Columns.Add(CreateColumn(COL_SET_SELECTED, typeof(int), "行選択"));
            wkTable.Columns.Add(CreateColumn(COL_SET_MIDDLEGENRECODE, typeof(int), "中分類コード"));
            wkTable.Columns.Add(CreateColumn(COL_SET_TBSPARTSCODE, typeof(int), "BLコード"));
            wkTable.Columns.Add(CreateColumn(COL_SET_TBSPARTSCDDERIVEDNO, typeof(int), "BLコード枝番"));
			wkTable.Columns.Add(CreateColumn(COL_SET_SETMAINMAKERCD, typeof(int), "セット親メーカーコード"));
			wkTable.Columns.Add(CreateColumn(COL_SET_SETMAINPARTSNO, typeof(string), "セット親品番"));
			wkTable.Columns.Add(CreateColumn(COL_SET_SETSUBMAKERCD, typeof(int), "セット子メーカーコード"));
            wkTable.Columns.Add(CreateColumn(COL_SET_SETSUBMAKERNAME, typeof(string), "セット子メーカー名"));
			wkTable.Columns.Add(CreateColumn(COL_SET_SETSUBPARTSNO, typeof(string), "セット子品番"));
            wkTable.Columns.Add(CreateColumn(COL_SET_SETSUBPARTSNAME, typeof(string), "セット子部品名称"));
            wkTable.Columns.Add(CreateColumn(COL_SET_SETDISPORDER, typeof(int), "表示順位"));
			wkTable.Columns.Add(CreateColumn(COL_SET_SETQTY, typeof(double), "セットQTY"));
			wkTable.Columns.Add(CreateColumn(COL_SET_SETNAME, typeof(string), "セット名称"));
			wkTable.Columns.Add(CreateColumn(COL_SET_SETSPECIALNOTE, typeof(string), "セット規格・特記事項"));
			wkTable.Columns.Add(CreateColumn(COL_SET_CATALOGSHAPENO, typeof(string), "カタログ図番"));

            wkTable.Columns.Add(CreateColumn(COL_SET_SETPRICE, typeof(Int64), "セット標準価格"));

            return wkTable;
        }
        # endregion

    }
}
