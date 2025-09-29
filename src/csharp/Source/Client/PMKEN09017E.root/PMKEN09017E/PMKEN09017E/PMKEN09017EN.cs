using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// �񋟁F�a�k���N���X
    /// </summary>
	public class OfrBLInfo : PartsSerchSub
    {
        # region DataTable ��`
		public const string TABLENAME_BL = "TABLENAME_BL";
		public const string TABLENAME_OFR_BL = "TABLENAME_OFR_BL";

        // ���ۂ̃����o���L�q
		public const string COL_BL_TBSPARTSCODE = "TbsPartsCode";
		public const string COL_BL_TBSPARTSFULLNAME = "TbsPartsFullName";
		public const string COL_BL_TBSPARTSHALFNAME = "TbsPartsHalfName";
		public const string COL_BL_OFRKBN = "OfrKbn";

		public const string COL_BL_EQUIPGENRECODE = "EquipGenreCode";
		public const string COL_BL_GROUPCODE = "GroupCode";
		public const string COL_BL_MIDDLEGENRECODE = "MiddleGenreCode";
		public const string COL_BL_TBSPARTSCDDERIVEDNO = "TbsPartsCdDerivedNo";
		public const string COL_BL_PRIMESEARCHFLG = "PrimeSearchFlg";
		public const string COL_BL_SELECTED = "Col_Selected";

		/// <summary>
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        /// <returns>CarKindInfo�p��DataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_BL_TBSPARTSCODE, typeof(int), "BL�R�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_BL_TBSPARTSFULLNAME, typeof(String), "BL�R�[�h���́i�S�p�j"));
			wkTable.Columns.Add(CreateColumn(COL_BL_TBSPARTSHALFNAME, typeof(String), "BL�R�[�h���́i���p�j"));
			wkTable.Columns.Add(CreateColumn(COL_BL_OFRKBN, typeof(int), "�񋟋敪"));

			wkTable.Columns.Add(CreateColumn(COL_BL_EQUIPGENRECODE, typeof(int), "��������"));
			wkTable.Columns.Add(CreateColumn(COL_BL_GROUPCODE, typeof(int), "�O���[�v�R�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_BL_MIDDLEGENRECODE, typeof(int), "�����ރR�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_BL_TBSPARTSCDDERIVEDNO, typeof(int), "BL�R�[�h�}��"));
			wkTable.Columns.Add(CreateColumn(COL_BL_PRIMESEARCHFLG, typeof(int), "�D��BL�敪"));
			wkTable.Columns.Add(CreateColumn(COL_BL_SELECTED, typeof(int), "�I�����"));


			//wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COL_BL_TBSPARTSCODE] };

            return wkTable;
        }

		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_BL_OFRKBN] = sourcedr[COL_BL_OFRKBN];
			dr[COL_BL_TBSPARTSCODE] = sourcedr[COL_BL_TBSPARTSCODE];
			dr[COL_BL_TBSPARTSFULLNAME] = sourcedr[COL_BL_TBSPARTSFULLNAME];
			dr[COL_BL_TBSPARTSHALFNAME] = sourcedr[COL_BL_TBSPARTSHALFNAME];
			return dr;
		}


        # endregion

    }
}
