using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// ユーザー結合検索：商品情報クラス
    /// </summary>
	public class UsrGoodsInfo : PartsSerchSub
    {

        # region DataTable 定義
		//商品情報：ユーザー結合検索用
		public const string JN_USRGOODSINFO_TBL_NAME = "JN_UsrGoodsInfo";

		//商品情報：ユーザー部品検索用
		public const string PT_USRGOODSINFO_TBL_NAME = "PT_UsrGoodsInfo";

        //商品情報：ユーザー部品検索用
        public const string PT_OFRPUREPARTSINFO_TBL_NAME = "PT_OfrPurePartsInfo";

        //商品情報：ユーザー部品検索用
        public const string PT_OFRPRIMEPARTSINFO_TBL_NAME = "PT_OfrPrimePartsInfo";

		//ユーザー品番検索：ＵＩテーブル情報＜商品＞
		public const string UIUSRJOINPARTSINFO_TBL_NAME = "UiUsrJoinPartsInfo";

		// 選択状態を示すフラグ
        public const string COL_SELECTED = "Selected";
        // 実際のメンバを記述
		public const string COL_MAKERCD = "MakerCd";
        public const string COL_MAKERNAME = "MakerName";
        public const string COL_GOODSNOWITHHYP = "GoodsNoWithHyp";
		public const string COL_GOODSNONONEHYP = "GoodsNoNoneHyp";
		public const string COL_GOODSNAME = "GoodsName";
		public const string COL_MIDDLEGENRECODE = "MiddleGenreCode";
		public const string COL_TBSPARTSCODE = "TbsPartsCode";
		public const string COL_LISTPRICE = "ListPrice";
		public const string COL_GOODSLAYERCD = "GoodsLayerCd";
		public const string COL_GOODSSPECIALNOTE = "GoodsSpecialNote";
		public const string COL_OFFERDATE = "OfferDate";
		public const string COL_NEWLISTPRICE = "NewListPrice";
		public const string COL_NEWLISTPRICEAPPLYDATE = "NewListPriceApplyDate";
		public const string COL_PARTSCODE = "PartsCode";
		public const string COL_GOODSCODE = "GoodsCode";
		public const string COL_TAXATIONCODE = "TaxationCode";
		public const string COL_GOODSNOTE1 = "GoodsNote1";
		public const string COL_GOODSNOTE2 = "GoodsNote2";

		//メンバCAPTION
		// 選択状態を示すフラグ
		public const string TIT_SELECTED = "選択状態";

		public const string TIT_MAKERCD = "メーカーコード";
        public const string TIT_MAKERNAME = "メーカー名称";
        public const string TIT_GOODSNOWITHHYP = "商品品番（ハイフン付き）";
		public const string TIT_GOODSNONONEHYP = "商品品番（ハイフン無し）";
		public const string TIT_GOODSNAME = "商品名称";
		public const string TIT_MIDDLEGENRECODE = "中分類コード";
		public const string TIT_TBSPARTSCODE = "BLコード";
		public const string TIT_LISTPRICE = "定価";
		public const string TIT_GOODSLAYERCD = "層別コード";
		public const string TIT_GOODSSPECIALNOTE = "商品規格・特記事項";
		public const string TIT_OFFERDATE = "データ提供日付";
		public const string TIT_NEWLISTPRICE = "新定価";
		public const string TIT_NEWLISTPRICEAPPLYDATE = "新定価適用日付";
		public const string TIT_PARTSCODE = "部品区分";
		public const string TIT_GOODSCODE = "商品区分 ";
		public const string TIT_TAXATIONCODE = "税区分";
		public const string TIT_GOODSNOTE1 = "商品備考1";
		public const string TIT_GOODSNOTE2 = "商品備考2";

		/// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        /// <returns>CarKindInfo用のDataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_SELECTED, typeof(int), TIT_SELECTED));

			wkTable.Columns.Add(CreateColumn(COL_MAKERCD, typeof(Int32), TIT_MAKERCD));
            wkTable.Columns.Add(CreateColumn(COL_MAKERNAME, typeof(string), TIT_MAKERNAME));
            wkTable.Columns.Add(CreateColumn(COL_GOODSNOWITHHYP, typeof(string), TIT_GOODSNOWITHHYP));
			wkTable.Columns.Add(CreateColumn(COL_GOODSNONONEHYP, typeof(string), TIT_GOODSNONONEHYP));
			wkTable.Columns.Add(CreateColumn(COL_GOODSNAME, typeof(string), TIT_GOODSNAME));
			wkTable.Columns.Add(CreateColumn(COL_MIDDLEGENRECODE, typeof(Int32), TIT_MIDDLEGENRECODE));
			wkTable.Columns.Add(CreateColumn(COL_TBSPARTSCODE, typeof(Int32), TIT_TBSPARTSCODE));
			wkTable.Columns.Add(CreateColumn(COL_LISTPRICE, typeof(Int64), TIT_LISTPRICE));
			wkTable.Columns.Add(CreateColumn(COL_GOODSLAYERCD, typeof(string), TIT_GOODSLAYERCD));
			wkTable.Columns.Add(CreateColumn(COL_GOODSSPECIALNOTE, typeof(string), TIT_GOODSSPECIALNOTE));
			wkTable.Columns.Add(CreateColumn(COL_OFFERDATE, typeof(Int32), TIT_OFFERDATE));
			wkTable.Columns.Add(CreateColumn(COL_NEWLISTPRICE, typeof(Int64), TIT_NEWLISTPRICE));
			wkTable.Columns.Add(CreateColumn(COL_NEWLISTPRICEAPPLYDATE, typeof(Int32), TIT_NEWLISTPRICEAPPLYDATE));
			wkTable.Columns.Add(CreateColumn(COL_PARTSCODE, typeof(Int32), TIT_PARTSCODE));
			wkTable.Columns.Add(CreateColumn(COL_GOODSCODE, typeof(Int32), TIT_GOODSCODE));
			wkTable.Columns.Add(CreateColumn(COL_TAXATIONCODE, typeof(Int32), TIT_TAXATIONCODE));
			wkTable.Columns.Add(CreateColumn(COL_GOODSNOTE1, typeof(string), TIT_GOODSNOTE1));
			wkTable.Columns.Add(CreateColumn(COL_GOODSNOTE2, typeof(string), TIT_GOODSNOTE2));

            return wkTable;
        }

		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_MAKERCD] = sourcedr[COL_MAKERCD];
			dr[COL_GOODSNOWITHHYP] = sourcedr[COL_GOODSNOWITHHYP];
			dr[COL_GOODSNAME] = sourcedr[COL_GOODSNAME];
			dr[COL_TBSPARTSCODE] = sourcedr[COL_TBSPARTSCODE];
			dr[COL_LISTPRICE] = sourcedr[COL_LISTPRICE];
			dr[COL_GOODSLAYERCD] = sourcedr[COL_GOODSLAYERCD];
			dr[COL_GOODSSPECIALNOTE] = sourcedr[COL_GOODSSPECIALNOTE];
			dr[COL_OFFERDATE] = sourcedr[COL_OFFERDATE];
			dr[COL_NEWLISTPRICE] = sourcedr[COL_NEWLISTPRICE];
			dr[COL_NEWLISTPRICEAPPLYDATE] = sourcedr[COL_NEWLISTPRICEAPPLYDATE];
			//dr[COL_OFFERCODE] = OfferCode;

			return dr;
		}


        # endregion

    }
}
