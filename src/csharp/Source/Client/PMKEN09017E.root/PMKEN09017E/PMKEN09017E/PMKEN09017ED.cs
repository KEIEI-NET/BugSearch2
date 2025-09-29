using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// ユーザー結合検索：セット情報クラス
    /// </summary>
	public class UsrSetPartsInfo : PartsSerchSub
    {

        # region DataTable 定義
		//セット情報
		public const string USRSETPARTSINFO_TBL_NAME = "UsrSetPartsInfo";

		//ＵＩテーブル情報＜セット品番＞
		public const string UISETPARTSINFO_TBL_NAME = "UiSetPartsInfo";

        // 選択状態を示すフラグ
        public const string COL_SELECTED = "Selected";
        // 実際のメンバを記述
		public const string COL_SETMAINMAKERCD = "SetMainMakerCd";
		public const string COL_SETMAINPARTSNO = "SetMainPartsNo";
		public const string COL_SETSUBMAKERCD = "SetSubMakerCd";
		public const string COL_SETSUBPARTSNO = "SetSubPartsNo";
		public const string COL_SETDISPORDER = "SetDispOrder";
		public const string COL_SETQTY = "SetQty";
		public const string COL_SETNAME = "SetName";
		public const string COL_SETSPECIALNOTE = "SetSpecialNote";
		public const string COL_CATALOGSHAPENO = "CatalogShapeNo";
        public const string COL_SETSUBPARTSNAME = "SetSubPartsName";
        public const string COL_SETSUBMAKERNAME = "SetSubMakerName";

		//メンバCAPTION
		// 選択状態を示すフラグ
		public const string TIT_SELECTED = "選択状態";

		public const string TIT_SETMAINMAKERCD = "セット親メーカーコード";
		public const string TIT_SETMAINPARTSNO = "セット親品番";
		public const string TIT_SETSUBMAKERCD = "セット子メーカーコード";
		public const string TIT_SETSUBPARTSNO = "セット子品番";
		public const string TIT_SETDISPORDER = "セット表示順位";
		public const string TIT_SETQTY = "セットQTY";
		public const string TIT_SETNAME = "セット名称";
		public const string TIT_SETSPECIALNOTE = "セット規格・特記事項";
		public const string TIT_CATALOGSHAPENO = "カタログ図番";
        public const string TIT_SET_SETSUBPARTSNAME = "セット子メーカー名";
        public const string TIT_SET_SETSUBMAKERNAME = "セット子部品名称";

        /// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        /// <returns>CarKindInfo用のDataTable</returns>
		public static DataTable CreateTable(string tbl_name)
		{
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_SELECTED, typeof(int), TIT_SELECTED));

			wkTable.Columns.Add(CreateColumn(COL_SETMAINMAKERCD, typeof(Int32), TIT_SETMAINMAKERCD));
			wkTable.Columns.Add(CreateColumn(COL_SETMAINPARTSNO, typeof(string), TIT_SETMAINPARTSNO));
			wkTable.Columns.Add(CreateColumn(COL_SETSUBMAKERCD, typeof(Int32), TIT_SETSUBMAKERCD));
			wkTable.Columns.Add(CreateColumn(COL_SETSUBPARTSNO, typeof(string), TIT_SETSUBPARTSNO));
			wkTable.Columns.Add(CreateColumn(COL_SETDISPORDER, typeof(Int32), TIT_SETDISPORDER));
			wkTable.Columns.Add(CreateColumn(COL_SETQTY, typeof(Double), TIT_SETQTY));
			wkTable.Columns.Add(CreateColumn(COL_SETNAME, typeof(string), TIT_SETNAME));
			wkTable.Columns.Add(CreateColumn(COL_SETSPECIALNOTE, typeof(string), TIT_SETSPECIALNOTE));
			wkTable.Columns.Add(CreateColumn(COL_CATALOGSHAPENO, typeof(string), TIT_CATALOGSHAPENO));
            wkTable.Columns.Add(CreateColumn(COL_SETSUBMAKERNAME, typeof(string), TIT_SET_SETSUBPARTSNAME));
            wkTable.Columns.Add(CreateColumn(COL_SETSUBPARTSNAME, typeof(string), TIT_SET_SETSUBMAKERNAME));

            return wkTable;
        }

		/// <summary>
		/// 指定の行にデータをセット＜ユーザー結合検索:セット情報＞
		/// </summary>
		/// <returns>セット後のデータ行</returns>
		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_SETMAINMAKERCD] = sourcedr[COL_SETMAINMAKERCD];
			dr[COL_SETMAINPARTSNO] = sourcedr[COL_SETMAINPARTSNO];
			dr[COL_SETSUBMAKERCD] = sourcedr[COL_SETSUBMAKERCD];
			dr[COL_SETSUBPARTSNO] = sourcedr[COL_SETSUBPARTSNO];
			dr[COL_SETDISPORDER] = sourcedr[COL_SETDISPORDER];
			dr[COL_SETQTY] = sourcedr[COL_SETQTY];
			dr[COL_SETNAME] = sourcedr[COL_SETNAME];
			dr[COL_SETSPECIALNOTE] = sourcedr[COL_SETSPECIALNOTE];
			dr[COL_CATALOGSHAPENO] = sourcedr[COL_CATALOGSHAPENO];
			return dr;
		}


        # endregion

    }
}
