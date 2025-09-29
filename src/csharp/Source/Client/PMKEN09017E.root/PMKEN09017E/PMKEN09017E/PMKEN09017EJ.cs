using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// 提供：代替情報クラス
    /// </summary>
	public class OfrSubstInfo : PartsSerchSub
    {
        # region DataTable 定義
		//代替
		public const string TABLENAME_SUBST = "TABLENAME_SUBST";

		//複数代替
		public const string TABLENAME_DSUBST = "TABLENAME_DSUBST";

        // 実際のメンバを記述
		/// <summary>カタログ部品メーカーコード</summary>
		public const string COL_SUBST_CATALOGPARTSMAKERCD = "catalogPartsMakerCd";
		/// <summary>カタログ部品メーカー名称</summary>
		public const string COL_SUBST_CATALOGPARTSMAKERNM = "catalogPartsMakerNm";
		/// <summary>ハイフン付旧品番</summary>
		public const string COL_SUBST_OLDPARTSNOWITHHYPHEN = "oldPartsNoWithHyphen";
		/// <summary>ハイフン付新品番</summary>
		public const string COL_SUBST_NEWPARTSNOWITHHYPHEN = "newPartsNoWithHyphen";
		/// <summary>ハイフン付新品番表示順位</summary>
		public const string COL_SUBST_NPRTNOWITHHYPNDSPODR = "nPrtNoWithHypnDspOdr";
		/// <summary>部品複数代替フラグ</summary>
		public const string COL_SUBST_PARTSPLURALSUBSTFLG = "partsPluralSubstFlg";
		/// <summary>メイン・サブ部品区分</summary>
		public const string COL_SUBST_MAINORSUBPARTSDIVCD = "mainOrSubPartsDivCd";
		/// <summary>部品QTY</summary>
		public const string COL_SUBST_PARTSQTY = "partsQty";
		/// <summary>部品複数代替摘要</summary>
		public const string COL_SUBST_PARTSPLURALSUBSTCMNT = "partsPluralSubstCmnt";
		/// <summary>複数代替元ハイフン付新品番</summary>
		public const string COL_SUBST_PLRLSUBNEWPRTNOHYPN = "plrlSubNewPrtNoHypn";
		/// <summary>ハイフン無最新部品品番</summary>
		public const string COL_SUBST_NEWPRTSNONONEHYPHEN = "newPrtsNoNoneHyphen";
		/// <summary>BL部品コード</summary>
		public const string COL_SUBST_TBSPARTSCODE = "tbsPartsCode";
		/// <summary>BL部品コード枝番</summary>
		public const string COL_SUBST_TBSPARTSCDDERIVEDNO = "tbsPartsCdDerivedNo";
		/// <summary>メーカー提供部品名称</summary>
		public const string COL_SUBST_MAKEROFFERPARTSNAME = "makerOfferPartsName";
		/// <summary>部品価格</summary>
		public const string COL_SUBST_PARTSPRICE = "partsPrice";
		/// <summary>層別コード</summary>
		public const string COL_SUBST_PARTSLAYERCD = "partsLayerCd";
		/// <summary>部品情報制御フラグ</summary>
		public const string COL_SUBST_PARTSINFOCTRLFLG = "partsInfoCtrlFlg";
		/// <summary>部品名称</summary>
		public const string COL_SUBST_PARTSNAME = "partsName";
		/// <summary>部品区分コード</summary>
		public const string COL_SUBST_PARTSCODE = "partsCode";
		/// <summary>部品検索区分</summary>
		public const string COL_SUBST_PARTSSEARCHCODE = "partsSearchCode";


		public const string COL_PARTS_SELECTED = "Col_Selected";

		/// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        /// <returns>CarKindInfo用のDataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_SUBST_CATALOGPARTSMAKERCD, typeof(int), "カタログ部品メーカーコード"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_CATALOGPARTSMAKERNM, typeof(string), "カタログ部品メーカー名称"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_OLDPARTSNOWITHHYPHEN, typeof(string), "ハイフン付旧品番"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_NEWPARTSNOWITHHYPHEN, typeof(string), "ハイフン付新品番"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_NPRTNOWITHHYPNDSPODR, typeof(int), "ハイフン付新品番表示順位"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PARTSPLURALSUBSTFLG, typeof(int), "部品複数代替フラグ"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_MAINORSUBPARTSDIVCD, typeof(int), "メイン・サブ部品区分"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PARTSQTY, typeof(double), "部品QTY"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PARTSPLURALSUBSTCMNT, typeof(string), "部品複数代替摘要"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PLRLSUBNEWPRTNOHYPN, typeof(string), "複数代替元ハイフン付新品番"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_NEWPRTSNONONEHYPHEN, typeof(string), "ハイフン無最新部品品番"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_TBSPARTSCODE, typeof(int), "BL部品コード"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_TBSPARTSCDDERIVEDNO, typeof(int), "BL部品コード枝番"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_MAKEROFFERPARTSNAME, typeof(string), "メーカー提供部品名称"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PARTSPRICE, typeof(Int64), "部品価格"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PARTSLAYERCD, typeof(string), "層別コード"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PARTSINFOCTRLFLG, typeof(int), "部品情報制御フラグ"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PARTSNAME, typeof(string), "部品名称"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PARTSCODE, typeof(int), "部品区分コード"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PARTSSEARCHCODE, typeof(int), "部品検索区分"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_SELECTED, typeof(int), "行選択"));

            return wkTable;
        }

		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_SUBST_CATALOGPARTSMAKERCD] = sourcedr[COL_SUBST_CATALOGPARTSMAKERCD];
			dr[COL_SUBST_CATALOGPARTSMAKERCD] = sourcedr[COL_SUBST_CATALOGPARTSMAKERNM];
			dr[COL_SUBST_OLDPARTSNOWITHHYPHEN] = sourcedr[COL_SUBST_OLDPARTSNOWITHHYPHEN];
			dr[COL_SUBST_NEWPARTSNOWITHHYPHEN] = sourcedr[COL_SUBST_NEWPARTSNOWITHHYPHEN];
			dr[COL_SUBST_NPRTNOWITHHYPNDSPODR] = sourcedr[COL_SUBST_NPRTNOWITHHYPNDSPODR];
			dr[COL_SUBST_PARTSPLURALSUBSTFLG] = sourcedr[COL_SUBST_PARTSPLURALSUBSTFLG];
			dr[COL_SUBST_MAINORSUBPARTSDIVCD] = sourcedr[COL_SUBST_MAINORSUBPARTSDIVCD];
			dr[COL_SUBST_PARTSQTY] = sourcedr[COL_SUBST_PARTSQTY];
			dr[COL_SUBST_PARTSPLURALSUBSTCMNT] = sourcedr[COL_SUBST_PARTSPLURALSUBSTCMNT];
			dr[COL_SUBST_PLRLSUBNEWPRTNOHYPN] = sourcedr[COL_SUBST_PLRLSUBNEWPRTNOHYPN];
			dr[COL_SUBST_NEWPRTSNONONEHYPHEN] = sourcedr[COL_SUBST_NEWPRTSNONONEHYPHEN];
			dr[COL_SUBST_TBSPARTSCODE] = sourcedr[COL_SUBST_TBSPARTSCODE];
			dr[COL_SUBST_TBSPARTSCDDERIVEDNO] = sourcedr[COL_SUBST_TBSPARTSCDDERIVEDNO];
			dr[COL_SUBST_MAKEROFFERPARTSNAME] = sourcedr[COL_SUBST_MAKEROFFERPARTSNAME];
			dr[COL_SUBST_PARTSPRICE] = sourcedr[COL_SUBST_PARTSPRICE];
			dr[COL_SUBST_PARTSLAYERCD] = sourcedr[COL_SUBST_PARTSLAYERCD];
			dr[COL_SUBST_PARTSINFOCTRLFLG] = sourcedr[COL_SUBST_PARTSINFOCTRLFLG];
			dr[COL_SUBST_PARTSNAME] = sourcedr[COL_SUBST_PARTSNAME];
			dr[COL_SUBST_PARTSCODE] = sourcedr[COL_SUBST_PARTSCODE];
			dr[COL_SUBST_PARTSSEARCHCODE] = sourcedr[COL_SUBST_PARTSSEARCHCODE];
			return dr;
		}


        # endregion

    }
}
