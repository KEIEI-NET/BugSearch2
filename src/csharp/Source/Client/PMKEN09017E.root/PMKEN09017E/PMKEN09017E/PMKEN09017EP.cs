using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// UI�p�F���i�ڍׁi�^�����j�N���X
    /// </summary>
	public class PartsDetailInfo : PartsSerchSub
    {

        # region DataTable ��`
        public const string TABLENAME_PRTDTL = "TABLENAME_MODELPARTSDETAIL";

		// ���ۂ̃����o���L�q
        public const string COL_PRTDTL_FULLMODELFIXEDNO = "FullModelFixedNo";
        public const string COL_PRTDTL_PARTS_PARTSUNIQUENO = "PartsUniqueNo";
        public const string COL_PRTDTL_DOORCOUNT = "DoorCount";
		public const string COL_PRTDTL_BODYNAME = "BodyName";
		public const string COL_PRTDTL_MODELGRADENM = "ModelGradeNm";
		public const string COL_PRTDTL_ENGINEMODELNM = "EngineModelNm";
		public const string COL_PRTDTL_ENGINEDISPLACENM = "EngineDisplaceNm";
		public const string COL_PRTDTL_EDIVNM = "EDivNm";
		public const string COL_PRTDTL_TRANSMISSIONNM = "TransmissionNm";
		public const string COL_PRTDTL_SHIFTNM = "ShiftNm";
		public const string COL_PRTDTL_ADDICARSPEC1 = "AddiCarSpec1";
		public const string COL_PRTDTL_ADDICARSPEC2 = "AddiCarSpec2";
		public const string COL_PRTDTL_ADDICARSPEC3 = "AddiCarSpec3";
		public const string COL_PRTDTL_ADDICARSPEC4 = "AddiCarSpec4";
		public const string COL_PRTDTL_ADDICARSPEC5 = "AddiCarSpec5";
		public const string COL_PRTDTL_ADDICARSPEC6 = "AddiCarSpec6";
		public const string COL_PRTDTL_ADDICARSPECTITLE1 = "AddiCarSpecTitle1";
		public const string COL_PRTDTL_ADDICARSPECTITLE2 = "AddiCarSpecTitle2";
		public const string COL_PRTDTL_ADDICARSPECTITLE3 = "AddiCarSpecTitle3";
		public const string COL_PRTDTL_ADDICARSPECTITLE4 = "AddiCarSpecTitle4";
		public const string COL_PRTDTL_ADDICARSPECTITLE5 = "AddiCarSpecTitle5";
		public const string COL_PRTDTL_ADDICARSPECTITLE6 = "AddiCarSpecTitle6";
		public const string COL_PRTDTL_PARTSMAKERCD = "PartsMakerCd";
		public const string COL_PRTDTL_PARTSNO = "PartsNo";

        public const string COL_PRTDTL_SELECTED = "Col_Selected";

		/// <summary>
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        /// <returns>CarKindInfo�p��DataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_FULLMODELFIXEDNO, typeof(Int32), "�t���^���Œ�ԍ�"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_PARTS_PARTSUNIQUENO, typeof(Int64), "���i�ŗL�ԍ�"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_MODELGRADENM, typeof(string), "�O���[�h"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_BODYNAME, typeof(string), "�{�f�B"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_DOORCOUNT, typeof(string), "�h�A"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ENGINEMODELNM, typeof(string), "�G���W��"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ENGINEDISPLACENM, typeof(string), "�r�C��"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_EDIVNM, typeof(string), "�d�敪"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_TRANSMISSIONNM, typeof(string), "�~�b�V����"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_SHIFTNM, typeof(string), "�V�t�g"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPEC1, typeof(string), "�ǉ�����1"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPEC2, typeof(string), "�ǉ�����2"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPEC3, typeof(string), "�ǉ�����3"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPEC4, typeof(string), "�ǉ�����4"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPEC5, typeof(string), "�ǉ�����5"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPEC6, typeof(string), "�ǉ�����6"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPECTITLE1, typeof(string), "�ǉ������^�C�g��1"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPECTITLE2, typeof(string), "�ǉ������^�C�g��2"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPECTITLE3, typeof(string), "�ǉ������^�C�g��3"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPECTITLE4, typeof(string), "�ǉ������^�C�g��4"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPECTITLE5, typeof(string), "�ǉ������^�C�g��5"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPECTITLE6, typeof(string), "�ǉ������^�C�g��6"));

			wkTable.Columns.Add(CreateColumn(COL_PRTDTL_PARTSMAKERCD, typeof(Int32), "���i���[�J�[�R�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_PRTDTL_PARTSNO, typeof(string), "�i��"));

            return wkTable;
        }


        # endregion

    }
}
