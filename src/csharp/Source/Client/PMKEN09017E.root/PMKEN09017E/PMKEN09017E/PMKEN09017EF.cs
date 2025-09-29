using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// �񋟁F���i���N���X
    /// </summary>
	public class OfrPartsInfo : PartsSerchSub
    {
        # region DataTable ��`
		public const string TABLENAME_PARTS = "TABLENAME_PARTS";
		public const string TABLENAME_PARTSDETAIL = "TABLENAME_PARTSDETAIL";

        // ���ۂ̃����o���L�q
		/// <summary>���i�����敪</summary>
		public const string COL_PARTS_PARTSSEARCHCODE = "PartsSearchCode";
		/// <summary>���i�i���݋敪</summary>
		public const string COL_PARTS_PARTSNARROWINGCODE = "PartsNarrowingCode";
		/// <summary>���i����</summary>
		public const string COL_PARTS_PARTSNAME = "partsName";
		/// <summary>���i�敪�R�[�h</summary>
		public const string COL_PARTS_PARTSCODE = "partsCode";
		/// <summary>��ƕ��i�敪����</summary>
		public const string COL_PARTS_WORKORPARTSDIVNM = "workOrPartsDivNm";
		/// <summary>�t���^���Œ�ԍ�</summary>
		public const string COL_PARTS_FULLMODELFIXEDNO = "fullModelFixedNo";
		/// <summary>BL�R�[�h</summary>
		public const string COL_PARTS_TBSPARTSCODE = "tbsPartsCode";
		/// <summary>BL�R�[�h�}��</summary>
		public const string COL_PARTS_TBSPARTSCDDERIVEDNO = "tbsPartsCdDerivedNo";
		/// <summary>BL�R�[�h�}�ԗp���i����</summary>
		public const string COL_PARTS_TBSPARTSCDDERIVEDNM = "tbsPartsCdDerivedNm";
		/// <summary>Fig�}��</summary>
		public const string COL_PARTS_FIGSHAPENO = "figshapeNo";
		/// <summary>�}�ԓ��s�ԍ�</summary>
		public const string COL_PARTS_SHAPENOINSIDEROWNO = "shapeNoInsideRowNo";
		/// <summary>�^���ʕ��i�̗p�N��</summary>
		public const string COL_PARTS_MODELPRTSADPTYM = "modelPrtsAdptYm";
		/// <summary>�^���ʕ��i�p�~�N��</summary>
		public const string COL_PARTS_MODELPRTSABLSYM = "modelPrtsAblsYm";
		/// <summary>�^���ʕ��i�̗p�ԑ�ԍ�</summary>
		public const string COL_PARTS_MODELPRTSADPTFRAMENO = "modelPrtsAdptFrameNo";
		/// <summary>�^���ʕ��i�p�~�ԑ�ԍ�</summary>
		public const string COL_PARTS_MODELPRTSABLSFRAMENO = "modelPrtsAblsFrameNo";
		/// <summary>���iQTY</summary>
		public const string COL_PARTS_PARTSQTY = "partsQty";
		/// <summary>���i�I�v�V��������</summary>
		public const string COL_PARTS_PARTSOPNM = "partsOpNm";
		/// <summary>�K�i����</summary>
		public const string COL_PARTS_STANDARDNAME = "standardName";
		/// <summary>�J�^���O���i���[�J�[�R�[�h</summary>
		public const string COL_PARTS_CATALOGPARTSMAKERCD = "catalogPartsMakerCd";
		/// <summary>�J�^���O���i���[�J�[�R�[�h</summary>
		public const string COL_PARTS_CATALOGPARTSMAKERNM = "catalogPartsMakerNm";
	
		/// <summary>�n�C�t���t�J�^���O���i�i��</summary>
		public const string COL_PARTS_CLGPRTSNOWITHHYPHEN = "clgPrtsNoWithHyphen";
		/// <summary>����n�t���O</summary>
		public const string COL_PARTS_COLDDISTRICTSFLAG = "coldDistrictsFlag";
		/// <summary>�J���[�i���t���O</summary>
		public const string COL_PARTS_COLORNARROWINGFLAG = "colorNarrowingFlag";
		/// <summary>�g�����i���t���O</summary>
		public const string COL_PARTS_TRIMNARROWINGFLAG = "trimNarrowingFlag";
		/// <summary>�����i���t���O</summary>
		public const string COL_PARTS_EQUIPNARROWINGFLAG = "equipNarrowingFlag";
		/// <summary>�n�C�t���t�ŐV���i�i��</summary>
		public const string COL_PARTS_NEWPRTSNOWITHHYPHEN = "newPrtsNoWithHyphen";
		/// <summary>�n�C�t�����ŐV���i�i��</summary>
		public const string COL_PARTS_NEWPRTSNONONEHYPHEN = "newPrtsNoNoneHyphen";
		/// <summary>���[�J�[�ʕ��i����</summary>
		public const string COL_PARTS_MAKEROFFERPARTSNAME = "makerOfferPartsName";
		/// <summary>���i���i</summary>
		public const string COL_PARTS_PARTSPRICE = "partsPrice";
		/// <summary>�w�ʃR�[�h</summary>
		public const string COL_PARTS_PARTSLAYERCD = "partsLayerCd";
		/// <summary>���i�ŗL�ԍ�</summary>
		public const string COL_PARTS_PARTSUNIQUENO = "PartsUniqueNo";

		public const string COL_PARTS_SELECTED = "Col_Selected";

		/// <summary>
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        /// <returns>CarKindInfo�p��DataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_PARTS_PARTSSEARCHCODE, typeof(int), "���i�����敪"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_PARTSNARROWINGCODE, typeof(int), "���i�i���݋敪"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_PARTSNAME, typeof(string), "���i����"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_PARTSCODE, typeof(int), "���i�敪�R�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_WORKORPARTSDIVNM, typeof(string), "��ƕ��i�敪����"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_FULLMODELFIXEDNO, typeof(int), "�t���^���Œ�ԍ�"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_TBSPARTSCODE, typeof(int), "BL�R�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_TBSPARTSCDDERIVEDNO, typeof(int), "BL�R�[�h�}��"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_TBSPARTSCDDERIVEDNM, typeof(string), "BL�R�[�h�}�ԗp���i����"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_FIGSHAPENO, typeof(string), "Fig�}��"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_SHAPENOINSIDEROWNO, typeof(int), "�}�ԓ��s�ԍ�"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_MODELPRTSADPTYM, typeof(int), "�^���ʕ��i�̗p�N��"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_MODELPRTSABLSYM, typeof(int), "�^���ʕ��i�p�~�N��"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_MODELPRTSADPTFRAMENO, typeof(int), "�^���ʕ��i�̗p�ԑ�ԍ�"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_MODELPRTSABLSFRAMENO, typeof(int), "�^���ʕ��i�p�~�ԑ�ԍ�"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_PARTSQTY, typeof(double), "���iQTY"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_PARTSOPNM, typeof(string), "���i�I�v�V��������"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_STANDARDNAME, typeof(string), "�K�i����"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_CATALOGPARTSMAKERCD, typeof(int), "�J�^���O���i���[�J�[�R�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_CATALOGPARTSMAKERNM, typeof(string), "�J�^���O���i���[�J�[����"));


			wkTable.Columns.Add(CreateColumn(COL_PARTS_CLGPRTSNOWITHHYPHEN, typeof(string), "�n�C�t���t�J�^���O���i�i��"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_COLDDISTRICTSFLAG, typeof(int), "����n�t���O"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_COLORNARROWINGFLAG, typeof(int), "�J���[�i���t���O"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_TRIMNARROWINGFLAG, typeof(int), "�g�����i���t���O"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_EQUIPNARROWINGFLAG, typeof(int), "�����i���t���O"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_NEWPRTSNOWITHHYPHEN, typeof(string), "�n�C�t���t�ŐV���i�i��"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_NEWPRTSNONONEHYPHEN, typeof(string), "�n�C�t�����ŐV���i�i��"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_MAKEROFFERPARTSNAME, typeof(string), "���[�J�[�ʕ��i����"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_PARTSPRICE, typeof(Int64), "���i���i"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_PARTSLAYERCD, typeof(string), "�w�ʃR�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_PARTSUNIQUENO, typeof(Int64), "���i�ŗL�ԍ�"));
			wkTable.Columns.Add(CreateColumn(COL_PARTS_SELECTED, typeof(int), "�s�I��"));

            return wkTable;
        }

		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_PARTS_PARTSSEARCHCODE] = sourcedr[COL_PARTS_PARTSSEARCHCODE];
			dr[COL_PARTS_PARTSNARROWINGCODE] = sourcedr[COL_PARTS_PARTSNARROWINGCODE];
			dr[COL_PARTS_PARTSNAME] = sourcedr[COL_PARTS_PARTSNAME];
			dr[COL_PARTS_PARTSCODE] = sourcedr[COL_PARTS_PARTSCODE];
			dr[COL_PARTS_WORKORPARTSDIVNM] = sourcedr[COL_PARTS_WORKORPARTSDIVNM];
			dr[COL_PARTS_FULLMODELFIXEDNO] = sourcedr[COL_PARTS_FULLMODELFIXEDNO];
			dr[COL_PARTS_TBSPARTSCODE] = sourcedr[COL_PARTS_TBSPARTSCODE];
			dr[COL_PARTS_TBSPARTSCDDERIVEDNO] = sourcedr[COL_PARTS_TBSPARTSCDDERIVEDNO];
			dr[COL_PARTS_TBSPARTSCDDERIVEDNM] = sourcedr[COL_PARTS_TBSPARTSCDDERIVEDNM];
			dr[COL_PARTS_FIGSHAPENO] = sourcedr[COL_PARTS_FIGSHAPENO];
			dr[COL_PARTS_SHAPENOINSIDEROWNO] = sourcedr[COL_PARTS_SHAPENOINSIDEROWNO];
			dr[COL_PARTS_MODELPRTSADPTYM] = sourcedr[COL_PARTS_MODELPRTSADPTYM];
			dr[COL_PARTS_MODELPRTSABLSYM] = sourcedr[COL_PARTS_MODELPRTSABLSYM];
			dr[COL_PARTS_MODELPRTSADPTFRAMENO] = sourcedr[COL_PARTS_MODELPRTSADPTFRAMENO];
			dr[COL_PARTS_MODELPRTSABLSFRAMENO] = sourcedr[COL_PARTS_MODELPRTSABLSFRAMENO];
			dr[COL_PARTS_PARTSQTY] = sourcedr[COL_PARTS_PARTSQTY];
			dr[COL_PARTS_PARTSOPNM] = sourcedr[COL_PARTS_PARTSOPNM];
			dr[COL_PARTS_STANDARDNAME] = sourcedr[COL_PARTS_STANDARDNAME];
			dr[COL_PARTS_CATALOGPARTSMAKERCD] = sourcedr[COL_PARTS_CATALOGPARTSMAKERCD];
			dr[COL_PARTS_CATALOGPARTSMAKERNM] = sourcedr[COL_PARTS_CATALOGPARTSMAKERNM];
			dr[COL_PARTS_CLGPRTSNOWITHHYPHEN] = sourcedr[COL_PARTS_CLGPRTSNOWITHHYPHEN];
			dr[COL_PARTS_COLDDISTRICTSFLAG] = sourcedr[COL_PARTS_COLDDISTRICTSFLAG];
			dr[COL_PARTS_COLORNARROWINGFLAG] = sourcedr[COL_PARTS_COLORNARROWINGFLAG];
			dr[COL_PARTS_TRIMNARROWINGFLAG] = sourcedr[COL_PARTS_TRIMNARROWINGFLAG];
			dr[COL_PARTS_EQUIPNARROWINGFLAG] = sourcedr[COL_PARTS_EQUIPNARROWINGFLAG];
			dr[COL_PARTS_NEWPRTSNOWITHHYPHEN] = sourcedr[COL_PARTS_NEWPRTSNOWITHHYPHEN];
			dr[COL_PARTS_NEWPRTSNONONEHYPHEN] = sourcedr[COL_PARTS_NEWPRTSNONONEHYPHEN];
			dr[COL_PARTS_MAKEROFFERPARTSNAME] = sourcedr[COL_PARTS_MAKEROFFERPARTSNAME];
			dr[COL_PARTS_PARTSPRICE] = sourcedr[COL_PARTS_PARTSPRICE];
			dr[COL_PARTS_PARTSLAYERCD] = sourcedr[COL_PARTS_PARTSLAYERCD];
			dr[COL_PARTS_PARTSUNIQUENO] = sourcedr[COL_PARTS_PARTSUNIQUENO];
			return dr;
		}


        # endregion

    }
}
