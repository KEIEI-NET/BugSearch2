using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// �񋟁F�D�ǂa�k�������N���X
    /// </summary>
    public class OfrPrimeSearchPartsInfo : PartsSerchSub
    {

        # region DataTable ��`
        public const string TABLENAME_PRIMESEARCH = "TABLENAME_PRIMESEARCH";

        // ���ۂ̃����o���L�q
        public const string COL_PRIMESEARCH_SELECTED = "Col_Selected";
        public const string COL_PRIMESEARCH_FULLMODELFIXEDNO = "fullModelFixedNo";
        public const string COL_PRIMESEARCH_MIDDLEGENRECODE = "middleGenreCode";
        public const string COL_PRIMESEARCH_TBSPARTSCODE = "tbsPartsCode";
        public const string COL_PRIMESEARCH_TBSPARTSCDDERIVEDNO = "tbsPartsCdDerivedNo";
        public const string COL_PRIMESEARCH_TBSPARTSCDDERIVEDNM = "tbsPartsCdDerivedNm";//�ǉ�
        public const string COL_PRIMESEARCH_PARTSMAKERCD = "partsMakerCd";
        public const string COL_PRIMESEARCH_PARTSMAKERNAME = "partsMakerName";//�ǉ�
        public const string COL_PRIMESEARCH_SELECTCODE = "selectCode";
        public const string COL_PRIMESEARCH_PRIMEKINDCODE = "primeKindCode";
        public const string COL_PRIMESEARCH_PRIMESEARCHDISPORDER = "primeSearchDispOrder";
        public const string COL_PRIMESEARCH_PRIMEPARTSNO = "primePartsNo";
        public const string COL_PRIMESEARCH_PRIMEPARTSNAME = "primePartsName";//�ǉ�
        public const string COL_PRIMESEARCH_PRIMEOLDPARTSNO = "primeOldPartsNo";
        public const string COL_PRIMESEARCH_SETPARTSFLG = "setPartsFlg";
        public const string COL_PRIMESEARCH_PRIMEPRICE = "primePrice";
        public const string COL_PRIMESEARCH_PRIMEQTY = "primeQty";
        public const string COL_PRIMESEARCH_PRIMESPECIALNOTE = "primeSpecialNote";
        public const string COL_PRIMESEARCH_MAKERDISPORDER = "makerDispOrder";
        public const string COL_PRIMESEARCH_PRIMEDISPORDER = "primeDispOrder";
        public const string COL_PRIMESEARCH_STPRODUCETYPEOFYEAR = "stProduceTypeOfYear";
        public const string COL_PRIMESEARCH_EDPRODUCETYPEOFYEAR = "edProduceTypeOfYear";
        public const string COL_PRIMESEARCH_STPRODUCEFRAMENO = "stProduceFrameNo";
        public const string COL_PRIMESEARCH_EDPRODUCEFRAMENO = "edProduceFrameNo";

        /// <summary>
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        /// <returns>CarKindInfo�p��DataTable</returns>
        public static DataTable CreateTable(string table_name)
        {
            DataTable wkTable = new DataTable(table_name);
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_SELECTED, typeof(int), "�s�I��"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_FULLMODELFIXEDNO, typeof(int), "�t���^���Œ�ԍ�"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_MIDDLEGENRECODE, typeof(string), "�����ރR�[�h"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_TBSPARTSCODE, typeof(int), "BL�R�[�h"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_TBSPARTSCDDERIVEDNO, typeof(int), "BL�R�[�h�}��"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_TBSPARTSCDDERIVEDNM, typeof(string), "BL�R�[�h�}�Ԗ���"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_SELECTCODE, typeof(int), "�Z���N�g�R�[�h"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PRIMEKINDCODE, typeof(int), "��ʃR�[�h"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PRIMESEARCHDISPORDER, typeof(int), "�D�ǌ����\������"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PARTSMAKERCD, typeof(int), "���i���[�J�["));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PARTSMAKERNAME, typeof(string), "���i���[�J�[����"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PRIMEPARTSNO, typeof(string), "�D�Ǖi��"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PRIMEPARTSNAME, typeof(string), "�D�Ǖi��"));
			wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PRIMEOLDPARTSNO, typeof(string), "�D�ǋ��i��"));
			wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_SETPARTSFLG, typeof(int), "�Z�b�g�i�ԃt���O"));
			wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PRIMEPRICE, typeof(Int64), "�D�ǕW�����i"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PRIMEQTY, typeof(double), "�D��QTY"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PRIMESPECIALNOTE, typeof(string), "�D�Ǔ��L����"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_MAKERDISPORDER, typeof(int), "���[�J�[�\������"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_PRIMEDISPORDER, typeof(int), "�D�ǐݒ�\������"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_STPRODUCETYPEOFYEAR, typeof(int), "���Y�N��(�J�n)"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_EDPRODUCETYPEOFYEAR, typeof(int), "���Y�N��(�I��)"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_STPRODUCEFRAMENO, typeof(int), "�ԑ�ԍ�(�J�n)"));
            wkTable.Columns.Add(CreateColumn(COL_PRIMESEARCH_EDPRODUCEFRAMENO, typeof(int), "�ԑ�ԍ�(�I��)"));

            return wkTable;
        }

        # endregion

    }
}
