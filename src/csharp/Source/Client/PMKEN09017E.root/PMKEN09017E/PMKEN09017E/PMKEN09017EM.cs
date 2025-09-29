using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// �񋟁F�Z�b�g���N���X
    /// </summary>
	public class OfrSetPartsInfo : PartsSerchSub
    {

        # region DataTable ��`
		public const string TABLENAME_SET = "TABLENAME_SET";

        // ���ۂ̃����o���L�q
		public const string COL_SET_MIDDLEGENRECODE = "MiddleGenreCode";
		public const string COL_SET_TBSPARTSCODE = "TbsPartsCode";
		public const string COL_SET_TBSPARTSCDDERIVEDNO = "TbsPartsCdDerivedNo";
		public const string COL_SET_SETMAINMAKERCD = "SetMainMakerCd";
		public const string COL_SET_SETMAINPARTSNO = "SetMainPartsNo";
		public const string COL_SET_SETSUBMAKERCD = "SetSubMakerCd";
		public const string COL_SET_SETSUBPARTSNO = "SetSubPartsNo";
		public const string COL_SET_SETDISPORDER = "SetDispOrder";
		public const string COL_SET_SETQTY = "SetQty";
		public const string COL_SET_SETNAME = "SetName";
		public const string COL_SET_SETSPECIALNOTE = "SetSpecialNote";
		public const string COL_SET_CATALOGSHAPENO = "CatalogShapeNo";
        public const string COL_SET_SETSUBPARTSNAME = "SetSubPartsName";
        public const string COL_SET_SETSUBMAKERNAME = "SetSubMakerName";
        public const string COL_SET_SETPRICE = "SetPrice";
		public const string COL_SET_SELECTED = "Col_Selected";

		/// <summary>
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        /// <returns>CarKindInfo�p��DataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

            wkTable.Columns.Add(CreateColumn(COL_SET_SELECTED, typeof(int), "�s�I��"));
            wkTable.Columns.Add(CreateColumn(COL_SET_MIDDLEGENRECODE, typeof(int), "�����ރR�[�h"));
            wkTable.Columns.Add(CreateColumn(COL_SET_TBSPARTSCODE, typeof(int), "BL�R�[�h"));
            wkTable.Columns.Add(CreateColumn(COL_SET_TBSPARTSCDDERIVEDNO, typeof(int), "BL�R�[�h�}��"));
			wkTable.Columns.Add(CreateColumn(COL_SET_SETMAINMAKERCD, typeof(int), "�Z�b�g�e���[�J�[�R�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_SET_SETMAINPARTSNO, typeof(string), "�Z�b�g�e�i��"));
			wkTable.Columns.Add(CreateColumn(COL_SET_SETSUBMAKERCD, typeof(int), "�Z�b�g�q���[�J�[�R�[�h"));
            wkTable.Columns.Add(CreateColumn(COL_SET_SETSUBMAKERNAME, typeof(string), "�Z�b�g�q���[�J�[��"));
			wkTable.Columns.Add(CreateColumn(COL_SET_SETSUBPARTSNO, typeof(string), "�Z�b�g�q�i��"));
            wkTable.Columns.Add(CreateColumn(COL_SET_SETSUBPARTSNAME, typeof(string), "�Z�b�g�q���i����"));
            wkTable.Columns.Add(CreateColumn(COL_SET_SETDISPORDER, typeof(int), "�\������"));
			wkTable.Columns.Add(CreateColumn(COL_SET_SETQTY, typeof(double), "�Z�b�gQTY"));
			wkTable.Columns.Add(CreateColumn(COL_SET_SETNAME, typeof(string), "�Z�b�g����"));
			wkTable.Columns.Add(CreateColumn(COL_SET_SETSPECIALNOTE, typeof(string), "�Z�b�g�K�i�E���L����"));
			wkTable.Columns.Add(CreateColumn(COL_SET_CATALOGSHAPENO, typeof(string), "�J�^���O�}��"));

            wkTable.Columns.Add(CreateColumn(COL_SET_SETPRICE, typeof(Int64), "�Z�b�g�W�����i"));

            return wkTable;
        }
        # endregion

    }
}
