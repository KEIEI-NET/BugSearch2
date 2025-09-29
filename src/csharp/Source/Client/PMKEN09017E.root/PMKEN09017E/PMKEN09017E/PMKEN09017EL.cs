using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// �D�ǐݒ���N���X
    /// </summary>
	public class PrimeSettingInfo : PartsSerchSub
    {

        # region DataTable ��`
        public const string TABLENAME_PRIMESETTING = "PrimeSetting_Table";
        public const string TABLENAME_OFFER_PRIMESETTING = "Offer_PrimeSetting_Table";
        public const string TABLENAME_USER_PRIMESETTING = "User_PrimeSetting_Table";

        /// <summary>�����ރR�[�h </summary>
        public const string COL_MIDDLEGENRECODE = "MiddleGenreCode";
        /// <summary>���[�J�[�R�[�h </summary>
        public const string COL_PARTSMAKERCD = "PartsMakerCd";
        /// <summary>BL�R�[�h </summary>
        public const string COL_TBSPARTSCODE = "TbsPartsCode";
        /// <summary>BL�R�[�h�}��</summary>
        public const string COL_TBSPARTSCDDERIVEDNO = "TbsPartsCdDerivedNo";

        /// <summary>�����ޖ��� </summary>
        public const string COL_MIDDLEGENRENAME = "MiddleGenreName";
        /// <summary>���[�J�[����(�S�p) </summary>
        public const string COL_PARTSMAKERFULLNAME = "PartsMakerFullName";
        /// <summary>���[�J�[����(���p) </summary>
        public const string COL_PARTSMAKERHALFNAME = "PartsMakerHalfName";
        /// <summary>BL���i���� </summary>
        public const string COL_TBSPARTSFULLNAME = "TbsPartsFullName";
        /// <summary>BL���i����(���p)</summary>
        public const string COL_TBSPARTSHALFNAME = "TbsPartsHalfName";
        /// <summary>�V�[�N���b�g�敪</summary>
        /// <remarks>0:�ʏ�@1:�V�[�N���b�g</remarks>
        public const string COL_SECRETCODE = "SecretCode";
        /// <summary>�\������</summary>
        public const string COL_DISPLAYORDER = "DisplayOrder";
        /// <summary>���[�J�[�\������</summary>
        public const string COL_MAKERDISPORDER = "MakerDisplayOrder";
        /// <summary>�Z���N�g�R�[�h</summary>
        public const string COL_SELECTCODE = "SelectCode";
        /// <summary>�Z���N�g����</summary>
        public const string COL_SELECTNAME = "SelectName";
        /// <summary>�D�ǎ�ʃR�[�h</summary>
        public const string COL_PRIMEKINDCODE = "PrimeKindCode";
        /// <summary>�D�ǎ�ʖ���</summary>
        public const string COL_PRIMEKINDNAME = "PrimeKindName";
        /// <summary>�d����R�[�h</summary>
        public const string COL_SUPPLIERCD = "SupplierCd";
        /// <summary>�d����R�[�h</summary>
        public const string COL_SUPPLIERNAME = "SupplierName";
        /// <summary>�d����R�[�h�}��</summary>
        public const string COL_SUPPLIERCDDERIVEDNO = "SupplierCdDerivedNo";
        /// <summary>�\���敪</summary>
        /// <remarks>0:�����@1:���i&�����@2:���i</remarks>
        public const string COL_PRIMEDISPLAYCODE = "PrimeDisplayCode";
        /// <summary>�d�v�敪 </summary>
        public const string COL_IMPORTANTCODE = "ImportantCode";
        /// <summary>�D�ǐݒ���l </summary>
        public const string COL_PRIMESETTINGNOTE = "PrimeSettingNote";

        public const string COL_SUPPLIERGUIDE = "SupplierGuide";  // ADD 2008/07/04

        /// <summary>�D�ǐݒ�O���[�v</summary>
        public const string COL_PRMSETGROUP = "PrmSetGroup";    // ADD 2009/01/15

		/// <summary>
        /// �f�[�^�e�[�u���쐬���\�b�h
        /// </summary>
        /// <returns>CarKindInfo�p��DataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

			wkTable.Columns.Add(CreateColumn(COL_MIDDLEGENRECODE, typeof(int), "�����ރR�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_TBSPARTSCODE, typeof(int), "BL�R�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_TBSPARTSCDDERIVEDNO, typeof(int), "BL�R�[�h�}��"));
			wkTable.Columns.Add(CreateColumn(COL_PARTSMAKERCD, typeof(int), "���[�J�[�R�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_SELECTCODE, typeof(int), "�Z���N�g�R�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_PRIMEKINDCODE, typeof(int), "�D�ǎ�ʃR�[�h"));
			wkTable.Columns.Add(CreateColumn(COL_PRIMEKINDNAME, typeof(string), "�D�ǎ�ʖ���"));
			wkTable.Columns.Add(CreateColumn(COL_MAKERDISPORDER, typeof(Int32), "���[�J�[�\������"));
			wkTable.Columns.Add(CreateColumn(COL_PRIMEDISPLAYCODE, typeof(int), "�\���敪"));
			wkTable.Columns.Add(CreateColumn(COL_DISPLAYORDER, typeof(int), "�\������"));

            return wkTable;
        }
/*
		public static DataRow CreateDataRow(DataRow sourcedr, DataRow dr)
		{
			dr[COL_YURYO_MIDDLEGENRECODE] = sourcedr[COL_YURYO_MIDDLEGENRECODE];
			dr[COL_YURYO_TBSPARTSCODE] = sourcedr[COL_YURYO_TBSPARTSCODE];
			dr[COL_YURYO_TBSPARTSCDDERIVEDNO] = sourcedr[COL_YURYO_TBSPARTSCDDERIVEDNO];
			dr[COL_YURYO_PARTSMAKERCD] = sourcedr[COL_YURYO_PARTSMAKERCD];
			dr[COL_YURYO_SELECTCODE] = sourcedr[COL_YURYO_SELECTCODE];
			dr[COL_YURYO_PRIMEKINDCODE] = sourcedr[COL_YURYO_PRIMEKINDCODE];
			dr[COL_YURYO_PRIMEKINDNAME] = sourcedr[COL_YURYO_PRIMEKINDNAME];
			dr[COL_YURYO_PRIMEDISPLAYCODE] = sourcedr[COL_YURYO_PRIMEDISPLAYCODE];
			dr[COL_YURYO_MAKERDISPORDER] = sourcedr[COL_YURYO_MAKERDISPORDER];
			dr[COL_YURYO_DISPLAYORDER] = sourcedr[COL_YURYO_DISPLAYORDER];
			return dr;
		}
        */
        # endregion

    }
}
