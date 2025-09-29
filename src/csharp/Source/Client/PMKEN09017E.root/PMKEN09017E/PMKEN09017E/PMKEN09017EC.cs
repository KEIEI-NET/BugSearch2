using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// ユーザー結合検索：結合情報クラス
    /// </summary>
	public class UsrJoinPartsInfo : PartsSerchSub
    {

        # region DataTable 定義
		//結合情報
		public const string USRJOINPARTSINFO_TBL_NAME = "UsrJoinPartsInfo";

		//ＵＩテーブル情報＜代替品番→結合品番＞
		public const string UISUBSTJOINPARTSINFO_TBL_NAME = "UiSubstJoinPartsInfo";

        // 選択状態を示すフラグ
        public const string COL_SELECTED = "Selected";
        // 実際のメンバを記述
		public const string COL_JOINDISPORDER = "JoinDispOrder";
		public const string COL_JOINSOURCEMAKERCODE = "JoinSourceMakerCode";
		public const string COL_JOINSOURPARTSNOWITHH = "JoinSourPartsNoWithH";
		public const string COL_JOINSOURPARTSNONONEH = "JoinSourPartsNoNoneH";
		public const string COL_JOINDESTMAKERCD = "JoinDestMakerCd";
		public const string COL_JOINDESTPARTSNO = "JoinDestPartsNo";
		public const string COL_JOINQTY = "JoinQty";
		public const string COL_JOINSPECIALNOTE = "JoinSpecialNote";
		public const string COL_JOINOFFERDATE = "JoinOfferDate";

		//メンバCAPTION
		// 選択状態を示すフラグ
		public const string TIT_SELECTED = "選択状態";

		public const string TIT_JOINDISPORDER = "結合表示順位";
		public const string TIT_JOINSOURCEMAKERCODE = "結合元メーカーコード";
		public const string TIT_JOINSOURPARTSNOWITHH = "結合元品番(－付き品番)";
		public const string TIT_JOINSOURPARTSNONONEH = "結合元品番(－無し品番)";
		public const string TIT_JOINDESTMAKERCD = "結合先メーカーコード";
		public const string TIT_JOINDESTPARTSNO = "結合先品番(－付き品番)";
		public const string TIT_JOINQTY = "結合QTY";
		public const string TIT_JOINSPECIALNOTE = "結合規格・特記事項";
		public const string TIT_JOINOFFERDATE = "結合データ提供日付";

        /// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        /// <returns>CarKindInfo用のDataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_SELECTED, typeof(int), TIT_SELECTED));

			wkTable.Columns.Add(CreateColumn(COL_JOINDISPORDER, typeof(Int32), TIT_JOINDISPORDER));
			wkTable.Columns.Add(CreateColumn(COL_JOINSOURCEMAKERCODE, typeof(Int32), TIT_JOINSOURCEMAKERCODE));
			wkTable.Columns.Add(CreateColumn(COL_JOINSOURPARTSNOWITHH, typeof(string), TIT_JOINSOURPARTSNOWITHH));
			wkTable.Columns.Add(CreateColumn(COL_JOINSOURPARTSNONONEH, typeof(string), TIT_JOINSOURPARTSNONONEH));
			wkTable.Columns.Add(CreateColumn(COL_JOINDESTMAKERCD, typeof(Int32), TIT_JOINDESTMAKERCD));
			wkTable.Columns.Add(CreateColumn(COL_JOINDESTPARTSNO, typeof(string), TIT_JOINDESTPARTSNO));
			wkTable.Columns.Add(CreateColumn(COL_JOINQTY, typeof(Double), TIT_JOINQTY));
			wkTable.Columns.Add(CreateColumn(COL_JOINSPECIALNOTE, typeof(string), TIT_JOINSPECIALNOTE));
			wkTable.Columns.Add(CreateColumn(COL_JOINOFFERDATE, typeof(Int32), TIT_JOINOFFERDATE));

			return wkTable;
        }

		/// <summary>
		/// 指定の行にデータをセット＜ユーザー結合検索:結合情報＞
		/// </summary>
		/// <returns>セット後のデータ行</returns>
		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_JOINDISPORDER] = sourcedr[COL_JOINDISPORDER];
			dr[COL_JOINSOURCEMAKERCODE] = sourcedr[COL_JOINSOURCEMAKERCODE];
			dr[COL_JOINSOURPARTSNOWITHH] = sourcedr[COL_JOINSOURPARTSNOWITHH];
			dr[COL_JOINSOURPARTSNONONEH] = sourcedr[COL_JOINSOURPARTSNONONEH];
			dr[COL_JOINDESTMAKERCD] = sourcedr[COL_JOINDESTMAKERCD];
			dr[COL_JOINDESTPARTSNO] = sourcedr[COL_JOINDESTPARTSNO];
			dr[COL_JOINQTY] = sourcedr[COL_JOINQTY];
			dr[COL_JOINSPECIALNOTE] = sourcedr[COL_JOINSPECIALNOTE];
			dr[COL_JOINOFFERDATE] = sourcedr[COL_JOINOFFERDATE];
			return dr;
		}


        # endregion

    }
}
