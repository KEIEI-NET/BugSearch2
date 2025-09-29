using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// 優良設定情報クラス
    /// </summary>
	public class PrimeSettingInfo : PartsSerchSub
    {

        # region DataTable 定義
        public const string TABLENAME_PRIMESETTING = "PrimeSetting_Table";
        public const string TABLENAME_OFFER_PRIMESETTING = "Offer_PrimeSetting_Table";
        public const string TABLENAME_USER_PRIMESETTING = "User_PrimeSetting_Table";

        /// <summary>中分類コード </summary>
        public const string COL_MIDDLEGENRECODE = "MiddleGenreCode";
        /// <summary>メーカーコード </summary>
        public const string COL_PARTSMAKERCD = "PartsMakerCd";
        /// <summary>BLコード </summary>
        public const string COL_TBSPARTSCODE = "TbsPartsCode";
        /// <summary>BLコード枝番</summary>
        public const string COL_TBSPARTSCDDERIVEDNO = "TbsPartsCdDerivedNo";

        /// <summary>中分類名称 </summary>
        public const string COL_MIDDLEGENRENAME = "MiddleGenreName";
        /// <summary>メーカー名称(全角) </summary>
        public const string COL_PARTSMAKERFULLNAME = "PartsMakerFullName";
        /// <summary>メーカー名称(半角) </summary>
        public const string COL_PARTSMAKERHALFNAME = "PartsMakerHalfName";
        /// <summary>BL部品名称 </summary>
        public const string COL_TBSPARTSFULLNAME = "TbsPartsFullName";
        /// <summary>BL部品名称(半角)</summary>
        public const string COL_TBSPARTSHALFNAME = "TbsPartsHalfName";
        /// <summary>シークレット区分</summary>
        /// <remarks>0:通常　1:シークレット</remarks>
        public const string COL_SECRETCODE = "SecretCode";
        /// <summary>表示順位</summary>
        public const string COL_DISPLAYORDER = "DisplayOrder";
        /// <summary>メーカー表示順位</summary>
        public const string COL_MAKERDISPORDER = "MakerDisplayOrder";
        /// <summary>セレクトコード</summary>
        public const string COL_SELECTCODE = "SelectCode";
        /// <summary>セレクト名称</summary>
        public const string COL_SELECTNAME = "SelectName";
        /// <summary>優良種別コード</summary>
        public const string COL_PRIMEKINDCODE = "PrimeKindCode";
        /// <summary>優良種別名称</summary>
        public const string COL_PRIMEKINDNAME = "PrimeKindName";
        /// <summary>仕入先コード</summary>
        public const string COL_SUPPLIERCD = "SupplierCd";
        /// <summary>仕入先コード</summary>
        public const string COL_SUPPLIERNAME = "SupplierName";
        /// <summary>仕入先コード枝番</summary>
        public const string COL_SUPPLIERCDDERIVEDNO = "SupplierCdDerivedNo";
        /// <summary>表示区分</summary>
        /// <remarks>0:無し　1:商品&結合　2:商品</remarks>
        public const string COL_PRIMEDISPLAYCODE = "PrimeDisplayCode";
        /// <summary>重要区分 </summary>
        public const string COL_IMPORTANTCODE = "ImportantCode";
        /// <summary>優良設定備考 </summary>
        public const string COL_PRIMESETTINGNOTE = "PrimeSettingNote";

        public const string COL_SUPPLIERGUIDE = "SupplierGuide";  // ADD 2008/07/04

        /// <summary>優良設定グループ</summary>
        public const string COL_PRMSETGROUP = "PrmSetGroup";    // ADD 2009/01/15

		/// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        /// <returns>CarKindInfo用のDataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_MIDDLEGENRECODE, typeof(int), "中分類コード"));
			wkTable.Columns.Add(CreateColumn(COL_TBSPARTSCODE, typeof(int), "BLコード"));
			wkTable.Columns.Add(CreateColumn(COL_TBSPARTSCDDERIVEDNO, typeof(int), "BLコード枝番"));
			wkTable.Columns.Add(CreateColumn(COL_PARTSMAKERCD, typeof(int), "メーカーコード"));
			wkTable.Columns.Add(CreateColumn(COL_SELECTCODE, typeof(int), "セレクトコード"));
			wkTable.Columns.Add(CreateColumn(COL_PRIMEKINDCODE, typeof(int), "優良種別コード"));
			wkTable.Columns.Add(CreateColumn(COL_PRIMEKINDNAME, typeof(string), "優良種別名称"));
			wkTable.Columns.Add(CreateColumn(COL_MAKERDISPORDER, typeof(Int32), "メーカー表示順位"));
			wkTable.Columns.Add(CreateColumn(COL_PRIMEDISPLAYCODE, typeof(int), "表示区分"));
			wkTable.Columns.Add(CreateColumn(COL_DISPLAYORDER, typeof(int), "表示順位"));

            return wkTable;
        }
/*
		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_YURYO_MIDDLEGENRECODE] = sourcedr[COL_YURYO_MIDDLEGENRECODE];
			dr[COL_YURYO_TBSPARTSCODE] = sourcedr[COL_YURYO_TBSPARTSCODE];
			dr[COL_YURYO_TBSPARTSCDDERIVEDNO] = sourcedr[COL_YURYO_TBSPARTSCDDERIVEDNO];
			dr[COL_YURYO_PARTSMAKERCD] = sourcedr[COL_YURYO_PARTSMAKERCD];
			dr[COL_YURYO_SELECTCODE] = sourcedr[COL_YURYO_SELECTCODE];
			dr[COL_YURYO_PRIMEKINDCODE] = sourcedr[COL_YURYO_PRIMEKINDCODE];
			dr[COL_YURYO_PRIMEKINDNAME] = sourcedr[COL_YURYO_PRIMEKINDNAME];
			dr[COL_YURYO_PRIMEDISPLAYCODE] = sourcedr[COL_YURYO_PRIMEDISPLAYCODE];
			dr[COL_YURYO_MAKERDISPORDER] = sourcedr[COL_YURYO_MAKERDISPORDER];
			dr[COL_YURYO_DISPLAYORDER] = sourcedr[COL_YURYO_DISPLAYORDER];
			return dr;
		}
        */
        # endregion

    }
}
