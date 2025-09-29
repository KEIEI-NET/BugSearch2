using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// �񋟁F��֏��N���X
    /// </summary>
	public class OfrSubstInfo : PartsSerchSub
    {
        # region DataTable ��`
		//���
		public const string TABLENAME_SUBST = "TABLENAME_SUBST";

		//�������
		public const string TABLENAME_DSUBST = "TABLENAME_DSUBST";

        // ���ۂ̃����o���L�q
		/// <summary>�J�^���O���i���[�J�[�R�[�h</summary>
		public const string COL_SUBST_CATALOGPARTSMAKERCD = "catalogPartsMakerCd";
		/// <summary>�J�^���O���i���[�J�[����</summary>
		public const string COL_SUBST_CATALOGPARTSMAKERNM = "catalogPartsMakerNm";
		/// <summary>�n�C�t���t���i��</summary>
		public const string COL_SUBST_OLDPARTSNOWITHHYPHEN = "oldPartsNoWithHyphen";
		/// <summary>�n�C�t���t�V�i��</summary>
		public const string COL_SUBST_NEWPARTSNOWITHHYPHEN = "newPartsNoWithHyphen";
		/// <summary>�n�C�t���t�V�i�ԕ\������</summary>
		public const string COL_SUBST_NPRTNOWITHHYPNDSPODR = "nPrtNoWithHypnDspOdr";
		/// <summary>���i������փt���O</summary>
		public const string COL_SUBST_PARTSPLURALSUBSTFLG = "partsPluralSubstFlg";
		/// <summary>���C���E�T�u���i�敪</summary>
		public const string COL_SUBST_MAINORSUBPARTSDIVCD = "mainOrSubPartsDivCd";
		/// <summary>���iQTY</summary>
		public const string COL_SUBST_PARTSQTY = "partsQty";
		/// <summary>���i������֓E�v</summary>
		public const string COL_SUBST_PARTSPLURALSUBSTCMNT = "partsPluralSubstCmnt";
		/// <summary>������֌��n�C�t���t�V�i��</summary>
		public const string COL_SUBST_PLRLSUBNEWPRTNOHYPN = "plrlSubNewPrtNoHypn";
		/// <summary>�n�C�t�����ŐV���i�i��</summary>
		public const string COL_SUBST_NEWPRTSNONONEHYPHEN = "newPrtsNoNoneHyphen";
		/// <summary>BL���i�R�[�h</summary>
		public const string COL_SUBST_TBSPARTSCODE = "tbsPartsCode";
		/// <summary>BL���i�R�[�h�}��</summary>
		public const string COL_SUBST_TBSPARTSCDDERIVEDNO = "tbsPartsCdDerivedNo";
		/// <summary>���[�J�[�񋟕��i����</summary>
		public const string COL_SUBST_MAKEROFFERPARTSNAME = "makerOfferPartsName";
		/// <summary>���i���i</summary>
		public const string COL_SUBST_PARTSPRICE = "partsPrice";
		/// <summary>�w�ʃR�[�h</summary>
		public const string COL_SUBST_PARTSLAYERCD = "partsLayerCd";
		/// <summary>���i��񐧌�t���O</summary>
		public const string COL_SUBST_PARTSINFOCTRLFLG = "partsInfoCtrlFlg";
		/// <summary>���i����</summary>
		public const string COL_SUBST_PARTSNAME = "partsName";
		/// <summary>���i�敪�R�[�h</summary>
		public const string COL_SUBST_PARTSCODE = "partsCode";
		/// <summary>���i�����敪</summary>
		public const string COL_SUBST_PARTSSEARCHCODE = "partsSearchCode";


		public const string COL_PARTS_SELECTED = "Col_Selected";

		/// <summary>
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        /// <returns>CarKindInfo�p��DataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_SUBST_CATALOGPARTSMAKERCD, typeof(int), "�J�^���O���i���[�J�[�R�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_CATALOGPARTSMAKERNM, typeof(string), "�J�^���O���i���[�J�[����"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_OLDPARTSNOWITHHYPHEN, typeof(string), "�n�C�t���t���i��"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_NEWPARTSNOWITHHYPHEN, typeof(string), "�n�C�t���t�V�i��"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_NPRTNOWITHHYPNDSPODR, typeof(int), "�n�C�t���t�V�i�ԕ\������"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PARTSPLURALSUBSTFLG, typeof(int), "���i������փt���O"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_MAINORSUBPARTSDIVCD, typeof(int), "���C���E�T�u���i�敪"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PARTSQTY, typeof(double), "���iQTY"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PARTSPLURALSUBSTCMNT, typeof(string), "���i������֓E�v"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PLRLSUBNEWPRTNOHYPN, typeof(string), "������֌��n�C�t���t�V�i��"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_NEWPRTSNONONEHYPHEN, typeof(string), "�n�C�t�����ŐV���i�i��"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_TBSPARTSCODE, typeof(int), "BL���i�R�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_TBSPARTSCDDERIVEDNO, typeof(int), "BL���i�R�[�h�}��"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_MAKEROFFERPARTSNAME, typeof(string), "���[�J�[�񋟕��i����"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PARTSPRICE, typeof(Int64), "���i���i"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PARTSLAYERCD, typeof(string), "�w�ʃR�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PARTSINFOCTRLFLG, typeof(int), "���i��񐧌�t���O"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PARTSNAME, typeof(string), "���i����"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PARTSCODE, typeof(int), "���i�敪�R�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_SUBST_PARTSSEARCHCODE, typeof(int), "���i�����敪"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_SELECTED, typeof(int), "�s�I��"));

            return wkTable;
        }

		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_SUBST_CATALOGPARTSMAKERCD] = sourcedr[COL_SUBST_CATALOGPARTSMAKERCD];
			dr[COL_SUBST_CATALOGPARTSMAKERCD] = sourcedr[COL_SUBST_CATALOGPARTSMAKERNM];
			dr[COL_SUBST_OLDPARTSNOWITHHYPHEN] = sourcedr[COL_SUBST_OLDPARTSNOWITHHYPHEN];
			dr[COL_SUBST_NEWPARTSNOWITHHYPHEN] = sourcedr[COL_SUBST_NEWPARTSNOWITHHYPHEN];
			dr[COL_SUBST_NPRTNOWITHHYPNDSPODR] = sourcedr[COL_SUBST_NPRTNOWITHHYPNDSPODR];
			dr[COL_SUBST_PARTSPLURALSUBSTFLG] = sourcedr[COL_SUBST_PARTSPLURALSUBSTFLG];
			dr[COL_SUBST_MAINORSUBPARTSDIVCD] = sourcedr[COL_SUBST_MAINORSUBPARTSDIVCD];
			dr[COL_SUBST_PARTSQTY] = sourcedr[COL_SUBST_PARTSQTY];
			dr[COL_SUBST_PARTSPLURALSUBSTCMNT] = sourcedr[COL_SUBST_PARTSPLURALSUBSTCMNT];
			dr[COL_SUBST_PLRLSUBNEWPRTNOHYPN] = sourcedr[COL_SUBST_PLRLSUBNEWPRTNOHYPN];
			dr[COL_SUBST_NEWPRTSNONONEHYPHEN] = sourcedr[COL_SUBST_NEWPRTSNONONEHYPHEN];
			dr[COL_SUBST_TBSPARTSCODE] = sourcedr[COL_SUBST_TBSPARTSCODE];
			dr[COL_SUBST_TBSPARTSCDDERIVEDNO] = sourcedr[COL_SUBST_TBSPARTSCDDERIVEDNO];
			dr[COL_SUBST_MAKEROFFERPARTSNAME] = sourcedr[COL_SUBST_MAKEROFFERPARTSNAME];
			dr[COL_SUBST_PARTSPRICE] = sourcedr[COL_SUBST_PARTSPRICE];
			dr[COL_SUBST_PARTSLAYERCD] = sourcedr[COL_SUBST_PARTSLAYERCD];
			dr[COL_SUBST_PARTSINFOCTRLFLG] = sourcedr[COL_SUBST_PARTSINFOCTRLFLG];
			dr[COL_SUBST_PARTSNAME] = sourcedr[COL_SUBST_PARTSNAME];
			dr[COL_SUBST_PARTSCODE] = sourcedr[COL_SUBST_PARTSCODE];
			dr[COL_SUBST_PARTSSEARCHCODE] = sourcedr[COL_SUBST_PARTSSEARCHCODE];
			return dr;
		}


        # endregion

    }
}
