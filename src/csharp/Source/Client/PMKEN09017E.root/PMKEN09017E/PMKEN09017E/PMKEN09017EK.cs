using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// �񋟁F�D�Ǖ��i�������N���X
    /// </summary>
    public class OfrJoinPartsInfo : PartsSerchSub
    {

        # region DataTable ��`
        public const string TABLENAME_JOIN = "TABLENAME_JOIN";

        // ���ۂ̃����o���L�q
        public const string COL_JOIN_SELECTED = "Col_Selected";
        public const string COL_JOIN_TBSPARTSCODE = "TbsPartsCode";
        public const string COL_JOIN_TBSPARTSCDDERIVEDNO = "TbsPartsCdDerivedNo";
        public const string COL_JOIN_SELECTCODE = "SelectCode";
        public const string COL_JOIN_PRIMEKINDCODE = "PrimeKindCode";
        public const string COL_JOIN_JOINDISPORDER = "JoinDispOrder";
        public const string COL_JOIN_JOINSOURCEMAKERCODE = "JoinSourceMakerCode";
        public const string COL_JOIN_JOINSOURPARTSNOWITHH = "JoinSourPartsNoWithH";
        public const string COL_JOIN_JOINSOURPARTSNONONEH = "JoinSourPartsNoNoneH";
        public const string COL_JOIN_JOINDESTMAKERCD = "JoinDestMakerCd";
        public const string COL_JOIN_JOINDESTPARTSNO = "JoinDestPartsNo";
        public const string COL_JOIN_JOINDESTPARTSNAME = "JoinDestPartsName";
        public const string COL_JOIN_JOINOLDPARTSNO = "JoinOldPartsNo";
        public const string COL_JOIN_JOINQTY = "JoinQty";
        public const string COL_JOIN_SETPARTSFLG = "SetPartsFlg";
        public const string COL_JOIN_JOINSPECIALNOTE = "JoinSpecialNote";
        public const string COL_JOIN_JOINPRICE = "JoinPrice";
        public const string COL_JOIN_PRIMEKINDNAME = "PrimeKindName";
        public const string COL_JOIN_JOINDESTMAKERNAME = "JoinDestMakerName";
        public const string COL_JOIN_MAKERDISPORDER = "MakerDispOrder";
        public const string COL_JOIN_PRIMEDISPORDER = "PrimeDispOrder";

        /// <summary>
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        /// <returns>CarKindInfo�p��DataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
            DataTable wkTable = new DataTable(tbl_name);
            wkTable.Columns.Add(CreateColumn(COL_JOIN_SELECTED, typeof(int), "�s�I��"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_TBSPARTSCODE, typeof(int), "BL�R�[�h"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_TBSPARTSCDDERIVEDNO, typeof(int), "BL�R�[�h�}��"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_SELECTCODE, typeof(int), "�Z���N�g�R�[�h"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_PRIMEKINDCODE, typeof(int), "�D�ǎ�ʃR�[�h"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_PRIMEKINDNAME, typeof(string), "�D�ǎ�ʖ���"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINDISPORDER, typeof(int), "�����\������"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINSOURCEMAKERCODE, typeof(int), "���������[�J�["));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINSOURPARTSNOWITHH, typeof(string), "�n�C�t���t�������i��"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINSOURPARTSNONONEH, typeof(string), "�n�C�t�����������i��"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINDESTMAKERCD, typeof(int), "�����惁�[�J�["));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINDESTMAKERNAME, typeof(string), "�����惁�[�J�[����"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINDESTPARTSNO, typeof(string), "������i��"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINDESTPARTSNAME, typeof(string), "������i��"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINOLDPARTSNO, typeof(string), "�����拌�i��"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINPRICE, typeof(Int64), "������W�����i"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINQTY, typeof(double), "����QTY"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_SETPARTSFLG, typeof(int), "�Z�b�g�L���t���O"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_JOINSPECIALNOTE, typeof(string), "�������L����"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_MAKERDISPORDER, typeof(int), "���[�J�[�\������"));
            wkTable.Columns.Add(CreateColumn(COL_JOIN_PRIMEDISPORDER, typeof(int), "�D�Ǖ\������"));

            return wkTable;
        }

        # endregion

    }
}
