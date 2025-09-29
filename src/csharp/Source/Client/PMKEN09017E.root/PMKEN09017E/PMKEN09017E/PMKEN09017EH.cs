using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// �񋟁F�g�������N���X
    /// </summary>
	public class OfrTrimInfo : PartsSerchSub
    {

        # region DataTable ��`
		public const string TABLENAME_TRIM = "TABLENAME_TRIM";
		/// <summary>
		/// �g�����R�[�h
		/// </summary>
		public const string COL_TRIM_TRIMCODE = "trimCode";
		/// <summary>
		/// ���i�ŗL�ԍ�
		/// </summary>
		public const string COL_TRIM_PARTSPROPERNO = "partsproperno";


		public const string COL_PARTS_SELECTED = "Col_Selected";

		/// <summary>
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        /// <returns>CarKindInfo�p��DataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_TRIM_TRIMCODE, typeof(string), "�g�����R�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_TRIM_PARTSPROPERNO, typeof(Int64), "���i�ŗL�ԍ�"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_SELECTED, typeof(int), "�s�I��"));
			return wkTable;
        }

		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_TRIM_TRIMCODE] = sourcedr[COL_TRIM_TRIMCODE];
			dr[COL_TRIM_PARTSPROPERNO] = sourcedr[COL_TRIM_PARTSPROPERNO];
			return dr;
		}

        # endregion

    }
}
