using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// 提供：部品情報クラス
    /// </summary>
	public class OfrPartsInfo : PartsSerchSub
    {
        # region DataTable 定義
		public const string TABLENAME_PARTS = "TABLENAME_PARTS";
		public const string TABLENAME_PARTSDETAIL = "TABLENAME_PARTSDETAIL";

        // 実際のメンバを記述
		/// <summary>部品検索区分</summary>
		public const string COL_PARTS_PARTSSEARCHCODE = "PartsSearchCode";
		/// <summary>部品絞込み区分</summary>
		public const string COL_PARTS_PARTSNARROWINGCODE = "PartsNarrowingCode";
		/// <summary>部品名称</summary>
		public const string COL_PARTS_PARTSNAME = "partsName";
		/// <summary>部品区分コード</summary>
		public const string COL_PARTS_PARTSCODE = "partsCode";
		/// <summary>作業部品区分名称</summary>
		public const string COL_PARTS_WORKORPARTSDIVNM = "workOrPartsDivNm";
		/// <summary>フル型式固定番号</summary>
		public const string COL_PARTS_FULLMODELFIXEDNO = "fullModelFixedNo";
		/// <summary>BLコード</summary>
		public const string COL_PARTS_TBSPARTSCODE = "tbsPartsCode";
		/// <summary>BLコード枝番</summary>
		public const string COL_PARTS_TBSPARTSCDDERIVEDNO = "tbsPartsCdDerivedNo";
		/// <summary>BLコード枝番用部品名称</summary>
		public const string COL_PARTS_TBSPARTSCDDERIVEDNM = "tbsPartsCdDerivedNm";
		/// <summary>Fig図番</summary>
		public const string COL_PARTS_FIGSHAPENO = "figshapeNo";
		/// <summary>図番内行番号</summary>
		public const string COL_PARTS_SHAPENOINSIDEROWNO = "shapeNoInsideRowNo";
		/// <summary>型式別部品採用年月</summary>
		public const string COL_PARTS_MODELPRTSADPTYM = "modelPrtsAdptYm";
		/// <summary>型式別部品廃止年月</summary>
		public const string COL_PARTS_MODELPRTSABLSYM = "modelPrtsAblsYm";
		/// <summary>型式別部品採用車台番号</summary>
		public const string COL_PARTS_MODELPRTSADPTFRAMENO = "modelPrtsAdptFrameNo";
		/// <summary>型式別部品廃止車台番号</summary>
		public const string COL_PARTS_MODELPRTSABLSFRAMENO = "modelPrtsAblsFrameNo";
		/// <summary>部品QTY</summary>
		public const string COL_PARTS_PARTSQTY = "partsQty";
		/// <summary>部品オプション名称</summary>
		public const string COL_PARTS_PARTSOPNM = "partsOpNm";
		/// <summary>規格名称</summary>
		public const string COL_PARTS_STANDARDNAME = "standardName";
		/// <summary>カタログ部品メーカーコード</summary>
		public const string COL_PARTS_CATALOGPARTSMAKERCD = "catalogPartsMakerCd";
		/// <summary>カタログ部品メーカーコード</summary>
		public const string COL_PARTS_CATALOGPARTSMAKERNM = "catalogPartsMakerNm";
	
		/// <summary>ハイフン付カタログ部品品番</summary>
		public const string COL_PARTS_CLGPRTSNOWITHHYPHEN = "clgPrtsNoWithHyphen";
		/// <summary>寒冷地フラグ</summary>
		public const string COL_PARTS_COLDDISTRICTSFLAG = "coldDistrictsFlag";
		/// <summary>カラー絞込フラグ</summary>
		public const string COL_PARTS_COLORNARROWINGFLAG = "colorNarrowingFlag";
		/// <summary>トリム絞込フラグ</summary>
		public const string COL_PARTS_TRIMNARROWINGFLAG = "trimNarrowingFlag";
		/// <summary>装備絞込フラグ</summary>
		public const string COL_PARTS_EQUIPNARROWINGFLAG = "equipNarrowingFlag";
		/// <summary>ハイフン付最新部品品番</summary>
		public const string COL_PARTS_NEWPRTSNOWITHHYPHEN = "newPrtsNoWithHyphen";
		/// <summary>ハイフン無最新部品品番</summary>
		public const string COL_PARTS_NEWPRTSNONONEHYPHEN = "newPrtsNoNoneHyphen";
		/// <summary>メーカー別部品名称</summary>
		public const string COL_PARTS_MAKEROFFERPARTSNAME = "makerOfferPartsName";
		/// <summary>部品価格</summary>
		public const string COL_PARTS_PARTSPRICE = "partsPrice";
		/// <summary>層別コード</summary>
		public const string COL_PARTS_PARTSLAYERCD = "partsLayerCd";
		/// <summary>部品固有番号</summary>
		public const string COL_PARTS_PARTSUNIQUENO = "PartsUniqueNo";

		public const string COL_PARTS_SELECTED = "Col_Selected";

		/// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        /// <returns>CarKindInfo用のDataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_PARTS_PARTSSEARCHCODE, typeof(int), "部品検索区分"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_PARTSNARROWINGCODE, typeof(int), "部品絞込み区分"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_PARTSNAME, typeof(string), "部品名称"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_PARTSCODE, typeof(int), "部品区分コード"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_WORKORPARTSDIVNM, typeof(string), "作業部品区分名称"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_FULLMODELFIXEDNO, typeof(int), "フル型式固定番号"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_TBSPARTSCODE, typeof(int), "BLコード"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_TBSPARTSCDDERIVEDNO, typeof(int), "BLコード枝番"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_TBSPARTSCDDERIVEDNM, typeof(string), "BLコード枝番用部品名称"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_FIGSHAPENO, typeof(string), "Fig図番"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_SHAPENOINSIDEROWNO, typeof(int), "図番内行番号"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_MODELPRTSADPTYM, typeof(int), "型式別部品採用年月"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_MODELPRTSABLSYM, typeof(int), "型式別部品廃止年月"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_MODELPRTSADPTFRAMENO, typeof(int), "型式別部品採用車台番号"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_MODELPRTSABLSFRAMENO, typeof(int), "型式別部品廃止車台番号"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_PARTSQTY, typeof(double), "部品QTY"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_PARTSOPNM, typeof(string), "部品オプション名称"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_STANDARDNAME, typeof(string), "規格名称"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_CATALOGPARTSMAKERCD, typeof(int), "カタログ部品メーカーコード"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_CATALOGPARTSMAKERNM, typeof(string), "カタログ部品メーカー名称"));


			wkTable.Columns.Add(CreateColumn(COL_PARTS_CLGPRTSNOWITHHYPHEN, typeof(string), "ハイフン付カタログ部品品番"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_COLDDISTRICTSFLAG, typeof(int), "寒冷地フラグ"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_COLORNARROWINGFLAG, typeof(int), "カラー絞込フラグ"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_TRIMNARROWINGFLAG, typeof(int), "トリム絞込フラグ"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_EQUIPNARROWINGFLAG, typeof(int), "装備絞込フラグ"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_NEWPRTSNOWITHHYPHEN, typeof(string), "ハイフン付最新部品品番"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_NEWPRTSNONONEHYPHEN, typeof(string), "ハイフン無最新部品品番"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_MAKEROFFERPARTSNAME, typeof(string), "メーカー別部品名称"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_PARTSPRICE, typeof(Int64), "部品価格"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_PARTSLAYERCD, typeof(string), "層別コード"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_PARTSUNIQUENO, typeof(Int64), "部品固有番号"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_SELECTED, typeof(int), "行選択"));

            return wkTable;
        }

		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_PARTS_PARTSSEARCHCODE] = sourcedr[COL_PARTS_PARTSSEARCHCODE];
			dr[COL_PARTS_PARTSNARROWINGCODE] = sourcedr[COL_PARTS_PARTSNARROWINGCODE];
			dr[COL_PARTS_PARTSNAME] = sourcedr[COL_PARTS_PARTSNAME];
			dr[COL_PARTS_PARTSCODE] = sourcedr[COL_PARTS_PARTSCODE];
			dr[COL_PARTS_WORKORPARTSDIVNM] = sourcedr[COL_PARTS_WORKORPARTSDIVNM];
			dr[COL_PARTS_FULLMODELFIXEDNO] = sourcedr[COL_PARTS_FULLMODELFIXEDNO];
			dr[COL_PARTS_TBSPARTSCODE] = sourcedr[COL_PARTS_TBSPARTSCODE];
			dr[COL_PARTS_TBSPARTSCDDERIVEDNO] = sourcedr[COL_PARTS_TBSPARTSCDDERIVEDNO];
			dr[COL_PARTS_TBSPARTSCDDERIVEDNM] = sourcedr[COL_PARTS_TBSPARTSCDDERIVEDNM];
			dr[COL_PARTS_FIGSHAPENO] = sourcedr[COL_PARTS_FIGSHAPENO];
			dr[COL_PARTS_SHAPENOINSIDEROWNO] = sourcedr[COL_PARTS_SHAPENOINSIDEROWNO];
			dr[COL_PARTS_MODELPRTSADPTYM] = sourcedr[COL_PARTS_MODELPRTSADPTYM];
			dr[COL_PARTS_MODELPRTSABLSYM] = sourcedr[COL_PARTS_MODELPRTSABLSYM];
			dr[COL_PARTS_MODELPRTSADPTFRAMENO] = sourcedr[COL_PARTS_MODELPRTSADPTFRAMENO];
			dr[COL_PARTS_MODELPRTSABLSFRAMENO] = sourcedr[COL_PARTS_MODELPRTSABLSFRAMENO];
			dr[COL_PARTS_PARTSQTY] = sourcedr[COL_PARTS_PARTSQTY];
			dr[COL_PARTS_PARTSOPNM] = sourcedr[COL_PARTS_PARTSOPNM];
			dr[COL_PARTS_STANDARDNAME] = sourcedr[COL_PARTS_STANDARDNAME];
			dr[COL_PARTS_CATALOGPARTSMAKERCD] = sourcedr[COL_PARTS_CATALOGPARTSMAKERCD];
			dr[COL_PARTS_CATALOGPARTSMAKERNM] = sourcedr[COL_PARTS_CATALOGPARTSMAKERNM];
			dr[COL_PARTS_CLGPRTSNOWITHHYPHEN] = sourcedr[COL_PARTS_CLGPRTSNOWITHHYPHEN];
			dr[COL_PARTS_COLDDISTRICTSFLAG] = sourcedr[COL_PARTS_COLDDISTRICTSFLAG];
			dr[COL_PARTS_COLORNARROWINGFLAG] = sourcedr[COL_PARTS_COLORNARROWINGFLAG];
			dr[COL_PARTS_TRIMNARROWINGFLAG] = sourcedr[COL_PARTS_TRIMNARROWINGFLAG];
			dr[COL_PARTS_EQUIPNARROWINGFLAG] = sourcedr[COL_PARTS_EQUIPNARROWINGFLAG];
			dr[COL_PARTS_NEWPRTSNOWITHHYPHEN] = sourcedr[COL_PARTS_NEWPRTSNOWITHHYPHEN];
			dr[COL_PARTS_NEWPRTSNONONEHYPHEN] = sourcedr[COL_PARTS_NEWPRTSNONONEHYPHEN];
			dr[COL_PARTS_MAKEROFFERPARTSNAME] = sourcedr[COL_PARTS_MAKEROFFERPARTSNAME];
			dr[COL_PARTS_PARTSPRICE] = sourcedr[COL_PARTS_PARTSPRICE];
			dr[COL_PARTS_PARTSLAYERCD] = sourcedr[COL_PARTS_PARTSLAYERCD];
			dr[COL_PARTS_PARTSUNIQUENO] = sourcedr[COL_PARTS_PARTSUNIQUENO];
			return dr;
		}


        # endregion

    }
}
