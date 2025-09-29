using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// �񋟁F����i�ԏ��N���X
    /// </summary>
    public class SamePartsInfo : PartsSerchSub
    {

        # region DataTable ��`
        public const string TABLENAME_SAME = "TABLENAME_SAME";

        // ���ۂ̃����o���L�q
        public const string COL_SAME_SELECTED = "Col_Selected";
        public const string COL_SAME_MAKERCODE = "SameMakerCode";
        public const string COL_SAME_PARTSNOWITHH = "SamePartsNoWithH";
        public const string COL_SAME_PARTSNAME = "SamePartsName";
        public const string COL_SAME_MAKERNAME = "SameMakerName";
        public const string COL_SAME_PRICE = "SamePrice";

        /// <summary>
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        /// <returns>CarKindInfo�p��DataTable</returns>
        public static DataTable CreateTable(string table_name)
        {
			DataTable wkTable = new DataTable(table_name);
            wkTable.Columns.Add(CreateColumn(COL_SAME_SELECTED, typeof(int), "�s�I��"));
            wkTable.Columns.Add(CreateColumn(COL_SAME_MAKERCODE, typeof(int), "���[�J�["));
            wkTable.Columns.Add(CreateColumn(COL_SAME_PARTSNOWITHH, typeof(string), "�n�C�t���t�i��"));
            wkTable.Columns.Add(CreateColumn(COL_SAME_MAKERNAME, typeof(string), "���[�J�[����"));
            wkTable.Columns.Add(CreateColumn(COL_SAME_PARTSNAME, typeof(string), "�i��"));
            wkTable.Columns.Add(CreateColumn(COL_SAME_PRICE, typeof(Int64), "�W�����i"));

            return wkTable;
        }

        # endregion

    }
}
