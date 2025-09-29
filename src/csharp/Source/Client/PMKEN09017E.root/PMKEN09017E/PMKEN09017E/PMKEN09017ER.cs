using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// �񋟁F�ԗ���񌋍����N���X
    /// </summary>
    public class OfrCarInfoJoinPartsInfo : PartsSerchSub
    {

        # region DataTable ��`
        public const string TABLENAME_CARINFJOIN = "TABLENAME_CARINFJOIN";

        // ���ۂ̃����o���L�q

        public const string COL_CARINFJOIN_SELECTED = "Col_Selected";
        public const string COL_CARINFJOIN_MIDDLEGENRECODE = "MiddleGenreCode";
        public const string COL_CARINFJOIN_TBSPARTSCODE = "TbsPartsCode";
        public const string COL_CARINFJOIN_TBSPARTSCDDERIVEDNO = "TbsPartsCdDerivedNo";
        public const string COL_CARINFJOIN_EQUIPGENRECODE = "EquipGenreCode";
        public const string COL_CARINFJOIN_EQUIPNAME = "EquipName";
        public const string COL_CARINFJOIN_CARINFOJOINDISPORDER = "CarInfoJoinDispOrder";
        public const string COL_CARINFJOIN_JOINDESTMAKERCD = "JoinDestMakerCd";
        public const string COL_CARINFJOIN_JOINDESTMAKERNAME = "JoinDestMakerName";
        public const string COL_CARINFJOIN_JOINDESTPARTSNO = "JoinDestPartsNo";
        public const string COL_CARINFJOIN_JOINDESTPARTSNAME = "JoinDestPartsName";
        public const string COL_CARINFJOIN_JOINQTY = "JoinQty";
        public const string COL_CARINFJOIN_JOINPRICE = "JoinPrice";
        public const string COL_CARINFJOIN_EQUIPSPECIALNOTE = "EquipSpecialNote";
        public const string COL_CARINFJOIN_MAKERDISPORDER = "MakerDispOrder";


        /// <summary>
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        /// <returns>CarKindInfo�p��DataTable</returns>
        public static DataTable CreateTable(string table_name)
        {
            DataTable wkTable = new DataTable(table_name);

            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_SELECTED, typeof(int), "�s�I��"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_MIDDLEGENRECODE, typeof(int), "�����ރR�[�h"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_TBSPARTSCODE, typeof(int), "BL�R�[�h"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_TBSPARTSCDDERIVEDNO, typeof(int), "BL�R�[�h�}��"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_EQUIPGENRECODE, typeof(string), "��������"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_EQUIPNAME, typeof(string), "��������"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_CARINFOJOINDISPORDER, typeof(int), "�ԗ���񌋍��\������"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_JOINDESTMAKERCD, typeof(int), "�����惁�[�J�["));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_JOINDESTMAKERNAME, typeof(string), "�����惁�[�J�[����"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_JOINDESTPARTSNO, typeof(string), "������i��"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_JOINDESTPARTSNAME, typeof(string), "������i��"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_JOINPRICE, typeof(Int64), "������W�����i"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_JOINQTY, typeof(double), "����QTY"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_EQUIPSPECIALNOTE, typeof(string), "�������L����"));
            wkTable.Columns.Add(CreateColumn(COL_CARINFJOIN_MAKERDISPORDER, typeof(int), "���[�J�[�\������"));

            return wkTable;
        }

        # endregion

    }
}
