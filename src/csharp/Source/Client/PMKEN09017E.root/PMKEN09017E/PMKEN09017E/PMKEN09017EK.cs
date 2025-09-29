using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// 提供：優良部品検索情報クラス
    /// </summary>
    public class OfrJoinPartsInfo : PartsSerchSub
    {

        # region DataTable 定義
        public const string TABLENAME_JOIN = "TABLENAME_JOIN";

        // 実際のメンバを記述
        public const string COL_JOIN_SELECTED = "Col_Selected";
        public const string COL_JOIN_TBSPARTSCODE = "TbsPartsCode";
        public const string COL_JOIN_TBSPARTSCDDERIVEDNO = "TbsPartsCdDerivedNo";
        public const string COL_JOIN_SELECTCODE = "SelectCode";
        public const string COL_JOIN_PRIMEKINDCODE = "PrimeKindCode";
        public const string COL_JOIN_JOINDISPORDER = "JoinDispOrder";
        public const string COL_JOIN_JOINSOURCEMAKERCODE = "JoinSourceMakerCode";
        public const string COL_JOIN_JOINSOURPARTSNOWITHH = "JoinSourPartsNoWithH";
        public const string COL_JOIN_JOINSOURPARTSNONONEH = "JoinSourPartsNoNoneH";
        public const string COL_JOIN_JOINDESTMAKERCD = "JoinDestMakerCd";
        public const string COL_JOIN_JOINDESTPARTSNO = "JoinDestPartsNo";
        public const string COL_JOIN_JOINDESTPARTSNAME = "JoinDestPartsName";
        public const string COL_JOIN_JOINOLDPARTSNO = "JoinOldPartsNo";
        public const string COL_JOIN_JOINQTY = "JoinQty";
        public const string COL_JOIN_SETPARTSFLG = "SetPartsFlg";
        public const string COL_JOIN_JOINSPECIALNOTE = "JoinSpecialNote";
        public const string COL_JOIN_JOINPRICE = "JoinPrice";
        public const string COL_JOIN_PRIMEKINDNAME = "PrimeKindName";
        public const string COL_JOIN_JOINDESTMAKERNAME = "JoinDestMakerName";
        public const string COL_JOIN_MAKERDISPORDER = "MakerDispOrder";
        public const string COL_JOIN_PRIMEDISPORDER = "PrimeDispOrder";

        /// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        /// <returns>CarKindInfo用のDataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
            DataTable wkTable = new DataTable(tbl_name);
            wkTable.Columns.Add(CreateColumn(COL_JOIN_SELECTED, typeof(int), "行選択"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_TBSPARTSCODE, typeof(int), "BLコード"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_TBSPARTSCDDERIVEDNO, typeof(int), "BLコード枝番"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_SELECTCODE, typeof(int), "セレクトコード"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_PRIMEKINDCODE, typeof(int), "優良種別コード"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_PRIMEKINDNAME, typeof(string), "優良種別名称"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINDISPORDER, typeof(int), "結合表示順位"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINSOURCEMAKERCODE, typeof(int), "結合元メーカー"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINSOURPARTSNOWITHH, typeof(string), "ハイフン付結合元品番"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINSOURPARTSNONONEH, typeof(string), "ハイフン無結合元品番"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINDESTMAKERCD, typeof(int), "結合先メーカー"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINDESTMAKERNAME, typeof(string), "結合先メーカー名称"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINDESTPARTSNO, typeof(string), "結合先品番"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINDESTPARTSNAME, typeof(string), "結合先品名"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINOLDPARTSNO, typeof(string), "結合先旧品番"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINPRICE, typeof(Int64), "結合先標準価格"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINQTY, typeof(double), "結合QTY"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_SETPARTSFLG, typeof(int), "セット有無フラグ"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINSPECIALNOTE, typeof(string), "結合特記事項"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_MAKERDISPORDER, typeof(int), "メーカー表示順位"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_PRIMEDISPORDER, typeof(int), "優良表示順位"));

            return wkTable;
        }

        # endregion

    }
}
