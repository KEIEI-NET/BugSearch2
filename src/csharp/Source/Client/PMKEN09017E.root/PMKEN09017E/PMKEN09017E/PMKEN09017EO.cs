using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// 提供：同一品番情報クラス
    /// </summary>
    public class SamePartsInfo : PartsSerchSub
    {

        # region DataTable 定義
        public const string TABLENAME_SAME = "TABLENAME_SAME";

        // 実際のメンバを記述
        public const string COL_SAME_SELECTED = "Col_Selected";
        public const string COL_SAME_MAKERCODE = "SameMakerCode";
        public const string COL_SAME_PARTSNOWITHH = "SamePartsNoWithH";
        public const string COL_SAME_PARTSNAME = "SamePartsName";
        public const string COL_SAME_MAKERNAME = "SameMakerName";
        public const string COL_SAME_PRICE = "SamePrice";

        /// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        /// <returns>CarKindInfo用のDataTable</returns>
        public static DataTable CreateTable(string table_name)
        {
			DataTable wkTable = new DataTable(table_name);
            wkTable.Columns.Add(CreateColumn(COL_SAME_SELECTED, typeof(int), "行選択"));
            wkTable.Columns.Add(CreateColumn(COL_SAME_MAKERCODE, typeof(int), "メーカー"));
            wkTable.Columns.Add(CreateColumn(COL_SAME_PARTSNOWITHH, typeof(string), "ハイフン付品番"));
            wkTable.Columns.Add(CreateColumn(COL_SAME_MAKERNAME, typeof(string), "メーカー名称"));
            wkTable.Columns.Add(CreateColumn(COL_SAME_PARTSNAME, typeof(string), "品名"));
            wkTable.Columns.Add(CreateColumn(COL_SAME_PRICE, typeof(Int64), "標準価格"));

            return wkTable;
        }

        # endregion

    }
}
