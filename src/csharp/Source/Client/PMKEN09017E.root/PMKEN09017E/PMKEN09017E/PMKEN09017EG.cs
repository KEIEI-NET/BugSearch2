using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// �񋟁F�J���[���N���X
    /// </summary>
	public class OfrColorInfo : PartsSerchSub
    {
        # region DataTable ��`
		public const string TABLENAME_COLOR = "TABLENAME_COLOR";

        // ���ۂ̃����o���L�q
		public const string COL_COLOR_COLORCDINFONO = "colorCdInfoNo";
		/// <summary>
		/// ���i�ŗL�ԍ�
		/// </summary>
		public const string COL_COLOR_PARTSPROPERNO = "partsproperno";


		public const string COL_PARTS_SELECTED = "Col_Selected";

		/// <summary>
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        /// <returns>CarKindInfo�p��DataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_COLOR_COLORCDINFONO, typeof(string), "�J���[�R�[�h���No"));
			wkTable.Columns.Add(CreateColumn(COL_COLOR_PARTSPROPERNO, typeof(Int64), "���i�ŗL�ԍ�"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_SELECTED, typeof(int), "�s�I��"));

			return wkTable;
        }

		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_COLOR_COLORCDINFONO] = sourcedr[COL_COLOR_COLORCDINFONO];
			dr[COL_COLOR_PARTSPROPERNO] = sourcedr[COL_COLOR_PARTSPROPERNO];
			return dr;
		}

        # endregion

    }
}
