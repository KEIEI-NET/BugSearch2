using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// 提供：優良ＢＬ検索情報クラス
    /// </summary>
    public class OfrPrimeSearchPartsInfo : PartsSerchSub
    {

        # region DataTable 定義
        public const string TABLENAME_PRIMESEARCH = "TABLENAME_PRIMESEARCH";

        // 実際のメンバを記述
        public const string COL_PRIMESEARCH_SELECTED = "Col_Selected";
        public const string COL_PRIMESEARCH_FULLMODELFIXEDNO = "fullModelFixedNo";
        public const string COL_PRIMESEARCH_MIDDLEGENRECODE = "middleGenreCode";
        public const string COL_PRIMESEARCH_TBSPARTSCODE = "tbsPartsCode";
        public const string COL_PRIMESEARCH_TBSPARTSCDDERIVEDNO = "tbsPartsCdDerivedNo";
        public const string COL_PRIMESEARCH_TBSPARTSCDDERIVEDNM = "tbsPartsCdDerivedNm";//追加
        public const string COL_PRIMESEARCH_PARTSMAKERCD = "partsMakerCd";
        public const string COL_PRIMESEARCH_PARTSMAKERNAME = "partsMakerName";//追加
        public const string COL_PRIMESEARCH_SELECTCODE = "selectCode";
        public const string COL_PRIMESEARCH_PRIMEKINDCODE = "primeKindCode";
        public const string COL_PRIMESEARCH_PRIMESEARCHDISPORDER = "primeSearchDispOrder";
        public const string COL_PRIMESEARCH_PRIMEPARTSNO = "primePartsNo";
        public const string COL_PRIMESEARCH_PRIMEPARTSNAME = "primePartsName";//追加
        public const string COL_PRIMESEARCH_PRIMEOLDPARTSNO = "primeOldPartsNo";
        public const string COL_PRIMESEARCH_SETPARTSFLG = "setPartsFlg";
        public const string COL_PRIMESEARCH_PRIMEPRICE = "primePrice";
        public const string COL_PRIMESEARCH_PRIMEQTY = "primeQty";
        public const string COL_PRIMESEARCH_PRIMESPECIALNOTE = "primeSpecialNote";
        public const string COL_PRIMESEARCH_MAKERDISPORDER = "makerDispOrder";
        public const string COL_PRIMESEARCH_PRIMEDISPORDER = "primeDispOrder";
        public const string COL_PRIMESEARCH_STPRODUCETYPEOFYEAR = "stProduceTypeOfYear";
        public const string COL_PRIMESEARCH_EDPRODUCETYPEOFYEAR = "edProduceTypeOfYear";
        public const string COL_PRIMESEARCH_STPRODUCEFRAMENO = "stProduceFrameNo";
        public const string COL_PRIMESEARCH_EDPRODUCEFRAMENO = "edProduceFrameNo";

        /// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        /// <returns>CarKindInfo用のDataTable</returns>
        public static DataTable CreateTable(string table_name)
        {
            DataTable wkTable = new DataTable(table_name);
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_SELECTED, typeof(int), "行選択"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_FULLMODELFIXEDNO, typeof(int), "フル型式固定番号"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_MIDDLEGENRECODE, typeof(string), "中分類コード"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_TBSPARTSCODE, typeof(int), "BLコード"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_TBSPARTSCDDERIVEDNO, typeof(int), "BLコード枝番"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_TBSPARTSCDDERIVEDNM, typeof(string), "BLコード枝番名称"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_SELECTCODE, typeof(int), "セレクトコード"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PRIMEKINDCODE, typeof(int), "種別コード"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PRIMESEARCHDISPORDER, typeof(int), "優良検索表示順位"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PARTSMAKERCD, typeof(int), "部品メーカー"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PARTSMAKERNAME, typeof(string), "部品メーカー名称"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PRIMEPARTSNO, typeof(string), "優良品番"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PRIMEPARTSNAME, typeof(string), "優良品名"));
			wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PRIMEOLDPARTSNO, typeof(string), "優良旧品番"));
			wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_SETPARTSFLG, typeof(int), "セット品番フラグ"));
			wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PRIMEPRICE, typeof(Int64), "優良標準価格"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PRIMEQTY, typeof(double), "優良QTY"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PRIMESPECIALNOTE, typeof(string), "優良特記事項"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_MAKERDISPORDER, typeof(int), "メーカー表示順位"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PRIMEDISPORDER, typeof(int), "優良設定表示順位"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_STPRODUCETYPEOFYEAR, typeof(int), "生産年式(開始)"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_EDPRODUCETYPEOFYEAR, typeof(int), "生産年式(終了)"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_STPRODUCEFRAMENO, typeof(int), "車台番号(開始)"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_EDPRODUCEFRAMENO, typeof(int), "車台番号(終了)"));

            return wkTable;
        }

        # endregion

    }
}
