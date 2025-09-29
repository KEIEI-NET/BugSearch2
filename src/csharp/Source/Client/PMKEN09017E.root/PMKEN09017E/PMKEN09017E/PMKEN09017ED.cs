using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// ���[�U�[���������F�Z�b�g���N���X
    /// </summary>
	public class UsrSetPartsInfo : PartsSerchSub
    {

        # region DataTable ��`
		//�Z�b�g���
		public const string USRSETPARTSINFO_TBL_NAME = "UsrSetPartsInfo";

		//�t�h�e�[�u����񁃃Z�b�g�i�ԁ�
		public const string UISETPARTSINFO_TBL_NAME = "UiSetPartsInfo";

        // �I����Ԃ������t���O
        public const string COL_SELECTED = "Selected";
        // ���ۂ̃����o���L�q
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

		//�����oCAPTION
		// �I����Ԃ������t���O
		public const string TIT_SELECTED = "�I�����";

		public const string TIT_SETMAINMAKERCD = "�Z�b�g�e���[�J�[�R�[�h";
		public const string TIT_SETMAINPARTSNO = "�Z�b�g�e�i��";
		public const string TIT_SETSUBMAKERCD = "�Z�b�g�q���[�J�[�R�[�h";
		public const string TIT_SETSUBPARTSNO = "�Z�b�g�q�i��";
		public const string TIT_SETDISPORDER = "�Z�b�g�\������";
		public const string TIT_SETQTY = "�Z�b�gQTY";
		public const string TIT_SETNAME = "�Z�b�g����";
		public const string TIT_SETSPECIALNOTE = "�Z�b�g�K�i�E���L����";
		public const string TIT_CATALOGSHAPENO = "�J�^���O�}��";
        public const string TIT_SET_SETSUBPARTSNAME = "�Z�b�g�q���[�J�[��";
        public const string TIT_SET_SETSUBMAKERNAME = "�Z�b�g�q���i����";

        /// <summary>
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        /// <returns>CarKindInfo�p��DataTable</returns>
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
		/// �w��̍s�Ƀf�[�^���Z�b�g�����[�U�[��������:�Z�b�g���
		/// </summary>
		/// <returns>�Z�b�g��̃f�[�^�s</returns>
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
