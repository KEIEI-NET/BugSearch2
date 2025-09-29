using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// �d���m�F�\(�`�[�P��)���o���ʃf�[�^�e�[�u���X�L�[�}�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �d���m�F�\(�`�[�P��)�̒��o���ʃe�[�u���X�L�[�}�ł��B</br>
	/// <br>Programmer : 96186�@���ԗT��</br>
	/// <br>Date       : 2008.01.16</br>
    /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer : 3H ����</br>
    /// <br>Date       : 2020/02/27</br>
    /// <br>Update Note: 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j </br>
    /// <br>Programmer : ���O </br>
    /// <br>Date       : 2022/09/28</br>
	/// </remarks>
	public class MAKON02249EB
	{
		#region Public Members
        /// <summary>�d���m�F�\(�`�[�P��)�f�[�^�e�[�u����</summary>
        public const string CT_StockConfSlipTtlDataTable = "StockConfSlipTtlDataTable";

		#region �d���m�F�\�i�`�[�P�ʁj�J�������
        /// <summary>���_�R�[�h</summary>
		public const string CT_StockConfSlipTtl_SectionCodeRF = "SectionCodeRF";
        /// <summary>���_�K�C�h����</summary>
		public const string CT_StockConfSlipTtl_SectionGuideNmRF = "SectionGuideNmRF";

        // --- DEL 2008/07/16 -------------------------------->>>>>
        ///// <summary>���Ӑ�R�[�h</summary>
        //public const string CT_StockConfSlipTtl_CustomerCodeRF = "CustomerCodeRF";
        ///// <summary>���Ӑ於��</summary>
        //public const string CT_StockConfSlipTtl_CustomerSnmRF = "CustomerSnmRF";
        // --- DEL 2008/07/16 --------------------------------<<<<< 

        // --- ADD 2008/07/16 -------------------------------->>>>>
        /// <summary>�d����R�[�h</summary>
        public const string CT_StockConfSlipTtl_SupplierCd = "SupplierCd";
        /// <summary>�d���於��</summary>
        public const string CT_StockConfSlipTtl_SupplierSnm = "SupplierSnm";
        // --- ADD 2008/07/16 --------------------------------<<<<< 

		/// <summary>���͓��t</summary>
		public const string CT_StockConfSlipTtl_InputDayRF = "InputDayRF";
		/// <summary>���͓��t(���)</summary>
		public const string CT_StockConfSlipTtl_InputDayNmRF = "InputDayNmRF";
        /// <summary>���ד��t</summary>
		public const string CT_StockConfSlipTtl_ArrivalGoodsDayRF = "ArrivalGoodsDayRF";
		/// <summary>�d�����t</summary>
		public const string CT_StockConfSlipTtl_StockDateRF = "StockDateRF";
		/// <summary>�d�����t(���)</summary>
		public const string CT_StockConfSlipTtl_StockDateNmRF = "StockDateNmRF";
        /// <summary>�d���`��</summary>
		public const string CT_StockConfSlipTtl_SupplierFormalRF = "SupplierFormalRF";
        /// <summary>�d���`����</summary>
		public const string CT_StockConfSlipTtl_SupplierFormalNmRF = "SupplierFormalNmRF";
        /// <summary>�d���`�[�ԍ�</summary>
		public const string CT_StockConfSlipTtl_SupplierSlipNoRF = "SupplierSlipNoRF";
		/// <summary>�����`�[�ԍ�</summary>
		public const string CT_StockConfSlipTtl_PartySaleSlipNumRF = "PartySaleSlipNumRF";
        /// <summary>�d���`�[�敪</summary>
		public const string CT_StockConfSlipTtl_SupplierSlipCdRF = "SupplierSlipCdRF";
        /// <summary>�d���`�[�敪��</summary>
		public const string CT_StockConfSlipTtl_SupplierSlipNmRF = "SupplierSlipNmRF";

        /// <summary>�d�����z�v�i�Ŕ����j</summary>
		public const string CT_StockConfSlipTtl_StockTtlPricTaxExcRF = "StockTtlPricTaxExcRF";
		/// <summary>�d�����z����Ŋz</summary>
		public const string CT_StockConfSlipTtl_StockPriceConsTaxRF = "StockPriceConsTaxRF";
		/// <summary>�d�����z�v�i�ō��݁j</summary>
		public const string CT_StockConfSlipTtl_StockPriceTaxIncRF = "StockPriceTaxIncRF";
		
		/// <summary>�`�[����(����)</summary>
		public const string CT_StockConfSlipTtl_SalSlipCntRF = "SalSlipCntRF";
		/// <summary>�`�[����(�ԕi�l��)</summary>
		public const string CT_StockConfSlipTtl_DisSlipCntRF = "DisSlipCntRF";
		/// <summary>�`�[����(���v)</summary>
		public const string CT_StockConfSlipTtl_TotleSlipCntRF = "TotleSlipCntRF";

		/// <summary>�d�����z(����)</summary>
		public const string CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF = "SalStockTtlPricTaxExcRF";
		/// <summary>�����(����)</summary>
		public const string CT_StockConfSlipTtl_SalStockPriceConsTaxRF = "SalStockPriceConsTaxRF";
		/// <summary>���v���z(����)</summary>
		public const string CT_StockConfSlipTtl_SalTotalPriceRF = "SalTotalPriceRF";

        // 2009.01.09 30413 ���� �l���̋��z��ǉ� >>>>>>START
        ///// <summary>�d�����z(�ԕi�l��)</summary>
        //public const string CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF = "DisStockTtlPricTaxExcRF";
        ///// <summary>�����(�ԕi�l��)</summary>
        //public const string CT_StockConfSlipTtl_DisStockPriceConsTaxRF = "DisStockPriceConsTaxRF";
        ///// <summary>���v���z(�ԕi�l��)</summary>
        //public const string CT_StockConfSlipTtl_DisTotalPriceRF = "DisTotalPriceRF";
        /// <summary>�d�����z(�ԕi)</summary>
        public const string CT_StockConfSlipTtl_RetGdsStockTtlPricTaxExcRF = "RetGdsStockTtlPricTaxExcRF";
        /// <summary>�����(�ԕi)</summary>
        public const string CT_StockConfSlipTtl_RetGdsStockPriceConsTaxRF = "RetGdsStockPriceConsTaxRF";
        /// <summary>���v���z(�ԕi)</summary>
        public const string CT_StockConfSlipTtl_RetGdsTotalPriceRF = "RetGdsTotalPriceRF";

        // --- ADD START 3H ���� 2020/02/27 ----->>>>>
        /// <summary> ����Őŗ� </summary>
        public const String CT_Col_ConsTaxRate = "SupplierConsTaxRate";

        #region �u����Őŗ��P�v
        /// <summary>Title_�ŗ��P</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_Title = "TaxRate1Title";
        /// <summary>�d������_�ŗ��P</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_SalSlipCntRF = "TaxRate1SalSlipCntRF";
        /// <summary>�d�����z�v�i�Ŕ����j_�ŗ��P</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_StockTtlPricTaxExcRF = "TaxRate1StockTtlPricTaxExcRF";
        /// <summary>�d�����z����Ŋz_�ŗ��P</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_StockPriceConsTaxRF = "TaxRate1StockPriceConsTaxRF";
        /// <summary>�d�����z�v�i�ō��݁j_�ŗ��P</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_StockPriceTaxIncRF = "TaxRate1StockPriceTaxIncRF";

        /// <summary>Title(�ԕi)_�ŗ��P</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_RetTitle = "TaxRate1RetTitle";
        /// <summary>�d������(�ԕi�l��)_�ŗ��P</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_DisSlipCntRF = "TaxRate1DisSlipCntRF";
        /// <summary>�d�����z(�ԕi)_�ŗ��P</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_RetGdsStockTtlPricTaxExcRF = "TaxRate1RetGdsStockTtlPricTaxExcRF";
        /// <summary>�����(�ԕi)_�ŗ��P</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_RetGdsStockPriceConsTaxRF = "TaxRate1RetGdsStockPriceConsTaxRF";
        /// <summary>���v���z(�ԕi)_�ŗ��P</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_RetGdsTotalPriceRF = "TaxRate1RetGdsTotalPriceRF";
        #endregion

        #region �u����Őŗ��Q�v
        /// <summary>Title_�ŗ�2</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_Title = "TaxRate2Title";
        /// <summary>�d������_�ŗ��Q</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_SalSlipCntRF = "TaxRate2SalSlipCntRF";
        /// <summary>�d�����z�v�i�Ŕ����j_�ŗ��Q</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_StockTtlPricTaxExcRF = "TaxRate2StockTtlPricTaxExcRF";
        /// <summary>�d�����z����Ŋz_�ŗ��Q</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_StockPriceConsTaxRF = "TaxRate2StockPriceConsTaxRF";
        /// <summary>�d�����z�v�i�ō��݁j_�ŗ��Q</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_StockPriceTaxIncRF = "TaxRate2StockPriceTaxIncRF";

        /// <summary>Title(�ԕi)_�ŗ��Q</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_RetTitle = "TaxRate2RetTitle";
        /// <summary>�d������(�ԕi�l��)_�ŗ��Q</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_DisSlipCntRF = "TaxRate2DisSlipCntRF";
        /// <summary>�d�����z(�ԕi)_�ŗ��Q</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_RetGdsStockTtlPricTaxExcRF = "TaxRate2RetGdsStockTtlPricTaxExcRF";
        /// <summary>�����(�ԕi)_�ŗ��Q</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_RetGdsStockPriceConsTaxRF = "TaxRate2RetGdsStockPriceConsTaxRF";
        /// <summary>���v���z(�ԕi)_�ŗ��Q</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_RetGdsTotalPriceRF = "TaxRate2RetGdsTotalPriceRF";
        #endregion

        #region �u����Őŗ����̑��v
        /// <summary>Title_���̑�</summary>
        public const string CT_StockConfSlipTtl_Other_Title = "OtherTitle";
        /// <summary>�d������_���̑�</summary>
        public const string CT_StockConfSlipTtl_Other_SalSlipCntRF = "OtherSalSlipCntRF";
        /// <summary>�d�����z�v�i�Ŕ����j_���̑�</summary>
        public const string CT_StockConfSlipTtl_Other_StockTtlPricTaxExcRF = "OtherStockTtlPricTaxExcRF";
        /// <summary>�d�����z����Ŋz_���̑�</summary>
        public const string CT_StockConfSlipTtl_Other_StockPriceConsTaxRF = "OtherStockPriceConsTaxRF";
        /// <summary>�d�����z�v�i�ō��݁j_���̑�</summary>
        public const string CT_StockConfSlipTtl_Other_StockPriceTaxIncRF = "OtherStockPriceTaxIncRF";

        /// <summary>Title_���̑�</summary>
        public const string CT_StockConfSlipTtl_Other_RetTitle = "OtherRetTitle";
        /// <summary>�d������_���̑�</summary>
        public const string CT_StockConfSlipTtl_Other_DisSlipCntRF = "OtherDisSlipCntRF";
        /// <summary>�d�����z(�ԕi)_���̑�</summary>
        public const string CT_StockConfSlipTtl_Other_RetGdsStockTtlPricTaxExcRF = "OtherRetGdsStockTtlPricTaxExcRF";
        /// <summary>�����(�ԕi)_���̑�</summary>
        public const string CT_StockConfSlipTtl_Other_RetGdsStockPriceConsTaxRF = "OtherRetGdsStockPriceConsTaxRF";
        /// <summary>���v���z(�ԕi)_���̑�</summary>
        public const string CT_StockConfSlipTtl_Other_RetGdsTotalPriceRF = "OtherRetGdsTotalPriceRF";
        #endregion
        // --- ADD END 3H ���� 2020/02/27 -----<<<<<

        // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
        #region �u����Őŗ���ېŁv
        /// <summary>Title_��ې�</summary>
        public const string CT_StockConfSlipTtl_TaxFree_Title = "TaxFreeTitle";
        /// <summary>�d������_��ې�</summary>
        public const string CT_StockConfSlipTtl_TaxFree_SalSlipCntRF = "TaxFreeSalSlipCntRF";
        /// <summary>�d�����z�v�i�Ŕ����j_��ې�</summary>
        public const string CT_StockConfSlipTtl_TaxFree_StockTtlPricTaxExcRF = "TaxFreeStockTtlPricTaxExcRF";
        /// <summary>�d�����z����Ŋz_��ې�</summary>
        public const string CT_StockConfSlipTtl_TaxFree_StockPriceConsTaxRF = "TaxFreeStockPriceConsTaxRF";
        /// <summary>�d�����z�v�i�ō��݁j_��ې�</summary>
        public const string CT_StockConfSlipTtl_TaxFree_StockPriceTaxIncRF = "TaxFreeStockPriceTaxIncRF";

        /// <summary>Title(�ԕi)_��ې�</summary>
        public const string CT_StockConfSlipTtl_TaxFree_RetTitle = "TaxFreeRetTitle";
        /// <summary>�d������(�ԕi�l��)_��ې�</summary>
        public const string CT_StockConfSlipTtl_TaxFree_DisSlipCntRF = "TaxFreeDisSlipCntRF";
        /// <summary>�d�����z(�ԕi)_��ې�</summary>
        public const string CT_StockConfSlipTtl_TaxFree_RetGdsStockTtlPricTaxExcRF = "TaxFreeRetGdsStockTtlPricTaxExcRF";
        /// <summary>�����(�ԕi)_��ې�</summary>
        public const string CT_StockConfSlipTtl_TaxFree_RetGdsStockPriceConsTaxRF = "TaxFreeRetGdsStockPriceConsTaxRF";
        /// <summary>���v���z(�ԕi)_��ې�</summary>
        public const string CT_StockConfSlipTtl_TaxFree_RetGdsTotalPriceRF = "TaxFreeRetGdsTotalPriceRF";
        #endregion
        // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
      
        /// <summary>�d�����z(�l��)</summary>
        public const string CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF = "DisStockTtlPricTaxExcRF";
        /// <summary>�����(�l��)</summary>
        public const string CT_StockConfSlipTtl_DisStockPriceConsTaxRF = "DisStockPriceConsTaxRF";
        /// <summary>���v���z(�l��)</summary>
        public const string CT_StockConfSlipTtl_DisTotalPriceRF = "DisTotalPriceRF";
        // 2009.01.09 30413 ���� �l���̋��z��ǉ� <<<<<<END
                
		/// <summary>�d�����i�敪</summary>
		public const string CT_StockConfSlipTtl_StockGoodsCdRF = "StockGoodsCdRF";
		/// <summary>�d�����z���v</summary>
		public const string CT_StockConfSlipTtl_StockTotalPriceRF = "StockTotalPriceRF";

        // --- ADD 2008/07/16 -------------------------------->>>>>
        /// <summary>�t�n�d���}�[�N�P</summary>
        public const string CT_StockConfSlipTtl_UoeRemark1 = "UoeRemark1";
        /// <summary>�t�n�d���}�[�N�Q</summary>
        public const string CT_StockConfSlipTtl_UoeRemark2 = "UoeRemark2";
        // --- ADD 2008/07/16 --------------------------------<<<<< 

		public const string COL_KEYBREAK_AR	= "KEYBREAK_AR";				// �L�[�u���C�N

        // ADD 2008/11/04 �s��Ή�[6980] ����ł̈󎚎d�l�̕ύX ---------->>>>>
        // �d���摍�z�\�����@�敪
        public const string CT_StockConfSlipTtl_SuppTtlAmntDspWayCd = "SuppTtlAmntDspWayCd";

        // �d�������œ]�ŕ����R�[�h
        public const string CT_StockConfSlipTtl_SuppCTaxLayCd = "SuppCTaxLayCd";

        // UNDONE:�d�����z����Ŋz�i���Łj
        public const string CT_StockConfSlipTtl_StckPrcConsTaxInclu = "StckPrcConsTaxInclu";

        // UNDONE:�d���l������Ŋz
        public const string CT_StockConfSlipTtl_StckDisTtlTaxInclu = "StckDisTtlTaxInclu";
        // ADD 2008/11/04 �s��Ή�[6980] ����ł̈󎚎d�l�̕ύX ----------<<<<<

		#endregion

		#endregion

		#region Constructor
		/// <summary>
		/// �d���m�F�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �d���m�F�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���܂��B</br>
		/// <br>Programmer : 96186�@���ԗT��</br>
		/// <br>Date       : 2008.01.27</br>
		/// </remarks>
		public MAKON02249EB()
		{
		}
		#endregion
		
		#region Public Methods
		/// <summary>
		/// �f�[�^�Z�b�g�A�f�[�^�e�[�u���ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 96186�@���ԗT��</br>
		/// <br>Date       : 2008.01.16</br>
		/// </remarks>
		public static void SettingDataSet(ref DataSet ds)
		{
			// �e�[�u�������݂��邩�ǂ������`�F�b�N
			if ((ds.Tables.Contains(CT_StockConfSlipTtlDataTable)))
			{
				// TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
				// �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
				ds.Tables[CT_StockConfSlipTtlDataTable].Clear();
			}
			else
			{
                CreateStockConfTable(ref ds);
			}
		}

		#endregion
		
		#region Private Methods
		
		/// <summary>
		/// �d���m�F�\(�`�[)���o���ʍ쐬����
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 96186�@���ԗT��</br>
		/// <br>Date       : 2008.01.16</br>
        /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2020/02/27</br>
		/// </remarks>
		private static void CreateStockConfTable(ref DataSet ds)
		{
			DataTable dt = null;

			// �X�L�[�}�ݒ�
			ds.Tables.Add(CT_StockConfSlipTtlDataTable);
			dt = ds.Tables[CT_StockConfSlipTtlDataTable];

			//���_�R�[�h
			dt.Columns.Add(CT_StockConfSlipTtl_SectionCodeRF, typeof(string));
			dt.Columns[CT_StockConfSlipTtl_SectionCodeRF].DefaultValue = "";
			//���_�K�C�h����
			dt.Columns.Add(CT_StockConfSlipTtl_SectionGuideNmRF, typeof(string));
			dt.Columns[CT_StockConfSlipTtl_SectionGuideNmRF].DefaultValue = "";

            // --- DEL 2008/07/16 -------------------------------->>>>>
            ////���Ӑ�R�[�h
            //dt.Columns.Add(CT_StockConfSlipTtl_CustomerCodeRF, typeof(Int32));
            //dt.Columns[CT_StockConfSlipTtl_CustomerCodeRF].DefaultValue = 0;
            ////���Ӑ旪��
            //dt.Columns.Add(CT_StockConfSlipTtl_CustomerSnmRF, typeof(string));
            //dt.Columns[CT_StockConfSlipTtl_CustomerSnmRF].DefaultValue = "";
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // �d����R�[�h
            dt.Columns.Add(CT_StockConfSlipTtl_SupplierCd, typeof(Int32));
            dt.Columns[CT_StockConfSlipTtl_SupplierCd].DefaultValue = 0;
            // �d���旪��
            dt.Columns.Add(CT_StockConfSlipTtl_SupplierSnm, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_SupplierSnm].DefaultValue = "";
            // --- ADD 2008/07/16 --------------------------------<<<<< 

			//���͓�
			dt.Columns.Add(CT_StockConfSlipTtl_InputDayRF, typeof(DateTime));
			dt.Columns[CT_StockConfSlipTtl_InputDayRF].DefaultValue = DateTime.MinValue;
			//���ד�
			dt.Columns.Add(CT_StockConfSlipTtl_ArrivalGoodsDayRF, typeof(DateTime));
			dt.Columns[CT_StockConfSlipTtl_ArrivalGoodsDayRF].DefaultValue = DateTime.MinValue;
			//�d����
			dt.Columns.Add(CT_StockConfSlipTtl_StockDateRF, typeof(DateTime));
			dt.Columns[CT_StockConfSlipTtl_StockDateRF].DefaultValue = DateTime.MinValue;
			//�d���`��
			dt.Columns.Add(CT_StockConfSlipTtl_SupplierFormalRF, typeof(Int32));
			dt.Columns[CT_StockConfSlipTtl_SupplierFormalRF].DefaultValue = 0;
			//�d���`����
			dt.Columns.Add(CT_StockConfSlipTtl_SupplierFormalNmRF, typeof(string));
			dt.Columns[CT_StockConfSlipTtl_SupplierFormalNmRF].DefaultValue = "";
			//�d���`�[�ԍ�
			dt.Columns.Add(CT_StockConfSlipTtl_SupplierSlipNoRF, typeof(Int32));
			dt.Columns[CT_StockConfSlipTtl_SupplierSlipNoRF].DefaultValue = 0;
			//�����`�[�ԍ�
			dt.Columns.Add(CT_StockConfSlipTtl_PartySaleSlipNumRF, typeof(string));
			dt.Columns[CT_StockConfSlipTtl_PartySaleSlipNumRF].DefaultValue = "";
			//�d���`�[�敪
			dt.Columns.Add(CT_StockConfSlipTtl_SupplierSlipCdRF, typeof(Int32));
			dt.Columns[CT_StockConfSlipTtl_SupplierSlipCdRF].DefaultValue = 0;
			//�d�����z�v�i�Ŕ����j
			dt.Columns.Add(CT_StockConfSlipTtl_StockTtlPricTaxExcRF, typeof(Int64));
			dt.Columns[CT_StockConfSlipTtl_StockTtlPricTaxExcRF].DefaultValue = 0;
			//�d�����z����Ŋz
			dt.Columns.Add(CT_StockConfSlipTtl_StockPriceConsTaxRF, typeof(Int64));
			dt.Columns[CT_StockConfSlipTtl_StockPriceConsTaxRF].DefaultValue = 0;


			//���͓��t(���)
			dt.Columns.Add(CT_StockConfSlipTtl_InputDayNmRF, typeof(string));
			dt.Columns[CT_StockConfSlipTtl_InputDayNmRF].DefaultValue = "";
			//�d�����t(���)
			dt.Columns.Add(CT_StockConfSlipTtl_StockDateNmRF, typeof(string));
			dt.Columns[CT_StockConfSlipTtl_StockDateNmRF].DefaultValue = "";
			//�d���`�[�敪��
			dt.Columns.Add(CT_StockConfSlipTtl_SupplierSlipNmRF, typeof(string));
			dt.Columns[CT_StockConfSlipTtl_SupplierSlipNmRF].DefaultValue = "";
			//�d�����z�v�i�ō��݁j
			dt.Columns.Add(CT_StockConfSlipTtl_StockPriceTaxIncRF, typeof(Int64));
			dt.Columns[CT_StockConfSlipTtl_StockPriceTaxIncRF].DefaultValue = 0;
			//�`�[����(����)
			dt.Columns.Add(CT_StockConfSlipTtl_SalSlipCntRF, typeof(Int32));
			dt.Columns[CT_StockConfSlipTtl_SalSlipCntRF].DefaultValue = 0;
			//�`�[����(�ԕi�l��)
			dt.Columns.Add(CT_StockConfSlipTtl_DisSlipCntRF, typeof(Int32));
			dt.Columns[CT_StockConfSlipTtl_DisSlipCntRF].DefaultValue = 0;
			//�`�[����(���v)
			dt.Columns.Add(CT_StockConfSlipTtl_TotleSlipCntRF, typeof(Int32));
			dt.Columns[CT_StockConfSlipTtl_TotleSlipCntRF].DefaultValue = 0;

			//�d�����z(����)
			dt.Columns.Add(CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF, typeof(Int64));
			dt.Columns[CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF].DefaultValue = 0;
			//�����(����)
			dt.Columns.Add(CT_StockConfSlipTtl_SalStockPriceConsTaxRF, typeof(Int64));
			dt.Columns[CT_StockConfSlipTtl_SalStockPriceConsTaxRF].DefaultValue = 0;
			//���v���z(����)
			dt.Columns.Add(CT_StockConfSlipTtl_SalTotalPriceRF, typeof(Int64));
			dt.Columns[CT_StockConfSlipTtl_SalTotalPriceRF].DefaultValue = 0;

            // 2009.01.09 30413 ���� �l���̋��z��ǉ� >>>>>>START
            ////�d�����z(�ԕi�l��)
            //dt.Columns.Add(CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF, typeof(Int64));
            //dt.Columns[CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF].DefaultValue = 0;
            ////�����(�ԕi�l��)
            //dt.Columns.Add(CT_StockConfSlipTtl_DisStockPriceConsTaxRF, typeof(Int64));
            //dt.Columns[CT_StockConfSlipTtl_DisStockPriceConsTaxRF].DefaultValue = 0;
            ////���v���z(�ԕi�l��)
            //dt.Columns.Add(CT_StockConfSlipTtl_DisTotalPriceRF, typeof(Int64));
            //dt.Columns[CT_StockConfSlipTtl_DisTotalPriceRF].DefaultValue = 0;
            //�d�����z(�ԕi)
            dt.Columns.Add(CT_StockConfSlipTtl_RetGdsStockTtlPricTaxExcRF, typeof(Int64));
            dt.Columns[CT_StockConfSlipTtl_RetGdsStockTtlPricTaxExcRF].DefaultValue = 0;
            //�����(�ԕi)
            dt.Columns.Add(CT_StockConfSlipTtl_RetGdsStockPriceConsTaxRF, typeof(Int64));
            dt.Columns[CT_StockConfSlipTtl_RetGdsStockPriceConsTaxRF].DefaultValue = 0;
            //���v���z(�ԕi)
            dt.Columns.Add(CT_StockConfSlipTtl_RetGdsTotalPriceRF, typeof(Int64));
            dt.Columns[CT_StockConfSlipTtl_RetGdsTotalPriceRF].DefaultValue = 0;

            //�d�����z(�l��)
            dt.Columns.Add(CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF, typeof(Int64));
            dt.Columns[CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF].DefaultValue = 0;
            //�����(�l��)
            dt.Columns.Add(CT_StockConfSlipTtl_DisStockPriceConsTaxRF, typeof(Int64));
            dt.Columns[CT_StockConfSlipTtl_DisStockPriceConsTaxRF].DefaultValue = 0;
            //���v���z(�l��)
            dt.Columns.Add(CT_StockConfSlipTtl_DisTotalPriceRF, typeof(Int64));
            dt.Columns[CT_StockConfSlipTtl_DisTotalPriceRF].DefaultValue = 0;
            // 2009.01.09 30413 ���� �l���̋��z��ǉ� <<<<<<END
        
			//�d�����i�敪
			dt.Columns.Add(CT_StockConfSlipTtl_StockGoodsCdRF, typeof(Int32));
			dt.Columns[CT_StockConfSlipTtl_StockGoodsCdRF].DefaultValue = 0;
			//�d�����z���v
			dt.Columns.Add(CT_StockConfSlipTtl_StockTotalPriceRF, typeof(Int64));
			dt.Columns[CT_StockConfSlipTtl_StockTotalPriceRF].DefaultValue = 0;

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // �t�n�d���}�[�N�P
            dt.Columns.Add(CT_StockConfSlipTtl_UoeRemark1, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_UoeRemark1].DefaultValue = "";

            // �t�n�d���}�[�N�Q
            dt.Columns.Add(CT_StockConfSlipTtl_UoeRemark2, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_UoeRemark2].DefaultValue = "";
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            // �L�[�u���C�N
			dt.Columns.Add(COL_KEYBREAK_AR, typeof(string));
			dt.Columns[COL_KEYBREAK_AR].DefaultValue = "";

            // ADD 2008/11/04 �s��Ή�[6980] ����ł̈󎚎d�l�̕ύX ---------->>>>>
            // �d���摍�z�\�����@�敪
            dt.Columns.Add(CT_StockConfSlipTtl_SuppTtlAmntDspWayCd, typeof(int));
            dt.Columns[CT_StockConfSlipTtl_SuppTtlAmntDspWayCd].DefaultValue = 0;

            // �d�������œ]�ŕ����R�[�h
            dt.Columns.Add(CT_StockConfSlipTtl_SuppCTaxLayCd, typeof(int));
            dt.Columns[CT_StockConfSlipTtl_SuppCTaxLayCd].DefaultValue = 0;

            // UNDONE:�d�����z����Ŋz�i���Łj
            dt.Columns.Add(CT_StockConfSlipTtl_StckPrcConsTaxInclu, typeof(long));
            dt.Columns[CT_StockConfSlipTtl_StckPrcConsTaxInclu].DefaultValue = 0;

            // UNDONE:�d���l������Ŋz
            dt.Columns.Add(CT_StockConfSlipTtl_StckDisTtlTaxInclu, typeof(long));
            dt.Columns[CT_StockConfSlipTtl_StckDisTtlTaxInclu].DefaultValue = 0;
            // ADD 2008/11/04 �s��Ή�[6980] ����ł̈󎚎d�l�̕ύX ----------<<<<<
            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
            // ����Őŗ�
            dt.Columns.Add(CT_Col_ConsTaxRate, typeof(string));
            dt.Columns[CT_Col_ConsTaxRate].DefaultValue = "";
            #region �u����Őŗ��P�v
            // Title_�ŗ��P
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_Title, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_Title].DefaultValue = "";
            // �d������_�ŗ��P
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_SalSlipCntRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_SalSlipCntRF].DefaultValue = "";
            // �d�����z�v�i�Ŕ����j_�ŗ��P
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_StockTtlPricTaxExcRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_StockTtlPricTaxExcRF].DefaultValue = "";
            // �d�����z����Ŋz_�ŗ��P
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_StockPriceConsTaxRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_StockPriceConsTaxRF].DefaultValue = "";
            // �d�����z�v�i�ō��݁j_�ŗ��P
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_StockPriceTaxIncRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_StockPriceTaxIncRF].DefaultValue = "";
            // Title(�ԕi�l��)_�ŗ��P
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_RetTitle, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_RetTitle].DefaultValue = "";
            // �d������(�ԕi�l��)_�ŗ��P
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_DisSlipCntRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_DisSlipCntRF].DefaultValue = "";
            // �d�����z(�ԕi)_�ŗ��P
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_RetGdsStockTtlPricTaxExcRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_RetGdsStockTtlPricTaxExcRF].DefaultValue = "";
            // �����(�ԕi)_�ŗ��P
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_RetGdsStockPriceConsTaxRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_RetGdsStockPriceConsTaxRF].DefaultValue = "";
            // ���v���z(�ԕi)_�ŗ��P
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_RetGdsTotalPriceRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_RetGdsTotalPriceRF].DefaultValue = "";
            #endregion
            #region �u����Őŗ��Q�v
            // Title_�ŗ��Q
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_Title, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_Title].DefaultValue = "";
            // �d������_�ŗ��Q
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_SalSlipCntRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_SalSlipCntRF].DefaultValue = "";
            // �d�����z�v�i�Ŕ����j_�ŗ��Q
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_StockTtlPricTaxExcRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_StockTtlPricTaxExcRF].DefaultValue = "";
            // �d�����z����Ŋz_�ŗ��Q
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_StockPriceConsTaxRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_StockPriceConsTaxRF].DefaultValue = "";
            // �d�����z�v�i�ō��݁j_�ŗ��Q
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_StockPriceTaxIncRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_StockPriceTaxIncRF].DefaultValue = "";
            // Title(�ԕi�l��)_�ŗ��Q
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_RetTitle, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_RetTitle].DefaultValue = "";
            // �d������(�ԕi�l��)_�ŗ��Q
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_DisSlipCntRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_DisSlipCntRF].DefaultValue = "";
            // �d�����z(�ԕi)_�ŗ��Q
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_RetGdsStockTtlPricTaxExcRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_RetGdsStockTtlPricTaxExcRF].DefaultValue = "";
            // �����(�ԕi)_�ŗ��Q
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_RetGdsStockPriceConsTaxRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_RetGdsStockPriceConsTaxRF].DefaultValue = "";
            // ���v���z(�ԕi)_�ŗ��Q
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_RetGdsTotalPriceRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_RetGdsTotalPriceRF].DefaultValue = "";
            #endregion
            #region �u����Őŗ����̑��v
            // Title_���̑�
            dt.Columns.Add(CT_StockConfSlipTtl_Other_Title, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_Title].DefaultValue = "";
            // �d������_���̑�
            dt.Columns.Add(CT_StockConfSlipTtl_Other_SalSlipCntRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_SalSlipCntRF].DefaultValue = "";
            // �d�����z�v�i�Ŕ����j_���̑�
            dt.Columns.Add(CT_StockConfSlipTtl_Other_StockTtlPricTaxExcRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_StockTtlPricTaxExcRF].DefaultValue = "";
            // �d�����z����Ŋz_���̑�
            dt.Columns.Add(CT_StockConfSlipTtl_Other_StockPriceConsTaxRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_StockPriceConsTaxRF].DefaultValue = "";
            // �d�����z�v�i�ō��݁j_���̑�
            dt.Columns.Add(CT_StockConfSlipTtl_Other_StockPriceTaxIncRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_StockPriceTaxIncRF].DefaultValue = "";
            // Title(�ԕi�l��)_���̑�
            dt.Columns.Add(CT_StockConfSlipTtl_Other_RetTitle, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_RetTitle].DefaultValue = "";
            // �d������(�ԕi�l��)_���̑�
            dt.Columns.Add(CT_StockConfSlipTtl_Other_DisSlipCntRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_DisSlipCntRF].DefaultValue = "";
            // �d�����z(�ԕi)_���̑�
            dt.Columns.Add(CT_StockConfSlipTtl_Other_RetGdsStockTtlPricTaxExcRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_RetGdsStockTtlPricTaxExcRF].DefaultValue = "";
            // �����(�ԕi)_���̑�
            dt.Columns.Add(CT_StockConfSlipTtl_Other_RetGdsStockPriceConsTaxRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_RetGdsStockPriceConsTaxRF].DefaultValue = "";
            // ���v���z(�ԕi)_���̑�
            dt.Columns.Add(CT_StockConfSlipTtl_Other_RetGdsTotalPriceRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_RetGdsTotalPriceRF].DefaultValue = "";
            #endregion
            // --- ADD END 3H ���� 2020/02/27 -----<<<<<

            // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
            #region �u����Őŗ���ېŁv
            // Title_��ې�
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_Title, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_Title].DefaultValue = "";
            // �d������_��ې�
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_SalSlipCntRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_SalSlipCntRF].DefaultValue = "";
            // �d�����z�v�i�Ŕ����j_��ې�
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_StockTtlPricTaxExcRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_StockTtlPricTaxExcRF].DefaultValue = "";
            // �d�����z����Ŋz_��ې�
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_StockPriceConsTaxRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_StockPriceConsTaxRF].DefaultValue = "";
            // �d�����z�v�i�ō��݁j_��ې�
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_StockPriceTaxIncRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_StockPriceTaxIncRF].DefaultValue = "";
            // Title(�ԕi�l��)_��ې�
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_RetTitle, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_RetTitle].DefaultValue = "";
            // �d������(�ԕi�l��)_��ې�
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_DisSlipCntRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_DisSlipCntRF].DefaultValue = "";
            // �d�����z(�ԕi)_��ې�
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_RetGdsStockTtlPricTaxExcRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_RetGdsStockTtlPricTaxExcRF].DefaultValue = "";
            // �����(�ԕi)_��ې�
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_RetGdsStockPriceConsTaxRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_RetGdsStockPriceConsTaxRF].DefaultValue = "";
            // ���v���z(�ԕi)_��ې�
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_RetGdsTotalPriceRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_RetGdsTotalPriceRF].DefaultValue = "";
            #endregion
            // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
		}

		#endregion
	}
}