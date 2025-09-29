using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// UI�p�F���i�J���[���N���X
    /// </summary>
	public class PurePartsColorInfo : PartsSerchSub
    {

        # region DataTable ��`
        public const string TABLENAME_PRTCLR = "TABLENAME_PARTSCOLOR";

		// ���ۂ̃����o���L�q
        public const string COL_PRTCLR_PARTSUNIQUENO = "partsproperno";
        public const string COL_PRTCLR_COLORCODE = "ColorCode";
        public const string COL_PRTCLR_COLORNAME1 = "ColorName1";
        public const string COL_PRTCLR_SELECTED = "Col_Selected";

		/// <summary>
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);
			wkTable.Columns.Add(CreateColumn(COL_PRTCLR_PARTSUNIQUENO, typeof(Int64), "���i�ŗL�ԍ�"));
            wkTable.Columns.Add(CreateColumn(COL_PRTCLR_COLORCODE, typeof(string), "�J���[�R�[�h"));
            wkTable.Columns.Add(CreateColumn(COL_PRTCLR_COLORNAME1, typeof(string), "�J���[����"));
            wkTable.Columns.Add(CreateColumn(COL_PRTCLR_SELECTED, typeof(string), "�I��"));

            return wkTable;
        }


        # endregion

    }

    /// <summary>
    /// UI�p�F���i�g�������N���X
    /// </summary>
    public class PurePartsTrimInfo : PartsSerchSub
    {

        # region DataTable ��`
        public const string TABLENAME_PRTTRM = "TABLENAME_PARTSTRIM";

        // ���ۂ̃����o���L�q
        public const string COL_PRTTRM_PARTSUNIQUENO = "partsproperno";
        public const string COL_PRTTRM_TRIMCODE = "TrimCode";
        public const string COL_PRTTRM_TRIMNAME = "TrimName";
        public const string COL_PRTTRM_SELECTED = "Col_Selected";

        /// <summary>
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        public static DataTable CreateTable(string tbl_name)
        {
            DataTable wkTable = new DataTable(tbl_name);
			wkTable.Columns.Add(CreateColumn(COL_PRTTRM_PARTSUNIQUENO, typeof(Int64), "���i�ŗL�ԍ�"));
            wkTable.Columns.Add(CreateColumn(COL_PRTTRM_TRIMCODE, typeof(string), "�g�����R�[�h"));
            wkTable.Columns.Add(CreateColumn(COL_PRTTRM_TRIMNAME, typeof(string), "�g��������"));
            wkTable.Columns.Add(CreateColumn(COL_PRTTRM_SELECTED, typeof(string), "�I��"));

            return wkTable;
        }


        # endregion

    }

    /// <summary>
    /// UI�p�F���i�J���[���N���X
    /// </summary>
    public class PurePartsEquipInfo : PartsSerchSub
    {

        # region DataTable ��`
        public const string TABLENAME_PRTEQP = "TABLENAME_PARTSEQUIP";

        // ���ۂ̃����o���L�q
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
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        public static DataTable CreateTable(string tbl_name)
        {
            DataTable wkTable = new DataTable(tbl_name);
			wkTable.Columns.Add(CreateColumn(COL_PRTEQP_PARTSUNIQUENO, typeof(Int64), "���i�ŗL�ԍ�"));
            wkTable.Columns.Add(CreateColumn(COL_PRTEQP_EQUIPMENTCODE, typeof(string), "�����R�[�h"));
            wkTable.Columns.Add(CreateColumn(COL_PRTEQP_EQUIPMENTDISPORDER, typeof(int), "�\������"));
            wkTable.Columns.Add(CreateColumn(COL_PRTEQP_EQUIPMENTGENRECD, typeof(string), "�������ރR�[�h"));
            wkTable.Columns.Add(CreateColumn(COL_PRTEQP_EQUIPMENTSHORTNAME, typeof(string), "��������"));
            wkTable.Columns.Add(CreateColumn(COL_PRTEQP_EQUIPMENTGENRENM, typeof(string), "�������ޖ�"));
            wkTable.Columns.Add(CreateColumn(COL_PRTEQP_EQUIPMENTNAME, typeof(string), "��������"));
            wkTable.Columns.Add(CreateColumn(COL_PRTEQP_EQUIPMENTICONCODE, typeof(string), "�A�C�R���R�[�h"));

            return wkTable;
        }


        # endregion

    }

}
