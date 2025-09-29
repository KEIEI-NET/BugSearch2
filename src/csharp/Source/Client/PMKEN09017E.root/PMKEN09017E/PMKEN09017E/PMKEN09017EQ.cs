using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// UI用：部品カラー情報クラス
    /// </summary>
	public class PurePartsColorInfo : PartsSerchSub
    {

        # region DataTable 定義
        public const string TABLENAME_PRTCLR = "TABLENAME_PARTSCOLOR";

		// 実際のメンバを記述
        public const string COL_PRTCLR_PARTSUNIQUENO = "partsproperno";
        public const string COL_PRTCLR_COLORCODE = "ColorCode";
        public const string COL_PRTCLR_COLORNAME1 = "ColorName1";
        public const string COL_PRTCLR_SELECTED = "Col_Selected";

		/// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);
			wkTable.Columns.Add(CreateColumn(COL_PRTCLR_PARTSUNIQUENO, typeof(Int64), "部品固有番号"));
            wkTable.Columns.Add(CreateColumn(COL_PRTCLR_COLORCODE, typeof(string), "カラーコード"));
            wkTable.Columns.Add(CreateColumn(COL_PRTCLR_COLORNAME1, typeof(string), "カラー名称"));
            wkTable.Columns.Add(CreateColumn(COL_PRTCLR_SELECTED, typeof(string), "選択"));

            return wkTable;
        }


        # endregion

    }

    /// <summary>
    /// UI用：部品トリム情報クラス
    /// </summary>
    public class PurePartsTrimInfo : PartsSerchSub
    {

        # region DataTable 定義
        public const string TABLENAME_PRTTRM = "TABLENAME_PARTSTRIM";

        // 実際のメンバを記述
        public const string COL_PRTTRM_PARTSUNIQUENO = "partsproperno";
        public const string COL_PRTTRM_TRIMCODE = "TrimCode";
        public const string COL_PRTTRM_TRIMNAME = "TrimName";
        public const string COL_PRTTRM_SELECTED = "Col_Selected";

        /// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        public static DataTable CreateTable(string tbl_name)
        {
            DataTable wkTable = new DataTable(tbl_name);
			wkTable.Columns.Add(CreateColumn(COL_PRTTRM_PARTSUNIQUENO, typeof(Int64), "部品固有番号"));
            wkTable.Columns.Add(CreateColumn(COL_PRTTRM_TRIMCODE, typeof(string), "トリムコード"));
            wkTable.Columns.Add(CreateColumn(COL_PRTTRM_TRIMNAME, typeof(string), "トリム名称"));
            wkTable.Columns.Add(CreateColumn(COL_PRTTRM_SELECTED, typeof(string), "選択"));

            return wkTable;
        }


        # endregion

    }

    /// <summary>
    /// UI用：部品カラー情報クラス
    /// </summary>
    public class PurePartsEquipInfo : PartsSerchSub
    {

        # region DataTable 定義
        public const string TABLENAME_PRTEQP = "TABLENAME_PARTSEQUIP";

        // 実際のメンバを記述
        public const string COL_PRTEQP_PARTSUNIQUENO = "partsproperno";
        public const string COL_PRTEQP_EQUIPMENTCODE = "EquipmentCode";
        public const string COL_PRTEQP_EQUIPMENTDISPORDER = "EquipmentDispOrder";
        public const string COL_PRTEQP_EQUIPMENTGENRECD = "EquipmentGenreCd";
        public const string COL_PRTEQP_EQUIPMENTGENRENM = "EquipmentGenreNm";
        public const string COL_PRTEQP_EQUIPMENTICONCODE = "EquipmentIconCode";
        public const string COL_PRTEQP_EQUIPMENTNAME = "EquipmentName";
        public const string COL_PRTEQP_EQUIPMENTSHORTNAME = "EquipmentShortName";
        public const string COL_PRTEQP_SELECTED = "Col_Selected";

        /// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        public static DataTable CreateTable(string tbl_name)
        {
            DataTable wkTable = new DataTable(tbl_name);
			wkTable.Columns.Add(CreateColumn(COL_PRTEQP_PARTSUNIQUENO, typeof(Int64), "部品固有番号"));
            wkTable.Columns.Add(CreateColumn(COL_PRTEQP_EQUIPMENTCODE, typeof(string), "装備コード"));
            wkTable.Columns.Add(CreateColumn(COL_PRTEQP_EQUIPMENTDISPORDER, typeof(int), "表示順位"));
            wkTable.Columns.Add(CreateColumn(COL_PRTEQP_EQUIPMENTGENRECD, typeof(string), "装備分類コード"));
            wkTable.Columns.Add(CreateColumn(COL_PRTEQP_EQUIPMENTSHORTNAME, typeof(string), "装備略称"));
            wkTable.Columns.Add(CreateColumn(COL_PRTEQP_EQUIPMENTGENRENM, typeof(string), "装備分類名"));
            wkTable.Columns.Add(CreateColumn(COL_PRTEQP_EQUIPMENTNAME, typeof(string), "装備名称"));
            wkTable.Columns.Add(CreateColumn(COL_PRTEQP_EQUIPMENTICONCODE, typeof(string), "アイコンコード"));

            return wkTable;
        }


        # endregion

    }

}
