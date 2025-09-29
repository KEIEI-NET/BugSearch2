using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// ユーザー結合検索：代替情報情報クラス
    /// </summary>
	public class UsrPartsSubstInfo : PartsSerchSub
    {
        # region DataTable 定義
		//代替情報
		public const string USRPARTSSUBSTINFO_TBL_NAME = "UsrPartsSubstInfo";

		//ＵＩテーブル情報＜純正品番→代替品番＞
		public const string UISUBSTPARTSINFO_TBL_NAME = "UiSubstPartsInfo";

		//ＵＩテーブル情報＜結合品番→代替品番＞
		public const string UIJOINSUBSTPARTSINFO_TBL_NAME = "UiJoinSubstPartsInfo";

		//ＵＩテーブル情報＜セット品番→代替品番＞
		public const string UISETSUBSTPARTSINFO_TBL_NAME = "UiSetSubstPartsInfo";

        // 選択状態を示すフラグ
        public const string COL_SELECTED = "Selected";
        // 実際のメンバを記述
		public const string COL_MAKERCODE = "MakerCode";
		public const string COL_PRTSNOWITHHYPHEN = "PrtsNoWithHyphen";
		public const string COL_SUBSTORDER = "SubstOrder";
		public const string COL_SUBSTSORMAKERCD = "SubstSorMakerCd";
		public const string COL_SUBSTSORPARTSNO = "SubstSorPartsNo";
		public const string COL_SUBSTDESTMAKERCD = "SubstDestMakerCd";
		public const string COL_SUBSTDESTPARTSNO = "SubstDestPartsNo";
		public const string COL_APPLYSTDATE = "ApplyStDate";
		public const string COL_APPLYEDDATE = "ApplyEdDate";

		//メンバCAPTION
		// 選択状態を示すフラグ
		public const string TIT_SELECTED = "選択状態";
		public const string TIT_MAKERCODE = "メーカーコード";
		public const string TIT_PRTSNOWITHHYPHEN = "ハイフン付部品品番";
		public const string TIT_SUBSTORDER = "代替順位";
		public const string TIT_SUBSTSORMAKERCD = "代替元メーカーコード";
		public const string TIT_SUBSTSORPARTSNO = "代替元品番(-付品番)";
		public const string TIT_SUBSTDESTMAKERCD = "代替先メーカーコード";
		public const string TIT_SUBSTDESTPARTSNO = "代替先品番(-付品番)";
		public const string TIT_APPLYSTDATE = "適用開始年月日";
		public const string TIT_APPLYEDDATE = "適用終了年月日";

        /// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        /// <returns>CarKindInfo用のDataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_SELECTED, typeof(int), TIT_SELECTED));

			wkTable.Columns.Add(CreateColumn(COL_MAKERCODE, typeof(Int32), TIT_MAKERCODE));
			wkTable.Columns.Add(CreateColumn(COL_PRTSNOWITHHYPHEN, typeof(string), TIT_PRTSNOWITHHYPHEN));
			wkTable.Columns.Add(CreateColumn(COL_SUBSTORDER, typeof(Int32), TIT_SUBSTORDER));
			wkTable.Columns.Add(CreateColumn(COL_SUBSTDESTMAKERCD, typeof(Int32), TIT_SUBSTDESTMAKERCD));
			wkTable.Columns.Add(CreateColumn(COL_SUBSTDESTPARTSNO, typeof(string), TIT_SUBSTDESTPARTSNO));
			wkTable.Columns.Add(CreateColumn(COL_APPLYSTDATE, typeof(Int32), TIT_APPLYSTDATE));
			wkTable.Columns.Add(CreateColumn(COL_APPLYEDDATE, typeof(Int32), TIT_APPLYEDDATE));

            return wkTable;
        }

		/// <summary>
		/// 指定の行にデータをセット＜ユーザー結合検索:代替情報＞
		/// </summary>
		/// <returns>セット後のデータ行</returns>
		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_MAKERCODE] = sourcedr[COL_MAKERCODE];
			dr[COL_PRTSNOWITHHYPHEN] = sourcedr[COL_PRTSNOWITHHYPHEN];
			dr[COL_SUBSTORDER] = sourcedr[COL_SUBSTORDER];
			dr[COL_SUBSTDESTMAKERCD] = sourcedr[COL_SUBSTDESTMAKERCD];
			dr[COL_SUBSTDESTPARTSNO] = sourcedr[COL_SUBSTDESTPARTSNO];
			dr[COL_APPLYSTDATE] = sourcedr[COL_APPLYSTDATE];
			dr[COL_APPLYEDDATE] = sourcedr[COL_APPLYEDDATE];
			return dr;
		}


		# endregion

    }
}
