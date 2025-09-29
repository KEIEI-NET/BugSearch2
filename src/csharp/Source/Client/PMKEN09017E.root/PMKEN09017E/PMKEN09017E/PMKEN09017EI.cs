using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// �񋟁F�������N���X
    /// </summary>
	public class OfrEquipInfo : PartsSerchSub
    {

        # region DataTable ��`
		public const string TABLENAME_EQUIP = "TABLENAME_EQUIP";

        // ���ۂ̃����o���L�q
		/// <summary>�������ރR�[�h</summary>
		public const string COL_EQUIP_EQUIPMENTGENRECD = "equipmentGenreCd";
		/// <summary>�����R�[�h</summary>
		public const string COL_EQUIP_EQUIPMENTCODE = "equipmentCode";
		/// <summary>���i�ŗL�ԍ�</summary>
		public const string COL_EQUIP_PARTSPROPERNO = "partsproperno";


		public const string COL_PARTS_SELECTED = "Col_Selected";


		/// <summary>
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        /// <returns>CarKindInfo�p��DataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_EQUIP_EQUIPMENTGENRECD, typeof(int), "�������ރR�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_EQUIP_EQUIPMENTCODE, typeof(int), "�����R�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_EQUIP_PARTSPROPERNO, typeof(Int64), "���i�ŗL�ԍ�"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_SELECTED, typeof(int), "�s�I��"));
            return wkTable;
        }

		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_EQUIP_EQUIPMENTGENRECD] = sourcedr[COL_EQUIP_EQUIPMENTGENRECD];
			dr[COL_EQUIP_EQUIPMENTCODE] = sourcedr[COL_EQUIP_EQUIPMENTCODE];
			dr[COL_EQUIP_PARTSPROPERNO] = sourcedr[COL_EQUIP_PARTSPROPERNO];
			return dr;
		}

        # endregion

    }
}
