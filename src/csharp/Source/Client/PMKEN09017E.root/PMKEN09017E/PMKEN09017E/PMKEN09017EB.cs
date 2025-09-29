using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// ���[�U�[���������F��֏����N���X
    /// </summary>
	public class UsrPartsSubstInfo : PartsSerchSub
    {
        # region DataTable ��`
		//��֏��
		public const string USRPARTSSUBSTINFO_TBL_NAME = "UsrPartsSubstInfo";

		//�t�h�e�[�u����񁃏����i�ԁ���֕i�ԁ�
		public const string UISUBSTPARTSINFO_TBL_NAME = "UiSubstPartsInfo";

		//�t�h�e�[�u����񁃌����i�ԁ���֕i�ԁ�
		public const string UIJOINSUBSTPARTSINFO_TBL_NAME = "UiJoinSubstPartsInfo";

		//�t�h�e�[�u����񁃃Z�b�g�i�ԁ���֕i�ԁ�
		public const string UISETSUBSTPARTSINFO_TBL_NAME = "UiSetSubstPartsInfo";

        // �I����Ԃ������t���O
        public const string COL_SELECTED = "Selected";
        // ���ۂ̃����o���L�q
		public const string COL_MAKERCODE = "MakerCode";
		public const string COL_PRTSNOWITHHYPHEN = "PrtsNoWithHyphen";
		public const string COL_SUBSTORDER = "SubstOrder";
		public const string COL_SUBSTSORMAKERCD = "SubstSorMakerCd";
		public const string COL_SUBSTSORPARTSNO = "SubstSorPartsNo";
		public const string COL_SUBSTDESTMAKERCD = "SubstDestMakerCd";
		public const string COL_SUBSTDESTPARTSNO = "SubstDestPartsNo";
		public const string COL_APPLYSTDATE = "ApplyStDate";
		public const string COL_APPLYEDDATE = "ApplyEdDate";

		//�����oCAPTION
		// �I����Ԃ������t���O
		public const string TIT_SELECTED = "�I�����";
		public const string TIT_MAKERCODE = "���[�J�[�R�[�h";
		public const string TIT_PRTSNOWITHHYPHEN = "�n�C�t���t���i�i��";
		public const string TIT_SUBSTORDER = "��֏���";
		public const string TIT_SUBSTSORMAKERCD = "��֌����[�J�[�R�[�h";
		public const string TIT_SUBSTSORPARTSNO = "��֌��i��(-�t�i��)";
		public const string TIT_SUBSTDESTMAKERCD = "��֐惁�[�J�[�R�[�h";
		public const string TIT_SUBSTDESTPARTSNO = "��֐�i��(-�t�i��)";
		public const string TIT_APPLYSTDATE = "�K�p�J�n�N����";
		public const string TIT_APPLYEDDATE = "�K�p�I���N����";

        /// <summary>
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        /// <returns>CarKindInfo�p��DataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_SELECTED, typeof(int), TIT_SELECTED));

			wkTable.Columns.Add(CreateColumn(COL_MAKERCODE, typeof(Int32), TIT_MAKERCODE));
			wkTable.Columns.Add(CreateColumn(COL_PRTSNOWITHHYPHEN, typeof(string), TIT_PRTSNOWITHHYPHEN));
			wkTable.Columns.Add(CreateColumn(COL_SUBSTORDER, typeof(Int32), TIT_SUBSTORDER));
			wkTable.Columns.Add(CreateColumn(COL_SUBSTDESTMAKERCD, typeof(Int32), TIT_SUBSTDESTMAKERCD));
			wkTable.Columns.Add(CreateColumn(COL_SUBSTDESTPARTSNO, typeof(string), TIT_SUBSTDESTPARTSNO));
			wkTable.Columns.Add(CreateColumn(COL_APPLYSTDATE, typeof(Int32), TIT_APPLYSTDATE));
			wkTable.Columns.Add(CreateColumn(COL_APPLYEDDATE, typeof(Int32), TIT_APPLYEDDATE));

            return wkTable;
        }

		/// <summary>
		/// �w��̍s�Ƀf�[�^���Z�b�g�����[�U�[��������:��֏��
		/// </summary>
		/// <returns>�Z�b�g��̃f�[�^�s</returns>
		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_MAKERCODE] = sourcedr[COL_MAKERCODE];
			dr[COL_PRTSNOWITHHYPHEN] = sourcedr[COL_PRTSNOWITHHYPHEN];
			dr[COL_SUBSTORDER] = sourcedr[COL_SUBSTORDER];
			dr[COL_SUBSTDESTMAKERCD] = sourcedr[COL_SUBSTDESTMAKERCD];
			dr[COL_SUBSTDESTPARTSNO] = sourcedr[COL_SUBSTDESTPARTSNO];
			dr[COL_APPLYSTDATE] = sourcedr[COL_APPLYSTDATE];
			dr[COL_APPLYEDDATE] = sourcedr[COL_APPLYEDDATE];
			return dr;
		}


		# endregion

    }
}
