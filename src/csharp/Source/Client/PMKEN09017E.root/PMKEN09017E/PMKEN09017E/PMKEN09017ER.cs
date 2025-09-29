using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// 提供：車両情報結合情報クラス
    /// </summary>
    public class OfrCarInfoJoinPartsInfo : PartsSerchSub
    {

        # region DataTable 定義
        public const string TABLENAME_CARINFJOIN = "TABLENAME_CARINFJOIN";

        // 実際のメンバを記述

        public const string COL_CARINFJOIN_SELECTED = "Col_Selected";
        public const string COL_CARINFJOIN_MIDDLEGENRECODE = "MiddleGenreCode";
        public const string COL_CARINFJOIN_TBSPARTSCODE = "TbsPartsCode";
        public const string COL_CARINFJOIN_TBSPARTSCDDERIVEDNO = "TbsPartsCdDerivedNo";
        public const string COL_CARINFJOIN_EQUIPGENRECODE = "EquipGenreCode";
        public const string COL_CARINFJOIN_EQUIPNAME = "EquipName";
        public const string COL_CARINFJOIN_CARINFOJOINDISPORDER = "CarInfoJoinDispOrder";
        public const string COL_CARINFJOIN_JOINDESTMAKERCD = "JoinDestMakerCd";
        public const string COL_CARINFJOIN_JOINDESTMAKERNAME = "JoinDestMakerName";
        public const string COL_CARINFJOIN_JOINDESTPARTSNO = "JoinDestPartsNo";
        public const string COL_CARINFJOIN_JOINDESTPARTSNAME = "JoinDestPartsName";
        public const string COL_CARINFJOIN_JOINQTY = "JoinQty";
        public const string COL_CARINFJOIN_JOINPRICE = "JoinPrice";
        public const string COL_CARINFJOIN_EQUIPSPECIALNOTE = "EquipSpecialNote";
        public const string COL_CARINFJOIN_MAKERDISPORDER = "MakerDispOrder";


        /// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        /// <returns>CarKindInfo用のDataTable</returns>
        public static DataTable CreateTable(string table_name)
        {
            DataTable wkTable = new DataTable(table_name);

            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_SELECTED, typeof(int), "行選択"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_MIDDLEGENRECODE, typeof(int), "中分類コード"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_TBSPARTSCODE, typeof(int), "BLコード"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_TBSPARTSCDDERIVEDNO, typeof(int), "BLコード枝番"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_EQUIPGENRECODE, typeof(string), "装備分類"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_EQUIPNAME, typeof(string), "装備名称"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_CARINFOJOINDISPORDER, typeof(int), "車両情報結合表示順位"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_JOINDESTMAKERCD, typeof(int), "結合先メーカー"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_JOINDESTMAKERNAME, typeof(string), "結合先メーカー名称"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_JOINDESTPARTSNO, typeof(string), "結合先品番"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_JOINDESTPARTSNAME, typeof(string), "結合先品名"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_JOINPRICE, typeof(Int64), "結合先標準価格"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_JOINQTY, typeof(double), "結合QTY"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_EQUIPSPECIALNOTE, typeof(string), "装備特記事項"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_MAKERDISPORDER, typeof(int), "メーカー表示順位"));

            return wkTable;
        }

        # endregion

    }
}
