//***************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �d���ԕi�\��ꗗ�\
// �v���O�����T�v   : �d���ԕi�\��ꗗ�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : FSI���� ����
// �� �� ��   2013/01/28 �C�����e : �V�K�쐬 �d���ԕi�\��@�\�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// �d���ԕi�\��ꗗ�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �d���ԕi�\��ꗗ�\�̒��o���ʃe�[�u���X�L�[�}�ł��B</br>
	/// <br>Programmer : FSI���� ����</br>
	/// <br>Date       :  2013/01/28</br>
	/// </remarks>
    public class PMKAK02035EA
    {
        #region Public Members
        /// <summary>�d���ԕi�\��ꗗ�\�f�[�^�e�[�u����</summary>
        public const string ct_Tbl_StockRetDtl                  = "Tbl_StockRetDtl";
        /// <summary>�d���ԕi�\��ꗗ�\�o�b�t�@�f�[�^�e�[�u����</summary>
        public const string ct_Tbl_StockRetBuffDtl              = "Tbl_ArrivalBuffDtl";

        #region �d���ԕi�\��ꗗ�\�J�������
        /// <summary>���_�R�[�h</summary>
        public const string ct_Col_SectionCode                 = "SectionCode";
        /// <summary>���_�K�C�h����</summary>           
        public const string ct_Col_SectionGuideNm              = "SectionGuideNm";
		/// <summary>�d���`�[�ԍ�</summary>             
		public const string ct_Col_SupplierSlipNo              = "SupplierSlipNo";
		/// <summary>���͓��t</summary>                 
		public const string ct_Col_InputDay                    = "InputDay";
		/// <summary>�d�����t</summary>                 
		public const string ct_Col_StockDate                   = "StockDate";
        /// <summary>�d����R�[�h</summary>               
        public const string ct_Col_SupplierCd                  = "SupplierCd";
        /// <summary>�d���旪��</summary>               
        public const string ct_Col_SupplierSnm                 = "SupplierSnm";
		/// <summary>���i���[�J�[�R�[�h</summary>       
        public const string ct_Col_GoodsMakerCd                = "GoodsMakerCd";
        /// <summary>���[�J�[����</summary>             
        public const string ct_Col_MakerName                   = "MakerName";
        /// <summary>���i�ԍ�</summary>                 
        public const string ct_Col_GoodsNo                     = "GoodsNo";
        /// <summary>���i����</summary>                 
        public const string ct_Col_GoodsName                   = "GoodsName";
		/// <summary>�d����</summary>
		public const string ct_Col_StockCount                  = "StockCount";
		/// <summary>�d���P���i�ō��C�����j</summary>
		public const string ct_Col_StockUnitTaxPriceFl         = "StockUnitTaxPriceFl";
		/// <summary>�d���P���i�Ŕ��C�����j</summary>
		public const string ct_Col_StockUnitPriceFl            = "StockUnitPriceFl";
		/// <summary>�d�����z�i�ō��݁j</summary>
		public const string ct_Col_StockPriceTaxInc            = "StockPriceTaxInc";
		/// <summary>�d�����z�i�Ŕ����j</summary>
		public const string ct_Col_StockPriceTaxExc            = "StockPriceTaxExc";
		/// <summary>�ېŋ敪</summary>
		public const string ct_Col_TaxationCode                = "TaxationCode";
		/// <summary>�ԕi�\��敪</summary>
        public const string ct_Col_ReturnedGoodsType           = "ReturnedGoodsType";
		/// <summary>���[�^�C�g��</summary>
		public const string ct_Col_ListTitle                   = "ListTitle";
        /// <summary>�d���`�[���l1</summary>
        public const string ct_Col_SupplierSlipNote1           = "SupplierSlipNote1";
        /// <summary>�d�������œ]�ŕ����R�[�h</summary>
        public const string ct_Col_SuppCTaxLayCd               = "SuppCTaxLayCd";
        /// <summary>BL���i�R�[�h</summary>
        public const string ct_Col_BLGoodsCode                 = "BLGoodsCode";
        /// <summary>BL���i����</summary>
        public const string ct_Col_BLGoodsName                 = "BLGoodsName";
        /// <summary>�d�����z����Ŋz</summary>
        public const string ct_Col_StockPriceConsTax           = "StockPriceConsTax";
        /// <summary>�`�[�敪</summary>
        public const string ct_Col_SupplierSlipCd              = "SupplierSlipCd";
        /// <summary>�Ŕ��`�[���z</summary>
        public const string ct_Col_StockTtlPricTaxExc          = "StockTtlPricTaxExc";
        /// <summary>�ō��`�[���z</summary>
        public const string ct_Col_StockTtlPricTaxInc          = "StockTtlPricTaxInc";
        /// <summary>�`�[�����</summary>
        public const string ct_Col_SlpConsTax                  = "SlpConsTax";
        /// <summary>���׏����</summary>
        public const string ct_Col_DtlConsTax                  = "DtlConsTax";
        /// <summary>�Ŕ��艿</summary>
        public const string ct_Col_ListPriceTaxExc             = "ListPriceTaxExc";
        /// <summary>�ō��艿</summary>
        public const string ct_Col_ListPriceTaxInc             = "ListPriceTaxInc";

        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// �d���ԕi�\��ꗗ�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���ԕi�\��ꗗ�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���܂��B</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        public PMKAK02035EA()
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// �f�[�^�Z�b�g�A�f�[�^�e�[�u���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        public static void SettingDataSet(ref DataSet ds)
        {
            // �e�[�u�������݂��邩�ǂ������`�F�b�N
            if ((ds.Tables.Contains(ct_Tbl_StockRetDtl)))
            {
                // �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[ct_Tbl_StockRetDtl].Clear();
            }
            else
            {
                CreateSaleConfTable(ref ds, 0);

            }

            // �d���`�F�b�N���X�g�o�b�t�@�f�[�^�e�[�u��
            // �e�[�u�������݂��邩�ǂ������`�F�b�N
            if ((ds.Tables.Contains(ct_Tbl_StockRetBuffDtl)))
            {
                // �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[ct_Tbl_StockRetBuffDtl].Clear();
            }
            else
            {
                CreateSaleConfTable(ref ds, 1);
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// �d���ԕi�\��ꗗ�\���o���ʍ쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private static void CreateSaleConfTable(ref DataSet ds, int buffCheck)
        {
            DataTable dt = null;
            if (buffCheck == 0)
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(ct_Tbl_StockRetDtl);
                dt = ds.Tables[ct_Tbl_StockRetDtl];
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(ct_Tbl_StockRetBuffDtl);
                dt = ds.Tables[ct_Tbl_StockRetBuffDtl];
            }

            // ���_�R�[�h
            dt.Columns.Add(ct_Col_SectionCode, typeof(string));
            dt.Columns[ct_Col_SectionCode].DefaultValue = "";
            // ���_�K�C�h����
            dt.Columns.Add(ct_Col_SectionGuideNm, typeof(string));
            dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";
			// �d���`�[�ԍ�
			dt.Columns.Add(ct_Col_SupplierSlipNo, typeof(string));
			dt.Columns[ct_Col_SupplierSlipNo].DefaultValue = "";
			// ���͓��t
			dt.Columns.Add(ct_Col_InputDay, typeof(DateTime));
			dt.Columns[ct_Col_InputDay].DefaultValue = null;
			// �d�����t
			dt.Columns.Add(ct_Col_StockDate, typeof(DateTime));
			dt.Columns[ct_Col_StockDate].DefaultValue = null;
            // �d����R�[�h
            dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));
            dt.Columns[ct_Col_SupplierCd].DefaultValue = 0;
            // �d���旪��
            dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));
            dt.Columns[ct_Col_SupplierSnm].DefaultValue = "";
            // ���i���[�J�[�R�[�h
            dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
            dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = 0;
            // ���[�J�[����
            dt.Columns.Add(ct_Col_MakerName, typeof(string));
            dt.Columns[ct_Col_MakerName].DefaultValue = "";
            // ���i�ԍ�
            dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
            dt.Columns[ct_Col_GoodsNo].DefaultValue = "";
            // ���i����
            dt.Columns.Add(ct_Col_GoodsName, typeof(string));
            dt.Columns[ct_Col_GoodsName].DefaultValue = "";
			// �d����
			dt.Columns.Add(ct_Col_StockCount, typeof(Double));
			dt.Columns[ct_Col_StockCount].DefaultValue = 0;
			// �d���P���i�ō��C�����j
			dt.Columns.Add(ct_Col_StockUnitTaxPriceFl, typeof(Double));
			dt.Columns[ct_Col_StockUnitTaxPriceFl].DefaultValue = 0;
			// �d���P���i�Ŕ��C�����j
			dt.Columns.Add(ct_Col_StockUnitPriceFl, typeof(Double));
			dt.Columns[ct_Col_StockUnitPriceFl].DefaultValue = 0;
			// �d�����z�i�ō��݁j
			dt.Columns.Add(ct_Col_StockPriceTaxInc, typeof(Int64));
			dt.Columns[ct_Col_StockPriceTaxInc].DefaultValue = 0;
			// �d�����z�i�Ŕ����j
			dt.Columns.Add(ct_Col_StockPriceTaxExc, typeof(Int64));
			dt.Columns[ct_Col_StockPriceTaxExc].DefaultValue = 0;
			// �ېŋ敪
			dt.Columns.Add(ct_Col_TaxationCode, typeof(Int32));
			dt.Columns[ct_Col_TaxationCode].DefaultValue = 0;
			// �ԕi�d���敪
            dt.Columns.Add(ct_Col_ReturnedGoodsType, typeof(string));
            dt.Columns[ct_Col_ReturnedGoodsType].DefaultValue = "";
			// ���[�^�C�g��
			dt.Columns.Add(ct_Col_ListTitle, typeof(string));
			dt.Columns[ct_Col_ListTitle].DefaultValue = "";
            // �d���`�[���l1
            dt.Columns.Add(ct_Col_SupplierSlipNote1, typeof(string));
            dt.Columns[ct_Col_SupplierSlipNote1].DefaultValue = "";
            // �d�������œ]�ŕ����R�[�h
            dt.Columns.Add(ct_Col_SuppCTaxLayCd, typeof(Int32));
            dt.Columns[ct_Col_SuppCTaxLayCd].DefaultValue = 0;
            // BL���i�R�[�h
            dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));
            dt.Columns[ct_Col_BLGoodsCode].DefaultValue = 0;
            // BL���i����
            dt.Columns.Add(ct_Col_BLGoodsName, typeof(string));
            dt.Columns[ct_Col_BLGoodsName].DefaultValue = 0;
            // �`�[�敪
            dt.Columns.Add(ct_Col_SupplierSlipCd, typeof(string));
            dt.Columns[ct_Col_SupplierSlipCd].DefaultValue = 0;
            // �Ŕ��`�[���z
            dt.Columns.Add(ct_Col_StockTtlPricTaxExc, typeof(string));
            dt.Columns[ct_Col_StockTtlPricTaxExc].DefaultValue = 0;
            // �ō��`�[���z
            dt.Columns.Add(ct_Col_StockTtlPricTaxInc, typeof(string));
            dt.Columns[ct_Col_StockTtlPricTaxInc].DefaultValue = 0;
            // �`�[�����
            dt.Columns.Add(ct_Col_SlpConsTax, typeof(string));
            dt.Columns[ct_Col_SlpConsTax].DefaultValue = 0;
            // ���׏����
            dt.Columns.Add(ct_Col_DtlConsTax, typeof(string));
            dt.Columns[ct_Col_DtlConsTax].DefaultValue = 0;
            // �Ŕ��艿
            dt.Columns.Add(ct_Col_ListPriceTaxExc, typeof(string));
            dt.Columns[ct_Col_ListPriceTaxExc].DefaultValue = 0;
            // �ō��艿
            dt.Columns.Add(ct_Col_ListPriceTaxInc, typeof(string));
            dt.Columns[ct_Col_ListPriceTaxInc].DefaultValue = 0;
        }
        #endregion
    }
}