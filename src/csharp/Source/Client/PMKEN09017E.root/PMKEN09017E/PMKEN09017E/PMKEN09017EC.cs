using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// ���[�U�[���������F�������N���X
    /// </summary>
	public class UsrJoinPartsInfo : PartsSerchSub
    {

        # region DataTable ��`
		//�������
		public const string USRJOINPARTSINFO_TBL_NAME = "UsrJoinPartsInfo";

		//�t�h�e�[�u����񁃑�֕i�ԁ������i�ԁ�
		public const string UISUBSTJOINPARTSINFO_TBL_NAME = "UiSubstJoinPartsInfo";

        // �I����Ԃ������t���O
        public const string COL_SELECTED = "Selected";
        // ���ۂ̃����o���L�q
		public const string COL_JOINDISPORDER = "JoinDispOrder";
		public const string COL_JOINSOURCEMAKERCODE = "JoinSourceMakerCode";
		public const string COL_JOINSOURPARTSNOWITHH = "JoinSourPartsNoWithH";
		public const string COL_JOINSOURPARTSNONONEH = "JoinSourPartsNoNoneH";
		public const string COL_JOINDESTMAKERCD = "JoinDestMakerCd";
		public const string COL_JOINDESTPARTSNO = "JoinDestPartsNo";
		public const string COL_JOINQTY = "JoinQty";
		public const string COL_JOINSPECIALNOTE = "JoinSpecialNote";
		public const string COL_JOINOFFERDATE = "JoinOfferDate";

		//�����oCAPTION
		// �I����Ԃ������t���O
		public const string TIT_SELECTED = "�I�����";

		public const string TIT_JOINDISPORDER = "�����\������";
		public const string TIT_JOINSOURCEMAKERCODE = "���������[�J�[�R�[�h";
		public const string TIT_JOINSOURPARTSNOWITHH = "�������i��(�|�t���i��)";
		public const string TIT_JOINSOURPARTSNONONEH = "�������i��(�|�����i��)";
		public const string TIT_JOINDESTMAKERCD = "�����惁�[�J�[�R�[�h";
		public const string TIT_JOINDESTPARTSNO = "������i��(�|�t���i��)";
		public const string TIT_JOINQTY = "����QTY";
		public const string TIT_JOINSPECIALNOTE = "�����K�i�E���L����";
		public const string TIT_JOINOFFERDATE = "�����f�[�^�񋟓��t";

        /// <summary>
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        /// <returns>CarKindInfo�p��DataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_SELECTED, typeof(int), TIT_SELECTED));

			wkTable.Columns.Add(CreateColumn(COL_JOINDISPORDER, typeof(Int32), TIT_JOINDISPORDER));
			wkTable.Columns.Add(CreateColumn(COL_JOINSOURCEMAKERCODE, typeof(Int32), TIT_JOINSOURCEMAKERCODE));
			wkTable.Columns.Add(CreateColumn(COL_JOINSOURPARTSNOWITHH, typeof(string), TIT_JOINSOURPARTSNOWITHH));
			wkTable.Columns.Add(CreateColumn(COL_JOINSOURPARTSNONONEH, typeof(string), TIT_JOINSOURPARTSNONONEH));
			wkTable.Columns.Add(CreateColumn(COL_JOINDESTMAKERCD, typeof(Int32), TIT_JOINDESTMAKERCD));
			wkTable.Columns.Add(CreateColumn(COL_JOINDESTPARTSNO, typeof(string), TIT_JOINDESTPARTSNO));
			wkTable.Columns.Add(CreateColumn(COL_JOINQTY, typeof(Double), TIT_JOINQTY));
			wkTable.Columns.Add(CreateColumn(COL_JOINSPECIALNOTE, typeof(string), TIT_JOINSPECIALNOTE));
			wkTable.Columns.Add(CreateColumn(COL_JOINOFFERDATE, typeof(Int32), TIT_JOINOFFERDATE));

			return wkTable;
        }

		/// <summary>
		/// �w��̍s�Ƀf�[�^���Z�b�g�����[�U�[��������:�������
		/// </summary>
		/// <returns>�Z�b�g��̃f�[�^�s</returns>
		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_JOINDISPORDER] = sourcedr[COL_JOINDISPORDER];
			dr[COL_JOINSOURCEMAKERCODE] = sourcedr[COL_JOINSOURCEMAKERCODE];
			dr[COL_JOINSOURPARTSNOWITHH] = sourcedr[COL_JOINSOURPARTSNOWITHH];
			dr[COL_JOINSOURPARTSNONONEH] = sourcedr[COL_JOINSOURPARTSNONONEH];
			dr[COL_JOINDESTMAKERCD] = sourcedr[COL_JOINDESTMAKERCD];
			dr[COL_JOINDESTPARTSNO] = sourcedr[COL_JOINDESTPARTSNO];
			dr[COL_JOINQTY] = sourcedr[COL_JOINQTY];
			dr[COL_JOINSPECIALNOTE] = sourcedr[COL_JOINSPECIALNOTE];
			dr[COL_JOINOFFERDATE] = sourcedr[COL_JOINOFFERDATE];
			return dr;
		}


        # endregion

    }
}
